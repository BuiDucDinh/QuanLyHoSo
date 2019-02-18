<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/Site.master" CodeFile="DanhSachThuVien.aspx.cs" Inherits="Template_DanhSachThuVienAnh" %>

<%@ Register Src="~/Template/Controls/RightContent.ascx" TagPrefix="uc1" TagName="RightContent" %>


<asp:Content runat="server" ContentPlaceHolderID="Navigate">
    <a href="/"><%=Resources.labels.home %></a>
    <span>> </span><%= menu.TenMenu %>
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="left-main">
        <div class="module">
            <div class="module-title">
                <a href="#" class="TitleCate" title="<%= menu.TenMenu %>">
                    <span><%= menu.TenMenu %></span>
                </a>
            </div>
            <div class="module-content">

                <div class="result" id="divs">
                    <asp:Repeater runat="server" ID="rptMedia">
                        <ItemTemplate>
                            <div class="lib-item">
                                <img src="/FileUpload/Images/<%#Eval("HinhAnh") %>" />
                                <a href="<%#Eval("Url") %>"><%#Eval("TenMediaLib") %></a>
                                <div class="cleafix"></div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div style="clear:both"></div>
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
