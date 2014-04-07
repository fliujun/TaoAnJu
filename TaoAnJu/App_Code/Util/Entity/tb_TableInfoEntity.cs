using System;

namespace TaoAnJu.Util
{
    public class tb_TableInfoEntity
    {
        private Int32 _int_TbId = 0;
        private bool _int_TbIdNull = true;
        private string _vc_TableName;
        private string _vc_TableDesc;
        private Int32 _int_ParentId = 0;
        private bool _int_ParentIdNull = true;
        private Int32 _int_LinkFiId = 0;
        private bool _int_LinkFiIdNull = true;
        private string _vc_GUID;
        private Int32 _int_Order = 0;
        private bool _int_OrderNull = true;

        public tb_TableInfoEntity() { }
        /// <summary>
        /// 属性 <c>int_TbId3</c>.
        /// </summary>
        /// <value>对应表中<c>int_TbId</c>字段的值</value>
        public Int32 int_TbId
        {
            get { return _int_TbId; }
            set
            {
                _int_TbIdNull = false;
                _int_TbId = value;
            }
        }
        /// <summary>
        /// 属性 <c>int_TbId3是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_TbIdNull</c>字段的值</value>
        public bool int_TbIdNull
        {
            get { return _int_TbIdNull; }
            set { _int_TbIdNull = value; }
        }
        /// <summary>
        /// 属性 <c>vc_TableName130</c>.
        /// </summary>
        /// <value>对应表中<c>vc_TableName</c>字段的值</value>
        public string vc_TableName
        {
            get { return _vc_TableName; }
            set { _vc_TableName = value; }
        }
        /// <summary>
        /// 属性 <c>vc_TableDesc130</c>.
        /// </summary>
        /// <value>对应表中<c>vc_TableDesc</c>字段的值</value>
        public string vc_TableDesc
        {
            get { return _vc_TableDesc; }
            set { _vc_TableDesc = value; }
        }
        /// <summary>
        /// 属性 <c>int_ParentId3</c>.
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
        /// 属性 <c>int_ParentId3是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_ParentIdNull</c>字段的值</value>
        public bool int_ParentIdNull
        {
            get { return _int_ParentIdNull; }
            set { _int_ParentIdNull = value; }
        }
        /// <summary>
        /// 属性 <c>int_LinkFiId3</c>.
        /// </summary>
        /// <value>对应表中<c>int_LinkFiId</c>字段的值</value>
        public Int32 int_LinkFiId
        {
            get { return _int_LinkFiId; }
            set
            {
                _int_LinkFiIdNull = false;
                _int_LinkFiId = value;
            }
        }
        /// <summary>
        /// 属性 <c>int_LinkFiId3是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_LinkFiIdNull</c>字段的值</value>
        public bool int_LinkFiIdNull
        {
            get { return _int_LinkFiIdNull; }
            set { _int_LinkFiIdNull = value; }
        }
        /// <summary>
        /// 属性 <c>vc_GUID130</c>.
        /// </summary>
        /// <value>对应表中<c>vc_GUID</c>字段的值</value>
        public string vc_GUID
        {
            get { return _vc_GUID; }
            set { _vc_GUID = value; }
        }
        /// <summary>
        /// 属性 <c>int_Order3</c>.
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
        /// 属性 <c>int_Order3是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_OrderNull</c>字段的值</value>
        public bool int_OrderNull
        {
            get { return _int_OrderNull; }
            set { _int_OrderNull = value; }
        }

    }//类定义结束
}//命名空间结束

