<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChiTietDiVat.aspx.cs" Inherits="Template_ChiTietDiVat" %>


<!DOCTYPE html>

<html lang="vi" class="">
<head runat="server">
    <title></title>
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,400,600,600i,700" rel="stylesheet">

    <script src="/Template/js/jquery-2.0.3.min.js"></script>
    <script src="/Template/js/json2.min.js"></script>
    <script src="/Template/js/owl.carousel.min.js"></script>
    <script src="/Template/js/smartpaginator.js"></script>
</head>
<body>
    <form runat="server">
        <div class="page">
            <div class="content" style="max-width: 100%;">
                <div class="content-body" style="background: #fff; padding-bottom: 5px;">

                    <div class="list-module">
                        <div class="module">
                            <div class="module-content">

                                <div class="des">
                                    <div class="info">
                                        <p><span class="bold">Tên di vật : </span><%=dv.Ten %></p>
                                        <p><span class="bold">Tên khác : </span><%=dv.TenKhac %></p>
                                        <p><span class="bold">Nơi lưu trữ : </span><%=dv.IsMuseum?dv.BaoTang:dv.DiSan %></p>
                                        <p><span class="bold">Loại : </span><%=dv.TenLoai %></p>
                                        <p><span class="bold">Mã số : </span><%=dv.MaSo %></p>
                                        <p><span class="bold">Nguồn gốc : </span><%=dv.NguonGoc %></p>
                                        <p><span class="bold">Địa điểm phát hiện di vật : </span><%=dv.DiaDiemPhatHien %></p>
                                        <p><span class="bold">Số lượng : </span><%=dv.SoLuong %></p>
                                        <p><span class="bold">Thành phần hợp thành : </span><%=dv.ThanhPhanHopThanh %></p>
                                        <p><span class="bold">Kích thước, trọng lượng : </span><%=dv.KichThuocTrongLuong %></p>
                                        <p><span class="bold">Chất liệu : </span><%=dv.ChatLieu %></p>
                                        <p><span class="bold">Tình trạng : </span><%=dv.TinhTrang %></p>
                                        <p><span class="bold">Miên tả hiện vật : </span><%=dv.MieuTaHienVat %></p>
                                        <p><span class="bold">Dấu tích đặc biệt : </span><%=dv.DauTichDacBiet %></p>
                                        <div class="new-details">
                                            <p><span class="bold">Giới thiệu di vật : </span></p>
                                            <%=dv.GioiThieu %>
                                        </div>
                                    </div>
                                </div>

                                <div class="cate-ds" id="divs" style="padding: 10px;">
                                    <h4>Hình ảnh <%=dv.Ten %></h4>
                                    <asp:Repeater runat="server" ID="rptImage">
                                        <HeaderTemplate>
                                            <a class="example-image-link" href="/FileUpload/images/<%=dv.TenAnh %>" data-lightbox="example-1" data-title="Đền thờ Lê Đình Châu">Xem tất cả</a>
                                            <div class="clearfix"></div>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="image_chitiet_home">
                                                <div class="image_chitiet_home_image">
                                                    <a class="example-image-link" href="/FileUpload/images/<%#Eval("TenAnh") %>" data-lightbox="example-1" data-title="<%=dv.Ten %>">
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
                                            <p><%#Eval("TenTaiLieu") %><a href="/FileUpload/Document/<%#Eval("TenTaiLieu") %>"><i class="fa fa-download"></i></a></p>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
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
