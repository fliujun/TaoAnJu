using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TaoAnJu.Util;
public partial class admin_FunRole : CAdminCookiePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lit_Script.Text = "";
        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["funid"]))
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
            string sql = "select int_RoleId,vc_RoleName from v_RoleFun where int_FunId=" + Request["funid"] + " order by vc_RoleName";
            DataTable dt = db.ExecuteQuery(sql).Tables[0];
            lit_Msg.Text = "共有记录 " + dt.Rows.Count.ToString() + " 条";
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
}