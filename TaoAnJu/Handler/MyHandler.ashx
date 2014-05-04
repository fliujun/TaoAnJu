<%@ WebHandler Language="C#" Class="MyHandler" %>

using System;
using System.Web;
using TaoAnJu.Util;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;

public class MyHandler : IHttpHandler
{

    #region 初始化
    private HttpRequest Request;
    string LoadFilePath = System.Configuration.ConfigurationManager.AppSettings["LoadFilePath"];
    string LoadThumbnailPath = System.Configuration.ConfigurationManager.AppSettings["LoadThumbnailPath"];

    private string getString(string key)
    {
        return Request[key];
    }

    private int getInt(string key)
    {
        int value = -1;
        int.TryParse(Request[key].Trim(), out value);
        return value;
    }

    private DateTime getDateTime(string key)
    {
        DateTime date = Convert.ToDateTime("1900-01-01");
        string value = Request[key];
        if (!string.IsNullOrEmpty(value))
        {
            DateTime.TryParse(value, out date);
        }
        return date;
    }

    private bool getBool(string key)
    {
        bool result = false;
        bool.TryParse(Request[key].Trim(), out result);
        return result;
    }
    #endregion 初始化

    public void ProcessRequest(HttpContext context)
    {
        this.Request = context.Request;
        string method = this.getString("method");
        JsonData Result = new JsonData();
        try
        {
            switch (method)
            {
                case "getCity"://获取城市列表
                    this.getCity(ref Result);
                    break;
                case "initAdInfo"://获取广告信息
                    this.initAdInfo(ref Result);
                    break;
                case "initItemData"://获取项目信息
                    this.initItemData(ref Result);
                    break;
                case "initViewInfo"://获取项目视频
                    this.initViewInfo(ref Result);
                    break;
                case "initPicInfo"://获取项目图片
                    this.initPicInfo(ref Result);
                    break;
                case "itemDetail"://获取项目名细信息
                    this.itemDetail(ref Result);
                    break;
                case "baoming"://报名
                    this.baoming(ref Result);
                    break;
            }
        }
        catch (Exception e)
        {
            Result.SetError(e.Message);
        }

        context.Response.ContentType = "text/plain";
        context.Response.Write(Result.ToString());
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

    /// <summary>
    /// 获取城市列表
    /// </summary>
    private void getCity(ref JsonData Result)
    {
        using (DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal))
        {
            string sql = "select vc_Name from tb_DataConfigInfo where int_ParentId in(select int_DataNormal from tb_FieldInfo where vc_FieldName='vc_City' and int_TbId in(select int_TbId from tb_TableInfo where vc_TableName='tb_ItemInfo'))";
            DataTable dt = db.ExecuteQuery(sql).Tables[0];
            Result.Set("data", dt);
        }
    }

    /// <summary>
    /// 获取广告信息
    /// </summary>
    /// <param name="Result"></param>
    private void initAdInfo(ref JsonData Result)
    {
        using (DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal))
        {
            string LoadAdImagePath = System.Configuration.ConfigurationManager.AppSettings["LoadAdImagePath"];
            //字段分别是广告标题、广告描述、图片文件、广告链接
            string sql = "select vc_AdTitle,vc_AdDesc," + LoadAdImagePath.Replace("\\", "/") + "+vc_AdPicFile as vc_AdPicFile,vc_AdLink where vc_AdType='页头' and int_Static=1 order by int_Order desc,int_Aid desc";
            DataTable dt = db.ExecuteQuery(sql).Tables[0];
            Result.Set("data", dt);
        }
    }

    /// <summary>
    /// 获取项目信息
    /// </summary>
    /// <param name="Result"></param>
    private void initItemData(ref JsonData Result)
    {
        using (DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal))
        {
            int PageNum = this.getInt("PageNum");
            int PageSize = 5;//项目页记录，每次显示多少条

            string LoadThumbnailPath = System.Configuration.ConfigurationManager.AppSettings["LoadThumbnailPath"];
            //显示字段，分别是项目编号，项目名称，楼盘地址，售楼地址，开盘时间，价格，图片缩略图
            //string strFields = "int_ItemId,vc_ItemName,vc_Location,vc_SalesLocation,dt_OpeningTime,dec_ReferencePrice," + LoadThumbnailPath.Replace("\\", "/") + "+vc_PicFile2 as vc_PicFile2";
            string strFields = "int_ItemId,vc_ItemName,int_PropertyRight,vc_Location,vc_SalesLocation,dt_OpeningTime,dec_ReferencePrice,vc_Thumb1,vc_Discount";

            //查询条件，必须是状态为1，付费项目永远显示
            StringBuilder strFilter = new StringBuilder();

            strFilter.Append("int_Status=1 and (int_IsPay=1 or int_itemid>0");

            //页数
            if (!string.IsNullOrEmpty(Request["page"]))
            {
                PageNum = int.Parse(Request["page"]);
            }
            //查询项目名称
            if (!string.IsNullOrEmpty(Request["iname"]))
            {
                strFilter.Append(" and vc_ItemName like '%" + Request["iname"] + "%'");
            }
            //查询所属城市
            if (!string.IsNullOrEmpty(Request["city"]))
            {
                strFilter.Append(" and vc_City='" + Request["city"] + "'");
            }
            //查询户型
            if (!string.IsNullOrEmpty(Request["htype"]))
            {
                strFilter.Append(" and vc_HouseType=" + Request["htype"] + "'");
            }
            //查询价格，可以用区间法
            if (!string.IsNullOrEmpty(Request["price"]))
            {
                strFilter.Append(" and dec_ReferencePrice=" + Request["price"]);
            }
            strFilter.Append(")");
            //所有查询记录
            string sql = "SELECT count(*) FROM tb_ItemInfo where " + strFilter.ToString();

            //当前页记录
            DataTable dt = RiSystem.CurrentDataPage(db, "tb_ItemInfo", strFields, strFilter.ToString(), PageSize, PageNum, "int_IsPay desc,int_Order desc,int_ItemId", true);

            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in dt.Rows)
            {
                string picPath = "";
                if (string.IsNullOrEmpty(dr["vc_Thumb1"].ToString()))
                {
                    picPath = "Content/images/weixin.jpg";
                }
                else
                {
                    picPath = LoadThumbnailPath + dr["vc_Thumb1"];
                }
                string htmls = string.Format(@"<div class='card row'>
                <div class='picDiv col-lg-3 col-md-3 col-sx-3 col-xs-9' style='margin-bottom:10px;'>
                    <a href='detail.html?id={0}' target='_blank'><img src='{1}' style='width:100%;' /></a>
                </div>
                <div class='col-lg-1 col-md-1 col-sx-1 col-xs-3'>{2}
                    <div class='label label-warning'>推荐</div>
                    <div class='label label-primary'>接送</div>
                    <div class='label label-danger'>折扣</div>
                </div>
                <div class='col-lg-8 col-md-8 col-sx-8 col-xs-12'>
                    <a href='detail.html?id={0}'  target='_blank' class='title'>{3}</a>
                    <br /><br />
                    <table class='table table-condensed'>
                        <tr>
                            <td><span class='glyphicon glyphicon-map-marker'>&nbsp;</span>楼盘</td>
                            <td>{4}</td>
                        </tr>
                        <tr>
                            <td><span class='glyphicon glyphicon-map-marker'>&nbsp;</span>售楼处</td>
                            <td>{5}</td>
                        </tr>
                        <tr>
                            <td><span class='glyphicon glyphicon-time'>&nbsp;</span>产权</td>
                            <td>{6}</td>
                        </tr>
                        <tr>
                            <td><span class='glyphicon glyphicon-time'>&nbsp;</span>开盘时间</td>
                            <td>{7}</td>
                        </tr>
                        <tr>
                            <td><span class='glyphicon glyphicon-usd'>&nbsp;</span>参考均价</td>
                            <td>{8}</td>
                        </tr>
                    </table>
                    <button class='btnBuy btn btn-success btn-lg' title='{0}'><span class='glyphicon glyphicon-home'>&nbsp;</span>{9}</button>
                </div>
            </div>", dr["int_ItemId"].ToString(), picPath, "", dr["vc_ItemName"], dr["vc_Location"], dr["vc_SalesLocation"], dr["int_PropertyRight"] + "年", dr["dt_OpeningTime"], "￥" + dr["dec_ReferencePrice"] + "元/㎡", dr["vc_Discount"]);
                sb.Append(htmls);
            }

            Result.Set("PageNum", PageNum);//当前页数
            Result.Set("PageSize", PageSize);//当前页数大小
            Result.Set("RecordCount", dt.Rows.Count);//表格数据
            Result.Set("picPath", LoadThumbnailPath);//缩略图上传路径
            Result.Set("html", sb.ToString());
        }
    }

    /// <summary>
    /// 获取项目视频
    /// </summary>
    /// <param name="Result"></param>
    private void initViewInfo(ref JsonData Result)
    {
        using (DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal))
        {
            string sql = "select vc_ViewFile,vc_ViewDesc from tb_ViewInfo where int_ItemId=" + Request["itemid"] + " order by int_Vid desc";
            DataTable dt = db.ExecuteQuery(sql).Tables[0];
            Result.Set("vedio", dt);
        }
    }

    /// <summary>
    /// 获取项目图片
    /// </summary>
    /// <param name="Result"></param>
    private void initPicInfo(ref JsonData Result)
    {
        using (DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal))
        {
            //vc_PicType 图片类型
            string sql = "select vc_PicFile,vc_PicDesc,vc_PicType,vc_Pic1 from tb_PicInfo where int_ItemId=" + Request["itemid"] + " order by vc_PicType,int_Pid desc";
            DataTable dt = db.ExecuteQuery(sql).Tables[0];

            List<string> list = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["vc_PicFile"] = LoadFilePath.Replace("\\", "/") + Request["itemid"] + "/" + dt.Rows[i]["vc_PicFile"].ToString();
                dt.Rows[i]["vc_Pic1"] = LoadThumbnailPath.Replace("\\", "/") + Request["itemid"] + "/" + dt.Rows[i]["vc_Pic1"].ToString();
                string type = dt.Rows[i]["vc_PicType"].ToString();
                if (!list.Contains(type))
                {
                    list.Add(type);
                }
            }

            List<DataTable> dtlist = new List<DataTable>();
            foreach (var str in list)
            {
                DataRow[] drs = dt.Select("vc_PicType='" + str + "'");
                dtlist.Add(drs.CopyToDataTable());
            }

            Result.Set("pics", dtlist);
        }
    }

    /// <summary>
    /// 获取项目明细信息
    /// </summary>
    /// <param name="Result"></param>
    private void itemDetail(ref JsonData Result)
    {
        using (DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal))
        {
            tb_ItemInfoEntity_Op objo = new tb_ItemInfoEntity_Op(db);
            tb_ItemInfoEntity obj = objo.GetByPrimaryKey(this.getInt("itemid"));

            StringBuilder sb = new StringBuilder();

            if (obj != null)
            {
                //项目主图
                string PicFile1 = LoadFilePath.Replace("\\", "/") + obj.vc_PicFile1.ToString();
                string PicFile2 = LoadFilePath.Replace("\\", "/") + obj.vc_PicFile2.ToString();
                string PicFile3 = LoadFilePath.Replace("\\", "/") + obj.vc_PicFile3.ToString();
                
                //所在区域
                string Area = obj.vc_Area.ToString();
                //建筑设计
                string BuildDesign = obj.vc_BuildDesign.ToString();
                //建筑面积
                string BuildedArea = (!obj.dec_BuildedAreaNull && obj.dec_BuildedArea > 0) ? obj.dec_BuildedArea.ToString() + "㎡" : "";
                //建筑类别
                string BuildType = obj.vc_BuildType.ToString();
                //所属商圈
                string BusinessZone = obj.vc_BusinessZone.ToString();
                //入住时间
                string CheckinTime = (!obj.dt_CheckinTimeNull) ? obj.dt_CheckinTime.ToString("yyyy-MM-dd") : "";
                //配套信息
                string ConfigureInfo = RiSystem.FormatBody(obj.vc_ConfigureInfo.ToString());
                //承建商
                string Contractor = obj.vc_Contractor.ToString();
                //占地面积
                string CoveredArea = (!obj.dec_CoveredAreaNull && obj.dec_CoveredArea > 0) ? obj.dec_CoveredArea.ToString() + "㎡" : "";
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
                string Introduction = RiSystem.FormatBody(obj.vc_Introduction.ToString());
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
                string ReferencePrice = (!obj.dec_ReferencePriceNull && obj.dec_ReferencePrice > 0) ? "￥" + obj.dec_ReferencePrice.ToString() + "元/㎡" : "";
                //售楼地址
                string SalesLocation = obj.vc_SalesLocation.ToString();
                //售楼许可证
                string SalesPermit = obj.vc_SalesPermit.ToString();
                //交通出行
                string Traffic = RiSystem.FormatBody(obj.vc_Traffic.ToString());
                //容积率
                string VolumeRate = (!obj.dec_VolumeRateNull && obj.dec_VolumeRate > 0) ? obj.dec_VolumeRate.ToString()+"%" : "";
                //供水
                string WaterSupply = obj.vc_WaterSupply.ToString();
                //销售状态
                string SalesStatus = obj.vc_SalesStatus.ToString();

                //楼盘简介
                sb.Append(string.Format(@"<div class='row info'>
                        <div class='col-lg-12'>
                            <table class='table table-bordered table-hover table-striped'>
                                <thead>
                                    <tr>
                                        <th colspan='2'><img src='Content/images/title1.jpg' /></th>
                                    </tr>
                                </thead>
                                <tr>
                                    <td colspan='2'>
                                        {0}
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>", Introduction));

                //基本信息
                sb.Append(string.Format(@"<div class='row info'>
                        <div class='col-lg-12'>
                            <table class='table table-bordered table-hover table-striped'>
                                <thead>
                                    <tr>
                                        <th colspan='2'><img src='Content/images/title2.jpg' /></th>
                                    </tr>
                                </thead>
                                <tr><th>所属区县</th><td>{0}</td></tr>
                                <tr><th>所属商圈</th><td>{1}</td></tr>
                                <tr><th>楼盘地址</th><td>{2}</td></tr>
                                <tr><th>销售状态</th><td>{3}</td></tr>
                                <tr><th>项目特色</th><td>{4}</td></tr>
                                <tr><th>开发商</th><td>{5}</td></tr>
                            </table>
                        </div>
                    </div>", Area, BusinessZone, Location, SalesStatus, ProjectFeatures, Developer));

                //销售信息
                sb.Append(string.Format(@"<div class='row info'>
                        <div class='col-lg-12'>
                            <table class='table table-bordered table-hover table-striped'>
                                <thead>
                                    <tr>
                                        <th colspan='2'><img src='Content/images/title3.jpg' /></th>
                                    </tr>
                                </thead>
                                <tr><th>开盘时间</th><td>{0}</td></tr>
                                <tr><th>入住时间</th><td>{1}</td></tr>
                                <tr><th>价格详情</th><td>{2}</td></tr>
                                <tr><th>打折优惠</th><td>{3}</td></tr>
                                <tr><th>咨询热线</th><td>{4}</td></tr>
                                <tr><th>售楼地址</th><td>{5}</td></tr>
                                <tr><th>售楼许可证</th><td>{6}</td></tr>
                            </table>
                        </div>
                    </div>", OpeningTime, CheckinTime, ReferencePrice, Discount, Hotline, SalesLocation, SalesPermit));

                //建筑信息
                sb.Append(string.Format(@"<div class='row info'>
                        <div class='col-lg-12'>
                            <table class='table table-bordered table-hover table-striped'>
                                <thead>
                                    <tr>
                                        <th colspan='2'><img src='Content/images/title4.jpg' /></th>
                                    </tr>
                                </thead>
                                <tr><th>产权年限</th><td>{0}</td></tr>
                                <tr><th>户型</th><td>{1}</td></tr>
                                <tr><th>建筑面积</th><td>{2}</td></tr>
                                <tr><th>占地面积</th><td>{3}</td></tr>
                                <tr><th>建筑类别</th><td>{4}</td></tr>
                                <tr><th>装修情况</th><td>{5}</td></tr>
                                <tr><th>楼层状况</th><td>{6}</td></tr>
                                <tr><th>建筑及园林设计</th><td>{7}</td></tr>
                                <tr><th>景观设计</th><td>{8}</td></tr>
                            </table>
                        </div>
                    </div>", PropertyRight, HouseType, BuildedArea, CoveredArea, BuildType, Decoration, FloorCondition, BuildDesign, LandscapeDesign));

                //物业信息
                sb.Append(string.Format(@"<div class='row info'>
                        <div class='col-lg-12'>
                            <table class='table table-bordered table-hover table-striped'>
                                <thead>
                                    <tr>
                                        <th colspan='2'><img src='Content/images/title5.jpg' /></th>
                                    </tr>
                                </thead>
                                <tr><th>物业类别</th><td>{0}</td></tr>
                                <tr><th>容积率</th><td>{1}</td></tr>
                                <tr><th>绿化率</th><td>{2}</td></tr>
                                <tr><th>供水</th><td>{3}</td></tr>
                                <tr><th>供气</th><td>{4}</td></tr>
                                <tr><th>供暖</th><td>{5}</td></tr>
                                <tr><th>物业公司</th><td>{6}</td></tr>
                                <tr><th>物业费</th><td>{7}</td></tr>
                                <tr><th>停车位</th><td>{8}</td></tr>
                            </table>
                        </div>
                    </div>", PropertyType, VolumeRate, GreenRate, WaterSupply, GasSupply, Heating, PropertyCompany, PropertyFee, ParkingSpace));

                //交通信息
                sb.Append(string.Format(@"<div class='row info'>
                        <div class='col-lg-12'>
                            <table class='table table-bordered table-hover table-striped'>
                                <thead>
                                    <tr>
                                        <th colspan='2'><img src='Content/images/title6.jpg' /></th>
                                    </tr>
                                </thead>
                                <tr>
                                    <th colspan='2'>
                                        楼盘位置，见地图：
                                    </th>
                                </tr>
                                <tr>
                                    <td colspan='2'>
                                        <div id='qqmap'></div>
                                    </td>
                                </tr>
                                <tr><th>交通信息</th><td>{0}</td></tr>
                                <tr><th>周边配套</th><td>{1}</td></tr>
                            </table>
                        </div>
                    </div>", Traffic, ConfigureInfo));
                List<string> sliderPics = new List<string>();
                sliderPics.Add(PicFile1);
                sliderPics.Add(PicFile2);
                sliderPics.Add(PicFile3);
                Result.Set("sliderPics", sliderPics);
                Result.Set("html", sb.ToString());
                Result.Set("ItemName", ItemName);
                Result.Set("Discount", Discount);
                Result.Set("Hotline", Hotline);
                Result.Set("Location", Location);
                Result.Set("ReferencePrice", ReferencePrice);
                Result.Set("OpeningTime", OpeningTime);

                //获取项目视频
                initViewInfo(ref Result);
                //获取项目图片
                initPicInfo(ref Result);
            }
        }
    }

    /// <summary>
    /// 报名
    /// </summary>
    /// <param name="Result"></param>
    private void baoming(ref JsonData Result)
    {
        int id = this.getInt("id");
        string username = this.getString("username");
        string usertel = this.getString("usertel");
        string type = this.getString("type");
        //using (DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal))
        //{
        //    SqlTransaction trans = db.BeginTransaction();
        //    try
        //    {
        //        SqlCommand cmd = db.CreateCommand("insert into tb_RegInfo(int_ItemId,vc_Name,vc_Mobile,dt_CreateDate)values(@id,@username,@usertel,GETDATE())");
        //        db.AddParameter(cmd, "id", SqlDbType.Int, id);
        //        db.AddParameter(cmd, "username", SqlDbType.NVarChar, username);
        //        db.AddParameter(cmd, "usertel", SqlDbType.NVarChar, usertel);
        //        int i = cmd.ExecuteNonQuery();
        //        db.CommitTransaction();
        //        Result.Set("data", i);
        //    }
        //    catch (Exception e)
        //    {
        //        trans.Rollback();
        //        Result.SetError(e.Message);
        //    }
        //}
        DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
        try
        {
            string sql = "select count(*) from tb_RegInfo where int_ItemId=" + id + " and vc_Mobile='" + usertel + "'";
            if ((int)db.ExecuteScalar(sql) > 0)
            {
                Result.SetError("您已经报名，不能对同一楼盘重复提交报名。");
                return;
            }
            tb_RegInfoEntity r = new tb_RegInfoEntity();
            tb_RegInfoEntity_Op ro = new tb_RegInfoEntity_Op(db);
            r.int_ItemId = id;
            r.dt_CreateDate = DateTime.Now;
            r.vc_Mobile = usertel;
            r.vc_Name = username;
            r.vc_From = type;
            ro.Insert(r);
           
            //同时判断客户表里此客户是否存在
            sql = "select count(*) from tb_Customer where vc_Mobile='" + usertel + "'";
            if ((int)db.ExecuteScalar(sql) == 0)
            {
                //不存在则同时添加到客户表
                tb_CustomerEntity c = new tb_CustomerEntity();
                tb_CustomerEntity_Op co = new tb_CustomerEntity_Op(db);
                c.dt_CreateDate = DateTime.Now;
                c.vc_Mobile = usertel;
                c.vc_Name = username;
                c.vc_From = type;
                //自动分配给服务客户数量最少的销售代表，没有销售代表则分配给管理员
                sql = "select top 1 int_UserId from tb_UserInfo order by int_UserType desc,int_CCount asc";
                DataTable dt = db.ExecuteQuery(sql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    c.int_UserId = Convert.ToInt32(dt.Rows[0]["int_UserId"].ToString());
                }
                else
                {
                    c.int_UserId = 0;
                }
                co.Insert(c);
            }
        }
        catch (System.Exception ee)
        {
            Loger.logErr("失败", ee);
            Result.SetError(ee.Message);
        }
        finally
        {
            if (db != null)
            {
                db.Close();
            }
        }
    }
}