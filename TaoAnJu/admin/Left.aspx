<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="admin_Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="margin-left:0px;margin-top:0px;">
    <form id="form1" runat="server">
    <div>
        <asp:TreeView ID="tv" runat="server" ExpandDepth="0" Font-Size="Small" 
            ForeColor="Black" ShowLines="True" SkipLinkText="" NodeIndent="16">
            <LeafNodeStyle BorderStyle="None" />
        </asp:TreeView>
    </div>
    </form>
</body>
</html>
