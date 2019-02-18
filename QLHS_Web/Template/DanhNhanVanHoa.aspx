<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/Site.master" CodeFile="DanhNhanVanHoa.aspx.cs" Inherits="Template_ChiTietTin" %>

<%@ Register Src="~/Template/Controls/RightContent.ascx" TagPrefix="uc1" TagName="RightContent" %>


<asp:Content runat="server" ContentPlaceHolderID="Navigate">
    <a href="/"><%=Resources.labels.home %></a>
    <span>> </span>
    <a href="<%=menu.UrlFull %>"><%=menu.TenMenu %></a>
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
                <h4><%=dn.TenDanhNhan %><%=dn.Thoidai %></h4>
                <div class="new-details">
                    <%=dn.MoTa %>
                </div>
                <div class="more-link">
                    <h4><%=Resources.labels.danhnhankhac %></h4>
                    <ul>
                        <asp:Repeater runat="server" ID="rptOrther">
                            <ItemTemplate>
                                <li>
                                    <a href="<%#Eval("url") %>"><%#Eval("TenDanhNhan") %><%#Eval("Thoidai") %></a>
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
