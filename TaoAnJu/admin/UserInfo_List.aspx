<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserInfo_List.aspx.cs" Inherits="admin_UserInfo_List" %>
<%@ Register src="../inc/PageNumBar.ascx" tagname="PageNumBar" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="css/style.css" type="text/css" media="screen" />
    <link rel="stylesheet" type="text/css" href="css/jquery_dialog.css" />
    <script type="text/javascript" src="js/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="js/jquery_dialog.js"></script>
    <script language="javascript" type="text/javascript">
        function SelectAll(chkVal, idVal) {
            var thisfrm = document.forms[0];
            var ids = "";
            // 查找Forms里面所有的元素
            for (i = 0; i < thisfrm.length; i++) {
                // 查找模板头中的CheckBox
                if (idVal.indexOf('chkAll') != -1) {
                    if (chkVal == true) {
                        thisfrm.elements[i].checked = true;
                    }
                    else {
                        thisfrm.elements[i].checked = false;
                    }
                } // if
                // 如果除题头以外的项没有全選上则取消题头的選擇
                else if (idVal.indexOf('chkItem') != -1) {
                    if (thisfrm.elements[i].checked == false) {
                        thisfrm.elements[1].checked = false;
                    }
                }
            }
        }
	</script>
</head>
<body >
    <form id="form1" runat="server">
    <div id="maintitle"><div id="mainico"></div><div id="maintip"><strong>位置：</strong>用户</div>
        <div>
        <asp:LinkButton ID="btnAdd" runat="server" CssClass="linkbutton" 
            CausesValidation="False" Height="18px" EnableViewState="False" 
                onclick="btnAdd_Click">添加</asp:LinkButton>&nbsp;
        <asp:LinkButton ID="btnEdit" runat="server" CssClass="linkbutton" 
            onclick="btnEdit_Click" Height="18px">修改</asp:LinkButton>&nbsp;
        <asp:LinkButton ID="btnDelete" runat="server" CssClass="linkbutton" 
            onclick="btnDelete_Click" Height="18px">删除</asp:LinkButton>
        </div></div>
    <div class="content-box role">
	    <div class="content-box-content">
		<div class="tab-content default-tab">
		    <asp:GridView ID="GridView1" runat="server" 
                onrowdatabound="GridView1_RowDataBound" AutoGenerateColumns="False" 
                BorderStyle="None">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkAll" runat="server" Width="20px" />
                        </HeaderTemplate>
                        <ItemTemplate>
                             <asp:CheckBox ID="chkItem" runat="server" Width="20px" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20px" />
                     </asp:TemplateField>
                     <asp:BoundField DataField="int_UserId" HeaderText="用户编号" >
                         <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" Wrap="True" />
                         <HeaderStyle HorizontalAlign="center" VerticalAlign="Middle" Width="60px" Wrap="False" />
                     </asp:BoundField>
                     <asp:BoundField DataField="vc_LoginName" HeaderText="登录账号" >
                         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                         <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                     </asp:BoundField>
                     <asp:BoundField DataField="vc_RealName" HeaderText="姓名" >
                         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                         <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                     </asp:BoundField>
                     <asp:BoundField DataField="int_UserType" HeaderText="用户类型" >
                         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                         <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" Width="80px"/>
                     </asp:BoundField>
                     <asp:BoundField DataField="vc_LastLoginIp" HeaderText="最后登录IP地址" >
                         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True" />
                         <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" Width="110px" />
                     </asp:BoundField>
                     <asp:BoundField DataField="dt_LastLoginTime" HeaderText="最后登录时间" >
                         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True" />
                         <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" Width="120px" />
                     </asp:BoundField>
                     <asp:BoundField DataField="dt_CreateDate" HeaderText="创建时间">
                         <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="120px" Wrap="False" />
                         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                     </asp:BoundField>
                     <asp:BoundField DataField="int_Status" HeaderText="状态">
                         <HeaderStyle HorizontalAlign="center" VerticalAlign="Middle" Width="40px" Wrap="False" />
                         <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
                     </asp:BoundField>
                     <asp:BoundField DataField="" HeaderText="用户角色">
                         <HeaderStyle HorizontalAlign="center" VerticalAlign="Middle" Width="60px" Wrap="False" />
                         <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
                     </asp:BoundField>
                </Columns>
                <HeaderStyle Height="22px" BackColor="#E6F4FF" />
            </asp:GridView>
            <div>
				<uc1:PageNumBar ID="PageNumBar1" runat="server" />				
			</div>
		</div>
        </div>
    </div>

    <asp:Literal ID="lit_Script" runat="server"></asp:Literal>

    </form>
</body>
</html>