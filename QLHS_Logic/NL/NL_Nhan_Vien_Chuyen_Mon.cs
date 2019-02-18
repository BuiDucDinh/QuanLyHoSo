using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region NL_Nhan_Vien_Chuyen_Mon_Details
    public class NL_Nhan_Vien_Chuyen_Mon_Chi_Tiet
    {
        public int? Ma_Nhan_Vien_Chuyen_Mon = null; // Mã nhân viên chuyên môn
        public int? Ma_Nhan_Vien = null; // Mã nhân viên
        public int? Ma_Chuyen_Mon = null; // Mã chuyên môn
        public int? Ma_Dao_Tao = null; // Mã đào tạo
        public DateTime? Tu_Ngay = null; // Từ ngày
        public DateTime? Den_Ngay = null; // Đến ngày
        public string Ghi_Chu = null; // Ghi chú
    }
    #endregion
    #region NL_Nhan_Vien_Chuyen_Mon
    public class NL_Nhan_Vien_Chuyen_Mon
    {
        private string ConnectionString;
        public NL_Nhan_Vien_Chuyen_Mon(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_Nhan_Vien_Chuyen_Mon_Chi_Tiet Lay(int Ma_Nhan_Vien_Chuyen_Mon)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Chuyen_Mon_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien_Chuyen_Mon = new SqlParameter("@Ma_Nhan_Vien_Chuyen_Mon", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Chuyen_Mon.Value = Ma_Nhan_Vien_Chuyen_Mon;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Chuyen_Mon);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Nhan_Vien_Chuyen_Mon_Chi_Tiet");
                    NL_Nhan_Vien_Chuyen_Mon_Chi_Tiet myNL_Nhan_Vien_Chuyen_Mon_Chi_Tiet = new NL_Nhan_Vien_Chuyen_Mon_Chi_Tiet();
                    if (myDataSet.Tables["NL_Nhan_Vien_Chuyen_Mon_Chi_Tiet"] != null)
                    {
                        myNL_Nhan_Vien_Chuyen_Mon_Chi_Tiet.Ma_Nhan_Vien_Chuyen_Mon = Ma_Nhan_Vien_Chuyen_Mon;
                        myNL_Nhan_Vien_Chuyen_Mon_Chi_Tiet.Ma_Nhan_Vien = myDataSet.Tables["NL_Nhan_Vien_Chuyen_Mon_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Nhan_Vien_Chuyen_Mon_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] : (int?)null;
                        myNL_Nhan_Vien_Chuyen_Mon_Chi_Tiet.Ma_Chuyen_Mon = myDataSet.Tables["NL_Nhan_Vien_Chuyen_Mon_Chi_Tiet"].Rows[0]["Ma_Chuyen_Mon"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Nhan_Vien_Chuyen_Mon_Chi_Tiet"].Rows[0]["Ma_Chuyen_Mon"] : (int?)null;
                        myNL_Nhan_Vien_Chuyen_Mon_Chi_Tiet.Ma_Dao_Tao = myDataSet.Tables["NL_Nhan_Vien_Chuyen_Mon_Chi_Tiet"].Rows[0]["Ma_Dao_Tao"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Nhan_Vien_Chuyen_Mon_Chi_Tiet"].Rows[0]["Ma_Dao_Tao"] : (int?)null;
                        myNL_Nhan_Vien_Chuyen_Mon_Chi_Tiet.Tu_Ngay = myDataSet.Tables["NL_Nhan_Vien_Chuyen_Mon_Chi_Tiet"].Rows[0]["Tu_Ngay"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Nhan_Vien_Chuyen_Mon_Chi_Tiet"].Rows[0]["Tu_Ngay"] : (DateTime?)null;
                        myNL_Nhan_Vien_Chuyen_Mon_Chi_Tiet.Den_Ngay = myDataSet.Tables["NL_Nhan_Vien_Chuyen_Mon_Chi_Tiet"].Rows[0]["Den_Ngay"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Nhan_Vien_Chuyen_Mon_Chi_Tiet"].Rows[0]["Den_Ngay"] : (DateTime?)null;
                        myNL_Nhan_Vien_Chuyen_Mon_Chi_Tiet.Ghi_Chu = myDataSet.Tables["NL_Nhan_Vien_Chuyen_Mon_Chi_Tiet"].Rows[0]["Ghi_Chu"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Chuyen_Mon_Chi_Tiet"].Rows[0]["Ghi_Chu"] : (string)null;
                    }
                    return myNL_Nhan_Vien_Chuyen_Mon_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Ma_Nhan_Vien_Chuyen_Mon = null, int? Ma_Nhan_Vien = null, int? Ma_Chuyen_Mon = null, int? Ma_Dao_Tao = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null, string Ghi_Chu = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Chuyen_Mon_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien_Chuyen_Mon = new SqlParameter("@Ma_Nhan_Vien_Chuyen_Mon", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Chuyen_Mon.Value = Ma_Nhan_Vien_Chuyen_Mon;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Chuyen_Mon);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pMa_Chuyen_Mon = new SqlParameter("@Ma_Chuyen_Mon", SqlDbType.Int, 4);
                    pMa_Chuyen_Mon.Value = Ma_Chuyen_Mon;
                    myCommand.Parameters.Add(pMa_Chuyen_Mon);

                    SqlParameter pMa_Dao_Tao = new SqlParameter("@Ma_Dao_Tao", SqlDbType.Int, 4);
                    pMa_Dao_Tao.Value = Ma_Dao_Tao;
                    myCommand.Parameters.Add(pMa_Dao_Tao);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 250);
                    pGhi_Chu.Value = Ghi_Chu;
                    myCommand.Parameters.Add(pGhi_Chu);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int? Ma_Nhan_Vien_Chuyen_Mon = null, int? Ma_Nhan_Vien = null, int? Ma_Chuyen_Mon = null, int? Ma_Dao_Tao = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null, string Ghi_Chu = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Chuyen_Mon_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Nhan_Vien_Chuyen_Mon = new SqlParameter("@Ma_Nhan_Vien_Chuyen_Mon", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Chuyen_Mon.Value = Ma_Nhan_Vien_Chuyen_Mon;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Chuyen_Mon);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pMa_Chuyen_Mon = new SqlParameter("@Ma_Chuyen_Mon", SqlDbType.Int, 4);
                    pMa_Chuyen_Mon.Value = Ma_Chuyen_Mon;
                    myCommand.Parameters.Add(pMa_Chuyen_Mon);

                    SqlParameter pMa_Dao_Tao = new SqlParameter("@Ma_Dao_Tao", SqlDbType.Int, 4);
                    pMa_Dao_Tao.Value = Ma_Dao_Tao;
                    myCommand.Parameters.Add(pMa_Dao_Tao);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 250);
                    pGhi_Chu.Value = Ghi_Chu;
                    myCommand.Parameters.Add(pGhi_Chu);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(NL_Nhan_Vien_Chuyen_Mon_Chi_Tiet myNL_Nhan_Vien_Chuyen_Mon_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Chuyen_Mon_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien_Chuyen_Mon = new SqlParameter("@Ma_Nhan_Vien_Chuyen_Mon", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Chuyen_Mon.Value = myNL_Nhan_Vien_Chuyen_Mon_Chi_Tiet.Ma_Nhan_Vien_Chuyen_Mon;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Chuyen_Mon);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = myNL_Nhan_Vien_Chuyen_Mon_Chi_Tiet.Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pMa_Chuyen_Mon = new SqlParameter("@Ma_Chuyen_Mon", SqlDbType.Int, 4);
                    pMa_Chuyen_Mon.Value = myNL_Nhan_Vien_Chuyen_Mon_Chi_Tiet.Ma_Chuyen_Mon;
                    myCommand.Parameters.Add(pMa_Chuyen_Mon);

                    SqlParameter pMa_Dao_Tao = new SqlParameter("@Ma_Dao_Tao", SqlDbType.Int, 4);
                    pMa_Dao_Tao.Value = myNL_Nhan_Vien_Chuyen_Mon_Chi_Tiet.Ma_Dao_Tao;
                    myCommand.Parameters.Add(pMa_Dao_Tao);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = myNL_Nhan_Vien_Chuyen_Mon_Chi_Tiet.Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = myNL_Nhan_Vien_Chuyen_Mon_Chi_Tiet.Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 250);
                pGhi_Chu.Value = myNL_Nhan_Vien_Chuyen_Mon_Chi_Tiet.Ghi_Chu;
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
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Chuyen_Mon_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Nhan_Vien_Chuyen_Mon = new SqlParameter("@Ma_Nhan_Vien_Chuyen_Mon", SqlDbType.Int, 4);
                        pMa_Nhan_Vien_Chuyen_Mon.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nhan_Vien_Chuyen_Mon"];
                        myCommand.Parameters.Add(pMa_Nhan_Vien_Chuyen_Mon);

                        SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                        pMa_Nhan_Vien.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nhan_Vien"];
                        myCommand.Parameters.Add(pMa_Nhan_Vien);

                        SqlParameter pMa_Chuyen_Mon = new SqlParameter("@Ma_Chuyen_Mon", SqlDbType.Int, 4);
                        pMa_Chuyen_Mon.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Chuyen_Mon"];
                        myCommand.Parameters.Add(pMa_Chuyen_Mon);

                        SqlParameter pMa_Dao_Tao = new SqlParameter("@Ma_Dao_Tao", SqlDbType.Int, 4);
                        pMa_Dao_Tao.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Dao_Tao"];
                        myCommand.Parameters.Add(pMa_Dao_Tao);

                        SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                        pTu_Ngay.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Tu_Ngay"];
                        myCommand.Parameters.Add(pTu_Ngay);

                        SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                        pDen_Ngay.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Den_Ngay"];
                        myCommand.Parameters.Add(pDen_Ngay);

                        SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 250);
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
        public void Cap_Nhat_Them(int? Ma_Nhan_Vien_Chuyen_Mon = null, int? Ma_Nhan_Vien = null, int? Ma_Chuyen_Mon = null, int? Ma_Dao_Tao = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null,string Ghi_Chu=null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Chuyen_Mon_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien_Chuyen_Mon = new SqlParameter("@Ma_Nhan_Vien_Chuyen_Mon", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Chuyen_Mon.Value = Ma_Nhan_Vien_Chuyen_Mon;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Chuyen_Mon);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pMa_Chuyen_Mon = new SqlParameter("@Ma_Chuyen_Mon", SqlDbType.Int, 4);
                    pMa_Chuyen_Mon.Value = Ma_Chuyen_Mon;
                    myCommand.Parameters.Add(pMa_Chuyen_Mon);

                    SqlParameter pMa_Dao_Tao = new SqlParameter("@Ma_Dao_Tao", SqlDbType.Int, 4);
                    pMa_Dao_Tao.Value = Ma_Dao_Tao;
                    myCommand.Parameters.Add(pMa_Dao_Tao);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 250);
			        pGhi_Chu.Value = Ghi_Chu;
			        myCommand.Parameters.Add(pGhi_Chu);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Ma_Nhan_Vien_Chuyen_Mon)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Chuyen_Mon_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien_Chuyen_Mon = new SqlParameter("@Ma_Nhan_Vien_Chuyen_Mon", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Chuyen_Mon.Value = Ma_Nhan_Vien_Chuyen_Mon;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Chuyen_Mon);

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
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Chuyen_Mon_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Nhan_Vien_Chuyen_Mon_Danh_Sach");
                    return myDataSet.Tables["NL_Nhan_Vien_Chuyen_Mon_Danh_Sach"];
                }
            }
        }
        #endregion

        #region Lay_Boi_NL_DM_Chuyen_Mon
        public DataTable Lay_Boi_NL_DM_Chuyen_Mon(int Ma_Chuyen_Mon)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Chuyen_Mon_Lay_Boi_NL_DM_Chuyen_Mon", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Chuyen_Mon = new SqlParameter("@Ma_Chuyen_Mon", SqlDbType.Int, 4);
                    pMa_Chuyen_Mon.Value = Ma_Chuyen_Mon;
                    myCommand.Parameters.Add(pMa_Chuyen_Mon);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Nhan_Vien_Chuyen_Mon_Lay_Boi_NL_DM_Chuyen_Mon");
                    return myDataSet.Tables["NL_Nhan_Vien_Chuyen_Mon_Lay_Boi_NL_DM_Chuyen_Mon"];
                }
            }
        }
        #endregion
        #region Lay_Boi_NL_Nhan_Vien
        public DataTable Lay_Boi_NL_Nhan_Vien(int Ma_Nhan_Vien)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Chuyen_Mon_Lay_Boi_NL_Nhan_Vien", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Nhan_Vien_Chuyen_Mon_Lay_Boi_NL_Nhan_Vien");
                    return myDataSet.Tables["NL_Nhan_Vien_Chuyen_Mon_Lay_Boi_NL_Nhan_Vien"];
                }
            }
        }
        #endregion

    }
    #endregion
}