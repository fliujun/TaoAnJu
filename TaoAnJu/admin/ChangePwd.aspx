<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePwd.aspx.cs" Inherits="admin_ChangePwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="css/style.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="css/jquery_dialog.css" type="text/css" media="screen" />
    <script type="text/javascript" src="js/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="js/jquery_dialog.js"></script>
</head>
<body style="margin: 0px">
    <form id="changepwdform" runat="server" action="ChangePwd.aspx?action=submit">
    <div class="content-box" id="BodyDiv">
	    <div class="content-box-content">
			<table cellspacing="0" cellpadding="0" border="0">
                <tr><td height="25" colspan="2" align="center" style="color: #FF0000"><asp:Literal ID="lit_Msg" runat="server"></asp:Literal></td></tr>
				<tr>
				<td height="25" align="right" style="width: 80px">旧密码：</td>
				<td height="25" align="left" style="width: 180px">
					<asp:TextBox ID="txt_oldpwd" runat="server" TextMode="Password" CssClass="text" MaxLength="16"></asp:TextBox><font color="red">*</font>
				</td></tr>
				<tr>
				<td height="25" style="width: 80px" align="right">新密码：</td>
				<td height="25" align="left"><asp:TextBox ID="txt_newpwd" runat="server" TextMode="Password" CssClass="text" MaxLength="16"></asp:TextBox><font color="red">*</font>
				</td></tr>
				<tr>
				<td height="25" style="width: 80px" align="right">确认密码：</td>
				<td height="25" align="left"><asp:TextBox ID="txt_validepwd" runat="server" TextMode="Password" CssClass="text" MaxLength="16"></asp:TextBox><font color="red">*</font>
				</td></tr>
				<tr>
				<td height="25" align="center" colspan="2" style="color: #FF0000">为了系统安全，密码长度必须八位以上，至少要包含字母和数字，尽量包含大小写字母和数字组合</td></tr>
			</table>
          </div>
	</div>
    <asp:Literal ID="lit_Script" runat="server"></asp:Literal>
    <script language="javascript" type="text/javascript">
        function Ok() {
            document.getElementById("changepwdform").submit();
        }
    </script>
    </form>
    
</body>
</html>
