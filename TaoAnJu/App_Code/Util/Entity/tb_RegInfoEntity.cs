using System;

namespace TaoAnJu.Util
{
    public class tb_RegInfoEntity
    {
        private Int32 _int_RId = 0;
        private bool _int_RIdNull = true;
        private Int32 _int_ItemId = 0;
        private bool _int_ItemIdNull = true;
        private string _vc_Name;
        private string _vc_Mobile;
        private DateTime _dt_CreateDate;
        private bool _dt_CreateDateNull = true;
        private Int32 _int_UserId = 0;
        private bool _int_UserIdNull = true;
        private string _vc_From;

        public tb_RegInfoEntity() { }
        /// <summary>
        /// 属性 <c>报名编号</c>.
        /// </summary>
        /// <value>对应表中<c>int_RId</c>字段的值</value>
        public Int32 int_RId
        {
            get { return _int_RId; }
            set
            {
                _int_RIdNull = false;
                _int_RId = value;
            }
        }
        /// <summary>
        /// 属性 <c>报名编号是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_RIdNull</c>字段的值</value>
        public bool int_RIdNull
        {
            get { return _int_RIdNull; }
            set { _int_RIdNull = value; }
        }
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
        /// 属性 <c>报名时间</c>.
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
        /// 属性 <c>报名时间是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>dt_CreateDateNull</c>字段的值</value>
        public bool dt_CreateDateNull
        {
            get { return _dt_CreateDateNull; }
            set { _dt_CreateDateNull = value; }
        }
        /// <summary>
        /// 属性 <c>销售代表</c>.
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
        /// 属性 <c>销售代表是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_UserIdNull</c>字段的值</value>
        public bool int_UserIdNull
        {
            get { return _int_UserIdNull; }
            set { _int_UserIdNull = value; }
        }

        public string vc_From
        {
            get { return _vc_From; }
            set { _vc_From = value; }
        }
    }//类定义结束
}//命名空间结束

