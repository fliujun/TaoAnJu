<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserRole.aspx.cs" Inherits="admin_UserRole" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="css/style.css" type="text/css" media="screen" />
    <link rel="stylesheet" type="text/css" href="css/jquery_dialog.css" />
    <script type="text/javascript" src="js/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="js/jquery_dialog.js"></script>
</head>
<body style="margin: 0px">
    <form id="UserRoleForm" runat="server" action="UserRole.aspx?action=submit" method="post">
    <div class="content-box role">
	    <div class="content-box-content">
		<div class="tab-content default-tab">
		    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                BorderStyle="None">
                <Columns>
                     <asp:BoundField DataField="int_RoleId" HeaderText="角色编号" >
                         <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" Wrap="True" />
                         <HeaderStyle HorizontalAlign="center" VerticalAlign="Middle" Width="60px" Wrap="False" />
                     </asp:BoundField>
                     <asp:BoundField DataField="vc_RoleName" HeaderText="角色名称" >
                         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                         <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                     </asp:BoundField>
                     <asp:TemplateField HeaderText="选择">
                        <ItemTemplate>
                             <asp:CheckBox ID="chkItem" runat="server" Width="20px" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                     </asp:TemplateField>
                </Columns>
                <HeaderStyle Height="22px" BackColor="#E6F4FF" />
            </asp:GridView>
		</div>
        </div>
    </div><asp:TextBox ID="txt_UserId" runat="server" BorderStyle="None" Height="0px" Width="0px" BorderWidth="0px"></asp:TextBox>
    <asp:Literal ID="lit_Script" runat="server"></asp:Literal>
    <script language="javascript" type="text/javascript">
        function Ok() {
            document.getElementById("UserRoleForm").submit();
        }
    </script>
    </form>
</body>
</html>
