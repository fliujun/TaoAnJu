using System;

namespace TaoAnJu.Util
{
    public class tb_FunInfoEntity
    {
        private Int32 _int_FunId = 0;
        private bool _int_FunIdNull = true;
        private string _vc_Name;
        private Int32 _int_ParentId = 0;
        private bool _int_ParentIdNull = true;
        private string _vc_Value;
        private string _vc_Parameter;
        private Int32 _int_Type = 0;
        private bool _int_TypeNull = true;
        private Int32 _int_Order = 0;
        private bool _int_OrderNull = true;

        public tb_FunInfoEntity() { }
        /// <summary>
        /// ���� <c>Ȩ�ޱ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_FunId</c>�ֶε�ֵ</value>
        public Int32 int_FunId
        {
            get { return _int_FunId; }
            set
            {
                _int_FunIdNull = false;
                _int_FunId = value;
            }
        }
        /// <summary>
        /// ���� <c>Ȩ�ޱ���Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_FunIdNull</c>�ֶε�ֵ</value>
        public bool int_FunIdNull
        {
            get { return _int_FunIdNull; }
            set { _int_FunIdNull = value; }
        }
        /// <summary>
        /// ���� <c>Ȩ������</c>.
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
        /// ���� <c>Ȩ��ֵ</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_Value</c>�ֶε�ֵ</value>
        public string vc_Value
        {
            get { return _vc_Value; }
            set { _vc_Value = value; }
        }
        /// <summary>
        /// ���� <c>����</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_Parameter</c>�ֶε�ֵ</value>
        public string vc_Parameter
        {
            get { return _vc_Parameter; }
            set { _vc_Parameter = value; }
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

    }//�ඨ�����
}//�����ռ����

