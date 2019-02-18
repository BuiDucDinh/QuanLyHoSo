using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region NL_DM_Ngach_Details
    public class NL_DM_Ngach_Chi_Tiet
    {
        public string Ma_Ngach = null; // Mã ngạch
        public string Ten_Ngach = null; // Tên ngạch
        public int? Nhom_Ngach = null;
    }
    #endregion
    #region NL_DM_Ngach
    public class NL_DM_Ngach
    {
        private string ConnectionString;
        public NL_DM_Ngach(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_DM_Ngach_Chi_Tiet Lay(string Ma_Ngach)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Ngach_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Ngach = new SqlParameter("@Ma_Ngach", SqlDbType.VarChar, 50);
                    pMa_Ngach.Value = Ma_Ngach;
                    pMa_Ngach.Direction = ParameterDirection.Input;
                    myCommand.Parameters.Add(pMa_Ngach);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Ngach_Chi_Tiet");
                    NL_DM_Ngach_Chi_Tiet myNL_DM_Ngach_Chi_Tiet = new NL_DM_Ngach_Chi_Tiet();
                    if (myDataSet.Tables["NL_DM_Ngach_Chi_Tiet"] != null)
                    {
                        myNL_DM_Ngach_Chi_Tiet.Ma_Ngach = Ma_Ngach;
                        myNL_DM_Ngach_Chi_Tiet.Ten_Ngach = myDataSet.Tables["NL_DM_Ngach_Chi_Tiet"].Rows[0]["Ten_Ngach"] != DBNull.Value ? (string)myDataSet.Tables["NL_DM_Ngach_Chi_Tiet"].Rows[0]["Ten_Ngach"] : (string)null;
                        myNL_DM_Ngach_Chi_Tiet.Nhom_Ngach = myDataSet.Tables["NL_DM_Ngach_Chi_Tiet"].Rows[0]["Nhom_Ngach"] != DBNull.Value ? (int?)myDataSet.Tables["NL_DM_Ngach_Chi_Tiet"].Rows[0]["Nhom_Ngach"] : (int?)null;
                    }
                    return myNL_DM_Ngach_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(string Ma_Ngach = null, string Ten_Ngach = null,int? Nhom_Ngach = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Ngach_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Ngach = new SqlParameter("@Ma_Ngach", SqlDbType.VarChar, 50);
                    pMa_Ngach.Value = Ma_Ngach;
                    myCommand.Parameters.Add(pMa_Ngach);

                    SqlParameter pTen_Ngach = new SqlParameter("@Ten_Ngach", SqlDbType.NVarChar, 500);
                    pTen_Ngach.Value = Ten_Ngach;
                    myCommand.Parameters.Add(pTen_Ngach);

                    SqlParameter pNhom_Ngach = new SqlParameter("@Nhom_Ngach", SqlDbType.Int, 4);
                    pNhom_Ngach.Value = Nhom_Ngach;
                    myCommand.Parameters.Add(pNhom_Ngach);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(string Ma_Ngach = null, string Ten_Ngach = null, int? Nhom_Ngach = null, string Ma_Ngach_Cu= null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Ngach_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Ngach = new SqlParameter("@Ma_Ngach", SqlDbType.VarChar, 50);
                    pMa_Ngach.Value = Ma_Ngach;
                    myCommand.Parameters.Add(pMa_Ngach);

                    SqlParameter pTen_Ngach = new SqlParameter("@Ten_Ngach", SqlDbType.NVarChar, 500);
                    pTen_Ngach.Value = Ten_Ngach;
                    myCommand.Parameters.Add(pTen_Ngach);

                    SqlParameter pNhom_Ngach = new SqlParameter("@Nhom_Ngach", SqlDbType.Int, 4);
                    pNhom_Ngach.Value = Nhom_Ngach;
                    myCommand.Parameters.Add(pNhom_Ngach);

                    SqlParameter pMa_Ngach_Cu = new SqlParameter("@Ma_Ngach_Cu", SqlDbType.VarChar, 50);
                    pMa_Ngach_Cu.Value = Ma_Ngach_Cu;
                    myCommand.Parameters.Add(pMa_Ngach_Cu);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(NL_DM_Ngach_Chi_Tiet myNL_DM_Ngach_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Ngach_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Ngach = new SqlParameter("@Ma_Ngach", SqlDbType.VarChar, 50);
                    pMa_Ngach.Value = myNL_DM_Ngach_Chi_Tiet.Ma_Ngach;
                    myCommand.Parameters.Add(pMa_Ngach);

                    SqlParameter pTen_Ngach = new SqlParameter("@Ten_Ngach", SqlDbType.NVarChar, 500);
                    pTen_Ngach.Value = myNL_DM_Ngach_Chi_Tiet.Ten_Ngach;
                    myCommand.Parameters.Add(pTen_Ngach);

                    SqlParameter pNhom_Ngach = new SqlParameter("@Nhom_Ngach", SqlDbType.Int, 4);
                    pNhom_Ngach.Value = myNL_DM_Ngach_Chi_Tiet.Nhom_Ngach;
                    myCommand.Parameters.Add(pNhom_Ngach);

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
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Ngach_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Ngach = new SqlParameter("@Ma_Ngach", SqlDbType.VarChar, 50);
                        pMa_Ngach.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ma_Ngach"];
                        myCommand.Parameters.Add(pMa_Ngach);

                        SqlParameter pTen_Ngach = new SqlParameter("@Ten_Ngach", SqlDbType.NVarChar, 500);
                        pTen_Ngach.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ten_Ngach"];
                        myCommand.Parameters.Add(pTen_Ngach);

                        SqlParameter pNhom_Ngach = new SqlParameter("@Nhom_Ngach", SqlDbType.Int, 4);
                        pNhom_Ngach.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Nhom_Ngach"];
                        myCommand.Parameters.Add(pNhom_Ngach);

                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(string Ma_Ngach = null, string Ten_Ngach = null, int?Nhom_Ngach=null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Ngach_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Ngach = new SqlParameter("@Ma_Ngach", SqlDbType.VarChar, 50);
                    pMa_Ngach.Value = Ma_Ngach;
                    myCommand.Parameters.Add(pMa_Ngach);

                    SqlParameter pTen_Ngach = new SqlParameter("@Ten_Ngach", SqlDbType.NVarChar, 500);
                    pTen_Ngach.Value = Ten_Ngach;
                    myCommand.Parameters.Add(pTen_Ngach);

                    SqlParameter pNhom_Ngach = new SqlParameter("@Nhom_Ngach", SqlDbType.Int, 4);
                    pNhom_Ngach.Value = Nhom_Ngach;
                    myCommand.Parameters.Add(pNhom_Ngach);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(string Ma_Ngach)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Ngach_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Ngach = new SqlParameter("@Ma_Ngach", SqlDbType.VarChar, 50);
                    pMa_Ngach.Value = Ma_Ngach;
                    myCommand.Parameters.Add(pMa_Ngach);

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
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Ngach_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Ngach_Danh_Sach");
                    return myDataSet.Tables["NL_DM_Ngach_Danh_Sach"];
                }
            }
        }
        #endregion


    }
    #endregion
}