using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region NL_Lich_Su_Ban_Than_Details
    public class NL_Lich_Su_Ban_Than_Chi_Tiet
    {
        public int? Ma_LS_Ban_Than = null; // Mã lịch sử bản thân
        public int? Ma_Nhan_Vien = null; // Mã nhân viên
        public DateTime? Tu_Ngay = null; // Từ ngày
        public DateTime? Den_Ngay = null; // Đến ngày
        public string Thong_Tin_Lich_Su = null; // Thông tin lịch sử
    }
    #endregion
    #region NL_Lich_Su_Ban_Than
    public class NL_Lich_Su_Ban_Than
    {
        private string ConnectionString;
        public NL_Lich_Su_Ban_Than(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_Lich_Su_Ban_Than_Chi_Tiet Lay(int Ma_LS_Ban_Than)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Lich_Su_Ban_Than_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_LS_Ban_Than = new SqlParameter("@Ma_LS_Ban_Than", SqlDbType.Int, 4);
                    pMa_LS_Ban_Than.Value = Ma_LS_Ban_Than;
                    myCommand.Parameters.Add(pMa_LS_Ban_Than);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Lich_Su_Ban_Than_Chi_Tiet");
                    NL_Lich_Su_Ban_Than_Chi_Tiet myNL_Lich_Su_Ban_Than_Chi_Tiet = new NL_Lich_Su_Ban_Than_Chi_Tiet();
                    if (myDataSet.Tables["NL_Lich_Su_Ban_Than_Chi_Tiet"] != null)
                    {
                        myNL_Lich_Su_Ban_Than_Chi_Tiet.Ma_LS_Ban_Than = Ma_LS_Ban_Than;
                        myNL_Lich_Su_Ban_Than_Chi_Tiet.Ma_Nhan_Vien = myDataSet.Tables["NL_Lich_Su_Ban_Than_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Lich_Su_Ban_Than_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] : (int?)null;
                        myNL_Lich_Su_Ban_Than_Chi_Tiet.Tu_Ngay = myDataSet.Tables["NL_Lich_Su_Ban_Than_Chi_Tiet"].Rows[0]["Tu_Ngay"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Lich_Su_Ban_Than_Chi_Tiet"].Rows[0]["Tu_Ngay"] : (DateTime?)null;
                        myNL_Lich_Su_Ban_Than_Chi_Tiet.Den_Ngay = myDataSet.Tables["NL_Lich_Su_Ban_Than_Chi_Tiet"].Rows[0]["Den_Ngay"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Lich_Su_Ban_Than_Chi_Tiet"].Rows[0]["Den_Ngay"] : (DateTime?)null;
                        myNL_Lich_Su_Ban_Than_Chi_Tiet.Thong_Tin_Lich_Su = myDataSet.Tables["NL_Lich_Su_Ban_Than_Chi_Tiet"].Rows[0]["Thong_Tin_Lich_Su"] != DBNull.Value ? (string)myDataSet.Tables["NL_Lich_Su_Ban_Than_Chi_Tiet"].Rows[0]["Thong_Tin_Lich_Su"] : (string)null;
                    }
                    return myNL_Lich_Su_Ban_Than_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Ma_LS_Ban_Than = null, int? Ma_Nhan_Vien = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null, string Thong_Tin_Lich_Su = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Lich_Su_Ban_Than_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_LS_Ban_Than = new SqlParameter("@Ma_LS_Ban_Than", SqlDbType.Int, 4);
                    pMa_LS_Ban_Than.Value = Ma_LS_Ban_Than;
                    myCommand.Parameters.Add(pMa_LS_Ban_Than);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pThong_Tin_Lich_Su = new SqlParameter("@Thong_Tin_Lich_Su", SqlDbType.NText);
                    pThong_Tin_Lich_Su.Value = Thong_Tin_Lich_Su;
                    myCommand.Parameters.Add(pThong_Tin_Lich_Su);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int? Ma_LS_Ban_Than = null, int? Ma_Nhan_Vien = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null, string Thong_Tin_Lich_Su = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Lich_Su_Ban_Than_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_LS_Ban_Than = new SqlParameter("@Ma_LS_Ban_Than", SqlDbType.Int, 4);
                    pMa_LS_Ban_Than.Value = Ma_LS_Ban_Than;
                    myCommand.Parameters.Add(pMa_LS_Ban_Than);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pThong_Tin_Lich_Su = new SqlParameter("@Thong_Tin_Lich_Su", SqlDbType.NText);
                    pThong_Tin_Lich_Su.Value = Thong_Tin_Lich_Su;
                    myCommand.Parameters.Add(pThong_Tin_Lich_Su);



                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(NL_Lich_Su_Ban_Than_Chi_Tiet myNL_Lich_Su_Ban_Than_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Lich_Su_Ban_Than_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_LS_Ban_Than = new SqlParameter("@Ma_LS_Ban_Than", SqlDbType.Int, 4);
                    pMa_LS_Ban_Than.Value = myNL_Lich_Su_Ban_Than_Chi_Tiet.Ma_LS_Ban_Than;
                    myCommand.Parameters.Add(pMa_LS_Ban_Than);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = myNL_Lich_Su_Ban_Than_Chi_Tiet.Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = myNL_Lich_Su_Ban_Than_Chi_Tiet.Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = myNL_Lich_Su_Ban_Than_Chi_Tiet.Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pThong_Tin_Lich_Su = new SqlParameter("@Thong_Tin_Lich_Su", SqlDbType.NText);
                    pThong_Tin_Lich_Su.Value = myNL_Lich_Su_Ban_Than_Chi_Tiet.Thong_Tin_Lich_Su;
                    myCommand.Parameters.Add(pThong_Tin_Lich_Su);


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
                using (SqlCommand myCommand = new SqlCommand("NL_Lich_Su_Ban_Than_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_LS_Ban_Than = new SqlParameter("@Ma_LS_Ban_Than", SqlDbType.Int, 4);
                        pMa_LS_Ban_Than.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_LS_Ban_Than"];
                        myCommand.Parameters.Add(pMa_LS_Ban_Than);

                        SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                        pMa_Nhan_Vien.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nhan_Vien"];
                        myCommand.Parameters.Add(pMa_Nhan_Vien);

                        SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                        pTu_Ngay.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Tu_Ngay"];
                        myCommand.Parameters.Add(pTu_Ngay);

                        SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                        pDen_Ngay.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Den_Ngay"];
                        myCommand.Parameters.Add(pDen_Ngay);

                        SqlParameter pThong_Tin_Lich_Su = new SqlParameter("@Thong_Tin_Lich_Su", SqlDbType.NText);
                        pThong_Tin_Lich_Su.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Thong_Tin_Lich_Su"];
                        myCommand.Parameters.Add(pThong_Tin_Lich_Su);


                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int? Ma_LS_Ban_Than = null, int? Ma_Nhan_Vien = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null, string Thong_Tin_Lich_Su = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Lich_Su_Ban_Than_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_LS_Ban_Than = new SqlParameter("@Ma_LS_Ban_Than", SqlDbType.Int, 4);
                    pMa_LS_Ban_Than.Value = Ma_LS_Ban_Than;
                    myCommand.Parameters.Add(pMa_LS_Ban_Than);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pThong_Tin_Lich_Su = new SqlParameter("@Thong_Tin_Lich_Su", SqlDbType.NText);
                    pThong_Tin_Lich_Su.Value = Thong_Tin_Lich_Su;
                    myCommand.Parameters.Add(pThong_Tin_Lich_Su);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Ma_LS_Ban_Than)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Lich_Su_Ban_Than_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_LS_Ban_Than = new SqlParameter("@Ma_LS_Ban_Than", SqlDbType.Int, 4);
                    pMa_LS_Ban_Than.Value = Ma_LS_Ban_Than;
                    myCommand.Parameters.Add(pMa_LS_Ban_Than);

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
                using (SqlCommand myCommand = new SqlCommand("NL_Lich_Su_Ban_Than_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Lich_Su_Ban_Than_Danh_Sach");
                    return myDataSet.Tables["NL_Lich_Su_Ban_Than_Danh_Sach"];
                }
            }
        }
        #endregion

        #region Lay_Boi_NL_Nhan_Vien
        public DataTable Lay_Boi_NL_Nhan_Vien(int Ma_Nhan_Vien)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Lich_Su_Ban_Than_Lay_Boi_NL_Nhan_Vien", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Lich_Su_Ban_Than_Lay_Boi_NL_Nhan_Vien");
                    return myDataSet.Tables["NL_Lich_Su_Ban_Than_Lay_Boi_NL_Nhan_Vien"];
                }
            }
        }
        #endregion

    }
    #endregion
}