using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region NL_Qua_Trinh_Cong_Tac_Details
    public class NL_Qua_Trinh_Cong_Tac_Chi_Tiet
    {
        public int? Ma_Qua_Trinh = null; // Mã quá trình
        public int? Ma_Nhan_Vien = null; // Mã nhân viên
        public DateTime? Tu_Ngay = null; // Từ ngày
        public DateTime? Den_Ngay = null; // Đến ngày
        public int? Ma_Don_Vi = null; // Mã đơn vị
        public int? Ma_Chuc_Danh = null; // Mã chức danh
        public int? Ma_Chuc_Vu = null; // Mã chức vụ
        public string Ghi_Chu = null;
    }
    #endregion
    #region NL_Qua_Trinh_Cong_Tac
    public class NL_Qua_Trinh_Cong_Tac
    {
        private string ConnectionString;
        public NL_Qua_Trinh_Cong_Tac(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_Qua_Trinh_Cong_Tac_Chi_Tiet Lay(int Ma_Qua_Trinh)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Qua_Trinh_Cong_Tac_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Qua_Trinh = new SqlParameter("@Ma_Qua_Trinh", SqlDbType.Int, 4);
                    pMa_Qua_Trinh.Value = Ma_Qua_Trinh;
                    myCommand.Parameters.Add(pMa_Qua_Trinh);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Qua_Trinh_Cong_Tac_Chi_Tiet");
                    NL_Qua_Trinh_Cong_Tac_Chi_Tiet myNL_Qua_Trinh_Cong_Tac_Chi_Tiet = new NL_Qua_Trinh_Cong_Tac_Chi_Tiet();
                    if (myDataSet.Tables["NL_Qua_Trinh_Cong_Tac_Chi_Tiet"] != null)
                    {
                        myNL_Qua_Trinh_Cong_Tac_Chi_Tiet.Ma_Qua_Trinh = Ma_Qua_Trinh;
                        myNL_Qua_Trinh_Cong_Tac_Chi_Tiet.Ma_Nhan_Vien = myDataSet.Tables["NL_Qua_Trinh_Cong_Tac_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Qua_Trinh_Cong_Tac_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] : (int?)null;
                        myNL_Qua_Trinh_Cong_Tac_Chi_Tiet.Tu_Ngay = myDataSet.Tables["NL_Qua_Trinh_Cong_Tac_Chi_Tiet"].Rows[0]["Tu_Ngay"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Qua_Trinh_Cong_Tac_Chi_Tiet"].Rows[0]["Tu_Ngay"] : (DateTime?)null;
                        myNL_Qua_Trinh_Cong_Tac_Chi_Tiet.Den_Ngay = myDataSet.Tables["NL_Qua_Trinh_Cong_Tac_Chi_Tiet"].Rows[0]["Den_Ngay"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Qua_Trinh_Cong_Tac_Chi_Tiet"].Rows[0]["Den_Ngay"] : (DateTime?)null;
                        myNL_Qua_Trinh_Cong_Tac_Chi_Tiet.Ma_Don_Vi = myDataSet.Tables["NL_Qua_Trinh_Cong_Tac_Chi_Tiet"].Rows[0]["Ma_Don_Vi"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Qua_Trinh_Cong_Tac_Chi_Tiet"].Rows[0]["Ma_Don_Vi"] : (int?)null;
                        myNL_Qua_Trinh_Cong_Tac_Chi_Tiet.Ma_Chuc_Danh = myDataSet.Tables["NL_Qua_Trinh_Cong_Tac_Chi_Tiet"].Rows[0]["Ma_Chuc_Danh"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Qua_Trinh_Cong_Tac_Chi_Tiet"].Rows[0]["Ma_Chuc_Danh"] : (int?)null;
                        myNL_Qua_Trinh_Cong_Tac_Chi_Tiet.Ma_Chuc_Vu = myDataSet.Tables["NL_Qua_Trinh_Cong_Tac_Chi_Tiet"].Rows[0]["Ma_Chuc_Vu"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Qua_Trinh_Cong_Tac_Chi_Tiet"].Rows[0]["Ma_Chuc_Vu"] : (int?)null;
                        myNL_Qua_Trinh_Cong_Tac_Chi_Tiet.Ghi_Chu = myDataSet.Tables["NL_Qua_Trinh_Cong_Tac_Chi_Tiet"].Rows[0]["Ghi_Chu"] != DBNull.Value ? (string)myDataSet.Tables["NL_Qua_Trinh_Cong_Tac_Chi_Tiet"].Rows[0]["Ghi_Chu"] : (string)null;
                    }
                    return myNL_Qua_Trinh_Cong_Tac_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Ma_Qua_Trinh = null, int? Ma_Nhan_Vien = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null, int? Ma_Don_Vi = null, int? Ma_Chuc_Danh = null, int? Ma_Chuc_Vu = null, string Ghi_Chu = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Qua_Trinh_Cong_Tac_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Qua_Trinh = new SqlParameter("@Ma_Qua_Trinh", SqlDbType.Int, 4);
                    pMa_Qua_Trinh.Value = Ma_Qua_Trinh;
                    myCommand.Parameters.Add(pMa_Qua_Trinh);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pMa_Chuc_Danh = new SqlParameter("@Ma_Chuc_Danh", SqlDbType.Int, 4);
                    pMa_Chuc_Danh.Value = Ma_Chuc_Danh;
                    myCommand.Parameters.Add(pMa_Chuc_Danh);

                    SqlParameter pMa_Chuc_Vu = new SqlParameter("@Ma_Chuc_Vu", SqlDbType.Int, 4);
                    pMa_Chuc_Vu.Value = Ma_Chuc_Vu;
                    myCommand.Parameters.Add(pMa_Chuc_Vu);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 500);
                    pGhi_Chu.Value = Ghi_Chu;
                    myCommand.Parameters.Add(pGhi_Chu);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int? Ma_Qua_Trinh = null, int? Ma_Nhan_Vien = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null, int? Ma_Don_Vi = null, int? Ma_Chuc_Danh = null, int? Ma_Chuc_Vu = null, string Ghi_Chu = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Qua_Trinh_Cong_Tac_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Qua_Trinh = new SqlParameter("@Ma_Qua_Trinh", SqlDbType.Int, 4);
                    pMa_Qua_Trinh.Value = Ma_Qua_Trinh;
                    myCommand.Parameters.Add(pMa_Qua_Trinh);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pMa_Chuc_Danh = new SqlParameter("@Ma_Chuc_Danh", SqlDbType.Int, 4);
                    pMa_Chuc_Danh.Value = Ma_Chuc_Danh;
                    myCommand.Parameters.Add(pMa_Chuc_Danh);

                    SqlParameter pMa_Chuc_Vu = new SqlParameter("@Ma_Chuc_Vu", SqlDbType.Int, 4);
                    pMa_Chuc_Vu.Value = Ma_Chuc_Vu;
                    myCommand.Parameters.Add(pMa_Chuc_Vu);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 500);
                    pGhi_Chu.Value = Ghi_Chu;
                    myCommand.Parameters.Add(pGhi_Chu);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(NL_Qua_Trinh_Cong_Tac_Chi_Tiet myNL_Qua_Trinh_Cong_Tac_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Qua_Trinh_Cong_Tac_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Qua_Trinh = new SqlParameter("@Ma_Qua_Trinh", SqlDbType.Int, 4);
                    pMa_Qua_Trinh.Value = myNL_Qua_Trinh_Cong_Tac_Chi_Tiet.Ma_Qua_Trinh;
                    myCommand.Parameters.Add(pMa_Qua_Trinh);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = myNL_Qua_Trinh_Cong_Tac_Chi_Tiet.Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = myNL_Qua_Trinh_Cong_Tac_Chi_Tiet.Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = myNL_Qua_Trinh_Cong_Tac_Chi_Tiet.Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = myNL_Qua_Trinh_Cong_Tac_Chi_Tiet.Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pMa_Chuc_Danh = new SqlParameter("@Ma_Chuc_Danh", SqlDbType.Int, 4);
                    pMa_Chuc_Danh.Value = myNL_Qua_Trinh_Cong_Tac_Chi_Tiet.Ma_Chuc_Danh;
                    myCommand.Parameters.Add(pMa_Chuc_Danh);

                    SqlParameter pMa_Chuc_Vu = new SqlParameter("@Ma_Chuc_Vu", SqlDbType.Int, 4);
                    pMa_Chuc_Vu.Value = myNL_Qua_Trinh_Cong_Tac_Chi_Tiet.Ma_Chuc_Vu;
                    myCommand.Parameters.Add(pMa_Chuc_Vu);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 500);
                    pGhi_Chu.Value = myNL_Qua_Trinh_Cong_Tac_Chi_Tiet.Ghi_Chu;
                    myCommand.Parameters.Add(pGhi_Chu);


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
                using (SqlCommand myCommand = new SqlCommand("NL_Qua_Trinh_Cong_Tac_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Qua_Trinh = new SqlParameter("@Ma_Qua_Trinh", SqlDbType.Int, 4);
                        pMa_Qua_Trinh.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Qua_Trinh"];
                        myCommand.Parameters.Add(pMa_Qua_Trinh);

                        SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                        pMa_Nhan_Vien.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nhan_Vien"];
                        myCommand.Parameters.Add(pMa_Nhan_Vien);

                        SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                        pTu_Ngay.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Tu_Ngay"];
                        myCommand.Parameters.Add(pTu_Ngay);

                        SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                        pDen_Ngay.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Den_Ngay"];
                        myCommand.Parameters.Add(pDen_Ngay);

                        SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                        pMa_Don_Vi.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Don_Vi"];
                        myCommand.Parameters.Add(pMa_Don_Vi);

                        SqlParameter pMa_Chuc_Danh = new SqlParameter("@Ma_Chuc_Danh", SqlDbType.Int, 4);
                        pMa_Chuc_Danh.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Chuc_Danh"];
                        myCommand.Parameters.Add(pMa_Chuc_Danh);

                        SqlParameter pMa_Chuc_Vu = new SqlParameter("@Ma_Chuc_Vu", SqlDbType.Int, 4);
                        pMa_Chuc_Vu.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Chuc_Vu"];
                        myCommand.Parameters.Add(pMa_Chuc_Vu);

                        SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 500);
                        pGhi_Chu.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ghi_Chu"];
                        myCommand.Parameters.Add(pGhi_Chu);


                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int? Ma_Qua_Trinh = null, int? Ma_Nhan_Vien = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null, int? Ma_Don_Vi = null, int? Ma_Chuc_Danh = null, int? Ma_Chuc_Vu = null, string Ghi_Chu = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Qua_Trinh_Cong_Tac_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Qua_Trinh = new SqlParameter("@Ma_Qua_Trinh", SqlDbType.Int, 4);
                    pMa_Qua_Trinh.Value = Ma_Qua_Trinh;
                    myCommand.Parameters.Add(pMa_Qua_Trinh);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pMa_Chuc_Danh = new SqlParameter("@Ma_Chuc_Danh", SqlDbType.Int, 4);
                    pMa_Chuc_Danh.Value = Ma_Chuc_Danh;
                    myCommand.Parameters.Add(pMa_Chuc_Danh);

                    SqlParameter pMa_Chuc_Vu = new SqlParameter("@Ma_Chuc_Vu", SqlDbType.Int, 4);
                    pMa_Chuc_Vu.Value = Ma_Chuc_Vu;
                    myCommand.Parameters.Add(pMa_Chuc_Vu);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 500);
                    pGhi_Chu.Value = Ghi_Chu;
                    myCommand.Parameters.Add(pGhi_Chu);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Ma_Qua_Trinh)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Qua_Trinh_Cong_Tac_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Qua_Trinh = new SqlParameter("@Ma_Qua_Trinh", SqlDbType.Int, 4);
                    pMa_Qua_Trinh.Value = Ma_Qua_Trinh;
                    myCommand.Parameters.Add(pMa_Qua_Trinh);

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
                using (SqlCommand myCommand = new SqlCommand("NL_Qua_Trinh_Cong_Tac_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Qua_Trinh_Cong_Tac_Danh_Sach");
                    return myDataSet.Tables["NL_Qua_Trinh_Cong_Tac_Danh_Sach"];
                }
            }
        }
        #endregion

        #region Lay_Boi_NL_Nhan_Vien
        public DataTable Lay_Boi_NL_Nhan_Vien(int Ma_Nhan_Vien)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Qua_Trinh_Cong_Tac_Lay_Boi_NL_Nhan_Vien", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Qua_Trinh_Cong_Tac_Lay_Boi_NL_Nhan_Vien");
                    return myDataSet.Tables["NL_Qua_Trinh_Cong_Tac_Lay_Boi_NL_Nhan_Vien"];
                }
            }
        }
        #endregion

    }
    #endregion
}