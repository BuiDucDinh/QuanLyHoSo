using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_HoatDongVanHoa_ChiTiet
    {
        public int HoatDongID { get; set; }
        public string TenGoi { get; set; }
        public string TenGoiKhac { get; set; }
        public DateTime NgayDienRa { get; set; }
        public string ThoiGianDienRa { get; set; }
        public int DiSanID { get; set; }
        public string NoiDung { get; set; }
        public string DiaDiem { get; set; }
        public string ThuocTinh { get; set; }
        public string ThuocHuyen { get; set; }
        public string ThuocXa { get; set; }
        public int DonViToChucID { get; set; }
        public int DonViQuanLyID { get; set; }
        public string GioiThieu { get; set; }
        public string HinhAnh { get; set; }
        public string Url { get; set; }
        public bool Duyet { get; set; }
        public Boolean TonTai { get; set; }
        public int NguoiTao { get; set; }
        public DateTime NgayTao { get; set; }

        public string Lang { get; set; }
        public NV_HoatDongVanHoa_ChiTiet() { }
        public NV_HoatDongVanHoa_ChiTiet(DataTable dt)
        {
            HoatDongID = int.Parse(dt.Rows[0]["HoatDongID"].ToString());
            TenGoi = dt.Rows[0]["TenGoi"].ToString();
            TenGoiKhac = dt.Rows[0]["TenGoiKhac"].ToString();
            ThoiGianDienRa = dt.Rows[0]["ThoiGianDienRa"].ToString();
            DiSanID = int.Parse("0" + dt.Rows[0]["DiSanID"]);
            DiaDiem = dt.Rows[0]["DiaDiem"].ToString();
            ThuocTinh = dt.Rows[0]["ThuocTinh"].ToString();
            ThuocHuyen = dt.Rows[0]["ThuocHuyen"].ToString();
            ThuocXa = dt.Rows[0]["ThuocXa"].ToString();
            try
            {
                NgayDienRa = Convert.ToDateTime(dt.Rows[0]["NgayDienRa"].ToString());
            }
            catch
            {
                NgayDienRa = DateTime.Now;
            }
            NoiDung = dt.Rows[0]["NoiDung"].ToString();
            try
            {
                DonViToChucID = int.Parse("0" + dt.Rows[0]["DonViToChuc"]);
            }
            catch { }
            try
            {
                DonViQuanLyID = int.Parse("0" + dt.Rows[0]["DonViQuanLy"]);
            }
            catch { }
            GioiThieu = dt.Rows[0]["GioiThieu"].ToString();
            HinhAnh = dt.Rows[0]["HinhAnh"].ToString();
            Url = dt.Rows[0]["Url"].ToString();
            Duyet = bool.Parse(dt.Rows[0]["Duyet"].ToString());
            TonTai = bool.Parse(dt.Rows[0]["TonTai"].ToString());
            NguoiTao = int.Parse(dt.Rows[0]["NguoiTao"].ToString());
            NgayTao = Convert.ToDateTime(dt.Rows[0]["NgayTao"].ToString());
            Lang = dt.Rows[0]["Lang"].ToString();
        }
    }
    public class NV_HoatDongVanHoa
    {
        private string ConnectionString;
        public NV_HoatDongVanHoa(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }

        #region Lấy theo ID
        public NV_HoatDongVanHoa_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_HoatDongVanHoa_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@id", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    DataTable dt;
                    NV_HoatDongVanHoa_ChiTiet model = new NV_HoatDongVanHoa_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_HoatDongVanHoa_ChiTiet(dt);
                    }
                    return model;
                }
            }
        }
        #endregion
        #region Lấy theo url
        public NV_HoatDongVanHoa_ChiTiet GetByUrl(string url)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_HoatDongVanHoa_getByUrl", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@Url", SqlDbType.NVarChar, 200);
                    pID.Value = url;
                    myCommand.Parameters.Add(pID);

                    DataTable dt;
                    NV_HoatDongVanHoa_ChiTiet model = new NV_HoatDongVanHoa_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_HoatDongVanHoa_ChiTiet(dt);
                    }
                    return model;
                }
            }
        }
        #endregion
        #region Lấy tất cả
        public DataTable GetAll(string lang = "vi")
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_HoatDongVanHoa_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pLang = new SqlParameter("@Lang", SqlDbType.VarChar, 10);
                    pLang.Value = lang;
                    myCommand.Parameters.Add(pLang);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_HoatDongVanHoa_getAll");
                    return myDataSet.Tables["NV_HoatDongVanHoa_getAll"];
                }
            }
        }

        #endregion

        #region Thêm
        public bool them(NV_HoatDongVanHoa_ChiTiet model, out int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_HoatDongVanHoa_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pHoatDongID = new SqlParameter("@HoatDongID", SqlDbType.Int);
                    pHoatDongID.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pHoatDongID);

                    SqlParameter pTenGoi = new SqlParameter("@TenGoi", SqlDbType.NVarChar, 250);
                    pTenGoi.Value = model.TenGoi;
                    myCommand.Parameters.Add(pTenGoi);

                    SqlParameter pTenGoiKkhac = new SqlParameter("@TenGoiKhac", SqlDbType.NVarChar, 250);
                    pTenGoiKkhac.Value = model.TenGoiKhac;
                    myCommand.Parameters.Add(pTenGoiKkhac);

                    SqlParameter pNgayDienRa = new SqlParameter("@NgayDienRa", SqlDbType.DateTime);
                    pNgayDienRa.Value = model.NgayDienRa;
                    myCommand.Parameters.Add(pNgayDienRa);


                    SqlParameter pThoiGianDienRa = new SqlParameter("@ThoiGianDienRa", SqlDbType.NVarChar, 200);
                    pThoiGianDienRa.Value = model.ThoiGianDienRa;
                    myCommand.Parameters.Add(pThoiGianDienRa);

                    SqlParameter pDiSanID = new SqlParameter("@DiSanID", SqlDbType.Int);
                    pDiSanID.Value = model.DiSanID;
                    myCommand.Parameters.Add(pDiSanID);

                    SqlParameter pNoiDung = new SqlParameter("@NoiDung", SqlDbType.NText);
                    pNoiDung.Value = model.NoiDung;
                    myCommand.Parameters.Add(pNoiDung);

                    SqlParameter pDiaDiem = new SqlParameter("@DiaDiem", SqlDbType.NVarChar, 200);
                    pDiaDiem.Value = model.DiaDiem;
                    myCommand.Parameters.Add(pDiaDiem);

                    SqlParameter pThuocTinh = new SqlParameter("@ThuocTinh", SqlDbType.VarChar, 10);
                    pThuocTinh.Value = model.ThuocTinh;
                    myCommand.Parameters.Add(pThuocTinh);

                    SqlParameter pThuocHuyen = new SqlParameter("@ThuocHuyen", SqlDbType.VarChar, 10);
                    pThuocHuyen.Value = model.ThuocHuyen;
                    myCommand.Parameters.Add(pThuocHuyen);

                    SqlParameter pThuocXa = new SqlParameter("@ThuocXa", SqlDbType.VarChar, 10);
                    pThuocXa.Value = model.ThuocXa;
                    myCommand.Parameters.Add(pThuocXa);

                    SqlParameter pDonViToChuc = new SqlParameter("@DonViToChuc", SqlDbType.Int);
                    pDonViToChuc.Value = model.DonViToChucID;
                    myCommand.Parameters.Add(pDonViToChuc);

                    SqlParameter pGioiThieu = new SqlParameter("@GioiThieu", SqlDbType.NText);
                    pGioiThieu.Value = model.GioiThieu;
                    myCommand.Parameters.Add(pGioiThieu);

                    SqlParameter pDonViQuanLy = new SqlParameter("@DonViQuanLy", SqlDbType.Int);
                    pDonViQuanLy.Value = model.DonViQuanLyID;
                    myCommand.Parameters.Add(pDonViQuanLy);

                    SqlParameter pHinhAnh = new SqlParameter("@HinhAnh", SqlDbType.NVarChar, 500);
                    pHinhAnh.Value = model.HinhAnh;
                    myCommand.Parameters.Add(pHinhAnh);

                    SqlParameter pUrl = new SqlParameter("@Url", SqlDbType.NVarChar, 250);
                    pUrl.Value = model.Url;
                    myCommand.Parameters.Add(pUrl);

                    SqlParameter pNguoiTao = new SqlParameter("@NguoiTao", SqlDbType.Int);
                    pNguoiTao.Value = model.NguoiTao;
                    myCommand.Parameters.Add(pNguoiTao);


                    SqlParameter pLang = new SqlParameter("@Lang", SqlDbType.VarChar, 10);
                    pLang.Value = model.Lang;
                    myCommand.Parameters.Add(pLang);

                    id = 0;
                    try
                    {
                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                        id = (int)pHoatDongID.Value;
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
        public bool Update(NV_HoatDongVanHoa_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_HoatDongVanHoa_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@HoatDongID", SqlDbType.Int);
                    pID.Value = model.HoatDongID;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pTenGoi = new SqlParameter("@TenGoi", SqlDbType.NVarChar, 250);
                    pTenGoi.Value = model.TenGoi;
                    myCommand.Parameters.Add(pTenGoi);

                    SqlParameter pTenGoiKkhac = new SqlParameter("@TenGoiKhac", SqlDbType.NVarChar, 250);
                    pTenGoiKkhac.Value = model.TenGoiKhac;
                    myCommand.Parameters.Add(pTenGoiKkhac);

                    SqlParameter pNgayDienRa = new SqlParameter("@NgayDienRa", SqlDbType.DateTime);
                    pNgayDienRa.Value = model.NgayDienRa;
                    myCommand.Parameters.Add(pNgayDienRa);


                    SqlParameter pThoiGianDienRa = new SqlParameter("@ThoiGianDienRa", SqlDbType.NVarChar, 200);
                    pThoiGianDienRa.Value = model.ThoiGianDienRa;
                    myCommand.Parameters.Add(pThoiGianDienRa);

                    SqlParameter pDiSanID = new SqlParameter("@DiSanID", SqlDbType.Int);
                    pDiSanID.Value = model.DiSanID;
                    myCommand.Parameters.Add(pDiSanID);

                    SqlParameter pNoiDung = new SqlParameter("@NoiDung", SqlDbType.NText);
                    pNoiDung.Value = model.NoiDung;
                    myCommand.Parameters.Add(pNoiDung);

                    SqlParameter pDiaDiem = new SqlParameter("@DiaDiem", SqlDbType.NVarChar, 200);
                    pDiaDiem.Value = model.DiaDiem;
                    myCommand.Parameters.Add(pDiaDiem);

                    SqlParameter pThuocTinh = new SqlParameter("@ThuocTinh", SqlDbType.VarChar, 10);
                    pThuocTinh.Value = model.ThuocTinh;
                    myCommand.Parameters.Add(pThuocTinh);

                    SqlParameter pThuocHuyen = new SqlParameter("@ThuocHuyen", SqlDbType.VarChar, 10);
                    pThuocHuyen.Value = model.ThuocHuyen;
                    myCommand.Parameters.Add(pThuocHuyen);

                    SqlParameter pThuocXa = new SqlParameter("@ThuocXa", SqlDbType.VarChar, 10);
                    pThuocXa.Value = model.ThuocXa;
                    myCommand.Parameters.Add(pThuocXa);

                    SqlParameter pDonViToChuc = new SqlParameter("@DonViToChuc", SqlDbType.Int);
                    pDonViToChuc.Value = model.DonViToChucID;
                    myCommand.Parameters.Add(pDonViToChuc);

                    SqlParameter pGioiThieu = new SqlParameter("@GioiThieu", SqlDbType.NText);
                    pGioiThieu.Value = model.GioiThieu;
                    myCommand.Parameters.Add(pGioiThieu);

                    SqlParameter pDonViQuanLy = new SqlParameter("@DonViQuanLy", SqlDbType.Int);
                    pDonViQuanLy.Value = model.DonViQuanLyID;
                    myCommand.Parameters.Add(pDonViQuanLy);

                    SqlParameter pHinhAnh = new SqlParameter("@HinhAnh", SqlDbType.NVarChar, 500);
                    pHinhAnh.Value = model.HinhAnh;
                    myCommand.Parameters.Add(pHinhAnh);

                    SqlParameter pUrl = new SqlParameter("@Url", SqlDbType.NVarChar, 250);
                    pUrl.Value = model.Url;
                    myCommand.Parameters.Add(pUrl);
                    SqlParameter pDuyet = new SqlParameter("@Duyet", SqlDbType.Bit);
                    pDuyet.Value = model.Duyet;
                    myCommand.Parameters.Add(pDuyet);

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
                using (SqlCommand myCommand = new SqlCommand("NV_HoatDongVanHoa_del", myConnection))
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

        #region Lọc theo điềnu kiện
        /*
         
         */
        public DataTable getByCondition(int disan, DateTime? tuNgay, string maTinh, string maHuyen, string lang)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_HoatDongVanHoa_getByCondition", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pDisan = new SqlParameter("@DiSanID", SqlDbType.Int);
                    pDisan.Value = disan;
                    myCommand.Parameters.Add(pDisan);

                    SqlParameter pTungay = new SqlParameter("@TuNgay", SqlDbType.DateTime);
                    pTungay.Value = tuNgay;
                    myCommand.Parameters.Add(pTungay);

                    SqlParameter pTinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pTinh.Value = maTinh;
                    myCommand.Parameters.Add(pTinh);

                    SqlParameter pHuyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pHuyen.Value = maHuyen;
                    myCommand.Parameters.Add(pHuyen);

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
    }
}
