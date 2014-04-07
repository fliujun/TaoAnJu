using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TaoAnJu.Util;
public partial class admin_RoleFun : CAdminCookiePage
{
    string Nowgather = "0"; 
    protected void Page_Load(object sender, EventArgs e)
    {
        tv.Attributes.Add("onclick", "OnTreeNodeChecked(\""+tv.ID+"\",\"3\")");
        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty (Request["roleid"]))
            {
                this.txt_RoleId.Text = Request["roleid"];
                this.InitTree();
            }
        }
        if (txt_RoleId.Text != "")
        {
            if (!string.IsNullOrEmpty(Request["action"]) && Request["action"].ToString().ToLower() == "submit")
            {
                SavaData();
            }
        }
    }
    protected void SavaData()
    {
        SearchFun();
        string FunStr = "";
        string FunInfoIds = "";
        if (ViewState["FunStr"] != null)
        {
            FunStr = ViewState["FunStr"].ToString();
        }
        string[] Nowdata = Nowgather.Substring(0, Nowgather.Length - 1).Split(',');
        string[] Predata = FunStr.Split(',');
        DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
        try
        {
            tb_RoleFunEntity_Op objo = new tb_RoleFunEntity_Op(db);
            if (FunStr == "")
            {
                for (int i = 0; i < Nowdata.Length; i++)                           //    添加新记录
                {
                    tb_RoleFunEntity obj = new tb_RoleFunEntity();
                    obj.dt_CreateDate = DateTime.Now;
                    obj.int_FunId = Convert.ToInt32(Nowdata[i]);
                    obj.int_RoleId = Convert.ToInt32(txt_RoleId.Text);
                    objo.Insert(obj);
                }
            }
            else
            {
                for (int i = 0; i < Predata.Length; i++)
                {
                    if (Nowgather.IndexOf(Predata[i].ToString()) < 0)           //    删除原来的记录	
                    {
                        FunInfoIds += Predata[i].ToString() + ",";
                    }
                }
                if (FunInfoIds.Length > 0)
                {
                    FunInfoIds = FunInfoIds.Substring(0, FunInfoIds.Length - 1);
                    string sql = "delete from tb_RoleFun where int_RoleId=" + this.txt_RoleId.Text + "  and int_FunId in (" + FunInfoIds + ")";
                    db.ExecuteNonQuery(sql);
                }
                for (int i = 0; i < Nowdata.Length; i++)
                {
                    if (FunStr.IndexOf(Nowdata[i].ToString()) < 0)            //     添加新的记录
                    {
                        tb_RoleFunEntity obj = new tb_RoleFunEntity();
                        obj.dt_CreateDate = DateTime.Now;
                        obj.int_FunId = Convert.ToInt32(Nowdata[i]);
                        obj.int_RoleId = Convert.ToInt32(txt_RoleId.Text);
                        objo.Insert(obj);
                    }
                }
            }
            ViewState["FunStr"] = null;
            RiSystem.AddLog(db, "修改", LoginInfo.RealName + "进行 角色权限 修改操作", Request.UserHostAddress, LoginInfo.UserId);
            lit_Script.Text = StringTools.AddScript("JqueryDialog.Close();");
            return;
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
    //获取选择的权限
    protected void SearchFun()
    {
        for (int i = 0; i < tv.Nodes.Count; i++)
        {
            if (tv.Nodes[i].Checked)
            {
                Nowgather += tv.Nodes[i].Value + ",";
            }
            Tree_Search(tv.Nodes[i]);
        }
    }
    protected void Tree_Search(TreeNode node)
    {
        for (int i = 0; i < node.ChildNodes.Count; i++)
        {
            if (node.ChildNodes[i].Checked)
            {
                Nowgather += node.ChildNodes[i].Value + ",";
            }
            if (node.ChildNodes[i].ChildNodes.Count > 0)
                this.Tree_Search(node.ChildNodes[i]);
        }
    }
    protected void InitTree()
    {
        DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
        try
        {
            //提取角色已有权限
            string sql = "SELECT int_FunId FROM tb_RoleFun WHERE int_RoleId=" + this.txt_RoleId.Text;
            DataTable dt = db.ExecuteQuery(sql).Tables[0];
            string FunStr = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                FunStr += dt.Rows[i]["int_FunId"].ToString();
                if (i < dt.Rows.Count - 1)
                    FunStr += ",";
            }
            ViewState["FunStr"] = FunStr;
            //提取所有权限
            sql = "SELECT int_FunId,vc_Name,int_ParentId from tb_FunInfo order by int_order,int_funid";
            dt = db.ExecuteQuery(sql).Tables[0];
            DataRow[] dr = dt.Select(" int_ParentId=-1");
            for (int i = 0; i < dr.Length; i++)
            {
                TreeNode tnRoot = new TreeNode();
                tnRoot.Text = dr[i]["vc_Name"].ToString();
                tnRoot.Value = dr[i]["int_FunId"].ToString();
                tnRoot.SelectAction = TreeNodeSelectAction.None;
                tv.Nodes.Add(tnRoot);
                if (ISTRUE(int.Parse(tnRoot.Value)))
                {
                    tnRoot.Checked = true;
                }
                this.InitFun(dt, tnRoot);
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
    protected void InitFun(DataTable dt, TreeNode tnCurrent)
    {
        DataRow[] dr = dt.Select(" int_ParentId=" + tnCurrent.Value);
        for (int i = 0; i < dr.Length; i++)
        {
            TreeNode cNode = new TreeNode();
            cNode.Text = dr[i]["vc_Name"].ToString();
            cNode.Value = dr[i]["int_FunId"].ToString();
            cNode.SelectAction = TreeNodeSelectAction.None;
            tnCurrent.ChildNodes.Add(cNode);
            if (ISTRUE(int.Parse(cNode.Value)))
            {
                cNode.Checked = true;
            }
            this.InitFun(dt, cNode);
        }
    }
    protected bool ISTRUE(int int_FunId)              // 判断是否有相应的权限
    {
        if (ViewState["FunStr"] == null)
        {
            return false;
        }
        string FunStr = "";
        FunStr = ViewState["FunStr"].ToString();
        if (FunStr.IndexOf(int_FunId.ToString()) >= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void CheckParentNode(TreeNode n)
    {
        TreeNode node = n.Parent;
        if (node != null)
        {
            node.Checked = true;
            CheckParentNode(node);
        }
    }
    private void CheckChildNode(TreeNode n)
    {
        for (int i = 0; i < n.ChildNodes.Count; i++)
        {
            TreeNode node = n.ChildNodes[i];
            node.Checked = n.Checked;
            CheckChildNode(node);
        }
    }
    protected void tv_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
    {
        //CheckParentNode(e.Node);
        //CheckChildNode(e.Node);
    }
}