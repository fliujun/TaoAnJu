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

public partial class admin_PicInfo_List : CAdminCookiePage
{
    DataTable dt;
    int RecordCount = 0;
    int PageSize = 15;
    int PageNum = 1;
    string LoadFilePath = System.Configuration.ConfigurationManager.AppSettings["LoadFilePath"];
    string LoadThumbnailPath = System.Configuration.ConfigurationManager.AppSettings["LoadThumbnailPath"];
    protected void Page_Load(object sender, EventArgs e)
    {
        lit_Script.Text = "";
        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["itemid"]))
            {
                txt_ItemId.Text = Request["itemid"];
                InitData();
            }
            else
            {
                this.btnUpLoad.Visible = false;
            }
        }
    }
    protected void InitConfigData(DsConnectionDB db)
    {
        string sql = "select vc_Name from tb_DataConfigInfo where int_ParentId in(select int_DataNormal from tb_FieldInfo where vc_FieldName='vc_PicType' and int_TbId in(select int_TbId from tb_TableInfo where vc_TableName='tb_PicInfo'))";
        ddl_PicType.Items.Clear();
        dt = db.ExecuteQuery(sql).Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ddl_PicType.Items.Add(dt.Rows[i]["vc_Name"].ToString());
        }
    }
    protected void InitData()
    {
        DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
        try
        {
            InitConfigData(db);
            string sql = "select vc_ItemName from tb_ItemInfo where int_ItemId="+txt_ItemId.Text ;
            dt = db.ExecuteQuery(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                lit_ItemName.Text = dt.Rows[0]["vc_ItemName"].ToString();
            }
            string strFields = "int_PId,vc_PicFile,vc_PicDesc,vc_PicType,vc_Pic2,dt_CreateDate";
            string strFilter = "int_ItemId=" + txt_ItemId.Text;
            if (!string.IsNullOrEmpty(Request["page"]))
            {
                PageNum = int.Parse(Request["page"]);
            }
            if (!string.IsNullOrEmpty(Request["ptype"]))
            {
                ddl_PicType.Text = Request["ptype"];
            }
            if(!string.IsNullOrEmpty (Request["pid"]))
            {
                txt_Pid.Text = Request["pid"];
            }
            strFilter += " and vc_PicType='" + ddl_PicType.Text + "'";
            sql = "SELECT count(*) FROM tb_PicInfo where " + strFilter;
            dt = db.ExecuteQuery(sql).Tables[0];
            RecordCount = (int)dt.Rows[0][0];
            dt = RiSystem.CurrentDataPage(db, "tb_PicInfo", strFields, strFilter, PageSize, PageNum, "int_PId", true);
            
            PageNumBar1.PageSize=PageSize;
            PageNumBar1.CurrPage = PageNum;
            PageNumBar1.RecordCount = RecordCount;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string url = Request.Url.AbsolutePath;
                url = url.Substring(0, url.IndexOf("admin"));
                dt.Rows[i]["vc_PicFile"] = url + LoadFilePath.Replace ("\\","/") + txt_ItemId.Text + "/" + dt.Rows[i]["vc_PicFile"].ToString();
                dt.Rows[i]["vc_Pic2"] = url + LoadThumbnailPath.Replace("\\", "/") + txt_ItemId.Text + "/" + dt.Rows[i]["vc_Pic2"].ToString();

                if (dt.Rows[i]["int_Pid"].ToString() == txt_Pid.Text)
                {
                    txt_PicDesc.Text = dt.Rows[i]["vc_PicDesc"].ToString();
                }
                else
                {
                    dt.Rows[i]["vc_PicDesc"] = "<a href=\"PicInfo_List.aspx?itemid=" + txt_ItemId.Text + "&pid=" + dt.Rows[i]["int_Pid"].ToString() + "&ptype=" + Server.UrlEncode(ddl_PicType.Text) + "\"><font color=\"blue\">" + dt.Rows[i]["vc_PicDesc"] + "</font></a>";
                }
            }
            DataList1.DataSource = dt;
            DataList1.DataBind();
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
    protected void btnUpLoad_Click(object sender, EventArgs e)
    {
        string sExtension = "";
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
            if (txt_Pid.Text == "")
            {
                lit_Msg.Text = "错误提示：请选择要上传的图片文件！";
                return;
            }
        }
        DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
        try
        {
            tb_PicInfoEntity obj = new tb_PicInfoEntity();
            tb_PicInfoEntity_Op objo = new tb_PicInfoEntity_Op(db);
            if (FileUpload1.HasFile)
            {
                string destDir = System.Web.HttpContext.Current.Server.MapPath(LoadFilePath).Replace("admin\\", "") + txt_ItemId.Text + "\\";
                if (!Directory.Exists(destDir))
                {
                    Directory.CreateDirectory(destDir);
                }
                string FileName = RiSystem.FormatUpLoadFileName("item_" + txt_ItemId.Text + "_", FileUpload1.FileName);
                Boolean IsUpLoad = RiSystem.UpLoadFile(destDir + FileName, FileUpload1.PostedFile);
                if (!IsUpLoad)
                {
                    lit_Msg.Text = "错误提示：图片上传失败，请重新提交！";
                    return;
                }
                obj.vc_PicFile = FileName;
                string[] ThumbnailSize1 = System.Configuration.ConfigurationManager.AppSettings["ThumbnailSize1"].Split(',');
                int dwidth = Convert.ToInt32(ThumbnailSize1[0]);
                int dheight = Convert.ToInt32(ThumbnailSize1[1]);
                destDir = System.Web.HttpContext.Current.Server.MapPath(LoadThumbnailPath).Replace("admin\\", "") + txt_ItemId.Text + "\\";
                if (!Directory.Exists(destDir))
                {
                    Directory.CreateDirectory(destDir);
                }
                FileName = RiSystem.FormatUpLoadFileName("thumb_" + txt_ItemId.Text + "_1_", FileUpload1.FileName);
                IsUpLoad = RiSystem.UpLoadThumbnail(destDir + FileName, FileUpload1.PostedFile, dwidth, dheight);
                if (IsUpLoad)
                {
                    obj.vc_Pic1 = FileName;
                }
                else
                {
                    obj.vc_Pic1 = obj.vc_PicFile;
                }
                string[] ThumbnailSize2 = System.Configuration.ConfigurationManager.AppSettings["ThumbnailSize2"].Split(',');
                dwidth = Convert.ToInt32(ThumbnailSize2[0]);
                dheight = Convert.ToInt32(ThumbnailSize2[1]);
                FileName = RiSystem.FormatUpLoadFileName("thumb_" + txt_ItemId.Text + "_2_", FileUpload1.FileName);
                IsUpLoad = RiSystem.UpLoadThumbnail(destDir + FileName, FileUpload1.PostedFile, dwidth, dheight);
                if (IsUpLoad)
                {
                    obj.vc_Pic2 = FileName;
                }
                else
                {
                    obj.vc_Pic2 = obj.vc_PicFile;
                }
                //string[] ThumbnailSize3 = System.Configuration.ConfigurationManager.AppSettings["ThumbnailSize3"].Split(',');
                //dwidth = Convert.ToInt32(ThumbnailSize3[0]);
                //dheight = Convert.ToInt32(ThumbnailSize3[1]);
                //FileName = RiSystem.FormatUpLoadFileName("thumb_" + txt_ItemId.Text + "_3_", FileUpload1.FileName);
                //IsUpLoad = RiSystem.UpLoadThumbnail(destDir + FileName, FileUpload1.PostedFile, dwidth, dheight);
                //if (IsUpLoad)
                //{
                //    obj.vc_Pic3 = FileName;
                //}
                //else
                //{
                //    obj.vc_Pic3 = obj.vc_PicFile;
                //}
            }
            obj.vc_PicType = ddl_PicType.Text;
            if (txt_Pid.Text == "")
            {
                obj.dt_CreateDate = DateTime.Now;
                obj.int_IsView = 1;
                obj.int_ItemId = Convert.ToInt32(txt_ItemId.Text);
                if (txt_PicDesc.Text.Trim() == "")
                {
                    obj.vc_PicDesc = FileUpload1.FileName;
                    obj.vc_PicDesc = obj.vc_PicDesc.Substring(0, obj.vc_PicDesc.Length - sExtension.Length);
                }
                else
                {
                    obj.vc_PicDesc = txt_PicDesc.Text.Trim();
                }
                objo.Insert(obj);

                RiSystem.AddLog(db, "添加", LoginInfo.RealName + "进行 房产项目编号为" + txt_ItemId.Text + "的图片 添加操作，相关编号为：" + obj.int_PId.ToString(), Request.UserHostAddress, LoginInfo.UserId);
            }
            else
            {
                obj.vc_PicDesc = txt_PicDesc.Text.Trim();
                obj.int_PId = Convert.ToInt32(txt_Pid.Text);
                objo.Update(obj);
                RiSystem.AddLog(db, "修改", LoginInfo.RealName + "进行 房产项目编号为" + txt_ItemId.Text + "的图片 修改操作，相关编号为：" + obj.int_PId.ToString(), Request.UserHostAddress, LoginInfo.UserId);
            }
            Response.Redirect("PicInfo_List.aspx?itemid=" + txt_ItemId.Text+"&ptype="+Server.UrlEncode (ddl_PicType.Text));
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
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            string pid = DataList1.DataKeys[e.Item.ItemIndex].ToString();
            DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
            try
            {
                //删除图片文件
                string sql = "select vc_PicFile,vc_Pic1,vc_Pic2,vc_Pic3 from tb_PicInfo where int_Pid="+pid;
                dt = db.ExecuteQuery(sql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    string destDir = System.Web.HttpContext.Current.Server.MapPath(LoadFilePath).Replace("admin\\", "") + txt_ItemId.Text + "\\";
                    if (dt.Rows[0]["vc_PicFile"].ToString() != "")
                    {
                        RiSystem.DelFile(destDir + dt.Rows[0]["vc_PicFile"].ToString());
                    }
                    destDir = System.Web.HttpContext.Current.Server.MapPath(LoadThumbnailPath).Replace("admin\\", "") + txt_ItemId.Text + "\\";
                    if (dt.Rows[0]["vc_Pic1"].ToString() != "")
                    {
                        RiSystem.DelFile(destDir + dt.Rows[0]["vc_Pic1"].ToString());
                    }
                    if (dt.Rows[0]["vc_Pic2"].ToString() != "")
                    {
                        RiSystem.DelFile(destDir + dt.Rows[0]["vc_Pic2"].ToString());
                    }
                    if (dt.Rows[0]["vc_Pic3"].ToString() != "")
                    {
                        RiSystem.DelFile(destDir + dt.Rows[0]["vc_Pic3"].ToString());
                    }
                }
                //删除记录
                sql = "delete from tb_PicInfo where int_Pid=" + pid;
                db.ExecuteNonQuery(sql);
                RiSystem.AddLog(db, "删除", LoginInfo.RealName + "进行 房产项目编号为" + txt_ItemId.Text + "的图片 删除操作，相关编号为：" + pid, Request.UserHostAddress, LoginInfo.UserId);
                Response.Redirect("PicInfo_List.aspx?itemid=" + txt_ItemId.Text + "&ptype=" + Server.UrlEncode(ddl_PicType.Text));
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
    protected void ddl_PicType_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("PicInfo_List.aspx?itemid=" + txt_ItemId.Text + "&ptype=" + Server.UrlEncode(ddl_PicType.Text));
    }
    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemIndex >= 0)
        {
            LinkButton lb = (LinkButton)e.Item.FindControl("btnDel");
            lb.Attributes.Add("onclick", "javascript:return del_sure()");
        }
    }
}