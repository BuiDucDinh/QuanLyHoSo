using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic
{
    public class NV_DM_ChucVu_ChiTiet
    {
        public int ChucvuID { get; set; }
        public string TenChucVu { get; set; }
        public string Mota { get; set; }

    }
    public class NV_DM_ChucVu
    {
        private string ConnectionString;
        public NV_DM_ChucVu(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }

        #region Lấy theo ID
        public NV_DM_ChucVu_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_ChucVu_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pID = new SqlParameter("@id", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    DataTable dt;
                    NV_DM_ChucVu_ChiTiet model = new NV_DM_ChucVu_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {

                        model.ChucvuID = id;
                        model.TenChucVu = dt.Rows[0]["TenChucVu"].ToString();
                        model.Mota = dt.Rows[0]["MoTa"].ToString();
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
                using (SqlCommand myCommand = new SqlCommand("NV_ChucVu_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_ChucVu_getAll");
                    return myDataSet.Tables["NV_ChucVu_getAll"];

                }
            }
        }

        #endregion
        #region Thêm
        public bool them(NV_DM_ChucVu_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_ChucVu_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;


                    SqlParameter pTenChucVu = new SqlParameter("@TenChucVu", SqlDbType.NVarChar, 100);
                    pTenChucVu.Value = model.TenChucVu;
                    myCommand.Parameters.Add(pTenChucVu);


                    SqlParameter pMoTa = new SqlParameter("@MoTa", SqlDbType.NText);
                    pMoTa.Value = model.Mota;
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
        public bool update(NV_DM_ChucVu_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_ChucVu_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ChucVuID", SqlDbType.Int);
                    pID.Value = model.ChucvuID;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pTenChucVu = new SqlParameter("@TenChucVu", SqlDbType.NVarChar, 100);
                    pTenChucVu.Value = model.TenChucVu;
                    myCommand.Parameters.Add(pTenChucVu);


                    SqlParameter pMoTa = new SqlParameter("@MoTa", SqlDbType.NText);
                    pMoTa.Value = model.Mota;
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
                using (SqlCommand myCommand = new SqlCommand("NV_ChucVu_del", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@id", SqlDbType.VarChar, 10);
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
