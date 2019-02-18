<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/Site.master" CodeFile="ChiTietNgheNhan.aspx.cs" Inherits="Template_ChiTietDiSan" %>

<%@ Register Src="~/Template/Controls/RightContent.ascx" TagPrefix="uc1" TagName="RightContent" %>


<asp:Content runat="server" ContentPlaceHolderID="Navigate">
    <a href="/"><%=Resources.labels.home %></a>
    <span>> </span>
    <a href="<%=menu.UrlFull %>"><%=menu.TenMenu %></a>
    <span>> </span>
    <a href="#"><%=nghenhan.HoTen %></a>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

    <div class="left-main">
        <div class="module">
            <div class="module-title">
                <a href="<%=menu.UrlFull %>" class="TitleCate" title="<%=menu.TenMenu %>">
                    <span><%=menu.TenMenu %></span>
                </a>
            </div>
            <div class="module-content">
                <div class="des">
                    <div class="info">
                        <h3><%#Eval("HoTen") %> <%#Eval("TenKhac") %></h3>
                        <p><span class="bold"><%=Resources.labels.tennghenhan %> : </span><%=nghenhan.HoTen %></p>
                        <p><span class="bold"><%=Resources.labels.danhhieu %> : </span><%=nghenhan.TenDanhHieu %></p>
                        <p><span class="bold"><%=Resources.labels.ngaysinh %> : </span><%=nghenhan.NgaySinh %></p>
                        <p><span class="bold"><%=Resources.labels.dantoc %> : </span><%=nghenhan.TenDanToc %></p>
                        <p><span class="bold"><%=Resources.labels.diachi %> : </span><%=nghenhan.DiaChi %></p>
                    </div>
                </div>
                <div class="new-details">
                    <%=nghenhan.GioiThieu %>
                </div>
                <div class="more-link">
                    <h4><%=Resources.labels.danhsachnghenhan %></h4>
                    <ul>
                        <asp:Repeater runat="server" ID="rptOrther">
                            <ItemTemplate>
                                <li>
                                    <a href="<%#Eval("UrlFull") %>"><%#Eval("HoTen") %></a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
    </div>
   <div class="right-main">
        <uc1:RightContent runat="server" ID="RightContent" />
    </div>
</asp:Content>
