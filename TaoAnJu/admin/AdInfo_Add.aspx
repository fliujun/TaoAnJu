<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdInfo_Add.aspx.cs" Inherits="admin_AdInfo_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
        .style3
        {
            width: 90px;
            height: 29px;
        }
        .style4
        {
            height: 29px;
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
                <tr><td align="right" style="width: 90px">广告编号：</td><td>
                    <asp:TextBox ID="txt_AId" runat="server" Enabled="False" BackColor="#EEEEEE" 
                        Width="300px"></asp:TextBox>注：自动生成
                    </td></tr>
               
                <tr><td align="right" style="width: 90px">广告标题：</td>
                <td>   
                       <asp:TextBox ID="txt_AdTitle" runat="server" MaxLength="50" Width="300px"></asp:TextBox> 
                 </td></tr>
               
                <tr><td align="right" style="width: 90px">广告描述：</td>
                <td><asp:TextBox ID="txt_AdDesc" runat="server" MaxLength="100" Width="296px" 
                        Height="80px" TextMode="MultiLine"></asp:TextBox> 
                 </td></tr>
               
                <tr><td align="right" style="width: 90px">广告链接：</td>
                <td>   
                        <asp:TextBox ID="txt_AdLink" runat="server" MaxLength="300" Width="296px" 
                            Height="80px" TextMode="MultiLine"></asp:TextBox> 
                 </td></tr>
                 <tr><td align="right" class="style3">广告图片：</td><td align="left" class="style4">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:Literal ID="lit_Pic" runat="server"></asp:Literal>
                    </td></tr>
                 <tr><td align="right" class="style1">广告类型：</td>
                <td class="style2">   
                        <asp:DropDownList ID="ddl_AdType" runat="server" Width="302px">
                        </asp:DropDownList>
                 </td></tr>
                 <tr><td align="right" class="style1">显示顺序：</td>
                <td class="style2">   
                       <asp:TextBox ID="txt_Order" runat="server" MaxLength="50" Width="300px">0</asp:TextBox> 
                 </td></tr>
                <tr><td align="right" style="width: 90px">状态：</td><td align="left">
                    <asp:DropDownList ID="ddl_Status" runat="server" Width="302px">
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
