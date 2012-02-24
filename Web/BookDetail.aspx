<%@ Page Language="C#" MasterPageFile="~/common.master" AutoEventWireup="true" CodeFile="BookDetail.aspx.cs" Inherits="BookDetail" Title="Book Store"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" Runat="Server">
    <div style="font-size:small">
        <table>
            <tr>
                <td>
                    <table width="100%">
                        <tr>
                            <td rowspan="4">
                                <asp:Image runat="server" ID="imgBook"/>
                            </td>
                            <td colspan="2" style="font-size:medium"><font color="navy"><strong><asp:Label runat="server" ID="lblBookName"></asp:Label></strong></font></td>                            
                            
                        </tr>
                        <tr>
                            <td align="left" style="width: 212px">���ߣ�<asp:Label runat="server" ID="lblAuthor"></asp:Label></td>
                            <td align="left">��������<asp:Label runat="server" ID="lblBooksName"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 212px">�����磺<asp:Label runat="server" ID="lblPublisher"></asp:Label></td>
                            <td align="left">ISBN��<asp:Label runat="server" ID="lblISBN"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 212px">����ʱ�䣺<asp:Label runat="server" ID="lblPublishDate"></asp:Label></td>
                            <td align="left">������<asp:Label runat="server" ID="lblFonts"></asp:Label></td>
                        </tr> 
                        <tr>
                            <td>
                                <asp:Label ID="lblvotes" runat="server" style=" color:Red"></asp:Label>
                                �û����֣�<asp:Label ID="lblrating" runat="server" style=" color:Red"></asp:Label>
                            </td>
                        </tr>                     
                        <tr>
                            <td colspan="3" align="right"><asp:Label runat="server" ID="lblPrice"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="3" align="right">
                                <asp:ImageButton runat="server" ID="imgb_Buy" ImageUrl="~/Images/sale.gif" OnClick="imgb_Buy_Click" />&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <hr style="width: 100%; height: 1px;" />
                    <div style="font-size:medium;color:Red"><strong>Ϊ����Ʒ���:</strong></div>
                    <asp:DropDownList ID="ddlRatings" runat="server">
                        <asp:ListItem Value="1">1����</asp:ListItem>
                        <asp:ListItem Value="2">2����</asp:ListItem>
                        <asp:ListItem Selected="True" Value="3">3����</asp:ListItem>
                        <asp:ListItem Value="4">4����</asp:ListItem>
                        <asp:ListItem Value="5">5����</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="btnRate" runat="server" Text="���" onclick="btnRate_Click" />
                    <asp:Literal runat="server" ID="lblUserRating" Visible="False"
      Text="���Ѿ�Ϊ������ {0} ���ǣ�" />
                          
                    </td>
            </tr>
            <tr>
                <td align="left">
                    <div style="font-size:medium;color:Red">
                    <hr style="width: 100%; height: 1px;" />
                        <strong>������Ҫ:</strong></div>
                    <asp:Label runat="server" ID="lblContent"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <div style="font-size:medium;color:Red"><strong>���߼��:</strong></div>
                    <asp:Label runat="server" ID="lblAuthorIntroduce"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <div style="font-size:medium;color:Red"><strong>�༭�Ƽ�:</strong></div>
                    <asp:Label runat="server" ID="lblRecomment"></asp:Label>
                    <hr style="width: 100%; height: 1px;" />
                </td>
            </tr>
            <tr>
                <td align="left">
                    <div style="font-size:medium;color:Red"><strong>Ŀ¼:</strong></div>
                    <asp:Label runat="server" ID="lblCatagory"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <hr style="width: 100%; height: 1px;" />
                </td>
            </tr>
            <tr>
                <td align="left">
                    <div style="font-size:medium;color:Red"><strong>�û�����:</strong></div>
                    </td>
            </tr>
        </table>
    </div>
</asp:Content>

