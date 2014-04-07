using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TaoAnJu.Util;
public partial class admin_TableInfo_List : CAdminCookiePage
{
    DataTable dt;
    int RecordCount = 0;
    int PageNum = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        lit_Script.Text = "";
        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["tbid"]))
            {
                InitData();
            }
        }
    }
    private void InitData()
    {
        DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
        try
        {
            lit_TbName.Text = "{" + RiSystem.getTableNameById(db, Convert.ToInt32(Request["tbid"]))+"}";
            string strFilter = "int_TbId=" + Request["tbid"];
            string sql = "SELECT count(*) FROM tb_FieldInfo where " + strFilter;
            dt = db.ExecuteQuery(sql).Tables[0];
            RecordCount = (int)dt.Rows[0][0];

            dt = RiSystem.CurrentDataPage(db, "tb_FieldInfo", "*", strFilter, RecordCount, PageNum, "int_ShowOrder", false);
            DataColumn dc = new DataColumn("vc_DataNormal", typeof(string));
            dt.Columns.Add(dc);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["vc_DataNormal"] = RiSystem.getDataNormalById(db, Convert.ToInt32(dt.Rows[i]["int_DataNormal"])).Replace(",", "");
            }
            PageNumBar1.CurrPage = PageNum;
            PageNumBar1.RecordCount = RecordCount;
            PageNumBar1.PageSize = RecordCount;
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
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex >= 0)
        {
            if (e.Row.Cells[2].Text == "0")
            {
                e.Row.Cells[2].Text = "";
            }
            e.Row.Cells[4].Text = "<div><div align=\"left\" style=\"float:left;\">" + e.Row.Cells[4].Text + "</div><div align=\"right\" style=\"float:right;\"><a href=\"javascript:JqueryDialog.Open1('数据规范\', 'SetDataNormal.aspx?fiid=" + e.Row.Cells[0].Text + "', 310, 120, false, false, true, 'no');\"><font color=\"blue\">设置</font></a></div></div>";
        }
    }
}