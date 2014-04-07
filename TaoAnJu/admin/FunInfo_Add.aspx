<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FunInfo_Add.aspx.cs" Inherits="admin_FunInfo_Add" %>
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
                <tr><td align="right" style="width: 70px">编号：</td><td>
                    <asp:TextBox ID="txt_FunId" runat="server" Enabled="False" BackColor="#EEEEEE"></asp:TextBox>注：自动生成
                    </td></tr>
               
                <tr><td align="right" style="width: 70px">名称：</td>
                <td>   
                    
                        <asp:TextBox ID="txt_Name" runat="server" MaxLength="50"></asp:TextBox><font color="red"><asp:Literal ID="lit_Msg" runat="server"></asp:Literal></font> 
                 </td></tr>
               <tr><td align="right" style="width: 70px">值：</td>
                <td><asp:TextBox ID="txt_Value" runat="server" MaxLength="500" Width="300px"></asp:TextBox></td></tr>
                <tr><td align="right" style="width: 70px">参数：</td>
                <td><asp:TextBox ID="txt_Parameter" runat="server" MaxLength="50"></asp:TextBox></td></tr>
                 <tr><td align="right" style="width: 70px">上级权限：</td><td>
                    <uc1:SelectTree ID="SelectTree1" runat="server" TextReadOnly="True" 
                         TextEnabled="False" SelectedType="1" />
                    </td></tr>
                <tr><td align="right" style="width: 70px">类型：</td><td align="left">
                    <asp:DropDownList ID="ddlType" runat="server">
                        <asp:ListItem>菜单名称</asp:ListItem>
                        <asp:ListItem>页面地址</asp:ListItem>
                        <asp:ListItem>操作权限</asp:ListItem>
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
