<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PicInfo_List.aspx.cs" Inherits="admin_PicInfo_List" %>
<%@ Register src="../inc/PageNumBar.ascx" tagname="PageNumBar" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link rel="stylesheet" href="css/style.css" type="text/css" media="screen" />
    <link rel="stylesheet" type="text/css" href="css/jquery_dialog.css" />
    <script type="text/javascript" src="js/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="js/jquery_dialog.js"></script>
    <script type="text/javascript">
        function del_sure() {
            return confirm("你确定要删除该图片吗?");
        } 
    </script>
</head>
<body">
    <form id="form1" runat="server">
    <div class="content-box role">
	    <div class="content-box-content">
		<div class="tab-content default-tab">
            <table width ="100%">
                <tr><td style="width: 70px" align="right">项目名称：</td><td style="width: 200px" colspan="4">
                    <asp:Literal ID="lit_ItemName" runat="server"></asp:Literal>
                    </td><td colspan ="4"><font color="red">&nbsp;&nbsp;
                        <asp:Literal ID="lit_Msg" runat="server"></asp:Literal></font>
                    </td></tr>
                    <tr><td style="width: 70px" align="right">图片编号：</td><td style="width: 70px">
                        <asp:TextBox ID="txt_Pid" runat="server" BorderStyle="None" Width="70px" Enabled="False" BackColor="#EEEEEE"></asp:TextBox></td><td style="width: 70px" align="right">图片类型：</td><td style="width: 80px">
                    <asp:DropDownList ID="ddl_PicType" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="ddl_PicType_SelectedIndexChanged">
                    </asp:DropDownList>
                    </td><td style="width:160px"><asp:FileUpload ID="FileUpload1" 
                                runat="server" />
                        </td><td style="width: 70px" align="right">图片描述：</td><td>
                    <asp:TextBox ID="txt_PicDesc" runat="server" Width="200px" MaxLength="30"></asp:TextBox>
                    </td><td>
                            <asp:LinkButton ID="btnUpLoad" runat="server" CssClass="button" 
                                onclick="btnUpLoad_Click"> 提交 </asp:LinkButton>
                        </td><td style="width:60px">
                            <input id="btnClose" type="button" value=" 关闭 " class="button" 
                                style="height: 24px" onclick="javascript:JqueryDialog.Close();"/></td></tr>
            </table>
            <div style="height: 5px">&nbsp;</div>
            <div>
				<asp:DataList ID="DataList1" runat="server" RepeatColumns="5" CellSpacing="10" 
                    onitemcommand="DataList1_ItemCommand" DataKeyField="int_Pid" 
                    BorderWidth="0" onitemdatabound="DataList1_ItemDataBound">
                    <ItemTemplate>
                        <table style="border-width: 0px; width:210; height:100%">
                            <tr><td colspan="2"><a href ="<%#Eval("vc_PicFile")%>" target="_blank"><img alt="" src="<%#Eval("vc_Pic2")%>"  style="border-width: 0px; width: 180px; height: 120px"/></a>
                                </td>
                            </tr>
                            <tr><td style="width:35px">[<asp:LinkButton ID="btnDel" runat="server" CommandName="del" ForeColor="Red">删除</asp:LinkButton>]</td><td><%#Eval("vc_PicDesc")%></td>
                            </tr>
                        </table>
                        
                    </ItemTemplate>
                </asp:DataList>
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



