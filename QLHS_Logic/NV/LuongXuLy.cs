using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic
{
    public class NV_LuongXuLy_ChiTiet
    {
        public int ID { get; set; }
        public int IDQTCuThe { get; set; }
        public string Ten { get; set; }
        public int IDLuong { get; set; }
        public int NguoiXuLy { get; set; }
        public DateTime? NgayXuLy { get; set; }
        public string MoTa { get; set; }
        public int TrangThai { get; set; }
        public string FileTiepNhan { get; set; }
        public string FileLienQuan { get; set; }
        public int Stt { get; set; }
        public NV_LuongXuLy_ChiTiet() { }
        public NV_LuongXuLy_ChiTiet(DataRow dr)
        {
            ID = int.Parse(dr["ID"].ToString());
            IDLuong = int.Parse(dr["IDLuong"].ToString());
            Ten = dr["Ten"].ToString();
            IDQTCuThe = int.Parse(dr["IDQTCuThe"].ToString());
            NguoiXuLy = int.Parse(dr["NguoiXuLy"].ToString());
            try
            {
                NgayXuLy = Convert.ToDateTime(dr["NgayXuLy"].ToString());
            }
            catch
            {
                NgayXuLy = null;
            }
            MoTa = dr["MoTa"].ToString();
            TrangThai = int.Parse(dr["TrangThai"].ToString());
            FileLienQuan = dr["FileLienQuan"].ToString();
            FileTiepNhan = dr["FileTiepNhan"].ToString();
            Stt=int.Parse(dr["Stt"].ToString());
        }
    }
    public class NV_LuongXuLy
    {
        private string ConnectionString;
        public NV_LuongXuLy(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region lấy bước cuối cùng
        #region Lấy theo ID
        public NV_LuongXuLy_ChiTiet GetLast(int idQuytrinh)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_LuongXuLy_getLast", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pID = new SqlParameter("@IDQuyTrinh", SqlDbType.Int);
                    pID.Value = idQuytrinh;
                    myCommand.Parameters.Add(pID);

                    DataTable dt;
                    NV_LuongXuLy_ChiTiet model = new NV_LuongXuLy_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_LuongXuLy_ChiTiet(dt.Rows[0]);
                    }
                    return model;
                }
            }
        }
        #endregion
        #endregion
        #region Lấy theo ID
        public NV_LuongXuLy_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_LuongXuLy_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    DataTable dt;
                    NV_LuongXuLy_ChiTiet model = new NV_LuongXuLy_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_LuongXuLy_ChiTiet(dt.Rows[0]);
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
                using (SqlCommand myCommand = new SqlCommand("NV_LuongXuLy_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_LuongXuLy_getAll");
                    return myDataSet.Tables["NV_LuongXuLy_getAll"];

                }
            }
        }

        #endregion
        #region Lấy theo quy trình
        public List<NV_LuongXuLy_ChiTiet> GetByQT(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_LuongXuLy_getByQT", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pID = new SqlParameter("@IDQTCuThe", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    DataTable dt = new DataTable();
                    List<NV_LuongXuLy_ChiTiet> lst = new List<NV_LuongXuLy_ChiTiet>();
                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            lst.Add(new NV_LuongXuLy_ChiTiet(item));
                        }

                    }
                    return lst;
                }
            }
        }
        #endregion
        #region Lọc điều kiện (Nguoi xu ly, ngay xu ly, trang thai, sap xep)
        public List<NV_LuongXuLy_ChiTiet> Loc(int nguoixuly, DateTime? ngayxuly, int trangthai, string orderby)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_LuongXuLy_getByNguoiXuLy", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pNguoiXuLy = new SqlParameter("@NguoiXuLy", SqlDbType.Int);
                    pNguoiXuLy.Value = nguoixuly;
                    myCommand.Parameters.Add(pNguoiXuLy);

                    SqlParameter pNgayXuLy = new SqlParameter("@NgayXuLy", SqlDbType.DateTime);
                    pNgayXuLy.Value = ngayxuly;
                    myCommand.Parameters.Add(pNgayXuLy);

                    SqlParameter pTrangThai = new SqlParameter("@TrangThai", SqlDbType.Int);
                    pTrangThai.Value = trangthai;
                    myCommand.Parameters.Add(pTrangThai);

                    SqlParameter pOrderBy = new SqlParameter("@OrderBy", SqlDbType.NVarChar, 20);
                    pOrderBy.Value = orderby;
                    myCommand.Parameters.Add(pOrderBy);

                    DataTable dt = new DataTable();
                    List<NV_LuongXuLy_ChiTiet> lst = new List<NV_LuongXuLy_ChiTiet>();
                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            lst.Add(new NV_LuongXuLy_ChiTiet(item));
                        }

                    }
                    return lst;
                }
            }
        }
        #endregion
        #region Hủy quy trình
        public void Cancel(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_LuongXuLy_Cancel", myConnection))
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
        #region Thêm
        public bool them(NV_LuongXuLy_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_LuongXuLy_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;


                    SqlParameter pIDLuong = new SqlParameter("@IDLuong", SqlDbType.Int);
                    pIDLuong.Value = model.IDLuong;
                    myCommand.Parameters.Add(pIDLuong);

                    SqlParameter pIDQTCuThe = new SqlParameter("@IDQTCuThe", SqlDbType.Int);
                    pIDQTCuThe.Value = model.IDQTCuThe;
                    myCommand.Parameters.Add(pIDQTCuThe);

                    SqlParameter pNguoiXuLy = new SqlParameter("@NguoiXuLy", SqlDbType.Int);
                    pNguoiXuLy.Value = model.NguoiXuLy;
                    myCommand.Parameters.Add(pNguoiXuLy);

                    SqlParameter pMoTa = new SqlParameter("@MoTa", SqlDbType.NVarChar, 1000);
                    pMoTa.Value = model.MoTa;
                    myCommand.Parameters.Add(pMoTa);

                    SqlParameter pNgayXuLy = new SqlParameter("@NgayXuLy", SqlDbType.DateTime);
                    pNgayXuLy.Value = model.NgayXuLy;
                    myCommand.Parameters.Add(pNgayXuLy);

                    SqlParameter pTrangThai = new SqlParameter("@TrangThai", SqlDbType.Int);
                    pTrangThai.Value = model.TrangThai;
                    myCommand.Parameters.Add(pTrangThai);


                    SqlParameter pFileLienQuan = new SqlParameter("@FileLienQuan", SqlDbType.NVarChar, 50);
                    pFileLienQuan.Value = model.FileLienQuan;
                    myCommand.Parameters.Add(pFileLienQuan);
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
        public bool update(NV_LuongXuLy_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_LuongXuLy_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = model.ID;
                    myCommand.Parameters.Add(pID);


                    SqlParameter pIDLuong = new SqlParameter("@IDLuong", SqlDbType.Int);
                    pIDLuong.Value = model.IDLuong;
                    myCommand.Parameters.Add(pIDLuong);

                    SqlParameter pIDQTCuThe = new SqlParameter("@IDQTCuThe", SqlDbType.Int);
                    pIDQTCuThe.Value = model.IDQTCuThe;
                    myCommand.Parameters.Add(pIDQTCuThe);

                    SqlParameter pNguoiXuLy = new SqlParameter("@NguoiXuLy", SqlDbType.Int);
                    pNguoiXuLy.Value = model.NguoiXuLy;
                    myCommand.Parameters.Add(pNguoiXuLy);

                    SqlParameter pMoTa = new SqlParameter("@MoTa", SqlDbType.NVarChar, 1000);
                    pMoTa.Value = model.MoTa;
                    myCommand.Parameters.Add(pMoTa);

                    SqlParameter pNgayXuLy = new SqlParameter("@NgayXuLy", SqlDbType.DateTime);
                    pNgayXuLy.Value = model.NgayXuLy;
                    myCommand.Parameters.Add(pNgayXuLy);

                    SqlParameter pTrangThai = new SqlParameter("@TrangThai", SqlDbType.Int);
                    pTrangThai.Value = model.TrangThai;
                    myCommand.Parameters.Add(pTrangThai);


                    SqlParameter pFileLienQuan = new SqlParameter("@FileLienQuan", SqlDbType.NVarChar, 50);
                    pFileLienQuan.Value = model.FileLienQuan;
                    myCommand.Parameters.Add(pFileLienQuan);
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
                using (SqlCommand myCommand = new SqlCommand("NV_LuongXuLy_del", myConnection))
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
