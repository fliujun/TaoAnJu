using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaoAnJu.Util;
public partial class admin_Index : CAdminCookiePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lit_LoginInfo.Text = "今天是 " + DateTime.Now.ToString("yyyy年MM月dd日") + "，欢迎您 " + LoginInfo.LoginName + "（" + LoginInfo.RealName + "） <a href=\"javascript:changepwd()\">";
        lit_LoginInfo.Text += "<font color=\"red\">修改密码</font></a>";
    }
}