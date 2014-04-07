<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SelectTree.ascx.cs" Inherits="admin_SelectTree" %>
<script language="javascript" type="text/JavaScript">
function <%=CClientId%>_SelectTree() 
{
	var url = "Tree.aspx?ctype="+document.getElementById("<%=CClientId%>_txtType").value+"&cid="+document.getElementById("<%=CClientId%>_txtValue").value+"&cname="+"<%=CClientId%>_txtText&cvalue="+"<%=CClientId%>_txtValue";
	showx = event.screenX - event.offsetX +40; // + deltaX;
	showy = event.screenY - event.offsetY-5; // + deltaY;
	var w   = 300;
	var h   = 450; 
    var xMax=screen.width;
    var yMax=screen.height;
    if (w>xMax) w = xMax * .9;
    if (h>yMax) h = yMax * .9;
    var l = (xMax - w)/2, t = (yMax-h)/2;
    handle_PUH = window.open (url,"Tree","screenX="+l+",left="+l+",screenY="+t+",top="+t+",directories=no,toolbar=no,menubar=no,resizable=no,location=no,status=no,scrollbars=yes,width="+w+",height="+h);
}
</script>
<asp:textbox id="txtText" runat="server" Enabled="False"></asp:textbox><input id="<%=CClientId%>_btnSelect" style="CURSOR: hand; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; background-color: transparent;"  onclick="<%=CClientId%>_SelectTree();" type="button" value="选择" name="<%=CClientId%>_btnSelect" class="button" />
<script language="javascript" type="text/JavaScript">document.getElementById("<%=CClientId%>_btnSelect").disabled=<%=btnDisabled%>;</script>
<asp:TextBox ID="txtValue" runat="server" BorderStyle="None" Height="0px" Width="0px" BorderWidth="0px"></asp:TextBox>
<asp:TextBox ID="txtType" runat="server" BorderStyle="None" Height="0px" Width="0px" BorderWidth="0px"></asp:TextBox>