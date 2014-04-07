using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Text.RegularExpressions;
using TaoAnJu.Util;
public partial class admin_UserInfo_Add : CAdminCookiePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lit_Msg.Text = "";
        lit_Script.Text = "";
        RiSystem.InitSubmitButton(this.Page, btnSubmit.ID);
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
            if (!string.IsNullOrEmpty(Request["userid"]))
            {
                ddlStatus.Enabled = true;
                txt_UserId.Text = Request["userid"];
                tb_UserInfoEntity_Op objo = new tb_UserInfoEntity_Op(db);
                tb_UserInfoEntity obj = objo.GetByPrimaryKey(Convert.ToInt32(txt_UserId.Text));
                if (obj != null)
                {
                    txt_LoginName.Text = obj.vc_LoginName.ToString();
                    txt_RealName.Text = obj.vc_RealName.ToString();
                    ddlStatus.SelectedIndex = obj.int_Status;
                    ddlUserType.SelectedIndex = obj.int_UserType - 1;
                    if (txt_LoginName.Text  == "tajadmin")
                    {
                        btnSubmit.Enabled = false;
                        txt_LoginName.Enabled = false;
                        txt_CheckPwd.Enabled = false;
                        txt_LoginPwd.Enabled = false;
                        txt_RealName.Enabled = false;
                        ddlStatus.Enabled = false;
                        ddlUserType.Enabled = false;
                    }
                }
            }
            else
            {
                txt_LoginName.Text = "";
                txt_LoginPwd.Text = "";
                txt_RealName.Text = "";
                ddlStatus.Enabled = false;
            }
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lit_Msg.Text = "";
        if (txt_LoginName.Text.Trim() == "")
        {
            lit_Msg.Text = "账号不能为空！";
            return;
        }
        //账号长度为8-16个字符，必须由字母开头，字母或数字或下划线组成的字符串！
        Regex re = new Regex(@"^[a-zA-Z][a-zA-Z0-9_]{7,15}$");
        if (!re.IsMatch(txt_LoginName.Text.Trim()))
        {
            lit_Msg.Text = "账号长度为8-16个字符，必须由字母开头，字母或数字或下划线混合组成！";
            return;
        }
        if (txt_RealName.Text.Trim() == "")
        {
            lit_Msg.Text = "真实名称不能为空！";
            return;
        }
        if (txt_UserId.Text == "" || txt_LoginPwd.Text.Trim() != "")
        {
            re = new Regex(@"^(?!\D+$)(?!\d+$)[a-zA-Z0-9_~!@#$%^&*()]{8,16}$");
            if (!re.IsMatch(txt_LoginPwd.Text.Trim()))
            {
                lit_Msg.Text = "密码长度为8-16个字符，必须是字母和数字混合，可以有下划线或特殊字符！";
                txt_LoginPwd.Text = "";
                return;
            }
            if (txt_LoginPwd.Text != txt_CheckPwd.Text)
            {
                lit_Msg.Text = "密码二次验证不对，请重新输入！";
                txt_CheckPwd.Text = "";
                return;
            }
        }
        DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
        try
        {
            string sql = "select count(*) from tb_UserInfo where vc_LoginName='" + txt_LoginName.Text + "'";
            if (txt_UserId.Text != "")
            {
                sql += " and int_UserId<>" + txt_UserId.Text;
            }
            if ((int)db.ExecuteScalar(sql) > 0)
            {
                lit_Msg.Text = "此账号已存在，请重新输入！";
                txt_LoginName.Text = "";
                return;
            }
            tb_UserInfoEntity ui = new tb_UserInfoEntity();
            tb_UserInfoEntity_Op uio = new tb_UserInfoEntity_Op(db);
            ui.int_UserType = ddlUserType.SelectedIndex + 1;
            ui.vc_LoginName = txt_LoginName.Text.Trim();
            ui.vc_RealName = txt_RealName.Text.Trim();
            ui.int_Status = ddlStatus.SelectedIndex;
            if (txt_UserId.Text == "")
            {
                ui.vc_LoginPwd = CSecretProcess.Encrypt(txt_LoginPwd.Text, RiSystem.PwdSecret);
                ui.dt_CreateDate = DateTime.Now;
                ui.int_CCount = 0;
                uio.Insert(ui);
                RiSystem.AddLog(db, "添加", LoginInfo.RealName + "进行 用户 添加操作，相关编号为：" + ui.int_UserId.ToString(), Request.UserHostAddress, LoginInfo.UserId);
            }
            else
            {
                if (txt_LoginPwd.Text.Trim() != "")
                {
                    ui.vc_LoginPwd = CSecretProcess.Encrypt(txt_LoginPwd.Text, RiSystem.PwdSecret);
                }
                ui.int_UserId = Convert.ToInt32(txt_UserId.Text);
                uio.Update(ui);
                RiSystem.AddLog(db, "修改", LoginInfo.RealName + "进行 用户 修改操作，相关编号为：" + ui.int_UserId.ToString(), Request.UserHostAddress, LoginInfo.UserId);
            }

            lit_Script.Text = StringTools.AddScript("window.parent.frames['mainFrame'].location=window.parent.frames['mainFrame'].location;JqueryDialog.Close();");
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