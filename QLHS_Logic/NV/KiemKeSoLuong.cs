using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_KiemKeSoLuong
    {
        private string ConnectionString;
        public NV_KiemKeSoLuong(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region thống kế số di tích theo năm
        public DataTable ThongKeSoDiTich(int nam)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("ThongKeSoDiTich", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@Nam", SqlDbType.Int);
                    pID.Value = nam;
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
        #region thống kế số bảo tàng theo năm
        public DataTable ThongKeSoBaoTang(int nam)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("ThongKeSoBaoTang", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@Nam", SqlDbType.Int);
                    pID.Value = nam;
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
        #region thống kế số di sản phi vật thể
        public DataTable ThongKeSoDiSanPVT(int nam)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("ThongKeSoDiSanPVT", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@Nam", SqlDbType.Int);
                    pID.Value = nam;
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
        
        #region Thêm thông ke di tich
        public bool ThongKeSoDiTich_them(int nam, int loai)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("ThongKeSoDiTich_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pNam = new SqlParameter("@Nam", SqlDbType.Int);
                    pNam.Value = nam;
                    myCommand.Parameters.Add(pNam);

                    try
                    {
                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }
        #endregion
    }
}
