using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace QLHS_Logic
{
    #region NL_Khen_Thuong_DonVi_Details
    public class NL_Khen_Thuong_Don_Vi_Chi_Tiet
    {
        public int? Ma_Khen_Thuong_Don_Vi = null; // Mã nhận xét
        public int? Ma_Don_Vi = null; // Mã nhân viên
        public DateTime? Ngay_Quyet_Dinh = null; // Nhiệm vụ
        public string Noi_Quyet_Dinh = null; // Nhận xét
        public string Ly_Do = null;
        public int? Hinh_Thuc = null;
        public string Ghi_Chu = null;
        public int? Linh_Vuc = null;
        public bool? Hinh_Thuc_Cao_Nhat = null;
    }
    #endregion

    public class NL_Khen_Thuong_Don_Vi
    {

        private string ConnectionString;

        public NL_Khen_Thuong_Don_Vi(string _ConnectionString)
        {
            this.ConnectionString = _ConnectionString;
        }

        #region Lay
        public NL_Khen_Thuong_Don_Vi_Chi_Tiet Lay(int Ma_Khen_Thuong_Don_Vi)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Khen_Thuong_Don_Vi_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Khen_Thuong_Don_Vi = new SqlParameter("@Ma_Khen_Thuong_Don_Vi", SqlDbType.Int, 4);
                    pMa_Khen_Thuong_Don_Vi.Value = Ma_Khen_Thuong_Don_Vi;
                    myCommand.Parameters.Add(pMa_Khen_Thuong_Don_Vi);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Khen_Thuong_Don_Vi_Chi_Tiet");
                    NL_Khen_Thuong_Don_Vi_Chi_Tiet myNL_Khen_Thuong_Don_Vi_Chi_Tiet = new NL_Khen_Thuong_Don_Vi_Chi_Tiet();
                    if (myDataSet.Tables["NL_Khen_Thuong_Don_Vi_Chi_Tiet"] != null)
                    {
                        myNL_Khen_Thuong_Don_Vi_Chi_Tiet.Ma_Khen_Thuong_Don_Vi = Ma_Khen_Thuong_Don_Vi;
                        myNL_Khen_Thuong_Don_Vi_Chi_Tiet.Ma_Don_Vi = myDataSet.Tables["NL_Khen_Thuong_Don_Vi_Chi_Tiet"].Rows[0]["Ma_Don_Vi"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Khen_Thuong_Don_Vi_Chi_Tiet"].Rows[0]["Ma_Don_Vi"] : (int?)null;
                        myNL_Khen_Thuong_Don_Vi_Chi_Tiet.Ngay_Quyet_Dinh = myDataSet.Tables["NL_Khen_Thuong_Don_Vi_Chi_Tiet"].Rows[0]["Ngay_Quyet_Dinh"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Khen_Thuong_Don_Vi_Chi_Tiet"].Rows[0]["Ngay_Quyet_Dinh"] : (DateTime?)null;
                        myNL_Khen_Thuong_Don_Vi_Chi_Tiet.Noi_Quyet_Dinh = myDataSet.Tables["NL_Khen_Thuong_Don_Vi_Chi_Tiet"].Rows[0]["Noi_Quyet_Dinh"] != DBNull.Value ? (string)myDataSet.Tables["NL_Khen_Thuong_Don_Vi_Chi_Tiet"].Rows[0]["Noi_Quyet_Dinh"] : (string)null;
                        myNL_Khen_Thuong_Don_Vi_Chi_Tiet.Ly_Do = myDataSet.Tables["NL_Khen_Thuong_Don_Vi_Chi_Tiet"].Rows[0]["Ly_Do"] != DBNull.Value ? (string)myDataSet.Tables["NL_Khen_Thuong_Don_Vi_Chi_Tiet"].Rows[0]["Ly_Do"] : (string)null;
                        myNL_Khen_Thuong_Don_Vi_Chi_Tiet.Hinh_Thuc = myDataSet.Tables["NL_Khen_Thuong_Don_Vi_Chi_Tiet"].Rows[0]["Hinh_Thuc"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Khen_Thuong_Don_Vi_Chi_Tiet"].Rows[0]["Hinh_Thuc"] : (int?)null;
                        myNL_Khen_Thuong_Don_Vi_Chi_Tiet.Ghi_Chu = myDataSet.Tables["NL_Khen_Thuong_Don_Vi_Chi_Tiet"].Rows[0]["Ghi_Chu"] != DBNull.Value ? (string)myDataSet.Tables["NL_Khen_Thuong_Don_Vi_Chi_Tiet"].Rows[0]["Ghi_Chu"] : (string)null;
                        myNL_Khen_Thuong_Don_Vi_Chi_Tiet.Linh_Vuc = myDataSet.Tables["NL_Khen_Thuong_Don_Vi_Chi_Tiet"].Rows[0]["Linh_Vuc"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Khen_Thuong_Don_Vi_Chi_Tiet"].Rows[0]["Linh_Vuc"] : (int?)null;
                        myNL_Khen_Thuong_Don_Vi_Chi_Tiet.Hinh_Thuc_Cao_Nhat = myDataSet.Tables["NL_Khen_Thuong_Don_Vi_Chi_Tiet"].Rows[0]["Hinh_Thuc_Cao_Nhat"] != DBNull.Value ? (bool?)myDataSet.Tables["NL_Khen_Thuong_Don_Vi_Chi_Tiet"].Rows[0]["Hinh_Thuc_Cao_Nhat"] : (bool?)null;
                    }
                    return myNL_Khen_Thuong_Don_Vi_Chi_Tiet;
                }
            }
        }
        #endregion

        #region XoaTheoMaKhenThuongDonVi
        public void Xoa(int Ma_Khen_Thuong_Don_Vi)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Khen_Thuong_Don_Vi_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Khen_Thuong_Don_Vi = new SqlParameter("@Ma_Khen_Thuong_Don_Vi", SqlDbType.Int, 4);
                    pMa_Khen_Thuong_Don_Vi.Value = Ma_Khen_Thuong_Don_Vi;
                    myCommand.Parameters.Add(pMa_Khen_Thuong_Don_Vi);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Them
        public void Them(int? Ma_Khen_Thuong_Don_Vi = null, int? Ma_Don_Vi = null, DateTime? Ngay_Quyet_Dinh = null, string Noi_Quyet_Dinh = null, string Ly_Do = null, int? Hinh_Thuc = null, string Ghi_Chu = null, int? Linh_Vuc = null, bool? Hinh_Thuc_Cao_Nhat = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Khen_Thuong_Don_Vi_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Khen_Thuong_Don_Vi = new SqlParameter("@Ma_Khen_Thuong_Don_Vi", SqlDbType.Int, 4);
                    pMa_Khen_Thuong_Don_Vi.Value = Ma_Khen_Thuong_Don_Vi;
                    myCommand.Parameters.Add(pMa_Khen_Thuong_Don_Vi);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pNgay_Quyet_Dinh = new SqlParameter("@Ngay_Quyet_Dinh", SqlDbType.DateTime, 8);
                    pNgay_Quyet_Dinh.Value = Ngay_Quyet_Dinh;
                    myCommand.Parameters.Add(pNgay_Quyet_Dinh);

                    SqlParameter pNoi_Quyet_Dinh = new SqlParameter("@Noi_Quyet_Dinh", SqlDbType.NVarChar, 500);
                    pNoi_Quyet_Dinh.Value = Noi_Quyet_Dinh;
                    myCommand.Parameters.Add(pNoi_Quyet_Dinh);

                    SqlParameter pLy_Do = new SqlParameter("@Ly_Do", SqlDbType.NText);
                    pLy_Do.Value = Ly_Do;
                    myCommand.Parameters.Add(pLy_Do);

                    SqlParameter pHinh_Thuc = new SqlParameter("@Hinh_Thuc", SqlDbType.Int, 4);
                    pHinh_Thuc.Value = Hinh_Thuc;
                    myCommand.Parameters.Add(pHinh_Thuc);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 500);
                    pGhi_Chu.Value = Ghi_Chu;
                    myCommand.Parameters.Add(pGhi_Chu);

                    SqlParameter pLinh_Vuc = new SqlParameter("@Linh_Vuc", SqlDbType.Int, 4);
                    pLinh_Vuc.Value = Linh_Vuc;
                    myCommand.Parameters.Add(pLinh_Vuc);

                    SqlParameter pHinh_Thuc_Cao_Nhat = new SqlParameter("@Hinh_Thuc_Cao_Nhat", SqlDbType.Bit, 1);
                    pHinh_Thuc_Cao_Nhat.Value = Hinh_Thuc_Cao_Nhat;
                    myCommand.Parameters.Add(pHinh_Thuc_Cao_Nhat);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Cap_Nhat
        public void Cap_Nhat(int? Ma_Khen_Thuong_Don_Vi = null, int? Ma_Don_Vi = null, DateTime? Ngay_Quyet_Dinh = null, string Noi_Quyet_Dinh = null, string Ly_Do = null, int? Hinh_Thuc = null, string Ghi_Chu = null, int? Linh_Vuc = null, bool? Hinh_Thuc_Cao_Nhat = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Khen_Thuong_Don_Vi_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Khen_Thuong_Don_Vi = new SqlParameter("@Ma_Khen_Thuong_Don_Vi", SqlDbType.Int, 4);
                    pMa_Khen_Thuong_Don_Vi.Value = Ma_Khen_Thuong_Don_Vi;
                    myCommand.Parameters.Add(pMa_Khen_Thuong_Don_Vi);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pNgay_Quyet_Dinh = new SqlParameter("@Ngay_Quyet_Dinh", SqlDbType.DateTime, 8);
                    pNgay_Quyet_Dinh.Value = Ngay_Quyet_Dinh;
                    myCommand.Parameters.Add(pNgay_Quyet_Dinh);

                    SqlParameter pNoi_Quyet_Dinh = new SqlParameter("@Noi_Quyet_Dinh", SqlDbType.NVarChar, 500);
                    pNoi_Quyet_Dinh.Value = Noi_Quyet_Dinh;
                    myCommand.Parameters.Add(pNoi_Quyet_Dinh);

                    SqlParameter pLy_Do = new SqlParameter("@Ly_Do", SqlDbType.NText);
                    pLy_Do.Value = Ly_Do;
                    myCommand.Parameters.Add(pLy_Do);

                    SqlParameter pHinh_Thuc = new SqlParameter("@Hinh_Thuc", SqlDbType.Int, 4);
                    pHinh_Thuc.Value = Hinh_Thuc;
                    myCommand.Parameters.Add(pHinh_Thuc);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 500);
                    pGhi_Chu.Value = Ghi_Chu;
                    myCommand.Parameters.Add(pGhi_Chu);

                    SqlParameter pLinh_Vuc = new SqlParameter("@Linh_Vuc", SqlDbType.Int, 4);
                    pLinh_Vuc.Value = Linh_Vuc;
                    myCommand.Parameters.Add(pLinh_Vuc);

                    SqlParameter pHinh_Thuc_Cao_Nhat = new SqlParameter("@Hinh_Thuc_Cao_Nhat", SqlDbType.Bit, 1);
                    pHinh_Thuc_Cao_Nhat.Value = Hinh_Thuc_Cao_Nhat;
                    myCommand.Parameters.Add(pHinh_Thuc_Cao_Nhat);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

    }
}
