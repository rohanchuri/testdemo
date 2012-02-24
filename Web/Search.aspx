<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/common.master" CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" Runat="Server" style="text-align:left">
<div class="main_booklist">
    <dl>
        <dt class="ipt1">
          请选择排序方式：<asp:Button class="anniu"  ID="btnDate" runat="server" Text="出版日期" OnClick="btnDate_Click" />       
           | <asp:Button ID="btnPrice" runat="server" Text="价格" OnClick="btnPrice_Click" class="anniu"  />
         </dt>
        <dt>
            <ul class="title_ul1">
                <li class="title_booklist0">书名</li>  
                <li class="title_booklist1">作者</li> 
                <li class="title_booklist2">出版社</li>  
                <li class="title_booklist3">出版日期</li>
                <li class="title_booklist4">价格</li>   
            </ul>
            <asp:Repeater ID="rpBookList" runat="server">
            <ItemTemplate>
            <ul class="title_ul2">
                <li class="title_booklist0" ><a href="BookDetail.aspx?bid=<%# Eval("Id")%>"><%#Eval("Title") %></a></li>  
                <li class="title_booklist1"><%#GetCut(Eval("Author"),12)%> </li> 
                <li class="title_booklist2"><%#Eval("Publisher.Name")%> </li>  
                <li class="title_booklist3"><%#GetDate(Eval("PublishDate"))%> </li>
                <li class="title_booklist4"><%#GetMoney(Eval("UnitPrice"))%></li>   
            </ul>
            </ItemTemplate>  
            <AlternatingItemTemplate>
            <ul class="title_ul3">
                <li class="title_booklist0" ><a href="BookDetail.aspx?bid=<%# Eval("Id")%>"><%#Eval("Title") %></a></li>  
                <li class="title_booklist1"><%#GetCut(Eval("Author"),12)%> </li> 
                <li class="title_booklist2"><%#Eval("Publisher.Name")%> </li>  
                <li class="title_booklist3"><%#GetDate(Eval("PublishDate"))%> </li>
                <li class="title_booklist4"><%#GetMoney(Eval("UnitPrice"))%></li>   
            </ul>
            </AlternatingItemTemplate>  
            </asp:Repeater>    
        </dt>
        <dt class="ipt2"><asp:Label runat="server" ID="lblCurrentPage"></asp:Label>        
        <asp:Button ID="btnPrev" runat="server" Text="上一页" class="anniu" OnClick="btnPrev_Click"/> 
        <asp:Button ID="btnNext" runat="server" Text="下一页" class="anniu"  OnClick="btnNext_Click"/> 
        </dt>
    </dl>
</div>
</asp:Content>
