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
        /// 属性 <c>角色名称</c>.
        /// </summary>
        /// <value>对应表中<c>vc_RoleName</c>字段的值</value>
        public string vc_RoleName
        {
            get { return _vc_RoleName; }
            set { _vc_RoleName = value; }
        }
        /// <summary>
        /// 属性 <c>角色描述</c>.
        /// </summary>
        /// <value>对应表中<c>vc_Desc</c>字段的值</value>
        public string vc_Desc
        {
            get { return _vc_Desc; }
            set { _vc_Desc = value; }
        }
        /// <summary>
        /// 属性 <c>类型</c>.
        /// </summary>
        /// <value>对应表中<c>int_Type</c>字段的值</value>
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
        /// 属性 <c>类型是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_TypeNull</c>字段的值</value>
        public bool int_TypeNull
        {
            get { return _int_TypeNull; }
            set { _int_TypeNull = value; }
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

