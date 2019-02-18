<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/Site.master" CodeFile="ThuVienVideo.aspx.cs" Inherits="Template_ThuVienVideo" %>

<%@ Register Src="~/Template/Controls/RightContent.ascx" TagPrefix="uc1" TagName="RightContent" %>


<asp:Content runat="server" ContentPlaceHolderID="Navigate">
    <a href="/"><%=Resources.labels.home %></a>
    <span>> </span>
    <a href="<%=menu.UrlFull %>"><%=menu.TenMenu %></a>
    <span>> </span>
    <a href="#"><%=lib.TenMediaLib %></a>
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
                <div>
                    <%=lib.MoTa %>
                </div>
                <asp:Repeater runat="server" ID="rptVideo">
                    <ItemTemplate>
                        <div class="box-content" style="text-align: center;">
                            <video width="600" controls poster="/FileUpload/Images/<%#Eval("HinhAnh") %>">
                                <source src="<%#"http://"+HttpContext.Current.Request.Url.Host +"/FileUpload/Video/"+Eval("FileUpload") %>" type="video/mp4">
                                <source src="<%#"http://"+HttpContext.Current.Request.Url.Host +"/FileUpload/Video/"+Eval("FileUpload") %>" type="video/ogg">
                                Your browser does not support HTML5 video.
                            </video>
                            <div class="cleafix"></div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                <div class="clearfix"></div>
                <asp:Repeater runat="server" ID="rptOrther">
                    <HeaderTemplate>
                        <div class="more-link">
                            <h4><%=Resources.labels.otheralbum %></h4>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="lib-item">
                            <img src="/FileUpload/Images/<%#Eval("HinhAnh") %>" />
                            <a href="<%#Eval("Url") %>"><%#Eval("TenMediaLib") %></a>
                            <div class="cleafix"></div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div><div class="right-main">
        <uc1:RightContent runat="server" ID="RightContent" />
    </div>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ScriptContent">
    <link href="/Template/css/lightbox.min.css" rel="stylesheet" />
    <script src="/Template/js/lightbox-plus-jquery.min.js"></script>
</asp:Content>
