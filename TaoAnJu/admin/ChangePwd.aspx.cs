using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using TaoAnJu.Util;
public partial class admin_ChangePwd : CAdminCookiePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lit_Msg.Text = "";
        lit_Script.Text = "";
        if (!string.IsNullOrEmpty(Request["action"]) && Request["action"].ToString().ToLower() == "submit")
        {
            Regex re = new Regex(@"^(?!\D+$)(?!\d+$)[a-zA-Z0-9_~!@#$%^&*()]{8,16}$");
            if (txt_oldpwd.Text == "")
            {
                lit_Msg.Text = "旧密码不能为空！";
                return;
            }
            if (!re.IsMatch(txt_oldpwd.Text.Trim()))
            {
                lit_Msg.Text = "旧密码不符合规则，请重新输入！";
                return;
            }
            if (txt_newpwd.Text == "")
            {
                lit_Msg.Text = "新密码不能为空！";
                return;
            }
            
            if (!re.IsMatch(txt_newpwd.Text.Trim()))
            {
                lit_Msg.Text = "新密码不符合规则，请重新设置！";
                return;
            }
            if (txt_validepwd.Text != txt_newpwd.Text)
            {
                lit_Msg.Text = "密码确认不匹配！";
                return;
            }
            DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
            try
            {
                string EncodPwd = CSecretProcess.Encrypt(txt_oldpwd.Text, RiSystem.PwdSecret);
                string sql = "select count(*) from tb_UserInfo where int_UserId="+LoginInfo.UserId.ToString ()+" and vc_LoginPwd='"+EncodPwd+"'";
                if ((int)db.ExecuteScalar(sql) == 0)
                {
                    lit_Msg.Text = "旧密码输入错误，请重新输入！";
                    return;
                }
                sql = "update tb_UserInfo set dt_LastPwdChangeDate='"+DateTime.Now.ToString ()+"',vc_LoginPwd='" + EncodPwd + "' where int_UserId=" + LoginInfo.UserId.ToString();
                db.ExecuteNonQuery(sql);
                RiSystem.AddLog(db, "修改", LoginInfo.RealName + "进行 密码 修改操作", Request.UserHostAddress, LoginInfo.UserId);
                lit_Script.Text = StringTools.AddScript("JqueryDialog.Close();");
            }
            catch (System.Exception ee)
            {
                Loger.logErr("失败", ee);
            }
            finally
            {
                if (db != null)
                {
                    db.Close();
                }
            }
        }
    }
}