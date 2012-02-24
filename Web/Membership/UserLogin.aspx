<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserLogin.aspx.cs" Inherits="UserManager_UserLogin" MasterPageFile="~/Membership/Member.master"%>

<%@ Register Src="../_Controls/UserLoginControl.ascx" TagName="UserLoginControl"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMember" Runat="Server">
    <uc1:UserLoginControl id="UserLoginControl1" runat="server">
    </uc1:UserLoginControl>



</asp:Content>
