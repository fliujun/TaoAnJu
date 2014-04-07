using System;

namespace TaoAnJu.Util
{
    public class tb_PicInfoEntity
    {
        private Int32 _int_PId = 0;
        private bool _int_PIdNull = true;
        private Int32 _int_ItemId = 0;
        private bool _int_ItemIdNull = true;
        private string _vc_PicFile;
        private string _vc_PicDesc;
        private string _vc_PicType;
        private string _vc_Pic1;
        private string _vc_Pic2;
        private string _vc_Pic3;
        private DateTime _dt_CreateDate;
        private bool _dt_CreateDateNull = true;
        private Int32 _int_IsView = 0;
        private bool _int_IsViewNull = true;

        public tb_PicInfoEntity() { }
        /// <summary>
        /// ���� <c>ͼƬ���</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_PId</c>�ֶε�ֵ</value>
        public Int32 int_PId
        {
            get { return _int_PId; }
            set
            {
                _int_PIdNull = false;
                _int_PId = value;
            }
        }
        /// <summary>
        /// ���� <c>ͼƬ����Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_PIdNull</c>�ֶε�ֵ</value>
        public bool int_PIdNull
        {
            get { return _int_PIdNull; }
            set { _int_PIdNull = value; }
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
        /// ���� <c>ͼƬ�ļ�</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_PicFile</c>�ֶε�ֵ</value>
        public string vc_PicFile
        {
            get { return _vc_PicFile; }
            set { _vc_PicFile = value; }
        }
        /// <summary>
        /// ���� <c>ͼƬ����</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_PicDesc</c>�ֶε�ֵ</value>
        public string vc_PicDesc
        {
            get { return _vc_PicDesc; }
            set { _vc_PicDesc = value; }
        }
        /// <summary>
        /// ���� <c>ͼƬ����</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_PicType</c>�ֶε�ֵ</value>
        public string vc_PicType
        {
            get { return _vc_PicType; }
            set { _vc_PicType = value; }
        }
        /// <summary>
        /// ���� <c>����ͼ1</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_Pic1</c>�ֶε�ֵ</value>
        public string vc_Pic1
        {
            get { return _vc_Pic1; }
            set { _vc_Pic1 = value; }
        }
        /// <summary>
        /// ���� <c>����ͼ2</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_Pic2</c>�ֶε�ֵ</value>
        public string vc_Pic2
        {
            get { return _vc_Pic2; }
            set { _vc_Pic2 = value; }
        }
        /// <summary>
        /// ���� <c>����ͼ3</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_Pic3</c>�ֶε�ֵ</value>
        public string vc_Pic3
        {
            get { return _vc_Pic3; }
            set { _vc_Pic3 = value; }
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

