using System;

namespace TaoAnJu.Util
{
    using System.Data;
	/// <summary>
	/// 系统管理员登录判断
	/// </summary>
    public class CAdminCookiePage : System.Web.UI.Page
	{
		protected CUserTicket LoginInfo;

		/// <summary>
		/// 页面Load时检查用户是否已登录。如果已登录，就把Cookie中的信息写入用户信息；没有登录则创建没登录用户信息。

		/// </summary>
		/// <param name="e">事件参数</param>
		/// <returns>void</returns>
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN：该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			string OpSecretStr = RiSystem.PwdSecret;
			bool IsLogin =CUserAuthen.CheckOpLogin(Request,OpSecretStr,out LoginInfo);

            if (!IsLogin || LoginInfo.ExpireTime < DateTime.Now)
            {
                //没有登录	
                LoginInfo = new CUserTicket(0, "", "", DateTime.Now, "", DateTime.Now, "", "",false);

                string AbsoluteUri = Request.Url.AbsoluteUri.ToLower();
                AbsoluteUri = AbsoluteUri.Substring(0, AbsoluteUri.IndexOf("admin") + "admin".Length);
                string url = AbsoluteUri + "/LoginPage.aspx";
                System.Web.HttpContext.Current.Response.Write("<script>window.parent.location=\"" + url + "\";</script>");
                System.Web.HttpContext.Current.Response.End();
            }
            else
            {
                string AbsoluteUri = Request.Url.AbsoluteUri.ToLower();
                string currpage = AbsoluteUri.Substring(AbsoluteUri.LastIndexOf("/") + 1).ToLower();
                int n=currpage.IndexOf("?");
                if (n >= 0)
                {
                    currpage = currpage.Substring(0, n);
                }
                if (currpage != "msg.aspx" && currpage != "left.aspx"  && currpage !="index.aspx"  && currpage !="logout.aspx" && currpage !="changepwd.aspx")
                {
                    DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
                    try
                    {
                        string sql = "select int_FunId from tb_FunInfo where int_FunId in(" + LoginInfo.FunIdList + ") and vc_Value like '%" + currpage + "%'";
                        DataTable dt = db.ExecuteQuery(sql).Tables[0];
                        if (dt.Rows.Count == 0)
                        {
                            AbsoluteUri = AbsoluteUri.Substring(0, AbsoluteUri.IndexOf("admin") + "admin".Length);
                            string url = AbsoluteUri + "/Msg.aspx?optype=error&msg=" + Server.UrlEncode("对不起，您没有访问权限！");
                            System.Web.HttpContext.Current.Response.Write("<script>window.location=\"" + url + "\";</script>");
                            System.Web.HttpContext.Current.Response.End();
                        }
                    }
                    catch (System.Exception ee)
                    {
                        Loger.logErr(LoginInfo.LoginName + "访问" + currpage + "页面失败", ee);
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
			base.OnInit(e);
		}
	}
}
