<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="admin_Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>淘安居信息后台管理系统</title>
    <link rel="stylesheet" href="css/reset.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="css/index.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="css/invalid.css" type="text/css" media="screen" />	
    <link rel="stylesheet" type="text/css" href="css/jquery_dialog.css" />
    <script type="text/javascript" src="js/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="js/jquery_dialog.js"></script>
    <script type="text/javascript">
        function changepwd() {
            JqueryDialog.Open1("修改密码", "ChangePwd.aspx", 310, 156, true, true, true, 'no');
    }
    </script>
</head>
<body style="background-color:#eaf7ff;">
    <form id="form1" runat="server">
    <div class="body_header">
		<div class="Top_title">淘安居信息后台管理系统</div>
        <div class="shortcut-buttons-set" style="margin-right:10px;">
            <asp:Literal ID="lit_LoginInfo" runat="server"></asp:Literal>&nbsp;&nbsp;
            <a href="Logout.aspx"><font color="blue">安全退出</font></a></div>
    </div>
    <div id="body-wrapper">
	    <div id="left">
            <div id="menutop">管理菜单</div>
		    <div id="menubg">
			    <iframe name="leftFrame" frameborder="0" scrolling="auto" onload="Javascript:SetCwinHeight('leftFrame')" src="Left.aspx"  id="leftFrame"></iframe>
		    </div>
	    </div>
	    <div id="main">
            <iframe name="mainFrame" style="border:1px solid #C0DCF2;" frameborder="0" scrolling="auto" onload="Javascript:SetCwinHeight('mainFrame')" src="Welcome.aspx"  id="mainFrame"></iframe>
        </div>
    </div>
    
    <div id="bottom-tip">
    <div class="middle" style="width:750px;">
    <div id="infozone">
    <div><a target='mainFrame'></a></div>
    </div>
</div>
<div style="float:left; width:240px;" id="liveclock">&nbsp;</div>
<div style="float:right; width:140px; background:url(images/buttonright.jpg) no-repeat;">&nbsp;</div>
</div>
<script type ="text/javascript">
    function SetCwinHeight(divid) {
        var cwin = document.getElementById(divid);
        if (document.getElementById) {
            if (cwin && !window.opera) {
                if (cwin.contentDocument && cwin.contentDocument.body.offsetHeight) {
                    cwin.height = cwin.contentDocument.body.offsetHeight;
                }
                else if (cwin.Document && cwin.Document.body.scrollHeight) {
                    cwin.height = cwin.Document.body.scrollHeight;
                }
            }
        }
    }
    document.getElementById("left").style.height = document.documentElement.clientHeight - 55 + "px";
    document.getElementById("leftFrame").style.height = document.documentElement.clientHeight - 91 + "px";
    document.getElementById("main").style.height = document.documentElement.clientHeight - 55 + "px";
    document.getElementById("mainFrame").style.height = document.documentElement.clientHeight - 55 + "px";
    document.getElementById("left").style.width = 200 + "px";
    document.getElementById("leftFrame").style.width = 184 + "px";
    document.getElementById("main").style.width = document.documentElement.clientWidth - 221 + "px";
    document.getElementById("mainFrame").style.width = document.documentElement.clientWidth - 221 + "px";
    window.onresize = function () {
        document.getElementById("left").style.height = document.documentElement.clientHeight - 55 + "px";
        document.getElementById("leftFrame").style.height = document.documentElement.clientHeight - 91 + "px";
        document.getElementById("main").style.height = document.documentElement.clientHeight - 55 + "px";
        document.getElementById("mainFrame").style.height = document.documentElement.clientHeight - 55 + "px";
        document.getElementById("left").style.width = 200 + "px";
        document.getElementById("leftFrame").style.width = 184 + "px";
        document.getElementById("main").style.width = document.documentElement.clientWidth - 221 + "px";
        document.getElementById("mainFrame").style.width = document.documentElement.clientWidth - 221 + "px";
    }
    </script>
    </form>
</body>
</html>
