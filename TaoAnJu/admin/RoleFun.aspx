<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleFun.aspx.cs" Inherits="admin_RoleFun" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="css/style.css" type="text/css" media="screen" />
    <link rel="stylesheet" type="text/css" href="css/jquery_dialog.css" />
    <script type="text/javascript" src="js/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="js/jquery_dialog.js"></script>
    <script type="text/javascript" src="js/TreeCheck.js"></script>
</head>
<body style="margin: 0px">
    <form id="RoleFunForm" runat="server"  action="RoleFun.aspx?action=submit" method="post">
    <div class="content-box role">
        <asp:TreeView ID="tv" runat="server" Font-Size="Small" 
            ForeColor="Black" ShowLines="True" SkipLinkText="" 
            ontreenodecheckchanged="tv_TreeNodeCheckChanged" ShowCheckBoxes="All">
            <LeafNodeStyle BorderStyle="None" />
        </asp:TreeView>
    </div>
    <asp:TextBox id="txt_RoleId" runat="server" Width="0px" Visible="False" BorderStyle="None"></asp:TextBox>
    <asp:TextBox id="txt_IsOk" runat="server" Width="0px" Visible="False" BorderStyle="None"></asp:TextBox>
    <asp:Literal ID="lit_Script" runat="server"></asp:Literal>
    <script language="javascript" type="text/javascript">
        function Ok() {
            document.getElementById("RoleFunForm").submit();
        }
    </script>
    </form>
</body>
</html>