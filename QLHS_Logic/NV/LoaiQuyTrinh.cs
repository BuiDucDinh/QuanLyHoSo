using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_LoaiQuyTrinh_ChiTiet
    {
        public int ID { get; set; }
        public string TenLoai { get; set; }
        public string MoTa { get; set; }
        public int Stt { get; set; }
        public string Url { get; set; }
        public NV_LoaiQuyTrinh_ChiTiet() { }
        public NV_LoaiQuyTrinh_ChiTiet(DataRow dr)
        {
            ID = int.Parse(dr["ID"].ToString());
            TenLoai = dr["TenLoai"].ToString();
            MoTa = dr["MoTa"].ToString();
            try
            {
                Stt = int.Parse(dr["Stt"].ToString());
            }
            catch
            {
                Stt = 1;
            }
            Url = dr["Url"].ToString();
        }
    }

    public class NV_LoaiQuyTrinh
    {
        private string ConnectionString;
        public NV_LoaiQuyTrinh(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lấy theo ID
        public NV_LoaiQuyTrinh_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_LoaiQuyTrinh_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    NV_LoaiQuyTrinh_ChiTiet model = new NV_LoaiQuyTrinh_ChiTiet();
                    DataTable dt;

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_LoaiQuyTrinh_ChiTiet(dt.Rows[0]);
                    }
                    return model;
                }
            }
        }
        #endregion
        #region Lấy theo Url
        public NV_LoaiQuyTrinh_ChiTiet GetByUrl(string url)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_LoaiQuyTrinh_getByUrl", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pUrl = new SqlParameter("@Url", SqlDbType.NVarChar,200);
                    pUrl.Value = url;
                    myCommand.Parameters.Add(pUrl);

                    NV_LoaiQuyTrinh_ChiTiet model = new NV_LoaiQuyTrinh_ChiTiet();
                    DataTable dt;

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_LoaiQuyTrinh_ChiTiet(dt.Rows[0]);
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
                using (SqlCommand myCommand = new SqlCommand("NV_LoaiQuyTrinh_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_LoaiQuyTrinh_GetAll");
                    return myDataSet.Tables["NV_LoaiQuyTrinh_GetAll"];

                }
            }
        }
        #endregion

        #region Thêm
        public bool them(NV_LoaiQuyTrinh_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_LoaiQuyTrinh_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pTenLoaiVanBan = new SqlParameter("@TenLoai", SqlDbType.NVarChar, 250);
                    pTenLoaiVanBan.Value = model.TenLoai;
                    myCommand.Parameters.Add(pTenLoaiVanBan);

                    SqlParameter pMoTa = new SqlParameter("@MoTa", SqlDbType.NVarChar, 1000);
                    pMoTa.Value = model.MoTa;
                    myCommand.Parameters.Add(pMoTa);

                    SqlParameter pStt = new SqlParameter("@Stt", SqlDbType.Int);
                    pStt.Value = model.Stt;
                    myCommand.Parameters.Add(pStt);

                    SqlParameter pUrl = new SqlParameter("@Url", SqlDbType.NVarChar, 200);
                    pUrl.Value = model.Url;
                    myCommand.Parameters.Add(pUrl);

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
        public bool update(NV_LoaiQuyTrinh_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_LoaiQuyTrinh_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = model.ID;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pTenLoai = new SqlParameter("@TenLoai", SqlDbType.NVarChar, 250);
                    pTenLoai.Value = model.TenLoai;
                    myCommand.Parameters.Add(pTenLoai);

                    SqlParameter pMoTa = new SqlParameter("@MoTa", SqlDbType.NVarChar, 1000);
                    pMoTa.Value = model.MoTa;
                    myCommand.Parameters.Add(pMoTa);

                    SqlParameter pStt = new SqlParameter("@Stt", SqlDbType.Int);
                    pStt.Value = model.Stt;
                    myCommand.Parameters.Add(pStt);

                    SqlParameter pUrl = new SqlParameter("@Url", SqlDbType.NVarChar, 200);
                    pUrl.Value = model.Url;
                    myCommand.Parameters.Add(pUrl);
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
                using (SqlCommand myCommand = new SqlCommand("NV_LoaiQuyTrinh_del", myConnection))
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
