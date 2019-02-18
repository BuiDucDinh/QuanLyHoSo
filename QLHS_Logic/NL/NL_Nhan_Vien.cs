using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region NL_Nhan_Vien_Details
    public class NL_Nhan_Vien_Chi_Tiet
    {
        public int? Ma_Nhan_Vien = null; // Mã nhân viên
        public string Ho_Ten_Dem = null;//Họ và tên đệm
        public string Ten_Nhan_Vien = null; // Tên nhân viên

        public string So_Hieu = null; // Số hiệu
        public string Ma_Ho_So = null; // Mã hồ sơ(Chương trình tự động tạo mã theo triger)
        public string Ten_Thuong_Dung = null; // Tên thường dùng
        public string Bi_Danh = null; // Bí danh
        public bool Gioi_Tinh; // Giới tính
        public DateTime? Ngay_Sinh = null; // Ngày sinh
        public string Ma_Dan_Toc = null;
        public string Ton_Giao = null; // Tôn giáo
        public string Noi_Sinh = null; // Nơi sinh
        public string Que_Quan = null; // Quê quán
        public string Thuong_Tru = null; // Thường trú
        public string Noi_O = null; // Nơi ở
        public string Nghe_Nghiep_Khi_Tuyen_Dung = null; // Nghề nghiệp khi tuyển dụng
        public DateTime? Ngay_Tuyen_Dung = null; // Ngày tuyển dụng
        public string Co_Quan_Tuyen_Dung = null; // Cơ quan tuyển dụng
        public string Cong_Viec_Chinh = null; // Công việc chính
        public string So_CMND = null; // Số CMND
        public DateTime? Ngay_CMND = null; // Ngày CMND
        public string Noi_CMND = null; // Nơi CMND
        public string Thanh_Phan = null; // Thành phần
        public string Trinh_Do_Giao_Duc_Pho_Thong = null; // Trình độ giáo dục phổ thông
        public DateTime? Ngay_Bat_Dau = null; // Ngày bắt đầu vào làm việc 
        public DateTime? Ngay_Vao_Co_Quan = null; // Ngày vào cơ quan
        public DateTime? Ngay_Vao_Doan = null; // Ngày vào đoàn
        public string Noi_Vao_Doan = null; // Nơi vào đoàn
        public DateTime? Ngay_Vao_Dang = null; // Ngày vào đảng
        public DateTime? Ngay_Vao_Dang_Chinh_Thuc = null; // Ngày vào đảng chính thức
        public string Noi_Vao_Dang = null; // Nơi vào đảng
        public DateTime? Ngay_Khai_Tru_Dang = null; // Ngày khai trừ đảng (nếu có)
        public DateTime? Ngay_Nhap_Ngu = null; // Ngày nhập ngũ (nếu có)
        public DateTime? Ngay_Xuat_Ngu = null; // Ngày xuất ngũ (nếu có)
        public string Ly_Do_Xuat_Ngu = null; // Lý do xuất ngũ
        public string Quan_Ham_Cao_Nhat = null; // Quân hàm cao nhất
        public bool? La_Quan_Nhan = null; // Là quân nhân
        public string Danh_Hieu_Cao_Nhat = null; // Danh hiệu cao nhất
        public DateTime? Ngay_TGCM = null; // Ngày tham gia cách mạng
        public string Dien_Thoai = null; // Điện thoại
        public string So_Truong = null; // Sở trường
        public string Suc_Khoe = null; // Tình trạng sức khỏe
        public string Man_Tinh = null; // Mãn tính
        public decimal? Cao = null; // Cao (cm)
        public decimal? Nang = null; // Nặng (kg)
        public string Nhom_Mau = null; // Nhóm máu
        public bool? La_Thuong_Binh = null; // Là thương binh
        public string Hang_Thuong_Binh = null; // Thương binh hạng
        public int? Con_Gia_Dinh_Chinh_Sach = null; // 0:Con thương binh;1:con liệt sĩ;2:người nhiễm chất đọc da cam Dioxin
        public string Ma_So_So_BHXH = null; // Mã số sổ BHXH
        public string So_So_BHXH = null; // Số sổ BHXH
        public string So_So_Lao_Dong = null; // Số sổ lao động
        public DateTime? Ngay_Nghi_Viec = null; // Ngày nghỉ việc
        public string Ghi_Chu = null; // Ghi chú
        public int? Ma_Phong = null; // Mã phòng ban
        public int? Ma_Chinh_Tri = null; // Mã chính trị
        public int? Ma_Linh_Vuc = null; // Mã lĩnh vực
        public int? Ma_QL_Nha_Nuoc = null; // Mã quản lý nhà nước
        public int? Ma_Tin_Hoc = null; // Mã tin học
        public int? Ma_Ngoai_Ngu = null; // Mã ngoại ngữ
        public string Ma_Ngach = null; // Mã ngạch
        public string Hinh_Anh = null; // Hình ảnh
        public int? Ma_Chuc_Danh = null; // Mã chức danh
        public int? Ma_Chuyen_Mon = null; // Mã chuyên môn
        public int? Ma_Chuc_Vu = null; // Mã chức vụ
        public bool? Tieng_Dan_Toc = null; // Tiếng dân tộc
    }
    #endregion
    #region NL_Nhan_Vien
    public class NL_Nhan_Vien
    {
        private string ConnectionString;
        public NL_Nhan_Vien(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_Nhan_Vien_Chi_Tiet Lay(int Ma_Nhan_Vien)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Nhan_Vien_Chi_Tiet");
                    NL_Nhan_Vien_Chi_Tiet myNL_Nhan_Vien_Chi_Tiet = new NL_Nhan_Vien_Chi_Tiet();
                    if (myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"] != null)
                    {
                        myNL_Nhan_Vien_Chi_Tiet.Ma_Nhan_Vien = Ma_Nhan_Vien;
                        myNL_Nhan_Vien_Chi_Tiet.Ho_Ten_Dem = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ho_Ten_Dem"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ho_Ten_Dem"] : (string)null;

                        myNL_Nhan_Vien_Chi_Tiet.Ten_Nhan_Vien = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ten_Nhan_Vien"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ten_Nhan_Vien"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.So_Hieu = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["So_Hieu"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["So_Hieu"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.Ma_Ho_So = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ma_Ho_So"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ma_Ho_So"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.Ten_Thuong_Dung = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ten_Thuong_Dung"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ten_Thuong_Dung"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.Bi_Danh = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Bi_Danh"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Bi_Danh"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.Gioi_Tinh = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Gioi_Tinh"] != DBNull.Value ? (bool)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Gioi_Tinh"] : false;
                        myNL_Nhan_Vien_Chi_Tiet.Ngay_Sinh = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ngay_Sinh"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ngay_Sinh"] : (DateTime?)null;
                        myNL_Nhan_Vien_Chi_Tiet.Ma_Dan_Toc = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ma_Dan_Toc"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ma_Dan_Toc"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.Ton_Giao = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ton_Giao"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ton_Giao"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.Noi_Sinh = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Noi_Sinh"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Noi_Sinh"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.Que_Quan = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Que_Quan"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Que_Quan"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.Thuong_Tru = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Thuong_Tru"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Thuong_Tru"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.Noi_O = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Noi_O"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Noi_O"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.Nghe_Nghiep_Khi_Tuyen_Dung = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Nghe_Nghiep_Khi_Tuyen_Dung"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Nghe_Nghiep_Khi_Tuyen_Dung"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.Ngay_Tuyen_Dung = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ngay_Tuyen_Dung"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ngay_Tuyen_Dung"] : (DateTime?)null;
                        myNL_Nhan_Vien_Chi_Tiet.Co_Quan_Tuyen_Dung = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Co_Quan_Tuyen_Dung"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Co_Quan_Tuyen_Dung"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.Cong_Viec_Chinh = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Cong_Viec_Chinh"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Cong_Viec_Chinh"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.So_CMND = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["So_CMND"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["So_CMND"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.Ngay_CMND = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ngay_CMND"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ngay_CMND"] : (DateTime?)null;
                        myNL_Nhan_Vien_Chi_Tiet.Noi_CMND = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Noi_CMND"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Noi_CMND"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.Thanh_Phan = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Thanh_Phan"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Thanh_Phan"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.Trinh_Do_Giao_Duc_Pho_Thong = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Trinh_Do_Giao_Duc_Pho_Thong"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Trinh_Do_Giao_Duc_Pho_Thong"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.Ngay_Bat_Dau = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ngay_Bat_Dau"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ngay_Bat_Dau"] : (DateTime?)null;
                        myNL_Nhan_Vien_Chi_Tiet.Ngay_Vao_Co_Quan = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ngay_Vao_Co_Quan"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ngay_Vao_Co_Quan"] : (DateTime?)null;
                        myNL_Nhan_Vien_Chi_Tiet.Ngay_Vao_Doan = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ngay_Vao_Doan"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ngay_Vao_Doan"] : (DateTime?)null;
                        myNL_Nhan_Vien_Chi_Tiet.Noi_Vao_Doan = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Noi_Vao_Doan"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Noi_Vao_Doan"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.Ngay_Vao_Dang = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ngay_Vao_Dang"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ngay_Vao_Dang"] : (DateTime?)null;
                        myNL_Nhan_Vien_Chi_Tiet.Ngay_Vao_Dang_Chinh_Thuc = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ngay_Vao_Dang_Chinh_Thuc"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ngay_Vao_Dang_Chinh_Thuc"] : (DateTime?)null;
                        myNL_Nhan_Vien_Chi_Tiet.Noi_Vao_Dang = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Noi_Vao_Dang"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Noi_Vao_Dang"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.Ngay_Khai_Tru_Dang = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ngay_Khai_Tru_Dang"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ngay_Khai_Tru_Dang"] : (DateTime?)null;
                        myNL_Nhan_Vien_Chi_Tiet.Ngay_Nhap_Ngu = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ngay_Nhap_Ngu"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ngay_Nhap_Ngu"] : (DateTime?)null;
                        myNL_Nhan_Vien_Chi_Tiet.Ngay_Xuat_Ngu = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ngay_Xuat_Ngu"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ngay_Xuat_Ngu"] : (DateTime?)null;
                        myNL_Nhan_Vien_Chi_Tiet.Ly_Do_Xuat_Ngu = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ly_Do_Xuat_Ngu"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ly_Do_Xuat_Ngu"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.Quan_Ham_Cao_Nhat = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Quan_Ham_Cao_Nhat"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Quan_Ham_Cao_Nhat"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.La_Quan_Nhan = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["La_Quan_Nhan"] != DBNull.Value ? (bool?)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["La_Quan_Nhan"] : (bool?)null;
                        myNL_Nhan_Vien_Chi_Tiet.Danh_Hieu_Cao_Nhat = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Danh_Hieu_Cao_Nhat"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Danh_Hieu_Cao_Nhat"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.Ngay_TGCM = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ngay_TGCM"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ngay_TGCM"] : (DateTime?)null;
                        myNL_Nhan_Vien_Chi_Tiet.Dien_Thoai = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Dien_Thoai"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Dien_Thoai"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.So_Truong = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["So_Truong"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["So_Truong"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.Suc_Khoe = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Suc_Khoe"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Suc_Khoe"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.Man_Tinh = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Man_Tinh"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Man_Tinh"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.Cao = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Cao"] != DBNull.Value ? (decimal?)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Cao"] : (decimal?)null;
                        myNL_Nhan_Vien_Chi_Tiet.Nang = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Nang"] != DBNull.Value ? (decimal?)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Nang"] : (decimal?)null;
                        myNL_Nhan_Vien_Chi_Tiet.Nhom_Mau = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Nhom_Mau"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Nhom_Mau"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.La_Thuong_Binh = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["La_Thuong_Binh"] != DBNull.Value ? (bool?)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["La_Thuong_Binh"] : (bool?)null;
                        myNL_Nhan_Vien_Chi_Tiet.Hang_Thuong_Binh = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Hang_Thuong_Binh"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Hang_Thuong_Binh"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.Con_Gia_Dinh_Chinh_Sach = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Con_Gia_Dinh_Chinh_Sach"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Con_Gia_Dinh_Chinh_Sach"] : (int?)null;
                        myNL_Nhan_Vien_Chi_Tiet.Ma_So_So_BHXH = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ma_So_So_BHXH"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ma_So_So_BHXH"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.So_So_BHXH = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["So_So_BHXH"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["So_So_BHXH"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.So_So_Lao_Dong = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["So_So_Lao_Dong"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["So_So_Lao_Dong"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.Ngay_Nghi_Viec = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ngay_Nghi_Viec"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ngay_Nghi_Viec"] : (DateTime?)null;
                        myNL_Nhan_Vien_Chi_Tiet.Ghi_Chu = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ghi_Chu"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ghi_Chu"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.Ma_Phong = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ma_Phong"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ma_Phong"] : (int?)null;
                        myNL_Nhan_Vien_Chi_Tiet.Ma_Chinh_Tri = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ma_Chinh_Tri"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ma_Chinh_Tri"] : (int?)null;
                        myNL_Nhan_Vien_Chi_Tiet.Ma_Linh_Vuc = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ma_Linh_Vuc"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ma_Linh_Vuc"] : (int?)null;
                        myNL_Nhan_Vien_Chi_Tiet.Ma_QL_Nha_Nuoc = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ma_QL_Nha_Nuoc"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ma_QL_Nha_Nuoc"] : (int?)null;
                        myNL_Nhan_Vien_Chi_Tiet.Ma_Tin_Hoc = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ma_Tin_Hoc"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ma_Tin_Hoc"] : (int?)null;
                        myNL_Nhan_Vien_Chi_Tiet.Ma_Ngoai_Ngu = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ma_Ngoai_Ngu"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ma_Ngoai_Ngu"] : (int?)null;
                        myNL_Nhan_Vien_Chi_Tiet.Ma_Ngach = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ma_Ngach"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ma_Ngach"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.Hinh_Anh = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Hinh_Anh"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Hinh_Anh"] : (string)null;
                        myNL_Nhan_Vien_Chi_Tiet.Ma_Chuc_Danh = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ma_Chuc_Danh"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ma_Chuc_Danh"] : (int?)null;
                        myNL_Nhan_Vien_Chi_Tiet.Ma_Chuyen_Mon = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ma_Chuyen_Mon"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ma_Chuyen_Mon"] : (int?)null;
                        myNL_Nhan_Vien_Chi_Tiet.Ma_Chuc_Vu = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ma_Chuc_Vu"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Ma_Chuc_Vu"] : (int?)null;
                        myNL_Nhan_Vien_Chi_Tiet.Tieng_Dan_Toc = myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Tieng_Dan_Toc"] != DBNull.Value ? (bool?)myDataSet.Tables["NL_Nhan_Vien_Chi_Tiet"].Rows[0]["Tieng_Dan_Toc"] : (bool?)null;
                    }
                    return myNL_Nhan_Vien_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Ma_Nhan_Vien = null, string Ho_Ten_Dem = null, string Ten_Nhan_Vien = null, string So_Hieu = null, string Ma_Ho_So = null, string Ten_Thuong_Dung = null, string Bi_Danh = null, bool? Gioi_Tinh = null, DateTime? Ngay_Sinh = null, string Ma_Dan_Toc = null, string Ton_Giao = null, string Noi_Sinh = null, string Que_Quan = null, string Thuong_Tru = null, string Noi_O = null, string Nghe_Nghiep_Khi_Tuyen_Dung = null, DateTime? Ngay_Tuyen_Dung = null, string Co_Quan_Tuyen_Dung = null, string Cong_Viec_Chinh = null, string So_CMND = null, DateTime? Ngay_CMND = null, string Noi_CMND = null, string Thanh_Phan = null, string Trinh_Do_Giao_Duc_Pho_Thong = null, DateTime? Ngay_Bat_Dau = null, DateTime? Ngay_Vao_Co_Quan = null, DateTime? Ngay_Vao_Doan = null, string Noi_Vao_Doan = null, DateTime? Ngay_Vao_Dang = null, DateTime? Ngay_Vao_Dang_Chinh_Thuc = null, string Noi_Vao_Dang = null, DateTime? Ngay_Khai_Tru_Dang = null, DateTime? Ngay_Nhap_Ngu = null, DateTime? Ngay_Xuat_Ngu = null, string Ly_Do_Xuat_Ngu = null, string Quan_Ham_Cao_Nhat = null, bool? La_Quan_Nhan = null, string Danh_Hieu_Cao_Nhat = null, DateTime? Ngay_TGCM = null, string Dien_Thoai = null, string So_Truong = null, string Suc_Khoe = null, string Man_Tinh = null, decimal? Cao = null, decimal? Nang = null, string Nhom_Mau = null, bool? La_Thuong_Binh = null, string Hang_Thuong_Binh = null, int? Con_Gia_Dinh_Chinh_Sach = null, string Ma_So_So_BHXH = null, string So_So_BHXH = null, string So_So_Lao_Dong = null, DateTime? Ngay_Nghi_Viec = null, string Ghi_Chu = null, int? Ma_Phong = null, int? Ma_Chinh_Tri = null, int? Ma_Linh_Vuc = null, int? Ma_QL_Nha_Nuoc = null, int? Ma_Tin_Hoc = null, int? Ma_Ngoai_Ngu = null, string Ma_Ngach = null, string Hinh_Anh = null, int? Ma_Chuc_Danh = null, int? Ma_Chuyen_Mon = null, int? Ma_Chuc_Vu = null, bool? Tieng_Dan_Toc = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pHo_Ten_Dem = new SqlParameter("@Ho_Ten_Dem", SqlDbType.NVarChar, 200);
                    pHo_Ten_Dem.Value = Ho_Ten_Dem;
                    myCommand.Parameters.Add(pHo_Ten_Dem);

                    SqlParameter pTen_Nhan_Vien = new SqlParameter("@Ten_Nhan_Vien", SqlDbType.NVarChar, 200);
                    pTen_Nhan_Vien.Value = Ten_Nhan_Vien;
                    myCommand.Parameters.Add(pTen_Nhan_Vien);

                    SqlParameter pSo_Hieu = new SqlParameter("@So_Hieu", SqlDbType.VarChar, 50);
                    pSo_Hieu.Value = So_Hieu;
                    myCommand.Parameters.Add(pSo_Hieu);

                    SqlParameter pMa_Ho_So = new SqlParameter("@Ma_Ho_So", SqlDbType.VarChar, 50);
                    pMa_Ho_So.Value = Ma_Ho_So;
                    myCommand.Parameters.Add(pMa_Ho_So);

                    SqlParameter pTen_Thuong_Dung = new SqlParameter("@Ten_Thuong_Dung", SqlDbType.NVarChar, 100);
                    pTen_Thuong_Dung.Value = Ten_Thuong_Dung;
                    myCommand.Parameters.Add(pTen_Thuong_Dung);

                    SqlParameter pBi_Danh = new SqlParameter("@Bi_Danh", SqlDbType.NVarChar, 100);
                    pBi_Danh.Value = Bi_Danh;
                    myCommand.Parameters.Add(pBi_Danh);

                    SqlParameter pGioi_Tinh = new SqlParameter("@Gioi_Tinh", SqlDbType.Bit, 1);
                    pGioi_Tinh.Value = Gioi_Tinh;
                    myCommand.Parameters.Add(pGioi_Tinh);

                    SqlParameter pNgay_Sinh = new SqlParameter("@Ngay_Sinh", SqlDbType.DateTime, 8);
                    pNgay_Sinh.Value = Ngay_Sinh;
                    myCommand.Parameters.Add(pNgay_Sinh);

                    SqlParameter pMa_Dan_Toc = new SqlParameter("@Ma_Dan_Toc", SqlDbType.VarChar, 5);
                    pMa_Dan_Toc.Value = Ma_Dan_Toc;
                    myCommand.Parameters.Add(pMa_Dan_Toc);

                    SqlParameter pTon_Giao = new SqlParameter("@Ton_Giao", SqlDbType.NVarChar, 50);
                    pTon_Giao.Value = Ton_Giao;
                    myCommand.Parameters.Add(pTon_Giao);

                    SqlParameter pNoi_Sinh = new SqlParameter("@Noi_Sinh", SqlDbType.NVarChar, 200);
                    pNoi_Sinh.Value = Noi_Sinh;
                    myCommand.Parameters.Add(pNoi_Sinh);

                    SqlParameter pQue_Quan = new SqlParameter("@Que_Quan", SqlDbType.NVarChar, 200);
                    pQue_Quan.Value = Que_Quan;
                    myCommand.Parameters.Add(pQue_Quan);

                    SqlParameter pThuong_Tru = new SqlParameter("@Thuong_Tru", SqlDbType.NVarChar, 200);
                    pThuong_Tru.Value = Thuong_Tru;
                    myCommand.Parameters.Add(pThuong_Tru);

                    SqlParameter pNoi_O = new SqlParameter("@Noi_O", SqlDbType.NVarChar, 200);
                    pNoi_O.Value = Noi_O;
                    myCommand.Parameters.Add(pNoi_O);

                    SqlParameter pNghe_Nghiep_Khi_Tuyen_Dung = new SqlParameter("@Nghe_Nghiep_Khi_Tuyen_Dung", SqlDbType.NVarChar, 300);
                    pNghe_Nghiep_Khi_Tuyen_Dung.Value = Nghe_Nghiep_Khi_Tuyen_Dung;
                    myCommand.Parameters.Add(pNghe_Nghiep_Khi_Tuyen_Dung);

                    SqlParameter pNgay_Tuyen_Dung = new SqlParameter("@Ngay_Tuyen_Dung", SqlDbType.DateTime, 8);
                    pNgay_Tuyen_Dung.Value = Ngay_Tuyen_Dung;
                    myCommand.Parameters.Add(pNgay_Tuyen_Dung);

                    SqlParameter pCo_Quan_Tuyen_Dung = new SqlParameter("@Co_Quan_Tuyen_Dung", SqlDbType.NVarChar, 500);
                    pCo_Quan_Tuyen_Dung.Value = Co_Quan_Tuyen_Dung;
                    myCommand.Parameters.Add(pCo_Quan_Tuyen_Dung);

                    SqlParameter pCong_Viec_Chinh = new SqlParameter("@Cong_Viec_Chinh", SqlDbType.NVarChar, 500);
                    pCong_Viec_Chinh.Value = Cong_Viec_Chinh;
                    myCommand.Parameters.Add(pCong_Viec_Chinh);

                    SqlParameter pSo_CMND = new SqlParameter("@So_CMND", SqlDbType.VarChar, 50);
                    pSo_CMND.Value = So_CMND;
                    myCommand.Parameters.Add(pSo_CMND);

                    SqlParameter pNgay_CMND = new SqlParameter("@Ngay_CMND", SqlDbType.DateTime, 8);
                    pNgay_CMND.Value = Ngay_CMND;
                    myCommand.Parameters.Add(pNgay_CMND);

                    SqlParameter pNoi_CMND = new SqlParameter("@Noi_CMND", SqlDbType.NVarChar, 200);
                    pNoi_CMND.Value = Noi_CMND;
                    myCommand.Parameters.Add(pNoi_CMND);

                    SqlParameter pThanh_Phan = new SqlParameter("@Thanh_Phan", SqlDbType.NVarChar, 500);
                    pThanh_Phan.Value = Thanh_Phan;
                    myCommand.Parameters.Add(pThanh_Phan);

                    SqlParameter pTrinh_Do_Giao_Duc_Pho_Thong = new SqlParameter("@Trinh_Do_Giao_Duc_Pho_Thong", SqlDbType.NVarChar, 500);
                    pTrinh_Do_Giao_Duc_Pho_Thong.Value = Trinh_Do_Giao_Duc_Pho_Thong;
                    myCommand.Parameters.Add(pTrinh_Do_Giao_Duc_Pho_Thong);

                    SqlParameter pNgay_Bat_Dau = new SqlParameter("@Ngay_Bat_Dau", SqlDbType.DateTime, 8);
                    pNgay_Bat_Dau.Value = Ngay_Bat_Dau;
                    myCommand.Parameters.Add(pNgay_Bat_Dau);

                    SqlParameter pNgay_Vao_Co_Quan = new SqlParameter("@Ngay_Vao_Co_Quan", SqlDbType.DateTime, 8);
                    pNgay_Vao_Co_Quan.Value = Ngay_Vao_Co_Quan;
                    myCommand.Parameters.Add(pNgay_Vao_Co_Quan);

                    SqlParameter pNgay_Vao_Doan = new SqlParameter("@Ngay_Vao_Doan", SqlDbType.DateTime, 8);
                    pNgay_Vao_Doan.Value = Ngay_Vao_Doan;
                    myCommand.Parameters.Add(pNgay_Vao_Doan);

                    SqlParameter pNoi_Vao_Doan = new SqlParameter("@Noi_Vao_Doan", SqlDbType.NVarChar, 200);
                    pNoi_Vao_Doan.Value = Noi_Vao_Doan;
                    myCommand.Parameters.Add(pNoi_Vao_Doan);

                    SqlParameter pNgay_Vao_Dang = new SqlParameter("@Ngay_Vao_Dang", SqlDbType.DateTime, 8);
                    pNgay_Vao_Dang.Value = Ngay_Vao_Dang;
                    myCommand.Parameters.Add(pNgay_Vao_Dang);

                    SqlParameter pNgay_Vao_Dang_Chinh_Thuc = new SqlParameter("@Ngay_Vao_Dang_Chinh_Thuc", SqlDbType.DateTime, 8);
                    pNgay_Vao_Dang_Chinh_Thuc.Value = Ngay_Vao_Dang_Chinh_Thuc;
                    myCommand.Parameters.Add(pNgay_Vao_Dang_Chinh_Thuc);

                    SqlParameter pNoi_Vao_Dang = new SqlParameter("@Noi_Vao_Dang", SqlDbType.NVarChar, 500);
                    pNoi_Vao_Dang.Value = Noi_Vao_Dang;
                    myCommand.Parameters.Add(pNoi_Vao_Dang);

                    SqlParameter pNgay_Khai_Tru_Dang = new SqlParameter("@Ngay_Khai_Tru_Dang", SqlDbType.DateTime, 8);
                    pNgay_Khai_Tru_Dang.Value = Ngay_Khai_Tru_Dang;
                    myCommand.Parameters.Add(pNgay_Khai_Tru_Dang);

                    SqlParameter pNgay_Nhap_Ngu = new SqlParameter("@Ngay_Nhap_Ngu", SqlDbType.DateTime, 8);
                    pNgay_Nhap_Ngu.Value = Ngay_Nhap_Ngu;
                    myCommand.Parameters.Add(pNgay_Nhap_Ngu);

                    SqlParameter pNgay_Xuat_Ngu = new SqlParameter("@Ngay_Xuat_Ngu", SqlDbType.DateTime, 8);
                    pNgay_Xuat_Ngu.Value = Ngay_Xuat_Ngu;
                    myCommand.Parameters.Add(pNgay_Xuat_Ngu);

                    SqlParameter pLy_Do_Xuat_Ngu = new SqlParameter("@Ly_Do_Xuat_Ngu", SqlDbType.NVarChar, 1000);
                    pLy_Do_Xuat_Ngu.Value = Ly_Do_Xuat_Ngu;
                    myCommand.Parameters.Add(pLy_Do_Xuat_Ngu);

                    SqlParameter pQuan_Ham_Cao_Nhat = new SqlParameter("@Quan_Ham_Cao_Nhat", SqlDbType.NVarChar, 500);
                    pQuan_Ham_Cao_Nhat.Value = Quan_Ham_Cao_Nhat;
                    myCommand.Parameters.Add(pQuan_Ham_Cao_Nhat);

                    SqlParameter pLa_Quan_Nhan = new SqlParameter("@La_Quan_Nhan", SqlDbType.Bit, 1);
                    pLa_Quan_Nhan.Value = La_Quan_Nhan;
                    myCommand.Parameters.Add(pLa_Quan_Nhan);

                    SqlParameter pDanh_Hieu_Cao_Nhat = new SqlParameter("@Danh_Hieu_Cao_Nhat", SqlDbType.NVarChar, 500);
                    pDanh_Hieu_Cao_Nhat.Value = Danh_Hieu_Cao_Nhat;
                    myCommand.Parameters.Add(pDanh_Hieu_Cao_Nhat);

                    SqlParameter pNgay_TGCM = new SqlParameter("@Ngay_TGCM", SqlDbType.DateTime, 8);
                    pNgay_TGCM.Value = Ngay_TGCM;
                    myCommand.Parameters.Add(pNgay_TGCM);

                    SqlParameter pDien_Thoai = new SqlParameter("@Dien_Thoai", SqlDbType.VarChar, 15);
                    pDien_Thoai.Value = Dien_Thoai;
                    myCommand.Parameters.Add(pDien_Thoai);

                    SqlParameter pSo_Truong = new SqlParameter("@So_Truong", SqlDbType.NVarChar, 50);
                    pSo_Truong.Value = So_Truong;
                    myCommand.Parameters.Add(pSo_Truong);

                    SqlParameter pSuc_Khoe = new SqlParameter("@Suc_Khoe", SqlDbType.NVarChar, 50);
                    pSuc_Khoe.Value = Suc_Khoe;
                    myCommand.Parameters.Add(pSuc_Khoe);

                    SqlParameter pMan_Tinh = new SqlParameter("@Man_Tinh", SqlDbType.NVarChar, 50);
                    pMan_Tinh.Value = Man_Tinh;
                    myCommand.Parameters.Add(pMan_Tinh);

                    SqlParameter pCao = new SqlParameter("@Cao", SqlDbType.Decimal);
                    pCao.Value = Cao;
                    myCommand.Parameters.Add(pCao);

                    SqlParameter pNang = new SqlParameter("@Nang", SqlDbType.Decimal);
                    pNang.Value = Nang;
                    myCommand.Parameters.Add(pNang);

                    SqlParameter pNhom_Mau = new SqlParameter("@Nhom_Mau", SqlDbType.NVarChar, 50);
                    pNhom_Mau.Value = Nhom_Mau;
                    myCommand.Parameters.Add(pNhom_Mau);

                    SqlParameter pLa_Thuong_Binh = new SqlParameter("@La_Thuong_Binh", SqlDbType.Bit, 1);
                    pLa_Thuong_Binh.Value = La_Thuong_Binh;
                    myCommand.Parameters.Add(pLa_Thuong_Binh);

                    SqlParameter pHang_Thuong_Binh = new SqlParameter("@Hang_Thuong_Binh", SqlDbType.NVarChar, 50);
                    pHang_Thuong_Binh.Value = Hang_Thuong_Binh;
                    myCommand.Parameters.Add(pHang_Thuong_Binh);

                    SqlParameter pCon_Gia_Dinh_Chinh_Sach = new SqlParameter("@Con_Gia_Dinh_Chinh_Sach", SqlDbType.Int, 4);
                    pCon_Gia_Dinh_Chinh_Sach.Value = Con_Gia_Dinh_Chinh_Sach;
                    myCommand.Parameters.Add(pCon_Gia_Dinh_Chinh_Sach);

                    SqlParameter pMa_So_So_BHXH = new SqlParameter("@Ma_So_So_BHXH", SqlDbType.VarChar, 50);
                    pMa_So_So_BHXH.Value = Ma_So_So_BHXH;
                    myCommand.Parameters.Add(pMa_So_So_BHXH);

                    SqlParameter pSo_So_BHXH = new SqlParameter("@So_So_BHXH", SqlDbType.VarChar, 50);
                    pSo_So_BHXH.Value = So_So_BHXH;
                    myCommand.Parameters.Add(pSo_So_BHXH);

                    SqlParameter pSo_So_Lao_Dong = new SqlParameter("@So_So_Lao_Dong", SqlDbType.VarChar, 50);
                    pSo_So_Lao_Dong.Value = So_So_Lao_Dong;
                    myCommand.Parameters.Add(pSo_So_Lao_Dong);

                    SqlParameter pNgay_Nghi_Viec = new SqlParameter("@Ngay_Nghi_Viec", SqlDbType.DateTime, 8);
                    pNgay_Nghi_Viec.Value = Ngay_Nghi_Viec;
                    myCommand.Parameters.Add(pNgay_Nghi_Viec);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NText);
                    pGhi_Chu.Value = Ghi_Chu;
                    myCommand.Parameters.Add(pGhi_Chu);

                    SqlParameter pMa_Phong = new SqlParameter("@Ma_Phong", SqlDbType.Int, 4);
                    pMa_Phong.Value = Ma_Phong;
                    myCommand.Parameters.Add(pMa_Phong);

                    SqlParameter pMa_Chinh_Tri = new SqlParameter("@Ma_Chinh_Tri", SqlDbType.Int, 4);
                    pMa_Chinh_Tri.Value = Ma_Chinh_Tri;
                    myCommand.Parameters.Add(pMa_Chinh_Tri);

                    SqlParameter pMa_Linh_Vuc = new SqlParameter("@Ma_Linh_Vuc", SqlDbType.Int, 4);
                    pMa_Linh_Vuc.Value = Ma_Linh_Vuc;
                    myCommand.Parameters.Add(pMa_Linh_Vuc);

                    SqlParameter pMa_QL_Nha_Nuoc = new SqlParameter("@Ma_QL_Nha_Nuoc", SqlDbType.Int, 4);
                    pMa_QL_Nha_Nuoc.Value = Ma_QL_Nha_Nuoc;
                    myCommand.Parameters.Add(pMa_QL_Nha_Nuoc);

                    SqlParameter pMa_Tin_Hoc = new SqlParameter("@Ma_Tin_Hoc", SqlDbType.Int, 4);
                    pMa_Tin_Hoc.Value = Ma_Tin_Hoc;
                    myCommand.Parameters.Add(pMa_Tin_Hoc);

                    SqlParameter pMa_Ngoai_Ngu = new SqlParameter("@Ma_Ngoai_Ngu", SqlDbType.Int, 4);
                    pMa_Ngoai_Ngu.Value = Ma_Ngoai_Ngu;
                    myCommand.Parameters.Add(pMa_Ngoai_Ngu);

                    SqlParameter pMa_Ngach = new SqlParameter("@Ma_Ngach", SqlDbType.VarChar, 50);
                    pMa_Ngach.Value = Ma_Ngach;
                    myCommand.Parameters.Add(pMa_Ngach);

                    SqlParameter pHinh_Anh = new SqlParameter("@Hinh_Anh", SqlDbType.NVarChar, 200);
                    pHinh_Anh.Value = Hinh_Anh;
                    myCommand.Parameters.Add(pHinh_Anh);

                    SqlParameter pMa_Chuc_Danh = new SqlParameter("@Ma_Chuc_Danh", SqlDbType.Int, 4);
                    pMa_Chuc_Danh.Value = Ma_Chuc_Danh;
                    myCommand.Parameters.Add(pMa_Chuc_Danh);

                    SqlParameter pMa_Chuyen_Mon = new SqlParameter("@Ma_Chuyen_Mon", SqlDbType.Int, 4);
                    pMa_Chuyen_Mon.Value = Ma_Chuyen_Mon;
                    myCommand.Parameters.Add(pMa_Chuyen_Mon);

                    SqlParameter pMa_Chuc_Vu = new SqlParameter("@Ma_Chuc_Vu", SqlDbType.Int, 4);
                    pMa_Chuc_Vu.Value = Ma_Chuc_Vu;
                    myCommand.Parameters.Add(pMa_Chuc_Vu);

                    SqlParameter pTieng_Dan_Toc = new SqlParameter("@Tieng_Dan_Toc", SqlDbType.Bit, 1);
                    pTieng_Dan_Toc.Value = Tieng_Dan_Toc;
                    myCommand.Parameters.Add(pTieng_Dan_Toc);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                  
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int? Ma_Nhan_Vien = null, string Ho_Ten_Dem = null, string Ten_Nhan_Vien = null, string So_Hieu = null, string Ma_Ho_So = null, string Ten_Thuong_Dung = null, string Bi_Danh = null, bool? Gioi_Tinh = null, DateTime? Ngay_Sinh = null, string Ma_Dan_Toc = null, string Ton_Giao = null, string Noi_Sinh = null, string Que_Quan = null, string Thuong_Tru = null, string Noi_O = null, string Nghe_Nghiep_Khi_Tuyen_Dung = null, DateTime? Ngay_Tuyen_Dung = null, string Co_Quan_Tuyen_Dung = null, string Cong_Viec_Chinh = null, string So_CMND = null, DateTime? Ngay_CMND = null, string Noi_CMND = null, string Thanh_Phan = null, string Trinh_Do_Giao_Duc_Pho_Thong = null, DateTime? Ngay_Bat_Dau = null, DateTime? Ngay_Vao_Co_Quan = null, DateTime? Ngay_Vao_Doan = null, string Noi_Vao_Doan = null, DateTime? Ngay_Vao_Dang = null, DateTime? Ngay_Vao_Dang_Chinh_Thuc = null, string Noi_Vao_Dang = null, DateTime? Ngay_Khai_Tru_Dang = null, DateTime? Ngay_Nhap_Ngu = null, DateTime? Ngay_Xuat_Ngu = null, string Ly_Do_Xuat_Ngu = null, string Quan_Ham_Cao_Nhat = null, bool? La_Quan_Nhan = null, string Danh_Hieu_Cao_Nhat = null, DateTime? Ngay_TGCM = null, string Dien_Thoai = null, string So_Truong = null, string Suc_Khoe = null, string Man_Tinh = null, decimal? Cao = null, decimal? Nang = null, string Nhom_Mau = null, bool? La_Thuong_Binh = null, string Hang_Thuong_Binh = null, int? Con_Gia_Dinh_Chinh_Sach = null, string Ma_So_So_BHXH = null, string So_So_BHXH = null, string So_So_Lao_Dong = null, DateTime? Ngay_Nghi_Viec = null, string Ghi_Chu = null, int? Ma_Phong = null, int? Ma_Chinh_Tri = null, int? Ma_Linh_Vuc = null, int? Ma_QL_Nha_Nuoc = null, int? Ma_Tin_Hoc = null, int? Ma_Ngoai_Ngu = null, string Ma_Ngach = null, string Hinh_Anh = null, int? Ma_Chuc_Danh = null, int? Ma_Chuyen_Mon = null, int? Ma_Chuc_Vu = null, bool? Tieng_Dan_Toc = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pHo_Ten_Dem = new SqlParameter("@Ho_Ten_Dem", SqlDbType.NVarChar, 200);
                    pHo_Ten_Dem.Value = Ho_Ten_Dem;
                    myCommand.Parameters.Add(pHo_Ten_Dem);

                    SqlParameter pTen_Nhan_Vien = new SqlParameter("@Ten_Nhan_Vien", SqlDbType.NVarChar, 200);
                    pTen_Nhan_Vien.Value = Ten_Nhan_Vien;
                    myCommand.Parameters.Add(pTen_Nhan_Vien);

                    SqlParameter pSo_Hieu = new SqlParameter("@So_Hieu", SqlDbType.VarChar, 50);
                    pSo_Hieu.Value = So_Hieu;
                    myCommand.Parameters.Add(pSo_Hieu);

                    SqlParameter pMa_Ho_So = new SqlParameter("@Ma_Ho_So", SqlDbType.VarChar, 50);
                    pMa_Ho_So.Value = Ma_Ho_So;
                    myCommand.Parameters.Add(pMa_Ho_So);

                    SqlParameter pTen_Thuong_Dung = new SqlParameter("@Ten_Thuong_Dung", SqlDbType.NVarChar, 100);
                    pTen_Thuong_Dung.Value = Ten_Thuong_Dung;
                    myCommand.Parameters.Add(pTen_Thuong_Dung);

                    SqlParameter pBi_Danh = new SqlParameter("@Bi_Danh", SqlDbType.NVarChar, 100);
                    pBi_Danh.Value = Bi_Danh;
                    myCommand.Parameters.Add(pBi_Danh);

                    SqlParameter pGioi_Tinh = new SqlParameter("@Gioi_Tinh", SqlDbType.Bit, 1);
                    pGioi_Tinh.Value = Gioi_Tinh;
                    myCommand.Parameters.Add(pGioi_Tinh);

                    SqlParameter pNgay_Sinh = new SqlParameter("@Ngay_Sinh", SqlDbType.DateTime, 8);
                    pNgay_Sinh.Value = Ngay_Sinh;
                    myCommand.Parameters.Add(pNgay_Sinh);

                    SqlParameter pMa_Dan_Toc = new SqlParameter("@Ma_Dan_Toc", SqlDbType.VarChar, 5);
                    pMa_Dan_Toc.Value = Ma_Dan_Toc;
                    myCommand.Parameters.Add(pMa_Dan_Toc);

                    SqlParameter pTon_Giao = new SqlParameter("@Ton_Giao", SqlDbType.NVarChar, 50);
                    pTon_Giao.Value = Ton_Giao;
                    myCommand.Parameters.Add(pTon_Giao);

                    SqlParameter pNoi_Sinh = new SqlParameter("@Noi_Sinh", SqlDbType.NVarChar, 200);
                    pNoi_Sinh.Value = Noi_Sinh;
                    myCommand.Parameters.Add(pNoi_Sinh);

                    SqlParameter pQue_Quan = new SqlParameter("@Que_Quan", SqlDbType.NVarChar, 200);
                    pQue_Quan.Value = Que_Quan;
                    myCommand.Parameters.Add(pQue_Quan);

                    SqlParameter pThuong_Tru = new SqlParameter("@Thuong_Tru", SqlDbType.NVarChar, 200);
                    pThuong_Tru.Value = Thuong_Tru;
                    myCommand.Parameters.Add(pThuong_Tru);

                    SqlParameter pNoi_O = new SqlParameter("@Noi_O", SqlDbType.NVarChar, 200);
                    pNoi_O.Value = Noi_O;
                    myCommand.Parameters.Add(pNoi_O);

                    SqlParameter pNghe_Nghiep_Khi_Tuyen_Dung = new SqlParameter("@Nghe_Nghiep_Khi_Tuyen_Dung", SqlDbType.NVarChar, 300);
                    pNghe_Nghiep_Khi_Tuyen_Dung.Value = Nghe_Nghiep_Khi_Tuyen_Dung;
                    myCommand.Parameters.Add(pNghe_Nghiep_Khi_Tuyen_Dung);

                    SqlParameter pNgay_Tuyen_Dung = new SqlParameter("@Ngay_Tuyen_Dung", SqlDbType.DateTime, 8);
                    pNgay_Tuyen_Dung.Value = Ngay_Tuyen_Dung;
                    myCommand.Parameters.Add(pNgay_Tuyen_Dung);

                    SqlParameter pCo_Quan_Tuyen_Dung = new SqlParameter("@Co_Quan_Tuyen_Dung", SqlDbType.NVarChar, 500);
                    pCo_Quan_Tuyen_Dung.Value = Co_Quan_Tuyen_Dung;
                    myCommand.Parameters.Add(pCo_Quan_Tuyen_Dung);

                    SqlParameter pCong_Viec_Chinh = new SqlParameter("@Cong_Viec_Chinh", SqlDbType.NVarChar, 500);
                    pCong_Viec_Chinh.Value = Cong_Viec_Chinh;
                    myCommand.Parameters.Add(pCong_Viec_Chinh);

                    SqlParameter pSo_CMND = new SqlParameter("@So_CMND", SqlDbType.VarChar, 50);
                    pSo_CMND.Value = So_CMND;
                    myCommand.Parameters.Add(pSo_CMND);

                    SqlParameter pNgay_CMND = new SqlParameter("@Ngay_CMND", SqlDbType.DateTime, 8);
                    pNgay_CMND.Value = Ngay_CMND;
                    myCommand.Parameters.Add(pNgay_CMND);

                    SqlParameter pNoi_CMND = new SqlParameter("@Noi_CMND", SqlDbType.NVarChar, 200);
                    pNoi_CMND.Value = Noi_CMND;
                    myCommand.Parameters.Add(pNoi_CMND);

                    SqlParameter pThanh_Phan = new SqlParameter("@Thanh_Phan", SqlDbType.NVarChar, 500);
                    pThanh_Phan.Value = Thanh_Phan;
                    myCommand.Parameters.Add(pThanh_Phan);

                    SqlParameter pTrinh_Do_Giao_Duc_Pho_Thong = new SqlParameter("@Trinh_Do_Giao_Duc_Pho_Thong", SqlDbType.NVarChar, 500);
                    pTrinh_Do_Giao_Duc_Pho_Thong.Value = Trinh_Do_Giao_Duc_Pho_Thong;
                    myCommand.Parameters.Add(pTrinh_Do_Giao_Duc_Pho_Thong);

                    SqlParameter pNgay_Bat_Dau = new SqlParameter("@Ngay_Bat_Dau", SqlDbType.DateTime, 8);
                    pNgay_Bat_Dau.Value = Ngay_Bat_Dau;
                    myCommand.Parameters.Add(pNgay_Bat_Dau);

                    SqlParameter pNgay_Vao_Co_Quan = new SqlParameter("@Ngay_Vao_Co_Quan", SqlDbType.DateTime, 8);
                    pNgay_Vao_Co_Quan.Value = Ngay_Vao_Co_Quan;
                    myCommand.Parameters.Add(pNgay_Vao_Co_Quan);

                    SqlParameter pNgay_Vao_Doan = new SqlParameter("@Ngay_Vao_Doan", SqlDbType.DateTime, 8);
                    pNgay_Vao_Doan.Value = Ngay_Vao_Doan;
                    myCommand.Parameters.Add(pNgay_Vao_Doan);

                    SqlParameter pNoi_Vao_Doan = new SqlParameter("@Noi_Vao_Doan", SqlDbType.NVarChar, 200);
                    pNoi_Vao_Doan.Value = Noi_Vao_Doan;
                    myCommand.Parameters.Add(pNoi_Vao_Doan);

                    SqlParameter pNgay_Vao_Dang = new SqlParameter("@Ngay_Vao_Dang", SqlDbType.DateTime, 8);
                    pNgay_Vao_Dang.Value = Ngay_Vao_Dang;
                    myCommand.Parameters.Add(pNgay_Vao_Dang);

                    SqlParameter pNgay_Vao_Dang_Chinh_Thuc = new SqlParameter("@Ngay_Vao_Dang_Chinh_Thuc", SqlDbType.DateTime, 8);
                    pNgay_Vao_Dang_Chinh_Thuc.Value = Ngay_Vao_Dang_Chinh_Thuc;
                    myCommand.Parameters.Add(pNgay_Vao_Dang_Chinh_Thuc);

                    SqlParameter pNoi_Vao_Dang = new SqlParameter("@Noi_Vao_Dang", SqlDbType.NVarChar, 500);
                    pNoi_Vao_Dang.Value = Noi_Vao_Dang;
                    myCommand.Parameters.Add(pNoi_Vao_Dang);

                    SqlParameter pNgay_Khai_Tru_Dang = new SqlParameter("@Ngay_Khai_Tru_Dang", SqlDbType.DateTime, 8);
                    pNgay_Khai_Tru_Dang.Value = Ngay_Khai_Tru_Dang;
                    myCommand.Parameters.Add(pNgay_Khai_Tru_Dang);

                    SqlParameter pNgay_Nhap_Ngu = new SqlParameter("@Ngay_Nhap_Ngu", SqlDbType.DateTime, 8);
                    pNgay_Nhap_Ngu.Value = Ngay_Nhap_Ngu;
                    myCommand.Parameters.Add(pNgay_Nhap_Ngu);

                    SqlParameter pNgay_Xuat_Ngu = new SqlParameter("@Ngay_Xuat_Ngu", SqlDbType.DateTime, 8);
                    pNgay_Xuat_Ngu.Value = Ngay_Xuat_Ngu;
                    myCommand.Parameters.Add(pNgay_Xuat_Ngu);

                    SqlParameter pLy_Do_Xuat_Ngu = new SqlParameter("@Ly_Do_Xuat_Ngu", SqlDbType.NVarChar, 1000);
                    pLy_Do_Xuat_Ngu.Value = Ly_Do_Xuat_Ngu;
                    myCommand.Parameters.Add(pLy_Do_Xuat_Ngu);

                    SqlParameter pQuan_Ham_Cao_Nhat = new SqlParameter("@Quan_Ham_Cao_Nhat", SqlDbType.NVarChar, 500);
                    pQuan_Ham_Cao_Nhat.Value = Quan_Ham_Cao_Nhat;
                    myCommand.Parameters.Add(pQuan_Ham_Cao_Nhat);

                    SqlParameter pLa_Quan_Nhan = new SqlParameter("@La_Quan_Nhan", SqlDbType.Bit, 1);
                    pLa_Quan_Nhan.Value = La_Quan_Nhan;
                    myCommand.Parameters.Add(pLa_Quan_Nhan);

                    SqlParameter pDanh_Hieu_Cao_Nhat = new SqlParameter("@Danh_Hieu_Cao_Nhat", SqlDbType.NVarChar, 500);
                    pDanh_Hieu_Cao_Nhat.Value = Danh_Hieu_Cao_Nhat;
                    myCommand.Parameters.Add(pDanh_Hieu_Cao_Nhat);

                    SqlParameter pNgay_TGCM = new SqlParameter("@Ngay_TGCM", SqlDbType.DateTime, 8);
                    pNgay_TGCM.Value = Ngay_TGCM;
                    myCommand.Parameters.Add(pNgay_TGCM);

                    SqlParameter pDien_Thoai = new SqlParameter("@Dien_Thoai", SqlDbType.VarChar, 15);
                    pDien_Thoai.Value = Dien_Thoai;
                    myCommand.Parameters.Add(pDien_Thoai);

                    SqlParameter pSo_Truong = new SqlParameter("@So_Truong", SqlDbType.NVarChar, 50);
                    pSo_Truong.Value = So_Truong;
                    myCommand.Parameters.Add(pSo_Truong);

                    SqlParameter pSuc_Khoe = new SqlParameter("@Suc_Khoe", SqlDbType.NVarChar, 50);
                    pSuc_Khoe.Value = Suc_Khoe;
                    myCommand.Parameters.Add(pSuc_Khoe);

                    SqlParameter pMan_Tinh = new SqlParameter("@Man_Tinh", SqlDbType.NVarChar, 50);
                    pMan_Tinh.Value = Man_Tinh;
                    myCommand.Parameters.Add(pMan_Tinh);

                    SqlParameter pCao = new SqlParameter("@Cao", SqlDbType.Decimal);
                    pCao.Value = Cao;
                    myCommand.Parameters.Add(pCao);

                    SqlParameter pNang = new SqlParameter("@Nang", SqlDbType.Decimal);
                    pNang.Value = Nang;
                    myCommand.Parameters.Add(pNang);

                    SqlParameter pNhom_Mau = new SqlParameter("@Nhom_Mau", SqlDbType.NVarChar, 50);
                    pNhom_Mau.Value = Nhom_Mau;
                    myCommand.Parameters.Add(pNhom_Mau);

                    SqlParameter pLa_Thuong_Binh = new SqlParameter("@La_Thuong_Binh", SqlDbType.Bit, 1);
                    pLa_Thuong_Binh.Value = La_Thuong_Binh;
                    myCommand.Parameters.Add(pLa_Thuong_Binh);

                    SqlParameter pHang_Thuong_Binh = new SqlParameter("@Hang_Thuong_Binh", SqlDbType.NVarChar, 50);
                    pHang_Thuong_Binh.Value = Hang_Thuong_Binh;
                    myCommand.Parameters.Add(pHang_Thuong_Binh);

                    SqlParameter pCon_Gia_Dinh_Chinh_Sach = new SqlParameter("@Con_Gia_Dinh_Chinh_Sach", SqlDbType.Int, 4);
                    pCon_Gia_Dinh_Chinh_Sach.Value = Con_Gia_Dinh_Chinh_Sach;
                    myCommand.Parameters.Add(pCon_Gia_Dinh_Chinh_Sach);

                    SqlParameter pMa_So_So_BHXH = new SqlParameter("@Ma_So_So_BHXH", SqlDbType.VarChar, 50);
                    pMa_So_So_BHXH.Value = Ma_So_So_BHXH;
                    myCommand.Parameters.Add(pMa_So_So_BHXH);

                    SqlParameter pSo_So_BHXH = new SqlParameter("@So_So_BHXH", SqlDbType.VarChar, 50);
                    pSo_So_BHXH.Value = So_So_BHXH;
                    myCommand.Parameters.Add(pSo_So_BHXH);

                    SqlParameter pSo_So_Lao_Dong = new SqlParameter("@So_So_Lao_Dong", SqlDbType.VarChar, 50);
                    pSo_So_Lao_Dong.Value = So_So_Lao_Dong;
                    myCommand.Parameters.Add(pSo_So_Lao_Dong);

                    SqlParameter pNgay_Nghi_Viec = new SqlParameter("@Ngay_Nghi_Viec", SqlDbType.DateTime, 8);
                    pNgay_Nghi_Viec.Value = Ngay_Nghi_Viec;
                    myCommand.Parameters.Add(pNgay_Nghi_Viec);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NText);
                    pGhi_Chu.Value = Ghi_Chu;
                    myCommand.Parameters.Add(pGhi_Chu);

                    SqlParameter pMa_Phong = new SqlParameter("@Ma_Phong", SqlDbType.Int, 4);
                    pMa_Phong.Value = Ma_Phong;
                    myCommand.Parameters.Add(pMa_Phong);

                    SqlParameter pMa_Chinh_Tri = new SqlParameter("@Ma_Chinh_Tri", SqlDbType.Int, 4);
                    pMa_Chinh_Tri.Value = Ma_Chinh_Tri;
                    myCommand.Parameters.Add(pMa_Chinh_Tri);

                    SqlParameter pMa_Linh_Vuc = new SqlParameter("@Ma_Linh_Vuc", SqlDbType.Int, 4);
                    pMa_Linh_Vuc.Value = Ma_Linh_Vuc;
                    myCommand.Parameters.Add(pMa_Linh_Vuc);

                    SqlParameter pMa_QL_Nha_Nuoc = new SqlParameter("@Ma_QL_Nha_Nuoc", SqlDbType.Int, 4);
                    pMa_QL_Nha_Nuoc.Value = Ma_QL_Nha_Nuoc;
                    myCommand.Parameters.Add(pMa_QL_Nha_Nuoc);

                    SqlParameter pMa_Tin_Hoc = new SqlParameter("@Ma_Tin_Hoc", SqlDbType.Int, 4);
                    pMa_Tin_Hoc.Value = Ma_Tin_Hoc;
                    myCommand.Parameters.Add(pMa_Tin_Hoc);

                    SqlParameter pMa_Ngoai_Ngu = new SqlParameter("@Ma_Ngoai_Ngu", SqlDbType.Int, 4);
                    pMa_Ngoai_Ngu.Value = Ma_Ngoai_Ngu;
                    myCommand.Parameters.Add(pMa_Ngoai_Ngu);

                    SqlParameter pMa_Ngach = new SqlParameter("@Ma_Ngach", SqlDbType.VarChar, 50);
                    pMa_Ngach.Value = Ma_Ngach;
                    myCommand.Parameters.Add(pMa_Ngach);

                    SqlParameter pHinh_Anh = new SqlParameter("@Hinh_Anh", SqlDbType.NVarChar, 200);
                    pHinh_Anh.Value = Hinh_Anh;
                    myCommand.Parameters.Add(pHinh_Anh);

                    SqlParameter pMa_Chuc_Danh = new SqlParameter("@Ma_Chuc_Danh", SqlDbType.Int, 4);
                    pMa_Chuc_Danh.Value = Ma_Chuc_Danh;
                    myCommand.Parameters.Add(pMa_Chuc_Danh);

                    SqlParameter pMa_Chuyen_Mon = new SqlParameter("@Ma_Chuyen_Mon", SqlDbType.Int, 4);
                    pMa_Chuyen_Mon.Value = Ma_Chuyen_Mon;
                    myCommand.Parameters.Add(pMa_Chuyen_Mon);

                    SqlParameter pMa_Chuc_Vu = new SqlParameter("@Ma_Chuc_Vu", SqlDbType.Int, 4);
                    pMa_Chuc_Vu.Value = Ma_Chuc_Vu;
                    myCommand.Parameters.Add(pMa_Chuc_Vu);

                    SqlParameter pTieng_Dan_Toc = new SqlParameter("@Tieng_Dan_Toc", SqlDbType.Bit, 1);
                    pTieng_Dan_Toc.Value = Tieng_Dan_Toc;
                    myCommand.Parameters.Add(pTieng_Dan_Toc);



                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(NL_Nhan_Vien_Chi_Tiet myNL_Nhan_Vien_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = myNL_Nhan_Vien_Chi_Tiet.Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pHo_Ten_Dem = new SqlParameter("@Ho_Ten_Dem", SqlDbType.NVarChar, 200);
                    pHo_Ten_Dem.Value = myNL_Nhan_Vien_Chi_Tiet.Ho_Ten_Dem;
                    myCommand.Parameters.Add(pHo_Ten_Dem);

                    SqlParameter pTen_Nhan_Vien = new SqlParameter("@Ten_Nhan_Vien", SqlDbType.NVarChar, 200);
                    pTen_Nhan_Vien.Value = myNL_Nhan_Vien_Chi_Tiet.Ten_Nhan_Vien;
                    myCommand.Parameters.Add(pTen_Nhan_Vien);

                    SqlParameter pSo_Hieu = new SqlParameter("@So_Hieu", SqlDbType.VarChar, 50);
                    pSo_Hieu.Value = myNL_Nhan_Vien_Chi_Tiet.So_Hieu;
                    myCommand.Parameters.Add(pSo_Hieu);

                    SqlParameter pMa_Ho_So = new SqlParameter("@Ma_Ho_So", SqlDbType.VarChar, 50);
                    pMa_Ho_So.Value = myNL_Nhan_Vien_Chi_Tiet.Ma_Ho_So;
                    myCommand.Parameters.Add(pMa_Ho_So);

                    SqlParameter pTen_Thuong_Dung = new SqlParameter("@Ten_Thuong_Dung", SqlDbType.NVarChar, 100);
                    pTen_Thuong_Dung.Value = myNL_Nhan_Vien_Chi_Tiet.Ten_Thuong_Dung;
                    myCommand.Parameters.Add(pTen_Thuong_Dung);

                    SqlParameter pBi_Danh = new SqlParameter("@Bi_Danh", SqlDbType.NVarChar, 100);
                    pBi_Danh.Value = myNL_Nhan_Vien_Chi_Tiet.Bi_Danh;
                    myCommand.Parameters.Add(pBi_Danh);

                    SqlParameter pGioi_Tinh = new SqlParameter("@Gioi_Tinh", SqlDbType.Bit, 1);
                    pGioi_Tinh.Value = myNL_Nhan_Vien_Chi_Tiet.Gioi_Tinh;
                    myCommand.Parameters.Add(pGioi_Tinh);

                    SqlParameter pNgay_Sinh = new SqlParameter("@Ngay_Sinh", SqlDbType.DateTime, 8);
                    pNgay_Sinh.Value = myNL_Nhan_Vien_Chi_Tiet.Ngay_Sinh;
                    myCommand.Parameters.Add(pNgay_Sinh);

                    SqlParameter pMa_Dan_Toc = new SqlParameter("@Ma_Dan_Toc", SqlDbType.VarChar, 5);
                    pMa_Dan_Toc.Value = myNL_Nhan_Vien_Chi_Tiet.Ma_Dan_Toc;
                    myCommand.Parameters.Add(pMa_Dan_Toc);

                    SqlParameter pTon_Giao = new SqlParameter("@Ton_Giao", SqlDbType.NVarChar, 50);
                    pTon_Giao.Value = myNL_Nhan_Vien_Chi_Tiet.Ton_Giao;
                    myCommand.Parameters.Add(pTon_Giao);

                    SqlParameter pNoi_Sinh = new SqlParameter("@Noi_Sinh", SqlDbType.NVarChar, 200);
                    pNoi_Sinh.Value = myNL_Nhan_Vien_Chi_Tiet.Noi_Sinh;
                    myCommand.Parameters.Add(pNoi_Sinh);

                    SqlParameter pQue_Quan = new SqlParameter("@Que_Quan", SqlDbType.NVarChar, 200);
                    pQue_Quan.Value = myNL_Nhan_Vien_Chi_Tiet.Que_Quan;
                    myCommand.Parameters.Add(pQue_Quan);

                    SqlParameter pThuong_Tru = new SqlParameter("@Thuong_Tru", SqlDbType.NVarChar, 200);
                    pThuong_Tru.Value = myNL_Nhan_Vien_Chi_Tiet.Thuong_Tru;
                    myCommand.Parameters.Add(pThuong_Tru);

                    SqlParameter pNoi_O = new SqlParameter("@Noi_O", SqlDbType.NVarChar, 200);
                    pNoi_O.Value = myNL_Nhan_Vien_Chi_Tiet.Noi_O;
                    myCommand.Parameters.Add(pNoi_O);

                    SqlParameter pNghe_Nghiep_Khi_Tuyen_Dung = new SqlParameter("@Nghe_Nghiep_Khi_Tuyen_Dung", SqlDbType.NVarChar, 300);
                    pNghe_Nghiep_Khi_Tuyen_Dung.Value = myNL_Nhan_Vien_Chi_Tiet.Nghe_Nghiep_Khi_Tuyen_Dung;
                    myCommand.Parameters.Add(pNghe_Nghiep_Khi_Tuyen_Dung);

                    SqlParameter pNgay_Tuyen_Dung = new SqlParameter("@Ngay_Tuyen_Dung", SqlDbType.DateTime, 8);
                    pNgay_Tuyen_Dung.Value = myNL_Nhan_Vien_Chi_Tiet.Ngay_Tuyen_Dung;
                    myCommand.Parameters.Add(pNgay_Tuyen_Dung);

                    SqlParameter pCo_Quan_Tuyen_Dung = new SqlParameter("@Co_Quan_Tuyen_Dung", SqlDbType.NVarChar, 500);
                    pCo_Quan_Tuyen_Dung.Value = myNL_Nhan_Vien_Chi_Tiet.Co_Quan_Tuyen_Dung;
                    myCommand.Parameters.Add(pCo_Quan_Tuyen_Dung);

                    SqlParameter pCong_Viec_Chinh = new SqlParameter("@Cong_Viec_Chinh", SqlDbType.NVarChar, 500);
                    pCong_Viec_Chinh.Value = myNL_Nhan_Vien_Chi_Tiet.Cong_Viec_Chinh;
                    myCommand.Parameters.Add(pCong_Viec_Chinh);

                    SqlParameter pSo_CMND = new SqlParameter("@So_CMND", SqlDbType.VarChar, 50);
                    pSo_CMND.Value = myNL_Nhan_Vien_Chi_Tiet.So_CMND;
                    myCommand.Parameters.Add(pSo_CMND);

                    SqlParameter pNgay_CMND = new SqlParameter("@Ngay_CMND", SqlDbType.DateTime, 8);
                    pNgay_CMND.Value = myNL_Nhan_Vien_Chi_Tiet.Ngay_CMND;
                    myCommand.Parameters.Add(pNgay_CMND);

                    SqlParameter pNoi_CMND = new SqlParameter("@Noi_CMND", SqlDbType.NVarChar, 200);
                    pNoi_CMND.Value = myNL_Nhan_Vien_Chi_Tiet.Noi_CMND;
                    myCommand.Parameters.Add(pNoi_CMND);

                    SqlParameter pThanh_Phan = new SqlParameter("@Thanh_Phan", SqlDbType.NVarChar, 500);
                    pThanh_Phan.Value = myNL_Nhan_Vien_Chi_Tiet.Thanh_Phan;
                    myCommand.Parameters.Add(pThanh_Phan);

                    SqlParameter pTrinh_Do_Giao_Duc_Pho_Thong = new SqlParameter("@Trinh_Do_Giao_Duc_Pho_Thong", SqlDbType.NVarChar, 500);
                    pTrinh_Do_Giao_Duc_Pho_Thong.Value = myNL_Nhan_Vien_Chi_Tiet.Trinh_Do_Giao_Duc_Pho_Thong;
                    myCommand.Parameters.Add(pTrinh_Do_Giao_Duc_Pho_Thong);

                    SqlParameter pNgay_Bat_Dau = new SqlParameter("@Ngay_Bat_Dau", SqlDbType.DateTime, 8);
                    pNgay_Bat_Dau.Value = myNL_Nhan_Vien_Chi_Tiet.Ngay_Bat_Dau;
                    myCommand.Parameters.Add(pNgay_Bat_Dau);

                    SqlParameter pNgay_Vao_Co_Quan = new SqlParameter("@Ngay_Vao_Co_Quan", SqlDbType.DateTime, 8);
                    pNgay_Vao_Co_Quan.Value = myNL_Nhan_Vien_Chi_Tiet.Ngay_Vao_Co_Quan;
                    myCommand.Parameters.Add(pNgay_Vao_Co_Quan);

                    SqlParameter pNgay_Vao_Doan = new SqlParameter("@Ngay_Vao_Doan", SqlDbType.DateTime, 8);
                    pNgay_Vao_Doan.Value = myNL_Nhan_Vien_Chi_Tiet.Ngay_Vao_Doan;
                    myCommand.Parameters.Add(pNgay_Vao_Doan);

                    SqlParameter pNoi_Vao_Doan = new SqlParameter("@Noi_Vao_Doan", SqlDbType.NVarChar, 200);
                    pNoi_Vao_Doan.Value = myNL_Nhan_Vien_Chi_Tiet.Noi_Vao_Doan;
                    myCommand.Parameters.Add(pNoi_Vao_Doan);

                    SqlParameter pNgay_Vao_Dang = new SqlParameter("@Ngay_Vao_Dang", SqlDbType.DateTime, 8);
                    pNgay_Vao_Dang.Value = myNL_Nhan_Vien_Chi_Tiet.Ngay_Vao_Dang;
                    myCommand.Parameters.Add(pNgay_Vao_Dang);

                    SqlParameter pNgay_Vao_Dang_Chinh_Thuc = new SqlParameter("@Ngay_Vao_Dang_Chinh_Thuc", SqlDbType.DateTime, 8);
                    pNgay_Vao_Dang_Chinh_Thuc.Value = myNL_Nhan_Vien_Chi_Tiet.Ngay_Vao_Dang_Chinh_Thuc;
                    myCommand.Parameters.Add(pNgay_Vao_Dang_Chinh_Thuc);

                    SqlParameter pNoi_Vao_Dang = new SqlParameter("@Noi_Vao_Dang", SqlDbType.NVarChar, 500);
                    pNoi_Vao_Dang.Value = myNL_Nhan_Vien_Chi_Tiet.Noi_Vao_Dang;
                    myCommand.Parameters.Add(pNoi_Vao_Dang);

                    SqlParameter pNgay_Khai_Tru_Dang = new SqlParameter("@Ngay_Khai_Tru_Dang", SqlDbType.DateTime, 8);
                    pNgay_Khai_Tru_Dang.Value = myNL_Nhan_Vien_Chi_Tiet.Ngay_Khai_Tru_Dang;
                    myCommand.Parameters.Add(pNgay_Khai_Tru_Dang);

                    SqlParameter pNgay_Nhap_Ngu = new SqlParameter("@Ngay_Nhap_Ngu", SqlDbType.DateTime, 8);
                    pNgay_Nhap_Ngu.Value = myNL_Nhan_Vien_Chi_Tiet.Ngay_Nhap_Ngu;
                    myCommand.Parameters.Add(pNgay_Nhap_Ngu);

                    SqlParameter pNgay_Xuat_Ngu = new SqlParameter("@Ngay_Xuat_Ngu", SqlDbType.DateTime, 8);
                    pNgay_Xuat_Ngu.Value = myNL_Nhan_Vien_Chi_Tiet.Ngay_Xuat_Ngu;
                    myCommand.Parameters.Add(pNgay_Xuat_Ngu);

                    SqlParameter pLy_Do_Xuat_Ngu = new SqlParameter("@Ly_Do_Xuat_Ngu", SqlDbType.NVarChar, 1000);
                    pLy_Do_Xuat_Ngu.Value = myNL_Nhan_Vien_Chi_Tiet.Ly_Do_Xuat_Ngu;
                    myCommand.Parameters.Add(pLy_Do_Xuat_Ngu);

                    SqlParameter pQuan_Ham_Cao_Nhat = new SqlParameter("@Quan_Ham_Cao_Nhat", SqlDbType.NVarChar, 500);
                    pQuan_Ham_Cao_Nhat.Value = myNL_Nhan_Vien_Chi_Tiet.Quan_Ham_Cao_Nhat;
                    myCommand.Parameters.Add(pQuan_Ham_Cao_Nhat);

                    SqlParameter pLa_Quan_Nhan = new SqlParameter("@La_Quan_Nhan", SqlDbType.Bit, 1);
                    pLa_Quan_Nhan.Value = myNL_Nhan_Vien_Chi_Tiet.La_Quan_Nhan;
                    myCommand.Parameters.Add(pLa_Quan_Nhan);

                    SqlParameter pDanh_Hieu_Cao_Nhat = new SqlParameter("@Danh_Hieu_Cao_Nhat", SqlDbType.NVarChar, 500);
                    pDanh_Hieu_Cao_Nhat.Value = myNL_Nhan_Vien_Chi_Tiet.Danh_Hieu_Cao_Nhat;
                    myCommand.Parameters.Add(pDanh_Hieu_Cao_Nhat);

                    SqlParameter pNgay_TGCM = new SqlParameter("@Ngay_TGCM", SqlDbType.DateTime, 8);
                    pNgay_TGCM.Value = myNL_Nhan_Vien_Chi_Tiet.Ngay_TGCM;
                    myCommand.Parameters.Add(pNgay_TGCM);

                    SqlParameter pDien_Thoai = new SqlParameter("@Dien_Thoai", SqlDbType.VarChar, 15);
                    pDien_Thoai.Value = myNL_Nhan_Vien_Chi_Tiet.Dien_Thoai;
                    myCommand.Parameters.Add(pDien_Thoai);

                    SqlParameter pSo_Truong = new SqlParameter("@So_Truong", SqlDbType.NVarChar, 50);
                    pSo_Truong.Value = myNL_Nhan_Vien_Chi_Tiet.So_Truong;
                    myCommand.Parameters.Add(pSo_Truong);

                    SqlParameter pSuc_Khoe = new SqlParameter("@Suc_Khoe", SqlDbType.NVarChar, 50);
                    pSuc_Khoe.Value = myNL_Nhan_Vien_Chi_Tiet.Suc_Khoe;
                    myCommand.Parameters.Add(pSuc_Khoe);

                    SqlParameter pMan_Tinh = new SqlParameter("@Man_Tinh", SqlDbType.NVarChar, 50);
                    pMan_Tinh.Value = myNL_Nhan_Vien_Chi_Tiet.Man_Tinh;
                    myCommand.Parameters.Add(pMan_Tinh);

                    SqlParameter pCao = new SqlParameter("@Cao", SqlDbType.Decimal);
                    pCao.Value = myNL_Nhan_Vien_Chi_Tiet.Cao;
                    myCommand.Parameters.Add(pCao);

                    SqlParameter pNang = new SqlParameter("@Nang", SqlDbType.Decimal);
                    pNang.Value = myNL_Nhan_Vien_Chi_Tiet.Nang;
                    myCommand.Parameters.Add(pNang);

                    SqlParameter pNhom_Mau = new SqlParameter("@Nhom_Mau", SqlDbType.NVarChar, 50);
                    pNhom_Mau.Value = myNL_Nhan_Vien_Chi_Tiet.Nhom_Mau;
                    myCommand.Parameters.Add(pNhom_Mau);

                    SqlParameter pLa_Thuong_Binh = new SqlParameter("@La_Thuong_Binh", SqlDbType.Bit, 1);
                    pLa_Thuong_Binh.Value = myNL_Nhan_Vien_Chi_Tiet.La_Thuong_Binh;
                    myCommand.Parameters.Add(pLa_Thuong_Binh);

                    SqlParameter pHang_Thuong_Binh = new SqlParameter("@Hang_Thuong_Binh", SqlDbType.NVarChar, 50);
                    pHang_Thuong_Binh.Value = myNL_Nhan_Vien_Chi_Tiet.Hang_Thuong_Binh;
                    myCommand.Parameters.Add(pHang_Thuong_Binh);

                    SqlParameter pCon_Gia_Dinh_Chinh_Sach = new SqlParameter("@Con_Gia_Dinh_Chinh_Sach", SqlDbType.Int, 4);
                    pCon_Gia_Dinh_Chinh_Sach.Value = myNL_Nhan_Vien_Chi_Tiet.Con_Gia_Dinh_Chinh_Sach;
                    myCommand.Parameters.Add(pCon_Gia_Dinh_Chinh_Sach);

                    SqlParameter pMa_So_So_BHXH = new SqlParameter("@Ma_So_So_BHXH", SqlDbType.VarChar, 50);
                    pMa_So_So_BHXH.Value = myNL_Nhan_Vien_Chi_Tiet.Ma_So_So_BHXH;
                    myCommand.Parameters.Add(pMa_So_So_BHXH);

                    SqlParameter pSo_So_BHXH = new SqlParameter("@So_So_BHXH", SqlDbType.VarChar, 50);
                    pSo_So_BHXH.Value = myNL_Nhan_Vien_Chi_Tiet.So_So_BHXH;
                    myCommand.Parameters.Add(pSo_So_BHXH);

                    SqlParameter pSo_So_Lao_Dong = new SqlParameter("@So_So_Lao_Dong", SqlDbType.VarChar, 50);
                    pSo_So_Lao_Dong.Value = myNL_Nhan_Vien_Chi_Tiet.So_So_Lao_Dong;
                    myCommand.Parameters.Add(pSo_So_Lao_Dong);

                    SqlParameter pNgay_Nghi_Viec = new SqlParameter("@Ngay_Nghi_Viec", SqlDbType.DateTime, 8);
                    pNgay_Nghi_Viec.Value = myNL_Nhan_Vien_Chi_Tiet.Ngay_Nghi_Viec;
                    myCommand.Parameters.Add(pNgay_Nghi_Viec);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NText);
                    pGhi_Chu.Value = myNL_Nhan_Vien_Chi_Tiet.Ghi_Chu;
                    myCommand.Parameters.Add(pGhi_Chu);

                    SqlParameter pMa_Phong = new SqlParameter("@Ma_Phong", SqlDbType.Int, 4);
                    pMa_Phong.Value = myNL_Nhan_Vien_Chi_Tiet.Ma_Phong;
                    myCommand.Parameters.Add(pMa_Phong);

                    SqlParameter pMa_Chinh_Tri = new SqlParameter("@Ma_Chinh_Tri", SqlDbType.Int, 4);
                    pMa_Chinh_Tri.Value = myNL_Nhan_Vien_Chi_Tiet.Ma_Chinh_Tri;
                    myCommand.Parameters.Add(pMa_Chinh_Tri);

                    SqlParameter pMa_Linh_Vuc = new SqlParameter("@Ma_Linh_Vuc", SqlDbType.Int, 4);
                    pMa_Linh_Vuc.Value = myNL_Nhan_Vien_Chi_Tiet.Ma_Linh_Vuc;
                    myCommand.Parameters.Add(pMa_Linh_Vuc);

                    SqlParameter pMa_QL_Nha_Nuoc = new SqlParameter("@Ma_QL_Nha_Nuoc", SqlDbType.Int, 4);
                    pMa_QL_Nha_Nuoc.Value = myNL_Nhan_Vien_Chi_Tiet.Ma_QL_Nha_Nuoc;
                    myCommand.Parameters.Add(pMa_QL_Nha_Nuoc);

                    SqlParameter pMa_Tin_Hoc = new SqlParameter("@Ma_Tin_Hoc", SqlDbType.Int, 4);
                    pMa_Tin_Hoc.Value = myNL_Nhan_Vien_Chi_Tiet.Ma_Tin_Hoc;
                    myCommand.Parameters.Add(pMa_Tin_Hoc);

                    SqlParameter pMa_Ngoai_Ngu = new SqlParameter("@Ma_Ngoai_Ngu", SqlDbType.Int, 4);
                    pMa_Ngoai_Ngu.Value = myNL_Nhan_Vien_Chi_Tiet.Ma_Ngoai_Ngu;
                    myCommand.Parameters.Add(pMa_Ngoai_Ngu);

                    SqlParameter pMa_Ngach = new SqlParameter("@Ma_Ngach", SqlDbType.VarChar, 50);
                    pMa_Ngach.Value = myNL_Nhan_Vien_Chi_Tiet.Ma_Ngach;
                    myCommand.Parameters.Add(pMa_Ngach);

                    SqlParameter pHinh_Anh = new SqlParameter("@Hinh_Anh", SqlDbType.NVarChar, 200);
                    pHinh_Anh.Value = myNL_Nhan_Vien_Chi_Tiet.Hinh_Anh;
                    myCommand.Parameters.Add(pHinh_Anh);

                    SqlParameter pMa_Chuc_Danh = new SqlParameter("@Ma_Chuc_Danh", SqlDbType.Int, 4);
                    pMa_Chuc_Danh.Value = myNL_Nhan_Vien_Chi_Tiet.Ma_Chuc_Danh;
                    myCommand.Parameters.Add(pMa_Chuc_Danh);

                    SqlParameter pMa_Chuyen_Mon = new SqlParameter("@Ma_Chuyen_Mon", SqlDbType.Int, 4);
                    pMa_Chuyen_Mon.Value = myNL_Nhan_Vien_Chi_Tiet.Ma_Chuyen_Mon;
                    myCommand.Parameters.Add(pMa_Chuyen_Mon);

                    SqlParameter pMa_Chuc_Vu = new SqlParameter("@Ma_Chuc_Vu", SqlDbType.Int, 4);
                    pMa_Chuc_Vu.Value = myNL_Nhan_Vien_Chi_Tiet.Ma_Chuc_Vu;
                    myCommand.Parameters.Add(pMa_Chuc_Vu);

                    SqlParameter pTieng_Dan_Toc = new SqlParameter("@Tieng_Dan_Toc", SqlDbType.Bit, 1);
                    pTieng_Dan_Toc.Value = myNL_Nhan_Vien_Chi_Tiet.Tieng_Dan_Toc;
                    myCommand.Parameters.Add(pTieng_Dan_Toc);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(DataSet myDataSet, String strTableName)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                        pMa_Nhan_Vien.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nhan_Vien"];
                        myCommand.Parameters.Add(pMa_Nhan_Vien);

                        SqlParameter pHo_Ten_Dem = new SqlParameter("@Ho_Ten_Dem", SqlDbType.NVarChar, 200);
                        pHo_Ten_Dem.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ho_Ten_Dem"];
                        myCommand.Parameters.Add(pHo_Ten_Dem);

                        SqlParameter pTen_Nhan_Vien = new SqlParameter("@Ten_Nhan_Vien", SqlDbType.NVarChar, 200);
                        pTen_Nhan_Vien.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ten_Nhan_Vien"];
                        myCommand.Parameters.Add(pTen_Nhan_Vien);

                        SqlParameter pSo_Hieu = new SqlParameter("@So_Hieu", SqlDbType.VarChar, 50);
                        pSo_Hieu.Value = (string)myDataSet.Tables[strTableName].Rows[i]["So_Hieu"];
                        myCommand.Parameters.Add(pSo_Hieu);

                        SqlParameter pMa_Ho_So = new SqlParameter("@Ma_Ho_So", SqlDbType.VarChar, 50);
                        pMa_Ho_So.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ma_Ho_So"];
                        myCommand.Parameters.Add(pMa_Ho_So);

                        SqlParameter pTen_Thuong_Dung = new SqlParameter("@Ten_Thuong_Dung", SqlDbType.NVarChar, 100);
                        pTen_Thuong_Dung.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ten_Thuong_Dung"];
                        myCommand.Parameters.Add(pTen_Thuong_Dung);

                        SqlParameter pBi_Danh = new SqlParameter("@Bi_Danh", SqlDbType.NVarChar, 100);
                        pBi_Danh.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Bi_Danh"];
                        myCommand.Parameters.Add(pBi_Danh);

                        SqlParameter pGioi_Tinh = new SqlParameter("@Gioi_Tinh", SqlDbType.Bit, 1);
                        pGioi_Tinh.Value = (bool)myDataSet.Tables[strTableName].Rows[i]["Gioi_Tinh"];
                        myCommand.Parameters.Add(pGioi_Tinh);

                        SqlParameter pNgay_Sinh = new SqlParameter("@Ngay_Sinh", SqlDbType.DateTime, 8);
                        pNgay_Sinh.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Ngay_Sinh"];
                        myCommand.Parameters.Add(pNgay_Sinh);

                        SqlParameter pMa_Dan_Toc = new SqlParameter("@Ma_Dan_Toc", SqlDbType.VarChar, 5);
                        pMa_Dan_Toc.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ma_Dan_Toc"];
                        myCommand.Parameters.Add(pMa_Dan_Toc);

                        SqlParameter pTon_Giao = new SqlParameter("@Ton_Giao", SqlDbType.NVarChar, 50);
                        pTon_Giao.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ton_Giao"];
                        myCommand.Parameters.Add(pTon_Giao);

                        SqlParameter pNoi_Sinh = new SqlParameter("@Noi_Sinh", SqlDbType.NVarChar, 200);
                        pNoi_Sinh.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Noi_Sinh"];
                        myCommand.Parameters.Add(pNoi_Sinh);

                        SqlParameter pQue_Quan = new SqlParameter("@Que_Quan", SqlDbType.NVarChar, 200);
                        pQue_Quan.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Que_Quan"];
                        myCommand.Parameters.Add(pQue_Quan);

                        SqlParameter pThuong_Tru = new SqlParameter("@Thuong_Tru", SqlDbType.NVarChar, 200);
                        pThuong_Tru.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Thuong_Tru"];
                        myCommand.Parameters.Add(pThuong_Tru);

                        SqlParameter pNoi_O = new SqlParameter("@Noi_O", SqlDbType.NVarChar, 200);
                        pNoi_O.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Noi_O"];
                        myCommand.Parameters.Add(pNoi_O);

                        SqlParameter pNghe_Nghiep_Khi_Tuyen_Dung = new SqlParameter("@Nghe_Nghiep_Khi_Tuyen_Dung", SqlDbType.NVarChar, 300);
                        pNghe_Nghiep_Khi_Tuyen_Dung.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Nghe_Nghiep_Khi_Tuyen_Dung"];
                        myCommand.Parameters.Add(pNghe_Nghiep_Khi_Tuyen_Dung);

                        SqlParameter pNgay_Tuyen_Dung = new SqlParameter("@Ngay_Tuyen_Dung", SqlDbType.DateTime, 8);
                        pNgay_Tuyen_Dung.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Ngay_Tuyen_Dung"];
                        myCommand.Parameters.Add(pNgay_Tuyen_Dung);

                        SqlParameter pCo_Quan_Tuyen_Dung = new SqlParameter("@Co_Quan_Tuyen_Dung", SqlDbType.NVarChar, 500);
                        pCo_Quan_Tuyen_Dung.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Co_Quan_Tuyen_Dung"];
                        myCommand.Parameters.Add(pCo_Quan_Tuyen_Dung);

                        SqlParameter pCong_Viec_Chinh = new SqlParameter("@Cong_Viec_Chinh", SqlDbType.NVarChar, 500);
                        pCong_Viec_Chinh.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Cong_Viec_Chinh"];
                        myCommand.Parameters.Add(pCong_Viec_Chinh);

                        SqlParameter pSo_CMND = new SqlParameter("@So_CMND", SqlDbType.VarChar, 50);
                        pSo_CMND.Value = (string)myDataSet.Tables[strTableName].Rows[i]["So_CMND"];
                        myCommand.Parameters.Add(pSo_CMND);

                        SqlParameter pNgay_CMND = new SqlParameter("@Ngay_CMND", SqlDbType.DateTime, 8);
                        pNgay_CMND.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Ngay_CMND"];
                        myCommand.Parameters.Add(pNgay_CMND);

                        SqlParameter pNoi_CMND = new SqlParameter("@Noi_CMND", SqlDbType.NVarChar, 200);
                        pNoi_CMND.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Noi_CMND"];
                        myCommand.Parameters.Add(pNoi_CMND);

                        SqlParameter pThanh_Phan = new SqlParameter("@Thanh_Phan", SqlDbType.NVarChar, 500);
                        pThanh_Phan.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Thanh_Phan"];
                        myCommand.Parameters.Add(pThanh_Phan);

                        SqlParameter pTrinh_Do_Giao_Duc_Pho_Thong = new SqlParameter("@Trinh_Do_Giao_Duc_Pho_Thong", SqlDbType.NVarChar, 500);
                        pTrinh_Do_Giao_Duc_Pho_Thong.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Trinh_Do_Giao_Duc_Pho_Thong"];
                        myCommand.Parameters.Add(pTrinh_Do_Giao_Duc_Pho_Thong);

                        SqlParameter pNgay_Bat_Dau = new SqlParameter("@Ngay_Bat_Dau", SqlDbType.DateTime, 8);
                        pNgay_Bat_Dau.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Ngay_Bat_Dau"];
                        myCommand.Parameters.Add(pNgay_Bat_Dau);

                        SqlParameter pNgay_Vao_Co_Quan = new SqlParameter("@Ngay_Vao_Co_Quan", SqlDbType.DateTime, 8);
                        pNgay_Vao_Co_Quan.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Ngay_Vao_Co_Quan"];
                        myCommand.Parameters.Add(pNgay_Vao_Co_Quan);

                        SqlParameter pNgay_Vao_Doan = new SqlParameter("@Ngay_Vao_Doan", SqlDbType.DateTime, 8);
                        pNgay_Vao_Doan.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Ngay_Vao_Doan"];
                        myCommand.Parameters.Add(pNgay_Vao_Doan);

                        SqlParameter pNoi_Vao_Doan = new SqlParameter("@Noi_Vao_Doan", SqlDbType.NVarChar, 200);
                        pNoi_Vao_Doan.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Noi_Vao_Doan"];
                        myCommand.Parameters.Add(pNoi_Vao_Doan);

                        SqlParameter pNgay_Vao_Dang = new SqlParameter("@Ngay_Vao_Dang", SqlDbType.DateTime, 8);
                        pNgay_Vao_Dang.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Ngay_Vao_Dang"];
                        myCommand.Parameters.Add(pNgay_Vao_Dang);

                        SqlParameter pNgay_Vao_Dang_Chinh_Thuc = new SqlParameter("@Ngay_Vao_Dang_Chinh_Thuc", SqlDbType.DateTime, 8);
                        pNgay_Vao_Dang_Chinh_Thuc.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Ngay_Vao_Dang_Chinh_Thuc"];
                        myCommand.Parameters.Add(pNgay_Vao_Dang_Chinh_Thuc);

                        SqlParameter pNoi_Vao_Dang = new SqlParameter("@Noi_Vao_Dang", SqlDbType.NVarChar, 500);
                        pNoi_Vao_Dang.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Noi_Vao_Dang"];
                        myCommand.Parameters.Add(pNoi_Vao_Dang);

                        SqlParameter pNgay_Khai_Tru_Dang = new SqlParameter("@Ngay_Khai_Tru_Dang", SqlDbType.DateTime, 8);
                        pNgay_Khai_Tru_Dang.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Ngay_Khai_Tru_Dang"];
                        myCommand.Parameters.Add(pNgay_Khai_Tru_Dang);

                        SqlParameter pNgay_Nhap_Ngu = new SqlParameter("@Ngay_Nhap_Ngu", SqlDbType.DateTime, 8);
                        pNgay_Nhap_Ngu.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Ngay_Nhap_Ngu"];
                        myCommand.Parameters.Add(pNgay_Nhap_Ngu);

                        SqlParameter pNgay_Xuat_Ngu = new SqlParameter("@Ngay_Xuat_Ngu", SqlDbType.DateTime, 8);
                        pNgay_Xuat_Ngu.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Ngay_Xuat_Ngu"];
                        myCommand.Parameters.Add(pNgay_Xuat_Ngu);

                        SqlParameter pLy_Do_Xuat_Ngu = new SqlParameter("@Ly_Do_Xuat_Ngu", SqlDbType.NVarChar, 1000);
                        pLy_Do_Xuat_Ngu.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ly_Do_Xuat_Ngu"];
                        myCommand.Parameters.Add(pLy_Do_Xuat_Ngu);

                        SqlParameter pQuan_Ham_Cao_Nhat = new SqlParameter("@Quan_Ham_Cao_Nhat", SqlDbType.NVarChar, 500);
                        pQuan_Ham_Cao_Nhat.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Quan_Ham_Cao_Nhat"];
                        myCommand.Parameters.Add(pQuan_Ham_Cao_Nhat);

                        SqlParameter pLa_Quan_Nhan = new SqlParameter("@La_Quan_Nhan", SqlDbType.Bit, 1);
                        pLa_Quan_Nhan.Value = (bool)myDataSet.Tables[strTableName].Rows[i]["La_Quan_Nhan"];
                        myCommand.Parameters.Add(pLa_Quan_Nhan);

                        SqlParameter pDanh_Hieu_Cao_Nhat = new SqlParameter("@Danh_Hieu_Cao_Nhat", SqlDbType.NVarChar, 500);
                        pDanh_Hieu_Cao_Nhat.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Danh_Hieu_Cao_Nhat"];
                        myCommand.Parameters.Add(pDanh_Hieu_Cao_Nhat);

                        SqlParameter pNgay_TGCM = new SqlParameter("@Ngay_TGCM", SqlDbType.DateTime, 8);
                        pNgay_TGCM.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Ngay_TGCM"];
                        myCommand.Parameters.Add(pNgay_TGCM);

                        SqlParameter pDien_Thoai = new SqlParameter("@Dien_Thoai", SqlDbType.VarChar, 15);
                        pDien_Thoai.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Dien_Thoai"];
                        myCommand.Parameters.Add(pDien_Thoai);

                        SqlParameter pSo_Truong = new SqlParameter("@So_Truong", SqlDbType.NVarChar, 50);
                        pSo_Truong.Value = (string)myDataSet.Tables[strTableName].Rows[i]["So_Truong"];
                        myCommand.Parameters.Add(pSo_Truong);

                        SqlParameter pSuc_Khoe = new SqlParameter("@Suc_Khoe", SqlDbType.NVarChar, 50);
                        pSuc_Khoe.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Suc_Khoe"];
                        myCommand.Parameters.Add(pSuc_Khoe);

                        SqlParameter pMan_Tinh = new SqlParameter("@Man_Tinh", SqlDbType.NVarChar, 50);
                        pMan_Tinh.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Man_Tinh"];
                        myCommand.Parameters.Add(pMan_Tinh);

                        SqlParameter pCao = new SqlParameter("@Cao", SqlDbType.Decimal);
                        pCao.Value = (decimal)myDataSet.Tables[strTableName].Rows[i]["Cao"];
                        myCommand.Parameters.Add(pCao);

                        SqlParameter pNang = new SqlParameter("@Nang", SqlDbType.Decimal);
                        pNang.Value = (decimal)myDataSet.Tables[strTableName].Rows[i]["Nang"];
                        myCommand.Parameters.Add(pNang);

                        SqlParameter pNhom_Mau = new SqlParameter("@Nhom_Mau", SqlDbType.NVarChar, 50);
                        pNhom_Mau.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Nhom_Mau"];
                        myCommand.Parameters.Add(pNhom_Mau);

                        SqlParameter pLa_Thuong_Binh = new SqlParameter("@La_Thuong_Binh", SqlDbType.Bit, 1);
                        pLa_Thuong_Binh.Value = (bool)myDataSet.Tables[strTableName].Rows[i]["La_Thuong_Binh"];
                        myCommand.Parameters.Add(pLa_Thuong_Binh);

                        SqlParameter pHang_Thuong_Binh = new SqlParameter("@Hang_Thuong_Binh", SqlDbType.NVarChar, 50);
                        pHang_Thuong_Binh.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Hang_Thuong_Binh"];
                        myCommand.Parameters.Add(pHang_Thuong_Binh);

                        SqlParameter pCon_Gia_Dinh_Chinh_Sach = new SqlParameter("@Con_Gia_Dinh_Chinh_Sach", SqlDbType.Int, 4);
                        pCon_Gia_Dinh_Chinh_Sach.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Con_Gia_Dinh_Chinh_Sach"];
                        myCommand.Parameters.Add(pCon_Gia_Dinh_Chinh_Sach);

                        SqlParameter pMa_So_So_BHXH = new SqlParameter("@Ma_So_So_BHXH", SqlDbType.VarChar, 50);
                        pMa_So_So_BHXH.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ma_So_So_BHXH"];
                        myCommand.Parameters.Add(pMa_So_So_BHXH);

                        SqlParameter pSo_So_BHXH = new SqlParameter("@So_So_BHXH", SqlDbType.VarChar, 50);
                        pSo_So_BHXH.Value = (string)myDataSet.Tables[strTableName].Rows[i]["So_So_BHXH"];
                        myCommand.Parameters.Add(pSo_So_BHXH);

                        SqlParameter pSo_So_Lao_Dong = new SqlParameter("@So_So_Lao_Dong", SqlDbType.VarChar, 50);
                        pSo_So_Lao_Dong.Value = (string)myDataSet.Tables[strTableName].Rows[i]["So_So_Lao_Dong"];
                        myCommand.Parameters.Add(pSo_So_Lao_Dong);

                        SqlParameter pNgay_Nghi_Viec = new SqlParameter("@Ngay_Nghi_Viec", SqlDbType.DateTime, 8);
                        pNgay_Nghi_Viec.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Ngay_Nghi_Viec"];
                        myCommand.Parameters.Add(pNgay_Nghi_Viec);

                        SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NText);
                        pGhi_Chu.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ghi_Chu"];
                        myCommand.Parameters.Add(pGhi_Chu);

                        SqlParameter pMa_Phong = new SqlParameter("@Ma_Phong", SqlDbType.Int, 4);
                        pMa_Phong.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Phong"];
                        myCommand.Parameters.Add(pMa_Phong);

                        SqlParameter pMa_Chinh_Tri = new SqlParameter("@Ma_Chinh_Tri", SqlDbType.Int, 4);
                        pMa_Chinh_Tri.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Chinh_Tri"];
                        myCommand.Parameters.Add(pMa_Chinh_Tri);

                        SqlParameter pMa_Linh_Vuc = new SqlParameter("@Ma_Linh_Vuc", SqlDbType.Int, 4);
                        pMa_Linh_Vuc.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Linh_Vuc"];
                        myCommand.Parameters.Add(pMa_Linh_Vuc);

                        SqlParameter pMa_QL_Nha_Nuoc = new SqlParameter("@Ma_QL_Nha_Nuoc", SqlDbType.Int, 4);
                        pMa_QL_Nha_Nuoc.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_QL_Nha_Nuoc"];
                        myCommand.Parameters.Add(pMa_QL_Nha_Nuoc);

                        SqlParameter pMa_Tin_Hoc = new SqlParameter("@Ma_Tin_Hoc", SqlDbType.Int, 4);
                        pMa_Tin_Hoc.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Tin_Hoc"];
                        myCommand.Parameters.Add(pMa_Tin_Hoc);

                        SqlParameter pMa_Ngoai_Ngu = new SqlParameter("@Ma_Ngoai_Ngu", SqlDbType.Int, 4);
                        pMa_Ngoai_Ngu.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Ngoai_Ngu"];
                        myCommand.Parameters.Add(pMa_Ngoai_Ngu);

                        SqlParameter pMa_Ngach = new SqlParameter("@Ma_Ngach", SqlDbType.VarChar, 50);
                        pMa_Ngach.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ma_Ngach"];
                        myCommand.Parameters.Add(pMa_Ngach);

                        SqlParameter pHinh_Anh = new SqlParameter("@Hinh_Anh", SqlDbType.NVarChar, 200);
                        pHinh_Anh.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Hinh_Anh"];
                        myCommand.Parameters.Add(pHinh_Anh);

                        SqlParameter pMa_Chuc_Danh = new SqlParameter("@Ma_Chuc_Danh", SqlDbType.Int, 4);
                        pMa_Chuc_Danh.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Chuc_Danh"];
                        myCommand.Parameters.Add(pMa_Chuc_Danh);

                        SqlParameter pMa_Chuyen_Mon = new SqlParameter("@Ma_Chuyen_Mon", SqlDbType.Int, 4);
                        pMa_Chuyen_Mon.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Chuyen_Mon"];
                        myCommand.Parameters.Add(pMa_Chuyen_Mon);

                        SqlParameter pMa_Chuc_Vu = new SqlParameter("@Ma_Chuc_Vu", SqlDbType.Int, 4);
                        pMa_Chuc_Vu.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Chuc_Vu"];
                        myCommand.Parameters.Add(pMa_Chuc_Vu);

                        SqlParameter pTieng_Dan_Toc = new SqlParameter("@Tieng_Dan_Toc", SqlDbType.Bit, 1);
                        pTieng_Dan_Toc.Value = (bool)myDataSet.Tables[strTableName].Rows[i]["Tieng_Dan_Toc"];
                        myCommand.Parameters.Add(pTieng_Dan_Toc);


                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public int Cap_Nhat_Them(int? Ma_Nhan_Vien = null, string Ho_Ten_Dem = null, string Ten_Nhan_Vien = null, string So_Hieu = null, string Ma_Ho_So = null, string Ten_Thuong_Dung = null, string Bi_Danh = null, bool? Gioi_Tinh = null, DateTime? Ngay_Sinh = null, string Ma_Dan_Toc = null, string Ton_Giao = null, string Noi_Sinh = null, string Que_Quan = null, string Thuong_Tru = null, string Noi_O = null, string Nghe_Nghiep_Khi_Tuyen_Dung = null, DateTime? Ngay_Tuyen_Dung = null, string Co_Quan_Tuyen_Dung = null, string Cong_Viec_Chinh = null, string So_CMND = null, DateTime? Ngay_CMND = null, string Noi_CMND = null, string Thanh_Phan = null, string Trinh_Do_Giao_Duc_Pho_Thong = null, DateTime? Ngay_Bat_Dau = null, DateTime? Ngay_Vao_Co_Quan = null, DateTime? Ngay_Vao_Doan = null, string Noi_Vao_Doan = null, DateTime? Ngay_Vao_Dang = null, DateTime? Ngay_Vao_Dang_Chinh_Thuc = null, string Noi_Vao_Dang = null, DateTime? Ngay_Khai_Tru_Dang = null, DateTime? Ngay_Nhap_Ngu = null, DateTime? Ngay_Xuat_Ngu = null, string Ly_Do_Xuat_Ngu = null, string Quan_Ham_Cao_Nhat = null, bool? La_Quan_Nhan = null, string Danh_Hieu_Cao_Nhat = null, DateTime? Ngay_TGCM = null, string Dien_Thoai = null, string So_Truong = null, string Suc_Khoe = null, string Man_Tinh = null, decimal? Cao = null, decimal? Nang = null, string Nhom_Mau = null, bool? La_Thuong_Binh = null, string Hang_Thuong_Binh = null, int? Con_Gia_Dinh_Chinh_Sach = null, string Ma_So_So_BHXH = null, string So_So_BHXH = null, string So_So_Lao_Dong = null, DateTime? Ngay_Nghi_Viec = null, string Ghi_Chu = null, int? Ma_Phong = null, int? Ma_Chinh_Tri = null, int? Ma_Linh_Vuc = null, int? Ma_QL_Nha_Nuoc = null, int? Ma_Tin_Hoc = null, int? Ma_Ngoai_Ngu = null, string Ma_Ngach = null, string Hinh_Anh = null, int? Ma_Chuc_Danh = null, int? Ma_Chuyen_Mon = null, int? Ma_Chuc_Vu = null, bool? Tieng_Dan_Toc = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pHo_Ten_Dem = new SqlParameter("@Ho_Ten_Dem", SqlDbType.NVarChar, 200);
                    pHo_Ten_Dem.Value = Ho_Ten_Dem;
                    myCommand.Parameters.Add(pHo_Ten_Dem);

                    SqlParameter pTen_Nhan_Vien = new SqlParameter("@Ten_Nhan_Vien", SqlDbType.NVarChar, 200);
                    pTen_Nhan_Vien.Value = Ten_Nhan_Vien;
                    myCommand.Parameters.Add(pTen_Nhan_Vien);

                    SqlParameter pSo_Hieu = new SqlParameter("@So_Hieu", SqlDbType.VarChar, 50);
                    pSo_Hieu.Value = So_Hieu;
                    myCommand.Parameters.Add(pSo_Hieu);

                    SqlParameter pMa_Ho_So = new SqlParameter("@Ma_Ho_So", SqlDbType.VarChar, 50);
                    pMa_Ho_So.Value = Ma_Ho_So;
                    myCommand.Parameters.Add(pMa_Ho_So);

                    SqlParameter pTen_Thuong_Dung = new SqlParameter("@Ten_Thuong_Dung", SqlDbType.NVarChar, 100);
                    pTen_Thuong_Dung.Value = Ten_Thuong_Dung;
                    myCommand.Parameters.Add(pTen_Thuong_Dung);

                    SqlParameter pBi_Danh = new SqlParameter("@Bi_Danh", SqlDbType.NVarChar, 100);
                    pBi_Danh.Value = Bi_Danh;
                    myCommand.Parameters.Add(pBi_Danh);

                    SqlParameter pGioi_Tinh = new SqlParameter("@Gioi_Tinh", SqlDbType.Bit, 1);
                    pGioi_Tinh.Value = Gioi_Tinh;
                    myCommand.Parameters.Add(pGioi_Tinh);

                    SqlParameter pNgay_Sinh = new SqlParameter("@Ngay_Sinh", SqlDbType.DateTime, 8);
                    pNgay_Sinh.Value = Ngay_Sinh;
                    myCommand.Parameters.Add(pNgay_Sinh);

                    SqlParameter pMa_Dan_Toc = new SqlParameter("@Ma_Dan_Toc", SqlDbType.VarChar, 5);
                    pMa_Dan_Toc.Value = Ma_Dan_Toc;
                    myCommand.Parameters.Add(pMa_Dan_Toc);

                    SqlParameter pTon_Giao = new SqlParameter("@Ton_Giao", SqlDbType.NVarChar, 50);
                    pTon_Giao.Value = Ton_Giao;
                    myCommand.Parameters.Add(pTon_Giao);

                    SqlParameter pNoi_Sinh = new SqlParameter("@Noi_Sinh", SqlDbType.NVarChar, 200);
                    pNoi_Sinh.Value = Noi_Sinh;
                    myCommand.Parameters.Add(pNoi_Sinh);

                    SqlParameter pQue_Quan = new SqlParameter("@Que_Quan", SqlDbType.NVarChar, 200);
                    pQue_Quan.Value = Que_Quan;
                    myCommand.Parameters.Add(pQue_Quan);

                    SqlParameter pThuong_Tru = new SqlParameter("@Thuong_Tru", SqlDbType.NVarChar, 200);
                    pThuong_Tru.Value = Thuong_Tru;
                    myCommand.Parameters.Add(pThuong_Tru);

                    SqlParameter pNoi_O = new SqlParameter("@Noi_O", SqlDbType.NVarChar, 200);
                    pNoi_O.Value = Noi_O;
                    myCommand.Parameters.Add(pNoi_O);

                    SqlParameter pNghe_Nghiep_Khi_Tuyen_Dung = new SqlParameter("@Nghe_Nghiep_Khi_Tuyen_Dung", SqlDbType.NVarChar, 300);
                    pNghe_Nghiep_Khi_Tuyen_Dung.Value = Nghe_Nghiep_Khi_Tuyen_Dung;
                    myCommand.Parameters.Add(pNghe_Nghiep_Khi_Tuyen_Dung);

                    SqlParameter pNgay_Tuyen_Dung = new SqlParameter("@Ngay_Tuyen_Dung", SqlDbType.DateTime, 8);
                    pNgay_Tuyen_Dung.Value = Ngay_Tuyen_Dung;
                    myCommand.Parameters.Add(pNgay_Tuyen_Dung);

                    SqlParameter pCo_Quan_Tuyen_Dung = new SqlParameter("@Co_Quan_Tuyen_Dung", SqlDbType.NVarChar, 500);
                    pCo_Quan_Tuyen_Dung.Value = Co_Quan_Tuyen_Dung;
                    myCommand.Parameters.Add(pCo_Quan_Tuyen_Dung);

                    SqlParameter pCong_Viec_Chinh = new SqlParameter("@Cong_Viec_Chinh", SqlDbType.NVarChar, 500);
                    pCong_Viec_Chinh.Value = Cong_Viec_Chinh;
                    myCommand.Parameters.Add(pCong_Viec_Chinh);

                    SqlParameter pSo_CMND = new SqlParameter("@So_CMND", SqlDbType.VarChar, 50);
                    pSo_CMND.Value = So_CMND;
                    myCommand.Parameters.Add(pSo_CMND);

                    SqlParameter pNgay_CMND = new SqlParameter("@Ngay_CMND", SqlDbType.DateTime, 8);
                    pNgay_CMND.Value = Ngay_CMND;
                    myCommand.Parameters.Add(pNgay_CMND);

                    SqlParameter pNoi_CMND = new SqlParameter("@Noi_CMND", SqlDbType.NVarChar, 200);
                    pNoi_CMND.Value = Noi_CMND;
                    myCommand.Parameters.Add(pNoi_CMND);

                    SqlParameter pThanh_Phan = new SqlParameter("@Thanh_Phan", SqlDbType.NVarChar, 500);
                    pThanh_Phan.Value = Thanh_Phan;
                    myCommand.Parameters.Add(pThanh_Phan);

                    SqlParameter pTrinh_Do_Giao_Duc_Pho_Thong = new SqlParameter("@Trinh_Do_Giao_Duc_Pho_Thong", SqlDbType.NVarChar, 500);
                    pTrinh_Do_Giao_Duc_Pho_Thong.Value = Trinh_Do_Giao_Duc_Pho_Thong;
                    myCommand.Parameters.Add(pTrinh_Do_Giao_Duc_Pho_Thong);

                    SqlParameter pNgay_Bat_Dau = new SqlParameter("@Ngay_Bat_Dau", SqlDbType.DateTime, 8);
                    pNgay_Bat_Dau.Value = Ngay_Bat_Dau;
                    myCommand.Parameters.Add(pNgay_Bat_Dau);

                    SqlParameter pNgay_Vao_Co_Quan = new SqlParameter("@Ngay_Vao_Co_Quan", SqlDbType.DateTime, 8);
                    pNgay_Vao_Co_Quan.Value = Ngay_Vao_Co_Quan;
                    myCommand.Parameters.Add(pNgay_Vao_Co_Quan);

                    SqlParameter pNgay_Vao_Doan = new SqlParameter("@Ngay_Vao_Doan", SqlDbType.DateTime, 8);
                    pNgay_Vao_Doan.Value = Ngay_Vao_Doan;
                    myCommand.Parameters.Add(pNgay_Vao_Doan);

                    SqlParameter pNoi_Vao_Doan = new SqlParameter("@Noi_Vao_Doan", SqlDbType.NVarChar, 200);
                    pNoi_Vao_Doan.Value = Noi_Vao_Doan;
                    myCommand.Parameters.Add(pNoi_Vao_Doan);

                    SqlParameter pNgay_Vao_Dang = new SqlParameter("@Ngay_Vao_Dang", SqlDbType.DateTime, 8);
                    pNgay_Vao_Dang.Value = Ngay_Vao_Dang;
                    myCommand.Parameters.Add(pNgay_Vao_Dang);

                    SqlParameter pNgay_Vao_Dang_Chinh_Thuc = new SqlParameter("@Ngay_Vao_Dang_Chinh_Thuc", SqlDbType.DateTime, 8);
                    pNgay_Vao_Dang_Chinh_Thuc.Value = Ngay_Vao_Dang_Chinh_Thuc;
                    myCommand.Parameters.Add(pNgay_Vao_Dang_Chinh_Thuc);

                    SqlParameter pNoi_Vao_Dang = new SqlParameter("@Noi_Vao_Dang", SqlDbType.NVarChar, 500);
                    pNoi_Vao_Dang.Value = Noi_Vao_Dang;
                    myCommand.Parameters.Add(pNoi_Vao_Dang);

                    SqlParameter pNgay_Khai_Tru_Dang = new SqlParameter("@Ngay_Khai_Tru_Dang", SqlDbType.DateTime, 8);
                    pNgay_Khai_Tru_Dang.Value = Ngay_Khai_Tru_Dang;
                    myCommand.Parameters.Add(pNgay_Khai_Tru_Dang);

                    SqlParameter pNgay_Nhap_Ngu = new SqlParameter("@Ngay_Nhap_Ngu", SqlDbType.DateTime, 8);
                    pNgay_Nhap_Ngu.Value = Ngay_Nhap_Ngu;
                    myCommand.Parameters.Add(pNgay_Nhap_Ngu);

                    SqlParameter pNgay_Xuat_Ngu = new SqlParameter("@Ngay_Xuat_Ngu", SqlDbType.DateTime, 8);
                    pNgay_Xuat_Ngu.Value = Ngay_Xuat_Ngu;
                    myCommand.Parameters.Add(pNgay_Xuat_Ngu);

                    SqlParameter pLy_Do_Xuat_Ngu = new SqlParameter("@Ly_Do_Xuat_Ngu", SqlDbType.NVarChar, 1000);
                    pLy_Do_Xuat_Ngu.Value = Ly_Do_Xuat_Ngu;
                    myCommand.Parameters.Add(pLy_Do_Xuat_Ngu);

                    SqlParameter pQuan_Ham_Cao_Nhat = new SqlParameter("@Quan_Ham_Cao_Nhat", SqlDbType.NVarChar, 500);
                    pQuan_Ham_Cao_Nhat.Value = Quan_Ham_Cao_Nhat;
                    myCommand.Parameters.Add(pQuan_Ham_Cao_Nhat);

                    SqlParameter pLa_Quan_Nhan = new SqlParameter("@La_Quan_Nhan", SqlDbType.Bit, 1);
                    pLa_Quan_Nhan.Value = La_Quan_Nhan;
                    myCommand.Parameters.Add(pLa_Quan_Nhan);

                    SqlParameter pDanh_Hieu_Cao_Nhat = new SqlParameter("@Danh_Hieu_Cao_Nhat", SqlDbType.NVarChar, 500);
                    pDanh_Hieu_Cao_Nhat.Value = Danh_Hieu_Cao_Nhat;
                    myCommand.Parameters.Add(pDanh_Hieu_Cao_Nhat);

                    SqlParameter pNgay_TGCM = new SqlParameter("@Ngay_TGCM", SqlDbType.DateTime, 8);
                    pNgay_TGCM.Value = Ngay_TGCM;
                    myCommand.Parameters.Add(pNgay_TGCM);

                    SqlParameter pDien_Thoai = new SqlParameter("@Dien_Thoai", SqlDbType.VarChar, 15);
                    pDien_Thoai.Value = Dien_Thoai;
                    myCommand.Parameters.Add(pDien_Thoai);

                    SqlParameter pSo_Truong = new SqlParameter("@So_Truong", SqlDbType.NVarChar, 50);
                    pSo_Truong.Value = So_Truong;
                    myCommand.Parameters.Add(pSo_Truong);

                    SqlParameter pSuc_Khoe = new SqlParameter("@Suc_Khoe", SqlDbType.NVarChar, 50);
                    pSuc_Khoe.Value = Suc_Khoe;
                    myCommand.Parameters.Add(pSuc_Khoe);

                    SqlParameter pMan_Tinh = new SqlParameter("@Man_Tinh", SqlDbType.NVarChar, 50);
                    pMan_Tinh.Value = Man_Tinh;
                    myCommand.Parameters.Add(pMan_Tinh);

                    SqlParameter pCao = new SqlParameter("@Cao", SqlDbType.Decimal);
                    pCao.Value = Cao;
                    myCommand.Parameters.Add(pCao);

                    SqlParameter pNang = new SqlParameter("@Nang", SqlDbType.Decimal);
                    pNang.Value = Nang;
                    myCommand.Parameters.Add(pNang);

                    SqlParameter pNhom_Mau = new SqlParameter("@Nhom_Mau", SqlDbType.NVarChar, 50);
                    pNhom_Mau.Value = Nhom_Mau;
                    myCommand.Parameters.Add(pNhom_Mau);

                    SqlParameter pLa_Thuong_Binh = new SqlParameter("@La_Thuong_Binh", SqlDbType.Bit, 1);
                    pLa_Thuong_Binh.Value = La_Thuong_Binh;
                    myCommand.Parameters.Add(pLa_Thuong_Binh);

                    SqlParameter pHang_Thuong_Binh = new SqlParameter("@Hang_Thuong_Binh", SqlDbType.NVarChar, 50);
                    pHang_Thuong_Binh.Value = Hang_Thuong_Binh;
                    myCommand.Parameters.Add(pHang_Thuong_Binh);

                    SqlParameter pCon_Gia_Dinh_Chinh_Sach = new SqlParameter("@Con_Gia_Dinh_Chinh_Sach", SqlDbType.Int, 4);
                    pCon_Gia_Dinh_Chinh_Sach.Value = Con_Gia_Dinh_Chinh_Sach;
                    myCommand.Parameters.Add(pCon_Gia_Dinh_Chinh_Sach);

                    SqlParameter pMa_So_So_BHXH = new SqlParameter("@Ma_So_So_BHXH", SqlDbType.VarChar, 50);
                    pMa_So_So_BHXH.Value = Ma_So_So_BHXH;
                    myCommand.Parameters.Add(pMa_So_So_BHXH);

                    SqlParameter pSo_So_BHXH = new SqlParameter("@So_So_BHXH", SqlDbType.VarChar, 50);
                    pSo_So_BHXH.Value = So_So_BHXH;
                    myCommand.Parameters.Add(pSo_So_BHXH);

                    SqlParameter pSo_So_Lao_Dong = new SqlParameter("@So_So_Lao_Dong", SqlDbType.VarChar, 50);
                    pSo_So_Lao_Dong.Value = So_So_Lao_Dong;
                    myCommand.Parameters.Add(pSo_So_Lao_Dong);

                    SqlParameter pNgay_Nghi_Viec = new SqlParameter("@Ngay_Nghi_Viec", SqlDbType.DateTime, 8);
                    pNgay_Nghi_Viec.Value = Ngay_Nghi_Viec;
                    myCommand.Parameters.Add(pNgay_Nghi_Viec);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NText);
                    pGhi_Chu.Value = Ghi_Chu;
                    myCommand.Parameters.Add(pGhi_Chu);

                    SqlParameter pMa_Phong = new SqlParameter("@Ma_Phong", SqlDbType.Int, 4);
                    pMa_Phong.Value = Ma_Phong;
                    myCommand.Parameters.Add(pMa_Phong);

                    SqlParameter pMa_Chinh_Tri = new SqlParameter("@Ma_Chinh_Tri", SqlDbType.Int, 4);
                    pMa_Chinh_Tri.Value = Ma_Chinh_Tri;
                    myCommand.Parameters.Add(pMa_Chinh_Tri);

                    SqlParameter pMa_Linh_Vuc = new SqlParameter("@Ma_Linh_Vuc", SqlDbType.Int, 4);
                    pMa_Linh_Vuc.Value = Ma_Linh_Vuc;
                    myCommand.Parameters.Add(pMa_Linh_Vuc);

                    SqlParameter pMa_QL_Nha_Nuoc = new SqlParameter("@Ma_QL_Nha_Nuoc", SqlDbType.Int, 4);
                    pMa_QL_Nha_Nuoc.Value = Ma_QL_Nha_Nuoc;
                    myCommand.Parameters.Add(pMa_QL_Nha_Nuoc);

                    SqlParameter pMa_Tin_Hoc = new SqlParameter("@Ma_Tin_Hoc", SqlDbType.Int, 4);
                    pMa_Tin_Hoc.Value = Ma_Tin_Hoc;
                    myCommand.Parameters.Add(pMa_Tin_Hoc);

                    SqlParameter pMa_Ngoai_Ngu = new SqlParameter("@Ma_Ngoai_Ngu", SqlDbType.Int, 4);
                    pMa_Ngoai_Ngu.Value = Ma_Ngoai_Ngu;
                    myCommand.Parameters.Add(pMa_Ngoai_Ngu);

                    SqlParameter pMa_Ngach = new SqlParameter("@Ma_Ngach", SqlDbType.VarChar, 50);
                    pMa_Ngach.Value = Ma_Ngach;
                    myCommand.Parameters.Add(pMa_Ngach);

                    SqlParameter pHinh_Anh = new SqlParameter("@Hinh_Anh", SqlDbType.NVarChar, 200);
                    pHinh_Anh.Value = Hinh_Anh;
                    myCommand.Parameters.Add(pHinh_Anh);

                    SqlParameter pMa_Chuc_Danh = new SqlParameter("@Ma_Chuc_Danh", SqlDbType.Int, 4);
                    pMa_Chuc_Danh.Value = Ma_Chuc_Danh;
                    myCommand.Parameters.Add(pMa_Chuc_Danh);

                    SqlParameter pMa_Chuyen_Mon = new SqlParameter("@Ma_Chuyen_Mon", SqlDbType.Int, 4);
                    pMa_Chuyen_Mon.Value = Ma_Chuyen_Mon;
                    myCommand.Parameters.Add(pMa_Chuyen_Mon);

                    SqlParameter pMa_Chuc_Vu = new SqlParameter("@Ma_Chuc_Vu", SqlDbType.Int, 4);
                    pMa_Chuc_Vu.Value = Ma_Chuc_Vu;
                    myCommand.Parameters.Add(pMa_Chuc_Vu);

                    SqlParameter pTieng_Dan_Toc = new SqlParameter("@Tieng_Dan_Toc", SqlDbType.Bit, 1);
                    pTieng_Dan_Toc.Value = Tieng_Dan_Toc;
                    myCommand.Parameters.Add(pTieng_Dan_Toc);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    return (int)pMa_Nhan_Vien.Value;
                }
            }
        }
        #endregion
        #region Cap_Nhat_Them
        public int Cap_Nhat_Them(NL_Nhan_Vien_Chi_Tiet myNL_Nhan_Vien_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Direction = ParameterDirection.InputOutput;
                    pMa_Nhan_Vien.Value = myNL_Nhan_Vien_Chi_Tiet.Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pHo_Ten_Dem = new SqlParameter("@Ho_Ten_Dem", SqlDbType.NVarChar, 200);
                    pHo_Ten_Dem.Value = myNL_Nhan_Vien_Chi_Tiet.Ho_Ten_Dem;
                    myCommand.Parameters.Add(pHo_Ten_Dem);

                    SqlParameter pTen_Nhan_Vien = new SqlParameter("@Ten_Nhan_Vien", SqlDbType.NVarChar, 200);
                    pTen_Nhan_Vien.Value = myNL_Nhan_Vien_Chi_Tiet.Ten_Nhan_Vien;
                    myCommand.Parameters.Add(pTen_Nhan_Vien);

                    SqlParameter pSo_Hieu = new SqlParameter("@So_Hieu", SqlDbType.VarChar, 50);
                    pSo_Hieu.Value = myNL_Nhan_Vien_Chi_Tiet.So_Hieu;
                    myCommand.Parameters.Add(pSo_Hieu);

                    SqlParameter pMa_Ho_So = new SqlParameter("@Ma_Ho_So", SqlDbType.VarChar, 50);
                    pMa_Ho_So.Value = myNL_Nhan_Vien_Chi_Tiet.Ma_Ho_So;
                    myCommand.Parameters.Add(pMa_Ho_So);

                    SqlParameter pTen_Thuong_Dung = new SqlParameter("@Ten_Thuong_Dung", SqlDbType.NVarChar, 100);
                    pTen_Thuong_Dung.Value = myNL_Nhan_Vien_Chi_Tiet.Ten_Thuong_Dung;
                    myCommand.Parameters.Add(pTen_Thuong_Dung);

                    SqlParameter pBi_Danh = new SqlParameter("@Bi_Danh", SqlDbType.NVarChar, 100);
                    pBi_Danh.Value = myNL_Nhan_Vien_Chi_Tiet.Bi_Danh;
                    myCommand.Parameters.Add(pBi_Danh);

                    SqlParameter pGioi_Tinh = new SqlParameter("@Gioi_Tinh", SqlDbType.Bit, 1);
                    pGioi_Tinh.Value = myNL_Nhan_Vien_Chi_Tiet.Gioi_Tinh;
                    myCommand.Parameters.Add(pGioi_Tinh);

                    SqlParameter pNgay_Sinh = new SqlParameter("@Ngay_Sinh", SqlDbType.DateTime, 8);
                    pNgay_Sinh.Value = myNL_Nhan_Vien_Chi_Tiet.Ngay_Sinh;
                    myCommand.Parameters.Add(pNgay_Sinh);

                    SqlParameter pMa_Dan_Toc = new SqlParameter("@Ma_Dan_Toc", SqlDbType.VarChar, 5);
                    pMa_Dan_Toc.Value = myNL_Nhan_Vien_Chi_Tiet.Ma_Dan_Toc;
                    myCommand.Parameters.Add(pMa_Dan_Toc);

                    SqlParameter pTon_Giao = new SqlParameter("@Ton_Giao", SqlDbType.NVarChar, 50);
                    pTon_Giao.Value = myNL_Nhan_Vien_Chi_Tiet.Ton_Giao;
                    myCommand.Parameters.Add(pTon_Giao);

                    SqlParameter pNoi_Sinh = new SqlParameter("@Noi_Sinh", SqlDbType.NVarChar, 200);
                    pNoi_Sinh.Value = myNL_Nhan_Vien_Chi_Tiet.Noi_Sinh;
                    myCommand.Parameters.Add(pNoi_Sinh);

                    SqlParameter pQue_Quan = new SqlParameter("@Que_Quan", SqlDbType.NVarChar, 200);
                    pQue_Quan.Value = myNL_Nhan_Vien_Chi_Tiet.Que_Quan;
                    myCommand.Parameters.Add(pQue_Quan);

                    SqlParameter pThuong_Tru = new SqlParameter("@Thuong_Tru", SqlDbType.NVarChar, 200);
                    pThuong_Tru.Value = myNL_Nhan_Vien_Chi_Tiet.Thuong_Tru;
                    myCommand.Parameters.Add(pThuong_Tru);

                    SqlParameter pNoi_O = new SqlParameter("@Noi_O", SqlDbType.NVarChar, 200);
                    pNoi_O.Value = myNL_Nhan_Vien_Chi_Tiet.Noi_O;
                    myCommand.Parameters.Add(pNoi_O);

                    SqlParameter pNghe_Nghiep_Khi_Tuyen_Dung = new SqlParameter("@Nghe_Nghiep_Khi_Tuyen_Dung", SqlDbType.NVarChar, 300);
                    pNghe_Nghiep_Khi_Tuyen_Dung.Value = myNL_Nhan_Vien_Chi_Tiet.Nghe_Nghiep_Khi_Tuyen_Dung;
                    myCommand.Parameters.Add(pNghe_Nghiep_Khi_Tuyen_Dung);

                    SqlParameter pNgay_Tuyen_Dung = new SqlParameter("@Ngay_Tuyen_Dung", SqlDbType.DateTime, 8);
                    pNgay_Tuyen_Dung.Value = myNL_Nhan_Vien_Chi_Tiet.Ngay_Tuyen_Dung;
                    myCommand.Parameters.Add(pNgay_Tuyen_Dung);

                    SqlParameter pCo_Quan_Tuyen_Dung = new SqlParameter("@Co_Quan_Tuyen_Dung", SqlDbType.NVarChar, 500);
                    pCo_Quan_Tuyen_Dung.Value = myNL_Nhan_Vien_Chi_Tiet.Co_Quan_Tuyen_Dung;
                    myCommand.Parameters.Add(pCo_Quan_Tuyen_Dung);

                    SqlParameter pCong_Viec_Chinh = new SqlParameter("@Cong_Viec_Chinh", SqlDbType.NVarChar, 500);
                    pCong_Viec_Chinh.Value = myNL_Nhan_Vien_Chi_Tiet.Cong_Viec_Chinh;
                    myCommand.Parameters.Add(pCong_Viec_Chinh);

                    SqlParameter pSo_CMND = new SqlParameter("@So_CMND", SqlDbType.VarChar, 50);
                    pSo_CMND.Value = myNL_Nhan_Vien_Chi_Tiet.So_CMND;
                    myCommand.Parameters.Add(pSo_CMND);

                    SqlParameter pNgay_CMND = new SqlParameter("@Ngay_CMND", SqlDbType.DateTime, 8);
                    pNgay_CMND.Value = myNL_Nhan_Vien_Chi_Tiet.Ngay_CMND;
                    myCommand.Parameters.Add(pNgay_CMND);

                    SqlParameter pNoi_CMND = new SqlParameter("@Noi_CMND", SqlDbType.NVarChar, 200);
                    pNoi_CMND.Value = myNL_Nhan_Vien_Chi_Tiet.Noi_CMND;
                    myCommand.Parameters.Add(pNoi_CMND);

                    SqlParameter pThanh_Phan = new SqlParameter("@Thanh_Phan", SqlDbType.NVarChar, 500);
                    pThanh_Phan.Value = myNL_Nhan_Vien_Chi_Tiet.Thanh_Phan;
                    myCommand.Parameters.Add(pThanh_Phan);

                    SqlParameter pTrinh_Do_Giao_Duc_Pho_Thong = new SqlParameter("@Trinh_Do_Giao_Duc_Pho_Thong", SqlDbType.NVarChar, 500);
                    pTrinh_Do_Giao_Duc_Pho_Thong.Value = myNL_Nhan_Vien_Chi_Tiet.Trinh_Do_Giao_Duc_Pho_Thong;
                    myCommand.Parameters.Add(pTrinh_Do_Giao_Duc_Pho_Thong);

                    SqlParameter pNgay_Bat_Dau = new SqlParameter("@Ngay_Bat_Dau", SqlDbType.DateTime, 8);
                    pNgay_Bat_Dau.Value = myNL_Nhan_Vien_Chi_Tiet.Ngay_Bat_Dau;
                    myCommand.Parameters.Add(pNgay_Bat_Dau);

                    SqlParameter pNgay_Vao_Co_Quan = new SqlParameter("@Ngay_Vao_Co_Quan", SqlDbType.DateTime, 8);
                    pNgay_Vao_Co_Quan.Value = myNL_Nhan_Vien_Chi_Tiet.Ngay_Vao_Co_Quan;
                    myCommand.Parameters.Add(pNgay_Vao_Co_Quan);

                    SqlParameter pNgay_Vao_Doan = new SqlParameter("@Ngay_Vao_Doan", SqlDbType.DateTime, 8);
                    pNgay_Vao_Doan.Value = myNL_Nhan_Vien_Chi_Tiet.Ngay_Vao_Doan;
                    myCommand.Parameters.Add(pNgay_Vao_Doan);

                    SqlParameter pNoi_Vao_Doan = new SqlParameter("@Noi_Vao_Doan", SqlDbType.NVarChar, 200);
                    pNoi_Vao_Doan.Value = myNL_Nhan_Vien_Chi_Tiet.Noi_Vao_Doan;
                    myCommand.Parameters.Add(pNoi_Vao_Doan);

                    SqlParameter pNgay_Vao_Dang = new SqlParameter("@Ngay_Vao_Dang", SqlDbType.DateTime, 8);
                    pNgay_Vao_Dang.Value = myNL_Nhan_Vien_Chi_Tiet.Ngay_Vao_Dang;
                    myCommand.Parameters.Add(pNgay_Vao_Dang);

                    SqlParameter pNgay_Vao_Dang_Chinh_Thuc = new SqlParameter("@Ngay_Vao_Dang_Chinh_Thuc", SqlDbType.DateTime, 8);
                    pNgay_Vao_Dang_Chinh_Thuc.Value = myNL_Nhan_Vien_Chi_Tiet.Ngay_Vao_Dang_Chinh_Thuc;
                    myCommand.Parameters.Add(pNgay_Vao_Dang_Chinh_Thuc);

                    SqlParameter pNoi_Vao_Dang = new SqlParameter("@Noi_Vao_Dang", SqlDbType.NVarChar, 500);
                    pNoi_Vao_Dang.Value = myNL_Nhan_Vien_Chi_Tiet.Noi_Vao_Dang;
                    myCommand.Parameters.Add(pNoi_Vao_Dang);

                    SqlParameter pNgay_Khai_Tru_Dang = new SqlParameter("@Ngay_Khai_Tru_Dang", SqlDbType.DateTime, 8);
                    pNgay_Khai_Tru_Dang.Value = myNL_Nhan_Vien_Chi_Tiet.Ngay_Khai_Tru_Dang;
                    myCommand.Parameters.Add(pNgay_Khai_Tru_Dang);

                    SqlParameter pNgay_Nhap_Ngu = new SqlParameter("@Ngay_Nhap_Ngu", SqlDbType.DateTime, 8);
                    pNgay_Nhap_Ngu.Value = myNL_Nhan_Vien_Chi_Tiet.Ngay_Nhap_Ngu;
                    myCommand.Parameters.Add(pNgay_Nhap_Ngu);

                    SqlParameter pNgay_Xuat_Ngu = new SqlParameter("@Ngay_Xuat_Ngu", SqlDbType.DateTime, 8);
                    pNgay_Xuat_Ngu.Value = myNL_Nhan_Vien_Chi_Tiet.Ngay_Xuat_Ngu;
                    myCommand.Parameters.Add(pNgay_Xuat_Ngu);

                    SqlParameter pLy_Do_Xuat_Ngu = new SqlParameter("@Ly_Do_Xuat_Ngu", SqlDbType.NVarChar, 1000);
                    pLy_Do_Xuat_Ngu.Value = myNL_Nhan_Vien_Chi_Tiet.Ly_Do_Xuat_Ngu;
                    myCommand.Parameters.Add(pLy_Do_Xuat_Ngu);

                    SqlParameter pQuan_Ham_Cao_Nhat = new SqlParameter("@Quan_Ham_Cao_Nhat", SqlDbType.NVarChar, 500);
                    pQuan_Ham_Cao_Nhat.Value = myNL_Nhan_Vien_Chi_Tiet.Quan_Ham_Cao_Nhat;
                    myCommand.Parameters.Add(pQuan_Ham_Cao_Nhat);

                    SqlParameter pLa_Quan_Nhan = new SqlParameter("@La_Quan_Nhan", SqlDbType.Bit, 1);
                    pLa_Quan_Nhan.Value = myNL_Nhan_Vien_Chi_Tiet.La_Quan_Nhan;
                    myCommand.Parameters.Add(pLa_Quan_Nhan);

                    SqlParameter pDanh_Hieu_Cao_Nhat = new SqlParameter("@Danh_Hieu_Cao_Nhat", SqlDbType.NVarChar, 500);
                    pDanh_Hieu_Cao_Nhat.Value = myNL_Nhan_Vien_Chi_Tiet.Danh_Hieu_Cao_Nhat;
                    myCommand.Parameters.Add(pDanh_Hieu_Cao_Nhat);

                    SqlParameter pNgay_TGCM = new SqlParameter("@Ngay_TGCM", SqlDbType.DateTime, 8);
                    pNgay_TGCM.Value = myNL_Nhan_Vien_Chi_Tiet.Ngay_TGCM;
                    myCommand.Parameters.Add(pNgay_TGCM);

                    SqlParameter pDien_Thoai = new SqlParameter("@Dien_Thoai", SqlDbType.VarChar, 15);
                    pDien_Thoai.Value = myNL_Nhan_Vien_Chi_Tiet.Dien_Thoai;
                    myCommand.Parameters.Add(pDien_Thoai);

                    SqlParameter pSo_Truong = new SqlParameter("@So_Truong", SqlDbType.NVarChar, 50);
                    pSo_Truong.Value = myNL_Nhan_Vien_Chi_Tiet.So_Truong;
                    myCommand.Parameters.Add(pSo_Truong);

                    SqlParameter pSuc_Khoe = new SqlParameter("@Suc_Khoe", SqlDbType.NVarChar, 50);
                    pSuc_Khoe.Value = myNL_Nhan_Vien_Chi_Tiet.Suc_Khoe;
                    myCommand.Parameters.Add(pSuc_Khoe);

                    SqlParameter pMan_Tinh = new SqlParameter("@Man_Tinh", SqlDbType.NVarChar, 50);
                    pMan_Tinh.Value = myNL_Nhan_Vien_Chi_Tiet.Man_Tinh;
                    myCommand.Parameters.Add(pMan_Tinh);

                    SqlParameter pCao = new SqlParameter("@Cao", SqlDbType.Decimal);
                    pCao.Value = myNL_Nhan_Vien_Chi_Tiet.Cao;
                    myCommand.Parameters.Add(pCao);

                    SqlParameter pNang = new SqlParameter("@Nang", SqlDbType.Decimal);
                    pNang.Value = myNL_Nhan_Vien_Chi_Tiet.Nang;
                    myCommand.Parameters.Add(pNang);

                    SqlParameter pNhom_Mau = new SqlParameter("@Nhom_Mau", SqlDbType.NVarChar, 50);
                    pNhom_Mau.Value = myNL_Nhan_Vien_Chi_Tiet.Nhom_Mau;
                    myCommand.Parameters.Add(pNhom_Mau);

                    SqlParameter pLa_Thuong_Binh = new SqlParameter("@La_Thuong_Binh", SqlDbType.Bit, 1);
                    pLa_Thuong_Binh.Value = myNL_Nhan_Vien_Chi_Tiet.La_Thuong_Binh;
                    myCommand.Parameters.Add(pLa_Thuong_Binh);

                    SqlParameter pHang_Thuong_Binh = new SqlParameter("@Hang_Thuong_Binh", SqlDbType.NVarChar, 50);
                    pHang_Thuong_Binh.Value = myNL_Nhan_Vien_Chi_Tiet.Hang_Thuong_Binh;
                    myCommand.Parameters.Add(pHang_Thuong_Binh);

                    SqlParameter pCon_Gia_Dinh_Chinh_Sach = new SqlParameter("@Con_Gia_Dinh_Chinh_Sach", SqlDbType.Int, 4);
                    pCon_Gia_Dinh_Chinh_Sach.Value = myNL_Nhan_Vien_Chi_Tiet.Con_Gia_Dinh_Chinh_Sach;
                    myCommand.Parameters.Add(pCon_Gia_Dinh_Chinh_Sach);

                    SqlParameter pMa_So_So_BHXH = new SqlParameter("@Ma_So_So_BHXH", SqlDbType.VarChar, 50);
                    pMa_So_So_BHXH.Value = myNL_Nhan_Vien_Chi_Tiet.Ma_So_So_BHXH;
                    myCommand.Parameters.Add(pMa_So_So_BHXH);

                    SqlParameter pSo_So_BHXH = new SqlParameter("@So_So_BHXH", SqlDbType.VarChar, 50);
                    pSo_So_BHXH.Value = myNL_Nhan_Vien_Chi_Tiet.So_So_BHXH;
                    myCommand.Parameters.Add(pSo_So_BHXH);

                    SqlParameter pSo_So_Lao_Dong = new SqlParameter("@So_So_Lao_Dong", SqlDbType.VarChar, 50);
                    pSo_So_Lao_Dong.Value = myNL_Nhan_Vien_Chi_Tiet.So_So_Lao_Dong;
                    myCommand.Parameters.Add(pSo_So_Lao_Dong);

                    SqlParameter pNgay_Nghi_Viec = new SqlParameter("@Ngay_Nghi_Viec", SqlDbType.DateTime, 8);
                    pNgay_Nghi_Viec.Value = myNL_Nhan_Vien_Chi_Tiet.Ngay_Nghi_Viec;
                    myCommand.Parameters.Add(pNgay_Nghi_Viec);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NText);
                    pGhi_Chu.Value = myNL_Nhan_Vien_Chi_Tiet.Ghi_Chu;
                    myCommand.Parameters.Add(pGhi_Chu);

                    SqlParameter pMa_Phong = new SqlParameter("@Ma_Phong", SqlDbType.Int, 4);
                    pMa_Phong.Value = myNL_Nhan_Vien_Chi_Tiet.Ma_Phong;
                    myCommand.Parameters.Add(pMa_Phong);

                    SqlParameter pMa_Chinh_Tri = new SqlParameter("@Ma_Chinh_Tri", SqlDbType.Int, 4);
                    pMa_Chinh_Tri.Value = myNL_Nhan_Vien_Chi_Tiet.Ma_Chinh_Tri;
                    myCommand.Parameters.Add(pMa_Chinh_Tri);

                    SqlParameter pMa_Linh_Vuc = new SqlParameter("@Ma_Linh_Vuc", SqlDbType.Int, 4);
                    pMa_Linh_Vuc.Value = myNL_Nhan_Vien_Chi_Tiet.Ma_Linh_Vuc;
                    myCommand.Parameters.Add(pMa_Linh_Vuc);

                    SqlParameter pMa_QL_Nha_Nuoc = new SqlParameter("@Ma_QL_Nha_Nuoc", SqlDbType.Int, 4);
                    pMa_QL_Nha_Nuoc.Value = myNL_Nhan_Vien_Chi_Tiet.Ma_QL_Nha_Nuoc;
                    myCommand.Parameters.Add(pMa_QL_Nha_Nuoc);

                    SqlParameter pMa_Tin_Hoc = new SqlParameter("@Ma_Tin_Hoc", SqlDbType.Int, 4);
                    pMa_Tin_Hoc.Value = myNL_Nhan_Vien_Chi_Tiet.Ma_Tin_Hoc;
                    myCommand.Parameters.Add(pMa_Tin_Hoc);

                    SqlParameter pMa_Ngoai_Ngu = new SqlParameter("@Ma_Ngoai_Ngu", SqlDbType.Int, 4);
                    pMa_Ngoai_Ngu.Value = myNL_Nhan_Vien_Chi_Tiet.Ma_Ngoai_Ngu;
                    myCommand.Parameters.Add(pMa_Ngoai_Ngu);

                    SqlParameter pMa_Ngach = new SqlParameter("@Ma_Ngach", SqlDbType.VarChar, 50);
                    pMa_Ngach.Value = myNL_Nhan_Vien_Chi_Tiet.Ma_Ngach;
                    myCommand.Parameters.Add(pMa_Ngach);

                    SqlParameter pHinh_Anh = new SqlParameter("@Hinh_Anh", SqlDbType.NVarChar, 200);
                    pHinh_Anh.Value = myNL_Nhan_Vien_Chi_Tiet.Hinh_Anh;
                    myCommand.Parameters.Add(pHinh_Anh);

                    SqlParameter pMa_Chuc_Danh = new SqlParameter("@Ma_Chuc_Danh", SqlDbType.Int, 4);
                    pMa_Chuc_Danh.Value = myNL_Nhan_Vien_Chi_Tiet.Ma_Chuc_Danh;
                    myCommand.Parameters.Add(pMa_Chuc_Danh);

                    SqlParameter pMa_Chuyen_Mon = new SqlParameter("@Ma_Chuyen_Mon", SqlDbType.Int, 4);
                    pMa_Chuyen_Mon.Value = myNL_Nhan_Vien_Chi_Tiet.Ma_Chuyen_Mon;
                    myCommand.Parameters.Add(pMa_Chuyen_Mon);

                    SqlParameter pMa_Chuc_Vu = new SqlParameter("@Ma_Chuc_Vu", SqlDbType.Int, 4);
                    pMa_Chuc_Vu.Value = myNL_Nhan_Vien_Chi_Tiet.Ma_Chuc_Vu;
                    myCommand.Parameters.Add(pMa_Chuc_Vu);

                    SqlParameter pTieng_Dan_Toc = new SqlParameter("@Tieng_Dan_Toc", SqlDbType.Bit, 1);
                    pTieng_Dan_Toc.Value = myNL_Nhan_Vien_Chi_Tiet.Tieng_Dan_Toc;
                    myCommand.Parameters.Add(pTieng_Dan_Toc);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                    return (int)pMa_Nhan_Vien.Value;
                }
            }
        }
        #endregion
        #region Xoa
        public void Xoa(int Ma_Nhan_Vien)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Danh_Sach
        public DataTable Danh_Sach()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Nhan_Vien_Danh_Sach");
                    return myDataSet.Tables["NL_Nhan_Vien_Danh_Sach"];
                }
            }
        }
        #endregion

        #region Lay_Boi_NL_DM_Phong_Ban
        public DataTable Lay_Boi_NL_DM_Phong_Ban(int Ma_Phong)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Lay_Boi_NL_DM_Phong_Ban", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Phong = new SqlParameter("@Ma_Phong", SqlDbType.Int, 4);
                    pMa_Phong.Value = Ma_Phong;
                    myCommand.Parameters.Add(pMa_Phong);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Nhan_Vien_Lay_Boi_NL_DM_Phong_Ban");
                    return myDataSet.Tables["NL_Nhan_Vien_Lay_Boi_NL_DM_Phong_Ban"];
                }
            }
        }
        #endregion

        #region Danh Sach Het han tap su truoc 1 thang của huyện
        public DataTable NL_TB_HetHanTapSu_Huyen(string Ma_Huyen)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_TB_HetHanTapSu_Huyen", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 20);
                    pMa_Huyen.Value = Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_TB_HetHanTapSu_Huyen");
                    return myDataSet.Tables["NL_TB_HetHanTapSu_Huyen"];
                }
            }
        }
        #endregion

        #region Danh sách hết hạn tập sự trước 1 tháng của 1 đơn vị
        public DataTable NL_TB_HetHanTapSu_DonVi(int Ma_Don_Vi)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_TB_HetHanTapSu_DonVi", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_TB_HetHanTapSu_DonVi");
                    return myDataSet.Tables["NL_TB_HetHanTapSu_DonVi"];
                }
            }
        }
        #endregion

        #region Danh_Sach Hết hạn tập sự trước 1 tháng của toàn tỉnh
        public DataTable NL_TB_HetHanTapSu_Tinh()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_TB_HetHanTapSu_Tinh", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_TB_HetHanTapSu_Tinh");
                    return myDataSet.Tables["NL_TB_HetHanTapSu_Tinh"];
                }
            }
        }
        #endregion
    }
    #endregion


}