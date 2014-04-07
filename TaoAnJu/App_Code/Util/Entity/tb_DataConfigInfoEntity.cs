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
        /// 属性 <c>数据编号</c>.
        /// </summary>
        /// <value>对应表中<c>int_DId</c>字段的值</value>
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
        /// 属性 <c>数据编号是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_DIdNull</c>字段的值</value>
        public bool int_DIdNull
        {
            get { return _int_DIdNull; }
            set { _int_DIdNull = value; }
        }
        /// <summary>
        /// 属性 <c>数据名称</c>.
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

