using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region NL_Dang_Doan_Details
    public class NL_Dang_Doan_Chi_Tiet
    {
        public int? Ma_Dang_Doan = null; // Mã đảng đoàn
        public int? Ma_Nhan_Vien = null; // Mã nhân viên
        public DateTime? Tu_Ngay = null; // Từ ngày
        public DateTime? Den_Ngay = null; // Đến ngày
        public string Chuc_Vu = null; // Chức vụ
        public string Nhiem_Vu = null; // Nhiệm vụ
    }
    #endregion
    #region NL_Dang_Doan
    public class NL_Dang_Doan
    {
        private string ConnectionString;
        public NL_Dang_Doan(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_Dang_Doan_Chi_Tiet Lay(int Ma_Dang_Doan)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Dang_Doan_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Dang_Doan = new SqlParameter("@Ma_Dang_Doan", SqlDbType.Int, 4);
                    pMa_Dang_Doan.Value = Ma_Dang_Doan;
                    myCommand.Parameters.Add(pMa_Dang_Doan);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Dang_Doan_Chi_Tiet");
                    NL_Dang_Doan_Chi_Tiet myNL_Dang_Doan_Chi_Tiet = new NL_Dang_Doan_Chi_Tiet();
                    if (myDataSet.Tables["NL_Dang_Doan_Chi_Tiet"] != null)
                    {
                        myNL_Dang_Doan_Chi_Tiet.Ma_Dang_Doan = Ma_Dang_Doan;
                        myNL_Dang_Doan_Chi_Tiet.Ma_Nhan_Vien = myDataSet.Tables["NL_Dang_Doan_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Dang_Doan_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] : (int?)null;
                        myNL_Dang_Doan_Chi_Tiet.Tu_Ngay = myDataSet.Tables["NL_Dang_Doan_Chi_Tiet"].Rows[0]["Tu_Ngay"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Dang_Doan_Chi_Tiet"].Rows[0]["Tu_Ngay"] : (DateTime?)null;
                        myNL_Dang_Doan_Chi_Tiet.Den_Ngay = myDataSet.Tables["NL_Dang_Doan_Chi_Tiet"].Rows[0]["Den_Ngay"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Dang_Doan_Chi_Tiet"].Rows[0]["Den_Ngay"] : (DateTime?)null;
                        myNL_Dang_Doan_Chi_Tiet.Chuc_Vu = myDataSet.Tables["NL_Dang_Doan_Chi_Tiet"].Rows[0]["Chuc_Vu"] != DBNull.Value ? (string)myDataSet.Tables["NL_Dang_Doan_Chi_Tiet"].Rows[0]["Chuc_Vu"] : (string)null;
                        myNL_Dang_Doan_Chi_Tiet.Nhiem_Vu = myDataSet.Tables["NL_Dang_Doan_Chi_Tiet"].Rows[0]["Nhiem_Vu"] != DBNull.Value ? (string)myDataSet.Tables["NL_Dang_Doan_Chi_Tiet"].Rows[0]["Nhiem_Vu"] : (string)null;
                    }
                    return myNL_Dang_Doan_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Ma_Dang_Doan = null, int? Ma_Nhan_Vien = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null, string Chuc_Vu = null, string Nhiem_Vu = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Dang_Doan_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Dang_Doan = new SqlParameter("@Ma_Dang_Doan", SqlDbType.Int, 4);
                    pMa_Dang_Doan.Value = Ma_Dang_Doan;
                    myCommand.Parameters.Add(pMa_Dang_Doan);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pChuc_Vu = new SqlParameter("@Chuc_Vu", SqlDbType.NVarChar, 500);
                    pChuc_Vu.Value = Chuc_Vu;
                    myCommand.Parameters.Add(pChuc_Vu);

                    SqlParameter pNhiem_Vu = new SqlParameter("@Nhiem_Vu", SqlDbType.NVarChar, 500);
                    pNhiem_Vu.Value = Nhiem_Vu;
                    myCommand.Parameters.Add(pNhiem_Vu);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int? Ma_Dang_Doan = null, int? Ma_Nhan_Vien = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null, string Chuc_Vu = null, string Nhiem_Vu = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Dang_Doan_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Dang_Doan = new SqlParameter("@Ma_Dang_Doan", SqlDbType.Int, 4);
                    pMa_Dang_Doan.Value = Ma_Dang_Doan;
                    myCommand.Parameters.Add(pMa_Dang_Doan);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pChuc_Vu = new SqlParameter("@Chuc_Vu", SqlDbType.NVarChar, 500);
                    pChuc_Vu.Value = Chuc_Vu;
                    myCommand.Parameters.Add(pChuc_Vu);

                    SqlParameter pNhiem_Vu = new SqlParameter("@Nhiem_Vu", SqlDbType.NVarChar, 500);
                    pNhiem_Vu.Value = Nhiem_Vu;
                    myCommand.Parameters.Add(pNhiem_Vu);



                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(NL_Dang_Doan_Chi_Tiet myNL_Dang_Doan_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Dang_Doan_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Dang_Doan = new SqlParameter("@Ma_Dang_Doan", SqlDbType.Int, 4);
                    pMa_Dang_Doan.Value = myNL_Dang_Doan_Chi_Tiet.Ma_Dang_Doan;
                    myCommand.Parameters.Add(pMa_Dang_Doan);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = myNL_Dang_Doan_Chi_Tiet.Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = myNL_Dang_Doan_Chi_Tiet.Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = myNL_Dang_Doan_Chi_Tiet.Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pChuc_Vu = new SqlParameter("@Chuc_Vu", SqlDbType.NVarChar, 500);
                    pChuc_Vu.Value = myNL_Dang_Doan_Chi_Tiet.Chuc_Vu;
                    myCommand.Parameters.Add(pChuc_Vu);

                    SqlParameter pNhiem_Vu = new SqlParameter("@Nhiem_Vu", SqlDbType.NVarChar, 500);
                    pNhiem_Vu.Value = myNL_Dang_Doan_Chi_Tiet.Nhiem_Vu;
                    myCommand.Parameters.Add(pNhiem_Vu);


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
                using (SqlCommand myCommand = new SqlCommand("NL_Dang_Doan_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Dang_Doan = new SqlParameter("@Ma_Dang_Doan", SqlDbType.Int, 4);
                        pMa_Dang_Doan.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Dang_Doan"];
                        myCommand.Parameters.Add(pMa_Dang_Doan);

                        SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                        pMa_Nhan_Vien.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nhan_Vien"];
                        myCommand.Parameters.Add(pMa_Nhan_Vien);

                        SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                        pTu_Ngay.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Tu_Ngay"];
                        myCommand.Parameters.Add(pTu_Ngay);

                        SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                        pDen_Ngay.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Den_Ngay"];
                        myCommand.Parameters.Add(pDen_Ngay);

                        SqlParameter pChuc_Vu = new SqlParameter("@Chuc_Vu", SqlDbType.NVarChar, 500);
                        pChuc_Vu.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Chuc_Vu"];
                        myCommand.Parameters.Add(pChuc_Vu);

                        SqlParameter pNhiem_Vu = new SqlParameter("@Nhiem_Vu", SqlDbType.NVarChar, 500);
                        pNhiem_Vu.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Nhiem_Vu"];
                        myCommand.Parameters.Add(pNhiem_Vu);


                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int? Ma_Dang_Doan = null, int? Ma_Nhan_Vien = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null, string Chuc_Vu = null, string Nhiem_Vu = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Dang_Doan_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Dang_Doan = new SqlParameter("@Ma_Dang_Doan", SqlDbType.Int, 4);
                    pMa_Dang_Doan.Value = Ma_Dang_Doan;
                    myCommand.Parameters.Add(pMa_Dang_Doan);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pChuc_Vu = new SqlParameter("@Chuc_Vu", SqlDbType.NVarChar, 500);
                    pChuc_Vu.Value = Chuc_Vu;
                    myCommand.Parameters.Add(pChuc_Vu);

                    SqlParameter pNhiem_Vu = new SqlParameter("@Nhiem_Vu", SqlDbType.NVarChar, 500);
                    pNhiem_Vu.Value = Nhiem_Vu;
                    myCommand.Parameters.Add(pNhiem_Vu);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Ma_Dang_Doan)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Dang_Doan_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Dang_Doan = new SqlParameter("@Ma_Dang_Doan", SqlDbType.Int, 4);
                    pMa_Dang_Doan.Value = Ma_Dang_Doan;
                    myCommand.Parameters.Add(pMa_Dang_Doan);

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
                using (SqlCommand myCommand = new SqlCommand("NL_Dang_Doan_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Dang_Doan_Danh_Sach");
                    return myDataSet.Tables["NL_Dang_Doan_Danh_Sach"];
                }
            }
        }
        #endregion

        #region Lay_Boi_NL_Nhan_Vien
        public DataTable Lay_Boi_NL_Nhan_Vien(int Ma_Nhan_Vien)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Dang_Doan_Lay_Boi_NL_Nhan_Vien", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Dang_Doan_Lay_Boi_NL_Nhan_Vien");
                    return myDataSet.Tables["NL_Dang_Doan_Lay_Boi_NL_Nhan_Vien"];
                }
            }
        }
        #endregion

    }
    #endregion
}