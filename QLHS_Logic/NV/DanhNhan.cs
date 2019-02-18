using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_DanhNhan_ChiTiet
    {
        public int DanhNhanID { get; set; }
        public string TenDanhNhan { get; set; }
        public string MoTa { get; set; }
        public string Thoidai { get; set; }
        public int Stt { get; set; }
        public string Url { get; set; }
        public NV_DanhNhan_ChiTiet(DataRow dr)
        {
            DanhNhanID = int.Parse(dr["DanhNhanID"].ToString());
            TenDanhNhan = dr["TenDanhNhan"].ToString();
            MoTa = dr["MoTa"].ToString();
            Thoidai = dr["Thoidai"].ToString();
            Stt = int.Parse(dr["Stt"].ToString());
            Url = dr["Url"].ToString();
        }
        public NV_DanhNhan_ChiTiet() { }
    }
    public class NV_DanhNhan
    {
        private string ConnectionString;
        public NV_DanhNhan(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lấy theo ID
        public NV_DanhNhan_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DanhNhan_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@DanhNhanID", SqlDbType.VarChar, 10);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    DataTable dt;
                    NV_DanhNhan_ChiTiet model = new NV_DanhNhan_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_DanhNhan_ChiTiet(dt.Rows[0]);
                    }
                    return model;
                }
            }
        }
        #endregion
        #region Lấy theo Url
        public NV_DanhNhan_ChiTiet GetByUrl(string url)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DanhNhan_getByUrl", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pUrl = new SqlParameter("@Url", SqlDbType.NVarChar, 100);
                    pUrl.Value = url;
                    myCommand.Parameters.Add(pUrl);

                    DataTable dt;
                    NV_DanhNhan_ChiTiet model = new NV_DanhNhan_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            model = new NV_DanhNhan_ChiTiet(dt.Rows[0]);
                        }
                        return model;
                    }
                }
            }
        }
        #endregion
        #region Lấy tất cả
        public DataTable GetAll()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DanhNhan_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_DanhNhan_getAll");
                    return myDataSet.Tables["NV_DanhNhan_getAll"];

                }
            }
        }

        #endregion
        #region Thêm
        public bool them(NV_DanhNhan_ChiTiet model, out int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DanhNhan_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@DanhNhanID", SqlDbType.Int);
                    pID.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pTenDanhNhan = new SqlParameter("@TenDanhNhan", SqlDbType.NVarChar, 100);
                    pTenDanhNhan.Value = model.TenDanhNhan;
                    myCommand.Parameters.Add(pTenDanhNhan);

                    SqlParameter pThoidai = new SqlParameter("@Thoidai", SqlDbType.NVarChar, 100);
                    pThoidai.Value = model.Thoidai;
                    myCommand.Parameters.Add(pThoidai);

                    SqlParameter pStt = new SqlParameter("@Stt", SqlDbType.Int);
                    pStt.Value = model.Stt;
                    myCommand.Parameters.Add(pStt);

                    SqlParameter pMoTa = new SqlParameter("@MoTa", SqlDbType.NText);
                    pMoTa.Value = model.MoTa;
                    myCommand.Parameters.Add(pMoTa);

                    SqlParameter pUrl = new SqlParameter("@Url", SqlDbType.NVarChar, 100);
                    pUrl.Value = model.Url;
                    myCommand.Parameters.Add(pUrl);
                    id = 0;
                    try
                    {
                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                        id = (int)pID.Value;
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
        public bool update(NV_DanhNhan_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DanhNhan_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@DanhNhanID", SqlDbType.Int);
                    pID.Value = model.DanhNhanID;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pTenDanhNhan = new SqlParameter("@TenDanhNhan", SqlDbType.NVarChar, 100);
                    pTenDanhNhan.Value = model.TenDanhNhan;
                    myCommand.Parameters.Add(pTenDanhNhan);

                    SqlParameter pThoidai = new SqlParameter("@Thoidai", SqlDbType.NVarChar, 100);
                    pThoidai.Value = model.Thoidai;
                    myCommand.Parameters.Add(pThoidai);

                    SqlParameter pStt = new SqlParameter("@Stt", SqlDbType.Int);
                    pStt.Value = model.Stt;
                    myCommand.Parameters.Add(pStt);

                    SqlParameter pMoTa = new SqlParameter("@MoTa", SqlDbType.NText);
                    pMoTa.Value = model.MoTa;
                    myCommand.Parameters.Add(pMoTa);
                    SqlParameter pUrl = new SqlParameter("@Url", SqlDbType.NVarChar, 100);
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
                using (SqlCommand myCommand = new SqlCommand("NV_DanhNhan_del", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.VarChar, 10);
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
