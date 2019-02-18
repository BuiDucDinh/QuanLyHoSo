
using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region HT_Ma_Nuoc_Details
    public class HT_Ma_Nuoc_Chi_Tiet
    {
        public string Ma_Nuoc;
        public string Ten_Nuoc;
        public int STT;
    }
    #endregion
    #region HT_Ma_Nuoc
    public class HT_Ma_Nuoc
    {
        private string ConnectionString;
        public HT_Ma_Nuoc(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public HT_Ma_Nuoc_Chi_Tiet Lay(string Ma_Nuoc)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Ma_Nuoc_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nuoc = new SqlParameter("@Ma_Nuoc", SqlDbType.VarChar, 3);
                    pMa_Nuoc.Value = Ma_Nuoc;
                    myCommand.Parameters.Add(pMa_Nuoc);

                    SqlParameter pTen_Nuoc = new SqlParameter("@Ten_Nuoc", SqlDbType.NVarChar, 150);
                    pTen_Nuoc.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pTen_Nuoc);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pSTT);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();


                    HT_Ma_Nuoc_Chi_Tiet myHT_Ma_Nuoc_Chi_Tiet = new HT_Ma_Nuoc_Chi_Tiet();
                    myHT_Ma_Nuoc_Chi_Tiet.Ma_Nuoc = Ma_Nuoc;
                    myHT_Ma_Nuoc_Chi_Tiet.Ten_Nuoc = (string)pTen_Nuoc.Value;
                    myHT_Ma_Nuoc_Chi_Tiet.STT = (int)pSTT.Value;
                    return myHT_Ma_Nuoc_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public string Them(string Ma_Nuoc, string Ten_Nuoc, int STT)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Ma_Nuoc_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nuoc = new SqlParameter("@Ma_Nuoc", SqlDbType.VarChar, 3);
                    pMa_Nuoc.Value = Ma_Nuoc;
                    myCommand.Parameters.Add(pMa_Nuoc);

                    SqlParameter pTen_Nuoc = new SqlParameter("@Ten_Nuoc", SqlDbType.NVarChar, 150);
                    pTen_Nuoc.Value = Ten_Nuoc;
                    myCommand.Parameters.Add(pTen_Nuoc);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Value = STT;
                    myCommand.Parameters.Add(pSTT);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    return (string)pMa_Nuoc.Value;
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(string Ma_Nuoc, string Ten_Nuoc, int STT)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Ma_Nuoc_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Nuoc = new SqlParameter("@Ma_Nuoc", SqlDbType.VarChar, 3);
                    pMa_Nuoc.Value = Ma_Nuoc;
                    myCommand.Parameters.Add(pMa_Nuoc);

                    SqlParameter pTen_Nuoc = new SqlParameter("@Ten_Nuoc", SqlDbType.NVarChar, 150);
                    pTen_Nuoc.Value = Ten_Nuoc;
                    myCommand.Parameters.Add(pTen_Nuoc);

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
        public void Cap_Nhat(HT_Ma_Nuoc_Chi_Tiet myHT_Ma_Nuoc_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Ma_Nuoc_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nuoc = new SqlParameter("@Ma_Nuoc", SqlDbType.VarChar, 3);
                    pMa_Nuoc.Value = myHT_Ma_Nuoc_Chi_Tiet.Ma_Nuoc;
                    myCommand.Parameters.Add(pMa_Nuoc);

                    SqlParameter pTen_Nuoc = new SqlParameter("@Ten_Nuoc", SqlDbType.NVarChar, 150);
                    pTen_Nuoc.Value = myHT_Ma_Nuoc_Chi_Tiet.Ten_Nuoc;
                    myCommand.Parameters.Add(pTen_Nuoc);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Value = myHT_Ma_Nuoc_Chi_Tiet.STT;
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
                using (SqlCommand myCommand = new SqlCommand("HT_Ma_Nuoc_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Nuoc = new SqlParameter("@Ma_Nuoc", SqlDbType.VarChar, 3);
                        pMa_Nuoc.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ma_Nuoc"];
                        myCommand.Parameters.Add(pMa_Nuoc);

                        SqlParameter pTen_Nuoc = new SqlParameter("@Ten_Nuoc", SqlDbType.NVarChar, 150);
                        pTen_Nuoc.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ten_Nuoc"];
                        myCommand.Parameters.Add(pTen_Nuoc);

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
        public void Cap_Nhat_Them(string Ma_Nuoc, string Ten_Nuoc, int STT)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Ma_Nuoc_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nuoc = new SqlParameter("@Ma_Nuoc", SqlDbType.VarChar, 3);
                    pMa_Nuoc.Value = Ma_Nuoc;
                    myCommand.Parameters.Add(pMa_Nuoc);

                    SqlParameter pTen_Nuoc = new SqlParameter("@Ten_Nuoc", SqlDbType.NVarChar, 150);
                    pTen_Nuoc.Value = Ten_Nuoc;
                    myCommand.Parameters.Add(pTen_Nuoc);

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
        public void Xoa(string Ma_Nuoc)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Ma_Nuoc_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nuoc = new SqlParameter("@Ma_Nuoc", SqlDbType.VarChar, 3);
                    pMa_Nuoc.Value = Ma_Nuoc;
                    myCommand.Parameters.Add(pMa_Nuoc);

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
                using (SqlCommand myCommand = new SqlCommand("HT_Ma_Nuoc_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Ma_Nuoc_Danh_Sach");
                    return myDataSet.Tables["HT_Ma_Nuoc_Danh_Sach"];
                }
            }
        }
        #endregion


    }
    #endregion
}