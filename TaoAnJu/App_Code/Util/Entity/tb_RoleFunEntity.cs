using System;

namespace TaoAnJu.Util
{
    public class tb_RoleFunEntity
    {
        private Int32 _int_RFId = 0;
        private bool _int_RFIdNull = true;
        private Int32 _int_RoleId = 0;
        private bool _int_RoleIdNull = true;
        private Int32 _int_FunId = 0;
        private bool _int_FunIdNull = true;
        private DateTime _dt_CreateDate;
        private bool _dt_CreateDateNull = true;

        public tb_RoleFunEntity() { }
        /// <summary>
        /// ���� <c>���</c>.
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
        /// ���� <c>����Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_RFIdNull</c>�ֶε�ֵ</value>
        public bool int_RFIdNull
        {
            get { return _int_RFIdNull; }
            set { _int_RFIdNull = value; }
        }
        /// <summary>
        /// ���� <c>��ɫ���</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_RoleId</c>�ֶε�ֵ</value>
        public Int32 int_RoleId
        {
            get { return _int_RoleId; }
            set
            {
                _int_RoleIdNull = false;
                _int_RoleId = value;
            }
        }
        /// <summary>
        /// ���� <c>��ɫ����Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_RoleIdNull</c>�ֶε�ֵ</value>
        public bool int_RoleIdNull
        {
            get { return _int_RoleIdNull; }
            set { _int_RoleIdNull = value; }
        }
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

