using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region NL_DM_Chuc_Danh_Details
    public class NL_DM_Chuc_Danh_Chi_Tiet
    {
        public int? Ma_Chuc_Danh = null; // Mã chức danh
        public string Ten_Chuc_Danh = null; // Tên chức danh
        public int? Ma_Linh_Vuc = null; // Mã lĩnh vực
    }
    #endregion
    #region NL_DM_Chuc_Danh
    public class NL_DM_Chuc_Danh
    {
        private string ConnectionString;
        public NL_DM_Chuc_Danh(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_DM_Chuc_Danh_Chi_Tiet Lay(int Ma_Chuc_Danh)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Chuc_Danh_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Chuc_Danh = new SqlParameter("@Ma_Chuc_Danh", SqlDbType.Int, 4);
                    pMa_Chuc_Danh.Value = Ma_Chuc_Danh;
                    myCommand.Parameters.Add(pMa_Chuc_Danh);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Chuc_Danh_Chi_Tiet");
                    NL_DM_Chuc_Danh_Chi_Tiet myNL_DM_Chuc_Danh_Chi_Tiet = new NL_DM_Chuc_Danh_Chi_Tiet();
                    if (myDataSet.Tables["NL_DM_Chuc_Danh_Chi_Tiet"] != null)
                    {
                        myNL_DM_Chuc_Danh_Chi_Tiet.Ma_Chuc_Danh = Ma_Chuc_Danh;
                        myNL_DM_Chuc_Danh_Chi_Tiet.Ten_Chuc_Danh = myDataSet.Tables["NL_DM_Chuc_Danh_Chi_Tiet"].Rows[0]["Ten_Chuc_Danh"] != DBNull.Value ? (string)myDataSet.Tables["NL_DM_Chuc_Danh_Chi_Tiet"].Rows[0]["Ten_Chuc_Danh"] : (string)null;
                        myNL_DM_Chuc_Danh_Chi_Tiet.Ma_Linh_Vuc = myDataSet.Tables["NL_DM_Chuc_Danh_Chi_Tiet"].Rows[0]["Ma_Linh_Vuc"] != DBNull.Value ? (int?)myDataSet.Tables["NL_DM_Chuc_Danh_Chi_Tiet"].Rows[0]["Ma_Linh_Vuc"] : (int?)null;
                    }
                    return myNL_DM_Chuc_Danh_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Ma_Chuc_Danh = null, string Ten_Chuc_Danh = null, int? Ma_Linh_Vuc = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Chuc_Danh_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Chuc_Danh = new SqlParameter("@Ma_Chuc_Danh", SqlDbType.Int, 4);
                    pMa_Chuc_Danh.Value = Ma_Chuc_Danh;
                    myCommand.Parameters.Add(pMa_Chuc_Danh);

                    SqlParameter pTen_Chuc_Danh = new SqlParameter("@Ten_Chuc_Danh", SqlDbType.NVarChar, 200);
                    pTen_Chuc_Danh.Value = Ten_Chuc_Danh;
                    myCommand.Parameters.Add(pTen_Chuc_Danh);

                    SqlParameter pMa_Linh_Vuc = new SqlParameter("@Ma_Linh_Vuc", SqlDbType.Int, 4);
                    pMa_Linh_Vuc.Value = Ma_Linh_Vuc;
                    myCommand.Parameters.Add(pMa_Linh_Vuc);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int? Ma_Chuc_Danh = null, string Ten_Chuc_Danh = null, int? Ma_Linh_Vuc = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Chuc_Danh_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Chuc_Danh = new SqlParameter("@Ma_Chuc_Danh", SqlDbType.Int, 4);
                    pMa_Chuc_Danh.Value = Ma_Chuc_Danh;
                    myCommand.Parameters.Add(pMa_Chuc_Danh);

                    SqlParameter pTen_Chuc_Danh = new SqlParameter("@Ten_Chuc_Danh", SqlDbType.NVarChar, 200);
                    pTen_Chuc_Danh.Value = Ten_Chuc_Danh;
                    myCommand.Parameters.Add(pTen_Chuc_Danh);

                    SqlParameter pMa_Linh_Vuc = new SqlParameter("@Ma_Linh_Vuc", SqlDbType.Int, 4);
                    pMa_Linh_Vuc.Value = Ma_Linh_Vuc;
                    myCommand.Parameters.Add(pMa_Linh_Vuc);



                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(NL_DM_Chuc_Danh_Chi_Tiet myNL_DM_Chuc_Danh_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Chuc_Danh_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Chuc_Danh = new SqlParameter("@Ma_Chuc_Danh", SqlDbType.Int, 4);
                    pMa_Chuc_Danh.Value = myNL_DM_Chuc_Danh_Chi_Tiet.Ma_Chuc_Danh;
                    myCommand.Parameters.Add(pMa_Chuc_Danh);

                    SqlParameter pTen_Chuc_Danh = new SqlParameter("@Ten_Chuc_Danh", SqlDbType.NVarChar, 200);
                    pTen_Chuc_Danh.Value = myNL_DM_Chuc_Danh_Chi_Tiet.Ten_Chuc_Danh;
                    myCommand.Parameters.Add(pTen_Chuc_Danh);

                    SqlParameter pMa_Linh_Vuc = new SqlParameter("@Ma_Linh_Vuc", SqlDbType.Int, 4);
                    pMa_Linh_Vuc.Value = myNL_DM_Chuc_Danh_Chi_Tiet.Ma_Linh_Vuc;
                    myCommand.Parameters.Add(pMa_Linh_Vuc);


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
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Chuc_Danh_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Chuc_Danh = new SqlParameter("@Ma_Chuc_Danh", SqlDbType.Int, 4);
                        pMa_Chuc_Danh.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Chuc_Danh"];
                        myCommand.Parameters.Add(pMa_Chuc_Danh);

                        SqlParameter pTen_Chuc_Danh = new SqlParameter("@Ten_Chuc_Danh", SqlDbType.NVarChar, 200);
                        pTen_Chuc_Danh.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ten_Chuc_Danh"];
                        myCommand.Parameters.Add(pTen_Chuc_Danh);

                        SqlParameter pMa_Linh_Vuc = new SqlParameter("@Ma_Linh_Vuc", SqlDbType.Int, 4);
                        pMa_Linh_Vuc.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Linh_Vuc"];
                        myCommand.Parameters.Add(pMa_Linh_Vuc);


                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int? Ma_Chuc_Danh = null, string Ten_Chuc_Danh = null, int? Ma_Linh_Vuc = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Chuc_Danh_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Chuc_Danh = new SqlParameter("@Ma_Chuc_Danh", SqlDbType.Int, 4);
                    pMa_Chuc_Danh.Value = Ma_Chuc_Danh;
                    myCommand.Parameters.Add(pMa_Chuc_Danh);

                    SqlParameter pTen_Chuc_Danh = new SqlParameter("@Ten_Chuc_Danh", SqlDbType.NVarChar, 200);
                    pTen_Chuc_Danh.Value = Ten_Chuc_Danh;
                    myCommand.Parameters.Add(pTen_Chuc_Danh);

                    SqlParameter pMa_Linh_Vuc = new SqlParameter("@Ma_Linh_Vuc", SqlDbType.Int, 4);
                    pMa_Linh_Vuc.Value = Ma_Linh_Vuc;
                    myCommand.Parameters.Add(pMa_Linh_Vuc);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Ma_Chuc_Danh)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Chuc_Danh_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Chuc_Danh = new SqlParameter("@Ma_Chuc_Danh", SqlDbType.Int, 4);
                    pMa_Chuc_Danh.Value = Ma_Chuc_Danh;
                    myCommand.Parameters.Add(pMa_Chuc_Danh);

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
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Chuc_Danh_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Chuc_Danh_Danh_Sach");
                    return myDataSet.Tables["NL_DM_Chuc_Danh_Danh_Sach"];
                }
            }
        }
        #endregion


    }
    #endregion
}