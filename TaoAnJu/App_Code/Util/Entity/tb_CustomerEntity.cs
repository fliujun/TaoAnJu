using System;

namespace TaoAnJu.Util
{
    public class tb_CustomerEntity
    {
        private Int32 _int_CId = 0;
        private bool _int_CIdNull = true;
        private string _vc_Name;
        private string _vc_Mobile;
        private Int32 _int_Age = 0;
        private bool _int_AgeNull = true;
        private string _vc_Occupation;
        private string _vc_WorkingPlace;
        private string _vc_LivePlace;
        private string _vc_Use;
        private decimal _dec_Price = 0;
        private bool _dec_PriceNull = true;
        private decimal _dec_TotalPrice = 0;
        private bool _dec_TotalPriceNull = true;
        private string _vc_Referee;
        private Int32 _int_UserId = 0;
        private bool _int_UserIdNull = true;
        private DateTime _dt_CreateDate;
        private bool _dt_CreateDateNull = true;
        private string _vc_Static;

        public tb_CustomerEntity() { }
        /// <summary>
        /// 属性 <c>客户编号</c>.
        /// </summary>
        /// <value>对应表中<c>int_CId</c>字段的值</value>
        public Int32 int_CId
        {
            get { return _int_CId; }
            set
            {
                _int_CIdNull = false;
                _int_CId = value;
            }
        }
        /// <summary>
        /// 属性 <c>客户编号是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_CIdNull</c>字段的值</value>
        public bool int_CIdNull
        {
            get { return _int_CIdNull; }
            set { _int_CIdNull = value; }
        }
        /// <summary>
        /// 属性 <c>姓名</c>.
        /// </summary>
        /// <value>对应表中<c>vc_Name</c>字段的值</value>
        public string vc_Name
        {
            get { return _vc_Name; }
            set { _vc_Name = value; }
        }
        /// <summary>
        /// 属性 <c>手机号</c>.
        /// </summary>
        /// <value>对应表中<c>vc_Mobile</c>字段的值</value>
        public string vc_Mobile
        {
            get { return _vc_Mobile; }
            set { _vc_Mobile = value; }
        }
        /// <summary>
        /// 属性 <c>年龄</c>.
        /// </summary>
        /// <value>对应表中<c>int_Age</c>字段的值</value>
        public Int32 int_Age
        {
            get { return _int_Age; }
            set
            {
                _int_AgeNull = false;
                _int_Age = value;
            }
        }
        /// <summary>
        /// 属性 <c>年龄是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_AgeNull</c>字段的值</value>
        public bool int_AgeNull
        {
            get { return _int_AgeNull; }
            set { _int_AgeNull = value; }
        }
        /// <summary>
        /// 属性 <c>职业</c>.
        /// </summary>
        /// <value>对应表中<c>vc_Occupation</c>字段的值</value>
        public string vc_Occupation
        {
            get { return _vc_Occupation; }
            set { _vc_Occupation = value; }
        }
        /// <summary>
        /// 属性 <c>工作地点</c>.
        /// </summary>
        /// <value>对应表中<c>vc_WorkingPlace</c>字段的值</value>
        public string vc_WorkingPlace
        {
            get { return _vc_WorkingPlace; }
            set { _vc_WorkingPlace = value; }
        }
        /// <summary>
        /// 属性 <c>居住地点</c>.
        /// </summary>
        /// <value>对应表中<c>vc_LivePlace</c>字段的值</value>
        public string vc_LivePlace
        {
            get { return _vc_LivePlace; }
            set { _vc_LivePlace = value; }
        }
        /// <summary>
        /// 属性 <c>购房使用</c>.
        /// </summary>
        /// <value>对应表中<c>vc_Use</c>字段的值</value>
        public string vc_Use
        {
            get { return _vc_Use; }
            set { _vc_Use = value; }
        }
        /// <summary>
        /// 属性 <c>期望单价</c>.
        /// </summary>
        /// <value>对应表中<c>dec_Price</c>字段的值</value>
        public decimal dec_Price
        {
            get { return _dec_Price; }
            set
            {
                _dec_PriceNull = false;
                _dec_Price = value;
            }
        }
        /// <summary>
        /// 属性 <c>期望单价是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>dec_PriceNull</c>字段的值</value>
        public bool dec_PriceNull
        {
            get { return _dec_PriceNull; }
            set { _dec_PriceNull = value; }
        }
        /// <summary>
        /// 属性 <c>期望总价</c>.
        /// </summary>
        /// <value>对应表中<c>dec_TotalPrice</c>字段的值</value>
        public decimal dec_TotalPrice
        {
            get { return _dec_TotalPrice; }
            set
            {
                _dec_TotalPriceNull = false;
                _dec_TotalPrice = value;
            }
        }
        /// <summary>
        /// 属性 <c>期望总价是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>dec_TotalPriceNull</c>字段的值</value>
        public bool dec_TotalPriceNull
        {
            get { return _dec_TotalPriceNull; }
            set { _dec_TotalPriceNull = value; }
        }
        /// <summary>
        /// 属性 <c>推荐人</c>.
        /// </summary>
        /// <value>对应表中<c>vc_Referee</c>字段的值</value>
        public string vc_Referee
        {
            get { return _vc_Referee; }
            set { _vc_Referee = value; }
        }
        /// <summary>
        /// 属性 <c>贴心管家</c>.
        /// </summary>
        /// <value>对应表中<c>int_UserId</c>字段的值</value>
        public Int32 int_UserId
        {
            get { return _int_UserId; }
            set
            {
                _int_UserIdNull = false;
                _int_UserId = value;
            }
        }
        /// <summary>
        /// 属性 <c>贴心管家是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_UserIdNull</c>字段的值</value>
        public bool int_UserIdNull
        {
            get { return _int_UserIdNull; }
            set { _int_UserIdNull = value; }
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
        /// 属性 <c>状态</c>.
        /// </summary>
        /// <value>对应表中<c>vc_Static</c>字段的值</value>
        public string vc_Static
        {
            get { return _vc_Static; }
            set { _vc_Static = value; }
        }

    }//类定义结束
}//命名空间结束

