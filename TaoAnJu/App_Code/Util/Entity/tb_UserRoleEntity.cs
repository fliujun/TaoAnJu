using System;

namespace TaoAnJu.Util
{
    public class tb_UserRoleEntity
    {
        private Int32 _int_Id = 0;
        private bool _int_IdNull = true;
        private Int32 _int_UserId = 0;
        private bool _int_UserIdNull = true;
        private Int32 _int_RoleId = 0;
        private bool _int_RoleIdNull = true;
        private DateTime _dt_CreateDate;
        private bool _dt_CreateDateNull = true;

        public tb_UserRoleEntity() { }
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

