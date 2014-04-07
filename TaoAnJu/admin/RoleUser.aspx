<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleUser.aspx.cs" Inherits="admin_RoleUser" %>

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
    <form id="form1" runat="server">
    <div class="content-box role">
	    <div class="content-box-content">
		<div class="tab-content default-tab">
            <asp:Literal ID="lit_Msg" runat="server"></asp:Literal>
		    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                BorderStyle="None">
                <Columns>
                     <asp:BoundField DataField="int_UserId" HeaderText="用户编号" >
                         <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" Wrap="True" />
                         <HeaderStyle HorizontalAlign="center" VerticalAlign="Middle" Width="65px" Wrap="False" />
                     </asp:BoundField>
                     <asp:BoundField DataField="vc_RealName" HeaderText="用户姓名" >
                         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                         <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False"  />
                     </asp:BoundField>
                </Columns>
                <HeaderStyle Height="22px" BackColor="#E6F4FF" />
            </asp:GridView>
            <div>
			</div>
		</div>
        </div>
    </div>
    <script language="javascript" type="text/javascript">
        function Ok() {
            JqueryDialog.Close();
        }
    </script>
    <asp:Literal ID="lit_Script" runat="server"></asp:Literal>
    </form>
</body>
</html>
