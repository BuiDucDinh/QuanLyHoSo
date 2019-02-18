<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/Site.master" CodeFile="ChiTietDiVat.aspx.cs" Inherits="Template_ChiTietDiSan" %>

<%@ Register Src="~/Template/Controls/RightContent.ascx" TagPrefix="uc1" TagName="RightContent" %>


<asp:Content runat="server" ContentPlaceHolderID="Navigate">
    <a href="/"><%=Resources.labels.home %></a>
    <span>> </span>
    <a href="/Di-vat,-co-vat,-bao-vat-quoc-gia-ldv"><%=Resources.labels.divatcovat %></a>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <link href="/Template/css/lightbox.min.css" rel="stylesheet" />
    <script src="/Template/js/lightbox-plus-jquery.min.js"></script>
    <script src="/Template/js/smartpaginator.js"></script>
    <div class="left-main">
        <div class="module">
            <div class="module-title">
                <a href="/Di-vat,-co-vat,-bao-vat-quoc-gia-ldv" class="TitleCate" title="<%=Resources.labels.divatcovat %>">
                    <span><%=Resources.labels.divatcovat %></span>
                </a>
            </div>
            <div class="module-content">

                <div class="des">
                    <div class="info">
                        <p><span class="bold"><%=Resources.labels.tendivat %> : </span><%= dv.TenKhac!=""?dv.Ten+" - "+dv.TenKhac:dv.Ten %></p>
                        <p><span class="bold"><%=Resources.labels.noiluutru %> : </span><%=dv.DiSan+dv.BaoTang %></p>
                        <p><span class="bold"><%=Resources.labels.loaids %> : </span><%=dv.TenLoai %></p>
                    </div>
                </div>
                <div class="new-details">
                    <%=dv.GioiThieu %>
                </div>
                <asp:Repeater runat="server" ID="rptImage">
                    <HeaderTemplate>
                        <div>
                            <h4><%=Resources.labels.hinhanh %> <%=dv.Ten %></h4>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="image_chitiet_home" style="width: 50%;">
                            <div class="image_chitiet_home_image" style="width: 100%; height: 220px;">
                                <a class="example-image-link" href="/FileUpload/images/<%#Eval("TenAnh") %>" data-lightbox="example-1" data-title="<%=dv.Ten %>">
                                    <img class="example-image" src="/FileUpload/images/<%#Eval("TenAnh") %>" alt="image-1" /></a>
                            </div>
                        </div>
                        <div class="<%# (Container.ItemIndex+1)%3==0?"clearfix":""%>"></div>
                    </ItemTemplate>
                    <FooterTemplate>
                        <div class="clearfix"></div>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:Repeater runat="server" ID="rptDiVat">
                    <HeaderTemplate>
                        <div class="module-content" id="divs">
                            <h4><%=Resources.labels.divatlienquan %></h4>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="image_chitiet_home">
                            <div class="image_chitiet_home_image">
                                <a href="<%#Eval("url") %>">
                                    <img class="example-image" src="/FileUpload/images/<%#Eval("TenAnh") %>" alt="image-1" /></a>
                            </div>
                            <div class="info">
                                <p><span class="bold"><%=Resources.labels.tendivat %> : </span><%#Eval("Ten") %> <%#" - "+Eval("TenKhac") %></p>
                                <p><span class="bold"><%=Resources.labels.noiluutru %>Nơi lưu trữ : </span><%#Eval("DiSan") %><%#Eval("BaoTang") %></p>
                                <p><span class="bold"><%=Resources.labels.loaids %>Loại : </span><%#Eval("TenLoai") %></p>
                            </div>
                        </div>
                        <%-- <div class="new block-cate">
                            <a href="<%#Eval("url") %>">
                                <img src="/FileUpload/images/<%#Eval("TenAnh") %>" class="img-responsive home-img" style="height: 235px;" />
                            </a>
                            <div class="info">
                                <p><span class="bold">Tên di sản : </span><%#Eval("Ten") %> <%#" - "+Eval("TenKhac") %></p>
                                <p><span class="bold">Nơi lưu trữ : </span><%#Eval("DiSan") %><%#Eval("BaoTang") %></p>
                                <p><span class="bold">Loại : </span><%#Eval("TenLoai") %></p>
                            </div>
                        </div>--%>
                        <div class="<%# (Container.ItemIndex+1)%3==0?"clearfix":""%>"></div>
                    </ItemTemplate>
                    <FooterTemplate>

                        <div class="clearfix"></div>
                        <div id="pagination"></div>
                        </div>

                    </FooterTemplate>
                </asp:Repeater>

                <script type="text/javascript">
                    $(document).ready(function () {
                        var totalrow = $("#divs .image_chitiet_home").length;
                        var size = 9;
                        $('#pagination').smartpaginator({ totalrecords: totalrow, recordsperpage: size, lenght: 4, datacontainer: 'divs', dataelement: '.image_chitiet_home', initval: 0, next: 'Next', prev: 'Prev', first: 'First', last: 'Last', theme: 'black' });
                    });
                </script>
            </div>
        </div>
    </div>
    <div class="right-main">
        <uc1:RightContent runat="server" ID="RightContent" />
    </div>
</asp:Content>
