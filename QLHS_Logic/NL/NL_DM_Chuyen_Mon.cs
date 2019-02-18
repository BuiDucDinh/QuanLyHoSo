using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region NL_DM_Chuyen_Mon_Details
    public class NL_DM_Chuyen_Mon_Chi_Tiet
    {
        public int? Ma_Chuyen_Mon = null; // Mã chuyên môn
        public string Ten_Chuyen_Mon = null; // Tên chuyên môn
        public string Loai_Chuyen_Mon = null; // Loại A, B, C,D
        public int? Cap_Do = null;
        public int? Linh_Vuc = null;
    }
    #endregion
    #region NL_DM_Chuyen_Mon
    public class NL_DM_Chuyen_Mon
    {
        private string ConnectionString;
        public NL_DM_Chuyen_Mon(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_DM_Chuyen_Mon_Chi_Tiet Lay(int Ma_Chuyen_Mon)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Chuyen_Mon_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Chuyen_Mon = new SqlParameter("@Ma_Chuyen_Mon", SqlDbType.Int, 4);
                    pMa_Chuyen_Mon.Value = Ma_Chuyen_Mon;
                    myCommand.Parameters.Add(pMa_Chuyen_Mon);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Chuyen_Mon_Chi_Tiet");
                    NL_DM_Chuyen_Mon_Chi_Tiet myNL_DM_Chuyen_Mon_Chi_Tiet = new NL_DM_Chuyen_Mon_Chi_Tiet();
                    if (myDataSet.Tables["NL_DM_Chuyen_Mon_Chi_Tiet"] != null)
                    {
                        myNL_DM_Chuyen_Mon_Chi_Tiet.Ma_Chuyen_Mon = Ma_Chuyen_Mon;
                        myNL_DM_Chuyen_Mon_Chi_Tiet.Ten_Chuyen_Mon = myDataSet.Tables["NL_DM_Chuyen_Mon_Chi_Tiet"].Rows[0]["Ten_Chuyen_Mon"] != DBNull.Value ? (string)myDataSet.Tables["NL_DM_Chuyen_Mon_Chi_Tiet"].Rows[0]["Ten_Chuyen_Mon"] : (string)null;
                        myNL_DM_Chuyen_Mon_Chi_Tiet.Loai_Chuyen_Mon = myDataSet.Tables["NL_DM_Chuyen_Mon_Chi_Tiet"].Rows[0]["Loai_Chuyen_Mon"] != DBNull.Value ? (string)myDataSet.Tables["NL_DM_Chuyen_Mon_Chi_Tiet"].Rows[0]["Loai_Chuyen_Mon"] : (string)null;
                        myNL_DM_Chuyen_Mon_Chi_Tiet.Cap_Do = myDataSet.Tables["NL_DM_Chuyen_Mon_Chi_Tiet"].Rows[0]["Cap_Do"] != DBNull.Value ? (int?)myDataSet.Tables["NL_DM_Chuyen_Mon_Chi_Tiet"].Rows[0]["Cap_Do"] : (int?)null;
                        myNL_DM_Chuyen_Mon_Chi_Tiet.Linh_Vuc = myDataSet.Tables["NL_DM_Chuyen_Mon_Chi_Tiet"].Rows[0]["Linh_Vuc"] != DBNull.Value ? (int?)myDataSet.Tables["NL_DM_Chuyen_Mon_Chi_Tiet"].Rows[0]["Linh_Vuc"] : (int?)null;
                    }
                    return myNL_DM_Chuyen_Mon_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Ma_Chuyen_Mon = null, string Ten_Chuyen_Mon = null, string Loai_Chuyen_Mon = null, int? Cap_Do = null, int? Linh_Vuc=null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Chuyen_Mon_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Chuyen_Mon = new SqlParameter("@Ma_Chuyen_Mon", SqlDbType.Int, 4);
                    pMa_Chuyen_Mon.Value = Ma_Chuyen_Mon;
                    myCommand.Parameters.Add(pMa_Chuyen_Mon);

                    SqlParameter pTen_Chuyen_Mon = new SqlParameter("@Ten_Chuyen_Mon", SqlDbType.NVarChar, 200);
                    pTen_Chuyen_Mon.Value = Ten_Chuyen_Mon;
                    myCommand.Parameters.Add(pTen_Chuyen_Mon);

                    SqlParameter pLoai_Chuyen_Mon = new SqlParameter("@Loai_Chuyen_Mon", SqlDbType.Char, 1);
                    pLoai_Chuyen_Mon.Value = Loai_Chuyen_Mon;
                    myCommand.Parameters.Add(pLoai_Chuyen_Mon);

                    SqlParameter pCap_Do = new SqlParameter("@Cap_Do", SqlDbType.Int, 4);
                    pCap_Do.Value = Cap_Do;
                    myCommand.Parameters.Add(pCap_Do);


                    SqlParameter pLinh_Vuc = new SqlParameter("@Linh_Vuc", SqlDbType.Int, 4);
                    pLinh_Vuc.Value = Linh_Vuc;
                    myCommand.Parameters.Add(pLinh_Vuc);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int? Ma_Chuyen_Mon = null, string Ten_Chuyen_Mon = null, string Loai_Chuyen_Mon = null, int? Cap_Do = null, int? Linh_Vuc = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Chuyen_Mon_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Chuyen_Mon = new SqlParameter("@Ma_Chuyen_Mon", SqlDbType.Int, 4);
                    pMa_Chuyen_Mon.Value = Ma_Chuyen_Mon;
                    myCommand.Parameters.Add(pMa_Chuyen_Mon);

                    SqlParameter pTen_Chuyen_Mon = new SqlParameter("@Ten_Chuyen_Mon", SqlDbType.NVarChar, 200);
                    pTen_Chuyen_Mon.Value = Ten_Chuyen_Mon;
                    myCommand.Parameters.Add(pTen_Chuyen_Mon);

                    SqlParameter pLoai_Chuyen_Mon = new SqlParameter("@Loai_Chuyen_Mon", SqlDbType.Char, 1);
                    pLoai_Chuyen_Mon.Value = Loai_Chuyen_Mon;
                    myCommand.Parameters.Add(pLoai_Chuyen_Mon);

                    SqlParameter pCap_Do = new SqlParameter("@Cap_Do", SqlDbType.Int, 4);
                    pCap_Do.Value = Cap_Do;
                    myCommand.Parameters.Add(pCap_Do);

                    SqlParameter pLinh_Vuc = new SqlParameter("@Linh_Vuc", SqlDbType.Int, 4);
                    pLinh_Vuc.Value = Linh_Vuc;
                    myCommand.Parameters.Add(pLinh_Vuc);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(NL_DM_Chuyen_Mon_Chi_Tiet myNL_DM_Chuyen_Mon_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Chuyen_Mon_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Chuyen_Mon = new SqlParameter("@Ma_Chuyen_Mon", SqlDbType.Int, 4);
                    pMa_Chuyen_Mon.Value = myNL_DM_Chuyen_Mon_Chi_Tiet.Ma_Chuyen_Mon;
                    myCommand.Parameters.Add(pMa_Chuyen_Mon);

                    SqlParameter pTen_Chuyen_Mon = new SqlParameter("@Ten_Chuyen_Mon", SqlDbType.NVarChar, 200);
                    pTen_Chuyen_Mon.Value = myNL_DM_Chuyen_Mon_Chi_Tiet.Ten_Chuyen_Mon;
                    myCommand.Parameters.Add(pTen_Chuyen_Mon);

                    SqlParameter pLoai_Chuyen_Mon = new SqlParameter("@Loai_Chuyen_Mon", SqlDbType.Char, 1);
                    pLoai_Chuyen_Mon.Value = myNL_DM_Chuyen_Mon_Chi_Tiet.Loai_Chuyen_Mon;
                    myCommand.Parameters.Add(pLoai_Chuyen_Mon);

                    SqlParameter pCap_Do = new SqlParameter("@Cap_Do", SqlDbType.Int, 4);
                    pCap_Do.Value = myNL_DM_Chuyen_Mon_Chi_Tiet.Cap_Do;
                    myCommand.Parameters.Add(pCap_Do);

                    SqlParameter pLinh_Vuc = new SqlParameter("@Linh_Vuc", SqlDbType.Int, 4);
                    pLinh_Vuc.Value = myNL_DM_Chuyen_Mon_Chi_Tiet.Linh_Vuc;
                    myCommand.Parameters.Add(pLinh_Vuc);      

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
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Chuyen_Mon_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Chuyen_Mon = new SqlParameter("@Ma_Chuyen_Mon", SqlDbType.Int, 4);
                        pMa_Chuyen_Mon.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Chuyen_Mon"];
                        myCommand.Parameters.Add(pMa_Chuyen_Mon);

                        SqlParameter pTen_Chuyen_Mon = new SqlParameter("@Ten_Chuyen_Mon", SqlDbType.NVarChar, 200);
                        pTen_Chuyen_Mon.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ten_Chuyen_Mon"];
                        myCommand.Parameters.Add(pTen_Chuyen_Mon);

                        SqlParameter pLoai_Chuyen_Mon = new SqlParameter("@Loai_Chuyen_Mon", SqlDbType.Char, 1);
                        pLoai_Chuyen_Mon.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Loai_Chuyen_Mon"];
                        myCommand.Parameters.Add(pLoai_Chuyen_Mon);

                        SqlParameter pCap_Do = new SqlParameter("@Cap_Do", SqlDbType.Int, 4);
                        pCap_Do.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Cap_Do"];
                        myCommand.Parameters.Add(pCap_Do);

                        SqlParameter pLinh_Vuc = new SqlParameter("@Linh_Vuc", SqlDbType.Int, 4);
                        pLinh_Vuc.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Linh_Vuc"];
                        myCommand.Parameters.Add(pLinh_Vuc);

                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int? Ma_Chuyen_Mon = null, string Ten_Chuyen_Mon = null, string Loai_Chuyen_Mon = null, int? Cap_Do = null, int? Linh_Vuc = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Chuyen_Mon_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Chuyen_Mon = new SqlParameter("@Ma_Chuyen_Mon", SqlDbType.Int, 4);
                    pMa_Chuyen_Mon.Value = Ma_Chuyen_Mon;
                    myCommand.Parameters.Add(pMa_Chuyen_Mon);

                    SqlParameter pTen_Chuyen_Mon = new SqlParameter("@Ten_Chuyen_Mon", SqlDbType.NVarChar, 200);
                    pTen_Chuyen_Mon.Value = Ten_Chuyen_Mon;
                    myCommand.Parameters.Add(pTen_Chuyen_Mon);

                    SqlParameter pLoai_Chuyen_Mon = new SqlParameter("@Loai_Chuyen_Mon", SqlDbType.Char, 1);
                    pLoai_Chuyen_Mon.Value = Loai_Chuyen_Mon;
                    myCommand.Parameters.Add(pLoai_Chuyen_Mon);

                    SqlParameter pCap_Do = new SqlParameter("@Cap_Do", SqlDbType.Int, 4);
                    pCap_Do.Value = Cap_Do;
                    myCommand.Parameters.Add(pCap_Do);

                    SqlParameter pLinh_Vuc = new SqlParameter("@Linh_Vuc", SqlDbType.Int, 4);
                    pLinh_Vuc.Value = Linh_Vuc;
                    myCommand.Parameters.Add(pLinh_Vuc);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Ma_Chuyen_Mon)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Chuyen_Mon_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Chuyen_Mon = new SqlParameter("@Ma_Chuyen_Mon", SqlDbType.Int, 4);
                    pMa_Chuyen_Mon.Value = Ma_Chuyen_Mon;
                    myCommand.Parameters.Add(pMa_Chuyen_Mon);

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
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Chuyen_Mon_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Chuyen_Mon_Danh_Sach");
                    return myDataSet.Tables["NL_DM_Chuyen_Mon_Danh_Sach"];
                }
            }
        }
        #endregion


    }
    #endregion
}