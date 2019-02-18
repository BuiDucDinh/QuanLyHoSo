
using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region HT_DM_Tuan_Details
    public class HT_DM_Tuan_Chi_Tiet
    {
        public int Ma_Tuan;
        public int Tuan_So;
        public int Nam_Tinh;
        public DateTime Tu_Ngay;
        public DateTime Den_Ngay;
    }
    #endregion
    #region HT_DM_Tuan
    public class HT_DM_Tuan
    {
        private string ConnectionString;
        public HT_DM_Tuan(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public HT_DM_Tuan_Chi_Tiet Lay(int Ma_Tuan)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_DM_Tuan_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Tuan = new SqlParameter("@Ma_Tuan", SqlDbType.Int, 4);
                    pMa_Tuan.Value = Ma_Tuan;
                    myCommand.Parameters.Add(pMa_Tuan);

                    SqlParameter pTuan_So = new SqlParameter("@Tuan_So", SqlDbType.Int, 4);
                    pTuan_So.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pTuan_So);

                    SqlParameter pNam_Tinh = new SqlParameter("@Nam_Tinh", SqlDbType.Int, 4);
                    pNam_Tinh.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pNam_Tinh);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pDen_Ngay);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();


                    HT_DM_Tuan_Chi_Tiet myHT_DM_Tuan_Chi_Tiet = new HT_DM_Tuan_Chi_Tiet();
                    myHT_DM_Tuan_Chi_Tiet.Ma_Tuan = Ma_Tuan;
                    myHT_DM_Tuan_Chi_Tiet.Tuan_So = (int)pTuan_So.Value;
                    myHT_DM_Tuan_Chi_Tiet.Nam_Tinh = (int)pNam_Tinh.Value;
                    myHT_DM_Tuan_Chi_Tiet.Tu_Ngay = (DateTime)pTu_Ngay.Value;
                    myHT_DM_Tuan_Chi_Tiet.Den_Ngay = (DateTime)pDen_Ngay.Value;
                    return myHT_DM_Tuan_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public int Them(int Ma_Tuan, int Tuan_So, int Nam_Tinh, DateTime Tu_Ngay, DateTime Den_Ngay)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_DM_Tuan_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Tuan = new SqlParameter("@Ma_Tuan", SqlDbType.Int, 4);
                    pMa_Tuan.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pMa_Tuan);

                    SqlParameter pTuan_So = new SqlParameter("@Tuan_So", SqlDbType.Int, 4);
                    pTuan_So.Value = Tuan_So;
                    myCommand.Parameters.Add(pTuan_So);

                    SqlParameter pNam_Tinh = new SqlParameter("@Nam_Tinh", SqlDbType.Int, 4);
                    pNam_Tinh.Value = Nam_Tinh;
                    myCommand.Parameters.Add(pNam_Tinh);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    return (int)pMa_Tuan.Value;
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int Ma_Tuan, int Tuan_So, int Nam_Tinh, DateTime Tu_Ngay, DateTime Den_Ngay)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_DM_Tuan_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Tuan = new SqlParameter("@Ma_Tuan", SqlDbType.Int, 4);
                    pMa_Tuan.Value = Ma_Tuan;
                    myCommand.Parameters.Add(pMa_Tuan);

                    SqlParameter pTuan_So = new SqlParameter("@Tuan_So", SqlDbType.Int, 4);
                    pTuan_So.Value = Tuan_So;
                    myCommand.Parameters.Add(pTuan_So);

                    SqlParameter pNam_Tinh = new SqlParameter("@Nam_Tinh", SqlDbType.Int, 4);
                    pNam_Tinh.Value = Nam_Tinh;
                    myCommand.Parameters.Add(pNam_Tinh);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);



                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(HT_DM_Tuan_Chi_Tiet myHT_DM_Tuan_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_DM_Tuan_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Tuan = new SqlParameter("@Ma_Tuan", SqlDbType.Int, 4);
                    pMa_Tuan.Value = myHT_DM_Tuan_Chi_Tiet.Ma_Tuan;
                    myCommand.Parameters.Add(pMa_Tuan);

                    SqlParameter pTuan_So = new SqlParameter("@Tuan_So", SqlDbType.Int, 4);
                    pTuan_So.Value = myHT_DM_Tuan_Chi_Tiet.Tuan_So;
                    myCommand.Parameters.Add(pTuan_So);

                    SqlParameter pNam_Tinh = new SqlParameter("@Nam_Tinh", SqlDbType.Int, 4);
                    pNam_Tinh.Value = myHT_DM_Tuan_Chi_Tiet.Nam_Tinh;
                    myCommand.Parameters.Add(pNam_Tinh);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = myHT_DM_Tuan_Chi_Tiet.Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = myHT_DM_Tuan_Chi_Tiet.Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);


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
                using (SqlCommand myCommand = new SqlCommand("HT_DM_Tuan_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Tuan = new SqlParameter("@Ma_Tuan", SqlDbType.Int, 4);
                        pMa_Tuan.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Tuan"];
                        myCommand.Parameters.Add(pMa_Tuan);

                        SqlParameter pTuan_So = new SqlParameter("@Tuan_So", SqlDbType.Int, 4);
                        pTuan_So.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Tuan_So"];
                        myCommand.Parameters.Add(pTuan_So);

                        SqlParameter pNam_Tinh = new SqlParameter("@Nam_Tinh", SqlDbType.Int, 4);
                        pNam_Tinh.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Nam_Tinh"];
                        myCommand.Parameters.Add(pNam_Tinh);

                        SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                        pTu_Ngay.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Tu_Ngay"];
                        myCommand.Parameters.Add(pTu_Ngay);

                        SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                        pDen_Ngay.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Den_Ngay"];
                        myCommand.Parameters.Add(pDen_Ngay);


                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int Ma_Tuan, int Tuan_So, int Nam_Tinh, DateTime Tu_Ngay, DateTime Den_Ngay)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_DM_Tuan_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Tuan = new SqlParameter("@Ma_Tuan", SqlDbType.Int, 4);
                    pMa_Tuan.Value = Ma_Tuan;
                    myCommand.Parameters.Add(pMa_Tuan);

                    SqlParameter pTuan_So = new SqlParameter("@Tuan_So", SqlDbType.Int, 4);
                    pTuan_So.Value = Tuan_So;
                    myCommand.Parameters.Add(pTuan_So);

                    SqlParameter pNam_Tinh = new SqlParameter("@Nam_Tinh", SqlDbType.Int, 4);
                    pNam_Tinh.Value = Nam_Tinh;
                    myCommand.Parameters.Add(pNam_Tinh);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Ma_Tuan)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_DM_Tuan_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Tuan = new SqlParameter("@Ma_Tuan", SqlDbType.Int, 4);
                    pMa_Tuan.Value = Ma_Tuan;
                    myCommand.Parameters.Add(pMa_Tuan);

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
                using (SqlCommand myCommand = new SqlCommand("HT_DM_Tuan_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_DM_Tuan_Danh_Sach");
                    return myDataSet.Tables["HT_DM_Tuan_Danh_Sach"];
                }
            }
        }
        #endregion


    }
    #endregion
}