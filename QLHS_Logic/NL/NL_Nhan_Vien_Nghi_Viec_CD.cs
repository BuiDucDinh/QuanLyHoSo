using System;
using System.Data;
using System.Data.SqlClient;

namespace QLHS_Logic
{
    #region NL_Nhan_Vien_Nghi_Viec_CD_Details
    public class NL_Nhan_Vien_Nghi_Viec_CD_Chi_Tiet
    {
        public int? Ma_Nhan_Vien_Nghi_CD = null;
        public int? Ma_Nhan_Vien = null;
        public int? Loai_Nghi = null; // 1.Nghỉ hưu,2.Chuyển công tác,3.Thôi việc,4.Chết
        public string Ly_Do = null;
        public DateTime? Ngay_Bat_Dau = null;
        public DateTime? Ngay_Ket_Thuc = null;
    }
    #endregion
    #region NL_Nhan_Vien_Nghi_Viec_CD
    public class NL_Nhan_Vien_Nghi_Viec_CD
    {
        private string ConnectionString;
        public NL_Nhan_Vien_Nghi_Viec_CD(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_Nhan_Vien_Nghi_Viec_CD_Chi_Tiet Lay(int Ma_Nhan_Vien_Nghi_CD)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Nghi_CD_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien_Nghi_CD = new SqlParameter("@Ma_Nhan_Vien_Nghi_CD", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Nghi_CD.Value = Ma_Nhan_Vien_Nghi_CD;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Nghi_CD);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Nhan_Vien_Nghi_Viec_CD_Chi_Tiet");
                    NL_Nhan_Vien_Nghi_Viec_CD_Chi_Tiet myNL_Nhan_Vien_Nghi_Viec_CD_Chi_Tiet = new NL_Nhan_Vien_Nghi_Viec_CD_Chi_Tiet();
                    if (myDataSet.Tables["NL_Nhan_Vien_Nghi_Viec_CD_Chi_Tiet"] != null)
                    {
                        myNL_Nhan_Vien_Nghi_Viec_CD_Chi_Tiet.Ma_Nhan_Vien_Nghi_CD = Ma_Nhan_Vien_Nghi_CD;
                        myNL_Nhan_Vien_Nghi_Viec_CD_Chi_Tiet.Ma_Nhan_Vien = myDataSet.Tables["NL_Nhan_Vien_Nghi_Viec_CD_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Nhan_Vien_Nghi_Viec_CD_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] : (int?)null;
                        myNL_Nhan_Vien_Nghi_Viec_CD_Chi_Tiet.Loai_Nghi = myDataSet.Tables["NL_Nhan_Vien_Nghi_Viec_CD_Chi_Tiet"].Rows[0]["Loai_Nghi"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Nhan_Vien_Nghi_Viec_CD_Chi_Tiet"].Rows[0]["Loai_Nghi"] : (int?)null;
                        myNL_Nhan_Vien_Nghi_Viec_CD_Chi_Tiet.Ly_Do = myDataSet.Tables["NL_Nhan_Vien_Nghi_Viec_CD_Chi_Tiet"].Rows[0]["Ly_Do"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Nghi_Viec_CD_Chi_Tiet"].Rows[0]["Ly_Do"] : (string)null;
                        myNL_Nhan_Vien_Nghi_Viec_CD_Chi_Tiet.Ngay_Bat_Dau = myDataSet.Tables["NL_Nhan_Vien_Nghi_Viec_CD_Chi_Tiet"].Rows[0]["Ngay_Bat_Dau"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Nhan_Vien_Nghi_Viec_CD_Chi_Tiet"].Rows[0]["Ngay_Bat_Dau"] : (DateTime?)null;
                        myNL_Nhan_Vien_Nghi_Viec_CD_Chi_Tiet.Ngay_Ket_Thuc = myDataSet.Tables["NL_Nhan_Vien_Nghi_Viec_CD_Chi_Tiet"].Rows[0]["Ngay_Ket_Thuc"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Nhan_Vien_Nghi_Viec_CD_Chi_Tiet"].Rows[0]["Ngay_Ket_Thuc"] : (DateTime?)null;
                    }
                    return myNL_Nhan_Vien_Nghi_Viec_CD_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Ma_Nhan_Vien_Nghi_CD = null, int? Ma_Nhan_Vien = null, int? Loai_Nghi = null, string Ly_Do = null, DateTime? Ngay_Bat_Dau = null, DateTime? Ngay_Ket_Thuc = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Nghi_CD_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien_Nghi_CD = new SqlParameter("@Ma_Nhan_Vien_Nghi_CD", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Nghi_CD.Value = Ma_Nhan_Vien_Nghi_CD;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Nghi_CD);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pLoai_Nghi = new SqlParameter("@Loai_Nghi", SqlDbType.Int, 4);
                    pLoai_Nghi.Value = Loai_Nghi;
                    myCommand.Parameters.Add(pLoai_Nghi);

                    SqlParameter pLy_Do = new SqlParameter("@Ly_Do", SqlDbType.NVarChar, 500);
                    pLy_Do.Value = Ly_Do;
                    myCommand.Parameters.Add(pLy_Do);

                    SqlParameter pNgay_Bat_Dau = new SqlParameter("@Ngay_Bat_Dau", SqlDbType.DateTime, 8);
                    pNgay_Bat_Dau.Value = Ngay_Bat_Dau;
                    myCommand.Parameters.Add(pNgay_Bat_Dau);

                    SqlParameter pNgay_Ket_Thuc = new SqlParameter("@Ngay_Ket_Thuc", SqlDbType.DateTime, 8);
                    pNgay_Ket_Thuc.Value = Ngay_Ket_Thuc;
                    myCommand.Parameters.Add(pNgay_Ket_Thuc);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int? Ma_Nhan_Vien_Nghi_CD = null, int? Ma_Nhan_Vien = null, int? Loai_Nghi = null, string Ly_Do = null, DateTime? Ngay_Bat_Dau = null, DateTime? Ngay_Ket_Thuc = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Nghi_CD_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien_Nghi_CD = new SqlParameter("@Ma_Nhan_Vien_Nghi_CD", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Nghi_CD.Value = Ma_Nhan_Vien_Nghi_CD;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Nghi_CD);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pLoai_Nghi = new SqlParameter("@Loai_Nghi", SqlDbType.Int, 4);
                    pLoai_Nghi.Value = Loai_Nghi;
                    myCommand.Parameters.Add(pLoai_Nghi);

                    SqlParameter pLy_Do = new SqlParameter("@Ly_Do", SqlDbType.NVarChar, 500);
                    pLy_Do.Value = Ly_Do;
                    myCommand.Parameters.Add(pLy_Do);

                    SqlParameter pNgay_Bat_Dau = new SqlParameter("@Ngay_Bat_Dau", SqlDbType.DateTime, 8);
                    pNgay_Bat_Dau.Value = Ngay_Bat_Dau;
                    myCommand.Parameters.Add(pNgay_Bat_Dau);

                    SqlParameter pNgay_Ket_Thuc = new SqlParameter("@Ngay_Ket_Thuc", SqlDbType.DateTime, 8);
                    pNgay_Ket_Thuc.Value = Ngay_Ket_Thuc;
                    myCommand.Parameters.Add(pNgay_Ket_Thuc);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(NL_Nhan_Vien_Nghi_Viec_CD_Chi_Tiet myNL_Nhan_Vien_Nghi_Viec_CD_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Nghi_CD_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien_Nghi_CD = new SqlParameter("@Ma_Nhan_Vien_Nghi_CD", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Nghi_CD.Value = myNL_Nhan_Vien_Nghi_Viec_CD_Chi_Tiet.Ma_Nhan_Vien_Nghi_CD;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Nghi_CD);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = myNL_Nhan_Vien_Nghi_Viec_CD_Chi_Tiet.Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pLoai_Nghi = new SqlParameter("@Loai_Nghi", SqlDbType.Int, 4);
                    pLoai_Nghi.Value = myNL_Nhan_Vien_Nghi_Viec_CD_Chi_Tiet.Loai_Nghi;
                    myCommand.Parameters.Add(pLoai_Nghi);

                    SqlParameter pLy_Do = new SqlParameter("@Ly_Do", SqlDbType.NVarChar, 500);
                    pLy_Do.Value = myNL_Nhan_Vien_Nghi_Viec_CD_Chi_Tiet.Ly_Do;
                    myCommand.Parameters.Add(pLy_Do);

                    SqlParameter pNgay_Bat_Dau = new SqlParameter("@Ngay_Bat_Dau", SqlDbType.DateTime, 8);
                    pNgay_Bat_Dau.Value = myNL_Nhan_Vien_Nghi_Viec_CD_Chi_Tiet.Ngay_Bat_Dau;
                    myCommand.Parameters.Add(pNgay_Bat_Dau);

                    SqlParameter pNgay_Ket_Thuc = new SqlParameter("@Ngay_Ket_Thuc", SqlDbType.DateTime, 8);
                    pNgay_Ket_Thuc.Value = myNL_Nhan_Vien_Nghi_Viec_CD_Chi_Tiet.Ngay_Ket_Thuc;
                    myCommand.Parameters.Add(pNgay_Ket_Thuc);

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
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Nghi_CD_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Nhan_Vien_Nghi_CD = new SqlParameter("@Ma_Nhan_Vien_Nghi_CD", SqlDbType.Int, 4);
                        pMa_Nhan_Vien_Nghi_CD.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nhan_Vien_Nghi_CD"];
                        myCommand.Parameters.Add(pMa_Nhan_Vien_Nghi_CD);

                        SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                        pMa_Nhan_Vien.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nhan_Vien"];
                        myCommand.Parameters.Add(pMa_Nhan_Vien);

                        SqlParameter pLoai_Nghi = new SqlParameter("@Loai_Nghi", SqlDbType.Int, 4);
                        pLoai_Nghi.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Loai_Nghi"];
                        myCommand.Parameters.Add(pLoai_Nghi);

                        SqlParameter pLy_Do = new SqlParameter("@Ly_Do", SqlDbType.NVarChar, 500);
                        pLy_Do.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ly_Do"];
                        myCommand.Parameters.Add(pLy_Do);

                        SqlParameter pNgay_Bat_Dau = new SqlParameter("@Ngay_Bat_Dau", SqlDbType.DateTime, 8);
                        pNgay_Bat_Dau.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Ngay_Bat_Dau"];
                        myCommand.Parameters.Add(pNgay_Bat_Dau);

                        SqlParameter pNgay_Ket_Thuc = new SqlParameter("@Ngay_Ket_Thuc", SqlDbType.DateTime, 8);
                        pNgay_Ket_Thuc.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ngay_Ket_Thuc"];
                        myCommand.Parameters.Add(pNgay_Ket_Thuc);

                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int? Ma_Nhan_Vien_Nghi_CD = null, int? Ma_Nhan_Vien = null, int? Loai_Nghi = null, string Ly_Do = null, DateTime? Ngay_Bat_Dau = null, DateTime? Ngay_Ket_Thuc = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Nghi_CD_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien_Nghi_CD = new SqlParameter("@Ma_Nhan_Vien_Nghi_CD", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Nghi_CD.Value = Ma_Nhan_Vien_Nghi_CD;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Nghi_CD);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pLoai_Nghi = new SqlParameter("@Loai_Nghi", SqlDbType.Int, 4);
                    pLoai_Nghi.Value = Loai_Nghi;
                    myCommand.Parameters.Add(pLoai_Nghi);

                    SqlParameter pLy_Do = new SqlParameter("@Ly_Do", SqlDbType.NVarChar, 500);
                    pLy_Do.Value = Ly_Do;
                    myCommand.Parameters.Add(pLy_Do);

                    SqlParameter pNgay_Bat_Dau = new SqlParameter("@Ngay_Bat_Dau", SqlDbType.DateTime, 8);
                    pNgay_Bat_Dau.Value = Ngay_Bat_Dau;
                    myCommand.Parameters.Add(pNgay_Bat_Dau);

                    SqlParameter pNgay_Ket_Thuc = new SqlParameter("@Ngay_Ket_Thuc", SqlDbType.DateTime, 8);
                    pNgay_Ket_Thuc.Value = Ngay_Ket_Thuc;
                    myCommand.Parameters.Add(pNgay_Ket_Thuc);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Ma_Nhan_Vien_Nghi_CD)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Nghi_CD_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Vien_Nghi_CD = new SqlParameter("@Ma_Nhan_Vien_Nghi_CD", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Nghi_CD.Value = Ma_Nhan_Vien_Nghi_CD;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Nghi_CD);

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
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_CD_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Nhan_Vien_CD_Danh_Sach");
                    return myDataSet.Tables["NL_Nhan_Vien_CD_Danh_Sach"];
                }
            }
        }
        #endregion

        #region Lay_Boi_NL_Nhan_Vien
        public DataTable Lay_Boi_NL_Nhan_Vien(int Ma_Nhan_Vien_Nghi_CD)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Nghi_CD_Lay_Boi_NL_Nhan_Vien", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Nhan_Vien_Nghi_CD = new SqlParameter("@Ma_Nhan_Vien_Nghi_CD", SqlDbType.Int, 4);
                    pMa_Nhan_Vien_Nghi_CD.Value = Ma_Nhan_Vien_Nghi_CD;
                    myCommand.Parameters.Add(pMa_Nhan_Vien_Nghi_CD);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Nhan_Vien_Nghi_CD_Lay_Boi_NL_Nhan_Vien");
                    return myDataSet.Tables["NL_Nhan_Vien_Nghi_CD_Lay_Boi_NL_Nhan_Vien"];
                }
            }
        }
        #endregion
    }
    #endregion
}
