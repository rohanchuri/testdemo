<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>���ﳵ</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link href="Style.css" type="text/css" rel="Stylesheet" /> 
</head>
<body class="sub">
<div id="wrap">
<div class="header">
       		<div class="logo"><a href="Default.aspx"><img src="Images/logo.gif" alt="" title="" border="0" /></a></div>            
        <div id="menu">
            <ul>                                                                       
            <li class="selected"><a href="Default.aspx">��ҳ</a></li>
            <li><a href="BookList.aspx">ͼ���б�ҳ</a></li>
            <li><a href="Cart.aspx">�ҵĹ��ﳵ</a></li>
            <li><a href="Membership/userlogin.aspx">�û���¼</a></li>
            <li><a href="Admin/AdminLogin.aspx">����Ա��¼</a></li>
            </ul>
        </div>     
            
            
       </div>
<form runat="server">
  <table width="100%">
    <tr>
      <td style="height: 18px"><div class="STYLE3" id="__breadcrumb"><img src="images/touming.gif" width="27" height="10" />�����ڵ�λ�ã�<span id="uc_cat_spnPath">
          <asp:SiteMapPath
              ID="SiteMapPath1" runat="server">
          </asp:SiteMapPath>
          </span></div></td>
    </tr>
    <tr> 
        <td>
            <img src="images/shop-cart-header-blue.gif" width="206" height="27" />&nbsp;<asp:ValidationSummary
                ID="vsMessage" runat="server" ShowSummary="False" ShowMessageBox="True" />
        </td>
    </tr>
  </table>  
  <table width="100%" border="0" cellpadding="4" cellspacing="0" class="contentstyle" style="text-align: center">
    <tr style="vertical-align: top" class="HeaderColor">
      <td style="height: 364px">
        <asp:GridView runat="server" ID="gvCart" Width="95%" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gvCart_PageIndexChanging" OnRowEditing="gvCart_RowEditing" PageSize="5" OnRowCancelingEdit="gvCart_RowCancelingEdit" OnRowDeleting="gvCart_RowDeleting" OnRowDataBound="gvCart_RowDataBound" OnRowUpdating="gvCart_RowUpdating">
            <Columns>
                <asp:TemplateField HeaderText="ͼʾ">
                    <ItemTemplate>
                        <img runat="server" id="imgbook" src='<%# GetUrl(DataBinder.Eval(Container.DataItem,"ImageUrl").ToString()) %>' width="49" height="56"/>
                    </ItemTemplate>
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="����">                   
                    <ItemTemplate>
                        <asp:Label ID="lblBookName" runat="server" Text='<%# Bind("BookName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="����">
                    <EditItemTemplate>
                        &nbsp;<asp:TextBox ID="txtNumber" runat="server" Text='<%# Bind("Number") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNumber" runat="server" ControlToValidate="txtNumber" ErrorMessage="����������" Text="*"
                           ></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="refNumber" runat="server" ControlToValidate="txtNumber" ErrorMessage="������Ǹ�����" Text="*" ValidationExpression="^[0-9]*[1-9][0-9]*$"></asp:RegularExpressionValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Number") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="����">                    
                    <ItemTemplate>
                        <asp:Label ID="lblUnitPrice" runat="server" Text='<%# Bind("UnitPrice") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True"/>             
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkbtnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                            Text="ɾ��"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField Visible="False">                   
                    <ItemTemplate>
                        <asp:Label ID="lblBookId" runat="server" Text='<%# Bind("BookId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>    
            </Columns>
        </asp:GridView>
      </td>
    </tr>
  </table>
  <table width="100%" class="contentstyle">
    <tr>
      <td width="68%" align="right">
        <a href="BookList.aspx">������ѡ��Ʒ</a>&nbsp;&nbsp;&nbsp;&nbsp;
        ��Ʒ����ܼƣ���<em><strong><asp:Literal runat="server" ID="ltrSalary"></asp:Literal></strong></em>
      </td>
      <td align="center"><asp:ImageButton runat="server" ID="imgbtnSalary" ImageUrl="images/balance.gif" OnClick="imgb_Salary_Click" /></td>
    </tr>
  </table>
</form>
</div>
</body>
</html>