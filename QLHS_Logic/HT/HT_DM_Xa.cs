
using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region HT_DM_Xa_Details
    public class HT_DM_Xa_Chi_Tiet
    {
        public string Ma_Xa;
        public string Ma_Huyen;
        public string Ten_Xa;
        public string STT;
    }
    #endregion
    #region HT_DM_Xa
    public class HT_DM_Xa
    {
        private string ConnectionString;
        public HT_DM_Xa(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public HT_DM_Xa_Chi_Tiet Lay(string Ma_Xa)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_DM_Xa_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Xa = new SqlParameter("@Ma_Xa", SqlDbType.VarChar, 10);
                    pMa_Xa.Value = Ma_Xa;
                    myCommand.Parameters.Add(pMa_Xa);

                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pMa_Huyen.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pMa_Huyen);

                    SqlParameter pTen_Xa = new SqlParameter("@Ten_Xa", SqlDbType.NVarChar, 200);
                    pTen_Xa.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pTen_Xa);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.NChar, 10);
                    pSTT.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pSTT);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();


                    HT_DM_Xa_Chi_Tiet myHT_DM_Xa_Chi_Tiet = new HT_DM_Xa_Chi_Tiet();
                    myHT_DM_Xa_Chi_Tiet.Ma_Xa = Ma_Xa;
                    myHT_DM_Xa_Chi_Tiet.Ma_Huyen = (string)pMa_Huyen.Value;
                    myHT_DM_Xa_Chi_Tiet.Ten_Xa = (string)pTen_Xa.Value;
                    myHT_DM_Xa_Chi_Tiet.STT = (string)pSTT.Value;
                    return myHT_DM_Xa_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public string Them(string Ma_Xa, string Ma_Huyen, string Ten_Xa, string STT)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_DM_Xa_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Xa = new SqlParameter("@Ma_Xa", SqlDbType.VarChar, 10);
                    pMa_Xa.Value = Ma_Xa;
                    myCommand.Parameters.Add(pMa_Xa);

                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pMa_Huyen.Value = Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

                    SqlParameter pTen_Xa = new SqlParameter("@Ten_Xa", SqlDbType.NVarChar, 200);
                    pTen_Xa.Value = Ten_Xa;
                    myCommand.Parameters.Add(pTen_Xa);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.NChar, 10);
                    pSTT.Value = STT;
                    myCommand.Parameters.Add(pSTT);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    return (string)pMa_Xa.Value;
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(string Ma_Xa, string Ma_Huyen, string Ten_Xa, string STT)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_DM_Xa_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Xa = new SqlParameter("@Ma_Xa", SqlDbType.VarChar, 10);
                    pMa_Xa.Value = Ma_Xa;
                    myCommand.Parameters.Add(pMa_Xa);

                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pMa_Huyen.Value = Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

                    SqlParameter pTen_Xa = new SqlParameter("@Ten_Xa", SqlDbType.NVarChar, 200);
                    pTen_Xa.Value = Ten_Xa;
                    myCommand.Parameters.Add(pTen_Xa);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.NChar, 10);
                    pSTT.Value = STT;
                    myCommand.Parameters.Add(pSTT);



                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(HT_DM_Xa_Chi_Tiet myHT_DM_Xa_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_DM_Xa_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Xa = new SqlParameter("@Ma_Xa", SqlDbType.VarChar, 10);
                    pMa_Xa.Value = myHT_DM_Xa_Chi_Tiet.Ma_Xa;
                    myCommand.Parameters.Add(pMa_Xa);

                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pMa_Huyen.Value = myHT_DM_Xa_Chi_Tiet.Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

                    SqlParameter pTen_Xa = new SqlParameter("@Ten_Xa", SqlDbType.NVarChar, 200);
                    pTen_Xa.Value = myHT_DM_Xa_Chi_Tiet.Ten_Xa;
                    myCommand.Parameters.Add(pTen_Xa);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.NChar, 10);
                    pSTT.Value = myHT_DM_Xa_Chi_Tiet.STT;
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
                using (SqlCommand myCommand = new SqlCommand("HT_DM_Xa_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Xa = new SqlParameter("@Ma_Xa", SqlDbType.VarChar, 10);
                        pMa_Xa.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ma_Xa"];
                        myCommand.Parameters.Add(pMa_Xa);

                        SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                        pMa_Huyen.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ma_Huyen"];
                        myCommand.Parameters.Add(pMa_Huyen);

                        SqlParameter pTen_Xa = new SqlParameter("@Ten_Xa", SqlDbType.NVarChar, 200);
                        pTen_Xa.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ten_Xa"];
                        myCommand.Parameters.Add(pTen_Xa);

                        SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.NChar, 10);
                        pSTT.Value = (string)myDataSet.Tables[strTableName].Rows[i]["STT"];
                        myCommand.Parameters.Add(pSTT);


                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(string Ma_Xa, string Ma_Huyen, string Ten_Xa, string STT)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_DM_Xa_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Xa = new SqlParameter("@Ma_Xa", SqlDbType.VarChar, 10);
                    pMa_Xa.Value = Ma_Xa;
                    myCommand.Parameters.Add(pMa_Xa);

                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pMa_Huyen.Value = Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

                    SqlParameter pTen_Xa = new SqlParameter("@Ten_Xa", SqlDbType.NVarChar, 200);
                    pTen_Xa.Value = Ten_Xa;
                    myCommand.Parameters.Add(pTen_Xa);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.NChar, 10);
                    pSTT.Value = STT;
                    myCommand.Parameters.Add(pSTT);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(string Ma_Xa)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_DM_Xa_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Xa = new SqlParameter("@Ma_Xa", SqlDbType.VarChar, 10);
                    pMa_Xa.Value = Ma_Xa;
                    myCommand.Parameters.Add(pMa_Xa);

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
                using (SqlCommand myCommand = new SqlCommand("HT_DM_Xa_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_DM_Xa_Danh_Sach");
                    return myDataSet.Tables["HT_DM_Xa_Danh_Sach"];
                }
            }
        }
        #endregion

        #region Lay_Boi_HT_DM_Huyen
        public DataTable Lay_Boi_HT_DM_Huyen(string Ma_Huyen)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_DM_Xa_Lay_Boi_HT_DM_Huyen", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pMa_Huyen.Value = Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_DM_Xa_Lay_Boi_HT_DM_Huyen");
                    return myDataSet.Tables["HT_DM_Xa_Lay_Boi_HT_DM_Huyen"];
                }
            }
        }
        #endregion

    }
    #endregion
}