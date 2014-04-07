using System;

namespace TaoAnJu.Util
{
    public class tb_RoleFunRangeEntity
    {
        private Int32 _int_Id = 0;
        private bool _int_IdNull = true;
        private Int32 _int_RFId = 0;
        private bool _int_RFIdNull = true;
        private Int32 _int_Range = 0;
        private bool _int_RangeNull = true;
        private Int32 _int_DepId = 0;
        private bool _int_DepIdNull = true;
        private DateTime _dt_CreateDate;
        private bool _dt_CreateDateNull = true;

        public tb_RoleFunRangeEntity() { }
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
        /// 属性 <c>角色权限编号</c>.
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
        /// 属性 <c>角色权限编号是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_RFIdNull</c>字段的值</value>
        public bool int_RFIdNull
        {
            get { return _int_RFIdNull; }
            set { _int_RFIdNull = value; }
        }
        /// <summary>
        /// 属性 <c>数据范围</c>.
        /// </summary>
        /// <value>对应表中<c>int_Range</c>字段的值</value>
        public Int32 int_Range
        {
            get { return _int_Range; }
            set
            {
                _int_RangeNull = false;
                _int_Range = value;
            }
        }
        /// <summary>
        /// 属性 <c>数据范围是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_RangeNull</c>字段的值</value>
        public bool int_RangeNull
        {
            get { return _int_RangeNull; }
            set { _int_RangeNull = value; }
        }
        /// <summary>
        /// 属性 <c>部门编号</c>.
        /// </summary>
        /// <value>对应表中<c>int_DepId</c>字段的值</value>
        public Int32 int_DepId
        {
            get { return _int_DepId; }
            set
            {
                _int_DepIdNull = false;
                _int_DepId = value;
            }
        }
        /// <summary>
        /// 属性 <c>部门编号是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_DepIdNull</c>字段的值</value>
        public bool int_DepIdNull
        {
            get { return _int_DepIdNull; }
            set { _int_DepIdNull = value; }
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

