using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region NL_DM_Ma_Ten_Van_Bang_Details
    public class NL_DM_Ma_Ten_Van_Bang_Chi_Tiet
    {
        public int? Ma_Ten_Van_Bang = null; // Mã tên văn bằng
        public string Ten_Van_Bang = null; // Tên văn bằng
        public int? STT = null; // Số thứ tự
    }
    #endregion
    #region NL_DM_Ma_Ten_Van_Bang
    public class NL_DM_Ma_Ten_Van_Bang
    {
        private string ConnectionString;
        public NL_DM_Ma_Ten_Van_Bang(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_DM_Ma_Ten_Van_Bang_Chi_Tiet Lay(int Ma_Ten_Van_Bang)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Ma_Ten_Van_Bang_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Ten_Van_Bang = new SqlParameter("@Ma_Ten_Van_Bang", SqlDbType.Int, 4);
                    pMa_Ten_Van_Bang.Value = Ma_Ten_Van_Bang;
                    myCommand.Parameters.Add(pMa_Ten_Van_Bang);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Ma_Ten_Van_Bang_Chi_Tiet");
                    NL_DM_Ma_Ten_Van_Bang_Chi_Tiet myNL_DM_Ma_Ten_Van_Bang_Chi_Tiet = new NL_DM_Ma_Ten_Van_Bang_Chi_Tiet();
                    if (myDataSet.Tables["NL_DM_Ma_Ten_Van_Bang_Chi_Tiet"] != null)
                    {
                        myNL_DM_Ma_Ten_Van_Bang_Chi_Tiet.Ma_Ten_Van_Bang = Ma_Ten_Van_Bang;
                        myNL_DM_Ma_Ten_Van_Bang_Chi_Tiet.Ten_Van_Bang = myDataSet.Tables["NL_DM_Ma_Ten_Van_Bang_Chi_Tiet"].Rows[0]["Ten_Van_Bang"] != DBNull.Value ? (string)myDataSet.Tables["NL_DM_Ma_Ten_Van_Bang_Chi_Tiet"].Rows[0]["Ten_Van_Bang"] : (string)null;
                        myNL_DM_Ma_Ten_Van_Bang_Chi_Tiet.STT = myDataSet.Tables["NL_DM_Ma_Ten_Van_Bang_Chi_Tiet"].Rows[0]["STT"] != DBNull.Value ? (int?)myDataSet.Tables["NL_DM_Ma_Ten_Van_Bang_Chi_Tiet"].Rows[0]["STT"] : (int?)null;
                    }
                    return myNL_DM_Ma_Ten_Van_Bang_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Ma_Ten_Van_Bang = null, string Ten_Van_Bang = null, int? STT = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Ma_Ten_Van_Bang_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Ten_Van_Bang = new SqlParameter("@Ma_Ten_Van_Bang", SqlDbType.Int, 4);
                    pMa_Ten_Van_Bang.Value = Ma_Ten_Van_Bang;
                    myCommand.Parameters.Add(pMa_Ten_Van_Bang);

                    SqlParameter pTen_Van_Bang = new SqlParameter("@Ten_Van_Bang", SqlDbType.NVarChar, 500);
                    pTen_Van_Bang.Value = Ten_Van_Bang;
                    myCommand.Parameters.Add(pTen_Van_Bang);

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
        public void Cap_Nhat(int? Ma_Ten_Van_Bang = null, string Ten_Van_Bang = null, int? STT = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Ma_Ten_Van_Bang_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Ten_Van_Bang = new SqlParameter("@Ma_Ten_Van_Bang", SqlDbType.Int, 4);
                    pMa_Ten_Van_Bang.Value = Ma_Ten_Van_Bang;
                    myCommand.Parameters.Add(pMa_Ten_Van_Bang);

                    SqlParameter pTen_Van_Bang = new SqlParameter("@Ten_Van_Bang", SqlDbType.NVarChar, 500);
                    pTen_Van_Bang.Value = Ten_Van_Bang;
                    myCommand.Parameters.Add(pTen_Van_Bang);

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
        public void Cap_Nhat(NL_DM_Ma_Ten_Van_Bang_Chi_Tiet myNL_DM_Ma_Ten_Van_Bang_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Ma_Ten_Van_Bang_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Ten_Van_Bang = new SqlParameter("@Ma_Ten_Van_Bang", SqlDbType.Int, 4);
                    pMa_Ten_Van_Bang.Value = myNL_DM_Ma_Ten_Van_Bang_Chi_Tiet.Ma_Ten_Van_Bang;
                    myCommand.Parameters.Add(pMa_Ten_Van_Bang);

                    SqlParameter pTen_Van_Bang = new SqlParameter("@Ten_Van_Bang", SqlDbType.NVarChar, 500);
                    pTen_Van_Bang.Value = myNL_DM_Ma_Ten_Van_Bang_Chi_Tiet.Ten_Van_Bang;
                    myCommand.Parameters.Add(pTen_Van_Bang);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Value = myNL_DM_Ma_Ten_Van_Bang_Chi_Tiet.STT;
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
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Ma_Ten_Van_Bang_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Ten_Van_Bang = new SqlParameter("@Ma_Ten_Van_Bang", SqlDbType.Int, 4);
                        pMa_Ten_Van_Bang.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Ten_Van_Bang"];
                        myCommand.Parameters.Add(pMa_Ten_Van_Bang);

                        SqlParameter pTen_Van_Bang = new SqlParameter("@Ten_Van_Bang", SqlDbType.NVarChar, 500);
                        pTen_Van_Bang.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ten_Van_Bang"];
                        myCommand.Parameters.Add(pTen_Van_Bang);

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
        public void Cap_Nhat_Them(int? Ma_Ten_Van_Bang = null, string Ten_Van_Bang = null, int? STT = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Ma_Ten_Van_Bang_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Ten_Van_Bang = new SqlParameter("@Ma_Ten_Van_Bang", SqlDbType.Int, 4);
                    pMa_Ten_Van_Bang.Value = Ma_Ten_Van_Bang;
                    myCommand.Parameters.Add(pMa_Ten_Van_Bang);

                    SqlParameter pTen_Van_Bang = new SqlParameter("@Ten_Van_Bang", SqlDbType.NVarChar, 500);
                    pTen_Van_Bang.Value = Ten_Van_Bang;
                    myCommand.Parameters.Add(pTen_Van_Bang);

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
        public void Xoa(int Ma_Ten_Van_Bang)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Ma_Ten_Van_Bang_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Ten_Van_Bang = new SqlParameter("@Ma_Ten_Van_Bang", SqlDbType.Int, 4);
                    pMa_Ten_Van_Bang.Value = Ma_Ten_Van_Bang;
                    myCommand.Parameters.Add(pMa_Ten_Van_Bang);

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
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Ma_Ten_Van_Bang_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Ma_Ten_Van_Bang_Danh_Sach");
                    return myDataSet.Tables["NL_DM_Ma_Ten_Van_Bang_Danh_Sach"];
                }
            }
        }
        #endregion


    }
    #endregion
}