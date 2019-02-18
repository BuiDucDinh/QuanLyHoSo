using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region NL_Qua_Trinh_Hoc_Tap_Details
    public class NL_Qua_Trinh_Hoc_Tap_Chi_Tiet
    {
        public int? Ma_Qua_Trinh_Hoc_Tap = null; // Mã quá trình 
        public int? Ma_Nhan_Vien = null; // Mã nhân viên
        public DateTime? Tu_Ngay = null; // Từ ngày
        public DateTime? Den_Ngay = null; // Đến ngày
        public string Ten_Truong = null; // Nơi học
        public string Ten_Chuyen_Nganh = null; // Tên chuyên ngành
        public int? Ma_Dao_Tao = null; // Mã đào tạo
        public string Van_Bang = null; // Văn bằng
        public int? Ma_Hoc_Van = null; // Mã học vấn
        public int? Ma_Ten_Van_Bang = null;//Mã tên văn bằng (danh mục)
        public string Ghi_Chu = null;
    }
    #endregion
    #region NL_Qua_Trinh_Hoc_Tap
    public class NL_Qua_Trinh_Hoc_Tap
    {
        private string ConnectionString;
        public NL_Qua_Trinh_Hoc_Tap(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_Qua_Trinh_Hoc_Tap_Chi_Tiet Lay(int Ma_Qua_Trinh_Hoc_Tap)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Qua_Trinh_Hoc_Tap_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Qua_Trinh_Hoc_Tap = new SqlParameter("@Ma_Qua_Trinh_Hoc_Tap", SqlDbType.Int, 4);
                    pMa_Qua_Trinh_Hoc_Tap.Value = Ma_Qua_Trinh_Hoc_Tap;
                    myCommand.Parameters.Add(pMa_Qua_Trinh_Hoc_Tap);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Qua_Trinh_Hoc_Tap_Chi_Tiet");
                    NL_Qua_Trinh_Hoc_Tap_Chi_Tiet myNL_Qua_Trinh_Hoc_Tap_Chi_Tiet = new NL_Qua_Trinh_Hoc_Tap_Chi_Tiet();
                    if (myDataSet.Tables["NL_Qua_Trinh_Hoc_Tap_Chi_Tiet"] != null)
                    {
                        myNL_Qua_Trinh_Hoc_Tap_Chi_Tiet.Ma_Qua_Trinh_Hoc_Tap = Ma_Qua_Trinh_Hoc_Tap;
                        myNL_Qua_Trinh_Hoc_Tap_Chi_Tiet.Ma_Nhan_Vien = myDataSet.Tables["NL_Qua_Trinh_Hoc_Tap_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Qua_Trinh_Hoc_Tap_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] : (int?)null;
                        myNL_Qua_Trinh_Hoc_Tap_Chi_Tiet.Tu_Ngay = myDataSet.Tables["NL_Qua_Trinh_Hoc_Tap_Chi_Tiet"].Rows[0]["Tu_Ngay"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Qua_Trinh_Hoc_Tap_Chi_Tiet"].Rows[0]["Tu_Ngay"] : (DateTime?)null;
                        myNL_Qua_Trinh_Hoc_Tap_Chi_Tiet.Den_Ngay = myDataSet.Tables["NL_Qua_Trinh_Hoc_Tap_Chi_Tiet"].Rows[0]["Den_Ngay"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Qua_Trinh_Hoc_Tap_Chi_Tiet"].Rows[0]["Den_Ngay"] : (DateTime?)null;
                        myNL_Qua_Trinh_Hoc_Tap_Chi_Tiet.Ten_Truong = myDataSet.Tables["NL_Qua_Trinh_Hoc_Tap_Chi_Tiet"].Rows[0]["Ten_Truong"] != DBNull.Value ? (string)myDataSet.Tables["NL_Qua_Trinh_Hoc_Tap_Chi_Tiet"].Rows[0]["Ten_Truong"] : (string)null;
                        myNL_Qua_Trinh_Hoc_Tap_Chi_Tiet.Ten_Chuyen_Nganh = myDataSet.Tables["NL_Qua_Trinh_Hoc_Tap_Chi_Tiet"].Rows[0]["Ten_Chuyen_Nganh"] != DBNull.Value ? (string)myDataSet.Tables["NL_Qua_Trinh_Hoc_Tap_Chi_Tiet"].Rows[0]["Ten_Chuyen_Nganh"] : (string)null;
                        myNL_Qua_Trinh_Hoc_Tap_Chi_Tiet.Ma_Dao_Tao = myDataSet.Tables["NL_Qua_Trinh_Hoc_Tap_Chi_Tiet"].Rows[0]["Ma_Dao_Tao"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Qua_Trinh_Hoc_Tap_Chi_Tiet"].Rows[0]["Ma_Dao_Tao"] : (int?)null;
                        myNL_Qua_Trinh_Hoc_Tap_Chi_Tiet.Van_Bang = myDataSet.Tables["NL_Qua_Trinh_Hoc_Tap_Chi_Tiet"].Rows[0]["Van_Bang"] != DBNull.Value ? (string)myDataSet.Tables["NL_Qua_Trinh_Hoc_Tap_Chi_Tiet"].Rows[0]["Van_Bang"] : (string)null;
                        myNL_Qua_Trinh_Hoc_Tap_Chi_Tiet.Ma_Hoc_Van = myDataSet.Tables["NL_Qua_Trinh_Hoc_Tap_Chi_Tiet"].Rows[0]["Ma_Hoc_Van"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Qua_Trinh_Hoc_Tap_Chi_Tiet"].Rows[0]["Ma_Hoc_Van"] : (int?)null;
                        myNL_Qua_Trinh_Hoc_Tap_Chi_Tiet.Ma_Ten_Van_Bang = myDataSet.Tables["NL_Qua_Trinh_Hoc_Tap_Chi_Tiet"].Rows[0]["Ma_Ten_Van_Bang"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Qua_Trinh_Hoc_Tap_Chi_Tiet"].Rows[0]["Ma_Ten_Van_Bang"] : (int?)null;
                        myNL_Qua_Trinh_Hoc_Tap_Chi_Tiet.Ghi_Chu = myDataSet.Tables["NL_Qua_Trinh_Hoc_Tap_Chi_Tiet"].Rows[0]["Ghi_Chu"] != DBNull.Value ? (string)myDataSet.Tables["NL_Qua_Trinh_Hoc_Tap_Chi_Tiet"].Rows[0]["Ghi_Chu"] : (string)null;
                    }
                    return myNL_Qua_Trinh_Hoc_Tap_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Ma_Qua_Trinh_Hoc_Tap = null, int? Ma_Nhan_Vien = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null, string Ten_Truong = null, string Ten_Chuyen_Nganh = null, int? Ma_Dao_Tao = null, string Van_Bang = null, int? Ma_Hoc_Van = null, int? Ma_Ten_Van_Bang = null, string Ghi_Chu = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Qua_Trinh_Hoc_Tap_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Qua_Trinh_Hoc_Tap = new SqlParameter("@Ma_Qua_Trinh_Hoc_Tap", SqlDbType.Int, 4);
                    pMa_Qua_Trinh_Hoc_Tap.Value = Ma_Qua_Trinh_Hoc_Tap;
                    myCommand.Parameters.Add(pMa_Qua_Trinh_Hoc_Tap);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pTen_Truong = new SqlParameter("@Ten_Truong", SqlDbType.NVarChar, 500);
                    pTen_Truong.Value = Ten_Truong;
                    myCommand.Parameters.Add(pTen_Truong);

                    SqlParameter pTen_Chuyen_Nganh = new SqlParameter("@Ten_Chuyen_Nganh", SqlDbType.NVarChar, 500);
                    pTen_Chuyen_Nganh.Value = Ten_Chuyen_Nganh;
                    myCommand.Parameters.Add(pTen_Chuyen_Nganh);

                    SqlParameter pMa_Dao_Tao = new SqlParameter("@Ma_Dao_Tao", SqlDbType.Int, 4);
                    pMa_Dao_Tao.Value = Ma_Dao_Tao;
                    myCommand.Parameters.Add(pMa_Dao_Tao);

                    SqlParameter pVan_Bang = new SqlParameter("@Van_Bang", SqlDbType.NVarChar, 250);
                    pVan_Bang.Value = Van_Bang;
                    myCommand.Parameters.Add(pVan_Bang);

                    SqlParameter pMa_Hoc_Van = new SqlParameter("@Ma_Hoc_Van", SqlDbType.Int, 4);
                    pMa_Hoc_Van.Value = Ma_Hoc_Van;
                    myCommand.Parameters.Add(pMa_Hoc_Van);

                    SqlParameter pMa_Ten_Van_Bang = new SqlParameter("@Ma_Ten_Van_Bang", SqlDbType.Int, 4);
                    pMa_Ten_Van_Bang.Value = Ma_Ten_Van_Bang;
                    myCommand.Parameters.Add(pMa_Ten_Van_Bang);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 500);
                    pGhi_Chu.Value = Ghi_Chu;
                    myCommand.Parameters.Add(pGhi_Chu);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int? Ma_Qua_Trinh_Hoc_Tap = null, int? Ma_Nhan_Vien = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null, string Ten_Truong = null, string Ten_Chuyen_Nganh = null, int? Ma_Dao_Tao = null, string Van_Bang = null, int? Ma_Hoc_Van = null, int? Ma_Ten_Van_Bang = null, string Ghi_Chu = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Qua_Trinh_Hoc_Tap_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Qua_Trinh_Hoc_Tap = new SqlParameter("@Ma_Qua_Trinh_Hoc_Tap", SqlDbType.Int, 4);
                    pMa_Qua_Trinh_Hoc_Tap.Value = Ma_Qua_Trinh_Hoc_Tap;
                    myCommand.Parameters.Add(pMa_Qua_Trinh_Hoc_Tap);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pTen_Truong = new SqlParameter("@Ten_Truong", SqlDbType.NVarChar, 500);
                    pTen_Truong.Value = Ten_Truong;
                    myCommand.Parameters.Add(pTen_Truong);

                    SqlParameter pTen_Chuyen_Nganh = new SqlParameter("@Ten_Chuyen_Nganh", SqlDbType.NVarChar, 500);
                    pTen_Chuyen_Nganh.Value = Ten_Chuyen_Nganh;
                    myCommand.Parameters.Add(pTen_Chuyen_Nganh);

                    SqlParameter pMa_Dao_Tao = new SqlParameter("@Ma_Dao_Tao", SqlDbType.Int, 4);
                    pMa_Dao_Tao.Value = Ma_Dao_Tao;
                    myCommand.Parameters.Add(pMa_Dao_Tao);

                    SqlParameter pVan_Bang = new SqlParameter("@Van_Bang", SqlDbType.NVarChar, 250);
                    pVan_Bang.Value = Van_Bang;
                    myCommand.Parameters.Add(pVan_Bang);

                    SqlParameter pMa_Hoc_Van = new SqlParameter("@Ma_Hoc_Van", SqlDbType.Int, 4);
                    pMa_Hoc_Van.Value = Ma_Hoc_Van;
                    myCommand.Parameters.Add(pMa_Hoc_Van);

                    SqlParameter pMa_Ten_Van_Bang = new SqlParameter("@Ma_Ten_Van_Bang", SqlDbType.Int, 4);
                    pMa_Ten_Van_Bang.Value = Ma_Ten_Van_Bang;
                    myCommand.Parameters.Add(pMa_Ten_Van_Bang);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 500);
                    pGhi_Chu.Value = Ghi_Chu;
                    myCommand.Parameters.Add(pGhi_Chu);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(NL_Qua_Trinh_Hoc_Tap_Chi_Tiet myNL_Qua_Trinh_Hoc_Tap_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Qua_Trinh_Hoc_Tap_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Qua_Trinh_Hoc_Tap = new SqlParameter("@Ma_Qua_Trinh_Hoc_Tap", SqlDbType.Int, 4);
                    pMa_Qua_Trinh_Hoc_Tap.Value = myNL_Qua_Trinh_Hoc_Tap_Chi_Tiet.Ma_Qua_Trinh_Hoc_Tap;
                    myCommand.Parameters.Add(pMa_Qua_Trinh_Hoc_Tap);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = myNL_Qua_Trinh_Hoc_Tap_Chi_Tiet.Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = myNL_Qua_Trinh_Hoc_Tap_Chi_Tiet.Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = myNL_Qua_Trinh_Hoc_Tap_Chi_Tiet.Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pTen_Truong = new SqlParameter("@Ten_Truong", SqlDbType.NVarChar, 500);
                    pTen_Truong.Value = myNL_Qua_Trinh_Hoc_Tap_Chi_Tiet.Ten_Truong;
                    myCommand.Parameters.Add(pTen_Truong);

                    SqlParameter pTen_Chuyen_Nganh = new SqlParameter("@Ten_Chuyen_Nganh", SqlDbType.NVarChar, 500);
                    pTen_Chuyen_Nganh.Value = myNL_Qua_Trinh_Hoc_Tap_Chi_Tiet.Ten_Chuyen_Nganh;
                    myCommand.Parameters.Add(pTen_Chuyen_Nganh);

                    SqlParameter pMa_Dao_Tao = new SqlParameter("@Ma_Dao_Tao", SqlDbType.Int, 4);
                    pMa_Dao_Tao.Value = myNL_Qua_Trinh_Hoc_Tap_Chi_Tiet.Ma_Dao_Tao;
                    myCommand.Parameters.Add(pMa_Dao_Tao);

                    SqlParameter pVan_Bang = new SqlParameter("@Van_Bang", SqlDbType.NVarChar, 250);
                    pVan_Bang.Value = myNL_Qua_Trinh_Hoc_Tap_Chi_Tiet.Van_Bang;
                    myCommand.Parameters.Add(pVan_Bang);

                    SqlParameter pMa_Hoc_Van = new SqlParameter("@Ma_Hoc_Van", SqlDbType.Int, 4);
                    pMa_Hoc_Van.Value = myNL_Qua_Trinh_Hoc_Tap_Chi_Tiet.Ma_Hoc_Van;
                    myCommand.Parameters.Add(pMa_Hoc_Van);

                    SqlParameter pMa_Ten_Van_Bang = new SqlParameter("@Ma_Ten_Van_Bang", SqlDbType.Int, 4);
                    pMa_Ten_Van_Bang.Value = myNL_Qua_Trinh_Hoc_Tap_Chi_Tiet.Ma_Ten_Van_Bang;
                    myCommand.Parameters.Add(pMa_Ten_Van_Bang);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 500);
                    pGhi_Chu.Value = myNL_Qua_Trinh_Hoc_Tap_Chi_Tiet.Ghi_Chu;
                    myCommand.Parameters.Add(pGhi_Chu);

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
                using (SqlCommand myCommand = new SqlCommand("NL_Qua_Trinh_Hoc_Tap_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Qua_Trinh_Hoc_Tap = new SqlParameter("@Ma_Qua_Trinh_Hoc_Tap", SqlDbType.Int, 4);
                        pMa_Qua_Trinh_Hoc_Tap.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Qua_Trinh_Hoc_Tap"];
                        myCommand.Parameters.Add(pMa_Qua_Trinh_Hoc_Tap);

                        SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                        pMa_Nhan_Vien.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nhan_Vien"];
                        myCommand.Parameters.Add(pMa_Nhan_Vien);

                        SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                        pTu_Ngay.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Tu_Ngay"];
                        myCommand.Parameters.Add(pTu_Ngay);

                        SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                        pDen_Ngay.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Den_Ngay"];
                        myCommand.Parameters.Add(pDen_Ngay);

                        SqlParameter pTen_Truong = new SqlParameter("@Ten_Truong", SqlDbType.NVarChar, 500);
                        pTen_Truong.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ten_Truong"];
                        myCommand.Parameters.Add(pTen_Truong);

                        SqlParameter pTen_Chuyen_Nganh = new SqlParameter("@Ten_Chuyen_Nganh", SqlDbType.NVarChar, 500);
                        pTen_Chuyen_Nganh.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ten_Chuyen_Nganh"];
                        myCommand.Parameters.Add(pTen_Chuyen_Nganh);

                        SqlParameter pMa_Dao_Tao = new SqlParameter("@Ma_Dao_Tao", SqlDbType.Int, 4);
                        pMa_Dao_Tao.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Dao_Tao"];
                        myCommand.Parameters.Add(pMa_Dao_Tao);

                        SqlParameter pVan_Bang = new SqlParameter("@Van_Bang", SqlDbType.NVarChar, 250);
                        pVan_Bang.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Van_Bang"];
                        myCommand.Parameters.Add(pVan_Bang);

                        SqlParameter pMa_Hoc_Van = new SqlParameter("@Ma_Hoc_Van", SqlDbType.Int, 4);
                        pMa_Hoc_Van.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Hoc_Van"];
                        myCommand.Parameters.Add(pMa_Hoc_Van);

                        SqlParameter pMa_Ten_Van_Bang = new SqlParameter("@Ma_Ten_Van_Bang", SqlDbType.Int, 4);
                        pMa_Ten_Van_Bang.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Ten_Van_Bang"];
                        myCommand.Parameters.Add(pMa_Ten_Van_Bang);

                        SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 500);
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
        public void Cap_Nhat_Them(int? Ma_Qua_Trinh_Hoc_Tap = null, int? Ma_Nhan_Vien = null, DateTime? Tu_Ngay = null, DateTime? Den_Ngay = null, string Ten_Truong = null, string Ten_Chuyen_Nganh = null, int? Ma_Dao_Tao = null, string Van_Bang = null, int? Ma_Hoc_Van = null, int? Ma_Ten_Van_Bang = null, string Ghi_Chu = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Qua_Trinh_Hoc_Tap_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Qua_Trinh_Hoc_Tap = new SqlParameter("@Ma_Qua_Trinh_Hoc_Tap", SqlDbType.Int, 4);
                    pMa_Qua_Trinh_Hoc_Tap.Value = Ma_Qua_Trinh_Hoc_Tap;
                    myCommand.Parameters.Add(pMa_Qua_Trinh_Hoc_Tap);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay = new SqlParameter("@Tu_Ngay", SqlDbType.DateTime, 8);
                    pTu_Ngay.Value = Tu_Ngay;
                    myCommand.Parameters.Add(pTu_Ngay);

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pTen_Truong = new SqlParameter("@Ten_Truong", SqlDbType.NVarChar, 500);
                    pTen_Truong.Value = Ten_Truong;
                    myCommand.Parameters.Add(pTen_Truong);

                    SqlParameter pTen_Chuyen_Nganh = new SqlParameter("@Ten_Chuyen_Nganh", SqlDbType.NVarChar, 500);
                    pTen_Chuyen_Nganh.Value = Ten_Chuyen_Nganh;
                    myCommand.Parameters.Add(pTen_Chuyen_Nganh);

                    SqlParameter pMa_Dao_Tao = new SqlParameter("@Ma_Dao_Tao", SqlDbType.Int, 4);
                    pMa_Dao_Tao.Value = Ma_Dao_Tao;
                    myCommand.Parameters.Add(pMa_Dao_Tao);

                    SqlParameter pVan_Bang = new SqlParameter("@Van_Bang", SqlDbType.NVarChar, 250);
                    pVan_Bang.Value = Van_Bang;
                    myCommand.Parameters.Add(pVan_Bang);

                    SqlParameter pMa_Hoc_Van = new SqlParameter("@Ma_Hoc_Van", SqlDbType.Int, 4);
                    pMa_Hoc_Van.Value = Ma_Hoc_Van;
                    myCommand.Parameters.Add(pMa_Hoc_Van);

                    SqlParameter pMa_Ten_Van_Bang = new SqlParameter("@Ma_Ten_Van_Bang", SqlDbType.Int, 4);
                    pMa_Ten_Van_Bang.Value = Ma_Ten_Van_Bang;
                    myCommand.Parameters.Add(pMa_Ten_Van_Bang);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 500);
                    pGhi_Chu.Value = Ghi_Chu;
                    myCommand.Parameters.Add(pGhi_Chu);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Ma_Qua_Trinh_Hoc_Tap)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Qua_Trinh_Hoc_Tap_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Qua_Trinh_Hoc_Tap = new SqlParameter("@Ma_Qua_Trinh_Hoc_Tap", SqlDbType.Int, 4);
                    pMa_Qua_Trinh_Hoc_Tap.Value = Ma_Qua_Trinh_Hoc_Tap;
                    myCommand.Parameters.Add(pMa_Qua_Trinh_Hoc_Tap);

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
                using (SqlCommand myCommand = new SqlCommand("NL_Qua_Trinh_Hoc_Tap_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Qua_Trinh_Hoc_Tap_Danh_Sach");
                    return myDataSet.Tables["NL_Qua_Trinh_Hoc_Tap_Danh_Sach"];
                }
            }
        }
        #endregion

        #region Lay_Boi_NL_DM_Dao_Tao
        public DataTable Lay_Boi_NL_DM_Dao_Tao(int Ma_Dao_Tao)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Qua_Trinh_Hoc_Tap_Lay_Boi_NL_DM_Dao_Tao", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Dao_Tao = new SqlParameter("@Ma_Dao_Tao", SqlDbType.Int, 4);
                    pMa_Dao_Tao.Value = Ma_Dao_Tao;
                    myCommand.Parameters.Add(pMa_Dao_Tao);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Qua_Trinh_Hoc_Tap_Lay_Boi_NL_DM_Dao_Tao");
                    return myDataSet.Tables["NL_Qua_Trinh_Hoc_Tap_Lay_Boi_NL_DM_Dao_Tao"];
                }
            }
        }
        #endregion
        #region Lay_Boi_NL_DM_Hoc_Van
        public DataTable Lay_Boi_NL_DM_Hoc_Van(int Ma_Hoc_Van)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Qua_Trinh_Hoc_Tap_Lay_Boi_NL_DM_Hoc_Van", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Hoc_Van = new SqlParameter("@Ma_Hoc_Van", SqlDbType.Int, 4);
                    pMa_Hoc_Van.Value = Ma_Hoc_Van;
                    myCommand.Parameters.Add(pMa_Hoc_Van);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Qua_Trinh_Hoc_Tap_Lay_Boi_NL_DM_Hoc_Van");
                    return myDataSet.Tables["NL_Qua_Trinh_Hoc_Tap_Lay_Boi_NL_DM_Hoc_Van"];
                }
            }
        }
        #endregion
        #region Lay_Boi_NL_Nhan_Vien
        public DataTable Lay_Boi_NL_Nhan_Vien(int Ma_Nhan_Vien)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Qua_Trinh_Hoc_Tap_Lay_Boi_NL_Nhan_Vien", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Qua_Trinh_Hoc_Tap_Lay_Boi_NL_Nhan_Vien");
                    return myDataSet.Tables["NL_Qua_Trinh_Hoc_Tap_Lay_Boi_NL_Nhan_Vien"];
                }
            }
        }
        #endregion

    }
    #endregion
}