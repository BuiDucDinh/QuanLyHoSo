
using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region HT_Vai_Tro_Details
    public class HT_Vai_Tro_Chi_Tiet
    {
        public int Ma_Vai_Tro; // Mã vai trò (Role) tổ hợp từ Mã dự án và STT
        public string Ten_Vai_Tro; // Tên vai trò
        public int STT; // Số thứ tự
    }
    #endregion
    #region HT_Vai_Tro
    public class HT_Vai_Tro
    {
        private string ConnectionString;
        public HT_Vai_Tro(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public HT_Vai_Tro_Chi_Tiet Lay(int Ma_Vai_Tro)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Vai_Tro_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Vai_Tro.Value = Ma_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Vai_Tro);

                    SqlParameter pTen_Vai_Tro = new SqlParameter("@Ten_Vai_Tro", SqlDbType.NVarChar, 250);
                    pTen_Vai_Tro.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pTen_Vai_Tro);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pSTT);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();


                    HT_Vai_Tro_Chi_Tiet myHT_Vai_Tro_Chi_Tiet = new HT_Vai_Tro_Chi_Tiet();
                    myHT_Vai_Tro_Chi_Tiet.Ma_Vai_Tro = Ma_Vai_Tro;
                    myHT_Vai_Tro_Chi_Tiet.Ten_Vai_Tro = (string)pTen_Vai_Tro.Value;
                    myHT_Vai_Tro_Chi_Tiet.STT = (int)pSTT.Value;
                    return myHT_Vai_Tro_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int Ma_Vai_Tro, string Ten_Vai_Tro, int STT)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Vai_Tro_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                                        
                    SqlParameter pTen_Vai_Tro = new SqlParameter("@Ten_Vai_Tro", SqlDbType.NVarChar, 250);
                    pTen_Vai_Tro.Value = Ten_Vai_Tro;
                    myCommand.Parameters.Add(pTen_Vai_Tro);

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
        public void Cap_Nhat(int Ma_Vai_Tro, string Ten_Vai_Tro, int STT)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Vai_Tro_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Vai_Tro.Value = Ma_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Vai_Tro);

                    SqlParameter pTen_Vai_Tro = new SqlParameter("@Ten_Vai_Tro", SqlDbType.NVarChar, 250);
                    pTen_Vai_Tro.Value = Ten_Vai_Tro;
                    myCommand.Parameters.Add(pTen_Vai_Tro);

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
        public void Cap_Nhat(HT_Vai_Tro_Chi_Tiet myHT_Vai_Tro_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Vai_Tro_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Vai_Tro.Value = myHT_Vai_Tro_Chi_Tiet.Ma_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Vai_Tro);

                    SqlParameter pTen_Vai_Tro = new SqlParameter("@Ten_Vai_Tro", SqlDbType.NVarChar, 250);
                    pTen_Vai_Tro.Value = myHT_Vai_Tro_Chi_Tiet.Ten_Vai_Tro;
                    myCommand.Parameters.Add(pTen_Vai_Tro);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Value = myHT_Vai_Tro_Chi_Tiet.STT;
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
                using (SqlCommand myCommand = new SqlCommand("HT_Vai_Tro_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                        pMa_Vai_Tro.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Vai_Tro"];
                        myCommand.Parameters.Add(pMa_Vai_Tro);

                        SqlParameter pTen_Vai_Tro = new SqlParameter("@Ten_Vai_Tro", SqlDbType.NVarChar, 250);
                        pTen_Vai_Tro.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ten_Vai_Tro"];
                        myCommand.Parameters.Add(pTen_Vai_Tro);

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
        public void Cap_Nhat_Them(int Ma_Vai_Tro, string Ten_Vai_Tro, int STT)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Vai_Tro_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Vai_Tro.Value = Ma_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Vai_Tro);

                    SqlParameter pTen_Vai_Tro = new SqlParameter("@Ten_Vai_Tro", SqlDbType.NVarChar, 250);
                    pTen_Vai_Tro.Value = Ten_Vai_Tro;
                    myCommand.Parameters.Add(pTen_Vai_Tro);

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
        public void Xoa(int Ma_Vai_Tro)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Vai_Tro_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Vai_Tro.Value = Ma_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Vai_Tro);

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
                using (SqlCommand myCommand = new SqlCommand("HT_Vai_Tro_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Vai_Tro_Danh_Sach");
                    return myDataSet.Tables["HT_Vai_Tro_Danh_Sach"];
                }
            }
        }
        #endregion


    }
    #endregion
}