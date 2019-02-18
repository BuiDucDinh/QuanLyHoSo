using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region NL_Nhan_Vien_Chinh_Tri_Details
    public class NL_Nhan_Vien_Chinh_Tri_Chi_Tiet
    {
        public int? Ma_Nhan_Vien_Chinh_Tri = null; // mã nhân viên chính trị
        public int? Ma_Nhan_Vien = null; // Mã nhân viên
        public int? Ma_Chinh_Tri = null; // Mã chính trị
        public DateTime? Tu_Ngay = null; // Từ  ngày
        public DateTime? Den_Ngay = null; // Đến  ngày
    }
    #endregion
    #region NL_Nhan_Vien_Chinh_Tri
    public class NL_Nhan_Vien_Chinh_Tri
    {
        private string ConnectionString;
        public NL_Nhan_Vien_Chinh_Tri(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_Nhan_Vien_Chinh_Tri_Chi_Tiet Lay(int Ma_Nhan_Vien_Chinh_Tri)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Chinh_Tri_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien_Chinh_Tri = new SqlParameter("@Ma_Nhan_Vien_Chinh_Tri", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Chinh_Tri.Value = Ma_Nhan_Vien_Chinh_Tri;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Chinh_Tri);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Nhan_Vien_Chinh_Tri_Chi_Tiet");
                    NL_Nhan_Vien_Chinh_Tri_Chi_Tiet myNL_Nhan_Vien_Chinh_Tri_Chi_Tiet = new NL_Nhan_Vien_Chinh_Tri_Chi_Tiet();
                    if (myDataSet.Tables["NL_Nhan_Vien_Chinh_Tri_Chi_Tiet"] != null)
                    {
                        myNL_Nhan_Vien_Chinh_Tri_Chi_Tiet.Ma_Nhan_Vien_Chinh_Tri = Ma_Nhan_Vien_Chinh_Tri;
                        myNL_Nhan_Vien_Chinh_Tri_Chi_Tiet.Ma_Nhan_Vien = myDataSet.Tables["NL_Nhan_Vien_Chinh_Tri_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Nhan_Vien_Chinh_Tri_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] : (int?)null;
                        myNL_Nhan_Vien_Chinh_Tri_Chi_Tiet.Ma_Chinh_Tri = myDataSet.Tables["NL_Nhan_Vien_Chinh_Tri_Chi_Tiet"].Rows[0]["Ma_Chinh_Tri"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Nhan_Vien_Chinh_Tri_Chi_Tiet"].Rows[0]["Ma_Chinh_Tri"] : (int?)null;
                        myNL_Nhan_Vien_Chinh_Tri_Chi_Tiet.Tu_Ngay = myDataSet.Tables["NL_Nhan_Vien_Chinh_Tri_Chi_Tiet"].Rows[0]["Tu_Ngay"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Nhan_Vien_Chinh_Tri_Chi_Tiet"].Rows[0]["Tu_Ngay"] : (DateTime?)null;
                        myNL_Nhan_Vien_Chinh_Tri_Chi_Tiet.Den_Ngay = myDataSet.Tables["NL_Nhan_Vien_Chinh_Tri_Chi_Tiet"].Rows[0]["Den_Ngay"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Nhan_Vien_Chinh_Tri_Chi_Tiet"].Rows[0]["Den_Ngay"] : (DateTime?)null;
                    }
                    return myNL_Nhan_Vien_Chinh_Tri_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Ma_Nhan_Vien_Chinh_Tri = null, int? Ma_Nhan_Vien = null, int? Ma_Chinh_Tri = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Chinh_Tri_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien_Chinh_Tri = new SqlParameter("@Ma_Nhan_Vien_Chinh_Tri", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Chinh_Tri.Value = Ma_Nhan_Vien_Chinh_Tri;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Chinh_Tri);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pMa_Chinh_Tri = new SqlParameter("@Ma_Chinh_Tri", SqlDbType.Int, 4);
                    pMa_Chinh_Tri.Value = Ma_Chinh_Tri;
                    myCommand.Parameters.Add(pMa_Chinh_Tri);

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
        public void Cap_Nhat(int? Ma_Nhan_Vien_Chinh_Tri = null, int? Ma_Nhan_Vien = null, int? Ma_Chinh_Tri = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Chinh_Tri_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Nhan_Vien_Chinh_Tri = new SqlParameter("@Ma_Nhan_Vien_Chinh_Tri", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Chinh_Tri.Value = Ma_Nhan_Vien_Chinh_Tri;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Chinh_Tri);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pMa_Chinh_Tri = new SqlParameter("@Ma_Chinh_Tri", SqlDbType.Int, 4);
                    pMa_Chinh_Tri.Value = Ma_Chinh_Tri;
                    myCommand.Parameters.Add(pMa_Chinh_Tri);

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
        public void Cap_Nhat(NL_Nhan_Vien_Chinh_Tri_Chi_Tiet myNL_Nhan_Vien_Chinh_Tri_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Chinh_Tri_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien_Chinh_Tri = new SqlParameter("@Ma_Nhan_Vien_Chinh_Tri", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Chinh_Tri.Value = myNL_Nhan_Vien_Chinh_Tri_Chi_Tiet.Ma_Nhan_Vien_Chinh_Tri;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Chinh_Tri);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = myNL_Nhan_Vien_Chinh_Tri_Chi_Tiet.Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pMa_Chinh_Tri = new SqlParameter("@Ma_Chinh_Tri", SqlDbType.Int, 4);
                    pMa_Chinh_Tri.Value = myNL_Nhan_Vien_Chinh_Tri_Chi_Tiet.Ma_Chinh_Tri;
                    myCommand.Parameters.Add(pMa_Chinh_Tri);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = myNL_Nhan_Vien_Chinh_Tri_Chi_Tiet.Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = myNL_Nhan_Vien_Chinh_Tri_Chi_Tiet.Den_Ngay;
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
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Chinh_Tri_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Nhan_Vien_Chinh_Tri = new SqlParameter("@Ma_Nhan_Vien_Chinh_Tri", SqlDbType.Int, 4);
                        pMa_Nhan_Vien_Chinh_Tri.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nhan_Vien_Chinh_Tri"];
                        myCommand.Parameters.Add(pMa_Nhan_Vien_Chinh_Tri);

                        SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                        pMa_Nhan_Vien.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nhan_Vien"];
                        myCommand.Parameters.Add(pMa_Nhan_Vien);

                        SqlParameter pMa_Chinh_Tri = new SqlParameter("@Ma_Chinh_Tri", SqlDbType.Int, 4);
                        pMa_Chinh_Tri.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Chinh_Tri"];
                        myCommand.Parameters.Add(pMa_Chinh_Tri);

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
        public void Cap_Nhat_Them(int? Ma_Nhan_Vien_Chinh_Tri = null, int? Ma_Nhan_Vien = null, int? Ma_Chinh_Tri = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Chinh_Tri_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien_Chinh_Tri = new SqlParameter("@Ma_Nhan_Vien_Chinh_Tri", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Chinh_Tri.Value = Ma_Nhan_Vien_Chinh_Tri;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Chinh_Tri);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pMa_Chinh_Tri = new SqlParameter("@Ma_Chinh_Tri", SqlDbType.Int, 4);
                    pMa_Chinh_Tri.Value = Ma_Chinh_Tri;
                    myCommand.Parameters.Add(pMa_Chinh_Tri);

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
        public void Xoa(int Ma_Nhan_Vien_Chinh_Tri)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Chinh_Tri_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien_Chinh_Tri = new SqlParameter("@Ma_Nhan_Vien_Chinh_Tri", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Chinh_Tri.Value = Ma_Nhan_Vien_Chinh_Tri;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Chinh_Tri);

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
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Chinh_Tri_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Nhan_Vien_Chinh_Tri_Danh_Sach");
                    return myDataSet.Tables["NL_Nhan_Vien_Chinh_Tri_Danh_Sach"];
                }
            }
        }
        #endregion

        #region Lay_Boi_NL_DM_Chinh_Tri
        public DataTable Lay_Boi_NL_DM_Chinh_Tri(int Ma_Chinh_Tri)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Chinh_Tri_Lay_Boi_NL_DM_Chinh_Tri", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Chinh_Tri = new SqlParameter("@Ma_Chinh_Tri", SqlDbType.Int, 4);
                    pMa_Chinh_Tri.Value = Ma_Chinh_Tri;
                    myCommand.Parameters.Add(pMa_Chinh_Tri);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Nhan_Vien_Chinh_Tri_Lay_Boi_NL_DM_Chinh_Tri");
                    return myDataSet.Tables["NL_Nhan_Vien_Chinh_Tri_Lay_Boi_NL_DM_Chinh_Tri"];
                }
            }
        }
        #endregion
        #region Lay_Boi_NL_Nhan_Vien
        public DataTable Lay_Boi_NL_Nhan_Vien(int Ma_Nhan_Vien)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Chinh_Tri_Lay_Boi_NL_Nhan_Vien", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Nhan_Vien_Chinh_Tri_Lay_Boi_NL_Nhan_Vien");
                    return myDataSet.Tables["NL_Nhan_Vien_Chinh_Tri_Lay_Boi_NL_Nhan_Vien"];
                }
            }
        }
        #endregion

    }
    #endregion
}