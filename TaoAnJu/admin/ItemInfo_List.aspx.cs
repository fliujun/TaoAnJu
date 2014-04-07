using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using TaoAnJu.Util;

public partial class admin_ItemInfo_List : CAdminCookiePage
{
    DataTable dt;
    int RecordCount = 0;
    int PageNum = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        lit_Script.Text = "";
        btnAdd.Attributes.Add("href", "javascript:JqueryDialog.Open1(\"添加房产项目\", \"ItemInfo_Add.aspx\", 1050, 700, false, false, true, 'no');");
        if (!Page.IsPostBack)
        {
            DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
            try
            {
                InitConfigData(db);
                InitData(db);
            }
            catch (System.Exception ee)
            {
                Loger.logErr("失败", ee);
            }
            finally
            {
                if (null != db) { db.Close(); }
            }
        }
    }
    protected void InitConfigData(DsConnectionDB db)
    {
        string sql = "select vc_Name from tb_DataConfigInfo where int_ParentId in(select int_DataNormal from tb_FieldInfo where vc_FieldName='vc_SalesStatus' and int_TbId in(select int_TbId from tb_TableInfo where vc_TableName='tb_ItemInfo'))"; ;
        dt = db.ExecuteQuery(sql).Tables[0];
        ddl_SalesStatus.Items.Clear();
        ddl_SalesStatus.Items.Add("全部");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ddl_SalesStatus.Items.Add(dt.Rows[i]["vc_Name"].ToString());
        }
    }
    protected void InitData(DsConnectionDB db)
    {
        string strFields = "int_ItemId,vc_ItemName,vc_City,vc_Area,vc_Developer,dt_OpeningTime,dec_ReferencePrice,int_IsPay,vc_SalesStatus,dt_CreateDate,int_Status";
        string strFilter = "int_ItemId>0";
        if (!string.IsNullOrEmpty(Request["page"]))
        {
            PageNum = int.Parse(Request["page"]);
        }
        if (!string.IsNullOrEmpty(Request["iname"]))
        {
            strFilter += " and vc_ItemName like '%" + Request["iname"] + "%'";
        }
        if (!string.IsNullOrEmpty(Request["dev"]))
        {
            strFilter += " and vc_Developer like '%" + Request["dev"] + "'";
        }
        if (!string.IsNullOrEmpty(Request["ispay"]))
        {
            strFilter += " and int_IsPay=" + Request["ispay"];
        }
        if (!string.IsNullOrEmpty(Request["sstatus"]))
        {
            strFilter += " and vc_SalesStatus='" + Request["sstatus"] + "'";
        }
        string sql = "SELECT count(*) FROM tb_ItemInfo where " + strFilter;
        dt = db.ExecuteQuery(sql).Tables[0];
        RecordCount = (int)dt.Rows[0][0];
        dt = RiSystem.CurrentDataPage(db, "tb_ItemInfo", strFields, strFilter, PageNumBar1.PageSize, PageNum, "int_ItemId", true);

        PageNumBar1.CurrPage = PageNum;
        PageNumBar1.RecordCount = RecordCount;

        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"添加房产项目\", \"ItemInfo_Add.aspx\", 1050, 700, false, false, true, 'no');");
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        int SelectCount = 0;
        string itemid = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (GridView1.Rows[i].RowIndex >= 0)
            {
                CheckBox chk = (CheckBox)GridView1.Rows[i].FindControl("chkItem");
                if (chk.Checked)
                {
                    ++SelectCount;
                    itemid = GridView1.Rows[i].Cells[1].Text;
                }
            }
        }
        if (SelectCount == 0)
        {
            lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"系统提示\", \"Msg.aspx?msg=请选择要修改的房产项目\", 240, 110, false, false, true, 'no');");
            return;
        }
        if (SelectCount > 1)
        {
            lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"系统提示\", \"Msg.aspx?msg=请选择一个房产项目进行修改\", 260, 110, false, false, true, 'no');");
            return;
        }
        lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"修改房产项目\", \"ItemInfo_Add.aspx?itemid=" + itemid + "\",1050, 700, false, false, true, 'no');");
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int SelectCount = 0;
        string IdList = "";
        string sql = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (GridView1.Rows[i].RowIndex >= 0)
            {
                CheckBox chk = (CheckBox)GridView1.Rows[i].FindControl("chkItem");
                if (chk.Checked)
                {
                    ++SelectCount;
                    IdList += GridView1.Rows[i].Cells[1].Text + ",";
                }
            }
        }
        if (SelectCount == 0)
        {
            lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"系统提示\", \"Msg.aspx?msg=请选择要删除的房产项目\", 240, 110, false, false, true, 'no');");
            return;
        }
        else
        {
            IdList = IdList.Substring(0, IdList.Length - 1);
        }

        sql = "delete from tb_ItemInfo where int_ItemId in(" + IdList + ");delete from tb_PicInfo where int_ItemId in(" + IdList + ");delete from tb_ViewInfo where int_ItemId in(" + IdList + ");";
        UserOpInfo ui = new UserOpInfo("删除", "房产项目", sql, IdList);
        Session["UserOpInfo"] = ui;
        lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"系统提示\", \"Msg.aspx?optype=submit&msg=请确定是否删除所选记录\", 260, 110, false, false, true, 'no');");
    }
    protected void btnAddPic_Click(object sender, EventArgs e)
    {
        int SelectCount = 0;
        string itemid = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (GridView1.Rows[i].RowIndex >= 0)
            {
                CheckBox chk = (CheckBox)GridView1.Rows[i].FindControl("chkItem");
                if (chk.Checked)
                {
                    ++SelectCount;
                    itemid = GridView1.Rows[i].Cells[1].Text;
                }
            }
        }
        if (SelectCount == 0)
        {
            lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"系统提示\", \"Msg.aspx?msg=请选择要添加图片的房产项目\", 240, 110, false, false, true, 'no');");
            return;
        }
        if (SelectCount > 1)
        {
            lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"系统提示\", \"Msg.aspx?msg=请选择一个房产项目添加图片\", 260, 110, false, false, true, 'no');");
            return;
        }
        lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"房产项目添加图片\", \"PicInfo_List.aspx?itemid=" + itemid + "\", 1024, 646, false, false, true, 'no');");
    }
    protected void btnAddView_Click(object sender, EventArgs e)
    {
        int SelectCount = 0;
        string itemid = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (GridView1.Rows[i].RowIndex >= 0)
            {
                CheckBox chk = (CheckBox)GridView1.Rows[i].FindControl("chkItem");
                if (chk.Checked)
                {
                    ++SelectCount;
                    itemid = GridView1.Rows[i].Cells[1].Text;
                }
            }
        }
        if (SelectCount == 0)
        {
            lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"系统提示\", \"Msg.aspx?msg=请选择要添加视频的房产项目\", 240, 110, false, false, true, 'no');");
            return;
        }
        if (SelectCount > 1)
        {
            lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"系统提示\", \"Msg.aspx?msg=请选择一个房产项目添加视频\", 260, 110, false, false, true, 'no');");
            return;
        }
        lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"房产项目添加视频\", \"ViewInfo_List.aspx?itemid=" + itemid + "\", 940, 600, false, false, true, 'no');");
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            CheckBox chk = (CheckBox)e.Row.FindControl("chkAll");
            chk.Attributes.Add("onclick", "javascript:return SelectAll(this.checked,this.id)");
        }
        if (e.Row.RowIndex >= 0)
        {
            e.Row.Cells[7].Text = (e.Row.Cells[7].Text != "0") ? e.Row.Cells[7].Text + "/㎡" : "";
            e.Row.Cells[8].Text = (e.Row.Cells[8].Text == "1") ? "是" : "否";
            e.Row.Cells[11].Text = (e.Row.Cells[11].Text == "1") ? "正常" : "<font color=\"red\">停用</font>";
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string strcon = "";
        string strpar = "";
        if (txt_ItemName.Text.Trim ()!="")
        {
            strpar = "iname=" + Server.UrlEncode(txt_ItemName.Text.Trim ());
            strcon = "&";
        }
        if (txt_Developer.Text.Trim () != "")
        {
            strpar += strcon + "dev=" + Server.UrlEncode(txt_Developer.Text.Trim());
            strcon = "&";
        }
        if (ddl_IsPay.Text !="全部")
        {
            strpar += strcon + "ispay=" + Server.UrlEncode(ddl_IsPay.SelectedIndex.ToString ());
            strcon = "&";
        }
        if (ddl_SalesStatus.Text !="全部")
        {
            strpar += strcon + "sstatus=" + Server.UrlEncode(ddl_SalesStatus.Text);
        }
        string url = "ItemInfo_List.aspx";
        if (strpar != "")
        {
            url += "?" + strpar;
        }
        Response.Redirect(url);
    }
}