using System;
using System.Data;
using System.Data.SqlClient;

namespace QLHS_Logic
{
   
    #region NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Details
    public class NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet
    {
        public int? Ma_Nhan_Vien_Chuc_Vu_KiemNghiem = null; // Mã nhan viên chức vụ
        public string Ten_Chuc_Vu_KiemNghiem = null;
        public int? Ma_Nhan_Vien = null; // Mã nhân viên
        public int? Ma_Don_Vi = null; // Mã đơn vị
        public int? Ma_Phong = null; // Mã phòng
        public DateTime? Ngay_Co_Hieu_Luc = null; // Ngày có hiệu lục
        public DateTime? Ngay_Het_Hieu_Luc = null; // Ngày hết hiệu lục
        public string So_Quyet_Dinh_Chuc_Vu = null; // Số quyết định chức vụ
        public DateTime? Ngay_Ky_Quyet_Dinh = null; // Ngày ký quyết định
        public string Noi_Ky_Quyet_Dinh = null; // Nơi ký quyết định
        
        public string Chuc_Vu_Nguoi_Ky = null;
    }
    #endregion
    #region NL_Nhan_Vien_Chuc_Vu_KiemNghiem
    public class NL_Nhan_Vien_Chuc_Vu_KiemNghiem
    {
        private string ConnectionString;
        public NL_Nhan_Vien_Chuc_Vu_KiemNghiem(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet Lay(int Ma_Nhan_Vien_Chuc_Vu_KiemNghiem)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien_Chuc_Vu_KiemNghiem = new SqlParameter("@Ma_Nhan_Vien_Chuc_Vu_KiemNghiem", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Chuc_Vu_KiemNghiem.Value = Ma_Nhan_Vien_Chuc_Vu_KiemNghiem;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Chuc_Vu_KiemNghiem);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet");
                    NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet myNL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet = new NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet();
                    if (myDataSet.Tables["NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet"] != null)
                    {
                        myNL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet.Ma_Nhan_Vien_Chuc_Vu_KiemNghiem = Ma_Nhan_Vien_Chuc_Vu_KiemNghiem;
                        myNL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet.Ten_Chuc_Vu_KiemNghiem = myDataSet.Tables["NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet"].Rows[0]["Ten_Chuc_Vu_KiemNghiem"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet"].Rows[0]["Ten_Chuc_Vu_KiemNghiem"] : (string)null;
                        myNL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet.Ma_Nhan_Vien = myDataSet.Tables["NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] : (int?)null;
                        myNL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet.Ma_Don_Vi = myDataSet.Tables["NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet"].Rows[0]["Ma_Don_Vi"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet"].Rows[0]["Ma_Don_Vi"] : (int?)null;
                        myNL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet.Ma_Phong = myDataSet.Tables["NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet"].Rows[0]["Ma_Phong"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet"].Rows[0]["Ma_Phong"] : (int?)null;
                        myNL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet.Ngay_Co_Hieu_Luc = myDataSet.Tables["NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet"].Rows[0]["Ngay_Co_Hieu_Luc"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet"].Rows[0]["Ngay_Co_Hieu_Luc"] : (DateTime?)null;
                        myNL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet.Ngay_Het_Hieu_Luc = myDataSet.Tables["NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet"].Rows[0]["Ngay_Het_Hieu_Luc"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet"].Rows[0]["Ngay_Het_Hieu_Luc"] : (DateTime?)null;
                        myNL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet.So_Quyet_Dinh_Chuc_Vu = myDataSet.Tables["NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet"].Rows[0]["So_Quyet_Dinh_Chuc_Vu"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet"].Rows[0]["So_Quyet_Dinh_Chuc_Vu"] : (string)null;
                        myNL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet.Ngay_Ky_Quyet_Dinh = myDataSet.Tables["NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet"].Rows[0]["Ngay_Ky_Quyet_Dinh"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet"].Rows[0]["Ngay_Ky_Quyet_Dinh"] : (DateTime?)null;
                        myNL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet.Noi_Ky_Quyet_Dinh = myDataSet.Tables["NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet"].Rows[0]["Noi_Ky_Quyet_Dinh"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet"].Rows[0]["Noi_Ky_Quyet_Dinh"] : (string)null;

                        myNL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet.Chuc_Vu_Nguoi_Ky = myDataSet.Tables["NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet"].Rows[0]["Chuc_Vu_Nguoi_Ky"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet"].Rows[0]["Chuc_Vu_Nguoi_Ky"] : (string)null;
                    }
                    return myNL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Ma_Nhan_Vien_Chuc_Vu_KiemNghiem = null,string Ten_Chuc_Vu_KiemNghiem=null, int? Ma_Nhan_Vien = null, int? Ma_Don_Vi = null, int? Ma_Phong = null, DateTime? Ngay_Co_Hieu_Luc = null, DateTime? Ngay_Het_Hieu_Luc = null, string So_Quyet_Dinh_Chuc_Vu = null, DateTime? Ngay_Ky_Quyet_Dinh = null, string Noi_Ky_Quyet_Dinh = null, string Chuc_Vu_Nguoi_Ky = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien_Chuc_Vu_KiemNghiem = new SqlParameter("@Ma_Nhan_Vien_Chuc_Vu_KiemNghiem", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Chuc_Vu_KiemNghiem.Value = Ma_Nhan_Vien_Chuc_Vu_KiemNghiem;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Chuc_Vu_KiemNghiem);

                    SqlParameter pTen_Chuc_Vu_KiemNghiem = new SqlParameter("@Ten_Chuc_Vu_KiemNghiem", SqlDbType.NVarChar, 250);
                    pTen_Chuc_Vu_KiemNghiem.Value = Ten_Chuc_Vu_KiemNghiem;
                    myCommand.Parameters.Add(pTen_Chuc_Vu_KiemNghiem);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pMa_Phong = new SqlParameter("@Ma_Phong", SqlDbType.Int, 4);
                    pMa_Phong.Value = Ma_Phong;
                    myCommand.Parameters.Add(pMa_Phong);

                    SqlParameter pNgay_Co_Hieu_Luc = new SqlParameter("@Ngay_Co_Hieu_Luc", SqlDbType.DateTime, 8);
                    pNgay_Co_Hieu_Luc.Value = Ngay_Co_Hieu_Luc;
                    myCommand.Parameters.Add(pNgay_Co_Hieu_Luc);

                    SqlParameter pNgay_Het_Hieu_Luc = new SqlParameter("@Ngay_Het_Hieu_Luc", SqlDbType.DateTime, 8);
                    pNgay_Het_Hieu_Luc.Value = Ngay_Het_Hieu_Luc;
                    myCommand.Parameters.Add(pNgay_Het_Hieu_Luc);

                    SqlParameter pSo_Quyet_Dinh_Chuc_Vu = new SqlParameter("@So_Quyet_Dinh_Chuc_Vu", SqlDbType.NVarChar, 50);
                    pSo_Quyet_Dinh_Chuc_Vu.Value = So_Quyet_Dinh_Chuc_Vu;
                    myCommand.Parameters.Add(pSo_Quyet_Dinh_Chuc_Vu);

                    SqlParameter pNgay_Ky_Quyet_Dinh = new SqlParameter("@Ngay_Ky_Quyet_Dinh", SqlDbType.DateTime, 8);
                    pNgay_Ky_Quyet_Dinh.Value = Ngay_Ky_Quyet_Dinh;
                    myCommand.Parameters.Add(pNgay_Ky_Quyet_Dinh);

                    SqlParameter pNoi_Ky_Quyet_Dinh = new SqlParameter("@Noi_Ky_Quyet_Dinh", SqlDbType.NVarChar, 200);
                    pNoi_Ky_Quyet_Dinh.Value = Noi_Ky_Quyet_Dinh;
                    myCommand.Parameters.Add(pNoi_Ky_Quyet_Dinh);

                    SqlParameter pChuc_Vu_Nguoi_Ky = new SqlParameter("@Chuc_Vu_Nguoi_Ky", SqlDbType.NVarChar, 150);
                    pChuc_Vu_Nguoi_Ky.Value = Chuc_Vu_Nguoi_Ky;
                    myCommand.Parameters.Add(pChuc_Vu_Nguoi_Ky);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int? Ma_Nhan_Vien_Chuc_Vu_KiemNghiem = null, string Ten_Chuc_Vu_KiemNghiem=null,int? Ma_Nhan_Vien = null, int? Ma_Don_Vi = null, int? Ma_Phong = null, DateTime? Ngay_Co_Hieu_Luc = null, DateTime? Ngay_Het_Hieu_Luc = null, string So_Quyet_Dinh_Chuc_Vu = null, DateTime? Ngay_Ky_Quyet_Dinh = null, string Noi_Ky_Quyet_Dinh = null, string Chuc_Vu_Nguoi_Ky = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Nhan_Vien_Chuc_Vu_KiemNghiem = new SqlParameter("@Ma_Nhan_Vien_Chuc_Vu_KiemNghiem", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Chuc_Vu_KiemNghiem.Value = Ma_Nhan_Vien_Chuc_Vu_KiemNghiem;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Chuc_Vu_KiemNghiem);

                    SqlParameter pTen_Chuc_Vu_KiemNghiem = new SqlParameter("@Ten_Chuc_Vu_KiemNghiem", SqlDbType.NVarChar, 750);
                    pTen_Chuc_Vu_KiemNghiem.Value = Ten_Chuc_Vu_KiemNghiem;
                    myCommand.Parameters.Add(pTen_Chuc_Vu_KiemNghiem);


                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pMa_Phong = new SqlParameter("@Ma_Phong", SqlDbType.Int, 4);
                    pMa_Phong.Value = Ma_Phong;
                    myCommand.Parameters.Add(pMa_Phong);

                    SqlParameter pNgay_Co_Hieu_Luc = new SqlParameter("@Ngay_Co_Hieu_Luc", SqlDbType.DateTime, 8);
                    pNgay_Co_Hieu_Luc.Value = Ngay_Co_Hieu_Luc;
                    myCommand.Parameters.Add(pNgay_Co_Hieu_Luc);

                    SqlParameter pNgay_Het_Hieu_Luc = new SqlParameter("@Ngay_Het_Hieu_Luc", SqlDbType.DateTime, 8);
                    pNgay_Het_Hieu_Luc.Value = Ngay_Het_Hieu_Luc;
                    myCommand.Parameters.Add(pNgay_Het_Hieu_Luc);

                    SqlParameter pSo_Quyet_Dinh_Chuc_Vu = new SqlParameter("@So_Quyet_Dinh_Chuc_Vu", SqlDbType.NVarChar, 50);
                    pSo_Quyet_Dinh_Chuc_Vu.Value = So_Quyet_Dinh_Chuc_Vu;
                    myCommand.Parameters.Add(pSo_Quyet_Dinh_Chuc_Vu);

                    SqlParameter pNgay_Ky_Quyet_Dinh = new SqlParameter("@Ngay_Ky_Quyet_Dinh", SqlDbType.DateTime, 8);
                    pNgay_Ky_Quyet_Dinh.Value = Ngay_Ky_Quyet_Dinh;
                    myCommand.Parameters.Add(pNgay_Ky_Quyet_Dinh);

                    SqlParameter pNoi_Ky_Quyet_Dinh = new SqlParameter("@Noi_Ky_Quyet_Dinh", SqlDbType.NVarChar, 200);
                    pNoi_Ky_Quyet_Dinh.Value = Noi_Ky_Quyet_Dinh;
                    myCommand.Parameters.Add(pNoi_Ky_Quyet_Dinh);

                    SqlParameter pChuc_Vu_Nguoi_Ky = new SqlParameter("@Chuc_Vu_Nguoi_Ky", SqlDbType.NVarChar, 150);
                    pChuc_Vu_Nguoi_Ky.Value = Chuc_Vu_Nguoi_Ky;
                    myCommand.Parameters.Add(pChuc_Vu_Nguoi_Ky);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet myNL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien_Chuc_Vu_KiemNghiem = new SqlParameter("@Ma_Nhan_Vien_Chuc_Vu_KiemNghiem", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Chuc_Vu_KiemNghiem.Value = myNL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet.Ma_Nhan_Vien_Chuc_Vu_KiemNghiem;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Chuc_Vu_KiemNghiem);


                    SqlParameter pTen_Chuc_Vu_KiemNghiem = new SqlParameter("@Ten_Chuc_Vu_KiemNghiem", SqlDbType.NVarChar, 250);
                    pTen_Chuc_Vu_KiemNghiem.Value = myNL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet.Ten_Chuc_Vu_KiemNghiem;
                    myCommand.Parameters.Add(pTen_Chuc_Vu_KiemNghiem);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = myNL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet.Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = myNL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet.Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pMa_Phong = new SqlParameter("@Ma_Phong", SqlDbType.Int, 4);
                    pMa_Phong.Value = myNL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet.Ma_Phong;
                    myCommand.Parameters.Add(pMa_Phong);

                    SqlParameter pNgay_Co_Hieu_Luc = new SqlParameter("@Ngay_Co_Hieu_Luc", SqlDbType.DateTime, 8);
                    pNgay_Co_Hieu_Luc.Value = myNL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet.Ngay_Co_Hieu_Luc;
                    myCommand.Parameters.Add(pNgay_Co_Hieu_Luc);

                    SqlParameter pNgay_Het_Hieu_Luc = new SqlParameter("@Ngay_Het_Hieu_Luc", SqlDbType.DateTime, 8);
                    pNgay_Het_Hieu_Luc.Value = myNL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet.Ngay_Het_Hieu_Luc;
                    myCommand.Parameters.Add(pNgay_Het_Hieu_Luc);

                    SqlParameter pSo_Quyet_Dinh_Chuc_Vu = new SqlParameter("@So_Quyet_Dinh_Chuc_Vu", SqlDbType.NVarChar, 50);
                    pSo_Quyet_Dinh_Chuc_Vu.Value = myNL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet.So_Quyet_Dinh_Chuc_Vu;
                    myCommand.Parameters.Add(pSo_Quyet_Dinh_Chuc_Vu);

                    SqlParameter pNgay_Ky_Quyet_Dinh = new SqlParameter("@Ngay_Ky_Quyet_Dinh", SqlDbType.DateTime, 8);
                    pNgay_Ky_Quyet_Dinh.Value = myNL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet.Ngay_Ky_Quyet_Dinh;
                    myCommand.Parameters.Add(pNgay_Ky_Quyet_Dinh);

                    SqlParameter pNoi_Ky_Quyet_Dinh = new SqlParameter("@Noi_Ky_Quyet_Dinh", SqlDbType.NVarChar, 200);
                    pNoi_Ky_Quyet_Dinh.Value = myNL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet.Noi_Ky_Quyet_Dinh;
                    myCommand.Parameters.Add(pNoi_Ky_Quyet_Dinh);

                    SqlParameter pChuc_Vu_Nguoi_Ky = new SqlParameter("@Chuc_Vu_Nguoi_Ky", SqlDbType.NVarChar, 150);
                    pChuc_Vu_Nguoi_Ky.Value = myNL_Nhan_Vien_Chuc_Vu_KiemNghiem_Chi_Tiet.Chuc_Vu_Nguoi_Ky;
                    myCommand.Parameters.Add(pChuc_Vu_Nguoi_Ky);


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
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Nhan_Vien_Chuc_Vu_KiemNghiem = new SqlParameter("@Ma_Nhan_Vien_Chuc_Vu_KiemNghiem", SqlDbType.Int, 4);
                        pMa_Nhan_Vien_Chuc_Vu_KiemNghiem.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nhan_Vien_Chuc_Vu_KiemNghiem"];
                        myCommand.Parameters.Add(pMa_Nhan_Vien_Chuc_Vu_KiemNghiem);

                        SqlParameter pTen_Chuc_Vu_KiemNghiem = new SqlParameter("@Ten_Chuc_Vu_KiemNghiem", SqlDbType.NVarChar, 250);
                        pTen_Chuc_Vu_KiemNghiem.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ten_Chuc_Vu_KiemNghiem"];
                        myCommand.Parameters.Add(pTen_Chuc_Vu_KiemNghiem);

                        SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                        pMa_Nhan_Vien.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nhan_Vien"];
                        myCommand.Parameters.Add(pMa_Nhan_Vien);

                        SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                        pMa_Don_Vi.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Don_Vi"];
                        myCommand.Parameters.Add(pMa_Don_Vi);

                        SqlParameter pMa_Phong = new SqlParameter("@Ma_Phong", SqlDbType.Int, 4);
                        pMa_Phong.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Phong"];
                        myCommand.Parameters.Add(pMa_Phong);

                        SqlParameter pNgay_Co_Hieu_Luc = new SqlParameter("@Ngay_Co_Hieu_Luc", SqlDbType.DateTime, 8);
                        pNgay_Co_Hieu_Luc.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Ngay_Co_Hieu_Luc"];
                        myCommand.Parameters.Add(pNgay_Co_Hieu_Luc);

                        SqlParameter pNgay_Het_Hieu_Luc = new SqlParameter("@Ngay_Het_Hieu_Luc", SqlDbType.DateTime, 8);
                        pNgay_Het_Hieu_Luc.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Ngay_Het_Hieu_Luc"];
                        myCommand.Parameters.Add(pNgay_Het_Hieu_Luc);

                        SqlParameter pSo_Quyet_Dinh_Chuc_Vu = new SqlParameter("@So_Quyet_Dinh_Chuc_Vu", SqlDbType.NVarChar, 50);
                        pSo_Quyet_Dinh_Chuc_Vu.Value = (string)myDataSet.Tables[strTableName].Rows[i]["So_Quyet_Dinh_Chuc_Vu"];
                        myCommand.Parameters.Add(pSo_Quyet_Dinh_Chuc_Vu);

                        SqlParameter pNgay_Ky_Quyet_Dinh = new SqlParameter("@Ngay_Ky_Quyet_Dinh", SqlDbType.DateTime, 8);
                        pNgay_Ky_Quyet_Dinh.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Ngay_Ky_Quyet_Dinh"];
                        myCommand.Parameters.Add(pNgay_Ky_Quyet_Dinh);

                        SqlParameter pNoi_Ky_Quyet_Dinh = new SqlParameter("@Noi_Ky_Quyet_Dinh", SqlDbType.NVarChar, 200);
                        pNoi_Ky_Quyet_Dinh.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Noi_Ky_Quyet_Dinh"];
                        myCommand.Parameters.Add(pNoi_Ky_Quyet_Dinh);

                       SqlParameter pChuc_Vu_Nguoi_Ky = new SqlParameter("@Chuc_Vu_Nguoi_Ky", SqlDbType.NVarChar, 150);
                        pChuc_Vu_Nguoi_Ky.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Chuc_Vu_Nguoi_Ky"];
                        myCommand.Parameters.Add(pChuc_Vu_Nguoi_Ky);


                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int? Ma_Nhan_Vien_Chuc_Vu_KiemNghiem = null, string Ten_Chuc_Vu_KiemNghiem=null, int? Ma_Nhan_Vien = null, int? Ma_Don_Vi = null, int? Ma_Phong = null, DateTime? Ngay_Co_Hieu_Luc = null, DateTime? Ngay_Het_Hieu_Luc = null, string So_Quyet_Dinh_Chuc_Vu = null, DateTime? Ngay_Ky_Quyet_Dinh = null, string Noi_Ky_Quyet_Dinh = null, string Chuc_Vu_Nguoi_Ky = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien_Chuc_Vu_KiemNghiem = new SqlParameter("@Ma_Nhan_Vien_Chuc_Vu_KiemNghiem", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Chuc_Vu_KiemNghiem.Value = Ma_Nhan_Vien_Chuc_Vu_KiemNghiem;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Chuc_Vu_KiemNghiem);

                    SqlParameter pTen_Chuc_Vu_KiemNghiem = new SqlParameter("@Ten_Chuc_Vu_KiemNghiem", SqlDbType.NVarChar, 250);
                    pTen_Chuc_Vu_KiemNghiem.Value = Ten_Chuc_Vu_KiemNghiem;
                    myCommand.Parameters.Add(pTen_Chuc_Vu_KiemNghiem);


                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pMa_Phong = new SqlParameter("@Ma_Phong", SqlDbType.Int, 4);
                    pMa_Phong.Value = Ma_Phong;
                    myCommand.Parameters.Add(pMa_Phong);

                    SqlParameter pNgay_Co_Hieu_Luc = new SqlParameter("@Ngay_Co_Hieu_Luc", SqlDbType.DateTime, 8);
                    pNgay_Co_Hieu_Luc.Value = Ngay_Co_Hieu_Luc;
                    myCommand.Parameters.Add(pNgay_Co_Hieu_Luc);

                    SqlParameter pNgay_Het_Hieu_Luc = new SqlParameter("@Ngay_Het_Hieu_Luc", SqlDbType.DateTime, 8);
                    pNgay_Het_Hieu_Luc.Value = Ngay_Het_Hieu_Luc;
                    myCommand.Parameters.Add(pNgay_Het_Hieu_Luc);

                    SqlParameter pSo_Quyet_Dinh_Chuc_Vu = new SqlParameter("@So_Quyet_Dinh_Chuc_Vu", SqlDbType.NVarChar, 50);
                    pSo_Quyet_Dinh_Chuc_Vu.Value = So_Quyet_Dinh_Chuc_Vu;
                    myCommand.Parameters.Add(pSo_Quyet_Dinh_Chuc_Vu);

                    SqlParameter pNgay_Ky_Quyet_Dinh = new SqlParameter("@Ngay_Ky_Quyet_Dinh", SqlDbType.DateTime, 8);
                    pNgay_Ky_Quyet_Dinh.Value = Ngay_Ky_Quyet_Dinh;
                    myCommand.Parameters.Add(pNgay_Ky_Quyet_Dinh);

                    SqlParameter pNoi_Ky_Quyet_Dinh = new SqlParameter("@Noi_Ky_Quyet_Dinh", SqlDbType.NVarChar, 200);
                    pNoi_Ky_Quyet_Dinh.Value = Noi_Ky_Quyet_Dinh;
                    myCommand.Parameters.Add(pNoi_Ky_Quyet_Dinh);


                    SqlParameter pChuc_Vu_Nguoi_Ky = new SqlParameter("@Chuc_Vu_Nguoi_Ky", SqlDbType.NVarChar, 150);
                    pChuc_Vu_Nguoi_Ky.Value = Chuc_Vu_Nguoi_Ky;
                    myCommand.Parameters.Add(pChuc_Vu_Nguoi_Ky);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Ma_Nhan_Vien_Chuc_Vu_KiemNghiem)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien_Chuc_Vu_KiemNghiem = new SqlParameter("@Ma_Nhan_Vien_Chuc_Vu_KiemNghiem", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Chuc_Vu_KiemNghiem.Value = Ma_Nhan_Vien_Chuc_Vu_KiemNghiem;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Chuc_Vu_KiemNghiem);

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
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Danh_Sach");
                    return myDataSet.Tables["NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Danh_Sach"];
                }
            }
        }
        #endregion

        #region Lay_Boi_NL_DM_Chuc_Vu
        public DataTable Lay_Boi_NL_DM_Chuc_Vu(int Ma_Chuc_Vu)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Lay_Boi_NL_DM_Chuc_Vu", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Chuc_Vu = new SqlParameter("@Ma_Chuc_Vu", SqlDbType.Int, 4);
                    pMa_Chuc_Vu.Value = Ma_Chuc_Vu;
                    myCommand.Parameters.Add(pMa_Chuc_Vu);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Lay_Boi_NL_DM_Chuc_Vu");
                    return myDataSet.Tables["NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Lay_Boi_NL_DM_Chuc_Vu"];
                }
            }
        }
        #endregion
        #region Lay_Boi_NL_Nhan_Vien
        public DataTable Lay_Boi_NL_Nhan_Vien(int Ma_Nhan_Vien)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Lay_Boi_NL_Nhan_Vien", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Lay_Boi_NL_Nhan_Vien");
                    return myDataSet.Tables["NL_Nhan_Vien_Chuc_Vu_KiemNghiem_Lay_Boi_NL_Nhan_Vien"];
                }
            }
        }
        #endregion

    }
    #endregion
}
