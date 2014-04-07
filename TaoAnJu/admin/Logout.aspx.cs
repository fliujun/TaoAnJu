using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaoAnJu.Util;
public partial class admin_Logout :CAdminCookiePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
        try
        {
            RiSystem.AddLog(db, "退出", LoginInfo.RealName + "退出淘安居后台管理", Request.UserHostAddress, LoginInfo.UserId);
        }
        finally
        {
            if (db != null)
            {
                db.Close();
            }
        }
        CUserAuthen.ClearLoginTicket(Response);
        Response.Redirect("LoginPage.aspx");
    }
}