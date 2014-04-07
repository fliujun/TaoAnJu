using System;

namespace TaoAnJu.Util
{
    public class tb_ViewInfoEntity
    {
        private Int32 _int_VId = 0;
        private bool _int_VIdNull = true;
        private Int32 _int_ItemId = 0;
        private bool _int_ItemIdNull = true;
        private string _vc_ViewFile;
        private string _vc_ViewDesc;
        private DateTime _dt_CreateDate;
        private bool _dt_CreateDateNull = true;
        private Int32 _int_IsView = 0;
        private bool _int_IsViewNull = true;

        public tb_ViewInfoEntity() { }
        /// <summary>
        /// 属性 <c>视频编号</c>.
        /// </summary>
        /// <value>对应表中<c>int_VId</c>字段的值</value>
        public Int32 int_VId
        {
            get { return _int_VId; }
            set
            {
                _int_VIdNull = false;
                _int_VId = value;
            }
        }
        /// <summary>
        /// 属性 <c>视频编号是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_VIdNull</c>字段的值</value>
        public bool int_VIdNull
        {
            get { return _int_VIdNull; }
            set { _int_VIdNull = value; }
        }
        /// <summary>
        /// 属性 <c>项目编号</c>.
        /// </summary>
        /// <value>对应表中<c>int_ItemId</c>字段的值</value>
        public Int32 int_ItemId
        {
            get { return _int_ItemId; }
            set
            {
                _int_ItemIdNull = false;
                _int_ItemId = value;
            }
        }
        /// <summary>
        /// 属性 <c>项目编号是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_ItemIdNull</c>字段的值</value>
        public bool int_ItemIdNull
        {
            get { return _int_ItemIdNull; }
            set { _int_ItemIdNull = value; }
        }
        /// <summary>
        /// 属性 <c>视频文件</c>.
        /// </summary>
        /// <value>对应表中<c>vc_ViewFile</c>字段的值</value>
        public string vc_ViewFile
        {
            get { return _vc_ViewFile; }
            set { _vc_ViewFile = value; }
        }
        /// <summary>
        /// 属性 <c>视频描述</c>.
        /// </summary>
        /// <value>对应表中<c>vc_ViewDesc</c>字段的值</value>
        public string vc_ViewDesc
        {
            get { return _vc_ViewDesc; }
            set { _vc_ViewDesc = value; }
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
        /// 属性 <c>是否显示</c>.
        /// </summary>
        /// <value>对应表中<c>int_IsView</c>字段的值</value>
        public Int32 int_IsView
        {
            get { return _int_IsView; }
            set
            {
                _int_IsViewNull = false;
                _int_IsView = value;
            }
        }
        /// <summary>
        /// 属性 <c>是否显示是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_IsViewNull</c>字段的值</value>
        public bool int_IsViewNull
        {
            get { return _int_IsViewNull; }
            set { _int_IsViewNull = value; }
        }

    }//类定义结束
}//命名空间结束

