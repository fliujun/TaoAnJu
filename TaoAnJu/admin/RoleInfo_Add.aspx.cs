using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaoAnJu.Util;
public partial class admin_RoleInfo_Add : CAdminCookiePage 
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
            if (!string.IsNullOrEmpty(Request["roleid"]))
            {
                txt_RoleId.Text = Request["roleid"];
                tb_RoleInfoEntity_Op objo = new tb_RoleInfoEntity_Op(db);
                tb_RoleInfoEntity obj = objo.GetByPrimaryKey(Convert.ToInt32(txt_RoleId.Text));
                if (obj != null)
                {
                    txt_RoleName.Text = obj.vc_RoleName.ToString();
                    txt_RoleDesc.Text = obj.vc_Desc.ToString();
                }
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
        if (txt_RoleName.Text.Trim() == "")
        {
            lit_Msg.Text = "角色名称不能为空！";
            return;
        }
        DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
        try
        {
            string sql = "select count(*) from tb_RoleInfo where vc_RoleName='" + txt_RoleName.Text.Trim () +"'";
            if (txt_RoleId.Text != "")
            {
                sql += " and int_RoleId<>" + txt_RoleId.Text;
            }
            if ((int)db.ExecuteScalar(sql) > 0)
            {
                lit_Msg.Text = "这个角色名称已存在！";
                return;
            }
            tb_RoleInfoEntity obj = new tb_RoleInfoEntity();
            tb_RoleInfoEntity_Op objo = new tb_RoleInfoEntity_Op(db);
            obj.vc_Desc = txt_RoleDesc.Text.Trim();
            obj.vc_RoleName = txt_RoleName.Text.Trim();
            if (txt_RoleId.Text == "")
            {
                obj.dt_CreateDate = DateTime.Now;
                objo.Insert(obj);
                RiSystem.AddLog(db, "添加", LoginInfo.RealName + "进行 角色 添加操作，相关编号为：" + obj.int_RoleId.ToString(), Request.UserHostAddress, LoginInfo.UserId);
            }
            else
            {
                obj.int_RoleId = Convert.ToInt32(txt_RoleId.Text);
                objo.Update(obj);
                RiSystem.AddLog(db, "修改", LoginInfo.RealName + "进行 角色 修改操作，相关编号为：" + obj.int_RoleId.ToString(), Request.UserHostAddress, LoginInfo.UserId);
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