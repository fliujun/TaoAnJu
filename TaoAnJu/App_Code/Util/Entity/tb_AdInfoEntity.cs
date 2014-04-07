using System;

namespace TaoAnJu.Util
{
    public class tb_AdInfoEntity
    {
        private Int32 _int_AId = 0;
        private bool _int_AIdNull = true;
        private string _vc_Guid;
        private string _vc_AdTitle;
        private string _vc_AdDesc;
        private string _vc_AdPicFile;
        private string _vc_AdLink;
        private string _vc_AdType;
        private DateTime _dt_CreateDate;
        private bool _dt_CreateDateNull = true;
        private Int32 _int_Order = 0;
        private bool _int_OrderNull = true;
        private Int32 _int_Status = 0;
        private bool _int_StatusNull = true;

        public tb_AdInfoEntity() { }
        /// <summary>
        /// ���� <c>�����</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_AId</c>�ֶε�ֵ</value>
        public Int32 int_AId
        {
            get { return _int_AId; }
            set
            {
                _int_AIdNull = false;
                _int_AId = value;
            }
        }
        /// <summary>
        /// ���� <c>������Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_AIdNull</c>�ֶε�ֵ</value>
        public bool int_AIdNull
        {
            get { return _int_AIdNull; }
            set { _int_AIdNull = value; }
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
        /// ���� <c>������</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_AdTitle</c>�ֶε�ֵ</value>
        public string vc_AdTitle
        {
            get { return _vc_AdTitle; }
            set { _vc_AdTitle = value; }
        }
        /// <summary>
        /// ���� <c>�������</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_AdDesc</c>�ֶε�ֵ</value>
        public string vc_AdDesc
        {
            get { return _vc_AdDesc; }
            set { _vc_AdDesc = value; }
        }
        /// <summary>
        /// ���� <c>���ͼƬ</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_AdPicFile</c>�ֶε�ֵ</value>
        public string vc_AdPicFile
        {
            get { return _vc_AdPicFile; }
            set { _vc_AdPicFile = value; }
        }
        /// <summary>
        /// ���� <c>�������</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_AdLink</c>�ֶε�ֵ</value>
        public string vc_AdLink
        {
            get { return _vc_AdLink; }
            set { _vc_AdLink = value; }
        }
        /// <summary>
        /// ���� <c>�������</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_AdType</c>�ֶε�ֵ</value>
        public string vc_AdType
        {
            get { return _vc_AdType; }
            set { _vc_AdType = value; }
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

