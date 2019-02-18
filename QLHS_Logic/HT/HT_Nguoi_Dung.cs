
using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region HT_Nguoi_Dung_Details
    public class HT_Nguoi_Dung_Chi_Tiet
    {
        public int Ma_Nguoi_Dung;
        public int Ma_Don_Vi;
        public string Ten_Dang_Nhap;
        public string Mat_Khau;
        public string Ho_Ten;
        public string Hom_Thu;
        public string Dien_Thoai;
        public bool Duoc_Kich_Hoat;
        public int Hinh_Nen;
        public int CanBoID { get; set; }
    }
    #endregion
    #region HT_Nguoi_Dung
    public class HT_Nguoi_Dung
    {
        private string ConnectionString;
        public HT_Nguoi_Dung(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public HT_Nguoi_Dung_Chi_Tiet Lay(int Ma_Nguoi_Dung)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung.Value = Ma_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pTen_Dang_Nhap = new SqlParameter("@Ten_Dang_Nhap", SqlDbType.NVarChar, 50);
                    pTen_Dang_Nhap.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pTen_Dang_Nhap);

                    SqlParameter pMat_Khau = new SqlParameter("@Mat_Khau", SqlDbType.NVarChar, 150);
                    pMat_Khau.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pMat_Khau);

                    SqlParameter pHo_Ten = new SqlParameter("@Ho_Ten", SqlDbType.NVarChar, 150);
                    pHo_Ten.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pHo_Ten);

                    SqlParameter pHom_Thu = new SqlParameter("@Hom_Thu", SqlDbType.NVarChar, 50);
                    pHom_Thu.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pHom_Thu);

                    SqlParameter pDien_Thoai = new SqlParameter("@Dien_Thoai", SqlDbType.NVarChar, 20);
                    pDien_Thoai.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pDien_Thoai);

                    SqlParameter pDuoc_Kich_Hoat = new SqlParameter("@Duoc_Kich_Hoat", SqlDbType.Bit, 1);
                    pDuoc_Kich_Hoat.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pDuoc_Kich_Hoat);

                    SqlParameter pHinh_Nen = new SqlParameter("@Hinh_Nen", SqlDbType.Int, 4);
                    pHinh_Nen.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pHinh_Nen);

                    SqlParameter pCanBoID = new SqlParameter("@CanBoID", SqlDbType.Int, 4);
                    pCanBoID.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pCanBoID);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();


                    HT_Nguoi_Dung_Chi_Tiet myHT_Nguoi_Dung_Chi_Tiet = new HT_Nguoi_Dung_Chi_Tiet();
                    myHT_Nguoi_Dung_Chi_Tiet.Ma_Nguoi_Dung = Ma_Nguoi_Dung;
                    myHT_Nguoi_Dung_Chi_Tiet.Ma_Don_Vi = (int)pMa_Don_Vi.Value;
                    myHT_Nguoi_Dung_Chi_Tiet.Ten_Dang_Nhap = (string)pTen_Dang_Nhap.Value;
                    myHT_Nguoi_Dung_Chi_Tiet.Mat_Khau = (string)pMat_Khau.Value;
                    myHT_Nguoi_Dung_Chi_Tiet.Ho_Ten = (string)pHo_Ten.Value;
                    myHT_Nguoi_Dung_Chi_Tiet.Hom_Thu = pHom_Thu.Value == DBNull.Value ? null : (string)pHom_Thu.Value;
                    myHT_Nguoi_Dung_Chi_Tiet.Dien_Thoai = (string)pDien_Thoai.Value;
                    myHT_Nguoi_Dung_Chi_Tiet.Duoc_Kich_Hoat = (bool)pDuoc_Kich_Hoat.Value;
                    myHT_Nguoi_Dung_Chi_Tiet.Hinh_Nen = (int)pHinh_Nen.Value;
                    myHT_Nguoi_Dung_Chi_Tiet.CanBoID = (int)pCanBoID.Value;

                    return myHT_Nguoi_Dung_Chi_Tiet;
                }
            }
        }
        #endregion

        #region Them
        public int Them(int Ma_Nguoi_Dung = 0, int Ma_Don_Vi = 0, string Ten_Dang_Nhap = null, string Mat_Khau = null, string Ho_Ten = null, string Hom_Thu = null, string Dien_Thoai = null, bool Duoc_Kich_Hoat = false, int Hinh_Nen = 0, int CanBoID = 0)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung.Value = Ma_Nguoi_Dung;
                    pMa_Nguoi_Dung.Direction = ParameterDirection.InputOutput;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pTen_Dang_Nhap = new SqlParameter("@Ten_Dang_Nhap", SqlDbType.NVarChar, 50);
                    pTen_Dang_Nhap.Value = Ten_Dang_Nhap;
                    myCommand.Parameters.Add(pTen_Dang_Nhap);

                    SqlParameter pMat_Khau = new SqlParameter("@Mat_Khau", SqlDbType.NVarChar, 150);
                    pMat_Khau.Value = Mat_Khau;
                    myCommand.Parameters.Add(pMat_Khau);

                    SqlParameter pHo_Ten = new SqlParameter("@Ho_Ten", SqlDbType.NVarChar, 150);
                    pHo_Ten.Value = Ho_Ten;
                    myCommand.Parameters.Add(pHo_Ten);

                    SqlParameter pHom_Thu = new SqlParameter("@Hom_Thu", SqlDbType.NVarChar, 50);
                    pHom_Thu.Value = Hom_Thu;
                    myCommand.Parameters.Add(pHom_Thu);

                    SqlParameter pDien_Thoai = new SqlParameter("@Dien_Thoai", SqlDbType.NVarChar, 20);
                    pDien_Thoai.Value = Dien_Thoai;
                    myCommand.Parameters.Add(pDien_Thoai);

                    SqlParameter pDuoc_Kich_Hoat = new SqlParameter("@Duoc_Kich_Hoat", SqlDbType.Bit, 1);
                    pDuoc_Kich_Hoat.Value = Duoc_Kich_Hoat;
                    myCommand.Parameters.Add(pDuoc_Kich_Hoat);

                    SqlParameter pHinh_Nen = new SqlParameter("@Hinh_Nen", SqlDbType.Int, 4);
                    pHinh_Nen.Value = Hinh_Nen;
                    myCommand.Parameters.Add(pHinh_Nen);

                    SqlParameter pCanBoID = new SqlParameter("@CanBoID", SqlDbType.Int);
                    pCanBoID.Value = CanBoID;
                    myCommand.Parameters.Add(pCanBoID);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    return (int)pMa_Nguoi_Dung.Value;
                }
            }
        }
        #endregion

        #region Cap_Nhat
        public void Cap_Nhat(int Ma_Nguoi_Dung, int Ma_Don_Vi, string Ten_Dang_Nhap, string Mat_Khau, string Ho_Ten, string Hom_Thu, string Dien_Thoai, bool Duoc_Kich_Hoat, int Hinh_Nen, int CanBoID)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung.Value = Ma_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pTen_Dang_Nhap = new SqlParameter("@Ten_Dang_Nhap", SqlDbType.NVarChar, 50);
                    pTen_Dang_Nhap.Value = Ten_Dang_Nhap;
                    myCommand.Parameters.Add(pTen_Dang_Nhap);

                    SqlParameter pMat_Khau = new SqlParameter("@Mat_Khau", SqlDbType.NVarChar, 150);
                    pMat_Khau.Value = Mat_Khau;
                    myCommand.Parameters.Add(pMat_Khau);

                    SqlParameter pHo_Ten = new SqlParameter("@Ho_Ten", SqlDbType.NVarChar, 150);
                    pHo_Ten.Value = Ho_Ten;
                    myCommand.Parameters.Add(pHo_Ten);

                    SqlParameter pHom_Thu = new SqlParameter("@Hom_Thu", SqlDbType.NVarChar, 50);
                    pHom_Thu.Value = Hom_Thu;
                    myCommand.Parameters.Add(pHom_Thu);

                    SqlParameter pDien_Thoai = new SqlParameter("@Dien_Thoai", SqlDbType.NVarChar, 20);
                    pDien_Thoai.Value = Dien_Thoai;
                    myCommand.Parameters.Add(pDien_Thoai);

                    SqlParameter pDuoc_Kich_Hoat = new SqlParameter("@Duoc_Kich_Hoat", SqlDbType.Bit, 1);
                    pDuoc_Kich_Hoat.Value = Duoc_Kich_Hoat;
                    myCommand.Parameters.Add(pDuoc_Kich_Hoat);

                    SqlParameter pHinh_Nen = new SqlParameter("@Hinh_Nen", SqlDbType.Int, 4);
                    pHinh_Nen.Value = Hinh_Nen;
                    myCommand.Parameters.Add(pHinh_Nen);

                    SqlParameter pCanBoID = new SqlParameter("@CanBoID", SqlDbType.Int);
                    pCanBoID.Value = CanBoID;
                    myCommand.Parameters.Add(pCanBoID);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(HT_Nguoi_Dung_Chi_Tiet myHT_Nguoi_Dung_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung.Value = myHT_Nguoi_Dung_Chi_Tiet.Ma_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = myHT_Nguoi_Dung_Chi_Tiet.Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pTen_Dang_Nhap = new SqlParameter("@Ten_Dang_Nhap", SqlDbType.NVarChar, 50);
                    pTen_Dang_Nhap.Value = myHT_Nguoi_Dung_Chi_Tiet.Ten_Dang_Nhap;
                    myCommand.Parameters.Add(pTen_Dang_Nhap);

                    SqlParameter pMat_Khau = new SqlParameter("@Mat_Khau", SqlDbType.NVarChar, 150);
                    pMat_Khau.Value = myHT_Nguoi_Dung_Chi_Tiet.Mat_Khau;
                    myCommand.Parameters.Add(pMat_Khau);

                    SqlParameter pHo_Ten = new SqlParameter("@Ho_Ten", SqlDbType.NVarChar, 150);
                    pHo_Ten.Value = myHT_Nguoi_Dung_Chi_Tiet.Ho_Ten;
                    myCommand.Parameters.Add(pHo_Ten);

                    SqlParameter pHom_Thu = new SqlParameter("@Hom_Thu", SqlDbType.NVarChar, 50);
                    pHom_Thu.Value = myHT_Nguoi_Dung_Chi_Tiet.Hom_Thu;
                    myCommand.Parameters.Add(pHom_Thu);

                    SqlParameter pDien_Thoai = new SqlParameter("@Dien_Thoai", SqlDbType.NVarChar, 20);
                    pDien_Thoai.Value = myHT_Nguoi_Dung_Chi_Tiet.Dien_Thoai;
                    myCommand.Parameters.Add(pDien_Thoai);

                    SqlParameter pDuoc_Kich_Hoat = new SqlParameter("@Duoc_Kich_Hoat", SqlDbType.Bit, 1);
                    pDuoc_Kich_Hoat.Value = myHT_Nguoi_Dung_Chi_Tiet.Duoc_Kich_Hoat;
                    myCommand.Parameters.Add(pDuoc_Kich_Hoat);

                    SqlParameter pHinh_Nen = new SqlParameter("@Hinh_Nen", SqlDbType.Int, 4);
                    pHinh_Nen.Value = myHT_Nguoi_Dung_Chi_Tiet.Hinh_Nen;
                    myCommand.Parameters.Add(pHinh_Nen);


                    SqlParameter pCanBoID = new SqlParameter("@CanBoID", SqlDbType.Int);
                    pCanBoID.Value = myHT_Nguoi_Dung_Chi_Tiet.CanBoID;
                    myCommand.Parameters.Add(pCanBoID);

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
                using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int, 4);
                        pMa_Nguoi_Dung.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nguoi_Dung"];
                        myCommand.Parameters.Add(pMa_Nguoi_Dung);

                        SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                        pMa_Don_Vi.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Don_Vi"];
                        myCommand.Parameters.Add(pMa_Don_Vi);

                        SqlParameter pTen_Dang_Nhap = new SqlParameter("@Ten_Dang_Nhap", SqlDbType.NVarChar, 50);
                        pTen_Dang_Nhap.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ten_Dang_Nhap"];
                        myCommand.Parameters.Add(pTen_Dang_Nhap);

                        SqlParameter pMat_Khau = new SqlParameter("@Mat_Khau", SqlDbType.NVarChar, 150);
                        pMat_Khau.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Mat_Khau"];
                        myCommand.Parameters.Add(pMat_Khau);

                        SqlParameter pHo_Ten = new SqlParameter("@Ho_Ten", SqlDbType.NVarChar, 150);
                        pHo_Ten.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ho_Ten"];
                        myCommand.Parameters.Add(pHo_Ten);

                        SqlParameter pHom_Thu = new SqlParameter("@Hom_Thu", SqlDbType.NVarChar, 50);
                        pHom_Thu.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Hom_Thu"];
                        myCommand.Parameters.Add(pHom_Thu);

                        SqlParameter pDien_Thoai = new SqlParameter("@Dien_Thoai", SqlDbType.NVarChar, 20);
                        pDien_Thoai.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Dien_Thoai"];
                        myCommand.Parameters.Add(pDien_Thoai);

                        SqlParameter pDuoc_Kich_Hoat = new SqlParameter("@Duoc_Kich_Hoat", SqlDbType.Bit, 1);
                        pDuoc_Kich_Hoat.Value = (bool)myDataSet.Tables[strTableName].Rows[i]["Duoc_Kich_Hoat"];
                        myCommand.Parameters.Add(pDuoc_Kich_Hoat);

                        SqlParameter pHinh_Nen = new SqlParameter("@Hinh_Nen", SqlDbType.Int, 4);
                        pHinh_Nen.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Hinh_Nen"];
                        myCommand.Parameters.Add(pHinh_Nen);


                        SqlParameter pCanBoID = new SqlParameter("@CanBoID", SqlDbType.Int,4);
                        pCanBoID.Value = (int)myDataSet.Tables[strTableName].Rows[i]["CanBoID"];
                        myCommand.Parameters.Add(pCanBoID);


                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int Ma_Nguoi_Dung, int Ma_Don_Vi, string Ten_Dang_Nhap, string Mat_Khau, string Ho_Ten, string Hom_Thu, string Dien_Thoai, bool Duoc_Kich_Hoat, int Hinh_Nen, int CanBoID)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung.Value = Ma_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pTen_Dang_Nhap = new SqlParameter("@Ten_Dang_Nhap", SqlDbType.NVarChar, 50);
                    pTen_Dang_Nhap.Value = Ten_Dang_Nhap;
                    myCommand.Parameters.Add(pTen_Dang_Nhap);

                    SqlParameter pMat_Khau = new SqlParameter("@Mat_Khau", SqlDbType.NVarChar, 150);
                    pMat_Khau.Value = Mat_Khau;
                    myCommand.Parameters.Add(pMat_Khau);

                    SqlParameter pHo_Ten = new SqlParameter("@Ho_Ten", SqlDbType.NVarChar, 150);
                    pHo_Ten.Value = Ho_Ten;
                    myCommand.Parameters.Add(pHo_Ten);

                    SqlParameter pHom_Thu = new SqlParameter("@Hom_Thu", SqlDbType.NVarChar, 50);
                    pHom_Thu.Value = Hom_Thu;
                    myCommand.Parameters.Add(pHom_Thu);

                    SqlParameter pDien_Thoai = new SqlParameter("@Dien_Thoai", SqlDbType.NVarChar, 20);
                    pDien_Thoai.Value = Dien_Thoai;
                    myCommand.Parameters.Add(pDien_Thoai);

                    SqlParameter pDuoc_Kich_Hoat = new SqlParameter("@Duoc_Kich_Hoat", SqlDbType.Bit, 1);
                    pDuoc_Kich_Hoat.Value = Duoc_Kich_Hoat;
                    myCommand.Parameters.Add(pDuoc_Kich_Hoat);

                    SqlParameter pHinh_Nen = new SqlParameter("@Hinh_Nen", SqlDbType.Int, 4);
                    pHinh_Nen.Value = Hinh_Nen;
                    myCommand.Parameters.Add(pHinh_Nen);

                    SqlParameter pCanBoID = new SqlParameter("@CanBoID", SqlDbType.Int);
                    pCanBoID.Value = CanBoID;
                    myCommand.Parameters.Add(pCanBoID);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Ma_Nguoi_Dung)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung.Value = Ma_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung);

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
                using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Nguoi_Dung_Danh_Sach");
                    return myDataSet.Tables["HT_Nguoi_Dung_Danh_Sach"];
                }
            }
        }
        #endregion

        #region Lay_Boi_HT_Don_Vi_YT
        public DataTable Lay_Boi_HT_Don_Vi_YT(int Ma_Don_Vi)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Lay_Boi_HT_Don_Vi_YT", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Nguoi_Dung_Lay_Boi_HT_Don_Vi_YT");
                    return myDataSet.Tables["HT_Nguoi_Dung_Lay_Boi_HT_Don_Vi_YT"];
                }
            }
        }
        #endregion

        //New
        #region Lay_Boi_Mat_Khau
        public HT_Nguoi_Dung_Chi_Tiet Lay_Boi_Mat_Khau(string Ten_Dang_Nhap, string Mat_Khau)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Lay_Boi_Mat_Khau", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pTen_Dang_Nhap = new SqlParameter("@Ten_Dang_Nhap", SqlDbType.NVarChar, 50);
                    pTen_Dang_Nhap.Value = Ten_Dang_Nhap;
                    myCommand.Parameters.Add(pTen_Dang_Nhap);

                    SqlParameter pMat_Khau = new SqlParameter("@Mat_Khau", SqlDbType.NVarChar, 150);
                    pMat_Khau.Value = Mat_Khau;
                    myCommand.Parameters.Add(pMat_Khau);

                    SqlParameter pHo_Ten = new SqlParameter("@Ho_Ten", SqlDbType.NVarChar, 150);
                    pHo_Ten.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pHo_Ten);

                    SqlParameter pHom_Thu = new SqlParameter("@Hom_Thu", SqlDbType.NVarChar, 50);
                    pHom_Thu.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pHom_Thu);

                    SqlParameter pDien_Thoai = new SqlParameter("@Dien_Thoai", SqlDbType.NVarChar, 20);
                    pDien_Thoai.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pDien_Thoai);

                    SqlParameter pDuoc_Kich_Hoat = new SqlParameter("@Duoc_Kich_Hoat", SqlDbType.Bit, 1);
                    pDuoc_Kich_Hoat.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pDuoc_Kich_Hoat);

                    SqlParameter pHinh_Nen = new SqlParameter("@Hinh_Nen", SqlDbType.Int, 4);
                    pHinh_Nen.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pHinh_Nen);

                    SqlParameter pCanBoID = new SqlParameter("@CanBoID", SqlDbType.Int,4);
                    pCanBoID.Value = ParameterDirection.Output;
                    myCommand.Parameters.Add(pCanBoID);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();


                    HT_Nguoi_Dung_Chi_Tiet myHT_Nguoi_Dung_Chi_Tiet = new HT_Nguoi_Dung_Chi_Tiet();
                    myHT_Nguoi_Dung_Chi_Tiet.Ma_Nguoi_Dung = (int)pMa_Nguoi_Dung.Value;
                    myHT_Nguoi_Dung_Chi_Tiet.Ma_Don_Vi = (int)pMa_Don_Vi.Value;
                    myHT_Nguoi_Dung_Chi_Tiet.Ten_Dang_Nhap = (string)pTen_Dang_Nhap.Value;
                    myHT_Nguoi_Dung_Chi_Tiet.Mat_Khau = (string)pMat_Khau.Value;
                    myHT_Nguoi_Dung_Chi_Tiet.Ho_Ten = (string)pHo_Ten.Value;
                    myHT_Nguoi_Dung_Chi_Tiet.Hom_Thu = pHom_Thu.Value == DBNull.Value ? null : (string)pHom_Thu.Value;
                    myHT_Nguoi_Dung_Chi_Tiet.Dien_Thoai = (string)pDien_Thoai.Value;
                    myHT_Nguoi_Dung_Chi_Tiet.Duoc_Kich_Hoat = (bool)pDuoc_Kich_Hoat.Value;
                    myHT_Nguoi_Dung_Chi_Tiet.Hinh_Nen = (int)pHinh_Nen.Value;
                    myHT_Nguoi_Dung_Chi_Tiet.CanBoID = (int)pCanBoID.Value;
                    return myHT_Nguoi_Dung_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Lay_Boi_Ten_Dang_Nhap
        public HT_Nguoi_Dung_Chi_Tiet Lay_Boi_Ten_Dang_Nhap(string Ten_Dang_Nhap)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Lay_Boi_Ten_Dang_Nhap", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pTen_Dang_Nhap = new SqlParameter("@Ten_Dang_Nhap", SqlDbType.NVarChar, 50);
                    pTen_Dang_Nhap.Value = Ten_Dang_Nhap;
                    myCommand.Parameters.Add(pTen_Dang_Nhap);

                    SqlParameter pMat_Khau = new SqlParameter("@Mat_Khau", SqlDbType.NVarChar, 150);
                    pMat_Khau.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pMat_Khau);

                    SqlParameter pHo_Ten = new SqlParameter("@Ho_Ten", SqlDbType.NVarChar, 150);
                    pHo_Ten.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pHo_Ten);

                    SqlParameter pHom_Thu = new SqlParameter("@Hom_Thu", SqlDbType.NVarChar, 50);
                    pHom_Thu.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pHom_Thu);

                    SqlParameter pDien_Thoai = new SqlParameter("@Dien_Thoai", SqlDbType.NVarChar, 20);
                    pDien_Thoai.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pDien_Thoai);

                    SqlParameter pDuoc_Kich_Hoat = new SqlParameter("@Duoc_Kich_Hoat", SqlDbType.Bit, 1);
                    pDuoc_Kich_Hoat.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pDuoc_Kich_Hoat);

                    SqlParameter pHinh_Nen = new SqlParameter("@Hinh_Nen", SqlDbType.Int, 4);
                    pHinh_Nen.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pHinh_Nen);

                    SqlParameter pCanBoID = new SqlParameter("@CanBoID", SqlDbType.Int);
                    pCanBoID.Value = ParameterDirection.Output;
                    myCommand.Parameters.Add(pCanBoID);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();


                    HT_Nguoi_Dung_Chi_Tiet myHT_Nguoi_Dung_Chi_Tiet = new HT_Nguoi_Dung_Chi_Tiet();
                    myHT_Nguoi_Dung_Chi_Tiet.Ma_Nguoi_Dung = (int)pMa_Nguoi_Dung.Value;
                    myHT_Nguoi_Dung_Chi_Tiet.Ma_Don_Vi = (int)pMa_Don_Vi.Value;
                    myHT_Nguoi_Dung_Chi_Tiet.Ten_Dang_Nhap = (string)pTen_Dang_Nhap.Value;
                    myHT_Nguoi_Dung_Chi_Tiet.Mat_Khau = (string)pMat_Khau.Value;
                    myHT_Nguoi_Dung_Chi_Tiet.Ho_Ten = (string)pHo_Ten.Value;
                    myHT_Nguoi_Dung_Chi_Tiet.Hom_Thu = pHom_Thu.Value == DBNull.Value ? null : (string)pHom_Thu.Value;
                    myHT_Nguoi_Dung_Chi_Tiet.Dien_Thoai = (string)pDien_Thoai.Value;
                    myHT_Nguoi_Dung_Chi_Tiet.Duoc_Kich_Hoat = (bool)pDuoc_Kich_Hoat.Value;
                    myHT_Nguoi_Dung_Chi_Tiet.Hinh_Nen = (int)pHinh_Nen.Value;
                    myHT_Nguoi_Dung_Chi_Tiet.CanBoID = (int)pCanBoID.Value;
                    return myHT_Nguoi_Dung_Chi_Tiet;
                }
            }
        }
        #endregion

    }
    #endregion
}