using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region NL_Phu_Cap_Details
    public class NL_Phu_Cap_Chi_Tiet
    {
        public int? Ma_Phu_Cap = null; // Mã phụ câp
        public int? Ma_Nhan_Vien = null; // Mã nhân viên
        public DateTime? Tu_Ngay = null; // Từ ngày
        public DateTime? Den_Ngay = null; // Đến ngày
        public decimal? He_So_Chuc_Vu = null; // Hệ số chức vụ
        public decimal? He_So_Trach_Nhiem = null; // Hệ số trách nhiệm
        public decimal? He_So_Khu_Vuc = null; // Hệ số khu vực
        public decimal? He_So_Doc_Hai = null; // Hệ số độc hại
        public decimal? He_So_Luu_Dong = null; // Hệ số lưu động
        public decimal? He_So_Khac = null; // Hệ số khác
        public decimal? Ty_Le_Tham_Nien = null; // Tỷ lệ thâm niên
        public string Ghi_Chu = null;
        public decimal? He_So_Dac_Thu = null;
    }
    #endregion
    #region NL_Phu_Cap
    public class NL_Phu_Cap
    {
        private string ConnectionString;
        public NL_Phu_Cap(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_Phu_Cap_Chi_Tiet Lay(int Ma_Phu_Cap)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Phu_Cap_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Phu_Cap = new SqlParameter("@Ma_Phu_Cap", SqlDbType.Int, 4);
                    pMa_Phu_Cap.Value = Ma_Phu_Cap;
                    myCommand.Parameters.Add(pMa_Phu_Cap);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Phu_Cap_Chi_Tiet");
                    NL_Phu_Cap_Chi_Tiet myNL_Phu_Cap_Chi_Tiet = new NL_Phu_Cap_Chi_Tiet();
                    if (myDataSet.Tables["NL_Phu_Cap_Chi_Tiet"] != null)
                    {
                        myNL_Phu_Cap_Chi_Tiet.Ma_Phu_Cap = Ma_Phu_Cap;
                        myNL_Phu_Cap_Chi_Tiet.Ma_Nhan_Vien = myDataSet.Tables["NL_Phu_Cap_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Phu_Cap_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] : (int?)null;
                        myNL_Phu_Cap_Chi_Tiet.Tu_Ngay = myDataSet.Tables["NL_Phu_Cap_Chi_Tiet"].Rows[0]["Tu_Ngay"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Phu_Cap_Chi_Tiet"].Rows[0]["Tu_Ngay"] : (DateTime?)null;
                        myNL_Phu_Cap_Chi_Tiet.Den_Ngay = myDataSet.Tables["NL_Phu_Cap_Chi_Tiet"].Rows[0]["Den_Ngay"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Phu_Cap_Chi_Tiet"].Rows[0]["Den_Ngay"] : (DateTime?)null;
                        myNL_Phu_Cap_Chi_Tiet.He_So_Chuc_Vu = myDataSet.Tables["NL_Phu_Cap_Chi_Tiet"].Rows[0]["He_So_Chuc_Vu"] != DBNull.Value ? (decimal?)myDataSet.Tables["NL_Phu_Cap_Chi_Tiet"].Rows[0]["He_So_Chuc_Vu"] : (decimal?)null;
                        myNL_Phu_Cap_Chi_Tiet.He_So_Trach_Nhiem = myDataSet.Tables["NL_Phu_Cap_Chi_Tiet"].Rows[0]["He_So_Trach_Nhiem"] != DBNull.Value ? (decimal?)myDataSet.Tables["NL_Phu_Cap_Chi_Tiet"].Rows[0]["He_So_Trach_Nhiem"] : (decimal?)null;
                        myNL_Phu_Cap_Chi_Tiet.He_So_Khu_Vuc = myDataSet.Tables["NL_Phu_Cap_Chi_Tiet"].Rows[0]["He_So_Khu_Vuc"] != DBNull.Value ? (decimal?)myDataSet.Tables["NL_Phu_Cap_Chi_Tiet"].Rows[0]["He_So_Khu_Vuc"] : (decimal?)null;
                        myNL_Phu_Cap_Chi_Tiet.He_So_Doc_Hai = myDataSet.Tables["NL_Phu_Cap_Chi_Tiet"].Rows[0]["He_So_Doc_Hai"] != DBNull.Value ? (decimal?)myDataSet.Tables["NL_Phu_Cap_Chi_Tiet"].Rows[0]["He_So_Doc_Hai"] : (decimal?)null;
                        myNL_Phu_Cap_Chi_Tiet.He_So_Luu_Dong = myDataSet.Tables["NL_Phu_Cap_Chi_Tiet"].Rows[0]["He_So_Luu_Dong"] != DBNull.Value ? (decimal?)myDataSet.Tables["NL_Phu_Cap_Chi_Tiet"].Rows[0]["He_So_Luu_Dong"] : (decimal?)null;
                        myNL_Phu_Cap_Chi_Tiet.He_So_Khac = myDataSet.Tables["NL_Phu_Cap_Chi_Tiet"].Rows[0]["He_So_Khac"] != DBNull.Value ? (decimal?)myDataSet.Tables["NL_Phu_Cap_Chi_Tiet"].Rows[0]["He_So_Khac"] : (decimal?)null;
                        myNL_Phu_Cap_Chi_Tiet.Ty_Le_Tham_Nien = myDataSet.Tables["NL_Phu_Cap_Chi_Tiet"].Rows[0]["Ty_Le_Tham_Nien"] != DBNull.Value ? (decimal?)myDataSet.Tables["NL_Phu_Cap_Chi_Tiet"].Rows[0]["Ty_Le_Tham_Nien"] : (decimal?)null;
                        myNL_Phu_Cap_Chi_Tiet.Ghi_Chu = myDataSet.Tables["NL_Phu_Cap_Chi_Tiet"].Rows[0]["Ghi_Chu"] != DBNull.Value ? (string)myDataSet.Tables["NL_Phu_Cap_Chi_Tiet"].Rows[0]["Ghi_Chu"] : (string)null;

                        myNL_Phu_Cap_Chi_Tiet.He_So_Dac_Thu = myDataSet.Tables["NL_Phu_Cap_Chi_Tiet"].Rows[0]["He_So_Dac_Thu"] != DBNull.Value ? (decimal?)myDataSet.Tables["NL_Phu_Cap_Chi_Tiet"].Rows[0]["He_So_Dac_Thu"] : (decimal?)null;
                    }
                    return myNL_Phu_Cap_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Ma_Phu_Cap = null, int? Ma_Nhan_Vien = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null, decimal? He_So_Chuc_Vu = null, decimal? He_So_Trach_Nhiem = null, decimal? He_So_Khu_Vuc = null, decimal? He_So_Doc_Hai = null, decimal? He_So_Luu_Dong = null, decimal? He_So_Khac = null, decimal? Ty_Le_Tham_Nien = null, string Ghi_Chu = null, decimal? He_So_Dac_Thu=null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Phu_Cap_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Phu_Cap = new SqlParameter("@Ma_Phu_Cap", SqlDbType.Int, 4);
                    pMa_Phu_Cap.Value = Ma_Phu_Cap;
                    myCommand.Parameters.Add(pMa_Phu_Cap);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pHe_So_Chuc_Vu = new SqlParameter("@He_So_Chuc_Vu", SqlDbType.Decimal);
                    pHe_So_Chuc_Vu.Value = He_So_Chuc_Vu;
                    myCommand.Parameters.Add(pHe_So_Chuc_Vu);

                    SqlParameter pHe_So_Trach_Nhiem = new SqlParameter("@He_So_Trach_Nhiem", SqlDbType.Decimal);
                    pHe_So_Trach_Nhiem.Value = He_So_Trach_Nhiem;
                    myCommand.Parameters.Add(pHe_So_Trach_Nhiem);

                    SqlParameter pHe_So_Khu_Vuc = new SqlParameter("@He_So_Khu_Vuc", SqlDbType.Decimal);
                    pHe_So_Khu_Vuc.Value = He_So_Khu_Vuc;
                    myCommand.Parameters.Add(pHe_So_Khu_Vuc);

                    SqlParameter pHe_So_Doc_Hai = new SqlParameter("@He_So_Doc_Hai", SqlDbType.Decimal);
                    pHe_So_Doc_Hai.Value = He_So_Doc_Hai;
                    myCommand.Parameters.Add(pHe_So_Doc_Hai);

                    SqlParameter pHe_So_Luu_Dong = new SqlParameter("@He_So_Luu_Dong", SqlDbType.Decimal);
                    pHe_So_Luu_Dong.Value = He_So_Luu_Dong;
                    myCommand.Parameters.Add(pHe_So_Luu_Dong);

                    SqlParameter pHe_So_Khac = new SqlParameter("@He_So_Khac", SqlDbType.Decimal);
                    pHe_So_Khac.Value = He_So_Khac;
                    myCommand.Parameters.Add(pHe_So_Khac);

                    SqlParameter pTy_Le_Tham_Nien = new SqlParameter("@Ty_Le_Tham_Nien", SqlDbType.Decimal);
                    pTy_Le_Tham_Nien.Value = Ty_Le_Tham_Nien;
                    myCommand.Parameters.Add(pTy_Le_Tham_Nien);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 500);
                    pGhi_Chu.Value = Ghi_Chu;
                    myCommand.Parameters.Add(pGhi_Chu);


                    SqlParameter pHe_So_Dac_Thu = new SqlParameter("@He_So_Dac_Thu", SqlDbType.Decimal);
                    pHe_So_Dac_Thu.Value = He_So_Dac_Thu;
                    myCommand.Parameters.Add(pHe_So_Dac_Thu);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int? Ma_Phu_Cap = null, int? Ma_Nhan_Vien = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null, decimal? He_So_Chuc_Vu = null, decimal? He_So_Trach_Nhiem = null, decimal? He_So_Khu_Vuc = null, decimal? He_So_Doc_Hai = null, decimal? He_So_Luu_Dong = null, decimal? He_So_Khac = null, decimal? Ty_Le_Tham_Nien = null, string Ghi_Chu = null, decimal? He_So_Dac_Thu=null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Phu_Cap_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Phu_Cap = new SqlParameter("@Ma_Phu_Cap", SqlDbType.Int, 4);
                    pMa_Phu_Cap.Value = Ma_Phu_Cap;
                    myCommand.Parameters.Add(pMa_Phu_Cap);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pHe_So_Chuc_Vu = new SqlParameter("@He_So_Chuc_Vu", SqlDbType.Decimal);
                    pHe_So_Chuc_Vu.Value = He_So_Chuc_Vu;
                    myCommand.Parameters.Add(pHe_So_Chuc_Vu);

                    SqlParameter pHe_So_Trach_Nhiem = new SqlParameter("@He_So_Trach_Nhiem", SqlDbType.Decimal);
                    pHe_So_Trach_Nhiem.Value = He_So_Trach_Nhiem;
                    myCommand.Parameters.Add(pHe_So_Trach_Nhiem);

                    SqlParameter pHe_So_Khu_Vuc = new SqlParameter("@He_So_Khu_Vuc", SqlDbType.Decimal);
                    pHe_So_Khu_Vuc.Value = He_So_Khu_Vuc;
                    myCommand.Parameters.Add(pHe_So_Khu_Vuc);

                    SqlParameter pHe_So_Doc_Hai = new SqlParameter("@He_So_Doc_Hai", SqlDbType.Decimal);
                    pHe_So_Doc_Hai.Value = He_So_Doc_Hai;
                    myCommand.Parameters.Add(pHe_So_Doc_Hai);

                    SqlParameter pHe_So_Luu_Dong = new SqlParameter("@He_So_Luu_Dong", SqlDbType.Decimal);
                    pHe_So_Luu_Dong.Value = He_So_Luu_Dong;
                    myCommand.Parameters.Add(pHe_So_Luu_Dong);

                    SqlParameter pHe_So_Khac = new SqlParameter("@He_So_Khac", SqlDbType.Decimal);
                    pHe_So_Khac.Value = He_So_Khac;
                    myCommand.Parameters.Add(pHe_So_Khac);

                    SqlParameter pTy_Le_Tham_Nien = new SqlParameter("@Ty_Le_Tham_Nien", SqlDbType.Decimal);
                    pTy_Le_Tham_Nien.Value = Ty_Le_Tham_Nien;
                    myCommand.Parameters.Add(pTy_Le_Tham_Nien);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 500);
                    pGhi_Chu.Value = Ghi_Chu;
                    myCommand.Parameters.Add(pGhi_Chu);

                    SqlParameter pHe_So_Dac_Thu = new SqlParameter("@He_So_Dac_Thu", SqlDbType.Decimal);
                    pHe_So_Dac_Thu.Value = He_So_Dac_Thu;
                    myCommand.Parameters.Add(pHe_So_Dac_Thu);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(NL_Phu_Cap_Chi_Tiet myNL_Phu_Cap_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Phu_Cap_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Phu_Cap = new SqlParameter("@Ma_Phu_Cap", SqlDbType.Int, 4);
                    pMa_Phu_Cap.Value = myNL_Phu_Cap_Chi_Tiet.Ma_Phu_Cap;
                    myCommand.Parameters.Add(pMa_Phu_Cap);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = myNL_Phu_Cap_Chi_Tiet.Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = myNL_Phu_Cap_Chi_Tiet.Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = myNL_Phu_Cap_Chi_Tiet.Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pHe_So_Chuc_Vu = new SqlParameter("@He_So_Chuc_Vu", SqlDbType.Decimal);
                    pHe_So_Chuc_Vu.Value = myNL_Phu_Cap_Chi_Tiet.He_So_Chuc_Vu;
                    myCommand.Parameters.Add(pHe_So_Chuc_Vu);

                    SqlParameter pHe_So_Trach_Nhiem = new SqlParameter("@He_So_Trach_Nhiem", SqlDbType.Decimal);
                    pHe_So_Trach_Nhiem.Value = myNL_Phu_Cap_Chi_Tiet.He_So_Trach_Nhiem;
                    myCommand.Parameters.Add(pHe_So_Trach_Nhiem);

                    SqlParameter pHe_So_Khu_Vuc = new SqlParameter("@He_So_Khu_Vuc", SqlDbType.Decimal);
                    pHe_So_Khu_Vuc.Value = myNL_Phu_Cap_Chi_Tiet.He_So_Khu_Vuc;
                    myCommand.Parameters.Add(pHe_So_Khu_Vuc);

                    SqlParameter pHe_So_Doc_Hai = new SqlParameter("@He_So_Doc_Hai", SqlDbType.Decimal);
                    pHe_So_Doc_Hai.Value = myNL_Phu_Cap_Chi_Tiet.He_So_Doc_Hai;
                    myCommand.Parameters.Add(pHe_So_Doc_Hai);

                    SqlParameter pHe_So_Luu_Dong = new SqlParameter("@He_So_Luu_Dong", SqlDbType.Decimal);
                    pHe_So_Luu_Dong.Value = myNL_Phu_Cap_Chi_Tiet.He_So_Luu_Dong;
                    myCommand.Parameters.Add(pHe_So_Luu_Dong);

                    SqlParameter pHe_So_Khac = new SqlParameter("@He_So_Khac", SqlDbType.Decimal);
                    pHe_So_Khac.Value = myNL_Phu_Cap_Chi_Tiet.He_So_Khac;
                    myCommand.Parameters.Add(pHe_So_Khac);

                    SqlParameter pTy_Le_Tham_Nien = new SqlParameter("@Ty_Le_Tham_Nien", SqlDbType.Decimal);
                    pTy_Le_Tham_Nien.Value = myNL_Phu_Cap_Chi_Tiet.Ty_Le_Tham_Nien;
                    myCommand.Parameters.Add(pTy_Le_Tham_Nien);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 500);
                    pGhi_Chu.Value = myNL_Phu_Cap_Chi_Tiet.Ghi_Chu;
                    myCommand.Parameters.Add(pGhi_Chu);

                    SqlParameter pHe_So_Dac_Thu = new SqlParameter("@He_So_Dac_Thu", SqlDbType.Decimal);
                    pHe_So_Dac_Thu.Value = myNL_Phu_Cap_Chi_Tiet.He_So_Dac_Thu;
                    myCommand.Parameters.Add(pHe_So_Dac_Thu);

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
                using (SqlCommand myCommand = new SqlCommand("NL_Phu_Cap_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Phu_Cap = new SqlParameter("@Ma_Phu_Cap", SqlDbType.Int, 4);
                        pMa_Phu_Cap.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Phu_Cap"];
                        myCommand.Parameters.Add(pMa_Phu_Cap);

                        SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                        pMa_Nhan_Vien.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nhan_Vien"];
                        myCommand.Parameters.Add(pMa_Nhan_Vien);

                        SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                        pTu_Ngay.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Tu_Ngay"];
                        myCommand.Parameters.Add(pTu_Ngay);

                        SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                        pDen_Ngay.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Den_Ngay"];
                        myCommand.Parameters.Add(pDen_Ngay);

                        SqlParameter pHe_So_Chuc_Vu = new SqlParameter("@He_So_Chuc_Vu", SqlDbType.Decimal);
                        pHe_So_Chuc_Vu.Value = (decimal)myDataSet.Tables[strTableName].Rows[i]["He_So_Chuc_Vu"];
                        myCommand.Parameters.Add(pHe_So_Chuc_Vu);

                        SqlParameter pHe_So_Trach_Nhiem = new SqlParameter("@He_So_Trach_Nhiem", SqlDbType.Decimal);
                        pHe_So_Trach_Nhiem.Value = (decimal)myDataSet.Tables[strTableName].Rows[i]["He_So_Trach_Nhiem"];
                        myCommand.Parameters.Add(pHe_So_Trach_Nhiem);

                        SqlParameter pHe_So_Khu_Vuc = new SqlParameter("@He_So_Khu_Vuc", SqlDbType.Decimal);
                        pHe_So_Khu_Vuc.Value = (decimal)myDataSet.Tables[strTableName].Rows[i]["He_So_Khu_Vuc"];
                        myCommand.Parameters.Add(pHe_So_Khu_Vuc);

                        SqlParameter pHe_So_Doc_Hai = new SqlParameter("@He_So_Doc_Hai", SqlDbType.Decimal);
                        pHe_So_Doc_Hai.Value = (decimal)myDataSet.Tables[strTableName].Rows[i]["He_So_Doc_Hai"];
                        myCommand.Parameters.Add(pHe_So_Doc_Hai);

                        SqlParameter pHe_So_Luu_Dong = new SqlParameter("@He_So_Luu_Dong", SqlDbType.Decimal);
                        pHe_So_Luu_Dong.Value = (decimal)myDataSet.Tables[strTableName].Rows[i]["He_So_Luu_Dong"];
                        myCommand.Parameters.Add(pHe_So_Luu_Dong);

                        SqlParameter pHe_So_Khac = new SqlParameter("@He_So_Khac", SqlDbType.Decimal);
                        pHe_So_Khac.Value = (decimal)myDataSet.Tables[strTableName].Rows[i]["He_So_Khac"];
                        myCommand.Parameters.Add(pHe_So_Khac);

                        SqlParameter pTy_Le_Tham_Nien = new SqlParameter("@Ty_Le_Tham_Nien", SqlDbType.Decimal);
                        pTy_Le_Tham_Nien.Value = (decimal)myDataSet.Tables[strTableName].Rows[i]["Ty_Le_Tham_Nien"];
                        myCommand.Parameters.Add(pTy_Le_Tham_Nien);

                        SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 500);
                        pGhi_Chu.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ghi_Chu"];
                        myCommand.Parameters.Add(pGhi_Chu);
                        
                        SqlParameter pHe_So_Dac_Thu = new SqlParameter("@He_So_Dac_Thu", SqlDbType.Decimal);
                        pHe_So_Dac_Thu.Value = (decimal)myDataSet.Tables[strTableName].Rows[i]["He_So_Dac_Thu"];
                        myCommand.Parameters.Add(pHe_So_Dac_Thu);

                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int? Ma_Phu_Cap = null, int? Ma_Nhan_Vien = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null, decimal? He_So_Chuc_Vu = null, decimal? He_So_Trach_Nhiem = null, decimal? He_So_Khu_Vuc = null, decimal? He_So_Doc_Hai = null, decimal? He_So_Luu_Dong = null, decimal? He_So_Khac = null, decimal? Ty_Le_Tham_Nien = null, string Ghi_Chu = null, decimal? He_So_Dac_Thu=null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Phu_Cap_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Phu_Cap = new SqlParameter("@Ma_Phu_Cap", SqlDbType.Int, 4);
                    pMa_Phu_Cap.Value = Ma_Phu_Cap;
                    myCommand.Parameters.Add(pMa_Phu_Cap);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pHe_So_Chuc_Vu = new SqlParameter("@He_So_Chuc_Vu", SqlDbType.Decimal);
                    pHe_So_Chuc_Vu.Value = He_So_Chuc_Vu;
                    myCommand.Parameters.Add(pHe_So_Chuc_Vu);

                    SqlParameter pHe_So_Trach_Nhiem = new SqlParameter("@He_So_Trach_Nhiem", SqlDbType.Decimal);
                    pHe_So_Trach_Nhiem.Value = He_So_Trach_Nhiem;
                    myCommand.Parameters.Add(pHe_So_Trach_Nhiem);

                    SqlParameter pHe_So_Khu_Vuc = new SqlParameter("@He_So_Khu_Vuc", SqlDbType.Decimal);
                    pHe_So_Khu_Vuc.Value = He_So_Khu_Vuc;
                    myCommand.Parameters.Add(pHe_So_Khu_Vuc);

                    SqlParameter pHe_So_Doc_Hai = new SqlParameter("@He_So_Doc_Hai", SqlDbType.Decimal);
                    pHe_So_Doc_Hai.Value = He_So_Doc_Hai;
                    myCommand.Parameters.Add(pHe_So_Doc_Hai);

                    SqlParameter pHe_So_Luu_Dong = new SqlParameter("@He_So_Luu_Dong", SqlDbType.Decimal);
                    pHe_So_Luu_Dong.Value = He_So_Luu_Dong;
                    myCommand.Parameters.Add(pHe_So_Luu_Dong);

                    SqlParameter pHe_So_Khac = new SqlParameter("@He_So_Khac", SqlDbType.Decimal);
                    pHe_So_Khac.Value = He_So_Khac;
                    myCommand.Parameters.Add(pHe_So_Khac);

                    SqlParameter pTy_Le_Tham_Nien = new SqlParameter("@Ty_Le_Tham_Nien", SqlDbType.Decimal);
                    pTy_Le_Tham_Nien.Value = Ty_Le_Tham_Nien;
                    myCommand.Parameters.Add(pTy_Le_Tham_Nien);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 500);
                    pGhi_Chu.Value = Ghi_Chu;
                    myCommand.Parameters.Add(pGhi_Chu);

                    SqlParameter pHe_So_Dac_Thu = new SqlParameter("@He_So_Dac_Thu", SqlDbType.Decimal);
                    pHe_So_Dac_Thu.Value = He_So_Dac_Thu;
                    myCommand.Parameters.Add(pHe_So_Dac_Thu);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Ma_Phu_Cap)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Phu_Cap_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Phu_Cap = new SqlParameter("@Ma_Phu_Cap", SqlDbType.Int, 4);
                    pMa_Phu_Cap.Value = Ma_Phu_Cap;
                    myCommand.Parameters.Add(pMa_Phu_Cap);

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
                using (SqlCommand myCommand = new SqlCommand("NL_Phu_Cap_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Phu_Cap_Danh_Sach");
                    return myDataSet.Tables["NL_Phu_Cap_Danh_Sach"];
                }
            }
        }
        #endregion

        #region Lay_Boi_NL_Nhan_Vien
        public DataTable Lay_Boi_NL_Nhan_Vien(int Ma_Nhan_Vien)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Phu_Cap_Lay_Boi_NL_Nhan_Vien", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Phu_Cap_Lay_Boi_NL_Nhan_Vien");
                    return myDataSet.Tables["NL_Phu_Cap_Lay_Boi_NL_Nhan_Vien"];
                }
            }
        }
        #endregion

    }
    #endregion
}