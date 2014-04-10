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
        /// ���� <c>��Ŀ���</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_ItemId</c>�ֶε�ֵ</value>
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
        /// ���� <c>��Ŀ����Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_ItemIdNull</c>�ֶε�ֵ</value>
        public bool int_ItemIdNull
        {
            get { return _int_ItemIdNull; }
            set { _int_ItemIdNull = value; }
        }
        /// <summary>
        /// ���� <c>Guid</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_Guid</c>�ֶε�ֵ</value>
        public string vc_Guid
        {
            get { return _vc_Guid; }
            set { _vc_Guid = value; }
        }
        /// <summary>
        /// ���� <c>��Ŀ����</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_ItemName</c>�ֶε�ֵ</value>
        public string vc_ItemName
        {
            get { return _vc_ItemName; }
            set { _vc_ItemName = value; }
        }
        /// <summary>
        /// ���� <c>���ڳ���</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_City</c>�ֶε�ֵ</value>
        public string vc_City
        {
            get { return _vc_City; }
            set { _vc_City = value; }
        }
        /// <summary>
        /// ���� <c>��������</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_Area</c>�ֶε�ֵ</value>
        public string vc_Area
        {
            get { return _vc_Area; }
            set { _vc_Area = value; }
        }
        /// <summary>
        /// ���� <c>������Ȧ</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_BusinessZone</c>�ֶε�ֵ</value>
        public string vc_BusinessZone
        {
            get { return _vc_BusinessZone; }
            set { _vc_BusinessZone = value; }
        }
        /// <summary>
        /// ���� <c>¥�̵�ַ</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_Location</c>�ֶε�ֵ</value>
        public string vc_Location
        {
            get { return _vc_Location; }
            set { _vc_Location = value; }
        }
        /// <summary>
        /// ���� <c>��Ŀ��ɫ</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_ProjectFeatures</c>�ֶε�ֵ</value>
        public string vc_ProjectFeatures
        {
            get { return _vc_ProjectFeatures; }
            set { _vc_ProjectFeatures = value; }
        }
        /// <summary>
        /// ���� <c>������</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_Developer</c>�ֶε�ֵ</value>
        public string vc_Developer
        {
            get { return _vc_Developer; }
            set { _vc_Developer = value; }
        }
        /// <summary>
        /// ���� <c>¥�̼��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_Introduction</c>�ֶε�ֵ</value>
        public string vc_Introduction
        {
            get { return _vc_Introduction; }
            set { _vc_Introduction = value; }
        }
        /// <summary>
        /// ���� <c>����ʱ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>dt_OpeningTime</c>�ֶε�ֵ</value>
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
        /// ���� <c>����ʱ���Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>dt_OpeningTimeNull</c>�ֶε�ֵ</value>
        public bool dt_OpeningTimeNull
        {
            get { return _dt_OpeningTimeNull; }
            set { _dt_OpeningTimeNull = value; }
        }
        /// <summary>
        /// ���� <c>��סʱ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>dt_CheckinTime</c>�ֶε�ֵ</value>
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
        /// ���� <c>��סʱ���Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>dt_CheckinTimeNull</c>�ֶε�ֵ</value>
        public bool dt_CheckinTimeNull
        {
            get { return _dt_CheckinTimeNull; }
            set { _dt_CheckinTimeNull = value; }
        }
        /// <summary>
        /// ���� <c>�ο��۸�</c>.
        /// </summary>
        /// <value>��Ӧ����<c>dec_ReferencePrice</c>�ֶε�ֵ</value>
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
        /// ���� <c>�ο��۸��Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>dec_ReferencePriceNull</c>�ֶε�ֵ</value>
        public bool dec_ReferencePriceNull
        {
            get { return _dec_ReferencePriceNull; }
            set { _dec_ReferencePriceNull = value; }
        }
        /// <summary>
        /// ���� <c>�����Ż�</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_Discount</c>�ֶε�ֵ</value>
        public string vc_Discount
        {
            get { return _vc_Discount; }
            set { _vc_Discount = value; }
        }
        /// <summary>
        /// ���� <c>��ѯ����</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_Hotline</c>�ֶε�ֵ</value>
        public string vc_Hotline
        {
            get { return _vc_Hotline; }
            set { _vc_Hotline = value; }
        }
        /// <summary>
        /// ���� <c>��¥��ַ</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_SalesLocation</c>�ֶε�ֵ</value>
        public string vc_SalesLocation
        {
            get { return _vc_SalesLocation; }
            set { _vc_SalesLocation = value; }
        }
        /// <summary>
        /// ���� <c>��¥���֤</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_SalesPermit</c>�ֶε�ֵ</value>
        public string vc_SalesPermit
        {
            get { return _vc_SalesPermit; }
            set { _vc_SalesPermit = value; }
        }
        /// <summary>
        /// ���� <c>��Ȩ����</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_PropertyRight</c>�ֶε�ֵ</value>
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
        /// ���� <c>��Ȩ�����Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_PropertyRightNull</c>�ֶε�ֵ</value>
        public bool int_PropertyRightNull
        {
            get { return _int_PropertyRightNull; }
            set { _int_PropertyRightNull = value; }
        }
        /// <summary>
        /// ���� <c>����</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_HouseType</c>�ֶε�ֵ</value>
        public string vc_HouseType
        {
            get { return _vc_HouseType; }
            set { _vc_HouseType = value; }
        }
        /// <summary>
        /// ���� <c>�������</c>.
        /// </summary>
        /// <value>��Ӧ����<c>dec_BuildedArea</c>�ֶε�ֵ</value>
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
        /// ���� <c>��������Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>dec_BuildedAreaNull</c>�ֶε�ֵ</value>
        public bool dec_BuildedAreaNull
        {
            get { return _dec_BuildedAreaNull; }
            set { _dec_BuildedAreaNull = value; }
        }
        /// <summary>
        /// ���� <c>ռ�����</c>.
        /// </summary>
        /// <value>��Ӧ����<c>dec_CoveredArea</c>�ֶε�ֵ</value>
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
        /// ���� <c>ռ������Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>dec_CoveredAreaNull</c>�ֶε�ֵ</value>
        public bool dec_CoveredAreaNull
        {
            get { return _dec_CoveredAreaNull; }
            set { _dec_CoveredAreaNull = value; }
        }
        /// <summary>
        /// ���� <c>�������</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_BuildType</c>�ֶε�ֵ</value>
        public string vc_BuildType
        {
            get { return _vc_BuildType; }
            set { _vc_BuildType = value; }
        }
        /// <summary>
        /// ���� <c>װ�����</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_Decoration</c>�ֶε�ֵ</value>
        public string vc_Decoration
        {
            get { return _vc_Decoration; }
            set { _vc_Decoration = value; }
        }
        /// <summary>
        /// ���� <c>¥��״��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_FloorCondition</c>�ֶε�ֵ</value>
        public string vc_FloorCondition
        {
            get { return _vc_FloorCondition; }
            set { _vc_FloorCondition = value; }
        }
        /// <summary>
        /// ���� <c>�������</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_BuildDesign</c>�ֶε�ֵ</value>
        public string vc_BuildDesign
        {
            get { return _vc_BuildDesign; }
            set { _vc_BuildDesign = value; }
        }
        /// <summary>
        /// ���� <c>�н���</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_Contractor</c>�ֶε�ֵ</value>
        public string vc_Contractor
        {
            get { return _vc_Contractor; }
            set { _vc_Contractor = value; }
        }
        /// <summary>
        /// ���� <c>�������</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_LandscapeDesign</c>�ֶε�ֵ</value>
        public string vc_LandscapeDesign
        {
            get { return _vc_LandscapeDesign; }
            set { _vc_LandscapeDesign = value; }
        }
        /// <summary>
        /// ���� <c>��ҵ���</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_PropertyType</c>�ֶε�ֵ</value>
        public string vc_PropertyType
        {
            get { return _vc_PropertyType; }
            set { _vc_PropertyType = value; }
        }
        /// <summary>
        /// ���� <c>�ݻ���</c>.
        /// </summary>
        /// <value>��Ӧ����<c>dec_VolumeRate</c>�ֶε�ֵ</value>
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
        /// ���� <c>�ݻ����Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>dec_VolumeRateNull</c>�ֶε�ֵ</value>
        public bool dec_VolumeRateNull
        {
            get { return _dec_VolumeRateNull; }
            set { _dec_VolumeRateNull = value; }
        }
        /// <summary>
        /// ���� <c>�̻���</c>.
        /// </summary>
        /// <value>��Ӧ����<c>dec_GreenRate</c>�ֶε�ֵ</value>
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
        /// ���� <c>�̻����Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>dec_GreenRateNull</c>�ֶε�ֵ</value>
        public bool dec_GreenRateNull
        {
            get { return _dec_GreenRateNull; }
            set { _dec_GreenRateNull = value; }
        }
        /// <summary>
        /// ���� <c>��ˮ</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_WaterSupply</c>�ֶε�ֵ</value>
        public string vc_WaterSupply
        {
            get { return _vc_WaterSupply; }
            set { _vc_WaterSupply = value; }
        }
        /// <summary>
        /// ���� <c>��ů</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_Heating</c>�ֶε�ֵ</value>
        public string vc_Heating
        {
            get { return _vc_Heating; }
            set { _vc_Heating = value; }
        }
        /// <summary>
        /// ���� <c>����</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_GasSupply</c>�ֶε�ֵ</value>
        public string vc_GasSupply
        {
            get { return _vc_GasSupply; }
            set { _vc_GasSupply = value; }
        }
        /// <summary>
        /// ���� <c>��ҵ��˾</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_PropertyCompany</c>�ֶε�ֵ</value>
        public string vc_PropertyCompany
        {
            get { return _vc_PropertyCompany; }
            set { _vc_PropertyCompany = value; }
        }
        /// <summary>
        /// ���� <c>��ҵ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_PropertyFee</c>�ֶε�ֵ</value>
        public string vc_PropertyFee
        {
            get { return _vc_PropertyFee; }
            set { _vc_PropertyFee = value; }
        }
        /// <summary>
        /// ���� <c>ͣ��λ</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_ParkingSpace</c>�ֶε�ֵ</value>
        public string vc_ParkingSpace
        {
            get { return _vc_ParkingSpace; }
            set { _vc_ParkingSpace = value; }
        }
        /// <summary>
        /// ���� <c>��ͨ����</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_Traffic</c>�ֶε�ֵ</value>
        public string vc_Traffic
        {
            get { return _vc_Traffic; }
            set { _vc_Traffic = value; }
        }
        /// <summary>
        /// ���� <c>������Ϣ</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_ConfigureInfo</c>�ֶε�ֵ</value>
        public string vc_ConfigureInfo
        {
            get { return _vc_ConfigureInfo; }
            set { _vc_ConfigureInfo = value; }
        }
        /// <summary>
        /// ���� <c>ͼƬ1</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_PicFile1</c>�ֶε�ֵ</value>
        public string vc_PicFile1
        {
            get { return _vc_PicFile1; }
            set { _vc_PicFile1 = value; }
        }
        /// <summary>
        /// ���� <c>ͼƬ1����ͼ</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_Thumb1</c>�ֶε�ֵ</value>
        public string vc_Thumb1
        {
            get { return _vc_Thumb1; }
            set { _vc_Thumb1 = value; }
        }
        /// <summary>
        /// ���� <c>ͼƬ2</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_PicFile2</c>�ֶε�ֵ</value>
        public string vc_PicFile2
        {
            get { return _vc_PicFile2; }
            set { _vc_PicFile2 = value; }
        }
        /// <summary>
        /// ���� <c>ͼƬ3</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_PicFile3</c>�ֶε�ֵ</value>
        public string vc_PicFile3
        {
            get { return _vc_PicFile3; }
            set { _vc_PicFile3 = value; }
        }
        /// <summary>
        /// ���� <c>����״̬</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_SalesStatus</c>�ֶε�ֵ</value>
        public string vc_SalesStatus
        {
            get { return _vc_SalesStatus; }
            set { _vc_SalesStatus = value; }
        }
        /// <summary>
        /// ���� <c>����ʱ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>dt_UpdateTime</c>�ֶε�ֵ</value>
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
        /// ���� <c>����ʱ���Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>dt_UpdateTimeNull</c>�ֶε�ֵ</value>
        public bool dt_UpdateTimeNull
        {
            get { return _dt_UpdateTimeNull; }
            set { _dt_UpdateTimeNull = value; }
        }
        /// <summary>
        /// ���� <c>����ʱ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>dt_CreateDate</c>�ֶε�ֵ</value>
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
        /// ���� <c>����ʱ���Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>dt_CreateDateNull</c>�ֶε�ֵ</value>
        public bool dt_CreateDateNull
        {
            get { return _dt_CreateDateNull; }
            set { _dt_CreateDateNull = value; }
        }
        /// <summary>
        /// ���� <c>�Ƿ񸶷�</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_IsPay</c>�ֶε�ֵ</value>
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
        /// ���� <c>�Ƿ񸶷��Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_IsPayNull</c>�ֶε�ֵ</value>
        public bool int_IsPayNull
        {
            get { return _int_IsPayNull; }
            set { _int_IsPayNull = value; }
        }
        /// <summary>
        /// ���� <c>��ʾ˳��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_Order</c>�ֶε�ֵ</value>
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
        /// ���� <c>��ʾ˳���Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_OrderNull</c>�ֶε�ֵ</value>
        public bool int_OrderNull
        {
            get { return _int_OrderNull; }
            set { _int_OrderNull = value; }
        }
        /// <summary>
        /// ���� <c>״̬</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_Status</c>�ֶε�ֵ</value>
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
        /// ���� <c>״̬�Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_StatusNull</c>�ֶε�ֵ</value>
        public bool int_StatusNull
        {
            get { return _int_StatusNull; }
            set { _int_StatusNull = value; }
        }

    }//�ඨ�����
}//�����ռ����

