using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TaoAnJu.Util;
public partial class admin_RoleUser : CAdminCookiePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lit_Script.Text = "";
        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["roleid"]))
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
            string sql = "select int_UserId,vc_RealName from v_UserRole where int_RoleId=" + Request["roleid"] + " order by vc_RealName";
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