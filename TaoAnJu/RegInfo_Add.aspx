<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegInfo_Add.aspx.cs" Inherits="RegInfo_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellspacing="0" cellpadding="0" width="100%" border="0" style="background-color: #Ffffff; width: 100%;">
                               
                <tr><td align="right" style="width: 70px">姓名：</td>
                <td>   
                    
                        <asp:TextBox ID="txt_Name" runat="server" MaxLength="50"></asp:TextBox> 
                 </td></tr>
               <tr><td align="right" style="width: 70px">手机号：</td>
                <td><asp:TextBox ID="txt_Mobile" runat="server" MaxLength="500"></asp:TextBox></td></tr>
                                
            </table>
    </div>
    </form>
</body>
</html>
