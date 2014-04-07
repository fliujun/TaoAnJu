using System;

namespace TaoAnJu.Util
{
    public class tb_UserInfoEntity
    {
        private Int32 _int_UserId = 0;
        private bool _int_UserIdNull = true;
        private string _vc_LoginName;
        private string _vc_RealName;
        private string _vc_LoginPwd;
        private string _vc_LastLoginIp;
        private DateTime _dt_LastLoginTime;
        private bool _dt_LastLoginTimeNull = true;
        private Int32 _int_UserType = 0;
        private bool _int_UserTypeNull = true;
        private Int32 _int_CCount = 0;
        private bool _int_CCountNull = true;
        private DateTime _dt_CreateDate;
        private bool _dt_CreateDateNull = true;
        private Int32 _int_Status = 0;
        private bool _int_StatusNull = true;

        public tb_UserInfoEntity() { }
        /// <summary>
        /// 属性 <c>用户编号</c>.
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
        /// 属性 <c>用户编号是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_UserIdNull</c>字段的值</value>
        public bool int_UserIdNull
        {
            get { return _int_UserIdNull; }
            set { _int_UserIdNull = value; }
        }
        /// <summary>
        /// 属性 <c>登录账号</c>.
        /// </summary>
        /// <value>对应表中<c>vc_LoginName</c>字段的值</value>
        public string vc_LoginName
        {
            get { return _vc_LoginName; }
            set { _vc_LoginName = value; }
        }
        /// <summary>
        /// 属性 <c>真实姓名</c>.
        /// </summary>
        /// <value>对应表中<c>vc_RealName</c>字段的值</value>
        public string vc_RealName
        {
            get { return _vc_RealName; }
            set { _vc_RealName = value; }
        }
        /// <summary>
        /// 属性 <c>登录密码</c>.
        /// </summary>
        /// <value>对应表中<c>vc_LoginPwd</c>字段的值</value>
        public string vc_LoginPwd
        {
            get { return _vc_LoginPwd; }
            set { _vc_LoginPwd = value; }
        }
        /// <summary>
        /// 属性 <c>最后登录IP</c>.
        /// </summary>
        /// <value>对应表中<c>vc_LastLoginIp</c>字段的值</value>
        public string vc_LastLoginIp
        {
            get { return _vc_LastLoginIp; }
            set { _vc_LastLoginIp = value; }
        }
        /// <summary>
        /// 属性 <c>最后登录时间</c>.
        /// </summary>
        /// <value>对应表中<c>dt_LastLoginTime</c>字段的值</value>
        public DateTime dt_LastLoginTime
        {
            get { return _dt_LastLoginTime; }
            set
            {
                _dt_LastLoginTimeNull = false;
                _dt_LastLoginTime = value;
            }
        }
        /// <summary>
        /// 属性 <c>最后登录时间是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>dt_LastLoginTimeNull</c>字段的值</value>
        public bool dt_LastLoginTimeNull
        {
            get { return _dt_LastLoginTimeNull; }
            set { _dt_LastLoginTimeNull = value; }
        }
        /// <summary>
        /// 属性 <c>用户类型</c>.
        /// </summary>
        /// <value>对应表中<c>int_UserType</c>字段的值</value>
        public Int32 int_UserType
        {
            get { return _int_UserType; }
            set
            {
                _int_UserTypeNull = false;
                _int_UserType = value;
            }
        }
        /// <summary>
        /// 属性 <c>用户类型是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_UserTypeNull</c>字段的值</value>
        public bool int_UserTypeNull
        {
            get { return _int_UserTypeNull; }
            set { _int_UserTypeNull = value; }
        }
        /// <summary>
        /// 属性 <c>服务客服数量</c>.
        /// </summary>
        /// <value>对应表中<c>int_CCount</c>字段的值</value>
        public Int32 int_CCount
        {
            get { return _int_CCount; }
            set
            {
                _int_CCountNull = false;
                _int_CCount = value;
            }
        }
        /// <summary>
        /// 属性 <c>服务客服数量是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_CCountNull</c>字段的值</value>
        public bool int_CCountNull
        {
            get { return _int_CCountNull; }
            set { _int_CCountNull = value; }
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

