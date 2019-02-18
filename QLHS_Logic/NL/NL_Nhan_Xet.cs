using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region NL_Nhan_Xet_Details
    public class NL_Nhan_Xet_Chi_Tiet
    {
        public int? Ma_Nhan_Xet = null; // Mã nhận xét
        public int? Ma_Nhan_Vien = null; // Mã nhân viên
        public string Nhiem_Vu = null; // Nhiệm vụ
        public string Nhan_Xet = null; // Nhận xét
        public int? Nam = null;
        public int? Xep_Loai = null;
        public string File_Ban_Nhan_Xet = null;
    }
    #endregion
    #region NL_Nhan_Xet
    public class NL_Nhan_Xet
    {
        private string ConnectionString;
        public NL_Nhan_Xet(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public NL_Nhan_Xet_Chi_Tiet Lay(int Ma_Nhan_Xet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Xet_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Xet = new SqlParameter("@Ma_Nhan_Xet", SqlDbType.Int, 4);
                    pMa_Nhan_Xet.Value = Ma_Nhan_Xet;
                    myCommand.Parameters.Add(pMa_Nhan_Xet);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Nhan_Xet_Chi_Tiet");
                    NL_Nhan_Xet_Chi_Tiet myNL_Nhan_Xet_Chi_Tiet = new NL_Nhan_Xet_Chi_Tiet();
                    if (myDataSet.Tables["NL_Nhan_Xet_Chi_Tiet"] != null)
                    {
                        myNL_Nhan_Xet_Chi_Tiet.Ma_Nhan_Xet = Ma_Nhan_Xet;
                        myNL_Nhan_Xet_Chi_Tiet.Ma_Nhan_Vien = myDataSet.Tables["NL_Nhan_Xet_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Nhan_Xet_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"] : (int?)null;
                        myNL_Nhan_Xet_Chi_Tiet.Nhiem_Vu = myDataSet.Tables["NL_Nhan_Xet_Chi_Tiet"].Rows[0]["Nhiem_Vu"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Xet_Chi_Tiet"].Rows[0]["Nhiem_Vu"] : (string)null;
                        myNL_Nhan_Xet_Chi_Tiet.Nhan_Xet = myDataSet.Tables["NL_Nhan_Xet_Chi_Tiet"].Rows[0]["Nhan_Xet"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Xet_Chi_Tiet"].Rows[0]["Nhan_Xet"] : (string)null;
                        myNL_Nhan_Xet_Chi_Tiet.Nam = myDataSet.Tables["NL_Nhan_Xet_Chi_Tiet"].Rows[0]["Nam"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Nhan_Xet_Chi_Tiet"].Rows[0]["Nam"] : (int?)null;
                        myNL_Nhan_Xet_Chi_Tiet.Xep_Loai = myDataSet.Tables["NL_Nhan_Xet_Chi_Tiet"].Rows[0]["Xep_Loai"] != DBNull.Value ? (int?)myDataSet.Tables["NL_Nhan_Xet_Chi_Tiet"].Rows[0]["Xep_Loai"] : (int?)null;
                        myNL_Nhan_Xet_Chi_Tiet.File_Ban_Nhan_Xet = myDataSet.Tables["NL_Nhan_Xet_Chi_Tiet"].Rows[0]["File_Ban_Nhan_Xet"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Xet_Chi_Tiet"].Rows[0]["File_Ban_Nhan_Xet"] : (string)null;
                    }
                    return myNL_Nhan_Xet_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? Ma_Nhan_Xet = null, int? Ma_Nhan_Vien = null, string Nhiem_Vu = null, string Nhan_Xet = null, int? Nam = null, int? Xep_Loai = null, string File_Ban_Nhan_Xet = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Xet_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Xet = new SqlParameter("@Ma_Nhan_Xet", SqlDbType.Int, 4);
                    pMa_Nhan_Xet.Value = Ma_Nhan_Xet;
                    myCommand.Parameters.Add(pMa_Nhan_Xet);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pNhiem_Vu = new SqlParameter("@Nhiem_Vu", SqlDbType.NText);
                    pNhiem_Vu.Value = Nhiem_Vu;
                    myCommand.Parameters.Add(pNhiem_Vu);

                    SqlParameter pNhan_Xet = new SqlParameter("@Nhan_Xet", SqlDbType.NText);
                    pNhan_Xet.Value = Nhan_Xet;
                    myCommand.Parameters.Add(pNhan_Xet);

                    SqlParameter pNam = new SqlParameter("@Nam", SqlDbType.Int, 4);
                    pNam.Value = Nam;
                    myCommand.Parameters.Add(pNam);

                    SqlParameter pXep_Loai = new SqlParameter("@Xep_Loai", SqlDbType.Int, 4);
                    pXep_Loai.Value = Xep_Loai;
                    myCommand.Parameters.Add(pXep_Loai);

                    SqlParameter pFile_Ban_Nhan_Xet = new SqlParameter("@File_Ban_Nhan_Xet", SqlDbType.NVarChar, 350);
                    pFile_Ban_Nhan_Xet.Value = File_Ban_Nhan_Xet;
                    myCommand.Parameters.Add(pFile_Ban_Nhan_Xet);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int? Ma_Nhan_Xet = null, int? Ma_Nhan_Vien = null, string Nhiem_Vu = null, string Nhan_Xet = null, int? Nam = null, int? Xep_Loai = null, string File_Ban_Nhan_Xet = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Xet_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Nhan_Xet = new SqlParameter("@Ma_Nhan_Xet", SqlDbType.Int, 4);
                    pMa_Nhan_Xet.Value = Ma_Nhan_Xet;
                    myCommand.Parameters.Add(pMa_Nhan_Xet);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pNhiem_Vu = new SqlParameter("@Nhiem_Vu", SqlDbType.NText);
                    pNhiem_Vu.Value = Nhiem_Vu;
                    myCommand.Parameters.Add(pNhiem_Vu);

                    SqlParameter pNhan_Xet = new SqlParameter("@Nhan_Xet", SqlDbType.NText);
                    pNhan_Xet.Value = Nhan_Xet;
                    myCommand.Parameters.Add(pNhan_Xet);

                    SqlParameter pNam = new SqlParameter("@Nam", SqlDbType.Int, 4);
                    pNam.Value = Nam;
                    myCommand.Parameters.Add(pNam);

                    SqlParameter pXep_Loai = new SqlParameter("@Xep_Loai", SqlDbType.Int, 4);
                    pXep_Loai.Value = Xep_Loai;
                    myCommand.Parameters.Add(pXep_Loai);

                    SqlParameter pFile_Ban_Nhan_Xet = new SqlParameter("@File_Ban_Nhan_Xet", SqlDbType.NVarChar, 350);
                    pFile_Ban_Nhan_Xet.Value = File_Ban_Nhan_Xet;
                    myCommand.Parameters.Add(pFile_Ban_Nhan_Xet);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(NL_Nhan_Xet_Chi_Tiet myNL_Nhan_Xet_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Xet_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Xet = new SqlParameter("@Ma_Nhan_Xet", SqlDbType.Int, 4);
                    pMa_Nhan_Xet.Value = myNL_Nhan_Xet_Chi_Tiet.Ma_Nhan_Xet;
                    myCommand.Parameters.Add(pMa_Nhan_Xet);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = myNL_Nhan_Xet_Chi_Tiet.Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pNhiem_Vu = new SqlParameter("@Nhiem_Vu", SqlDbType.NText);
                    pNhiem_Vu.Value = myNL_Nhan_Xet_Chi_Tiet.Nhiem_Vu;
                    myCommand.Parameters.Add(pNhiem_Vu);

                    SqlParameter pNhan_Xet = new SqlParameter("@Nhan_Xet", SqlDbType.NText);
                    pNhan_Xet.Value = myNL_Nhan_Xet_Chi_Tiet.Nhan_Xet;
                    myCommand.Parameters.Add(pNhan_Xet);

                    SqlParameter pNam = new SqlParameter("@Nam", SqlDbType.Int, 4);
                    pNam.Value = myNL_Nhan_Xet_Chi_Tiet.Nam;
                    myCommand.Parameters.Add(pNam);

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
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Xet_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Nhan_Xet = new SqlParameter("@Ma_Nhan_Xet", SqlDbType.Int, 4);
                        pMa_Nhan_Xet.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nhan_Xet"];
                        myCommand.Parameters.Add(pMa_Nhan_Xet);

                        SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                        pMa_Nhan_Vien.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nhan_Vien"];
                        myCommand.Parameters.Add(pMa_Nhan_Vien);

                        SqlParameter pNhiem_Vu = new SqlParameter("@Nhiem_Vu", SqlDbType.NText);
                        pNhiem_Vu.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Nhiem_Vu"];
                        myCommand.Parameters.Add(pNhiem_Vu);

                        SqlParameter pNhan_Xet = new SqlParameter("@Nhan_Xet", SqlDbType.NText);
                        pNhan_Xet.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Nhan_Xet"];
                        myCommand.Parameters.Add(pNhan_Xet);

                        SqlParameter pNam = new SqlParameter("@Nam", SqlDbType.Int, 4);
                        pNam.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Nam"];
                        myCommand.Parameters.Add(pNam);

                        SqlParameter pXep_Loai = new SqlParameter("@Xep_Loai", SqlDbType.Int, 4);
                        pXep_Loai.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Xep_Loai"];
                        myCommand.Parameters.Add(pXep_Loai);

                        SqlParameter pFile_Ban_Nhan_Xet = new SqlParameter("@File_Ban_Nhan_Xet", SqlDbType.NVarChar);
                        pFile_Ban_Nhan_Xet.Value = (string)myDataSet.Tables[strTableName].Rows[i]["File_Ban_Nhan_Xet"];
                        myCommand.Parameters.Add(pFile_Ban_Nhan_Xet);

                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int? Ma_Nhan_Xet = null, int? Ma_Nhan_Vien = null, string Nhiem_Vu = null, string Nhan_Xet = null, int? Nam = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Xet_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Xet = new SqlParameter("@Ma_Nhan_Xet", SqlDbType.Int, 4);
                    pMa_Nhan_Xet.Value = Ma_Nhan_Xet;
                    myCommand.Parameters.Add(pMa_Nhan_Xet);

                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    SqlParameter pNhiem_Vu = new SqlParameter("@Nhiem_Vu", SqlDbType.NText);
                    pNhiem_Vu.Value = Nhiem_Vu;
                    myCommand.Parameters.Add(pNhiem_Vu);

                    SqlParameter pNhan_Xet = new SqlParameter("@Nhan_Xet", SqlDbType.NText);
                    pNhan_Xet.Value = Nhan_Xet;
                    myCommand.Parameters.Add(pNhan_Xet);

                    SqlParameter pNam = new SqlParameter("@Nam", SqlDbType.Int, 4);
                    pNam.Value = Nam;
                    myCommand.Parameters.Add(pNam);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Ma_Nhan_Xet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Xet_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nhan_Xet = new SqlParameter("@Ma_Nhan_Xet", SqlDbType.Int, 4);
                    pMa_Nhan_Xet.Value = Ma_Nhan_Xet;
                    myCommand.Parameters.Add(pMa_Nhan_Xet);

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
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Xet_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Nhan_Xet_Danh_Sach");
                    return myDataSet.Tables["NL_Nhan_Xet_Danh_Sach"];
                }
            }
        }
        #endregion

        #region Lay_Boi_NL_Nhan_Vien
        public DataTable Lay_Boi_NL_Nhan_Vien(int Ma_Nhan_Vien)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Xet_Lay_Boi_NL_Nhan_Vien", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien", SqlDbType.Int, 4);
                    pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
                    myCommand.Parameters.Add(pMa_Nhan_Vien);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_Nhan_Xet_Lay_Boi_NL_Nhan_Vien");
                    return myDataSet.Tables["NL_Nhan_Xet_Lay_Boi_NL_Nhan_Vien"];
                }
            }
        }
        #endregion

    }
    #endregion
}