using System;

namespace TaoAnJu.Util
{
    public class tb_DataConfigInfoEntity
    {
        private Int32 _int_DId = 0;
        private bool _int_DIdNull = true;
        private string _vc_Name;
        private Int32 _int_ParentId = 0;
        private bool _int_ParentIdNull = true;
        private Int32 _int_Type = 0;
        private bool _int_TypeNull = true;
        private Int32 _int_Order = 0;
        private bool _int_OrderNull = true;
        private DateTime _dt_CreateDate;
        private bool _dt_CreateDateNull = true;

        public tb_DataConfigInfoEntity() { }
        /// <summary>
        /// ���� <c>���ݱ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_DId</c>�ֶε�ֵ</value>
        public Int32 int_DId
        {
            get { return _int_DId; }
            set
            {
                _int_DIdNull = false;
                _int_DId = value;
            }
        }
        /// <summary>
        /// ���� <c>���ݱ���Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_DIdNull</c>�ֶε�ֵ</value>
        public bool int_DIdNull
        {
            get { return _int_DIdNull; }
            set { _int_DIdNull = value; }
        }
        /// <summary>
        /// ���� <c>��������</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_Name</c>�ֶε�ֵ</value>
        public string vc_Name
        {
            get { return _vc_Name; }
            set { _vc_Name = value; }
        }
        /// <summary>
        /// ���� <c>�����</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_ParentId</c>�ֶε�ֵ</value>
        public Int32 int_ParentId
        {
            get { return _int_ParentId; }
            set
            {
                _int_ParentIdNull = false;
                _int_ParentId = value;
            }
        }
        /// <summary>
        /// ���� <c>������Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_ParentIdNull</c>�ֶε�ֵ</value>
        public bool int_ParentIdNull
        {
            get { return _int_ParentIdNull; }
            set { _int_ParentIdNull = value; }
        }
        /// <summary>
        /// ���� <c>����</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_Type</c>�ֶε�ֵ</value>
        public Int32 int_Type
        {
            get { return _int_Type; }
            set
            {
                _int_TypeNull = false;
                _int_Type = value;
            }
        }
        /// <summary>
        /// ���� <c>�����Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_TypeNull</c>�ֶε�ֵ</value>
        public bool int_TypeNull
        {
            get { return _int_TypeNull; }
            set { _int_TypeNull = value; }
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

