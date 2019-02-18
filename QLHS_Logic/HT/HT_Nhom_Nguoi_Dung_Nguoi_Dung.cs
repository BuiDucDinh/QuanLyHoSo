using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region HT_Nhom_Nguoi_Dung_Nguoi_Dung_Details
    public class HT_Nhom_Nguoi_Dung_Nguoi_Dung_Chi_Tiet
    {
        public int Ma_Lien_Ket;
        public int Ma_Nhom_Nguoi_Dung;
        public int Ma_Nguoi_Dung;
    }
    #endregion
    #region HT_Nhom_Nguoi_Dung_Nguoi_Dung
    public class HT_Nhom_Nguoi_Dung_Nguoi_Dung
    {
        private string ConnectionString;
        public HT_Nhom_Nguoi_Dung_Nguoi_Dung(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public HT_Nhom_Nguoi_Dung_Nguoi_Dung_Chi_Tiet Lay(int Ma_Lien_Ket)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nhom_Nguoi_Dung_Nguoi_Dung_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Lien_Ket = new SqlParameter("@Ma_Lien_Ket", SqlDbType.Int, 4);
                    pMa_Lien_Ket.Value = Ma_Lien_Ket;
                    myCommand.Parameters.Add(pMa_Lien_Ket);

                    SqlParameter pMa_Nhom_Nguoi_Dung = new SqlParameter("@Ma_Nhom_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nhom_Nguoi_Dung.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pMa_Nhom_Nguoi_Dung);

                    SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();


                    HT_Nhom_Nguoi_Dung_Nguoi_Dung_Chi_Tiet myHT_Nhom_Nguoi_Dung_Nguoi_Dung_Chi_Tiet = new HT_Nhom_Nguoi_Dung_Nguoi_Dung_Chi_Tiet();
                    myHT_Nhom_Nguoi_Dung_Nguoi_Dung_Chi_Tiet.Ma_Lien_Ket = Ma_Lien_Ket;
                    myHT_Nhom_Nguoi_Dung_Nguoi_Dung_Chi_Tiet.Ma_Nhom_Nguoi_Dung = (int)pMa_Nhom_Nguoi_Dung.Value;
                    myHT_Nhom_Nguoi_Dung_Nguoi_Dung_Chi_Tiet.Ma_Nguoi_Dung = (int)pMa_Nguoi_Dung.Value;
                    return myHT_Nhom_Nguoi_Dung_Nguoi_Dung_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int Ma_Lien_Ket, int Ma_Nhom_Nguoi_Dung, int Ma_Nguoi_Dung)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nhom_Nguoi_Dung_Nguoi_Dung_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Lien_Ket = new SqlParameter("@Ma_Lien_Ket", SqlDbType.Int, 4);
                    pMa_Lien_Ket.Value = Ma_Lien_Ket;
                    myCommand.Parameters.Add(pMa_Lien_Ket);

                    SqlParameter pMa_Nhom_Nguoi_Dung = new SqlParameter("@Ma_Nhom_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nhom_Nguoi_Dung.Value = Ma_Nhom_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nhom_Nguoi_Dung);

                    SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung.Value = Ma_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int Ma_Lien_Ket, int Ma_Nhom_Nguoi_Dung, int Ma_Nguoi_Dung)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nhom_Nguoi_Dung_Nguoi_Dung_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Lien_Ket = new SqlParameter("@Ma_Lien_Ket", SqlDbType.Int, 4);
                    pMa_Lien_Ket.Value = Ma_Lien_Ket;
                    myCommand.Parameters.Add(pMa_Lien_Ket);

                    SqlParameter pMa_Nhom_Nguoi_Dung = new SqlParameter("@Ma_Nhom_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nhom_Nguoi_Dung.Value = Ma_Nhom_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nhom_Nguoi_Dung);

                    SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung.Value = Ma_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung);



                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(HT_Nhom_Nguoi_Dung_Nguoi_Dung_Chi_Tiet myHT_Nhom_Nguoi_Dung_Nguoi_Dung_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nhom_Nguoi_Dung_Nguoi_Dung_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Lien_Ket = new SqlParameter("@Ma_Lien_Ket", SqlDbType.Int, 4);
                    pMa_Lien_Ket.Value = myHT_Nhom_Nguoi_Dung_Nguoi_Dung_Chi_Tiet.Ma_Lien_Ket;
                    myCommand.Parameters.Add(pMa_Lien_Ket);

                    SqlParameter pMa_Nhom_Nguoi_Dung = new SqlParameter("@Ma_Nhom_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nhom_Nguoi_Dung.Value = myHT_Nhom_Nguoi_Dung_Nguoi_Dung_Chi_Tiet.Ma_Nhom_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nhom_Nguoi_Dung);

                    SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung.Value = myHT_Nhom_Nguoi_Dung_Nguoi_Dung_Chi_Tiet.Ma_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung);


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
                using (SqlCommand myCommand = new SqlCommand("HT_Nhom_Nguoi_Dung_Nguoi_Dung_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Lien_Ket = new SqlParameter("@Ma_Lien_Ket", SqlDbType.Int, 4);
                        pMa_Lien_Ket.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Lien_Ket"];
                        myCommand.Parameters.Add(pMa_Lien_Ket);

                        SqlParameter pMa_Nhom_Nguoi_Dung = new SqlParameter("@Ma_Nhom_Nguoi_Dung", SqlDbType.Int, 4);
                        pMa_Nhom_Nguoi_Dung.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nhom_Nguoi_Dung"];
                        myCommand.Parameters.Add(pMa_Nhom_Nguoi_Dung);

                        SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int, 4);
                        pMa_Nguoi_Dung.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nguoi_Dung"];
                        myCommand.Parameters.Add(pMa_Nguoi_Dung);


                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int Ma_Lien_Ket, int Ma_Nhom_Nguoi_Dung, int Ma_Nguoi_Dung)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nhom_Nguoi_Dung_Nguoi_Dung_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Lien_Ket = new SqlParameter("@Ma_Lien_Ket", SqlDbType.Int, 4);
                    pMa_Lien_Ket.Value = Ma_Lien_Ket;
                    myCommand.Parameters.Add(pMa_Lien_Ket);

                    SqlParameter pMa_Nhom_Nguoi_Dung = new SqlParameter("@Ma_Nhom_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nhom_Nguoi_Dung.Value = Ma_Nhom_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nhom_Nguoi_Dung);

                    SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung.Value = Ma_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Ma_Lien_Ket)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nhom_Nguoi_Dung_Nguoi_Dung_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Lien_Ket = new SqlParameter("@Ma_Lien_Ket", SqlDbType.Int, 4);
                    pMa_Lien_Ket.Value = Ma_Lien_Ket;
                    myCommand.Parameters.Add(pMa_Lien_Ket);

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
                using (SqlCommand myCommand = new SqlCommand("HT_Nhom_Nguoi_Dung_Nguoi_Dung_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Nhom_Nguoi_Dung_Nguoi_Dung_Danh_Sach");
                    return myDataSet.Tables["HT_Nhom_Nguoi_Dung_Nguoi_Dung_Danh_Sach"];
                }
            }
        }
        #endregion

        #region Lay_Boi_HT_Nguoi_Dung
        public DataTable Lay_Boi_HT_Nguoi_Dung(int Ma_Nguoi_Dung)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nhom_Nguoi_Dung_Nguoi_Dung_Lay_Boi_HT_Nguoi_Dung", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung.Value = Ma_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Nhom_Nguoi_Dung_Nguoi_Dung_Lay_Boi_HT_Nguoi_Dung");
                    return myDataSet.Tables["HT_Nhom_Nguoi_Dung_Nguoi_Dung_Lay_Boi_HT_Nguoi_Dung"];
                }
            }
        }
        #endregion
        #region Lay_Boi_HT_Nhom_Nguoi_Dung
        public DataTable Lay_Boi_HT_Nhom_Nguoi_Dung(int Ma_Nhom_Nguoi_Dung)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nhom_Nguoi_Dung_Nguoi_Dung_Lay_Boi_HT_Nhom_Nguoi_Dung", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Nhom_Nguoi_Dung = new SqlParameter("@Ma_Nhom_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nhom_Nguoi_Dung.Value = Ma_Nhom_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nhom_Nguoi_Dung);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Nhom_Nguoi_Dung_Nguoi_Dung_Lay_Boi_HT_Nhom_Nguoi_Dung");
                    return myDataSet.Tables["HT_Nhom_Nguoi_Dung_Nguoi_Dung_Lay_Boi_HT_Nhom_Nguoi_Dung"];
                }
            }
        }
        #endregion
        //new
        #region Lay_Boi_HT_Nguoi_Dung_Chon
        public DataTable Lay_Boi_HT_Nguoi_Dung_Chon(int Ma_Nguoi_Dung, bool Chon)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nhom_Nguoi_Dung_Lay_Boi_HT_Nguoi_Dung_Chon", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung.Value = Ma_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung);

                    SqlParameter pChon = new SqlParameter("@Chon", SqlDbType.Bit);
                    pChon.Value = Chon;
                    myCommand.Parameters.Add(pChon);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Nhom_Nguoi_Dung_Lay_Boi_HT_Nguoi_Dung_Chon");
                    return myDataSet.Tables["HT_Nhom_Nguoi_Dung_Lay_Boi_HT_Nguoi_Dung_Chon"];
                }
            }
        }
        #endregion
    }
    #endregion
}