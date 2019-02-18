<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChiTietNgheNhan.aspx.cs" Inherits="Template_ChiTietDiVat" %>


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
                                        <p><span class="bold">Tên nghệ nhân : </span><%=nghenhan.HoTen %></p>
                                        <p><span class="bold">Tên gọi khác : </span><%=nghenhan.TenKhac %></p>
                                        <p><span class="bold">Ngày sinh : </span><%=nghenhan.NgaySinh %></p>
                                        <p><span class="bold">Dân tộc : </span><%=nghenhan.TenDanToc %></p>

                                        <p><span class="bold">Danh hiệu nghệ nhân : </span><%=nghenhan.TenDanhHieu %></p>
                                        <p><span class="bold">Ngày cấp : </span><%=nghenhan.NgayCap %></p>
                                        <p><span class="bold">Loại di sản : </span><%=nghenhan.TenLoaiDS %></p>
                                        <p><span class="bold">Di sản nắm giữ : </span><%=nghenhan.TenDiSan %></p>
                                        <p><span class="bold">Năm bắt đầu thực hiện : </span><%=nghenhan.NamBatDau %></p>
                                        <p><span class="bold">Điện thoại cố định : </span><%=nghenhan.DienThoai %></p>
                                        <p><span class="bold">Điện thoại di động : </span><%=nghenhan.DiDong %></p>

                                        <p><span class="bold">Nguyên quán : </span><%=nghenhan.NguyenQuan %></p>
                                        <p><span class="bold">Hộ khẩu thường trú : </span><%=nghenhan.HoKhauThuongTru %></p>
                                        <p><span class="bold">Địa chỉ : </span><%=nghenhan.DiaChi %></p>
                                        <p><span class="bold">Quá trình thực hiện di sản : </span></p>
                                        <div class="new-details">
                                            <%=nghenhan.QuaTrinh %>
                                        </div>
                                        <p><span class="bold">Tri thức và kỹ năng đang nắm giữ : </span></p>
                                        <div class="new-details">
                                            <%=nghenhan.TriThucKyNang %>
                                        </div>
                                        <p><span class="bold">Thành tích, khen thưởng : </span></p>
                                        <div class="new-details">
                                            <%=nghenhan.KhenThuong %>
                                        </div>
                                        <p><span class="bold">Kỷ luật : </span></p>
                                        <div class="new-details">
                                            <%=nghenhan.KyLuat %>
                                        </div>
                                        <p><span class="bold">Giới thiệu về nghệ nhân : </span></p>
                                        <div class="new-details">
                                            <%=nghenhan.GioiThieu %>
                                        </div>
                                    </div>
                                </div>

                                <div class="cate-ds" id="divs" style="padding: 10px;">
                                    <h4>Hình ảnh <%=nghenhan.HoTen %></h4>
                                    <div class="image_chitiet_home">
                                        <div class="image_chitiet_home_image">
                                            <img class="example-image" src="/FileUpload/images/<%=nghenhan.HinhAnh %>" alt="image-1" />
                                        </div>
                                    </div>
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
