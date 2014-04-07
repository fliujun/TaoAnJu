<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Tree.aspx.cs" Inherits="admin_Tree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%=TreeTitle%></title>
    <style type="text/css">
    .button{
            font-family: Verdana, Arial, sans-serif;
            display: inline-block;
            background:url('images/button.jpg') top left repeat-x    !important;
            border: 1px solid #67A3D3 !important;
            padding: 4px 10px 4px 10px;
            _padding: 4px 10px 4px 10px !important;
            color: #275c86 !important;
            font-size: 12px !important;
            cursor: pointer;
            }
    </style>
</head>
<body style="margin: 0px">
    <form id="form1" runat="server">
    <div class="content-box role">
	    <div class="content-box-content">
            <table cellpadding="0" cellspacing="0" border="0" width ="100%" 
                style="border: 1px solid #D8D8D8">
				<tr style="height: 35px">
                    <td align ="right" valign="middle">
                        <asp:Button ID="btnClear" runat="server" CssClass="button" 
                            onclick="btnClear_Click" Text=" 清 空 " />
                        &nbsp;</td>
					<td align ="left" valign="middle">&nbsp;
                        <input id="btnCancel" class="button" type="button" value=" 关 闭 " 
                            onclick="javascript:window.close();" /></td>
				</tr>
			</table>
			<div>
        <asp:TreeView ID="tv" runat="server" Font-Size="Small" 
            ForeColor="Black" ShowLines="True" SkipLinkText="">
            <LeafNodeStyle BorderStyle="None" />
        </asp:TreeView>
    
                </div>
        </div>
    </div>
    <asp:TextBox id="txtName" runat="server" Width="0px" Visible="False" BorderStyle="None"></asp:TextBox>
	<asp:TextBox id="txtValue" runat="server" Width="0px" Visible="False" BorderStyle="None"></asp:TextBox>
    <asp:TextBox id="txtId" runat="server" Width="0px" Visible="False" BorderStyle="None"></asp:TextBox>
    <asp:TextBox id="txtType" runat="server" Width="0px" Visible="False" BorderStyle="None"></asp:TextBox>
    <asp:Literal ID="lit_Script" runat="server"></asp:Literal>
    </form>
</body>
</html>
