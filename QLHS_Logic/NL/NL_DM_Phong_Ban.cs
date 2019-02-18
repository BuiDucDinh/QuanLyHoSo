using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region NL_DM_Phong_Ban_Details
    public class NL_DM_Phong_Ban_Chi_Tiet
    {
        public int? Ma_Phong = null; // Mã phòng
        public string Ten_Phong = null; // Tên phòng
        public int? Ma_Don_Vi = null; // Mã đơn vị
        public int? So_Nguoi = null; // Se do he thong tu dong cap nhat khi co su thay doi nhan vien trong Table NL_Nhan_Vien
    }
    #endregion
    #region NL_DM_Phong_Ban
    public class NL_DM_Phong_Ban
    {
        private string ConnectionString;
        public NL_DM_Phong_Ban(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_DM_Phong_Ban_Chi_Tiet Lay(int Ma_Phong)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Phong_Ban_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Phong = new SqlParameter("@Ma_Phong", SqlDbType.Int, 4);
                    pMa_Phong.Value = Ma_Phong;
                    myCommand.Parameters.Add(pMa_Phong);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Phong_Ban_Chi_Tiet");
                    NL_DM_Phong_Ban_Chi_Tiet myNL_DM_Phong_Ban_Chi_Tiet = new NL_DM_Phong_Ban_Chi_Tiet();
                    if (myDataSet.Tables["NL_DM_Phong_Ban_Chi_Tiet"] != null)
                    {
                        myNL_DM_Phong_Ban_Chi_Tiet.Ma_Phong = Ma_Phong;
                        myNL_DM_Phong_Ban_Chi_Tiet.Ten_Phong = myDataSet.Tables["NL_DM_Phong_Ban_Chi_Tiet"].Rows[0]["Ten_Phong"] != DBNull.Value ? (string)myDataSet.Tables["NL_DM_Phong_Ban_Chi_Tiet"].Rows[0]["Ten_Phong"] : (string)null;
                        myNL_DM_Phong_Ban_Chi_Tiet.Ma_Don_Vi = myDataSet.Tables["NL_DM_Phong_Ban_Chi_Tiet"].Rows[0]["Ma_Don_Vi"] != DBNull.Value ? (int?)myDataSet.Tables["NL_DM_Phong_Ban_Chi_Tiet"].Rows[0]["Ma_Don_Vi"] : (int?)null;
                        myNL_DM_Phong_Ban_Chi_Tiet.So_Nguoi = myDataSet.Tables["NL_DM_Phong_Ban_Chi_Tiet"].Rows[0]["So_Nguoi"] != DBNull.Value ? (int?)myDataSet.Tables["NL_DM_Phong_Ban_Chi_Tiet"].Rows[0]["So_Nguoi"] : (int?)null;
                    }
                    return myNL_DM_Phong_Ban_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Ma_Phong = null, string Ten_Phong = null, int? Ma_Don_Vi = null, int? So_Nguoi = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Phong_Ban_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Phong = new SqlParameter("@Ma_Phong", SqlDbType.Int, 4);
                    pMa_Phong.Value = Ma_Phong;
                    myCommand.Parameters.Add(pMa_Phong);

                    SqlParameter pTen_Phong = new SqlParameter("@Ten_Phong", SqlDbType.NVarChar, 500);
                    pTen_Phong.Value = Ten_Phong;
                    myCommand.Parameters.Add(pTen_Phong);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pSo_Nguoi = new SqlParameter("@So_Nguoi", SqlDbType.Int, 4);
                    pSo_Nguoi.Value = So_Nguoi;
                    myCommand.Parameters.Add(pSo_Nguoi);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int? Ma_Phong = null, string Ten_Phong = null, int? Ma_Don_Vi = null, int? So_Nguoi = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Phong_Ban_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Phong = new SqlParameter("@Ma_Phong", SqlDbType.Int, 4);
                    pMa_Phong.Value = Ma_Phong;
                    myCommand.Parameters.Add(pMa_Phong);

                    SqlParameter pTen_Phong = new SqlParameter("@Ten_Phong", SqlDbType.NVarChar, 500);
                    pTen_Phong.Value = Ten_Phong;
                    myCommand.Parameters.Add(pTen_Phong);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pSo_Nguoi = new SqlParameter("@So_Nguoi", SqlDbType.Int, 4);
                    pSo_Nguoi.Value = So_Nguoi;
                    myCommand.Parameters.Add(pSo_Nguoi);



                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(NL_DM_Phong_Ban_Chi_Tiet myNL_DM_Phong_Ban_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Phong_Ban_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Phong = new SqlParameter("@Ma_Phong", SqlDbType.Int, 4);
                    pMa_Phong.Value = myNL_DM_Phong_Ban_Chi_Tiet.Ma_Phong;
                    myCommand.Parameters.Add(pMa_Phong);

                    SqlParameter pTen_Phong = new SqlParameter("@Ten_Phong", SqlDbType.NVarChar, 500);
                    pTen_Phong.Value = myNL_DM_Phong_Ban_Chi_Tiet.Ten_Phong;
                    myCommand.Parameters.Add(pTen_Phong);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = myNL_DM_Phong_Ban_Chi_Tiet.Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pSo_Nguoi = new SqlParameter("@So_Nguoi", SqlDbType.Int, 4);
                    pSo_Nguoi.Value = myNL_DM_Phong_Ban_Chi_Tiet.So_Nguoi;
                    myCommand.Parameters.Add(pSo_Nguoi);


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
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Phong_Ban_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Phong = new SqlParameter("@Ma_Phong", SqlDbType.Int, 4);
                        pMa_Phong.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Phong"];
                        myCommand.Parameters.Add(pMa_Phong);

                        SqlParameter pTen_Phong = new SqlParameter("@Ten_Phong", SqlDbType.NVarChar, 500);
                        pTen_Phong.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ten_Phong"];
                        myCommand.Parameters.Add(pTen_Phong);

                        SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                        pMa_Don_Vi.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Don_Vi"];
                        myCommand.Parameters.Add(pMa_Don_Vi);

                        SqlParameter pSo_Nguoi = new SqlParameter("@So_Nguoi", SqlDbType.Int, 4);
                        pSo_Nguoi.Value = (int)myDataSet.Tables[strTableName].Rows[i]["So_Nguoi"];
                        myCommand.Parameters.Add(pSo_Nguoi);


                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int? Ma_Phong = null, string Ten_Phong = null, int? Ma_Don_Vi = null, int? So_Nguoi = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Phong_Ban_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Phong = new SqlParameter("@Ma_Phong", SqlDbType.Int, 4);
                    pMa_Phong.Value = Ma_Phong;
                    myCommand.Parameters.Add(pMa_Phong);

                    SqlParameter pTen_Phong = new SqlParameter("@Ten_Phong", SqlDbType.NVarChar, 500);
                    pTen_Phong.Value = Ten_Phong;
                    myCommand.Parameters.Add(pTen_Phong);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pSo_Nguoi = new SqlParameter("@So_Nguoi", SqlDbType.Int, 4);
                    pSo_Nguoi.Value = So_Nguoi;
                    myCommand.Parameters.Add(pSo_Nguoi);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Ma_Phong)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Phong_Ban_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Phong = new SqlParameter("@Ma_Phong", SqlDbType.Int, 4);
                    pMa_Phong.Value = Ma_Phong;
                    myCommand.Parameters.Add(pMa_Phong);

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
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Phong_Ban_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Phong_Ban_Danh_Sach");
                    return myDataSet.Tables["NL_DM_Phong_Ban_Danh_Sach"];
                }
            }
        }
        #endregion

        #region Lay_Boi_HT_Don_Vi_YT
        public DataTable Lay_Boi_HT_Don_Vi_YT(int Ma_Don_Vi)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Phong_Ban_Lay_Boi_HT_Don_Vi_YT", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Phong_Ban_Lay_Boi_HT_Don_Vi_YT");
                    return myDataSet.Tables["NL_DM_Phong_Ban_Lay_Boi_HT_Don_Vi_YT"];
                }
            }
        }
        #endregion

    }
    #endregion
}