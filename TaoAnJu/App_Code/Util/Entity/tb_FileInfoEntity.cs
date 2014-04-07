using System;

namespace TaoAnJu.Util
{
    public class tb_FileInfoEntity
    {
        private Int32 _int_FileId = 0;
        private bool _int_FileIdNull = true;
        private string _vc_ShowName;
        private string _vc_FileName;
        private Int32 _int_TbId = 0;
        private bool _int_TbIdNull = true;
        private Int32 _int_RecordId = 0;
        private bool _int_RecordIdNull = true;
        private DateTime _dt_CreateDate;
        private bool _dt_CreateDateNull = true;
        private Int32 _int_UserId = 0;
        private bool _int_UserIdNull = true;

        public tb_FileInfoEntity() { }
        /// <summary>
        /// 属性 <c>文件编号</c>.
        /// </summary>
        /// <value>对应表中<c>int_FileId</c>字段的值</value>
        public Int32 int_FileId
        {
            get { return _int_FileId; }
            set
            {
                _int_FileIdNull = false;
                _int_FileId = value;
            }
        }
        /// <summary>
        /// 属性 <c>文件编号是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_FileIdNull</c>字段的值</value>
        public bool int_FileIdNull
        {
            get { return _int_FileIdNull; }
            set { _int_FileIdNull = value; }
        }
        /// <summary>
        /// 属性 <c>显示名称</c>.
        /// </summary>
        /// <value>对应表中<c>vc_ShowName</c>字段的值</value>
        public string vc_ShowName
        {
            get { return _vc_ShowName; }
            set { _vc_ShowName = value; }
        }
        /// <summary>
        /// 属性 <c>文件路径</c>.
        /// </summary>
        /// <value>对应表中<c>vc_FileName</c>字段的值</value>
        public string vc_FileName
        {
            get { return _vc_FileName; }
            set { _vc_FileName = value; }
        }
        /// <summary>
        /// 属性 <c>来源表编号</c>.
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
        /// 属性 <c>来源表编号是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_TbIdNull</c>字段的值</value>
        public bool int_TbIdNull
        {
            get { return _int_TbIdNull; }
            set { _int_TbIdNull = value; }
        }
        /// <summary>
        /// 属性 <c>来源记录编号</c>.
        /// </summary>
        /// <value>对应表中<c>int_RecordId</c>字段的值</value>
        public Int32 int_RecordId
        {
            get { return _int_RecordId; }
            set
            {
                _int_RecordIdNull = false;
                _int_RecordId = value;
            }
        }
        /// <summary>
        /// 属性 <c>来源记录编号是否为空</c>.
        /// </summary>
        /// <value>对应表中<c>int_RecordIdNull</c>字段的值</value>
        public bool int_RecordIdNull
        {
            get { return _int_RecordIdNull; }
            set { _int_RecordIdNull = value; }
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

    }//类定义结束
}//命名空间结束

