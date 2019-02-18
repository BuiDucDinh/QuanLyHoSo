<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/Site.master" CodeFile="ChiTietTin.aspx.cs" Inherits="Template_ChiTietTin" %>

<%@ Register Src="~/Template/Controls/RightContent.ascx" TagPrefix="uc1" TagName="RightContent" %>


<asp:Content runat="server" ContentPlaceHolderID="Navigate">
    <a href="/"><%=Resources.labels.home %></a>
    <span>> </span>
    <a href="<%=menu.UrlFull %>"><%=menu.TenMenu %></a>
    <span>> </span>
    <a href="#"><%=bv.TieuDe %></a>
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <div class="left-main">
        <div class="module">
            <div class="module-title">
                <a href="<%=menu.UrlFull %>" class="TitleCate" title="<%=menu.TenMenu %>">
                    <span><%=menu.TenMenu %></span>
                </a>
            </div>
            <div class="module-content">
                <div class="new-details">
                    <%=bv.NoiDung %>
                </div>
                <div class="more-link">
                    <h4><%=Resources.labels.tintuclienquan %></h4>
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
        <uc1:RightContent runat="server" ID="RightContent" />
    </div>
</asp:Content>
