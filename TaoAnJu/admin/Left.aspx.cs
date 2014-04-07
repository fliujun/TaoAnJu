using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaoAnJu.Util;
public partial class admin_Left : CAdminCookiePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
        try
        {
            DataTable dt2;
            string sql = "select vc_Name,vc_Value from tb_FunInfo where int_Type=2 and int_FunId in(" + LoginInfo.FunIdList + ")";
            DataTable dt = db.ExecuteQuery(sql).Tables[0];
            tv.Nodes.Clear();
            TreeNode tnRoot;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tnRoot = new TreeNode();
                tnRoot.Text = "&nbsp;"+dt.Rows[i]["vc_Name"].ToString ();
                tnRoot.Value = "-1";
                tnRoot.Target = "mainFrame";
                tnRoot.NavigateUrl = dt.Rows[i]["vc_Value"].ToString();
                tnRoot.ImageUrl = "images/menu_6.jpg";
                tnRoot.SelectAction = TreeNodeSelectAction.Expand;
                tv.Nodes.Add(tnRoot);
                switch (dt.Rows[i]["vc_Value"].ToString())
                {
                    case "dataconfig_list.aspx":
                        {
                            InitDataConfigForDrop(db, tnRoot);
                            break;
                        }
                    case "tableinfo_list.aspx":
                        {
                            sql = "select int_TbId,vc_TableDesc,int_ParentId from tb_TableInfo";
                            dt2 = db.ExecuteQuery(sql).Tables[0];
                            InitTableTree(dt2, tnRoot);
                            break;
                        }
                    case "funinfo_list.aspx":
                        {
                            sql = "select int_FunId,vc_Name,int_ParentId,int_Type from tb_FunInfo where int_Type<>3 order by int_ParentId,int_Order";
                            dt2 = db.ExecuteQuery(sql).Tables[0];
                            InitFunTree(dt2, tnRoot);
                            if (Request["expand"] == "fun")
                            {
                                tnRoot.ExpandAll();
                            }
                            break;
                        }
                }
            }
            //tnRoot= new TreeNode();
            //tnRoot.Text = "&nbsp;角色";
            //tnRoot.Value = "-1";
            //tnRoot.Target = "mainFrame";
            //tnRoot.NavigateUrl = "roleinfo_list.aspx";
            //tnRoot.ImageUrl = "images/menu_6.jpg";
            //tv.Nodes.Add(tnRoot);

            //tnRoot = new TreeNode();
            //tnRoot.Text = "&nbsp;用户";
            //tnRoot.Value = "-1";
            //tnRoot.Target = "mainFrame";
            //tnRoot.NavigateUrl = "userinfo_list.aspx";
            //tnRoot.ImageUrl = "images/menu_6.jpg";
            //tnRoot.SelectAction = TreeNodeSelectAction.Expand;
            //tv.Nodes.Add(tnRoot);

            //tnRoot = new TreeNode();
            //tnRoot.Text = "&nbsp;房产项目";
            //tnRoot.Value = "-1";
            //tnRoot.Target = "mainFrame";
            //tnRoot.NavigateUrl = "iteminfo_list.aspx";
            //tnRoot.ImageUrl = "images/menu_6.jpg";
            //tnRoot.SelectAction = TreeNodeSelectAction.Expand;
            //tv.Nodes.Add(tnRoot);

            //tnRoot = new TreeNode();
            //tnRoot.Text = "&nbsp;团房报名";
            //tnRoot.Value = "-1";
            //tnRoot.Target = "mainFrame";
            //tnRoot.NavigateUrl = "reginfo_list.aspx";
            //tnRoot.ImageUrl = "images/menu_6.jpg";
            //tnRoot.SelectAction = TreeNodeSelectAction.Expand;
            //tv.Nodes.Add(tnRoot);

            //tnRoot = new TreeNode();
            //tnRoot.Text = "&nbsp;客户管理";
            //tnRoot.Value = "-1";
            //tnRoot.Target = "mainFrame";
            //tnRoot.NavigateUrl = "customer_list.aspx";
            //tnRoot.ImageUrl = "images/menu_6.jpg";
            //tnRoot.SelectAction = TreeNodeSelectAction.Expand;
            //tv.Nodes.Add(tnRoot);

            //tnRoot = new TreeNode();
            //tnRoot.Text = "&nbsp;广告管理";
            //tnRoot.Value = "-1";
            //tnRoot.Target = "mainFrame";
            //tnRoot.NavigateUrl = "adinfo_list.aspx";
            //tnRoot.ImageUrl = "images/menu_6.jpg";
            //tnRoot.SelectAction = TreeNodeSelectAction.Expand;
            //tv.Nodes.Add(tnRoot);

            //tnRoot = new TreeNode();
            //tnRoot.Text = "&nbsp;数据规范";
            //tnRoot.Value = "-1";
            //tnRoot.Target = "mainFrame";
            //tnRoot.NavigateUrl = "dataconfig_list.aspx";
            //tnRoot.ImageUrl = "images/menu_6.jpg";
            //tnRoot.SelectAction = TreeNodeSelectAction.Expand;
            //tv.Nodes.Add(tnRoot);
            //InitDataConfigForDrop(db, tnRoot);

            //if (Request["expand"] == "dconfig")
            //{
            //    tnRoot.ExpandAll();
            //}
            //tnRoot = new TreeNode();
            //tnRoot.Text = "&nbsp;数据库表";
            //tnRoot.Value = "-1";
            //tnRoot.Target = "mainFrame";
            //tnRoot.NavigateUrl = "tableinfo_list.aspx";
            //tnRoot.ImageUrl = "images/menu_6.jpg";
            //tnRoot.SelectAction = TreeNodeSelectAction.Expand;
            //tv.Nodes.Add(tnRoot);

            //sql = "select int_TbId,vc_TableDesc,int_ParentId from tb_TableInfo";
            //dt2 = db.ExecuteQuery(sql).Tables[0];
            //InitTableTree(dt2, tnRoot);
            //tnRoot = new TreeNode();
            //tnRoot.Text = "&nbsp;日志";
            //tnRoot.Value = "-1";
            //tnRoot.Target = "mainFrame";
            //tnRoot.NavigateUrl = "loginfo_list.aspx";
            //tnRoot.ImageUrl = "images/menu_6.jpg";
            //tv.Nodes.Add(tnRoot);

            //tnRoot = new TreeNode();
            //tnRoot.Text = "&nbsp;权限";
            //tnRoot.Value = "-1";
            //tnRoot.Target = "mainFrame";
            //tnRoot.NavigateUrl = "funinfo_list.aspx";
            //tnRoot.ImageUrl = "images/menu_6.jpg";
            //tnRoot.SelectAction = TreeNodeSelectAction.Expand;
            //tv.Nodes.Add(tnRoot);
            //sql = "select int_FunId,vc_Name,int_ParentId,int_Type from tb_FunInfo where int_Type<>3 order by int_ParentId,int_Order";
            //dt2 = db.ExecuteQuery(sql).Tables[0];
            //InitFunTree(dt2, tnRoot);
            //if (Request["expand"] == "fun")
            //{
            //    tnRoot.ExpandAll();
            //}

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
    private void InitTableTree(DataTable dt, TreeNode tnCurrent)
    {
        DataRow[] dr = dt.Select(" int_parentid=" + tnCurrent.Value);
        for (int i = 0; i < dr.Length; i++)
        {
            TreeNode tNode = new TreeNode();
            tNode.Text = "&nbsp;" + dr[i][1].ToString();
            tNode.Value = dr[i][0].ToString();
            tNode.ImageUrl = "images/menu_6.jpg";
            tNode.Target = "mainFrame";
            tNode.NavigateUrl = "TableInfo_List.aspx?tbid=" + dr[i][0].ToString();
            tNode.SelectAction = TreeNodeSelectAction.Expand;
            tnCurrent.ChildNodes.Add(tNode);
            InitTableTree(dt, tNode);
        }
    }
    /// <summary>
    /// 初始化数据规范下拉选择
    /// </summary>
    /// <param name="db"></param>
    /// <param name="tnCurrent"></param>
    private void InitDataConfigForDrop(DsConnectionDB db, TreeNode tnCurrent)
    {
        string sql = "select int_DId,vc_Name,int_ParentId from tb_DataConfigInfo where int_ParentId=-1 and int_Type=1";
        DataTable dt = db.ExecuteQuery(sql).Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            TreeNode tNode = new TreeNode();
            tNode.Text = "&nbsp;"+dt.Rows[i]["vc_Name"].ToString ();
            tNode.Value = dt.Rows[i]["int_Did"].ToString();
            tNode.ImageUrl = "images/menu_6.jpg";
            tNode.Target = "mainFrame";
            tNode.NavigateUrl = "DataConfig_List.aspx?dtype="+tnCurrent.Value +"&parentid=" + dt.Rows[i]["int_DId"].ToString();
            tNode.SelectAction = TreeNodeSelectAction.Expand;
            tnCurrent.ChildNodes.Add(tNode);
        }
    }
    /// <summary>
    /// 权限树
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="tnCurrent"></param>
    private void InitFunTree(DataTable dt, TreeNode tnCurrent)
    {
        DataRow[] dr = dt.Select(" int_parentid=" + tnCurrent.Value);
        for (int i = 0; i < dr.Length; i++)
        {
            TreeNode tNode = new TreeNode();
            tNode.Text = "&nbsp;" + dr[i][1].ToString();
            tNode.Value = dr[i][0].ToString();
            tNode.ImageUrl = "images/menu_6.jpg";
            tNode.Target = "mainFrame";
            tNode.NavigateUrl = "Funinfo_list.aspx?parentid=" + dr[i][0].ToString();
            tNode.SelectAction = TreeNodeSelectAction.Expand;
            tnCurrent.ChildNodes.Add(tNode);
            InitFunTree(dt, tNode);
        }
    }
}