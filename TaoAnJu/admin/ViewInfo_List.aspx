<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewInfo_List.aspx.cs" Inherits="admin_ViewInfo_List" %>
<%@ Register src="../inc/PageNumBar.ascx" tagname="PageNumBar" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
<link rel="stylesheet" href="css/style.css" type="text/css" media="screen" />
    <link rel="stylesheet" type="text/css" href="css/jquery_dialog.css" />
    <script type="text/javascript" src="js/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="js/jquery_dialog.js"></script>
    <script type="text/javascript">
        function del_sure() {
            return confirm("你确定要删除吗?");
        } 
    </script>
</head>
<body">
    <form id="form1" runat="server">
    <div class="content-box role">
	    <div class="content-box-content">
		<div class="tab-content default-tab">
            <table width ="100%">
                <tr><td style="width: 70px" align="right">项目名称：</td><td colspan="5">
                    <asp:Literal ID="lit_ItemName" runat="server"></asp:Literal>
                    <font color="red">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Literal ID="lit_Msg" runat="server"></asp:Literal></font>
                    </td></tr>
                    <tr><td style="width: 70px" align="right">视频编号：</td><td style="width: 70px">
                        <asp:TextBox ID="txt_VId" runat="server" BorderStyle="None" Width="70px" Enabled="False" BackColor="#EEEEEE"></asp:TextBox></td><td style="width: 70px" align="right">视频描述：</td>
                        <td>
                    <asp:TextBox ID="txt_ViewDesc" runat="server" Width="100%" MaxLength="30"></asp:TextBox>
                    </td><td align="center" style="width: 120px">
                            <asp:LinkButton ID="btnUpLoad" runat="server" CssClass="button" 
                                onclick="btnUpLoad_Click" Width="50px"> 提交 </asp:LinkButton>
                        </td><td style="width:60px">
                            <input id="btnClose" type="button" value=" 关闭 " class="button" 
                                style="height: 24px" onclick="javascript:JqueryDialog.Close();"/></td></tr>
                    <tr><td style="width: 70px" align="right">
                            视频地址：</td>
                        <td colspan="3">
                    <asp:TextBox ID="txt_ViewFile" runat="server" Width="100%" MaxLength="200"></asp:TextBox>
                        </td><td></td><td></td></tr>
            </table>
            <div style="height: 5px">&nbsp;</div>
            <asp:GridView ID="GridView1" runat="server" 
                onrowdatabound="GridView1_RowDataBound" AutoGenerateColumns="False" 
                BorderStyle="None" 
                onrowdeleting="GridView1_RowDeleting" Visible="False">
                <Columns>
                     <asp:BoundField DataField="int_VId" HeaderText="视频编号" >
                         <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" Wrap="True" />
                         <HeaderStyle HorizontalAlign="center" VerticalAlign="Middle" Width="60px" Wrap="False" />
                     </asp:BoundField>
                     <asp:BoundField DataField="vc_ViewDesc" HeaderText="视频描述" >
                         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                         <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                     </asp:BoundField>
                     <asp:BoundField DataField="vc_ViewFile" HeaderText="视频文件" >
                         <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                         <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" 
                         Width="80px" />
                     </asp:BoundField>
                     <asp:BoundField DataField="dt_CreateDate" HeaderText="创建时间">
                         <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="120px" Wrap="False" />
                         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                     </asp:BoundField>
                     <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnDel" runat="server"  CommandName="Delete" ForeColor="Red">删除</asp:LinkButton>
                            </ItemTemplate>
                         <HeaderStyle Width="70px" />
                         <ItemStyle HorizontalAlign="Center" />
                     </asp:TemplateField>
                </Columns>
                <HeaderStyle Height="22px" BackColor="#E6F4FF" />
            </asp:GridView>
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" CellSpacing="10" 
                    onitemcommand="DataList1_ItemCommand" DataKeyField="int_Vid" 
                    BorderWidth="0" onitemdatabound="DataList1_ItemDataBound">
                    <ItemTemplate>
                        <table style="border-width: 0px; width:300px; height:200px">
                            <tr><td colspan="2"><embed src="<%#Eval("vc_ViewFile")%>" type="application/x-shockwave-flash" allowscriptaccess="always" allowfullscreen="true" autostart="true" loop="true" wmode="opaque" width="300px" height="200px"></embed>
                                </td>
                            </tr>
                            <tr><td style="width:35px">[<asp:LinkButton ID="btnDel" runat="server" CommandName="del" ForeColor="Red">删除</asp:LinkButton>]</td><td><%#Eval("vc_ViewDesc")%></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            <div>
				<uc1:PageNumBar ID="PageNumBar1" runat="server" />				
			</div>
		</div>
        </div>
    </div>
    <asp:TextBox ID="txt_ItemId" runat="server" BorderStyle="None" 
        Height="0px" Width="0px"></asp:TextBox>
    <asp:Literal ID="lit_Script" runat="server"></asp:Literal>

    </form>
</body>
</html>