using System;

namespace TaoAnJu.Util
{
    public class tb_AdInfoEntity
    {
        private Int32 _int_AId = 0;
        private bool _int_AIdNull = true;
        private string _vc_Guid;
        private string _vc_AdTitle;
        private string _vc_AdDesc;
        private string _vc_AdPicFile;
        private string _vc_AdLink;
        private string _vc_AdType;
        private DateTime _dt_CreateDate;
        private bool _dt_CreateDateNull = true;
        private Int32 _int_Order = 0;
        private bool _int_OrderNull = true;
        private Int32 _int_Status = 0;
        private bool _int_StatusNull = true;

        public tb_AdInfoEntity() { }
        /// <summary>
        /// 属性 <c>广告编号</c>.
        /// </summary>
        /// <value>对应表中<c>int_AId</c>字段的值</value>
        public Int32 int_AId
        {
            get { return _int_AId; }
            set
            {
                _int_AIdNull = false;
                _int_AId = value;
            }
        }
        /// <summary>
        /// 属性 <c>广告编号是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_AIdNull</c>字段的值</value>
        public bool int_AIdNull
        {
            get { return _int_AIdNull; }
            set { _int_AIdNull = value; }
        }
        /// <summary>
        /// 属性 <c>Guid</c>.
        /// </summary>
        /// <value>对应表中<c>vc_Guid</c>字段的值</value>
        public string vc_Guid
        {
            get { return _vc_Guid; }
            set { _vc_Guid = value; }
        }
        /// <summary>
        /// 属性 <c>广告标题</c>.
        /// </summary>
        /// <value>对应表中<c>vc_AdTitle</c>字段的值</value>
        public string vc_AdTitle
        {
            get { return _vc_AdTitle; }
            set { _vc_AdTitle = value; }
        }
        /// <summary>
        /// 属性 <c>广告描述</c>.
        /// </summary>
        /// <value>对应表中<c>vc_AdDesc</c>字段的值</value>
        public string vc_AdDesc
        {
            get { return _vc_AdDesc; }
            set { _vc_AdDesc = value; }
        }
        /// <summary>
        /// 属性 <c>广告图片</c>.
        /// </summary>
        /// <value>对应表中<c>vc_AdPicFile</c>字段的值</value>
        public string vc_AdPicFile
        {
            get { return _vc_AdPicFile; }
            set { _vc_AdPicFile = value; }
        }
        /// <summary>
        /// 属性 <c>广告链接</c>.
        /// </summary>
        /// <value>对应表中<c>vc_AdLink</c>字段的值</value>
        public string vc_AdLink
        {
            get { return _vc_AdLink; }
            set { _vc_AdLink = value; }
        }
        /// <summary>
        /// 属性 <c>广告类型</c>.
        /// </summary>
        /// <value>对应表中<c>vc_AdType</c>字段的值</value>
        public string vc_AdType
        {
            get { return _vc_AdType; }
            set { _vc_AdType = value; }
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
        /// 属性 <c>状态</c>.
        /// </summary>
        /// <value>对应表中<c>int_Status</c>字段的值</value>
        public Int32 int_Status
        {
            get { return _int_Status; }
            set
            {
                _int_StatusNull = false;
                _int_Status = value;
            }
        }
        /// <summary>
        /// 属性 <c>状态是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_StatusNull</c>字段的值</value>
        public bool int_StatusNull
        {
            get { return _int_StatusNull; }
            set { _int_StatusNull = value; }
        }

    }//类定义结束
}//命名空间结束

