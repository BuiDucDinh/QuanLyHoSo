using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region NL_Nhan_Vien_Hop_Dong_Details
    public class NL_Nhan_Vien_Hop_Dong_Chi_Tiet
    {
        public int? Ma_Nhan_Vien_Hop_Dong = null; // Mã nhân viên hợp đồng
        public int? Ma_Hop_Dong = null; // Mã hợp đồng
        public int? Ma_Nhan_Vien = null; // Mã nhân viên
        public DateTime? Tu_Ngay = null; // Từ ngày
        public DateTime? Den_Ngay = null; // Đến ngày
        public int? Luong = null; // Lương
        public int? Trang_Thai = null;
        public bool? Co_BHXH = null;
        public int? Linh_Vuc_LD = null; 
    }
    #endregion
    #region NL_Nhan_Vien_Hop_Dong
    public class NL_Nhan_Vien_Hop_Dong
    {
        private string ConnectionString;
        public NL_Nhan_Vien_Hop_Dong(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_Nhan_Vien_Hop_Dong_Chi_Tiet Lay(int Ma_Nhan_Vien_Hop_Dong)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Hop_Dong_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien_Hop_Dong = new SqlParameter("@Ma_Nhan_Vien_Hop_Dong", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Hop_Dong.Value = Ma_Nhan_Vien_Hop_Dong;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Hop_Dong);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Nhan_Vien_Hop_Dong_Chi_Tiet");
                    NL_Nhan_Vien_Hop_Dong_Chi_Tiet myNL_Nhan_Vien_Hop_Dong_Chi_Tiet = new NL_Nhan_Vien_Hop_Dong_Chi_Tiet();
                    if (myDataSet.Tables["NL_Nhan_Vien_Hop_Dong_Chi_Tiet"] != null)
                    {
                        myNL_Nhan_Vien_Hop_Dong_Chi_Tiet.Ma_Nhan_Vien_Hop_Dong = Ma_Nhan_Vien_Hop_Dong;
                        myNL_Nhan_Vien_Hop_Dong_Chi_Tiet.Ma_Hop_Dong = myDataSet.Tables["NL_Nhan_Vien_Hop_Dong_Chi_Tiet"].Rows[0]["Ma_Hop_Dong"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Nhan_Vien_Hop_Dong_Chi_Tiet"].Rows[0]["Ma_Hop_Dong"] : (int?)null;
                        myNL_Nhan_Vien_Hop_Dong_Chi_Tiet.Ma_Nhan_Vien = myDataSet.Tables["NL_Nhan_Vien_Hop_Dong_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Nhan_Vien_Hop_Dong_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] : (int?)null;
                        myNL_Nhan_Vien_Hop_Dong_Chi_Tiet.Tu_Ngay = myDataSet.Tables["NL_Nhan_Vien_Hop_Dong_Chi_Tiet"].Rows[0]["Tu_Ngay"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Nhan_Vien_Hop_Dong_Chi_Tiet"].Rows[0]["Tu_Ngay"] : (DateTime?)null;
                        myNL_Nhan_Vien_Hop_Dong_Chi_Tiet.Den_Ngay = myDataSet.Tables["NL_Nhan_Vien_Hop_Dong_Chi_Tiet"].Rows[0]["Den_Ngay"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Nhan_Vien_Hop_Dong_Chi_Tiet"].Rows[0]["Den_Ngay"] : (DateTime?)null;
                        myNL_Nhan_Vien_Hop_Dong_Chi_Tiet.Luong = myDataSet.Tables["NL_Nhan_Vien_Hop_Dong_Chi_Tiet"].Rows[0]["Luong"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Nhan_Vien_Hop_Dong_Chi_Tiet"].Rows[0]["Luong"] : (int?)null;
                        myNL_Nhan_Vien_Hop_Dong_Chi_Tiet.Trang_Thai = myDataSet.Tables["NL_Nhan_Vien_Hop_Dong_Chi_Tiet"].Rows[0]["Trang_Thai"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Nhan_Vien_Hop_Dong_Chi_Tiet"].Rows[0]["Trang_Thai"] : (int?)null;
                        myNL_Nhan_Vien_Hop_Dong_Chi_Tiet.Co_BHXH = myDataSet.Tables["NL_Nhan_Vien_Hop_Dong_Chi_Tiet"].Rows[0]["Co_BHXH"] != DBNull.Value ? (bool?)myDataSet.Tables["NL_Nhan_Vien_Hop_Dong_Chi_Tiet"].Rows[0]["Co_BHXH"] : (bool?)null;
                        myNL_Nhan_Vien_Hop_Dong_Chi_Tiet.Linh_Vuc_LD = myDataSet.Tables["NL_Nhan_Vien_Hop_Dong_Chi_Tiet"].Rows[0]["Linh_Vuc_LD"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Nhan_Vien_Hop_Dong_Chi_Tiet"].Rows[0]["Linh_Vuc_LD"] : (int?)null;
                    }
                    return myNL_Nhan_Vien_Hop_Dong_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Ma_Nhan_Vien_Hop_Dong = null, int? Ma_Hop_Dong = null, int? Ma_Nhan_Vien = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null, int? Luong = null, int? Trang_Thai = null,bool? Co_BHXH =null,int? Linh_Vuc_LD = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Hop_Dong_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien_Hop_Dong = new SqlParameter("@Ma_Nhan_Vien_Hop_Dong", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Hop_Dong.Value = Ma_Nhan_Vien_Hop_Dong;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Hop_Dong);

                    SqlParameter pMa_Hop_Dong = new SqlParameter("@Ma_Hop_Dong", SqlDbType.Int, 4);
                    pMa_Hop_Dong.Value = Ma_Hop_Dong;
                    myCommand.Parameters.Add(pMa_Hop_Dong);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pLuong = new SqlParameter("@Luong", SqlDbType.Int, 4);
                    pLuong.Value = Luong;
                    myCommand.Parameters.Add(pLuong);

                    SqlParameter pTrang_Thai = new SqlParameter("@Trang_Thai", SqlDbType.Int, 4);
                    pTrang_Thai.Value = Trang_Thai;
                    myCommand.Parameters.Add(pTrang_Thai);

                    SqlParameter pCo_BHXH = new SqlParameter("@Co_BHXH", SqlDbType.Bit, 1);
                    pCo_BHXH.Value = Co_BHXH;
                    myCommand.Parameters.Add(pCo_BHXH);

                    SqlParameter pLinh_Vuc_LD = new SqlParameter("@Linh_Vuc_LD", SqlDbType.Int, 4);
                    pLinh_Vuc_LD.Value = Linh_Vuc_LD;
                    myCommand.Parameters.Add(pLinh_Vuc_LD);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int? Ma_Nhan_Vien_Hop_Dong = null, int? Ma_Hop_Dong = null, int? Ma_Nhan_Vien = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null, int? Luong = null, int? Trang_Thai = null, bool? Co_BHXH = null, int? Linh_Vuc_LD = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Hop_Dong_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Nhan_Vien_Hop_Dong = new SqlParameter("@Ma_Nhan_Vien_Hop_Dong", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Hop_Dong.Value = Ma_Nhan_Vien_Hop_Dong;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Hop_Dong);

                    SqlParameter pMa_Hop_Dong = new SqlParameter("@Ma_Hop_Dong", SqlDbType.Int, 4);
                    pMa_Hop_Dong.Value = Ma_Hop_Dong;
                    myCommand.Parameters.Add(pMa_Hop_Dong);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pLuong = new SqlParameter("@Luong", SqlDbType.Int, 4);
                    pLuong.Value = Luong;
                    myCommand.Parameters.Add(pLuong);

                    SqlParameter pTrang_Thai = new SqlParameter("@Trang_Thai", SqlDbType.Int, 4);
                    pTrang_Thai.Value = Trang_Thai;
                    myCommand.Parameters.Add(pTrang_Thai);

                    SqlParameter pCo_BHXH = new SqlParameter("@Co_BHXH", SqlDbType.Bit, 1);
                    pCo_BHXH.Value = Co_BHXH;
                    myCommand.Parameters.Add(pCo_BHXH);

                    SqlParameter pLinh_Vuc_LD = new SqlParameter("@Linh_Vuc_LD", SqlDbType.Int, 4);
                    pLinh_Vuc_LD.Value = Linh_Vuc_LD;
                    myCommand.Parameters.Add(pLinh_Vuc_LD);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(NL_Nhan_Vien_Hop_Dong_Chi_Tiet myNL_Nhan_Vien_Hop_Dong_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Hop_Dong_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien_Hop_Dong = new SqlParameter("@Ma_Nhan_Vien_Hop_Dong", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Hop_Dong.Value = myNL_Nhan_Vien_Hop_Dong_Chi_Tiet.Ma_Nhan_Vien_Hop_Dong;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Hop_Dong);

                    SqlParameter pMa_Hop_Dong = new SqlParameter("@Ma_Hop_Dong", SqlDbType.Int, 4);
                    pMa_Hop_Dong.Value = myNL_Nhan_Vien_Hop_Dong_Chi_Tiet.Ma_Hop_Dong;
                    myCommand.Parameters.Add(pMa_Hop_Dong);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = myNL_Nhan_Vien_Hop_Dong_Chi_Tiet.Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = myNL_Nhan_Vien_Hop_Dong_Chi_Tiet.Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = myNL_Nhan_Vien_Hop_Dong_Chi_Tiet.Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pLuong = new SqlParameter("@Luong", SqlDbType.Int, 4);
                    pLuong.Value = myNL_Nhan_Vien_Hop_Dong_Chi_Tiet.Luong;
                    myCommand.Parameters.Add(pLuong);

                    SqlParameter pTrang_Thai = new SqlParameter("@Trang_Thai", SqlDbType.Int, 4);
                    pTrang_Thai.Value = myNL_Nhan_Vien_Hop_Dong_Chi_Tiet.Trang_Thai;
                    myCommand.Parameters.Add(pTrang_Thai);

                    SqlParameter pCo_BHXH = new SqlParameter("@Co_BHXH", SqlDbType.Bit, 1);
                    pCo_BHXH.Value = myNL_Nhan_Vien_Hop_Dong_Chi_Tiet.Co_BHXH;
                    myCommand.Parameters.Add(pCo_BHXH);

                    SqlParameter pLinh_Vuc_LD = new SqlParameter("@Linh_Vuc_LD", SqlDbType.Int, 4);
                    pLinh_Vuc_LD.Value = myNL_Nhan_Vien_Hop_Dong_Chi_Tiet.Linh_Vuc_LD;
                    myCommand.Parameters.Add(pLinh_Vuc_LD);


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
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Hop_Dong_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Nhan_Vien_Hop_Dong = new SqlParameter("@Ma_Nhan_Vien_Hop_Dong", SqlDbType.Int, 4);
                        pMa_Nhan_Vien_Hop_Dong.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nhan_Vien_Hop_Dong"];
                        myCommand.Parameters.Add(pMa_Nhan_Vien_Hop_Dong);

                        SqlParameter pMa_Hop_Dong = new SqlParameter("@Ma_Hop_Dong", SqlDbType.Int, 4);
                        pMa_Hop_Dong.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Hop_Dong"];
                        myCommand.Parameters.Add(pMa_Hop_Dong);

                        SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                        pMa_Nhan_Vien.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nhan_Vien"];
                        myCommand.Parameters.Add(pMa_Nhan_Vien);

                        SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                        pTu_Ngay.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Tu_Ngay"];
                        myCommand.Parameters.Add(pTu_Ngay);

                        SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                        pDen_Ngay.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Den_Ngay"];
                        myCommand.Parameters.Add(pDen_Ngay);

                        SqlParameter pLuong = new SqlParameter("@Luong", SqlDbType.Int, 4);
                        pLuong.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Luong"];
                        myCommand.Parameters.Add(pLuong);

                        SqlParameter pTrang_Thai = new SqlParameter("@Trang_Thai", SqlDbType.Int, 4);
                        pTrang_Thai.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Trang_Thai"];
                        myCommand.Parameters.Add(pTrang_Thai);

                        SqlParameter pCo_BHXH = new SqlParameter("@Co_BHXH", SqlDbType.Bit, 1);
                        pCo_BHXH.Value = (bool)myDataSet.Tables[strTableName].Rows[i]["Co_BHXH"];
                        myCommand.Parameters.Add(pCo_BHXH);

                        SqlParameter pLinh_Vuc_LD = new SqlParameter("@Linh_Vuc_LD", SqlDbType.Int, 4);
                        pLinh_Vuc_LD.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Linh_Vuc_LD"];
                        myCommand.Parameters.Add(pLinh_Vuc_LD);

                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int? Ma_Nhan_Vien_Hop_Dong = null, int? Ma_Hop_Dong = null, int? Ma_Nhan_Vien = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null, int? Luong = null, int? Trang_Thai = null, bool? Co_BHXH = null, int? Linh_Vuc_LD = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Hop_Dong_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien_Hop_Dong = new SqlParameter("@Ma_Nhan_Vien_Hop_Dong", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Hop_Dong.Value = Ma_Nhan_Vien_Hop_Dong;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Hop_Dong);

                    SqlParameter pMa_Hop_Dong = new SqlParameter("@Ma_Hop_Dong", SqlDbType.Int, 4);
                    pMa_Hop_Dong.Value = Ma_Hop_Dong;
                    myCommand.Parameters.Add(pMa_Hop_Dong);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pLuong = new SqlParameter("@Luong", SqlDbType.Int, 4);
                    pLuong.Value = Luong;
                    myCommand.Parameters.Add(pLuong);

                    SqlParameter pTrang_Thai = new SqlParameter("@Trang_Thai", SqlDbType.Int, 4);
                    pTrang_Thai.Value = Trang_Thai;
                    myCommand.Parameters.Add(pTrang_Thai);

                    SqlParameter pCo_BHXH = new SqlParameter("@Co_BHXH", SqlDbType.Bit, 1);
                    pCo_BHXH.Value = Co_BHXH;
                    myCommand.Parameters.Add(pCo_BHXH);

                    SqlParameter pLinh_Vuc_LD = new SqlParameter("@Linh_Vuc_LD", SqlDbType.Int, 4);
                    pLinh_Vuc_LD.Value = Linh_Vuc_LD;
                    myCommand.Parameters.Add(pLinh_Vuc_LD);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Ma_Nhan_Vien_Hop_Dong)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Hop_Dong_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien_Hop_Dong = new SqlParameter("@Ma_Nhan_Vien_Hop_Dong", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Hop_Dong.Value = Ma_Nhan_Vien_Hop_Dong;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Hop_Dong);

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
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Hop_Dong_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Nhan_Vien_Hop_Dong_Danh_Sach");
                    return myDataSet.Tables["NL_Nhan_Vien_Hop_Dong_Danh_Sach"];
                }
            }
        }
        #endregion

        #region Lay_Boi_NL_DM_Hop_Dong
        public DataTable Lay_Boi_NL_DM_Hop_Dong(int Ma_Hop_Dong)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Hop_Dong_Lay_Boi_NL_DM_Hop_Dong", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Hop_Dong = new SqlParameter("@Ma_Hop_Dong", SqlDbType.Int, 4);
                    pMa_Hop_Dong.Value = Ma_Hop_Dong;
                    myCommand.Parameters.Add(pMa_Hop_Dong);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Nhan_Vien_Hop_Dong_Lay_Boi_NL_DM_Hop_Dong");
                    return myDataSet.Tables["NL_Nhan_Vien_Hop_Dong_Lay_Boi_NL_DM_Hop_Dong"];
                }
            }
        }
        #endregion
        #region Lay_Boi_NL_Nhan_Vien
        public DataTable Lay_Boi_NL_Nhan_Vien(int Ma_Nhan_Vien)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Hop_Dong_Lay_Boi_NL_Nhan_Vien", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Nhan_Vien_Hop_Dong_Lay_Boi_NL_Nhan_Vien");
                    return myDataSet.Tables["NL_Nhan_Vien_Hop_Dong_Lay_Boi_NL_Nhan_Vien"];
                }
            }
        }
        #endregion

    }
    #endregion
}