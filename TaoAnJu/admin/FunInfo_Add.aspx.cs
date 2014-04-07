using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data ;
using TaoAnJu.Util ;
public partial class admin_FunInfo_Add : CAdminCookiePage
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
            if (!string.IsNullOrEmpty(Request["funid"]))
            {
                txt_FunId.Text = Request["funid"];
                tb_FunInfoEntity_Op objo = new tb_FunInfoEntity_Op(db);
                tb_FunInfoEntity obj = objo.GetByPrimaryKey(Convert.ToInt32(txt_FunId.Text));
                if (obj != null)
                {
                    txt_Name.Text = obj.vc_Name.ToString();
                    txt_Value.Text = obj.vc_Value.ToString();
                    txt_Parameter.Text = obj.vc_Parameter.ToString();
                    SelectTree1.SelectedValue = obj.int_ParentId.ToString();
                    SelectTree1.SelectedText = RiSystem.getFunNameById(db, obj.int_ParentId);
                    ddlType.SelectedIndex = obj.int_Type - 1;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(Request["parentid"]))
                {
                    SelectTree1.SelectedValue = Request["parentid"];
                    SelectTree1.SelectedText = RiSystem.getFunNameById(db, Convert.ToInt32(Request["parentid"]));
                }
                else
                {
                    SelectTree1.SelectedValue = "-1";
                    SelectTree1.SelectedText = "顶级权限";
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
        if (txt_Name.Text.Trim() == "")
        {
            lit_Msg.Text = "名称不能为空！";
            return;
        }
        DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
        try
        {
            string sql = "select count(*) from tb_FunInfo where vc_Name='" + txt_Name.Text + "' and int_ParentId=" + SelectTree1.SelectedValue;
            if (txt_FunId.Text != "")
            {
                sql += " and int_FunId<>" + txt_FunId.Text;
            }
            if ((int)db.ExecuteScalar(sql) > 0)
            {
                lit_Msg.Text = "同级权限名称不能重复！";
                return;
            }
            tb_FunInfoEntity obj = new tb_FunInfoEntity();
            tb_FunInfoEntity_Op objo = new tb_FunInfoEntity_Op(db);
            obj.int_ParentId = Convert.ToInt32(SelectTree1.SelectedValue);
            obj.int_Type = ddlType.SelectedIndex + 1;
            obj.vc_Value = txt_Value.Text.Trim().ToLower ();
            obj.vc_Name = txt_Name.Text.Trim();
            obj.vc_Parameter = txt_Parameter.Text.Trim();
            if (txt_FunId.Text == "")
            {
                obj.int_Order = 99;
                objo.Insert(obj);
                RiSystem.AddLog(db, "添加", LoginInfo.RealName + "进行 权限 添加操作，相关编号为：" + obj.int_FunId.ToString(), Request.UserHostAddress, LoginInfo.UserId);
            }
            else
            {
                obj.int_FunId = Convert.ToInt32(txt_FunId.Text);
                objo.Update(obj);
                RiSystem.AddLog(db, "修改", LoginInfo.RealName + "进行 权限 修改操作，相关编号为：" + obj.int_FunId.ToString(), Request.UserHostAddress, LoginInfo.UserId);
            }

            lit_Script.Text = StringTools.AddScript("window.parent.frames['leftFrame'].location='left.aspx?expand=fun';window.parent.frames['mainFrame'].location=window.parent.frames['mainFrame'].location;JqueryDialog.Close();");
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