using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region NL_DM_Loai_Quan_He_Details
    public class NL_DM_Loai_Quan_He_Chi_Tiet
    {
        public int? Loai_Quan_He = null; // Loại quan hệ (bố, mẹ, anh chị)
        public string Ten_Quan_He = null; // Tên quan hệ
        public int? Kieu_Quan_He = null; // 0:Về bản thân;1:Về bên vợ/chồng
    }
    #endregion
    #region NL_DM_Loai_Quan_He
    public class NL_DM_Loai_Quan_He
    {
        private string ConnectionString;
        public NL_DM_Loai_Quan_He(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_DM_Loai_Quan_He_Chi_Tiet Lay(int Loai_Quan_He)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Loai_Quan_He_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pLoai_Quan_He = new SqlParameter("@Loai_Quan_He", SqlDbType.Int, 4);
                    pLoai_Quan_He.Value = Loai_Quan_He;
                    myCommand.Parameters.Add(pLoai_Quan_He);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Loai_Quan_He_Chi_Tiet");
                    NL_DM_Loai_Quan_He_Chi_Tiet myNL_DM_Loai_Quan_He_Chi_Tiet = new NL_DM_Loai_Quan_He_Chi_Tiet();
                    if (myDataSet.Tables["NL_DM_Loai_Quan_He_Chi_Tiet"] != null)
                    {
                        myNL_DM_Loai_Quan_He_Chi_Tiet.Loai_Quan_He = Loai_Quan_He;
                        myNL_DM_Loai_Quan_He_Chi_Tiet.Ten_Quan_He = myDataSet.Tables["NL_DM_Loai_Quan_He_Chi_Tiet"].Rows[0]["Ten_Quan_He"] != DBNull.Value ? (string)myDataSet.Tables["NL_DM_Loai_Quan_He_Chi_Tiet"].Rows[0]["Ten_Quan_He"] : (string)null;
                        myNL_DM_Loai_Quan_He_Chi_Tiet.Kieu_Quan_He = myDataSet.Tables["NL_DM_Loai_Quan_He_Chi_Tiet"].Rows[0]["Kieu_Quan_He"] != DBNull.Value ? (int?)myDataSet.Tables["NL_DM_Loai_Quan_He_Chi_Tiet"].Rows[0]["Kieu_Quan_He"] : (int?)null;
                    }
                    return myNL_DM_Loai_Quan_He_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Loai_Quan_He = null, string Ten_Quan_He = null, int? Kieu_Quan_He = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Loai_Quan_He_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pLoai_Quan_He = new SqlParameter("@Loai_Quan_He", SqlDbType.Int, 4);
                    pLoai_Quan_He.Value = Loai_Quan_He;
                    myCommand.Parameters.Add(pLoai_Quan_He);

                    SqlParameter pTen_Quan_He = new SqlParameter("@Ten_Quan_He", SqlDbType.NVarChar, 150);
                    pTen_Quan_He.Value = Ten_Quan_He;
                    myCommand.Parameters.Add(pTen_Quan_He);

                    SqlParameter pKieu_Quan_He = new SqlParameter("@Kieu_Quan_He", SqlDbType.Int, 4);
                    pKieu_Quan_He.Value = Kieu_Quan_He;
                    myCommand.Parameters.Add(pKieu_Quan_He);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int? Loai_Quan_He = null, string Ten_Quan_He = null, int? Kieu_Quan_He = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Loai_Quan_He_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pLoai_Quan_He = new SqlParameter("@Loai_Quan_He", SqlDbType.Int, 4);
                    pLoai_Quan_He.Value = Loai_Quan_He;
                    myCommand.Parameters.Add(pLoai_Quan_He);

                    SqlParameter pTen_Quan_He = new SqlParameter("@Ten_Quan_He", SqlDbType.NVarChar, 150);
                    pTen_Quan_He.Value = Ten_Quan_He;
                    myCommand.Parameters.Add(pTen_Quan_He);

                    SqlParameter pKieu_Quan_He = new SqlParameter("@Kieu_Quan_He", SqlDbType.Int, 4);
                    pKieu_Quan_He.Value = Kieu_Quan_He;
                    myCommand.Parameters.Add(pKieu_Quan_He);



                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(NL_DM_Loai_Quan_He_Chi_Tiet myNL_DM_Loai_Quan_He_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Loai_Quan_He_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pLoai_Quan_He = new SqlParameter("@Loai_Quan_He", SqlDbType.Int, 4);
                    pLoai_Quan_He.Value = myNL_DM_Loai_Quan_He_Chi_Tiet.Loai_Quan_He;
                    myCommand.Parameters.Add(pLoai_Quan_He);

                    SqlParameter pTen_Quan_He = new SqlParameter("@Ten_Quan_He", SqlDbType.NVarChar, 150);
                    pTen_Quan_He.Value = myNL_DM_Loai_Quan_He_Chi_Tiet.Ten_Quan_He;
                    myCommand.Parameters.Add(pTen_Quan_He);

                    SqlParameter pKieu_Quan_He = new SqlParameter("@Kieu_Quan_He", SqlDbType.Int, 4);
                    pKieu_Quan_He.Value = myNL_DM_Loai_Quan_He_Chi_Tiet.Kieu_Quan_He;
                    myCommand.Parameters.Add(pKieu_Quan_He);


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
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Loai_Quan_He_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pLoai_Quan_He = new SqlParameter("@Loai_Quan_He", SqlDbType.Int, 4);
                        pLoai_Quan_He.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Loai_Quan_He"];
                        myCommand.Parameters.Add(pLoai_Quan_He);

                        SqlParameter pTen_Quan_He = new SqlParameter("@Ten_Quan_He", SqlDbType.NVarChar, 150);
                        pTen_Quan_He.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ten_Quan_He"];
                        myCommand.Parameters.Add(pTen_Quan_He);

                        SqlParameter pKieu_Quan_He = new SqlParameter("@Kieu_Quan_He", SqlDbType.Int, 4);
                        pKieu_Quan_He.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Kieu_Quan_He"];
                        myCommand.Parameters.Add(pKieu_Quan_He);


                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int? Loai_Quan_He = null, string Ten_Quan_He = null, int? Kieu_Quan_He = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Loai_Quan_He_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pLoai_Quan_He = new SqlParameter("@Loai_Quan_He", SqlDbType.Int, 4);
                    pLoai_Quan_He.Value = Loai_Quan_He;
                    myCommand.Parameters.Add(pLoai_Quan_He);

                    SqlParameter pTen_Quan_He = new SqlParameter("@Ten_Quan_He", SqlDbType.NVarChar, 150);
                    pTen_Quan_He.Value = Ten_Quan_He;
                    myCommand.Parameters.Add(pTen_Quan_He);

                    SqlParameter pKieu_Quan_He = new SqlParameter("@Kieu_Quan_He", SqlDbType.Int, 4);
                    pKieu_Quan_He.Value = Kieu_Quan_He;
                    myCommand.Parameters.Add(pKieu_Quan_He);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Loai_Quan_He)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Loai_Quan_He_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pLoai_Quan_He = new SqlParameter("@Loai_Quan_He", SqlDbType.Int, 4);
                    pLoai_Quan_He.Value = Loai_Quan_He;
                    myCommand.Parameters.Add(pLoai_Quan_He);

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
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Loai_Quan_He_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Loai_Quan_He_Danh_Sach");
                    return myDataSet.Tables["NL_DM_Loai_Quan_He_Danh_Sach"];
                }
            }
        }
        #endregion


    }
    #endregion
}