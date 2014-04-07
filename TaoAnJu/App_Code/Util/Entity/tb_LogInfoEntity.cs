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
        /// ���� <c>��־���</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_LogId</c>�ֶε�ֵ</value>
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
        /// ���� <c>��־����Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_LogIdNull</c>�ֶε�ֵ</value>
        public bool int_LogIdNull
        {
            get { return _int_LogIdNull; }
            set { _int_LogIdNull = value; }
        }
        /// <summary>
        /// ���� <c>���</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_LogType</c>�ֶε�ֵ</value>
        public string vc_LogType
        {
            get { return _vc_LogType; }
            set { _vc_LogType = value; }
        }
        /// <summary>
        /// ���� <c>����</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_Content</c>�ֶε�ֵ</value>
        public string vc_Content
        {
            get { return _vc_Content; }
            set { _vc_Content = value; }
        }
        /// <summary>
        /// ���� <c>����IP</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_Ip</c>�ֶε�ֵ</value>
        public string vc_Ip
        {
            get { return _vc_Ip; }
            set { _vc_Ip = value; }
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
        /// ���� <c>�û����</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_UserId</c>�ֶε�ֵ</value>
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
        /// ���� <c>�û�����Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_UserIdNull</c>�ֶε�ֵ</value>
        public bool int_UserIdNull
        {
            get { return _int_UserIdNull; }
            set { _int_UserIdNull = value; }
        }

    }//�ඨ�����
}//�����ռ����

