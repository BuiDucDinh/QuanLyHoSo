
using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{ 
    #region HT_DM_Huyen_Details
    public class HT_DM_Huyen_Chi_Tiet
    {
        public string Ma_Huyen; // Mã huyện
        public string Ma_Tinh; // Mã tỉnh
        public string Ten_Huyen; // Tên huyện
        public int STT; // STT
    }
    #endregion
    #region HT_DM_Huyen
    public class HT_DM_Huyen
    {
        private string ConnectionString;
        public HT_DM_Huyen(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public HT_DM_Huyen_Chi_Tiet Lay(string Ma_Huyen)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_DM_Huyen_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pMa_Huyen.Value = Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pMa_Tinh.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pMa_Tinh);

                    SqlParameter pTen_Huyen = new SqlParameter("@Ten_Huyen", SqlDbType.NVarChar, 200);
                    pTen_Huyen.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pTen_Huyen);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pSTT);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();


                    HT_DM_Huyen_Chi_Tiet myHT_DM_Huyen_Chi_Tiet = new HT_DM_Huyen_Chi_Tiet();
                    myHT_DM_Huyen_Chi_Tiet.Ma_Huyen = Ma_Huyen;
                    myHT_DM_Huyen_Chi_Tiet.Ma_Tinh = (string)pMa_Tinh.Value;
                    myHT_DM_Huyen_Chi_Tiet.Ten_Huyen = (string)pTen_Huyen.Value;
                    myHT_DM_Huyen_Chi_Tiet.STT = (int)pSTT.Value;
                    return myHT_DM_Huyen_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public string Them(string Ma_Huyen, string Ma_Tinh, string Ten_Huyen, int STT)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_DM_Huyen_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pMa_Huyen.Value = Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pMa_Tinh.Value = Ma_Tinh;
                    myCommand.Parameters.Add(pMa_Tinh);

                    SqlParameter pTen_Huyen = new SqlParameter("@Ten_Huyen", SqlDbType.NVarChar, 200);
                    pTen_Huyen.Value = Ten_Huyen;
                    myCommand.Parameters.Add(pTen_Huyen);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Value = STT;
                    myCommand.Parameters.Add(pSTT);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    return (string)pMa_Huyen.Value;
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(string Ma_Huyen, string Ma_Tinh, string Ten_Huyen, int STT)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_DM_Huyen_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pMa_Huyen.Value = Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pMa_Tinh.Value = Ma_Tinh;
                    myCommand.Parameters.Add(pMa_Tinh);

                    SqlParameter pTen_Huyen = new SqlParameter("@Ten_Huyen", SqlDbType.NVarChar, 200);
                    pTen_Huyen.Value = Ten_Huyen;
                    myCommand.Parameters.Add(pTen_Huyen);

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
        public void Cap_Nhat(HT_DM_Huyen_Chi_Tiet myHT_DM_Huyen_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_DM_Huyen_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pMa_Huyen.Value = myHT_DM_Huyen_Chi_Tiet.Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pMa_Tinh.Value = myHT_DM_Huyen_Chi_Tiet.Ma_Tinh;
                    myCommand.Parameters.Add(pMa_Tinh);

                    SqlParameter pTen_Huyen = new SqlParameter("@Ten_Huyen", SqlDbType.NVarChar, 200);
                    pTen_Huyen.Value = myHT_DM_Huyen_Chi_Tiet.Ten_Huyen;
                    myCommand.Parameters.Add(pTen_Huyen);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Value = myHT_DM_Huyen_Chi_Tiet.STT;
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
                using (SqlCommand myCommand = new SqlCommand("HT_DM_Huyen_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                        pMa_Huyen.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ma_Huyen"];
                        myCommand.Parameters.Add(pMa_Huyen);

                        SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                        pMa_Tinh.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ma_Tinh"];
                        myCommand.Parameters.Add(pMa_Tinh);

                        SqlParameter pTen_Huyen = new SqlParameter("@Ten_Huyen", SqlDbType.NVarChar, 200);
                        pTen_Huyen.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ten_Huyen"];
                        myCommand.Parameters.Add(pTen_Huyen);

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
        public void Cap_Nhat_Them(string Ma_Huyen, string Ma_Tinh, string Ten_Huyen, int STT)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_DM_Huyen_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pMa_Huyen.Value = Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pMa_Tinh.Value = Ma_Tinh;
                    myCommand.Parameters.Add(pMa_Tinh);

                    SqlParameter pTen_Huyen = new SqlParameter("@Ten_Huyen", SqlDbType.NVarChar, 200);
                    pTen_Huyen.Value = Ten_Huyen;
                    myCommand.Parameters.Add(pTen_Huyen);

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
        public void Xoa(string Ma_Huyen)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_DM_Huyen_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pMa_Huyen.Value = Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

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
                using (SqlCommand myCommand = new SqlCommand("HT_DM_Huyen_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_DM_Huyen_Danh_Sach");
                    return myDataSet.Tables["HT_DM_Huyen_Danh_Sach"];
                }
            }
        }
        #endregion

        #region Lay_Boi_HT_DM_Tinh
        public DataTable Lay_Boi_HT_DM_Tinh(string Ma_Tinh)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_DM_Huyen_Lay_Boi_HT_DM_Tinh", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pMa_Tinh.Value = Ma_Tinh;
                    myCommand.Parameters.Add(pMa_Tinh);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_DM_Huyen_Lay_Boi_HT_DM_Tinh");
                    return myDataSet.Tables["HT_DM_Huyen_Lay_Boi_HT_DM_Tinh"];
                }
            }
        }
        #endregion

    }
    #endregion
}