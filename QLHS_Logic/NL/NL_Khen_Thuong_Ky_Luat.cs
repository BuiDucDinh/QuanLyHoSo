using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic{
    #region NL_Khen_Thuong_Ky_Luat_Details
    public class NL_Khen_Thuong_Ky_Luat_Chi_Tiet
    {
        public int? Ma_Khen_Thuong_Ky_Luat = null; // Mã khen thưởng kỷ luật
        public int? Ma_Nhan_Vien = null; // Mã nhân viên
        public DateTime? Tu_Ngay = null; // Từ ngày
        public DateTime? Den_Ngay = null; // Đến ngày
        public DateTime? Ngay_Quyet_Dinh = null; // Ngày quyết định
        public string Noi_Quyet_Dinh = null; // Nơi quyết định
        public string Ly_Do = null; // Lý do
        public int? Hinh_Thuc = null; // Hình thức
        public bool? Trang_Thai = null; // 0.Ky luat,1.Khen Thuong
        public string Ghi_Chu = null; // Ghi chú
        public int? Linh_Vuc = null;
        public bool? Hinh_Thuc_Cao_Nhat = null;
        public string So_Van_Ban_Quyet_Dinh = null;//Số văn bản quyết định
        public string Chuc_Vu_Nguoi_Ky = null;//Chức vụ người ký
        public int? Ma_Luong_Truoc = null;//Mã lương, hệ số,bậc trước khi quyết định
        public int? Ma_Qua_Trinh_Truoc = null;//Mã quá trình, chức vụ trước khi quyết định
        public int? Ma_Luong_Sau = null;//Mã lương, hệ số,bậc sau khi quyết định
        public int? Ma_Qua_Trinh_Sau = null;//Mã quá trình, chức vụ sau khi quyết định
    }
    #endregion
    #region NL_Khen_Thuong_Ky_Luat
    public class NL_Khen_Thuong_Ky_Luat
    {
        private string ConnectionString;
        public NL_Khen_Thuong_Ky_Luat(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_Khen_Thuong_Ky_Luat_Chi_Tiet Lay(int Ma_Khen_Thuong_Ky_Luat)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Khen_Thuong_Ky_Luat_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Khen_Thuong_Ky_Luat = new SqlParameter("@Ma_Khen_Thuong_Ky_Luat", SqlDbType.Int, 4);
                    pMa_Khen_Thuong_Ky_Luat.Value = Ma_Khen_Thuong_Ky_Luat;
                    myCommand.Parameters.Add(pMa_Khen_Thuong_Ky_Luat);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Khen_Thuong_Ky_Luat_Chi_Tiet");
                    NL_Khen_Thuong_Ky_Luat_Chi_Tiet myNL_Khen_Thuong_Ky_Luat_Chi_Tiet = new NL_Khen_Thuong_Ky_Luat_Chi_Tiet();
                    if (myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"] != null)
                    {
                        myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.Ma_Khen_Thuong_Ky_Luat = Ma_Khen_Thuong_Ky_Luat;
                        myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.Ma_Nhan_Vien = myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] : (int?)null;
                        myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.Tu_Ngay = myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"].Rows[0]["Tu_Ngay"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"].Rows[0]["Tu_Ngay"] : (DateTime?)null;
                        myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.Den_Ngay = myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"].Rows[0]["Den_Ngay"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"].Rows[0]["Den_Ngay"] : (DateTime?)null;
                        myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.Ngay_Quyet_Dinh = myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"].Rows[0]["Ngay_Quyet_Dinh"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"].Rows[0]["Ngay_Quyet_Dinh"] : (DateTime?)null;
                        myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.Noi_Quyet_Dinh = myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"].Rows[0]["Noi_Quyet_Dinh"] != DBNull.Value ? (string)myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"].Rows[0]["Noi_Quyet_Dinh"] : (string)null;
                        myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.Ly_Do = myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"].Rows[0]["Ly_Do"] != DBNull.Value ? (string)myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"].Rows[0]["Ly_Do"] : (string)null;
                        myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.Hinh_Thuc = myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"].Rows[0]["Hinh_Thuc"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"].Rows[0]["Hinh_Thuc"] : (int?)null;
                        myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.Trang_Thai = myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"].Rows[0]["Trang_Thai"] != DBNull.Value ? (bool?)myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"].Rows[0]["Trang_Thai"] : (bool?)null;
                        myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.Ghi_Chu = myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"].Rows[0]["Ghi_Chu"] != DBNull.Value ? (string)myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"].Rows[0]["Ghi_Chu"] : (string)null;

                        myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.Linh_Vuc = myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"].Rows[0]["Linh_Vuc"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"].Rows[0]["Linh_Vuc"] : (int?)null;

                        myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.Hinh_Thuc_Cao_Nhat = myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"].Rows[0]["Hinh_Thuc_Cao_Nhat"] != DBNull.Value ? (bool?)myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"].Rows[0]["Hinh_Thuc_Cao_Nhat"] : (bool?)null;
                        myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.So_Van_Ban_Quyet_Dinh = myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"].Rows[0]["So_Van_Ban_Quyet_Dinh"] != DBNull.Value ? (string)myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"].Rows[0]["So_Van_Ban_Quyet_Dinh"] : (string)null;
                        myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.Chuc_Vu_Nguoi_Ky = myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"].Rows[0]["Chuc_Vu_Nguoi_Ky"] != DBNull.Value ? (string)myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"].Rows[0]["Chuc_Vu_Nguoi_Ky"] : (string)null;
                        myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.Ma_Luong_Truoc = myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"].Rows[0]["Ma_Luong_Truoc"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"].Rows[0]["Ma_Luong_Truoc"] : (int?)null;
                        myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.Ma_Qua_Trinh_Truoc = myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"].Rows[0]["Ma_Qua_Trinh_Truoc"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"].Rows[0]["Ma_Qua_Trinh_Truoc"] : (int?)null;
                        myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.Ma_Luong_Sau = myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"].Rows[0]["Ma_Luong_Sau"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"].Rows[0]["Ma_Luong_Sau"] : (int?)null;
                        myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.Ma_Qua_Trinh_Sau = myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"].Rows[0]["Ma_Qua_Trinh_Sau"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Chi_Tiet"].Rows[0]["Ma_Qua_Trinh_Sau"] : (int?)null;
                    }
                    return myNL_Khen_Thuong_Ky_Luat_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Ma_Khen_Thuong_Ky_Luat = null, int? Ma_Nhan_Vien = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null, DateTime? Ngay_Quyet_Dinh = null, string Noi_Quyet_Dinh = null, string Ly_Do = null, int? Hinh_Thuc = null, bool? Trang_Thai = null, string Ghi_Chu = null, int? Linh_Vuc = null, bool? Hinh_Thuc_Cao_Nhat = null, string So_Van_Ban_Quyet_Dinh = null, string Chuc_Vu_Nguoi_Ky = null, int? Ma_Luong_Truoc = null, int? Ma_Qua_Trinh_Truoc = null, int? Ma_Luong_Sau = null, int? Ma_Qua_Trinh_Sau = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Khen_Thuong_Ky_Luat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Khen_Thuong_Ky_Luat = new SqlParameter("@Ma_Khen_Thuong_Ky_Luat", SqlDbType.Int, 4);
                    pMa_Khen_Thuong_Ky_Luat.Value = Ma_Khen_Thuong_Ky_Luat;
                    myCommand.Parameters.Add(pMa_Khen_Thuong_Ky_Luat);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pNgay_Quyet_Dinh = new SqlParameter("@Ngay_Quyet_Dinh", SqlDbType.DateTime, 8);
                    pNgay_Quyet_Dinh.Value = Ngay_Quyet_Dinh;
                    myCommand.Parameters.Add(pNgay_Quyet_Dinh);

                    SqlParameter pNoi_Quyet_Dinh = new SqlParameter("@Noi_Quyet_Dinh", SqlDbType.NVarChar, 500);
                    pNoi_Quyet_Dinh.Value = Noi_Quyet_Dinh;
                    myCommand.Parameters.Add(pNoi_Quyet_Dinh);

                    SqlParameter pLy_Do = new SqlParameter("@Ly_Do", SqlDbType.NVarChar, 500);
                    pLy_Do.Value = Ly_Do;
                    myCommand.Parameters.Add(pLy_Do);

                    SqlParameter pHinh_Thuc = new SqlParameter("@Hinh_Thuc", SqlDbType.Int, 4);
                    pHinh_Thuc.Value = Hinh_Thuc;
                    myCommand.Parameters.Add(pHinh_Thuc);

                    SqlParameter pTrang_Thai = new SqlParameter("@Trang_Thai", SqlDbType.Bit, 1);
                    pTrang_Thai.Value = Trang_Thai;
                    myCommand.Parameters.Add(pTrang_Thai);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 500);
                    pGhi_Chu.Value = Ghi_Chu;
                    myCommand.Parameters.Add(pGhi_Chu);

                    SqlParameter pLinh_Vuc = new SqlParameter("@Linh_Vuc", SqlDbType.Int, 4);
                    pLinh_Vuc.Value = Linh_Vuc;
                    myCommand.Parameters.Add(pLinh_Vuc);

                    SqlParameter pHinh_Thuc_Cao_Nhat = new SqlParameter("@Hinh_Thuc_Cao_Nhat", SqlDbType.Bit, 1);
                    pHinh_Thuc_Cao_Nhat.Value = Hinh_Thuc_Cao_Nhat;
                    myCommand.Parameters.Add(pHinh_Thuc_Cao_Nhat);

                    SqlParameter pSo_Van_Ban_Quyet_Dinh = new SqlParameter("@So_Van_Ban_Quyet_Dinh", SqlDbType.NVarChar, 500);
                    pSo_Van_Ban_Quyet_Dinh.Value = So_Van_Ban_Quyet_Dinh;
                    myCommand.Parameters.Add(pSo_Van_Ban_Quyet_Dinh);

                    SqlParameter pChuc_Vu_Nguoi_Ky = new SqlParameter("@Chuc_Vu_Nguoi_Ky", SqlDbType.NVarChar, 500);
                    pChuc_Vu_Nguoi_Ky.Value = Chuc_Vu_Nguoi_Ky;
                    myCommand.Parameters.Add(pChuc_Vu_Nguoi_Ky);

                    SqlParameter pMa_Luong_Truoc = new SqlParameter("@Ma_Luong_Truoc", SqlDbType.Int, 4);
                    pMa_Luong_Truoc.Value = Ma_Luong_Truoc;
                    myCommand.Parameters.Add(pMa_Luong_Truoc);

                    SqlParameter pMa_Qua_Trinh_Truoc = new SqlParameter("@Ma_Qua_Trinh_Truoc", SqlDbType.Int, 4);
                    pMa_Qua_Trinh_Truoc.Value = Ma_Qua_Trinh_Truoc;
                    myCommand.Parameters.Add(pMa_Qua_Trinh_Truoc);

                    SqlParameter pMa_Luong_Sau = new SqlParameter("@Ma_Luong_Sau", SqlDbType.Int, 4);
                    pMa_Luong_Sau.Value = Ma_Luong_Sau;
                    myCommand.Parameters.Add(pMa_Luong_Sau);

                    SqlParameter pMa_Qua_Trinh_Sau = new SqlParameter("@Ma_Qua_Trinh_Sau", SqlDbType.Int, 4);
                    pMa_Qua_Trinh_Sau.Value = Ma_Qua_Trinh_Sau;
                    myCommand.Parameters.Add(pMa_Qua_Trinh_Sau);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int? Ma_Khen_Thuong_Ky_Luat = null, int? Ma_Nhan_Vien = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null, DateTime? Ngay_Quyet_Dinh = null, string Noi_Quyet_Dinh = null, string Ly_Do = null, int? Hinh_Thuc = null, bool? Trang_Thai = null, string Ghi_Chu = null, int? Linh_Vuc = null, bool? Hinh_Thuc_Cao_Nhat = null, string So_Van_Ban_Quyet_Dinh = null, string Chuc_Vu_Nguoi_Ky = null, int? Ma_Luong_Truoc = null, int? Ma_Qua_Trinh_Truoc = null, int? Ma_Luong_Sau = null, int? Ma_Qua_Trinh_Sau = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Khen_Thuong_Ky_Luat_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Khen_Thuong_Ky_Luat = new SqlParameter("@Ma_Khen_Thuong_Ky_Luat", SqlDbType.Int, 4);
                    pMa_Khen_Thuong_Ky_Luat.Value = Ma_Khen_Thuong_Ky_Luat;
                    myCommand.Parameters.Add(pMa_Khen_Thuong_Ky_Luat);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pNgay_Quyet_Dinh = new SqlParameter("@Ngay_Quyet_Dinh", SqlDbType.DateTime, 8);
                    pNgay_Quyet_Dinh.Value = Ngay_Quyet_Dinh;
                    myCommand.Parameters.Add(pNgay_Quyet_Dinh);

                    SqlParameter pNoi_Quyet_Dinh = new SqlParameter("@Noi_Quyet_Dinh", SqlDbType.NVarChar, 500);
                    pNoi_Quyet_Dinh.Value = Noi_Quyet_Dinh;
                    myCommand.Parameters.Add(pNoi_Quyet_Dinh);

                    SqlParameter pLy_Do = new SqlParameter("@Ly_Do", SqlDbType.NVarChar, 500);
                    pLy_Do.Value = Ly_Do;
                    myCommand.Parameters.Add(pLy_Do);

                    SqlParameter pHinh_Thuc = new SqlParameter("@Hinh_Thuc", SqlDbType.Int);
                    pHinh_Thuc.Value = Hinh_Thuc;
                    myCommand.Parameters.Add(pHinh_Thuc);

                    SqlParameter pTrang_Thai = new SqlParameter("@Trang_Thai", SqlDbType.Bit, 1);
                    pTrang_Thai.Value = Trang_Thai;
                    myCommand.Parameters.Add(pTrang_Thai);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 500);
                    pGhi_Chu.Value = Ghi_Chu;
                    myCommand.Parameters.Add(pGhi_Chu);

                    SqlParameter pLinh_Vuc = new SqlParameter("@Linh_Vuc", SqlDbType.Int);
                    pLinh_Vuc.Value = Linh_Vuc;
                    myCommand.Parameters.Add(pLinh_Vuc);

                    SqlParameter pHinh_Thuc_Cao_Nhat = new SqlParameter("@Hinh_Thuc_Cao_Nhat", SqlDbType.Bit, 1);
                    pHinh_Thuc_Cao_Nhat.Value = Hinh_Thuc_Cao_Nhat;
                    myCommand.Parameters.Add(pHinh_Thuc_Cao_Nhat);

                    SqlParameter pSo_Van_Ban_Quyet_Dinh = new SqlParameter("@So_Van_Ban_Quyet_Dinh", SqlDbType.NVarChar, 500);
                    pSo_Van_Ban_Quyet_Dinh.Value = So_Van_Ban_Quyet_Dinh;
                    myCommand.Parameters.Add(pSo_Van_Ban_Quyet_Dinh);

                    SqlParameter pChuc_Vu_Nguoi_Ky = new SqlParameter("@Chuc_Vu_Nguoi_Ky", SqlDbType.NVarChar, 500);
                    pChuc_Vu_Nguoi_Ky.Value = Chuc_Vu_Nguoi_Ky;
                    myCommand.Parameters.Add(pChuc_Vu_Nguoi_Ky);

                    SqlParameter pMa_Luong_Truoc = new SqlParameter("@Ma_Luong_Truoc", SqlDbType.Int, 4);
                    pMa_Luong_Truoc.Value = Ma_Luong_Truoc;
                    myCommand.Parameters.Add(pMa_Luong_Truoc);

                    SqlParameter pMa_Qua_Trinh_Truoc = new SqlParameter("@Ma_Qua_Trinh_Truoc", SqlDbType.Int, 4);
                    pMa_Qua_Trinh_Truoc.Value = Ma_Qua_Trinh_Truoc;
                    myCommand.Parameters.Add(pMa_Qua_Trinh_Truoc);

                    SqlParameter pMa_Luong_Sau = new SqlParameter("@Ma_Luong_Sau", SqlDbType.Int, 4);
                    pMa_Luong_Sau.Value = Ma_Luong_Sau;
                    myCommand.Parameters.Add(pMa_Luong_Sau);

                    SqlParameter pMa_Qua_Trinh_Sau = new SqlParameter("@Ma_Qua_Trinh_Sau", SqlDbType.Int, 4);
                    pMa_Qua_Trinh_Sau.Value = Ma_Qua_Trinh_Sau;
                    myCommand.Parameters.Add(pMa_Qua_Trinh_Sau);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(NL_Khen_Thuong_Ky_Luat_Chi_Tiet myNL_Khen_Thuong_Ky_Luat_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Khen_Thuong_Ky_Luat_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Khen_Thuong_Ky_Luat = new SqlParameter("@Ma_Khen_Thuong_Ky_Luat", SqlDbType.Int, 4);
                    pMa_Khen_Thuong_Ky_Luat.Value = myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.Ma_Khen_Thuong_Ky_Luat;
                    myCommand.Parameters.Add(pMa_Khen_Thuong_Ky_Luat);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pNgay_Quyet_Dinh = new SqlParameter("@Ngay_Quyet_Dinh", SqlDbType.DateTime, 8);
                    pNgay_Quyet_Dinh.Value = myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.Ngay_Quyet_Dinh;
                    myCommand.Parameters.Add(pNgay_Quyet_Dinh);

                    SqlParameter pNoi_Quyet_Dinh = new SqlParameter("@Noi_Quyet_Dinh", SqlDbType.NVarChar, 500);
                    pNoi_Quyet_Dinh.Value = myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.Noi_Quyet_Dinh;
                    myCommand.Parameters.Add(pNoi_Quyet_Dinh);

                    SqlParameter pLy_Do = new SqlParameter("@Ly_Do", SqlDbType.NVarChar, 500);
                    pLy_Do.Value = myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.Ly_Do;
                    myCommand.Parameters.Add(pLy_Do);

                    SqlParameter pHinh_Thuc = new SqlParameter("@Hinh_Thuc", SqlDbType.Int);
                    pHinh_Thuc.Value = myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.Hinh_Thuc;
                    myCommand.Parameters.Add(pHinh_Thuc);

                    SqlParameter pTrang_Thai = new SqlParameter("@Trang_Thai", SqlDbType.Bit, 1);
                    pTrang_Thai.Value = myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.Trang_Thai;
                    myCommand.Parameters.Add(pTrang_Thai);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 500);
                    pGhi_Chu.Value = myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.Ghi_Chu;
                    myCommand.Parameters.Add(pGhi_Chu);


                    SqlParameter pLinh_Vuc = new SqlParameter("@Linh_Vuc", SqlDbType.Int);
                    pLinh_Vuc.Value = myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.Linh_Vuc;
                    myCommand.Parameters.Add(pLinh_Vuc);


                    SqlParameter pHinh_Thuc_Cao_Nhat = new SqlParameter("@Hinh_Thuc_Cao_Nhat", SqlDbType.Bit, 1);
                    pHinh_Thuc_Cao_Nhat.Value = myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.Hinh_Thuc_Cao_Nhat;
                    myCommand.Parameters.Add(pHinh_Thuc_Cao_Nhat);

                    SqlParameter pSo_Van_Ban_Quyet_Dinh = new SqlParameter("@So_Van_Ban_Quyet_Dinh", SqlDbType.NVarChar, 500);
                    pSo_Van_Ban_Quyet_Dinh.Value = myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.So_Van_Ban_Quyet_Dinh;
                    myCommand.Parameters.Add(pSo_Van_Ban_Quyet_Dinh);

                    SqlParameter pChuc_Vu_Nguoi_Ky = new SqlParameter("@Chuc_Vu_Nguoi_Ky", SqlDbType.NVarChar, 500);
                    pChuc_Vu_Nguoi_Ky.Value = myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.Chuc_Vu_Nguoi_Ky;
                    myCommand.Parameters.Add(pChuc_Vu_Nguoi_Ky);

                    SqlParameter pMa_Luong_Truoc = new SqlParameter("@Ma_Luong_Truoc", SqlDbType.Int, 4);
                    pMa_Luong_Truoc.Value = myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.Ma_Luong_Truoc;
                    myCommand.Parameters.Add(pMa_Luong_Truoc);

                    SqlParameter pMa_Qua_Trinh_Truoc = new SqlParameter("@Ma_Qua_Trinh_Truoc", SqlDbType.Int, 4);
                    pMa_Qua_Trinh_Truoc.Value = myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.Ma_Qua_Trinh_Truoc;
                    myCommand.Parameters.Add(pMa_Qua_Trinh_Truoc);

                    SqlParameter pMa_Luong_Sau = new SqlParameter("@Ma_Luong_Sau", SqlDbType.Int, 4);
                    pMa_Luong_Sau.Value = myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.Ma_Luong_Sau;
                    myCommand.Parameters.Add(pMa_Luong_Sau);

                    SqlParameter pMa_Qua_Trinh_Sau = new SqlParameter("@Ma_Qua_Trinh_Sau", SqlDbType.Int, 4);
                    pMa_Qua_Trinh_Sau.Value = myNL_Khen_Thuong_Ky_Luat_Chi_Tiet.Ma_Qua_Trinh_Sau;
                    myCommand.Parameters.Add(pMa_Qua_Trinh_Sau);

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
                using (SqlCommand myCommand = new SqlCommand("NL_Khen_Thuong_Ky_Luat_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Khen_Thuong_Ky_Luat = new SqlParameter("@Ma_Khen_Thuong_Ky_Luat", SqlDbType.Int, 4);
                        pMa_Khen_Thuong_Ky_Luat.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Khen_Thuong_Ky_Luat"];
                        myCommand.Parameters.Add(pMa_Khen_Thuong_Ky_Luat);

                        SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                        pMa_Nhan_Vien.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nhan_Vien"];
                        myCommand.Parameters.Add(pMa_Nhan_Vien);

                        SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                        pTu_Ngay.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Tu_Ngay"];
                        myCommand.Parameters.Add(pTu_Ngay);

                        SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                        pDen_Ngay.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Den_Ngay"];
                        myCommand.Parameters.Add(pDen_Ngay);

                        SqlParameter pNgay_Quyet_Dinh = new SqlParameter("@Ngay_Quyet_Dinh", SqlDbType.DateTime, 8);
                        pNgay_Quyet_Dinh.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Ngay_Quyet_Dinh"];
                        myCommand.Parameters.Add(pNgay_Quyet_Dinh);

                        SqlParameter pNoi_Quyet_Dinh = new SqlParameter("@Noi_Quyet_Dinh", SqlDbType.NVarChar, 500);
                        pNoi_Quyet_Dinh.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Noi_Quyet_Dinh"];
                        myCommand.Parameters.Add(pNoi_Quyet_Dinh);

                        SqlParameter pLy_Do = new SqlParameter("@Ly_Do", SqlDbType.NVarChar, 500);
                        pLy_Do.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ly_Do"];
                        myCommand.Parameters.Add(pLy_Do);

                        SqlParameter pHinh_Thuc = new SqlParameter("@Hinh_Thuc", SqlDbType.Int);
                        pHinh_Thuc.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Hinh_Thuc"];
                        myCommand.Parameters.Add(pHinh_Thuc);

                        SqlParameter pTrang_Thai = new SqlParameter("@Trang_Thai", SqlDbType.Bit, 1);
                        pTrang_Thai.Value = (bool)myDataSet.Tables[strTableName].Rows[i]["Trang_Thai"];
                        myCommand.Parameters.Add(pTrang_Thai);

                        SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 500);
                        pGhi_Chu.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ghi_Chu"];
                        myCommand.Parameters.Add(pGhi_Chu);


                        SqlParameter pLinh_Vuc = new SqlParameter("@Linh_Vuc", SqlDbType.Int);
                        pLinh_Vuc.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Linh_Vuc"];
                        myCommand.Parameters.Add(pLinh_Vuc);


                        SqlParameter pHinh_Thuc_Cao_Nhat = new SqlParameter("@Hinh_Thuc_Cao_Nhat", SqlDbType.Bit, 1);
                        pHinh_Thuc_Cao_Nhat.Value = (bool)myDataSet.Tables[strTableName].Rows[i]["Hinh_Thuc_Cao_Nhat"];
                        myCommand.Parameters.Add(pHinh_Thuc_Cao_Nhat);


                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int? Ma_Khen_Thuong_Ky_Luat = null, int? Ma_Nhan_Vien = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null, DateTime? Ngay_Quyet_Dinh = null, string Noi_Quyet_Dinh = null, string Ly_Do = null, int? Hinh_Thuc = null, bool? Trang_Thai = null, string Ghi_Chu = null, int? Linh_Vuc = null, bool? Hinh_Thuc_Cao_Nhat = null, string So_Van_Ban_Quyet_Dinh = null, string Chuc_Vu_Nguoi_Ky = null, int? Ma_Luong_Truoc = null, int? Ma_Qua_Trinh_Truoc = null, int? Ma_Luong_Sau = null, int? Ma_Qua_Trinh_Sau = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Khen_Thuong_Ky_Luat_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Khen_Thuong_Ky_Luat = new SqlParameter("@Ma_Khen_Thuong_Ky_Luat", SqlDbType.Int, 4);
                    pMa_Khen_Thuong_Ky_Luat.Value = Ma_Khen_Thuong_Ky_Luat;
                    myCommand.Parameters.Add(pMa_Khen_Thuong_Ky_Luat);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pNgay_Quyet_Dinh = new SqlParameter("@Ngay_Quyet_Dinh", SqlDbType.DateTime, 8);
                    pNgay_Quyet_Dinh.Value = Ngay_Quyet_Dinh;
                    myCommand.Parameters.Add(pNgay_Quyet_Dinh);

                    SqlParameter pNoi_Quyet_Dinh = new SqlParameter("@Noi_Quyet_Dinh", SqlDbType.NVarChar, 500);
                    pNoi_Quyet_Dinh.Value = Noi_Quyet_Dinh;
                    myCommand.Parameters.Add(pNoi_Quyet_Dinh);

                    SqlParameter pLy_Do = new SqlParameter("@Ly_Do", SqlDbType.NVarChar, 500);
                    pLy_Do.Value = Ly_Do;
                    myCommand.Parameters.Add(pLy_Do);

                    SqlParameter pHinh_Thuc = new SqlParameter("@Hinh_Thuc", SqlDbType.Int, 4);
                    pHinh_Thuc.Value = Hinh_Thuc;
                    myCommand.Parameters.Add(pHinh_Thuc);

                    SqlParameter pTrang_Thai = new SqlParameter("@Trang_Thai", SqlDbType.Bit, 1);
                    pTrang_Thai.Value = Trang_Thai;
                    myCommand.Parameters.Add(pTrang_Thai);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 500);
                    pGhi_Chu.Value = Ghi_Chu;
                    myCommand.Parameters.Add(pGhi_Chu);

                    SqlParameter pLinh_Vuc = new SqlParameter("@Linh_Vuc", SqlDbType.Int, 4);
                    pLinh_Vuc.Value = Linh_Vuc;
                    myCommand.Parameters.Add(pLinh_Vuc);

                    SqlParameter pHinh_Thuc_Cao_Nhat = new SqlParameter("@Hinh_Thuc_Cao_Nhat", SqlDbType.Bit, 1);
                    pHinh_Thuc_Cao_Nhat.Value = Hinh_Thuc_Cao_Nhat;
                    myCommand.Parameters.Add(pHinh_Thuc_Cao_Nhat);

                    SqlParameter pSo_Van_Ban_Quyet_Dinh = new SqlParameter("@So_Van_Ban_Quyet_Dinh", SqlDbType.NVarChar, 500);
                    pSo_Van_Ban_Quyet_Dinh.Value = So_Van_Ban_Quyet_Dinh;
                    myCommand.Parameters.Add(pSo_Van_Ban_Quyet_Dinh);

                    SqlParameter pChuc_Vu_Nguoi_Ky = new SqlParameter("@Chuc_Vu_Nguoi_Ky", SqlDbType.NVarChar, 500);
                    pChuc_Vu_Nguoi_Ky.Value = Chuc_Vu_Nguoi_Ky;
                    myCommand.Parameters.Add(pChuc_Vu_Nguoi_Ky);

                    SqlParameter pMa_Luong_Truoc = new SqlParameter("@Ma_Luong_Truoc", SqlDbType.Int, 4);
                    pMa_Luong_Truoc.Value = Ma_Luong_Truoc;
                    myCommand.Parameters.Add(pMa_Luong_Truoc);

                    SqlParameter pMa_Qua_Trinh_Truoc = new SqlParameter("@Ma_Qua_Trinh_Truoc", SqlDbType.Int, 4);
                    pMa_Qua_Trinh_Truoc.Value = Ma_Qua_Trinh_Truoc;
                    myCommand.Parameters.Add(pMa_Qua_Trinh_Truoc);

                    SqlParameter pMa_Luong_Sau = new SqlParameter("@Ma_Luong_Sau", SqlDbType.Int, 4);
                    pMa_Luong_Sau.Value = Ma_Luong_Sau;
                    myCommand.Parameters.Add(pMa_Luong_Sau);

                    SqlParameter pMa_Qua_Trinh_Sau = new SqlParameter("@Ma_Qua_Trinh_Sau", SqlDbType.Int, 4);
                    pMa_Qua_Trinh_Sau.Value = Ma_Qua_Trinh_Sau;
                    myCommand.Parameters.Add(pMa_Qua_Trinh_Sau);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Ma_Khen_Thuong_Ky_Luat)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Khen_Thuong_Ky_Luat_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Khen_Thuong_Ky_Luat = new SqlParameter("@Ma_Khen_Thuong_Ky_Luat", SqlDbType.Int, 4);
                    pMa_Khen_Thuong_Ky_Luat.Value = Ma_Khen_Thuong_Ky_Luat;
                    myCommand.Parameters.Add(pMa_Khen_Thuong_Ky_Luat);

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
                using (SqlCommand myCommand = new SqlCommand("NL_Khen_Thuong_Ky_Luat_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Khen_Thuong_Ky_Luat_Danh_Sach");
                    return myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Danh_Sach"];
                }
            }
        }
        #endregion

        #region Lay_Boi_NL_Nhan_Vien
        public DataTable Lay_Boi_NL_Nhan_Vien(int Ma_Nhan_Vien)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Khen_Thuong_Ky_Luat_Lay_Boi_NL_Nhan_Vien", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Khen_Thuong_Ky_Luat_Lay_Boi_NL_Nhan_Vien");
                    return myDataSet.Tables["NL_Khen_Thuong_Ky_Luat_Lay_Boi_NL_Nhan_Vien"];
                }
            }
        }
        #endregion

    }
    #endregion
}