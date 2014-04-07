using System;

namespace TaoAnJu.Util
{
    using System.Data;
	/// <summary>
	/// ϵͳ����Ա��¼�ж�
	/// </summary>
    public class CAdminCookiePage : System.Web.UI.Page
	{
		protected CUserTicket LoginInfo;

		/// <summary>
		/// ҳ��Loadʱ����û��Ƿ��ѵ�¼������ѵ�¼���Ͱ�Cookie�е���Ϣд���û���Ϣ��û�е�¼�򴴽�û��¼�û���Ϣ��

		/// </summary>
		/// <param name="e">�¼�����</param>
		/// <returns>void</returns>
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN���õ����� ASP.NET Web ���������������ġ�
			//
			string OpSecretStr = RiSystem.PwdSecret;
			bool IsLogin =CUserAuthen.CheckOpLogin(Request,OpSecretStr,out LoginInfo);

            if (!IsLogin || LoginInfo.ExpireTime < DateTime.Now)
            {
                //û�е�¼	
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
                            string url = AbsoluteUri + "/Msg.aspx?optype=error&msg=" + Server.UrlEncode("�Բ�����û�з���Ȩ�ޣ�");
                            System.Web.HttpContext.Current.Response.Write("<script>window.location=\"" + url + "\";</script>");
                            System.Web.HttpContext.Current.Response.End();
                        }
                    }
                    catch (System.Exception ee)
                    {
                        Loger.logErr(LoginInfo.LoginName + "����" + currpage + "ҳ��ʧ��", ee);
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
