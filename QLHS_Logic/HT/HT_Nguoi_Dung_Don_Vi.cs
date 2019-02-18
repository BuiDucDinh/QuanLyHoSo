
using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region HT_Nguoi_Dung_Don_Vi_Details
    public class HT_Nguoi_Dung_Don_Vi_Chi_Tiet
    {
        public int Nguoi_Dung_Don_Vi; // Mã người dùng, đơn vị
        public int Ma_Nguoi_Dung; // Mã người dùng
        public int Ma_Don_Vi; // Mã đơn vị
    }
    #endregion
    #region HT_Nguoi_Dung_Don_Vi
    public class HT_Nguoi_Dung_Don_Vi
    {
        private string ConnectionString;
        public HT_Nguoi_Dung_Don_Vi(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public HT_Nguoi_Dung_Don_Vi_Chi_Tiet Lay(int Nguoi_Dung_Don_Vi)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Don_Vi_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pNguoi_Dung_Don_Vi = new SqlParameter("@Nguoi_Dung_Don_Vi", SqlDbType.Int, 4);
                    pNguoi_Dung_Don_Vi.Value = Nguoi_Dung_Don_Vi;
                    myCommand.Parameters.Add(pNguoi_Dung_Don_Vi);

                    SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pMa_Don_Vi);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();


                    HT_Nguoi_Dung_Don_Vi_Chi_Tiet myHT_Nguoi_Dung_Don_Vi_Chi_Tiet = new HT_Nguoi_Dung_Don_Vi_Chi_Tiet();
                    myHT_Nguoi_Dung_Don_Vi_Chi_Tiet.Nguoi_Dung_Don_Vi = Nguoi_Dung_Don_Vi;
                    myHT_Nguoi_Dung_Don_Vi_Chi_Tiet.Ma_Nguoi_Dung = (int)pMa_Nguoi_Dung.Value;
                    myHT_Nguoi_Dung_Don_Vi_Chi_Tiet.Ma_Don_Vi = (int)pMa_Don_Vi.Value;
                    return myHT_Nguoi_Dung_Don_Vi_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public int Them(int Nguoi_Dung_Don_Vi, int Ma_Nguoi_Dung, int Ma_Don_Vi)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Don_Vi_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pNguoi_Dung_Don_Vi = new SqlParameter("@Nguoi_Dung_Don_Vi", SqlDbType.Int, 4);
                    pNguoi_Dung_Don_Vi.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pNguoi_Dung_Don_Vi);

                    SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung.Value = Ma_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    return (int)pNguoi_Dung_Don_Vi.Value;
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int Nguoi_Dung_Don_Vi, int Ma_Nguoi_Dung, int Ma_Don_Vi)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Don_Vi_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pNguoi_Dung_Don_Vi = new SqlParameter("@Nguoi_Dung_Don_Vi", SqlDbType.Int, 4);
                    pNguoi_Dung_Don_Vi.Value = Nguoi_Dung_Don_Vi;
                    myCommand.Parameters.Add(pNguoi_Dung_Don_Vi);

                    SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung.Value = Ma_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung);

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
        public void Cap_Nhat(HT_Nguoi_Dung_Don_Vi_Chi_Tiet myHT_Nguoi_Dung_Don_Vi_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Don_Vi_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pNguoi_Dung_Don_Vi = new SqlParameter("@Nguoi_Dung_Don_Vi", SqlDbType.Int, 4);
                    pNguoi_Dung_Don_Vi.Value = myHT_Nguoi_Dung_Don_Vi_Chi_Tiet.Nguoi_Dung_Don_Vi;
                    myCommand.Parameters.Add(pNguoi_Dung_Don_Vi);

                    SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung.Value = myHT_Nguoi_Dung_Don_Vi_Chi_Tiet.Ma_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = myHT_Nguoi_Dung_Don_Vi_Chi_Tiet.Ma_Don_Vi;
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
                using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Don_Vi_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pNguoi_Dung_Don_Vi = new SqlParameter("@Nguoi_Dung_Don_Vi", SqlDbType.Int, 4);
                        pNguoi_Dung_Don_Vi.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Nguoi_Dung_Don_Vi"];
                        myCommand.Parameters.Add(pNguoi_Dung_Don_Vi);

                        SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int, 4);
                        pMa_Nguoi_Dung.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nguoi_Dung"];
                        myCommand.Parameters.Add(pMa_Nguoi_Dung);

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
        public void Cap_Nhat_Them(int Nguoi_Dung_Don_Vi, int Ma_Nguoi_Dung, int Ma_Don_Vi)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Don_Vi_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pNguoi_Dung_Don_Vi = new SqlParameter("@Nguoi_Dung_Don_Vi", SqlDbType.Int, 4);
                    pNguoi_Dung_Don_Vi.Value = Nguoi_Dung_Don_Vi;
                    myCommand.Parameters.Add(pNguoi_Dung_Don_Vi);

                    SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung.Value = Ma_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung);

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
        public void Xoa(int Nguoi_Dung_Don_Vi)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Don_Vi_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pNguoi_Dung_Don_Vi = new SqlParameter("@Nguoi_Dung_Don_Vi", SqlDbType.Int, 4);
                    pNguoi_Dung_Don_Vi.Value = Nguoi_Dung_Don_Vi;
                    myCommand.Parameters.Add(pNguoi_Dung_Don_Vi);

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
                using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Don_Vi_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Nguoi_Dung_Don_Vi_Danh_Sach");
                    return myDataSet.Tables["HT_Nguoi_Dung_Don_Vi_Danh_Sach"];
                }
            }
        }
        #endregion

        #region Lay_Boi_HT_Don_Vi_YT
        public DataTable Lay_Boi_HT_Don_Vi_YT(int Ma_Don_Vi)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Don_Vi_Lay_Boi_HT_Don_Vi_YT", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Nguoi_Dung_Don_Vi_Lay_Boi_HT_Don_Vi_YT");
                    return myDataSet.Tables["HT_Nguoi_Dung_Don_Vi_Lay_Boi_HT_Don_Vi_YT"];
                }
            }
        }
        #endregion
        #region Lay_Boi_HT_Nguoi_Dung
        public DataTable Lay_Boi_HT_Nguoi_Dung(int Ma_Nguoi_Dung)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Don_Vi_Lay_Boi_HT_Nguoi_Dung", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung.Value = Ma_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Nguoi_Dung_Don_Vi_Lay_Boi_HT_Nguoi_Dung");
                    return myDataSet.Tables["HT_Nguoi_Dung_Don_Vi_Lay_Boi_HT_Nguoi_Dung"];
                }
            }
        }
        #endregion

    }
    #endregion
}