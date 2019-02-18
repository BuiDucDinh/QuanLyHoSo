using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic
{
    public class NV_QuyTrinhDinhNghia_ChiTiet
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public int LoaiQuyTrinh { get; set; }
        public string TenLoai { get; set; }
        public bool TrangThai { get; set; }
        public DateTime? NgayHieuLuc { get; set; }
        public DateTime? NgayTao { get; set; }
        public int NguoiTao { get; set; }
        public string ChuanBi { get; set; }
        public string CachThuc { get; set; }
        public string ThoiHan { get; set; }
        public string DoiTuong { get; set; }
        public int CoQuanID { get; set; }
        public string CoQuan { get; set; }
        public string KetQua { get; set; }
        public string YeuCau { get; set; }
        public string LePhi { get; set; }
        public string MauDon { get; set; }
        public string PhapLy { get; set; }
        public string TrinhTu { get; set; }

        public NV_QuyTrinhDinhNghia_ChiTiet(DataRow dr)
        {
            ID = int.Parse(dr["ID"].ToString());
            Ten = dr["Ten"].ToString();
            LoaiQuyTrinh = int.Parse(dr["LoaiQuyTrinh"].ToString());
            TrangThai = Convert.ToBoolean(dr["TrangThai"].ToString());
            NguoiTao = int.Parse(dr["NguoiTao"].ToString());
            try
            {
                NgayHieuLuc = Convert.ToDateTime(dr["NgayHieuLuc"].ToString());
            }
            catch { }
            try
            {
                NgayTao = Convert.ToDateTime(dr["NgayTao"].ToString());
            }
            catch { }
            ChuanBi = dr["ChuanBi"].ToString();
            CachThuc = dr["CachThuc"].ToString();
            ThoiHan = dr["ThoiHan"].ToString();
            DoiTuong = dr["DoiTuong"].ToString();
            try
            {
                CoQuanID = int.Parse(dr["CoQuanID"].ToString());
            }
            catch { }
            KetQua = dr["KetQua"].ToString();
            YeuCau = dr["YeuCau"].ToString();
            LePhi = dr["LePhi"].ToString();
            MauDon = dr["MauDon"].ToString();
            PhapLy = dr["PhapLy"].ToString();
            TrinhTu = dr["TrinhTu"].ToString();
            CoQuan = dr["CoQuan"].ToString();
        }
        public NV_QuyTrinhDinhNghia_ChiTiet() { }
    }
    public class NV_QuyTrinhDinhNghia
    {
        private string ConnectionString;
        public NV_QuyTrinhDinhNghia(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region active quy trình
        public bool Active(int id, int loaiqt)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_QuyTrinhDinhNghia_active", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pLoaiQuyTrinh = new SqlParameter("@LoaiQuyTrinh", SqlDbType.Int);
                    pLoaiQuyTrinh.Value = loaiqt;
                    myCommand.Parameters.Add(pLoaiQuyTrinh);
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
        #region Lấy theo ID
        public NV_QuyTrinhDinhNghia_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_QuyTrinhDinhNghia_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    DataTable dt;
                    NV_QuyTrinhDinhNghia_ChiTiet model = new NV_QuyTrinhDinhNghia_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_QuyTrinhDinhNghia_ChiTiet(dt.Rows[0]);
                    }
                    return model;
                }
            }
        }
        #endregion

        #region Lấy theo loại và đang active
        public NV_QuyTrinhDinhNghia_ChiTiet GetByLoaiActive(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_QuyTrinhDinhNghia_getByLoaiActive", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pID = new SqlParameter("@LoaiQuyTrinh", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    DataTable dt;
                    NV_QuyTrinhDinhNghia_ChiTiet model = new NV_QuyTrinhDinhNghia_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_QuyTrinhDinhNghia_ChiTiet(dt.Rows[0]);

                    }
                    return model;
                }
            }
        }
        #endregion

        #region Lấy quy trinh active
        public DataTable GetActive()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_QuyTrinhDinhNghia_getActive", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_QuyTrinhDinhNghia_getActive");
                    return myDataSet.Tables["NV_QuyTrinhDinhNghia_getActive"];

                }
            }
        }

        #endregion
        #region Lấy tất cả
        public DataTable GetAll()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_QuyTrinhDinhNghia_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_QuyTrinhDinhNghia_getAll");
                    return myDataSet.Tables["NV_QuyTrinhDinhNghia_getAll"];

                }
            }
        }

        #endregion
        #region Lấy theo loại
        public DataTable GetByLoai(int idLoai)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_QuyTrinhDinhNghia_getByLoai", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pID = new SqlParameter("@LoaiQuyTrinh", SqlDbType.Int);
                    pID.Value = idLoai;
                    myCommand.Parameters.Add(pID);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_QuyTrinhDinhNghia_getByLoai");
                    return myDataSet.Tables["NV_QuyTrinhDinhNghia_getByLoai"];

                }
            }
        }

        #endregion
        #region Thêm
        public bool them(NV_QuyTrinhDinhNghia_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_QuyTrinhDinhNghia_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;


                    SqlParameter pTen = new SqlParameter("@Ten", SqlDbType.NVarChar, 1000);
                    pTen.Value = model.Ten;
                    myCommand.Parameters.Add(pTen);

                    SqlParameter pLoaiQuyTrinh = new SqlParameter("@LoaiQuyTrinh", SqlDbType.Int);
                    pLoaiQuyTrinh.Value = model.LoaiQuyTrinh;
                    myCommand.Parameters.Add(pLoaiQuyTrinh);

                    SqlParameter pTrangThai = new SqlParameter("@TrangThai", SqlDbType.Bit);
                    pTrangThai.Value = model.TrangThai;
                    myCommand.Parameters.Add(pTrangThai);

                    SqlParameter pNgayHieuLuc = new SqlParameter("@NgayHieuLuc", SqlDbType.DateTime);
                    pNgayHieuLuc.Value = model.NgayHieuLuc;
                    myCommand.Parameters.Add(pNgayHieuLuc);

                    SqlParameter pNgayTao = new SqlParameter("@NgayTao", SqlDbType.DateTime);
                    pNgayTao.Value = model.NgayTao;
                    myCommand.Parameters.Add(pNgayTao);

                    SqlParameter pNguoiTao = new SqlParameter("@NguoiTao", SqlDbType.Int);
                    pNguoiTao.Value = model.NguoiTao;
                    myCommand.Parameters.Add(pNguoiTao);

                    SqlParameter pChuanBi = new SqlParameter("@ChuanBi", SqlDbType.NVarChar, 4000);
                    pChuanBi.Value = model.ChuanBi;
                    myCommand.Parameters.Add(pChuanBi);


                    SqlParameter pCachThuc = new SqlParameter("@CachThuc", SqlDbType.NVarChar, 200);
                    pCachThuc.Value = model.CachThuc;
                    myCommand.Parameters.Add(pCachThuc);

                    SqlParameter pThoiHan = new SqlParameter("@ThoiHan", SqlDbType.NVarChar, 200);
                    pThoiHan.Value = model.ThoiHan;
                    myCommand.Parameters.Add(pThoiHan);

                    SqlParameter pDoiTuong = new SqlParameter("@DoiTuong", SqlDbType.NVarChar, 200);
                    pDoiTuong.Value = model.DoiTuong;
                    myCommand.Parameters.Add(pDoiTuong);

                    SqlParameter pCoQuan = new SqlParameter("@CoQuan", SqlDbType.Int);
                    pCoQuan.Value = model.CoQuanID;
                    myCommand.Parameters.Add(pCoQuan);

                    SqlParameter pKetQua = new SqlParameter("@KetQua", SqlDbType.NVarChar, 200);
                    pKetQua.Value = model.KetQua;
                    myCommand.Parameters.Add(pKetQua);

                    SqlParameter pYeuCau = new SqlParameter("@YeuCau", SqlDbType.NText);
                    pYeuCau.Value = model.YeuCau;
                    myCommand.Parameters.Add(pYeuCau);

                    SqlParameter pLePhi = new SqlParameter("@LePhi", SqlDbType.NVarChar, 200);
                    pLePhi.Value = model.LePhi;
                    myCommand.Parameters.Add(pLePhi);

                    SqlParameter pMauDon = new SqlParameter("@MauDon", SqlDbType.NText);
                    pMauDon.Value = model.MauDon;
                    myCommand.Parameters.Add(pMauDon);

                    SqlParameter pPhapLy = new SqlParameter("@PhapLy", SqlDbType.NText);
                    pPhapLy.Value = model.PhapLy;
                    myCommand.Parameters.Add(pPhapLy);

                    SqlParameter pTrinhTu = new SqlParameter("@TrinhTu", SqlDbType.NText);
                    pTrinhTu.Value = model.TrinhTu;
                    myCommand.Parameters.Add(pTrinhTu);

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
        public bool update(NV_QuyTrinhDinhNghia_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_QuyTrinhDinhNghia_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = model.ID;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pTen = new SqlParameter("@Ten", SqlDbType.NVarChar, 1000);
                    pTen.Value = model.Ten;
                    myCommand.Parameters.Add(pTen);

                    SqlParameter pLoaiQuyTrinh = new SqlParameter("@LoaiQuyTrinh", SqlDbType.Int);
                    pLoaiQuyTrinh.Value = model.LoaiQuyTrinh;
                    myCommand.Parameters.Add(pLoaiQuyTrinh);

                    SqlParameter pTrangThai = new SqlParameter("@TrangThai", SqlDbType.Bit);
                    pTrangThai.Value = model.TrangThai;
                    myCommand.Parameters.Add(pTrangThai);

                    SqlParameter pNgayHieuLuc = new SqlParameter("@NgayHieuLuc", SqlDbType.DateTime);
                    pNgayHieuLuc.Value = model.NgayHieuLuc;
                    myCommand.Parameters.Add(pNgayHieuLuc);

                    SqlParameter pNgayTao = new SqlParameter("@NgayTao", SqlDbType.DateTime);
                    pNgayTao.Value = model.NgayTao;
                    myCommand.Parameters.Add(pNgayTao);

                    SqlParameter pNguoiTao = new SqlParameter("@NguoiTao", SqlDbType.Int);
                    pNguoiTao.Value = model.NguoiTao;
                    myCommand.Parameters.Add(pNguoiTao);

                    SqlParameter pChuanBi = new SqlParameter("@ChuanBi", SqlDbType.NVarChar, 4000);
                    pChuanBi.Value = model.ChuanBi;
                    myCommand.Parameters.Add(pChuanBi);


                    SqlParameter pCachThuc = new SqlParameter("@CachThuc", SqlDbType.NVarChar, 200);
                    pCachThuc.Value = model.CachThuc;
                    myCommand.Parameters.Add(pCachThuc);

                    SqlParameter pThoiHan = new SqlParameter("@ThoiHan", SqlDbType.NVarChar, 200);
                    pThoiHan.Value = model.ThoiHan;
                    myCommand.Parameters.Add(pThoiHan);

                    SqlParameter pDoiTuong = new SqlParameter("@DoiTuong", SqlDbType.NVarChar, 200);
                    pDoiTuong.Value = model.DoiTuong;
                    myCommand.Parameters.Add(pDoiTuong);

                    SqlParameter pCoQuan = new SqlParameter("@CoQuan", SqlDbType.Int);
                    pCoQuan.Value = model.CoQuanID;
                    myCommand.Parameters.Add(pCoQuan);

                    SqlParameter pKetQua = new SqlParameter("@KetQua", SqlDbType.NVarChar, 200);
                    pKetQua.Value = model.KetQua;
                    myCommand.Parameters.Add(pKetQua);

                    SqlParameter pYeuCau = new SqlParameter("@YeuCau", SqlDbType.NText);
                    pYeuCau.Value = model.YeuCau;
                    myCommand.Parameters.Add(pYeuCau);

                    SqlParameter pLePhi = new SqlParameter("@LePhi", SqlDbType.NVarChar, 200);
                    pLePhi.Value = model.LePhi;
                    myCommand.Parameters.Add(pLePhi);

                    SqlParameter pMauDon = new SqlParameter("@MauDon", SqlDbType.NText);
                    pMauDon.Value = model.MauDon;
                    myCommand.Parameters.Add(pMauDon);

                    SqlParameter pPhapLy = new SqlParameter("@PhapLy", SqlDbType.NText);
                    pPhapLy.Value = model.PhapLy;
                    myCommand.Parameters.Add(pPhapLy);

                    SqlParameter pTrinhTu = new SqlParameter("@TrinhTu", SqlDbType.NText);
                    pTrinhTu.Value = model.TrinhTu;
                    myCommand.Parameters.Add(pTrinhTu);
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
                using (SqlCommand myCommand = new SqlCommand("NV_QuyTrinhDinhNghia_del", myConnection))
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
