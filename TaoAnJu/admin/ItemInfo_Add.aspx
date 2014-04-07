<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ItemInfo_Add.aspx.cs" Inherits="admin_ItemInfo_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="css/style.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="css/jquery_dialog.css" type="text/css" media="screen" />
    <script type="text/javascript" src="js/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="js/jquery_dialog.js"></script>
    <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
</head>
<body style="margin: 0px">
    <form id="form1" runat="server">
    <div class="content-box" id="BodyDiv">
	    <div class="content-box-content10">
			<table cellspacing="0" cellpadding="0" width="100%" border="0" style="background-color: #Ffffff; width: 100%;">
                <tr><td colspan="6" style="height: 20px"><font color="red">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Literal ID="lit_Msg" runat="server"></asp:Literal></font> 
                    </td></tr>
                <tr><td align="right" style="width: 80px; background-color: #EBEBEB;">项目名称：</td><td>
                    <asp:TextBox ID="txt_ItemName" runat="server" BackColor="White" MaxLength="50" 
                        Width="200px"></asp:TextBox>
                    </td><td align="right" style="width: 80px; background-color: #EBEBEB;">所在城市：</td><td>
                    <asp:DropDownList ID="ddl_City" runat="server" Width="160px">
                    </asp:DropDownList>
                    </td><td align="right" style="width: 80px; background-color: #EBEBEB;">所在区域：</td><td>
                    <asp:TextBox ID="txt_Area" runat="server" BackColor="White" MaxLength="50" 
                        Width="160px"></asp:TextBox>
                    </td><td align="right" style="width: 80px; background-color: #EBEBEB;">所属商圈：</td><td>
                    <asp:TextBox ID="txt_BusinessZone" runat="server" BackColor="White" MaxLength="50" 
                        Width="200px"></asp:TextBox>
                    </td></tr>
               
                <tr><td align="right" style="width: 80px; background-color: #EBEBEB;">楼盘地址：</td>
                <td>   
                       <asp:TextBox ID="txt_Location" runat="server" MaxLength="80" Width="196px" 
                           TextMode="MultiLine" Height="80px"></asp:TextBox> 
                 </td><td align="right" style="width: 80px; background-color: #EBEBEB;">项目特色：</td>
                <td>   
                       <asp:TextBox ID="txt_ProjectFeatures" runat="server" MaxLength="80" Width="156px" 
                           TextMode="MultiLine" Height="80px"></asp:TextBox> 
                 </td><td align="right" style="width: 80px; background-color: #EBEBEB;">楼盘简介：</td><td align="left" colspan="3">
                       <asp:TextBox ID="txt_Introduction" runat="server" MaxLength="2000" Width="98%" 
                        TextMode="MultiLine" Height="80px"></asp:TextBox> </td></tr>
               
               <tr><td align="right" style="width: 80px; background-color: #EBEBEB;">开发商：</td>
                <td>   
                       <asp:TextBox ID="txt_Developer" runat="server" MaxLength="80" Width="200px"></asp:TextBox> 
                 </td><td align="right" style="width: 80px; background-color: #EBEBEB;">
                   开盘时间：</td><td>
                    <asp:TextBox ID="txt_OpeningTime" runat="server" BackColor="White" MaxLength="50" 
                        Width="160px" CssClass="Wdate" onFocus="WdatePicker({readOnly:true})"></asp:TextBox>
                    </td><td align="right" style="width: 80px; background-color: #EBEBEB;">入住时间：</td><td>
                    <asp:TextBox ID="txt_CheckinTime" runat="server" BackColor="White" MaxLength="50" 
                        Width="160px" CssClass="Wdate" onFocus="WdatePicker({readOnly:true})"></asp:TextBox>
                    </td><td align="right" style="width: 80px; background-color: #EBEBEB;">参考价格：</td><td>
                    <asp:TextBox ID="txt_ReferencePrice" runat="server" BackColor="White" MaxLength="50" 
                        Width="200px"></asp:TextBox>
                    </td></tr>
                <tr><td align="right" style="width: 80px; background-color: #EBEBEB;">打折优惠：</td>
                <td>   
                    <asp:TextBox ID="txt_Discount" runat="server" BackColor="White" MaxLength="50" 
                        Width="200px"></asp:TextBox>
                 </td><td align="right" style="width: 80px; background-color: #EBEBEB;">咨询热线：</td>
                <td>   
                    <asp:TextBox ID="txt_Hotline" runat="server" BackColor="White" MaxLength="50" 
                        Width="160px"></asp:TextBox>
                 </td><td align="right" style="width: 80px; background-color: #EBEBEB;">售楼许可证：</td>
                    <td align="left">
                       <asp:TextBox ID="txt_SalesPermit" runat="server" MaxLength="50" Width="160px"></asp:TextBox> </td>
                    <td align="right" style="width: 80px; background-color: #EBEBEB;">售楼地址：</td>
                    <td>   
                    <asp:TextBox ID="txt_SalesLocation" runat="server" BackColor="White" MaxLength="100" 
                        Width="200px"></asp:TextBox>
                 </td></tr>
               <tr><td align="right" style="width: 80px; background-color: #EBEBEB;">
                   产权年限：</td><td>
                    <asp:TextBox ID="txt_PropertyRight" runat="server" BackColor="White" MaxLength="50" 
                        Width="200px"></asp:TextBox>
                    </td><td align="right" style="width: 80px; background-color: #EBEBEB;">建筑面积：</td><td>
                    <asp:TextBox ID="txt_BuildedArea" runat="server" BackColor="White" MaxLength="50" 
                        Width="160px" ></asp:TextBox>
                    </td><td align="right" style="width: 80px; background-color: #EBEBEB;">占地面积：</td><td>
                    <asp:TextBox ID="txt_CoveredArea" runat="server" BackColor="White" MaxLength="50" 
                        Width="160px"></asp:TextBox>
                    </td><td align="right" style="width: 80px; background-color: #EBEBEB;">建筑类别：</td>
                <td>   
                    <asp:TextBox ID="txt_BuildType" runat="server" BackColor="White" MaxLength="50" 
                        Width="200px"></asp:TextBox>
                 </td></tr>
               
                <tr><td align="right" style="width: 80px; background-color: #EBEBEB;">装修情况：</td>
                <td>   
                    <asp:TextBox ID="txt_Decoration" runat="server" BackColor="White" MaxLength="50" 
                        Width="200px"></asp:TextBox>
                 </td><td align="right" style="width: 80px; background-color: #EBEBEB;">建筑设计：</td>
                <td>   
                    <asp:TextBox ID="txt_BuildDesign" runat="server" BackColor="White" MaxLength="50" 
                        Width="160px"></asp:TextBox>
                 </td><td align="right" style="width: 80px; background-color: #EBEBEB;">承建商：</td>
                <td>   
                    <asp:TextBox ID="txt_Contractor" runat="server" BackColor="White" MaxLength="50" 
                        Width="160px"></asp:TextBox>
                 </td><td align="right" style="width: 80px; background-color: #EBEBEB;">景观设计：</td>
                <td>   
                    <asp:TextBox ID="txt_LandscapeDesign" runat="server" BackColor="White" MaxLength="50" 
                        Width="200px"></asp:TextBox>
                 </td></tr>
                 <tr><td align="right" style="width: 80px; background-color: #EBEBEB;">楼层状况：</td>
                <td>   
                    <asp:TextBox ID="txt_FloorCondition" runat="server" BackColor="White" MaxLength="100" 
                        Width="196px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                 </td><td align="right" style="width: 80px; background-color: #EBEBEB;">户型：</td><td align="left" colspan="3">
                       <asp:TextBox ID="txt_HouseType" runat="server" MaxLength="50" Width="98%" 
                           Height="50px" TextMode="MultiLine"></asp:TextBox> </td><td align="right" style="width: 80px; background-color: #EBEBEB;">
                       物业类别：</td><td>
                    <asp:TextBox ID="txt_PropertyType" runat="server" BackColor="White" MaxLength="50" 
                        Width="196px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                    </td></tr>
                   <tr><td align="right" style="width: 80px; background-color: #EBEBEB;">容积率：</td><td>
                    <asp:TextBox ID="txt_VolumeRate" runat="server" BackColor="White" MaxLength="50" 
                        Width="200px" ></asp:TextBox>
                    </td><td align="right" style="width: 80px; background-color: #EBEBEB;">绿化率：</td><td>
                    <asp:TextBox ID="txt_GreenRate" runat="server" BackColor="White" MaxLength="50" 
                        Width="160px"></asp:TextBox>
                    </td><td align="right" style="width: 80px; background-color: #EBEBEB;">供水：</td>
                <td>   
                    <asp:TextBox ID="txt_WaterSupply" runat="server" BackColor="White" MaxLength="50" 
                        Width="160px"></asp:TextBox>
                 </td><td align="right" style="width: 80px; background-color: #EBEBEB;">供暖：</td>
                <td>   
                    <asp:TextBox ID="txt_Heating" runat="server" BackColor="White" MaxLength="50" 
                        Width="200px"></asp:TextBox>
                 </td></tr>
               
                <tr><td align="right" style="width: 80px; background-color: #EBEBEB;">供气：</td>
                <td>   
                    <asp:TextBox ID="txt_GasSupply" runat="server" BackColor="White" MaxLength="50" 
                        Width="200px"></asp:TextBox>
                 </td><td align="right" style="width: 80px; background-color: #EBEBEB;">物业费：</td>
                <td>   
                    <asp:TextBox ID="txt_PropertyFee" runat="server" BackColor="White" MaxLength="50" 
                        Width="160px"></asp:TextBox>
                 </td><td align="right" style="width: 80px; background-color: #EBEBEB;">物业公司：</td>
                <td>   
                    <asp:TextBox ID="txt_PropertyCompany" runat="server" BackColor="White" MaxLength="50" 
                        Width="160px"></asp:TextBox>
                 </td><td align="right" style="width: 80px; background-color: #EBEBEB;">停车位：</td>
                <td>   
                    <asp:TextBox ID="txt_ParkingSpace" runat="server" BackColor="White" MaxLength="50" 
                        Width="200px"></asp:TextBox>
                 </td></tr>
                 <tr><td align="right" style="width: 80px; background-color: #EBEBEB;">交通出行：</td>
                <td colspan="3">   
                       <asp:TextBox ID="txt_Traffic" runat="server" MaxLength="2000" Width="98%" 
                           TextMode="MultiLine" Height="190px"></asp:TextBox> </td>
                <td align="right" style="width: 80px; background-color: #EBEBEB;">配套信息：</td><td align="left" colspan="3">
                       <asp:TextBox ID="txt_ConfigureInfo" runat="server" MaxLength="2000" Width="98%" 
                        TextMode="MultiLine" Height="190px"></asp:TextBox> </td></tr>
                <tr><td align="right" style="width: 80px; background-color: #EBEBEB;">明细主图：
                    </td><td colspan="7"><asp:FileUpload ID="FileUpload1" runat="server" />
                        <asp:Literal ID="lit_Pic" runat="server"></asp:Literal>
                    </td></tr>
                <tr><td align="right" style="width: 80px; background-color: #EBEBEB;">销售状态：</td>
                <td>   
                    <asp:DropDownList ID="ddl_SalesStatus" runat="server" Width="200px">
                        <asp:ListItem>预售</asp:ListItem>
                        <asp:ListItem>在售</asp:ListItem>
                        <asp:ListItem>告罄</asp:ListItem>
                    </asp:DropDownList>
                 </td><td align="right" style="width: 80px; background-color: #EBEBEB;">是否付费：</td>
                <td>   
                    <asp:DropDownList ID="ddl_IsPay" runat="server" Width="160px">
                        <asp:ListItem>否</asp:ListItem>
                        <asp:ListItem Selected="True">是</asp:ListItem>
                    </asp:DropDownList>
                 </td><td align="right" style="width: 80px; background-color: #EBEBEB;">显示排序：</td>
                <td>   
                    <asp:TextBox ID="txt_Order" runat="server" BackColor="White" MaxLength="50" 
                        Width="160px"></asp:TextBox>
                 </td><td align="right" style="width: 80px; background-color: #EBEBEB;">信息状态：</td>
                <td>   
                    <asp:DropDownList ID="ddl_Status" runat="server" Width="200px">
                        <asp:ListItem>停用</asp:ListItem>
                        <asp:ListItem Selected="True">正常</asp:ListItem>
                    </asp:DropDownList>
                 </td></tr>
            </table>
        </div>
    </div>
    <table cellspacing="0" cellpadding="0" border="0" 
            style="background-color: #F7F9FA; width: 100%; height: 45px;">
            <tr><td align="center">
                <asp:Button ID="btnSubmit" runat="server" CssClass="button" Text=" 确 定 " 
                    onclick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;<input id="btnCancel" class="button" type="button" value="&nbsp;&nbsp;取 消&nbsp;&nbsp;" onclick="javascript:JqueryDialog.Close();"/>
                </td></tr>
            </table>
            <asp:TextBox ID="txt_ItemId" runat="server" BorderStyle="None" 
        Height="0px" Width="0px"></asp:TextBox>
            <asp:Literal ID="lit_Script" runat="server"></asp:Literal> 
    <script type ="text/javascript">
        document.getElementById("BodyDiv").style.height = document.documentElement.clientHeight - 45 + "px";
        window.onresize = function () {
            document.getElementById("BodyDiv").style.height = document.documentElement.clientHeight - 45 + "px";
        }
    </script>
    </form>
</body>
</html>

