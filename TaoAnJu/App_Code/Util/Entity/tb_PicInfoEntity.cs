using System;

namespace TaoAnJu.Util
{
    public class tb_PicInfoEntity
    {
        private Int32 _int_PId = 0;
        private bool _int_PIdNull = true;
        private Int32 _int_ItemId = 0;
        private bool _int_ItemIdNull = true;
        private string _vc_PicFile;
        private string _vc_PicDesc;
        private string _vc_PicType;
        private string _vc_Pic1;
        private string _vc_Pic2;
        private string _vc_Pic3;
        private DateTime _dt_CreateDate;
        private bool _dt_CreateDateNull = true;
        private Int32 _int_IsView = 0;
        private bool _int_IsViewNull = true;

        public tb_PicInfoEntity() { }
        /// <summary>
        /// 属性 <c>图片编号</c>.
        /// </summary>
        /// <value>对应表中<c>int_PId</c>字段的值</value>
        public Int32 int_PId
        {
            get { return _int_PId; }
            set
            {
                _int_PIdNull = false;
                _int_PId = value;
            }
        }
        /// <summary>
        /// 属性 <c>图片编号是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_PIdNull</c>字段的值</value>
        public bool int_PIdNull
        {
            get { return _int_PIdNull; }
            set { _int_PIdNull = value; }
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
        /// 属性 <c>图片文件</c>.
        /// </summary>
        /// <value>对应表中<c>vc_PicFile</c>字段的值</value>
        public string vc_PicFile
        {
            get { return _vc_PicFile; }
            set { _vc_PicFile = value; }
        }
        /// <summary>
        /// 属性 <c>图片描述</c>.
        /// </summary>
        /// <value>对应表中<c>vc_PicDesc</c>字段的值</value>
        public string vc_PicDesc
        {
            get { return _vc_PicDesc; }
            set { _vc_PicDesc = value; }
        }
        /// <summary>
        /// 属性 <c>图片类型</c>.
        /// </summary>
        /// <value>对应表中<c>vc_PicType</c>字段的值</value>
        public string vc_PicType
        {
            get { return _vc_PicType; }
            set { _vc_PicType = value; }
        }
        /// <summary>
        /// 属性 <c>略缩图1</c>.
        /// </summary>
        /// <value>对应表中<c>vc_Pic1</c>字段的值</value>
        public string vc_Pic1
        {
            get { return _vc_Pic1; }
            set { _vc_Pic1 = value; }
        }
        /// <summary>
        /// 属性 <c>略缩图2</c>.
        /// </summary>
        /// <value>对应表中<c>vc_Pic2</c>字段的值</value>
        public string vc_Pic2
        {
            get { return _vc_Pic2; }
            set { _vc_Pic2 = value; }
        }
        /// <summary>
        /// 属性 <c>略缩图3</c>.
        /// </summary>
        /// <value>对应表中<c>vc_Pic3</c>字段的值</value>
        public string vc_Pic3
        {
            get { return _vc_Pic3; }
            set { _vc_Pic3 = value; }
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

