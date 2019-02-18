using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region NL_DM_Hinh_Thuc_KhenThuong_Details
    public class NL_DM_Hinh_Thuc_KhenThuong_Chi_Tiet
    {
        public int? Ma_Hinh_Thuc = null;
        public string Ten_Hinh_Thuc = null;
        public int? Loai_Hinh_Thuc = null; // 1: Khen thưởng; 2: Kỷ luật
    }
    #endregion
    #region NL_DM_Hinh_Thuc_KhenThuong
    public class NL_DM_Hinh_Thuc_KhenThuong
    {
        private string ConnectionString;
        public NL_DM_Hinh_Thuc_KhenThuong(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_DM_Hinh_Thuc_KhenThuong_Chi_Tiet Lay(int Ma_Hinh_Thuc)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Hinh_Thuc_KhenThuong_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Hinh_Thuc = new SqlParameter("@Ma_Hinh_Thuc", SqlDbType.Int, 4);
                    pMa_Hinh_Thuc.Value = Ma_Hinh_Thuc;
                    myCommand.Parameters.Add(pMa_Hinh_Thuc);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Hinh_Thuc_KhenThuong_Chi_Tiet");
                    NL_DM_Hinh_Thuc_KhenThuong_Chi_Tiet myNL_DM_Hinh_Thuc_KhenThuong_Chi_Tiet = new NL_DM_Hinh_Thuc_KhenThuong_Chi_Tiet();
                    if (myDataSet.Tables["NL_DM_Hinh_Thuc_KhenThuong_Chi_Tiet"] != null)
                    {
                        myNL_DM_Hinh_Thuc_KhenThuong_Chi_Tiet.Ma_Hinh_Thuc = Ma_Hinh_Thuc;
                        myNL_DM_Hinh_Thuc_KhenThuong_Chi_Tiet.Ten_Hinh_Thuc = myDataSet.Tables["NL_DM_Hinh_Thuc_KhenThuong_Chi_Tiet"].Rows[0]["Ten_Hinh_Thuc"] != DBNull.Value ? (string)myDataSet.Tables["NL_DM_Hinh_Thuc_KhenThuong_Chi_Tiet"].Rows[0]["Ten_Hinh_Thuc"] : (string)null;
                        myNL_DM_Hinh_Thuc_KhenThuong_Chi_Tiet.Loai_Hinh_Thuc = myDataSet.Tables["NL_DM_Hinh_Thuc_KhenThuong_Chi_Tiet"].Rows[0]["Loai_Hinh_Thuc"] != DBNull.Value ? (int?)myDataSet.Tables["NL_DM_Hinh_Thuc_KhenThuong_Chi_Tiet"].Rows[0]["Loai_Hinh_Thuc"] : (int?)null;
                    }
                    return myNL_DM_Hinh_Thuc_KhenThuong_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Ma_Hinh_Thuc = null, string Ten_Hinh_Thuc = null, int? Loai_Hinh_Thuc = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Hinh_Thuc_KhenThuong_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Hinh_Thuc = new SqlParameter("@Ma_Hinh_Thuc", SqlDbType.Int, 4);
                    pMa_Hinh_Thuc.Value = Ma_Hinh_Thuc;
                    myCommand.Parameters.Add(pMa_Hinh_Thuc);

                    SqlParameter pTen_Hinh_Thuc = new SqlParameter("@Ten_Hinh_Thuc", SqlDbType.NVarChar, 350);
                    pTen_Hinh_Thuc.Value = Ten_Hinh_Thuc;
                    myCommand.Parameters.Add(pTen_Hinh_Thuc);

                    SqlParameter pLoai_Hinh_Thuc = new SqlParameter("@Loai_Hinh_Thuc", SqlDbType.Int, 4);
                    pLoai_Hinh_Thuc.Value = Loai_Hinh_Thuc;
                    myCommand.Parameters.Add(pLoai_Hinh_Thuc);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int? Ma_Hinh_Thuc = null, string Ten_Hinh_Thuc = null, int? Loai_Hinh_Thuc = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Hinh_Thuc_KhenThuong_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Hinh_Thuc = new SqlParameter("@Ma_Hinh_Thuc", SqlDbType.Int, 4);
                    pMa_Hinh_Thuc.Value = Ma_Hinh_Thuc;
                    myCommand.Parameters.Add(pMa_Hinh_Thuc);

                    SqlParameter pTen_Hinh_Thuc = new SqlParameter("@Ten_Hinh_Thuc", SqlDbType.NVarChar, 350);
                    pTen_Hinh_Thuc.Value = Ten_Hinh_Thuc;
                    myCommand.Parameters.Add(pTen_Hinh_Thuc);

                    SqlParameter pLoai_Hinh_Thuc = new SqlParameter("@Loai_Hinh_Thuc", SqlDbType.Int, 4);
                    pLoai_Hinh_Thuc.Value = Loai_Hinh_Thuc;
                    myCommand.Parameters.Add(pLoai_Hinh_Thuc);



                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(NL_DM_Hinh_Thuc_KhenThuong_Chi_Tiet myNL_DM_Hinh_Thuc_KhenThuong_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Hinh_Thuc_KhenThuong_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Hinh_Thuc = new SqlParameter("@Ma_Hinh_Thuc", SqlDbType.Int, 4);
                    pMa_Hinh_Thuc.Value = myNL_DM_Hinh_Thuc_KhenThuong_Chi_Tiet.Ma_Hinh_Thuc;
                    myCommand.Parameters.Add(pMa_Hinh_Thuc);

                    SqlParameter pTen_Hinh_Thuc = new SqlParameter("@Ten_Hinh_Thuc", SqlDbType.NVarChar, 350);
                    pTen_Hinh_Thuc.Value = myNL_DM_Hinh_Thuc_KhenThuong_Chi_Tiet.Ten_Hinh_Thuc;
                    myCommand.Parameters.Add(pTen_Hinh_Thuc);

                    SqlParameter pLoai_Hinh_Thuc = new SqlParameter("@Loai_Hinh_Thuc", SqlDbType.Int, 4);
                    pLoai_Hinh_Thuc.Value = myNL_DM_Hinh_Thuc_KhenThuong_Chi_Tiet.Loai_Hinh_Thuc;
                    myCommand.Parameters.Add(pLoai_Hinh_Thuc);


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
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Hinh_Thuc_KhenThuong_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Hinh_Thuc = new SqlParameter("@Ma_Hinh_Thuc", SqlDbType.Int, 4);
                        pMa_Hinh_Thuc.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Hinh_Thuc"];
                        myCommand.Parameters.Add(pMa_Hinh_Thuc);

                        SqlParameter pTen_Hinh_Thuc = new SqlParameter("@Ten_Hinh_Thuc", SqlDbType.NVarChar, 350);
                        pTen_Hinh_Thuc.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ten_Hinh_Thuc"];
                        myCommand.Parameters.Add(pTen_Hinh_Thuc);

                        SqlParameter pLoai_Hinh_Thuc = new SqlParameter("@Loai_Hinh_Thuc", SqlDbType.Int, 4);
                        pLoai_Hinh_Thuc.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Loai_Hinh_Thuc"];
                        myCommand.Parameters.Add(pLoai_Hinh_Thuc);


                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int? Ma_Hinh_Thuc = null, string Ten_Hinh_Thuc = null, int? Loai_Hinh_Thuc = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Hinh_Thuc_KhenThuong_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Hinh_Thuc = new SqlParameter("@Ma_Hinh_Thuc", SqlDbType.Int, 4);
                    pMa_Hinh_Thuc.Value = Ma_Hinh_Thuc;
                    myCommand.Parameters.Add(pMa_Hinh_Thuc);

                    SqlParameter pTen_Hinh_Thuc = new SqlParameter("@Ten_Hinh_Thuc", SqlDbType.NVarChar, 350);
                    pTen_Hinh_Thuc.Value = Ten_Hinh_Thuc;
                    myCommand.Parameters.Add(pTen_Hinh_Thuc);

                    SqlParameter pLoai_Hinh_Thuc = new SqlParameter("@Loai_Hinh_Thuc", SqlDbType.Int, 4);
                    pLoai_Hinh_Thuc.Value = Loai_Hinh_Thuc;
                    myCommand.Parameters.Add(pLoai_Hinh_Thuc);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Ma_Hinh_Thuc)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Hinh_Thuc_KhenThuong_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Hinh_Thuc = new SqlParameter("@Ma_Hinh_Thuc", SqlDbType.Int, 4);
                    pMa_Hinh_Thuc.Value = Ma_Hinh_Thuc;
                    myCommand.Parameters.Add(pMa_Hinh_Thuc);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Danh_Sach_By_Trang_Thai
        public DataTable Danh_Sach_By_TrangThai(int Trang_Thai)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Hinh_Thuc_KhenThuong_Danh_Sach_By_TT", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();

                    SqlParameter pTrang_Thai = new SqlParameter("@Trang_Thai", SqlDbType.Int, 4);
                    pTrang_Thai.Value = Trang_Thai;
                    myCommand.Parameters.Add(pTrang_Thai);


                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Hinh_Thuc_KhenThuong_Danh_Sach_By_TT");
                    return myDataSet.Tables["NL_DM_Hinh_Thuc_KhenThuong_Danh_Sach_By_TT"];
                }
            }
        }
        #endregion

        #region Danh_Sach
        public DataTable Danh_Sach()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Hinh_Thuc_KhenThuong_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Hinh_Thuc_KhenThuong_Danh_Sach");
                    return myDataSet.Tables["NL_DM_Hinh_Thuc_KhenThuong_Danh_Sach"];
                }
            }
        }
        #endregion

    }
    #endregion
}