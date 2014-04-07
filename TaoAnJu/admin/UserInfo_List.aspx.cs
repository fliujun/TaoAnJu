using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using TaoAnJu.Util;
public partial class admin_UserInfo_List : CAdminCookiePage
{
    DataTable dt;
    int RecordCount = 0;
    int PageNum = 1;
    Hashtable ht = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        lit_Script.Text = "";
        btnAdd.Attributes.Add("href", "javascript:JqueryDialog.Open1(\"添加用户\", \"UserInfo_Add.aspx\", 480, 298, false, false, true, 'no');");
        if (!Page.IsPostBack)
        {
            DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
            try
            {
                InitData(db);
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
    protected void InitRoleInfo(DsConnectionDB db)
    {
        string sql = "select int_RoleId,vc_RoleName from tb_RoleInfo";
        DataTable dt = db.ExecuteQuery(sql).Tables[0];
        ht.Clear();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ht.Add(dt.Rows[i][0], dt.Rows[i][1].ToString());
        }
    }
    protected void InitData(DsConnectionDB db)
    {
        string strFilter = "int_UserType>0";
        if (!string.IsNullOrEmpty(Request["page"]))
        {
            PageNum = int.Parse(Request["page"]);
        }
        string sql = "SELECT count(*) FROM tb_UserInfo where " + strFilter;
        dt = db.ExecuteQuery(sql).Tables[0];
        RecordCount = (int)dt.Rows[0][0];
        if (RecordCount == 0)
        {
            this.btnEdit.Visible = false;
            this.btnDelete.Visible = false;
        }
        dt = RiSystem.CurrentDataPage(db, "tb_UserInfo", "*", strFilter, PageNumBar1.PageSize, PageNum, "int_UserId", true);

        PageNumBar1.CurrPage = PageNum;
        PageNumBar1.RecordCount = RecordCount;

        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"添加用户\", \"UserInfo_Add.aspx\", 480, 298, false, false, true, 'no');");
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        int SelectCount = 0;
        string userid = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (GridView1.Rows[i].RowIndex >= 0)
            {
                CheckBox chk = (CheckBox)GridView1.Rows[i].FindControl("chkItem");
                if (chk.Checked)
                {
                    ++SelectCount;
                    userid = GridView1.Rows[i].Cells[1].Text;
                }
            }
        }
        if (SelectCount == 0)
        {
            lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"系统提示\", \"Msg.aspx?msg=请选择要修改的用户\", 240, 110, false, false, true, 'no');");
            return;
        }
        if (SelectCount > 1)
        {
            lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"系统提示\", \"Msg.aspx?msg=请选择一个用户进行修改\", 260, 110, false, false, true, 'no');");
            return;
        }
        lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"修改用户\", \"UserInfo_Add.aspx?userid=" + userid + "\", 480, 298, false, false, true, 'no');");
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
            lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"系统提示\", \"Msg.aspx?msg=请选择要删除的用户\", 240, 110, false, false, true, 'no');");
            return;
        }
        else
        {
            IdList = IdList.Substring(0, IdList.Length - 1);
        }

        sql = "delete from tb_UserInfo where int_UserId in(" + IdList + ")";
        UserOpInfo ui = new UserOpInfo("删除", "用户", sql, IdList);
        Session["UserOpInfo"] = ui;
        lit_Script.Text = StringTools.AddScript("JqueryDialog.Open1(\"系统提示\", \"Msg.aspx?optype=submit&msg=请确定是否删除所选记录\", 260, 110, false, false, true, 'no');");
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
            e.Row.Cells[9].Text = "<a href=\"javascript:JqueryDialog.Open1('用户角色\', 'UserRole.aspx?userid=" + e.Row.Cells[1].Text + "', 300, 300, true, true, true, 'yes');\" data-url=\"test\"><font color=\"blue\">用户角色</font></a>";
            if (e.Row.Cells[2].Text == "tajadmin")
            {
                e.Row.BackColor = System.Drawing.Color.LightGray;
                CheckBox chk = (CheckBox)e.Row.FindControl("chkItem");
                chk.Visible = false;
                e.Row.Cells[9].Text = "";
            }
            e.Row.Cells[4].Text = (e.Row.Cells[4].Text == "1") ? "管理员" : "销售代表";
            e.Row.Cells[8].Text = (e.Row.Cells[8].Text == "1") ? "正常" : "<font color=\"red\">停用</font>";
            
        }
    }
}