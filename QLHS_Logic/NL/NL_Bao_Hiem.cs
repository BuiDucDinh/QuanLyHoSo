using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region NL_Bao_Hiem_Details
    public class NL_Bao_Hiem_Chi_Tiet
    {
        public int? Ma_Bao_Hiem = null; // Mã bảo hiểm
        public int? Ma_Nhan_Vien = null; // Mã nhân viên
        public DateTime? Tu_Ngay_Nghi_Thuc = null; // Từ ngày nghỉ thực
        public DateTime? Den_Ngay_Nghi_Thuc = null; // Đến ngày nghỉ thực
        public DateTime? Tu_Ngay_Nghi_Bao_Hiem = null; // Từ ngày nghỉ bảo hiểm
        public DateTime? Den_Ngay_Nghi_Bao_Hiem = null; // Đến ngày nghỉ bảo hiểm
        public string Ly_Do = null; // Lý do
        public string Ghi_Chu = null; // Ghi chú
    }
    #endregion
    #region NL_Bao_Hiem
    public class NL_Bao_Hiem
    {
        private string ConnectionString;
        public NL_Bao_Hiem(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_Bao_Hiem_Chi_Tiet Lay(int Ma_Bao_Hiem)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Bao_Hiem_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Bao_Hiem = new SqlParameter("@Ma_Bao_Hiem", SqlDbType.Int, 4);
                    pMa_Bao_Hiem.Value = Ma_Bao_Hiem;
                    myCommand.Parameters.Add(pMa_Bao_Hiem);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Bao_Hiem_Chi_Tiet");
                    NL_Bao_Hiem_Chi_Tiet myNL_Bao_Hiem_Chi_Tiet = new NL_Bao_Hiem_Chi_Tiet();
                    if (myDataSet.Tables["NL_Bao_Hiem_Chi_Tiet"] != null)
                    {
                        myNL_Bao_Hiem_Chi_Tiet.Ma_Bao_Hiem = Ma_Bao_Hiem;
                        myNL_Bao_Hiem_Chi_Tiet.Ma_Nhan_Vien = myDataSet.Tables["NL_Bao_Hiem_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Bao_Hiem_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] : (int?)null;
                        myNL_Bao_Hiem_Chi_Tiet.Tu_Ngay_Nghi_Thuc = myDataSet.Tables["NL_Bao_Hiem_Chi_Tiet"].Rows[0]["Tu_Ngay_Nghi_Thuc"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Bao_Hiem_Chi_Tiet"].Rows[0]["Tu_Ngay_Nghi_Thuc"] : (DateTime?)null;
                        myNL_Bao_Hiem_Chi_Tiet.Den_Ngay_Nghi_Thuc = myDataSet.Tables["NL_Bao_Hiem_Chi_Tiet"].Rows[0]["Den_Ngay_Nghi_Thuc"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Bao_Hiem_Chi_Tiet"].Rows[0]["Den_Ngay_Nghi_Thuc"] : (DateTime?)null;
                        myNL_Bao_Hiem_Chi_Tiet.Tu_Ngay_Nghi_Bao_Hiem = myDataSet.Tables["NL_Bao_Hiem_Chi_Tiet"].Rows[0]["Tu_Ngay_Nghi_Bao_Hiem"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Bao_Hiem_Chi_Tiet"].Rows[0]["Tu_Ngay_Nghi_Bao_Hiem"] : (DateTime?)null;
                        myNL_Bao_Hiem_Chi_Tiet.Den_Ngay_Nghi_Bao_Hiem = myDataSet.Tables["NL_Bao_Hiem_Chi_Tiet"].Rows[0]["Den_Ngay_Nghi_Bao_Hiem"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Bao_Hiem_Chi_Tiet"].Rows[0]["Den_Ngay_Nghi_Bao_Hiem"] : (DateTime?)null;
                        myNL_Bao_Hiem_Chi_Tiet.Ly_Do = myDataSet.Tables["NL_Bao_Hiem_Chi_Tiet"].Rows[0]["Ly_Do"] != DBNull.Value ? (string)myDataSet.Tables["NL_Bao_Hiem_Chi_Tiet"].Rows[0]["Ly_Do"] : (string)null;
                        myNL_Bao_Hiem_Chi_Tiet.Ghi_Chu = myDataSet.Tables["NL_Bao_Hiem_Chi_Tiet"].Rows[0]["Ghi_Chu"] != DBNull.Value ? (string)myDataSet.Tables["NL_Bao_Hiem_Chi_Tiet"].Rows[0]["Ghi_Chu"] : (string)null;
                    }
                    return myNL_Bao_Hiem_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Ma_Bao_Hiem = null, int? Ma_Nhan_Vien = null, DateTime? Tu_Ngay_Nghi_Thuc = null, DateTime? Den_Ngay_Nghi_Thuc = null, DateTime? Tu_Ngay_Nghi_Bao_Hiem = null, DateTime? Den_Ngay_Nghi_Bao_Hiem = null, string Ly_Do = null, string Ghi_Chu = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Bao_Hiem_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Bao_Hiem = new SqlParameter("@Ma_Bao_Hiem", SqlDbType.Int, 4);
                    pMa_Bao_Hiem.Value = Ma_Bao_Hiem;
                    myCommand.Parameters.Add(pMa_Bao_Hiem);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay_Nghi_Thuc = new SqlParameter("@Tu_Ngay_Nghi_Thuc", SqlDbType.DateTime, 8);
                    pTu_Ngay_Nghi_Thuc.Value = Tu_Ngay_Nghi_Thuc;
                    myCommand.Parameters.Add(pTu_Ngay_Nghi_Thuc);

                    SqlParameter pDen_Ngay_Nghi_Thuc = new SqlParameter("@Den_Ngay_Nghi_Thuc", SqlDbType.DateTime, 8);
                    pDen_Ngay_Nghi_Thuc.Value = Den_Ngay_Nghi_Thuc;
                    myCommand.Parameters.Add(pDen_Ngay_Nghi_Thuc);

                    SqlParameter pTu_Ngay_Nghi_Bao_Hiem = new SqlParameter("@Tu_Ngay_Nghi_Bao_Hiem", SqlDbType.DateTime, 8);
                    pTu_Ngay_Nghi_Bao_Hiem.Value = Tu_Ngay_Nghi_Bao_Hiem;
                    myCommand.Parameters.Add(pTu_Ngay_Nghi_Bao_Hiem);

                    SqlParameter pDen_Ngay_Nghi_Bao_Hiem = new SqlParameter("@Den_Ngay_Nghi_Bao_Hiem", SqlDbType.DateTime, 8);
                    pDen_Ngay_Nghi_Bao_Hiem.Value = Den_Ngay_Nghi_Bao_Hiem;
                    myCommand.Parameters.Add(pDen_Ngay_Nghi_Bao_Hiem);

                    SqlParameter pLy_Do = new SqlParameter("@Ly_Do", SqlDbType.NVarChar, 500);
                    pLy_Do.Value = Ly_Do;
                    myCommand.Parameters.Add(pLy_Do);

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
        public void Cap_Nhat(int? Ma_Bao_Hiem = null, int? Ma_Nhan_Vien = null, DateTime? Tu_Ngay_Nghi_Thuc = null, DateTime? Den_Ngay_Nghi_Thuc = null, DateTime? Tu_Ngay_Nghi_Bao_Hiem = null, DateTime? Den_Ngay_Nghi_Bao_Hiem = null, string Ly_Do = null, string Ghi_Chu = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Bao_Hiem_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Bao_Hiem = new SqlParameter("@Ma_Bao_Hiem", SqlDbType.Int, 4);
                    pMa_Bao_Hiem.Value = Ma_Bao_Hiem;
                    myCommand.Parameters.Add(pMa_Bao_Hiem);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay_Nghi_Thuc = new SqlParameter("@Tu_Ngay_Nghi_Thuc", SqlDbType.DateTime, 8);
                    pTu_Ngay_Nghi_Thuc.Value = Tu_Ngay_Nghi_Thuc;
                    myCommand.Parameters.Add(pTu_Ngay_Nghi_Thuc);

                    SqlParameter pDen_Ngay_Nghi_Thuc = new SqlParameter("@Den_Ngay_Nghi_Thuc", SqlDbType.DateTime, 8);
                    pDen_Ngay_Nghi_Thuc.Value = Den_Ngay_Nghi_Thuc;
                    myCommand.Parameters.Add(pDen_Ngay_Nghi_Thuc);

                    SqlParameter pTu_Ngay_Nghi_Bao_Hiem = new SqlParameter("@Tu_Ngay_Nghi_Bao_Hiem", SqlDbType.DateTime, 8);
                    pTu_Ngay_Nghi_Bao_Hiem.Value = Tu_Ngay_Nghi_Bao_Hiem;
                    myCommand.Parameters.Add(pTu_Ngay_Nghi_Bao_Hiem);

                    SqlParameter pDen_Ngay_Nghi_Bao_Hiem = new SqlParameter("@Den_Ngay_Nghi_Bao_Hiem", SqlDbType.DateTime, 8);
                    pDen_Ngay_Nghi_Bao_Hiem.Value = Den_Ngay_Nghi_Bao_Hiem;
                    myCommand.Parameters.Add(pDen_Ngay_Nghi_Bao_Hiem);

                    SqlParameter pLy_Do = new SqlParameter("@Ly_Do", SqlDbType.NVarChar, 500);
                    pLy_Do.Value = Ly_Do;
                    myCommand.Parameters.Add(pLy_Do);

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
        public void Cap_Nhat(NL_Bao_Hiem_Chi_Tiet myNL_Bao_Hiem_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Bao_Hiem_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Bao_Hiem = new SqlParameter("@Ma_Bao_Hiem", SqlDbType.Int, 4);
                    pMa_Bao_Hiem.Value = myNL_Bao_Hiem_Chi_Tiet.Ma_Bao_Hiem;
                    myCommand.Parameters.Add(pMa_Bao_Hiem);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = myNL_Bao_Hiem_Chi_Tiet.Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay_Nghi_Thuc = new SqlParameter("@Tu_Ngay_Nghi_Thuc", SqlDbType.DateTime, 8);
                    pTu_Ngay_Nghi_Thuc.Value = myNL_Bao_Hiem_Chi_Tiet.Tu_Ngay_Nghi_Thuc;
                    myCommand.Parameters.Add(pTu_Ngay_Nghi_Thuc);

                    SqlParameter pDen_Ngay_Nghi_Thuc = new SqlParameter("@Den_Ngay_Nghi_Thuc", SqlDbType.DateTime, 8);
                    pDen_Ngay_Nghi_Thuc.Value = myNL_Bao_Hiem_Chi_Tiet.Den_Ngay_Nghi_Thuc;
                    myCommand.Parameters.Add(pDen_Ngay_Nghi_Thuc);

                    SqlParameter pTu_Ngay_Nghi_Bao_Hiem = new SqlParameter("@Tu_Ngay_Nghi_Bao_Hiem", SqlDbType.DateTime, 8);
                    pTu_Ngay_Nghi_Bao_Hiem.Value = myNL_Bao_Hiem_Chi_Tiet.Tu_Ngay_Nghi_Bao_Hiem;
                    myCommand.Parameters.Add(pTu_Ngay_Nghi_Bao_Hiem);

                    SqlParameter pDen_Ngay_Nghi_Bao_Hiem = new SqlParameter("@Den_Ngay_Nghi_Bao_Hiem", SqlDbType.DateTime, 8);
                    pDen_Ngay_Nghi_Bao_Hiem.Value = myNL_Bao_Hiem_Chi_Tiet.Den_Ngay_Nghi_Bao_Hiem;
                    myCommand.Parameters.Add(pDen_Ngay_Nghi_Bao_Hiem);

                    SqlParameter pLy_Do = new SqlParameter("@Ly_Do", SqlDbType.NVarChar, 500);
                    pLy_Do.Value = myNL_Bao_Hiem_Chi_Tiet.Ly_Do;
                    myCommand.Parameters.Add(pLy_Do);

                    SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 500);
                    pGhi_Chu.Value = myNL_Bao_Hiem_Chi_Tiet.Ghi_Chu;
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
                using (SqlCommand myCommand = new SqlCommand("NL_Bao_Hiem_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Bao_Hiem = new SqlParameter("@Ma_Bao_Hiem", SqlDbType.Int, 4);
                        pMa_Bao_Hiem.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Bao_Hiem"];
                        myCommand.Parameters.Add(pMa_Bao_Hiem);

                        SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                        pMa_Nhan_Vien.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nhan_Vien"];
                        myCommand.Parameters.Add(pMa_Nhan_Vien);

                        SqlParameter pTu_Ngay_Nghi_Thuc = new SqlParameter("@Tu_Ngay_Nghi_Thuc", SqlDbType.DateTime, 8);
                        pTu_Ngay_Nghi_Thuc.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Tu_Ngay_Nghi_Thuc"];
                        myCommand.Parameters.Add(pTu_Ngay_Nghi_Thuc);

                        SqlParameter pDen_Ngay_Nghi_Thuc = new SqlParameter("@Den_Ngay_Nghi_Thuc", SqlDbType.DateTime, 8);
                        pDen_Ngay_Nghi_Thuc.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Den_Ngay_Nghi_Thuc"];
                        myCommand.Parameters.Add(pDen_Ngay_Nghi_Thuc);

                        SqlParameter pTu_Ngay_Nghi_Bao_Hiem = new SqlParameter("@Tu_Ngay_Nghi_Bao_Hiem", SqlDbType.DateTime, 8);
                        pTu_Ngay_Nghi_Bao_Hiem.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Tu_Ngay_Nghi_Bao_Hiem"];
                        myCommand.Parameters.Add(pTu_Ngay_Nghi_Bao_Hiem);

                        SqlParameter pDen_Ngay_Nghi_Bao_Hiem = new SqlParameter("@Den_Ngay_Nghi_Bao_Hiem", SqlDbType.DateTime, 8);
                        pDen_Ngay_Nghi_Bao_Hiem.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Den_Ngay_Nghi_Bao_Hiem"];
                        myCommand.Parameters.Add(pDen_Ngay_Nghi_Bao_Hiem);

                        SqlParameter pLy_Do = new SqlParameter("@Ly_Do", SqlDbType.NVarChar, 500);
                        pLy_Do.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ly_Do"];
                        myCommand.Parameters.Add(pLy_Do);

                        SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 500);
                        pGhi_Chu.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ghi_Chu"];
                        myCommand.Parameters.Add(pGhi_Chu);


                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int? Ma_Bao_Hiem = null, int? Ma_Nhan_Vien = null, DateTime? Tu_Ngay_Nghi_Thuc = null, DateTime? Den_Ngay_Nghi_Thuc = null, DateTime? Tu_Ngay_Nghi_Bao_Hiem = null, DateTime? Den_Ngay_Nghi_Bao_Hiem = null, string Ly_Do = null, string Ghi_Chu = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Bao_Hiem_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Bao_Hiem = new SqlParameter("@Ma_Bao_Hiem", SqlDbType.Int, 4);
                    pMa_Bao_Hiem.Value = Ma_Bao_Hiem;
                    myCommand.Parameters.Add(pMa_Bao_Hiem);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTu_Ngay_Nghi_Thuc = new SqlParameter("@Tu_Ngay_Nghi_Thuc", SqlDbType.DateTime, 8);
                    pTu_Ngay_Nghi_Thuc.Value = Tu_Ngay_Nghi_Thuc;
                    myCommand.Parameters.Add(pTu_Ngay_Nghi_Thuc);

                    SqlParameter pDen_Ngay_Nghi_Thuc = new SqlParameter("@Den_Ngay_Nghi_Thuc", SqlDbType.DateTime, 8);
                    pDen_Ngay_Nghi_Thuc.Value = Den_Ngay_Nghi_Thuc;
                    myCommand.Parameters.Add(pDen_Ngay_Nghi_Thuc);

                    SqlParameter pTu_Ngay_Nghi_Bao_Hiem = new SqlParameter("@Tu_Ngay_Nghi_Bao_Hiem", SqlDbType.DateTime, 8);
                    pTu_Ngay_Nghi_Bao_Hiem.Value = Tu_Ngay_Nghi_Bao_Hiem;
                    myCommand.Parameters.Add(pTu_Ngay_Nghi_Bao_Hiem);

                    SqlParameter pDen_Ngay_Nghi_Bao_Hiem = new SqlParameter("@Den_Ngay_Nghi_Bao_Hiem", SqlDbType.DateTime, 8);
                    pDen_Ngay_Nghi_Bao_Hiem.Value = Den_Ngay_Nghi_Bao_Hiem;
                    myCommand.Parameters.Add(pDen_Ngay_Nghi_Bao_Hiem);

                    SqlParameter pLy_Do = new SqlParameter("@Ly_Do", SqlDbType.NVarChar, 500);
                    pLy_Do.Value = Ly_Do;
                    myCommand.Parameters.Add(pLy_Do);

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
        public void Xoa(int Ma_Bao_Hiem)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Bao_Hiem_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Bao_Hiem = new SqlParameter("@Ma_Bao_Hiem", SqlDbType.Int, 4);
                    pMa_Bao_Hiem.Value = Ma_Bao_Hiem;
                    myCommand.Parameters.Add(pMa_Bao_Hiem);

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
                using (SqlCommand myCommand = new SqlCommand("NL_Bao_Hiem_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Bao_Hiem_Danh_Sach");
                    return myDataSet.Tables["NL_Bao_Hiem_Danh_Sach"];
                }
            }
        }
        #endregion

        #region Lay_Boi_NL_Nhan_Vien
        public DataTable Lay_Boi_NL_Nhan_Vien(int Ma_Nhan_Vien)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Bao_Hiem_Lay_Boi_NL_Nhan_Vien", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Bao_Hiem_Lay_Boi_NL_Nhan_Vien");
                    return myDataSet.Tables["NL_Bao_Hiem_Lay_Boi_NL_Nhan_Vien"];
                }
            }
        }
        #endregion

    }
    #endregion
}