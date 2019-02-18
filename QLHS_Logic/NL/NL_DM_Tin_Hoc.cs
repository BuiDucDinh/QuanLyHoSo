using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region NL_DM_Tin_Hoc_Details
    public class NL_DM_Tin_Hoc_Chi_Tiet
    {
        public int? Ma_Tin_Hoc = null; // Mã tin học
        public string Trinh_Do = null; // Trình độ
        public int? Cap_Do = null; // Cấp độ
    }
    #endregion
    #region NL_DM_Tin_Hoc
    public class NL_DM_Tin_Hoc
    {
        private string ConnectionString;
        public NL_DM_Tin_Hoc(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_DM_Tin_Hoc_Chi_Tiet Lay(int Ma_Tin_Hoc)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Tin_Hoc_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Tin_Hoc = new SqlParameter("@Ma_Tin_Hoc", SqlDbType.Int, 4);
                    pMa_Tin_Hoc.Value = Ma_Tin_Hoc;
                    myCommand.Parameters.Add(pMa_Tin_Hoc);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Tin_Hoc_Chi_Tiet");
                    NL_DM_Tin_Hoc_Chi_Tiet myNL_DM_Tin_Hoc_Chi_Tiet = new NL_DM_Tin_Hoc_Chi_Tiet();
                    if (myDataSet.Tables["NL_DM_Tin_Hoc_Chi_Tiet"] != null)
                    {
                        myNL_DM_Tin_Hoc_Chi_Tiet.Ma_Tin_Hoc = Ma_Tin_Hoc;
                        myNL_DM_Tin_Hoc_Chi_Tiet.Trinh_Do = myDataSet.Tables["NL_DM_Tin_Hoc_Chi_Tiet"].Rows[0]["Trinh_Do"] != DBNull.Value ? (string)myDataSet.Tables["NL_DM_Tin_Hoc_Chi_Tiet"].Rows[0]["Trinh_Do"] : (string)null;
                        myNL_DM_Tin_Hoc_Chi_Tiet.Cap_Do = myDataSet.Tables["NL_DM_Tin_Hoc_Chi_Tiet"].Rows[0]["Cap_Do"] != DBNull.Value ? (int?)myDataSet.Tables["NL_DM_Tin_Hoc_Chi_Tiet"].Rows[0]["Cap_Do"] : (int?)null;
                    }
                    return myNL_DM_Tin_Hoc_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Ma_Tin_Hoc = null, string Trinh_Do = null, int? Cap_Do = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Tin_Hoc_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Tin_Hoc = new SqlParameter("@Ma_Tin_Hoc", SqlDbType.Int, 4);
                    pMa_Tin_Hoc.Value = Ma_Tin_Hoc;
                    myCommand.Parameters.Add(pMa_Tin_Hoc);

                    SqlParameter pTrinh_Do = new SqlParameter("@Trinh_Do", SqlDbType.NVarChar, 50);
                    pTrinh_Do.Value = Trinh_Do;
                    myCommand.Parameters.Add(pTrinh_Do);

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
        public void Cap_Nhat(int? Ma_Tin_Hoc = null, string Trinh_Do = null, int? Cap_Do = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Tin_Hoc_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Tin_Hoc = new SqlParameter("@Ma_Tin_Hoc", SqlDbType.Int, 4);
                    pMa_Tin_Hoc.Value = Ma_Tin_Hoc;
                    myCommand.Parameters.Add(pMa_Tin_Hoc);

                    SqlParameter pTrinh_Do = new SqlParameter("@Trinh_Do", SqlDbType.NVarChar, 50);
                    pTrinh_Do.Value = Trinh_Do;
                    myCommand.Parameters.Add(pTrinh_Do);

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
        public void Cap_Nhat(NL_DM_Tin_Hoc_Chi_Tiet myNL_DM_Tin_Hoc_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Tin_Hoc_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Tin_Hoc = new SqlParameter("@Ma_Tin_Hoc", SqlDbType.Int, 4);
                    pMa_Tin_Hoc.Value = myNL_DM_Tin_Hoc_Chi_Tiet.Ma_Tin_Hoc;
                    myCommand.Parameters.Add(pMa_Tin_Hoc);

                    SqlParameter pTrinh_Do = new SqlParameter("@Trinh_Do", SqlDbType.NVarChar, 50);
                    pTrinh_Do.Value = myNL_DM_Tin_Hoc_Chi_Tiet.Trinh_Do;
                    myCommand.Parameters.Add(pTrinh_Do);

                    SqlParameter pCap_Do = new SqlParameter("@Cap_Do", SqlDbType.Int, 4);
                    pCap_Do.Value = myNL_DM_Tin_Hoc_Chi_Tiet.Cap_Do;
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
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Tin_Hoc_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Tin_Hoc = new SqlParameter("@Ma_Tin_Hoc", SqlDbType.Int, 4);
                        pMa_Tin_Hoc.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Tin_Hoc"];
                        myCommand.Parameters.Add(pMa_Tin_Hoc);

                        SqlParameter pTrinh_Do = new SqlParameter("@Trinh_Do", SqlDbType.NVarChar, 50);
                        pTrinh_Do.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Trinh_Do"];
                        myCommand.Parameters.Add(pTrinh_Do);

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
        public void Cap_Nhat_Them(int? Ma_Tin_Hoc = null, string Trinh_Do = null, int? Cap_Do = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Tin_Hoc_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Tin_Hoc = new SqlParameter("@Ma_Tin_Hoc", SqlDbType.Int, 4);
                    pMa_Tin_Hoc.Value = Ma_Tin_Hoc;
                    myCommand.Parameters.Add(pMa_Tin_Hoc);

                    SqlParameter pTrinh_Do = new SqlParameter("@Trinh_Do", SqlDbType.NVarChar, 50);
                    pTrinh_Do.Value = Trinh_Do;
                    myCommand.Parameters.Add(pTrinh_Do);

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
        public void Xoa(int Ma_Tin_Hoc)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Tin_Hoc_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Tin_Hoc = new SqlParameter("@Ma_Tin_Hoc", SqlDbType.Int, 4);
                    pMa_Tin_Hoc.Value = Ma_Tin_Hoc;
                    myCommand.Parameters.Add(pMa_Tin_Hoc);

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
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Tin_Hoc_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Tin_Hoc_Danh_Sach");
                    return myDataSet.Tables["NL_DM_Tin_Hoc_Danh_Sach"];
                }
            }
        }
        #endregion


    }
    #endregion
}