using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_LoaiVanBan_ChiTiet
    {
        public int LoaiVanBanID { get; set; }
        public string TenLoaiVanBan { get; set; }
        public string MoTa { get; set; }

        public NV_LoaiVanBan_ChiTiet() { }
    }

    public class NV_LoaiVanBan
    {
        private string ConnectionString;
        public NV_LoaiVanBan(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lấy theo ID
        public NV_LoaiVanBan_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_LoaiVanBan_GetByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@id", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    NV_LoaiVanBan_ChiTiet model = new NV_LoaiVanBan_ChiTiet();
                    DataTable dt;

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model.LoaiVanBanID = id;
                        model.TenLoaiVanBan = dt.Rows[0]["TenLoaivanBan"].ToString();
                        model.MoTa = dt.Rows[0]["MoTa"].ToString();
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
                using (SqlCommand myCommand = new SqlCommand("NV_LoaiVanBan_GetAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_LoaiVanBan_GetAll");
                    return myDataSet.Tables["NV_LoaiVanBan_GetAll"];

                }
            }
        }

        #endregion

        #region Thêm
        public bool them(NV_LoaiVanBan_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_LoaiVanBan_Add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pTenLoaiVanBan = new SqlParameter("@TenLoaiVanBan", SqlDbType.NVarChar, 250);
                    pTenLoaiVanBan.Value = model.TenLoaiVanBan;
                    myCommand.Parameters.Add(pTenLoaiVanBan);

                    SqlParameter pMoTa = new SqlParameter("@MoTa", SqlDbType.NVarChar, 1000);
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
        public bool update(NV_LoaiVanBan_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_LoaiVanBan_Update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@LoaiVanBanID", SqlDbType.Int);
                    pID.Value = model.LoaiVanBanID;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pTenLoaiVanBan = new SqlParameter("@TenLoaiVanBan", SqlDbType.NVarChar, 250);
                    pTenLoaiVanBan.Value = model.TenLoaiVanBan;
                    myCommand.Parameters.Add(pTenLoaiVanBan);

                    SqlParameter pMoTa = new SqlParameter("@MoTa", SqlDbType.NVarChar, 1000);
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
                using (SqlCommand myCommand = new SqlCommand("NV_LoaiVanBan_Del", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@id", SqlDbType.Int);
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
