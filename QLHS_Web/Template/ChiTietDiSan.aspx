<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/Site.master" CodeFile="ChiTietDiSan.aspx.cs" Inherits="Template_ChiTietDiSan" %>

<%@ Register Src="~/Template/Controls/RightContent.ascx" TagPrefix="uc1" TagName="RightContent" %>

<asp:Content runat="server" ContentPlaceHolderID="Navigate">
    <a href="/"><%=Resources.labels.home %></a>
    <span>> </span>
    <a href="/di-san-van-hoa-lds"><%=Resources.labels.dsvh %></a>
    <span>> </span>
    <a href="#"><%=ds.TenDiSan %></a>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

    <script src="/Template/js/lightbox-plus-jquery.min.js"></script>
    <link href="/Template/css/lightbox.min.css" rel="stylesheet" />
    <div class="left-main">
        <div class="module">
            <div class="module-title">
                <a href="<%=urlLoaids %>" class="TitleCate" title="<%=loaids %>">
                    <span><%=loaids %></span>
                </a>
            </div>
            <div class="module-content">

                <div class="des">
                    <div class="info">
                        <p><span class="bold"><%=Resources.labels.tendisan %> : </span><%=ds.TenDiSan %></p>
                        <p><span class="bold"><%=Resources.labels.city %> : </span><%=ds.ThuocTinh %></p>
                        <p>
                            <%
                                if (ds.LoaiDiSan == 225)
                                {%>
                            <span class="bold"><%=Resources.labels.loaiditich %> : </span>
                            <% }
                                else
                                {  %>
                            <span class="bold"><%=Resources.labels.loaidisan %> : </span>
                            <%     
                                }
                            %>

                            <%=loaids %>
                        </p>
                        <p><span class="bold"><%=Resources.labels.soquuyetdinh %> : </span><%=ds.SoDangKy %><%--<%=filequyetdinh %>--%></p>
                        <p id="danhmuc" runat="server" clientidmode="Static"><span class="bold"><%=Resources.labels.danhmucdisan %>: </span><%=ds.DanhMucDS %></p>

                        <%--<p>
                            <%
                                if (ds.LoaiDiSan == 225)
                                {%>
                            <span class="bold">I - Giới thiệu di tích </span>
                            <% }
                                else
                                {  %>
                            <span class="bold">I - Lý lịch di sản</span>
                            <%     
                                }
                            %>
                        </p>
                        <%=ds.LyLich %>
                        <p><span class="bold">II - Niên đại khởi dựng - tu bổ</span></p>
                        <%=ds.NienDai %>
                        <p><span class="bold">III - Giá trị đánh giá</span></p>
                        <%=ds.GiaTriDanhGia %>
                        <p><span class="bold">IV - Kinh phí tu bổ - bảo quản</span></p>
                        <%=ds.ChiPhiDuyTri %>

                        <p><span class="bold">V - Hiện trạng</span></p>
                        <%=ds.HienTrang %>
                        <p><span class="bold">VI - Đề xuất bảo vệ</span></p>
                        <%=ds.DeXuat %>
                        <p><span class="bold">VII - Giới thiệu</span></p>
                        <%=ds.MoTa %>--%>
                        <p><span class="bold"><%=Resources.labels.gioithieu %></span></p>
                        <%=ds.MoTa %>
                    </div>
                </div>
                <div class="cate-ds" id="divs" style="padding: 10px;">
                    <h4><%=Resources.labels.hinhanh %> <%=ds.TenDiSan %></h4>
                    <asp:Repeater runat="server" ID="rptImage">
                        <HeaderTemplate>
                            <a class="example-image-link" href="/FileUpload/images/IMG_0009.jpg" data-lightbox="example-1" data-title=""><%=Resources.labels.xemtatca %></a>
                            <div class="clearfix"></div>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="image_chitiet_home">
                                <div class="image_chitiet_home_image">
                                    <a class="example-image-link" href="/FileUpload/images/<%#Eval("TenAnh") %>" data-lightbox="example-1" data-title="<%=ds.TenDiSan %>">
                                        <img class="example-image" src="/FileUpload/images/<%#Eval("TenAnh") %>" alt="image-1" /></a>
                                </div>
                            </div>
                            <%-- <div class="<%# (Container.ItemIndex+1)%3==0?"clearfix":""%>"></div>--%>
                        </ItemTemplate>
                        <FooterTemplate>
                            <div class="clearfix"></div>
                            <div id="pagination"></div>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <%--  <div class="doc" style="padding: 10px;">
                    <asp:Repeater runat="server" ID="rptDoc">
                        <HeaderTemplate>
                            <h4>Tài liệu của di sản</h4>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <p><%#Eval("TenTaiLieu") %><a href="/FileUpload/Document/<%#Eval("File") %>"><i class="fa fa-download"></i></a></p>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>--%>
                <%--<div class="span12">
                    <div id="sync1" class="owl-carousel">
                        <asp:Repeater runat="server" ID="rptImage2">
                            <ItemTemplate>
                                <div class="item">
                                    <img src="/FileUpload/images/<%#Eval("TenAnh") %>" />
                                   
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                    <div style="border-radius: 5px; margin-bottom: 0;">
                        <div id="sync2" class="owl-carousel">
                            <asp:Repeater runat="server" ID="rptImage">
                                <ItemTemplate>
                                    <div class="item">
                                        <img src="/FileUpload/images/<%#Eval("TenAnh") %>" />
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>--%>
                <asp:Repeater runat="server" ID="rptDiVat">
                    <HeaderTemplate>
                        <div class="more-link" style="padding: 10px;">
                            <h4><%=Resources.labels.divatcuadisan %></h4>
                            <ul class="list-dv clearfix">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <a href="<%#Eval("url") %>"><%#Eval("Ten") %></a>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
                <div class="image">
                    <img src="/FileUpload/Images/<%=ds.TenAnhBanDo %>" alt="<%=ds.TenDiSan %>" style="width: 100%;" />
                </div>
                <%--<iframe src="/Template/Controls/Map.aspx?id=<%=ds.DiSanID %>" style="margin: 10px 0 10px 10px; width: 100%; border: 2px solid" class="map"></iframe>--%>

                <asp:Repeater runat="server" ID="rptImageLib">
                    <HeaderTemplate>
                        <div class="more-link">
                            <h4><%=Resources.labels.albumanh %> <%=ds.TenDiSan %></h4>
                            <div id="owl-images" class="owl-carousel">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="item">
                            <img src="/FileUpload/Images/<%#Eval("HinhAnh") %>" />
                            <a href="<%#Eval("Url") %>"><%#Eval("TenMediaLib") %></a>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        </div>
                   <%-- <div class="customNavigation">
                        <a class="btn prev">Previous</a>
                        <a class="btn next">Next</a>
                        <a class="btn play">Autoplay</a>
                        <a class="btn stop">Stop</a>
                    </div>--%>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:Repeater runat="server" ID="rptOrther">
                    <HeaderTemplate>
                        <div class="more-link">
                            <h4><%=Resources.labels.tintuclienquan %></h4>
                            <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <a href="<%#Eval("url") %>"><%#Eval("TieuDe") %></a>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
    <div class="right-main">
        <uc1:RightContent runat="server" ID="RightContent" />
    </div>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ScriptContent">
    <link href="/Template/css/smartpaginator.css" rel="stylesheet" />
    <script src="/Template/js/smartpaginator.js"></script>
    <script type="text/javascript">
        var totalrow = $("#divs .image_chitiet_home").length;
        var size = 9;
        $('#pagination').smartpaginator({ totalrecords: totalrow, recordsperpage: size, lenght: 4, datacontainer: 'divs', dataelement: '.image_chitiet_home', initval: 0, next: 'Next', prev: 'Prev', first: 'First', last: 'Last', theme: 'black' });
    </script>
</asp:Content>
