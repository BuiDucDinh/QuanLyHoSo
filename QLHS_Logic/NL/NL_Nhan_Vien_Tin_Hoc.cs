using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region NL_Nhan_Vien_Tin_Hoc_Details
    public class NL_Nhan_Vien_Tin_Hoc_Chi_Tiet
    {
        public int? Ma_Nhan_Vien_Tin_Hoc = null; // Mã nhân viên tin học
        public int? Ma_Nhan_Vien = null; // Mã nhân viên
        public int? Ma_Tin_Hoc = null; // Mã in học
        public DateTime? Tu_Ngay = null; // Từ  ngày
        public DateTime? Den_Ngay = null; // Đến ngày
    }
    #endregion
    #region NL_Nhan_Vien_Tin_Hoc
    public class NL_Nhan_Vien_Tin_Hoc
    {
        private string ConnectionString;
        public NL_Nhan_Vien_Tin_Hoc(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_Nhan_Vien_Tin_Hoc_Chi_Tiet Lay(int Ma_Nhan_Vien_Tin_Hoc)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Tin_Hoc_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien_Tin_Hoc = new SqlParameter("@Ma_Nhan_Vien_Tin_Hoc", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Tin_Hoc.Value = Ma_Nhan_Vien_Tin_Hoc;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Tin_Hoc);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Nhan_Vien_Tin_Hoc_Chi_Tiet");
                    NL_Nhan_Vien_Tin_Hoc_Chi_Tiet myNL_Nhan_Vien_Tin_Hoc_Chi_Tiet = new NL_Nhan_Vien_Tin_Hoc_Chi_Tiet();
                    if (myDataSet.Tables["NL_Nhan_Vien_Tin_Hoc_Chi_Tiet"] != null)
                    {
                        myNL_Nhan_Vien_Tin_Hoc_Chi_Tiet.Ma_Nhan_Vien_Tin_Hoc = Ma_Nhan_Vien_Tin_Hoc;
                        myNL_Nhan_Vien_Tin_Hoc_Chi_Tiet.Ma_Nhan_Vien = myDataSet.Tables["NL_Nhan_Vien_Tin_Hoc_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Nhan_Vien_Tin_Hoc_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] : (int?)null;
                        myNL_Nhan_Vien_Tin_Hoc_Chi_Tiet.Ma_Tin_Hoc = myDataSet.Tables["NL_Nhan_Vien_Tin_Hoc_Chi_Tiet"].Rows[0]["Ma_Tin_Hoc"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Nhan_Vien_Tin_Hoc_Chi_Tiet"].Rows[0]["Ma_Tin_Hoc"] : (int?)null;
                        myNL_Nhan_Vien_Tin_Hoc_Chi_Tiet.Tu_Ngay = myDataSet.Tables["NL_Nhan_Vien_Tin_Hoc_Chi_Tiet"].Rows[0]["Tu_Ngay"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Nhan_Vien_Tin_Hoc_Chi_Tiet"].Rows[0]["Tu_Ngay"] : (DateTime?)null;
                        myNL_Nhan_Vien_Tin_Hoc_Chi_Tiet.Den_Ngay = myDataSet.Tables["NL_Nhan_Vien_Tin_Hoc_Chi_Tiet"].Rows[0]["Den_Ngay"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Nhan_Vien_Tin_Hoc_Chi_Tiet"].Rows[0]["Den_Ngay"] : (DateTime?)null;
                    }
                    return myNL_Nhan_Vien_Tin_Hoc_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Ma_Nhan_Vien_Tin_Hoc = null, int? Ma_Nhan_Vien = null, int? Ma_Tin_Hoc = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Tin_Hoc_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien_Tin_Hoc = new SqlParameter("@Ma_Nhan_Vien_Tin_Hoc", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Tin_Hoc.Value = Ma_Nhan_Vien_Tin_Hoc;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Tin_Hoc);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pMa_Tin_Hoc = new SqlParameter("@Ma_Tin_Hoc", SqlDbType.Int, 4);
                    pMa_Tin_Hoc.Value = Ma_Tin_Hoc;
                    myCommand.Parameters.Add(pMa_Tin_Hoc);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int? Ma_Nhan_Vien_Tin_Hoc = null, int? Ma_Nhan_Vien = null, int? Ma_Tin_Hoc = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Tin_Hoc_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Nhan_Vien_Tin_Hoc = new SqlParameter("@Ma_Nhan_Vien_Tin_Hoc", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Tin_Hoc.Value = Ma_Nhan_Vien_Tin_Hoc;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Tin_Hoc);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pMa_Tin_Hoc = new SqlParameter("@Ma_Tin_Hoc", SqlDbType.Int, 4);
                    pMa_Tin_Hoc.Value = Ma_Tin_Hoc;
                    myCommand.Parameters.Add(pMa_Tin_Hoc);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);



                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(NL_Nhan_Vien_Tin_Hoc_Chi_Tiet myNL_Nhan_Vien_Tin_Hoc_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Tin_Hoc_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien_Tin_Hoc = new SqlParameter("@Ma_Nhan_Vien_Tin_Hoc", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Tin_Hoc.Value = myNL_Nhan_Vien_Tin_Hoc_Chi_Tiet.Ma_Nhan_Vien_Tin_Hoc;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Tin_Hoc);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = myNL_Nhan_Vien_Tin_Hoc_Chi_Tiet.Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pMa_Tin_Hoc = new SqlParameter("@Ma_Tin_Hoc", SqlDbType.Int, 4);
                    pMa_Tin_Hoc.Value = myNL_Nhan_Vien_Tin_Hoc_Chi_Tiet.Ma_Tin_Hoc;
                    myCommand.Parameters.Add(pMa_Tin_Hoc);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = myNL_Nhan_Vien_Tin_Hoc_Chi_Tiet.Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = myNL_Nhan_Vien_Tin_Hoc_Chi_Tiet.Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);


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
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Tin_Hoc_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Nhan_Vien_Tin_Hoc = new SqlParameter("@Ma_Nhan_Vien_Tin_Hoc", SqlDbType.Int, 4);
                        pMa_Nhan_Vien_Tin_Hoc.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nhan_Vien_Tin_Hoc"];
                        myCommand.Parameters.Add(pMa_Nhan_Vien_Tin_Hoc);

                        SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                        pMa_Nhan_Vien.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nhan_Vien"];
                        myCommand.Parameters.Add(pMa_Nhan_Vien);

                        SqlParameter pMa_Tin_Hoc = new SqlParameter("@Ma_Tin_Hoc", SqlDbType.Int, 4);
                        pMa_Tin_Hoc.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Tin_Hoc"];
                        myCommand.Parameters.Add(pMa_Tin_Hoc);

                        SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                        pTu_Ngay.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Tu_Ngay"];
                        myCommand.Parameters.Add(pTu_Ngay);

                        SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                        pDen_Ngay.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Den_Ngay"];
                        myCommand.Parameters.Add(pDen_Ngay);


                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int? Ma_Nhan_Vien_Tin_Hoc = null, int? Ma_Nhan_Vien = null, int? Ma_Tin_Hoc = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Tin_Hoc_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien_Tin_Hoc = new SqlParameter("@Ma_Nhan_Vien_Tin_Hoc", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Tin_Hoc.Value = Ma_Nhan_Vien_Tin_Hoc;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Tin_Hoc);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pMa_Tin_Hoc = new SqlParameter("@Ma_Tin_Hoc", SqlDbType.Int, 4);
                    pMa_Tin_Hoc.Value = Ma_Tin_Hoc;
                    myCommand.Parameters.Add(pMa_Tin_Hoc);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Ma_Nhan_Vien_Tin_Hoc)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Tin_Hoc_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien_Tin_Hoc = new SqlParameter("@Ma_Nhan_Vien_Tin_Hoc", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Tin_Hoc.Value = Ma_Nhan_Vien_Tin_Hoc;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Tin_Hoc);

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
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Tin_Hoc_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Nhan_Vien_Tin_Hoc_Danh_Sach");
                    return myDataSet.Tables["NL_Nhan_Vien_Tin_Hoc_Danh_Sach"];
                }
            }
        }
        #endregion

        #region Lay_Boi_NL_DM_Tin_Hoc
        public DataTable Lay_Boi_NL_DM_Tin_Hoc(int Ma_Tin_Hoc)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Tin_Hoc_Lay_Boi_NL_DM_Tin_Hoc", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Tin_Hoc = new SqlParameter("@Ma_Tin_Hoc", SqlDbType.Int, 4);
                    pMa_Tin_Hoc.Value = Ma_Tin_Hoc;
                    myCommand.Parameters.Add(pMa_Tin_Hoc);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Nhan_Vien_Tin_Hoc_Lay_Boi_NL_DM_Tin_Hoc");
                    return myDataSet.Tables["NL_Nhan_Vien_Tin_Hoc_Lay_Boi_NL_DM_Tin_Hoc"];
                }
            }
        }
        #endregion
        #region Lay_Boi_NL_Nhan_Vien
        public DataTable Lay_Boi_NL_Nhan_Vien(int Ma_Nhan_Vien)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Tin_Hoc_Lay_Boi_NL_Nhan_Vien", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Nhan_Vien_Tin_Hoc_Lay_Boi_NL_Nhan_Vien");
                    return myDataSet.Tables["NL_Nhan_Vien_Tin_Hoc_Lay_Boi_NL_Nhan_Vien"];
                }
            }
        }
        #endregion

    }
    #endregion
}