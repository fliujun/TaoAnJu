using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using TaoAnJu.Util;

public partial class admin_AdInfo_List : CAdminCookiePage
{
    DataTable dt;
    int RecordCount = 0;
    int PageNum = 1;
    string LoadAdImagePath = System.Configuration.ConfigurationManager.AppSettings["LoadAdImagePath"];
    protected void Page_Load(object sender, EventArgs e)
    {
        lit_Script.Text = "";
        btnAdd.Attributes.Add("href", "javascript:JqueryDialog.Open1(\"添加广告\", \"AdInfo_Add.aspx\", 500, 440, false, false, true, 'no');");
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
        string sql = "select vc_Name from tb_DataConfigInfo where int_ParentId in(select int_DataNormal from tb_FieldInfo where vc_FieldName='vc_AdType' and int_TbId in(select int_TbId from tb_TableInfo where vc_TableName='tb_AdInfo'))"; ;
        dt = db.ExecuteQuery(sql).Tables[0];
        ddl_AdType.Items.Clear();
        ddl_AdType.Items.Add("全部");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ddl_AdType.Items.Add(dt.Rows[i]["vc_Name"].ToString());
        }
    }
    protected void InitData(DsConnectionDB db)
    {
        string strFields = "*";
        string strFilter = "int_AId>0";
        if (!string.IsNullOrEmpty(Request["page"]))
        {
            PageNum = int.Parse(Request["page"]);
        }
        if (!string.IsNullOrEmpty(Request["title"]))
        {
            strFilter += " and vc_AdTitle like '%" + Request["title"] + "%'";
        }
        if (!string.IsNullOrEmpty(Request["atype"]))
        {
            strFilter += " and vc_AdType='" + Request["atype"] + "'";
        }
        string sql = "SELECT count(*) FROM tb_AdInfo where " + strFilter;
        dt = db.ExecuteQuery(sql).Tables[0];
        RecordCount = (int)dt.Rows[0][0];
        dt = RiSystem.CurrentDataPage(db, "tb_AdInfo", strFields, strFilter, PageNumBar1.PageSize, PageNum, "int_AId", true);

        PageNumBar1.CurrPage = PageNum;
        PageNumBar1.RecordCount = RecordCount;

        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"添加广告\", \"AdInfo_Add.aspx\", 500, 440, false, false, true, 'no');");
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
            lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"系统提示\", \"Msg.aspx?msg=请选择要修改的广告\", 240, 110, false, false, true, 'no');");
            return;
        }
        if (SelectCount > 1)
        {
            lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"系统提示\", \"Msg.aspx?msg=请选择一条广告进行修改\", 260, 110, false, false, true, 'no');");
            return;
        }
        lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"修改广告\", \"AdInfo_Add.aspx?aid=" + itemid + "\", 500,440, false, false, true, 'no');");
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
            lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"系统提示\", \"Msg.aspx?msg=请选择要删除的广告\", 240, 110, false, false, true, 'no');");
            return;
        }
        else
        {
            IdList = IdList.Substring(0, IdList.Length - 1);
        }

        sql = "delete from tb_AdInfo where int_AId in(" + IdList + ")";
        UserOpInfo ui = new UserOpInfo("删除", "广告", sql, IdList);
        Session["UserOpInfo"] = ui;
        lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"系统提示\", \"Msg.aspx?optype=submit&msg=请确定是否删除所选记录\", 260, 110, false, false, true, 'no');");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string strcon = "";
        string strpar = "";
        if (txt_AdTitle.Text.Trim() != "")
        {
            strpar = "title=" + Server.UrlEncode(txt_AdTitle.Text.Trim());
            strcon = "&";
        }
        if (ddl_AdType.Text != "全部")
        {
            strpar += strcon + "atype=" + Server.UrlEncode(ddl_AdType.Text);
        }
        string url = "AdInfo_List.aspx";
        if (strpar != "")
        {
            url += "?" + strpar;
        }
        Response.Redirect(url);
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
            string url = Request.Url.AbsolutePath;
            url = url.Substring(0, url.IndexOf("admin"));
            e.Row.Cells[4].Text = "<a href =\"" + url + LoadAdImagePath.Replace("\\", "/") + e.Row.Cells[4].Text + "\" target=\"_blank\"><font color=\"red\">查看图片</font></a>";
            e.Row.Cells[5].Text = "<a href =\"" + e.Row.Cells[5].Text + "\" target=\"_blank\"><font color=\"blue\">打开链接</font></a>";
            e.Row.Cells[8].Text = (e.Row.Cells[8].Text == "1") ? "正常" : "<font color=\"red\">停用</font>";
        }
    }
}