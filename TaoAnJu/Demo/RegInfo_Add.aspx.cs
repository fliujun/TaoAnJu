using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaoAnJu.Util;
public partial class RegInfo_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty (Request["itemid"])&&!string.IsNullOrEmpty(Request["action"]) && Request["action"].ToString().ToLower() == "submit")
        {
            if (txt_Mobile.Text.Trim() == "")
            {
                //不能为空
            }
            else
            {
                //判断是否为合格的手机号
            }
            if (txt_Name.Text.Trim() == "")
            {
                //不能为空
            }
            DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
            try
            {
                string sql = "select count(*) from tb_RegInfo where vc_ItemId="+Request["itemid"]+" and vc_Mobile='" + txt_Mobile.Text + "'";
                if ((int)db.ExecuteScalar(sql) > 0)
                {
                    //本项目已经报名
                    return;
                }
                tb_RegInfoEntity r = new tb_RegInfoEntity();
                tb_RegInfoEntity_Op ro = new tb_RegInfoEntity_Op(db);
                r.int_ItemId = Convert.ToInt32(Request["itemid"]);
                r.dt_CreateDate = DateTime.Now;
                r.vc_Mobile = txt_Mobile.Text.Trim();
                r.vc_Name = txt_Name.Text.Trim();
                ro.Insert(r);
                //同时判断客户表里此客户是否存在
                sql = "select count(*) from tb_Customer where vc_Mobile='" + txt_Mobile.Text.Trim() + "'";
                if ((int)db.ExecuteScalar(sql) == 0)
                {
                    //不存在则同时添加到客户表
                    tb_CustomerEntity c = new tb_CustomerEntity();
                    tb_CustomerEntity_Op co = new tb_CustomerEntity_Op(db);
                    c.dt_CreateDate = DateTime.Now;
                    c.vc_Mobile = txt_Mobile.Text.Trim();
                    c.vc_Name = txt_Name.Text.Trim();
                    //自动分配给服务客户数量最少的销售代表，没有销售代表则分配给管理员
                    sql = "select top 1 int_UserId from tb_UserInfo order by int_CCount asc,int_UserType desc";
                    DataTable dt = db.ExecuteQuery(sql).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        c.int_UserId = Convert.ToInt32(dt.Rows[0]["int_UserInfo"].ToString());
                    }
                    else
                    {
                        c.int_UserId = 0;
                    }
                    co.Insert(c);
                }
            }
            catch (System.Exception ee)
            {
                Loger.logErr("失败", ee);
            }
            finally
            {
                if (db != null)
                {
                    db.Close();
                }
            }
        }
    }
}