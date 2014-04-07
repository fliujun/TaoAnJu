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
        /// 属性 <c>权限名称</c>.
        /// </summary>
        /// <value>对应表中<c>vc_Name</c>字段的值</value>
        public string vc_Name
        {
            get { return _vc_Name; }
            set { _vc_Name = value; }
        }
        /// <summary>
        /// 属性 <c>父编号</c>.
        /// </summary>
        /// <value>对应表中<c>int_ParentId</c>字段的值</value>
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
        /// 属性 <c>父编号是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_ParentIdNull</c>字段的值</value>
        public bool int_ParentIdNull
        {
            get { return _int_ParentIdNull; }
            set { _int_ParentIdNull = value; }
        }
        /// <summary>
        /// 属性 <c>权限值</c>.
        /// </summary>
        /// <value>对应表中<c>vc_Value</c>字段的值</value>
        public string vc_Value
        {
            get { return _vc_Value; }
            set { _vc_Value = value; }
        }
        /// <summary>
        /// 属性 <c>参数</c>.
        /// </summary>
        /// <value>对应表中<c>vc_Parameter</c>字段的值</value>
        public string vc_Parameter
        {
            get { return _vc_Parameter; }
            set { _vc_Parameter = value; }
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
        /// 属性 <c>显示顺序</c>.
        /// </summary>
        /// <value>对应表中<c>int_Order</c>字段的值</value>
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
        /// 属性 <c>显示顺序是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_OrderNull</c>字段的值</value>
        public bool int_OrderNull
        {
            get { return _int_OrderNull; }
            set { _int_OrderNull = value; }
        }

    }//类定义结束
}//命名空间结束

