<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ItemInfo_List.aspx.cs" Inherits="admin_ItemInfo_List" %>
<%@ Register src="../inc/PageNumBar.ascx" tagname="PageNumBar" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="css/style.css" type="text/css" media="screen" />
    <link rel="stylesheet" type="text/css" href="css/jquery_dialog.css" />
    <script type="text/javascript" src="js/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="js/jquery_dialog.js"></script>
    <script language="javascript" type="text/javascript">
        function SelectAll(chkVal, idVal) {
            var thisfrm = document.forms[0];
            var ids = "";
            // 查找Forms里面所有的元素
            for (i = 0; i < thisfrm.length; i++) {
                // 查找模板头中的CheckBox
                if (idVal.indexOf('chkAll') != -1) {
                    if (chkVal == true) {
                        thisfrm.elements[i].checked = true;
                    }
                    else {
                        thisfrm.elements[i].checked = false;
                    }
                } // if
                // 如果除题头以外的项没有全選上则取消题头的選擇
                else if (idVal.indexOf('chkItem') != -1) {
                    if (thisfrm.elements[i].checked == false) {
                        thisfrm.elements[1].checked = false;
                    }
                }
            }
        }
	</script>
</head>
<body >
    <form id="form1" runat="server">
    <div id="maintitle"><div id="mainico"></div><div id="maintip"><strong>位置：</strong>房产项目</div>
        <div>
        <asp:LinkButton ID="btnAdd" runat="server" CssClass="linkbutton" 
            CausesValidation="False" Height="18px" EnableViewState="False" 
                onclick="btnAdd_Click">添加</asp:LinkButton>&nbsp;
        <asp:LinkButton ID="btnEdit" runat="server" CssClass="linkbutton" 
            onclick="btnEdit_Click" Height="18px">修改</asp:LinkButton>&nbsp;
        <asp:LinkButton ID="btnDelete" runat="server" CssClass="linkbutton" 
            onclick="btnDelete_Click" Height="18px">删除</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="btnAddPic" runat="server" CssClass="linkbutton" 
            onclick="btnAddPic_Click" Height="18px">添加图片</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="btnAddView" runat="server" CssClass="linkbutton" 
            onclick="btnAddView_Click" Height="18px">添加视频</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="btnSearch" runat="server" CssClass="linkbutton"  
                Height="18px" onclick="btnSearch_Click">查询</asp:LinkButton>
        </div></div>
    <div class="content-box role">
	    <div class="content-box-content">
        <div class="searchgrid">
            <table width ="100%">
                <tr><td style="width: 70px" align="right">项目名称：</td><td style="width: 150px">
                    <asp:TextBox ID="txt_ItemName" runat="server"></asp:TextBox>
                    </td><td style="width: 55px" align="right">开发商：</td><td style="width: 150px">
                    <asp:TextBox ID="txt_Developer" runat="server"></asp:TextBox>
                    </td><td style="width: 65px" align="right">是否付费：</td><td style="width: 50px">
                    <asp:DropDownList ID="ddl_IsPay" runat="server">
                        <asp:ListItem>否</asp:ListItem>
                        <asp:ListItem>是</asp:ListItem>
                        <asp:ListItem Selected="True">全部</asp:ListItem>
                    </asp:DropDownList>
                    </td><td style="width: 70px" align="right">销售状态：</td><td>
                    <asp:DropDownList ID="ddl_SalesStatus" runat="server">
                    </asp:DropDownList>
                    </td><td></td></tr>
            </table>
		</div>
        <div style="height: 5px">&nbsp;</div>
		<div class="tab-content default-tab">
		    <asp:GridView ID="GridView1" runat="server" 
                onrowdatabound="GridView1_RowDataBound" AutoGenerateColumns="False" 
                BorderStyle="None">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkAll" runat="server" Width="20px" />
                        </HeaderTemplate>
                        <ItemTemplate>
                             <asp:CheckBox ID="chkItem" runat="server" Width="20px" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20px" />
                     </asp:TemplateField>
                     <asp:BoundField DataField="int_ItemId" HeaderText="项目编号" >
                         <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" Wrap="True" />
                         <HeaderStyle HorizontalAlign="center" VerticalAlign="Middle" Width="60px" Wrap="False" />
                     </asp:BoundField>
                     <asp:BoundField DataField="vc_ItemName" HeaderText="项目名称" >
                         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                         <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                     </asp:BoundField>
                     <asp:BoundField DataField="vc_City" HeaderText="所在城市" >
                         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                         <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" Width="80px"/>
                     </asp:BoundField>
                     <asp:BoundField DataField="vc_Area" HeaderText="所在区域" >
                         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                         <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" Width="80px"/>
                     </asp:BoundField>
                     <asp:BoundField DataField="vc_Developer" HeaderText="开发商" >
                         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                         <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                     </asp:BoundField>
                     <asp:BoundField DataField="dt_OpeningTime" HeaderText="开盘时间" >
                         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True" />
                         <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" Width="110px" />
                     </asp:BoundField>
                     <asp:BoundField DataField="dec_ReferencePrice" HeaderText="参考价格" >
                         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True" />
                         <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" Width="70px" />
                     </asp:BoundField>
                     <asp:BoundField DataField="int_IsPay" HeaderText="是否付费" >
                         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True" />
                         <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" Width="60px" />
                     </asp:BoundField>
                     <asp:BoundField DataField="vc_SalesStatus" HeaderText="销售状态" >
                         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True" />
                         <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" Width="60px" />
                     </asp:BoundField>
                     <asp:BoundField DataField="dt_CreateDate" HeaderText="创建时间">
                         <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="120px" Wrap="False" />
                         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                     </asp:BoundField>
                     <asp:BoundField DataField="int_Status" HeaderText="状态">
                         <HeaderStyle HorizontalAlign="center" VerticalAlign="Middle" Width="40px" Wrap="False" />
                         <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
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