using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region NL_DM_Chinh_Tri_Details
    public class NL_DM_Chinh_Tri_Chi_Tiet
    {
        public int? Ma_Chinh_Tri = null; // Mã lý luận
        public string Ten_Chinh_Tri = null; // Tên lý luận chính trị
        public int? Cap_Do = null; // Cấp độ
    }
    #endregion
    #region NL_DM_Chinh_Tri
    public class NL_DM_Chinh_Tri
    {
        private string ConnectionString;
        public NL_DM_Chinh_Tri(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_DM_Chinh_Tri_Chi_Tiet Lay(int Ma_Chinh_Tri)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Chinh_Tri_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Chinh_Tri = new SqlParameter("@Ma_Chinh_Tri", SqlDbType.Int, 4);
                    pMa_Chinh_Tri.Value = Ma_Chinh_Tri;
                    myCommand.Parameters.Add(pMa_Chinh_Tri);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Chinh_Tri_Chi_Tiet");
                    NL_DM_Chinh_Tri_Chi_Tiet myNL_DM_Chinh_Tri_Chi_Tiet = new NL_DM_Chinh_Tri_Chi_Tiet();
                    if (myDataSet.Tables["NL_DM_Chinh_Tri_Chi_Tiet"] != null)
                    {
                        myNL_DM_Chinh_Tri_Chi_Tiet.Ma_Chinh_Tri = Ma_Chinh_Tri;
                        myNL_DM_Chinh_Tri_Chi_Tiet.Ten_Chinh_Tri = myDataSet.Tables["NL_DM_Chinh_Tri_Chi_Tiet"].Rows[0]["Ten_Chinh_Tri"] != DBNull.Value ? (string)myDataSet.Tables["NL_DM_Chinh_Tri_Chi_Tiet"].Rows[0]["Ten_Chinh_Tri"] : (string)null;
                        myNL_DM_Chinh_Tri_Chi_Tiet.Cap_Do = myDataSet.Tables["NL_DM_Chinh_Tri_Chi_Tiet"].Rows[0]["Cap_Do"] != DBNull.Value ? (int?)myDataSet.Tables["NL_DM_Chinh_Tri_Chi_Tiet"].Rows[0]["Cap_Do"] : (int?)null;
                    }
                    return myNL_DM_Chinh_Tri_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Ma_Chinh_Tri = null, string Ten_Chinh_Tri = null, int? Cap_Do = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Chinh_Tri_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Chinh_Tri = new SqlParameter("@Ma_Chinh_Tri", SqlDbType.Int, 4);
                    pMa_Chinh_Tri.Value = Ma_Chinh_Tri;
                    myCommand.Parameters.Add(pMa_Chinh_Tri);

                    SqlParameter pTen_Chinh_Tri = new SqlParameter("@Ten_Chinh_Tri", SqlDbType.NVarChar, 1000);
                    pTen_Chinh_Tri.Value = Ten_Chinh_Tri;
                    myCommand.Parameters.Add(pTen_Chinh_Tri);

                    SqlParameter pCap_Do = new SqlParameter("@Cap_Do", SqlDbType.Int, 4);
                    pCap_Do.Value = Cap_Do;
                    myCommand.Parameters.Add(pCap_Do);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int? Ma_Chinh_Tri = null, string Ten_Chinh_Tri = null, int? Cap_Do = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Chinh_Tri_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Chinh_Tri = new SqlParameter("@Ma_Chinh_Tri", SqlDbType.Int, 4);
                    pMa_Chinh_Tri.Value = Ma_Chinh_Tri;
                    myCommand.Parameters.Add(pMa_Chinh_Tri);

                    SqlParameter pTen_Chinh_Tri = new SqlParameter("@Ten_Chinh_Tri", SqlDbType.NVarChar, 1000);
                    pTen_Chinh_Tri.Value = Ten_Chinh_Tri;
                    myCommand.Parameters.Add(pTen_Chinh_Tri);

                    SqlParameter pCap_Do = new SqlParameter("@Cap_Do", SqlDbType.Int, 4);
                    pCap_Do.Value = Cap_Do;
                    myCommand.Parameters.Add(pCap_Do);



                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(NL_DM_Chinh_Tri_Chi_Tiet myNL_DM_Chinh_Tri_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Chinh_Tri_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Chinh_Tri = new SqlParameter("@Ma_Chinh_Tri", SqlDbType.Int, 4);
                    pMa_Chinh_Tri.Value = myNL_DM_Chinh_Tri_Chi_Tiet.Ma_Chinh_Tri;
                    myCommand.Parameters.Add(pMa_Chinh_Tri);

                    SqlParameter pTen_Chinh_Tri = new SqlParameter("@Ten_Chinh_Tri", SqlDbType.NVarChar, 1000);
                    pTen_Chinh_Tri.Value = myNL_DM_Chinh_Tri_Chi_Tiet.Ten_Chinh_Tri;
                    myCommand.Parameters.Add(pTen_Chinh_Tri);

                    SqlParameter pCap_Do = new SqlParameter("@Cap_Do", SqlDbType.Int, 4);
                    pCap_Do.Value = myNL_DM_Chinh_Tri_Chi_Tiet.Cap_Do;
                    myCommand.Parameters.Add(pCap_Do);


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
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Chinh_Tri_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Chinh_Tri = new SqlParameter("@Ma_Chinh_Tri", SqlDbType.Int, 4);
                        pMa_Chinh_Tri.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Chinh_Tri"];
                        myCommand.Parameters.Add(pMa_Chinh_Tri);

                        SqlParameter pTen_Chinh_Tri = new SqlParameter("@Ten_Chinh_Tri", SqlDbType.NVarChar, 1000);
                        pTen_Chinh_Tri.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ten_Chinh_Tri"];
                        myCommand.Parameters.Add(pTen_Chinh_Tri);

                        SqlParameter pCap_Do = new SqlParameter("@Cap_Do", SqlDbType.Int, 4);
                        pCap_Do.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Cap_Do"];
                        myCommand.Parameters.Add(pCap_Do);


                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int? Ma_Chinh_Tri = null, string Ten_Chinh_Tri = null, int? Cap_Do = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Chinh_Tri_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Chinh_Tri = new SqlParameter("@Ma_Chinh_Tri", SqlDbType.Int, 4);
                    pMa_Chinh_Tri.Value = Ma_Chinh_Tri;
                    myCommand.Parameters.Add(pMa_Chinh_Tri);

                    SqlParameter pTen_Chinh_Tri = new SqlParameter("@Ten_Chinh_Tri", SqlDbType.NVarChar, 1000);
                    pTen_Chinh_Tri.Value = Ten_Chinh_Tri;
                    myCommand.Parameters.Add(pTen_Chinh_Tri);

                    SqlParameter pCap_Do = new SqlParameter("@Cap_Do", SqlDbType.Int, 4);
                    pCap_Do.Value = Cap_Do;
                    myCommand.Parameters.Add(pCap_Do);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Ma_Chinh_Tri)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Chinh_Tri_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Chinh_Tri = new SqlParameter("@Ma_Chinh_Tri", SqlDbType.Int, 4);
                    pMa_Chinh_Tri.Value = Ma_Chinh_Tri;
                    myCommand.Parameters.Add(pMa_Chinh_Tri);

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
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Chinh_Tri_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Chinh_Tri_Danh_Sach");
                    return myDataSet.Tables["NL_DM_Chinh_Tri_Danh_Sach"];
                }
            }
        }
        #endregion


    }
    #endregion
}