<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/Site.master" CodeFile="ChiTietAnPham.aspx.cs" Inherits="Template_ChiTietTin" %>

<%@ Register Src="~/Template/Controls/RightContent.ascx" TagPrefix="uc1" TagName="RightContent" %>


<asp:Content runat="server" ContentPlaceHolderID="Navigate">
    <a href="/"><%=Resources.labels.home %></a>
    <span>> </span>
    <a href="<%=menu.UrlFull %>"><%=menu.TenDanhMuc %></a>
    <span>> </span>
    <a href="#"><%=ap.TenSach %></a>
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <div class="left-main">
        <div class="module">
            <div class="module-title">
                <a href="<%=menu.UrlFull %>" class="TitleCate" title="<%=menu.TenDanhMuc %>">
                    <span><%=menu.TenDanhMuc %></span>
                </a>
            </div>
            <div class="module-content">
                <div class="new-details">
                    <%=ap.TomTatNoiDung %>
                </div>
                <div class="more-link">
                    <h4><%=Resources.labels.anphamlienquan %></h4>
                    <ul>
                        <asp:Repeater runat="server" ID="rptOrther">
                            <ItemTemplate>
                                <li>
                                    <a href="<%#Eval("url") %>"><%#Eval("TieuDe") %></a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <div class="right-main">
        <uc1:RightContent runat="server" ID="RightContent1" />
    </div>
</asp:Content>
