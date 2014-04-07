using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaoAnJu.Util;
public partial class admin_Tree :CAdminCookiePage
{
    string sql = "";
    public string TreeTitle = "选择部门";
    string __ClientScript = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["cid"]))
            {
                txtId.Text = Request["cid"];
            }
            if (!string.IsNullOrEmpty(Request["ctype"]))
            {
                txtType.Text = Request["ctype"];
            }
            if (!string.IsNullOrEmpty (Request["svalue"]))
            {
                txtValue.Text = Request["svalue"];
                txtName.Text = Request["sname"];
                __ClientScript += "window.opener.document.getElementById('" + Request["cvalue"] + "').value='" + txtValue.Text + "';";
                __ClientScript += "window.opener.document.getElementById('" + Request["cname"] + "').value='" + txtName.Text + "';";
                __ClientScript += "window.close();";
                lit_Script.Text = StringTools.AddScript(__ClientScript);
                return;
            }
            DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
            try
            {
                DataTable dt;
                TreeNode tnRoot = new TreeNode();
                tnRoot.SelectAction = TreeNodeSelectAction.Expand;
                tnRoot.Value = "-1";
                switch (txtType.Text)
                {
                    case "1":
                        sql = "select int_FunId,vc_Name,int_ParentId from tb_FunInfo where int_Type<>3";
                        TreeTitle = "选择权限";
                        tnRoot.Text = "权限";
                        tv.Nodes.Add(tnRoot);
                        dt = db.ExecuteQuery(sql).Tables[0];
                        InitTree(dt, tnRoot,"-1");
                        break;
                    case "2":
                        sql = "select int_DepId,vc_Name,int_ParentId from tb_DepInfo";
                        TreeTitle = "选择部门";
                        tnRoot.Text = "部门";
                        tv.Nodes.Add(tnRoot);
                        dt = db.ExecuteQuery(sql).Tables[0];
                        InitTree(dt, tnRoot,"-1");
                        break;
                    case "3":
                        TreeTitle = "选择数据规范";
                        tnRoot.Text = "数据规范";
                        tv.Nodes.Add(tnRoot);
                        sql = "select int_DId,vc_Name,int_ParentId from tb_DataConfigInfo where int_ParentId=-1 and int_Type=1";
                        dt = db.ExecuteQuery(sql).Tables[0];
                        InitTree(dt, tnRoot, "-1");
                        break;
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
    }
    private void InitTree(DataTable dt, TreeNode tnCurrent,string parentid)
    {
        DataRow[] dr = dt.Select(" int_parentid=" + parentid.ToString ());
        for (int i = 0; i < dr.Length; i++)
        {
            TreeNode tNode = new TreeNode();
            if (dr[i][0].ToString() == txtId.Text)
            {
                tNode.Text ="<font color=\"blue\">"+ dr[i][1].ToString()+"</font>";
            }
            else
            {
                tNode.Text = dr[i][1].ToString();
            }
            tNode.Value = dr[i][0].ToString();
            tNode.NavigateUrl = "Tree.aspx?cname=" + Request["cname"] + "&cvalue=" + Request["cvalue"];
            tNode.NavigateUrl += "&svalue=" + dr[i][0].ToString() + "&sname=" + dr[i][1].ToString();
            tnCurrent.ChildNodes.Add(tNode);
            InitTree(dt, tNode, dr[i][0].ToString());
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        __ClientScript += "window.opener.document.getElementById('" + Request["cvalue"] + "').value='';" ;
        __ClientScript += "window.opener.document.getElementById('" + Request["cname"] + "').value='';" ;
        __ClientScript += "window.close();";
        lit_Script.Text = StringTools.AddScript(__ClientScript);
        return;
    }
}