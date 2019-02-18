
using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region HT_Chuc_Nang_Details
    public class HT_Chuc_Nang_Chi_Tiet
    {
        public string Ma_Chuc_Nang; // Mã chức năng (tổ hợp từ mã nhóm chức năng và STT chức năng)
        public string Ma_Nhom_Chuc_Nang;
        public string Ten_Chuc_Nang; // Tên chức năng
        public int STT; // Số thứ tự
        public bool Duoc_Hien_Thi; // Cho phép hiển thị hay không
        public string Icon; // Icon cho chức năng
        public string Duong_Dan;
    }
    #endregion
    #region HT_Chuc_Nang
    public class HT_Chuc_Nang
    {
        private string ConnectionString;
        public HT_Chuc_Nang(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public HT_Chuc_Nang_Chi_Tiet Lay(string Ma_Chuc_Nang)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Chuc_Nang_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Chuc_Nang = new SqlParameter("@Ma_Chuc_Nang", SqlDbType.VarChar, 10);
                    pMa_Chuc_Nang.Value = Ma_Chuc_Nang;
                    myCommand.Parameters.Add(pMa_Chuc_Nang);

                    SqlParameter pMa_Nhom_Chuc_Nang = new SqlParameter("@Ma_Nhom_Chuc_Nang", SqlDbType.VarChar, 10);
                    pMa_Nhom_Chuc_Nang.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pMa_Nhom_Chuc_Nang);

                    SqlParameter pTen_Chuc_Nang = new SqlParameter("@Ten_Chuc_Nang", SqlDbType.NVarChar, 200);
                    pTen_Chuc_Nang.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pTen_Chuc_Nang);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pSTT);

                    SqlParameter pDuoc_Hien_Thi = new SqlParameter("@Duoc_Hien_Thi", SqlDbType.Bit, 1);
                    pDuoc_Hien_Thi.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pDuoc_Hien_Thi);

                    SqlParameter pIcon = new SqlParameter("@Icon", SqlDbType.NVarChar, 50);
                    pIcon.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pIcon);

                    SqlParameter pDuong_Dan = new SqlParameter("@Duong_Dan", SqlDbType.NVarChar, 250);
                    pDuong_Dan.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pDuong_Dan);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();


                    HT_Chuc_Nang_Chi_Tiet myHT_Chuc_Nang_Chi_Tiet = new HT_Chuc_Nang_Chi_Tiet();
                    myHT_Chuc_Nang_Chi_Tiet.Ma_Chuc_Nang = Ma_Chuc_Nang;
                    myHT_Chuc_Nang_Chi_Tiet.Ma_Nhom_Chuc_Nang = (string)pMa_Nhom_Chuc_Nang.Value;
                    myHT_Chuc_Nang_Chi_Tiet.Ten_Chuc_Nang = (string)pTen_Chuc_Nang.Value;
                    myHT_Chuc_Nang_Chi_Tiet.STT = (int)pSTT.Value;
                    myHT_Chuc_Nang_Chi_Tiet.Duoc_Hien_Thi = (bool)pDuoc_Hien_Thi.Value;
                    myHT_Chuc_Nang_Chi_Tiet.Icon = (string)pIcon.Value;
                    myHT_Chuc_Nang_Chi_Tiet.Duong_Dan = (string)pDuong_Dan.Value;
                    return myHT_Chuc_Nang_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public string Them(string Ma_Chuc_Nang, string Ma_Nhom_Chuc_Nang, string Ten_Chuc_Nang, int STT, bool Duoc_Hien_Thi, string Icon, string Duong_Dan)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Chuc_Nang_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Chuc_Nang = new SqlParameter("@Ma_Chuc_Nang", SqlDbType.VarChar, 10);
                    pMa_Chuc_Nang.Value = Ma_Chuc_Nang;
                    myCommand.Parameters.Add(pMa_Chuc_Nang);

                    SqlParameter pMa_Nhom_Chuc_Nang = new SqlParameter("@Ma_Nhom_Chuc_Nang", SqlDbType.VarChar, 10);
                    pMa_Nhom_Chuc_Nang.Value = Ma_Nhom_Chuc_Nang;
                    myCommand.Parameters.Add(pMa_Nhom_Chuc_Nang);

                    SqlParameter pTen_Chuc_Nang = new SqlParameter("@Ten_Chuc_Nang", SqlDbType.NVarChar, 200);
                    pTen_Chuc_Nang.Value = Ten_Chuc_Nang;
                    myCommand.Parameters.Add(pTen_Chuc_Nang);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Value = STT;
                    myCommand.Parameters.Add(pSTT);

                    SqlParameter pDuoc_Hien_Thi = new SqlParameter("@Duoc_Hien_Thi", SqlDbType.Bit, 1);
                    pDuoc_Hien_Thi.Value = Duoc_Hien_Thi;
                    myCommand.Parameters.Add(pDuoc_Hien_Thi);

                    SqlParameter pIcon = new SqlParameter("@Icon", SqlDbType.NVarChar, 50);
                    pIcon.Value = Icon;
                    myCommand.Parameters.Add(pIcon);

                    SqlParameter pDuong_Dan = new SqlParameter("@Duong_Dan", SqlDbType.NVarChar, 250);
                    pDuong_Dan.Value = Duong_Dan;
                    myCommand.Parameters.Add(pDuong_Dan);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    return (string)pMa_Chuc_Nang.Value;
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(string Ma_Chuc_Nang, string Ma_Nhom_Chuc_Nang, string Ten_Chuc_Nang, int STT, bool Duoc_Hien_Thi, string Icon, string Duong_Dan)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Chuc_Nang_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Chuc_Nang = new SqlParameter("@Ma_Chuc_Nang", SqlDbType.VarChar, 10);
                    pMa_Chuc_Nang.Value = Ma_Chuc_Nang;
                    myCommand.Parameters.Add(pMa_Chuc_Nang);

                    SqlParameter pMa_Nhom_Chuc_Nang = new SqlParameter("@Ma_Nhom_Chuc_Nang", SqlDbType.VarChar, 10);
                    pMa_Nhom_Chuc_Nang.Value = Ma_Nhom_Chuc_Nang;
                    myCommand.Parameters.Add(pMa_Nhom_Chuc_Nang);

                    SqlParameter pTen_Chuc_Nang = new SqlParameter("@Ten_Chuc_Nang", SqlDbType.NVarChar, 200);
                    pTen_Chuc_Nang.Value = Ten_Chuc_Nang;
                    myCommand.Parameters.Add(pTen_Chuc_Nang);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Value = STT;
                    myCommand.Parameters.Add(pSTT);

                    SqlParameter pDuoc_Hien_Thi = new SqlParameter("@Duoc_Hien_Thi", SqlDbType.Bit, 1);
                    pDuoc_Hien_Thi.Value = Duoc_Hien_Thi;
                    myCommand.Parameters.Add(pDuoc_Hien_Thi);

                    SqlParameter pIcon = new SqlParameter("@Icon", SqlDbType.NVarChar, 50);
                    pIcon.Value = Icon;
                    myCommand.Parameters.Add(pIcon);

                    SqlParameter pDuong_Dan = new SqlParameter("@Duong_Dan", SqlDbType.NVarChar, 250);
                    pDuong_Dan.Value = Duong_Dan;
                    myCommand.Parameters.Add(pDuong_Dan);



                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(HT_Chuc_Nang_Chi_Tiet myHT_Chuc_Nang_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Chuc_Nang_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Chuc_Nang = new SqlParameter("@Ma_Chuc_Nang", SqlDbType.VarChar, 10);
                    pMa_Chuc_Nang.Value = myHT_Chuc_Nang_Chi_Tiet.Ma_Chuc_Nang;
                    myCommand.Parameters.Add(pMa_Chuc_Nang);

                    SqlParameter pMa_Nhom_Chuc_Nang = new SqlParameter("@Ma_Nhom_Chuc_Nang", SqlDbType.VarChar, 10);
                    pMa_Nhom_Chuc_Nang.Value = myHT_Chuc_Nang_Chi_Tiet.Ma_Nhom_Chuc_Nang;
                    myCommand.Parameters.Add(pMa_Nhom_Chuc_Nang);

                    SqlParameter pTen_Chuc_Nang = new SqlParameter("@Ten_Chuc_Nang", SqlDbType.NVarChar, 200);
                    pTen_Chuc_Nang.Value = myHT_Chuc_Nang_Chi_Tiet.Ten_Chuc_Nang;
                    myCommand.Parameters.Add(pTen_Chuc_Nang);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Value = myHT_Chuc_Nang_Chi_Tiet.STT;
                    myCommand.Parameters.Add(pSTT);

                    SqlParameter pDuoc_Hien_Thi = new SqlParameter("@Duoc_Hien_Thi", SqlDbType.Bit, 1);
                    pDuoc_Hien_Thi.Value = myHT_Chuc_Nang_Chi_Tiet.Duoc_Hien_Thi;
                    myCommand.Parameters.Add(pDuoc_Hien_Thi);

                    SqlParameter pIcon = new SqlParameter("@Icon", SqlDbType.NVarChar, 50);
                    pIcon.Value = myHT_Chuc_Nang_Chi_Tiet.Icon;
                    myCommand.Parameters.Add(pIcon);

                    SqlParameter pDuong_Dan = new SqlParameter("@Duong_Dan", SqlDbType.NVarChar, 250);
                    pDuong_Dan.Value = myHT_Chuc_Nang_Chi_Tiet.Duong_Dan;
                    myCommand.Parameters.Add(pDuong_Dan);


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
                using (SqlCommand myCommand = new SqlCommand("HT_Chuc_Nang_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Chuc_Nang = new SqlParameter("@Ma_Chuc_Nang", SqlDbType.VarChar, 10);
                        pMa_Chuc_Nang.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ma_Chuc_Nang"];
                        myCommand.Parameters.Add(pMa_Chuc_Nang);

                        SqlParameter pMa_Nhom_Chuc_Nang = new SqlParameter("@Ma_Nhom_Chuc_Nang", SqlDbType.VarChar, 10);
                        pMa_Nhom_Chuc_Nang.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ma_Nhom_Chuc_Nang"];
                        myCommand.Parameters.Add(pMa_Nhom_Chuc_Nang);

                        SqlParameter pTen_Chuc_Nang = new SqlParameter("@Ten_Chuc_Nang", SqlDbType.NVarChar, 200);
                        pTen_Chuc_Nang.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ten_Chuc_Nang"];
                        myCommand.Parameters.Add(pTen_Chuc_Nang);

                        SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                        pSTT.Value = (int)myDataSet.Tables[strTableName].Rows[i]["STT"];
                        myCommand.Parameters.Add(pSTT);

                        SqlParameter pDuoc_Hien_Thi = new SqlParameter("@Duoc_Hien_Thi", SqlDbType.Bit, 1);
                        pDuoc_Hien_Thi.Value = (bool)myDataSet.Tables[strTableName].Rows[i]["Duoc_Hien_Thi"];
                        myCommand.Parameters.Add(pDuoc_Hien_Thi);

                        SqlParameter pIcon = new SqlParameter("@Icon", SqlDbType.NVarChar, 50);
                        pIcon.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Icon"];
                        myCommand.Parameters.Add(pIcon);

                        SqlParameter pDuong_Dan = new SqlParameter("@Duong_Dan", SqlDbType.NVarChar, 250);
                        pDuong_Dan.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Duong_Dan"];
                        myCommand.Parameters.Add(pDuong_Dan);


                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion
        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(string Ma_Chuc_Nang, string Ma_Nhom_Chuc_Nang, string Ten_Chuc_Nang, int STT, bool Duoc_Hien_Thi, string Icon, string Duong_Dan)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Chuc_Nang_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Chuc_Nang = new SqlParameter("@Ma_Chuc_Nang", SqlDbType.VarChar, 10);
                    pMa_Chuc_Nang.Value = Ma_Chuc_Nang;
                    myCommand.Parameters.Add(pMa_Chuc_Nang);

                    SqlParameter pMa_Nhom_Chuc_Nang = new SqlParameter("@Ma_Nhom_Chuc_Nang", SqlDbType.VarChar, 10);
                    pMa_Nhom_Chuc_Nang.Value = Ma_Nhom_Chuc_Nang;
                    myCommand.Parameters.Add(pMa_Nhom_Chuc_Nang);

                    SqlParameter pTen_Chuc_Nang = new SqlParameter("@Ten_Chuc_Nang", SqlDbType.NVarChar, 200);
                    pTen_Chuc_Nang.Value = Ten_Chuc_Nang;
                    myCommand.Parameters.Add(pTen_Chuc_Nang);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int, 4);
                    pSTT.Value = STT;
                    myCommand.Parameters.Add(pSTT);

                    SqlParameter pDuoc_Hien_Thi = new SqlParameter("@Duoc_Hien_Thi", SqlDbType.Bit, 1);
                    pDuoc_Hien_Thi.Value = Duoc_Hien_Thi;
                    myCommand.Parameters.Add(pDuoc_Hien_Thi);

                    SqlParameter pIcon = new SqlParameter("@Icon", SqlDbType.NVarChar, 50);
                    pIcon.Value = Icon;
                    myCommand.Parameters.Add(pIcon);

                    SqlParameter pDuong_Dan = new SqlParameter("@Duong_Dan", SqlDbType.NVarChar, 250);
                    pDuong_Dan.Value = Duong_Dan;
                    myCommand.Parameters.Add(pDuong_Dan);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Xoa
        public void Xoa(string Ma_Chuc_Nang)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Chuc_Nang_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Chuc_Nang = new SqlParameter("@Ma_Chuc_Nang", SqlDbType.VarChar, 10);
                    pMa_Chuc_Nang.Value = Ma_Chuc_Nang;
                    myCommand.Parameters.Add(pMa_Chuc_Nang);

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
                using (SqlCommand myCommand = new SqlCommand("HT_Chuc_Nang_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Chuc_Nang_Danh_Sach");
                    return myDataSet.Tables["HT_Chuc_Nang_Danh_Sach"];
                }
            }
        }
        #endregion
        #region Lay_Boi_HT_Nhom_Chuc_Nang
        public DataTable Lay_Boi_HT_Nhom_Chuc_Nang(string Ma_Nhom_Chuc_Nang)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Chuc_Nang_Lay_Boi_HT_Nhom_Chuc_Nang", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Nhom_Chuc_Nang = new SqlParameter("@Ma_Nhom_Chuc_Nang", SqlDbType.VarChar, 10);
                    pMa_Nhom_Chuc_Nang.Value = Ma_Nhom_Chuc_Nang;
                    myCommand.Parameters.Add(pMa_Nhom_Chuc_Nang);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Chuc_Nang_Lay_Boi_HT_Nhom_Chuc_Nang");
                    return myDataSet.Tables["HT_Chuc_Nang_Lay_Boi_HT_Nhom_Chuc_Nang"];
                }
            }
        }
        #endregion
    }
    #endregion
}