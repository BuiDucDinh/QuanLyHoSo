
using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region HT_Nhom_Chuc_Nang_Details
    public class HT_Nhom_Chuc_Nang_Chi_Tiet
    {
        public string Ma_Nhom_Chuc_Nang; // Mã nhóm chức năng (tổ hợp từ Mã Module + STT Nhóm)
        public string Ma_Du_An;
        public string Ten_Nhom_Chuc_Nang; // Tên nhóm chức năng
        public int STT; // Số thứ tự nhóm
        public bool Duoc_Hien_Thi; // Được hiển thị để sử dụng hay không
    }
    #endregion
    #region HT_Nhom_Chuc_Nang
    public class HT_Nhom_Chuc_Nang
    {
        private string ConnectionString;
        public HT_Nhom_Chuc_Nang(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public HT_Nhom_Chuc_Nang_Chi_Tiet Lay(string Ma_Nhom_Chuc_Nang)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nhom_Chuc_Nang_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhom_Chuc_Nang = new SqlParameter("@Ma_Nhom_Chuc_Nang", SqlDbType.VarChar, 10);
                    pMa_Nhom_Chuc_Nang.Value = Ma_Nhom_Chuc_Nang;
                    myCommand.Parameters.Add(pMa_Nhom_Chuc_Nang);

                    SqlParameter pMa_Du_An = new SqlParameter("@Ma_Du_An", SqlDbType.VarChar, 2);
                    pMa_Du_An.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pMa_Du_An);

                    SqlParameter pTen_Nhom_Chuc_Nang = new SqlParameter("@Ten_Nhom_Chuc_Nang", SqlDbType.NVarChar, 200);
                    pTen_Nhom_Chuc_Nang.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pTen_Nhom_Chuc_Nang);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pSTT);

                    SqlParameter pDuoc_Hien_Thi = new SqlParameter("@Duoc_Hien_Thi", SqlDbType.Bit, 1);
                    pDuoc_Hien_Thi.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pDuoc_Hien_Thi);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();


                    HT_Nhom_Chuc_Nang_Chi_Tiet myHT_Nhom_Chuc_Nang_Chi_Tiet = new HT_Nhom_Chuc_Nang_Chi_Tiet();
                    myHT_Nhom_Chuc_Nang_Chi_Tiet.Ma_Nhom_Chuc_Nang = Ma_Nhom_Chuc_Nang;
                    myHT_Nhom_Chuc_Nang_Chi_Tiet.Ma_Du_An = (string)pMa_Du_An.Value;
                    myHT_Nhom_Chuc_Nang_Chi_Tiet.Ten_Nhom_Chuc_Nang = (string)pTen_Nhom_Chuc_Nang.Value;
                    myHT_Nhom_Chuc_Nang_Chi_Tiet.STT = (int)pSTT.Value;
                    myHT_Nhom_Chuc_Nang_Chi_Tiet.Duoc_Hien_Thi = (bool)pDuoc_Hien_Thi.Value;
                    return myHT_Nhom_Chuc_Nang_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public string Them(string Ma_Nhom_Chuc_Nang, string Ma_Du_An, string Ten_Nhom_Chuc_Nang, int STT, bool Duoc_Hien_Thi)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nhom_Chuc_Nang_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhom_Chuc_Nang = new SqlParameter("@Ma_Nhom_Chuc_Nang", SqlDbType.VarChar, 10);
                    pMa_Nhom_Chuc_Nang.Value = Ma_Nhom_Chuc_Nang;
                    myCommand.Parameters.Add(pMa_Nhom_Chuc_Nang);

                    SqlParameter pMa_Du_An = new SqlParameter("@Ma_Du_An", SqlDbType.VarChar, 2);
                    pMa_Du_An.Value = Ma_Du_An;
                    myCommand.Parameters.Add(pMa_Du_An);

                    SqlParameter pTen_Nhom_Chuc_Nang = new SqlParameter("@Ten_Nhom_Chuc_Nang", SqlDbType.NVarChar, 200);
                    pTen_Nhom_Chuc_Nang.Value = Ten_Nhom_Chuc_Nang;
                    myCommand.Parameters.Add(pTen_Nhom_Chuc_Nang);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Value = STT;
                    myCommand.Parameters.Add(pSTT);

                    SqlParameter pDuoc_Hien_Thi = new SqlParameter("@Duoc_Hien_Thi", SqlDbType.Bit, 1);
                    pDuoc_Hien_Thi.Value = Duoc_Hien_Thi;
                    myCommand.Parameters.Add(pDuoc_Hien_Thi);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    return (string)pMa_Nhom_Chuc_Nang.Value;
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(string Ma_Nhom_Chuc_Nang, string Ma_Du_An, string Ten_Nhom_Chuc_Nang, int STT, bool Duoc_Hien_Thi)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nhom_Chuc_Nang_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Nhom_Chuc_Nang = new SqlParameter("@Ma_Nhom_Chuc_Nang", SqlDbType.VarChar, 10);
                    pMa_Nhom_Chuc_Nang.Value = Ma_Nhom_Chuc_Nang;
                    myCommand.Parameters.Add(pMa_Nhom_Chuc_Nang);

                    SqlParameter pMa_Du_An = new SqlParameter("@Ma_Du_An", SqlDbType.VarChar, 2);
                    pMa_Du_An.Value = Ma_Du_An;
                    myCommand.Parameters.Add(pMa_Du_An);

                    SqlParameter pTen_Nhom_Chuc_Nang = new SqlParameter("@Ten_Nhom_Chuc_Nang", SqlDbType.NVarChar, 200);
                    pTen_Nhom_Chuc_Nang.Value = Ten_Nhom_Chuc_Nang;
                    myCommand.Parameters.Add(pTen_Nhom_Chuc_Nang);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Value = STT;
                    myCommand.Parameters.Add(pSTT);

                    SqlParameter pDuoc_Hien_Thi = new SqlParameter("@Duoc_Hien_Thi", SqlDbType.Bit, 1);
                    pDuoc_Hien_Thi.Value = Duoc_Hien_Thi;
                    myCommand.Parameters.Add(pDuoc_Hien_Thi);



                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(HT_Nhom_Chuc_Nang_Chi_Tiet myHT_Nhom_Chuc_Nang_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nhom_Chuc_Nang_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhom_Chuc_Nang = new SqlParameter("@Ma_Nhom_Chuc_Nang", SqlDbType.VarChar, 10);
                    pMa_Nhom_Chuc_Nang.Value = myHT_Nhom_Chuc_Nang_Chi_Tiet.Ma_Nhom_Chuc_Nang;
                    myCommand.Parameters.Add(pMa_Nhom_Chuc_Nang);

                    SqlParameter pMa_Du_An = new SqlParameter("@Ma_Du_An", SqlDbType.VarChar, 2);
                    pMa_Du_An.Value = myHT_Nhom_Chuc_Nang_Chi_Tiet.Ma_Du_An;
                    myCommand.Parameters.Add(pMa_Du_An);

                    SqlParameter pTen_Nhom_Chuc_Nang = new SqlParameter("@Ten_Nhom_Chuc_Nang", SqlDbType.NVarChar, 200);
                    pTen_Nhom_Chuc_Nang.Value = myHT_Nhom_Chuc_Nang_Chi_Tiet.Ten_Nhom_Chuc_Nang;
                    myCommand.Parameters.Add(pTen_Nhom_Chuc_Nang);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Value = myHT_Nhom_Chuc_Nang_Chi_Tiet.STT;
                    myCommand.Parameters.Add(pSTT);

                    SqlParameter pDuoc_Hien_Thi = new SqlParameter("@Duoc_Hien_Thi", SqlDbType.Bit, 1);
                    pDuoc_Hien_Thi.Value = myHT_Nhom_Chuc_Nang_Chi_Tiet.Duoc_Hien_Thi;
                    myCommand.Parameters.Add(pDuoc_Hien_Thi);


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
                using (SqlCommand myCommand = new SqlCommand("HT_Nhom_Chuc_Nang_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Nhom_Chuc_Nang = new SqlParameter("@Ma_Nhom_Chuc_Nang", SqlDbType.VarChar, 10);
                        pMa_Nhom_Chuc_Nang.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ma_Nhom_Chuc_Nang"];
                        myCommand.Parameters.Add(pMa_Nhom_Chuc_Nang);

                        SqlParameter pMa_Du_An = new SqlParameter("@Ma_Du_An", SqlDbType.VarChar, 2);
                        pMa_Du_An.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ma_Du_An"];
                        myCommand.Parameters.Add(pMa_Du_An);

                        SqlParameter pTen_Nhom_Chuc_Nang = new SqlParameter("@Ten_Nhom_Chuc_Nang", SqlDbType.NVarChar, 200);
                        pTen_Nhom_Chuc_Nang.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ten_Nhom_Chuc_Nang"];
                        myCommand.Parameters.Add(pTen_Nhom_Chuc_Nang);

                        SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                        pSTT.Value = (int)myDataSet.Tables[strTableName].Rows[i]["STT"];
                        myCommand.Parameters.Add(pSTT);

                        SqlParameter pDuoc_Hien_Thi = new SqlParameter("@Duoc_Hien_Thi", SqlDbType.Bit, 1);
                        pDuoc_Hien_Thi.Value = (bool)myDataSet.Tables[strTableName].Rows[i]["Duoc_Hien_Thi"];
                        myCommand.Parameters.Add(pDuoc_Hien_Thi);


                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(string Ma_Nhom_Chuc_Nang, string Ma_Du_An, string Ten_Nhom_Chuc_Nang, int STT, bool Duoc_Hien_Thi)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nhom_Chuc_Nang_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhom_Chuc_Nang = new SqlParameter("@Ma_Nhom_Chuc_Nang", SqlDbType.VarChar, 10);
                    pMa_Nhom_Chuc_Nang.Value = Ma_Nhom_Chuc_Nang;
                    myCommand.Parameters.Add(pMa_Nhom_Chuc_Nang);

                    SqlParameter pMa_Du_An = new SqlParameter("@Ma_Du_An", SqlDbType.VarChar, 2);
                    pMa_Du_An.Value = Ma_Du_An;
                    myCommand.Parameters.Add(pMa_Du_An);

                    SqlParameter pTen_Nhom_Chuc_Nang = new SqlParameter("@Ten_Nhom_Chuc_Nang", SqlDbType.NVarChar, 200);
                    pTen_Nhom_Chuc_Nang.Value = Ten_Nhom_Chuc_Nang;
                    myCommand.Parameters.Add(pTen_Nhom_Chuc_Nang);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Value = STT;
                    myCommand.Parameters.Add(pSTT);

                    SqlParameter pDuoc_Hien_Thi = new SqlParameter("@Duoc_Hien_Thi", SqlDbType.Bit, 1);
                    pDuoc_Hien_Thi.Value = Duoc_Hien_Thi;
                    myCommand.Parameters.Add(pDuoc_Hien_Thi);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(string Ma_Nhom_Chuc_Nang)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nhom_Chuc_Nang_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhom_Chuc_Nang = new SqlParameter("@Ma_Nhom_Chuc_Nang", SqlDbType.VarChar, 10);
                    pMa_Nhom_Chuc_Nang.Value = Ma_Nhom_Chuc_Nang;
                    myCommand.Parameters.Add(pMa_Nhom_Chuc_Nang);

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
                using (SqlCommand myCommand = new SqlCommand("HT_Nhom_Chuc_Nang_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Nhom_Chuc_Nang_Danh_Sach");
                    return myDataSet.Tables["HT_Nhom_Chuc_Nang_Danh_Sach"];
                }
            }
        }
        #endregion

        #region Lay_Boi_HT_Du_An
        public DataTable Lay_Boi_HT_Du_An(string Ma_Du_An)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nhom_Chuc_Nang_Lay_Boi_HT_Du_An", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Du_An = new SqlParameter("@Ma_Du_An", SqlDbType.VarChar, 2);
                    pMa_Du_An.Value = Ma_Du_An;
                    myCommand.Parameters.Add(pMa_Du_An);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Nhom_Chuc_Nang_Lay_Boi_HT_Du_An");
                    return myDataSet.Tables["HT_Nhom_Chuc_Nang_Lay_Boi_HT_Du_An"];
                }
            }
        }
        #endregion

    }
    #endregion
}

