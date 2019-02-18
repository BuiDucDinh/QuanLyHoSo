using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_ThoiKy_ChiTiet
    {
        public int ID { get; set; }
        public string TenThoiKy { get; set; }
        public string EngName { get; set; }
        public string MoTa { get; set; }
        public NV_ThoiKy_ChiTiet() { }
        public NV_ThoiKy_ChiTiet(DataRow dr)
        {
            ID = int.Parse(dr["ID"].ToString());
            TenThoiKy = dr["TenThoiKy"].ToString();
            EngName = dr["EngName"].ToString();
            MoTa = dr["MoTa"].ToString();
        }
    }
    public class NV_ThoiKy
    {
        private string ConnectionString;
        public NV_ThoiKy(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lấy theo ID
        public NV_ThoiKy_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_ThoiKy_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    DataTable dt;
                    NV_ThoiKy_ChiTiet model = new NV_ThoiKy_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_ThoiKy_ChiTiet(dt.Rows[0]);
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
                using (SqlCommand myCommand = new SqlCommand("NV_ThoiKy_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_ThoiKy_getAll");
                    return myDataSet.Tables["NV_ThoiKy_getAll"];

                }
            }
        }

        #endregion
        #region Thêm
        public bool them(NV_ThoiKy_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_ThoiKy_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pTenThoiKy = new SqlParameter("@TenThoiKy", SqlDbType.NVarChar, 200);
                    pTenThoiKy.Value = model.TenThoiKy;
                    myCommand.Parameters.Add(pTenThoiKy);

                    SqlParameter pEngName = new SqlParameter("@EngName", SqlDbType.NVarChar, 200);
                    pEngName.Value = model.EngName;
                    myCommand.Parameters.Add(pEngName);

                    SqlParameter pMoTa = new SqlParameter("@MoTa", SqlDbType.NText);
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
        public bool update(NV_ThoiKy_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_ThoiKy_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = model.ID;
                    myCommand.Parameters.Add(pID); 
                    
                    SqlParameter pTenThoiKy = new SqlParameter("@TenThoiKy", SqlDbType.NVarChar, 200);
                    pTenThoiKy.Value = model.TenThoiKy;
                    myCommand.Parameters.Add(pTenThoiKy);

                    SqlParameter pEngName = new SqlParameter("@EngName", SqlDbType.NVarChar, 200);
                    pEngName.Value = model.EngName;
                    myCommand.Parameters.Add(pEngName);

                    SqlParameter pMoTa = new SqlParameter("@MoTa", SqlDbType.NText);
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
                using (SqlCommand myCommand = new SqlCommand("NV_ThoiKy_del", myConnection))
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
