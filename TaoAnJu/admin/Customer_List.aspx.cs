using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using TaoAnJu.Util;
public partial class admin_Customer_List : CAdminCookiePage
{
    DataTable dt;
    int RecordCount = 0;
    int PageNum = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        lit_Script.Text = "";
        btnAdd.Attributes.Add("href", "javascript:JqueryDialog.Open1(\"添加客户\", \"Customer_Add.aspx\", 420, 380, false, false, true, 'no');");
        if (!Page.IsPostBack)
        {
            DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
            try
            {
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
    protected void InitData(DsConnectionDB db)
    {
        string strFilter = "int_Cid>0";
        if (LoginInfo.UserType == "2")
        {
            strFilter += " and int_UserId=" + LoginInfo.UserId.ToString();
        }
        if (!string.IsNullOrEmpty(Request["page"]))
        {
            PageNum = int.Parse(Request["page"]);
        }
        if (!string.IsNullOrEmpty(Request["mobile"]))
        {
            strFilter += " and vc_Mobile='" + Request["mobile"] + "'";
        }
        if (!string.IsNullOrEmpty(Request["cname"]))
        {
            strFilter += " and vc_Name='" + Request["cname"] + "'";
        }
        if (!string.IsNullOrEmpty(Request["occupation"]))
        {
            strFilter += " and vc_Occupation like '%" + Request["occupation"] + "%'";
        }
        if (!string.IsNullOrEmpty(Request["use"]))
        {
            strFilter += " and vc_Use like '%" + Request["use"] + "%'";
        }
        if (!string.IsNullOrEmpty(Request["rname"]))
        {
            strFilter += " and vc_RealName='" + Request["rname"] + "'";
        }
        string sql = "SELECT count(*) FROM v_Customer where " + strFilter;
        dt = db.ExecuteQuery(sql).Tables[0];
        RecordCount = (int)dt.Rows[0][0];
        dt = RiSystem.CurrentDataPage(db, "v_Customer", "*", strFilter, PageNumBar1.PageSize, PageNum, "int_Cid", true);

        PageNumBar1.CurrPage = PageNum;
        PageNumBar1.RecordCount = RecordCount;

        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"添加客户\", \"Customer_Add.aspx\", 420, 380, false, false, true, 'no');");
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        int SelectCount = 0;
        string userid = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (GridView1.Rows[i].RowIndex >= 0)
            {
                CheckBox chk = (CheckBox)GridView1.Rows[i].FindControl("chkItem");
                if (chk.Checked)
                {
                    ++SelectCount;
                    userid = GridView1.Rows[i].Cells[1].Text;
                }
            }
        }
        if (SelectCount == 0)
        {
            lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"系统提示\", \"Msg.aspx?msg=请选择要修改的客户\", 240, 110, false, false, true, 'no');");
            return;
        }
        if (SelectCount > 1)
        {
            lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"系统提示\", \"Msg.aspx?msg=请选择一个客户进行修改\", 260, 110, false, false, true, 'no');");
            return;
        }
        lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"修改客户\", \"Customer_Add.aspx?cid=" + userid + "\", 420, 380, false, false, true, 'no');");
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
            lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"系统提示\", \"Msg.aspx?msg=请选择要删除的客户\", 240, 110, false, false, true, 'no');");
            return;
        }
        else
        {
            IdList = IdList.Substring(0, IdList.Length - 1);
        }

        sql = "delete from tb_Customer where int_CId in(" + IdList + ")";
        UserOpInfo ui = new UserOpInfo("删除", "客户", sql, IdList);
        Session["UserOpInfo"] = ui;
        lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"系统提示\", \"Msg.aspx?optype=submit&msg=请确定是否删除所选记录\", 260, 110, false, false, true, 'no');");
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            CheckBox chk = (CheckBox)e.Row.FindControl("chkAll");
            chk.Attributes.Add("onclick", "javascript:return SelectAll(this.checked,this.id)");
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string strcon = "";
        string strpar = "";
        if (txt_Mobile.Text.Trim() != "")
        {
            strpar = "mobile=" + Server.UrlEncode(txt_Mobile.Text.Trim());
            strcon = "&";
        }
        if (txt_Name.Text.Trim() != "")
        {
            strpar += strcon + "cname=" + Server.UrlEncode(txt_Name.Text.Trim());
            strcon = "&";
        }
        if (txt_Occupation.Text.Trim() != "")
        {
            strpar += strcon + "occupation=" + Server.UrlEncode(txt_Occupation.Text.Trim());
            strcon = "&";
        }
        if (txt_Use.Text.Trim() != "")
        {
            strpar += strcon + "use=" + Server.UrlEncode(txt_Use.Text.Trim());
            strcon = "&";
        }
        if (txt_RealName.Text.Trim() != "")
        {
            strpar += strcon + "rname=" + Server.UrlEncode(txt_RealName.Text.Trim());
            strcon = "&";
        }
        string url = "Customer_List.aspx";
        if (strpar != "")
        {
            url += "?" + strpar;
        }
        Response.Redirect(url);
    }
}