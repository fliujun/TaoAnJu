<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegInfo_List.aspx.cs" Inherits="admin_RegInfo_List" %>
<%@ Register src="../inc/PageNumBar.ascx" tagname="PageNumBar" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="css/style.css" type="text/css" media="screen" />
    <link rel="stylesheet" type="text/css" href="css/jquery_dialog.css" />
    <script type="text/javascript" src="js/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="js/jquery_dialog.js"></script>
</head>
<body >
    <form id="form1" runat="server">
    <div id="maintitle"><div id="mainico"></div><div id="maintip"><strong>位置：</strong>团房报名</div>
        <div>
            <asp:LinkButton ID="btnSearch" runat="server" CssClass="linkbutton"  
                Height="18px" onclick="btnSearch_Click">查询</asp:LinkButton>
        </div></div>
    <div class="content-box role">
	    <div class="content-box-content">
        <div class="searchgrid">
            <table width ="100%">
                <tr><td style="width: 70px" align="right">项目名称：</td><td style="width: 250px">
                    <asp:TextBox ID="txt_ItemName" runat="server" Width="240px"></asp:TextBox>
                    </td><td></td></tr>
            </table>
		</div>
        <div style="height: 5px">&nbsp;</div>
		<div class="tab-content default-tab">
		    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                BorderStyle="None">
                <Columns>
                     <asp:BoundField DataField="vc_ItemName" HeaderText="项目名称" >
                         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                         <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                     </asp:BoundField>
                     <asp:BoundField DataField="vc_Name" HeaderText="报名人" >
                         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                         <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" Width="100px"/>
                     </asp:BoundField>
                     <asp:BoundField DataField="vc_Mobile" HeaderText="手机号" >
                         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                         <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" Width="150px"/>
                     </asp:BoundField>
                     <asp:BoundField DataField="dt_CreateDate" HeaderText="创建时间">
                         <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="130px" Wrap="False" />
                         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                     </asp:BoundField>
                </Columns>
                <HeaderStyle Height="22px" BackColor="#E6F4FF" />
            </asp:GridView>
            <div>
				<uc1:PageNumBar ID="PageNumBar1" runat="server" />				
			</div>
		</div>
        </div>
    </div>

    <asp:Literal ID="lit_Script" runat="server"></asp:Literal>

    </form>
</body>
</html>