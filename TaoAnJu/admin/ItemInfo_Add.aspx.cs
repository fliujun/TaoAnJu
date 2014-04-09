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

public partial class admin_ItemInfo_Add : CAdminCookiePage
{
    string LoadFilePath = System.Configuration.ConfigurationManager.AppSettings["LoadFilePath"];
    string LoadThumbnailPath = System.Configuration.ConfigurationManager.AppSettings["LoadThumbnailPath"];
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
    protected void InitConfigData(DsConnectionDB db)
    {
        string sql = "select vc_Name from tb_DataConfigInfo where int_ParentId in(select int_DataNormal from tb_FieldInfo where vc_FieldName='vc_City' and int_TbId in(select int_TbId from tb_TableInfo where vc_TableName='tb_ItemInfo'))";
        DataTable dt = db.ExecuteQuery(sql).Tables[0];
        ddl_City.Items.Clear();
        ddl_City.Items.Add("");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ddl_City.Items.Add(dt.Rows[i]["vc_Name"].ToString());
        }
        sql = "select vc_Name from tb_DataConfigInfo where int_ParentId in(select int_DataNormal from tb_FieldInfo where vc_FieldName='vc_SalesStatus' and int_TbId in(select int_TbId from tb_TableInfo where vc_TableName='tb_ItemInfo'))"; ;
        dt = db.ExecuteQuery(sql).Tables[0];
        ddl_SalesStatus.Items.Clear();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ddl_SalesStatus.Items.Add(dt.Rows[i]["vc_Name"].ToString());
        }
    }
    
    protected void InitData()
    {
        DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
        try
        {
            InitConfigData(db);
            if (!string.IsNullOrEmpty(Request["itemid"]))
            {
                ddl_Status.Enabled = true;
                txt_ItemId.Text = Request["itemid"];
                tb_ItemInfoEntity_Op objo = new tb_ItemInfoEntity_Op(db);
                tb_ItemInfoEntity obj = objo.GetByPrimaryKey(Convert.ToInt32(txt_ItemId.Text));
                if (obj != null)
                {
                    txt_Area.Text = obj.vc_Area.ToString();
                    txt_BuildDesign.Text = obj.vc_BuildDesign.ToString();
                    txt_BuildedArea.Text = (!obj.dec_BuildedAreaNull && obj.dec_BuildedArea > 0) ? obj.dec_BuildedArea.ToString() : "";
                    txt_BuildType.Text = obj.vc_BuildType.ToString();
                    txt_BusinessZone.Text = obj.vc_BusinessZone.ToString();
                    txt_CheckinTime.Text = (!obj.dt_CheckinTimeNull) ? obj.dt_CheckinTime.ToString("yyyy-MM-dd") : "";
                    txt_ConfigureInfo.Text = obj.vc_ConfigureInfo.ToString();
                    txt_Contractor.Text = obj.vc_Contractor.ToString();
                    txt_CoveredArea.Text = (!obj.dec_CoveredAreaNull && obj.dec_CoveredArea > 0) ? obj.dec_CoveredArea.ToString() : "";
                    txt_Decoration.Text = obj.vc_Decoration.ToString();
                    txt_Developer.Text = obj.vc_Developer.ToString();
                    txt_Discount.Text = obj.vc_Discount.ToString();
                    txt_FloorCondition.Text = obj.vc_FloorCondition.ToString();
                    txt_GasSupply.Text = obj.vc_GasSupply.ToString();
                    txt_GreenRate.Text = (!obj.dec_GreenRateNull && obj.dec_GreenRate > 0) ? obj.dec_GreenRate.ToString() : "";
                    txt_Heating.Text = obj.vc_Heating.ToString();
                    txt_Hotline.Text = obj.vc_Hotline.ToString();
                    txt_HouseType.Text = obj.vc_HouseType.ToString();
                    txt_Introduction.Text = obj.vc_Introduction.ToString();
                    txt_ItemName.Text = obj.vc_ItemName.ToString();
                    txt_LandscapeDesign.Text = obj.vc_LandscapeDesign.ToString();
                    txt_Location.Text = obj.vc_Location.ToString();
                    txt_OpeningTime.Text = (!obj.dt_OpeningTimeNull) ? obj.dt_OpeningTime.ToString("yyyy-MM-dd") : "";
                    txt_Order.Text = (!obj.int_OrderNull && obj.int_Order > 0) ? obj.int_Order.ToString() : "";
                    txt_ParkingSpace.Text = obj.vc_ParkingSpace.ToString();
                    if (!string.IsNullOrEmpty(obj.vc_PicFile1))
                    {
                        string url = Request.Url.AbsolutePath;
                        url = url.Substring(0, url.IndexOf("admin"));
                        lit_Pic.Text = "图片文件：<a href =\"" + url + LoadFilePath.Replace("\\", "/") + obj.vc_PicFile1.ToString() + "\" target=\"_blank\"><font color=\"red\">查看大图</font></a>";
                        lit_Pic.Text += "&nbsp;&nbsp;<a href =\"" + url + LoadThumbnailPath.Replace("\\", "/") + obj.vc_PicFile2.ToString() + "\" target=\"_blank\"><font color=\"blue\">查看缩略图</font></a>";
                    }
                    txt_ProjectFeatures.Text = obj.vc_ProjectFeatures.ToString();
                    txt_PropertyCompany.Text = obj.vc_PropertyCompany.ToString();
                    txt_PropertyFee.Text = obj.vc_PropertyFee.ToString();
                    txt_PropertyRight.Text = (!obj.int_PropertyRightNull && obj.int_PropertyRight > 0) ? obj.int_PropertyRight.ToString() : "";
                    txt_PropertyType.Text = obj.vc_PropertyType.ToString();
                    txt_ReferencePrice.Text = (!obj.dec_ReferencePriceNull && obj.dec_ReferencePrice > 0) ? obj.dec_ReferencePrice.ToString() : "";
                    txt_SalesLocation.Text = obj.vc_SalesLocation.ToString();
                    txt_SalesPermit.Text = obj.vc_SalesPermit.ToString();
                    txt_Traffic.Text = obj.vc_Traffic.ToString();
                    txt_VolumeRate.Text = (!obj.dec_VolumeRateNull && obj.dec_VolumeRate > 0) ? obj.dec_VolumeRate.ToString() : "";
                    txt_WaterSupply.Text = obj.vc_WaterSupply.ToString();
                    ddl_City.Text = obj.vc_City.ToString();
                    ddl_IsPay.SelectedIndex = obj.int_IsPay;
                    ddl_SalesStatus.Text = obj.vc_SalesStatus.ToString();
                    ddl_Status.SelectedIndex = obj.int_Status;
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lit_Msg.Text = "";
        if (txt_ItemName.Text.Trim() == "")
        {
            lit_Msg.Text = "错误提示：项目名称不能为空！";
            return;
        }
        //^[0-9]*[1-9][0-9]*$　　//匹配正整数 
        //匹配正浮点数
        Regex re = new Regex(@"^[0-9]+\.{0,1}[0-9]{0,3}$");
        if (!string.IsNullOrEmpty(txt_PropertyRight.Text.Trim()) && !re.IsMatch(txt_PropertyRight.Text.Trim()))
        {
            lit_Msg.Text = "错误提示：产权年限请输入数字！";
            txt_PropertyRight.Text = "";
            return;
        }
        if (!string.IsNullOrEmpty(txt_BuildedArea.Text.Trim()) && !re.IsMatch(txt_BuildedArea.Text.Trim()))
        {
            lit_Msg.Text = "错误提示：建筑面积请输入数字！";
            txt_BuildedArea.Text = "";
            return;
        }
        if (!string.IsNullOrEmpty(txt_CoveredArea.Text.Trim()) && !re.IsMatch(txt_CoveredArea.Text.Trim()))
        {
            lit_Msg.Text = "错误提示：占地面积请输入数字！";
            txt_CoveredArea.Text = "";
            return;
        }
        if (!string.IsNullOrEmpty(txt_GreenRate.Text.Trim()) && !re.IsMatch(txt_GreenRate.Text.Trim()))
        {
            lit_Msg.Text = "错误提示：绿化率请输入数字，前台页面显示会自动转换为百分比！";
            txt_GreenRate.Text = "";
            return;
        }
        if (!string.IsNullOrEmpty(txt_ReferencePrice.Text.Trim()) && !re.IsMatch(txt_ReferencePrice.Text.Trim()))
        {
            lit_Msg.Text = "错误提示：参考价格请输入数字！";
            txt_ReferencePrice.Text = "";
            return;
        }
        if (!string.IsNullOrEmpty(txt_VolumeRate.Text.Trim()) && !re.IsMatch(txt_VolumeRate.Text.Trim()))
        {
            lit_Msg.Text = "错误提示：容积率请输入数字！";
            txt_VolumeRate.Text = "";
            return;
        }
        re = new Regex(@"^[0-9]*[0-9][0-9]*$");
        if (!string.IsNullOrEmpty(txt_Order.Text.Trim()) && !re.IsMatch(txt_Order.Text.Trim()))
        {
            lit_Msg.Text = "错误提示：显示顺序请输入数字！";
            txt_Order.Text = "";
            return;
        }
        if (FileUpload1.HasFile)
        {
            string sExtension = Path.GetExtension(FileUpload1.FileName).ToUpper();
            if (sExtension != ".GIF" && sExtension != ".JPG")
            {
                lit_Msg.Text = "错误提示：上传文件必须是jpg或gif格式！";
                return;
            }
        }
        DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
        try
        {
            string sql = "select count(*) from tb_ItemInfo where vc_ItemName='" + txt_ItemName.Text + "'";
            if (txt_ItemId.Text != "")
            {
                sql += " and int_ItemId<>" + txt_ItemId.Text;
            }
            if ((int)db.ExecuteScalar(sql) > 0)
            {
                lit_Msg.Text = "错误提示：此项目名称已存在，请重新输入！";
                txt_ItemName.Text = "";
                return;
            }
            tb_ItemInfoEntity obj = new tb_ItemInfoEntity();
            tb_ItemInfoEntity_Op objo = new tb_ItemInfoEntity_Op(db);
            obj.vc_Area = txt_Area.Text.Trim ();
            obj.vc_BuildDesign = txt_BuildDesign.Text.Trim ();
            obj.vc_BuildType = txt_BuildType.Text.Trim();
            obj.vc_BusinessZone = txt_BusinessZone.Text.Trim();
            obj.vc_City = ddl_City.Text;
            obj.vc_ConfigureInfo = txt_ConfigureInfo.Text.Trim();
            obj.vc_Contractor = txt_Contractor.Text.Trim();
            obj.vc_Decoration = txt_Decoration.Text.Trim();
            obj.vc_Developer = txt_Developer.Text.Trim();
            obj.vc_Discount = txt_Discount.Text.Trim();
            obj.vc_FloorCondition = txt_FloorCondition.Text.Trim();
            obj.vc_GasSupply = txt_GasSupply.Text.Trim();
            obj.vc_Heating = txt_Heating.Text.Trim();
            obj.vc_Hotline = txt_Hotline.Text.Trim();
            obj.vc_HouseType = txt_HouseType.Text.Trim();
            obj.vc_Introduction = txt_Introduction.Text.Trim();
            obj.vc_ItemName = txt_ItemName.Text.Trim();
            obj.vc_LandscapeDesign = txt_LandscapeDesign.Text.Trim();
            obj.vc_Location = txt_Location.Text.Trim();
            obj.vc_ParkingSpace = txt_ParkingSpace.Text.Trim();
            obj.vc_ProjectFeatures = txt_ProjectFeatures.Text.Trim();
            obj.vc_PropertyCompany = txt_PropertyCompany.Text.Trim();
            obj.vc_PropertyFee = txt_PropertyFee.Text.Trim();
            obj.vc_PropertyType = txt_PropertyType.Text.Trim();
            obj.vc_SalesLocation = txt_SalesLocation.Text.Trim();
            obj.vc_SalesPermit = txt_SalesPermit.Text.Trim();
            obj.vc_SalesStatus = ddl_SalesStatus.Text;
            obj.vc_Traffic = txt_Traffic.Text.Trim();
            obj.vc_WaterSupply = txt_WaterSupply.Text.Trim();
            obj.int_IsPay = ddl_IsPay.SelectedIndex;
            obj.int_Order = (!string.IsNullOrEmpty(txt_Order.Text.Trim())) ? Convert.ToInt32(txt_Order.Text.Trim()) : 0;
            if (!string.IsNullOrEmpty(txt_PropertyRight.Text.Trim()))
            {
                obj.int_PropertyRight = Convert.ToInt32(txt_PropertyRight.Text.Trim());
            }
            else
            {
                obj.int_PropertyRight = 0;
            }
            obj.int_Status = ddl_Status.SelectedIndex;
            if (!string.IsNullOrEmpty(txt_BuildedArea.Text.Trim()))
            {
                obj.dec_BuildedArea = Convert.ToDecimal(txt_BuildedArea.Text.Trim());
            }
            else
            {
                obj.dec_BuildedArea = 0;
            }
            if (!string.IsNullOrEmpty(txt_CoveredArea.Text.Trim()))
            {
                obj.dec_CoveredArea = Convert.ToDecimal(txt_CoveredArea.Text.Trim());
            }
            else
            {
                obj.dec_CoveredArea = 0;
            }
            if (!string.IsNullOrEmpty(txt_GreenRate.Text.Trim()))
            {
                obj.dec_GreenRate = Convert.ToDecimal(txt_GreenRate.Text.Trim());
            }
            else
            {
                obj.dec_GreenRate = 0;
            }
            if (!string.IsNullOrEmpty(txt_ReferencePrice.Text.Trim()))
            {
                obj.dec_ReferencePrice = Convert.ToDecimal(txt_ReferencePrice.Text.Trim());
            }
            else
            {
                obj.dec_ReferencePrice = 0;
            }
            if (!string.IsNullOrEmpty(txt_VolumeRate.Text.Trim()))
            {
                obj.dec_VolumeRate = Convert.ToDecimal(txt_VolumeRate.Text.Trim());
            }
            else
            {
                obj.dec_VolumeRate = 0;
            }
            if (!string.IsNullOrEmpty(txt_CheckinTime.Text.Trim()))
            {
                obj.dt_CheckinTime = Convert.ToDateTime(txt_CheckinTime.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txt_OpeningTime.Text.Trim()))
            {
                obj.dt_OpeningTime = Convert.ToDateTime(txt_OpeningTime.Text.Trim());
            }
            obj.dt_UpdateTime = DateTime.Now;
            if (FileUpload1.HasFile)
            {
                string destDir = System.Web.HttpContext.Current.Server.MapPath(LoadFilePath).Replace("admin\\", "");
                string FileName = RiSystem.FormatUpLoadFileName("item", FileUpload1.FileName);
                Boolean IsUpLoad = RiSystem.UpLoadFile(destDir + FileName, FileUpload1.PostedFile);
                if (!IsUpLoad)
                {
                    lit_Msg.Text = "错误提示：图片上传失败，请重新提交！";
                    return;
                }
                obj.vc_PicFile1 = FileName;
                string[] ThumbnailSize1 = System.Configuration.ConfigurationManager.AppSettings["ThumbnailSize1"].Split(',');
                int dwidth = Convert.ToInt32(ThumbnailSize1[0]);
                int dheight = Convert.ToInt32(ThumbnailSize1[1]);
                destDir = System.Web.HttpContext.Current.Server.MapPath(LoadThumbnailPath).Replace("admin\\", "");
                FileName = RiSystem.FormatUpLoadFileName("thumb", FileUpload1.FileName);
                IsUpLoad=RiSystem.UpLoadThumbnail(destDir+FileName, FileUpload1.PostedFile, dwidth, dheight);
                if (IsUpLoad)
                {
                    obj.vc_PicFile2 = FileName;
                }
                else
                {
                    obj.vc_PicFile2 = obj.vc_PicFile1;
                }
                RiSystem.DelItemFile(db, txt_ItemId.Text, true);
            }
            if (txt_ItemId.Text == "")
            {
                obj.vc_Guid = Guid.NewGuid().ToString();
                obj.dt_CreateDate = DateTime.Now;
                objo.Insert(obj);
                RiSystem.AddLog(db, "添加", LoginInfo.RealName + "进行 房产项目 添加操作，相关编号为：" + obj.int_ItemId.ToString(), Request.UserHostAddress, LoginInfo.UserId);
            }
            else
            {
                obj.int_ItemId = Convert.ToInt32(txt_ItemId.Text);
                objo.Update(obj);
                RiSystem.AddLog(db, "修改", LoginInfo.RealName + "进行 房产项目 修改操作，相关编号为：" + obj.int_ItemId.ToString(), Request.UserHostAddress, LoginInfo.UserId);
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