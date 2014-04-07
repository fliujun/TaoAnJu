<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogInfo_List.aspx.cs" Inherits="admin_LogInfo_List" %>
<%@ Register src="../inc/PageNumBar.ascx" tagname="PageNumBar" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="css/style.css" type="text/css" media="screen" />
    <link rel="stylesheet" type="text/css" href="css/jquery_dialog.css" />
    <script type="text/javascript" src="js/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="js/jquery_dialog.js"></script>
    <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
</head>
<body style="margin: 0px">
    <form id="form1" runat="server">
    <div id="maintitle"><div id="mainico"></div><div id="maintip"><strong>位置：</strong>日志</div>
        <div>
        <asp:LinkButton ID="btnSearch" runat="server" CssClass="linkbutton" 
            CausesValidation="False" onclick="btnSearch_Click" Height="18px">查询</asp:LinkButton>
        </div>
    </div>
    <div class="content-box" id="BodyDiv">
	    <div class="content-box-content">
		<div class="searchgrid">
            <table width ="100%">
                <tr><td style="width: 40px" align="right">类型：</td><td style="width: 70px">
                    <asp:DropDownList ID="ddlLogType" runat="server">
                        <asp:ListItem>全部</asp:ListItem>
                        <asp:ListItem>添加</asp:ListItem>
                        <asp:ListItem>修改</asp:ListItem>
                        <asp:ListItem>删除</asp:ListItem>
                        <asp:ListItem>审批</asp:ListItem>
                        <asp:ListItem>登录</asp:ListItem>
                        <asp:ListItem>退出</asp:ListItem>
                    </asp:DropDownList>
                    </td><td style="width: 65px" align="right">开始日期：</td><td style="width: 105px">
                    <asp:TextBox ID="txt_StartDate" runat="server" Width="100px" CssClass="Wdate" onFocus="WdatePicker()"></asp:TextBox>
                    </td><td style="width: 65px" align="right">结束日期：</td><td style="width: 105px">
                    <asp:TextBox ID="txt_EndDate" runat="server" Width="100px" CssClass="Wdate" onFocus="WdatePicker()"></asp:TextBox>
                    </td><td style="width: 40px" align="right">内容：</td><td>
                    <asp:TextBox ID="txt_Content" runat="server"></asp:TextBox>
                    </td><td></td></tr>
            </table>
		</div>
        <div style="height: 5px">&nbsp;</div>
		<div class="tab-content default-tab" 
                style="border: 0px solid #E1E1E1; background-color: #FFFFFF">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" onrowdatabound="GridView1_RowDataBound" >
                <Columns>
                     <asp:BoundField DataField="" HeaderText="序号" >
                         <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" Wrap="True" />
                         <HeaderStyle HorizontalAlign="center" VerticalAlign="Middle" Width="65px" Wrap="False" />
                     </asp:BoundField>
                     <asp:BoundField DataField="vc_LogType" HeaderText="类型" >
                         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                         <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" Width="80px"/>
                     </asp:BoundField>
                     <asp:BoundField DataField="vc_Content" HeaderText="内容" >
                         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                         <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                     </asp:BoundField>
                     <asp:BoundField DataField="vc_Ip" HeaderText="操作IP" >
                         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True" />
                         <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" Width="110px" />
                     </asp:BoundField>
                     <asp:BoundField DataField="dt_CreateDate" HeaderText="操作时间" >
                         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True" />
                         <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" Width="130px" />
                     </asp:BoundField>
                </Columns>
                <HeaderStyle Height="22px" BackColor="#E6F4FF" />
            </asp:GridView>
            <div >
				<uc1:PageNumBar ID="PageNumBar1" runat="server" />				
			</div>
		</div>
        </div>
    </div>
    <asp:Literal ID="lit_Script" runat="server"></asp:Literal>
    </form>
</body>
</html>

