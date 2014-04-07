using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TaoAnJu.Util;
public partial class admin_LogInfo_List : CAdminCookiePage
{
    DataTable dt;
    int RecordCount = 0;
    int PageNum = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        lit_Script.Text = "";
        if (!Page.IsPostBack)
        {
            InitData();
        }
    }
    protected void InitData()
    {
        DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
        try
        {
            string strFilter = "int_LogId>0";
            if (!string.IsNullOrEmpty(Request["page"]))
            {
                PageNum = int.Parse(Request["page"]);
            }
            if (!string.IsNullOrEmpty(Request["logtype"]))
            {
                strFilter += " and vc_LogType='" + Request["logtype"] + "'";
                ddlLogType.SelectedValue = Request["logtype"];
            }
            if (!string.IsNullOrEmpty(Request["startdate"]))
            {
                strFilter += " and dt_CreateDate>='" + Request["startdate"] + "'";
                txt_StartDate.Text = Request["startdate"];
            }
            if (!string.IsNullOrEmpty(Request["enddate"]))
            {
                strFilter += " and dt_CreateDate<'" + Convert.ToDateTime(Request["enddate"]).AddDays(1).ToString () + "'";
                txt_EndDate.Text = Request["enddate"];
            }
            if (!string.IsNullOrEmpty(Request["logcontent"]))
            {
                strFilter += " and vc_Content like '%" + Request["logcontent"] + "%'";
                txt_Content.Text = Request["logcontent"];
            }
            string sql = "SELECT count(*) FROM tb_LogInfo where " + strFilter;
            dt = db.ExecuteQuery(sql).Tables[0];
            RecordCount = (int)dt.Rows[0][0];

            dt = RiSystem.CurrentDataPage(db, "tb_LogInfo", "*", strFilter, 30, PageNum, "int_LogId", true);

            PageNumBar1.CurrPage = PageNum;
            PageNumBar1.RecordCount = RecordCount;
            PageNumBar1.PageSize = 30;

            GridView1.DataSource = dt;
            GridView1.DataBind();
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string strcon = "";
        string strpar = "";
        if (ddlLogType.SelectedIndex > 0)
        {
            strpar = "logtype=" + Server.UrlEncode(ddlLogType.Text);
            strcon = "&";
        }
        if (txt_StartDate.Text != "")
        {
            strpar += strcon + "startdate=" + Server.UrlEncode(txt_StartDate.Text);
            strcon = "&";
        }
        if (txt_EndDate.Text != "")
        {
            strpar += strcon + "enddate=" + Server.UrlEncode(txt_EndDate.Text);
            strcon = "&";
        }
        if (txt_Content.Text.Trim() != "")
        {
            strpar +=strcon +"logcontent="+Server.UrlEncode (txt_Content.Text );
        }
        string url = "LogInfo_List.aspx";
        if (strpar != "")
        {
            url += "?" + strpar;
        }
        Response.Redirect(url);
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex >= 0)
        {
            e.Row.Cells[0].Text = Convert.ToString((PageNumBar1.CurrPage - 1) * PageNumBar1.PageSize + e.Row.RowIndex + 1);
        }
    }
}