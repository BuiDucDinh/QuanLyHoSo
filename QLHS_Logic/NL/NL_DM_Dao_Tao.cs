using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region NL_DM_Dao_Tao_Details
    public class NL_DM_Dao_Tao_Chi_Tiet
    {
        public int? Ma_Dao_Tao = null; // Mã đào tạo
        public string Ten_Dao_Tao = null;
        public int? STT = null;
    }
    #endregion
    #region NL_DM_Dao_Tao
    public class NL_DM_Dao_Tao
    {
        private string ConnectionString;
        public NL_DM_Dao_Tao(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_DM_Dao_Tao_Chi_Tiet Lay(int Ma_Dao_Tao)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Dao_Tao_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Dao_Tao = new SqlParameter("@Ma_Dao_Tao", SqlDbType.Int, 4);
                    pMa_Dao_Tao.Value = Ma_Dao_Tao;
                    myCommand.Parameters.Add(pMa_Dao_Tao);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Dao_Tao_Chi_Tiet");
                    NL_DM_Dao_Tao_Chi_Tiet myNL_DM_Dao_Tao_Chi_Tiet = new NL_DM_Dao_Tao_Chi_Tiet();
                    if (myDataSet.Tables["NL_DM_Dao_Tao_Chi_Tiet"] != null)
                    {
                        myNL_DM_Dao_Tao_Chi_Tiet.Ma_Dao_Tao = Ma_Dao_Tao;
                        myNL_DM_Dao_Tao_Chi_Tiet.Ten_Dao_Tao = myDataSet.Tables["NL_DM_Dao_Tao_Chi_Tiet"].Rows[0]["Ten_Dao_Tao"] != DBNull.Value ? (string)myDataSet.Tables["NL_DM_Dao_Tao_Chi_Tiet"].Rows[0]["Ten_Dao_Tao"] : (string)null;
                        myNL_DM_Dao_Tao_Chi_Tiet.STT = myDataSet.Tables["NL_DM_Dao_Tao_Chi_Tiet"].Rows[0]["STT"] != DBNull.Value ? (int?)myDataSet.Tables["NL_DM_Dao_Tao_Chi_Tiet"].Rows[0]["STT"] : (int?)null;
                    }
                    return myNL_DM_Dao_Tao_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Ma_Dao_Tao = null, string Ten_Dao_Tao = null, int? STT = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Dao_Tao_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Dao_Tao = new SqlParameter("@Ma_Dao_Tao", SqlDbType.Int, 4);
                    pMa_Dao_Tao.Value = Ma_Dao_Tao;
                    myCommand.Parameters.Add(pMa_Dao_Tao);

                    SqlParameter pTen_Dao_Tao = new SqlParameter("@Ten_Dao_Tao", SqlDbType.NVarChar, 200);
                    pTen_Dao_Tao.Value = Ten_Dao_Tao;
                    myCommand.Parameters.Add(pTen_Dao_Tao);

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
        public void Cap_Nhat(int? Ma_Dao_Tao = null, string Ten_Dao_Tao = null, int? STT = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Dao_Tao_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Dao_Tao = new SqlParameter("@Ma_Dao_Tao", SqlDbType.Int, 4);
                    pMa_Dao_Tao.Value = Ma_Dao_Tao;
                    myCommand.Parameters.Add(pMa_Dao_Tao);

                    SqlParameter pTen_Dao_Tao = new SqlParameter("@Ten_Dao_Tao", SqlDbType.NVarChar, 200);
                    pTen_Dao_Tao.Value = Ten_Dao_Tao;
                    myCommand.Parameters.Add(pTen_Dao_Tao);

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
        public void Cap_Nhat(NL_DM_Dao_Tao_Chi_Tiet myNL_DM_Dao_Tao_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Dao_Tao_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Dao_Tao = new SqlParameter("@Ma_Dao_Tao", SqlDbType.Int, 4);
                    pMa_Dao_Tao.Value = myNL_DM_Dao_Tao_Chi_Tiet.Ma_Dao_Tao;
                    myCommand.Parameters.Add(pMa_Dao_Tao);

                    SqlParameter pTen_Dao_Tao = new SqlParameter("@Ten_Dao_Tao", SqlDbType.NVarChar, 200);
                    pTen_Dao_Tao.Value = myNL_DM_Dao_Tao_Chi_Tiet.Ten_Dao_Tao;
                    myCommand.Parameters.Add(pTen_Dao_Tao);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Value = myNL_DM_Dao_Tao_Chi_Tiet.STT;
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
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Dao_Tao_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Dao_Tao = new SqlParameter("@Ma_Dao_Tao", SqlDbType.Int, 4);
                        pMa_Dao_Tao.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Dao_Tao"];
                        myCommand.Parameters.Add(pMa_Dao_Tao);

                        SqlParameter pTen_Dao_Tao = new SqlParameter("@Ten_Dao_Tao", SqlDbType.NVarChar, 200);
                        pTen_Dao_Tao.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ten_Dao_Tao"];
                        myCommand.Parameters.Add(pTen_Dao_Tao);


                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int? Ma_Dao_Tao = null, string Ten_Dao_Tao = null, int? STT = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Dao_Tao_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Dao_Tao = new SqlParameter("@Ma_Dao_Tao", SqlDbType.Int, 4);
                    pMa_Dao_Tao.Value = Ma_Dao_Tao;
                    myCommand.Parameters.Add(pMa_Dao_Tao);

                    SqlParameter pTen_Dao_Tao = new SqlParameter("@Ten_Dao_Tao", SqlDbType.NVarChar, 200);
                    pTen_Dao_Tao.Value = Ten_Dao_Tao;
                    myCommand.Parameters.Add(pTen_Dao_Tao);

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
        public void Xoa(int Ma_Dao_Tao)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Dao_Tao_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Dao_Tao = new SqlParameter("@Ma_Dao_Tao", SqlDbType.Int, 4);
                    pMa_Dao_Tao.Value = Ma_Dao_Tao;
                    myCommand.Parameters.Add(pMa_Dao_Tao);

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
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Dao_Tao_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Dao_Tao_Danh_Sach");
                    return myDataSet.Tables["NL_DM_Dao_Tao_Danh_Sach"];
                }
            }
        }
        #endregion


    }
    #endregion
}