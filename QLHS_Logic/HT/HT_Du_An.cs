
using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region HT_Du_An_Details
    public class HT_Du_An_Chi_Tiet
    {
        public string Ma_Du_An; // Mã dự án (2 ký tự đại diện)
        public string Ten_Du_An; // Tên dự án
        public int STT; // Số thứ tự
    }
    #endregion
    #region HT_Du_An
    public class HT_Du_An
    {
        private string ConnectionString;
        public HT_Du_An(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public HT_Du_An_Chi_Tiet Lay(string Ma_Du_An)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Du_An_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Du_An = new SqlParameter("@Ma_Du_An", SqlDbType.VarChar, 2);
                    pMa_Du_An.Value = Ma_Du_An;
                    myCommand.Parameters.Add(pMa_Du_An);

                    SqlParameter pTen_Du_An = new SqlParameter("@Ten_Du_An", SqlDbType.NVarChar, 200);
                    pTen_Du_An.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pTen_Du_An);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pSTT);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();


                    HT_Du_An_Chi_Tiet myHT_Du_An_Chi_Tiet = new HT_Du_An_Chi_Tiet();
                    myHT_Du_An_Chi_Tiet.Ma_Du_An = Ma_Du_An;
                    myHT_Du_An_Chi_Tiet.Ten_Du_An = (string)pTen_Du_An.Value;
                    myHT_Du_An_Chi_Tiet.STT = (int)pSTT.Value;
                    return myHT_Du_An_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public string Them(string Ma_Du_An, string Ten_Du_An, int STT)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Du_An_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Du_An = new SqlParameter("@Ma_Du_An", SqlDbType.VarChar, 2);
                    pMa_Du_An.Value = Ma_Du_An;
                    myCommand.Parameters.Add(pMa_Du_An);

                    SqlParameter pTen_Du_An = new SqlParameter("@Ten_Du_An", SqlDbType.NVarChar, 200);
                    pTen_Du_An.Value = Ten_Du_An;
                    myCommand.Parameters.Add(pTen_Du_An);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Value = STT;
                    myCommand.Parameters.Add(pSTT);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    return (string)pMa_Du_An.Value;
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(string Ma_Du_An, string Ten_Du_An, int STT)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Du_An_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Du_An = new SqlParameter("@Ma_Du_An", SqlDbType.VarChar, 2);
                    pMa_Du_An.Value = Ma_Du_An;
                    myCommand.Parameters.Add(pMa_Du_An);

                    SqlParameter pTen_Du_An = new SqlParameter("@Ten_Du_An", SqlDbType.NVarChar, 200);
                    pTen_Du_An.Value = Ten_Du_An;
                    myCommand.Parameters.Add(pTen_Du_An);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Value = STT;
                    myCommand.Parameters.Add(pSTT);



                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(HT_Du_An_Chi_Tiet myHT_Du_An_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Du_An_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Du_An = new SqlParameter("@Ma_Du_An", SqlDbType.VarChar, 2);
                    pMa_Du_An.Value = myHT_Du_An_Chi_Tiet.Ma_Du_An;
                    myCommand.Parameters.Add(pMa_Du_An);

                    SqlParameter pTen_Du_An = new SqlParameter("@Ten_Du_An", SqlDbType.NVarChar, 200);
                    pTen_Du_An.Value = myHT_Du_An_Chi_Tiet.Ten_Du_An;
                    myCommand.Parameters.Add(pTen_Du_An);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Value = myHT_Du_An_Chi_Tiet.STT;
                    myCommand.Parameters.Add(pSTT);


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
                using (SqlCommand myCommand = new SqlCommand("HT_Du_An_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Du_An = new SqlParameter("@Ma_Du_An", SqlDbType.VarChar, 2);
                        pMa_Du_An.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ma_Du_An"];
                        myCommand.Parameters.Add(pMa_Du_An);

                        SqlParameter pTen_Du_An = new SqlParameter("@Ten_Du_An", SqlDbType.NVarChar, 200);
                        pTen_Du_An.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ten_Du_An"];
                        myCommand.Parameters.Add(pTen_Du_An);

                        SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                        pSTT.Value = (int)myDataSet.Tables[strTableName].Rows[i]["STT"];
                        myCommand.Parameters.Add(pSTT);


                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(string Ma_Du_An, string Ten_Du_An, int STT)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Du_An_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Du_An = new SqlParameter("@Ma_Du_An", SqlDbType.VarChar, 2);
                    pMa_Du_An.Value = Ma_Du_An;
                    myCommand.Parameters.Add(pMa_Du_An);

                    SqlParameter pTen_Du_An = new SqlParameter("@Ten_Du_An", SqlDbType.NVarChar, 200);
                    pTen_Du_An.Value = Ten_Du_An;
                    myCommand.Parameters.Add(pTen_Du_An);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Value = STT;
                    myCommand.Parameters.Add(pSTT);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(string Ma_Du_An)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Du_An_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Du_An = new SqlParameter("@Ma_Du_An", SqlDbType.VarChar, 2);
                    pMa_Du_An.Value = Ma_Du_An;
                    myCommand.Parameters.Add(pMa_Du_An);

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
                using (SqlCommand myCommand = new SqlCommand("HT_Du_An_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Du_An_Danh_Sach");
                    return myDataSet.Tables["HT_Du_An_Danh_Sach"];
                }
            }
        }
        #endregion

        //New
        #region Danh_Sach_Boi_Nguoi_Dung
        public DataTable Danh_Sach_Boi_Nguoi_Dung(int Ma_Nguoi_Dung)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Du_An_Danh_Sach_Boi_Nguoi_Dung", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung.Value = Ma_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Du_An_Danh_Sach_Boi_Nguoi_Dung");
                    return myDataSet.Tables["HT_Du_An_Danh_Sach_Boi_Nguoi_Dung"];
                }
            }
        }
        #endregion
        #region Danh_Sach_Boi_Vai_Tro
        public DataTable Danh_Sach_Boi_Vai_Tro(int Ma_Vai_Tro)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Du_An_Danh_Sach_Boi_Vai_Tro", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Vai_Tro.Value = Ma_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Vai_Tro);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Du_An_Danh_Sach_Boi_Vai_Tro");
                    return myDataSet.Tables["HT_Du_An_Danh_Sach_Boi_Vai_Tro"];
                }
            }
        }
        #endregion
    }
    #endregion
}