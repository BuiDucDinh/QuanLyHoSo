using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.IO;
using System.Configuration;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using QLHS_Logic.NV;
namespace QLHS_Logic
{
    public class Sys_Common
    {

        #region Variable
        //static public string ConnectionString = "Data Source=PC2014032421FGL\\SQLEXPRESS;Initial Catalog=DuAn_CucThue;User ID=sa;Password=123;Integrated Security=True";
        //static public string ConnectionString = "Data Source=WINDOWS7-PC;Initial Catalog=QLHHC; User ID=sa;Password=123;Integrated Security=True";
        static public string ConnectionString = ConfigurationManager.ConnectionStrings["DHMConnectionString"].ConnectionString;

        public const string Key = "DHM-2012"; //constant
        public const string G_MA_TINH = "22";//Mã tỉnh
        public const string G_TEN_TINH = "Tên tỉnh thành";


        public const int G_TUYEN_XA = 1;
        public const int G_TUYEN_HUYEN = 2;
        public const int G_TUYEN_TINH = 3;

        public const int G_LOAI_HINH_KHAM_CHUA_BENH = 1;
        public const int G_LOAI_HINH_DU_PHONG = 0;
        public const int G_LOAI_HINH_PHONG_BAN_THUOC_SO_YTE = 2;
        public const int G_LOAI_HINH_CHI_CUC_TRUNG_TAM_CHUYEN_NGANH = 3;

        public const int G_LOAI_HINH_CHON_TUYEN_DU_PHONG = 0;
        public const int G_LOAI_HINH_CHON_TUYEN_DIEU_TRI = 1;
        public const int G_LOAI_HINH_CHON_TUYEN_QL_NN = 2;

        public const string CHECKED = "";
        //public const string CHECKED = "True";
        public const string NOTCHECKED = "";

        static public string str = "";

        #region AT


        public const int G_ATCN_DON_DE_NGHI_ND_SOAN_DON = 1;
        public const int G_ATCN_DON_DE_NGHI_ND_NOP_DON = 2;
        public const int G_ATCN_DON_DE_NGHI_NV_1CUA_NHAN_DON = 3;
        public const int G_ATCN_DON_DE_NGHI_NV_1CUA_CHUYEN_DON = 4;
        public const int G_ATCN_DON_DE_NGHI_NV_NHAN_DON = 5;
        public const int G_ATCN_DON_DE_NGHI_NV_TRINH_DUYET = 6;
        public const int G_ATCN_DON_DE_NGHI_LD_NHAN_DON = 7;
        public const int G_ATCN_DON_DE_NGHI_LD_PHE_DUYET = 8;
        public const int G_ATCN_DON_DE_NGHI_HUY = 99;

        public const int G_ATCN_DON_CAP_MOI = 0;
        public const int G_ATCN_DON_CAP_LAI = 1;
        public const int G_ATCN_SO_NGAY_TRA = 25;
        public const bool G_ATCN_DANG_KY_TREN_MANG = true;
        public const bool G_ATCN_DANG_KY_TRUC_TIEP = false;

        public const int G_ATQC_DON_DE_NGHI_ND_SOAN_DON = 1;
        public const int G_ATQC_DON_DE_NGHI_ND_NOP_DON = 2;
        public const int G_ATQC_DON_DE_NGHI_NV_1CUA_NHAN_DON = 3;
        public const int G_ATQC_DON_DE_NGHI_NV_1CUA_CHUYEN_DON = 4;
        public const int G_ATQC_DON_DE_NGHI_NV_NHAN_DON = 5;
        public const int G_ATQC_DON_DE_NGHI_NV_TRINH_DUYET = 6;
        public const int G_ATQC_DON_DE_NGHI_LD_NHAN_DON = 7;
        public const int G_ATQC_DON_DE_NGHI_LD_PHE_DUYET = 8;
        public const int G_ATQC_DON_DE_NGHI_HUY = 99;

        public const int G_ATQC_DON_QUANG_CAO = 0;
        public const int G_ATQC_DON_HOI_THAO = 1;
        public const int G_ATQC_SO_NGAY_TRA = 25;
        public const bool G_ATQC_DANG_KY_TREN_MANG = true;
        public const bool G_ATQC_DANG_KY_TRUC_TIEP = false;

        public const int G_ATHQ_DON_DE_NGHI_ND_SOAN_DON = 1;
        public const int G_ATHQ_DON_DE_NGHI_ND_NOP_DON = 2;
        public const int G_ATHQ_DON_DE_NGHI_NV_1CUA_NHAN_DON = 3;
        public const int G_ATHQ_DON_DE_NGHI_NV_1CUA_CHUYEN_DON = 4;
        public const int G_ATHQ_DON_DE_NGHI_NV_NHAN_DON = 5;
        public const int G_ATHQ_DON_DE_NGHI_NV_TRINH_DUYET = 6;
        public const int G_ATHQ_DON_DE_NGHI_LD_NHAN_DON = 7;
        public const int G_ATHQ_DON_DE_NGHI_LD_PHE_DUYET = 8;
        public const int G_ATHQ_DON_DE_NGHI_HUY = 99;

        public const int G_ATHQ_DON_CAP_MOI_HQ = 0;
        public const int G_ATHQ_DON_CAP_LAI_HQ = 1;
        public const int G_ATHQ_DON_CAP_MOI_PH = 2;
        public const int G_ATHQ_DON_CAP_LAI_PH = 3;
        public const int G_ATHQ_SO_NGAY_TRA = 25;
        public const bool G_ATHQ_DANG_KY_TREN_MANG = true;
        public const bool G_ATHQ_DANG_KY_TRUC_TIEP = false;

        public const int G_ATNOTIFY_WIDTH = 600;
        public const int G_ATNOTIFY_HEIGHT = 250;
        public const int G_ATNOTIFY_HIDEDELAY = 5000;

        #endregion
        #region CP
        public const int G_CP_DON_DE_NGHI_ND_SOAN_DON = 1;
        public const int G_CP_DON_DE_NGHI_ND_NOP_DON = 2;
        public const int G_CP_DON_DE_NGHI_NV_1CUA_NHAN_DON = 3;
        public const int G_CP_DON_DE_NGHI_NV_1CUA_CHUYEN_DON = 4;
        public const int G_CP_DON_DE_NGHI_NV_NHAN_DON = 5;
        public const int G_CP_DON_DE_NGHI_NV_TRINH_DUYET = 6;
        public const int G_CP_DON_DE_NGHI_LD_NHAN_DON = 7;
        public const int G_CP_DON_DE_NGHI_LD_PHE_DUYET = 8;
        public const int G_CP_DON_DE_NGHI_NV_TRA_1CUA = 9;
        public const int G_CP_DON_DE_NGHI_HUY = 99;

        public const int G_CP_PHAP_NHAN_CHUA_SU_DUNG = 1;
        public const int G_CP_PHAP_NHAN_DA_SU_DUNG = 2;
        public const int G_CP_PHAP_NHAN_BI_KHOA = 3;

        public const int G_CP_SO_NGAY_TRA = 25;

        public const bool G_CP_DANG_KY_TREN_MANG = true;
        public const bool G_CP_DANG_KY_TRUC_TIEP = false;

        public const int G_CP_DON_CAP_CHUNG_CHI = 1;
        public const int G_CP_DON_CAP_LAI_CHUNG_CHI = 2;
        public const int G_CP_DON_CAP_CO_SO = 3;
        public const int G_CP_DON_THAY_DOI_DIA_DIEM_CO_SO = 4;
        public const int G_CP_DON_THAY_DOI_TEN_CO_SO = 5;
        public const int G_CP_DON_CAP_LAI_CO_SO = 6;
        public const int G_CP_DON_DIEU_CHINH_CO_SO = 7;
        public const int G_CP_DON_CAP_CHUNG_CHI_DUOC = 8;
        public const int G_CP_DON_CAP_CO_SO_DUOC = 9;
        public const int G_CP_DON_CAP_LAI_CHUNG_CHI_DUOC = 10;//1b
        public const int G_CP_DON_NHAN_LAI_CHUNG_CHI_CO_SO_DUOC = 11;//2a
        public const int G_CP_DON_NHAN_LAI_CHUNG_CHI_DUOC = 12;//2b
        public const int G_CP_DON_SUA_DOI_CO_SO_DUOC = 13;//4b
        public const int G_CP_DON_GIA_HAN_CO_SO_DUOC = 14;//4c
        public const int G_CP_DON_CAP_LAI_CO_SO_DUOC = 15;//4d

        public const string Website = "http://soytequangninh.gov.vn";
        public const string Website_AT = "http://soytequangninh.gov.vn";
        #endregion
        #region DV
        public const int G_DV_DON_DE_NGHI_ND_SOAN_DON = 1;
        public const int G_DV_DON_DE_NGHI_ND_NOP_DON = 2;
        public const int G_DV_DON_DE_NGHI_NV_1CUA_NHAN_DON = 3;
        public const int G_DV_DON_DE_NGHI_NV_1CUA_CHUYEN_DON = 4;
        public const int G_DV_DON_DE_NGHI_NV_NHAN_DON = 5;
        public const int G_DV_DON_DE_NGHI_NV_TRINH_DUYET = 6;
        public const int G_DV_DON_DE_NGHI_LD_NHAN_DON = 7;
        public const int G_DV_DON_DE_NGHI_LD_PHE_DUYET = 8;
        public const int G_DV_DON_DE_NGHI_HUY = 99;

        public const int G_DV_PHAP_NHAN_CHUA_SU_DUNG = 1;
        public const int G_DV_PHAP_NHAN_DA_SU_DUNG = 2;
        public const int G_DV_PHAP_NHAN_BI_KHOA = 3;

        public const int G_DV_SO_NGAY_TRA = 25;

        public const bool G_DV_DANG_KY_TREN_MANG = true;
        public const bool G_DV_DANG_KY_TRUC_TIEP = false;

        public const int G_DV_DON_KHAI_BAO_Y_TE_HANG_HOA = 0;
        public const int G_DV_DON_KHAI_BAO_Y_TE_HANG_HAI = 1;



        #endregion
        #endregion

        #region Page_By_Filter
        public static DataTable Page_By_Filter(int Start, int Limit, string WhereString, string SortString, out int Count)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("Sp_Paging_Dynamic", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pPageStart = new SqlParameter("@PageStart", SqlDbType.Int, 4);
                    pPageStart.Value = Start;
                    myCommand.Parameters.Add(pPageStart);

                    SqlParameter pPageLimit = new SqlParameter("@PageLimit", SqlDbType.Int, 4);
                    pPageLimit.Value = Limit;
                    myCommand.Parameters.Add(pPageLimit);

                    SqlParameter pWhereString = new SqlParameter("@WhereString", SqlDbType.NVarChar);
                    pWhereString.Value = WhereString;
                    myCommand.Parameters.Add(pWhereString);

                    SqlParameter pSortString = new SqlParameter("@SortString", SqlDbType.NVarChar);
                    pSortString.Value = SortString;
                    myCommand.Parameters.Add(pSortString);

                    SqlParameter pTotalCount = new SqlParameter("@TotalCount", SqlDbType.Int);
                    pTotalCount.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pTotalCount);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "SP_Paging_Dynamic");
                    Count = (int)pTotalCount.Value;
                    return myDataSet.Tables["SP_Paging_Dynamic"];
                }
            }
        }
        public static DataTable Page_By_Filter_DAT(string Activity, int Start, int Limit, string WhereString, string SortString, out int Count)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand(Activity, myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pPageStart = new SqlParameter("@PageStart", SqlDbType.Int, 4);
                    pPageStart.Value = Start;
                    myCommand.Parameters.Add(pPageStart);

                    SqlParameter pPageLimit = new SqlParameter("@PageLimit", SqlDbType.Int, 4);
                    pPageLimit.Value = Limit;
                    myCommand.Parameters.Add(pPageLimit);

                    SqlParameter pWhereString = new SqlParameter("@WhereString", SqlDbType.NVarChar);
                    pWhereString.Value = WhereString;
                    myCommand.Parameters.Add(pWhereString);

                    SqlParameter pSortString = new SqlParameter("@SortString", SqlDbType.NVarChar);
                    pSortString.Value = SortString;
                    myCommand.Parameters.Add(pSortString);

                    SqlParameter pTotalCount = new SqlParameter("@TotalCount", SqlDbType.Int);
                    pTotalCount.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pTotalCount);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, Activity);
                    Count = (int)pTotalCount.Value;
                    return myDataSet.Tables[Activity];
                }
            }
        }
        #endregion
        public static DataTable Page_By_Filter_Image(int Start, int Limit, string ImgArr, out int Count)
        {
            DataTable dt = new DataTable();
            if (ImgArr != null && ImgArr != "")
            {
                dt.Columns.Add("Stt");
                dt.Columns.Add("TenAnh");
                dt.Columns.Add("url");
                string[] arr = ImgArr.Split(';');
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].Length > 0)
                    {
                        string[] img = arr[i].Split(':');
                        DataRow row = dt.NewRow();
                        row["Stt"] = img[0];
                        row["TenAnh"] = img[1];
                        row["url"] = "~/FileUpload/Images/" + img[1];
                        dt.Rows.Add(row);
                    }
                }
            }
            Count = dt.Rows.Count;
            return dt;
        }

        #region duyệt cây
        public static DataTable GetChild(int id, int? chucnang, int? vitri, string lang, out int Count)
        {
            DataTable dt = GetChildMenu(id, chucnang, vitri, lang);
            Count = 0;
            if (dt != null)
            {
                Count = dt.Rows.Count;
            }
            return dt;
        }

        public static DataTable GetChildMenu(int id, int? key, int? vitri, string lang)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("getChildMenu", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@id", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pChucnang = new SqlParameter("@key", SqlDbType.Int);
                    pChucnang.Value = key;
                    myCommand.Parameters.Add(pChucnang);

                    SqlParameter pVitri = new SqlParameter("@vitri", SqlDbType.Int);
                    pVitri.Value = vitri;
                    myCommand.Parameters.Add(pVitri);


                    SqlParameter pLang = new SqlParameter("@lang", SqlDbType.VarChar, 10);
                    pLang.Value = lang;
                    myCommand.Parameters.Add(pLang);

                    DataTable dt;
                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    return dt;
                }
            }
        }
        public static DataTable GetChildCoQuan(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("getChildCoQuan", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@id", SqlDbType.NVarChar, 30);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);
                    DataTable dt;
                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    return dt;
                }
            }
        }
        #endregion

        #region Function
        public static string CalBySQL(string sqlQuerry)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand(sqlQuerry, myConnection))
                {
                    try
                    {
                        myCommand.CommandType = CommandType.Text;
                        SqlDataAdapter myAdapter = new SqlDataAdapter();
                        DataSet myDataSet = new DataSet();

                        myConnection.Open();
                        myAdapter.SelectCommand = myCommand;
                        myAdapter.Fill(myDataSet, "sqlQuerry");
                        if (myDataSet.Tables["sqlQuerry"].Rows.Count > 0)
                        {
                            return myDataSet.Tables["sqlQuerry"].Rows[0][0].ToString();
                        }
                        else
                        {
                            return "";
                        }
                    }
                    catch (Exception ex)
                    {
                        return "";
                    }
                }
            }
        }
        public static void RunBySQL(string sqlQuerry)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand(sqlQuerry, myConnection))
                {
                    myCommand.CommandType = CommandType.Text;

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        public static DataTable RunTableBySQL(string sqlQuerry)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand(sqlQuerry, myConnection))
                {
                    try
                    {
                        myCommand.CommandType = CommandType.Text;
                        SqlDataAdapter myAdapter = new SqlDataAdapter();
                        DataSet myDataSet = new DataSet();

                        myConnection.Open();
                        myAdapter.SelectCommand = myCommand;
                        myAdapter.Fill(myDataSet, "sqlQuerry");
                        if (myDataSet.Tables["sqlQuerry"].Rows.Count > 0)
                        {
                            return myDataSet.Tables["sqlQuerry"];
                        }
                        else
                        {
                            return null;
                        }
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
            }
        }
        public static int RunCP(string LoanId, int ReportId, int UserId)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("sp_CPProcess", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pLoanId = new SqlParameter("@LoanId", SqlDbType.NVarChar, 25);
                    pLoanId.Value = LoanId;
                    myCommand.Parameters.Add(pLoanId);

                    SqlParameter pReportId = new SqlParameter("@ReportId", SqlDbType.Int);
                    pReportId.Value = ReportId;
                    myCommand.Parameters.Add(pReportId);

                    SqlParameter pUserId = new SqlParameter("@UserId", SqlDbType.Int);
                    pUserId.Value = UserId;
                    myCommand.Parameters.Add(pUserId);

                    SqlParameter pRet = new SqlParameter("@Ret", SqlDbType.Int);
                    pRet.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pRet);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    return (int)pRet.Value;
                }
            }
        }
        public static string[] SplitString(string strInput, string strSplit)
        {
            return strInput.Split(strSplit.ToCharArray());
        }
        public static string NumberToString(double number)
        {
            string s = number.ToString("#");
            string[] so = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] hang = new string[] { "", "nghìn", "triệu", "tỷ" };
            int i, j, donvi, chuc, tram;
            string str = " ";
            bool booAm = false;
            double decS = 0;
            //Tung addnew
            try
            {
                decS = Convert.ToDouble(s.ToString());
            }
            catch
            {
            }
            if (decS < 0)
            {
                decS = -decS;
                s = decS.ToString();
                booAm = true;
            }
            i = s.Length;
            if (i == 0)
                str = so[0] + str;
            else
            {
                j = 0;
                while (i > 0)
                {
                    donvi = Convert.ToInt32(s.Substring(i - 1, 1));
                    i--;
                    if (i > 0)
                        chuc = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        chuc = -1;
                    i--;
                    if (i > 0)
                        tram = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        tram = -1;
                    i--;
                    if ((donvi > 0) || (chuc > 0) || (tram > 0) || (j == 3))
                        str = hang[j] + str;
                    j++;
                    if (j > 3) j = 1;
                    if ((donvi == 1) && (chuc > 1))
                        str = "một " + str;
                    else
                    {
                        if ((donvi == 5) && (chuc > 0))
                            str = "lăm " + str;
                        else if (donvi > 0)
                            str = so[donvi] + " " + str;
                    }
                    if (chuc < 0)
                        break;
                    else
                    {
                        if ((chuc == 0) && (donvi > 0)) str = "lẻ " + str;
                        if (chuc == 1) str = "mười " + str;
                        if (chuc > 1) str = so[chuc] + " mươi " + str;
                    }
                    if (tram < 0) break;
                    else
                    {
                        if ((tram > 0) || (chuc > 0) || (donvi > 0)) str = so[tram] + " trăm " + str;
                    }
                    str = " " + str;
                }
            }
            str = str.Substring(0, 1).ToUpper() + str.Substring(1, str.Length - 1);
            if (booAm) str = "Âm " + str;
            return str;
        }
        public static string NumberToFormat(double number)
        {
            string str;
            str = number.ToString();

            return str;
        }
        public static DateTime DateVNToDate(string strDate)
        {
            try
            {
                string[] arrstr;
                arrstr = SplitString(strDate, "/");
                return DateTime.Parse(arrstr[1].ToString() + "/" + arrstr[0].ToString() + "/" + arrstr[2].ToString());
            }
            catch (Exception ex)
            {
                return DateTime.Now;
            }
        }
        public static string FormatNumber(string number)
        {
            if (number.Equals("0"))
            {
                return "0";
            }
            else
            {
                return String.Format("{0:0,0}", double.Parse(number.ToString()));
            }
        }
        public static DateTime GetFirstDayOfMonth(DateTime dtInput)
        {
            DateTime dtResult = dtInput;
            dtResult = dtResult.AddDays((-dtResult.Day) + 1);
            return dtResult;
        }
        public static DateTime GetFirstDayOfMonth(int iMonth)
        {
            DateTime dtResult = new DateTime(DateTime.Now.Year, iMonth, 1);
            dtResult = dtResult.AddDays((-dtResult.Day) + 1);
            return dtResult;
        }
        public static DateTime GetLastDayOfMonth(DateTime dtInput)
        {
            DateTime dtResult = dtInput;
            dtResult = dtResult.AddMonths(1);
            dtResult = dtResult.AddDays(-(dtResult.Day));
            return dtResult;
        }
        public static DateTime GetLastDayOfMonth(int iMonth)
        {
            DateTime dtResult = new DateTime(DateTime.Now.Year, iMonth, 1);
            dtResult = dtResult.AddMonths(1);
            dtResult = dtResult.AddDays(-(dtResult.Day));
            return dtResult;
        }
        #region Encrypt

        public static string Encrypt(string strText, string strEncrKey)
        {
            byte[] byKey = { };
            byte[] IV = { 0x11, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };

            try
            {
                byKey = System.Text.Encoding.UTF8.GetBytes(strEncrKey);

                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(strText);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            //Return ms.ToArray()
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        #endregion
        #region Decrypt

        public static string Decrypt(string strText, string sDecrKey)
        {
            byte[] byKey = { };
            //Co the thay doi phan IV() nay, tuong tu cho Encrypt.
            byte[] IV = { 0x11, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
            byte[] inputByteArray = new byte[strText.Length + 1];

            try
            {
                byKey = System.Text.Encoding.UTF8.GetBytes(sDecrKey);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(strText);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;

                return encoding.GetString(ms.ToArray());
            }

            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        #endregion
        #region List_By_SQL
        public static DataTable List_By_SQL(string query)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    myCommand.CommandType = CommandType.Text;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "List_By_SQL");
                    return myDataSet.Tables["List_By_SQL"];
                }
            }
        }
        #endregion
        public static string GetFileNameFromUrl(string Url)
        {
            if (Url == "")
            {
                return "";
            }
            return Path.GetFileName(Url);
        }
        public static DataTable LoadCombo(string table, string lang = "vi")
        {
            DataTable dt = new DataTable();
            DataRow row;
            string sql = "";
            if (table == "DiSan")
            {
                sql = "select DiSanID,'+ '+TenDiSan as TenDiSan from DiSanVanHoa where Lang='" + lang + "'";
                dt = getDataByQuery(sql);
                row = dt.NewRow();
                row["DiSanID"] = 0;
                row["TenDiSan"] = lang == "vi" ? "Chọn di sản văn hóa" : "Cultural heritage ";
                dt.Rows.InsertAt(row, 0);
            }
            else if (table == "HoatDong")
            {
                sql = "select HoatDongID,'+ '+TenGoi as TenGoi from HoatDongVanHoa where Lang='" + lang + "'";
                dt = getDataByQuery(sql);
                row = dt.NewRow();
                row["HoatDongID"] = 0;
                row["TenGoi"] = lang == "vi" ? "Chọn hoạt động văn hóa" : "Cultural activities";
                dt.Rows.InsertAt(row, 0);
            }
            else if (table == "CoQuan")
            {
                dt = GetChildCoQuan(0);
                row = dt.NewRow();
                row["CoQuanID"] = 0;
                row["TenCoQuan"] = "Chọn cơ quan";
                dt.Rows.InsertAt(row, 0);
            }
            return dt;
        }
        #endregion
        public static DataTable LoadComboDiaDiem(string addr, string typeload, string lang = "vi")
        {
            DataTable dt = new DataTable();
            DataRow row;
            if (typeload == "tinh")
            {
                dt = Sys_Common.HT_DM_TINH.Danh_Sach();
                row = dt.NewRow();
                row["Ma_Tinh"] = 0;
                row["Ten_Tinh"] = lang == "vi" ? "Chọn tỉnh" : "Province";
                dt.Rows.InsertAt(row, 0);
            }
            else if (typeload == "huyen")
            {
                dt = Sys_Common.HT_DM_HUYEN.Lay_Boi_HT_DM_Tinh(addr);
                row = dt.NewRow();
                row["Ma_Huyen"] = 0;
                row["Ten_Huyen"] = lang == "vi" ? "Chọn huyện" : "District";
                dt.Rows.InsertAt(row, 0);
            }
            else if (typeload == "xa")
            {
                //if (!string.IsNullOrEmpty(addr))
                {
                    dt = Sys_Common.HT_DM_XA.Lay_Boi_HT_DM_Huyen(addr);
                }
                row = dt.NewRow();
                row["Ma_Xa"] = 0;
                row["Ten_Xa"] = lang == "vi" ? "Chọn xã" : "Commune";
                dt.Rows.InsertAt(row, 0);
            }
            return dt;
        }

        #region logic
        #region HT
        private static HT_Nguoi_Dung_Dang_Nhap _HT_Nguoi_Dung_Dang_Nhap = null;
        public static HT_Nguoi_Dung_Dang_Nhap HT_NGUOI_DUNG_DANG_NHAP
        {
            get
            {
                if (_HT_Nguoi_Dung_Dang_Nhap == null)
                    _HT_Nguoi_Dung_Dang_Nhap = new HT_Nguoi_Dung_Dang_Nhap(ConnectionString);
                return _HT_Nguoi_Dung_Dang_Nhap;
            }
            set
            {
                _HT_Nguoi_Dung_Dang_Nhap = value;
            }
        }

        private static HT_Chuc_Nang _HT_Chuc_Nang = null;
        public static HT_Chuc_Nang HT_CHUC_NANG
        {
            get
            {
                if (_HT_Chuc_Nang == null)
                    _HT_Chuc_Nang = new HT_Chuc_Nang(ConnectionString);
                return _HT_Chuc_Nang;
            }
            set
            {
                _HT_Chuc_Nang = value;
            }
        }


        private static HT_Dan_Toc _HT_Dan_Toc = null;
        public static HT_Dan_Toc HT_DAN_TOC
        {
            get
            {
                if (_HT_Dan_Toc == null)
                    _HT_Dan_Toc = new HT_Dan_Toc(ConnectionString);
                return _HT_Dan_Toc;
            }
            set
            {
                _HT_Dan_Toc = value;
            }
        }


        private static HT_DM_Huyen _HT_DM_Huyen = null;
        public static HT_DM_Huyen HT_DM_HUYEN
        {
            get
            {
                if (_HT_DM_Huyen == null)
                    _HT_DM_Huyen = new HT_DM_Huyen(ConnectionString);
                return _HT_DM_Huyen;
            }
            set
            {
                _HT_DM_Huyen = value;
            }
        }


        private static HT_DM_Tinh _HT_DM_Tinh = null;
        public static HT_DM_Tinh HT_DM_TINH
        {
            get
            {
                if (_HT_DM_Tinh == null)
                    _HT_DM_Tinh = new HT_DM_Tinh(ConnectionString);
                return _HT_DM_Tinh;
            }
            set
            {
                _HT_DM_Tinh = value;
            }
        }


        private static HT_DM_Tuan _HT_DM_Tuan = null;
        public static HT_DM_Tuan HT_DM_TUAN
        {
            get
            {
                if (_HT_DM_Tuan == null)
                    _HT_DM_Tuan = new HT_DM_Tuan(ConnectionString);
                return _HT_DM_Tuan;
            }
            set
            {
                _HT_DM_Tuan = value;
            }
        }


        private static HT_DM_Xa _HT_DM_Xa = null;
        public static HT_DM_Xa HT_DM_XA
        {
            get
            {
                if (_HT_DM_Xa == null)
                    _HT_DM_Xa = new HT_DM_Xa(ConnectionString);
                return _HT_DM_Xa;
            }
            set
            {
                _HT_DM_Xa = value;
            }
        }


        private static HT_Don_Vi_YT _HT_Don_Vi_YT = null;
        public static HT_Don_Vi_YT HT_DON_VI_YT
        {
            get
            {
                if (_HT_Don_Vi_YT == null)
                    _HT_Don_Vi_YT = new HT_Don_Vi_YT(ConnectionString);
                return _HT_Don_Vi_YT;
            }
            set
            {
                _HT_Don_Vi_YT = value;
            }
        }


        private static HT_Du_An _HT_Du_An = null;
        public static HT_Du_An HT_DU_AN
        {
            get
            {
                if (_HT_Du_An == null)
                    _HT_Du_An = new HT_Du_An(ConnectionString);
                return _HT_Du_An;
            }
            set
            {
                _HT_Du_An = value;
            }
        }


        private static HT_Ma_Nuoc _HT_Ma_Nuoc = null;
        public static HT_Ma_Nuoc HT_MA_NUOC
        {
            get
            {
                if (_HT_Ma_Nuoc == null)
                    _HT_Ma_Nuoc = new HT_Ma_Nuoc(ConnectionString);
                return _HT_Ma_Nuoc;
            }
            set
            {
                _HT_Ma_Nuoc = value;
            }
        }


        private static HT_Nguoi_Dung _HT_Nguoi_Dung = null;
        public static HT_Nguoi_Dung HT_NGUOI_DUNG
        {
            get
            {
                if (_HT_Nguoi_Dung == null)
                    _HT_Nguoi_Dung = new HT_Nguoi_Dung(ConnectionString);
                return _HT_Nguoi_Dung;
            }
            set
            {
                _HT_Nguoi_Dung = value;
            }
        }


        private static HT_Nguoi_Dung_Vai_Tro _HT_Nguoi_Dung_Vai_Tro = null;
        public static HT_Nguoi_Dung_Vai_Tro HT_NGUOI_DUNG_VAI_TRO
        {
            get
            {
                if (_HT_Nguoi_Dung_Vai_Tro == null)
                    _HT_Nguoi_Dung_Vai_Tro = new HT_Nguoi_Dung_Vai_Tro(ConnectionString);
                return _HT_Nguoi_Dung_Vai_Tro;
            }
            set
            {
                _HT_Nguoi_Dung_Vai_Tro = value;
            }
        }


        private static HT_Nhom_Chuc_Nang _HT_Nhom_Chuc_Nang = null;
        public static HT_Nhom_Chuc_Nang HT_NHOM_CHUC_NANG
        {
            get
            {
                if (_HT_Nhom_Chuc_Nang == null)
                    _HT_Nhom_Chuc_Nang = new HT_Nhom_Chuc_Nang(ConnectionString);
                return _HT_Nhom_Chuc_Nang;
            }
            set
            {
                _HT_Nhom_Chuc_Nang = value;
            }
        }

        private static Role Role = null;


        private static HT_Vai_Tro _HT_Vai_Tro = null;
        public static HT_Vai_Tro HT_VAI_TRO
        {
            get
            {
                if (_HT_Vai_Tro == null)
                    _HT_Vai_Tro = new HT_Vai_Tro(ConnectionString);
                return _HT_Vai_Tro;
            }
            set
            {
                _HT_Vai_Tro = value;
            }
        }


        private static HT_Vai_Tro_Chuc_Nang _HT_Vai_Tro_Chuc_Nang = null;
        public static HT_Vai_Tro_Chuc_Nang HT_VAI_TRO_CHUC_NANG
        {
            get
            {
                if (_HT_Vai_Tro_Chuc_Nang == null)
                    _HT_Vai_Tro_Chuc_Nang = new HT_Vai_Tro_Chuc_Nang(ConnectionString);
                return _HT_Vai_Tro_Chuc_Nang;
            }
            set
            {
                _HT_Vai_Tro_Chuc_Nang = value;
            }
        }


        private static HT_Vai_Tro_Du_An _HT_Vai_Tro_Du_An = null;
        public static HT_Vai_Tro_Du_An HT_VAI_TRO_DU_AN
        {
            get
            {
                if (_HT_Vai_Tro_Du_An == null)
                    _HT_Vai_Tro_Du_An = new HT_Vai_Tro_Du_An(ConnectionString);
                return _HT_Vai_Tro_Du_An;
            }
            set
            {
                _HT_Vai_Tro_Du_An = value;
            }
        }
        #endregion

        #region NV
        private static NV_LoaiBaoTang _NV_LoaiBaoTang = null;
        public static NV_LoaiBaoTang NV_LoaiBaoTang
        {
            get
            {
                if (_NV_LoaiBaoTang == null)
                    _NV_LoaiBaoTang = new NV_LoaiBaoTang(ConnectionString);
                return _NV_LoaiBaoTang;
            }
            set
            {
                _NV_LoaiBaoTang = value;
            }
        }
        private static NV_DM_ChucVu _NV_DM_ChucVu = null;
        public static NV_DM_ChucVu NV_DM_ChucVu
        {
            get
            {
                if (_NV_DM_ChucVu == null)
                    _NV_DM_ChucVu = new NV_DM_ChucVu(ConnectionString);
                return _NV_DM_ChucVu;
            }
            set
            {
                _NV_DM_ChucVu = value;
            }
        }
        private static NV_Log _NV_Log = null;
        public static NV_Log NV_Log
        {
            get
            {
                if (_NV_Log == null)
                    _NV_Log = new NV_Log(ConnectionString);
                return _NV_Log;
            }
            set
            {
                _NV_Log = value;
            }
        }

        private static NV_DonViKinhDoanh _NV_DonViKinhDoanh = null;
        public static NV_DonViKinhDoanh NV_DonViKinhDoanh
        {
            get
            {
                if (_NV_DonViKinhDoanh == null)
                    _NV_DonViKinhDoanh = new NV_DonViKinhDoanh(ConnectionString);
                return _NV_DonViKinhDoanh;
            }
            set
            {
                _NV_DonViKinhDoanh = value;
            }
        }
        private static NV_KiemKeSoLuong _NV_KiemKeSoLuong = null;
        public static NV_KiemKeSoLuong NV_KiemKeSoLuong
        {
            get
            {
                if (_NV_KiemKeSoLuong == null)
                    _NV_KiemKeSoLuong = new NV_KiemKeSoLuong(ConnectionString);
                return _NV_KiemKeSoLuong;
            }
            set
            {
                _NV_KiemKeSoLuong = value;
            }
        }
        private static NV_DM_LinhVucKinhDoanh _NV_DM_LinhVucKinhDoanh = null;
        public static NV_DM_LinhVucKinhDoanh NV_DM_LinhVucKinhDoanh
        {
            get
            {
                if (_NV_DM_LinhVucKinhDoanh == null)
                    _NV_DM_LinhVucKinhDoanh = new NV_DM_LinhVucKinhDoanh(ConnectionString);
                return _NV_DM_LinhVucKinhDoanh;
            }
            set
            {
                _NV_DM_LinhVucKinhDoanh = value;
            }
        }


        private static NV_DM_DiSan _NV_DM_DiSan = null;
        public static NV_DM_DiSan NV_DM_DiSan
        {
            get
            {
                if (_NV_DM_DiSan == null)
                    _NV_DM_DiSan = new NV_DM_DiSan(ConnectionString);
                return _NV_DM_DiSan;
            }
            set
            {
                _NV_DM_DiSan = value;
            }
        }


        private static NV_ChucNang _NV_ChucNang = null;
        public static NV_ChucNang NV_ChucNang
        {
            get
            {
                if (_NV_ChucNang == null)
                    _NV_ChucNang = new NV_ChucNang(ConnectionString);
                return _NV_ChucNang;
            }
            set
            {
                _NV_ChucNang = value;
            }
        }

        private static NV_DanhMucAnPham _NV_DanhMucAnPham = null;
        public static NV_DanhMucAnPham NV_DanhMucAnPham
        {
            get
            {
                if (_NV_DanhMucAnPham == null)
                    _NV_DanhMucAnPham = new NV_DanhMucAnPham(ConnectionString);
                return _NV_DanhMucAnPham;
            }
            set
            {
                _NV_DanhMucAnPham = value;
            }
        }
        private static NV_TrangThaiXuLy _NV_TrangThaiXuLy = null;
        public static NV_TrangThaiXuLy NV_TrangThaiXuLy
        {
            get
            {
                if (_NV_TrangThaiXuLy == null)
                    _NV_TrangThaiXuLy = new NV_TrangThaiXuLy(ConnectionString);
                return _NV_TrangThaiXuLy;
            }
            set
            {
                _NV_TrangThaiXuLy = value;
            }
        }

        private static NV_Vitri _NV_Vitri = null;
        public static NV_Vitri NV_Vitri
        {
            get
            {
                if (_NV_Vitri == null)
                    _NV_Vitri = new NV_Vitri(ConnectionString);
                return _NV_Vitri;
            }
            set
            {
                _NV_Vitri = value;
            }
        }


        private static NV_MediaLib _NV_MediaLib = null;
        public static NV_MediaLib NV_MediaLib
        {
            get
            {
                if (_NV_MediaLib == null)
                    _NV_MediaLib = new NV_MediaLib(ConnectionString);
                return _NV_MediaLib;
            }
            set
            {
                _NV_MediaLib = value;
            }
        }

        private static NV_Video _NV_Video = null;
        public static NV_Video NV_Video
        {
            get
            {
                if (_NV_Video == null)
                    _NV_Video = new NV_Video(ConnectionString);
                return _NV_Video;
            }
            set
            {
                _NV_Video = value;
            }
        }

        private static NV_Quangcao _NV_Quangcao = null;
        public static NV_Quangcao NV_Quangcao
        {
            get
            {
                if (_NV_Quangcao == null)
                    _NV_Quangcao = new NV_Quangcao(ConnectionString);
                return _NV_Quangcao;
            }
            set
            {
                _NV_Quangcao = value;
            }
        }
        private static NV_HoiDongThamDinh _NV_HoiDongThamDinh = null;
        public static NV_HoiDongThamDinh NV_HoiDongThamDinh
        {
            get
            {
                if (_NV_HoiDongThamDinh == null)
                    _NV_HoiDongThamDinh = new NV_HoiDongThamDinh(ConnectionString);
                return _NV_HoiDongThamDinh;
            }
            set
            {
                _NV_HoiDongThamDinh = value;
            }
        }

        private static NV_Document _NV_Document = null;
        public static NV_Document NV_Document
        {
            get
            {
                if (_NV_Document == null)
                    _NV_Document = new NV_Document(ConnectionString);
                return _NV_Document;
            }
            set
            {
                _NV_Document = value;
            }
        }
        private static NV_ChucNangTuBo _NV_ChucNangTuBo = null;
        public static NV_ChucNangTuBo NV_ChucNangTuBo
        {
            get
            {
                if (_NV_ChucNangTuBo == null)
                    _NV_ChucNangTuBo = new NV_ChucNangTuBo(ConnectionString);
                return _NV_ChucNangTuBo;
            }
            set
            {
                _NV_ChucNangTuBo = value;
            }
        }

        private static NV_DanhHieuNgheNhan _NV_DanhHieuNgheNhan = null;
        public static NV_DanhHieuNgheNhan NV_DanhHieuNgheNhan
        {
            get
            {
                if (_NV_DanhHieuNgheNhan == null)
                    _NV_DanhHieuNgheNhan = new NV_DanhHieuNgheNhan(ConnectionString);
                return _NV_DanhHieuNgheNhan;
            }
            set
            {
                _NV_DanhHieuNgheNhan = value;
            }
        }
        private static NV_Image _NV_Image = null;
        public static NV_Image NV_Image
        {
            get
            {
                if (_NV_Image == null)
                    _NV_Image = new NV_Image(ConnectionString);
                return _NV_Image;
            }
            set
            {
                _NV_Image = value;
            }
        }
        private static NV_DiVatCoVat _NV_DiVatCoVat = null;
        public static NV_DiVatCoVat NV_DiVatCoVat
        {
            get
            {
                if (_NV_DiVatCoVat == null)
                    _NV_DiVatCoVat = new NV_DiVatCoVat(ConnectionString);
                return _NV_DiVatCoVat;
            }
            set
            {
                _NV_DiVatCoVat = value;
            }
        }
        private static NV_DanhMuc _NV_DanhMuc = null;
        public static NV_DanhMuc NV_DanhMuc
        {
            get
            {
                if (_NV_DanhMuc == null)
                    _NV_DanhMuc = new NV_DanhMuc(ConnectionString);
                return _NV_DanhMuc;
            }
            set
            {
                _NV_DanhMuc = value;
            }
        }
        private static NV_NoiLuuTru _NV_NoiLuuTru = null;
        public static NV_NoiLuuTru NV_NoiLuuTru
        {
            get
            {
                if (_NV_NoiLuuTru == null)
                    _NV_NoiLuuTru = new NV_NoiLuuTru(ConnectionString);
                return _NV_NoiLuuTru;
            }
            set
            {
                _NV_NoiLuuTru = value;
            }
        }
        private static NV_ThoiKy _NV_ThoiKy = null;
        public static NV_ThoiKy NV_ThoiKy
        {
            get
            {
                if (_NV_ThoiKy == null)
                    _NV_ThoiKy = new NV_ThoiKy(ConnectionString);
                return _NV_ThoiKy;
            }
            set
            {
                _NV_ThoiKy = value;
            }
        }


        private static NV_Map _NV_Map = null;
        public static NV_Map NV_Map
        {
            get
            {
                if (_NV_Map == null)
                    _NV_Map = new NV_Map(ConnectionString);
                return _NV_Map;
            }
            set
            {
                _NV_Map = value;
            }
        }
        private static NV_NgheNhan _NV_NgheNhan = null;
        public static NV_NgheNhan NV_NgheNhan
        {
            get
            {
                if (_NV_NgheNhan == null)
                    _NV_NgheNhan = new NV_NgheNhan(ConnectionString);
                return _NV_NgheNhan;
            }
            set
            {
                _NV_NgheNhan = value;
            }
        }
        private static NV_NhaDauTu _NV_NhaDauTu = null;
        public static NV_NhaDauTu NV_NhaDauTu
        {
            get
            {
                if (_NV_NhaDauTu == null)
                    _NV_NhaDauTu = new NV_NhaDauTu(ConnectionString);
                return _NV_NhaDauTu;
            }
            set
            {
                _NV_NhaDauTu = value;
            }
        }
        private static NV_DM_CapDiSan _NV_DM_CapDiSan = null;
        public static NV_DM_CapDiSan NV_DM_CapDiSan
        {
            get
            {
                if (_NV_DM_CapDiSan == null)
                    _NV_DM_CapDiSan = new NV_DM_CapDiSan(ConnectionString);
                return _NV_DM_CapDiSan;
            }
            set
            {
                _NV_DM_CapDiSan = value;
            }
        }


        private static NV_DangKyDiSan _NV_DangKyDiSan = null;
        public static NV_DangKyDiSan NV_DangKyDiSan
        {
            get
            {
                if (_NV_DangKyDiSan == null)
                    _NV_DangKyDiSan = new NV_DangKyDiSan(ConnectionString);
                return _NV_DangKyDiSan;
            }
            set
            {
                _NV_DangKyDiSan = value;
            }
        }
        //private static NV_DM_LoaiVanBan _NV_DM_LoaiVanBan = null;
        //public static NV_DM_LoaiVanBan NV_DM_LoaiVanBan
        //{
        //    get
        //    {
        //        if (_NV_DM_LoaiVanBan == null)
        //            _NV_DM_LoaiVanBan = new NV_DM_LoaiVanBan(ConnectionString);
        //        return _NV_DM_LoaiVanBan;
        //    }
        //    set
        //    {
        //        _NV_DM_LoaiVanBan = value;
        //    }
        //}

        private static NV_VanBan _NV_VanBan = null;
        public static NV_VanBan NV_VanBan
        {
            get
            {
                if (_NV_VanBan == null)
                    _NV_VanBan = new NV_VanBan(ConnectionString);
                return _NV_VanBan;
            }
            set
            {
                _NV_VanBan = value;
            }
        }
        private static NV_LoaiQuyTrinh _NV_LoaiQuyTrinh = null;
        public static NV_LoaiQuyTrinh NV_LoaiQuyTrinh
        {
            get
            {
                if (_NV_LoaiQuyTrinh == null)
                    _NV_LoaiQuyTrinh = new NV_LoaiQuyTrinh(ConnectionString);
                return _NV_LoaiQuyTrinh;
            }
            set
            {
                _NV_LoaiQuyTrinh = value;
            }
        }

        private static NV_QuyTrinhDinhNghia _NV_QuyTrinhDinhNghia = null;
        public static NV_QuyTrinhDinhNghia NV_QuyTrinhDinhNghia
        {
            get
            {
                if (_NV_QuyTrinhDinhNghia == null)
                    _NV_QuyTrinhDinhNghia = new NV_QuyTrinhDinhNghia(ConnectionString);
                return _NV_QuyTrinhDinhNghia;
            }
            set
            {
                _NV_QuyTrinhDinhNghia = value;
            }
        }
        private static NV_QuyTrinhXuLy _NV_QuyTrinhXuLy = null;
        public static NV_QuyTrinhXuLy NV_QuyTrinhXuLy
        {
            get
            {
                if (_NV_QuyTrinhXuLy == null)
                    _NV_QuyTrinhXuLy = new NV_QuyTrinhXuLy(ConnectionString);
                return _NV_QuyTrinhXuLy;
            }
            set
            {
                _NV_QuyTrinhXuLy = value;
            }
        }
        private static NV_LuongDinhNghia _NV_LuongDinhNghia = null;
        public static NV_LuongDinhNghia NV_LuongDinhNghia
        {
            get
            {
                if (_NV_LuongDinhNghia == null)
                    _NV_LuongDinhNghia = new NV_LuongDinhNghia(ConnectionString);
                return _NV_LuongDinhNghia;
            }
            set
            {
                _NV_LuongDinhNghia = value;
            }
        }

        private static NV_LuongXuLy _NV_LuongXuLy = null;
        public static NV_LuongXuLy NV_LuongXuLy
        {
            get
            {
                if (_NV_LuongXuLy == null)
                    _NV_LuongXuLy = new NV_LuongXuLy(ConnectionString);
                return _NV_LuongXuLy;
            }
            set
            {
                _NV_LuongXuLy = value;
            }
        }


        private static NV_Menu _NV_Menu = null;
        public static NV_Menu NV_Menu
        {
            get
            {
                if (_NV_Menu == null)
                    _NV_Menu = new NV_Menu(ConnectionString);
                return _NV_Menu;
            }
            set
            {
                _NV_Menu = value;
            }
        }

        private static NV_BaiViet_AnPham _NV_BaiViet_AnPham;
        public static NV_BaiViet_AnPham NV_BaiViet_AnPham
        {
            get
            {
                if (_NV_BaiViet_AnPham == null)
                    _NV_BaiViet_AnPham = new NV_BaiViet_AnPham(ConnectionString);
                return _NV_BaiViet_AnPham;
            }
            set
            {
                _NV_BaiViet_AnPham = value;
            }
        }

        private static NV_AnPham _NV_AnPham;
        public static NV_AnPham NV_AnPham
        {
            get
            {
                if (_NV_AnPham == null)
                    _NV_AnPham = new NV_AnPham(ConnectionString);
                return _NV_AnPham;
            }
            set
            {
                _NV_AnPham = value;
            }
        }

        private static NV_PhanBoKinhPhi _NV_PhanBoKinhPhi;
        public static NV_PhanBoKinhPhi NV_PhanBoKinhPhi
        {
            get
            {
                if (_NV_PhanBoKinhPhi == null)
                    _NV_PhanBoKinhPhi = new NV_PhanBoKinhPhi(ConnectionString);
                return _NV_PhanBoKinhPhi;
            }
            set
            {
                _NV_PhanBoKinhPhi = value;
            }
        }
        private static NV_NguonKinhPhi _NV_NguonKinhPhi;
        public static NV_NguonKinhPhi NV_NguonKinhPhi
        {
            get
            {
                if (_NV_NguonKinhPhi == null)
                    _NV_NguonKinhPhi = new NV_NguonKinhPhi(ConnectionString);
                return _NV_NguonKinhPhi;
            }
            set
            {
                _NV_NguonKinhPhi = value;
            }
        }
        private static NV_LoaiNguonKinhPhi _NV_LoaiNguonKinhPhi;
        public static NV_LoaiNguonKinhPhi NV_LoaiNguonKinhPhi
        {
            get
            {
                if (_NV_LoaiNguonKinhPhi == null)
                    _NV_LoaiNguonKinhPhi = new NV_LoaiNguonKinhPhi(ConnectionString);
                return _NV_LoaiNguonKinhPhi;
            }
            set
            {
                _NV_LoaiNguonKinhPhi = value;
            }
        }

        private static NV_DanhMucDuong _NV_DanhMucDuong;
        public static NV_DanhMucDuong NV_DanhMucDuong
        {
            get
            {
                if (_NV_DanhMucDuong == null)
                    _NV_DanhMucDuong = new NV_DanhMucDuong(ConnectionString);
                return _NV_DanhMucDuong;
            }
            set
            {
                _NV_DanhMucDuong = value;
            }
        }
        private static NV_LoaiVanBan _NV_LoaiVanBan = null;
        public static NV_LoaiVanBan NV_LoaiVanBan
        {
            get
            {
                if (_NV_LoaiVanBan == null)
                    _NV_LoaiVanBan = new NV_LoaiVanBan(ConnectionString);
                return _NV_LoaiVanBan;
            }
            set
            {
                _NV_LoaiVanBan = value;
            }
        }


        private static NV_DiSanVanHoa _NV_DiSanVanHoa = null;
        public static NV_DiSanVanHoa NV_DiSanVanHoa
        {
            get
            {
                if (_NV_DiSanVanHoa == null)
                    _NV_DiSanVanHoa = new NV_DiSanVanHoa(ConnectionString);
                return _NV_DiSanVanHoa;
            }
            set
            {
                _NV_DiSanVanHoa = value;
            }
        }

        private static NV_DM_LoaiDiSan _NV_DM_LoaiDiSan = null;
        public static NV_DM_LoaiDiSan NV_DM_LoaiDiSan
        {
            get
            {
                if (_NV_DM_LoaiDiSan == null)
                    _NV_DM_LoaiDiSan = new NV_DM_LoaiDiSan(ConnectionString);
                return _NV_DM_LoaiDiSan;
            }
            set
            {
                _NV_DM_LoaiDiSan = value;
            }
        }

        private static NV_CoQuanHanhChinh _NV_CoQuanHanhChinh = null;
        public static NV_CoQuanHanhChinh NV_CoQuanHanhChinh
        {
            get
            {
                if (_NV_CoQuanHanhChinh == null)
                    _NV_CoQuanHanhChinh = new NV_CoQuanHanhChinh(ConnectionString);
                return _NV_CoQuanHanhChinh;
            }
            set
            {
                NV_CoQuanHanhChinh = value;
            }
        }

        private static NV_CanBo _NV_CanBo = null;
        public static NV_CanBo NV_CanBo
        {
            get
            {
                if (_NV_CanBo == null)
                    _NV_CanBo = new NV_CanBo(ConnectionString);
                return _NV_CanBo;
            }
            set
            {
                _NV_CanBo = value;
            }
        }

        private static NV_DanhNhan _NV_DanhNhan = null;
        public static NV_DanhNhan NV_DanhNhan
        {
            get
            {
                if (_NV_DanhNhan == null)
                    _NV_DanhNhan = new NV_DanhNhan(ConnectionString);
                return _NV_DanhNhan;
            }
            set
            {
                _NV_DanhNhan = value;
            }
        }

        private static NV_DonViTuBo _NV_DonViTuBo = null;
        public static NV_DonViTuBo NV_DonViTuBo
        {
            get
            {
                if (_NV_DonViTuBo == null)
                    _NV_DonViTuBo = new NV_DonViTuBo(ConnectionString);
                return _NV_DonViTuBo;
            }
            set
            {
                _NV_DonViTuBo = value;
            }
        }

        private static NV_KeHoachTuBo _NV_KeHoachTuBo = null;
        public static NV_KeHoachTuBo NV_KeHoachTuBo
        {
            get
            {
                if (_NV_KeHoachTuBo == null)
                    _NV_KeHoachTuBo = new NV_KeHoachTuBo(ConnectionString);
                return _NV_KeHoachTuBo;
            }
            set
            {
                _NV_KeHoachTuBo = value;
            }
        }

        private static NV_HoatDongVanHoa _NV_HoatDongVanHoa = null;
        public static NV_HoatDongVanHoa NV_HoatDongVanHoa
        {
            get
            {
                if (_NV_HoatDongVanHoa == null)
                    _NV_HoatDongVanHoa = new NV_HoatDongVanHoa(ConnectionString);
                return _NV_HoatDongVanHoa;
            }
            set
            {
                _NV_HoatDongVanHoa = value;
            }
        }

        #endregion

        #region baocao
        private static BAOCAO _BAOCAO = null;
        public static BAOCAO BAOCAO
        {
            get
            {
                if (_BAOCAO == null)
                    _BAOCAO = new BAOCAO(ConnectionString);
                return _BAOCAO;
            }
            set
            {
                _BAOCAO = value;
            }
        }
        #endregion
        #endregion

        #region Function
        public static DataTable getDataByQuery(string strSQL)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            DataTable dtb = null;
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(strSQL, conn))
                    {
                        dtb = new DataTable();
                        mData.Fill(dtb);
                    }
                }
            }
            catch
            {
                dtb = null;
            }
            finally
            {
                conn.Close();
            }
            return dtb;
        }
        public static DataTable getDataByProc(string proc, string[] param)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(proc, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < param.Count(); i++)
            {
                string str = "@param" + i.ToString();
                cmd.Parameters.Add(str, param[i]);
            }
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(cmd))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                }
            }
            catch
            {
                dt = null;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        public static int executeSQL(SqlCommand cmd)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            cmd.Connection = conn;
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                return 0;
            }
            catch
            {
                return 1;
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }

        #endregion
    }
}
