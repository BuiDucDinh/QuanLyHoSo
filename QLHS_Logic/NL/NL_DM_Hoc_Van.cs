using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region NL_DM_Hoc_Van_Details
    public class NL_DM_Hoc_Van_Chi_Tiet
    {
        public int? Ma_Hoc_Van = null; // Mã học vấn
        public string Ten_Hoc_Van = null; // Tên học vấn(Giao sư, tiến sỹ..)
        public int? Cap_Do = null; // Cấp độ
    }
    #endregion
    #region NL_DM_Hoc_Van
    public class NL_DM_Hoc_Van
    {
        private string ConnectionString;
        public NL_DM_Hoc_Van(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_DM_Hoc_Van_Chi_Tiet Lay(int Ma_Hoc_Van)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Hoc_Van_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Hoc_Van = new SqlParameter("@Ma_Hoc_Van", SqlDbType.Int, 4);
                    pMa_Hoc_Van.Value = Ma_Hoc_Van;
                    myCommand.Parameters.Add(pMa_Hoc_Van);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Hoc_Van_Chi_Tiet");
                    NL_DM_Hoc_Van_Chi_Tiet myNL_DM_Hoc_Van_Chi_Tiet = new NL_DM_Hoc_Van_Chi_Tiet();
                    if (myDataSet.Tables["NL_DM_Hoc_Van_Chi_Tiet"] != null)
                    {
                        myNL_DM_Hoc_Van_Chi_Tiet.Ma_Hoc_Van = Ma_Hoc_Van;
                        myNL_DM_Hoc_Van_Chi_Tiet.Ten_Hoc_Van = myDataSet.Tables["NL_DM_Hoc_Van_Chi_Tiet"].Rows[0]["Ten_Hoc_Van"] != DBNull.Value ? (string)myDataSet.Tables["NL_DM_Hoc_Van_Chi_Tiet"].Rows[0]["Ten_Hoc_Van"] : (string)null;
                        myNL_DM_Hoc_Van_Chi_Tiet.Cap_Do = myDataSet.Tables["NL_DM_Hoc_Van_Chi_Tiet"].Rows[0]["Cap_Do"] != DBNull.Value ? (int?)myDataSet.Tables["NL_DM_Hoc_Van_Chi_Tiet"].Rows[0]["Cap_Do"] : (int?)null;
                    }
                    return myNL_DM_Hoc_Van_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Ma_Hoc_Van = null, string Ten_Hoc_Van = null, int? Cap_Do = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Hoc_Van_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Hoc_Van = new SqlParameter("@Ma_Hoc_Van", SqlDbType.Int, 4);
                    pMa_Hoc_Van.Value = Ma_Hoc_Van;
                    myCommand.Parameters.Add(pMa_Hoc_Van);

                    SqlParameter pTen_Hoc_Van = new SqlParameter("@Ten_Hoc_Van", SqlDbType.NVarChar, 500);
                    pTen_Hoc_Van.Value = Ten_Hoc_Van;
                    myCommand.Parameters.Add(pTen_Hoc_Van);

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
        public void Cap_Nhat(int? Ma_Hoc_Van = null, string Ten_Hoc_Van = null, int? Cap_Do = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Hoc_Van_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Hoc_Van = new SqlParameter("@Ma_Hoc_Van", SqlDbType.Int, 4);
                    pMa_Hoc_Van.Value = Ma_Hoc_Van;
                    myCommand.Parameters.Add(pMa_Hoc_Van);

                    SqlParameter pTen_Hoc_Van = new SqlParameter("@Ten_Hoc_Van", SqlDbType.NVarChar, 500);
                    pTen_Hoc_Van.Value = Ten_Hoc_Van;
                    myCommand.Parameters.Add(pTen_Hoc_Van);

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
        public void Cap_Nhat(NL_DM_Hoc_Van_Chi_Tiet myNL_DM_Hoc_Van_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Hoc_Van_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Hoc_Van = new SqlParameter("@Ma_Hoc_Van", SqlDbType.Int, 4);
                    pMa_Hoc_Van.Value = myNL_DM_Hoc_Van_Chi_Tiet.Ma_Hoc_Van;
                    myCommand.Parameters.Add(pMa_Hoc_Van);

                    SqlParameter pTen_Hoc_Van = new SqlParameter("@Ten_Hoc_Van", SqlDbType.NVarChar, 500);
                    pTen_Hoc_Van.Value = myNL_DM_Hoc_Van_Chi_Tiet.Ten_Hoc_Van;
                    myCommand.Parameters.Add(pTen_Hoc_Van);

                    SqlParameter pCap_Do = new SqlParameter("@Cap_Do", SqlDbType.Int, 4);
                    pCap_Do.Value = myNL_DM_Hoc_Van_Chi_Tiet.Cap_Do;
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
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Hoc_Van_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Hoc_Van = new SqlParameter("@Ma_Hoc_Van", SqlDbType.Int, 4);
                        pMa_Hoc_Van.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Hoc_Van"];
                        myCommand.Parameters.Add(pMa_Hoc_Van);

                        SqlParameter pTen_Hoc_Van = new SqlParameter("@Ten_Hoc_Van", SqlDbType.NVarChar, 500);
                        pTen_Hoc_Van.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ten_Hoc_Van"];
                        myCommand.Parameters.Add(pTen_Hoc_Van);

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
        public void Cap_Nhat_Them(int? Ma_Hoc_Van = null, string Ten_Hoc_Van = null, int? Cap_Do = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Hoc_Van_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Hoc_Van = new SqlParameter("@Ma_Hoc_Van", SqlDbType.Int, 4);
                    pMa_Hoc_Van.Value = Ma_Hoc_Van;
                    myCommand.Parameters.Add(pMa_Hoc_Van);

                    SqlParameter pTen_Hoc_Van = new SqlParameter("@Ten_Hoc_Van", SqlDbType.NVarChar, 500);
                    pTen_Hoc_Van.Value = Ten_Hoc_Van;
                    myCommand.Parameters.Add(pTen_Hoc_Van);

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
        public void Xoa(int Ma_Hoc_Van)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Hoc_Van_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Hoc_Van = new SqlParameter("@Ma_Hoc_Van", SqlDbType.Int, 4);
                    pMa_Hoc_Van.Value = Ma_Hoc_Van;
                    myCommand.Parameters.Add(pMa_Hoc_Van);

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
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Hoc_Van_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Hoc_Van_Danh_Sach");
                    return myDataSet.Tables["NL_DM_Hoc_Van_Danh_Sach"];
                }
            }
        }
        #endregion


    }
    #endregion
}