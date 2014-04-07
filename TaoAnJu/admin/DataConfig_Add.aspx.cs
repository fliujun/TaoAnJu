using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TaoAnJu.Util;
public partial class admin_DataConfig_Add : CAdminCookiePage
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
            if (!string.IsNullOrEmpty(Request["parentid"]))
            {
                txt_ParentId.Text = Request["parentid"];
                lit_Type.Text = RiSystem.getDataNormalById(db, Convert.ToInt32 (txt_ParentId.Text));
            }
            if (!string.IsNullOrEmpty(Request["did"]))
            {
                txt_DId.Text = Request["did"];
                tb_DataConfigInfoEntity_Op objo = new tb_DataConfigInfoEntity_Op(db);
                tb_DataConfigInfoEntity obj = objo.GetByPrimaryKey(Convert.ToInt32(txt_DId.Text));
                if (obj != null)
                {
                    txt_Name.Text = obj.vc_Name.ToString();
                    lit_Type.Text = RiSystem.getDataNormalById(db, obj.int_ParentId);
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
            string sql = "select count(*) from tb_DataConfigInfo where vc_Name='" + txt_Name.Text.Trim() + "' and int_ParentId=" + txt_ParentId.Text;
            if (txt_DId.Text != "")
            {
                sql += " and int_DId<>" + txt_DId.Text;
            }
            if ((int)db.ExecuteScalar(sql) > 0)
            {
                lit_Msg.Text = "这个名称已存在！";
                return;
            }
            tb_DataConfigInfoEntity obj = new tb_DataConfigInfoEntity();
            tb_DataConfigInfoEntity_Op objo = new tb_DataConfigInfoEntity_Op(db);
            obj.vc_Name = txt_Name.Text.Trim();
            if (txt_DId.Text == "")
            {
                obj.int_ParentId = Convert.ToInt32(txt_ParentId.Text);
                obj.int_Order = 99;
                obj.int_Type =1;
                obj.dt_CreateDate = DateTime.Now;
                objo.Insert(obj);
                RiSystem.AddLog(db, "添加", LoginInfo.RealName + "进行 数据规范 添加操作，相关编号为：" + obj.int_DId.ToString(), Request.UserHostAddress, LoginInfo.UserId);
            }
            else
            {
                obj.int_DId = Convert.ToInt32(txt_DId.Text);
                objo.Update(obj);
                RiSystem.AddLog(db, "修改", LoginInfo.RealName + "进行 数据规范 修改操作，相关编号为：" + obj.int_DId.ToString(), Request.UserHostAddress, LoginInfo.UserId);
            }
            if (txt_ParentId.Text != "-1")
            {
                lit_Script.Text = StringTools.AddScript("window.parent.frames['mainFrame'].location=window.parent.frames['mainFrame'].location;JqueryDialog.Close();");
            }
            else
            {
                lit_Script.Text = StringTools.AddScript("window.parent.frames['leftFrame'].location='left.aspx?expand=dconfig';window.parent.frames['mainFrame'].location=window.parent.frames['mainFrame'].location;JqueryDialog.Close();");
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
}