using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Text.RegularExpressions;
using System.IO;
using TaoAnJu.Util;

public partial class admin_ViewInfo_List : CAdminCookiePage
{
    DataTable dt;
    int RecordCount = 0;
    int PageSize = 6;
    int PageNum = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        lit_Script.Text = "";
        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["itemid"]))
            {
                txt_ItemId.Text = Request["itemid"];
                InitData();
            }
            else
            {
                this.btnUpLoad.Visible = false;
            }
        }
    }
    protected void InitData()
    {
        DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
        try
        {
            string sql = "select vc_ItemName from tb_ItemInfo where int_ItemId=" + txt_ItemId.Text;
            dt = db.ExecuteQuery(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                lit_ItemName.Text = dt.Rows[0]["vc_ItemName"].ToString();
            }
            string strFields = "int_VId,vc_ViewFile,vc_ViewDesc,dt_CreateDate";
            string strFilter = "int_ItemId=" + txt_ItemId.Text;
            if (!string.IsNullOrEmpty(Request["page"]))
            {
                PageNum = int.Parse(Request["page"]);
            }
            if (!string.IsNullOrEmpty(Request["vid"]))
            {
                txt_VId.Text = Request["vid"];
            }
            sql = "SELECT count(*) FROM tb_ViewInfo where " + strFilter;
            dt = db.ExecuteQuery(sql).Tables[0];
            RecordCount = (int)dt.Rows[0][0];
            dt = RiSystem.CurrentDataPage(db, "tb_ViewInfo", strFields, strFilter, PageSize, PageNum, "int_VId", true);

            PageNumBar1.PageSize = PageSize;
            PageNumBar1.CurrPage = PageNum;
            PageNumBar1.RecordCount = RecordCount;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["int_VId"].ToString() == txt_VId.Text)
                {
                    txt_ViewDesc.Text = dt.Rows[i]["vc_ViewDesc"].ToString();
                    txt_ViewFile.Text = dt.Rows[i]["vc_ViewFile"].ToString();
                }
                else
                {
                    dt.Rows[i]["vc_ViewDesc"] = "<a href=\"ViewInfo_List.aspx?itemid=" + txt_ItemId.Text + "&vid=" + dt.Rows[i]["int_Vid"].ToString() + "\"><font color=\"blue\">" + dt.Rows[i]["vc_ViewDesc"] + "</font></a>";
                }
            }
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
            DataList1.DataSource = dt;
            DataList1.DataBind();
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
    protected void btnUpLoad_Click(object sender, EventArgs e)
    {   
        if (txt_ViewFile.Text == "")
        {
            lit_Msg.Text = "错误提示：请输入视频文件地址！";
            return;
        }
        if (txt_ViewDesc.Text == "")
        {
            lit_Msg.Text = "错误提示：请输入视频描述！";
            return;
        }
        DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
        try
        {
            tb_ViewInfoEntity obj = new tb_ViewInfoEntity();
            tb_ViewInfoEntity_Op objo = new tb_ViewInfoEntity_Op(db);

            obj.vc_ViewDesc = txt_ViewDesc.Text.Trim();
            obj.vc_ViewFile = txt_ViewFile.Text.Trim();
            if (txt_VId.Text == "")
            {
                obj.dt_CreateDate = DateTime.Now;
                obj.int_IsView = 1;
                obj.int_ItemId = Convert.ToInt32(txt_ItemId.Text);
                objo.Insert(obj);

                RiSystem.AddLog(db, "添加", LoginInfo.RealName + "进行 房产项目编号为" + txt_ItemId.Text + "的视频 添加操作，相关编号为：" + obj.int_VId.ToString(), Request.UserHostAddress, LoginInfo.UserId);
            }
            else
            {
                obj.int_VId = Convert.ToInt32(txt_VId.Text);
                objo.Update(obj);
                RiSystem.AddLog(db, "修改", LoginInfo.RealName + "进行 房产项目编号为" + txt_ItemId.Text + "的视频 修改操作，相关编号为：" + obj.int_VId.ToString(), Request.UserHostAddress, LoginInfo.UserId);
            }
            Response.Redirect("ViewInfo_List.aspx?itemid=" + txt_ItemId.Text);
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
        if (e.Row.RowIndex >= 0)
        {
            LinkButton lb = (LinkButton)e.Row.FindControl("btnDel");
            lb.Attributes.Add("onclick", "javascript:return del_sure()");
            e.Row.Cells[1].Text = "<a href =\"ViewInfo_List.aspx?itemid=" + txt_ItemId.Text + "&vid=" + e.Row.Cells[0].Text + "\">"+e.Row.Cells[1].Text+"</a>";
            e.Row.Cells[2].Text = "<a href =\""+e.Row.Cells[2].Text +"\" target=\"_blank\">查看视频</a>";
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
        try
        {
            string sql = "delete from tb_ViewInfo where int_VId=" + GridView1.Rows[e.RowIndex].Cells[0].Text;
            db.ExecuteNonQuery(sql);
            RiSystem.AddLog(db, "删除", LoginInfo.RealName + "进行 房产项目编号为" + txt_ItemId.Text + "的视频 删除操作，相关编号为：" + GridView1.Rows[e.RowIndex].Cells[0].Text, Request.UserHostAddress, LoginInfo.UserId);
            Response.Redirect("ViewInfo_List.aspx?itemid=" + txt_ItemId.Text);
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
    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemIndex >= 0)
        {
            LinkButton lb = (LinkButton)e.Item.FindControl("btnDel");
            lb.Attributes.Add("onclick", "javascript:return del_sure()");
        }
    }
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            string vid = DataList1.DataKeys[e.Item.ItemIndex].ToString();
            DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
            try
            {
                string sql = "delete from tb_ViewInfo where int_Vid=" + vid;
                db.ExecuteNonQuery(sql);
                RiSystem.AddLog(db, "删除", LoginInfo.RealName + "进行 房产项目编号为" + txt_ItemId.Text + "的视频 删除操作，相关编号为：" + vid, Request.UserHostAddress, LoginInfo.UserId);
                Response.Redirect("ViewInfo_List.aspx?itemid=" + txt_ItemId.Text);
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
}