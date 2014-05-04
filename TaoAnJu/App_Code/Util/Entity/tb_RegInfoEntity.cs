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
        /// ���� <c>�������</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_RId</c>�ֶε�ֵ</value>
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
        /// ���� <c>��������Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_RIdNull</c>�ֶε�ֵ</value>
        public bool int_RIdNull
        {
            get { return _int_RIdNull; }
            set { _int_RIdNull = value; }
        }
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
        /// ���� <c>����</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_Name</c>�ֶε�ֵ</value>
        public string vc_Name
        {
            get { return _vc_Name; }
            set { _vc_Name = value; }
        }
        /// <summary>
        /// ���� <c>�ֻ���</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_Mobile</c>�ֶε�ֵ</value>
        public string vc_Mobile
        {
            get { return _vc_Mobile; }
            set { _vc_Mobile = value; }
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
        /// ���� <c>���۴���</c>.
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
        /// ���� <c>���۴����Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_UserIdNull</c>�ֶε�ֵ</value>
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
    }//�ඨ�����
}//�����ռ����

