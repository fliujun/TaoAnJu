<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Msg.aspx.cs" Inherits="admin_Msg" %>

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
    <form id="Msgform" runat="server">
    <div class="content-box" id="BodyDiv">
	    <div class="content-box-content20">
			<table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr><td width="36">
                    <img alt="" height="24" src="images/info_24.jpg" width="24" /></td><td align="left">
                    <b><asp:Literal ID="lit_Msg" runat="server"></asp:Literal></b>
                    </td></tr>
            </table>
        </div>
    </div>
    <asp:Panel ID="Panel1" runat="server">
        <table cellspacing="0" cellpadding="0" border="0" 
            style="background-color: #F7F9FA; width: 100%; height: 45px;">
            <tr><td align="center">
                <input id="btnOk" class="button" type="button" value="&nbsp;&nbsp;确 定&nbsp;&nbsp;" onclick="javascript:JqueryDialog.Close();"/></td></tr>
        </table>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Visible="False">
        <table cellspacing="0" cellpadding="0" border="0" 
            style="background-color: #F7F9FA; width: 100%; height: 45px;">
            <tr><td align="center">
                <asp:Button ID="btnSubmit" runat="server" CssClass="button" Text=" 确 定 " 
                    onclick="btnSubmit_Click" />&nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text=" 取 消 " 
                    onclick="btnCancel_Click" />
                </td></tr>
        </table>
        </asp:Panel>
    <script type ="text/javascript">
        document.getElementById("BodyDiv").style.height = document.documentElement.clientHeight - 45 + "px";
        window.onresize = function () {
            document.getElementById("BodyDiv").style.height = document.documentElement.clientHeight - 45 + "px";
        }
    </script>
    <asp:Literal ID="lit_Script" runat="server"></asp:Literal> 
    </form>
</body>
</html>
