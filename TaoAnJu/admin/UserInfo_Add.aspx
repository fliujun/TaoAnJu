<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserInfo_Add.aspx.cs" Inherits="admin_UserInfo_Add" %>
<%@ Register src="SelectTree.ascx" tagname="SelectTree" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="css/style.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="css/jquery_dialog.css" type="text/css" media="screen" />
    <script type="text/javascript" src="js/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="js/jquery_dialog.js"></script>
</head>
<body style="margin: 0px">
    <form id="form1" runat="server">
    <div class="content-box" id="BodyDiv">
	    <div class="content-box-content10">
			<table cellspacing="0" cellpadding="0" width="100%" border="0" style="background-color: #Ffffff; width: 100%;">
                <tr><td colspan="2" style="height: 20px"><font color="red">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Literal ID="lit_Msg" runat="server"></asp:Literal></font> 
                    </td></tr>
                <tr><td align="right" style="width: 90px">用户编号：</td><td>
                    <asp:TextBox ID="txt_UserId" runat="server" Enabled="False" BackColor="#EEEEEE"></asp:TextBox>注：自动生成
                    </td></tr>
               
                <tr><td align="right" style="width: 90px">登录账号：</td>
                <td>   
                       <asp:TextBox ID="txt_LoginName" runat="server" MaxLength="50"></asp:TextBox> 
                 </td></tr>
               
                <tr><td align="right" style="width: 90px">真实姓名：</td>
                <td><asp:TextBox ID="txt_RealName" runat="server" MaxLength="20"></asp:TextBox> 
                 </td></tr>
               <tr><td align="right" style="width: 90px">用户类型：</td><td align="left">
                    <asp:DropDownList ID="ddlUserType" runat="server">
                        <asp:ListItem>管理员</asp:ListItem>
                        <asp:ListItem Selected="True">销售代表</asp:ListItem>
                    </asp:DropDownList>
                    </td></tr>
                <tr><td align="right" style="width: 90px">登录密码：</td>
                <td>   
                        <asp:TextBox ID="txt_LoginPwd" runat="server" MaxLength="20" 
                            TextMode="Password"></asp:TextBox> 
                 </td></tr>
                 <tr><td align="right" style="width: 90px">密码二次验证：</td>
                <td>   
                        <asp:TextBox ID="txt_CheckPwd" runat="server" MaxLength="16" 
                            TextMode="Password"></asp:TextBox> 
                 </td></tr>
                <tr><td align="right" style="width: 90px">账号状态：</td><td align="left">
                    <asp:DropDownList ID="ddlStatus" runat="server" Enabled="False">
                        <asp:ListItem>停用</asp:ListItem>
                        <asp:ListItem Selected="True">正常</asp:ListItem>
                    </asp:DropDownList>
                    </td></tr>
                
            </table>
        </div>
    </div>
    <table cellspacing="0" cellpadding="0" border="0" 
            style="background-color: #F7F9FA; width: 100%; height: 45px;">
            <tr><td align="center">
                <asp:Button ID="btnSubmit" runat="server" CssClass="button" Text=" 确 定 " 
                    onclick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;<input id="btnCancel" class="button" type="button" value="&nbsp;&nbsp;取 消&nbsp;&nbsp;" onclick="javascript:JqueryDialog.Close();"/>
                </td></tr>
            </table>
            <asp:Literal ID="lit_Script" runat="server"></asp:Literal> 
    <script type ="text/javascript">
        document.getElementById("BodyDiv").style.height = document.documentElement.clientHeight - 45 + "px";
        window.onresize = function () {
            document.getElementById("BodyDiv").style.height = document.documentElement.clientHeight - 45 + "px";
        }
    </script>
    </form>
</body>
</html>
