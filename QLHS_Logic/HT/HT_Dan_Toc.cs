
using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region HT_Dan_Toc_Details
    public class HT_Dan_Toc_Chi_Tiet
    {
        public string Ma_Dan_Toc;
        public string Ten_Dan_Toc;
        public int STT;
    }
    #endregion
    #region HT_Dan_Toc
    public class HT_Dan_Toc
    {
        private string ConnectionString;
        public HT_Dan_Toc(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public HT_Dan_Toc_Chi_Tiet Lay(string Ma_Dan_Toc)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Dan_Toc_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Dan_Toc = new SqlParameter("@Ma_Dan_Toc", SqlDbType.VarChar, 5);
                    pMa_Dan_Toc.Value = Ma_Dan_Toc;
                    myCommand.Parameters.Add(pMa_Dan_Toc);

                    SqlParameter pTen_Dan_Toc = new SqlParameter("@Ten_Dan_Toc", SqlDbType.NVarChar, 100);
                    pTen_Dan_Toc.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pTen_Dan_Toc);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pSTT);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();


                    HT_Dan_Toc_Chi_Tiet myHT_Dan_Toc_Chi_Tiet = new HT_Dan_Toc_Chi_Tiet();
                    myHT_Dan_Toc_Chi_Tiet.Ma_Dan_Toc = Ma_Dan_Toc;
                    myHT_Dan_Toc_Chi_Tiet.Ten_Dan_Toc = (string)pTen_Dan_Toc.Value;
                    myHT_Dan_Toc_Chi_Tiet.STT = (int)pSTT.Value;
                    return myHT_Dan_Toc_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public string Them(string Ma_Dan_Toc, string Ten_Dan_Toc, int STT)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Dan_Toc_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Dan_Toc = new SqlParameter("@Ma_Dan_Toc", SqlDbType.VarChar, 5);
                    pMa_Dan_Toc.Value = Ma_Dan_Toc;
                    myCommand.Parameters.Add(pMa_Dan_Toc);

                    SqlParameter pTen_Dan_Toc = new SqlParameter("@Ten_Dan_Toc", SqlDbType.NVarChar, 100);
                    pTen_Dan_Toc.Value = Ten_Dan_Toc;
                    myCommand.Parameters.Add(pTen_Dan_Toc);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Value = STT;
                    myCommand.Parameters.Add(pSTT);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    return (string)pMa_Dan_Toc.Value;
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(string Ma_Dan_Toc, string Ten_Dan_Toc, int STT)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Dan_Toc_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Dan_Toc = new SqlParameter("@Ma_Dan_Toc", SqlDbType.VarChar, 5);
                    pMa_Dan_Toc.Value = Ma_Dan_Toc;
                    myCommand.Parameters.Add(pMa_Dan_Toc);

                    SqlParameter pTen_Dan_Toc = new SqlParameter("@Ten_Dan_Toc", SqlDbType.NVarChar, 100);
                    pTen_Dan_Toc.Value = Ten_Dan_Toc;
                    myCommand.Parameters.Add(pTen_Dan_Toc);

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
        public void Cap_Nhat(HT_Dan_Toc_Chi_Tiet myHT_Dan_Toc_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Dan_Toc_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Dan_Toc = new SqlParameter("@Ma_Dan_Toc", SqlDbType.VarChar, 5);
                    pMa_Dan_Toc.Value = myHT_Dan_Toc_Chi_Tiet.Ma_Dan_Toc;
                    myCommand.Parameters.Add(pMa_Dan_Toc);

                    SqlParameter pTen_Dan_Toc = new SqlParameter("@Ten_Dan_Toc", SqlDbType.NVarChar, 100);
                    pTen_Dan_Toc.Value = myHT_Dan_Toc_Chi_Tiet.Ten_Dan_Toc;
                    myCommand.Parameters.Add(pTen_Dan_Toc);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Value = myHT_Dan_Toc_Chi_Tiet.STT;
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
                using (SqlCommand myCommand = new SqlCommand("HT_Dan_Toc_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Dan_Toc = new SqlParameter("@Ma_Dan_Toc", SqlDbType.VarChar, 5);
                        pMa_Dan_Toc.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ma_Dan_Toc"];
                        myCommand.Parameters.Add(pMa_Dan_Toc);

                        SqlParameter pTen_Dan_Toc = new SqlParameter("@Ten_Dan_Toc", SqlDbType.NVarChar, 100);
                        pTen_Dan_Toc.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ten_Dan_Toc"];
                        myCommand.Parameters.Add(pTen_Dan_Toc);

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
        public void Cap_Nhat_Them(string Ma_Dan_Toc, string Ten_Dan_Toc, int STT)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Dan_Toc_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Dan_Toc = new SqlParameter("@Ma_Dan_Toc", SqlDbType.VarChar, 5);
                    pMa_Dan_Toc.Value = Ma_Dan_Toc;
                    myCommand.Parameters.Add(pMa_Dan_Toc);

                    SqlParameter pTen_Dan_Toc = new SqlParameter("@Ten_Dan_Toc", SqlDbType.NVarChar, 100);
                    pTen_Dan_Toc.Value = Ten_Dan_Toc;
                    myCommand.Parameters.Add(pTen_Dan_Toc);

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
        public void Xoa(string Ma_Dan_Toc)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Dan_Toc_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Dan_Toc = new SqlParameter("@Ma_Dan_Toc", SqlDbType.VarChar, 5);
                    pMa_Dan_Toc.Value = Ma_Dan_Toc;
                    myCommand.Parameters.Add(pMa_Dan_Toc);

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
                using (SqlCommand myCommand = new SqlCommand("HT_Dan_Toc_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Dan_Toc_Danh_Sach");
                    return myDataSet.Tables["HT_Dan_Toc_Danh_Sach"];
                }
            }
        }
        #endregion


    }
    #endregion
}