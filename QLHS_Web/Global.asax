<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>
<script RunAt="server">


    void RegisterRoutes(RouteCollection routes)
    {
        routes.Ignore("{resource}.axd/{*pathInfo}");

        routes.MapPageRoute("pagenotfound", "page-not-found", "~/PageError.aspx");

        routes.MapPageRoute("home", "", "~/Template/Default.aspx");
        //quản trị
        routes.MapPageRoute("admin", "admin", "~/Default.aspx");
        routes.MapPageRoute("danh muc di san", "{menu}-mds", "~/Template/DanhMucDiSan.aspx");
        //loại di sản
        routes.MapPageRoute("danh sách di san theo loại di sản", "{menu}-lds", "~/Template/LoaiDiSan1.aspx");

        //hoạt động văn hóa
        routes.MapPageRoute("ds hoạt động văn hóa", "{menu}-hd", "~/Template/HoatDongVanHoa.aspx");
        //hoạt động văn hóa chi tiết
        routes.MapPageRoute("tin hoạt động văn hóa", "{hoatdong}-thd", "~/Template/HoatDongVanHoaChiTiet.aspx");


        //chi tiết di sản
        routes.MapPageRoute("Chi tiết di sản", "{menu}/{disan}-ds", "~/Template/ChiTietDiSan.aspx");
        routes.MapPageRoute("Chi tiết di sản1", "{disan}-ds", "~/Template/ChiTietDiSan.aspx");

        // di vật
        routes.MapPageRoute("Danh sách di vật", "{disan}-ldv", "~/Template/DanhSachDiVat.aspx");
        routes.MapPageRoute("Chi tiết di vậtt", "{divat}-cv", "~/Template/ChiTietDiVat.aspx");

        //nghệ nhân
        routes.MapPageRoute("Danh sách nghẹ nhân", "{menu}-nn", "~/Template/DanhSachNgheNhan.aspx");
        routes.MapPageRoute("Chi tiết nghệ nhân", "{menu}/{nghenhan}-nn", "~/Template/ChiTietNgheNhan.aspx");


        //thư viện ảnh, thư viện video
        routes.MapPageRoute("Danh sách thư viện ảnh", "{menuanh}-a", "~/Template/DanhSachThuVien.aspx");
        routes.MapPageRoute("Danh sách thư viện video", "{menuvideo}-vd", "~/Template/DanhSachThuVien.aspx");
        routes.MapPageRoute("thư viện ảnh", "{menu}/{anh}-a", "~/Template/ThuVienAnh.aspx");
        routes.MapPageRoute("thư viện video", "{menu}/{video}-vd", "~/Template/ThuVienVideo.aspx");

        //danh sách bài viết
        routes.MapPageRoute("Danh sách tin tức", "{menu}-tds", "~/Template/DanhSachTin.aspx");

        //Chi tiết bài tin
        routes.MapPageRoute("Chi tiết bài viết", "{menu}/{baiviet}-tct", "~/Template/ChiTietTin.aspx");
        routes.MapPageRoute("Chi tiết menu", "{dmtin}-tct", "~/Template/ChiTietTin.aspx");

        //tim kiếm tổng hợp
        routes.MapPageRoute("tìm kiếm tổng hợp", "{menu}-tk", "~/Template/TimKiemTongHop.aspx");

        //tìm kiếm di san
        routes.MapPageRoute("tìm kiếm di sản", "{menu}-ts", "~/Template/TimKiemDiSan.aspx");

        //tìm kiếm tin tức
        routes.MapPageRoute("tìm kiếm tin tức", "{menu}-tkt", "~/Template/TimKiemTinTuc.aspx");

        //Danh sách ấn phẩm
        routes.MapPageRoute("danh sách ấn phẩm", "{menu}-ap", "~/Template/DanhSachAnPham.aspx");
        routes.MapPageRoute("chi tiet ấn phẩm", "{menu}/{anpham}-ap", "~/Template/ChiTietAnPham.aspx");

        //Báo cáo thống kê
        routes.MapPageRoute("Báo cáo thống kê", "{menu}-bc", "~/Template/BaoCaoThongKe.aspx");

        //Thủ tục hành chính
        routes.MapPageRoute("Danh sách thủ tục hành chính", "{menu}-hc", "~/Template/DanhSachThuTuc.aspx");
        routes.MapPageRoute("Thủ tục hành chính", "{menu}/{thutuc}-hc", "~/Template/ThuTucHanhChinh.aspx");

        //Danh nhân văn hóa
        routes.MapPageRoute("Danh sách danh nhân văn hóa", "{menu}-dn", "~/Template/DanhSachDanhNhan.aspx");
        routes.MapPageRoute("Danh nhân văn hóa", "{menu}/{danhnhan}-dn", "~/Template/DanhNhanVanHoa.aspx");
    }

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        //WebApiConfig.Register(System.Web.Http.GlobalConfiguration.Configuration);
        RegisterRoutes(RouteTable.Routes);
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
