using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region NL_To_Nhom_Details
    public class NL_To_Nhom_Chi_Tiet
    {
        public int? Ma_To_Nhom = null; // Mã tổ nhóm
        public int? Ma_Nhan_Vien = null; // Mã nhân viên
        public DateTime? Tu_Ngay = null; // Từ ngày
        public DateTime? Den_Ngay = null; // Đến ngày
        public string Ten_Nhom = null; // Tên nhóm
        public string Nhiem_Vu = null; // Nhiệm vụ
        public bool? Biet_Phai = null; // Biệt phái
    }
    #endregion
    #region NL_To_Nhom
    public class NL_To_Nhom
    {
        private string ConnectionString;
        public NL_To_Nhom(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_To_Nhom_Chi_Tiet Lay(int Ma_To_Nhom)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_To_Nhom_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_To_Nhom = new SqlParameter("@Ma_To_Nhom", SqlDbType.Int, 4);
                    pMa_To_Nhom.Value = Ma_To_Nhom;
                    myCommand.Parameters.Add(pMa_To_Nhom);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_To_Nhom_Chi_Tiet");
                    NL_To_Nhom_Chi_Tiet myNL_To_Nhom_Chi_Tiet = new NL_To_Nhom_Chi_Tiet();
                    if (myDataSet.Tables["NL_To_Nhom_Chi_Tiet"] != null)
                    {
                        myNL_To_Nhom_Chi_Tiet.Ma_To_Nhom = Ma_To_Nhom;
                        myNL_To_Nhom_Chi_Tiet.Ma_Nhan_Vien = myDataSet.Tables["NL_To_Nhom_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] != DBNull.Value ? (int?)myDataSet.Tables["NL_To_Nhom_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] : (int?)null;
                        myNL_To_Nhom_Chi_Tiet.Tu_Ngay = myDataSet.Tables["NL_To_Nhom_Chi_Tiet"].Rows[0]["Tu_Ngay"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_To_Nhom_Chi_Tiet"].Rows[0]["Tu_Ngay"] : (DateTime?)null;
                        myNL_To_Nhom_Chi_Tiet.Den_Ngay = myDataSet.Tables["NL_To_Nhom_Chi_Tiet"].Rows[0]["Den_Ngay"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_To_Nhom_Chi_Tiet"].Rows[0]["Den_Ngay"] : (DateTime?)null;
                        myNL_To_Nhom_Chi_Tiet.Ten_Nhom = myDataSet.Tables["NL_To_Nhom_Chi_Tiet"].Rows[0]["Ten_Nhom"] != DBNull.Value ? (string)myDataSet.Tables["NL_To_Nhom_Chi_Tiet"].Rows[0]["Ten_Nhom"] : (string)null;
                        myNL_To_Nhom_Chi_Tiet.Nhiem_Vu = myDataSet.Tables["NL_To_Nhom_Chi_Tiet"].Rows[0]["Nhiem_Vu"] != DBNull.Value ? (string)myDataSet.Tables["NL_To_Nhom_Chi_Tiet"].Rows[0]["Nhiem_Vu"] : (string)null;
                        myNL_To_Nhom_Chi_Tiet.Biet_Phai = myDataSet.Tables["NL_To_Nhom_Chi_Tiet"].Rows[0]["Biet_Phai"] != DBNull.Value ? (bool?)myDataSet.Tables["NL_To_Nhom_Chi_Tiet"].Rows[0]["Biet_Phai"] : (bool?)null;
                    }
                    return myNL_To_Nhom_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Ma_To_Nhom = null, int? Ma_Nhan_Vien = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null, string Ten_Nhom = null, string Nhiem_Vu = null, bool? Biet_Phai = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_To_Nhom_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_To_Nhom = new SqlParameter("@Ma_To_Nhom", SqlDbType.Int, 4);
                    pMa_To_Nhom.Value = Ma_To_Nhom;
                    myCommand.Parameters.Add(pMa_To_Nhom);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pTen_Nhom = new SqlParameter("@Ten_Nhom", SqlDbType.NVarChar, 500);
                    pTen_Nhom.Value = Ten_Nhom;
                    myCommand.Parameters.Add(pTen_Nhom);

                    SqlParameter pNhiem_Vu = new SqlParameter("@Nhiem_Vu", SqlDbType.NVarChar, 500);
                    pNhiem_Vu.Value = Nhiem_Vu;
                    myCommand.Parameters.Add(pNhiem_Vu);

                    SqlParameter pBiet_Phai = new SqlParameter("@Biet_Phai", SqlDbType.Bit, 1);
                    pBiet_Phai.Value = Biet_Phai;
                    myCommand.Parameters.Add(pBiet_Phai);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int? Ma_To_Nhom = null, int? Ma_Nhan_Vien = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null, string Ten_Nhom = null, string Nhiem_Vu = null, bool? Biet_Phai = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_To_Nhom_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_To_Nhom = new SqlParameter("@Ma_To_Nhom", SqlDbType.Int, 4);
                    pMa_To_Nhom.Value = Ma_To_Nhom;
                    myCommand.Parameters.Add(pMa_To_Nhom);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pTen_Nhom = new SqlParameter("@Ten_Nhom", SqlDbType.NVarChar, 500);
                    pTen_Nhom.Value = Ten_Nhom;
                    myCommand.Parameters.Add(pTen_Nhom);

                    SqlParameter pNhiem_Vu = new SqlParameter("@Nhiem_Vu", SqlDbType.NVarChar, 500);
                    pNhiem_Vu.Value = Nhiem_Vu;
                    myCommand.Parameters.Add(pNhiem_Vu);

                    SqlParameter pBiet_Phai = new SqlParameter("@Biet_Phai", SqlDbType.Bit, 1);
                    pBiet_Phai.Value = Biet_Phai;
                    myCommand.Parameters.Add(pBiet_Phai);



                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(NL_To_Nhom_Chi_Tiet myNL_To_Nhom_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_To_Nhom_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_To_Nhom = new SqlParameter("@Ma_To_Nhom", SqlDbType.Int, 4);
                    pMa_To_Nhom.Value = myNL_To_Nhom_Chi_Tiet.Ma_To_Nhom;
                    myCommand.Parameters.Add(pMa_To_Nhom);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = myNL_To_Nhom_Chi_Tiet.Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = myNL_To_Nhom_Chi_Tiet.Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = myNL_To_Nhom_Chi_Tiet.Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pTen_Nhom = new SqlParameter("@Ten_Nhom", SqlDbType.NVarChar, 500);
                    pTen_Nhom.Value = myNL_To_Nhom_Chi_Tiet.Ten_Nhom;
                    myCommand.Parameters.Add(pTen_Nhom);

                    SqlParameter pNhiem_Vu = new SqlParameter("@Nhiem_Vu", SqlDbType.NVarChar, 500);
                    pNhiem_Vu.Value = myNL_To_Nhom_Chi_Tiet.Nhiem_Vu;
                    myCommand.Parameters.Add(pNhiem_Vu);

                    SqlParameter pBiet_Phai = new SqlParameter("@Biet_Phai", SqlDbType.Bit, 1);
                    pBiet_Phai.Value = myNL_To_Nhom_Chi_Tiet.Biet_Phai;
                    myCommand.Parameters.Add(pBiet_Phai);


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
                using (SqlCommand myCommand = new SqlCommand("NL_To_Nhom_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_To_Nhom = new SqlParameter("@Ma_To_Nhom", SqlDbType.Int, 4);
                        pMa_To_Nhom.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_To_Nhom"];
                        myCommand.Parameters.Add(pMa_To_Nhom);

                        SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                        pMa_Nhan_Vien.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nhan_Vien"];
                        myCommand.Parameters.Add(pMa_Nhan_Vien);

                        SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                        pTu_Ngay.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Tu_Ngay"];
                        myCommand.Parameters.Add(pTu_Ngay);

                        SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                        pDen_Ngay.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Den_Ngay"];
                        myCommand.Parameters.Add(pDen_Ngay);

                        SqlParameter pTen_Nhom = new SqlParameter("@Ten_Nhom", SqlDbType.NVarChar, 500);
                        pTen_Nhom.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ten_Nhom"];
                        myCommand.Parameters.Add(pTen_Nhom);

                        SqlParameter pNhiem_Vu = new SqlParameter("@Nhiem_Vu", SqlDbType.NVarChar, 500);
                        pNhiem_Vu.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Nhiem_Vu"];
                        myCommand.Parameters.Add(pNhiem_Vu);

                        SqlParameter pBiet_Phai = new SqlParameter("@Biet_Phai", SqlDbType.Bit, 1);
                        pBiet_Phai.Value = (bool)myDataSet.Tables[strTableName].Rows[i]["Biet_Phai"];
                        myCommand.Parameters.Add(pBiet_Phai);


                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int? Ma_To_Nhom = null, int? Ma_Nhan_Vien = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null, string Ten_Nhom = null, string Nhiem_Vu = null, bool? Biet_Phai = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_To_Nhom_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_To_Nhom = new SqlParameter("@Ma_To_Nhom", SqlDbType.Int, 4);
                    pMa_To_Nhom.Value = Ma_To_Nhom;
                    myCommand.Parameters.Add(pMa_To_Nhom);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pTen_Nhom = new SqlParameter("@Ten_Nhom", SqlDbType.NVarChar, 500);
                    pTen_Nhom.Value = Ten_Nhom;
                    myCommand.Parameters.Add(pTen_Nhom);

                    SqlParameter pNhiem_Vu = new SqlParameter("@Nhiem_Vu", SqlDbType.NVarChar, 500);
                    pNhiem_Vu.Value = Nhiem_Vu;
                    myCommand.Parameters.Add(pNhiem_Vu);

                    SqlParameter pBiet_Phai = new SqlParameter("@Biet_Phai", SqlDbType.Bit, 1);
                    pBiet_Phai.Value = Biet_Phai;
                    myCommand.Parameters.Add(pBiet_Phai);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Ma_To_Nhom)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_To_Nhom_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_To_Nhom = new SqlParameter("@Ma_To_Nhom", SqlDbType.Int, 4);
                    pMa_To_Nhom.Value = Ma_To_Nhom;
                    myCommand.Parameters.Add(pMa_To_Nhom);

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
                using (SqlCommand myCommand = new SqlCommand("NL_To_Nhom_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_To_Nhom_Danh_Sach");
                    return myDataSet.Tables["NL_To_Nhom_Danh_Sach"];
                }
            }
        }
        #endregion

        #region Lay_Boi_NL_Nhan_Vien
        public DataTable Lay_Boi_NL_Nhan_Vien(int Ma_Nhan_Vien)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_To_Nhom_Lay_Boi_NL_Nhan_Vien", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_To_Nhom_Lay_Boi_NL_Nhan_Vien");
                    return myDataSet.Tables["NL_To_Nhom_Lay_Boi_NL_Nhan_Vien"];
                }
            }
        }
        #endregion

    }
    #endregion
}