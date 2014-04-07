using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class inc_PageNumBar : System.Web.UI.UserControl
{
    public int RecordCount = 0;
    public int PageSize = 30;
    public int PageCount = 0;
    public int CurrPage = 1;
    public int LimitPageCount = 0;
    string RequestStr = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string sr = "";
            if (Request["sr"] == null)
            {
                sr = "sr=&";
            }
            RequestStr = Request.Url.AbsoluteUri;
            if (RequestStr.LastIndexOf("page=") >= 0)
            {
                RequestStr = RequestStr.Substring(0, RequestStr.LastIndexOf("page=")) + sr + "page=";
            }
            else
            {
                if (RequestStr.IndexOf("?") >= 0)
                {
                    RequestStr = RequestStr + "&" + sr + "page=";
                }
                else
                {
                    RequestStr = RequestStr + "?" + sr + "page=";
                }
            }
            PageCount = (PageCount == 0) ? (RecordCount - 1) / PageSize + 1 : PageCount;
            if (LimitPageCount == 0 || PageCount < LimitPageCount)
            {
                LimitPageCount = PageCount;
            }
            CurrPage = (CurrPage > LimitPageCount) ? LimitPageCount : CurrPage;
            lit_PageNum.Text = "<div style=\"height: 24px;border-width: 0px 1px 1px 1px; border-style: solid; border-color: #E1E1E1; background-color: #FFFFFF\"><div class=\"flickr\"><span class=\"recordcount\">共有记录<em>&nbsp;" + RecordCount.ToString() + "&nbsp;</em>条&nbsp;</span>";
            if (RecordCount > PageSize)
            {
                int FirstNum = 1;
                int LastNum = 10;
                if (LimitPageCount < 10)
                {
                    LastNum = LimitPageCount;
                }
                if (CurrPage > 3 && LimitPageCount > 10)
                {
                    FirstNum = CurrPage - 2;
                    if ((LimitPageCount - CurrPage) <= 7)
                    {
                        FirstNum = LimitPageCount - 9;
                    }
                    lit_PageNum.Text += "<a href=\"" + RequestStr + "1\">1 ...</a>";
                }
                if ((CurrPage + 7) < LimitPageCount)
                {
                    if (CurrPage > 3)
                    {
                        LastNum = CurrPage + 7;
                    }
                }
                else
                {
                    LastNum = LimitPageCount;
                }
                if (CurrPage > 1)
                {
                    lit_PageNum.Text += "<a href=\"" + RequestStr + Convert.ToString(CurrPage - 1) + "\">&lsaquo;&lsaquo;</a>";
                }
                for (int i = FirstNum; i <= LastNum; i++)
                {
                    if (i != CurrPage)
                    {
                        lit_PageNum.Text += "<a href=\"" + RequestStr + i.ToString() + "\">" + i.ToString() + "</a>";
                    }
                    else
                    {
                        lit_PageNum.Text += "<span class=\"current\">" + i.ToString() + "</span>";
                    }
                }
                if (CurrPage < LimitPageCount)
                {
                    lit_PageNum.Text += "<a href=\"" + RequestStr + Convert.ToString(CurrPage + 1) + "\">&rsaquo;&rsaquo;</a>";
                }
                if (LimitPageCount > 10 && (CurrPage + 7) < LimitPageCount)
                {
                    lit_PageNum.Text += "<a href=\"" + RequestStr + LimitPageCount.ToString() + "\">..." + PageCount.ToString() + "</a>";
                }
                lit_PageNum.Text += "<kbd><input type=\"text\" name=\"custompage\" size=\"3\" style=\"height:16px;BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove\" onkeydown=\"if(event.keyCode==13) {window.location='" + RequestStr + "'+this.value; return false;}\" /></kbd>";
            }
            lit_PageNum.Text += "</div></div>";
        }
    }
}