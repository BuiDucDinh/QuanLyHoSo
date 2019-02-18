using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic
{
    public class NV_Map_ChiTiet
    {
        public int ID { get; set; }
        public int DiSanID { get; set; }
        public string Ten { get; set; }
        public string DiaChi { get; set; }
        public string MoTa { get; set; }
        public float Lat { get; set; }
        public float Lng { get; set; }
        public string Link { get; set; }
        public NV_Map_ChiTiet() { }
        public NV_Map_ChiTiet(DataTable dt)
        {
            ID = int.Parse(dt.Rows[0]["ID"].ToString());
            DiSanID = int.Parse(dt.Rows[0]["DiSanID"].ToString());
            DiaChi = dt.Rows[0]["DiaChi"].ToString();
            MoTa = dt.Rows[0]["MoTa"].ToString();
            Ten = dt.Rows[0]["Ten"].ToString();
            Lat = float.Parse(dt.Rows[0]["Lat"].ToString());
            Lng = float.Parse(dt.Rows[0]["Lng"].ToString());
            Link = dt.Rows[0]["Link"].ToString();
        }
    }
    public class NV_Map
    {
        private string ConnectionString;
        public NV_Map(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }

        #region Lấy theo ID
        public NV_Map_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_Map_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    DataTable dt;
                    NV_Map_ChiTiet model = new NV_Map_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_Map_ChiTiet(dt);
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
                using (SqlCommand myCommand = new SqlCommand("NV_Map_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_Map_getAll");
                    return myDataSet.Tables["NV_Map_getAll"];

                }
            }
        }

        #endregion
        #region Thêm
        public bool them(NV_Map_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_Map_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pDiSanID = new SqlParameter("@DiSanID", SqlDbType.Int);
                    pDiSanID.Value = model.DiSanID;
                    myCommand.Parameters.Add(pDiSanID);

                    SqlParameter pDiaChi = new SqlParameter("@DiaChi", SqlDbType.NVarChar, 1000);
                    pDiaChi.Value = model.DiaChi;
                    myCommand.Parameters.Add(pDiaChi);

                    SqlParameter pMoTa = new SqlParameter("@MoTa", SqlDbType.NText);
                    pMoTa.Value = model.MoTa;
                    myCommand.Parameters.Add(pMoTa);

                    SqlParameter pLat = new SqlParameter("@Lat", SqlDbType.Float);
                    pLat.Value = model.Lat;
                    myCommand.Parameters.Add(pLat);

                    SqlParameter pLng = new SqlParameter("@Lng", SqlDbType.Float);
                    pLng.Value = model.Lng;
                    myCommand.Parameters.Add(pLng);

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
        public bool update(NV_Map_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_Map_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = model.ID;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pDiSanID = new SqlParameter("@DiSanID", SqlDbType.Int);
                    pDiSanID.Value = model.DiSanID;
                    myCommand.Parameters.Add(pDiSanID);

                    SqlParameter pDiaChi = new SqlParameter("@DiaChi", SqlDbType.NVarChar, 1000);
                    pDiaChi.Value = model.DiaChi;
                    myCommand.Parameters.Add(pDiaChi);

                    SqlParameter pMoTa = new SqlParameter("@MoTa", SqlDbType.NText);
                    pMoTa.Value = model.MoTa;
                    myCommand.Parameters.Add(pMoTa);

                    SqlParameter pLat = new SqlParameter("@Lat", SqlDbType.Float);
                    pLat.Value = model.Lat;
                    myCommand.Parameters.Add(pLat);

                    SqlParameter pLng = new SqlParameter("@Lng", SqlDbType.Float);
                    pLng.Value = model.Lng;
                    myCommand.Parameters.Add(pLng);
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
                using (SqlCommand myCommand = new SqlCommand("NV_Map_del", myConnection))
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
        #region Lấy theo di sản
        public DataTable GetByDiSan(int disan)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_Map_getByDiSan", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pID = new SqlParameter("@DiSanID", SqlDbType.Int);
                    pID.Value = disan;
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
    }
}
