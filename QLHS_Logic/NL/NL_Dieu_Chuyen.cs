using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region NL_Dieu_Chuyen_Details
    public class NL_Dieu_Chuyen_Chi_Tiet
    {
        public int? Ma_Dieu_Chuyen = null; // Mã điều chuyển
        public int? Ma_Nhan_Vien = null; // Mã nhân viên
        public int? Trang_Thai = null;
        public DateTime? Ngay_Dieu_Chuyen = null; // Ngày  điều chuyển
        public int? Ma_Phong_Hien_Tai = null; // Mã hiện tại
        public int? Ma_Don_Vi_Chuyen = null; // Mã đơn vị chuyển
        public int? Ma_Phong_Chuyen = null; // Mã phòng chuyển
        public string Ly_Do = null; // Lý do
        public string Chuc_Vu_Don_Vi_Truoc = null; // Lý do
        public DateTime? Ngay_Het_Han = null;
        public int? Ma_Don_Vi_Di = null;
    }
    #endregion
    #region NL_Dieu_Chuyen
    public class NL_Dieu_Chuyen
    {
        private string ConnectionString;
        public NL_Dieu_Chuyen(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_Dieu_Chuyen_Chi_Tiet Lay(int Ma_Dieu_Chuyen)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Dieu_Chuyen_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Dieu_Chuyen = new SqlParameter("@Ma_Dieu_Chuyen", SqlDbType.Int, 4);
                    pMa_Dieu_Chuyen.Value = Ma_Dieu_Chuyen;
                    myCommand.Parameters.Add(pMa_Dieu_Chuyen);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Dieu_Chuyen_Chi_Tiet");
                    NL_Dieu_Chuyen_Chi_Tiet myNL_Dieu_Chuyen_Chi_Tiet = new NL_Dieu_Chuyen_Chi_Tiet();
                    if (myDataSet.Tables["NL_Dieu_Chuyen_Chi_Tiet"] != null)
                    {
                        myNL_Dieu_Chuyen_Chi_Tiet.Ma_Dieu_Chuyen = Ma_Dieu_Chuyen;
                        myNL_Dieu_Chuyen_Chi_Tiet.Ma_Nhan_Vien = myDataSet.Tables["NL_Dieu_Chuyen_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Dieu_Chuyen_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] : (int?)null;
                        myNL_Dieu_Chuyen_Chi_Tiet.Trang_Thai = myDataSet.Tables["NL_Dieu_Chuyen_Chi_Tiet"].Rows[0]["Trang_Thai"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Dieu_Chuyen_Chi_Tiet"].Rows[0]["Trang_Thai"] : (int?)null;
                        myNL_Dieu_Chuyen_Chi_Tiet.Ngay_Dieu_Chuyen = myDataSet.Tables["NL_Dieu_Chuyen_Chi_Tiet"].Rows[0]["Ngay_Dieu_Chuyen"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Dieu_Chuyen_Chi_Tiet"].Rows[0]["Ngay_Dieu_Chuyen"] : (DateTime?)null;
                        myNL_Dieu_Chuyen_Chi_Tiet.Ma_Phong_Hien_Tai = myDataSet.Tables["NL_Dieu_Chuyen_Chi_Tiet"].Rows[0]["Ma_Phong_Hien_Tai"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Dieu_Chuyen_Chi_Tiet"].Rows[0]["Ma_Phong_Hien_Tai"] : (int?)null;
                        myNL_Dieu_Chuyen_Chi_Tiet.Ma_Don_Vi_Chuyen = myDataSet.Tables["NL_Dieu_Chuyen_Chi_Tiet"].Rows[0]["Ma_Don_Vi_Chuyen"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Dieu_Chuyen_Chi_Tiet"].Rows[0]["Ma_Don_Vi_Chuyen"] : (int?)null;
                        myNL_Dieu_Chuyen_Chi_Tiet.Ma_Phong_Chuyen = myDataSet.Tables["NL_Dieu_Chuyen_Chi_Tiet"].Rows[0]["Ma_Phong_Chuyen"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Dieu_Chuyen_Chi_Tiet"].Rows[0]["Ma_Phong_Chuyen"] : (int?)null;
                        myNL_Dieu_Chuyen_Chi_Tiet.Ly_Do = myDataSet.Tables["NL_Dieu_Chuyen_Chi_Tiet"].Rows[0]["Ly_Do"] != DBNull.Value ? (string)myDataSet.Tables["NL_Dieu_Chuyen_Chi_Tiet"].Rows[0]["Ly_Do"] : (string)null;
                        myNL_Dieu_Chuyen_Chi_Tiet.Chuc_Vu_Don_Vi_Truoc = myDataSet.Tables["NL_Dieu_Chuyen_Chi_Tiet"].Rows[0]["Chuc_Vu_Don_Vi_Truoc"] != DBNull.Value ? (string)myDataSet.Tables["NL_Dieu_Chuyen_Chi_Tiet"].Rows[0]["Chuc_Vu_Don_Vi_Truoc"] : (string)null;
                        myNL_Dieu_Chuyen_Chi_Tiet.Ngay_Het_Han = myDataSet.Tables["NL_Dieu_Chuyen_Chi_Tiet"].Rows[0]["Ngay_Het_Han"] != DBNull.Value ? (DateTime?)myDataSet.Tables["NL_Dieu_Chuyen_Chi_Tiet"].Rows[0]["Ngay_Het_Han"] : (DateTime?)null;

                        myNL_Dieu_Chuyen_Chi_Tiet.Ma_Don_Vi_Di = myDataSet.Tables["NL_Dieu_Chuyen_Chi_Tiet"].Rows[0]["Ma_Don_Vi_Di"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Dieu_Chuyen_Chi_Tiet"].Rows[0]["Ma_Don_Vi_Di"] : (int?)null;
                    }
                    return myNL_Dieu_Chuyen_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Ma_Dieu_Chuyen = null, int? Ma_Nhan_Vien = null, int? Trang_Thai = null, DateTime? Ngay_Dieu_Chuyen = null, int? Ma_Phong_Hien_Tai = null,
            int? Ma_Don_Vi_Chuyen = null, int? Ma_Phong_Chuyen = null, string Ly_Do = null, string Chuc_Vu_Don_Vi_Truoc = null, DateTime? Ngay_Het_Han = null
            , int? Ma_Don_Vi_Di=null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Dieu_Chuyen_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Dieu_Chuyen = new SqlParameter("@Ma_Dieu_Chuyen", SqlDbType.Int, 4);
                    pMa_Dieu_Chuyen.Value = Ma_Dieu_Chuyen;
                    myCommand.Parameters.Add(pMa_Dieu_Chuyen);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);
                    SqlParameter pTrang_Thai = new SqlParameter("@Trang_Thai", SqlDbType.Int, 4);
                    pTrang_Thai.Value = Trang_Thai;
                    myCommand.Parameters.Add(pTrang_Thai);

                    SqlParameter pNgay_Dieu_Chuyen = new SqlParameter("@Ngay_Dieu_Chuyen", SqlDbType.DateTime, 8);
                    pNgay_Dieu_Chuyen.Value = Ngay_Dieu_Chuyen;
                    myCommand.Parameters.Add(pNgay_Dieu_Chuyen);

                    SqlParameter pMa_Phong_Hien_Tai = new SqlParameter("@Ma_Phong_Hien_Tai", SqlDbType.Int, 4);
                    pMa_Phong_Hien_Tai.Value = Ma_Phong_Hien_Tai;
                    myCommand.Parameters.Add(pMa_Phong_Hien_Tai);

                    SqlParameter pMa_Don_Vi_Chuyen = new SqlParameter("@Ma_Don_Vi_Chuyen", SqlDbType.Int, 4);
                    pMa_Don_Vi_Chuyen.Value = Ma_Don_Vi_Chuyen;
                    myCommand.Parameters.Add(pMa_Don_Vi_Chuyen);

                    SqlParameter pMa_Phong_Chuyen = new SqlParameter("@Ma_Phong_Chuyen", SqlDbType.Int, 4);
                    pMa_Phong_Chuyen.Value = Ma_Phong_Chuyen;
                    myCommand.Parameters.Add(pMa_Phong_Chuyen);

                    SqlParameter pLy_Do = new SqlParameter("@Ly_Do", SqlDbType.NVarChar, 500);
                    pLy_Do.Value = Ly_Do;
                    myCommand.Parameters.Add(pLy_Do);

                    SqlParameter pChuc_Vu_Don_Vi_Truoc = new SqlParameter("@Chuc_Vu_Don_Vi_Truoc", SqlDbType.NVarChar, 300);
                    pChuc_Vu_Don_Vi_Truoc.Value = Chuc_Vu_Don_Vi_Truoc;
                    myCommand.Parameters.Add(pChuc_Vu_Don_Vi_Truoc);


                    SqlParameter pNgay_Het_Han = new SqlParameter("@Ngay_Het_Han", SqlDbType.DateTime, 8);
                    pNgay_Het_Han.Value = Ngay_Het_Han;
                    myCommand.Parameters.Add(pNgay_Het_Han);

                    SqlParameter pMa_Don_Vi_Di = new SqlParameter("@Ma_Don_Vi_Di", SqlDbType.Int, 4);
                    pMa_Don_Vi_Di.Value = Ma_Don_Vi_Di;
                    myCommand.Parameters.Add(pMa_Don_Vi_Di);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int? Ma_Dieu_Chuyen = null, int? Ma_Nhan_Vien = null, int? Trang_Thai = null, DateTime? Ngay_Dieu_Chuyen = null, int? Ma_Phong_Hien_Tai = null,
            int? Ma_Don_Vi_Chuyen = null, int? Ma_Phong_Chuyen = null, string Ly_Do = null, string Chuc_Vu_Don_Vi_Truoc = null, DateTime? Ngay_Het_Han=null
            , int? Ma_Don_Vi_Di = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Dieu_Chuyen_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Dieu_Chuyen = new SqlParameter("@Ma_Dieu_Chuyen", SqlDbType.Int, 4);
                    pMa_Dieu_Chuyen.Value = Ma_Dieu_Chuyen;
                    myCommand.Parameters.Add(pMa_Dieu_Chuyen);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTrang_Thai = new SqlParameter("@Trang_Thai", SqlDbType.Int, 4);
                    pTrang_Thai.Value = Trang_Thai;
                    myCommand.Parameters.Add(pTrang_Thai);

                    SqlParameter pNgay_Dieu_Chuyen = new SqlParameter("@Ngay_Dieu_Chuyen", SqlDbType.DateTime, 8);
                    pNgay_Dieu_Chuyen.Value = Ngay_Dieu_Chuyen;
                    myCommand.Parameters.Add(pNgay_Dieu_Chuyen);

                    SqlParameter pMa_Phong_Hien_Tai = new SqlParameter("@Ma_Phong_Hien_Tai", SqlDbType.Int, 4);
                    pMa_Phong_Hien_Tai.Value = Ma_Phong_Hien_Tai;
                    myCommand.Parameters.Add(pMa_Phong_Hien_Tai);

                    SqlParameter pMa_Don_Vi_Chuyen = new SqlParameter("@Ma_Don_Vi_Chuyen", SqlDbType.Int, 4);
                    pMa_Don_Vi_Chuyen.Value = Ma_Don_Vi_Chuyen;
                    myCommand.Parameters.Add(pMa_Don_Vi_Chuyen);

                    SqlParameter pMa_Phong_Chuyen = new SqlParameter("@Ma_Phong_Chuyen", SqlDbType.Int, 4);
                    pMa_Phong_Chuyen.Value = Ma_Phong_Chuyen;
                    myCommand.Parameters.Add(pMa_Phong_Chuyen);

                    SqlParameter pLy_Do = new SqlParameter("@Ly_Do", SqlDbType.NVarChar, 500);
                    pLy_Do.Value = Ly_Do;
                    myCommand.Parameters.Add(pLy_Do);

                    SqlParameter pChuc_Vu_Don_Vi_Truoc = new SqlParameter("@Chuc_Vu_Don_Vi_Truoc", SqlDbType.NVarChar, 300);
                    pChuc_Vu_Don_Vi_Truoc.Value = Chuc_Vu_Don_Vi_Truoc;
                    myCommand.Parameters.Add(pChuc_Vu_Don_Vi_Truoc);


                    SqlParameter pNgay_Het_Han = new SqlParameter("@Ngay_Het_Han", SqlDbType.DateTime, 8);
                    pNgay_Het_Han.Value = Ngay_Het_Han;
                    myCommand.Parameters.Add(pNgay_Het_Han);

                    SqlParameter pMa_Don_Vi_Di = new SqlParameter("@Ma_Don_Vi_Di", SqlDbType.Int, 4);
                    pMa_Don_Vi_Di.Value = Ma_Don_Vi_Di;
                    myCommand.Parameters.Add(pMa_Don_Vi_Di);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(NL_Dieu_Chuyen_Chi_Tiet myNL_Dieu_Chuyen_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Dieu_Chuyen_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Dieu_Chuyen = new SqlParameter("@Ma_Dieu_Chuyen", SqlDbType.Int, 4);
                    pMa_Dieu_Chuyen.Value = myNL_Dieu_Chuyen_Chi_Tiet.Ma_Dieu_Chuyen;
                    myCommand.Parameters.Add(pMa_Dieu_Chuyen);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = myNL_Dieu_Chuyen_Chi_Tiet.Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTrang_Thai = new SqlParameter("@Trang_Thai", SqlDbType.Int, 4);
                    pTrang_Thai.Value = myNL_Dieu_Chuyen_Chi_Tiet.Trang_Thai;
                    myCommand.Parameters.Add(pTrang_Thai);

                    SqlParameter pNgay_Dieu_Chuyen = new SqlParameter("@Ngay_Dieu_Chuyen", SqlDbType.DateTime, 8);
                    pNgay_Dieu_Chuyen.Value = myNL_Dieu_Chuyen_Chi_Tiet.Ngay_Dieu_Chuyen;
                    myCommand.Parameters.Add(pNgay_Dieu_Chuyen);

                    SqlParameter pMa_Phong_Hien_Tai = new SqlParameter("@Ma_Phong_Hien_Tai", SqlDbType.Int, 4);
                    pMa_Phong_Hien_Tai.Value = myNL_Dieu_Chuyen_Chi_Tiet.Ma_Phong_Hien_Tai;
                    myCommand.Parameters.Add(pMa_Phong_Hien_Tai);

                    SqlParameter pMa_Don_Vi_Chuyen = new SqlParameter("@Ma_Don_Vi_Chuyen", SqlDbType.Int, 4);
                    pMa_Don_Vi_Chuyen.Value = myNL_Dieu_Chuyen_Chi_Tiet.Ma_Don_Vi_Chuyen;
                    myCommand.Parameters.Add(pMa_Don_Vi_Chuyen);

                    SqlParameter pMa_Phong_Chuyen = new SqlParameter("@Ma_Phong_Chuyen", SqlDbType.Int, 4);
                    pMa_Phong_Chuyen.Value = myNL_Dieu_Chuyen_Chi_Tiet.Ma_Phong_Chuyen;
                    myCommand.Parameters.Add(pMa_Phong_Chuyen);

                    SqlParameter pLy_Do = new SqlParameter("@Ly_Do", SqlDbType.NVarChar, 500);
                    pLy_Do.Value = myNL_Dieu_Chuyen_Chi_Tiet.Ly_Do;
                    myCommand.Parameters.Add(pLy_Do);

                    SqlParameter pChuc_Vu_Don_Vi_Truoc = new SqlParameter("@Chuc_Vu_Don_Vi_Truoc", SqlDbType.NVarChar, 300);
                    pChuc_Vu_Don_Vi_Truoc.Value = myNL_Dieu_Chuyen_Chi_Tiet.Chuc_Vu_Don_Vi_Truoc;
                    myCommand.Parameters.Add(pChuc_Vu_Don_Vi_Truoc);

                    SqlParameter pNgay_Het_Han = new SqlParameter("@Ngay_Het_Han", SqlDbType.DateTime, 8);
                    pNgay_Het_Han.Value = myNL_Dieu_Chuyen_Chi_Tiet.Ngay_Het_Han;
                    myCommand.Parameters.Add(pNgay_Het_Han);

                    SqlParameter pMa_Don_Vi_Di = new SqlParameter("@Ma_Don_Vi_Di", SqlDbType.Int, 4);
                    pMa_Don_Vi_Di.Value = myNL_Dieu_Chuyen_Chi_Tiet.Ma_Don_Vi_Di;
                    myCommand.Parameters.Add(pMa_Don_Vi_Di);

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
                using (SqlCommand myCommand = new SqlCommand("NL_Dieu_Chuyen_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Dieu_Chuyen = new SqlParameter("@Ma_Dieu_Chuyen", SqlDbType.Int, 4);
                        pMa_Dieu_Chuyen.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Dieu_Chuyen"];
                        myCommand.Parameters.Add(pMa_Dieu_Chuyen);

                        SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                        pMa_Nhan_Vien.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nhan_Vien"];
                        myCommand.Parameters.Add(pMa_Nhan_Vien);

                        SqlParameter pTrang_Thai = new SqlParameter("@Trang_Thai", SqlDbType.Int, 4);
                        pTrang_Thai.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Trang_Thai"];
                        myCommand.Parameters.Add(pTrang_Thai);

                        SqlParameter pNgay_Dieu_Chuyen = new SqlParameter("@Ngay_Dieu_Chuyen", SqlDbType.DateTime, 8);
                        pNgay_Dieu_Chuyen.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Ngay_Dieu_Chuyen"];
                        myCommand.Parameters.Add(pNgay_Dieu_Chuyen);

                        SqlParameter pMa_Phong_Hien_Tai = new SqlParameter("@Ma_Phong_Hien_Tai", SqlDbType.Int, 4);
                        pMa_Phong_Hien_Tai.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Phong_Hien_Tai"];
                        myCommand.Parameters.Add(pMa_Phong_Hien_Tai);

                        SqlParameter pMa_Don_Vi_Chuyen = new SqlParameter("@Ma_Don_Vi_Chuyen", SqlDbType.Int, 4);
                        pMa_Don_Vi_Chuyen.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Don_Vi_Chuyen"];
                        myCommand.Parameters.Add(pMa_Don_Vi_Chuyen);

                        SqlParameter pMa_Phong_Chuyen = new SqlParameter("@Ma_Phong_Chuyen", SqlDbType.Int, 4);
                        pMa_Phong_Chuyen.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Phong_Chuyen"];
                        myCommand.Parameters.Add(pMa_Phong_Chuyen);

                        SqlParameter pLy_Do = new SqlParameter("@Ly_Do", SqlDbType.NVarChar, 500);
                        pLy_Do.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ly_Do"];
                        myCommand.Parameters.Add(pLy_Do);

                        SqlParameter pChuc_Vu_Don_Vi_Truoc = new SqlParameter("@Chuc_Vu_Don_Vi_Truoc", SqlDbType.NVarChar, 300);
                        pChuc_Vu_Don_Vi_Truoc.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Chuc_Vu_Don_Vi_Truoc"];
                        myCommand.Parameters.Add(pChuc_Vu_Don_Vi_Truoc);


                        SqlParameter pNgay_Het_Han = new SqlParameter("@Ngay_Het_Han", SqlDbType.DateTime, 8);
                        pNgay_Het_Han.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Ngay_Het_Han"];
                        myCommand.Parameters.Add(pNgay_Het_Han);
                        SqlParameter pMa_Don_Vi_Di = new SqlParameter("@Ma_Don_Vi_Di", SqlDbType.Int, 4);
                        pMa_Don_Vi_Di.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Don_Vi_Di"];
                        myCommand.Parameters.Add(pMa_Don_Vi_Di);

                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int? Ma_Dieu_Chuyen = null, int? Ma_Nhan_Vien = null, int? Trang_Thai = null, DateTime? Ngay_Dieu_Chuyen = null,
            int? Ma_Phong_Hien_Tai = null, int? Ma_Don_Vi_Chuyen = null, int? Ma_Phong_Chuyen = null, string Ly_Do = null, string Chuc_Vu_Don_Vi_Truoc = null,
            DateTime? Ngay_Het_Han = null, int? Ma_Don_Vi_Di = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Dieu_Chuyen_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Dieu_Chuyen = new SqlParameter("@Ma_Dieu_Chuyen", SqlDbType.Int, 4);
                    pMa_Dieu_Chuyen.Value = Ma_Dieu_Chuyen;
                    myCommand.Parameters.Add(pMa_Dieu_Chuyen);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pTrang_Thai = new SqlParameter("@Trang_Thai", SqlDbType.Int, 4);
                    pTrang_Thai.Value = Trang_Thai;
                    myCommand.Parameters.Add(pTrang_Thai);

                    SqlParameter pNgay_Dieu_Chuyen = new SqlParameter("@Ngay_Dieu_Chuyen", SqlDbType.DateTime, 8);
                    pNgay_Dieu_Chuyen.Value = Ngay_Dieu_Chuyen;
                    myCommand.Parameters.Add(pNgay_Dieu_Chuyen);

                    SqlParameter pMa_Phong_Hien_Tai = new SqlParameter("@Ma_Phong_Hien_Tai", SqlDbType.Int, 4);
                    pMa_Phong_Hien_Tai.Value = Ma_Phong_Hien_Tai;
                    myCommand.Parameters.Add(pMa_Phong_Hien_Tai);

                    SqlParameter pMa_Don_Vi_Chuyen = new SqlParameter("@Ma_Don_Vi_Chuyen", SqlDbType.Int, 4);
                    pMa_Don_Vi_Chuyen.Value = Ma_Don_Vi_Chuyen;
                    myCommand.Parameters.Add(pMa_Don_Vi_Chuyen);

                    SqlParameter pMa_Phong_Chuyen = new SqlParameter("@Ma_Phong_Chuyen", SqlDbType.Int, 4);
                    pMa_Phong_Chuyen.Value = Ma_Phong_Chuyen;
                    myCommand.Parameters.Add(pMa_Phong_Chuyen);

                    SqlParameter pLy_Do = new SqlParameter("@Ly_Do", SqlDbType.NVarChar, 500);
                    pLy_Do.Value = Ly_Do;
                    myCommand.Parameters.Add(pLy_Do);

                    SqlParameter pChuc_Vu_Don_Vi_Truoc = new SqlParameter("@Chuc_Vu_Don_Vi_Truoc", SqlDbType.NVarChar, 300);
                    pChuc_Vu_Don_Vi_Truoc.Value = Chuc_Vu_Don_Vi_Truoc;
                    myCommand.Parameters.Add(pChuc_Vu_Don_Vi_Truoc);

                    SqlParameter pNgay_Het_Han = new SqlParameter("@Ngay_Het_Han", SqlDbType.DateTime, 8);
                    pNgay_Het_Han.Value = Ngay_Het_Han;
                    myCommand.Parameters.Add(pNgay_Het_Han);

                    SqlParameter pMa_Don_Vi_Di = new SqlParameter("@Ma_Don_Vi_Di", SqlDbType.Int, 4);
                    pMa_Don_Vi_Di.Value = Ma_Don_Vi_Di;
                    myCommand.Parameters.Add(pMa_Don_Vi_Di);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Ma_Dieu_Chuyen)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Dieu_Chuyen_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Dieu_Chuyen = new SqlParameter("@Ma_Dieu_Chuyen", SqlDbType.Int, 4);
                    pMa_Dieu_Chuyen.Value = Ma_Dieu_Chuyen;
                    myCommand.Parameters.Add(pMa_Dieu_Chuyen);

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
                using (SqlCommand myCommand = new SqlCommand("NL_Dieu_Chuyen_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Dieu_Chuyen_Danh_Sach");
                    return myDataSet.Tables["NL_Dieu_Chuyen_Danh_Sach"];
                }
            }
        }
        #endregion

        #region Lay_Boi_NL_Nhan_Vien
        public DataTable Lay_Boi_NL_Nhan_Vien(int Ma_Nhan_Vien)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Dieu_Chuyen_Lay_Boi_NL_Nhan_Vien", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Dieu_Chuyen_Lay_Boi_NL_Nhan_Vien");
                    return myDataSet.Tables["NL_Dieu_Chuyen_Lay_Boi_NL_Nhan_Vien"];
                }
            }
        }
        #endregion

    }
    #endregion
}