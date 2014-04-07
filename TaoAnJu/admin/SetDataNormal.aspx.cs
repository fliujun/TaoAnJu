using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TaoAnJu.Util;
public partial class admin_SetDataNormal : CAdminCookiePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lit_Script.Text = "";
        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["fiid"]))
            {
                DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
                try
                {
                    tb_FieldInfoEntity_Op objo = new tb_FieldInfoEntity_Op(db);
                    tb_FieldInfoEntity obj = objo.GetByPrimaryKey(Convert.ToInt32(Request["fiid"]));
                    if (obj != null)
                    {
                        lit_Msg.Text =obj.vc_FieldDesc.ToString ();
                        if (obj.int_DataNormal > 0)
                        {
                            SelectTree1.SelectedValue = obj.int_DataNormal.ToString();
                            SelectTree1.SelectedText = RiSystem.getDataNormalById(db, obj.int_DataNormal);
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
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["fiid"]))
        {
            DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
            try
            {
                tb_FieldInfoEntity_Op objo = new tb_FieldInfoEntity_Op(db);
                tb_FieldInfoEntity obj = new tb_FieldInfoEntity();
                if (SelectTree1.SelectedValue != "")
                {
                    obj.int_DataNormal = Convert.ToInt32(SelectTree1.SelectedValue);
                }
                else
                {
                    obj.int_DataNormal = 0;
                }
                obj.int_FiId = Convert.ToInt32(Request["fiid"]);
                objo.Update(obj);
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
}