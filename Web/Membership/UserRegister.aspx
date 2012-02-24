<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserRegister.aspx.cs" Inherits="AddUsers"  MasterPageFile="~/Membership/Member.master" Title="用户注册"%>

<%@ Register Src="../_Controls/UserRegisterControl.ascx" TagName="UserRegisterControl"
    TagPrefix="uc1" %>

<asp:Content ID="regContent" ContentPlaceHolderID="cphMember" Runat="Server">
    <uc1:UserRegisterControl id="urcRegister" runat="server">
    </uc1:UserRegisterControl>
</asp:Content>
