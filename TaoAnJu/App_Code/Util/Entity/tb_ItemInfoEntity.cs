using System;

namespace TaoAnJu.Util
{
    public class tb_ItemInfoEntity
    {
        private Int32 _int_ItemId = 0;
        private bool _int_ItemIdNull = true;
        private string _vc_Guid;
        private string _vc_ItemName;
        private string _vc_City;
        private string _vc_Area;
        private string _vc_BusinessZone;
        private string _vc_Location;
        private string _vc_ProjectFeatures;
        private string _vc_Developer;
        private string _vc_Introduction;
        private DateTime _dt_OpeningTime;
        private bool _dt_OpeningTimeNull = true;
        private DateTime _dt_CheckinTime;
        private bool _dt_CheckinTimeNull = true;
        private decimal _dec_ReferencePrice = 0;
        private bool _dec_ReferencePriceNull = true;
        private string _vc_Discount;
        private string _vc_Hotline;
        private string _vc_SalesLocation;
        private string _vc_SalesPermit;
        private Int32 _int_PropertyRight = 0;
        private bool _int_PropertyRightNull = true;
        private string _vc_HouseType;
        private decimal _dec_BuildedArea = 0;
        private bool _dec_BuildedAreaNull = true;
        private decimal _dec_CoveredArea = 0;
        private bool _dec_CoveredAreaNull = true;
        private string _vc_BuildType;
        private string _vc_Decoration;
        private string _vc_FloorCondition;
        private string _vc_BuildDesign;
        private string _vc_Contractor;
        private string _vc_LandscapeDesign;
        private string _vc_PropertyType;
        private decimal _dec_VolumeRate = 0;
        private bool _dec_VolumeRateNull = true;
        private decimal _dec_GreenRate = 0;
        private bool _dec_GreenRateNull = true;
        private string _vc_WaterSupply;
        private string _vc_Heating;
        private string _vc_GasSupply;
        private string _vc_PropertyCompany;
        private string _vc_PropertyFee;
        private string _vc_ParkingSpace;
        private string _vc_Traffic;
        private string _vc_ConfigureInfo;
        private string _vc_PicFile1;
        private string _vc_Thumb1;
        private string _vc_PicFile2;
        private string _vc_PicFile3;
        private string _vc_SalesStatus;
        private DateTime _dt_UpdateTime;
        private bool _dt_UpdateTimeNull = true;
        private DateTime _dt_CreateDate;
        private bool _dt_CreateDateNull = true;
        private Int32 _int_IsPay = 0;
        private bool _int_IsPayNull = true;
        private Int32 _int_Order = 0;
        private bool _int_OrderNull = true;
        private Int32 _int_Status = 0;
        private bool _int_StatusNull = true;

        public tb_ItemInfoEntity() { }
        /// <summary>
        /// 属性 <c>项目编号</c>.
        /// </summary>
        /// <value>对应表中<c>int_ItemId</c>字段的值</value>
        public Int32 int_ItemId
        {
            get { return _int_ItemId; }
            set
            {
                _int_ItemIdNull = false;
                _int_ItemId = value;
            }
        }
        /// <summary>
        /// 属性 <c>项目编号是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_ItemIdNull</c>字段的值</value>
        public bool int_ItemIdNull
        {
            get { return _int_ItemIdNull; }
            set { _int_ItemIdNull = value; }
        }
        /// <summary>
        /// 属性 <c>Guid</c>.
        /// </summary>
        /// <value>对应表中<c>vc_Guid</c>字段的值</value>
        public string vc_Guid
        {
            get { return _vc_Guid; }
            set { _vc_Guid = value; }
        }
        /// <summary>
        /// 属性 <c>项目名称</c>.
        /// </summary>
        /// <value>对应表中<c>vc_ItemName</c>字段的值</value>
        public string vc_ItemName
        {
            get { return _vc_ItemName; }
            set { _vc_ItemName = value; }
        }
        /// <summary>
        /// 属性 <c>所在城市</c>.
        /// </summary>
        /// <value>对应表中<c>vc_City</c>字段的值</value>
        public string vc_City
        {
            get { return _vc_City; }
            set { _vc_City = value; }
        }
        /// <summary>
        /// 属性 <c>所在区域</c>.
        /// </summary>
        /// <value>对应表中<c>vc_Area</c>字段的值</value>
        public string vc_Area
        {
            get { return _vc_Area; }
            set { _vc_Area = value; }
        }
        /// <summary>
        /// 属性 <c>所属商圈</c>.
        /// </summary>
        /// <value>对应表中<c>vc_BusinessZone</c>字段的值</value>
        public string vc_BusinessZone
        {
            get { return _vc_BusinessZone; }
            set { _vc_BusinessZone = value; }
        }
        /// <summary>
        /// 属性 <c>楼盘地址</c>.
        /// </summary>
        /// <value>对应表中<c>vc_Location</c>字段的值</value>
        public string vc_Location
        {
            get { return _vc_Location; }
            set { _vc_Location = value; }
        }
        /// <summary>
        /// 属性 <c>项目特色</c>.
        /// </summary>
        /// <value>对应表中<c>vc_ProjectFeatures</c>字段的值</value>
        public string vc_ProjectFeatures
        {
            get { return _vc_ProjectFeatures; }
            set { _vc_ProjectFeatures = value; }
        }
        /// <summary>
        /// 属性 <c>开发商</c>.
        /// </summary>
        /// <value>对应表中<c>vc_Developer</c>字段的值</value>
        public string vc_Developer
        {
            get { return _vc_Developer; }
            set { _vc_Developer = value; }
        }
        /// <summary>
        /// 属性 <c>楼盘简介</c>.
        /// </summary>
        /// <value>对应表中<c>vc_Introduction</c>字段的值</value>
        public string vc_Introduction
        {
            get { return _vc_Introduction; }
            set { _vc_Introduction = value; }
        }
        /// <summary>
        /// 属性 <c>开盘时间</c>.
        /// </summary>
        /// <value>对应表中<c>dt_OpeningTime</c>字段的值</value>
        public DateTime dt_OpeningTime
        {
            get { return _dt_OpeningTime; }
            set
            {
                _dt_OpeningTimeNull = false;
                _dt_OpeningTime = value;
            }
        }
        /// <summary>
        /// 属性 <c>开盘时间是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>dt_OpeningTimeNull</c>字段的值</value>
        public bool dt_OpeningTimeNull
        {
            get { return _dt_OpeningTimeNull; }
            set { _dt_OpeningTimeNull = value; }
        }
        /// <summary>
        /// 属性 <c>入住时间</c>.
        /// </summary>
        /// <value>对应表中<c>dt_CheckinTime</c>字段的值</value>
        public DateTime dt_CheckinTime
        {
            get { return _dt_CheckinTime; }
            set
            {
                _dt_CheckinTimeNull = false;
                _dt_CheckinTime = value;
            }
        }
        /// <summary>
        /// 属性 <c>入住时间是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>dt_CheckinTimeNull</c>字段的值</value>
        public bool dt_CheckinTimeNull
        {
            get { return _dt_CheckinTimeNull; }
            set { _dt_CheckinTimeNull = value; }
        }
        /// <summary>
        /// 属性 <c>参考价格</c>.
        /// </summary>
        /// <value>对应表中<c>dec_ReferencePrice</c>字段的值</value>
        public decimal dec_ReferencePrice
        {
            get { return _dec_ReferencePrice; }
            set
            {
                _dec_ReferencePriceNull = false;
                _dec_ReferencePrice = value;
            }
        }
        /// <summary>
        /// 属性 <c>参考价格是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>dec_ReferencePriceNull</c>字段的值</value>
        public bool dec_ReferencePriceNull
        {
            get { return _dec_ReferencePriceNull; }
            set { _dec_ReferencePriceNull = value; }
        }
        /// <summary>
        /// 属性 <c>打折优惠</c>.
        /// </summary>
        /// <value>对应表中<c>vc_Discount</c>字段的值</value>
        public string vc_Discount
        {
            get { return _vc_Discount; }
            set { _vc_Discount = value; }
        }
        /// <summary>
        /// 属性 <c>咨询热线</c>.
        /// </summary>
        /// <value>对应表中<c>vc_Hotline</c>字段的值</value>
        public string vc_Hotline
        {
            get { return _vc_Hotline; }
            set { _vc_Hotline = value; }
        }
        /// <summary>
        /// 属性 <c>售楼地址</c>.
        /// </summary>
        /// <value>对应表中<c>vc_SalesLocation</c>字段的值</value>
        public string vc_SalesLocation
        {
            get { return _vc_SalesLocation; }
            set { _vc_SalesLocation = value; }
        }
        /// <summary>
        /// 属性 <c>售楼许可证</c>.
        /// </summary>
        /// <value>对应表中<c>vc_SalesPermit</c>字段的值</value>
        public string vc_SalesPermit
        {
            get { return _vc_SalesPermit; }
            set { _vc_SalesPermit = value; }
        }
        /// <summary>
        /// 属性 <c>产权年限</c>.
        /// </summary>
        /// <value>对应表中<c>int_PropertyRight</c>字段的值</value>
        public Int32 int_PropertyRight
        {
            get { return _int_PropertyRight; }
            set
            {
                _int_PropertyRightNull = false;
                _int_PropertyRight = value;
            }
        }
        /// <summary>
        /// 属性 <c>产权年限是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_PropertyRightNull</c>字段的值</value>
        public bool int_PropertyRightNull
        {
            get { return _int_PropertyRightNull; }
            set { _int_PropertyRightNull = value; }
        }
        /// <summary>
        /// 属性 <c>户型</c>.
        /// </summary>
        /// <value>对应表中<c>vc_HouseType</c>字段的值</value>
        public string vc_HouseType
        {
            get { return _vc_HouseType; }
            set { _vc_HouseType = value; }
        }
        /// <summary>
        /// 属性 <c>建筑面积</c>.
        /// </summary>
        /// <value>对应表中<c>dec_BuildedArea</c>字段的值</value>
        public decimal dec_BuildedArea
        {
            get { return _dec_BuildedArea; }
            set
            {
                _dec_BuildedAreaNull = false;
                _dec_BuildedArea = value;
            }
        }
        /// <summary>
        /// 属性 <c>建筑面积是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>dec_BuildedAreaNull</c>字段的值</value>
        public bool dec_BuildedAreaNull
        {
            get { return _dec_BuildedAreaNull; }
            set { _dec_BuildedAreaNull = value; }
        }
        /// <summary>
        /// 属性 <c>占地面积</c>.
        /// </summary>
        /// <value>对应表中<c>dec_CoveredArea</c>字段的值</value>
        public decimal dec_CoveredArea
        {
            get { return _dec_CoveredArea; }
            set
            {
                _dec_CoveredAreaNull = false;
                _dec_CoveredArea = value;
            }
        }
        /// <summary>
        /// 属性 <c>占地面积是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>dec_CoveredAreaNull</c>字段的值</value>
        public bool dec_CoveredAreaNull
        {
            get { return _dec_CoveredAreaNull; }
            set { _dec_CoveredAreaNull = value; }
        }
        /// <summary>
        /// 属性 <c>建筑类别</c>.
        /// </summary>
        /// <value>对应表中<c>vc_BuildType</c>字段的值</value>
        public string vc_BuildType
        {
            get { return _vc_BuildType; }
            set { _vc_BuildType = value; }
        }
        /// <summary>
        /// 属性 <c>装修情况</c>.
        /// </summary>
        /// <value>对应表中<c>vc_Decoration</c>字段的值</value>
        public string vc_Decoration
        {
            get { return _vc_Decoration; }
            set { _vc_Decoration = value; }
        }
        /// <summary>
        /// 属性 <c>楼层状况</c>.
        /// </summary>
        /// <value>对应表中<c>vc_FloorCondition</c>字段的值</value>
        public string vc_FloorCondition
        {
            get { return _vc_FloorCondition; }
            set { _vc_FloorCondition = value; }
        }
        /// <summary>
        /// 属性 <c>建筑设计</c>.
        /// </summary>
        /// <value>对应表中<c>vc_BuildDesign</c>字段的值</value>
        public string vc_BuildDesign
        {
            get { return _vc_BuildDesign; }
            set { _vc_BuildDesign = value; }
        }
        /// <summary>
        /// 属性 <c>承建商</c>.
        /// </summary>
        /// <value>对应表中<c>vc_Contractor</c>字段的值</value>
        public string vc_Contractor
        {
            get { return _vc_Contractor; }
            set { _vc_Contractor = value; }
        }
        /// <summary>
        /// 属性 <c>景观设计</c>.
        /// </summary>
        /// <value>对应表中<c>vc_LandscapeDesign</c>字段的值</value>
        public string vc_LandscapeDesign
        {
            get { return _vc_LandscapeDesign; }
            set { _vc_LandscapeDesign = value; }
        }
        /// <summary>
        /// 属性 <c>物业类别</c>.
        /// </summary>
        /// <value>对应表中<c>vc_PropertyType</c>字段的值</value>
        public string vc_PropertyType
        {
            get { return _vc_PropertyType; }
            set { _vc_PropertyType = value; }
        }
        /// <summary>
        /// 属性 <c>容积率</c>.
        /// </summary>
        /// <value>对应表中<c>dec_VolumeRate</c>字段的值</value>
        public decimal dec_VolumeRate
        {
            get { return _dec_VolumeRate; }
            set
            {
                _dec_VolumeRateNull = false;
                _dec_VolumeRate = value;
            }
        }
        /// <summary>
        /// 属性 <c>容积率是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>dec_VolumeRateNull</c>字段的值</value>
        public bool dec_VolumeRateNull
        {
            get { return _dec_VolumeRateNull; }
            set { _dec_VolumeRateNull = value; }
        }
        /// <summary>
        /// 属性 <c>绿化率</c>.
        /// </summary>
        /// <value>对应表中<c>dec_GreenRate</c>字段的值</value>
        public decimal dec_GreenRate
        {
            get { return _dec_GreenRate; }
            set
            {
                _dec_GreenRateNull = false;
                _dec_GreenRate = value;
            }
        }
        /// <summary>
        /// 属性 <c>绿化率是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>dec_GreenRateNull</c>字段的值</value>
        public bool dec_GreenRateNull
        {
            get { return _dec_GreenRateNull; }
            set { _dec_GreenRateNull = value; }
        }
        /// <summary>
        /// 属性 <c>供水</c>.
        /// </summary>
        /// <value>对应表中<c>vc_WaterSupply</c>字段的值</value>
        public string vc_WaterSupply
        {
            get { return _vc_WaterSupply; }
            set { _vc_WaterSupply = value; }
        }
        /// <summary>
        /// 属性 <c>供暖</c>.
        /// </summary>
        /// <value>对应表中<c>vc_Heating</c>字段的值</value>
        public string vc_Heating
        {
            get { return _vc_Heating; }
            set { _vc_Heating = value; }
        }
        /// <summary>
        /// 属性 <c>供气</c>.
        /// </summary>
        /// <value>对应表中<c>vc_GasSupply</c>字段的值</value>
        public string vc_GasSupply
        {
            get { return _vc_GasSupply; }
            set { _vc_GasSupply = value; }
        }
        /// <summary>
        /// 属性 <c>物业公司</c>.
        /// </summary>
        /// <value>对应表中<c>vc_PropertyCompany</c>字段的值</value>
        public string vc_PropertyCompany
        {
            get { return _vc_PropertyCompany; }
            set { _vc_PropertyCompany = value; }
        }
        /// <summary>
        /// 属性 <c>物业费</c>.
        /// </summary>
        /// <value>对应表中<c>vc_PropertyFee</c>字段的值</value>
        public string vc_PropertyFee
        {
            get { return _vc_PropertyFee; }
            set { _vc_PropertyFee = value; }
        }
        /// <summary>
        /// 属性 <c>停车位</c>.
        /// </summary>
        /// <value>对应表中<c>vc_ParkingSpace</c>字段的值</value>
        public string vc_ParkingSpace
        {
            get { return _vc_ParkingSpace; }
            set { _vc_ParkingSpace = value; }
        }
        /// <summary>
        /// 属性 <c>交通出行</c>.
        /// </summary>
        /// <value>对应表中<c>vc_Traffic</c>字段的值</value>
        public string vc_Traffic
        {
            get { return _vc_Traffic; }
            set { _vc_Traffic = value; }
        }
        /// <summary>
        /// 属性 <c>配套信息</c>.
        /// </summary>
        /// <value>对应表中<c>vc_ConfigureInfo</c>字段的值</value>
        public string vc_ConfigureInfo
        {
            get { return _vc_ConfigureInfo; }
            set { _vc_ConfigureInfo = value; }
        }
        /// <summary>
        /// 属性 <c>图片1</c>.
        /// </summary>
        /// <value>对应表中<c>vc_PicFile1</c>字段的值</value>
        public string vc_PicFile1
        {
            get { return _vc_PicFile1; }
            set { _vc_PicFile1 = value; }
        }
        /// <summary>
        /// 属性 <c>图片1略缩图</c>.
        /// </summary>
        /// <value>对应表中<c>vc_Thumb1</c>字段的值</value>
        public string vc_Thumb1
        {
            get { return _vc_Thumb1; }
            set { _vc_Thumb1 = value; }
        }
        /// <summary>
        /// 属性 <c>图片2</c>.
        /// </summary>
        /// <value>对应表中<c>vc_PicFile2</c>字段的值</value>
        public string vc_PicFile2
        {
            get { return _vc_PicFile2; }
            set { _vc_PicFile2 = value; }
        }
        /// <summary>
        /// 属性 <c>图片3</c>.
        /// </summary>
        /// <value>对应表中<c>vc_PicFile3</c>字段的值</value>
        public string vc_PicFile3
        {
            get { return _vc_PicFile3; }
            set { _vc_PicFile3 = value; }
        }
        /// <summary>
        /// 属性 <c>销售状态</c>.
        /// </summary>
        /// <value>对应表中<c>vc_SalesStatus</c>字段的值</value>
        public string vc_SalesStatus
        {
            get { return _vc_SalesStatus; }
            set { _vc_SalesStatus = value; }
        }
        /// <summary>
        /// 属性 <c>更新时间</c>.
        /// </summary>
        /// <value>对应表中<c>dt_UpdateTime</c>字段的值</value>
        public DateTime dt_UpdateTime
        {
            get { return _dt_UpdateTime; }
            set
            {
                _dt_UpdateTimeNull = false;
                _dt_UpdateTime = value;
            }
        }
        /// <summary>
        /// 属性 <c>更新时间是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>dt_UpdateTimeNull</c>字段的值</value>
        public bool dt_UpdateTimeNull
        {
            get { return _dt_UpdateTimeNull; }
            set { _dt_UpdateTimeNull = value; }
        }
        /// <summary>
        /// 属性 <c>创建时间</c>.
        /// </summary>
        /// <value>对应表中<c>dt_CreateDate</c>字段的值</value>
        public DateTime dt_CreateDate
        {
            get { return _dt_CreateDate; }
            set
            {
                _dt_CreateDateNull = false;
                _dt_CreateDate = value;
            }
        }
        /// <summary>
        /// 属性 <c>创建时间是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>dt_CreateDateNull</c>字段的值</value>
        public bool dt_CreateDateNull
        {
            get { return _dt_CreateDateNull; }
            set { _dt_CreateDateNull = value; }
        }
        /// <summary>
        /// 属性 <c>是否付费</c>.
        /// </summary>
        /// <value>对应表中<c>int_IsPay</c>字段的值</value>
        public Int32 int_IsPay
        {
            get { return _int_IsPay; }
            set
            {
                _int_IsPayNull = false;
                _int_IsPay = value;
            }
        }
        /// <summary>
        /// 属性 <c>是否付费是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_IsPayNull</c>字段的值</value>
        public bool int_IsPayNull
        {
            get { return _int_IsPayNull; }
            set { _int_IsPayNull = value; }
        }
        /// <summary>
        /// 属性 <c>显示顺序</c>.
        /// </summary>
        /// <value>对应表中<c>int_Order</c>字段的值</value>
        public Int32 int_Order
        {
            get { return _int_Order; }
            set
            {
                _int_OrderNull = false;
                _int_Order = value;
            }
        }
        /// <summary>
        /// 属性 <c>显示顺序是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_OrderNull</c>字段的值</value>
        public bool int_OrderNull
        {
            get { return _int_OrderNull; }
            set { _int_OrderNull = value; }
        }
        /// <summary>
        /// 属性 <c>状态</c>.
        /// </summary>
        /// <value>对应表中<c>int_Status</c>字段的值</value>
        public Int32 int_Status
        {
            get { return _int_Status; }
            set
            {
                _int_StatusNull = false;
                _int_Status = value;
            }
        }
        /// <summary>
        /// 属性 <c>状态是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_StatusNull</c>字段的值</value>
        public bool int_StatusNull
        {
            get { return _int_StatusNull; }
            set { _int_StatusNull = value; }
        }

    }//类定义结束
}//命名空间结束

