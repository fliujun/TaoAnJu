using System;

namespace TaoAnJu.Util
{
    public class tb_FileInfoEntity
    {
        private Int32 _int_FileId = 0;
        private bool _int_FileIdNull = true;
        private string _vc_ShowName;
        private string _vc_FileName;
        private Int32 _int_TbId = 0;
        private bool _int_TbIdNull = true;
        private Int32 _int_RecordId = 0;
        private bool _int_RecordIdNull = true;
        private DateTime _dt_CreateDate;
        private bool _dt_CreateDateNull = true;
        private Int32 _int_UserId = 0;
        private bool _int_UserIdNull = true;

        public tb_FileInfoEntity() { }
        /// <summary>
        /// ���� <c>�ļ����</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_FileId</c>�ֶε�ֵ</value>
        public Int32 int_FileId
        {
            get { return _int_FileId; }
            set
            {
                _int_FileIdNull = false;
                _int_FileId = value;
            }
        }
        /// <summary>
        /// ���� <c>�ļ�����Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_FileIdNull</c>�ֶε�ֵ</value>
        public bool int_FileIdNull
        {
            get { return _int_FileIdNull; }
            set { _int_FileIdNull = value; }
        }
        /// <summary>
        /// ���� <c>��ʾ����</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_ShowName</c>�ֶε�ֵ</value>
        public string vc_ShowName
        {
            get { return _vc_ShowName; }
            set { _vc_ShowName = value; }
        }
        /// <summary>
        /// ���� <c>�ļ�·��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_FileName</c>�ֶε�ֵ</value>
        public string vc_FileName
        {
            get { return _vc_FileName; }
            set { _vc_FileName = value; }
        }
        /// <summary>
        /// ���� <c>��Դ����</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_TbId</c>�ֶε�ֵ</value>
        public Int32 int_TbId
        {
            get { return _int_TbId; }
            set
            {
                _int_TbIdNull = false;
                _int_TbId = value;
            }
        }
        /// <summary>
        /// ���� <c>��Դ�����Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_TbIdNull</c>�ֶε�ֵ</value>
        public bool int_TbIdNull
        {
            get { return _int_TbIdNull; }
            set { _int_TbIdNull = value; }
        }
        /// <summary>
        /// ���� <c>��Դ��¼���</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_RecordId</c>�ֶε�ֵ</value>
        public Int32 int_RecordId
        {
            get { return _int_RecordId; }
            set
            {
                _int_RecordIdNull = false;
                _int_RecordId = value;
            }
        }
        /// <summary>
        /// ���� <c>��Դ��¼����Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_RecordIdNull</c>�ֶε�ֵ</value>
        public bool int_RecordIdNull
        {
            get { return _int_RecordIdNull; }
            set { _int_RecordIdNull = value; }
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

