using System;

namespace TaoAnJu.Util
{
    public class tb_RoleInfoEntity
    {
        private Int32 _int_RoleId = 0;
        private bool _int_RoleIdNull = true;
        private string _vc_RoleName;
        private string _vc_Desc;
        private Int32 _int_Type = 0;
        private bool _int_TypeNull = true;
        private DateTime _dt_CreateDate;
        private bool _dt_CreateDateNull = true;

        public tb_RoleInfoEntity() { }
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
        /// ���� <c>��ɫ����</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_RoleName</c>�ֶε�ֵ</value>
        public string vc_RoleName
        {
            get { return _vc_RoleName; }
            set { _vc_RoleName = value; }
        }
        /// <summary>
        /// ���� <c>��ɫ����</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_Desc</c>�ֶε�ֵ</value>
        public string vc_Desc
        {
            get { return _vc_Desc; }
            set { _vc_Desc = value; }
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

