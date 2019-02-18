using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region NL_DM_Chuc_Vu_Details
    public class NL_DM_Chuc_Vu_Chi_Tiet
    {
        public int? Ma_Chuc_Vu = null; // Mã chức vụ
        public int? Ma_Linh_Vuc = null; // Mã lĩnh vực
        public string Ten_Chuc_Vu = null; // Tên chức vụ
        public int? STT = null;
    }
    #endregion
    #region NL_DM_Chuc_Vu
    public class NL_DM_Chuc_Vu
    {
        private string ConnectionString;
        public NL_DM_Chuc_Vu(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_DM_Chuc_Vu_Chi_Tiet Lay(int Ma_Chuc_Vu)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Chuc_Vu_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Chuc_Vu = new SqlParameter("@Ma_Chuc_Vu", SqlDbType.Int, 4);
                    pMa_Chuc_Vu.Value = Ma_Chuc_Vu;
                    myCommand.Parameters.Add(pMa_Chuc_Vu);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Chuc_Vu_Chi_Tiet");
                    NL_DM_Chuc_Vu_Chi_Tiet myNL_DM_Chuc_Vu_Chi_Tiet = new NL_DM_Chuc_Vu_Chi_Tiet();
                    if (myDataSet.Tables["NL_DM_Chuc_Vu_Chi_Tiet"] != null)
                    {
                        myNL_DM_Chuc_Vu_Chi_Tiet.Ma_Chuc_Vu = Ma_Chuc_Vu;
                        myNL_DM_Chuc_Vu_Chi_Tiet.Ma_Linh_Vuc = myDataSet.Tables["NL_DM_Chuc_Vu_Chi_Tiet"].Rows[0]["Ma_Linh_Vuc"] != DBNull.Value ? (int?)myDataSet.Tables["NL_DM_Chuc_Vu_Chi_Tiet"].Rows[0]["Ma_Linh_Vuc"] : (int?)null;
                        myNL_DM_Chuc_Vu_Chi_Tiet.Ten_Chuc_Vu = myDataSet.Tables["NL_DM_Chuc_Vu_Chi_Tiet"].Rows[0]["Ten_Chuc_Vu"] != DBNull.Value ? (string)myDataSet.Tables["NL_DM_Chuc_Vu_Chi_Tiet"].Rows[0]["Ten_Chuc_Vu"] : (string)null;
                    }
                    return myNL_DM_Chuc_Vu_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Ma_Chuc_Vu = null, int? Ma_Linh_Vuc = null, string Ten_Chuc_Vu = null, int? STT = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Chuc_Vu_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Chuc_Vu = new SqlParameter("@Ma_Chuc_Vu", SqlDbType.Int, 4);
                    pMa_Chuc_Vu.Value = Ma_Chuc_Vu;
                    myCommand.Parameters.Add(pMa_Chuc_Vu);

                    SqlParameter pMa_Linh_Vuc = new SqlParameter("@Ma_Linh_Vuc", SqlDbType.Int, 4);
                    pMa_Linh_Vuc.Value = Ma_Linh_Vuc;
                    myCommand.Parameters.Add(pMa_Linh_Vuc);

                    SqlParameter pTen_Chuc_Vu = new SqlParameter("@Ten_Chuc_Vu", SqlDbType.NVarChar, 250);
                    pTen_Chuc_Vu.Value = Ten_Chuc_Vu;
                    myCommand.Parameters.Add(pTen_Chuc_Vu);

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
        public void Cap_Nhat(int? Ma_Chuc_Vu = null, int? Ma_Linh_Vuc = null, string Ten_Chuc_Vu = null, int? STT=null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Chuc_Vu_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Chuc_Vu = new SqlParameter("@Ma_Chuc_Vu", SqlDbType.Int, 4);
                    pMa_Chuc_Vu.Value = Ma_Chuc_Vu;
                    myCommand.Parameters.Add(pMa_Chuc_Vu);

                    SqlParameter pMa_Linh_Vuc = new SqlParameter("@Ma_Linh_Vuc", SqlDbType.Int, 4);
                    pMa_Linh_Vuc.Value = Ma_Linh_Vuc;
                    myCommand.Parameters.Add(pMa_Linh_Vuc);

                    SqlParameter pTen_Chuc_Vu = new SqlParameter("@Ten_Chuc_Vu", SqlDbType.NVarChar, 250);
                    pTen_Chuc_Vu.Value = Ten_Chuc_Vu;
                    myCommand.Parameters.Add(pTen_Chuc_Vu);

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
        public void Cap_Nhat(NL_DM_Chuc_Vu_Chi_Tiet myNL_DM_Chuc_Vu_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Chuc_Vu_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Chuc_Vu = new SqlParameter("@Ma_Chuc_Vu", SqlDbType.Int, 4);
                    pMa_Chuc_Vu.Value = myNL_DM_Chuc_Vu_Chi_Tiet.Ma_Chuc_Vu;
                    myCommand.Parameters.Add(pMa_Chuc_Vu);

                    SqlParameter pMa_Linh_Vuc = new SqlParameter("@Ma_Linh_Vuc", SqlDbType.Int, 4);
                    pMa_Linh_Vuc.Value = myNL_DM_Chuc_Vu_Chi_Tiet.Ma_Linh_Vuc;
                    myCommand.Parameters.Add(pMa_Linh_Vuc);

                    SqlParameter pTen_Chuc_Vu = new SqlParameter("@Ten_Chuc_Vu", SqlDbType.NVarChar, 250);
                    pTen_Chuc_Vu.Value = myNL_DM_Chuc_Vu_Chi_Tiet.Ten_Chuc_Vu;
                    myCommand.Parameters.Add(pTen_Chuc_Vu);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Value = myNL_DM_Chuc_Vu_Chi_Tiet.STT;
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
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Chuc_Vu_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Chuc_Vu = new SqlParameter("@Ma_Chuc_Vu", SqlDbType.Int, 4);
                        pMa_Chuc_Vu.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Chuc_Vu"];
                        myCommand.Parameters.Add(pMa_Chuc_Vu);

                        SqlParameter pMa_Linh_Vuc = new SqlParameter("@Ma_Linh_Vuc", SqlDbType.Int, 4);
                        pMa_Linh_Vuc.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Linh_Vuc"];
                        myCommand.Parameters.Add(pMa_Linh_Vuc);

                        SqlParameter pTen_Chuc_Vu = new SqlParameter("@Ten_Chuc_Vu", SqlDbType.NVarChar, 250);
                        pTen_Chuc_Vu.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ten_Chuc_Vu"];
                        myCommand.Parameters.Add(pTen_Chuc_Vu);

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
        public void Cap_Nhat_Them(int? Ma_Chuc_Vu = null, int? Ma_Linh_Vuc = null, string Ten_Chuc_Vu = null, int?STT=null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Chuc_Vu_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Chuc_Vu = new SqlParameter("@Ma_Chuc_Vu", SqlDbType.Int, 4);
                    pMa_Chuc_Vu.Value = Ma_Chuc_Vu;
                    myCommand.Parameters.Add(pMa_Chuc_Vu);

                    SqlParameter pMa_Linh_Vuc = new SqlParameter("@Ma_Linh_Vuc", SqlDbType.Int, 4);
                    pMa_Linh_Vuc.Value = Ma_Linh_Vuc;
                    myCommand.Parameters.Add(pMa_Linh_Vuc);

                    SqlParameter pTen_Chuc_Vu = new SqlParameter("@Ten_Chuc_Vu", SqlDbType.NVarChar, 250);
                    pTen_Chuc_Vu.Value = Ten_Chuc_Vu;
                    myCommand.Parameters.Add(pTen_Chuc_Vu);

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
        public void Xoa(int Ma_Chuc_Vu)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Chuc_Vu_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Chuc_Vu = new SqlParameter("@Ma_Chuc_Vu", SqlDbType.Int, 4);
                    pMa_Chuc_Vu.Value = Ma_Chuc_Vu;
                    myCommand.Parameters.Add(pMa_Chuc_Vu);

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
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Chuc_Vu_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Chuc_Vu_Danh_Sach");
                    return myDataSet.Tables["NL_DM_Chuc_Vu_Danh_Sach"];
                }
            }
        }
        #endregion


    }
    #endregion
}