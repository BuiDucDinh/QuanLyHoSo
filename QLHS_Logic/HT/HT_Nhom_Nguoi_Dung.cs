using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region HT_Nhom_Nguoi_Dung_Details
    public class HT_Nhom_Nguoi_Dung_Chi_Tiet
    {
        public int Ma_Nhom_Nguoi_Dung; // Mã nhóm người dùng
        public string Ten_Nhom_Nguoi_Dung; // Tên nhóm người dùng
        public int STT; // Số TT
    }
    #endregion
    #region HT_Nhom_Nguoi_Dung
    public class HT_Nhom_Nguoi_Dung
    {
        private string ConnectionString;
        public HT_Nhom_Nguoi_Dung(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public HT_Nhom_Nguoi_Dung_Chi_Tiet Lay(int Ma_Nhom_Nguoi_Dung)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nhom_Nguoi_Dung_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhom_Nguoi_Dung = new SqlParameter("@Ma_Nhom_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nhom_Nguoi_Dung.Value = Ma_Nhom_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nhom_Nguoi_Dung);

                    SqlParameter pTen_Nhom_Nguoi_Dung = new SqlParameter("@Ten_Nhom_Nguoi_Dung", SqlDbType.NVarChar, 250);
                    pTen_Nhom_Nguoi_Dung.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pTen_Nhom_Nguoi_Dung);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pSTT);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();


                    HT_Nhom_Nguoi_Dung_Chi_Tiet myHT_Nhom_Nguoi_Dung_Chi_Tiet = new HT_Nhom_Nguoi_Dung_Chi_Tiet();
                    myHT_Nhom_Nguoi_Dung_Chi_Tiet.Ma_Nhom_Nguoi_Dung = Ma_Nhom_Nguoi_Dung;
                    myHT_Nhom_Nguoi_Dung_Chi_Tiet.Ten_Nhom_Nguoi_Dung = (string)pTen_Nhom_Nguoi_Dung.Value;
                    myHT_Nhom_Nguoi_Dung_Chi_Tiet.STT = (int)pSTT.Value;
                    return myHT_Nhom_Nguoi_Dung_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int Ma_Nhom_Nguoi_Dung, string Ten_Nhom_Nguoi_Dung, int STT)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nhom_Nguoi_Dung_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhom_Nguoi_Dung = new SqlParameter("@Ma_Nhom_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nhom_Nguoi_Dung.Value = Ma_Nhom_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nhom_Nguoi_Dung);

                    SqlParameter pTen_Nhom_Nguoi_Dung = new SqlParameter("@Ten_Nhom_Nguoi_Dung", SqlDbType.NVarChar, 250);
                    pTen_Nhom_Nguoi_Dung.Value = Ten_Nhom_Nguoi_Dung;
                    myCommand.Parameters.Add(pTen_Nhom_Nguoi_Dung);

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
        public void Cap_Nhat(int Ma_Nhom_Nguoi_Dung, string Ten_Nhom_Nguoi_Dung, int STT)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nhom_Nguoi_Dung_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Nhom_Nguoi_Dung = new SqlParameter("@Ma_Nhom_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nhom_Nguoi_Dung.Value = Ma_Nhom_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nhom_Nguoi_Dung);

                    SqlParameter pTen_Nhom_Nguoi_Dung = new SqlParameter("@Ten_Nhom_Nguoi_Dung", SqlDbType.NVarChar, 250);
                    pTen_Nhom_Nguoi_Dung.Value = Ten_Nhom_Nguoi_Dung;
                    myCommand.Parameters.Add(pTen_Nhom_Nguoi_Dung);

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
        public void Cap_Nhat(HT_Nhom_Nguoi_Dung_Chi_Tiet myHT_Nhom_Nguoi_Dung_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nhom_Nguoi_Dung_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhom_Nguoi_Dung = new SqlParameter("@Ma_Nhom_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nhom_Nguoi_Dung.Value = myHT_Nhom_Nguoi_Dung_Chi_Tiet.Ma_Nhom_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nhom_Nguoi_Dung);

                    SqlParameter pTen_Nhom_Nguoi_Dung = new SqlParameter("@Ten_Nhom_Nguoi_Dung", SqlDbType.NVarChar, 250);
                    pTen_Nhom_Nguoi_Dung.Value = myHT_Nhom_Nguoi_Dung_Chi_Tiet.Ten_Nhom_Nguoi_Dung;
                    myCommand.Parameters.Add(pTen_Nhom_Nguoi_Dung);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Value = myHT_Nhom_Nguoi_Dung_Chi_Tiet.STT;
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
                using (SqlCommand myCommand = new SqlCommand("HT_Nhom_Nguoi_Dung_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Nhom_Nguoi_Dung = new SqlParameter("@Ma_Nhom_Nguoi_Dung", SqlDbType.Int, 4);
                        pMa_Nhom_Nguoi_Dung.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nhom_Nguoi_Dung"];
                        myCommand.Parameters.Add(pMa_Nhom_Nguoi_Dung);

                        SqlParameter pTen_Nhom_Nguoi_Dung = new SqlParameter("@Ten_Nhom_Nguoi_Dung", SqlDbType.NVarChar, 250);
                        pTen_Nhom_Nguoi_Dung.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ten_Nhom_Nguoi_Dung"];
                        myCommand.Parameters.Add(pTen_Nhom_Nguoi_Dung);

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
        public void Cap_Nhat_Them(int Ma_Nhom_Nguoi_Dung, string Ten_Nhom_Nguoi_Dung, int STT)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nhom_Nguoi_Dung_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhom_Nguoi_Dung = new SqlParameter("@Ma_Nhom_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nhom_Nguoi_Dung.Value = Ma_Nhom_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nhom_Nguoi_Dung);

                    SqlParameter pTen_Nhom_Nguoi_Dung = new SqlParameter("@Ten_Nhom_Nguoi_Dung", SqlDbType.NVarChar, 250);
                    pTen_Nhom_Nguoi_Dung.Value = Ten_Nhom_Nguoi_Dung;
                    myCommand.Parameters.Add(pTen_Nhom_Nguoi_Dung);

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
        public void Xoa(int Ma_Nhom_Nguoi_Dung)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nhom_Nguoi_Dung_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhom_Nguoi_Dung = new SqlParameter("@Ma_Nhom_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nhom_Nguoi_Dung.Value = Ma_Nhom_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nhom_Nguoi_Dung);

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
                using (SqlCommand myCommand = new SqlCommand("HT_Nhom_Nguoi_Dung_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Nhom_Nguoi_Dung_Danh_Sach");
                    return myDataSet.Tables["HT_Nhom_Nguoi_Dung_Danh_Sach"];
                }
            }
        }
        #endregion


    }
    #endregion
}