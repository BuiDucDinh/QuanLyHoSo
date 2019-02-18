using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic
{
    public class NV_QuyTrinhXuLy_ChiTiet
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public int IDQuyTrinh { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime? NgayHoanThanh { get; set; }
        public int NguoiTao { get; set; }
        public string NguoiTiepNhan { get; set; }
        public int TrangThai { get; set; }
        public string FileDauVao { get; set; }
        public string TenFileDauVao { get; set; }
        public string TenFileKQ { get; set; }
        public string FileKQ { get; set; }
        public string NguoiYeuCau { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string ThongTin { get; set; }
        public string GhiChu { get; set; }
        public string TrangThaiText { get; set; }
        public NV_QuyTrinhXuLy_ChiTiet() { }
        public NV_QuyTrinhXuLy_ChiTiet(DataRow dr)
        {
            ID = int.Parse(dr["ID"].ToString());
            Ten = dr["Ten"].ToString();
            IDQuyTrinh = int.Parse(dr["IDQuyTrinh"].ToString());
            TrangThai = int.Parse(dr["TrangThai"].ToString());
            NguoiTao = int.Parse(dr["NguoiTao"].ToString());
            FileDauVao = dr["FileDauVao"].ToString();
            TenFileDauVao = dr["TenFileDauVao"].ToString();
            FileKQ = dr["FileKQ"].ToString();
            TenFileKQ = dr["TenFileKQ"].ToString();
            NguoiYeuCau = dr["NguoiYeuCau"].ToString();
            SoDienThoai = dr["SoDienThoai"].ToString();
            Email = dr["Email"].ToString();
            DiaChi = dr["DiaChi"].ToString();
            ThongTin = dr["ThongTin"].ToString();
            NguoiTiepNhan = dr["NguoiTiepNhan"].ToString();
            TrangThaiText = dr["TrangThaiText"].ToString();
            try
            {
                NgayBatDau = Convert.ToDateTime(dr["NgayBatDau"].ToString());
            }
            catch { }
            try
            {
                NgayHoanThanh = Convert.ToDateTime(dr["NgayHoanThanh"].ToString());
            }
            catch { }
            GhiChu = dr["GhiChu"].ToString();
        }
    }
    public class NV_QuyTrinhXuLy
    {
        private string ConnectionString;
        public NV_QuyTrinhXuLy(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }

        #region Lấy theo ID
        public NV_QuyTrinhXuLy_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_QuyTrinhXuLy_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    DataTable dt;
                    NV_QuyTrinhXuLy_ChiTiet model = new NV_QuyTrinhXuLy_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_QuyTrinhXuLy_ChiTiet(dt.Rows[0]);

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
                using (SqlCommand myCommand = new SqlCommand("NV_QuyTrinhXuLy_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_QuyTrinhXuLy_getAll");
                    return myDataSet.Tables["NV_QuyTrinhXuLy_getAll"];

                }
            }
        }

        #endregion
        #region Lấy theo loại
        public DataTable GetByLoai()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_QuyTrinhXuLy_getByLoai", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_QuyTrinhXuLy_getByLoai");
                    return myDataSet.Tables["NV_QuyTrinhXuLy_getByLoai"];

                }
            }
        }

        #endregion
        #region Lấy theo loại quy trình ĐN
        public DataTable GetByQuyTrinh(int idQuyTrinh)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_QuyTrinhXuLy_getByQuyTrinhDN", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pID = new SqlParameter("@IDQuyTrinh", SqlDbType.Int);
                    pID.Value = idQuyTrinh;
                    myCommand.Parameters.Add(pID);

                    DataTable dt;
                    NV_QuyTrinhXuLy_ChiTiet model = new NV_QuyTrinhXuLy_ChiTiet();

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
        #region Thêm
        public bool them(NV_QuyTrinhXuLy_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_QuyTrinhXuLy_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    //SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    //pID.Value = ParameterDirection.Output;
                    //myCommand.Parameters.Add(pID);

                    SqlParameter pTen = new SqlParameter("@Ten", SqlDbType.NVarChar, 1000);
                    pTen.Value = model.Ten;
                    myCommand.Parameters.Add(pTen);

                    SqlParameter pIDQuyTrinh = new SqlParameter("@IDQuyTrinh", SqlDbType.Int);
                    pIDQuyTrinh.Value = model.IDQuyTrinh;
                    myCommand.Parameters.Add(pIDQuyTrinh);

                    SqlParameter pTrangThai = new SqlParameter("@TrangThai", SqlDbType.Bit);
                    pTrangThai.Value = model.TrangThai;
                    myCommand.Parameters.Add(pTrangThai);

                    SqlParameter pNgayHieuLuc = new SqlParameter("@NgayBatDau", SqlDbType.DateTime);
                    pNgayHieuLuc.Value = model.NgayBatDau;
                    myCommand.Parameters.Add(pNgayHieuLuc);

                    SqlParameter pNgayTao = new SqlParameter("@NgayHoanThanh", SqlDbType.DateTime);
                    pNgayTao.Value = model.NgayHoanThanh;
                    myCommand.Parameters.Add(pNgayTao);

                    SqlParameter pNguoiTao = new SqlParameter("@NguoiTao", SqlDbType.Int);
                    pNguoiTao.Value = model.NguoiTao;
                    myCommand.Parameters.Add(pNguoiTao);

                    SqlParameter pFileDauVao = new SqlParameter("@FileDauVao", SqlDbType.NVarChar, 200);
                    pFileDauVao.Value = model.FileDauVao;
                    myCommand.Parameters.Add(pFileDauVao);

                    SqlParameter pFileKQ = new SqlParameter("@FileKQ", SqlDbType.NVarChar, 200);
                    pFileKQ.Value = model.FileKQ;
                    myCommand.Parameters.Add(pFileKQ);

                    SqlParameter pNguoiYeuCau = new SqlParameter("@NguoiYeuCau", SqlDbType.NVarChar, 200);
                    pNguoiYeuCau.Value = model.NguoiYeuCau;
                    myCommand.Parameters.Add(pNguoiYeuCau);

                    SqlParameter pSoDienThoai = new SqlParameter("@SoDienThoai", SqlDbType.NVarChar, 50);
                    pSoDienThoai.Value = model.SoDienThoai;
                    myCommand.Parameters.Add(pSoDienThoai);

                    SqlParameter pEmail = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
                    pEmail.Value = model.Email;
                    myCommand.Parameters.Add(pEmail);

                    SqlParameter pDiaChi = new SqlParameter("@DiaChi", SqlDbType.NVarChar, 500);
                    pDiaChi.Value = model.DiaChi;
                    myCommand.Parameters.Add(pDiaChi);

                    SqlParameter pThongTin = new SqlParameter("@ThongTin", SqlDbType.NVarChar, 2000);
                    pThongTin.Value = model.ThongTin;
                    myCommand.Parameters.Add(pThongTin);

                    SqlParameter pGhiChu = new SqlParameter("@GhiChu", SqlDbType.NVarChar, 4000);
                    pGhiChu.Value = model.GhiChu;
                    myCommand.Parameters.Add(pGhiChu);
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
        public bool update(NV_QuyTrinhXuLy_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_QuyTrinhXuLy_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = model.ID;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pTen = new SqlParameter("@Ten", SqlDbType.NVarChar, 1000);
                    pTen.Value = model.Ten;
                    myCommand.Parameters.Add(pTen);

                    SqlParameter pIDQuyTrinh = new SqlParameter("@IDQuyTrinh", SqlDbType.Int);
                    pIDQuyTrinh.Value = model.IDQuyTrinh;
                    myCommand.Parameters.Add(pIDQuyTrinh);


                    SqlParameter pTrangThai = new SqlParameter("@TrangThai", SqlDbType.Bit);
                    pTrangThai.Value = model.TrangThai;
                    myCommand.Parameters.Add(pTrangThai);

                    SqlParameter pNgayHieuLuc = new SqlParameter("@NgayBatDau", SqlDbType.DateTime);
                    pNgayHieuLuc.Value = model.NgayBatDau;
                    myCommand.Parameters.Add(pNgayHieuLuc);

                    SqlParameter pNgayTao = new SqlParameter("@NgayHoanThanh", SqlDbType.DateTime);
                    pNgayTao.Value = model.NgayHoanThanh;
                    myCommand.Parameters.Add(pNgayTao);

                    SqlParameter pNguoiTao = new SqlParameter("@NguoiTao", SqlDbType.Int);
                    pNguoiTao.Value = model.NguoiTao;
                    myCommand.Parameters.Add(pNguoiTao);

                    SqlParameter pFileDauVao = new SqlParameter("@FileDauVao", SqlDbType.NVarChar, 200);
                    pFileDauVao.Value = model.FileDauVao;
                    myCommand.Parameters.Add(pFileDauVao);

                    SqlParameter pFileKQ = new SqlParameter("@FileKQ", SqlDbType.NVarChar, 200);
                    pFileKQ.Value = model.FileKQ;
                    myCommand.Parameters.Add(pFileKQ);

                    SqlParameter pNguoiYeuCau = new SqlParameter("@NguoiYeuCau", SqlDbType.NVarChar, 200);
                    pNguoiYeuCau.Value = model.NguoiYeuCau;
                    myCommand.Parameters.Add(pNguoiYeuCau);

                    SqlParameter pSoDienThoai = new SqlParameter("@SoDienThoai", SqlDbType.NVarChar, 50);
                    pSoDienThoai.Value = model.SoDienThoai;
                    myCommand.Parameters.Add(pSoDienThoai);

                    SqlParameter pEmail = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
                    pEmail.Value = model.Email;
                    myCommand.Parameters.Add(pEmail);

                    SqlParameter pDiaChi = new SqlParameter("@DiaChi", SqlDbType.NVarChar, 500);
                    pDiaChi.Value = model.DiaChi;
                    myCommand.Parameters.Add(pDiaChi);

                    SqlParameter pThongTin = new SqlParameter("@ThongTin", SqlDbType.NVarChar, 2000);
                    pThongTin.Value = model.ThongTin;
                    myCommand.Parameters.Add(pThongTin);
                    SqlParameter pGhiChu = new SqlParameter("@GhiChu", SqlDbType.NVarChar, 4000);
                    pGhiChu.Value = model.GhiChu;
                    myCommand.Parameters.Add(pGhiChu);
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
                using (SqlCommand myCommand = new SqlCommand("NV_QuyTrinhXuLy_del", myConnection))
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
