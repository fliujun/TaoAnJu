<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="admin_LoginPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>淘安居信息后台管理系统登录</title>
    <link href="css/login_style.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript">
        function ChangeCode() {

            var date = new Date();
            var myImg = document.getElementById("ImageCheck");
            var GUID = document.getElementById("lblGUID");

            if (GUID != null) {
                if (GUID.innerHTML != "" && GUID.innerHTML != null) {
                    myImg.src = "ValidateCode.aspx?GUID=" + GUID.innerHTML + "&flag=" + date.getMilliseconds()
                }
            }
            return false;
        }
    </script>
    <style type="text/css">
        .style1
        {
            height: 39px;
        }
    </style>
</head>
<body style="margin: 0px">
    <form id="form1" runat="server">
    <asp:Label ID="lblGUID" runat="server" Style="display: none"></asp:Label>
    <div class="main">
   <div class="main_title">淘安居信息后台管理系统登录</div>
   <div class="main_info">
   <asp:ScriptManager ID="ScriptManager1" runat="server">   
         </asp:ScriptManager>   
         
              
        <table width="260" border="0" cellspacing="0" cellpadding="0">
        <tr style="height: 20px"><td colspan="3" align="center">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">   
             <ContentTemplate>
             <font color="red"><asp:Literal ID="lit_Msg" runat="server"></asp:Literal></font>
             </ContentTemplate>   
            </asp:UpdatePanel>
         </td></tr>
        <tr>
          <td align="right" class="style1">账号:&nbsp;&nbsp;</td>
          <td colspan="2">
              <asp:TextBox ID="txt_LoginName" runat="server" CssClass="text" MaxLength="16"></asp:TextBox>
            </td>
        </tr>
        <tr>
          <td height="31" align="right">密码:&nbsp;&nbsp;</td>
          <td colspan="2">
              <asp:TextBox ID="txt_LoginPwd" runat="server" CssClass="text" MaxLength="16" 
                  TextMode="Password"></asp:TextBox>
            </td>
        </tr>
         <tr>
          <td height="31" align="right">验证码:&nbsp;&nbsp;</td>
          <td>
              <asp:TextBox ID="txt_Code" runat="server" CssClass="code" MaxLength="4"></asp:TextBox>
&nbsp;<a id="A2" href="" onclick="ChangeCode();return false;"><asp:Image ID="ImageCheck" runat="server" ImageUrl="ValidateCode.aspx?GUID=GUID" ImageAlign="AbsMiddle" ToolTip="看不清，换一个" BorderWidth="0"></asp:Image></a>
          </td>
          <td></td>
        </tr>
      </table>
      <asp:UpdatePanel ID="UpdatePanel2" runat="server">   
          <ContentTemplate>
            <table width="260" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td width="143" height="38" align="right">
                  <asp:Button ID="btn_Login" runat="server" CssClass="button" 
                      onclick="btn_Login_Click" />
              </td>
              <td width="115" height="38" align="center">
                  &nbsp;</td>
            </tr>
            </table>
        </ContentTemplate>   
     </asp:UpdatePanel>   
  </div>
</div>
    </form>
</body>
</html>
