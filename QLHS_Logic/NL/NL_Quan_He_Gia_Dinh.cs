using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region NL_Quan_He_Gia_Dinh_Details
    public class NL_Quan_He_Gia_Dinh_Chi_Tiet
    {
        public int? Ma_Quan_He = null; // Mã quan hệ
        public int? Ma_Nhan_Vien = null; // Mã nhân viên
        public int? Loai_Quan_He = null; // Loại quan hệ
        public string Ho_Ten = null; // Họ tên
        public int? Nam_Sinh = null; // Năm sinh
        public string Nghe_Nghiep = null; // Nghề nghiệp
        public string Cho_O = null; // Chỗ ở
        public string Ghi_Chu = null; // Ghi chú
        public bool? Quan_he_Ben = null;
        public string Noi_Lam_Viec = null;//Nơi làm việc
    }
    #endregion
    #region NL_Quan_He_Gia_Dinh
    public class NL_Quan_He_Gia_Dinh
    {
        private string ConnectionString;
        public NL_Quan_He_Gia_Dinh(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_Quan_He_Gia_Dinh_Chi_Tiet Lay(int Ma_Quan_He)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Quan_He_Gia_Dinh_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Quan_He = new SqlParameter("@Ma_Quan_He", SqlDbType.Int, 4);
                    pMa_Quan_He.Value = Ma_Quan_He;
                    myCommand.Parameters.Add(pMa_Quan_He);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Quan_He_Gia_Dinh_Chi_Tiet");
                    NL_Quan_He_Gia_Dinh_Chi_Tiet myNL_Quan_He_Gia_Dinh_Chi_Tiet = new NL_Quan_He_Gia_Dinh_Chi_Tiet();
                    if (myDataSet.Tables["NL_Quan_He_Gia_Dinh_Chi_Tiet"] != null)
                    {
                        myNL_Quan_He_Gia_Dinh_Chi_Tiet.Ma_Quan_He = Ma_Quan_He;
                        myNL_Quan_He_Gia_Dinh_Chi_Tiet.Ma_Nhan_Vien = myDataSet.Tables["NL_Quan_He_Gia_Dinh_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Quan_He_Gia_Dinh_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] : (int?)null;
                        myNL_Quan_He_Gia_Dinh_Chi_Tiet.Loai_Quan_He = myDataSet.Tables["NL_Quan_He_Gia_Dinh_Chi_Tiet"].Rows[0]["Loai_Quan_He"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Quan_He_Gia_Dinh_Chi_Tiet"].Rows[0]["Loai_Quan_He"] : (int?)null;
                        myNL_Quan_He_Gia_Dinh_Chi_Tiet.Ho_Ten = myDataSet.Tables["NL_Quan_He_Gia_Dinh_Chi_Tiet"].Rows[0]["Ho_Ten"] != DBNull.Value ? (string)myDataSet.Tables["NL_Quan_He_Gia_Dinh_Chi_Tiet"].Rows[0]["Ho_Ten"] : (string)null;
                        myNL_Quan_He_Gia_Dinh_Chi_Tiet.Nam_Sinh = myDataSet.Tables["NL_Quan_He_Gia_Dinh_Chi_Tiet"].Rows[0]["Nam_Sinh"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Quan_He_Gia_Dinh_Chi_Tiet"].Rows[0]["Nam_Sinh"] : (int?)null;
                        myNL_Quan_He_Gia_Dinh_Chi_Tiet.Nghe_Nghiep = myDataSet.Tables["NL_Quan_He_Gia_Dinh_Chi_Tiet"].Rows[0]["Nghe_Nghiep"] != DBNull.Value ? (string)myDataSet.Tables["NL_Quan_He_Gia_Dinh_Chi_Tiet"].Rows[0]["Nghe_Nghiep"] : (string)null;
                        myNL_Quan_He_Gia_Dinh_Chi_Tiet.Cho_O = myDataSet.Tables["NL_Quan_He_Gia_Dinh_Chi_Tiet"].Rows[0]["Cho_O"] != DBNull.Value ? (string)myDataSet.Tables["NL_Quan_He_Gia_Dinh_Chi_Tiet"].Rows[0]["Cho_O"] : (string)null;
                        myNL_Quan_He_Gia_Dinh_Chi_Tiet.Ghi_Chu = myDataSet.Tables["NL_Quan_He_Gia_Dinh_Chi_Tiet"].Rows[0]["Ghi_Chu"] != DBNull.Value ? (string)myDataSet.Tables["NL_Quan_He_Gia_Dinh_Chi_Tiet"].Rows[0]["Ghi_Chu"] : (string)null;
                        myNL_Quan_He_Gia_Dinh_Chi_Tiet.Quan_he_Ben = myDataSet.Tables["NL_Quan_He_Gia_Dinh_Chi_Tiet"].Rows[0]["Quan_he_Ben"] != DBNull.Value ? (bool?)myDataSet.Tables["NL_Quan_He_Gia_Dinh_Chi_Tiet"].Rows[0]["Quan_he_Ben"] : (bool?)null;
                        myNL_Quan_He_Gia_Dinh_Chi_Tiet.Noi_Lam_Viec = myDataSet.Tables["NL_Quan_He_Gia_Dinh_Chi_Tiet"].Rows[0]["Noi_Lam_Viec"] != DBNull.Value ? (string)myDataSet.Tables["NL_Quan_He_Gia_Dinh_Chi_Tiet"].Rows[0]["Noi_Lam_Viec"] : (string)null;


                    }
                    return myNL_Quan_He_Gia_Dinh_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Ma_Quan_He = null, int? Ma_Nhan_Vien = null, int? Loai_Quan_He = null, string Ho_Ten = null, int? Nam_Sinh = null, string Nghe_Nghiep = null, string Cho_O = null, string Ghi_Chu = null, bool? Quan_he_Ben = null, string Noi_Lam_Viec = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Quan_He_Gia_Dinh_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Quan_He = new SqlParameter("@Ma_Quan_He", SqlDbType.Int, 4);
                    pMa_Quan_He.Value = Ma_Quan_He;
                    myCommand.Parameters.Add(pMa_Quan_He);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pLoai_Quan_He = new SqlParameter("@Loai_Quan_He", SqlDbType.Int, 4);
                    pLoai_Quan_He.Value = Loai_Quan_He;
                    myCommand.Parameters.Add(pLoai_Quan_He);

                    SqlParameter pHo_Ten = new SqlParameter("@Ho_Ten", SqlDbType.NVarChar, 150);
                    pHo_Ten.Value = Ho_Ten;
                    myCommand.Parameters.Add(pHo_Ten);

                    SqlParameter pNam_Sinh = new SqlParameter("@Nam_Sinh", SqlDbType.Int, 4);
                    pNam_Sinh.Value = Nam_Sinh;
                    myCommand.Parameters.Add(pNam_Sinh);

                    SqlParameter pNghe_Nghiep = new SqlParameter("@Nghe_Nghiep", SqlDbType.NVarChar, 500);
                    pNghe_Nghiep.Value = Nghe_Nghiep;
                    myCommand.Parameters.Add(pNghe_Nghiep);

                    SqlParameter pCho_O = new SqlParameter("@Cho_O", SqlDbType.NVarChar, 500);
                    pCho_O.Value = Cho_O;
                    myCommand.Parameters.Add(pCho_O);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 500);
                    pGhi_Chu.Value = Ghi_Chu;
                    myCommand.Parameters.Add(pGhi_Chu);
                    SqlParameter pQuan_he_Ben = new SqlParameter("@Quan_he_Ben", SqlDbType.Bit);
                    pQuan_he_Ben.Value = Quan_he_Ben;
                    myCommand.Parameters.Add(pQuan_he_Ben);

                    SqlParameter pNoi_Lam_Viec = new SqlParameter("@Noi_Lam_Viec", SqlDbType.NVarChar, 500);
                    pNoi_Lam_Viec.Value = Noi_Lam_Viec;
                    myCommand.Parameters.Add(pNoi_Lam_Viec);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int? Ma_Quan_He = null, int? Ma_Nhan_Vien = null, int? Loai_Quan_He = null, string Ho_Ten = null, int? Nam_Sinh = null, string Nghe_Nghiep = null, string Cho_O = null, string Ghi_Chu = null, bool? Quan_he_Ben = null, string Noi_Lam_Viec = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Quan_He_Gia_Dinh_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Quan_He = new SqlParameter("@Ma_Quan_He", SqlDbType.Int, 4);
                    pMa_Quan_He.Value = Ma_Quan_He;
                    myCommand.Parameters.Add(pMa_Quan_He);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pLoai_Quan_He = new SqlParameter("@Loai_Quan_He", SqlDbType.Int, 4);
                    pLoai_Quan_He.Value = Loai_Quan_He;
                    myCommand.Parameters.Add(pLoai_Quan_He);

                    SqlParameter pHo_Ten = new SqlParameter("@Ho_Ten", SqlDbType.NVarChar, 150);
                    pHo_Ten.Value = Ho_Ten;
                    myCommand.Parameters.Add(pHo_Ten);

                    SqlParameter pNam_Sinh = new SqlParameter("@Nam_Sinh", SqlDbType.Int, 4);
                    pNam_Sinh.Value = Nam_Sinh;
                    myCommand.Parameters.Add(pNam_Sinh);

                    SqlParameter pNghe_Nghiep = new SqlParameter("@Nghe_Nghiep", SqlDbType.NVarChar, 500);
                    pNghe_Nghiep.Value = Nghe_Nghiep;
                    myCommand.Parameters.Add(pNghe_Nghiep);

                    SqlParameter pCho_O = new SqlParameter("@Cho_O", SqlDbType.NVarChar, 500);
                    pCho_O.Value = Cho_O;
                    myCommand.Parameters.Add(pCho_O);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 500);
                    pGhi_Chu.Value = Ghi_Chu;
                    myCommand.Parameters.Add(pGhi_Chu);


                    SqlParameter pQuan_he_Ben = new SqlParameter("@Quan_he_Ben", SqlDbType.Bit);
                    pQuan_he_Ben.Value = Quan_he_Ben;
                    myCommand.Parameters.Add(pQuan_he_Ben);

                    SqlParameter pNoi_Lam_Viec = new SqlParameter("@Noi_Lam_Viec", SqlDbType.NVarChar, 500);
                    pNoi_Lam_Viec.Value = Noi_Lam_Viec;
                    myCommand.Parameters.Add(pNoi_Lam_Viec);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(NL_Quan_He_Gia_Dinh_Chi_Tiet myNL_Quan_He_Gia_Dinh_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Quan_He_Gia_Dinh_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Quan_He = new SqlParameter("@Ma_Quan_He", SqlDbType.Int, 4);
                    pMa_Quan_He.Value = myNL_Quan_He_Gia_Dinh_Chi_Tiet.Ma_Quan_He;
                    myCommand.Parameters.Add(pMa_Quan_He);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = myNL_Quan_He_Gia_Dinh_Chi_Tiet.Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pLoai_Quan_He = new SqlParameter("@Loai_Quan_He", SqlDbType.Int, 4);
                    pLoai_Quan_He.Value = myNL_Quan_He_Gia_Dinh_Chi_Tiet.Loai_Quan_He;
                    myCommand.Parameters.Add(pLoai_Quan_He);

                    SqlParameter pHo_Ten = new SqlParameter("@Ho_Ten", SqlDbType.NVarChar, 150);
                    pHo_Ten.Value = myNL_Quan_He_Gia_Dinh_Chi_Tiet.Ho_Ten;
                    myCommand.Parameters.Add(pHo_Ten);

                    SqlParameter pNam_Sinh = new SqlParameter("@Nam_Sinh", SqlDbType.Int, 4);
                    pNam_Sinh.Value = myNL_Quan_He_Gia_Dinh_Chi_Tiet.Nam_Sinh;
                    myCommand.Parameters.Add(pNam_Sinh);

                    SqlParameter pNghe_Nghiep = new SqlParameter("@Nghe_Nghiep", SqlDbType.NVarChar, 500);
                    pNghe_Nghiep.Value = myNL_Quan_He_Gia_Dinh_Chi_Tiet.Nghe_Nghiep;
                    myCommand.Parameters.Add(pNghe_Nghiep);

                    SqlParameter pCho_O = new SqlParameter("@Cho_O", SqlDbType.NVarChar, 500);
                    pCho_O.Value = myNL_Quan_He_Gia_Dinh_Chi_Tiet.Cho_O;
                    myCommand.Parameters.Add(pCho_O);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 500);
                    pGhi_Chu.Value = myNL_Quan_He_Gia_Dinh_Chi_Tiet.Ghi_Chu;
                    myCommand.Parameters.Add(pGhi_Chu);


                    SqlParameter pQuan_he_Ben = new SqlParameter("@Quan_he_Ben", SqlDbType.Bit);
                    pQuan_he_Ben.Value = myNL_Quan_He_Gia_Dinh_Chi_Tiet.Quan_he_Ben;
                    myCommand.Parameters.Add(pQuan_he_Ben);

                    SqlParameter pNoi_Lam_Viec = new SqlParameter("@Noi_Lam_Viec", SqlDbType.NVarChar, 500);
                    pNoi_Lam_Viec.Value = myNL_Quan_He_Gia_Dinh_Chi_Tiet.Noi_Lam_Viec;
                    myCommand.Parameters.Add(pNoi_Lam_Viec);

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
                using (SqlCommand myCommand = new SqlCommand("NL_Quan_He_Gia_Dinh_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Quan_He = new SqlParameter("@Ma_Quan_He", SqlDbType.Int, 4);
                        pMa_Quan_He.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Quan_He"];
                        myCommand.Parameters.Add(pMa_Quan_He);

                        SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                        pMa_Nhan_Vien.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nhan_Vien"];
                        myCommand.Parameters.Add(pMa_Nhan_Vien);

                        SqlParameter pLoai_Quan_He = new SqlParameter("@Loai_Quan_He", SqlDbType.Int, 4);
                        pLoai_Quan_He.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Loai_Quan_He"];
                        myCommand.Parameters.Add(pLoai_Quan_He);

                        SqlParameter pHo_Ten = new SqlParameter("@Ho_Ten", SqlDbType.NVarChar, 150);
                        pHo_Ten.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ho_Ten"];
                        myCommand.Parameters.Add(pHo_Ten);

                        SqlParameter pNam_Sinh = new SqlParameter("@Nam_Sinh", SqlDbType.Int, 4);
                        pNam_Sinh.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Nam_Sinh"];
                        myCommand.Parameters.Add(pNam_Sinh);

                        SqlParameter pNghe_Nghiep = new SqlParameter("@Nghe_Nghiep", SqlDbType.NVarChar, 500);
                        pNghe_Nghiep.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Nghe_Nghiep"];
                        myCommand.Parameters.Add(pNghe_Nghiep);

                        SqlParameter pCho_O = new SqlParameter("@Cho_O", SqlDbType.NVarChar, 500);
                        pCho_O.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Cho_O"];
                        myCommand.Parameters.Add(pCho_O);

                        SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 500);
                        pGhi_Chu.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ghi_Chu"];
                        myCommand.Parameters.Add(pGhi_Chu);

                        SqlParameter pQuan_he_Ben = new SqlParameter("@Quan_he_Ben", SqlDbType.Bit);
                        pQuan_he_Ben.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Quan_he_Ben"];
                        myCommand.Parameters.Add(pQuan_he_Ben);

                        SqlParameter pNoi_Lam_Viec = new SqlParameter("@Noi_Lam_Viec", SqlDbType.NVarChar, 500);
                        pNoi_Lam_Viec.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Noi_Lam_Viec"];
                        myCommand.Parameters.Add(pNoi_Lam_Viec);

                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int? Ma_Quan_He = null, int? Ma_Nhan_Vien = null, int? Loai_Quan_He = null, string Ho_Ten = null, int? Nam_Sinh = null, string Nghe_Nghiep = null, string Cho_O = null, string Ghi_Chu = null, bool? Quan_he_Ben = null, string Noi_Lam_Viec = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Quan_He_Gia_Dinh_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Quan_He = new SqlParameter("@Ma_Quan_He", SqlDbType.Int, 4);
                    pMa_Quan_He.Value = Ma_Quan_He;
                    myCommand.Parameters.Add(pMa_Quan_He);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pLoai_Quan_He = new SqlParameter("@Loai_Quan_He", SqlDbType.Int, 4);
                    pLoai_Quan_He.Value = Loai_Quan_He;
                    myCommand.Parameters.Add(pLoai_Quan_He);

                    SqlParameter pHo_Ten = new SqlParameter("@Ho_Ten", SqlDbType.NVarChar, 150);
                    pHo_Ten.Value = Ho_Ten;
                    myCommand.Parameters.Add(pHo_Ten);

                    SqlParameter pNam_Sinh = new SqlParameter("@Nam_Sinh", SqlDbType.Int, 4);
                    pNam_Sinh.Value = Nam_Sinh;
                    myCommand.Parameters.Add(pNam_Sinh);

                    SqlParameter pNghe_Nghiep = new SqlParameter("@Nghe_Nghiep", SqlDbType.NVarChar, 500);
                    pNghe_Nghiep.Value = Nghe_Nghiep;
                    myCommand.Parameters.Add(pNghe_Nghiep);

                    SqlParameter pCho_O = new SqlParameter("@Cho_O", SqlDbType.NVarChar, 500);
                    pCho_O.Value = Cho_O;
                    myCommand.Parameters.Add(pCho_O);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 500);
                    pGhi_Chu.Value = Ghi_Chu;
                    myCommand.Parameters.Add(pGhi_Chu);


                    SqlParameter pQuan_he_Ben = new SqlParameter("@Quan_he_Ben", SqlDbType.Bit);
                    pQuan_he_Ben.Value = Quan_he_Ben;
                    myCommand.Parameters.Add(pQuan_he_Ben);

                    SqlParameter pNoi_Lam_Viec = new SqlParameter("@Noi_Lam_Viec", SqlDbType.NVarChar, 500);
                    pNoi_Lam_Viec.Value = Noi_Lam_Viec;
                    myCommand.Parameters.Add(pNoi_Lam_Viec);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Ma_Quan_He)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Quan_He_Gia_Dinh_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Quan_He = new SqlParameter("@Ma_Quan_He", SqlDbType.Int, 4);
                    pMa_Quan_He.Value = Ma_Quan_He;
                    myCommand.Parameters.Add(pMa_Quan_He);

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
                using (SqlCommand myCommand = new SqlCommand("NL_Quan_He_Gia_Dinh_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Quan_He_Gia_Dinh_Danh_Sach");
                    return myDataSet.Tables["NL_Quan_He_Gia_Dinh_Danh_Sach"];
                }
            }
        }
        #endregion

        #region Lay_Boi_NL_DM_Loai_Quan_He
        public DataTable Lay_Boi_NL_DM_Loai_Quan_He(int Loai_Quan_He)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Quan_He_Gia_Dinh_Lay_Boi_NL_DM_Loai_Quan_He", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pLoai_Quan_He = new SqlParameter("@Loai_Quan_He", SqlDbType.Int, 4);
                    pLoai_Quan_He.Value = Loai_Quan_He;
                    myCommand.Parameters.Add(pLoai_Quan_He);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Quan_He_Gia_Dinh_Lay_Boi_NL_DM_Loai_Quan_He");
                    return myDataSet.Tables["NL_Quan_He_Gia_Dinh_Lay_Boi_NL_DM_Loai_Quan_He"];
                }
            }
        }
        #endregion
        #region Lay_Boi_NL_Nhan_Vien
        public DataTable Lay_Boi_NL_Nhan_Vien(int Ma_Nhan_Vien)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Quan_He_Gia_Dinh_Lay_Boi_NL_Nhan_Vien", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Quan_He_Gia_Dinh_Lay_Boi_NL_Nhan_Vien");
                    return myDataSet.Tables["NL_Quan_He_Gia_Dinh_Lay_Boi_NL_Nhan_Vien"];
                }
            }
        }
        #endregion

    }
    #endregion
}