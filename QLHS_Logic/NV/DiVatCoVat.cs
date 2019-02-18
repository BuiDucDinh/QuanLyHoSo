using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_DiVatCoVat_ChiTiet
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public string TenKhac { get; set; }
        public string MaSo { get; set; }
        public DateTime? NgayGiamDinh { get; set; }
        public int HoiDongGiamDinh { get; set; }
        public string TenHoiDong { get; set; }
        public string GhiChuGiamDinh { get; set; }
        public int PhanLoai { get; set; }
        public string TenLoai { get; set; }
        public int SoLuong { get; set; }
        public string ThanhPhanHopThanh { get; set; }
        public string KichThuocTrongLuong { get; set; }
        public string MieuTaHienVat { get; set; }
        public string DauTichDacBiet { get; set; }
        public string ChatLieu { get; set; }
        public string NguonGoc { get; set; }
        public int Thoiky { get; set; }
        public string TenThoiKy { get; set; }
        public string NienDai { get; set; }
        public string TinhTrang { get; set; }
        public string ChuSoHuu { get; set; }
        public string ThayDoiChuSoHuu { get; set; }
        public int NoiLuuTru { get; set; }
        public string BaoTang { get; set; }
        public string Video { get; set; }
        public int AnhDaiDien { get; set; }
        public string TenAnh { get; set; }
        public string BoAnh { get; set; }
        public string FileDinhKem { get; set; }
        public string GioiThieu { get; set; }
        public string DiaDiemPhatHien { get; set; }
        public int NguoiTao { get; set; }
        public DateTime NgayTao { get; set; }
        public bool TrangThai { get; set; }
        public string DiSan { get; set; }
        public int DiSanID { get; set; }
        public bool IsMuseum { get; set; }
        public bool TonTai { get; set; }
        public string Url { get; set; }
        public string UrlName { get; set; }
        public string Lang { get; set; }
        public NV_DiVatCoVat_ChiTiet() { }
        public NV_DiVatCoVat_ChiTiet(DataRow dr)
        {
            ID = int.Parse(dr["ID"].ToString());
            Ten = dr["Ten"].ToString();
            TenKhac = dr["TenKhac"].ToString();
            MaSo = dr["MaSo"].ToString();
            try
            {
                NgayGiamDinh = Convert.ToDateTime(dr["NgayGiamDinh"].ToString());
            }
            catch { }
            try
            {
                HoiDongGiamDinh = int.Parse(dr["HoiDongGiamDinh"].ToString());
            }
            catch { }
            TenHoiDong = dr["TenHoiDong"].ToString();
            PhanLoai = int.Parse(dr["PhanLoai"].ToString());
            TenLoai = dr["TenLoai"].ToString();
            SoLuong = int.Parse(dr["SoLuong"].ToString());
            KichThuocTrongLuong = dr["KichThuocTrongLuong"].ToString();
            NguonGoc = dr["NguonGoc"].ToString();
            GhiChuGiamDinh = dr["GhiChuGiamDinh"].ToString();
            ThanhPhanHopThanh = dr["ThanhPhanHopThanh"].ToString();
            MieuTaHienVat = dr["MieuTaHienVat"].ToString();
            DauTichDacBiet = dr["DauTichDacBiet"].ToString();
            ChatLieu = dr["ChatLieu"].ToString();
            Thoiky = int.Parse(dr["ThoiKy"].ToString());
            TenThoiKy = dr["TenThoiKy"].ToString();
            NienDai = dr["NienDai"].ToString();
            TinhTrang = dr["TinhTrang"].ToString();
            try
            {
                DiSan = dr["DiSan"].ToString();
            }
            catch
            {
            }
            ChuSoHuu = dr["ChuSoHuu"].ToString();
            ThayDoiChuSoHuu = dr["ThayDoiChuSoHuu"].ToString();
            NoiLuuTru = int.Parse(dr["NoiLuuTru"].ToString());
            Video = dr["Video"].ToString();
            AnhDaiDien = int.Parse(dr["AnhDaiDien"].ToString());
            TenAnh = dr["TenAnh"].ToString();
            BoAnh = dr["BoAnh"].ToString();
            FileDinhKem = dr["FileDinhKem"].ToString();
            GioiThieu = dr["GioiThieu"].ToString();
            DiaDiemPhatHien = dr["DiaDiemPhatHien"].ToString();
            NguoiTao = int.Parse(dr["NguoiTao"].ToString());
            NgayTao = Convert.ToDateTime(dr["NgayTao"].ToString());
            TrangThai = bool.Parse(dr["TrangThai"].ToString());
            DiSanID = int.Parse(dr["DiSanID"].ToString());
            TonTai = bool.Parse(dr["TonTai"].ToString());
            IsMuseum = bool.Parse(dr["IsMuseum"].ToString());
            if (IsMuseum)
                BaoTang = dr["BaoTang"].ToString();
            else
                BaoTang = dr["DiSan"].ToString();
            Url = dr["Url"].ToString();
            UrlName = dr["UrlName"].ToString();
            Lang = dr["Lang"].ToString();
        }
    }
    public class NV_DiVatCoVat
    {
        private string ConnectionString;
        public NV_DiVatCoVat(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lấy theo ID
        public DataTable GetByIdTable(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DiVatCoVat_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
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
                        dr["TenAnh"] = "/FileUpload/Images/" + dr["TenAnh"].ToString();
                    }
                    return dt;
                }
            }
        }
        #endregion
        #region Lấy theo ID
        public NV_DiVatCoVat_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DiVatCoVat_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    DataTable dt;
                    NV_DiVatCoVat_ChiTiet model = new NV_DiVatCoVat_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_DiVatCoVat_ChiTiet(dt.Rows[0]);
                    }
                    return model;
                }
            }
        }
        #endregion

        #region Lấy theo ID
        public NV_DiVatCoVat_ChiTiet GetByUrl(string url)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DiVatCoVat_getByUrl", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pUrlName = new SqlParameter("@Url", SqlDbType.NVarChar, 200);
                    pUrlName.Value = url;
                    myCommand.Parameters.Add(pUrlName);

                    DataTable dt;
                    NV_DiVatCoVat_ChiTiet model = new NV_DiVatCoVat_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_DiVatCoVat_ChiTiet(dt.Rows[0]);
                    }
                    return model;
                }
            }
        }
        #endregion
        #region Lấy theo di sản
        public DataTable GetByDiSanID(int disanid)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DiVatCoVat_getByDiSanID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@DiSanID", SqlDbType.Int);
                    pID.Value = disanid;
                    myCommand.Parameters.Add(pID);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_DiVatCoVat_getByDiSanID");
                    return myDataSet.Tables["NV_DiVatCoVat_getByDiSanID"];

                }
            }
        }
        #endregion
        #region Lọc
        public DataTable GetSearch(string ten, int loai, int disanid, int baotang,string lang="vi")
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DiVatCoVat_getSearch", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pTen = new SqlParameter("@Ten", SqlDbType.NVarChar, 200);
                    pTen.Value = ten;
                    myCommand.Parameters.Add(pTen);

                    SqlParameter pPhanLoai = new SqlParameter("@PhanLoai", SqlDbType.Int);
                    pPhanLoai.Value = loai;
                    myCommand.Parameters.Add(pPhanLoai);

                    SqlParameter pDiSanID = new SqlParameter("@DiSanID", SqlDbType.Int);
                    pDiSanID.Value = disanid;
                    myCommand.Parameters.Add(pDiSanID);

                    SqlParameter pNoiLuuTru = new SqlParameter("@NoiLuuTru", SqlDbType.Int);
                    pNoiLuuTru.Value = baotang;
                    myCommand.Parameters.Add(pNoiLuuTru);

                    SqlParameter pLang = new SqlParameter("@Lang", SqlDbType.VarChar,10);
                    pLang.Value = lang;
                    myCommand.Parameters.Add(pLang);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_DiVatCoVat_getSearch");
                    return myDataSet.Tables["NV_DiVatCoVat_getSearch"];

                }
            }
        }
        #endregion
        #region Lấy tất cả
        public DataTable GetAll(string lang="vi")
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DiVatCoVat_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pLang = new SqlParameter("@Lang", SqlDbType.VarChar,10);
                    pLang.Value = lang;
                    myCommand.Parameters.Add(pLang);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_DiVatCoVat_getAll");
                    return myDataSet.Tables["NV_DiVatCoVat_getAll"];

                }
            }
        }

        #endregion
        #region Thêm
        public bool them(NV_DiVatCoVat_ChiTiet model, out int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DiVatCoVat_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pId = new SqlParameter("@ID", SqlDbType.Int);
                    pId.Value = ParameterDirection.Output;
                    myCommand.Parameters.Add(pId);

                    SqlParameter pTen = new SqlParameter("@Ten", SqlDbType.NVarChar, 200);
                    pTen.Value = model.Ten;
                    myCommand.Parameters.Add(pTen);
                    SqlParameter pTenKhac = new SqlParameter("@TenKhac", SqlDbType.NVarChar, 200);
                    pTenKhac.Value = model.TenKhac;
                    myCommand.Parameters.Add(pTenKhac);
                    SqlParameter pSoDangKy = new SqlParameter("@MaSo", SqlDbType.NVarChar, 50);
                    pSoDangKy.Value = model.MaSo;
                    myCommand.Parameters.Add(pSoDangKy);

                    SqlParameter pNgayDangKy = new SqlParameter("@NgayGiamDinh", SqlDbType.DateTime);
                    pNgayDangKy.Value = model.NgayGiamDinh;
                    myCommand.Parameters.Add(pNgayDangKy);

                    SqlParameter pHoiDongGiamDinh = new SqlParameter("@HoiDongGiamDinh", SqlDbType.Int);
                    pHoiDongGiamDinh.Value = model.HoiDongGiamDinh;
                    myCommand.Parameters.Add(pHoiDongGiamDinh);

                    SqlParameter pGhiChuGiamDinh = new SqlParameter("@GhiChuGiamDinh", SqlDbType.NVarChar, 2000);
                    pGhiChuGiamDinh.Value = model.GhiChuGiamDinh;
                    myCommand.Parameters.Add(pGhiChuGiamDinh);
                    SqlParameter pPhanLoai = new SqlParameter("@PhanLoai", SqlDbType.Int);
                    pPhanLoai.Value = model.PhanLoai;
                    myCommand.Parameters.Add(pPhanLoai);

                    SqlParameter pSoLuong = new SqlParameter("@SoLuong", SqlDbType.Int);
                    pSoLuong.Value = model.SoLuong;
                    myCommand.Parameters.Add(pSoLuong);

                    SqlParameter pThanhPhanHopThanh = new SqlParameter("@ThanhPhanHopThanh", SqlDbType.NVarChar, 2000);
                    pThanhPhanHopThanh.Value = model.ThanhPhanHopThanh;
                    myCommand.Parameters.Add(pThanhPhanHopThanh);

                    SqlParameter pKichThuoc = new SqlParameter("@KichThuocTrongLuong", SqlDbType.NVarChar, 2000);
                    pKichThuoc.Value = model.KichThuocTrongLuong;
                    myCommand.Parameters.Add(pKichThuoc);

                    SqlParameter pTrongLuong = new SqlParameter("@MieuTaHienVat", SqlDbType.NVarChar, 2000);
                    pTrongLuong.Value = model.MieuTaHienVat;
                    myCommand.Parameters.Add(pTrongLuong);

                    SqlParameter pDauTichDacBiet = new SqlParameter("@DauTichDacBiet", SqlDbType.NVarChar, 2000);
                    pDauTichDacBiet.Value = model.DauTichDacBiet;
                    myCommand.Parameters.Add(pDauTichDacBiet);

                    SqlParameter pChatLieu = new SqlParameter("@ChatLieu", SqlDbType.NVarChar, 2000);
                    pChatLieu.Value = model.ChatLieu;
                    myCommand.Parameters.Add(pChatLieu);
                    SqlParameter pNguonGoc = new SqlParameter("@NguonGoc", SqlDbType.NVarChar, 2000);
                    pNguonGoc.Value = model.NguonGoc;
                    myCommand.Parameters.Add(pNguonGoc);

                    SqlParameter pThoiky = new SqlParameter("@Thoiky", SqlDbType.Int);
                    pThoiky.Value = model.Thoiky;
                    myCommand.Parameters.Add(pThoiky);

                    SqlParameter pNienDai = new SqlParameter("@NienDai", SqlDbType.NVarChar, 1000);
                    pNienDai.Value = model.NienDai;
                    myCommand.Parameters.Add(pNienDai);

                    SqlParameter pTinhTrang = new SqlParameter("@TinhTrang", SqlDbType.NVarChar, 4000);
                    pTinhTrang.Value = model.TinhTrang;
                    myCommand.Parameters.Add(pTinhTrang);

                    SqlParameter pChuSoHuu = new SqlParameter("@ChuSoHuu", SqlDbType.NVarChar, 1000);
                    pChuSoHuu.Value = model.ChuSoHuu;
                    myCommand.Parameters.Add(pChuSoHuu);

                    SqlParameter pNoiLuuTru = new SqlParameter("@NoiLuuTru", SqlDbType.Int);
                    pNoiLuuTru.Value = model.NoiLuuTru;
                    myCommand.Parameters.Add(pNoiLuuTru);

                    SqlParameter pThayDoiChuSoHuu = new SqlParameter("@ThayDoiChuSoHuu", SqlDbType.NVarChar, 2000);
                    pThayDoiChuSoHuu.Value = model.ThayDoiChuSoHuu;
                    myCommand.Parameters.Add(pThayDoiChuSoHuu);

                    SqlParameter pVideo = new SqlParameter("@Video", SqlDbType.NVarChar, 100);
                    pVideo.Value = model.Video;
                    myCommand.Parameters.Add(pVideo);

                    SqlParameter pAnhDaiDien = new SqlParameter("@AnhDaiDien", SqlDbType.Int);
                    pAnhDaiDien.Value = model.AnhDaiDien;
                    myCommand.Parameters.Add(pAnhDaiDien);

                    SqlParameter pBoAnh = new SqlParameter("@BoAnh", SqlDbType.NVarChar, 100);
                    pBoAnh.Value = model.BoAnh;
                    myCommand.Parameters.Add(pBoAnh);

                    SqlParameter pFileDinhKem = new SqlParameter("@FileDinhKem", SqlDbType.NVarChar, 100);
                    pFileDinhKem.Value = model.FileDinhKem;
                    myCommand.Parameters.Add(pFileDinhKem);

                    SqlParameter pGioiThieu = new SqlParameter("@GioiThieu", SqlDbType.NText);
                    pGioiThieu.Value = model.GioiThieu;
                    myCommand.Parameters.Add(pGioiThieu);

                    SqlParameter pDiaDiemPhatHien = new SqlParameter("@DiaDiemPhatHien", SqlDbType.NVarChar, 200);
                    pDiaDiemPhatHien.Value = model.DiaDiemPhatHien;
                    myCommand.Parameters.Add(pDiaDiemPhatHien);

                    SqlParameter pNguoiTao = new SqlParameter("@NguoiTao", SqlDbType.Int);
                    pNguoiTao.Value = model.NguoiTao;
                    myCommand.Parameters.Add(pNguoiTao);

                    SqlParameter pDiSanID = new SqlParameter("@DiSanID", SqlDbType.Int);
                    pDiSanID.Value = model.DiSanID;
                    myCommand.Parameters.Add(pDiSanID);

                    SqlParameter pIsMuseum = new SqlParameter("@IsMuseum", SqlDbType.Bit);
                    pIsMuseum.Value = model.IsMuseum;
                    myCommand.Parameters.Add(pIsMuseum);

                    SqlParameter pUrlName = new SqlParameter("@UrlName", SqlDbType.NVarChar, 200);
                    pUrlName.Value = model.UrlName;
                    myCommand.Parameters.Add(pUrlName);

                    SqlParameter pLang = new SqlParameter("@Lang", SqlDbType.VarChar, 10);
                    pLang.Value = model.Lang;
                    myCommand.Parameters.Add(pLang);

                    try
                    {
                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                        id = (int)pId.Value;
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
        public bool update(NV_DiVatCoVat_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DiVatCoVat_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = model.ID;
                    myCommand.Parameters.Add(pID);
                    SqlParameter pTen = new SqlParameter("@Ten", SqlDbType.NVarChar, 200);
                    pTen.Value = model.Ten;
                    myCommand.Parameters.Add(pTen);
                    SqlParameter pTenKhac = new SqlParameter("@TenKhac", SqlDbType.NVarChar, 200);
                    pTenKhac.Value = model.TenKhac;
                    myCommand.Parameters.Add(pTenKhac);
                    SqlParameter pSoDangKy = new SqlParameter("@MaSo", SqlDbType.NVarChar, 50);
                    pSoDangKy.Value = model.MaSo;
                    myCommand.Parameters.Add(pSoDangKy);

                    SqlParameter pNgayDangKy = new SqlParameter("@NgayGiamDinh", SqlDbType.DateTime);
                    pNgayDangKy.Value = model.NgayGiamDinh;
                    myCommand.Parameters.Add(pNgayDangKy);

                    SqlParameter pHoiDongGiamDinh = new SqlParameter("@HoiDongGiamDinh", SqlDbType.Int);
                    pHoiDongGiamDinh.Value = model.HoiDongGiamDinh;
                    myCommand.Parameters.Add(pHoiDongGiamDinh);

                    SqlParameter pGhiChuGiamDinh = new SqlParameter("@GhiChuGiamDinh", SqlDbType.NVarChar, 2000);
                    pGhiChuGiamDinh.Value = model.GhiChuGiamDinh;
                    myCommand.Parameters.Add(pGhiChuGiamDinh);
                    SqlParameter pPhanLoai = new SqlParameter("@PhanLoai", SqlDbType.Int);
                    pPhanLoai.Value = model.PhanLoai;
                    myCommand.Parameters.Add(pPhanLoai);

                    SqlParameter pSoLuong = new SqlParameter("@SoLuong", SqlDbType.Int);
                    pSoLuong.Value = model.SoLuong;
                    myCommand.Parameters.Add(pSoLuong);

                    SqlParameter pThanhPhanHopThanh = new SqlParameter("@ThanhPhanHopThanh", SqlDbType.NVarChar, 2000);
                    pThanhPhanHopThanh.Value = model.ThanhPhanHopThanh;
                    myCommand.Parameters.Add(pThanhPhanHopThanh);

                    SqlParameter pKichThuoc = new SqlParameter("@KichThuocTrongLuong", SqlDbType.NVarChar, 2000);
                    pKichThuoc.Value = model.KichThuocTrongLuong;
                    myCommand.Parameters.Add(pKichThuoc);

                    SqlParameter pTrongLuong = new SqlParameter("@MieuTaHienVat", SqlDbType.NVarChar, 2000);
                    pTrongLuong.Value = model.MieuTaHienVat;
                    myCommand.Parameters.Add(pTrongLuong);

                    SqlParameter pDauTichDacBiet = new SqlParameter("@DauTichDacBiet", SqlDbType.NVarChar, 2000);
                    pDauTichDacBiet.Value = model.DauTichDacBiet;
                    myCommand.Parameters.Add(pDauTichDacBiet);

                    SqlParameter pChatLieu = new SqlParameter("@ChatLieu", SqlDbType.NVarChar, 2000);
                    pChatLieu.Value = model.ChatLieu;
                    myCommand.Parameters.Add(pChatLieu);
                    SqlParameter pNguonGoc = new SqlParameter("@NguonGoc", SqlDbType.NVarChar, 2000);
                    pNguonGoc.Value = model.NguonGoc;
                    myCommand.Parameters.Add(pNguonGoc);

                    SqlParameter pThoiky = new SqlParameter("@Thoiky", SqlDbType.Int);
                    pThoiky.Value = model.Thoiky;
                    myCommand.Parameters.Add(pThoiky);

                    SqlParameter pNienDai = new SqlParameter("@NienDai", SqlDbType.NVarChar, 1000);
                    pNienDai.Value = model.NienDai;
                    myCommand.Parameters.Add(pNienDai);

                    SqlParameter pTinhTrang = new SqlParameter("@TinhTrang", SqlDbType.NVarChar, 4000);
                    pTinhTrang.Value = model.TinhTrang;
                    myCommand.Parameters.Add(pTinhTrang);

                    SqlParameter pChuSoHuu = new SqlParameter("@ChuSoHuu", SqlDbType.NVarChar, 1000);
                    pChuSoHuu.Value = model.ChuSoHuu;
                    myCommand.Parameters.Add(pChuSoHuu);

                    SqlParameter pNoiLuuTru = new SqlParameter("@NoiLuuTru", SqlDbType.Int);
                    pNoiLuuTru.Value = model.NoiLuuTru;
                    myCommand.Parameters.Add(pNoiLuuTru);

                    SqlParameter pThayDoiChuSoHuu = new SqlParameter("@ThayDoiChuSoHuu", SqlDbType.NVarChar, 2000);
                    pThayDoiChuSoHuu.Value = model.ThayDoiChuSoHuu;
                    myCommand.Parameters.Add(pThayDoiChuSoHuu);

                    SqlParameter pVideo = new SqlParameter("@Video", SqlDbType.NVarChar, 100);
                    pVideo.Value = model.Video;
                    myCommand.Parameters.Add(pVideo);

                    SqlParameter pAnhDaiDien = new SqlParameter("@AnhDaiDien", SqlDbType.Int);
                    pAnhDaiDien.Value = model.AnhDaiDien;
                    myCommand.Parameters.Add(pAnhDaiDien);

                    SqlParameter pBoAnh = new SqlParameter("@BoAnh", SqlDbType.NVarChar, 100);
                    pBoAnh.Value = model.BoAnh;
                    myCommand.Parameters.Add(pBoAnh);

                    SqlParameter pFileDinhKem = new SqlParameter("@FileDinhKem", SqlDbType.NVarChar, 100);
                    pFileDinhKem.Value = model.FileDinhKem;
                    myCommand.Parameters.Add(pFileDinhKem);

                    SqlParameter pGioiThieu = new SqlParameter("@GioiThieu", SqlDbType.NText);
                    pGioiThieu.Value = model.GioiThieu;
                    myCommand.Parameters.Add(pGioiThieu);

                    SqlParameter pDiaDiemPhatHien = new SqlParameter("@DiaDiemPhatHien", SqlDbType.NVarChar, 200);
                    pDiaDiemPhatHien.Value = model.DiaDiemPhatHien;
                    myCommand.Parameters.Add(pDiaDiemPhatHien);

                    SqlParameter pDiSanID = new SqlParameter("@DiSanID", SqlDbType.Int);
                    pDiSanID.Value = model.DiSanID;
                    myCommand.Parameters.Add(pDiSanID);

                    SqlParameter pTrangThai = new SqlParameter("@TrangThai", SqlDbType.Bit);
                    pTrangThai.Value = model.TrangThai;
                    myCommand.Parameters.Add(pTrangThai);

                    SqlParameter pIsMuseum = new SqlParameter("@IsMuseum", SqlDbType.Bit);
                    pIsMuseum.Value = model.IsMuseum;
                    myCommand.Parameters.Add(pIsMuseum);

                    SqlParameter pUrlName = new SqlParameter("@UrlName", SqlDbType.NVarChar, 200);
                    pUrlName.Value = model.UrlName;
                    myCommand.Parameters.Add(pUrlName);

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
                using (SqlCommand myCommand = new SqlCommand("NV_DiVatCoVat_del", myConnection))
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
