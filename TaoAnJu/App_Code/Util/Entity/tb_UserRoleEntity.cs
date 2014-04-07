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
        /// 属性 <c>编号</c>.
        /// </summary>
        /// <value>对应表中<c>int_Id</c>字段的值</value>
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
        /// 属性 <c>编号是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_IdNull</c>字段的值</value>
        public bool int_IdNull
        {
            get { return _int_IdNull; }
            set { _int_IdNull = value; }
        }
        /// <summary>
        /// 属性 <c>用户编号</c>.
        /// </summary>
        /// <value>对应表中<c>int_UserId</c>字段的值</value>
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
        /// 属性 <c>用户编号是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_UserIdNull</c>字段的值</value>
        public bool int_UserIdNull
        {
            get { return _int_UserIdNull; }
            set { _int_UserIdNull = value; }
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

