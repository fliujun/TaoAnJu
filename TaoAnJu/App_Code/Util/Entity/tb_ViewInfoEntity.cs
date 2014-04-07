using System;

namespace TaoAnJu.Util
{
    public class tb_ViewInfoEntity
    {
        private Int32 _int_VId = 0;
        private bool _int_VIdNull = true;
        private Int32 _int_ItemId = 0;
        private bool _int_ItemIdNull = true;
        private string _vc_ViewFile;
        private string _vc_ViewDesc;
        private DateTime _dt_CreateDate;
        private bool _dt_CreateDateNull = true;
        private Int32 _int_IsView = 0;
        private bool _int_IsViewNull = true;

        public tb_ViewInfoEntity() { }
        /// <summary>
        /// ���� <c>��Ƶ���</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_VId</c>�ֶε�ֵ</value>
        public Int32 int_VId
        {
            get { return _int_VId; }
            set
            {
                _int_VIdNull = false;
                _int_VId = value;
            }
        }
        /// <summary>
        /// ���� <c>��Ƶ����Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_VIdNull</c>�ֶε�ֵ</value>
        public bool int_VIdNull
        {
            get { return _int_VIdNull; }
            set { _int_VIdNull = value; }
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
        /// ���� <c>��Ƶ�ļ�</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_ViewFile</c>�ֶε�ֵ</value>
        public string vc_ViewFile
        {
            get { return _vc_ViewFile; }
            set { _vc_ViewFile = value; }
        }
        /// <summary>
        /// ���� <c>��Ƶ����</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_ViewDesc</c>�ֶε�ֵ</value>
        public string vc_ViewDesc
        {
            get { return _vc_ViewDesc; }
            set { _vc_ViewDesc = value; }
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
        /// ���� <c>�Ƿ���ʾ</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_IsView</c>�ֶε�ֵ</value>
        public Int32 int_IsView
        {
            get { return _int_IsView; }
            set
            {
                _int_IsViewNull = false;
                _int_IsView = value;
            }
        }
        /// <summary>
        /// ���� <c>�Ƿ���ʾ�Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_IsViewNull</c>�ֶε�ֵ</value>
        public bool int_IsViewNull
        {
            get { return _int_IsViewNull; }
            set { _int_IsViewNull = value; }
        }

    }//�ඨ�����
}//�����ռ����

