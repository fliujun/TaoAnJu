using System;

namespace TaoAnJu.Util
{
    public class tb_RoleFunRangeEntity
    {
        private Int32 _int_Id = 0;
        private bool _int_IdNull = true;
        private Int32 _int_RFId = 0;
        private bool _int_RFIdNull = true;
        private Int32 _int_Range = 0;
        private bool _int_RangeNull = true;
        private Int32 _int_DepId = 0;
        private bool _int_DepIdNull = true;
        private DateTime _dt_CreateDate;
        private bool _dt_CreateDateNull = true;

        public tb_RoleFunRangeEntity() { }
        /// <summary>
        /// ���� <c>���</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_Id</c>�ֶε�ֵ</value>
        public Int32 int_Id
        {
            get { return _int_Id; }
            set
            {
                _int_IdNull = false;
                _int_Id = value;
            }
        }
        /// <summary>
        /// ���� <c>����Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_IdNull</c>�ֶε�ֵ</value>
        public bool int_IdNull
        {
            get { return _int_IdNull; }
            set { _int_IdNull = value; }
        }
        /// <summary>
        /// ���� <c>��ɫȨ�ޱ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_RFId</c>�ֶε�ֵ</value>
        public Int32 int_RFId
        {
            get { return _int_RFId; }
            set
            {
                _int_RFIdNull = false;
                _int_RFId = value;
            }
        }
        /// <summary>
        /// ���� <c>��ɫȨ�ޱ���Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_RFIdNull</c>�ֶε�ֵ</value>
        public bool int_RFIdNull
        {
            get { return _int_RFIdNull; }
            set { _int_RFIdNull = value; }
        }
        /// <summary>
        /// ���� <c>���ݷ�Χ</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_Range</c>�ֶε�ֵ</value>
        public Int32 int_Range
        {
            get { return _int_Range; }
            set
            {
                _int_RangeNull = false;
                _int_Range = value;
            }
        }
        /// <summary>
        /// ���� <c>���ݷ�Χ�Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_RangeNull</c>�ֶε�ֵ</value>
        public bool int_RangeNull
        {
            get { return _int_RangeNull; }
            set { _int_RangeNull = value; }
        }
        /// <summary>
        /// ���� <c>���ű��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_DepId</c>�ֶε�ֵ</value>
        public Int32 int_DepId
        {
            get { return _int_DepId; }
            set
            {
                _int_DepIdNull = false;
                _int_DepId = value;
            }
        }
        /// <summary>
        /// ���� <c>���ű���Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_DepIdNull</c>�ֶε�ֵ</value>
        public bool int_DepIdNull
        {
            get { return _int_DepIdNull; }
            set { _int_DepIdNull = value; }
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

    }//�ඨ�����
}//�����ռ����

