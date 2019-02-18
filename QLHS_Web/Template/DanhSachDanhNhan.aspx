<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/Site.master" CodeFile="DanhSachDanhNhan.aspx.cs" Inherits="Template_DanhSachThuTuc" %>


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

                <div id="divs">
                    <asp:Repeater runat="server" ID="rptTintuc">
                        <ItemTemplate>
                            <div class="new-item-search">
                                <a href="<%#Eval("url") %>" class="new-title">
                                    <h3>
                                        <%#Container.ItemIndex+1 %> :  <%#Eval("TenDanhNhan") %> <%#Eval("Thoidai") %></h3>
                                </a>
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
