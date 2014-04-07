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
        /// <summary>
        /// ���� <c>��¼�˺�</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_LoginName</c>�ֶε�ֵ</value>
        public string vc_LoginName
        {
            get { return _vc_LoginName; }
            set { _vc_LoginName = value; }
        }
        /// <summary>
        /// ���� <c>��ʵ����</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_RealName</c>�ֶε�ֵ</value>
        public string vc_RealName
        {
            get { return _vc_RealName; }
            set { _vc_RealName = value; }
        }
        /// <summary>
        /// ���� <c>��¼����</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_LoginPwd</c>�ֶε�ֵ</value>
        public string vc_LoginPwd
        {
            get { return _vc_LoginPwd; }
            set { _vc_LoginPwd = value; }
        }
        /// <summary>
        /// ���� <c>����¼IP</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_LastLoginIp</c>�ֶε�ֵ</value>
        public string vc_LastLoginIp
        {
            get { return _vc_LastLoginIp; }
            set { _vc_LastLoginIp = value; }
        }
        /// <summary>
        /// ���� <c>����¼ʱ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>dt_LastLoginTime</c>�ֶε�ֵ</value>
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
        /// ���� <c>����¼ʱ���Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>dt_LastLoginTimeNull</c>�ֶε�ֵ</value>
        public bool dt_LastLoginTimeNull
        {
            get { return _dt_LastLoginTimeNull; }
            set { _dt_LastLoginTimeNull = value; }
        }
        /// <summary>
        /// ���� <c>�û�����</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_UserType</c>�ֶε�ֵ</value>
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
        /// ���� <c>�û������Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_UserTypeNull</c>�ֶε�ֵ</value>
        public bool int_UserTypeNull
        {
            get { return _int_UserTypeNull; }
            set { _int_UserTypeNull = value; }
        }
        /// <summary>
        /// ���� <c>����ͷ�����</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_CCount</c>�ֶε�ֵ</value>
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
        /// ���� <c>����ͷ������Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_CCountNull</c>�ֶε�ֵ</value>
        public bool int_CCountNull
        {
            get { return _int_CCountNull; }
            set { _int_CCountNull = value; }
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

