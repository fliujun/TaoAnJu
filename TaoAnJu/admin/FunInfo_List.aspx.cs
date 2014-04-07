using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaoAnJu.Util;
public partial class admin_FunInfo_List : CAdminCookiePage
{
    DataTable dt;
    int RecordCount = 0;
    int PageNum = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        lit_Script.Text = "";
        btnAdd.Attributes.Add("href", "javascript:JqueryDialog.Open1(\"添加权限\", \"FunInfo_Add.aspx?parentid=" + Request["parentid"] + "\", 420, 225, false, false, true, 'no');");
        if (!Page.IsPostBack)
        {
            InitData();
        }
    }
    protected void InitData()
    {
        DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
        try
        {
            string strFilter = "int_ParentId=-1";
            if (!string.IsNullOrEmpty(Request["page"]))
            {
                PageNum = int.Parse(Request["page"]);
            }
            if (!string.IsNullOrEmpty(Request["parentid"]))
            {
                lit_FunPath.Text = RiSystem.getFunPath(db, Convert.ToInt32(Request["parentid"]));
                if (lit_FunPath.Text != "")
                {
                    lit_FunPath.Text = "{" + lit_FunPath.Text+"}";
                }
                strFilter = "int_ParentId=" + Request["parentid"];
            }
            string sql = "SELECT count(*) FROM tb_FunInfo where " + strFilter;
            dt = db.ExecuteQuery(sql).Tables[0];
            RecordCount = (int)dt.Rows[0][0];
            if (RecordCount == 0)
            {
                this.btnEdit.Visible = false;
                this.btnDelete.Visible = false;
            }
            dt = RiSystem.CurrentDataPage(db, "tb_FunInfo", "*", strFilter, PageNumBar1.PageSize, PageNum, "int_FunId,int_Order", false);

            PageNumBar1.CurrPage = PageNum;
            PageNumBar1.RecordCount = RecordCount;

            GridView1.DataSource = dt;
            GridView1.DataBind();
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
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"添加权限\", \"FunInfo_Add.aspx?parentid=" + Request["parentid"] + "\", 420, 225, false, false, true, 'no');");
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        int SelectCount = 0;
        string funid = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (GridView1.Rows[i].RowIndex >= 0)
            {
                CheckBox chk = (CheckBox)GridView1.Rows[i].FindControl("chkItem");
                if (chk.Checked)
                {
                    ++SelectCount;
                    funid = GridView1.Rows[i].Cells[1].Text;
                }
            }
        }
        if (SelectCount == 0)
        {
            lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"系统提示\", \"Msg.aspx?msg=请选择要修改的权限\", 200, 110, false, false, true, 'no');");
            return;
        }
        if (SelectCount > 1)
        {
            lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"系统提示\", \"Msg.aspx?msg=请选择一个权限进行修改\", 200, 110, false, false, true, 'no');");
            return;
        }
        lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"修改权限\", \"FunInfo_Add.aspx?funid=" + funid + "\", 420, 225, false, false, true, 'no');");
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int SelectCount = 0;
        string IdList = "";
        string sql = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (GridView1.Rows[i].RowIndex >= 0)
            {
                CheckBox chk = (CheckBox)GridView1.Rows[i].FindControl("chkItem");
                if (chk.Checked)
                {
                    ++SelectCount;
                    IdList += GridView1.Rows[i].Cells[1].Text + ",";
                }
            }
        }
        if (SelectCount == 0)
        {
            lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"系统提示\", \"Msg.aspx?msg=请选择要删除的权限\", 200, 110, false, false, true, 'no');");
            return;
        }
        else
        {
            IdList = IdList.Substring(0, IdList.Length - 1);
        }
        DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
        try
        {
            sql = "select int_FunId from tb_RoleFun where int_FunId in(" + IdList + ") group by int_FunId order by int_FunId";
            dt = db.ExecuteQuery(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                IdList = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IdList += dt.Rows[i][0].ToString() + ",";
                }
                IdList = IdList.Substring(0, IdList.Length - 1);
                lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"系统提示\", \"Msg.aspx?msg=删除失败，编号为：" + IdList + " 的权限已被使用\", 360, 130, false, false, true, 'no');");
                return;
            }
            sql = "delete from tb_FunInfo where int_FunId in(" + IdList + ")";
            UserOpInfo ui = new UserOpInfo("删除", "权限", sql, IdList);
            Session["UserOpInfo"] = ui;
            lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"系统提示\", \"Msg.aspx?isleft=1&expand=fun&optype=submit&msg=请确定是否删除所选记录\", 240, 110, false, false, true, 'no');");
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
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            CheckBox chk = (CheckBox)e.Row.FindControl("chkAll");
            chk.Attributes.Add("onclick", "javascript:return SelectAll(this.checked,this.id)");
        }
        if (e.Row.RowIndex >= 0)
        {
            switch (e.Row.Cells[5].Text)
            {
                case "1":
                    e.Row.Cells[5].Text = "菜单名称";
                    break;
                case "2":
                    e.Row.Cells[5].Text = "页面地址";
                    break;
                case "3":
                    e.Row.Cells[5].Text = "操作权限";
                    break;
                default :
                    e.Row.Cells[5].Text = "菜单名称";
                    break;
            }
            e.Row.Cells[6].Text = "<a href=\"javascript:JqueryDialog.Open1('授权角色\', 'FunRole.aspx?funid=" + e.Row.Cells[1].Text + "', 240, 300, true, true, true, 'no');\"><font color=\"blue\">授权角色</font></a>";
        }
    }
}