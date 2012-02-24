<%@ Page Language="C#" AutoEventWireup="true"   CodeFile="AdminLogin.aspx.cs" Inherits="Admin_AdminLogin" Title="管理员登录" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
    <!--
    #Layer1 {
	    position:absolute;
	    left:273px;
	    top:203px;
	    width:446px;
	    height:263px;
	    z-index:1;
    }
    #Layer2 {
	    position:absolute;
	    left:421px;
	    top:328px;
	    width:205px;
	    height:18px;
	    z-index:2;
    }
    #Layer3 {
	    position:absolute;
	    left:423px;
	    top:361px;
	    width:193px;
	    height:19px;
	    z-index:3;
    }
    #Layer5 {
	position:absolute;
	left:423px;
	top:424px;
	width:74px;
	height:28px;
	z-index:5;
    }
    #Layer6 {
	position:absolute;
	left:515px;
	top:425px;
	width:61px;
	height:27px;
	z-index:6;
    }
    -->
</style>
</head>
<body style="background-color: silver">
    <form id="form1" runat="server">
    <div id="Layer1">
        <img src="../Images/di-admini.gif" width="444" height="261" border="0" usemap="#Map" />            
    </div>
    <div id="Layer2">      
        <asp:TextBox runat="server" ID="txtLoginId"></asp:TextBox>
    </div>
    <div id="Layer3">  
        <asp:TextBox runat="server" ID="txtLoginPwd" TextMode="Password"></asp:TextBox>
    </div>
    <div id="Layer5">
        <asp:ImageButton runat="server" ID="imgbtnSure" ImageUrl="../Images/qd.gif" OnClick="imgb_Sure_Click" />
    </div>
    <div id="Layer6">
        <asp:ImageButton runat="server" ID="imgbtnCancel" ImageUrl="../Images/cz.gif" OnClick="imgb_Cancel_Click" />
    </div>
    </form>
</body>
</html>
