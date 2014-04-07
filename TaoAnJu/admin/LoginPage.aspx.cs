using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Text.RegularExpressions;
using TaoAnJu.Util;
public partial class admin_LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.ViewState["GUID"] = System.Guid.NewGuid().ToString();
        this.lblGUID.Text = this.ViewState["GUID"].ToString();
        RiSystem.InitSubmitButton(this.Page, btn_Login.ID);
    }
    protected void btn_Login_Click(object sender, EventArgs e)
    {
        lit_Msg.Text = "";
        if (string.IsNullOrEmpty(txt_LoginName.Text.Trim()))
        {
            lit_Msg.Text = "请输入账号！"; 
            return;
        }
        //账号长度为8-16个字符，必须由字母开头，字母或数字或下划线组成的字符串！
        Regex re = new Regex(@"^[a-zA-Z][a-zA-Z0-9_]{7,15}$");
        if (!re.IsMatch(txt_LoginName.Text.Trim ()))
        {
            lit_Msg.Text = "您的账号不符合规则，请重新输入！";
            txt_LoginName.Text = "";
            return;
        }
        if (string.IsNullOrEmpty(txt_LoginPwd.Text.Trim()))
        {
            lit_Msg.Text = "请输入密码！";
            return;
        }
        //密码长度为8-16个字符，必须是字母和数字混合，可以有下划线或特殊字符！
        re = new Regex(@"^(?!\D+$)(?!\d+$)[a-zA-Z0-9_~!@#$%^&*()]{8,16}$");
        if (!re.IsMatch(txt_LoginPwd.Text.Trim ()))
        {
            lit_Msg.Text = "您的密码不符合规则，请重新输入！";
            txt_LoginPwd.Text = "";
            return;
        }
        if (string.IsNullOrEmpty(txt_Code.Text.Trim()))
        {
            lit_Msg.Text = "请输入验证码！";
            return;
        }
        if (txt_Code.Text.Trim().ToLower () != Session["CheckCode"].ToString().ToLower ())
        {
            lit_Msg.Text = "验证码输入错误，请重新输入！";
            txt_Code.Text = "";
            return;
        }
        txt_Code.Text = "";
        string EncodPwd = CSecretProcess.Encrypt(txt_LoginPwd.Text, RiSystem.PwdSecret);
        DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
        try
        {
            string FunIdList = "";
            string sql = "select int_UserId,vc_RealName,vc_LoginPwd,vc_LastLoginIp,isnull(dt_LastLoginTime,getdate()) as dt_LastLoginTime,int_Status,int_UserType from tb_UserInfo where vc_LoginName='" + txt_LoginName.Text.Trim() + "'";
            DataTable dt = db.ExecuteQuery(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["vc_LoginPwd"].ToString() != EncodPwd)
                {
                    lit_Msg.Text = "密码输入错误！";
                    txt_LoginPwd.Text = "";
                    return;
                }
                if (dt.Rows[0]["int_Status"].ToString() != "1")
                {
                    lit_Msg.Text = "您的账号已被停用！";
                    return;
                }
                Int32 __UserId = Convert.ToInt32(dt.Rows[0]["int_UserId"]);
                string __RealName= dt.Rows[0]["vc_RealName"].ToString();
                DateTime __LastLoginTime=Convert.ToDateTime(dt.Rows[0]["dt_LastLoginTime"]);
                string __LastLoginIp = dt.Rows[0]["vc_LastLoginIp"].ToString();
                string UserType = dt.Rows[0]["int_UserType"].ToString();
                //提取账号权限
                if (txt_LoginName.Text.Trim() == "tajadmin")
                {
                    sql = "select int_FunId from tb_FunInfo order by int_Order,int_FunId";
                }
                else
                {
                    sql = "select int_FunId from tb_FunInfo where int_FunId in(select int_FunId from tb_RoleFun where int_RoleId in(select int_RoleId from tb_UserRole where int_UserId=" + __UserId + ") group by int_FunId) order by int_Order,int_FunId";
                }
                dt = db.ExecuteQuery(sql).Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    FunIdList += dt.Rows[i]["int_FunId"].ToString() + ",";
                }
                if (FunIdList != "")
                {
                    FunIdList = FunIdList.Substring(0, FunIdList.Length - 1);
                }
                CUserTicket CurrentInfo = new CUserTicket(__UserId, txt_LoginName.Text.Trim(), __RealName, __LastLoginTime, __LastLoginIp, DateTime.Now.AddHours(2), UserType, FunIdList,false);
                CUserAuthen.WriteLoginTicket(Response, CurrentInfo, RiSystem.PwdSecret);
                sql = string.Format("update tb_UserInfo set dt_LastLoginTime='{0}',vc_LastLoginIp='{1}' where int_UserId={2}", DateTime.Now.ToString(), Request.UserHostAddress, CurrentInfo.UserId);
                db.ExecuteNonQuery(sql);
                RiSystem.AddLog(db, "登录", __RealName + "登录淘安居后台管理", Request.UserHostAddress, __UserId);
                Response.Redirect(StringTools.getConfigValue("MainPage"));
            }
            else
            {
                lit_Msg.Text = "此账号不存在！";
                return;
            }
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