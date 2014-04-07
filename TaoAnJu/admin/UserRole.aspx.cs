using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using TaoAnJu.Util;
public partial class admin_UserRole :CAdminCookiePage 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lit_Script.Text = "";
        DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
        try
        {
            if (!string.IsNullOrEmpty(Request["userid"]))
            {
                txt_UserId.Text = Request["userid"];
            }
            if (txt_UserId.Text != "")
            {
                if (!string.IsNullOrEmpty(Request["action"]) && Request["action"].ToString().ToLower() == "submit")
                {
                    string sql = "delete from tb_UserRole where int_UserId=" + txt_UserId.Text;
                    db.ExecuteNonQuery(sql);
                    string RoleId = "";
                    tb_UserRoleEntity_Op uro = new tb_UserRoleEntity_Op(db);
                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        if (GridView1.Rows[i].RowIndex >= 0)
                        {
                            CheckBox chk = (CheckBox)GridView1.Rows[i].FindControl("chkItem");
                            if (chk.Checked)
                            {
                                RoleId = GridView1.Rows[i].Cells[0].Text;
                                tb_UserRoleEntity ur = new tb_UserRoleEntity();
                                ur.int_RoleId = Convert.ToInt32(RoleId);
                                ur.int_UserId = Convert.ToInt32(txt_UserId.Text);
                                ur.dt_CreateDate = DateTime.Now;
                                uro.Insert(ur);
                            }
                        }
                    }
                    RiSystem.AddLog(db, "修改", LoginInfo.RealName + "进行 用户角色 修改操作", Request.UserHostAddress, LoginInfo.UserId);
                    lit_Script.Text = StringTools.AddScript("JqueryDialog.Close();");
                    return;
                }
                InitData(db);
            }
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
    protected void InitData(DsConnectionDB db)
    {
        string sql = "select int_RoleId,vc_RoleName,1 as isCheck from v_UserRole where int_UserId=" + txt_UserId.Text + " order by int_RoleId";
        DataTable dt = db.ExecuteQuery(sql).Tables[0];

        sql = "select int_RoleId,vc_RoleName,0 as isCheck from tb_RoleInfo where int_RoleId not in(select int_RoleId from tb_UserRole where int_UserId=" + txt_UserId.Text + ") order by int_RoleId";
        DataTable rdt = db.ExecuteQuery(sql).Tables[0];
        for (int i = 0; i < rdt.Rows.Count; i++)
        {
            DataRow dr= dt.NewRow();
            dr[0] = rdt.Rows[i][0];
            dr[1] = rdt.Rows[i][1];
            dr[2] = rdt.Rows[i][2];
            dt.Rows.Add(dr);
        }
        rdt = null;
        GridView1.DataSource = dt;
        GridView1.DataBind();
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if ((int)dt.Rows[i]["isCheck"] == 1)
                {
                    CheckBox chk = (CheckBox)GridView1.Rows[i].FindControl("chkItem");
                    chk.Checked = true;
                }
            }
        }
    }
}