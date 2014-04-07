using System;
using System.Data;
using System.Data.SqlClient;
using TaoAnJu.Util;

namespace TaoAnJu.Util
{

    public class tb_ItemInfoEntity_Op
    {
        private DsConnectionDB _db;

        public tb_ItemInfoEntity_Op(DsConnectionDB db)
        {
            _db = db;
        }

        protected DsConnectionDB Database
        {
            get { return _db; }
        }

        public virtual tb_ItemInfoEntity[] GetAll()
        {
            using (SqlDataReader reader = _db.ExecuteReader(CreateGetAllCommand()))
            {
                return MapRecords(reader);
            }
        }


        protected virtual SqlCommand CreateGetAllCommand()
        {
            return CreateGetCommand(null, null);
        }

        public tb_ItemInfoEntity[] GetAsArray(string whereSql, string orderBySql)
        {
            int totalRecordCount = -1;
            return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
        }

        public virtual tb_ItemInfoEntity[] GetAsArray(string whereSql, string orderBySql,
            int startIndex, int length, ref int totalRecordCount)
        {
            using (SqlDataReader reader = _db.ExecuteReader(CreateGetCommand(whereSql, orderBySql)))
            {
                return MapRecords(reader, startIndex, length, ref totalRecordCount);
            }
        }

        protected virtual SqlCommand CreateGetCommand(string whereSql, string orderBySql)
        {
            string sql = "SELECT * FROM tb_ItemInfo";
            if (null != whereSql && 0 < whereSql.Length)
                sql += " WHERE " + whereSql;
            if (null != orderBySql && 0 < orderBySql.Length)
                sql += " ORDER BY " + orderBySql;
            return _db.CreateCommand(sql);
        }

        public virtual tb_ItemInfoEntity GetByPrimaryKey(int int_ItemId)
        {
            string whereSql = "";
            whereSql += "int_ItemId=@int_ItemId ";

            SqlCommand cmd = CreateGetCommand(whereSql, null);
            AddParameter(cmd, "int_ItemId", int_ItemId);

            using (SqlDataReader reader = _db.ExecuteReader(cmd))
            {
                tb_ItemInfoEntity[] tempArray = MapRecords(reader);
                return 0 == tempArray.Length ? null : tempArray[0];
            }
        }

        /// <summary>
        /// Adds a new record into the <c>WL_YEAR_WORK_MD</c> table.
        /// </summary>
        /// <param name="value">The <see cref="tb_ItemInfoEntity"/> object to be inserted.</param>
        public virtual void Insert(tb_ItemInfoEntity value)
        {
            string sqlStr = "INSERT INTO tb_ItemInfo(";
            if (null != value.vc_Guid)
                sqlStr += "vc_Guid,";
            if (null != value.vc_ItemName)
                sqlStr += "vc_ItemName,";
            if (null != value.vc_City)
                sqlStr += "vc_City,";
            if (null != value.vc_Area)
                sqlStr += "vc_Area,";
            if (null != value.vc_BusinessZone)
                sqlStr += "vc_BusinessZone,";
            if (null != value.vc_Location)
                sqlStr += "vc_Location,";
            if (null != value.vc_ProjectFeatures)
                sqlStr += "vc_ProjectFeatures,";
            if (null != value.vc_Developer)
                sqlStr += "vc_Developer,";
            if (null != value.vc_Introduction)
                sqlStr += "vc_Introduction,";
            if (!value.dt_OpeningTimeNull)
                sqlStr += "dt_OpeningTime,";
            if (!value.dt_CheckinTimeNull)
                sqlStr += "dt_CheckinTime,";
            if (!value.dec_ReferencePriceNull)
                sqlStr += "dec_ReferencePrice,";
            if (null != value.vc_Discount)
                sqlStr += "vc_Discount,";
            if (null != value.vc_Hotline)
                sqlStr += "vc_Hotline,";
            if (null != value.vc_SalesLocation)
                sqlStr += "vc_SalesLocation,";
            if (null != value.vc_SalesPermit)
                sqlStr += "vc_SalesPermit,";
            if (!value.int_PropertyRightNull)
                sqlStr += "int_PropertyRight,";
            if (null != value.vc_HouseType)
                sqlStr += "vc_HouseType,";
            if (!value.dec_BuildedAreaNull)
                sqlStr += "dec_BuildedArea,";
            if (!value.dec_CoveredAreaNull)
                sqlStr += "dec_CoveredArea,";
            if (null != value.vc_BuildType)
                sqlStr += "vc_BuildType,";
            if (null != value.vc_Decoration)
                sqlStr += "vc_Decoration,";
            if (null != value.vc_FloorCondition)
                sqlStr += "vc_FloorCondition,";
            if (null != value.vc_BuildDesign)
                sqlStr += "vc_BuildDesign,";
            if (null != value.vc_Contractor)
                sqlStr += "vc_Contractor,";
            if (null != value.vc_LandscapeDesign)
                sqlStr += "vc_LandscapeDesign,";
            if (null != value.vc_PropertyType)
                sqlStr += "vc_PropertyType,";
            if (!value.dec_VolumeRateNull)
                sqlStr += "dec_VolumeRate,";
            if (!value.dec_GreenRateNull)
                sqlStr += "dec_GreenRate,";
            if (null != value.vc_WaterSupply)
                sqlStr += "vc_WaterSupply,";
            if (null != value.vc_Heating)
                sqlStr += "vc_Heating,";
            if (null != value.vc_GasSupply)
                sqlStr += "vc_GasSupply,";
            if (null != value.vc_PropertyCompany)
                sqlStr += "vc_PropertyCompany,";
            if (null != value.vc_PropertyFee)
                sqlStr += "vc_PropertyFee,";
            if (null != value.vc_ParkingSpace)
                sqlStr += "vc_ParkingSpace,";
            if (null != value.vc_Traffic)
                sqlStr += "vc_Traffic,";
            if (null != value.vc_ConfigureInfo)
                sqlStr += "vc_ConfigureInfo,";
            if (null != value.vc_PicFile1)
                sqlStr += "vc_PicFile1,";
            if (null != value.vc_PicFile2)
                sqlStr += "vc_PicFile2,";
            if (null != value.vc_SalesStatus)
                sqlStr += "vc_SalesStatus,";
            if (!value.dt_UpdateTimeNull)
                sqlStr += "dt_UpdateTime,";
            if (!value.dt_CreateDateNull)
                sqlStr += "dt_CreateDate,";
            if (!value.int_IsPayNull)
                sqlStr += "int_IsPay,";
            if (!value.int_OrderNull)
                sqlStr += "int_Order,";
            if (!value.int_StatusNull)
                sqlStr += "int_Status,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += ")  VALUES (";
            if (null != value.vc_Guid)
                sqlStr += "@vc_Guid,";
            if (null != value.vc_ItemName)
                sqlStr += "@vc_ItemName,";
            if (null != value.vc_City)
                sqlStr += "@vc_City,";
            if (null != value.vc_Area)
                sqlStr += "@vc_Area,";
            if (null != value.vc_BusinessZone)
                sqlStr += "@vc_BusinessZone,";
            if (null != value.vc_Location)
                sqlStr += "@vc_Location,";
            if (null != value.vc_ProjectFeatures)
                sqlStr += "@vc_ProjectFeatures,";
            if (null != value.vc_Developer)
                sqlStr += "@vc_Developer,";
            if (null != value.vc_Introduction)
                sqlStr += "@vc_Introduction,";
            if (!value.dt_OpeningTimeNull)
                sqlStr += "@dt_OpeningTime,";
            if (!value.dt_CheckinTimeNull)
                sqlStr += "@dt_CheckinTime,";
            if (!value.dec_ReferencePriceNull)
                sqlStr += "@dec_ReferencePrice,";
            if (null != value.vc_Discount)
                sqlStr += "@vc_Discount,";
            if (null != value.vc_Hotline)
                sqlStr += "@vc_Hotline,";
            if (null != value.vc_SalesLocation)
                sqlStr += "@vc_SalesLocation,";
            if (null != value.vc_SalesPermit)
                sqlStr += "@vc_SalesPermit,";
            if (!value.int_PropertyRightNull)
                sqlStr += "@int_PropertyRight,";
            if (null != value.vc_HouseType)
                sqlStr += "@vc_HouseType,";
            if (!value.dec_BuildedAreaNull)
                sqlStr += "@dec_BuildedArea,";
            if (!value.dec_CoveredAreaNull)
                sqlStr += "@dec_CoveredArea,";
            if (null != value.vc_BuildType)
                sqlStr += "@vc_BuildType,";
            if (null != value.vc_Decoration)
                sqlStr += "@vc_Decoration,";
            if (null != value.vc_FloorCondition)
                sqlStr += "@vc_FloorCondition,";
            if (null != value.vc_BuildDesign)
                sqlStr += "@vc_BuildDesign,";
            if (null != value.vc_Contractor)
                sqlStr += "@vc_Contractor,";
            if (null != value.vc_LandscapeDesign)
                sqlStr += "@vc_LandscapeDesign,";
            if (null != value.vc_PropertyType)
                sqlStr += "@vc_PropertyType,";
            if (!value.dec_VolumeRateNull)
                sqlStr += "@dec_VolumeRate,";
            if (!value.dec_GreenRateNull)
                sqlStr += "@dec_GreenRate,";
            if (null != value.vc_WaterSupply)
                sqlStr += "@vc_WaterSupply,";
            if (null != value.vc_Heating)
                sqlStr += "@vc_Heating,";
            if (null != value.vc_GasSupply)
                sqlStr += "@vc_GasSupply,";
            if (null != value.vc_PropertyCompany)
                sqlStr += "@vc_PropertyCompany,";
            if (null != value.vc_PropertyFee)
                sqlStr += "@vc_PropertyFee,";
            if (null != value.vc_ParkingSpace)
                sqlStr += "@vc_ParkingSpace,";
            if (null != value.vc_Traffic)
                sqlStr += "@vc_Traffic,";
            if (null != value.vc_ConfigureInfo)
                sqlStr += "@vc_ConfigureInfo,";
            if (null != value.vc_PicFile1)
                sqlStr += "@vc_PicFile1,";
            if (null != value.vc_PicFile2)
                sqlStr += "@vc_PicFile2,";
            if (null != value.vc_SalesStatus)
                sqlStr += "@vc_SalesStatus,";
            if (!value.dt_UpdateTimeNull)
                sqlStr += "@dt_UpdateTime,";
            if (!value.dt_CreateDateNull)
                sqlStr += "@dt_CreateDate,";
            if (!value.int_IsPayNull)
                sqlStr += "@int_IsPay,";
            if (!value.int_OrderNull)
                sqlStr += "@int_Order,";
            if (!value.int_StatusNull)
                sqlStr += "@int_Status,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += ");SELECT @@IDENTITY";
            SqlCommand cmd = _db.CreateCommand(sqlStr);
            if (null != value.vc_Guid)
                AddParameter(cmd, "vc_Guid", value.vc_Guid);
            if (null != value.vc_ItemName)
                AddParameter(cmd, "vc_ItemName", value.vc_ItemName);
            if (null != value.vc_City)
                AddParameter(cmd, "vc_City", value.vc_City);
            if (null != value.vc_Area)
                AddParameter(cmd, "vc_Area", value.vc_Area);
            if (null != value.vc_BusinessZone)
                AddParameter(cmd, "vc_BusinessZone", value.vc_BusinessZone);
            if (null != value.vc_Location)
                AddParameter(cmd, "vc_Location", value.vc_Location);
            if (null != value.vc_ProjectFeatures)
                AddParameter(cmd, "vc_ProjectFeatures", value.vc_ProjectFeatures);
            if (null != value.vc_Developer)
                AddParameter(cmd, "vc_Developer", value.vc_Developer);
            if (null != value.vc_Introduction)
                AddParameter(cmd, "vc_Introduction", value.vc_Introduction);
            if (!value.dt_OpeningTimeNull)
                AddParameter(cmd, "dt_OpeningTime", (object)value.dt_OpeningTime);
            if (!value.dt_CheckinTimeNull)
                AddParameter(cmd, "dt_CheckinTime", (object)value.dt_CheckinTime);
            if (!value.dec_ReferencePriceNull)
                AddParameter(cmd, "dec_ReferencePrice", (object)value.dec_ReferencePrice);
            if (null != value.vc_Discount)
                AddParameter(cmd, "vc_Discount", value.vc_Discount);
            if (null != value.vc_Hotline)
                AddParameter(cmd, "vc_Hotline", value.vc_Hotline);
            if (null != value.vc_SalesLocation)
                AddParameter(cmd, "vc_SalesLocation", value.vc_SalesLocation);
            if (null != value.vc_SalesPermit)
                AddParameter(cmd, "vc_SalesPermit", value.vc_SalesPermit);
            if (!value.int_PropertyRightNull)
                AddParameter(cmd, "int_PropertyRight", (object)value.int_PropertyRight);
            if (null != value.vc_HouseType)
                AddParameter(cmd, "vc_HouseType", value.vc_HouseType);
            if (!value.dec_BuildedAreaNull)
                AddParameter(cmd, "dec_BuildedArea", (object)value.dec_BuildedArea);
            if (!value.dec_CoveredAreaNull)
                AddParameter(cmd, "dec_CoveredArea", (object)value.dec_CoveredArea);
            if (null != value.vc_BuildType)
                AddParameter(cmd, "vc_BuildType", value.vc_BuildType);
            if (null != value.vc_Decoration)
                AddParameter(cmd, "vc_Decoration", value.vc_Decoration);
            if (null != value.vc_FloorCondition)
                AddParameter(cmd, "vc_FloorCondition", value.vc_FloorCondition);
            if (null != value.vc_BuildDesign)
                AddParameter(cmd, "vc_BuildDesign", value.vc_BuildDesign);
            if (null != value.vc_Contractor)
                AddParameter(cmd, "vc_Contractor", value.vc_Contractor);
            if (null != value.vc_LandscapeDesign)
                AddParameter(cmd, "vc_LandscapeDesign", value.vc_LandscapeDesign);
            if (null != value.vc_PropertyType)
                AddParameter(cmd, "vc_PropertyType", value.vc_PropertyType);
            if (!value.dec_VolumeRateNull)
                AddParameter(cmd, "dec_VolumeRate", (object)value.dec_VolumeRate);
            if (!value.dec_GreenRateNull)
                AddParameter(cmd, "dec_GreenRate", (object)value.dec_GreenRate);
            if (null != value.vc_WaterSupply)
                AddParameter(cmd, "vc_WaterSupply", value.vc_WaterSupply);
            if (null != value.vc_Heating)
                AddParameter(cmd, "vc_Heating", value.vc_Heating);
            if (null != value.vc_GasSupply)
                AddParameter(cmd, "vc_GasSupply", value.vc_GasSupply);
            if (null != value.vc_PropertyCompany)
                AddParameter(cmd, "vc_PropertyCompany", value.vc_PropertyCompany);
            if (null != value.vc_PropertyFee)
                AddParameter(cmd, "vc_PropertyFee", value.vc_PropertyFee);
            if (null != value.vc_ParkingSpace)
                AddParameter(cmd, "vc_ParkingSpace", value.vc_ParkingSpace);
            if (null != value.vc_Traffic)
                AddParameter(cmd, "vc_Traffic", value.vc_Traffic);
            if (null != value.vc_ConfigureInfo)
                AddParameter(cmd, "vc_ConfigureInfo", value.vc_ConfigureInfo);
            if (null != value.vc_PicFile1)
                AddParameter(cmd, "vc_PicFile1", value.vc_PicFile1);
            if (null != value.vc_PicFile2)
                AddParameter(cmd, "vc_PicFile2", value.vc_PicFile2);
            if (null != value.vc_SalesStatus)
                AddParameter(cmd, "vc_SalesStatus", value.vc_SalesStatus);
            if (!value.dt_UpdateTimeNull)
                AddParameter(cmd, "dt_UpdateTime", (object)value.dt_UpdateTime);
            if (!value.dt_CreateDateNull)
                AddParameter(cmd, "dt_CreateDate", (object)value.dt_CreateDate);
            if (!value.int_IsPayNull)
                AddParameter(cmd, "int_IsPay", (object)value.int_IsPay);
            if (!value.int_OrderNull)
                AddParameter(cmd, "int_Order", (object)value.int_Order);
            if (!value.int_StatusNull)
                AddParameter(cmd, "int_Status", (object)value.int_Status);

            value.int_ItemId = Convert.ToInt32(cmd.ExecuteScalar());

        }

        /// <summary>
        /// 更新部分字段操作.
        /// </summary>
        /// <param name="value"><see cref="tb_ItemInfoEntity"/>
        /// 如果传入的值为空,则不升级该字段</param>
        /// <returns>影响的行数</returns>
        public virtual int Update(tb_ItemInfoEntity value)
        {
            string sqlStr = "UPDATE tb_ItemInfo SET ";
            if (null != value.vc_Guid)
                sqlStr += "vc_Guid=@vc_Guid,";
            if (null != value.vc_ItemName)
                sqlStr += "vc_ItemName=@vc_ItemName,";
            if (null != value.vc_City)
                sqlStr += "vc_City=@vc_City,";
            if (null != value.vc_Area)
                sqlStr += "vc_Area=@vc_Area,";
            if (null != value.vc_BusinessZone)
                sqlStr += "vc_BusinessZone=@vc_BusinessZone,";
            if (null != value.vc_Location)
                sqlStr += "vc_Location=@vc_Location,";
            if (null != value.vc_ProjectFeatures)
                sqlStr += "vc_ProjectFeatures=@vc_ProjectFeatures,";
            if (null != value.vc_Developer)
                sqlStr += "vc_Developer=@vc_Developer,";
            if (null != value.vc_Introduction)
                sqlStr += "vc_Introduction=@vc_Introduction,";
            if (!value.dt_OpeningTimeNull)
                sqlStr += "dt_OpeningTime=@dt_OpeningTime,";
            if (!value.dt_CheckinTimeNull)
                sqlStr += "dt_CheckinTime=@dt_CheckinTime,";
            if (!value.dec_ReferencePriceNull)
                sqlStr += "dec_ReferencePrice=@dec_ReferencePrice,";
            if (null != value.vc_Discount)
                sqlStr += "vc_Discount=@vc_Discount,";
            if (null != value.vc_Hotline)
                sqlStr += "vc_Hotline=@vc_Hotline,";
            if (null != value.vc_SalesLocation)
                sqlStr += "vc_SalesLocation=@vc_SalesLocation,";
            if (null != value.vc_SalesPermit)
                sqlStr += "vc_SalesPermit=@vc_SalesPermit,";
            if (!value.int_PropertyRightNull)
                sqlStr += "int_PropertyRight=@int_PropertyRight,";
            if (null != value.vc_HouseType)
                sqlStr += "vc_HouseType=@vc_HouseType,";
            if (!value.dec_BuildedAreaNull)
                sqlStr += "dec_BuildedArea=@dec_BuildedArea,";
            if (!value.dec_CoveredAreaNull)
                sqlStr += "dec_CoveredArea=@dec_CoveredArea,";
            if (null != value.vc_BuildType)
                sqlStr += "vc_BuildType=@vc_BuildType,";
            if (null != value.vc_Decoration)
                sqlStr += "vc_Decoration=@vc_Decoration,";
            if (null != value.vc_FloorCondition)
                sqlStr += "vc_FloorCondition=@vc_FloorCondition,";
            if (null != value.vc_BuildDesign)
                sqlStr += "vc_BuildDesign=@vc_BuildDesign,";
            if (null != value.vc_Contractor)
                sqlStr += "vc_Contractor=@vc_Contractor,";
            if (null != value.vc_LandscapeDesign)
                sqlStr += "vc_LandscapeDesign=@vc_LandscapeDesign,";
            if (null != value.vc_PropertyType)
                sqlStr += "vc_PropertyType=@vc_PropertyType,";
            if (!value.dec_VolumeRateNull)
                sqlStr += "dec_VolumeRate=@dec_VolumeRate,";
            if (!value.dec_GreenRateNull)
                sqlStr += "dec_GreenRate=@dec_GreenRate,";
            if (null != value.vc_WaterSupply)
                sqlStr += "vc_WaterSupply=@vc_WaterSupply,";
            if (null != value.vc_Heating)
                sqlStr += "vc_Heating=@vc_Heating,";
            if (null != value.vc_GasSupply)
                sqlStr += "vc_GasSupply=@vc_GasSupply,";
            if (null != value.vc_PropertyCompany)
                sqlStr += "vc_PropertyCompany=@vc_PropertyCompany,";
            if (null != value.vc_PropertyFee)
                sqlStr += "vc_PropertyFee=@vc_PropertyFee,";
            if (null != value.vc_ParkingSpace)
                sqlStr += "vc_ParkingSpace=@vc_ParkingSpace,";
            if (null != value.vc_Traffic)
                sqlStr += "vc_Traffic=@vc_Traffic,";
            if (null != value.vc_ConfigureInfo)
                sqlStr += "vc_ConfigureInfo=@vc_ConfigureInfo,";
            if (null != value.vc_PicFile1)
                sqlStr += "vc_PicFile1=@vc_PicFile1,";
            if (null != value.vc_PicFile2)
                sqlStr += "vc_PicFile2=@vc_PicFile2,";
            if (null != value.vc_SalesStatus)
                sqlStr += "vc_SalesStatus=@vc_SalesStatus,";
            if (!value.dt_UpdateTimeNull)
                sqlStr += "dt_UpdateTime=@dt_UpdateTime,";
            if (!value.dt_CreateDateNull)
                sqlStr += "dt_CreateDate=@dt_CreateDate,";
            if (!value.int_IsPayNull)
                sqlStr += "int_IsPay=@int_IsPay,";
            if (!value.int_OrderNull)
                sqlStr += "int_Order=@int_Order,";
            if (!value.int_StatusNull)
                sqlStr += "int_Status=@int_Status,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += " WHERE   ";
            if (!value.int_ItemIdNull)
                sqlStr += "int_ItemId= @int_ItemId";
            SqlCommand cmd = _db.CreateCommand(sqlStr);
            if (null != value.vc_Guid)
                AddParameter(cmd, "vc_Guid", value.vc_Guid);
            if (null != value.vc_ItemName)
                AddParameter(cmd, "vc_ItemName", value.vc_ItemName);
            if (null != value.vc_City)
                AddParameter(cmd, "vc_City", value.vc_City);
            if (null != value.vc_Area)
                AddParameter(cmd, "vc_Area", value.vc_Area);
            if (null != value.vc_BusinessZone)
                AddParameter(cmd, "vc_BusinessZone", value.vc_BusinessZone);
            if (null != value.vc_Location)
                AddParameter(cmd, "vc_Location", value.vc_Location);
            if (null != value.vc_ProjectFeatures)
                AddParameter(cmd, "vc_ProjectFeatures", value.vc_ProjectFeatures);
            if (null != value.vc_Developer)
                AddParameter(cmd, "vc_Developer", value.vc_Developer);
            if (null != value.vc_Introduction)
                AddParameter(cmd, "vc_Introduction", value.vc_Introduction);
            if (!value.dt_OpeningTimeNull)
                AddParameter(cmd, "dt_OpeningTime", (object)value.dt_OpeningTime);
            if (!value.dt_CheckinTimeNull)
                AddParameter(cmd, "dt_CheckinTime", (object)value.dt_CheckinTime);
            if (!value.dec_ReferencePriceNull)
                AddParameter(cmd, "dec_ReferencePrice", (object)value.dec_ReferencePrice);
            if (null != value.vc_Discount)
                AddParameter(cmd, "vc_Discount", value.vc_Discount);
            if (null != value.vc_Hotline)
                AddParameter(cmd, "vc_Hotline", value.vc_Hotline);
            if (null != value.vc_SalesLocation)
                AddParameter(cmd, "vc_SalesLocation", value.vc_SalesLocation);
            if (null != value.vc_SalesPermit)
                AddParameter(cmd, "vc_SalesPermit", value.vc_SalesPermit);
            if (!value.int_PropertyRightNull)
                AddParameter(cmd, "int_PropertyRight", (object)value.int_PropertyRight);
            if (null != value.vc_HouseType)
                AddParameter(cmd, "vc_HouseType", value.vc_HouseType);
            if (!value.dec_BuildedAreaNull)
                AddParameter(cmd, "dec_BuildedArea", (object)value.dec_BuildedArea);
            if (!value.dec_CoveredAreaNull)
                AddParameter(cmd, "dec_CoveredArea", (object)value.dec_CoveredArea);
            if (null != value.vc_BuildType)
                AddParameter(cmd, "vc_BuildType", value.vc_BuildType);
            if (null != value.vc_Decoration)
                AddParameter(cmd, "vc_Decoration", value.vc_Decoration);
            if (null != value.vc_FloorCondition)
                AddParameter(cmd, "vc_FloorCondition", value.vc_FloorCondition);
            if (null != value.vc_BuildDesign)
                AddParameter(cmd, "vc_BuildDesign", value.vc_BuildDesign);
            if (null != value.vc_Contractor)
                AddParameter(cmd, "vc_Contractor", value.vc_Contractor);
            if (null != value.vc_LandscapeDesign)
                AddParameter(cmd, "vc_LandscapeDesign", value.vc_LandscapeDesign);
            if (null != value.vc_PropertyType)
                AddParameter(cmd, "vc_PropertyType", value.vc_PropertyType);
            if (!value.dec_VolumeRateNull)
                AddParameter(cmd, "dec_VolumeRate", (object)value.dec_VolumeRate);
            if (!value.dec_GreenRateNull)
                AddParameter(cmd, "dec_GreenRate", (object)value.dec_GreenRate);
            if (null != value.vc_WaterSupply)
                AddParameter(cmd, "vc_WaterSupply", value.vc_WaterSupply);
            if (null != value.vc_Heating)
                AddParameter(cmd, "vc_Heating", value.vc_Heating);
            if (null != value.vc_GasSupply)
                AddParameter(cmd, "vc_GasSupply", value.vc_GasSupply);
            if (null != value.vc_PropertyCompany)
                AddParameter(cmd, "vc_PropertyCompany", value.vc_PropertyCompany);
            if (null != value.vc_PropertyFee)
                AddParameter(cmd, "vc_PropertyFee", value.vc_PropertyFee);
            if (null != value.vc_ParkingSpace)
                AddParameter(cmd, "vc_ParkingSpace", value.vc_ParkingSpace);
            if (null != value.vc_Traffic)
                AddParameter(cmd, "vc_Traffic", value.vc_Traffic);
            if (null != value.vc_ConfigureInfo)
                AddParameter(cmd, "vc_ConfigureInfo", value.vc_ConfigureInfo);
            if (null != value.vc_PicFile1)
                AddParameter(cmd, "vc_PicFile1", value.vc_PicFile1);
            if (null != value.vc_PicFile2)
                AddParameter(cmd, "vc_PicFile2", value.vc_PicFile2);
            if (null != value.vc_SalesStatus)
                AddParameter(cmd, "vc_SalesStatus", value.vc_SalesStatus);
            if (!value.dt_UpdateTimeNull)
                AddParameter(cmd, "dt_UpdateTime", (object)value.dt_UpdateTime);
            if (!value.dt_CreateDateNull)
                AddParameter(cmd, "dt_CreateDate", (object)value.dt_CreateDate);
            if (!value.int_IsPayNull)
                AddParameter(cmd, "int_IsPay", (object)value.int_IsPay);
            if (!value.int_OrderNull)
                AddParameter(cmd, "int_Order", (object)value.int_Order);
            if (!value.int_StatusNull)
                AddParameter(cmd, "int_Status", (object)value.int_Status);
            if (!value.int_ItemIdNull)
                AddParameter(cmd, "int_ItemId", (object)value.int_ItemId);

            return cmd.ExecuteNonQuery();

        }

        /// <summary>
        /// Deletes the specified object from the <c>tb_ItemInfoEntity</c> table.
        /// </summary>
        /// <param name="value">The <see cref="YearWorkChild"/> object to delete.</param>
        /// <returns>true if the record was deleted; otherwise, false.</returns>
        public int Delete(tb_ItemInfoEntity value)
        {
            return DeleteByPrimaryKey(value.int_ItemId);
        }

        public virtual int DeleteByPrimaryKey(int int_ItemId)
        {
            string whereSql = "";
            whereSql += "int_ItemId=@int_ItemId ";

            SqlCommand cmd = CreateDeleteCommand(whereSql);
            AddParameter(cmd, "int_ItemId", int_ItemId);

            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Deletes <c>tb_ItemInfoEntity</c> records that match the specified criteria.
        /// </summary>
        /// <param name="whereSql">The SQL search condition. 
        /// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
        /// <returns>The number of deleted records.</returns>
        public int Delete(string whereSql)
        {
            return CreateDeleteCommand(whereSql).ExecuteNonQuery();
        }

        /// <summary>
        /// Creates an <see cref="System.Data.SqlCommand"/> object that can be used 
        /// to delete <c>tb_ItemInfoEntity</c> records that match the specified criteria.
        /// </summary>
        /// <param name="whereSql">The SQL search condition. 
        /// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
        /// <returns>A reference to the <see cref="System.Data.SqlCommand"/> object.</returns>
        protected virtual SqlCommand CreateDeleteCommand(string whereSql)
        {
            string sql = "DELETE FROM tb_ItemInfo";
            if (null != whereSql && 0 < whereSql.Length)
                sql += " WHERE " + whereSql;
            return _db.CreateCommand(sql);
        }

        /// <summary>
        /// Reads data from the provided data reader and returns 
        /// an array of mapped objects.
        /// </summary>
        /// <param name="reader">The <see cref="System.Data.SqlDataReader"/> object to read data from the table.</param>
        /// <returns>An array of <see cref="YearWorkChild"/> objects.</returns>
        protected tb_ItemInfoEntity[] MapRecords(SqlDataReader reader)
        {
            int totalRecordCount = -1;
            return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
        }

        /// <summary>
        /// Reads data from the provided data reader and returns 
        /// an array of mapped objects.
        /// </summary>
        /// <param name="reader">The <see cref="System.Data.SqlDataReader"/> object to read data from the table.</param>
        /// <param name="startIndex">The index of the first record to map.</param>
        /// <param name="length">The number of records to map.</param>
        /// <param name="totalRecordCount">A reference parameter that returns the total number 
        /// of records in the reader object if 0 was passed into the method; otherwise it returns -1.</param>
        /// <returns>An array of <see cref="YearWorkChild"/> objects.</returns>
        protected virtual tb_ItemInfoEntity[] MapRecords(SqlDataReader reader,
            int startIndex, int length, ref int totalRecordCount)
        {
            if (0 > startIndex)
                throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
            if (0 > length)
                throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
            int int_ItemIdColumnIndex = reader.GetOrdinal("int_ItemId");
            int vc_GuidColumnIndex = reader.GetOrdinal("vc_Guid");
            int vc_ItemNameColumnIndex = reader.GetOrdinal("vc_ItemName");
            int vc_CityColumnIndex = reader.GetOrdinal("vc_City");
            int vc_AreaColumnIndex = reader.GetOrdinal("vc_Area");
            int vc_BusinessZoneColumnIndex = reader.GetOrdinal("vc_BusinessZone");
            int vc_LocationColumnIndex = reader.GetOrdinal("vc_Location");
            int vc_ProjectFeaturesColumnIndex = reader.GetOrdinal("vc_ProjectFeatures");
            int vc_DeveloperColumnIndex = reader.GetOrdinal("vc_Developer");
            int vc_IntroductionColumnIndex = reader.GetOrdinal("vc_Introduction");
            int dt_OpeningTimeColumnIndex = reader.GetOrdinal("dt_OpeningTime");
            int dt_CheckinTimeColumnIndex = reader.GetOrdinal("dt_CheckinTime");
            int dec_ReferencePriceColumnIndex = reader.GetOrdinal("dec_ReferencePrice");
            int vc_DiscountColumnIndex = reader.GetOrdinal("vc_Discount");
            int vc_HotlineColumnIndex = reader.GetOrdinal("vc_Hotline");
            int vc_SalesLocationColumnIndex = reader.GetOrdinal("vc_SalesLocation");
            int vc_SalesPermitColumnIndex = reader.GetOrdinal("vc_SalesPermit");
            int int_PropertyRightColumnIndex = reader.GetOrdinal("int_PropertyRight");
            int vc_HouseTypeColumnIndex = reader.GetOrdinal("vc_HouseType");
            int dec_BuildedAreaColumnIndex = reader.GetOrdinal("dec_BuildedArea");
            int dec_CoveredAreaColumnIndex = reader.GetOrdinal("dec_CoveredArea");
            int vc_BuildTypeColumnIndex = reader.GetOrdinal("vc_BuildType");
            int vc_DecorationColumnIndex = reader.GetOrdinal("vc_Decoration");
            int vc_FloorConditionColumnIndex = reader.GetOrdinal("vc_FloorCondition");
            int vc_BuildDesignColumnIndex = reader.GetOrdinal("vc_BuildDesign");
            int vc_ContractorColumnIndex = reader.GetOrdinal("vc_Contractor");
            int vc_LandscapeDesignColumnIndex = reader.GetOrdinal("vc_LandscapeDesign");
            int vc_PropertyTypeColumnIndex = reader.GetOrdinal("vc_PropertyType");
            int dec_VolumeRateColumnIndex = reader.GetOrdinal("dec_VolumeRate");
            int dec_GreenRateColumnIndex = reader.GetOrdinal("dec_GreenRate");
            int vc_WaterSupplyColumnIndex = reader.GetOrdinal("vc_WaterSupply");
            int vc_HeatingColumnIndex = reader.GetOrdinal("vc_Heating");
            int vc_GasSupplyColumnIndex = reader.GetOrdinal("vc_GasSupply");
            int vc_PropertyCompanyColumnIndex = reader.GetOrdinal("vc_PropertyCompany");
            int vc_PropertyFeeColumnIndex = reader.GetOrdinal("vc_PropertyFee");
            int vc_ParkingSpaceColumnIndex = reader.GetOrdinal("vc_ParkingSpace");
            int vc_TrafficColumnIndex = reader.GetOrdinal("vc_Traffic");
            int vc_ConfigureInfoColumnIndex = reader.GetOrdinal("vc_ConfigureInfo");
            int vc_PicFile1ColumnIndex = reader.GetOrdinal("vc_PicFile1");
            int vc_PicFile2ColumnIndex = reader.GetOrdinal("vc_PicFile2");
            int vc_SalesStatusColumnIndex = reader.GetOrdinal("vc_SalesStatus");
            int dt_UpdateTimeColumnIndex = reader.GetOrdinal("dt_UpdateTime");
            int dt_CreateDateColumnIndex = reader.GetOrdinal("dt_CreateDate");
            int int_IsPayColumnIndex = reader.GetOrdinal("int_IsPay");
            int int_OrderColumnIndex = reader.GetOrdinal("int_Order");
            int int_StatusColumnIndex = reader.GetOrdinal("int_Status");

            System.Collections.ArrayList recordList = new System.Collections.ArrayList();
            int ri = -startIndex;
            while (reader.Read())
            {
                ri++;
                if (ri > 0 && ri <= length)
                {
                    tb_ItemInfoEntity record = new tb_ItemInfoEntity();
                    recordList.Add(record); if (!reader.IsDBNull(int_ItemIdColumnIndex))
                        record.int_ItemId = Convert.ToInt32(reader.GetValue(int_ItemIdColumnIndex));
                    if (!reader.IsDBNull(vc_GuidColumnIndex))
                        record.vc_Guid = Convert.ToString(reader.GetValue(vc_GuidColumnIndex));
                    if (!reader.IsDBNull(vc_ItemNameColumnIndex))
                        record.vc_ItemName = Convert.ToString(reader.GetValue(vc_ItemNameColumnIndex));
                    if (!reader.IsDBNull(vc_CityColumnIndex))
                        record.vc_City = Convert.ToString(reader.GetValue(vc_CityColumnIndex));
                    if (!reader.IsDBNull(vc_AreaColumnIndex))
                        record.vc_Area = Convert.ToString(reader.GetValue(vc_AreaColumnIndex));
                    if (!reader.IsDBNull(vc_BusinessZoneColumnIndex))
                        record.vc_BusinessZone = Convert.ToString(reader.GetValue(vc_BusinessZoneColumnIndex));
                    if (!reader.IsDBNull(vc_LocationColumnIndex))
                        record.vc_Location = Convert.ToString(reader.GetValue(vc_LocationColumnIndex));
                    if (!reader.IsDBNull(vc_ProjectFeaturesColumnIndex))
                        record.vc_ProjectFeatures = Convert.ToString(reader.GetValue(vc_ProjectFeaturesColumnIndex));
                    if (!reader.IsDBNull(vc_DeveloperColumnIndex))
                        record.vc_Developer = Convert.ToString(reader.GetValue(vc_DeveloperColumnIndex));
                    if (!reader.IsDBNull(vc_IntroductionColumnIndex))
                        record.vc_Introduction = Convert.ToString(reader.GetValue(vc_IntroductionColumnIndex));
                    if (!reader.IsDBNull(dt_OpeningTimeColumnIndex))
                        record.dt_OpeningTime = Convert.ToDateTime(reader.GetValue(dt_OpeningTimeColumnIndex));
                    if (!reader.IsDBNull(dt_CheckinTimeColumnIndex))
                        record.dt_CheckinTime = Convert.ToDateTime(reader.GetValue(dt_CheckinTimeColumnIndex));
                    if (!reader.IsDBNull(dec_ReferencePriceColumnIndex))
                        record.dec_ReferencePrice = Convert.ToDecimal(reader.GetValue(dec_ReferencePriceColumnIndex));
                    if (!reader.IsDBNull(vc_DiscountColumnIndex))
                        record.vc_Discount = Convert.ToString(reader.GetValue(vc_DiscountColumnIndex));
                    if (!reader.IsDBNull(vc_HotlineColumnIndex))
                        record.vc_Hotline = Convert.ToString(reader.GetValue(vc_HotlineColumnIndex));
                    if (!reader.IsDBNull(vc_SalesLocationColumnIndex))
                        record.vc_SalesLocation = Convert.ToString(reader.GetValue(vc_SalesLocationColumnIndex));
                    if (!reader.IsDBNull(vc_SalesPermitColumnIndex))
                        record.vc_SalesPermit = Convert.ToString(reader.GetValue(vc_SalesPermitColumnIndex));
                    if (!reader.IsDBNull(int_PropertyRightColumnIndex))
                        record.int_PropertyRight = Convert.ToInt32(reader.GetValue(int_PropertyRightColumnIndex));
                    if (!reader.IsDBNull(vc_HouseTypeColumnIndex))
                        record.vc_HouseType = Convert.ToString(reader.GetValue(vc_HouseTypeColumnIndex));
                    if (!reader.IsDBNull(dec_BuildedAreaColumnIndex))
                        record.dec_BuildedArea = Convert.ToDecimal(reader.GetValue(dec_BuildedAreaColumnIndex));
                    if (!reader.IsDBNull(dec_CoveredAreaColumnIndex))
                        record.dec_CoveredArea = Convert.ToDecimal(reader.GetValue(dec_CoveredAreaColumnIndex));
                    if (!reader.IsDBNull(vc_BuildTypeColumnIndex))
                        record.vc_BuildType = Convert.ToString(reader.GetValue(vc_BuildTypeColumnIndex));
                    if (!reader.IsDBNull(vc_DecorationColumnIndex))
                        record.vc_Decoration = Convert.ToString(reader.GetValue(vc_DecorationColumnIndex));
                    if (!reader.IsDBNull(vc_FloorConditionColumnIndex))
                        record.vc_FloorCondition = Convert.ToString(reader.GetValue(vc_FloorConditionColumnIndex));
                    if (!reader.IsDBNull(vc_BuildDesignColumnIndex))
                        record.vc_BuildDesign = Convert.ToString(reader.GetValue(vc_BuildDesignColumnIndex));
                    if (!reader.IsDBNull(vc_ContractorColumnIndex))
                        record.vc_Contractor = Convert.ToString(reader.GetValue(vc_ContractorColumnIndex));
                    if (!reader.IsDBNull(vc_LandscapeDesignColumnIndex))
                        record.vc_LandscapeDesign = Convert.ToString(reader.GetValue(vc_LandscapeDesignColumnIndex));
                    if (!reader.IsDBNull(vc_PropertyTypeColumnIndex))
                        record.vc_PropertyType = Convert.ToString(reader.GetValue(vc_PropertyTypeColumnIndex));
                    if (!reader.IsDBNull(dec_VolumeRateColumnIndex))
                        record.dec_VolumeRate = Convert.ToDecimal(reader.GetValue(dec_VolumeRateColumnIndex));
                    if (!reader.IsDBNull(dec_GreenRateColumnIndex))
                        record.dec_GreenRate = Convert.ToDecimal(reader.GetValue(dec_GreenRateColumnIndex));
                    if (!reader.IsDBNull(vc_WaterSupplyColumnIndex))
                        record.vc_WaterSupply = Convert.ToString(reader.GetValue(vc_WaterSupplyColumnIndex));
                    if (!reader.IsDBNull(vc_HeatingColumnIndex))
                        record.vc_Heating = Convert.ToString(reader.GetValue(vc_HeatingColumnIndex));
                    if (!reader.IsDBNull(vc_GasSupplyColumnIndex))
                        record.vc_GasSupply = Convert.ToString(reader.GetValue(vc_GasSupplyColumnIndex));
                    if (!reader.IsDBNull(vc_PropertyCompanyColumnIndex))
                        record.vc_PropertyCompany = Convert.ToString(reader.GetValue(vc_PropertyCompanyColumnIndex));
                    if (!reader.IsDBNull(vc_PropertyFeeColumnIndex))
                        record.vc_PropertyFee = Convert.ToString(reader.GetValue(vc_PropertyFeeColumnIndex));
                    if (!reader.IsDBNull(vc_ParkingSpaceColumnIndex))
                        record.vc_ParkingSpace = Convert.ToString(reader.GetValue(vc_ParkingSpaceColumnIndex));
                    if (!reader.IsDBNull(vc_TrafficColumnIndex))
                        record.vc_Traffic = Convert.ToString(reader.GetValue(vc_TrafficColumnIndex));
                    if (!reader.IsDBNull(vc_ConfigureInfoColumnIndex))
                        record.vc_ConfigureInfo = Convert.ToString(reader.GetValue(vc_ConfigureInfoColumnIndex));
                    if (!reader.IsDBNull(vc_PicFile1ColumnIndex))
                        record.vc_PicFile1 = Convert.ToString(reader.GetValue(vc_PicFile1ColumnIndex));
                    if (!reader.IsDBNull(vc_PicFile2ColumnIndex))
                        record.vc_PicFile2 = Convert.ToString(reader.GetValue(vc_PicFile2ColumnIndex));
                    if (!reader.IsDBNull(vc_SalesStatusColumnIndex))
                        record.vc_SalesStatus = Convert.ToString(reader.GetValue(vc_SalesStatusColumnIndex));
                    if (!reader.IsDBNull(dt_UpdateTimeColumnIndex))
                        record.dt_UpdateTime = Convert.ToDateTime(reader.GetValue(dt_UpdateTimeColumnIndex));
                    if (!reader.IsDBNull(dt_CreateDateColumnIndex))
                        record.dt_CreateDate = Convert.ToDateTime(reader.GetValue(dt_CreateDateColumnIndex));
                    if (!reader.IsDBNull(int_IsPayColumnIndex))
                        record.int_IsPay = Convert.ToInt32(reader.GetValue(int_IsPayColumnIndex));
                    if (!reader.IsDBNull(int_OrderColumnIndex))
                        record.int_Order = Convert.ToInt32(reader.GetValue(int_OrderColumnIndex));
                    if (!reader.IsDBNull(int_StatusColumnIndex))
                        record.int_Status = Convert.ToInt32(reader.GetValue(int_StatusColumnIndex));
                    if (ri == length && 0 != totalRecordCount)
                        break;
                }//end if
            }//end while
            totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
            return (tb_ItemInfoEntity[])(recordList.ToArray(typeof(tb_ItemInfoEntity)));


        }


        /// <summary>
        /// Converts <see cref="System.Data.DataRow"/> to <see cref="tb_ItemInfoEntity"/>.
        /// </summary>
        /// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
        /// <returns>A reference to the <see cref="tb_ItemInfoEntity"/> object.</returns>
        protected virtual tb_ItemInfoEntity MapRow(DataRow row)
        {
            tb_ItemInfoEntity mappedObject = new tb_ItemInfoEntity();
            DataTable dataTable = row.Table;
            DataColumn dataColumn;
            // Column int_ItemId
            dataColumn = dataTable.Columns["int_ItemId"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_ItemId = (int)row[dataColumn];
            // Column vc_Guid
            dataColumn = dataTable.Columns["vc_Guid"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_Guid = (string)row[dataColumn];
            // Column vc_ItemName
            dataColumn = dataTable.Columns["vc_ItemName"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_ItemName = (string)row[dataColumn];
            // Column vc_City
            dataColumn = dataTable.Columns["vc_City"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_City = (string)row[dataColumn];
            // Column vc_Area
            dataColumn = dataTable.Columns["vc_Area"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_Area = (string)row[dataColumn];
            // Column vc_BusinessZone
            dataColumn = dataTable.Columns["vc_BusinessZone"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_BusinessZone = (string)row[dataColumn];
            // Column vc_Location
            dataColumn = dataTable.Columns["vc_Location"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_Location = (string)row[dataColumn];
            // Column vc_ProjectFeatures
            dataColumn = dataTable.Columns["vc_ProjectFeatures"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_ProjectFeatures = (string)row[dataColumn];
            // Column vc_Developer
            dataColumn = dataTable.Columns["vc_Developer"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_Developer = (string)row[dataColumn];
            // Column vc_Introduction
            dataColumn = dataTable.Columns["vc_Introduction"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_Introduction = (string)row[dataColumn];
            // Column dt_OpeningTime
            dataColumn = dataTable.Columns["dt_OpeningTime"];
            if (!row.IsNull(dataColumn))
                mappedObject.dt_OpeningTime = (DateTime)row[dataColumn];
            // Column dt_CheckinTime
            dataColumn = dataTable.Columns["dt_CheckinTime"];
            if (!row.IsNull(dataColumn))
                mappedObject.dt_CheckinTime = (DateTime)row[dataColumn];
            // Column dec_ReferencePrice
            dataColumn = dataTable.Columns["dec_ReferencePrice"];
            if (!row.IsNull(dataColumn))
                mappedObject.dec_ReferencePrice = (decimal)row[dataColumn];
            // Column vc_Discount
            dataColumn = dataTable.Columns["vc_Discount"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_Discount = (string)row[dataColumn];
            // Column vc_Hotline
            dataColumn = dataTable.Columns["vc_Hotline"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_Hotline = (string)row[dataColumn];
            // Column vc_SalesLocation
            dataColumn = dataTable.Columns["vc_SalesLocation"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_SalesLocation = (string)row[dataColumn];
            // Column vc_SalesPermit
            dataColumn = dataTable.Columns["vc_SalesPermit"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_SalesPermit = (string)row[dataColumn];
            // Column int_PropertyRight
            dataColumn = dataTable.Columns["int_PropertyRight"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_PropertyRight = (int)row[dataColumn];
            // Column vc_HouseType
            dataColumn = dataTable.Columns["vc_HouseType"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_HouseType = (string)row[dataColumn];
            // Column dec_BuildedArea
            dataColumn = dataTable.Columns["dec_BuildedArea"];
            if (!row.IsNull(dataColumn))
                mappedObject.dec_BuildedArea = (decimal)row[dataColumn];
            // Column dec_CoveredArea
            dataColumn = dataTable.Columns["dec_CoveredArea"];
            if (!row.IsNull(dataColumn))
                mappedObject.dec_CoveredArea = (decimal)row[dataColumn];
            // Column vc_BuildType
            dataColumn = dataTable.Columns["vc_BuildType"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_BuildType = (string)row[dataColumn];
            // Column vc_Decoration
            dataColumn = dataTable.Columns["vc_Decoration"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_Decoration = (string)row[dataColumn];
            // Column vc_FloorCondition
            dataColumn = dataTable.Columns["vc_FloorCondition"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_FloorCondition = (string)row[dataColumn];
            // Column vc_BuildDesign
            dataColumn = dataTable.Columns["vc_BuildDesign"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_BuildDesign = (string)row[dataColumn];
            // Column vc_Contractor
            dataColumn = dataTable.Columns["vc_Contractor"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_Contractor = (string)row[dataColumn];
            // Column vc_LandscapeDesign
            dataColumn = dataTable.Columns["vc_LandscapeDesign"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_LandscapeDesign = (string)row[dataColumn];
            // Column vc_PropertyType
            dataColumn = dataTable.Columns["vc_PropertyType"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_PropertyType = (string)row[dataColumn];
            // Column dec_VolumeRate
            dataColumn = dataTable.Columns["dec_VolumeRate"];
            if (!row.IsNull(dataColumn))
                mappedObject.dec_VolumeRate = (decimal)row[dataColumn];
            // Column dec_GreenRate
            dataColumn = dataTable.Columns["dec_GreenRate"];
            if (!row.IsNull(dataColumn))
                mappedObject.dec_GreenRate = (decimal)row[dataColumn];
            // Column vc_WaterSupply
            dataColumn = dataTable.Columns["vc_WaterSupply"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_WaterSupply = (string)row[dataColumn];
            // Column vc_Heating
            dataColumn = dataTable.Columns["vc_Heating"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_Heating = (string)row[dataColumn];
            // Column vc_GasSupply
            dataColumn = dataTable.Columns["vc_GasSupply"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_GasSupply = (string)row[dataColumn];
            // Column vc_PropertyCompany
            dataColumn = dataTable.Columns["vc_PropertyCompany"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_PropertyCompany = (string)row[dataColumn];
            // Column vc_PropertyFee
            dataColumn = dataTable.Columns["vc_PropertyFee"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_PropertyFee = (string)row[dataColumn];
            // Column vc_ParkingSpace
            dataColumn = dataTable.Columns["vc_ParkingSpace"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_ParkingSpace = (string)row[dataColumn];
            // Column vc_Traffic
            dataColumn = dataTable.Columns["vc_Traffic"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_Traffic = (string)row[dataColumn];
            // Column vc_ConfigureInfo
            dataColumn = dataTable.Columns["vc_ConfigureInfo"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_ConfigureInfo = (string)row[dataColumn];
            // Column vc_PicFile1
            dataColumn = dataTable.Columns["vc_PicFile1"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_PicFile1 = (string)row[dataColumn];
            // Column vc_PicFile2
            dataColumn = dataTable.Columns["vc_PicFile2"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_PicFile2 = (string)row[dataColumn];
            // Column vc_SalesStatus
            dataColumn = dataTable.Columns["vc_SalesStatus"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_SalesStatus = (string)row[dataColumn];
            // Column dt_UpdateTime
            dataColumn = dataTable.Columns["dt_UpdateTime"];
            if (!row.IsNull(dataColumn))
                mappedObject.dt_UpdateTime = (DateTime)row[dataColumn];
            // Column dt_CreateDate
            dataColumn = dataTable.Columns["dt_CreateDate"];
            if (!row.IsNull(dataColumn))
                mappedObject.dt_CreateDate = (DateTime)row[dataColumn];
            // Column int_IsPay
            dataColumn = dataTable.Columns["int_IsPay"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_IsPay = (int)row[dataColumn];
            // Column int_Order
            dataColumn = dataTable.Columns["int_Order"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_Order = (int)row[dataColumn];
            // Column int_Status
            dataColumn = dataTable.Columns["int_Status"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_Status = (int)row[dataColumn];


            return mappedObject;
        }

        /// <summary>
        /// Creates a <see cref="System.Data.DataTable"/> object for 
        /// the <c>tb_ItemInfoEntity</c> table.
        /// </summary>
        /// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
        protected virtual DataTable CreateDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.TableName = "tb_ItemInfoEntity";
            DataColumn dataColumn;
            dataColumn = dataTable.Columns.Add("int_ItemId", typeof(int));
            dataColumn = dataTable.Columns.Add("vc_Guid", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("vc_ItemName", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("vc_City", typeof(string));
            dataColumn.MaxLength = 20;
            dataColumn = dataTable.Columns.Add("vc_Area", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("vc_BusinessZone", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("vc_Location", typeof(string));
            dataColumn.MaxLength = 100;
            dataColumn = dataTable.Columns.Add("vc_ProjectFeatures", typeof(string));
            dataColumn.MaxLength = 100;
            dataColumn = dataTable.Columns.Add("vc_Developer", typeof(string));
            dataColumn.MaxLength = 100;
            dataColumn = dataTable.Columns.Add("vc_Introduction", typeof(string));
            dataColumn.MaxLength = 4000;
            dataColumn = dataTable.Columns.Add("dt_OpeningTime", typeof(DateTime));
            dataColumn = dataTable.Columns.Add("dt_CheckinTime", typeof(DateTime));
            dataColumn = dataTable.Columns.Add("dec_ReferencePrice", typeof(decimal));
            dataColumn = dataTable.Columns.Add("vc_Discount", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("vc_Hotline", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("vc_SalesLocation", typeof(string));
            dataColumn.MaxLength = 100;
            dataColumn = dataTable.Columns.Add("vc_SalesPermit", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("int_PropertyRight", typeof(int));
            dataColumn = dataTable.Columns.Add("vc_HouseType", typeof(string));
            dataColumn.MaxLength = 500;
            dataColumn = dataTable.Columns.Add("dec_BuildedArea", typeof(decimal));
            dataColumn = dataTable.Columns.Add("dec_CoveredArea", typeof(decimal));
            dataColumn = dataTable.Columns.Add("vc_BuildType", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("vc_Decoration", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("vc_FloorCondition", typeof(string));
            dataColumn.MaxLength = 100;
            dataColumn = dataTable.Columns.Add("vc_BuildDesign", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("vc_Contractor", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("vc_LandscapeDesign", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("vc_PropertyType", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("dec_VolumeRate", typeof(decimal));
            dataColumn = dataTable.Columns.Add("dec_GreenRate", typeof(decimal));
            dataColumn = dataTable.Columns.Add("vc_WaterSupply", typeof(string));
            dataColumn.MaxLength = 20;
            dataColumn = dataTable.Columns.Add("vc_Heating", typeof(string));
            dataColumn.MaxLength = 20;
            dataColumn = dataTable.Columns.Add("vc_GasSupply", typeof(string));
            dataColumn.MaxLength = 20;
            dataColumn = dataTable.Columns.Add("vc_PropertyCompany", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("vc_PropertyFee", typeof(string));
            dataColumn.MaxLength = 100;
            dataColumn = dataTable.Columns.Add("vc_ParkingSpace", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("vc_Traffic", typeof(string));
            dataColumn.MaxLength = 4000;
            dataColumn = dataTable.Columns.Add("vc_ConfigureInfo", typeof(string));
            dataColumn.MaxLength = 4000;
            dataColumn = dataTable.Columns.Add("vc_PicFile1", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("vc_PicFile2", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("vc_SalesStatus", typeof(string));
            dataColumn.MaxLength = 20;
            dataColumn = dataTable.Columns.Add("dt_UpdateTime", typeof(DateTime));
            dataColumn = dataTable.Columns.Add("dt_CreateDate", typeof(DateTime));
            dataColumn = dataTable.Columns.Add("int_IsPay", typeof(int));
            dataColumn = dataTable.Columns.Add("int_Order", typeof(int));
            dataColumn = dataTable.Columns.Add("int_Status", typeof(int));


            return dataTable;
        }

        /// <summary>
        /// Adds a new parameter to the specified command.
        /// </summary>
        /// <param name="cmd">The <see cref="System.Data.SqlCommand"/> object to add the parameter to.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <returns>A reference to the added parameter.</returns>
        protected virtual SqlParameter AddParameter(SqlCommand cmd, string paramName, object value)
        {
            SqlParameter parameter;
            switch (paramName)
            {
                case "int_ItemId":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "vc_Guid":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_ItemName":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_City":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_Area":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_BusinessZone":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_Location":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_ProjectFeatures":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_Developer":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_Introduction":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "dt_OpeningTime":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.DateTime, value);
                    break;
                case "dt_CheckinTime":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.DateTime, value);
                    break;
                case "dec_ReferencePrice":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Decimal, value);
                    break;
                case "vc_Discount":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_Hotline":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_SalesLocation":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_SalesPermit":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "int_PropertyRight":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "vc_HouseType":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "dec_BuildedArea":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Decimal, value);
                    break;
                case "dec_CoveredArea":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Decimal, value);
                    break;
                case "vc_BuildType":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_Decoration":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_FloorCondition":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_BuildDesign":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_Contractor":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_LandscapeDesign":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_PropertyType":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "dec_VolumeRate":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Decimal, value);
                    break;
                case "dec_GreenRate":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Decimal, value);
                    break;
                case "vc_WaterSupply":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_Heating":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_GasSupply":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_PropertyCompany":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_PropertyFee":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_ParkingSpace":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_Traffic":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_ConfigureInfo":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_PicFile1":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_PicFile2":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_SalesStatus":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "dt_UpdateTime":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.DateTime, value);
                    break;
                case "dt_CreateDate":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.DateTime, value);
                    break;
                case "int_IsPay":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "int_Order":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "int_Status":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;


                default:
                    throw new ArgumentException("Unknown parameter name (" + paramName + ").");
            }
            return parameter;
        }
    } // End of  tb_ItemInfoEntity_BaseOp class
}  // End of namespace

