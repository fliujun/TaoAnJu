using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using TaoAnJu.Util;

public partial class Index : System.Web.UI.Page
{
    DataTable dt;
    int RecordCount = 0;
    int PageNum = 1;
    int PageSize = 5;//项目页记录，每次显示多少条
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
            try
            {
                getCity(db);
                InitAdInfo(db);
                InitItemData(db);
            }
            catch (System.Exception ee)
            {
                Loger.logErr("失败", ee);
            }
            finally
            {
                if (null != db) { db.Close(); }
            }
        }
    }
    //获取城市列表
    protected void getCity(DsConnectionDB db)
    {
        string sql = "select vc_Name from tb_DataConfigInfo where int_ParentId in(select int_DataNormal from tb_FieldInfo where vc_FieldName='vc_City' and int_TbId in(select int_TbId from tb_TableInfo where vc_TableName='tb_ItemInfo'))";
        DataTable dt = db.ExecuteQuery(sql).Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
        }
    }
    //获取广告信息
    protected void InitAdInfo(DsConnectionDB db)
    {
        string LoadAdImagePath = System.Configuration.ConfigurationManager.AppSettings["LoadAdImagePath"];
        //字段分别是广告标题、广告描述、图片文件、广告链接
        string sql = "select vc_AdTitle,vc_AdDesc," + LoadAdImagePath.Replace("\\", "/") + "+vc_AdPicFile as vc_AdPicFile,vc_AdLink where vc_AdType='页头' and int_Static=1 order by int_Order desc,int_Aid desc";
        DataTable dt = db.ExecuteQuery(sql).Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            
        }
    }
    //获取项目信息
    protected void InitItemData(DsConnectionDB db)
    {
        string LoadThumbnailPath = System.Configuration.ConfigurationManager.AppSettings["LoadThumbnailPath"];
        //显示字段，分别是项目编号，项目名称，楼盘地址，售楼地址，开盘时间，价格，图片缩略图
        string strFields = "int_ItemId,vc_ItemName,vc_Location,vc_SalesLocation,dt_OpeningTime,dec_ReferencePrice," + LoadThumbnailPath.Replace("\\", "/") + "+vc_PicFile2 as vc_PicFile2";
        //查询条件，必须是状态为1，付费项目永远显示
        string strFilter = "int_Static=1 and (int_IsPay=1 or int_itemid>0";
        //页数
        if (!string.IsNullOrEmpty(Request["page"]))
        {
            PageNum = int.Parse(Request["page"]);
        }
        //查询项目名称
        if (!string.IsNullOrEmpty(Request["iname"]))
        {
            strFilter += " and vc_ItemName like '%" + Request["iname"] + "%'";
        }
        //查询所属城市
        if (!string.IsNullOrEmpty(Request["city"]))
        {
            strFilter += " and vc_City='" + Request["city"] + "'";
        }
        //查询户型
        if (!string.IsNullOrEmpty(Request["htype"]))
        {
            strFilter += " and vc_HouseType=" + Request["htype"] + "'";
        }
        //查询价格，可以用区间法
        if (!string.IsNullOrEmpty(Request["price"]))
        {
            strFilter += " and dec_ReferencePrice=" + Request["price"];
        }
        strFilter += ")";
        //所有查询记录
        string sql = "SELECT count(*) FROM tb_ItemInfo where " + strFilter;
        dt = db.ExecuteQuery(sql).Tables[0];
        RecordCount = (int)dt.Rows[0][0];
        //当前页记录
        dt = RiSystem.CurrentDataPage(db, "tb_ItemInfo", strFields, strFilter, PageSize, PageNum, "int_IsPay desc,int_Order desc,int_ItemId", true);
        for (int i = 0; i < dt.Rows.Count; i++)
        {

        }
    }
}