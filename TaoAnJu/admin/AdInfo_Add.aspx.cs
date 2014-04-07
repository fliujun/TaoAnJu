using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Text.RegularExpressions;
using System.IO;
using TaoAnJu.Util;
public partial class admin_AdInfo_Add : CAdminCookiePage
{
    string LoadAdImagePath = System.Configuration.ConfigurationManager.AppSettings["LoadAdImagePath"];
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
            InitConfigData(db);
            if (!string.IsNullOrEmpty(Request["aid"]))
            {
                txt_AId.Text = Request["aid"];
                tb_AdInfoEntity_Op objo = new tb_AdInfoEntity_Op(db);
                tb_AdInfoEntity obj = objo.GetByPrimaryKey(Convert.ToInt32(txt_AId.Text));
                if (obj != null)
                {
                    txt_AdDesc.Text = obj.vc_AdDesc.ToString();
                    txt_AdLink.Text = obj.vc_AdLink.ToString();
                    txt_AdTitle.Text = obj.vc_AdTitle.ToString();
                    ddl_AdType.Text = obj.vc_AdType.ToString();
                    ddl_Status.SelectedIndex = obj.int_Status;
                    txt_Order.Text = obj.int_Order.ToString();
                    string url = Request.Url.AbsolutePath;
                    url = url.Substring(0, url.IndexOf("admin"));
                    lit_Pic.Text = "<a href =\"" + url + LoadAdImagePath.Replace("\\", "/") + obj.vc_AdPicFile.ToString() + "\" target=\"_blank\"><font color=\"red\">查看图片</font></a>";
                }
            }
            else
            {
                ddl_Status.Enabled = false;
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
    protected void InitConfigData(DsConnectionDB db)
    {
        string sql = "select vc_Name from tb_DataConfigInfo where int_ParentId in(select int_DataNormal from tb_FieldInfo where vc_FieldName='vc_AdType' and int_TbId in(select int_TbId from tb_TableInfo where vc_TableName='tb_AdInfo'))"; ;
        DataTable dt = db.ExecuteQuery(sql).Tables[0];
        ddl_AdType.Items.Clear();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ddl_AdType.Items.Add(dt.Rows[i]["vc_Name"].ToString());
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lit_Msg.Text = "";
        string sExtension = "";
        if (txt_AdTitle.Text.Trim() == "")
        {
            lit_Msg.Text = "错误提示：广告标题不能为空！";
            return;
        }
        if (txt_AdDesc.Text.Trim() == "")
        {
            lit_Msg.Text = "错误提示：广告描述不能为空！";
            return;
        }
        if (txt_AdLink.Text.Trim() == "")
        {
            lit_Msg.Text = "错误提示：广告链接不能为空！";
            return;
        }
        if (FileUpload1.HasFile)
        {
            sExtension = Path.GetExtension(FileUpload1.FileName).ToUpper();
            if (sExtension != ".GIF" && sExtension != ".JPG")
            {
                lit_Msg.Text = "错误提示：上传文件必须是jpg或gif格式！";
                return;
            }
        }
        else
        {
            if (txt_AId.Text == "")
            {
                lit_Msg.Text = "错误提示：请选择要上传的图片文件！";
                return;
            }
        }
        Regex re = new Regex(@"^[0-9]*[0-9][0-9]*$");
        if (string.IsNullOrEmpty(txt_Order.Text.Trim()) || !re.IsMatch(txt_Order.Text.Trim()))
        {
            lit_Msg.Text = "错误提示：显示顺序请输入数字！";
            txt_Order.Text = "";
            return;
        }
        DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
        try
        {
            string sql = "select count(*) from tb_AdInfo where vc_AdLink='" + txt_AdLink.Text + "'";
            if (txt_AId.Text != "")
            {
                sql += " and int_AId<>" + txt_AId.Text;
            }
            if ((int)db.ExecuteScalar(sql) > 0)
            {
                lit_Msg.Text = "错误提示：此广告链接已存在，请重新输入！";
                txt_AdLink.Text = "";
                return;
            }
            
            tb_AdInfoEntity obj = new tb_AdInfoEntity();
            tb_AdInfoEntity_Op objo = new tb_AdInfoEntity_Op(db);
            if (FileUpload1.HasFile)
            {
                string destDir = System.Web.HttpContext.Current.Server.MapPath(LoadAdImagePath).Replace("admin\\", "") ;
                if (!Directory.Exists(destDir))
                {
                    Directory.CreateDirectory(destDir);
                }
                string FileName = RiSystem.FormatUpLoadFileName("Ad_", FileUpload1.FileName);
                Boolean IsUpLoad = RiSystem.UpLoadFile(destDir + FileName, FileUpload1.PostedFile);
                if (!IsUpLoad)
                {
                    lit_Msg.Text = "错误提示：图片上传失败，请重新提交！";
                    return;
                }
                obj.vc_AdPicFile = FileName;
            }
            obj.vc_AdDesc = txt_AdDesc.Text.Trim();
            obj.vc_AdLink = txt_AdLink.Text.Trim();
            obj.vc_AdTitle = txt_AdTitle.Text.Trim();
            obj.vc_AdType = ddl_AdType.Text;
            obj.int_Order = Convert.ToInt32(txt_Order.Text);
            obj.int_Status = ddl_Status.SelectedIndex;
            if (txt_AId.Text == "")
            {
                obj.vc_Guid = Guid.NewGuid().ToString();
                obj.dt_CreateDate = DateTime.Now;
                objo.Insert(obj);
                RiSystem.AddLog(db, "添加", LoginInfo.RealName + "进行 广告 添加操作，相关编号为：" + obj.int_AId.ToString(), Request.UserHostAddress, LoginInfo.UserId);
            }
            else
            {
                obj.int_AId = Convert.ToInt32(txt_AId.Text);
                objo.Update(obj);
                RiSystem.AddLog(db, "修改", LoginInfo.RealName + "进行 广告 修改操作，相关编号为：" + obj.int_AId.ToString(), Request.UserHostAddress, LoginInfo.UserId);
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