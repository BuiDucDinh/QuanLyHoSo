using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region NL_DM_Hop_Dong_Details
    public class NL_DM_Hop_Dong_Chi_Tiet
    {
        public int? Ma_Hop_Dong = null; // Mã hợp đồng
        public string Ten_Hop_Dong = null; // Tên hợp đồng
        public int? Loai_Hop_Dong = null; // Loại hợp đồng
    }
    #endregion
    #region NL_DM_Hop_Dong
    public class NL_DM_Hop_Dong
    {
        private string ConnectionString;
        public NL_DM_Hop_Dong(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_DM_Hop_Dong_Chi_Tiet Lay(int Ma_Hop_Dong)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Hop_Dong_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Hop_Dong = new SqlParameter("@Ma_Hop_Dong", SqlDbType.Int, 4);
                    pMa_Hop_Dong.Value = Ma_Hop_Dong;
                    myCommand.Parameters.Add(pMa_Hop_Dong);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Hop_Dong_Chi_Tiet");
                    NL_DM_Hop_Dong_Chi_Tiet myNL_DM_Hop_Dong_Chi_Tiet = new NL_DM_Hop_Dong_Chi_Tiet();
                    if (myDataSet.Tables["NL_DM_Hop_Dong_Chi_Tiet"] != null)
                    {
                        myNL_DM_Hop_Dong_Chi_Tiet.Ma_Hop_Dong = Ma_Hop_Dong;
                        myNL_DM_Hop_Dong_Chi_Tiet.Ten_Hop_Dong = myDataSet.Tables["NL_DM_Hop_Dong_Chi_Tiet"].Rows[0]["Ten_Hop_Dong"] != DBNull.Value ? (string)myDataSet.Tables["NL_DM_Hop_Dong_Chi_Tiet"].Rows[0]["Ten_Hop_Dong"] : (string)null;
                        myNL_DM_Hop_Dong_Chi_Tiet.Loai_Hop_Dong = myDataSet.Tables["NL_DM_Hop_Dong_Chi_Tiet"].Rows[0]["Loai_Hop_Dong"] != DBNull.Value ? (int?)myDataSet.Tables["NL_DM_Hop_Dong_Chi_Tiet"].Rows[0]["Loai_Hop_Dong"] : (int?)null;
                    }
                    return myNL_DM_Hop_Dong_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Ma_Hop_Dong = null, string Ten_Hop_Dong = null, int? Loai_Hop_Dong = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Hop_Dong_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Hop_Dong = new SqlParameter("@Ma_Hop_Dong", SqlDbType.Int, 4);
                    pMa_Hop_Dong.Value = Ma_Hop_Dong;
                    myCommand.Parameters.Add(pMa_Hop_Dong);

                    SqlParameter pTen_Hop_Dong = new SqlParameter("@Ten_Hop_Dong", SqlDbType.NVarChar, 200);
                    pTen_Hop_Dong.Value = Ten_Hop_Dong;
                    myCommand.Parameters.Add(pTen_Hop_Dong);

                    SqlParameter pLoai_Hop_Dong = new SqlParameter("@Loai_Hop_Dong", SqlDbType.Int, 4);
                    pLoai_Hop_Dong.Value = Loai_Hop_Dong;
                    myCommand.Parameters.Add(pLoai_Hop_Dong);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int? Ma_Hop_Dong = null, string Ten_Hop_Dong = null, int? Loai_Hop_Dong = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Hop_Dong_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Hop_Dong = new SqlParameter("@Ma_Hop_Dong", SqlDbType.Int, 4);
                    pMa_Hop_Dong.Value = Ma_Hop_Dong;
                    myCommand.Parameters.Add(pMa_Hop_Dong);

                    SqlParameter pTen_Hop_Dong = new SqlParameter("@Ten_Hop_Dong", SqlDbType.NVarChar, 200);
                    pTen_Hop_Dong.Value = Ten_Hop_Dong;
                    myCommand.Parameters.Add(pTen_Hop_Dong);

                    SqlParameter pLoai_Hop_Dong = new SqlParameter("@Loai_Hop_Dong", SqlDbType.Int, 4);
                    pLoai_Hop_Dong.Value = Loai_Hop_Dong;
                    myCommand.Parameters.Add(pLoai_Hop_Dong);



                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(NL_DM_Hop_Dong_Chi_Tiet myNL_DM_Hop_Dong_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Hop_Dong_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Hop_Dong = new SqlParameter("@Ma_Hop_Dong", SqlDbType.Int, 4);
                    pMa_Hop_Dong.Value = myNL_DM_Hop_Dong_Chi_Tiet.Ma_Hop_Dong;
                    myCommand.Parameters.Add(pMa_Hop_Dong);

                    SqlParameter pTen_Hop_Dong = new SqlParameter("@Ten_Hop_Dong", SqlDbType.NVarChar, 200);
                    pTen_Hop_Dong.Value = myNL_DM_Hop_Dong_Chi_Tiet.Ten_Hop_Dong;
                    myCommand.Parameters.Add(pTen_Hop_Dong);

                    SqlParameter pLoai_Hop_Dong = new SqlParameter("@Loai_Hop_Dong", SqlDbType.Int, 4);
                    pLoai_Hop_Dong.Value = myNL_DM_Hop_Dong_Chi_Tiet.Loai_Hop_Dong;
                    myCommand.Parameters.Add(pLoai_Hop_Dong);


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
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Hop_Dong_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Hop_Dong = new SqlParameter("@Ma_Hop_Dong", SqlDbType.Int, 4);
                        pMa_Hop_Dong.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Hop_Dong"];
                        myCommand.Parameters.Add(pMa_Hop_Dong);

                        SqlParameter pTen_Hop_Dong = new SqlParameter("@Ten_Hop_Dong", SqlDbType.NVarChar, 200);
                        pTen_Hop_Dong.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ten_Hop_Dong"];
                        myCommand.Parameters.Add(pTen_Hop_Dong);

                        SqlParameter pLoai_Hop_Dong = new SqlParameter("@Loai_Hop_Dong", SqlDbType.Int, 4);
                        pLoai_Hop_Dong.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Loai_Hop_Dong"];
                        myCommand.Parameters.Add(pLoai_Hop_Dong);


                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int? Ma_Hop_Dong = null, string Ten_Hop_Dong = null, int? Loai_Hop_Dong = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Hop_Dong_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Hop_Dong = new SqlParameter("@Ma_Hop_Dong", SqlDbType.Int, 4);
                    pMa_Hop_Dong.Value = Ma_Hop_Dong;
                    myCommand.Parameters.Add(pMa_Hop_Dong);

                    SqlParameter pTen_Hop_Dong = new SqlParameter("@Ten_Hop_Dong", SqlDbType.NVarChar, 200);
                    pTen_Hop_Dong.Value = Ten_Hop_Dong;
                    myCommand.Parameters.Add(pTen_Hop_Dong);

                    SqlParameter pLoai_Hop_Dong = new SqlParameter("@Loai_Hop_Dong", SqlDbType.Int, 4);
                    pLoai_Hop_Dong.Value = Loai_Hop_Dong;
                    myCommand.Parameters.Add(pLoai_Hop_Dong);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Ma_Hop_Dong)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Hop_Dong_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Hop_Dong = new SqlParameter("@Ma_Hop_Dong", SqlDbType.Int, 4);
                    pMa_Hop_Dong.Value = Ma_Hop_Dong;
                    myCommand.Parameters.Add(pMa_Hop_Dong);

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
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Hop_Dong_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Hop_Dong_Danh_Sach");
                    return myDataSet.Tables["NL_DM_Hop_Dong_Danh_Sach"];
                }
            }
        }
        #endregion


    }
    #endregion
}