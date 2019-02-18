<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/Site.master" CodeFile="DanhSachTin.aspx.cs" Inherits="Template_DanhSachTin" %>

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

                <div class="result" id="divs">
                    <asp:Repeater runat="server" ID="rptTintuc">
                        <ItemTemplate>
                            <div class="new-item-search">
                                <div class="left-new">
                                    <a href="<%#Eval("url") %>">
                                        <img src="/FileUpload/Images/<%#Eval("HinhAnh") %>" />
                                    </a>
                                </div>
                                <div class="right-new">
                                    <a href="<%#Eval("url") %>" class="new-title">
                                        <h3><%#Eval("TieuDe") %></h3>
                                    </a>
                                    <p class="new-description">
                                        <%#Eval("GioiThieu") %>
                                    </p>
                                </div>
                                <div class="clearfix"></div>
                            </div>

                        </ItemTemplate>
                    </asp:Repeater>
                </div>

                <div id="pagination"></div>
                <script type="text/javascript">
                    $(document).ready(function () {
                        var totalrow = $("#divs .new-item-search").length;
                        $('#pagination').smartpaginator({ totalrecords: totalrow, recordsperpage: 10, lenght: 4, datacontainer: 'divs', dataelement: '.new-item-search', initval: 0, next: 'Next', prev: 'Prev', first: 'First', last: 'Last', theme: 'black' });
                    });
                </script>
            </div>
        </div>
    </div><div class="right-main">
        <uc1:RightContent runat="server" ID="RightContent" />
    </div>
</asp:Content>
