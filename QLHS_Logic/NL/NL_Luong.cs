using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region NL_Luong_Details
    public class NL_Luong_Chi_Tiet
    {
        public int? Ma_Luong = null; // Mã lương
        public int? Ma_Nhan_Vien = null; // Mã nhân viên
        public DateTime? Tu_Ngay = null; // Từ ngày
        public DateTime? Den_Ngay = null; // Đến ngày
        public string Ma_Ngach = null; // Mã ngạch
        public int? Bac = null; // Bậc
        public decimal? He_So = null; // Hệ số
        public decimal? Phu_Cap_TNVK = null; // Phần trăm vượt khung (nếu có)
        public string Ghi_Chu = null;
        public decimal? Phu_Cap_Chuc_Vu = null;
        public decimal? Phu_Cap_Khac = null;
        public decimal? Phu_Cap_Trach_Nhiem = null;
        public decimal? Phu_Cap_Khu_Vuc = null;
        public decimal? Phu_Cap_Nghe = null;
    }
    #endregion
    #region NL_Luong
    public class NL_Luong
    {
        private string ConnectionString;
        public NL_Luong(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_Luong_Chi_Tiet Lay(int Ma_Luong)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Luong_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Luong = new SqlParameter("@Ma_Luong", SqlDbType.Int, 4);
                    pMa_Luong.Value = Ma_Luong;
                    myCommand.Parameters.Add(pMa_Luong);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Luong_Chi_Tiet");
                    NL_Luong_Chi_Tiet myNL_Luong_Chi_Tiet = new NL_Luong_Chi_Tiet();
                    if (myDataSet.Tables["NL_Luong_Chi_Tiet"] != null)
                    {
                        myNL_Luong_Chi_Tiet.Ma_Luong = Ma_Luong;
                        myNL_Luong_Chi_Tiet.Ma_Nhan_Vien = myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] : (int?)null;
                        myNL_Luong_Chi_Tiet.Tu_Ngay = myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Tu_Ngay"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Tu_Ngay"] : (DateTime?)null;
                        myNL_Luong_Chi_Tiet.Den_Ngay = myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Den_Ngay"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Den_Ngay"] : (DateTime?)null;
                        myNL_Luong_Chi_Tiet.Ma_Ngach = myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Ma_Ngach"] != DBNull.Value ? (string)myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Ma_Ngach"] : (string)null;
                        myNL_Luong_Chi_Tiet.Bac = myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Bac"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Bac"] : (int?)null;
                        myNL_Luong_Chi_Tiet.He_So = myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["He_So"] != DBNull.Value ? (decimal?)myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["He_So"] : (decimal?)null;
                        myNL_Luong_Chi_Tiet.Phu_Cap_TNVK = myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Phu_Cap_TNVK"] != DBNull.Value ? (decimal?)myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Phu_Cap_TNVK"] : (decimal?)null;
                        myNL_Luong_Chi_Tiet.Ghi_Chu = myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Ghi_Chu"] != DBNull.Value ? (string)myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Ghi_Chu"] : (string)null;
                        myNL_Luong_Chi_Tiet.Phu_Cap_Chuc_Vu = myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Phu_Cap_Chuc_Vu"] != DBNull.Value ? (decimal?)myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Phu_Cap_Chuc_Vu"] : (decimal?)null;
                        myNL_Luong_Chi_Tiet.Phu_Cap_Khac = myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Phu_Cap_Khac"] != DBNull.Value ? (decimal?)myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Phu_Cap_Khac"] : (decimal?)null;
                        myNL_Luong_Chi_Tiet.Phu_Cap_Trach_Nhiem = myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Phu_Cap_Trach_Nhiem"] != DBNull.Value ? (decimal?)myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Phu_Cap_Trach_Nhiem"] : (decimal?)null;


                        myNL_Luong_Chi_Tiet.Phu_Cap_Khu_Vuc = myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Phu_Cap_Khu_Vuc"] != DBNull.Value ? (decimal?)myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Phu_Cap_Khu_Vuc"] : (decimal?)null;

                        myNL_Luong_Chi_Tiet.Phu_Cap_Nghe = myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Phu_Cap_Nghe"] != DBNull.Value ? (decimal?)myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Phu_Cap_Nghe"] : (decimal?)null;

                    }
                    return myNL_Luong_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Ma_Luong = null, int? Ma_Nhan_Vien = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null, string Ma_Ngach = null, int? Bac = null, decimal? He_So = null, decimal? Phu_Cap_TNVK = null, string Ghi_Chu = null, decimal? Phu_Cap_Chuc_Vu = null, decimal? Phu_Cap_Khac = null, decimal? Phu_Cap_Trach_Nhiem = null
            , decimal? Phu_Cap_Khu_Vuc = null, decimal? Phu_Cap_Nghe = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Luong_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Luong = new SqlParameter("@Ma_Luong", SqlDbType.Int, 4);
                    pMa_Luong.Value = Ma_Luong;
                    myCommand.Parameters.Add(pMa_Luong);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pMa_Ngach = new SqlParameter("@Ma_Ngach", SqlDbType.NVarChar, 50);
                    pMa_Ngach.Value = Ma_Ngach;
                    myCommand.Parameters.Add(pMa_Ngach);

                    SqlParameter pBac = new SqlParameter("@Bac", SqlDbType.Int, 4);
                    pBac.Value = Bac;
                    myCommand.Parameters.Add(pBac);

                    SqlParameter pHe_So = new SqlParameter("@He_So", SqlDbType.Decimal);
                    pHe_So.Value = He_So;
                    myCommand.Parameters.Add(pHe_So);

                    SqlParameter pPhu_Cap_TNVK = new SqlParameter("@Phu_Cap_TNVK", SqlDbType.Decimal);
                    pPhu_Cap_TNVK.Value = Phu_Cap_TNVK;
                    myCommand.Parameters.Add(pPhu_Cap_TNVK);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 250);
                    pGhi_Chu.Value = Ghi_Chu;
                    myCommand.Parameters.Add(pGhi_Chu);

                    SqlParameter pPhu_Cap_Chuc_Vu = new SqlParameter("@Phu_Cap_Chuc_Vu", SqlDbType.Decimal);
                    pPhu_Cap_Chuc_Vu.Value = Phu_Cap_Chuc_Vu;
                    myCommand.Parameters.Add(pPhu_Cap_Chuc_Vu);

                    SqlParameter pPhu_Cap_Khac = new SqlParameter("@Phu_Cap_Khac", SqlDbType.Decimal);
                    pPhu_Cap_Khac.Value = Phu_Cap_Khac;
                    myCommand.Parameters.Add(pPhu_Cap_Khac);

                    SqlParameter pPhu_Cap_Trach_Nhiem = new SqlParameter("@Phu_Cap_Trach_Nhiem", SqlDbType.Decimal);
                    pPhu_Cap_Trach_Nhiem.Value = Phu_Cap_Trach_Nhiem;
                    myCommand.Parameters.Add(pPhu_Cap_Trach_Nhiem);


                    SqlParameter pPhu_Cap_Khu_Vuc = new SqlParameter("@Phu_Cap_Khu_Vuc", SqlDbType.Decimal);
                    pPhu_Cap_Khu_Vuc.Value = Phu_Cap_Khu_Vuc;
                    myCommand.Parameters.Add(pPhu_Cap_Khu_Vuc);

                    SqlParameter pPhu_Cap_Nghe = new SqlParameter("@Phu_Cap_Nghe", SqlDbType.Decimal);
                    pPhu_Cap_Nghe.Value = Phu_Cap_Nghe;
                    myCommand.Parameters.Add(pPhu_Cap_Nghe);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int? Ma_Luong = null, int? Ma_Nhan_Vien = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null, string Ma_Ngach = null, int? Bac = null, decimal? He_So = null, decimal? Phu_Cap_TNVK = null, string Ghi_Chu = null, decimal? Phu_Cap_Chuc_Vu = null, decimal? Phu_Cap_Khac = null, decimal? Phu_Cap_Trach_Nhiem = null, decimal? Phu_Cap_Khu_Vuc = null, decimal? Phu_Cap_Nghe = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Luong_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Luong = new SqlParameter("@Ma_Luong", SqlDbType.Int, 4);
                    pMa_Luong.Value = Ma_Luong;
                    myCommand.Parameters.Add(pMa_Luong);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pMa_Ngach = new SqlParameter("@Ma_Ngach", SqlDbType.NVarChar, 50);
                    pMa_Ngach.Value = Ma_Ngach;
                    myCommand.Parameters.Add(pMa_Ngach);

                    SqlParameter pBac = new SqlParameter("@Bac", SqlDbType.Int, 4);
                    pBac.Value = Bac;
                    myCommand.Parameters.Add(pBac);

                    SqlParameter pHe_So = new SqlParameter("@He_So", SqlDbType.Decimal);
                    pHe_So.Value = He_So;
                    myCommand.Parameters.Add(pHe_So);

                    SqlParameter pPhu_Cap_TNVK = new SqlParameter("@Phu_Cap_TNVK", SqlDbType.Decimal);
                    pPhu_Cap_TNVK.Value = Phu_Cap_TNVK;
                    myCommand.Parameters.Add(pPhu_Cap_TNVK);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 250);
                    pGhi_Chu.Value = Ghi_Chu;
                    myCommand.Parameters.Add(pGhi_Chu);

                    SqlParameter pPhu_Cap_Chuc_Vu = new SqlParameter("@Phu_Cap_Chuc_Vu", SqlDbType.Decimal);
                    pPhu_Cap_Chuc_Vu.Value = Phu_Cap_Chuc_Vu;
                    myCommand.Parameters.Add(pPhu_Cap_Chuc_Vu);

                    SqlParameter pPhu_Cap_Khac = new SqlParameter("@Phu_Cap_Khac", SqlDbType.Decimal);
                    pPhu_Cap_Khac.Value = Phu_Cap_Khac;
                    myCommand.Parameters.Add(pPhu_Cap_Khac);

                    SqlParameter pPhu_Cap_Trach_Nhiem = new SqlParameter("@Phu_Cap_Trach_Nhiem", SqlDbType.Decimal);
                    pPhu_Cap_Trach_Nhiem.Value = Phu_Cap_Trach_Nhiem;
                    myCommand.Parameters.Add(pPhu_Cap_Trach_Nhiem);


                    SqlParameter pPhu_Cap_Khu_Vuc = new SqlParameter("@Phu_Cap_Khu_Vuc", SqlDbType.Decimal);
                    pPhu_Cap_Khu_Vuc.Value = Phu_Cap_Khu_Vuc;
                    myCommand.Parameters.Add(pPhu_Cap_Khu_Vuc);

                    SqlParameter pPhu_Cap_Nghe = new SqlParameter("@Phu_Cap_Nghe", SqlDbType.Decimal);
                    pPhu_Cap_Nghe.Value = Phu_Cap_Nghe;
                    myCommand.Parameters.Add(pPhu_Cap_Nghe);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(NL_Luong_Chi_Tiet myNL_Luong_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Luong_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Luong = new SqlParameter("@Ma_Luong", SqlDbType.Int, 4);
                    pMa_Luong.Value = myNL_Luong_Chi_Tiet.Ma_Luong;
                    myCommand.Parameters.Add(pMa_Luong);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = myNL_Luong_Chi_Tiet.Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = myNL_Luong_Chi_Tiet.Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = myNL_Luong_Chi_Tiet.Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pMa_Ngach = new SqlParameter("@Ma_Ngach", SqlDbType.NVarChar, 50);
                    pMa_Ngach.Value = myNL_Luong_Chi_Tiet.Ma_Ngach;
                    myCommand.Parameters.Add(pMa_Ngach);

                    SqlParameter pBac = new SqlParameter("@Bac", SqlDbType.Int, 4);
                    pBac.Value = myNL_Luong_Chi_Tiet.Bac;
                    myCommand.Parameters.Add(pBac);

                    SqlParameter pHe_So = new SqlParameter("@He_So", SqlDbType.Decimal);
                    pHe_So.Value = myNL_Luong_Chi_Tiet.He_So;
                    myCommand.Parameters.Add(pHe_So);

                    SqlParameter pPhu_Cap_TNVK = new SqlParameter("@Phu_Cap_TNVK", SqlDbType.Int, 4);
                    pPhu_Cap_TNVK.Value = myNL_Luong_Chi_Tiet.Phu_Cap_TNVK;
                    myCommand.Parameters.Add(pPhu_Cap_TNVK);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 250);
                    pGhi_Chu.Value = myNL_Luong_Chi_Tiet.Ghi_Chu;
                    myCommand.Parameters.Add(pGhi_Chu);

                    SqlParameter pPhu_Cap_Trach_Nhiem = new SqlParameter("@Phu_Cap_Trach_Nhiem", SqlDbType.Decimal);
                    pPhu_Cap_Trach_Nhiem.Value = myNL_Luong_Chi_Tiet.Phu_Cap_Trach_Nhiem;
                    myCommand.Parameters.Add(pPhu_Cap_Trach_Nhiem);

                    SqlParameter pPhu_Cap_Khu_Vuc = new SqlParameter("@Phu_Cap_Khu_Vuc", SqlDbType.Decimal);
                    pPhu_Cap_Khu_Vuc.Value = myNL_Luong_Chi_Tiet.Phu_Cap_Khu_Vuc;
                    myCommand.Parameters.Add(pPhu_Cap_Khu_Vuc);

                    SqlParameter pPhu_Cap_Nghe = new SqlParameter("@Phu_Cap_Nghe", SqlDbType.Decimal);
                    pPhu_Cap_Nghe.Value = myNL_Luong_Chi_Tiet.Phu_Cap_Nghe;
                    myCommand.Parameters.Add(pPhu_Cap_Nghe);

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
                using (SqlCommand myCommand = new SqlCommand("NL_Luong_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Luong = new SqlParameter("@Ma_Luong", SqlDbType.Int, 4);
                        pMa_Luong.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Luong"];
                        myCommand.Parameters.Add(pMa_Luong);

                        SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                        pMa_Nhan_Vien.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nhan_Vien"];
                        myCommand.Parameters.Add(pMa_Nhan_Vien);

                        SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                        pTu_Ngay.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Tu_Ngay"];
                        myCommand.Parameters.Add(pTu_Ngay);

                        SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                        pDen_Ngay.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Den_Ngay"];
                        myCommand.Parameters.Add(pDen_Ngay);

                        SqlParameter pMa_Ngach = new SqlParameter("@Ma_Ngach", SqlDbType.NVarChar, 50);
                        pMa_Ngach.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ma_Ngach"];
                        myCommand.Parameters.Add(pMa_Ngach);

                        SqlParameter pBac = new SqlParameter("@Bac", SqlDbType.Int, 4);
                        pBac.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Bac"];
                        myCommand.Parameters.Add(pBac);

                        SqlParameter pHe_So = new SqlParameter("@He_So", SqlDbType.Decimal);
                        pHe_So.Value = (decimal)myDataSet.Tables[strTableName].Rows[i]["He_So"];
                        myCommand.Parameters.Add(pHe_So);

                        SqlParameter pPhu_Cap_TNVK = new SqlParameter("@Phu_Cap_TNVK", SqlDbType.Int, 4);
                        pPhu_Cap_TNVK.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Phu_Cap_TNVK"];
                        myCommand.Parameters.Add(pPhu_Cap_TNVK);

                        SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 250);
                        pGhi_Chu.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ghi_Chu"];
                        myCommand.Parameters.Add(pGhi_Chu);

                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int? Ma_Luong = null, int? Ma_Nhan_Vien = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null, string Ma_Ngach = null, int? Bac = null, decimal? He_So = null, decimal? Phu_Cap_TNVK = null, string Ghi_Chu = null, decimal? Phu_Cap_Chuc_Vu = null, decimal? Phu_Cap_Khac = null, decimal? Phu_Cap_Trach_Nhiem = null, decimal? Phu_Cap_Khu_Vuc = null, decimal? Phu_Cap_Nghe = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Luong_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Luong = new SqlParameter("@Ma_Luong", SqlDbType.Int, 4);
                    pMa_Luong.Value = Ma_Luong;
                    myCommand.Parameters.Add(pMa_Luong);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pMa_Ngach = new SqlParameter("@Ma_Ngach", SqlDbType.NVarChar, 50);
                    pMa_Ngach.Value = Ma_Ngach;
                    myCommand.Parameters.Add(pMa_Ngach);

                    SqlParameter pBac = new SqlParameter("@Bac", SqlDbType.Int, 4);
                    pBac.Value = Bac;
                    myCommand.Parameters.Add(pBac);

                    SqlParameter pHe_So = new SqlParameter("@He_So", SqlDbType.Decimal);
                    pHe_So.Value = He_So;
                    myCommand.Parameters.Add(pHe_So);

                    SqlParameter pPhu_Cap_TNVK = new SqlParameter("@Phu_Cap_TNVK", SqlDbType.Decimal);
                    pPhu_Cap_TNVK.Value = Phu_Cap_TNVK;
                    myCommand.Parameters.Add(pPhu_Cap_TNVK);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 250);
                    pGhi_Chu.Value = Ghi_Chu;
                    myCommand.Parameters.Add(pGhi_Chu);

                    SqlParameter pPhu_Cap_Chuc_Vu = new SqlParameter("@Phu_Cap_Chuc_Vu", SqlDbType.Decimal);
                    pPhu_Cap_Chuc_Vu.Value = Phu_Cap_Chuc_Vu;
                    myCommand.Parameters.Add(pPhu_Cap_Chuc_Vu);

                    SqlParameter pPhu_Cap_Khac = new SqlParameter("@Phu_Cap_Khac", SqlDbType.Decimal);
                    pPhu_Cap_Khac.Value = Phu_Cap_Khac;
                    myCommand.Parameters.Add(pPhu_Cap_Khac);

                    SqlParameter pPhu_Cap_Trach_Nhiem = new SqlParameter("@Phu_Cap_Trach_Nhiem", SqlDbType.Decimal);
                    pPhu_Cap_Trach_Nhiem.Value = Phu_Cap_Trach_Nhiem;
                    myCommand.Parameters.Add(pPhu_Cap_Trach_Nhiem);

                    SqlParameter pPhu_Cap_Khu_Vuc = new SqlParameter("@Phu_Cap_Khu_Vuc", SqlDbType.Decimal);
                    pPhu_Cap_Khu_Vuc.Value = Phu_Cap_Khu_Vuc;
                    myCommand.Parameters.Add(pPhu_Cap_Khu_Vuc);

                    SqlParameter pPhu_Cap_Nghe = new SqlParameter("@Phu_Cap_Nghe", SqlDbType.Decimal);
                    pPhu_Cap_Nghe.Value = Phu_Cap_Nghe;
                    myCommand.Parameters.Add(pPhu_Cap_Nghe);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Ma_Luong)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Luong_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Luong = new SqlParameter("@Ma_Luong", SqlDbType.Int, 4);
                    pMa_Luong.Value = Ma_Luong;
                    myCommand.Parameters.Add(pMa_Luong);

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
                using (SqlCommand myCommand = new SqlCommand("NL_Luong_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Luong_Danh_Sach");
                    return myDataSet.Tables["NL_Luong_Danh_Sach"];
                }
            }
        }
        #endregion

        #region Lay_Boi_NL_Nhan_Vien
        public DataTable Lay_Boi_NL_Nhan_Vien(int Ma_Nhan_Vien)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Luong_Lay_Boi_NL_Nhan_Vien", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Luong_Lay_Boi_NL_Nhan_Vien");
                    return myDataSet.Tables["NL_Luong_Lay_Boi_NL_Nhan_Vien"];
                }
            }
        }
        #endregion

        #region Lay_Gan_Nhat
        public NL_Luong_Chi_Tiet Lay_Gan_Nhat(int Ma_Nhan_Vien)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Luong_Lay_Gan_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Luong_Chi_Tiet");

                    NL_Luong_Chi_Tiet myNL_Luong_Chi_Tiet = new NL_Luong_Chi_Tiet();
                    if (myDataSet.Tables["NL_Luong_Chi_Tiet"] != null)
                    {
                        myNL_Luong_Chi_Tiet.Ma_Luong = myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Ma_Luong"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Ma_Luong"] : (int?)null;
                        myNL_Luong_Chi_Tiet.Ma_Nhan_Vien = myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] : (int?)null;
                        myNL_Luong_Chi_Tiet.Tu_Ngay = myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Tu_Ngay"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Tu_Ngay"] : (DateTime?)null;
                        myNL_Luong_Chi_Tiet.Den_Ngay = myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Den_Ngay"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Den_Ngay"] : (DateTime?)null;
                        myNL_Luong_Chi_Tiet.Ma_Ngach = myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Ma_Ngach"] != DBNull.Value ? (string)myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Ma_Ngach"] : (string)null;
                        myNL_Luong_Chi_Tiet.Bac = myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Bac"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Bac"] : (int?)null;
                        myNL_Luong_Chi_Tiet.He_So = myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["He_So"] != DBNull.Value ? (decimal?)myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["He_So"] : (decimal?)null;
                        myNL_Luong_Chi_Tiet.Phu_Cap_TNVK = myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Phu_Cap_TNVK"] != DBNull.Value ? (decimal?)myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Phu_Cap_TNVK"] : (decimal?)null;
                        myNL_Luong_Chi_Tiet.Phu_Cap_Chuc_Vu = myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Phu_Cap_Chuc_Vu"] != DBNull.Value ? (decimal?)myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Phu_Cap_Chuc_Vu"] : (decimal?)null;
                        myNL_Luong_Chi_Tiet.Phu_Cap_Khac = myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Phu_Cap_Khac"] != DBNull.Value ? (decimal?)myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Phu_Cap_Khac"] : (decimal?)null;

                        myNL_Luong_Chi_Tiet.Phu_Cap_Trach_Nhiem = myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Phu_Cap_Trach_Nhiem"] != DBNull.Value ? (decimal?)myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Phu_Cap_Trach_Nhiem"] : (decimal?)null;

                        myNL_Luong_Chi_Tiet.Phu_Cap_Khu_Vuc = myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Phu_Cap_Khu_Vuc"] != DBNull.Value ? (decimal?)myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Phu_Cap_Khu_Vuc"] : (decimal?)null;
                        myNL_Luong_Chi_Tiet.Phu_Cap_Nghe = myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Phu_Cap_Nghe"] != DBNull.Value ? (decimal?)myDataSet.Tables["NL_Luong_Chi_Tiet"].Rows[0]["Phu_Cap_Nghe"] : (decimal?)null;

                    }
                    return myNL_Luong_Chi_Tiet;
                }
            }
        }
        #endregion

        #region NL_Canh_Bao_Luong_Tinh
        public DataTable NL_Canh_Bao_Luong_Tinh()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Canh_Bao_Luong_Tinh", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Canh_Bao_Luong_Tinh");
                    return myDataSet.Tables["NL_Canh_Bao_Luong_Tinh"];
                }
            }
        }
        #endregion

        #region NL_Canh_Bao_Luong_DonVi
        public DataTable NL_Canh_Bao_Luong_DonVi(int Ma_Don_Vi)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Canh_Bao_Luong_DonVi", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Canh_Bao_Luong_DonVi");
                    return myDataSet.Tables["NL_Canh_Bao_Luong_DonVi"];
                }
            }
        }
        #endregion

        #region NL_Canh_Bao_Luong_Huyen
        public DataTable NL_Canh_Bao_Luong_Huyen(string Ma_Huyen)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Canh_Bao_Luong_Huyen", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.Int, 4);
                    pMa_Huyen.Value = Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Canh_Bao_Luong_Huyen");
                    return myDataSet.Tables["NL_Canh_Bao_Luong_Huyen"];
                }
            }
        }
        #endregion

        #region NL_Canh_Bao_Luong_Khoi_DuPhong
        public DataTable NL_Canh_Bao_Luong_Khoi_DuPhong()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Canh_Bao_Luong_Khoi_DuPhong", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Canh_Bao_Luong_Khoi_DuPhong");
                    return myDataSet.Tables["NL_Canh_Bao_Luong_Khoi_DuPhong"];
                }
            }
        }
        #endregion

        #region NL_Canh_Bao_Luong_Khoi_BenhVien
        public DataTable NL_Canh_Bao_Luong_Khoi_BenhVien()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Canh_Bao_Luong_Khoi_BenhVien", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Canh_Bao_Luong_Khoi_BenhVien");
                    return myDataSet.Tables["NL_Canh_Bao_Luong_Khoi_BenhVien"];
                }
            }
        }
        #endregion

        #region NL_Canh_Bao_Luong_Khoi_DonViTuyenTinh
        public DataTable NL_Canh_Bao_Luong_Khoi_DonViTuyenTinh()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Canh_Bao_Luong_Khoi_DonViTuyenTinh", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Canh_Bao_Luong_Khoi_DonViTuyenTinh");
                    return myDataSet.Tables["NL_Canh_Bao_Luong_Khoi_DonViTuyenTinh"];
                }
            }
        }
        #endregion
    }

    #endregion
}