using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic
{
    public class NV_LuongDinhNghia_ChiTiet
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public int IDQuyTrinh { get; set; }
        public int NguoiXuLy { get; set; }
        public string MoTa { get; set; }
        public int Stt { get; set; }
        public int CoQuanID { get; set; }
        public int ThoiGianHT { get; set; }
        public NV_LuongDinhNghia_ChiTiet() { }
        public NV_LuongDinhNghia_ChiTiet(DataRow dr)
        {
            ID = int.Parse(dr["ID"].ToString());
            Ten = dr["Ten"].ToString();
            Stt = int.Parse(dr["Stt"].ToString());
            IDQuyTrinh = int.Parse(dr["IDQuyTrinh"].ToString());
            NguoiXuLy = int.Parse(dr["NguoiXuLy"].ToString());
            CoQuanID = int.Parse(dr["CoQuanID"].ToString());
            MoTa = dr["MoTa"].ToString();
            ThoiGianHT = int.Parse(dr["ThoiGianHT"].ToString());
        }
    }
    public class NV_LuongDinhNghia
    {
        private string ConnectionString;
        public NV_LuongDinhNghia(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }

        #region Lấy theo ID
        public NV_LuongDinhNghia_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_LuongDinhNghia_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    DataTable dt;
                    NV_LuongDinhNghia_ChiTiet model = new NV_LuongDinhNghia_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_LuongDinhNghia_ChiTiet(dt.Rows[0]);
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
                using (SqlCommand myCommand = new SqlCommand("NV_LuongDinhNghia_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_LuongDinhNghia_getAll");
                    return myDataSet.Tables["NV_LuongDinhNghia_getAll"];

                }
            }
        }

        #endregion
        #region Lấy theo quy trình
        public List<NV_LuongDinhNghia_ChiTiet> GetByQT(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_LuongDinhNghia_getByQT", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pID = new SqlParameter("@IDQuyTrinh", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    DataTable dt = new DataTable();
                    List<NV_LuongDinhNghia_ChiTiet> lst = new List<NV_LuongDinhNghia_ChiTiet>();
                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            lst.Add(new NV_LuongDinhNghia_ChiTiet(item));
                        }

                    }
                    return lst;
                }
            }
        }
        #endregion
        #region Thêm
        public bool them(NV_LuongDinhNghia_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_LuongDinhNghia_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;


                    SqlParameter pTenLinhVuc = new SqlParameter("@Ten", SqlDbType.NVarChar, 250);
                    pTenLinhVuc.Value = model.Ten;
                    myCommand.Parameters.Add(pTenLinhVuc);


                    SqlParameter pStt = new SqlParameter("@Stt", SqlDbType.Int);
                    pStt.Value = model.Stt;
                    myCommand.Parameters.Add(pStt);

                    SqlParameter pIDQuyTrinh = new SqlParameter("@IDQuyTrinh", SqlDbType.Int);
                    pIDQuyTrinh.Value = model.IDQuyTrinh;
                    myCommand.Parameters.Add(pIDQuyTrinh);

                    SqlParameter pNguoiXuLy = new SqlParameter("@NguoiXuLy", SqlDbType.Int);
                    pNguoiXuLy.Value = model.NguoiXuLy;
                    myCommand.Parameters.Add(pNguoiXuLy);

                    SqlParameter pMoTa = new SqlParameter("@MoTa", SqlDbType.NVarChar, 1000);
                    pMoTa.Value = model.MoTa;
                    myCommand.Parameters.Add(pMoTa);

                    SqlParameter pCoQuanID = new SqlParameter("@CoQuanID", SqlDbType.Int);
                    pCoQuanID.Value = model.CoQuanID;
                    myCommand.Parameters.Add(pCoQuanID);

                    SqlParameter pThoiGianHT = new SqlParameter("@ThoiGianHT", SqlDbType.Int);
                    pThoiGianHT.Value = model.ThoiGianHT;
                    myCommand.Parameters.Add(pThoiGianHT);

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
        public bool update(NV_LuongDinhNghia_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_LuongDinhNghia_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = model.ID;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pTenLinhVuc = new SqlParameter("@Ten", SqlDbType.NVarChar, 250);
                    pTenLinhVuc.Value = model.Ten;
                    myCommand.Parameters.Add(pTenLinhVuc);


                    SqlParameter pStt = new SqlParameter("@Stt", SqlDbType.Int);
                    pStt.Value = model.Stt;
                    myCommand.Parameters.Add(pStt);

                    SqlParameter pIDQuyTrinh = new SqlParameter("@IDQuyTrinh", SqlDbType.Int);
                    pIDQuyTrinh.Value = model.IDQuyTrinh;
                    myCommand.Parameters.Add(pIDQuyTrinh);

                    SqlParameter pNguoiXuLy = new SqlParameter("@NguoiXuLy", SqlDbType.Int);
                    pNguoiXuLy.Value = model.NguoiXuLy;
                    myCommand.Parameters.Add(pNguoiXuLy);

                    SqlParameter pMoTa = new SqlParameter("@MoTa", SqlDbType.NVarChar, 1000);
                    pMoTa.Value = model.MoTa;
                    myCommand.Parameters.Add(pMoTa);

                    SqlParameter pCoQuanID = new SqlParameter("@CoQuanID", SqlDbType.Int);
                    pCoQuanID.Value = model.CoQuanID;
                    myCommand.Parameters.Add(pCoQuanID);

                    SqlParameter pThoiGianHT = new SqlParameter("@ThoiGianHT", SqlDbType.Int);
                    pThoiGianHT.Value = model.ThoiGianHT;
                    myCommand.Parameters.Add(pThoiGianHT);
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
                using (SqlCommand myCommand = new SqlCommand("NV_LuongDinhNghia_del", myConnection))
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
