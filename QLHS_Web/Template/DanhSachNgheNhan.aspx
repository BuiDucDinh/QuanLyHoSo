<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/Site.master" CodeFile="DanhSachNgheNhan.aspx.cs" Inherits="Template_DanhSachNgheNhan" %>

<%@ Register Src="~/Template/Controls/RightContent.ascx" TagPrefix="uc1" TagName="RightContent" %>


<asp:Content runat="server" ContentPlaceHolderID="Navigate">
    <a href="/"><%=Resources.labels.home %></a>
    <span>> </span>
    <a href="#"><%=menu.TenMenu %></a>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="left-main">
        <div class="module">
            <div class="module-title">
                <a href="#" class="TitleCate" title="<%=menu.TenMenu %>">
                    <span><%=menu.TenMenu %></span>
                </a>
            </div>
            <div class="module-content">
                <div class="result" id="divs">
                    <asp:Repeater runat="server" ID="rptTintuc">
                        <ItemTemplate>
                            <div class="new-item-search">
                                <div class="left-new">
                                    <a href="<%#Eval("UrlFull") %>">
                                        <img src="/FileUpload/Images/<%#Eval("AnhDaiDien") %>" />
                                    </a>
                                </div>
                                <div class="right-new">
                                    <a href="<%#Eval("UrlFull") %>" class="new-title">
                                        <h3><%#Eval("HoTen") %> <%#Eval("TenKhac") %></h3>
                                    </a>
                                    <p><%=Resources.labels.danhhieu %> : <%#Eval("TenDanhHieu") %></p>
                                    <p><%=Resources.labels.ngaynhandh %> : <%#DataBinder.Eval(Container.DataItem, "NgayCap", "{0:d/M/yyyy}")%></p>
                                    <p><%=Resources.labels.ngaysinh %> : <%#DataBinder.Eval(Container.DataItem, "Ngaysinh", "{0:d/M/yyyy}")%></p>
                                    <p><%=Resources.labels.dantoc %> : <%#Eval("TenDanToc") %></p>
                                    <p><%=Resources.labels.diachi %> : <%#Eval("DiaChi") %></p>
                                </div>
                                <div class="clearfix"></div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div id="pagination"></div>
                

            <script type="text/javascript">
                var totalrow = $("#divs .new-item-search").length;
                var size = 15;
                $('#pagination').smartpaginator({ totalrecords: totalrow, recordsperpage: size, lenght: 4, datacontainer: 'divs', dataelement: '.new-item-search', initval: 0, next: 'Next', prev: 'Prev', first: 'First', last: 'Last', theme: 'black' });
            </script>
            </div>
        </div>
    </div><div class="right-main">
        <uc1:RightContent runat="server" ID="RightContent" />
    </div>
</asp:Content>
