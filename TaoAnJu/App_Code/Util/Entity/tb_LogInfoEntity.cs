using System;

namespace TaoAnJu.Util
{
    public class tb_LogInfoEntity
    {
        private Int32 _int_LogId = 0;
        private bool _int_LogIdNull = true;
        private string _vc_LogType;
        private string _vc_Content;
        private string _vc_Ip;
        private DateTime _dt_CreateDate;
        private bool _dt_CreateDateNull = true;
        private Int32 _int_UserId = 0;
        private bool _int_UserIdNull = true;

        public tb_LogInfoEntity() { }
        /// <summary>
        /// 属性 <c>日志编号</c>.
        /// </summary>
        /// <value>对应表中<c>int_LogId</c>字段的值</value>
        public Int32 int_LogId
        {
            get { return _int_LogId; }
            set
            {
                _int_LogIdNull = false;
                _int_LogId = value;
            }
        }
        /// <summary>
        /// 属性 <c>日志编号是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_LogIdNull</c>字段的值</value>
        public bool int_LogIdNull
        {
            get { return _int_LogIdNull; }
            set { _int_LogIdNull = value; }
        }
        /// <summary>
        /// 属性 <c>类别</c>.
        /// </summary>
        /// <value>对应表中<c>vc_LogType</c>字段的值</value>
        public string vc_LogType
        {
            get { return _vc_LogType; }
            set { _vc_LogType = value; }
        }
        /// <summary>
        /// 属性 <c>内容</c>.
        /// </summary>
        /// <value>对应表中<c>vc_Content</c>字段的值</value>
        public string vc_Content
        {
            get { return _vc_Content; }
            set { _vc_Content = value; }
        }
        /// <summary>
        /// 属性 <c>访问IP</c>.
        /// </summary>
        /// <value>对应表中<c>vc_Ip</c>字段的值</value>
        public string vc_Ip
        {
            get { return _vc_Ip; }
            set { _vc_Ip = value; }
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

    }//类定义结束
}//命名空间结束

