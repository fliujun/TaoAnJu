﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Customer_Add.aspx.cs" Inherits="admin_Customer_Add" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="css/style.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="css/jquery_dialog.css" type="text/css" media="screen" />
    <script type="text/javascript" src="js/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="js/jquery_dialog.js"></script>
    <style type="text/css">
        .style1
        {
            width: 90px;
            height: 22px;
        }
        .style2
        {
            height: 22px;
        }
    </style>
</head>
<body style="margin: 0px">
    <form id="form1" runat="server">
    <div class="content-box" id="BodyDiv">
	    <div class="content-box-content10">
			<table cellspacing="0" cellpadding="0" width="100%" border="0" style="background-color: #Ffffff; width: 100%;">
                <tr><td colspan="2" style="height: 20px"><font color="red">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Literal ID="lit_Msg" runat="server"></asp:Literal></font> 
                    </td></tr>
                <tr><td align="right" style="width: 90px">客户编号：</td><td>
                    <asp:TextBox ID="txt_CId" runat="server" Enabled="False" BackColor="#EEEEEE" 
                        Width="200px"></asp:TextBox>注：自动生成
                    </td></tr>
               
                <tr><td align="right" style="width: 90px">手机号：</td>
                <td>   
                       <asp:TextBox ID="txt_Mobile" runat="server" MaxLength="50" Width="200px"></asp:TextBox> 
                 </td></tr>
               
                <tr><td align="right" style="width: 90px">姓名：</td>
                <td><asp:TextBox ID="txt_Name" runat="server" MaxLength="20" Width="200px"></asp:TextBox> 
                 </td></tr>
               <tr><td align="right" style="width: 90px">年龄：</td><td align="left">
                    <asp:TextBox ID="txt_Age" runat="server" MaxLength="20" Width="200px"></asp:TextBox> 
                    </td></tr>
                <tr><td align="right" style="width: 90px">职业：</td>
                <td>   
                        <asp:TextBox ID="txt_Occupation" runat="server" MaxLength="20" Width="200px"></asp:TextBox> 
                 </td></tr>
                 <tr><td align="right" class="style1">工作地点：</td>
                <td class="style2">   
                        <asp:TextBox ID="txt_WorkingPlace" runat="server" MaxLength="80" Width="200px"></asp:TextBox> 
                 </td></tr>
                <tr><td align="right" style="width: 90px">居住地点：</td><td align="left">
                    <asp:TextBox ID="txt_LivePlace" runat="server" MaxLength="80" Width="200px"></asp:TextBox> 
                    </td></tr>
                
                <tr><td align="right" style="width: 90px">购房用途：</td><td align="left">
                    <asp:TextBox ID="txt_Use" runat="server" MaxLength="20" Width="200px"></asp:TextBox> 
                    </td></tr>
                
                <tr><td align="right" style="width: 90px">期望单价：</td><td align="left">
                    <asp:TextBox ID="txt_Price" runat="server" MaxLength="20" Width="200px"></asp:TextBox> 
                    </td></tr>
                
                <tr><td align="right" style="width: 90px">期望总价：</td><td align="left">
                    <asp:TextBox ID="txt_TotalPrice" runat="server" MaxLength="20" Width="200px"></asp:TextBox> 
                    </td></tr>
                
                <tr><td align="right" style="width: 90px">推荐人：</td><td align="left">
                    <asp:TextBox ID="txt_Referee" runat="server" MaxLength="20" Width="200px"></asp:TextBox> 
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
