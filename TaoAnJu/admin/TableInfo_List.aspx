<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TableInfo_List.aspx.cs" Inherits="admin_TableInfo_List" %>
<%@ Register src="../inc/PageNumBar.ascx" tagname="PageNumBar" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
    <div id="maintitle"><div id="mainico"></div><div id="maintip"><strong>位置：</strong>数据库表<asp:Literal ID="lit_TbName" runat="server"></asp:Literal></div>
        <div>
            &nbsp;
        </div></div>
    <div class="content-box role">
	    <div class="content-box-content">
		<div class="tab-content default-tab">
		    <asp:GridView ID="GridView1" runat="server" 
                onrowdatabound="GridView1_RowDataBound" AutoGenerateColumns="False" 
                BorderStyle="None">
                <Columns>
                     <asp:BoundField DataField="int_FiId" HeaderText="字段编号" >
                         <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" Wrap="True" />
                         <HeaderStyle HorizontalAlign="center" VerticalAlign="Middle" Width="65px" Wrap="False" />
                     </asp:BoundField>
                     <asp:BoundField DataField="vc_FieldDesc" HeaderText="字段名称" >
                         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                         <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                     </asp:BoundField>
                     <asp:BoundField DataField="int_MaxLength" HeaderText="数据长度" >
                         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True" />
                         <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" Width="70px" />
                     </asp:BoundField>
                     <asp:BoundField DataField="vc_DataType" HeaderText="数据类型" >
                         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True" />
                         <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" Width="70px" />
                     </asp:BoundField>
                     <asp:BoundField DataField="vc_DataNormal" HeaderText="数据规范">
                         <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Width="160px" Wrap="False" />
                         <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
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
