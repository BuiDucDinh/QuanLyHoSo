using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_HoiDongThamDinh_ChiTiet
    {
        public int ID { get; set; }
        public string TenHoiDong { get; set; }
        public string MoTa { get; set; }
        public NV_HoiDongThamDinh_ChiTiet() { }
        public NV_HoiDongThamDinh_ChiTiet(DataRow dr)
        {
            ID = int.Parse(dr["ID"].ToString());
            TenHoiDong = dr["TenHoiDong"].ToString();
            MoTa = dr["MoTa"].ToString();
        }
    }
    public class NV_HoiDongThamDinh
    {
        private string ConnectionString;
        public NV_HoiDongThamDinh(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lấy theo ID
        public NV_HoiDongThamDinh_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_HoiDongThamDinh_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    DataTable dt;
                    NV_HoiDongThamDinh_ChiTiet model = new NV_HoiDongThamDinh_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_HoiDongThamDinh_ChiTiet(dt.Rows[0]);
                    }
                    return model;
                }
            }
        }
        #endregion
        #region Lấy tất cả
        public DataTable GetAll()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_HoiDongThamDinh_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_HoiDongThamDinh_getAll");
                    return myDataSet.Tables["NV_HoiDongThamDinh_getAll"];

                }
            }
        }

        #endregion
        #region Thêm
        public bool them(NV_HoiDongThamDinh_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_HoiDongThamDinh_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pTenHoiDong = new SqlParameter("@TenHoiDong", SqlDbType.NVarChar, 200);
                    pTenHoiDong.Value = model.TenHoiDong;
                    myCommand.Parameters.Add(pTenHoiDong);

                    SqlParameter pMoTa = new SqlParameter("@MoTa", SqlDbType.NVarChar, 2000);
                    pMoTa.Value = model.MoTa;
                    myCommand.Parameters.Add(pMoTa);

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
        #region update
        public bool update(NV_HoiDongThamDinh_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_HoiDongThamDinh_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = model.ID;
                    myCommand.Parameters.Add(pID); SqlParameter pTenHoiDong = new SqlParameter("@TenHoiDong", SqlDbType.NVarChar, 200);
                    pTenHoiDong.Value = model.TenHoiDong;
                    myCommand.Parameters.Add(pTenHoiDong);

                    SqlParameter pMoTa = new SqlParameter("@MoTa", SqlDbType.NVarChar, 2000);
                    pMoTa.Value = model.MoTa;
                    myCommand.Parameters.Add(pMoTa);

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
        #region Xóa
        public void Xoa(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_HoiDongThamDinh_del", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
    }
}
