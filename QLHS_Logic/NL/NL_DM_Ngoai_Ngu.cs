using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region NL_DM_Ngoai_Ngu_Details
    public class NL_DM_Ngoai_Ngu_Chi_Tiet
    {
        public int? Ma_Ngoai_Ngu = null; // Mã ngoại ngữ
        public string Ten_Ngoai_Ngu = null; // Tên ngoại ngữ
        public int? Cap_Do = null; // Cấp độ
        public bool? Loai_Ngoai_Ngu = null; // 0: Loại NN khác;1:Anh Văn
        public int? Ma_Ngoai_Ngu_Cha = null;
    }
    #endregion
    #region NL_DM_Ngoai_Ngu
    public class NL_DM_Ngoai_Ngu
    {
        private string ConnectionString;
        public NL_DM_Ngoai_Ngu(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_DM_Ngoai_Ngu_Chi_Tiet Lay(int Ma_Ngoai_Ngu)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Ngoai_Ngu_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Ngoai_Ngu = new SqlParameter("@Ma_Ngoai_Ngu", SqlDbType.Int, 4);
                    pMa_Ngoai_Ngu.Value = Ma_Ngoai_Ngu;
                    myCommand.Parameters.Add(pMa_Ngoai_Ngu);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Ngoai_Ngu_Chi_Tiet");
                    NL_DM_Ngoai_Ngu_Chi_Tiet myNL_DM_Ngoai_Ngu_Chi_Tiet = new NL_DM_Ngoai_Ngu_Chi_Tiet();
                    if (myDataSet.Tables["NL_DM_Ngoai_Ngu_Chi_Tiet"] != null)
                    {
                        myNL_DM_Ngoai_Ngu_Chi_Tiet.Ma_Ngoai_Ngu = Ma_Ngoai_Ngu;
                        myNL_DM_Ngoai_Ngu_Chi_Tiet.Ten_Ngoai_Ngu = myDataSet.Tables["NL_DM_Ngoai_Ngu_Chi_Tiet"].Rows[0]["Ten_Ngoai_Ngu"] != DBNull.Value ? (string)myDataSet.Tables["NL_DM_Ngoai_Ngu_Chi_Tiet"].Rows[0]["Ten_Ngoai_Ngu"] : (string)null;
                        myNL_DM_Ngoai_Ngu_Chi_Tiet.Cap_Do = myDataSet.Tables["NL_DM_Ngoai_Ngu_Chi_Tiet"].Rows[0]["Cap_Do"] != DBNull.Value ? (int?)myDataSet.Tables["NL_DM_Ngoai_Ngu_Chi_Tiet"].Rows[0]["Cap_Do"] : (int?)null;
                        myNL_DM_Ngoai_Ngu_Chi_Tiet.Loai_Ngoai_Ngu = myDataSet.Tables["NL_DM_Ngoai_Ngu_Chi_Tiet"].Rows[0]["Loai_Ngoai_Ngu"] != DBNull.Value ? (bool?)myDataSet.Tables["NL_DM_Ngoai_Ngu_Chi_Tiet"].Rows[0]["Loai_Ngoai_Ngu"] : (bool?)null;
                        myNL_DM_Ngoai_Ngu_Chi_Tiet.Ma_Ngoai_Ngu_Cha = myDataSet.Tables["NL_DM_Ngoai_Ngu_Chi_Tiet"].Rows[0]["Ma_Ngoai_Ngu_Cha"] != DBNull.Value ? (int?)myDataSet.Tables["NL_DM_Ngoai_Ngu_Chi_Tiet"].Rows[0]["Ma_Ngoai_Ngu_Cha"] : (int?)null;

                    }
                    return myNL_DM_Ngoai_Ngu_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Ma_Ngoai_Ngu = null, string Ten_Ngoai_Ngu = null, int? Cap_Do = null, bool? Loai_Ngoai_Ngu = null, int? Ma_Ngoai_Ngu_Cha=null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Ngoai_Ngu_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Ngoai_Ngu = new SqlParameter("@Ma_Ngoai_Ngu", SqlDbType.Int, 4);
                    pMa_Ngoai_Ngu.Value = Ma_Ngoai_Ngu;
                    myCommand.Parameters.Add(pMa_Ngoai_Ngu);

                    SqlParameter pTen_Ngoai_Ngu = new SqlParameter("@Ten_Ngoai_Ngu", SqlDbType.NVarChar, 500);
                    pTen_Ngoai_Ngu.Value = Ten_Ngoai_Ngu;
                    myCommand.Parameters.Add(pTen_Ngoai_Ngu);

                    SqlParameter pCap_Do = new SqlParameter("@Cap_Do", SqlDbType.Int, 4);
                    pCap_Do.Value = Cap_Do;
                    myCommand.Parameters.Add(pCap_Do);

                    SqlParameter pLoai_Ngoai_Ngu = new SqlParameter("@Loai_Ngoai_Ngu", SqlDbType.Bit, 1);
                    pLoai_Ngoai_Ngu.Value = Loai_Ngoai_Ngu;
                    myCommand.Parameters.Add(pLoai_Ngoai_Ngu);

                    SqlParameter pMa_Ngoai_Ngu_Cha = new SqlParameter("@Ma_Ngoai_Ngu_Cha", SqlDbType.Int, 4);
                    pMa_Ngoai_Ngu_Cha.Value = Ma_Ngoai_Ngu_Cha;
                    myCommand.Parameters.Add(pMa_Ngoai_Ngu_Cha);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int? Ma_Ngoai_Ngu = null, string Ten_Ngoai_Ngu = null, int? Cap_Do = null, bool? Loai_Ngoai_Ngu = null, int? Ma_Ngoai_Ngu_Cha = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Ngoai_Ngu_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Ngoai_Ngu = new SqlParameter("@Ma_Ngoai_Ngu", SqlDbType.Int, 4);
                    pMa_Ngoai_Ngu.Value = Ma_Ngoai_Ngu;
                    myCommand.Parameters.Add(pMa_Ngoai_Ngu);

                    SqlParameter pTen_Ngoai_Ngu = new SqlParameter("@Ten_Ngoai_Ngu", SqlDbType.NVarChar, 500);
                    pTen_Ngoai_Ngu.Value = Ten_Ngoai_Ngu;
                    myCommand.Parameters.Add(pTen_Ngoai_Ngu);

                    SqlParameter pCap_Do = new SqlParameter("@Cap_Do", SqlDbType.Int, 4);
                    pCap_Do.Value = Cap_Do;
                    myCommand.Parameters.Add(pCap_Do);

                    SqlParameter pLoai_Ngoai_Ngu = new SqlParameter("@Loai_Ngoai_Ngu", SqlDbType.Bit, 1);
                    pLoai_Ngoai_Ngu.Value = Loai_Ngoai_Ngu;
                    myCommand.Parameters.Add(pLoai_Ngoai_Ngu);

                    SqlParameter pMa_Ngoai_Ngu_Cha = new SqlParameter("@Ma_Ngoai_Ngu_Cha", SqlDbType.Int, 4);
                    pMa_Ngoai_Ngu_Cha.Value = Ma_Ngoai_Ngu_Cha;
                    myCommand.Parameters.Add(pMa_Ngoai_Ngu_Cha);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(NL_DM_Ngoai_Ngu_Chi_Tiet myNL_DM_Ngoai_Ngu_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Ngoai_Ngu_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Ngoai_Ngu = new SqlParameter("@Ma_Ngoai_Ngu", SqlDbType.Int, 4);
                    pMa_Ngoai_Ngu.Value = myNL_DM_Ngoai_Ngu_Chi_Tiet.Ma_Ngoai_Ngu;
                    myCommand.Parameters.Add(pMa_Ngoai_Ngu);

                    SqlParameter pTen_Ngoai_Ngu = new SqlParameter("@Ten_Ngoai_Ngu", SqlDbType.NVarChar, 500);
                    pTen_Ngoai_Ngu.Value = myNL_DM_Ngoai_Ngu_Chi_Tiet.Ten_Ngoai_Ngu;
                    myCommand.Parameters.Add(pTen_Ngoai_Ngu);

                    SqlParameter pCap_Do = new SqlParameter("@Cap_Do", SqlDbType.Int, 4);
                    pCap_Do.Value = myNL_DM_Ngoai_Ngu_Chi_Tiet.Cap_Do;
                    myCommand.Parameters.Add(pCap_Do);

                    SqlParameter pLoai_Ngoai_Ngu = new SqlParameter("@Loai_Ngoai_Ngu", SqlDbType.Bit, 1);
                    pLoai_Ngoai_Ngu.Value = myNL_DM_Ngoai_Ngu_Chi_Tiet.Loai_Ngoai_Ngu;
                    myCommand.Parameters.Add(pLoai_Ngoai_Ngu);

                    SqlParameter pMa_Ngoai_Ngu_Cha = new SqlParameter("@Ma_Ngoai_Ngu_Cha", SqlDbType.Int, 4);
                    pMa_Ngoai_Ngu_Cha.Value = myNL_DM_Ngoai_Ngu_Chi_Tiet.Ma_Ngoai_Ngu_Cha;
                    myCommand.Parameters.Add(pMa_Ngoai_Ngu_Cha);


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
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Ngoai_Ngu_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Ngoai_Ngu = new SqlParameter("@Ma_Ngoai_Ngu", SqlDbType.Int, 4);
                        pMa_Ngoai_Ngu.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Ngoai_Ngu"];
                        myCommand.Parameters.Add(pMa_Ngoai_Ngu);

                        SqlParameter pTen_Ngoai_Ngu = new SqlParameter("@Ten_Ngoai_Ngu", SqlDbType.NVarChar, 500);
                        pTen_Ngoai_Ngu.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ten_Ngoai_Ngu"];
                        myCommand.Parameters.Add(pTen_Ngoai_Ngu);

                        SqlParameter pCap_Do = new SqlParameter("@Cap_Do", SqlDbType.Int, 4);
                        pCap_Do.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Cap_Do"];
                        myCommand.Parameters.Add(pCap_Do);

                        SqlParameter pLoai_Ngoai_Ngu = new SqlParameter("@Loai_Ngoai_Ngu", SqlDbType.Bit, 1);
                        pLoai_Ngoai_Ngu.Value = (bool)myDataSet.Tables[strTableName].Rows[i]["Loai_Ngoai_Ngu"];
                        myCommand.Parameters.Add(pLoai_Ngoai_Ngu);

                        SqlParameter pMa_Ngoai_Ngu_Cha = new SqlParameter("@Ma_Ngoai_Ngu_Cha", SqlDbType.Int, 4);
                        pMa_Ngoai_Ngu_Cha.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Ngoai_Ngu_Cha"];
                        myCommand.Parameters.Add(pMa_Ngoai_Ngu_Cha);

                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int? Ma_Ngoai_Ngu = null, string Ten_Ngoai_Ngu = null, int? Cap_Do = null, bool? Loai_Ngoai_Ngu = null, int? Ma_Ngoai_Ngu_Cha = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Ngoai_Ngu_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Ngoai_Ngu = new SqlParameter("@Ma_Ngoai_Ngu", SqlDbType.Int, 4);
                    pMa_Ngoai_Ngu.Value = Ma_Ngoai_Ngu;
                    myCommand.Parameters.Add(pMa_Ngoai_Ngu);

                    SqlParameter pTen_Ngoai_Ngu = new SqlParameter("@Ten_Ngoai_Ngu", SqlDbType.NVarChar, 500);
                    pTen_Ngoai_Ngu.Value = Ten_Ngoai_Ngu;
                    myCommand.Parameters.Add(pTen_Ngoai_Ngu);

                    SqlParameter pCap_Do = new SqlParameter("@Cap_Do", SqlDbType.Int, 4);
                    pCap_Do.Value = Cap_Do;
                    myCommand.Parameters.Add(pCap_Do);

                    SqlParameter pLoai_Ngoai_Ngu = new SqlParameter("@Loai_Ngoai_Ngu", SqlDbType.Bit, 1);
                    pLoai_Ngoai_Ngu.Value = Loai_Ngoai_Ngu;
                    myCommand.Parameters.Add(pLoai_Ngoai_Ngu);

                    SqlParameter pMa_Ngoai_Ngu_Cha = new SqlParameter("@Ma_Ngoai_Ngu_Cha", SqlDbType.Int, 4);
                    pMa_Ngoai_Ngu_Cha.Value = Ma_Ngoai_Ngu_Cha;
                    myCommand.Parameters.Add(pMa_Ngoai_Ngu_Cha);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Ma_Ngoai_Ngu)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Ngoai_Ngu_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Ngoai_Ngu = new SqlParameter("@Ma_Ngoai_Ngu", SqlDbType.Int, 4);
                    pMa_Ngoai_Ngu.Value = Ma_Ngoai_Ngu;
                    myCommand.Parameters.Add(pMa_Ngoai_Ngu);

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
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Ngoai_Ngu_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Ngoai_Ngu_Danh_Sach");
                    return myDataSet.Tables["NL_DM_Ngoai_Ngu_Danh_Sach"];
                }
            }
        }
        #endregion


    }
    #endregion
}