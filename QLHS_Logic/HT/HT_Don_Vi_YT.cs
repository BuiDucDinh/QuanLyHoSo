using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region HT_Don_Vi_YT_Details
    public class HT_Don_Vi_YT_Chi_Tiet
    {
        public int Ma_Don_Vi;
        public string Ten_Don_Vi; // Tên đơn vị (Trạm y tế xã, huyện, phòng khám, bệnh viện huyện, tỉnh,...)
        public int Tuyen; // Tuyến đơn vị trực thuộc (1:Xã;2:Huyện;3:Tỉnh)
        public string Ma_Tinh; // Mã tỉnh (mặc định là 22 - QN)
        public string Ma_Huyen; // Mã Huyện mà đơn vị trực thuộc (nếu ko có thì để trống)
        public string Ma_Xa; // Mã xã mà đơn vị trực thuộc (nếu ko có thì để trống)
        public int Loai_Hinh; // Loại hình của đơn vị (1:Tuyến khám chữa bệnh;2:Tuyến điều trị)
        public int Thanh_Phan; // Thành phần kinh tế (1: Công lập;2: Tư nhân)
        public bool KB; // Module Khám bệnh
        public bool DP; // Module Dược phẩm
        public bool TB; // Module Thiết bị y tế
        public bool BC; // Module Báo cáo
        public bool SK; // Module Sức khỏe
        public bool DB; // Module Dịch bệnh
        public bool CP; // Module Cấp phép y dược
        public bool NL; // Module Quản lý nhân lực
        public bool AT; // Module An toàn vệ sinh thực phẩm
        public bool DV; // Module Dịch vụ công y tế dự phòng
        public int Loai_Dac_Biet;//0:Bình thường;1:Loại hình 7 và Quản lý nhà nước;2:Vừa là tuyến điều trị vừa là tuyến dự phòng
    }
    #endregion
    #region HT_Don_Vi_YT
    public class HT_Don_Vi_YT
    {
        private string ConnectionString;
        public HT_Don_Vi_YT(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public HT_Don_Vi_YT_Chi_Tiet Lay(int Ma_Don_Vi)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Don_Vi_YT_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pTen_Don_Vi = new SqlParameter("@Ten_Don_Vi", SqlDbType.NVarChar, 250);
                    pTen_Don_Vi.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pTen_Don_Vi);

                    SqlParameter pTuyen = new SqlParameter("@Tuyen", SqlDbType.Int, 4);
                    pTuyen.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pTuyen);

                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pMa_Tinh.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pMa_Tinh);

                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pMa_Huyen.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pMa_Huyen);

                    SqlParameter pMa_Xa = new SqlParameter("@Ma_Xa", SqlDbType.VarChar, 10);
                    pMa_Xa.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pMa_Xa);

                    SqlParameter pLoai_Hinh = new SqlParameter("@Loai_Hinh", SqlDbType.Int, 4);
                    pLoai_Hinh.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pLoai_Hinh);

                    SqlParameter pThanh_Phan = new SqlParameter("@Thanh_Phan", SqlDbType.Int, 4);
                    pThanh_Phan.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pThanh_Phan);

                    SqlParameter pKB = new SqlParameter("@KB", SqlDbType.Bit, 1);
                    pKB.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pKB);

                    SqlParameter pDP = new SqlParameter("@DP", SqlDbType.Bit, 1);
                    pDP.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pDP);

                    SqlParameter pTB = new SqlParameter("@TB", SqlDbType.Bit, 1);
                    pTB.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pTB);

                    SqlParameter pBC = new SqlParameter("@BC", SqlDbType.Bit, 1);
                    pBC.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pBC);

                    SqlParameter pSK = new SqlParameter("@SK", SqlDbType.Bit, 1);
                    pSK.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pSK);

                    SqlParameter pDB = new SqlParameter("@DB", SqlDbType.Bit, 1);
                    pDB.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pDB);

                    SqlParameter pCP = new SqlParameter("@CP", SqlDbType.Bit, 1);
                    pCP.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pCP);

                    SqlParameter pNL = new SqlParameter("@NL", SqlDbType.Bit, 1);
                    pNL.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pNL);

                    SqlParameter pAT = new SqlParameter("@AT", SqlDbType.Bit, 1);
                    pAT.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pAT);

                    SqlParameter pDV = new SqlParameter("@DV", SqlDbType.Bit, 1);
                    pDV.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pDV);

                    SqlParameter pLoai_Dac_Biet = new SqlParameter("@Loai_Dac_Biet", SqlDbType.Int, 4);
                    pLoai_Dac_Biet.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pLoai_Dac_Biet);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();


                    HT_Don_Vi_YT_Chi_Tiet myHT_Don_Vi_YT_Chi_Tiet = new HT_Don_Vi_YT_Chi_Tiet();
                    myHT_Don_Vi_YT_Chi_Tiet.Ma_Don_Vi = Ma_Don_Vi;
                    myHT_Don_Vi_YT_Chi_Tiet.Ten_Don_Vi = (string)pTen_Don_Vi.Value;
                    myHT_Don_Vi_YT_Chi_Tiet.Tuyen = (int)pTuyen.Value;
                    myHT_Don_Vi_YT_Chi_Tiet.Ma_Tinh = (string)pMa_Tinh.Value;
                    myHT_Don_Vi_YT_Chi_Tiet.Ma_Huyen = (string)pMa_Huyen.Value;
                    myHT_Don_Vi_YT_Chi_Tiet.Ma_Xa = (string)pMa_Xa.Value;
                    myHT_Don_Vi_YT_Chi_Tiet.Loai_Hinh = (int)pLoai_Hinh.Value;
                    myHT_Don_Vi_YT_Chi_Tiet.Thanh_Phan = (int)pThanh_Phan.Value;
                    myHT_Don_Vi_YT_Chi_Tiet.KB = (bool)pKB.Value;
                    myHT_Don_Vi_YT_Chi_Tiet.DP = (bool)pDP.Value;
                    myHT_Don_Vi_YT_Chi_Tiet.TB = (bool)pTB.Value;
                    myHT_Don_Vi_YT_Chi_Tiet.BC = (bool)pBC.Value;
                    myHT_Don_Vi_YT_Chi_Tiet.SK = (bool)pSK.Value;
                    myHT_Don_Vi_YT_Chi_Tiet.DB = (bool)pDB.Value;
                    myHT_Don_Vi_YT_Chi_Tiet.CP = (bool)pCP.Value;
                    myHT_Don_Vi_YT_Chi_Tiet.NL = (bool)pNL.Value;
                    myHT_Don_Vi_YT_Chi_Tiet.AT = (bool)pAT.Value;
                    myHT_Don_Vi_YT_Chi_Tiet.DV = (bool)pDV.Value;
                    myHT_Don_Vi_YT_Chi_Tiet.Loai_Dac_Biet = (int)pLoai_Dac_Biet.Value;
                    return myHT_Don_Vi_YT_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int Ma_Don_Vi, string Ten_Don_Vi, int Tuyen, string Ma_Tinh, string Ma_Huyen, string Ma_Xa, int Loai_Hinh, int Thanh_Phan, bool KB, bool DP, bool TB, bool BC, bool SK, bool DB, bool CP, bool NL, bool AT, bool DV, int Loai_Dac_Biet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Don_Vi_YT_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pTen_Don_Vi = new SqlParameter("@Ten_Don_Vi", SqlDbType.NVarChar, 250);
                    pTen_Don_Vi.Value = Ten_Don_Vi;
                    myCommand.Parameters.Add(pTen_Don_Vi);

                    SqlParameter pTuyen = new SqlParameter("@Tuyen", SqlDbType.Int, 4);
                    pTuyen.Value = Tuyen;
                    myCommand.Parameters.Add(pTuyen);

                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pMa_Tinh.Value = Ma_Tinh;
                    myCommand.Parameters.Add(pMa_Tinh);

                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pMa_Huyen.Value = Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

                    SqlParameter pMa_Xa = new SqlParameter("@Ma_Xa", SqlDbType.VarChar, 10);
                    pMa_Xa.Value = Ma_Xa;
                    myCommand.Parameters.Add(pMa_Xa);

                    SqlParameter pLoai_Hinh = new SqlParameter("@Loai_Hinh", SqlDbType.Int, 4);
                    pLoai_Hinh.Value = Loai_Hinh;
                    myCommand.Parameters.Add(pLoai_Hinh);

                    SqlParameter pThanh_Phan = new SqlParameter("@Thanh_Phan", SqlDbType.Int, 4);
                    pThanh_Phan.Value = Thanh_Phan;
                    myCommand.Parameters.Add(pThanh_Phan);

                    SqlParameter pKB = new SqlParameter("@KB", SqlDbType.Bit, 1);
                    pKB.Value = KB;
                    myCommand.Parameters.Add(pKB);

                    SqlParameter pDP = new SqlParameter("@DP", SqlDbType.Bit, 1);
                    pDP.Value = DP;
                    myCommand.Parameters.Add(pDP);

                    SqlParameter pTB = new SqlParameter("@TB", SqlDbType.Bit, 1);
                    pTB.Value = TB;
                    myCommand.Parameters.Add(pTB);

                    SqlParameter pBC = new SqlParameter("@BC", SqlDbType.Bit, 1);
                    pBC.Value = BC;
                    myCommand.Parameters.Add(pBC);

                    SqlParameter pSK = new SqlParameter("@SK", SqlDbType.Bit, 1);
                    pSK.Value = SK;
                    myCommand.Parameters.Add(pSK);

                    SqlParameter pDB = new SqlParameter("@DB", SqlDbType.Bit, 1);
                    pDB.Value = DB;
                    myCommand.Parameters.Add(pDB);

                    SqlParameter pCP = new SqlParameter("@CP", SqlDbType.Bit, 1);
                    pCP.Value = CP;
                    myCommand.Parameters.Add(pCP);

                    SqlParameter pNL = new SqlParameter("@NL", SqlDbType.Bit, 1);
                    pNL.Value = NL;
                    myCommand.Parameters.Add(pNL);

                    SqlParameter pAT = new SqlParameter("@AT", SqlDbType.Bit, 1);
                    pAT.Value = AT;
                    myCommand.Parameters.Add(pAT);

                    SqlParameter pDV = new SqlParameter("@DV", SqlDbType.Bit, 1);
                    pDV.Value = DV;
                    myCommand.Parameters.Add(pDV);

                    SqlParameter pLoai_Dac_Biet = new SqlParameter("@Loai_Dac_Biet", SqlDbType.Int, 4);
                    pLoai_Dac_Biet.Value = Loai_Dac_Biet;
                    myCommand.Parameters.Add(pLoai_Dac_Biet);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int Ma_Don_Vi, string Ten_Don_Vi, int Tuyen, string Ma_Tinh, string Ma_Huyen, string Ma_Xa, int Loai_Hinh, int Thanh_Phan, bool KB, bool DP, bool TB, bool BC, bool SK, bool DB, bool CP, bool NL, bool AT, bool DV,int Loai_Dac_Biet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Don_Vi_YT_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pTen_Don_Vi = new SqlParameter("@Ten_Don_Vi", SqlDbType.NVarChar, 250);
                    pTen_Don_Vi.Value = Ten_Don_Vi;
                    myCommand.Parameters.Add(pTen_Don_Vi);

                    SqlParameter pTuyen = new SqlParameter("@Tuyen", SqlDbType.Int, 4);
                    pTuyen.Value = Tuyen;
                    myCommand.Parameters.Add(pTuyen);

                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pMa_Tinh.Value = Ma_Tinh;
                    myCommand.Parameters.Add(pMa_Tinh);

                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pMa_Huyen.Value = Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

                    SqlParameter pMa_Xa = new SqlParameter("@Ma_Xa", SqlDbType.VarChar, 10);
                    pMa_Xa.Value = Ma_Xa;
                    myCommand.Parameters.Add(pMa_Xa);

                    SqlParameter pLoai_Hinh = new SqlParameter("@Loai_Hinh", SqlDbType.Int, 4);
                    pLoai_Hinh.Value = Loai_Hinh;
                    myCommand.Parameters.Add(pLoai_Hinh);

                    SqlParameter pThanh_Phan = new SqlParameter("@Thanh_Phan", SqlDbType.Int, 4);
                    pThanh_Phan.Value = Thanh_Phan;
                    myCommand.Parameters.Add(pThanh_Phan);

                    SqlParameter pKB = new SqlParameter("@KB", SqlDbType.Bit, 1);
                    pKB.Value = KB;
                    myCommand.Parameters.Add(pKB);

                    SqlParameter pDP = new SqlParameter("@DP", SqlDbType.Bit, 1);
                    pDP.Value = DP;
                    myCommand.Parameters.Add(pDP);

                    SqlParameter pTB = new SqlParameter("@TB", SqlDbType.Bit, 1);
                    pTB.Value = TB;
                    myCommand.Parameters.Add(pTB);

                    SqlParameter pBC = new SqlParameter("@BC", SqlDbType.Bit, 1);
                    pBC.Value = BC;
                    myCommand.Parameters.Add(pBC);

                    SqlParameter pSK = new SqlParameter("@SK", SqlDbType.Bit, 1);
                    pSK.Value = SK;
                    myCommand.Parameters.Add(pSK);

                    SqlParameter pDB = new SqlParameter("@DB", SqlDbType.Bit, 1);
                    pDB.Value = DB;
                    myCommand.Parameters.Add(pDB);

                    SqlParameter pCP = new SqlParameter("@CP", SqlDbType.Bit, 1);
                    pCP.Value = CP;
                    myCommand.Parameters.Add(pCP);

                    SqlParameter pNL = new SqlParameter("@NL", SqlDbType.Bit, 1);
                    pNL.Value = NL;
                    myCommand.Parameters.Add(pNL);

                    SqlParameter pAT = new SqlParameter("@AT", SqlDbType.Bit, 1);
                    pAT.Value = AT;
                    myCommand.Parameters.Add(pAT);

                    SqlParameter pDV = new SqlParameter("@DV", SqlDbType.Bit, 1);
                    pDV.Value = DV;
                    myCommand.Parameters.Add(pDV);

                    SqlParameter pLoai_Dac_Biet = new SqlParameter("@Loai_Dac_Biet", SqlDbType.Int, 4);
                    pLoai_Dac_Biet.Value = Loai_Dac_Biet;
                    myCommand.Parameters.Add(pLoai_Dac_Biet);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(HT_Don_Vi_YT_Chi_Tiet myHT_Don_Vi_YT_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Don_Vi_YT_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = myHT_Don_Vi_YT_Chi_Tiet.Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pTen_Don_Vi = new SqlParameter("@Ten_Don_Vi", SqlDbType.NVarChar, 250);
                    pTen_Don_Vi.Value = myHT_Don_Vi_YT_Chi_Tiet.Ten_Don_Vi;
                    myCommand.Parameters.Add(pTen_Don_Vi);

                    SqlParameter pTuyen = new SqlParameter("@Tuyen", SqlDbType.Int, 4);
                    pTuyen.Value = myHT_Don_Vi_YT_Chi_Tiet.Tuyen;
                    myCommand.Parameters.Add(pTuyen);

                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pMa_Tinh.Value = myHT_Don_Vi_YT_Chi_Tiet.Ma_Tinh;
                    myCommand.Parameters.Add(pMa_Tinh);

                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pMa_Huyen.Value = myHT_Don_Vi_YT_Chi_Tiet.Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

                    SqlParameter pMa_Xa = new SqlParameter("@Ma_Xa", SqlDbType.VarChar, 10);
                    pMa_Xa.Value = myHT_Don_Vi_YT_Chi_Tiet.Ma_Xa;
                    myCommand.Parameters.Add(pMa_Xa);

                    SqlParameter pLoai_Hinh = new SqlParameter("@Loai_Hinh", SqlDbType.Int, 4);
                    pLoai_Hinh.Value = myHT_Don_Vi_YT_Chi_Tiet.Loai_Hinh;
                    myCommand.Parameters.Add(pLoai_Hinh);

                    SqlParameter pThanh_Phan = new SqlParameter("@Thanh_Phan", SqlDbType.Int, 4);
                    pThanh_Phan.Value = myHT_Don_Vi_YT_Chi_Tiet.Thanh_Phan;
                    myCommand.Parameters.Add(pThanh_Phan);

                    SqlParameter pKB = new SqlParameter("@KB", SqlDbType.Bit, 1);
                    pKB.Value = myHT_Don_Vi_YT_Chi_Tiet.KB;
                    myCommand.Parameters.Add(pKB);

                    SqlParameter pDP = new SqlParameter("@DP", SqlDbType.Bit, 1);
                    pDP.Value = myHT_Don_Vi_YT_Chi_Tiet.DP;
                    myCommand.Parameters.Add(pDP);

                    SqlParameter pTB = new SqlParameter("@TB", SqlDbType.Bit, 1);
                    pTB.Value = myHT_Don_Vi_YT_Chi_Tiet.TB;
                    myCommand.Parameters.Add(pTB);

                    SqlParameter pBC = new SqlParameter("@BC", SqlDbType.Bit, 1);
                    pBC.Value = myHT_Don_Vi_YT_Chi_Tiet.BC;
                    myCommand.Parameters.Add(pBC);

                    SqlParameter pSK = new SqlParameter("@SK", SqlDbType.Bit, 1);
                    pSK.Value = myHT_Don_Vi_YT_Chi_Tiet.SK;
                    myCommand.Parameters.Add(pSK);

                    SqlParameter pDB = new SqlParameter("@DB", SqlDbType.Bit, 1);
                    pDB.Value = myHT_Don_Vi_YT_Chi_Tiet.DB;
                    myCommand.Parameters.Add(pDB);

                    SqlParameter pCP = new SqlParameter("@CP", SqlDbType.Bit, 1);
                    pCP.Value = myHT_Don_Vi_YT_Chi_Tiet.CP;
                    myCommand.Parameters.Add(pCP);

                    SqlParameter pNL = new SqlParameter("@NL", SqlDbType.Bit, 1);
                    pNL.Value = myHT_Don_Vi_YT_Chi_Tiet.NL;
                    myCommand.Parameters.Add(pNL);

                    SqlParameter pAT = new SqlParameter("@AT", SqlDbType.Bit, 1);
                    pAT.Value = myHT_Don_Vi_YT_Chi_Tiet.AT;
                    myCommand.Parameters.Add(pAT);

                    SqlParameter pDV = new SqlParameter("@DV", SqlDbType.Bit, 1);
                    pDV.Value = myHT_Don_Vi_YT_Chi_Tiet.DV;
                    myCommand.Parameters.Add(pDV);

                    SqlParameter pLoai_Dac_Biet = new SqlParameter("@Loai_Dac_Biet", SqlDbType.Int, 4);
                    pLoai_Dac_Biet.Value = myHT_Don_Vi_YT_Chi_Tiet.Loai_Dac_Biet;
                    myCommand.Parameters.Add(pLoai_Dac_Biet);

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
                using (SqlCommand myCommand = new SqlCommand("HT_Don_Vi_YT_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                        pMa_Don_Vi.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Don_Vi"];
                        myCommand.Parameters.Add(pMa_Don_Vi);

                        SqlParameter pTen_Don_Vi = new SqlParameter("@Ten_Don_Vi", SqlDbType.NVarChar, 250);
                        pTen_Don_Vi.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ten_Don_Vi"];
                        myCommand.Parameters.Add(pTen_Don_Vi);

                        SqlParameter pTuyen = new SqlParameter("@Tuyen", SqlDbType.Int, 4);
                        pTuyen.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Tuyen"];
                        myCommand.Parameters.Add(pTuyen);

                        SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                        pMa_Tinh.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ma_Tinh"];
                        myCommand.Parameters.Add(pMa_Tinh);

                        SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                        pMa_Huyen.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ma_Huyen"];
                        myCommand.Parameters.Add(pMa_Huyen);

                        SqlParameter pMa_Xa = new SqlParameter("@Ma_Xa", SqlDbType.VarChar, 10);
                        pMa_Xa.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ma_Xa"];
                        myCommand.Parameters.Add(pMa_Xa);

                        SqlParameter pLoai_Hinh = new SqlParameter("@Loai_Hinh", SqlDbType.Int, 4);
                        pLoai_Hinh.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Loai_Hinh"];
                        myCommand.Parameters.Add(pLoai_Hinh);

                        SqlParameter pThanh_Phan = new SqlParameter("@Thanh_Phan", SqlDbType.Int, 4);
                        pThanh_Phan.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Thanh_Phan"];
                        myCommand.Parameters.Add(pThanh_Phan);

                        SqlParameter pKB = new SqlParameter("@KB", SqlDbType.Bit, 1);
                        pKB.Value = (bool)myDataSet.Tables[strTableName].Rows[i]["KB"];
                        myCommand.Parameters.Add(pKB);

                        SqlParameter pDP = new SqlParameter("@DP", SqlDbType.Bit, 1);
                        pDP.Value = (bool)myDataSet.Tables[strTableName].Rows[i]["DP"];
                        myCommand.Parameters.Add(pDP);

                        SqlParameter pTB = new SqlParameter("@TB", SqlDbType.Bit, 1);
                        pTB.Value = (bool)myDataSet.Tables[strTableName].Rows[i]["TB"];
                        myCommand.Parameters.Add(pTB);

                        SqlParameter pBC = new SqlParameter("@BC", SqlDbType.Bit, 1);
                        pBC.Value = (bool)myDataSet.Tables[strTableName].Rows[i]["BC"];
                        myCommand.Parameters.Add(pBC);

                        SqlParameter pSK = new SqlParameter("@SK", SqlDbType.Bit, 1);
                        pSK.Value = (bool)myDataSet.Tables[strTableName].Rows[i]["SK"];
                        myCommand.Parameters.Add(pSK);

                        SqlParameter pDB = new SqlParameter("@DB", SqlDbType.Bit, 1);
                        pDB.Value = (bool)myDataSet.Tables[strTableName].Rows[i]["DB"];
                        myCommand.Parameters.Add(pDB);

                        SqlParameter pCP = new SqlParameter("@CP", SqlDbType.Bit, 1);
                        pCP.Value = (bool)myDataSet.Tables[strTableName].Rows[i]["CP"];
                        myCommand.Parameters.Add(pCP);

                        SqlParameter pNL = new SqlParameter("@NL", SqlDbType.Bit, 1);
                        pNL.Value = (bool)myDataSet.Tables[strTableName].Rows[i]["NL"];
                        myCommand.Parameters.Add(pNL);

                        SqlParameter pAT = new SqlParameter("@AT", SqlDbType.Bit, 1);
                        pAT.Value = (bool)myDataSet.Tables[strTableName].Rows[i]["AT"];
                        myCommand.Parameters.Add(pAT);

                        SqlParameter pDV = new SqlParameter("@DV", SqlDbType.Bit, 1);
                        pDV.Value = (bool)myDataSet.Tables[strTableName].Rows[i]["DV"];
                        myCommand.Parameters.Add(pDV);


                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int Ma_Don_Vi, string Ten_Don_Vi, int Tuyen, string Ma_Tinh, string Ma_Huyen, string Ma_Xa, int Loai_Hinh, int Thanh_Phan, bool KB, bool DP, bool TB, bool BC, bool SK, bool DB, bool CP, bool NL, bool AT, bool DV, int Loai_Dac_Biet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Don_Vi_YT_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pTen_Don_Vi = new SqlParameter("@Ten_Don_Vi", SqlDbType.NVarChar, 250);
                    pTen_Don_Vi.Value = Ten_Don_Vi;
                    myCommand.Parameters.Add(pTen_Don_Vi);

                    SqlParameter pTuyen = new SqlParameter("@Tuyen", SqlDbType.Int, 4);
                    pTuyen.Value = Tuyen;
                    myCommand.Parameters.Add(pTuyen);

                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pMa_Tinh.Value = Ma_Tinh;
                    myCommand.Parameters.Add(pMa_Tinh);

                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pMa_Huyen.Value = Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

                    SqlParameter pMa_Xa = new SqlParameter("@Ma_Xa", SqlDbType.VarChar, 10);
                    pMa_Xa.Value = Ma_Xa;
                    myCommand.Parameters.Add(pMa_Xa);

                    SqlParameter pLoai_Hinh = new SqlParameter("@Loai_Hinh", SqlDbType.Int, 4);
                    pLoai_Hinh.Value = Loai_Hinh;
                    myCommand.Parameters.Add(pLoai_Hinh);

                    SqlParameter pThanh_Phan = new SqlParameter("@Thanh_Phan", SqlDbType.Int, 4);
                    pThanh_Phan.Value = Thanh_Phan;
                    myCommand.Parameters.Add(pThanh_Phan);

                    SqlParameter pKB = new SqlParameter("@KB", SqlDbType.Bit, 1);
                    pKB.Value = KB;
                    myCommand.Parameters.Add(pKB);

                    SqlParameter pDP = new SqlParameter("@DP", SqlDbType.Bit, 1);
                    pDP.Value = DP;
                    myCommand.Parameters.Add(pDP);

                    SqlParameter pTB = new SqlParameter("@TB", SqlDbType.Bit, 1);
                    pTB.Value = TB;
                    myCommand.Parameters.Add(pTB);

                    SqlParameter pBC = new SqlParameter("@BC", SqlDbType.Bit, 1);
                    pBC.Value = BC;
                    myCommand.Parameters.Add(pBC);

                    SqlParameter pSK = new SqlParameter("@SK", SqlDbType.Bit, 1);
                    pSK.Value = SK;
                    myCommand.Parameters.Add(pSK);

                    SqlParameter pDB = new SqlParameter("@DB", SqlDbType.Bit, 1);
                    pDB.Value = DB;
                    myCommand.Parameters.Add(pDB);

                    SqlParameter pCP = new SqlParameter("@CP", SqlDbType.Bit, 1);
                    pCP.Value = CP;
                    myCommand.Parameters.Add(pCP);

                    SqlParameter pNL = new SqlParameter("@NL", SqlDbType.Bit, 1);
                    pNL.Value = NL;
                    myCommand.Parameters.Add(pNL);

                    SqlParameter pAT = new SqlParameter("@AT", SqlDbType.Bit, 1);
                    pAT.Value = AT;
                    myCommand.Parameters.Add(pAT);

                    SqlParameter pDV = new SqlParameter("@DV", SqlDbType.Bit, 1);
                    pDV.Value = DV;
                    myCommand.Parameters.Add(pDV);

                    SqlParameter pLoai_Dac_Biet = new SqlParameter("@Loai_Dac_Biet", SqlDbType.Int, 4);
                    pLoai_Dac_Biet.Value = Loai_Dac_Biet;
                    myCommand.Parameters.Add(pLoai_Dac_Biet);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Ma_Don_Vi)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Don_Vi_YT_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

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
                using (SqlCommand myCommand = new SqlCommand("HT_Don_Vi_YT_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Don_Vi_YT_Danh_Sach");
                    return myDataSet.Tables["HT_Don_Vi_YT_Danh_Sach"];
                }
            }
        }
        #endregion

        


    }
    #endregion
}