
using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region HT_DM_Tinh_Details
    public class HT_DM_Tinh_Chi_Tiet
    {
        public string Ma_Tinh; // Mã tỉnh
        public string Ten_Tinh; // Tên tỉnh
        public int STT; // STT
    }
    #endregion
    #region HT_DM_Tinh
    public class HT_DM_Tinh
    {
        private string ConnectionString;
        public HT_DM_Tinh(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public HT_DM_Tinh_Chi_Tiet Lay(string Ma_Tinh)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_DM_Tinh_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pMa_Tinh.Value = Ma_Tinh;
                    myCommand.Parameters.Add(pMa_Tinh);

                    SqlParameter pTen_Tinh = new SqlParameter("@Ten_Tinh", SqlDbType.NVarChar, 100);
                    pTen_Tinh.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pTen_Tinh);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pSTT);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();


                    HT_DM_Tinh_Chi_Tiet myHT_DM_Tinh_Chi_Tiet = new HT_DM_Tinh_Chi_Tiet();
                    myHT_DM_Tinh_Chi_Tiet.Ma_Tinh = Ma_Tinh;
                    myHT_DM_Tinh_Chi_Tiet.Ten_Tinh = (string)pTen_Tinh.Value;
                    myHT_DM_Tinh_Chi_Tiet.STT = (int)pSTT.Value;
                    return myHT_DM_Tinh_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public string Them(string Ma_Tinh, string Ten_Tinh, int STT)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_DM_Tinh_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pMa_Tinh.Value = Ma_Tinh;
                    myCommand.Parameters.Add(pMa_Tinh);

                    SqlParameter pTen_Tinh = new SqlParameter("@Ten_Tinh", SqlDbType.NVarChar, 100);
                    pTen_Tinh.Value = Ten_Tinh;
                    myCommand.Parameters.Add(pTen_Tinh);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Value = STT;
                    myCommand.Parameters.Add(pSTT);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    return (string)pMa_Tinh.Value;
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(string Ma_Tinh, string Ten_Tinh, int STT)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_DM_Tinh_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pMa_Tinh.Value = Ma_Tinh;
                    myCommand.Parameters.Add(pMa_Tinh);

                    SqlParameter pTen_Tinh = new SqlParameter("@Ten_Tinh", SqlDbType.NVarChar, 100);
                    pTen_Tinh.Value = Ten_Tinh;
                    myCommand.Parameters.Add(pTen_Tinh);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Value = STT;
                    myCommand.Parameters.Add(pSTT);



                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(HT_DM_Tinh_Chi_Tiet myHT_DM_Tinh_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_DM_Tinh_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pMa_Tinh.Value = myHT_DM_Tinh_Chi_Tiet.Ma_Tinh;
                    myCommand.Parameters.Add(pMa_Tinh);

                    SqlParameter pTen_Tinh = new SqlParameter("@Ten_Tinh", SqlDbType.NVarChar, 100);
                    pTen_Tinh.Value = myHT_DM_Tinh_Chi_Tiet.Ten_Tinh;
                    myCommand.Parameters.Add(pTen_Tinh);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Value = myHT_DM_Tinh_Chi_Tiet.STT;
                    myCommand.Parameters.Add(pSTT);


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
                using (SqlCommand myCommand = new SqlCommand("HT_DM_Tinh_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                        pMa_Tinh.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ma_Tinh"];
                        myCommand.Parameters.Add(pMa_Tinh);

                        SqlParameter pTen_Tinh = new SqlParameter("@Ten_Tinh", SqlDbType.NVarChar, 100);
                        pTen_Tinh.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ten_Tinh"];
                        myCommand.Parameters.Add(pTen_Tinh);

                        SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                        pSTT.Value = (int)myDataSet.Tables[strTableName].Rows[i]["STT"];
                        myCommand.Parameters.Add(pSTT);


                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(string Ma_Tinh, string Ten_Tinh, int STT)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_DM_Tinh_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pMa_Tinh.Value = Ma_Tinh;
                    myCommand.Parameters.Add(pMa_Tinh);

                    SqlParameter pTen_Tinh = new SqlParameter("@Ten_Tinh", SqlDbType.NVarChar, 100);
                    pTen_Tinh.Value = Ten_Tinh;
                    myCommand.Parameters.Add(pTen_Tinh);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Value = STT;
                    myCommand.Parameters.Add(pSTT);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(string Ma_Tinh)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_DM_Tinh_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pMa_Tinh.Value = Ma_Tinh;
                    myCommand.Parameters.Add(pMa_Tinh);

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
                using (SqlCommand myCommand = new SqlCommand("HT_DM_Tinh_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_DM_Tinh_Danh_Sach");
                    return myDataSet.Tables["HT_DM_Tinh_Danh_Sach"];
                }
            }
        }
        #endregion


    }
    #endregion
}