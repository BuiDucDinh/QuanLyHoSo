
using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region HT_Vai_Tro_Du_An_Details
    public class HT_Vai_Tro_Du_An_Chi_Tiet
    {
        public int Ma_Vai_Tro_Du_An;
        public int Ma_Vai_Tro;
        public string Ma_Du_An;
    }
    #endregion
    #region HT_Vai_Tro_Du_An
    public class HT_Vai_Tro_Du_An
    {
        private string ConnectionString;
        public HT_Vai_Tro_Du_An(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public HT_Vai_Tro_Du_An_Chi_Tiet Lay(int Ma_Vai_Tro_Du_An)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Vai_Tro_Du_An_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Vai_Tro_Du_An = new SqlParameter("@Ma_Vai_Tro_Du_An", SqlDbType.Int, 4);
                    pMa_Vai_Tro_Du_An.Value = Ma_Vai_Tro_Du_An;
                    myCommand.Parameters.Add(pMa_Vai_Tro_Du_An);

                    SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Vai_Tro.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pMa_Vai_Tro);

                    SqlParameter pMa_Du_An = new SqlParameter("@Ma_Du_An", SqlDbType.VarChar, 2);
                    pMa_Du_An.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pMa_Du_An);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();


                    HT_Vai_Tro_Du_An_Chi_Tiet myHT_Vai_Tro_Du_An_Chi_Tiet = new HT_Vai_Tro_Du_An_Chi_Tiet();
                    myHT_Vai_Tro_Du_An_Chi_Tiet.Ma_Vai_Tro_Du_An = Ma_Vai_Tro_Du_An;
                    myHT_Vai_Tro_Du_An_Chi_Tiet.Ma_Vai_Tro = (int)pMa_Vai_Tro.Value;
                    myHT_Vai_Tro_Du_An_Chi_Tiet.Ma_Du_An = (string)pMa_Du_An.Value;
                    return myHT_Vai_Tro_Du_An_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public int Them(int Ma_Vai_Tro_Du_An, int Ma_Vai_Tro, string Ma_Du_An)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Vai_Tro_Du_An_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Vai_Tro_Du_An = new SqlParameter("@Ma_Vai_Tro_Du_An", SqlDbType.Int, 4);
                    pMa_Vai_Tro_Du_An.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pMa_Vai_Tro_Du_An);

                    SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Vai_Tro.Value = Ma_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Vai_Tro);

                    SqlParameter pMa_Du_An = new SqlParameter("@Ma_Du_An", SqlDbType.VarChar, 2);
                    pMa_Du_An.Value = Ma_Du_An;
                    myCommand.Parameters.Add(pMa_Du_An);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    return (int)pMa_Vai_Tro_Du_An.Value;
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int Ma_Vai_Tro_Du_An, int Ma_Vai_Tro, string Ma_Du_An)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Vai_Tro_Du_An_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Vai_Tro_Du_An = new SqlParameter("@Ma_Vai_Tro_Du_An", SqlDbType.Int, 4);
                    pMa_Vai_Tro_Du_An.Value = Ma_Vai_Tro_Du_An;
                    myCommand.Parameters.Add(pMa_Vai_Tro_Du_An);

                    SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Vai_Tro.Value = Ma_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Vai_Tro);

                    SqlParameter pMa_Du_An = new SqlParameter("@Ma_Du_An", SqlDbType.VarChar, 2);
                    pMa_Du_An.Value = Ma_Du_An;
                    myCommand.Parameters.Add(pMa_Du_An);



                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(HT_Vai_Tro_Du_An_Chi_Tiet myHT_Vai_Tro_Du_An_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Vai_Tro_Du_An_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Vai_Tro_Du_An = new SqlParameter("@Ma_Vai_Tro_Du_An", SqlDbType.Int, 4);
                    pMa_Vai_Tro_Du_An.Value = myHT_Vai_Tro_Du_An_Chi_Tiet.Ma_Vai_Tro_Du_An;
                    myCommand.Parameters.Add(pMa_Vai_Tro_Du_An);

                    SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Vai_Tro.Value = myHT_Vai_Tro_Du_An_Chi_Tiet.Ma_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Vai_Tro);

                    SqlParameter pMa_Du_An = new SqlParameter("@Ma_Du_An", SqlDbType.VarChar, 2);
                    pMa_Du_An.Value = myHT_Vai_Tro_Du_An_Chi_Tiet.Ma_Du_An;
                    myCommand.Parameters.Add(pMa_Du_An);


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
                using (SqlCommand myCommand = new SqlCommand("HT_Vai_Tro_Du_An_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Vai_Tro_Du_An = new SqlParameter("@Ma_Vai_Tro_Du_An", SqlDbType.Int, 4);
                        pMa_Vai_Tro_Du_An.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Vai_Tro_Du_An"];
                        myCommand.Parameters.Add(pMa_Vai_Tro_Du_An);

                        SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                        pMa_Vai_Tro.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Vai_Tro"];
                        myCommand.Parameters.Add(pMa_Vai_Tro);

                        SqlParameter pMa_Du_An = new SqlParameter("@Ma_Du_An", SqlDbType.VarChar, 2);
                        pMa_Du_An.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ma_Du_An"];
                        myCommand.Parameters.Add(pMa_Du_An);


                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int Ma_Vai_Tro_Du_An, int Ma_Vai_Tro, string Ma_Du_An)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Vai_Tro_Du_An_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Vai_Tro_Du_An = new SqlParameter("@Ma_Vai_Tro_Du_An", SqlDbType.Int, 4);
                    pMa_Vai_Tro_Du_An.Value = Ma_Vai_Tro_Du_An;
                    myCommand.Parameters.Add(pMa_Vai_Tro_Du_An);

                    SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Vai_Tro.Value = Ma_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Vai_Tro);

                    SqlParameter pMa_Du_An = new SqlParameter("@Ma_Du_An", SqlDbType.VarChar, 2);
                    pMa_Du_An.Value = Ma_Du_An;
                    myCommand.Parameters.Add(pMa_Du_An);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Ma_Vai_Tro_Du_An)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Vai_Tro_Du_An_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Vai_Tro_Du_An = new SqlParameter("@Ma_Vai_Tro_Du_An", SqlDbType.Int, 4);
                    pMa_Vai_Tro_Du_An.Value = Ma_Vai_Tro_Du_An;
                    myCommand.Parameters.Add(pMa_Vai_Tro_Du_An);

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
                using (SqlCommand myCommand = new SqlCommand("HT_Vai_Tro_Du_An_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Vai_Tro_Du_An_Danh_Sach");
                    return myDataSet.Tables["HT_Vai_Tro_Du_An_Danh_Sach"];
                }
            }
        }
        #endregion

        #region Lay_Boi_HT_Du_An
        public DataTable Lay_Boi_HT_Du_An(string Ma_Du_An)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Vai_Tro_Du_An_Lay_Boi_HT_Du_An", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Du_An = new SqlParameter("@Ma_Du_An", SqlDbType.VarChar, 2);
                    pMa_Du_An.Value = Ma_Du_An;
                    myCommand.Parameters.Add(pMa_Du_An);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Vai_Tro_Du_An_Lay_Boi_HT_Du_An");
                    return myDataSet.Tables["HT_Vai_Tro_Du_An_Lay_Boi_HT_Du_An"];
                }
            }
        }
        #endregion
        #region Lay_Boi_HT_Vai_Tro
        public DataTable Lay_Boi_HT_Vai_Tro(int Ma_Vai_Tro)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Vai_Tro_Du_An_Lay_Boi_HT_Vai_Tro", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Vai_Tro.Value = Ma_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Vai_Tro);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Vai_Tro_Du_An_Lay_Boi_HT_Vai_Tro");
                    return myDataSet.Tables["HT_Vai_Tro_Du_An_Lay_Boi_HT_Vai_Tro"];
                }
            }
        }
        #endregion

        //new
        #region Lay_Boi_HT_Du_An_Chon
        public DataTable Lay_Boi_HT_Du_An_Chon(int Ma_Vai_Tro, bool Chon)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Vai_Tro_Du_An_Lay_Boi_HT_Du_An_Chon", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Vai_Tro.Value = Ma_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Vai_Tro);

                    SqlParameter pChon = new SqlParameter("@Chon", SqlDbType.Bit);
                    pChon.Value = Chon;
                    myCommand.Parameters.Add(pChon);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Vai_Tro_Du_An_Lay_Boi_HT_Du_An_Chon");
                    return myDataSet.Tables["HT_Vai_Tro_Du_An_Lay_Boi_HT_Du_An_Chon"];
                }
            }
        }
        #endregion
        public bool checkRole(string Ma_Du_An, string MaND)
        {
            string sql = "select distinct Ma_Du_An from HT_Vai_Tro_Du_An where Ma_Vai_Tro in (SELECT Ma_Vai_Tro FROM HT_Nguoi_Dung_Vai_Tro NVT where NVT.Ma_Nguoi_Dung = " + MaND + ")";
            DataTable dt = Sys_Common.RunTableBySQL(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["Ma_Du_An"].ToString().Equals(Ma_Du_An)) return true;
                }
            }
            return false;
        }
    }
    #endregion
}