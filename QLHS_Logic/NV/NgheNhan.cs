using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_NgheNhan_ChiTiet
    {
        public int ID { get; set; }
        public string HoTen { get; set; }
        public string TenKhac { get; set; }
        public string NgaySinh { get; set; }
        public string MaDanToc { get; set; }
        public string TenDanToc { get; set; }
        public string NguyenQuan { get; set; }
        public string HoKhauThuongTru { get; set; }
        public DateTime? NgayCap { get; set; }
        public int DiSanID { get; set; }
        public string DiSan { get; set; }
        public string NamBatDau { get; set; }
        public string DienThoai { get; set; }
        public string DiDong { get; set; }
        public string DiaChi { get; set; }
        public string QuaTrinh { get; set; }
        public string TriThucKyNang { get; set; }
        public string KhenThuong { get; set; }
        public string KyLuat { get; set; }
        public int HinhAnh { get; set; }
        public string File { get; set; }
        public string Url { get; set; }
        public string GioiThieu { get; set; }
        public int DanhHieu { get; set; }
        public string TenDanhHieu { get; set; }
        public int LoaiDiSan { get; set; }
        public string TenLoaiDS { get; set; }
        public string TenDiSan { get; set; }
        public NV_NgheNhan_ChiTiet(DataRow dr)
        {
            ID = int.Parse(dr["ID"].ToString());
            HoTen = dr["HoTen"].ToString();
            TenKhac = dr["TenKhac"].ToString();
            NgaySinh = dr["NgaySinh"].ToString();
            MaDanToc = dr["MaDanToc"].ToString();
            TenDanToc = dr["TenDanToc"].ToString();
            NguyenQuan = dr["NguyenQuan"].ToString();
            HoKhauThuongTru = dr["HoKhauThuongTru"].ToString();
            try
            {
                NgayCap = Convert.ToDateTime(dr["NgayCap"].ToString());
            }
            catch { }
            try
            {
                DiSanID = int.Parse(dr["DiSanID"].ToString());
            }
            catch { }
            try
            {
                LoaiDiSan = int.Parse(dr["LoaiDiSan"].ToString());
            }
            catch { }

            TenDiSan = dr["TenDiSan"].ToString();
            TenLoaiDS = dr["TenLoaiDS"].ToString();
            DiSan = dr["DiSan"].ToString();
            NamBatDau = dr["NamBatDau"].ToString();
            DienThoai = dr["DienThoai"].ToString();
            DiDong = dr["DiDong"].ToString();
            DiaChi = dr["DiaChi"].ToString();
            QuaTrinh = dr["QuaTrinh"].ToString();
            TriThucKyNang = dr["TriThucKyNang"].ToString();
            KhenThuong = dr["KhenThuong"].ToString();
            KyLuat = dr["KyLuat"].ToString();
            HinhAnh = int.Parse(dr["HinhAnh"].ToString());
            File = dr["File"].ToString();
            Url = dr["Url"].ToString();
            GioiThieu = dr["GioiThieu"].ToString();
            DanhHieu = int.Parse(dr["DanhHieu"].ToString());
            TenDanhHieu = dr["TenDanhHieu"].ToString();
            if (DiSanID != 0)
            {
                TenDiSan = DiSan;
            }
        }
        public NV_NgheNhan_ChiTiet() { }
    }
    public class NV_NgheNhan
    {
        private string ConnectionString;
        public NV_NgheNhan(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;

        }
        #region Lấy theo ID
        public DataTable GetByIdTable(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_NgheNhan_getByID", myConnection))
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
                        dr["TenAnh"] = "/FileUpload/images/" + dr["TenAnh"].ToString();
                    }
                    return dt;
                }
            }
        }
        #endregion
        #region Lấy theo ID
        public NV_NgheNhan_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_NgheNhan_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    DataTable dt;
                    NV_NgheNhan_ChiTiet model = new NV_NgheNhan_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_NgheNhan_ChiTiet(dt.Rows[0]);
                    }
                    return model;
                }
            }
        }
        #endregion
        #region Lấy theo Url
        public NV_NgheNhan_ChiTiet GetByUrl(string url)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_NgheNhan_getByUrl", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pUrl = new SqlParameter("@Url", SqlDbType.NVarChar, 100);
                    pUrl.Value = url;
                    myCommand.Parameters.Add(pUrl);

                    DataTable dt;
                    NV_NgheNhan_ChiTiet model = new NV_NgheNhan_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            model = new NV_NgheNhan_ChiTiet(dt.Rows[0]);
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
                using (SqlCommand myCommand = new SqlCommand("NV_NgheNhan_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_NgheNhan_getAll");
                    return myDataSet.Tables["NV_NgheNhan_getAll"];

                }
            }
        }

        #endregion
        #region Thêm
        public bool them(NV_NgheNhan_ChiTiet model, out int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_NgheNhan_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = ParameterDirection.Output;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pHoTen = new SqlParameter("@HoTen", SqlDbType.NVarChar, 50);
                    pHoTen.Value = model.HoTen;
                    myCommand.Parameters.Add(pHoTen);

                    SqlParameter pTenKhac = new SqlParameter("@TenKhac", SqlDbType.NVarChar, 50);
                    pTenKhac.Value = model.TenKhac;
                    myCommand.Parameters.Add(pTenKhac);

                    SqlParameter pNgaySinh = new SqlParameter("@NgaySinh", SqlDbType.NVarChar, 100);
                    pNgaySinh.Value = model.NgaySinh;
                    myCommand.Parameters.Add(pNgaySinh);

                    SqlParameter pNgayCap = new SqlParameter("@NgayCap", SqlDbType.DateTime);
                    pNgayCap.Value = model.NgayCap;
                    myCommand.Parameters.Add(pNgayCap);

                    SqlParameter pDanToc = new SqlParameter("@MaDanToc", SqlDbType.VarChar, 5);
                    pDanToc.Value = model.MaDanToc;
                    myCommand.Parameters.Add(pDanToc);

                    SqlParameter pNguyenQuan = new SqlParameter("@NguyenQuan", SqlDbType.NVarChar, 200);
                    pNguyenQuan.Value = model.NguyenQuan;
                    myCommand.Parameters.Add(pNguyenQuan);

                    SqlParameter pDiaChi = new SqlParameter("@DiaChi", SqlDbType.NVarChar, 200);
                    pDiaChi.Value = model.DiaChi;
                    myCommand.Parameters.Add(pDiaChi);

                    SqlParameter pHoKhauThuongTru = new SqlParameter("@HoKhauThuongTru", SqlDbType.NVarChar, 200);
                    pHoKhauThuongTru.Value = model.HoKhauThuongTru;
                    myCommand.Parameters.Add(pHoKhauThuongTru);

                    SqlParameter pDiSanID = new SqlParameter("@DiSanID", SqlDbType.Int);
                    pDiSanID.Value = model.DiSanID;
                    myCommand.Parameters.Add(pDiSanID);

                    SqlParameter pNamBatDau = new SqlParameter("@NamBatDau", SqlDbType.NVarChar, 100);
                    pNamBatDau.Value = model.NamBatDau;
                    myCommand.Parameters.Add(pNamBatDau);

                    SqlParameter pDienThoai = new SqlParameter("@DienThoai", SqlDbType.NVarChar, 50);
                    pDienThoai.Value = model.DienThoai;
                    myCommand.Parameters.Add(pDienThoai);

                    SqlParameter pDiDong = new SqlParameter("@DiDong", SqlDbType.NVarChar, 50);
                    pDiDong.Value = model.DiDong;
                    myCommand.Parameters.Add(pDiDong);

                    SqlParameter pQuyTrinh = new SqlParameter("@QuaTrinh", SqlDbType.NText);
                    pQuyTrinh.Value = model.QuaTrinh;
                    myCommand.Parameters.Add(pQuyTrinh);

                    SqlParameter pTriThucKyNang = new SqlParameter("@TriThucKyNang", SqlDbType.NText);
                    pTriThucKyNang.Value = model.TriThucKyNang;
                    myCommand.Parameters.Add(pTriThucKyNang);

                    SqlParameter pKhenThuong = new SqlParameter("@KhenThuong", SqlDbType.NVarChar, 4000);
                    pKhenThuong.Value = model.KhenThuong;
                    myCommand.Parameters.Add(pKhenThuong);

                    SqlParameter pKyLuat = new SqlParameter("@KyLuat", SqlDbType.NVarChar, 1000);
                    pKyLuat.Value = model.KyLuat;
                    myCommand.Parameters.Add(pKyLuat);

                    SqlParameter pHinhAnh = new SqlParameter("@HinhAnh", SqlDbType.Int);
                    pHinhAnh.Value = model.HinhAnh;
                    myCommand.Parameters.Add(pHinhAnh);

                    SqlParameter pFile = new SqlParameter("@File", SqlDbType.NVarChar, 50);
                    pFile.Value = model.File;
                    myCommand.Parameters.Add(pFile);

                    SqlParameter pUrl = new SqlParameter("@Url", SqlDbType.NVarChar, 100);
                    pUrl.Value = model.Url;
                    myCommand.Parameters.Add(pUrl);

                    SqlParameter pGioiThieu = new SqlParameter("@GioiThieu", SqlDbType.NText);
                    pGioiThieu.Value = model.GioiThieu;
                    myCommand.Parameters.Add(pGioiThieu);

                    SqlParameter pDanhHieu = new SqlParameter("@DanhHieu", SqlDbType.Int);
                    pDanhHieu.Value = model.DanhHieu;
                    myCommand.Parameters.Add(pDanhHieu);

                    SqlParameter pLoaiDiSan = new SqlParameter("@LoaiDiSan", SqlDbType.Int);
                    pLoaiDiSan.Value = model.LoaiDiSan;
                    myCommand.Parameters.Add(pLoaiDiSan);


                    SqlParameter pTenDiSan = new SqlParameter("@TenDiSan", SqlDbType.NVarChar, 500);
                    pTenDiSan.Value = model.TenDiSan;
                    myCommand.Parameters.Add(pTenDiSan);
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
        public bool update(NV_NgheNhan_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_NgheNhan_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = model.ID;
                    myCommand.Parameters.Add(pID);


                    SqlParameter pHoTen = new SqlParameter("@HoTen", SqlDbType.NVarChar, 50);
                    pHoTen.Value = model.HoTen;
                    myCommand.Parameters.Add(pHoTen);

                    SqlParameter pTenKhac = new SqlParameter("@TenKhac", SqlDbType.NVarChar, 50);
                    pTenKhac.Value = model.TenKhac;
                    myCommand.Parameters.Add(pTenKhac);

                    SqlParameter pNgaySinh = new SqlParameter("@NgaySinh", SqlDbType.NVarChar, 100);
                    pNgaySinh.Value = model.NgaySinh;
                    myCommand.Parameters.Add(pNgaySinh);

                    SqlParameter pNgayCap = new SqlParameter("@NgayCap", SqlDbType.DateTime);
                    pNgayCap.Value = model.NgayCap;
                    myCommand.Parameters.Add(pNgayCap);

                    SqlParameter pDanToc = new SqlParameter("@MaDanToc", SqlDbType.VarChar, 5);
                    pDanToc.Value = model.MaDanToc;
                    myCommand.Parameters.Add(pDanToc);

                    SqlParameter pNguyenQuan = new SqlParameter("@NguyenQuan", SqlDbType.NVarChar, 200);
                    pNguyenQuan.Value = model.NguyenQuan;
                    myCommand.Parameters.Add(pNguyenQuan);

                    SqlParameter pDiaChi = new SqlParameter("@DiaChi", SqlDbType.NVarChar, 200);
                    pDiaChi.Value = model.DiaChi;
                    myCommand.Parameters.Add(pDiaChi);

                    SqlParameter pHoKhauThuongTru = new SqlParameter("@HoKhauThuongTru", SqlDbType.NVarChar, 200);
                    pHoKhauThuongTru.Value = model.HoKhauThuongTru;
                    myCommand.Parameters.Add(pHoKhauThuongTru);

                    SqlParameter pDiSanID = new SqlParameter("@DiSanID", SqlDbType.Int);
                    pDiSanID.Value = model.DiSanID;
                    myCommand.Parameters.Add(pDiSanID);

                    SqlParameter pNamBatDau = new SqlParameter("@NamBatDau", SqlDbType.NVarChar, 100);
                    pNamBatDau.Value = model.NamBatDau;
                    myCommand.Parameters.Add(pNamBatDau);

                    SqlParameter pDienThoai = new SqlParameter("@DienThoai", SqlDbType.NVarChar, 50);
                    pDienThoai.Value = model.DienThoai;
                    myCommand.Parameters.Add(pDienThoai);

                    SqlParameter pDiDong = new SqlParameter("@DiDong", SqlDbType.NVarChar, 50);
                    pDiDong.Value = model.DiDong;
                    myCommand.Parameters.Add(pDiDong);

                    SqlParameter pQuyTrinh = new SqlParameter("@QuaTrinh", SqlDbType.NText);
                    pQuyTrinh.Value = model.QuaTrinh;
                    myCommand.Parameters.Add(pQuyTrinh);

                    SqlParameter pTriThucKyNang = new SqlParameter("@TriThucKyNang", SqlDbType.NText);
                    pTriThucKyNang.Value = model.TriThucKyNang;
                    myCommand.Parameters.Add(pTriThucKyNang);

                    SqlParameter pKhenThuong = new SqlParameter("@KhenThuong", SqlDbType.NVarChar, 4000);
                    pKhenThuong.Value = model.KhenThuong;
                    myCommand.Parameters.Add(pKhenThuong);

                    SqlParameter pKyLuat = new SqlParameter("@KyLuat", SqlDbType.NVarChar, 1000);
                    pKyLuat.Value = model.KyLuat;
                    myCommand.Parameters.Add(pKyLuat);

                    SqlParameter pHinhAnh = new SqlParameter("@HinhAnh", SqlDbType.Int);
                    pHinhAnh.Value = model.HinhAnh;
                    myCommand.Parameters.Add(pHinhAnh);

                    SqlParameter pFile = new SqlParameter("@File", SqlDbType.NVarChar, 50);
                    pFile.Value = model.File;
                    myCommand.Parameters.Add(pFile);

                    SqlParameter pUrl = new SqlParameter("@Url", SqlDbType.NVarChar, 100);
                    pUrl.Value = model.Url;
                    myCommand.Parameters.Add(pUrl);

                    SqlParameter pGioiThieu = new SqlParameter("@GioiThieu", SqlDbType.NText);
                    pGioiThieu.Value = model.GioiThieu;
                    myCommand.Parameters.Add(pGioiThieu);

                    SqlParameter pDanhHieu = new SqlParameter("@DanhHieu", SqlDbType.Int);
                    pDanhHieu.Value = model.DanhHieu;
                    myCommand.Parameters.Add(pDanhHieu);

                    SqlParameter pLoaiDiSan = new SqlParameter("@LoaiDiSan", SqlDbType.Int);
                    pLoaiDiSan.Value = model.LoaiDiSan;
                    myCommand.Parameters.Add(pLoaiDiSan);


                    SqlParameter pTenDiSan = new SqlParameter("@TenDiSan", SqlDbType.NVarChar, 500);
                    pTenDiSan.Value = model.TenDiSan;
                    myCommand.Parameters.Add(pTenDiSan);
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
                using (SqlCommand myCommand = new SqlCommand("NV_NgheNhan_del", myConnection))
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
