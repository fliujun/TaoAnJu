using System;

namespace TaoAnJu.Util
{
    public class tb_FieldDataConfigEntity
    {
        private Int32 _int_FDID = 0;
        private bool _int_FDIDNull = true;
        private Int32 _int_FiId = 0;
        private bool _int_FiIdNull = true;
        private Int32 _int_DataNormal = 0;
        private bool _int_DataNormalNull = true;
        private Int32 _int_DestFiId = 0;
        private bool _int_DestFiIdNull = true;
        private Int32 _int_SourTbId = 0;
        private bool _int_SourTbIdNull = true;
        private Int32 _int_SourFiId = 0;
        private bool _int_SourFiIdNull = true;

        public tb_FieldDataConfigEntity() { }
        /// <summary>
        /// 属性 <c>编号</c>.
        /// </summary>
        /// <value>对应表中<c>int_FDID</c>字段的值</value>
        public Int32 int_FDID
        {
            get { return _int_FDID; }
            set
            {
                _int_FDIDNull = false;
                _int_FDID = value;
            }
        }
        /// <summary>
        /// 属性 <c>编号是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_FDIDNull</c>字段的值</value>
        public bool int_FDIDNull
        {
            get { return _int_FDIDNull; }
            set { _int_FDIDNull = value; }
        }
        /// <summary>
        /// 属性 <c>字段编号</c>.
        /// </summary>
        /// <value>对应表中<c>int_FiId</c>字段的值</value>
        public Int32 int_FiId
        {
            get { return _int_FiId; }
            set
            {
                _int_FiIdNull = false;
                _int_FiId = value;
            }
        }
        /// <summary>
        /// 属性 <c>字段编号是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_FiIdNull</c>字段的值</value>
        public bool int_FiIdNull
        {
            get { return _int_FiIdNull; }
            set { _int_FiIdNull = value; }
        }
        /// <summary>
        /// 属性 <c>数据范围编号</c>.
        /// </summary>
        /// <value>对应表中<c>int_DataNormal</c>字段的值</value>
        public Int32 int_DataNormal
        {
            get { return _int_DataNormal; }
            set
            {
                _int_DataNormalNull = false;
                _int_DataNormal = value;
            }
        }
        /// <summary>
        /// 属性 <c>数据范围编号是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_DataNormalNull</c>字段的值</value>
        public bool int_DataNormalNull
        {
            get { return _int_DataNormalNull; }
            set { _int_DataNormalNull = value; }
        }
        /// <summary>
        /// 属性 <c>目标字段编号</c>.
        /// </summary>
        /// <value>对应表中<c>int_DestFiId</c>字段的值</value>
        public Int32 int_DestFiId
        {
            get { return _int_DestFiId; }
            set
            {
                _int_DestFiIdNull = false;
                _int_DestFiId = value;
            }
        }
        /// <summary>
        /// 属性 <c>目标字段编号是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_DestFiIdNull</c>字段的值</value>
        public bool int_DestFiIdNull
        {
            get { return _int_DestFiIdNull; }
            set { _int_DestFiIdNull = value; }
        }
        /// <summary>
        /// 属性 <c>源表编号</c>.
        /// </summary>
        /// <value>对应表中<c>int_SourTbId</c>字段的值</value>
        public Int32 int_SourTbId
        {
            get { return _int_SourTbId; }
            set
            {
                _int_SourTbIdNull = false;
                _int_SourTbId = value;
            }
        }
        /// <summary>
        /// 属性 <c>源表编号是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_SourTbIdNull</c>字段的值</value>
        public bool int_SourTbIdNull
        {
            get { return _int_SourTbIdNull; }
            set { _int_SourTbIdNull = value; }
        }
        /// <summary>
        /// 属性 <c>源字段编号</c>.
        /// </summary>
        /// <value>对应表中<c>int_SourFiId</c>字段的值</value>
        public Int32 int_SourFiId
        {
            get { return _int_SourFiId; }
            set
            {
                _int_SourFiIdNull = false;
                _int_SourFiId = value;
            }
        }
        /// <summary>
        /// 属性 <c>源字段编号是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_SourFiIdNull</c>字段的值</value>
        public bool int_SourFiIdNull
        {
            get { return _int_SourFiIdNull; }
            set { _int_SourFiIdNull = value; }
        }

    }//类定义结束
}//命名空间结束

