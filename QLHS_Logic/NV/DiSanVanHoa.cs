using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_DiSanVanHoa_ChiTiet
    {
        public int DiSanID { get; set; }
        public string TenDiSan { get; set; }
        public string MaDiSan { get; set; }
        public string TenGoiKhac { get; set; }
        public int LoaiDiSan { get; set; }
        public string ChuTheVanHoa { get; set; }
        public string ThuocTinh { get; set; }
        public string ThuocHuyen { get; set; }
        public string ThuocXa { get; set; }
        public DateTime? NgayChungNhan { get; set; }
        public string MoTa { get; set; }
        public string HienTrang { get; set; }
        public int CapDiSan { get; set; }
        public int DonViQuanLy { get; set; }
        public string GiaTriDanhGia { get; set; }
        public string DeXuat { get; set; }
        public string TaiLieu { get; set; }
        public string ChiPhiDuyTri { get; set; }
        public string SoLuotKhach { get; set; }
        public string SoDangKy { get; set; }
        public string HinhAnh { get; set; }
        public string DanhMucDS { get; set; }
        public string Url { get; set; }
        public int AnhDaiDien { get; set; }
        public bool TrangThai { get; set; }
        public string Video { get; set; }
        public string LyLich { get; set; }
        public string NienDai { get; set; }
        public string MatBangTongThe { get; set; }
        public string BanDoKhoanhVung { get; set; }
        public string QuyHoach { get; set; }
        public int NguoiTao { get; set; }
        public DateTime NgayTao { get; set; }
        public bool Duyet { get; set; }
        public bool TonTai { get; set; }
        public int DiSanLQ { get; set; }
        public bool NoiBat { get; set; }
        public string DiaDiem { get; set; }
        public string AnhBanDo { get; set; }
        public string TenAnhBanDo { get; set; }
        public int STT { get; set; }
        public string FileQuyetDinh { get; set; }
        public string ThoiGianDienRa { get; set; }
        public string ThongKeHienVat { get; set; }
        public string Lang { get; set; }
        public NV_DiSanVanHoa_ChiTiet(DataTable dt)
        {
            DiSanID = int.Parse(dt.Rows[0]["DiSanID"].ToString());
            MaDiSan = dt.Rows[0]["MaDiSan"].ToString();
            TenDiSan = dt.Rows[0]["TenDiSan"].ToString();
            TenGoiKhac = dt.Rows[0]["TenGoiKhac"].ToString();
            LoaiDiSan = int.Parse(dt.Rows[0]["LoaiDiSan"].ToString());
            ChuTheVanHoa = dt.Rows[0]["ChuTheVanHoa"].ToString();
            ThuocTinh = dt.Rows[0]["ThuocTinh"].ToString();
            ThuocHuyen = dt.Rows[0]["ThuocHuyen"].ToString();
            ThuocXa = dt.Rows[0]["ThuocXa"].ToString();
            Video = dt.Rows[0]["Video"].ToString();
            LyLich = dt.Rows[0]["LyLich"].ToString();
            NienDai = dt.Rows[0]["NienDai"].ToString();
            MatBangTongThe = dt.Rows[0]["MatBangTongThe"].ToString();
            BanDoKhoanhVung = dt.Rows[0]["BanDoKhoanhVung"].ToString();
            QuyHoach = dt.Rows[0]["QuyHoach"].ToString();
            try
            {
                DiaDiem = dt.Rows[0]["DiaDiem"].ToString();
            }
            catch { }
            try
            {
                NgayChungNhan = Convert.ToDateTime(dt.Rows[0]["NgayChungNhan"].ToString());
            }
            catch { }
            MoTa = dt.Rows[0]["MoTa"].ToString();
            HienTrang = dt.Rows[0]["HienTrang"].ToString();
            try
            {
                DonViQuanLy = int.Parse(dt.Rows[0]["DonViQuanLy"].ToString());
            }
            catch { }
            try
            {
                FileQuyetDinh = dt.Rows[0]["FileQuyetDinh"].ToString();
            }
            catch { }
            GiaTriDanhGia = dt.Rows[0]["GiaTriDanhGia"].ToString();
            DeXuat = dt.Rows[0]["DeXuat"].ToString();
            TaiLieu = dt.Rows[0]["TaiLieu"].ToString();
            ChiPhiDuyTri = dt.Rows[0]["ChiPhiDuyTri"].ToString();
            SoLuotKhach = dt.Rows[0]["SoLuotKhach"].ToString();
            SoDangKy = dt.Rows[0]["SoDangKy"].ToString();
            HinhAnh = dt.Rows[0]["HinhAnh"].ToString();
            CapDiSan = int.Parse(dt.Rows[0]["CapDiSan"].ToString());
            DanhMucDS = dt.Rows[0]["DanhMucDS"].ToString();
            Url = dt.Rows[0]["Url"].ToString();
            try
            {
                STT = int.Parse(dt.Rows[0]["STT"].ToString());
            }
            catch { }
            try
            {
                AnhBanDo = dt.Rows[0]["AnhBanDo"].ToString();
            }
            catch { }
            TenAnhBanDo = dt.Rows[0]["TenAnhBanDo"].ToString();
            try
            {
                TrangThai = Convert.ToBoolean(dt.Rows[0]["TrangThai"]);
            }
            catch { TrangThai = false; }
            try
            {
                AnhDaiDien = int.Parse(dt.Rows[0]["AnhDaiDien"].ToString());
            }
            catch
            {
                AnhDaiDien = 0;
            }
            NguoiTao = int.Parse(dt.Rows[0]["NguoiTao"].ToString());
            NgayTao = Convert.ToDateTime(dt.Rows[0]["NgayTao"].ToString());
            TonTai = Convert.ToBoolean(dt.Rows[0]["TonTai"].ToString());
            NoiBat = Convert.ToBoolean(dt.Rows[0]["NoiBat"].ToString());
            DiSanLQ = int.Parse(dt.Rows[0]["DiSanLQ"].ToString());
            ThoiGianDienRa = dt.Rows[0]["ThoiGianDienRa"].ToString();
            ThongKeHienVat = dt.Rows[0]["ThongKeHienVat"].ToString();
            Lang= dt.Rows[0]["Lang"].ToString();
        }
        public NV_DiSanVanHoa_ChiTiet()
        { }
    }

    public class NV_DiSanVanHoa
    {
        private string ConnectionString;
        public NV_DiSanVanHoa(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }

        #region Lấy theo ID
        public NV_DiSanVanHoa_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DiSanVanHoa_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@id", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    DataTable dt;
                    NV_DiSanVanHoa_ChiTiet model = new NV_DiSanVanHoa_ChiTiet();
                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_DiSanVanHoa_ChiTiet(dt);
                    }
                    return model;
                }
            }
        }
        #endregion
        #region Lấy theo ID
        public DataTable GetByIdTable(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DiSanVanHoa_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@id", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    DataTable dt;
                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    foreach (DataRow dr in dt.Rows)
                    {
                        dr["TenAnh"] = "/FileUpload/images/" + dr["TenAnh"].ToString();
                    }
                    return dt;
                }
            }
        }
        #endregion
        #region Lấy theo url
        public NV_DiSanVanHoa_ChiTiet GetByUrl(string url)
        {
            //string sql = "select top 1 *,(select TenAnh from Image where ImageID=AnhBanDo) as TenAnhBanDo from DiSanVanHoa where Url='" + url + "'";
            string sql = "select top 1 *,'' as TenAnhBanDo from DiSanVanHoa where Url='" + url + "'";
            DataTable dt = Sys_Common.getDataByQuery(sql);
            NV_DiSanVanHoa_ChiTiet ds = new NV_DiSanVanHoa_ChiTiet();
            if (dt != null && dt.Rows.Count > 0)
            {
                ds = new NV_DiSanVanHoa_ChiTiet(dt);
            }
            return ds;
        }
        #endregion
        #region Lấy theo loai vật thể hoặc phi vật thể /// 0:phi vật thể; 1:vật thể
        public DataTable GetByLoai(int loai,string lang="vi")
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DiSanVanHoa_getByLoai", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pTrangThai = new SqlParameter("@Loai", SqlDbType.TinyInt);
                    pTrangThai.Value = loai;
                    myCommand.Parameters.Add(pTrangThai);

                    SqlParameter pLang = new SqlParameter("@Lang", SqlDbType.VarChar,10);
                    pLang.Value = loai;
                    myCommand.Parameters.Add(pLang);
                    SqlDataAdapter myAdapter = new SqlDataAdapter();

                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_DiSanVanHoa_getByLoai");
                    return myDataSet.Tables["NV_DiSanVanHoa_getByLoai"];

                }
            }
        }

        #endregion
        #region Lọc điều kiện
        public DataTable GetResult(string ten, int loai, int cap, DateTime? tungay, DateTime? denngay, string tinh, string huyen, string xa,string lang)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DiSanVanHoa_result", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pTen = new SqlParameter("@TenDiSan", SqlDbType.NVarChar, 250);
                    pTen.Value = ten;
                    myCommand.Parameters.Add(pTen);

                    SqlParameter pLoai = new SqlParameter("@LoaiDiSan", SqlDbType.Int);
                    pLoai.Value = loai;
                    myCommand.Parameters.Add(pLoai);


                    SqlParameter pCap = new SqlParameter("@CapDiSan", SqlDbType.Int);
                    pCap.Value = cap;
                    myCommand.Parameters.Add(pCap);

                    SqlParameter pTungay = new SqlParameter("@TuNgay", SqlDbType.DateTime);
                    pTungay.Value = tungay;
                    myCommand.Parameters.Add(pTungay);

                    SqlParameter pDenngay = new SqlParameter("@DenNgay", SqlDbType.DateTime);
                    pDenngay.Value = denngay;
                    myCommand.Parameters.Add(pDenngay);

                    SqlParameter pTinh = new SqlParameter("@Tinh", SqlDbType.VarChar, 10);
                    pTinh.Value = tinh;
                    myCommand.Parameters.Add(pTinh);

                    SqlParameter pHuyen = new SqlParameter("@Huyen", SqlDbType.VarChar, 10);
                    pHuyen.Value = huyen;
                    myCommand.Parameters.Add(pHuyen);

                    SqlParameter pXa = new SqlParameter("@Xa", SqlDbType.VarChar, 10);
                    pXa.Value = xa;
                    myCommand.Parameters.Add(pXa);


                    SqlParameter pLang = new SqlParameter("@Lang", SqlDbType.VarChar, 10);
                    pLang.Value = lang;
                    myCommand.Parameters.Add(pLang);

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
        #region Lấy tất cả
        public DataTable GetAll(bool? trangthai,string lang)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DiSanVanHoa_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pTrangThai = new SqlParameter("@TrangThai", SqlDbType.Bit);
                    pTrangThai.Value = trangthai;
                    myCommand.Parameters.Add(pTrangThai);

                    SqlParameter pLang = new SqlParameter("@Lang", SqlDbType.VarChar,10);
                    pLang.Value = lang;
                    myCommand.Parameters.Add(pLang);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();

                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_DiSanVanHoa_getAll");
                    return myDataSet.Tables["NV_DiSanVanHoa_getAll"];

                }
            }
        }

        #endregion
        #region Thêm

        public bool them(NV_DiSanVanHoa_ChiTiet model, out int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DiSanVanHoa_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pDiSanID = new SqlParameter("@DiSanID", SqlDbType.Int);
                    pDiSanID.Value = ParameterDirection.Output;
                    myCommand.Parameters.Add(pDiSanID);

                    SqlParameter pMaDiSan = new SqlParameter("@MaDiSan", SqlDbType.NVarChar, 50);
                    pMaDiSan.Value = model.MaDiSan;
                    myCommand.Parameters.Add(pMaDiSan);

                    SqlParameter pTenDiSan = new SqlParameter("@TenDiSan", SqlDbType.NVarChar, 250);
                    pTenDiSan.Value = model.TenDiSan;
                    myCommand.Parameters.Add(pTenDiSan);

                    SqlParameter pTenGoiKhac = new SqlParameter("@TenGoiKhac", SqlDbType.NVarChar, 250);
                    pTenGoiKhac.Value = model.TenGoiKhac;
                    myCommand.Parameters.Add(pTenGoiKhac);


                    SqlParameter pLoaiDiSan = new SqlParameter("@LoaiDiSan", SqlDbType.Int);
                    pLoaiDiSan.Value = model.LoaiDiSan;
                    myCommand.Parameters.Add(pLoaiDiSan);

                    SqlParameter pChuTheVanHoa = new SqlParameter("@ChuTheVanHoa", SqlDbType.NText);
                    pChuTheVanHoa.Value = model.ChuTheVanHoa;
                    myCommand.Parameters.Add(pChuTheVanHoa);

                    SqlParameter pThuocTinh = new SqlParameter("@ThuocTinh", SqlDbType.VarChar, 10);
                    pThuocTinh.Value = model.ThuocTinh;
                    myCommand.Parameters.Add(pThuocTinh);

                    SqlParameter pThuocHuyen = new SqlParameter("@ThuocHuyen", SqlDbType.VarChar, 10);
                    pThuocHuyen.Value = model.ThuocHuyen;
                    myCommand.Parameters.Add(pThuocHuyen);

                    SqlParameter pThuocXa = new SqlParameter("@ThuocXa", SqlDbType.VarChar, 10);
                    pThuocXa.Value = model.ThuocXa;
                    myCommand.Parameters.Add(pThuocXa);

                    SqlParameter pNgayChungNhan = new SqlParameter("@NgayChungNhan", SqlDbType.DateTime);
                    pNgayChungNhan.Value = model.NgayChungNhan;
                    myCommand.Parameters.Add(pNgayChungNhan);

                    SqlParameter pMota = new SqlParameter("@Mota", SqlDbType.NText);
                    pMota.Value = model.MoTa;
                    myCommand.Parameters.Add(pMota);

                    SqlParameter pHienTrang = new SqlParameter("@HienTrang", SqlDbType.NText);
                    pHienTrang.Value = model.HienTrang;
                    myCommand.Parameters.Add(pHienTrang);

                    SqlParameter pDonViQuanLy = new SqlParameter("@DonViQuanLy", SqlDbType.Int);
                    pDonViQuanLy.Value = model.DonViQuanLy;
                    myCommand.Parameters.Add(pDonViQuanLy);

                    SqlParameter pGiaTriDanhGia = new SqlParameter("@GiaTriDanhGia", SqlDbType.NText);
                    pGiaTriDanhGia.Value = model.GiaTriDanhGia;
                    myCommand.Parameters.Add(pGiaTriDanhGia);

                    SqlParameter pDeXuat = new SqlParameter("@DeXuat", SqlDbType.NText);
                    pDeXuat.Value = model.DeXuat;
                    myCommand.Parameters.Add(pDeXuat);

                    SqlParameter pTaiLieu = new SqlParameter("@TaiLieu", SqlDbType.NVarChar, 500);
                    pTaiLieu.Value = model.TaiLieu;
                    myCommand.Parameters.Add(pTaiLieu);

                    SqlParameter pChiPhiDuyTri = new SqlParameter("@ChiPhiDuyTri", SqlDbType.NVarChar, 500);
                    pChiPhiDuyTri.Value = model.ChiPhiDuyTri;
                    myCommand.Parameters.Add(pChiPhiDuyTri);

                    SqlParameter pSoLuotKhach = new SqlParameter("@SoLuotKhach", SqlDbType.NVarChar, 50);
                    pSoLuotKhach.Value = model.SoLuotKhach;
                    myCommand.Parameters.Add(pSoLuotKhach);

                    SqlParameter pSoDangKy = new SqlParameter("@SoDangKy", SqlDbType.NVarChar, 20);
                    pSoDangKy.Value = model.SoDangKy;
                    myCommand.Parameters.Add(pSoDangKy);

                    SqlParameter pHinhAnh = new SqlParameter("@HinhAnh", SqlDbType.NVarChar, 500);
                    pHinhAnh.Value = model.HinhAnh;
                    myCommand.Parameters.Add(pHinhAnh);

                    SqlParameter pCapDiSan = new SqlParameter("@CapDiSan", SqlDbType.Int);
                    pCapDiSan.Value = model.CapDiSan;
                    myCommand.Parameters.Add(pCapDiSan);


                    SqlParameter pDanhMuc = new SqlParameter("@DanhMucDS", SqlDbType.NVarChar, 250);
                    pDanhMuc.Value = model.DanhMucDS;
                    myCommand.Parameters.Add(pDanhMuc);

                    SqlParameter pUrl = new SqlParameter("@Url", SqlDbType.NVarChar, 250);
                    pUrl.Value = model.Url;
                    myCommand.Parameters.Add(pUrl);

                    SqlParameter pAnhDaiDien = new SqlParameter("@AnhDaiDien", SqlDbType.Int);
                    pAnhDaiDien.Value = model.AnhDaiDien;
                    myCommand.Parameters.Add(pAnhDaiDien);

                    //SqlParameter pTrangThai = new SqlParameter("@TrangThai", SqlDbType.Bit);
                    //pTrangThai.Value = model.TrangThai;
                    //myCommand.Parameters.Add(pTrangThai);

                    SqlParameter pVideo = new SqlParameter("@Video", SqlDbType.NVarChar, 10);
                    pVideo.Value = model.Video;
                    myCommand.Parameters.Add(pVideo);

                    SqlParameter pLyLich = new SqlParameter("@LyLich", SqlDbType.NText);
                    pLyLich.Value = model.LyLich;
                    myCommand.Parameters.Add(pLyLich);

                    SqlParameter pNienDai = new SqlParameter("@NienDai", SqlDbType.NText);
                    pNienDai.Value = model.NienDai;
                    myCommand.Parameters.Add(pNienDai);

                    SqlParameter pMatBangTongThe = new SqlParameter("@MatBangTongThe", SqlDbType.NVarChar, 500);
                    pMatBangTongThe.Value = model.MatBangTongThe;
                    myCommand.Parameters.Add(pMatBangTongThe);

                    SqlParameter pBanDoKhoanhVung = new SqlParameter("@BanDoKhoanhVung", SqlDbType.NVarChar, 500);
                    pBanDoKhoanhVung.Value = model.BanDoKhoanhVung;
                    myCommand.Parameters.Add(pBanDoKhoanhVung);

                    SqlParameter pQuyHoach = new SqlParameter("@QuyHoach", SqlDbType.NVarChar, 500);
                    pQuyHoach.Value = model.QuyHoach;
                    myCommand.Parameters.Add(pQuyHoach);

                    SqlParameter pNguoiTao = new SqlParameter("@NguoiTao", SqlDbType.Int);
                    pNguoiTao.Value = model.NguoiTao;
                    myCommand.Parameters.Add(pNguoiTao);

                    SqlParameter pDiSanLQ = new SqlParameter("@DiSanLQ", SqlDbType.Int);
                    pDiSanLQ.Value = model.DiSanLQ;
                    myCommand.Parameters.Add(pDiSanLQ);

                    SqlParameter pAnhBanDo = new SqlParameter("@AnhBanDo", SqlDbType.NVarChar, 500);
                    pAnhBanDo.Value = model.AnhBanDo;
                    myCommand.Parameters.Add(pAnhBanDo);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int);
                    pSTT.Value = model.STT;
                    myCommand.Parameters.Add(pSTT);

                    SqlParameter pFileQuyetDinh = new SqlParameter("@FileQuyetDinh", SqlDbType.NVarChar,500);
                    pFileQuyetDinh.Value = model.FileQuyetDinh;
                    myCommand.Parameters.Add(pFileQuyetDinh);

                    SqlParameter pThoiGianDienRa = new SqlParameter("@ThoiGianDienRa", SqlDbType.NVarChar, 500);
                    pThoiGianDienRa.Value = model.ThoiGianDienRa;
                    myCommand.Parameters.Add(pThoiGianDienRa);

                    SqlParameter pThongKeHienVat = new SqlParameter("@ThongKeHienVat", SqlDbType.NVarChar, 500);
                    pThongKeHienVat.Value = model.ThongKeHienVat;
                    myCommand.Parameters.Add(pThongKeHienVat);

                    SqlParameter pLang = new SqlParameter("@Lang", SqlDbType.VarChar, 10);
                    pLang.Value = model.Lang;
                    myCommand.Parameters.Add(pLang);

                    try
                    {
                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                        id = (int)pDiSanID.Value;
                        return true;
                    }
                    catch
                    {
                        id = 0;
                        return false;
                    }
                }
            }
        }
        #endregion
        #region update
        public bool Update(NV_DiSanVanHoa_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DiSanVanHoa_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@DiSanID", SqlDbType.Int);
                    pID.Value = model.DiSanID;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pMaDiSan = new SqlParameter("@MaDiSan", SqlDbType.NVarChar, 50);
                    pMaDiSan.Value = model.MaDiSan;
                    myCommand.Parameters.Add(pMaDiSan);

                    SqlParameter pTenDiSan = new SqlParameter("@TenDiSan", SqlDbType.NVarChar, 250);
                    pTenDiSan.Value = model.TenDiSan;
                    myCommand.Parameters.Add(pTenDiSan);

                    SqlParameter pTenGoiKhac = new SqlParameter("@TenGoiKhac", SqlDbType.NVarChar, 250);
                    pTenGoiKhac.Value = model.TenGoiKhac;
                    myCommand.Parameters.Add(pTenGoiKhac);


                    SqlParameter pLoaiDiSan = new SqlParameter("@LoaiDiSan", SqlDbType.Int);
                    pLoaiDiSan.Value = model.LoaiDiSan;
                    myCommand.Parameters.Add(pLoaiDiSan);

                    SqlParameter pChuTheVanHoa = new SqlParameter("@ChuTheVanHoa", SqlDbType.NText);
                    pChuTheVanHoa.Value = model.ChuTheVanHoa;
                    myCommand.Parameters.Add(pChuTheVanHoa);

                    SqlParameter pThuocTinh = new SqlParameter("@ThuocTinh", SqlDbType.VarChar, 10);
                    pThuocTinh.Value = model.ThuocTinh;
                    myCommand.Parameters.Add(pThuocTinh);

                    SqlParameter pThuocHuyen = new SqlParameter("@ThuocHuyen", SqlDbType.VarChar, 10);
                    pThuocHuyen.Value = model.ThuocHuyen;
                    myCommand.Parameters.Add(pThuocHuyen);

                    SqlParameter pThuocXa = new SqlParameter("@ThuocXa", SqlDbType.VarChar, 10);
                    pThuocXa.Value = model.ThuocXa;
                    myCommand.Parameters.Add(pThuocXa);

                    SqlParameter pNgayChungNhan = new SqlParameter("@NgayChungNhan", SqlDbType.DateTime);
                    pNgayChungNhan.Value = model.NgayChungNhan;
                    myCommand.Parameters.Add(pNgayChungNhan);

                    SqlParameter pMota = new SqlParameter("@Mota", SqlDbType.NText);
                    pMota.Value = model.MoTa;
                    myCommand.Parameters.Add(pMota);

                    SqlParameter pHienTrang = new SqlParameter("@HienTrang", SqlDbType.NText);
                    pHienTrang.Value = model.HienTrang;
                    myCommand.Parameters.Add(pHienTrang);

                    SqlParameter pDonViQuanLy = new SqlParameter("@DonViQuanLy", SqlDbType.Int);
                    pDonViQuanLy.Value = model.DonViQuanLy;
                    myCommand.Parameters.Add(pDonViQuanLy);

                    SqlParameter pGiaTriDanhGia = new SqlParameter("@GiaTriDanhGia", SqlDbType.NText);
                    pGiaTriDanhGia.Value = model.GiaTriDanhGia;
                    myCommand.Parameters.Add(pGiaTriDanhGia);

                    SqlParameter pDeXuat = new SqlParameter("@DeXuat", SqlDbType.NText);
                    pDeXuat.Value = model.DeXuat;
                    myCommand.Parameters.Add(pDeXuat);

                    SqlParameter pTaiLieu = new SqlParameter("@TaiLieu", SqlDbType.NVarChar, 500);
                    pTaiLieu.Value = model.TaiLieu;
                    myCommand.Parameters.Add(pTaiLieu);

                    SqlParameter pChiPhiDuyTri = new SqlParameter("@ChiPhiDuyTri", SqlDbType.NVarChar, 500);
                    pChiPhiDuyTri.Value = model.ChiPhiDuyTri;
                    myCommand.Parameters.Add(pChiPhiDuyTri);

                    SqlParameter pSoLuotKhach = new SqlParameter("@SoLuotKhach", SqlDbType.NVarChar, 50);
                    pSoLuotKhach.Value = model.SoLuotKhach;
                    myCommand.Parameters.Add(pSoLuotKhach);

                    SqlParameter pSoDangKy = new SqlParameter("@SoDangKy", SqlDbType.NVarChar, 20);
                    pSoDangKy.Value = model.SoDangKy;
                    myCommand.Parameters.Add(pSoDangKy);

                    SqlParameter pHinhAnh = new SqlParameter("@HinhAnh", SqlDbType.NVarChar, 500);
                    pHinhAnh.Value = model.HinhAnh;
                    myCommand.Parameters.Add(pHinhAnh);

                    SqlParameter pCapDiSan = new SqlParameter("@CapDiSan", SqlDbType.Int);
                    pCapDiSan.Value = model.CapDiSan;
                    myCommand.Parameters.Add(pCapDiSan);


                    SqlParameter pDanhMuc = new SqlParameter("@DanhMucDS", SqlDbType.NVarChar, 250);
                    pDanhMuc.Value = model.DanhMucDS;
                    myCommand.Parameters.Add(pDanhMuc);


                    SqlParameter pUrl = new SqlParameter("@Url", SqlDbType.NVarChar, 250);
                    pUrl.Value = model.Url;
                    myCommand.Parameters.Add(pUrl);

                    SqlParameter pAnhDaiDien = new SqlParameter("@AnhDaiDien", SqlDbType.Int);
                    pAnhDaiDien.Value = model.AnhDaiDien;
                    myCommand.Parameters.Add(pAnhDaiDien);

                    SqlParameter pTrangThai = new SqlParameter("@TrangThai", SqlDbType.Bit);
                    pTrangThai.Value = model.TrangThai;
                    myCommand.Parameters.Add(pTrangThai);

                    SqlParameter pVideo = new SqlParameter("@Video", SqlDbType.NVarChar, 10);
                    pVideo.Value = model.Video;
                    myCommand.Parameters.Add(pVideo);

                    SqlParameter pLyLich = new SqlParameter("@LyLich", SqlDbType.NText);
                    pLyLich.Value = model.LyLich;
                    myCommand.Parameters.Add(pLyLich);

                    SqlParameter pNienDai = new SqlParameter("@NienDai", SqlDbType.NText);
                    pNienDai.Value = model.NienDai;
                    myCommand.Parameters.Add(pNienDai);

                    SqlParameter pMatBangTongThe = new SqlParameter("@MatBangTongThe", SqlDbType.NVarChar, 500);
                    pMatBangTongThe.Value = model.MatBangTongThe;
                    myCommand.Parameters.Add(pMatBangTongThe);

                    SqlParameter pBanDoKhoanhVung = new SqlParameter("@BanDoKhoanhVung", SqlDbType.NVarChar, 500);
                    pBanDoKhoanhVung.Value = model.BanDoKhoanhVung;
                    myCommand.Parameters.Add(pBanDoKhoanhVung);

                    SqlParameter pQuyHoach = new SqlParameter("@QuyHoach", SqlDbType.NVarChar, 500);
                    pQuyHoach.Value = model.QuyHoach;
                    myCommand.Parameters.Add(pQuyHoach);

                    SqlParameter pNoiBat = new SqlParameter("@NoiBat", SqlDbType.Bit);
                    pNoiBat.Value = model.NoiBat;
                    myCommand.Parameters.Add(pNoiBat);

                    SqlParameter pDiSanLQ = new SqlParameter("@DiSanLQ", SqlDbType.Int);
                    pDiSanLQ.Value = model.DiSanLQ;
                    myCommand.Parameters.Add(pDiSanLQ);

                    SqlParameter pAnhBanDo = new SqlParameter("@AnhBanDo", SqlDbType.NVarChar, 500);
                    pAnhBanDo.Value = model.AnhBanDo;
                    myCommand.Parameters.Add(pAnhBanDo);

                    SqlParameter pSTT = new SqlParameter("@STT", SqlDbType.Int);
                    pSTT.Value = model.STT;
                    myCommand.Parameters.Add(pSTT);

                    SqlParameter pFileQuyetDinh = new SqlParameter("@FileQuyetDinh", SqlDbType.NVarChar,500);
                    pFileQuyetDinh.Value = model.FileQuyetDinh;
                    myCommand.Parameters.Add(pFileQuyetDinh);

                    SqlParameter pThoiGianDienRa = new SqlParameter("@ThoiGianDienRa", SqlDbType.NVarChar, 500);
                    pThoiGianDienRa.Value = model.ThoiGianDienRa;
                    myCommand.Parameters.Add(pThoiGianDienRa);

                    SqlParameter pThongKeHienVat = new SqlParameter("@ThongKeHienVat", SqlDbType.NVarChar, 500);
                    pThongKeHienVat.Value = model.ThongKeHienVat;
                    myCommand.Parameters.Add(pThongKeHienVat);

                    SqlParameter pLang = new SqlParameter("@Lang", SqlDbType.VarChar, 10);
                    pLang.Value = model.Lang;
                    myCommand.Parameters.Add(pLang);

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
                using (SqlCommand myCommand = new SqlCommand("NV_DiSanVanHoa_del", myConnection))
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
        #region Lấy theo danh mục di sản
        public DataTable GetByDanhMuc(string danhmuc,string lang)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DiSanVanHoa_getByDanhmuc", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pDanhmuc = new SqlParameter("@DanhMuc", SqlDbType.Int);
                    pDanhmuc.Value = danhmuc;
                    myCommand.Parameters.Add(pDanhmuc);


                    SqlParameter pLang = new SqlParameter("@Lang", SqlDbType.VarChar,10);
                    pLang.Value = lang;
                    myCommand.Parameters.Add(pLang);

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
        #region Lấy theo loại di sản
        public DataTable GetByLoaiDS(int loaiID, bool? noibat,string lang)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DiSanVanHoa_getByLoaiDS", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pDanhmuc = new SqlParameter("@LoaiID", SqlDbType.Int);
                    pDanhmuc.Value = loaiID;
                    myCommand.Parameters.Add(pDanhmuc);

                    SqlParameter pNoiBat = new SqlParameter("@NoiBat", SqlDbType.Bit);
                    pNoiBat.Value = noibat;
                    myCommand.Parameters.Add(pNoiBat);


                    SqlParameter pLang = new SqlParameter("@Lang", SqlDbType.VarChar,10);
                    pLang.Value = lang;
                    myCommand.Parameters.Add(pLang);

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

        public DataTable getDataCombo()
        {
            DataTable dt = GetAll(null,"vi");
            DataRow dr = dt.NewRow();
            dr["DiSanID"] = 0;
            dr["TenDiSan"] = "Chon di sản văn hóa";
            dt.Rows.InsertAt(dr, 0);
            return dt;
        }
    }
}
