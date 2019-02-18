using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region NL_Cong_Tac_Nuoc_Ngoai_Details
    public class NL_Cong_Tac_Nuoc_Ngoai_Chi_Tiet
    {
        public int? Ma_Cong_Tac = null; // Mã công tác
        public int? Ma_Nhan_Vien = null; // Mã nhân viên
        public DateTime? Tu_Ngay = null; // Từ ngày
        public DateTime? Den_Ngay = null; // Đến ngày
        public string Ma_Nuoc = null; // Mã nước
        public string Nhiem_Vu = null; // Nhiệm vụ
    }
    #endregion
    #region NL_Cong_Tac_Nuoc_Ngoai
    public class NL_Cong_Tac_Nuoc_Ngoai
    {
        private string ConnectionString;
        public NL_Cong_Tac_Nuoc_Ngoai(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_Cong_Tac_Nuoc_Ngoai_Chi_Tiet Lay(int Ma_Cong_Tac)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Cong_Tac_Nuoc_Ngoai_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Cong_Tac = new SqlParameter("@Ma_Cong_Tac", SqlDbType.Int, 4);
                    pMa_Cong_Tac.Value = Ma_Cong_Tac;
                    myCommand.Parameters.Add(pMa_Cong_Tac);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Cong_Tac_Nuoc_Ngoai_Chi_Tiet");
                    NL_Cong_Tac_Nuoc_Ngoai_Chi_Tiet myNL_Cong_Tac_Nuoc_Ngoai_Chi_Tiet = new NL_Cong_Tac_Nuoc_Ngoai_Chi_Tiet();
                    if (myDataSet.Tables["NL_Cong_Tac_Nuoc_Ngoai_Chi_Tiet"] != null)
                    {
                        myNL_Cong_Tac_Nuoc_Ngoai_Chi_Tiet.Ma_Cong_Tac = Ma_Cong_Tac;
                        myNL_Cong_Tac_Nuoc_Ngoai_Chi_Tiet.Ma_Nhan_Vien = myDataSet.Tables["NL_Cong_Tac_Nuoc_Ngoai_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Cong_Tac_Nuoc_Ngoai_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] : (int?)null;
                        myNL_Cong_Tac_Nuoc_Ngoai_Chi_Tiet.Tu_Ngay = myDataSet.Tables["NL_Cong_Tac_Nuoc_Ngoai_Chi_Tiet"].Rows[0]["Tu_Ngay"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Cong_Tac_Nuoc_Ngoai_Chi_Tiet"].Rows[0]["Tu_Ngay"] : (DateTime?)null;
                        myNL_Cong_Tac_Nuoc_Ngoai_Chi_Tiet.Den_Ngay = myDataSet.Tables["NL_Cong_Tac_Nuoc_Ngoai_Chi_Tiet"].Rows[0]["Den_Ngay"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Cong_Tac_Nuoc_Ngoai_Chi_Tiet"].Rows[0]["Den_Ngay"] : (DateTime?)null;
                        myNL_Cong_Tac_Nuoc_Ngoai_Chi_Tiet.Ma_Nuoc = myDataSet.Tables["NL_Cong_Tac_Nuoc_Ngoai_Chi_Tiet"].Rows[0]["Ma_Nuoc"] != DBNull.Value ? (string)myDataSet.Tables["NL_Cong_Tac_Nuoc_Ngoai_Chi_Tiet"].Rows[0]["Ma_Nuoc"] : (string)null;
                        myNL_Cong_Tac_Nuoc_Ngoai_Chi_Tiet.Nhiem_Vu = myDataSet.Tables["NL_Cong_Tac_Nuoc_Ngoai_Chi_Tiet"].Rows[0]["Nhiem_Vu"] != DBNull.Value ? (string)myDataSet.Tables["NL_Cong_Tac_Nuoc_Ngoai_Chi_Tiet"].Rows[0]["Nhiem_Vu"] : (string)null;
                    }
                    return myNL_Cong_Tac_Nuoc_Ngoai_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Ma_Cong_Tac = null, int? Ma_Nhan_Vien = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null, string Ma_Nuoc = null, string Nhiem_Vu = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("them_cong_tac_nuoc_ngoai", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Cong_Tac = new SqlParameter("@ma_cong_tac", SqlDbType.Int, 4);
                    pMa_Cong_Tac.Value = Ma_Cong_Tac;
                    myCommand.Parameters.Add(pMa_Cong_Tac);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@ma_nhan_vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@tu_ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@den_ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pMa_Nuoc = new SqlParameter("@ma_nuoc", SqlDbType.VarChar, 3);
                    pMa_Nuoc.Value = Ma_Nuoc;
                    myCommand.Parameters.Add(pMa_Nuoc);

                    SqlParameter pNhiem_Vu = new SqlParameter("@nhiem_vu", SqlDbType.NVarChar, 500);
                    pNhiem_Vu.Value = Nhiem_Vu;
                    myCommand.Parameters.Add(pNhiem_Vu);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int? Ma_Cong_Tac = null, int? Ma_Nhan_Vien = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null, string Ma_Nuoc = null, string Nhiem_Vu = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Cong_Tac_Nuoc_Ngoai_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Cong_Tac = new SqlParameter("@Ma_Cong_Tac", SqlDbType.Int, 4);
                    pMa_Cong_Tac.Value = Ma_Cong_Tac;
                    myCommand.Parameters.Add(pMa_Cong_Tac);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pMa_Nuoc = new SqlParameter("@Ma_Nuoc", SqlDbType.VarChar, 3);
                    pMa_Nuoc.Value = Ma_Nuoc;
                    myCommand.Parameters.Add(pMa_Nuoc);

                    SqlParameter pNhiem_Vu = new SqlParameter("@Nhiem_Vu", SqlDbType.NVarChar, 500);
                    pNhiem_Vu.Value = Nhiem_Vu;
                    myCommand.Parameters.Add(pNhiem_Vu);



                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(NL_Cong_Tac_Nuoc_Ngoai_Chi_Tiet myNL_Cong_Tac_Nuoc_Ngoai_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Cong_Tac_Nuoc_Ngoai_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Cong_Tac = new SqlParameter("@Ma_Cong_Tac", SqlDbType.Int, 4);
                    pMa_Cong_Tac.Value = myNL_Cong_Tac_Nuoc_Ngoai_Chi_Tiet.Ma_Cong_Tac;
                    myCommand.Parameters.Add(pMa_Cong_Tac);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = myNL_Cong_Tac_Nuoc_Ngoai_Chi_Tiet.Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = myNL_Cong_Tac_Nuoc_Ngoai_Chi_Tiet.Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = myNL_Cong_Tac_Nuoc_Ngoai_Chi_Tiet.Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pMa_Nuoc = new SqlParameter("@Ma_Nuoc", SqlDbType.VarChar, 3);
                    pMa_Nuoc.Value = myNL_Cong_Tac_Nuoc_Ngoai_Chi_Tiet.Ma_Nuoc;
                    myCommand.Parameters.Add(pMa_Nuoc);

                    SqlParameter pNhiem_Vu = new SqlParameter("@Nhiem_Vu", SqlDbType.NVarChar, 500);
                    pNhiem_Vu.Value = myNL_Cong_Tac_Nuoc_Ngoai_Chi_Tiet.Nhiem_Vu;
                    myCommand.Parameters.Add(pNhiem_Vu);


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
                using (SqlCommand myCommand = new SqlCommand("NL_Cong_Tac_Nuoc_Ngoai_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Cong_Tac = new SqlParameter("@Ma_Cong_Tac", SqlDbType.Int, 4);
                        pMa_Cong_Tac.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Cong_Tac"];
                        myCommand.Parameters.Add(pMa_Cong_Tac);

                        SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                        pMa_Nhan_Vien.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nhan_Vien"];
                        myCommand.Parameters.Add(pMa_Nhan_Vien);

                        SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                        pTu_Ngay.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Tu_Ngay"];
                        myCommand.Parameters.Add(pTu_Ngay);

                        SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                        pDen_Ngay.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Den_Ngay"];
                        myCommand.Parameters.Add(pDen_Ngay);

                        SqlParameter pMa_Nuoc = new SqlParameter("@Ma_Nuoc", SqlDbType.VarChar, 3);
                        pMa_Nuoc.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ma_Nuoc"];
                        myCommand.Parameters.Add(pMa_Nuoc);

                        SqlParameter pNhiem_Vu = new SqlParameter("@Nhiem_Vu", SqlDbType.NVarChar, 500);
                        pNhiem_Vu.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Nhiem_Vu"];
                        myCommand.Parameters.Add(pNhiem_Vu);


                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int? Ma_Cong_Tac = null, int? Ma_Nhan_Vien = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null, string Ma_Nuoc = null, string Nhiem_Vu = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Cong_Tac_Nuoc_Ngoai_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Cong_Tac = new SqlParameter("@Ma_Cong_Tac", SqlDbType.Int, 4);
                    pMa_Cong_Tac.Value = Ma_Cong_Tac;
                    myCommand.Parameters.Add(pMa_Cong_Tac);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pMa_Nuoc = new SqlParameter("@Ma_Nuoc", SqlDbType.VarChar, 3);
                    pMa_Nuoc.Value = Ma_Nuoc;
                    myCommand.Parameters.Add(pMa_Nuoc);

                    SqlParameter pNhiem_Vu = new SqlParameter("@Nhiem_Vu", SqlDbType.NVarChar, 500);
                    pNhiem_Vu.Value = Nhiem_Vu;
                    myCommand.Parameters.Add(pNhiem_Vu);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Ma_Cong_Tac)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Cong_Tac_Nuoc_Ngoai_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Cong_Tac = new SqlParameter("@Ma_Cong_Tac", SqlDbType.Int, 4);
                    pMa_Cong_Tac.Value = Ma_Cong_Tac;
                    myCommand.Parameters.Add(pMa_Cong_Tac);

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
                using (SqlCommand myCommand = new SqlCommand("NL_Cong_Tac_Nuoc_Ngoai_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Cong_Tac_Nuoc_Ngoai_Danh_Sach");
                    return myDataSet.Tables["NL_Cong_Tac_Nuoc_Ngoai_Danh_Sach"];
                }
            }
        }
        #endregion

        #region Lay_Boi_NL_Nhan_Vien
        public DataTable Lay_Boi_NL_Nhan_Vien(int Ma_Nhan_Vien)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Cong_Tac_Nuoc_Ngoai_Lay_Boi_NL_Nhan_Vien", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Cong_Tac_Nuoc_Ngoai_Lay_Boi_NL_Nhan_Vien");
                    return myDataSet.Tables["NL_Cong_Tac_Nuoc_Ngoai_Lay_Boi_NL_Nhan_Vien"];
                }
            }
        }
        #endregion

        /*Lay combo ma nuoc*/
        public DataTable lay_ma_nuoc()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("ma_nuoc", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "ma_nuoc");
                    return myDataSet.Tables["ma_nuoc"];
                }
            }
        }

    }
    #endregion
}