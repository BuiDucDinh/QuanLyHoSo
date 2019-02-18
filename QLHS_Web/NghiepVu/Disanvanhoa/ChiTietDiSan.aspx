<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChiTietDiSan.aspx.cs" Inherits="Template_ChiTietDiSan" %>


<!DOCTYPE html>

<html lang="vi" class="">
<head runat="server">
    <title></title>
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,400,600,600i,700" rel="stylesheet">

    <script src="/Template/js/jquery-2.0.3.min.js"></script>
    <script src="/Template/js/json2.min.js"></script>
    <script src="/Template/js/owl.carousel.min.js"></script>
    <script src="/Template/js/smartpaginator.js"></script>
    <style media="print">
 @page {
   display: inline;
  size: auto;
  margin: 1.27cm 1.27cm;
       }
</style>
    <script>
        function printContent(el) {
            $(".doc").css("display", "none");	   
            var restorepage = $('body').html();
            var printcontent = $('#' + el).clone();
            $('body').empty().html(printcontent);
            document.title = "PHẦN MỀM QUẢN LÝ DI SẢN VĂN HÓA";
            window.print();
            $('body').html(restorepage);
        }
    </script>
</head>
<body>

    <form runat="server" style="padding-top: 0px;">
	<div class="btn-print" style="padding-left: 0px;">
	   <button id="print" onclick="printContent('Print-Id');" >Print</button>
	</div>        
        <div class="page">
            <div class="content" style="max-width: 100%;" id="Print-Id">
                <div class="content-body" style="background: #fff; padding-bottom: 5px;">

                    <div class="list-module">
                        <div class="module">
                            <div class="module-content">

                                <div class="des">
                                    <div class="info">
                                        <p style="font-weight: bold;font-size: 18px;"><span class="bold">Tên di sản : </span><%=ds.TenDiSan %></p>
                                        <p><span class="bold">Tỉnh/Thành phố : </span><%=ds.DiaDiem %></p>
                                        <p><span class="bold">Loại di sản : </span><%=loaids %></p>
                                        <p><span class="bold">Sô quyết định : </span><%=ds.SoDangKy %></p>
                                        <p id="danhmuc" runat="server" clientidmode="Static"><span class="bold">Danh mục di sản : </span><%=ds.DanhMucDS %></p>

                                        <p><span class="bold">I - Lý lịch di sản</span></p>
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
                                    </div>
                                </div>                                
                                <div class="new-details">  
                                    <p><span class="bold" style="color: #0e7cb2;font-weight: bold;font-size: 14px;">VII - Giới thiệu</span></p>                                 
                                    <%=ds.MoTa %>
                                </div>
                                <div class="cate-ds" id="divs" style="padding: 10px;">
                                    <h4>Hình ảnh <%=ds.TenDiSan %></h4>
                                    <asp:Repeater runat="server" ID="rptImage">
                                        <HeaderTemplate>
                                            <a class="example-image-link" href="/FileUpload/images/<%=ds.HinhAnh %>" data-lightbox="example-1" data-title="Đền thờ Lê Đình Châu">Xem tất cả</a>
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
                                <div class="doc" style="padding: 10px;">
                                    <asp:Repeater runat="server" ID="rptDoc">
                                        <HeaderTemplate>
                                            <h4>Tài liệu liên quan</h4>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%--<p><%#Eval("TenTaiLieu") %><a href="/FileUpload/Document/<%#Eval("LinkFile") %>"><i class="fa fa-download"></i></a></p>--%>
                                            <iframe src="http://docs.google.com/gview?url=http://dsvh.tcsoft.vn/FileUpload/Document/<%#Eval("LinkFile") %>&embedded=true" style="width:100%; height:450px;" frameborder="0"></iframe>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <asp:Repeater runat="server" ID="rptDiVat">
                                    <HeaderTemplate>
                                        <div class="more-link" style="padding: 10px;">
                                            <h4>Di vật, cổ vật liên quan</h4>
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
                                <%-- <iframe src="/Template/Controls/Map.aspx?id=<%=ds.DiSanID %>" style="margin: 10px 0 10px 10px; width: 100%; border: 2px solid" class="map"></iframe>--%>

                                <asp:Repeater runat="server" ID="rptImageLib">
                                    <HeaderTemplate>
                                        <div class="more-link">
                                            <h4>Album ảnh <%=ds.TenDiSan %></h4>
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
                        </div>
                                    </FooterTemplate>
                                </asp:Repeater>
                                <asp:Repeater runat="server" ID="rptOrther">
                                    <HeaderTemplate>
                                        <div class="more-link">
                                            <h4>Tin tức liên quan</h4>
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
                </div>
            </div>
        </div>

        <link href="/Template/css/bootstrap-modal.css" rel="stylesheet" type="text/css">
        <link href="/Template/css/font-awesome-4.6.3/css/font-awesome.min.css" rel="stylesheet" />
        <link href="/Template/css/css.css" rel="stylesheet" type="text/css">
        <link href="/Template/css/smartpaginator.css" rel="stylesheet" />

        <link href="/Template/dist/css/Style.css" rel="stylesheet" />
        <!-- SCRIPT -->
        <script src="/Template/js/bootstrap.min.js"></script>
        <script src="/Template/js/owl.carousel.min.js"></script>


        <script src="/Template/js/common.js" type="text/javascript"></script>

        <script src="/Template/js/main.js" type="text/javascript"></script>

    </form>
</body>
</html>
