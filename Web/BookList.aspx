<%@ Page Language="C#" MasterPageFile="~/common.master" AutoEventWireup="true" CodeFile="BookList.aspx.cs" Inherits="BookList" Title="图书列表页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" Runat="Server">

<div class="contentstyle">
  <div id="divOrder">
    <div style="text-align:left;margin:20px 0 20px 0;">排序方式：
    <asp:Button ID="btnDate" runat="server" Text="出版日期" OnClick="btnDate_Click" BackColor="#C0FFC0" BorderColor="SeaGreen" BorderStyle="Solid" BorderWidth="1px" CssClass="anniu" Font-Size="12px" ForeColor="Black" Font-Bold="False" Height="16px" Width="57px" />       
       | <asp:Button ID="btnPrice" runat="server" Text="价格" OnClick="btnPrice_Click" BackColor="#C0FFC0" BorderColor="SeaGreen" BorderStyle="Solid" BorderWidth="1px" CssClass="anniu" Font-Size="12px" ForeColor="Black" Font-Bold="False" Height="16px" Width="57px" /></div>
  </div>
</div>

<div class="contentstyle" >
    <asp:DataList ID="dlBooks" runat="server">
        <ItemTemplate>
            <table>
                <tr>
                  <td rowspan="2">
                     <a  href="BookDetail.aspx?bid=<%# Eval("Id")%>">
                         <img style="CURSOR: hand" height="121" alt="<%# Eval("Title") %>" src="<%# GetUrl(Eval("ISBN").ToString()) %>" width="95"  hspace="4"/>
                     </a> 
                  </td>
                  <td style="FONT-SIZE: small; COLOR: red" width="650">
                    <a href="BookDetail.aspx?bid=<%# Eval("Id")%>" name="link_prd_name" target="_blank" class="booktitle" id="link_prd_name"><%# Eval("Title") %></a> 
                  </td>
                </tr>
                <tr>
                  <td align="left">
                      <span style="font-size:12px;line-height:20px;"><%# Eval("Author") %></span><br />
                        <br />
                      <span style="font-size:12px;line-height:20px;"><%# GetCut(Eval("ContentDescription").ToString(),150) %></span> 
                  </td>
                </tr>
                <tr>
                  <td align="right" colspan="2">
                     <span style="font-size:13px;line-height:20px;font-weight:bold;"> &yen; <%# Eval("UnitPrice") %></span> 
                  </td>
                </tr>
            </table>
        </ItemTemplate>
        <SeparatorTemplate>
        <hr />
        </SeparatorTemplate>
    </asp:DataList>&nbsp;
</div>
<div class="contentstyle" style="text-align:left;margin:20px 0 20px 0;">
<asp:Label runat="server" ID="lblCurrentPage"></asp:Label>

<asp:Button ID="btnPrev" runat="server" Text="上一页" OnClick="btnPrev_Click" BackColor="#C0FFC0" BorderColor="SeaGreen" BorderStyle="Solid" BorderWidth="1px" CssClass="anniu" Font-Size="12px" ForeColor="Black" Font-Bold="False" Height="16px" Width="57px"/> 
<asp:Button ID="btnNext" runat="server" Text="下一页" OnClick="btnNext_Click" BackColor="#C0FFC0" BorderColor="SeaGreen" BorderStyle="Solid" BorderWidth="1px" CssClass="anniu" Font-Size="12px" ForeColor="Black" Font-Bold="False" Height="16px" Width="57px"/> 

</div>
</asp:Content>

