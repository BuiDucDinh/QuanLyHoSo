using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region HT_Ma_Nhom_Nguoi_Dung_Vai_Tro_Details
    public class HT_Ma_Nhom_Nguoi_Dung_Vai_Tro_Chi_Tiet
    {
        public int Ma_Nhom_Vai_Tro;
        public int Ma_Nhom_Nguoi_Dung;
        public int Ma_Vai_Tro;
    }
    #endregion
    #region HT_Ma_Nhom_Nguoi_Dung_Vai_Tro
    public class HT_Ma_Nhom_Nguoi_Dung_Vai_Tro
    {
        private string ConnectionString;
        public HT_Ma_Nhom_Nguoi_Dung_Vai_Tro(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public HT_Ma_Nhom_Nguoi_Dung_Vai_Tro_Chi_Tiet Lay(int Ma_Nhom_Vai_Tro)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Ma_Nhom_Nguoi_Dung_Vai_Tro_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhom_Vai_Tro = new SqlParameter("@Ma_Nhom_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Nhom_Vai_Tro.Value = Ma_Nhom_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Nhom_Vai_Tro);

                    SqlParameter pMa_Nhom_Nguoi_Dung = new SqlParameter("@Ma_Nhom_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nhom_Nguoi_Dung.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pMa_Nhom_Nguoi_Dung);

                    SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Vai_Tro.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pMa_Vai_Tro);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();


                    HT_Ma_Nhom_Nguoi_Dung_Vai_Tro_Chi_Tiet myHT_Ma_Nhom_Nguoi_Dung_Vai_Tro_Chi_Tiet = new HT_Ma_Nhom_Nguoi_Dung_Vai_Tro_Chi_Tiet();
                    myHT_Ma_Nhom_Nguoi_Dung_Vai_Tro_Chi_Tiet.Ma_Nhom_Vai_Tro = Ma_Nhom_Vai_Tro;
                    myHT_Ma_Nhom_Nguoi_Dung_Vai_Tro_Chi_Tiet.Ma_Nhom_Nguoi_Dung = (int)pMa_Nhom_Nguoi_Dung.Value;
                    myHT_Ma_Nhom_Nguoi_Dung_Vai_Tro_Chi_Tiet.Ma_Vai_Tro = (int)pMa_Vai_Tro.Value;
                    return myHT_Ma_Nhom_Nguoi_Dung_Vai_Tro_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int Ma_Nhom_Vai_Tro, int Ma_Nhom_Nguoi_Dung, int Ma_Vai_Tro)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Ma_Nhom_Nguoi_Dung_Vai_Tro_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhom_Vai_Tro = new SqlParameter("@Ma_Nhom_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Nhom_Vai_Tro.Value = Ma_Nhom_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Nhom_Vai_Tro);

                    SqlParameter pMa_Nhom_Nguoi_Dung = new SqlParameter("@Ma_Nhom_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nhom_Nguoi_Dung.Value = Ma_Nhom_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nhom_Nguoi_Dung);

                    SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Vai_Tro.Value = Ma_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Vai_Tro);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int Ma_Nhom_Vai_Tro, int Ma_Nhom_Nguoi_Dung, int Ma_Vai_Tro)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Ma_Nhom_Nguoi_Dung_Vai_Tro_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Nhom_Vai_Tro = new SqlParameter("@Ma_Nhom_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Nhom_Vai_Tro.Value = Ma_Nhom_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Nhom_Vai_Tro);

                    SqlParameter pMa_Nhom_Nguoi_Dung = new SqlParameter("@Ma_Nhom_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nhom_Nguoi_Dung.Value = Ma_Nhom_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nhom_Nguoi_Dung);

                    SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Vai_Tro.Value = Ma_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Vai_Tro);



                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(HT_Ma_Nhom_Nguoi_Dung_Vai_Tro_Chi_Tiet myHT_Ma_Nhom_Nguoi_Dung_Vai_Tro_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Ma_Nhom_Nguoi_Dung_Vai_Tro_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhom_Vai_Tro = new SqlParameter("@Ma_Nhom_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Nhom_Vai_Tro.Value = myHT_Ma_Nhom_Nguoi_Dung_Vai_Tro_Chi_Tiet.Ma_Nhom_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Nhom_Vai_Tro);

                    SqlParameter pMa_Nhom_Nguoi_Dung = new SqlParameter("@Ma_Nhom_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nhom_Nguoi_Dung.Value = myHT_Ma_Nhom_Nguoi_Dung_Vai_Tro_Chi_Tiet.Ma_Nhom_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nhom_Nguoi_Dung);

                    SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Vai_Tro.Value = myHT_Ma_Nhom_Nguoi_Dung_Vai_Tro_Chi_Tiet.Ma_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Vai_Tro);


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
                using (SqlCommand myCommand = new SqlCommand("HT_Ma_Nhom_Nguoi_Dung_Vai_Tro_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Nhom_Vai_Tro = new SqlParameter("@Ma_Nhom_Vai_Tro", SqlDbType.Int, 4);
                        pMa_Nhom_Vai_Tro.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nhom_Vai_Tro"];
                        myCommand.Parameters.Add(pMa_Nhom_Vai_Tro);

                        SqlParameter pMa_Nhom_Nguoi_Dung = new SqlParameter("@Ma_Nhom_Nguoi_Dung", SqlDbType.Int, 4);
                        pMa_Nhom_Nguoi_Dung.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nhom_Nguoi_Dung"];
                        myCommand.Parameters.Add(pMa_Nhom_Nguoi_Dung);

                        SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                        pMa_Vai_Tro.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Vai_Tro"];
                        myCommand.Parameters.Add(pMa_Vai_Tro);


                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int Ma_Nhom_Vai_Tro, int Ma_Nhom_Nguoi_Dung, int Ma_Vai_Tro)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Ma_Nhom_Nguoi_Dung_Vai_Tro_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhom_Vai_Tro = new SqlParameter("@Ma_Nhom_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Nhom_Vai_Tro.Value = Ma_Nhom_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Nhom_Vai_Tro);

                    SqlParameter pMa_Nhom_Nguoi_Dung = new SqlParameter("@Ma_Nhom_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nhom_Nguoi_Dung.Value = Ma_Nhom_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nhom_Nguoi_Dung);

                    SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Vai_Tro.Value = Ma_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Vai_Tro);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Ma_Nhom_Vai_Tro)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Ma_Nhom_Nguoi_Dung_Vai_Tro_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhom_Vai_Tro = new SqlParameter("@Ma_Nhom_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Nhom_Vai_Tro.Value = Ma_Nhom_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Nhom_Vai_Tro);

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
                using (SqlCommand myCommand = new SqlCommand("HT_Ma_Nhom_Nguoi_Dung_Vai_Tro_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Ma_Nhom_Nguoi_Dung_Vai_Tro_Danh_Sach");
                    return myDataSet.Tables["HT_Ma_Nhom_Nguoi_Dung_Vai_Tro_Danh_Sach"];
                }
            }
        }
        #endregion

        #region Lay_Boi_HT_Nhom_Nguoi_Dung
        public DataTable Lay_Boi_HT_Nhom_Nguoi_Dung(int Ma_Nhom_Nguoi_Dung)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Ma_Nhom_Nguoi_Dung_Vai_Tro_Lay_Boi_HT_Nhom_Nguoi_Dung", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Nhom_Nguoi_Dung = new SqlParameter("@Ma_Nhom_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nhom_Nguoi_Dung.Value = Ma_Nhom_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nhom_Nguoi_Dung);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Ma_Nhom_Nguoi_Dung_Vai_Tro_Lay_Boi_HT_Nhom_Nguoi_Dung");
                    return myDataSet.Tables["HT_Ma_Nhom_Nguoi_Dung_Vai_Tro_Lay_Boi_HT_Nhom_Nguoi_Dung"];
                }
            }
        }
        #endregion
        #region Lay_Boi_HT_Vai_Tro
        public DataTable Lay_Boi_HT_Vai_Tro(int Ma_Vai_Tro)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Ma_Nhom_Nguoi_Dung_Vai_Tro_Lay_Boi_HT_Vai_Tro", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Vai_Tro.Value = Ma_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Vai_Tro);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Ma_Nhom_Nguoi_Dung_Vai_Tro_Lay_Boi_HT_Vai_Tro");
                    return myDataSet.Tables["HT_Ma_Nhom_Nguoi_Dung_Vai_Tro_Lay_Boi_HT_Vai_Tro"];
                }
            }
        }
        #endregion
        //new
        #region Lay_Boi_HT_Vai_Tro_Chon
        public DataTable Lay_Boi_HT_Vai_Tro_Chon(int Ma_Nhom_Nguoi_Dung, bool Chon)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nhom_Nguoi_Dung_Lay_Boi_HT_Vai_Tro_Chon", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nhom_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung.Value = Ma_Nhom_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung);

                    SqlParameter pChon = new SqlParameter("@Chon", SqlDbType.Bit);
                    pChon.Value = Chon;
                    myCommand.Parameters.Add(pChon);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Nhom_Nguoi_Dung_Lay_Boi_HT_Vai_Tro_Chon");
                    return myDataSet.Tables["HT_Nhom_Nguoi_Dung_Lay_Boi_HT_Vai_Tro_Chon"];
                }
            }
        }
        #endregion
    }
    #endregion
}