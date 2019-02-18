using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QLHS_Logic
{
    #region 
    public class DM_HinhThucKhenThuong_Chi_Tiet
    {
        public int? id=null;
        public string makhenthuong=null;
        public string tenkhenthuong=null;
        public string ghichu=null;
    }
    #endregion

    #region
    public class DM_HinhThucKhenThuong
    {
        private string ConnectionString;
        public DM_HinhThucKhenThuong(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }

        #region Lay
        public DM_HinhThucKhenThuong_Chi_Tiet Lay(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DM_HinhThucKhenThuong__Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pId = new SqlParameter("@id", SqlDbType.Int, 4);
                    pId.Value = id;
                    myCommand.Parameters.Add(pId);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "DM_HinhThucKhenThuong_Chi_Tiet");
                    DM_HinhThucKhenThuong_Chi_Tiet myDM_HinhThucKhenThuong_Chi_Tiet = new DM_HinhThucKhenThuong_Chi_Tiet();
                    if (myDataSet.Tables["DM_HinhThucKhenThuong_Chi_Tiet"] != null)
                    {

                        myDM_HinhThucKhenThuong_Chi_Tiet.id = myDataSet.Tables["DM_HinhThucKhenThuong_Chi_Tiet"].Rows[0]["id"] != DBNull.Value ? (int?)myDataSet.Tables["DM_HinhThucKhenThuong_Chi_Tiet"].Rows[0]["id"] : (int?)null;
                        myDM_HinhThucKhenThuong_Chi_Tiet.makhenthuong = myDataSet.Tables["DM_HinhThucKhenThuong_Chi_Tiet"].Rows[0]["makhenthuong"] != DBNull.Value ? (string)myDataSet.Tables["DM_HinhThucKhenThuong_Chi_Tiet"].Rows[0]["makhenthuong"] : (string)null;
                        myDM_HinhThucKhenThuong_Chi_Tiet.tenkhenthuong = myDataSet.Tables["DM_HinhThucKhenThuong_Chi_Tiet"].Rows[0]["tenkhenthuong"] != DBNull.Value ? (string)myDataSet.Tables["DM_HinhThucKhenThuong_Chi_Tiet"].Rows[0]["tenkhenthuong"] : (string)null;
                        myDM_HinhThucKhenThuong_Chi_Tiet.ghichu = myDataSet.Tables["DM_HinhThucKhenThuong_Chi_Tiet"].Rows[0]["ghichu"] != DBNull.Value ? (string)myDataSet.Tables["DM_HinhThucKhenThuong_Chi_Tiet"].Rows[0]["ghichu"] : (string)null;
                    }
                    return myDM_HinhThucKhenThuong_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public void Them(int? id=null,string makhenthuong=null,string tenkhenthuong=null,string ghichu=null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DM_HinhThucKhenThuong_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pid = new SqlParameter("@id", SqlDbType.Int, 4);
                    pid.Value = id;
                    myCommand.Parameters.Add(pid);

                    SqlParameter pmakhenthuong = new SqlParameter("@makhenthuong", SqlDbType.NVarChar, 50);
                    pmakhenthuong.Value = makhenthuong;
                    myCommand.Parameters.Add(pmakhenthuong);

                    SqlParameter ptenkhenthuong = new SqlParameter("@tenkhenthuong", SqlDbType.NVarChar,250);
                    ptenkhenthuong.Value = tenkhenthuong;
                    myCommand.Parameters.Add(ptenkhenthuong);

                    SqlParameter pghichu = new SqlParameter("@ghichu", SqlDbType.NVarChar, 500);
                    pghichu.Value = ghichu;
                    myCommand.Parameters.Add(pghichu);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int? id = null, string makhenthuong = null, string tenkhenthuong = null, string ghichu = null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DM_HinhThucKhenThuong_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pid = new SqlParameter("@id", SqlDbType.Int, 4);
                    pid.Value = id;
                    myCommand.Parameters.Add(pid);

                    SqlParameter pmakhenthuong = new SqlParameter("@makhenthuong", SqlDbType.NVarChar, 50);
                    pmakhenthuong.Value = makhenthuong;
                    myCommand.Parameters.Add(pmakhenthuong);

                    SqlParameter ptenkhenthuong = new SqlParameter("@tenkhenthuong", SqlDbType.NVarChar, 250);
                    ptenkhenthuong.Value = tenkhenthuong;
                    myCommand.Parameters.Add(ptenkhenthuong);

                    SqlParameter pghichu = new SqlParameter("@ghichu", SqlDbType.NVarChar, 500);
                    pghichu.Value = ghichu;
                    myCommand.Parameters.Add(pghichu);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(DM_HinhThucKhenThuong_Chi_Tiet myDM_HinhThucKhenThuong_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DM_HinhThucKhenThuong_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pid = new SqlParameter("@id", SqlDbType.Int, 4);
                    pid.Value = myDM_HinhThucKhenThuong_Chi_Tiet.id;
                    myCommand.Parameters.Add(pid);

                    SqlParameter pmakhenthuong = new SqlParameter("@makhenthuong", SqlDbType.NVarChar, 50);
                    pmakhenthuong.Value = myDM_HinhThucKhenThuong_Chi_Tiet.makhenthuong;
                    myCommand.Parameters.Add(pmakhenthuong);

                    SqlParameter ptenkhenthuong = new SqlParameter("@tenkhenthuong", SqlDbType.NVarChar, 250);
                    ptenkhenthuong.Value = myDM_HinhThucKhenThuong_Chi_Tiet.tenkhenthuong;
                    myCommand.Parameters.Add(ptenkhenthuong);

                    SqlParameter pghichu = new SqlParameter("@ghichu", SqlDbType.NVarChar, 500);
                    pghichu.Value = myDM_HinhThucKhenThuong_Chi_Tiet.ghichu;
                    myCommand.Parameters.Add(pghichu);

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
                using (SqlCommand myCommand = new SqlCommand("DM_HinhThucKhenThuong_Cap_Nhat", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pid = new SqlParameter("@id", SqlDbType.Int, 4);
                        pid.Value = (int)myDataSet.Tables[strTableName].Rows[i]["id"];
                        myCommand.Parameters.Add(pid);

                        SqlParameter pmakhenthuong = new SqlParameter("@makhenthuong", SqlDbType.NVarChar,50);
                        pmakhenthuong.Value = (string)myDataSet.Tables[strTableName].Rows[i]["makhenthuong"];
                        myCommand.Parameters.Add(pmakhenthuong);

                        SqlParameter ptenkhenthuong = new SqlParameter("@tenkhenthuong", SqlDbType.NVarChar, 250);
                        ptenkhenthuong.Value = (string)myDataSet.Tables[strTableName].Rows[i]["tenkhenthuong"];
                        myCommand.Parameters.Add(ptenkhenthuong);

                        SqlParameter pghichu = new SqlParameter("@ghichu", SqlDbType.NVarChar, 500);
                        pghichu.Value = (string)myDataSet.Tables[strTableName].Rows[i]["ghichu"];
                        myCommand.Parameters.Add(pghichu);

                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int? id=null,string makhenthuong=null,string tenkhenthuong=null,string ghichu=null)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DM_HinhThucKhenThuong_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pid = new SqlParameter("@id", SqlDbType.Int, 4);
                    pid.Value = id;
                    myCommand.Parameters.Add(pid);

                    SqlParameter pmakhenthuong = new SqlParameter("@makhenthuong", SqlDbType.NVarChar, 50);
                    pmakhenthuong.Value = makhenthuong;
                    myCommand.Parameters.Add(pmakhenthuong);

                    SqlParameter ptenkhenthuong = new SqlParameter("@tenkhenthuong", SqlDbType.NVarChar, 250);
                    ptenkhenthuong.Value = tenkhenthuong;
                    myCommand.Parameters.Add(ptenkhenthuong);

                    SqlParameter pghichu = new SqlParameter("@ghichu", SqlDbType.NVarChar, 500);
                    pghichu.Value = ghichu;
                    myCommand.Parameters.Add(pghichu);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Xoa
        public void Xoa(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DM_HinhThucKhenThuong_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pid = new SqlParameter("@id", SqlDbType.Int, 4);
                    pid.Value = id;
                    myCommand.Parameters.Add(pid);

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
                using (SqlCommand myCommand = new SqlCommand("DM_HinhThucKhenThuong_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "DM_HinhThucKhenThuong_Danh_Sach");
                    return myDataSet.Tables["DM_HinhThucKhenThuong_Danh_Sach"];
                }
            }
        }
        #endregion
    }
    #endregion
}
