using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region NL_DM_Linh_Vuc_Details
    public class NL_DM_Linh_Vuc_Chi_Tiet
    {
        public int? Ma_Linh_Vuc = null;
        public int? Nhom_Linh_Vuc = null; // 0:Quản lý nhà nước;1:Sự nghiệp Giáo dục Đào tạo;2:Sự nghiệp Y tế Xã hội;3:Sự nghiệp VHTT;4:Sự nghiệp Khác




        public string Ten_Linh_Vuc = null; // Tên lĩnh vực
        public string Nhom_Cha = null;
    }
    #endregion
    #region NL_DM_Linh_Vuc
    public class NL_DM_Linh_Vuc
    {
        private string ConnectionString;
        public NL_DM_Linh_Vuc(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_DM_Linh_Vuc_Chi_Tiet Lay(int Ma_Linh_Vuc)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Linh_Vuc_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Linh_Vuc = new SqlParameter("@Ma_Linh_Vuc", SqlDbType.Int, 4);
                    pMa_Linh_Vuc.Value = Ma_Linh_Vuc;
                    myCommand.Parameters.Add(pMa_Linh_Vuc);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Linh_Vuc_Chi_Tiet");
                    NL_DM_Linh_Vuc_Chi_Tiet myNL_DM_Linh_Vuc_Chi_Tiet = new NL_DM_Linh_Vuc_Chi_Tiet();
                    if (myDataSet.Tables["NL_DM_Linh_Vuc_Chi_Tiet"] != null)
                    {
                        myNL_DM_Linh_Vuc_Chi_Tiet.Ma_Linh_Vuc = Ma_Linh_Vuc;
                        myNL_DM_Linh_Vuc_Chi_Tiet.Nhom_Linh_Vuc = myDataSet.Tables["NL_DM_Linh_Vuc_Chi_Tiet"].Rows[0]["Nhom_Linh_Vuc"] != DBNull.Value ? (int?)myDataSet.Tables["NL_DM_Linh_Vuc_Chi_Tiet"].Rows[0]["Nhom_Linh_Vuc"] : (int?)null;
                        myNL_DM_Linh_Vuc_Chi_Tiet.Ten_Linh_Vuc = myDataSet.Tables["NL_DM_Linh_Vuc_Chi_Tiet"].Rows[0]["Ten_Linh_Vuc"] != DBNull.Value ? (string)myDataSet.Tables["NL_DM_Linh_Vuc_Chi_Tiet"].Rows[0]["Ten_Linh_Vuc"] : (string)null;
                        myNL_DM_Linh_Vuc_Chi_Tiet.Nhom_Cha = myDataSet.Tables["NL_DM_Linh_Vuc_Chi_Tiet"].Rows[0]["Nhom_Cha"] != DBNull.Value ? (string)myDataSet.Tables["NL_DM_Linh_Vuc_Chi_Tiet"].Rows[0]["Nhom_Cha"] : (string)null;
                    }
                    return myNL_DM_Linh_Vuc_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Ma_Linh_Vuc = null, int? Nhom_Linh_Vuc = null, string Ten_Linh_Vuc = null, string Nhom_Cha = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Linh_Vuc_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Linh_Vuc = new SqlParameter("@Ma_Linh_Vuc", SqlDbType.Int, 4);
                    pMa_Linh_Vuc.Value = Ma_Linh_Vuc;
                    myCommand.Parameters.Add(pMa_Linh_Vuc);

                    SqlParameter pNhom_Linh_Vuc = new SqlParameter("@Nhom_Linh_Vuc", SqlDbType.Int, 4);
                    pNhom_Linh_Vuc.Value = Nhom_Linh_Vuc;
                    myCommand.Parameters.Add(pNhom_Linh_Vuc);

                    SqlParameter pTen_Linh_Vuc = new SqlParameter("@Ten_Linh_Vuc", SqlDbType.NVarChar, 200);
                    pTen_Linh_Vuc.Value = Ten_Linh_Vuc;
                    myCommand.Parameters.Add(pTen_Linh_Vuc);

                    SqlParameter pNhom_Cha = new SqlParameter("@Nhom_Cha", SqlDbType.NVarChar, 200);
                    pNhom_Cha.Value = Nhom_Cha;
                    myCommand.Parameters.Add(pNhom_Cha);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int? Ma_Linh_Vuc = null, int? Nhom_Linh_Vuc = null, string Ten_Linh_Vuc = null, string Nhom_Cha = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Linh_Vuc_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Linh_Vuc = new SqlParameter("@Ma_Linh_Vuc", SqlDbType.Int, 4);
                    pMa_Linh_Vuc.Value = Ma_Linh_Vuc;
                    myCommand.Parameters.Add(pMa_Linh_Vuc);

                    SqlParameter pNhom_Linh_Vuc = new SqlParameter("@Nhom_Linh_Vuc", SqlDbType.Int, 4);
                    pNhom_Linh_Vuc.Value = Nhom_Linh_Vuc;
                    myCommand.Parameters.Add(pNhom_Linh_Vuc);

                    SqlParameter pTen_Linh_Vuc = new SqlParameter("@Ten_Linh_Vuc", SqlDbType.NVarChar, 200);
                    pTen_Linh_Vuc.Value = Ten_Linh_Vuc;
                    myCommand.Parameters.Add(pTen_Linh_Vuc);


                    SqlParameter pNhom_Cha = new SqlParameter("@Nhom_Cha", SqlDbType.NVarChar, 200);
                    pNhom_Cha.Value = Nhom_Cha;
                    myCommand.Parameters.Add(pNhom_Cha);



                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(NL_DM_Linh_Vuc_Chi_Tiet myNL_DM_Linh_Vuc_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Linh_Vuc_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Linh_Vuc = new SqlParameter("@Ma_Linh_Vuc", SqlDbType.Int, 4);
                    pMa_Linh_Vuc.Value = myNL_DM_Linh_Vuc_Chi_Tiet.Ma_Linh_Vuc;
                    myCommand.Parameters.Add(pMa_Linh_Vuc);

                    SqlParameter pNhom_Linh_Vuc = new SqlParameter("@Nhom_Linh_Vuc", SqlDbType.Int, 4);
                    pNhom_Linh_Vuc.Value = myNL_DM_Linh_Vuc_Chi_Tiet.Nhom_Linh_Vuc;
                    myCommand.Parameters.Add(pNhom_Linh_Vuc);

                    SqlParameter pTen_Linh_Vuc = new SqlParameter("@Ten_Linh_Vuc", SqlDbType.NVarChar, 200);
                    pTen_Linh_Vuc.Value = myNL_DM_Linh_Vuc_Chi_Tiet.Ten_Linh_Vuc;
                    myCommand.Parameters.Add(pTen_Linh_Vuc);


                    SqlParameter pNhom_Cha = new SqlParameter("@Nhom_Cha", SqlDbType.NVarChar, 200);
                    pNhom_Cha.Value = myNL_DM_Linh_Vuc_Chi_Tiet.Nhom_Cha;
                    myCommand.Parameters.Add(pNhom_Cha);


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
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Linh_Vuc_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Linh_Vuc = new SqlParameter("@Ma_Linh_Vuc", SqlDbType.Int, 4);
                        pMa_Linh_Vuc.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Linh_Vuc"];
                        myCommand.Parameters.Add(pMa_Linh_Vuc);

                        SqlParameter pNhom_Linh_Vuc = new SqlParameter("@Nhom_Linh_Vuc", SqlDbType.Int, 4);
                        pNhom_Linh_Vuc.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Nhom_Linh_Vuc"];
                        myCommand.Parameters.Add(pNhom_Linh_Vuc);

                        SqlParameter pTen_Linh_Vuc = new SqlParameter("@Ten_Linh_Vuc", SqlDbType.NVarChar, 200);
                        pTen_Linh_Vuc.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ten_Linh_Vuc"];
                        myCommand.Parameters.Add(pTen_Linh_Vuc);

                        SqlParameter pNhom_Cha = new SqlParameter("@Nhom_Cha", SqlDbType.NVarChar, 200);
                        pNhom_Cha.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Nhom_Cha"];
                        myCommand.Parameters.Add(pNhom_Cha);


                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int? Ma_Linh_Vuc = null, int? Nhom_Linh_Vuc = null, string Ten_Linh_Vuc = null, string Nhom_Cha = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Linh_Vuc_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Linh_Vuc = new SqlParameter("@Ma_Linh_Vuc", SqlDbType.Int, 4);
                    pMa_Linh_Vuc.Value = Ma_Linh_Vuc;
                    myCommand.Parameters.Add(pMa_Linh_Vuc);

                    SqlParameter pNhom_Linh_Vuc = new SqlParameter("@Nhom_Linh_Vuc", SqlDbType.Int, 4);
                    pNhom_Linh_Vuc.Value = Nhom_Linh_Vuc;
                    myCommand.Parameters.Add(pNhom_Linh_Vuc);

                    SqlParameter pTen_Linh_Vuc = new SqlParameter("@Ten_Linh_Vuc", SqlDbType.NVarChar, 200);
                    pTen_Linh_Vuc.Value = Ten_Linh_Vuc;
                    myCommand.Parameters.Add(pTen_Linh_Vuc);

                    SqlParameter pNhom_Cha = new SqlParameter("@Nhom_Cha", SqlDbType.NVarChar, 200);
                    pNhom_Cha.Value = pNhom_Cha;
                    myCommand.Parameters.Add(pNhom_Cha);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Ma_Linh_Vuc)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Linh_Vuc_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Linh_Vuc = new SqlParameter("@Ma_Linh_Vuc", SqlDbType.Int, 4);
                    pMa_Linh_Vuc.Value = Ma_Linh_Vuc;
                    myCommand.Parameters.Add(pMa_Linh_Vuc);

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
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Linh_Vuc_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Linh_Vuc_Danh_Sach");
                    return myDataSet.Tables["NL_DM_Linh_Vuc_Danh_Sach"];
                }
            }
        }
        #endregion


    }
    #endregion
}