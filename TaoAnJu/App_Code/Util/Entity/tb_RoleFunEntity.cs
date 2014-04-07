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
        /// 属性 <c>编号</c>.
        /// </summary>
        /// <value>对应表中<c>int_RFId</c>字段的值</value>
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
        /// 属性 <c>编号是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_RFIdNull</c>字段的值</value>
        public bool int_RFIdNull
        {
            get { return _int_RFIdNull; }
            set { _int_RFIdNull = value; }
        }
        /// <summary>
        /// 属性 <c>角色编号</c>.
        /// </summary>
        /// <value>对应表中<c>int_RoleId</c>字段的值</value>
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
        /// 属性 <c>角色编号是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_RoleIdNull</c>字段的值</value>
        public bool int_RoleIdNull
        {
            get { return _int_RoleIdNull; }
            set { _int_RoleIdNull = value; }
        }
        /// <summary>
        /// 属性 <c>权限编号</c>.
        /// </summary>
        /// <value>对应表中<c>int_FunId</c>字段的值</value>
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
        /// 属性 <c>权限编号是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_FunIdNull</c>字段的值</value>
        public bool int_FunIdNull
        {
            get { return _int_FunIdNull; }
            set { _int_FunIdNull = value; }
        }
        /// <summary>
        /// 属性 <c>创建时间</c>.
        /// </summary>
        /// <value>对应表中<c>dt_CreateDate</c>字段的值</value>
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
        /// 属性 <c>创建时间是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>dt_CreateDateNull</c>字段的值</value>
        public bool dt_CreateDateNull
        {
            get { return _dt_CreateDateNull; }
            set { _dt_CreateDateNull = value; }
        }

    }//类定义结束
}//命名空间结束

