using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region NL_DM_Bien_Che_Details
    public class NL_DM_Bien_Che_Chi_Tiet
    {
        public int? Ma_Bien_Che = null;
        public int? Ma_Linh_Vuc = null;
        public int? Nam = null;
        public int? Tong_So_Bien_Che = null;
        public int? Ma_Don_Vi = null;
    }
    #endregion
    #region NL_DM_Bien_Che
    public class NL_DM_Bien_Che
    {
        private string ConnectionString;
        public NL_DM_Bien_Che(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_DM_Bien_Che_Chi_Tiet Lay(int Ma_Bien_Che)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Bien_Che_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Bien_Che = new SqlParameter("@Ma_Bien_Che", SqlDbType.Int, 4);
                    pMa_Bien_Che.Value = Ma_Bien_Che;
                    myCommand.Parameters.Add(pMa_Bien_Che);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Bien_Che_Chi_Tiet");
                    NL_DM_Bien_Che_Chi_Tiet myNL_DM_Bien_Che_Chi_Tiet = new NL_DM_Bien_Che_Chi_Tiet();
                    if (myDataSet.Tables["NL_DM_Bien_Che_Chi_Tiet"] != null)
                    {
                        myNL_DM_Bien_Che_Chi_Tiet.Ma_Bien_Che = Ma_Bien_Che;
                        myNL_DM_Bien_Che_Chi_Tiet.Ma_Linh_Vuc = myDataSet.Tables["NL_DM_Bien_Che_Chi_Tiet"].Rows[0]["Ma_Linh_Vuc"] != DBNull.Value ? (int?)myDataSet.Tables["NL_DM_Bien_Che_Chi_Tiet"].Rows[0]["Ma_Linh_Vuc"] : (int?)null;
                        myNL_DM_Bien_Che_Chi_Tiet.Nam = myDataSet.Tables["NL_DM_Bien_Che_Chi_Tiet"].Rows[0]["Nam"] != DBNull.Value ? (int?)myDataSet.Tables["NL_DM_Bien_Che_Chi_Tiet"].Rows[0]["Nam"] : (int?)null;
                        myNL_DM_Bien_Che_Chi_Tiet.Tong_So_Bien_Che = myDataSet.Tables["NL_DM_Bien_Che_Chi_Tiet"].Rows[0]["Tong_So_Bien_Che"] != DBNull.Value ? (int?)myDataSet.Tables["NL_DM_Bien_Che_Chi_Tiet"].Rows[0]["Tong_So_Bien_Che"] : (int?)null;
                        myNL_DM_Bien_Che_Chi_Tiet.Ma_Don_Vi = myDataSet.Tables["NL_DM_Bien_Che_Chi_Tiet"].Rows[0]["Ma_Don_Vi"] != DBNull.Value ? (int?)myDataSet.Tables["NL_DM_Bien_Che_Chi_Tiet"].Rows[0]["Ma_Don_Vi"] : (int?)null;
                    }
                    return myNL_DM_Bien_Che_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Ma_Bien_Che = null, int? Ma_Linh_Vuc = null, int? Nam = null, int? Tong_So_Bien_Che = null, int? Ma_Don_Vi = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Bien_Che_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Bien_Che = new SqlParameter("@Ma_Bien_Che", SqlDbType.Int, 4);
                    pMa_Bien_Che.Value = Ma_Bien_Che;
                    myCommand.Parameters.Add(pMa_Bien_Che);

                    SqlParameter pMa_Linh_Vuc = new SqlParameter("@Ma_Linh_Vuc", SqlDbType.Int, 4);
                    pMa_Linh_Vuc.Value = Ma_Linh_Vuc;
                    myCommand.Parameters.Add(pMa_Linh_Vuc);

                    SqlParameter pNam = new SqlParameter("@Nam", SqlDbType.Int, 4);
                    pNam.Value = Nam;
                    myCommand.Parameters.Add(pNam);

                    SqlParameter pTong_So_Bien_Che = new SqlParameter("@Tong_So_Bien_Che", SqlDbType.Int, 4);
                    pTong_So_Bien_Che.Value = Tong_So_Bien_Che;
                    myCommand.Parameters.Add(pTong_So_Bien_Che);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int? Ma_Bien_Che = null, int? Ma_Linh_Vuc = null, int? Nam = null, int? Tong_So_Bien_Che = null, int? Ma_Don_Vi = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Bien_Che_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Bien_Che = new SqlParameter("@Ma_Bien_Che", SqlDbType.Int, 4);
                    pMa_Bien_Che.Value = Ma_Bien_Che;
                    myCommand.Parameters.Add(pMa_Bien_Che);

                    SqlParameter pMa_Linh_Vuc = new SqlParameter("@Ma_Linh_Vuc", SqlDbType.Int, 4);
                    pMa_Linh_Vuc.Value = Ma_Linh_Vuc;
                    myCommand.Parameters.Add(pMa_Linh_Vuc);

                    SqlParameter pNam = new SqlParameter("@Nam", SqlDbType.Int, 4);
                    pNam.Value = Nam;
                    myCommand.Parameters.Add(pNam);

                    SqlParameter pTong_So_Bien_Che = new SqlParameter("@Tong_So_Bien_Che", SqlDbType.Int, 4);
                    pTong_So_Bien_Che.Value = Tong_So_Bien_Che;
                    myCommand.Parameters.Add(pTong_So_Bien_Che);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);



                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(NL_DM_Bien_Che_Chi_Tiet myNL_DM_Bien_Che_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Bien_Che_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Bien_Che = new SqlParameter("@Ma_Bien_Che", SqlDbType.Int, 4);
                    pMa_Bien_Che.Value = myNL_DM_Bien_Che_Chi_Tiet.Ma_Bien_Che;
                    myCommand.Parameters.Add(pMa_Bien_Che);

                    SqlParameter pMa_Linh_Vuc = new SqlParameter("@Ma_Linh_Vuc", SqlDbType.Int, 4);
                    pMa_Linh_Vuc.Value = myNL_DM_Bien_Che_Chi_Tiet.Ma_Linh_Vuc;
                    myCommand.Parameters.Add(pMa_Linh_Vuc);

                    SqlParameter pNam = new SqlParameter("@Nam", SqlDbType.Int, 4);
                    pNam.Value = myNL_DM_Bien_Che_Chi_Tiet.Nam;
                    myCommand.Parameters.Add(pNam);

                    SqlParameter pTong_So_Bien_Che = new SqlParameter("@Tong_So_Bien_Che", SqlDbType.Int, 4);
                    pTong_So_Bien_Che.Value = myNL_DM_Bien_Che_Chi_Tiet.Tong_So_Bien_Che;
                    myCommand.Parameters.Add(pTong_So_Bien_Che);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = myNL_DM_Bien_Che_Chi_Tiet.Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);


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
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Bien_Che_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Bien_Che = new SqlParameter("@Ma_Bien_Che", SqlDbType.Int, 4);
                        pMa_Bien_Che.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Bien_Che"];
                        myCommand.Parameters.Add(pMa_Bien_Che);

                        SqlParameter pMa_Linh_Vuc = new SqlParameter("@Ma_Linh_Vuc", SqlDbType.Int, 4);
                        pMa_Linh_Vuc.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Linh_Vuc"];
                        myCommand.Parameters.Add(pMa_Linh_Vuc);

                        SqlParameter pNam = new SqlParameter("@Nam", SqlDbType.Int, 4);
                        pNam.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Nam"];
                        myCommand.Parameters.Add(pNam);

                        SqlParameter pTong_So_Bien_Che = new SqlParameter("@Tong_So_Bien_Che", SqlDbType.Int, 4);
                        pTong_So_Bien_Che.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Tong_So_Bien_Che"];
                        myCommand.Parameters.Add(pTong_So_Bien_Che);

                        SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                        pMa_Don_Vi.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Don_Vi"];
                        myCommand.Parameters.Add(pMa_Don_Vi);


                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int? Ma_Bien_Che = null, int? Ma_Linh_Vuc = null, int? Nam = null, int? Tong_So_Bien_Che = null, int? Ma_Don_Vi = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Bien_Che_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Bien_Che = new SqlParameter("@Ma_Bien_Che", SqlDbType.Int, 4);
                    pMa_Bien_Che.Value = Ma_Bien_Che;
                    myCommand.Parameters.Add(pMa_Bien_Che);

                    SqlParameter pMa_Linh_Vuc = new SqlParameter("@Ma_Linh_Vuc", SqlDbType.Int, 4);
                    pMa_Linh_Vuc.Value = Ma_Linh_Vuc;
                    myCommand.Parameters.Add(pMa_Linh_Vuc);

                    SqlParameter pNam = new SqlParameter("@Nam", SqlDbType.Int, 4);
                    pNam.Value = Nam;
                    myCommand.Parameters.Add(pNam);

                    SqlParameter pTong_So_Bien_Che = new SqlParameter("@Tong_So_Bien_Che", SqlDbType.Int, 4);
                    pTong_So_Bien_Che.Value = Tong_So_Bien_Che;
                    myCommand.Parameters.Add(pTong_So_Bien_Che);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Ma_Bien_Che)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Bien_Che_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Bien_Che = new SqlParameter("@Ma_Bien_Che", SqlDbType.Int, 4);
                    pMa_Bien_Che.Value = Ma_Bien_Che;
                    myCommand.Parameters.Add(pMa_Bien_Che);

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
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Bien_Che_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Bien_Che_Danh_Sach");
                    return myDataSet.Tables["NL_DM_Bien_Che_Danh_Sach"];
                }
            }
        }
        #endregion

        #region Lay_Boi_HT_Don_Vi_YT
        public DataTable Lay_Boi_HT_Don_Vi_YT(int Ma_Don_Vi)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Bien_Che_Lay_Boi_HT_Don_Vi_YT", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Bien_Che_Lay_Boi_HT_Don_Vi_YT");
                    return myDataSet.Tables["NL_DM_Bien_Che_Lay_Boi_HT_Don_Vi_YT"];
                }
            }
        }
        #endregion
        #region Lay_Boi_NL_DM_Linh_Vuc
        public DataTable Lay_Boi_NL_DM_Linh_Vuc(int Ma_Linh_Vuc)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_DM_Bien_Che_Lay_Boi_NL_DM_Linh_Vuc", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Linh_Vuc = new SqlParameter("@Ma_Linh_Vuc", SqlDbType.Int, 4);
                    pMa_Linh_Vuc.Value = Ma_Linh_Vuc;
                    myCommand.Parameters.Add(pMa_Linh_Vuc);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_DM_Bien_Che_Lay_Boi_NL_DM_Linh_Vuc");
                    return myDataSet.Tables["NL_DM_Bien_Che_Lay_Boi_NL_DM_Linh_Vuc"];
                }
            }
        }
        #endregion

    }
    #endregion
}