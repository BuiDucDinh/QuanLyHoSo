using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_BaiViet_AnPham_ChiTiet
    {
        public int ID { get; set; }
        public string TieuDe { get; set; }
        public int DanhMucChinh { get; set; }
        public string DanhMuc { get; set; }
        public int DiSanID { get; set; }
        public string TenDiSan { get; set; }
        public int HoatDongID { get; set; }
        public string TenHoatDong { get; set; }
        public int HinhAnh { get; set; }
        public string AnhDaiDien { get; set; }
        public DateTime NgayXuatBan { get; set; }
        public string GioiThieu { get; set; }
        public string NoiDung { get; set; }
        public string File { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public string PageTitle { get; set; }
        public string Url { get; set; }
        public bool Duyet { get; set; }
        public bool NoiBat { get; set; }
        public int Stt { get; set; }
        public bool TonTai { get; set; }
        public int NguoiTao { get; set; }
        public string Lang { get; set; }
        public NV_BaiViet_AnPham_ChiTiet() { }
        public NV_BaiViet_AnPham_ChiTiet(DataTable dt)
        {
            ID = int.Parse(dt.Rows[0]["ID"].ToString());
            TieuDe = dt.Rows[0]["TieuDe"].ToString();
            DanhMuc = dt.Rows[0]["Danhmuc"].ToString();
            Lang = dt.Rows[0]["Lang"].ToString();

            DanhMucChinh = int.Parse(dt.Rows[0]["DanhmucChinh"].ToString());
            try
            {
                NgayXuatBan = Convert.ToDateTime(dt.Rows[0]["NgayxuatBan"].ToString());
            }
            catch { }
            GioiThieu = dt.Rows[0]["GioiThieu"].ToString();
            NoiDung = dt.Rows[0]["NoiDung"].ToString();
            File = dt.Rows[0]["File"].ToString();
            HinhAnh = int.Parse(dt.Rows[0]["HinhAnh"].ToString());
            MetaDescription = dt.Rows[0]["MetaDescription"].ToString();
            MetaKeyword = dt.Rows[0]["MeTaKeyword"].ToString();
            PageTitle = dt.Rows[0]["PageTitle"].ToString();
            Url = dt.Rows[0]["Url"].ToString();
            AnhDaiDien = dt.Rows[0]["AnhDaiDien"].ToString();
            Duyet = Convert.ToBoolean(dt.Rows[0]["Duyet"].ToString());
            NoiBat = Convert.ToBoolean(dt.Rows[0]["NoiBat"].ToString());
            try
            {
                DiSanID = int.Parse(dt.Rows[0]["DiSanID"].ToString());
                TenDiSan = dt.Rows[0]["TenDiSan"].ToString();
            }
            catch { }
            try
            {
                HoatDongID = int.Parse(dt.Rows[0]["HoatDongID"].ToString());
                TenHoatDong = dt.Rows[0]["TenHoatDong"].ToString();
            }
            catch { }
            TonTai = Convert.ToBoolean(dt.Rows[0]["TonTai"].ToString());
            NguoiTao = int.Parse(dt.Rows[0]["NguoiTao"].ToString());
        }

    }
    public class NV_BaiViet_AnPham
    {
        private string ConnectionString;
        public NV_BaiViet_AnPham(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }

        #region Lấy theo ID
        public NV_BaiViet_AnPham_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_BaiViet_AnPham_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@id", SqlDbType.VarChar, 10);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);


                    DataTable dt;
                    NV_BaiViet_AnPham_ChiTiet model = new NV_BaiViet_AnPham_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_BaiViet_AnPham_ChiTiet(dt);
                    }
                    return model;
                }
            }
        }
        #endregion
        #region Lấy theo url
        public NV_BaiViet_AnPham_ChiTiet GetByUrl(string url)
        {
            string sql = "select top 1 *,(select TenAnh from Image i where i.ImageID=bv.HinhAnh) as AnhDaiDien from BaiViet_AnPham bv where Duyet=1 and Url='" + url + "'";
            DataTable dt = Sys_Common.getDataByQuery(sql);
            NV_BaiViet_AnPham_ChiTiet bv = new NV_BaiViet_AnPham_ChiTiet();
            if (dt != null && dt.Rows.Count > 0)
            {
                bv = new NV_BaiViet_AnPham_ChiTiet(dt);
            }
            return bv;
        }
        #endregion
        #region Lấy tất cả
        public DataTable GetAll(string lang="vi")
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_BaiViet_AnPham_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pLang = new SqlParameter("@Lang", SqlDbType.VarChar, 10);
                    pLang.Value = lang;
                    myCommand.Parameters.Add(pLang);


                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_BaiViet_AnPham_getAll");
                    return myDataSet.Tables["NV_BaiViet_AnPham_getAll"];

                }
            }
        }

        #endregion
        #region Lấy theo danh mục
        public DataTable GetByCate(int cate,string lang)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_BaiViet_AnPham_getByCate", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pCate = new SqlParameter("@cate", SqlDbType.Int);
                    pCate.Value = cate;
                    myCommand.Parameters.Add(pCate);


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
        #region Thêm

        public bool Them(NV_BaiViet_AnPham_ChiTiet model,out int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_BaiViet_AnPham_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@BaiVietID", SqlDbType.Int);
                    pID.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pTieude = new SqlParameter("@TieuDe", SqlDbType.NVarChar, 500);
                    pTieude.Value = model.TieuDe;
                    myCommand.Parameters.Add(pTieude);

                    SqlParameter pDanhMucChinh = new SqlParameter("@DanhMucChinh", SqlDbType.Int);
                    pDanhMucChinh.Value = model.DanhMucChinh;
                    myCommand.Parameters.Add(pDanhMucChinh);


                    SqlParameter pDanhMuc = new SqlParameter("@DanhMuc", SqlDbType.NVarChar, 500);
                    pDanhMuc.Value = model.DanhMuc;
                    myCommand.Parameters.Add(pDanhMuc);

                    SqlParameter pNgayxuatban = new SqlParameter("@NgayXuatBan", SqlDbType.DateTime);
                    pNgayxuatban.Value = model.NgayXuatBan;
                    myCommand.Parameters.Add(pNgayxuatban);

                    SqlParameter pNoidung = new SqlParameter("@NoiDung", SqlDbType.NText);
                    pNoidung.Value = model.NoiDung;
                    myCommand.Parameters.Add(pNoidung);

                    SqlParameter pFile = new SqlParameter("@File", SqlDbType.NVarChar, 500);
                    pFile.Value = model.File;
                    myCommand.Parameters.Add(pFile);

                    SqlParameter pHinhanh = new SqlParameter("@HinhAnh", SqlDbType.NVarChar, 250);
                    pHinhanh.Value = model.HinhAnh;
                    myCommand.Parameters.Add(pHinhanh);

                    SqlParameter pMetaKeyword = new SqlParameter("@MetaKeyword", SqlDbType.NVarChar, 200);
                    pMetaKeyword.Value = model.MetaKeyword;
                    myCommand.Parameters.Add(pMetaKeyword);

                    SqlParameter pMetadescription = new SqlParameter("@MetaDescription", SqlDbType.NVarChar, 500);
                    pMetadescription.Value = model.MetaDescription;
                    myCommand.Parameters.Add(pMetadescription);

                    SqlParameter pPagetitle = new SqlParameter("@PageTitle", SqlDbType.NVarChar, 200);
                    pPagetitle.Value = model.PageTitle;
                    myCommand.Parameters.Add(pPagetitle);

                    SqlParameter pGioiThieu = new SqlParameter("@GioiThieu", SqlDbType.NText);
                    pGioiThieu.Value = model.GioiThieu;
                    myCommand.Parameters.Add(pGioiThieu);

                    SqlParameter pDisanID = new SqlParameter("@DiSanID", SqlDbType.Int);
                    pDisanID.Value = model.DiSanID;
                    myCommand.Parameters.Add(pDisanID);

                    SqlParameter pHoatDongID = new SqlParameter("@HoatDongID", SqlDbType.Int);
                    pHoatDongID.Value = model.HoatDongID;
                    myCommand.Parameters.Add(pHoatDongID);

                    SqlParameter pUrl = new SqlParameter("@Url", SqlDbType.VarChar, 250);
                    pUrl.Value = model.Url;
                    myCommand.Parameters.Add(pUrl);

                    SqlParameter pNoiBat = new SqlParameter("@NoiBat", SqlDbType.Bit);
                    pNoiBat.Value = model.NoiBat;
                    myCommand.Parameters.Add(pNoiBat);

                    SqlParameter pStt = new SqlParameter("@Stt", SqlDbType.Int);
                    pStt.Value = model.Stt;
                    myCommand.Parameters.Add(pStt);
                    SqlParameter pDuyet = new SqlParameter("@Duyet", SqlDbType.Bit);
                    pDuyet.Value = model.Duyet;
                    myCommand.Parameters.Add(pDuyet);

                    SqlParameter pTonTai = new SqlParameter("@TonTai", SqlDbType.Bit);
                    pTonTai.Value = model.TonTai;
                    myCommand.Parameters.Add(pTonTai);
                    SqlParameter pNguoiTao = new SqlParameter("@NguoiTao", SqlDbType.Int);
                    pNguoiTao.Value = model.NguoiTao;
                    myCommand.Parameters.Add(pNguoiTao);

                    SqlParameter pLang = new SqlParameter("@Lang", SqlDbType.VarChar, 10);
                    pLang.Value = model.Lang;
                    myCommand.Parameters.Add(pLang);
                    try
                    {
                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                        id = (int)pID.Value;
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
        public bool Update(NV_BaiViet_AnPham_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_BaiViet_AnPham_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@BaiVietID", SqlDbType.Int);
                    pID.Value = model.ID;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pTieude = new SqlParameter("@TieuDe", SqlDbType.NVarChar, 500);
                    pTieude.Value = model.TieuDe;
                    myCommand.Parameters.Add(pTieude);

                    SqlParameter pDanhMucChinh = new SqlParameter("@DanhMucChinh", SqlDbType.Int);
                    pDanhMucChinh.Value = model.DanhMucChinh;
                    myCommand.Parameters.Add(pDanhMucChinh);


                    SqlParameter pDanhMuc = new SqlParameter("@DanhMuc", SqlDbType.NVarChar, 500);
                    pDanhMuc.Value = model.DanhMuc;
                    myCommand.Parameters.Add(pDanhMuc);

                    //SqlParameter pNgayxuatban = new SqlParameter("@NgayXuatBan", SqlDbType.DateTime);
                    //pNgayxuatban.Value = model.NgayXuatBan;
                    //myCommand.Parameters.Add(pNgayxuatban);

                    SqlParameter pNoidung = new SqlParameter("@NoiDung", SqlDbType.NText);
                    pNoidung.Value = model.NoiDung;
                    myCommand.Parameters.Add(pNoidung);

                    SqlParameter pFile = new SqlParameter("@File", SqlDbType.NVarChar, 500);
                    pFile.Value = model.File;
                    myCommand.Parameters.Add(pFile);

                    SqlParameter pHinhanh = new SqlParameter("@HinhAnh", SqlDbType.NVarChar, 250);
                    pHinhanh.Value = model.HinhAnh;
                    myCommand.Parameters.Add(pHinhanh);

                    SqlParameter pMetaKeyword = new SqlParameter("@MetaKeyword", SqlDbType.NVarChar, 200);
                    pMetaKeyword.Value = model.MetaKeyword;
                    myCommand.Parameters.Add(pMetaKeyword);

                    SqlParameter pMetadescription = new SqlParameter("@MetaDescription", SqlDbType.NVarChar, 500);
                    pMetadescription.Value = model.MetaDescription;
                    myCommand.Parameters.Add(pMetadescription);

                    SqlParameter pPagetitle = new SqlParameter("@PageTitle", SqlDbType.NVarChar, 200);
                    pPagetitle.Value = model.PageTitle;
                    myCommand.Parameters.Add(pPagetitle);

                    SqlParameter pGioiThieu = new SqlParameter("@GioiThieu", SqlDbType.NText);
                    pGioiThieu.Value = model.GioiThieu;
                    myCommand.Parameters.Add(pGioiThieu);

                    SqlParameter pDisanID = new SqlParameter("@DiSanID", SqlDbType.Int);
                    pDisanID.Value = model.DiSanID;
                    myCommand.Parameters.Add(pDisanID);

                    SqlParameter pHoatDongID = new SqlParameter("@HoatDongID", SqlDbType.Int);
                    pHoatDongID.Value = model.HoatDongID;
                    myCommand.Parameters.Add(pHoatDongID);

                    SqlParameter pUrl = new SqlParameter("@Url", SqlDbType.NVarChar, 250);
                    pUrl.Value = model.Url;
                    myCommand.Parameters.Add(pUrl);

                    SqlParameter pDuyet = new SqlParameter("@Duyet", SqlDbType.Bit);
                    pDuyet.Value = model.Duyet;
                    myCommand.Parameters.Add(pDuyet);

                    SqlParameter pNoiBat = new SqlParameter("@NoiBat", SqlDbType.Bit);
                    pNoiBat.Value = model.NoiBat;
                    myCommand.Parameters.Add(pNoiBat);

                    SqlParameter pStt = new SqlParameter("@Stt", SqlDbType.Int);
                    pStt.Value = model.Stt;
                    myCommand.Parameters.Add(pStt);

                    SqlParameter pTonTai = new SqlParameter("@TonTai", SqlDbType.Bit);
                    pTonTai.Value = model.TonTai;
                    myCommand.Parameters.Add(pTonTai);

                    SqlParameter pLang = new SqlParameter("@Lang", SqlDbType.VarChar, 10);
                    pLang.Value = model.Lang;
                    myCommand.Parameters.Add(pLang);

                    //SqlParameter pNguoiTao = new SqlParameter("@NguoiTao", SqlDbType.Int);
                    //pNguoiTao.Value = model.NguoiTao;
                    //myCommand.Parameters.Add(pNguoiTao);
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
                using (SqlCommand myCommand = new SqlCommand("NV_BaiViet_AnPham_del", myConnection))
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
