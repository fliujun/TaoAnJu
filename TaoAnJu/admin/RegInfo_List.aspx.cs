using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using TaoAnJu.Util;
public partial class admin_RegInfo_List : CAdminCookiePage
{
    DataTable dt;
    int RecordCount = 0;
    int PageNum = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
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
        string strFields = "*";
        string strFilter = "int_RId>0";
        if (!string.IsNullOrEmpty(Request["page"]))
        {
            PageNum = int.Parse(Request["page"]);
        }
        if (!string.IsNullOrEmpty(Request["iname"]))
        {
            strFilter += " and vc_ItemName ='" + Request["iname"] + "'";
        }
        string sql = "SELECT count(*) FROM v_RegInfo where " + strFilter;
        dt = db.ExecuteQuery(sql).Tables[0];
        RecordCount = (int)dt.Rows[0][0];
        dt = RiSystem.CurrentDataPage(db, "v_RegInfo", strFields, strFilter, PageNumBar1.PageSize, PageNum, "int_RId", false);

        PageNumBar1.CurrPage = PageNum;
        PageNumBar1.RecordCount = RecordCount;

        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string strcon = "";
        string strpar = "";
        if (txt_ItemName.Text.Trim() != "")
        {
            strpar = "iname=" + Server.UrlEncode(txt_ItemName.Text.Trim());
            strcon = "&";
        }
        string url = "RegInfo_List.aspx";
        if (strpar != "")
        {
            url += "?" + strpar;
        }
        Response.Redirect(url);
    }
}