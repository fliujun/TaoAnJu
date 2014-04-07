using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using TaoAnJu.Util;
public partial class Detail : System.Web.UI.Page
{
    string LoadFilePath = System.Configuration.ConfigurationManager.AppSettings["LoadFilePath"];
    string LoadThumbnailPath = System.Configuration.ConfigurationManager.AppSettings["LoadThumbnailPath"];
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["itemid"]))
            {
                DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
                try
                {
                    InitViewInfo(db);
                    InitPicInfo(db);
                    ItemDetail(db);
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
    //获取项目视频
    protected void InitViewInfo(DsConnectionDB db)
    {
        string sql = "select vc_ViewFile,vc_ViewDesc from tb_ViewInfo where int_ItemId=" + Request["itemid"] + " order by int_Vid desc";
        DataTable dt = db.ExecuteQuery(sql).Tables[0];
    }
    //获取项目图片
    protected void InitPicInfo(DsConnectionDB db)
    {
        //vc_PicType 图片类型
        string sql = "select vc_PicFile,vc_PicDesc,vc_PicType,vc_Pic1 from tb_PicInfo where int_ItemId=" + Request["itemid"] + " order by vc_PicType,int_Pid desc";
        DataTable dt = db.ExecuteQuery(sql).Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["vc_PicFile"] = LoadFilePath.Replace("\\", "/") + Request["itemid"] + "/" + dt.Rows[i]["vc_PicFile"].ToString();
            dt.Rows[i]["vc_Pic1"] = LoadThumbnailPath.Replace("\\", "/") + Request["itemid"] + "/" + dt.Rows[i]["vc_Pic1"].ToString();
        }
    }
    //获取项目明细信息
    protected void ItemDetail(DsConnectionDB db)
    {
        tb_ItemInfoEntity_Op objo = new tb_ItemInfoEntity_Op(db);
        tb_ItemInfoEntity obj = objo.GetByPrimaryKey(Convert.ToInt32(Request["itemid"]));
        if (obj != null)
        {
            //项目主图
            string PicFile1 = LoadFilePath.Replace("\\", "/") + obj.vc_PicFile1.ToString();
            //所在区域
            string Area = obj.vc_Area.ToString();
            //建筑设计
            string BuildDesign = obj.vc_BuildDesign.ToString();
            //建筑面积
            string BuildedArea = (!obj.dec_BuildedAreaNull && obj.dec_BuildedArea > 0) ? obj.dec_BuildedArea.ToString() : "";
            //建筑类别
            string BuildType = obj.vc_BuildType.ToString();
            //所属商圈
            string BusinessZone = obj.vc_BusinessZone.ToString();
            //入住时间
            string CheckinTime = (!obj.dt_CheckinTimeNull) ? obj.dt_CheckinTime.ToString("yyyy-MM-dd") : "";
            //配套信息
            string ConfigureInfo = obj.vc_ConfigureInfo.ToString();
            //承建商
            string Contractor = obj.vc_Contractor.ToString();
            //占地面积
            string CoveredArea = (!obj.dec_CoveredAreaNull && obj.dec_CoveredArea > 0) ? obj.dec_CoveredArea.ToString() : "";
            //装修情况
            string Decoration = obj.vc_Decoration.ToString();
            //开发商
            string Developer = obj.vc_Developer.ToString();
            //打折优惠
            string Discount = obj.vc_Discount.ToString();
            //楼层状况
            string FloorCondition = obj.vc_FloorCondition.ToString();
            //供气
            string GasSupply = obj.vc_GasSupply.ToString();
            //绿化率
            string GreenRate = (!obj.dec_GreenRateNull && obj.dec_GreenRate > 0) ? Convert.ToString(100 * obj.dec_GreenRate) + "%" : "";
            //供暖
            string Heating = obj.vc_Heating.ToString();
            //咨询热线
            string Hotline = obj.vc_Hotline.ToString();
            //户型
            string HouseType = obj.vc_HouseType.ToString();
            //楼盘简介
            string Introduction = obj.vc_Introduction.ToString();
            //项目名称
            string ItemName = obj.vc_ItemName.ToString();
            //景观设计
            string LandscapeDesign = obj.vc_LandscapeDesign.ToString();
            //楼盘地址
            string Location = obj.vc_Location.ToString();
            //开盘时间
            string OpeningTime = (!obj.dt_OpeningTimeNull) ? obj.dt_OpeningTime.ToString("yyyy-MM-dd") : "";
            //停车位
            string ParkingSpace = obj.vc_ParkingSpace.ToString();
            //项目特色
            string ProjectFeatures = obj.vc_ProjectFeatures.ToString();
            //物业公司
            string PropertyCompany = obj.vc_PropertyCompany.ToString();
            //物业费
            string PropertyFee = obj.vc_PropertyFee.ToString();
            //产权年限
            string PropertyRight = (!obj.int_PropertyRightNull && obj.int_PropertyRight > 0) ? obj.int_PropertyRight.ToString() + "年" : "";
            //物业类别
            string PropertyType = obj.vc_PropertyType.ToString();
            //价格
            string ReferencePrice = (!obj.dec_ReferencePriceNull && obj.dec_ReferencePrice > 0) ? "￥" + obj.dec_ReferencePrice.ToString() + "/㎡" : "";
            //售楼地址
            string SalesLocation = obj.vc_SalesLocation.ToString();
            //售楼许可证
            string SalesPermit = obj.vc_SalesPermit.ToString();
            //交通出行
            string Traffic = obj.vc_Traffic.ToString();
            //容积率
            string VolumeRate = (!obj.dec_VolumeRateNull && obj.dec_VolumeRate > 0) ? obj.dec_VolumeRate.ToString() : "";
            //供水
            string WaterSupply = obj.vc_WaterSupply.ToString();
            //销售状态
            string SalesStatus = obj.vc_SalesStatus.ToString();
        }
    }
}