using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaoAnJu.Util ;
public partial class admin_Msg :CAdminCookiePage 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lit_Msg.Text = "";
        lit_Script.Text = "";
        if(!string.IsNullOrEmpty (Request["msg"]))
        {
            lit_Msg.Text = Request["msg"].ToString()+"！";
        }
        if (!string.IsNullOrEmpty(Request["optype"]) && Request["optype"] == "submit" && Session["UserOpInfo"] != null)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
        }
        else
        {
            if (!string.IsNullOrEmpty(Request["optype"]) && Request["optype"] == "error")
            {
                Panel1.Visible = false;
                Panel2.Visible = false;
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Session["UserOpInfo"] = null;
        lit_Script.Text = StringTools.AddScript("JqueryDialog.Close();");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Session["UserOpInfo"] != null)
        {
            UserOpInfo ui = (UserOpInfo)Session["UserOpInfo"];
            DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
            try
            {
                //删除对应项目的图片
                if (ui.OpType == "删除" && ui.ModelName == "房产项目")
                {
                    RiSystem.DelItemFile(db, ui.IdList);
                }
                db.ExecuteNonQuery(ui.OpSql);
                
                Session["UserOpInfo"] = null;
                RiSystem.AddLog(db, ui.OpType, LoginInfo.RealName + "进行 " + ui.ModelName + " " + ui.OpType + "操作，相关编号为：" + ui.IdList, Request.UserHostAddress, LoginInfo.UserId);
                if (!string.IsNullOrEmpty(Request["isleft"]))
                {
                    lit_Script.Text = StringTools.AddScript("window.parent.frames['leftFrame'].location='left.aspx?expand="+Request["expand"]+"';window.parent.frames['mainFrame'].location=window.parent.frames['mainFrame'].location;JqueryDialog.Close();");
                }
                else
                {
                    lit_Script.Text = StringTools.AddScript("window.parent.frames['mainFrame'].location=window.parent.frames['mainFrame'].location;JqueryDialog.Close();");
                }
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
        else
        {
            lit_Msg.Text = "<font color=\"red\">操作失败：当前操作已过时！</font>";
            Panel1.Visible = true;
            Panel2.Visible = false;
        }
    }
}