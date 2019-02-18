using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region HT_Vai_Tro_Chuc_Nang_Details
    public class HT_Vai_Tro_Chuc_Nang_Chi_Tiet
    {
        public int Ma_Vai_Tro_Chuc_Nang; // Tổ hợp từ Mã vai trò và mã chức năng
        public string Ma_Du_An;
        public int Ma_Vai_Tro;
        public string Ma_Chuc_Nang;
        public bool Duoc_Truy_Cap; // Được phép truy nhập
        public bool Duoc_Xoa; // Được phép xóa
        public bool Duoc_Sua; // Được phép sửa
        public bool Duoc_Xuat; // Được phép xuất file Excel
        public bool Duoc_Nhap; // Được phép import từ Excel
    }
    #endregion
    #region HT_Vai_Tro_Chuc_Nang
    public class HT_Vai_Tro_Chuc_Nang
    {
        private string ConnectionString;
        public HT_Vai_Tro_Chuc_Nang(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public HT_Vai_Tro_Chuc_Nang_Chi_Tiet Lay(int Ma_Vai_Tro_Chuc_Nang)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Vai_Tro_Chuc_Nang_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Vai_Tro_Chuc_Nang = new SqlParameter("@Ma_Vai_Tro_Chuc_Nang", SqlDbType.Int, 4);
                    pMa_Vai_Tro_Chuc_Nang.Value = Ma_Vai_Tro_Chuc_Nang;
                    myCommand.Parameters.Add(pMa_Vai_Tro_Chuc_Nang);

                    SqlParameter pMa_Du_An = new SqlParameter("@Ma_Du_An", SqlDbType.VarChar, 2);
                    pMa_Du_An.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pMa_Du_An);

                    SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Vai_Tro.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pMa_Vai_Tro);

                    SqlParameter pMa_Chuc_Nang = new SqlParameter("@Ma_Chuc_Nang", SqlDbType.VarChar, 10);
                    pMa_Chuc_Nang.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pMa_Chuc_Nang);

                    SqlParameter pDuoc_Truy_Cap = new SqlParameter("@Duoc_Truy_Cap", SqlDbType.Bit, 1);
                    pDuoc_Truy_Cap.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pDuoc_Truy_Cap);

                    SqlParameter pDuoc_Xoa = new SqlParameter("@Duoc_Xoa", SqlDbType.Bit, 1);
                    pDuoc_Xoa.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pDuoc_Xoa);

                    SqlParameter pDuoc_Sua = new SqlParameter("@Duoc_Sua", SqlDbType.Bit, 1);
                    pDuoc_Sua.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pDuoc_Sua);

                    SqlParameter pDuoc_Xuat = new SqlParameter("@Duoc_Xuat", SqlDbType.Bit, 1);
                    pDuoc_Xuat.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pDuoc_Xuat);

                    SqlParameter pDuoc_Nhap = new SqlParameter("@Duoc_Nhap", SqlDbType.Bit, 1);
                    pDuoc_Nhap.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pDuoc_Nhap);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();


                    HT_Vai_Tro_Chuc_Nang_Chi_Tiet myHT_Vai_Tro_Chuc_Nang_Chi_Tiet = new HT_Vai_Tro_Chuc_Nang_Chi_Tiet();
                    myHT_Vai_Tro_Chuc_Nang_Chi_Tiet.Ma_Vai_Tro_Chuc_Nang = Ma_Vai_Tro_Chuc_Nang;
                    myHT_Vai_Tro_Chuc_Nang_Chi_Tiet.Ma_Du_An = (string)pMa_Du_An.Value;
                    myHT_Vai_Tro_Chuc_Nang_Chi_Tiet.Ma_Vai_Tro = (int)pMa_Vai_Tro.Value;
                    myHT_Vai_Tro_Chuc_Nang_Chi_Tiet.Ma_Chuc_Nang = (string)pMa_Chuc_Nang.Value;
                    myHT_Vai_Tro_Chuc_Nang_Chi_Tiet.Duoc_Truy_Cap = (bool)pDuoc_Truy_Cap.Value;
                    myHT_Vai_Tro_Chuc_Nang_Chi_Tiet.Duoc_Xoa = (bool)pDuoc_Xoa.Value;
                    myHT_Vai_Tro_Chuc_Nang_Chi_Tiet.Duoc_Sua = (bool)pDuoc_Sua.Value;
                    myHT_Vai_Tro_Chuc_Nang_Chi_Tiet.Duoc_Xuat = (bool)pDuoc_Xuat.Value;
                    myHT_Vai_Tro_Chuc_Nang_Chi_Tiet.Duoc_Nhap = (bool)pDuoc_Nhap.Value;
                    return myHT_Vai_Tro_Chuc_Nang_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public int Them(int Ma_Vai_Tro_Chuc_Nang, string Ma_Du_An, int Ma_Vai_Tro, string Ma_Chuc_Nang, bool Duoc_Truy_Cap, bool Duoc_Xoa, bool Duoc_Sua, bool Duoc_Xuat, bool Duoc_Nhap)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Vai_Tro_Chuc_Nang_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Vai_Tro_Chuc_Nang = new SqlParameter("@Ma_Vai_Tro_Chuc_Nang", SqlDbType.Int, 4);
                    pMa_Vai_Tro_Chuc_Nang.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pMa_Vai_Tro_Chuc_Nang);

                    SqlParameter pMa_Du_An = new SqlParameter("@Ma_Du_An", SqlDbType.VarChar, 2);
                    pMa_Du_An.Value = Ma_Du_An;
                    myCommand.Parameters.Add(pMa_Du_An);

                    SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Vai_Tro.Value = Ma_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Vai_Tro);

                    SqlParameter pMa_Chuc_Nang = new SqlParameter("@Ma_Chuc_Nang", SqlDbType.VarChar, 10);
                    pMa_Chuc_Nang.Value = Ma_Chuc_Nang;
                    myCommand.Parameters.Add(pMa_Chuc_Nang);

                    SqlParameter pDuoc_Truy_Cap = new SqlParameter("@Duoc_Truy_Cap", SqlDbType.Bit, 1);
                    pDuoc_Truy_Cap.Value = Duoc_Truy_Cap;
                    myCommand.Parameters.Add(pDuoc_Truy_Cap);

                    SqlParameter pDuoc_Xoa = new SqlParameter("@Duoc_Xoa", SqlDbType.Bit, 1);
                    pDuoc_Xoa.Value = Duoc_Xoa;
                    myCommand.Parameters.Add(pDuoc_Xoa);

                    SqlParameter pDuoc_Sua = new SqlParameter("@Duoc_Sua", SqlDbType.Bit, 1);
                    pDuoc_Sua.Value = Duoc_Sua;
                    myCommand.Parameters.Add(pDuoc_Sua);

                    SqlParameter pDuoc_Xuat = new SqlParameter("@Duoc_Xuat", SqlDbType.Bit, 1);
                    pDuoc_Xuat.Value = Duoc_Xuat;
                    myCommand.Parameters.Add(pDuoc_Xuat);

                    SqlParameter pDuoc_Nhap = new SqlParameter("@Duoc_Nhap", SqlDbType.Bit, 1);
                    pDuoc_Nhap.Value = Duoc_Nhap;
                    myCommand.Parameters.Add(pDuoc_Nhap);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    return (int)pMa_Vai_Tro_Chuc_Nang.Value;
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int Ma_Vai_Tro_Chuc_Nang, string Ma_Du_An, int Ma_Vai_Tro, string Ma_Chuc_Nang, bool Duoc_Truy_Cap, bool Duoc_Xoa, bool Duoc_Sua, bool Duoc_Xuat, bool Duoc_Nhap)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Vai_Tro_Chuc_Nang_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Vai_Tro_Chuc_Nang = new SqlParameter("@Ma_Vai_Tro_Chuc_Nang", SqlDbType.Int, 4);
                    pMa_Vai_Tro_Chuc_Nang.Value = Ma_Vai_Tro_Chuc_Nang;
                    myCommand.Parameters.Add(pMa_Vai_Tro_Chuc_Nang);

                    SqlParameter pMa_Du_An = new SqlParameter("@Ma_Du_An", SqlDbType.VarChar, 2);
                    pMa_Du_An.Value = Ma_Du_An;
                    myCommand.Parameters.Add(pMa_Du_An);

                    SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Vai_Tro.Value = Ma_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Vai_Tro);

                    SqlParameter pMa_Chuc_Nang = new SqlParameter("@Ma_Chuc_Nang", SqlDbType.VarChar, 10);
                    pMa_Chuc_Nang.Value = Ma_Chuc_Nang;
                    myCommand.Parameters.Add(pMa_Chuc_Nang);

                    SqlParameter pDuoc_Truy_Cap = new SqlParameter("@Duoc_Truy_Cap", SqlDbType.Bit, 1);
                    pDuoc_Truy_Cap.Value = Duoc_Truy_Cap;
                    myCommand.Parameters.Add(pDuoc_Truy_Cap);

                    SqlParameter pDuoc_Xoa = new SqlParameter("@Duoc_Xoa", SqlDbType.Bit, 1);
                    pDuoc_Xoa.Value = Duoc_Xoa;
                    myCommand.Parameters.Add(pDuoc_Xoa);

                    SqlParameter pDuoc_Sua = new SqlParameter("@Duoc_Sua", SqlDbType.Bit, 1);
                    pDuoc_Sua.Value = Duoc_Sua;
                    myCommand.Parameters.Add(pDuoc_Sua);

                    SqlParameter pDuoc_Xuat = new SqlParameter("@Duoc_Xuat", SqlDbType.Bit, 1);
                    pDuoc_Xuat.Value = Duoc_Xuat;
                    myCommand.Parameters.Add(pDuoc_Xuat);

                    SqlParameter pDuoc_Nhap = new SqlParameter("@Duoc_Nhap", SqlDbType.Bit, 1);
                    pDuoc_Nhap.Value = Duoc_Nhap;
                    myCommand.Parameters.Add(pDuoc_Nhap);



                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(HT_Vai_Tro_Chuc_Nang_Chi_Tiet myHT_Vai_Tro_Chuc_Nang_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Vai_Tro_Chuc_Nang_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Vai_Tro_Chuc_Nang = new SqlParameter("@Ma_Vai_Tro_Chuc_Nang", SqlDbType.Int, 4);
                    pMa_Vai_Tro_Chuc_Nang.Value = myHT_Vai_Tro_Chuc_Nang_Chi_Tiet.Ma_Vai_Tro_Chuc_Nang;
                    myCommand.Parameters.Add(pMa_Vai_Tro_Chuc_Nang);

                    SqlParameter pMa_Du_An = new SqlParameter("@Ma_Du_An", SqlDbType.VarChar, 2);
                    pMa_Du_An.Value = myHT_Vai_Tro_Chuc_Nang_Chi_Tiet.Ma_Du_An;
                    myCommand.Parameters.Add(pMa_Du_An);

                    SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Vai_Tro.Value = myHT_Vai_Tro_Chuc_Nang_Chi_Tiet.Ma_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Vai_Tro);

                    SqlParameter pMa_Chuc_Nang = new SqlParameter("@Ma_Chuc_Nang", SqlDbType.VarChar, 10);
                    pMa_Chuc_Nang.Value = myHT_Vai_Tro_Chuc_Nang_Chi_Tiet.Ma_Chuc_Nang;
                    myCommand.Parameters.Add(pMa_Chuc_Nang);

                    SqlParameter pDuoc_Truy_Cap = new SqlParameter("@Duoc_Truy_Cap", SqlDbType.Bit, 1);
                    pDuoc_Truy_Cap.Value = myHT_Vai_Tro_Chuc_Nang_Chi_Tiet.Duoc_Truy_Cap;
                    myCommand.Parameters.Add(pDuoc_Truy_Cap);

                    SqlParameter pDuoc_Xoa = new SqlParameter("@Duoc_Xoa", SqlDbType.Bit, 1);
                    pDuoc_Xoa.Value = myHT_Vai_Tro_Chuc_Nang_Chi_Tiet.Duoc_Xoa;
                    myCommand.Parameters.Add(pDuoc_Xoa);

                    SqlParameter pDuoc_Sua = new SqlParameter("@Duoc_Sua", SqlDbType.Bit, 1);
                    pDuoc_Sua.Value = myHT_Vai_Tro_Chuc_Nang_Chi_Tiet.Duoc_Sua;
                    myCommand.Parameters.Add(pDuoc_Sua);

                    SqlParameter pDuoc_Xuat = new SqlParameter("@Duoc_Xuat", SqlDbType.Bit, 1);
                    pDuoc_Xuat.Value = myHT_Vai_Tro_Chuc_Nang_Chi_Tiet.Duoc_Xuat;
                    myCommand.Parameters.Add(pDuoc_Xuat);

                    SqlParameter pDuoc_Nhap = new SqlParameter("@Duoc_Nhap", SqlDbType.Bit, 1);
                    pDuoc_Nhap.Value = myHT_Vai_Tro_Chuc_Nang_Chi_Tiet.Duoc_Nhap;
                    myCommand.Parameters.Add(pDuoc_Nhap);


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
                using (SqlCommand myCommand = new SqlCommand("HT_Vai_Tro_Chuc_Nang_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Vai_Tro_Chuc_Nang = new SqlParameter("@Ma_Vai_Tro_Chuc_Nang", SqlDbType.Int, 4);
                        pMa_Vai_Tro_Chuc_Nang.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Vai_Tro_Chuc_Nang"];
                        myCommand.Parameters.Add(pMa_Vai_Tro_Chuc_Nang);

                        SqlParameter pMa_Du_An = new SqlParameter("@Ma_Du_An", SqlDbType.VarChar, 2);
                        pMa_Du_An.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ma_Du_An"];
                        myCommand.Parameters.Add(pMa_Du_An);

                        SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                        pMa_Vai_Tro.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Vai_Tro"];
                        myCommand.Parameters.Add(pMa_Vai_Tro);

                        SqlParameter pMa_Chuc_Nang = new SqlParameter("@Ma_Chuc_Nang", SqlDbType.VarChar, 10);
                        pMa_Chuc_Nang.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ma_Chuc_Nang"];
                        myCommand.Parameters.Add(pMa_Chuc_Nang);

                        SqlParameter pDuoc_Truy_Cap = new SqlParameter("@Duoc_Truy_Cap", SqlDbType.Bit, 1);
                        pDuoc_Truy_Cap.Value = (bool)myDataSet.Tables[strTableName].Rows[i]["Duoc_Truy_Cap"];
                        myCommand.Parameters.Add(pDuoc_Truy_Cap);

                        SqlParameter pDuoc_Xoa = new SqlParameter("@Duoc_Xoa", SqlDbType.Bit, 1);
                        pDuoc_Xoa.Value = (bool)myDataSet.Tables[strTableName].Rows[i]["Duoc_Xoa"];
                        myCommand.Parameters.Add(pDuoc_Xoa);

                        SqlParameter pDuoc_Sua = new SqlParameter("@Duoc_Sua", SqlDbType.Bit, 1);
                        pDuoc_Sua.Value = (bool)myDataSet.Tables[strTableName].Rows[i]["Duoc_Sua"];
                        myCommand.Parameters.Add(pDuoc_Sua);

                        SqlParameter pDuoc_Xuat = new SqlParameter("@Duoc_Xuat", SqlDbType.Bit, 1);
                        pDuoc_Xuat.Value = (bool)myDataSet.Tables[strTableName].Rows[i]["Duoc_Xuat"];
                        myCommand.Parameters.Add(pDuoc_Xuat);

                        SqlParameter pDuoc_Nhap = new SqlParameter("@Duoc_Nhap", SqlDbType.Bit, 1);
                        pDuoc_Nhap.Value = (bool)myDataSet.Tables[strTableName].Rows[i]["Duoc_Nhap"];
                        myCommand.Parameters.Add(pDuoc_Nhap);


                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int Ma_Vai_Tro_Chuc_Nang, string Ma_Du_An, int Ma_Vai_Tro, string Ma_Chuc_Nang, bool Duoc_Truy_Cap, bool Duoc_Xoa, bool Duoc_Sua, bool Duoc_Xuat, bool Duoc_Nhap,bool Duoc_Duyet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Vai_Tro_Chuc_Nang_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Vai_Tro_Chuc_Nang = new SqlParameter("@Ma_Vai_Tro_Chuc_Nang", SqlDbType.Int, 4);
                    pMa_Vai_Tro_Chuc_Nang.Value = Ma_Vai_Tro_Chuc_Nang;
                    myCommand.Parameters.Add(pMa_Vai_Tro_Chuc_Nang);

                    SqlParameter pMa_Du_An = new SqlParameter("@Ma_Du_An", SqlDbType.VarChar, 2);
                    pMa_Du_An.Value = Ma_Du_An;
                    myCommand.Parameters.Add(pMa_Du_An);

                    SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Vai_Tro.Value = Ma_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Vai_Tro);

                    SqlParameter pMa_Chuc_Nang = new SqlParameter("@Ma_Chuc_Nang", SqlDbType.VarChar, 10);
                    pMa_Chuc_Nang.Value = Ma_Chuc_Nang;
                    myCommand.Parameters.Add(pMa_Chuc_Nang);

                    SqlParameter pDuoc_Truy_Cap = new SqlParameter("@Duoc_Truy_Cap", SqlDbType.Bit, 1);
                    pDuoc_Truy_Cap.Value = Duoc_Truy_Cap;
                    myCommand.Parameters.Add(pDuoc_Truy_Cap);

                    SqlParameter pDuoc_Xoa = new SqlParameter("@Duoc_Xoa", SqlDbType.Bit, 1);
                    pDuoc_Xoa.Value = Duoc_Xoa;
                    myCommand.Parameters.Add(pDuoc_Xoa);

                    SqlParameter pDuoc_Sua = new SqlParameter("@Duoc_Sua", SqlDbType.Bit, 1);
                    pDuoc_Sua.Value = Duoc_Sua;
                    myCommand.Parameters.Add(pDuoc_Sua);

                    SqlParameter pDuoc_Xuat = new SqlParameter("@Duoc_Xuat", SqlDbType.Bit, 1);
                    pDuoc_Xuat.Value = Duoc_Xuat;
                    myCommand.Parameters.Add(pDuoc_Xuat);

                    SqlParameter pDuoc_Nhap = new SqlParameter("@Duoc_Nhap", SqlDbType.Bit, 1);
                    pDuoc_Nhap.Value = Duoc_Nhap;
                    myCommand.Parameters.Add(pDuoc_Nhap);

                    SqlParameter pDuoc_Duyet = new SqlParameter("@Duoc_Duyet", SqlDbType.Bit, 1);
                    pDuoc_Duyet.Value = Duoc_Duyet;
                    myCommand.Parameters.Add(pDuoc_Duyet);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Ma_Vai_Tro_Chuc_Nang)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Vai_Tro_Chuc_Nang_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Vai_Tro_Chuc_Nang = new SqlParameter("@Ma_Vai_Tro_Chuc_Nang", SqlDbType.Int, 4);
                    pMa_Vai_Tro_Chuc_Nang.Value = Ma_Vai_Tro_Chuc_Nang;
                    myCommand.Parameters.Add(pMa_Vai_Tro_Chuc_Nang);

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
                using (SqlCommand myCommand = new SqlCommand("HT_Vai_Tro_Chuc_Nang_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Vai_Tro_Chuc_Nang_Danh_Sach");
                    return myDataSet.Tables["HT_Vai_Tro_Chuc_Nang_Danh_Sach"];
                }
            }
        }
        #endregion

        #region Lay_Boi_HT_Chuc_Nang
        public DataTable Lay_Boi_HT_Chuc_Nang(string Ma_Chuc_Nang)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Vai_Tro_Chuc_Nang_Lay_Boi_HT_Chuc_Nang", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Chuc_Nang = new SqlParameter("@Ma_Chuc_Nang", SqlDbType.VarChar, 10);
                    pMa_Chuc_Nang.Value = Ma_Chuc_Nang;
                    myCommand.Parameters.Add(pMa_Chuc_Nang);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Vai_Tro_Chuc_Nang_Lay_Boi_HT_Chuc_Nang");
                    return myDataSet.Tables["HT_Vai_Tro_Chuc_Nang_Lay_Boi_HT_Chuc_Nang"];
                }
            }
        }
        #endregion
        #region Lay_Boi_HT_Du_An
        public DataTable Lay_Boi_HT_Du_An(string Ma_Du_An)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Vai_Tro_Chuc_Nang_Lay_Boi_HT_Du_An", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Du_An = new SqlParameter("@Ma_Du_An", SqlDbType.VarChar, 2);
                    pMa_Du_An.Value = Ma_Du_An;
                    myCommand.Parameters.Add(pMa_Du_An);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Vai_Tro_Chuc_Nang_Lay_Boi_HT_Du_An");
                    return myDataSet.Tables["HT_Vai_Tro_Chuc_Nang_Lay_Boi_HT_Du_An"];
                }
            }
        }
        #endregion
        #region Lay_Boi_HT_Vai_Tro
        public DataTable Lay_Boi_HT_Vai_Tro(int Ma_Vai_Tro)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Vai_Tro_Chuc_Nang_Lay_Boi_HT_Vai_Tro", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Vai_Tro.Value = Ma_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Vai_Tro);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Vai_Tro_Chuc_Nang_Lay_Boi_HT_Vai_Tro");
                    return myDataSet.Tables["HT_Vai_Tro_Chuc_Nang_Lay_Boi_HT_Vai_Tro"];
                }
            }
        }
        #endregion

        //New
        #region HT_Vai_Tro_Chuc_Nang_Lay_Boi_HT_Vai_Tro_Du_An
        public DataTable HT_Vai_Tro_Chuc_Nang_Lay_Boi_HT_Vai_Tro_Du_An(int Ma_Vai_Tro, string Ma_Du_An)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Vai_Tro_Chuc_Nang_Lay_Boi_HT_Vai_Tro_Du_An", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Vai_Tro.Value = Ma_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Vai_Tro);

                    SqlParameter pMa_Du_An = new SqlParameter("@Ma_Du_An", SqlDbType.VarChar, 2);
                    pMa_Du_An.Value = Ma_Du_An;
                    myCommand.Parameters.Add(pMa_Du_An);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Vai_Tro_Chuc_Nang_Lay_Boi_HT_Vai_Tro_Du_An");
                    return myDataSet.Tables["HT_Vai_Tro_Chuc_Nang_Lay_Boi_HT_Vai_Tro_Du_An"];
                }
            }
        }
        #endregion
    }
    #endregion
}