using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_AnPham_ChiTiet
    {
        public int ID { get; set; }
        public int DanhMucID { get; set; }
        public string DanhMuc { get; set; }
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public string TacGia { get; set; }
        public int DiSanID { get; set; }
        public int SoTrang { get; set; }
        public string GioiThieu { get; set; }

        public string KichCo { get; set; }
        public string FileDinhKem { get; set; }
        public string AnhDaiDien { get; set; }
        public string HinhAnh { get; set; }
        public string NhaXB { get; set; }
        public string TomTatNoiDung { get; set; }
        public int NamXB { get; set; }
        public string Url { get; set; }
        public string urlFull { get; set; }
        public bool Duyet { get; set; }
        public bool TonTai { get; set; }
        public int NguoiTao { get; set; }
        public DateTime NgayTao { get; set; }
        public string Lang { get; set; }
        public NV_AnPham_ChiTiet() { }
        public NV_AnPham_ChiTiet(DataTable dt)
        {
            Lang = dt.Rows[0]["Lang"].ToString();
            ID = int.Parse(dt.Rows[0]["ID"].ToString());
            MaSach = dt.Rows[0]["MaSach"].ToString();
            TenSach = dt.Rows[0]["TenSach"].ToString();
            DanhMuc = dt.Rows[0]["DanhMuc"].ToString();
            try
            {
                DanhMucID = int.Parse(dt.Rows[0]["DanhMucID"].ToString());
            }
            catch { }
            try
            {
                DiSanID = int.Parse(dt.Rows[0]["DiSanID"].ToString());
            }
            catch
            {
                DiSanID = 0;
            }
            NamXB = int.Parse(dt.Rows[0]["NamXB"].ToString());
            TacGia = dt.Rows[0]["TacGia"].ToString();
            GioiThieu = dt.Rows[0]["GioiThieu"].ToString();
            SoTrang = int.Parse(dt.Rows[0]["SoTrang"].ToString());
            KichCo = dt.Rows[0]["KichCo"].ToString();
            FileDinhKem = dt.Rows[0]["FileDinhKem"].ToString();
            AnhDaiDien = dt.Rows[0]["AnhDaiDien"].ToString();
            NhaXB = dt.Rows[0]["NhaXB"].ToString();
            TomTatNoiDung = dt.Rows[0]["TomTatNoiDung"].ToString();
            Url = dt.Rows[0]["Url"].ToString();
            Duyet = Convert.ToBoolean(dt.Rows[0]["Duyet"].ToString());
            TonTai = Convert.ToBoolean(dt.Rows[0]["TonTai"].ToString());
            NguoiTao = int.Parse(dt.Rows[0]["NguoiTao"].ToString());
            NgayTao = Convert.ToDateTime(dt.Rows[0]["NgayTao"].ToString());
            try
            {
                HinhAnh = dt.Rows[0]["HinhAnh"].ToString();
            }
            catch { }
        }

    }
    public class NV_AnPham
    {
        private string ConnectionString;
        public NV_AnPham(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }

        #region Lấy theo ID
        public NV_AnPham_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_AnPham_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);


                    DataTable dt;
                    NV_AnPham_ChiTiet model = new NV_AnPham_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_AnPham_ChiTiet(dt);
                    }
                    return model;
                }
            }
        }
        #endregion

        #region Lấy theo url
        public NV_AnPham_ChiTiet GetByUrl(string url)
        {
            string sql = "select top 1 * from AnPham where Url='" + url + "'";
            DataTable dt = Sys_Common.getDataByQuery(sql);
            NV_AnPham_ChiTiet bv = new NV_AnPham_ChiTiet();
            if (dt != null && dt.Rows.Count > 0)
            {
                bv = new NV_AnPham_ChiTiet(dt);
            }
            return bv;
        }
        #endregion
        #region Lấy theo danh muc
        public DataTable GetByDanhMuc(int danhmuc,string lang="vi")
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_AnPham_getByDanhMuc", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pID = new SqlParameter("@DanhMucID", SqlDbType.Int);
                    pID.Value = danhmuc;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pLang = new SqlParameter("@Lang", SqlDbType.VarChar,10);
                    pLang.Value = lang;
                    myCommand.Parameters.Add(pLang);


                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_AnPham_getByDanhMuc");
                    return myDataSet.Tables["NV_AnPham_getByDanhMuc"];

                }
            }
        }

        #endregion
        #region Lấy tất cả
        public DataTable GetAll(string lang="vi")
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_AnPham_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pLang = new SqlParameter("@Lang", SqlDbType.VarChar, 10);
                    pLang.Value = lang;
                    myCommand.Parameters.Add(pLang);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_AnPham_getAll");
                    return myDataSet.Tables["NV_AnPham_getAll"];

                }
            }
        }

        #endregion

        #region Thêm

        public bool Them(NV_AnPham_ChiTiet model, out int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_AnPham_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = ParameterDirection.Output;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pLang = new SqlParameter("@Lang", SqlDbType.VarChar, 10);
                    pLang.Value = model.Lang;
                    myCommand.Parameters.Add(pLang);


                    SqlParameter pTenSach = new SqlParameter("@TenSach", SqlDbType.NVarChar, 500);
                    pTenSach.Value = model.TenSach;
                    myCommand.Parameters.Add(pTenSach);

                    SqlParameter pMaSach = new SqlParameter("@MaSach", SqlDbType.VarChar, 20);
                    pMaSach.Value = model.MaSach;
                    myCommand.Parameters.Add(pMaSach);

                    SqlParameter pDanhMucID = new SqlParameter("@DanhMucID", SqlDbType.Int);
                    pDanhMucID.Value = model.DanhMucID;
                    myCommand.Parameters.Add(pDanhMucID);

                    SqlParameter pTacGia = new SqlParameter("@TacGia", SqlDbType.NVarChar, 500);
                    pTacGia.Value = model.TacGia;
                    myCommand.Parameters.Add(pTacGia);

                    SqlParameter pDiSanID = new SqlParameter("@DiSanID", SqlDbType.Int);
                    pDiSanID.Value = model.DiSanID;
                    myCommand.Parameters.Add(pDiSanID);

                    SqlParameter pSoTrang = new SqlParameter("@SoTrang", SqlDbType.Int);
                    pSoTrang.Value = model.SoTrang;
                    myCommand.Parameters.Add(pSoTrang);

                    SqlParameter pGioiThieu = new SqlParameter("@GioiThieu", SqlDbType.NText);
                    pGioiThieu.Value = model.GioiThieu;
                    myCommand.Parameters.Add(pGioiThieu);

                    SqlParameter pKichCo = new SqlParameter("@KichCo", SqlDbType.NVarChar, 50);
                    pKichCo.Value = model.KichCo;
                    myCommand.Parameters.Add(pKichCo);

                    SqlParameter pFileDinhKem = new SqlParameter("@FileDinhKem", SqlDbType.NVarChar, 500);
                    pFileDinhKem.Value = model.FileDinhKem;
                    myCommand.Parameters.Add(pFileDinhKem);

                    SqlParameter pAnhDaiDien = new SqlParameter("@AnhDaiDien", SqlDbType.NVarChar, 200);
                    pAnhDaiDien.Value = model.AnhDaiDien;
                    myCommand.Parameters.Add(pAnhDaiDien);

                    SqlParameter pNhaXB = new SqlParameter("@NhaXB", SqlDbType.NVarChar, 4000);
                    pNhaXB.Value = model.NhaXB;
                    myCommand.Parameters.Add(pNhaXB);

                    SqlParameter pTomTatNoiDung = new SqlParameter("@TomTatNoiDung", SqlDbType.NText);
                    pTomTatNoiDung.Value = model.TomTatNoiDung;
                    myCommand.Parameters.Add(pTomTatNoiDung);

                    SqlParameter pNamXB = new SqlParameter("@NamXB", SqlDbType.Int);
                    pNamXB.Value = model.NamXB;
                    myCommand.Parameters.Add(pNamXB);

                    SqlParameter pUrl = new SqlParameter("@Url", SqlDbType.NVarChar, 200);
                    pUrl.Value = model.Url;
                    myCommand.Parameters.Add(pUrl);

                    SqlParameter pNguoiTao = new SqlParameter("@NguoiTao", SqlDbType.Int);
                    pNguoiTao.Value = model.NguoiTao;
                    myCommand.Parameters.Add(pNguoiTao);

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
        public bool Update(NV_AnPham_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_AnPham_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = model.ID;
                    myCommand.Parameters.Add(pID);


                    SqlParameter pLang = new SqlParameter("@Lang", SqlDbType.VarChar, 10);
                    pLang.Value = model.Lang;
                    myCommand.Parameters.Add(pLang);

                    SqlParameter pTenSach = new SqlParameter("@TenSach", SqlDbType.NVarChar, 500);
                    pTenSach.Value = model.TenSach;
                    myCommand.Parameters.Add(pTenSach);

                    SqlParameter pDanhMucID = new SqlParameter("@DanhMucID", SqlDbType.Int);
                    pDanhMucID.Value = model.DanhMucID;
                    myCommand.Parameters.Add(pDanhMucID);

                    SqlParameter pMaSach = new SqlParameter("@MaSach", SqlDbType.VarChar, 20);
                    pMaSach.Value = model.MaSach;
                    myCommand.Parameters.Add(pMaSach);

                    SqlParameter pTacGia = new SqlParameter("@TacGia", SqlDbType.NVarChar, 500);
                    pTacGia.Value = model.TacGia;
                    myCommand.Parameters.Add(pTacGia);

                    SqlParameter pDiSanID = new SqlParameter("@DiSanID", SqlDbType.Int);
                    pDiSanID.Value = model.DiSanID;
                    myCommand.Parameters.Add(pDiSanID);

                    SqlParameter pSoTrang = new SqlParameter("@SoTrang", SqlDbType.Int);
                    pSoTrang.Value = model.SoTrang;
                    myCommand.Parameters.Add(pSoTrang);

                    SqlParameter pGioiThieu = new SqlParameter("@GioiThieu", SqlDbType.NText);
                    pGioiThieu.Value = model.GioiThieu;
                    myCommand.Parameters.Add(pGioiThieu);

                    SqlParameter pKichCo = new SqlParameter("@KichCo", SqlDbType.NVarChar, 50);
                    pKichCo.Value = model.KichCo;
                    myCommand.Parameters.Add(pKichCo);

                    SqlParameter pFileDinhKem = new SqlParameter("@FileDinhKem", SqlDbType.NVarChar, 500);
                    pFileDinhKem.Value = model.FileDinhKem;
                    myCommand.Parameters.Add(pFileDinhKem);

                    SqlParameter pAnhDaiDien = new SqlParameter("@AnhDaiDien", SqlDbType.NVarChar, 200);
                    pAnhDaiDien.Value = model.AnhDaiDien;
                    myCommand.Parameters.Add(pAnhDaiDien);

                    SqlParameter pNhaXB = new SqlParameter("@NhaXB", SqlDbType.NVarChar, 4000);
                    pNhaXB.Value = model.NhaXB;
                    myCommand.Parameters.Add(pNhaXB);

                    SqlParameter pTomTatNoiDung = new SqlParameter("@TomTatNoiDung", SqlDbType.NText);
                    pTomTatNoiDung.Value = model.TomTatNoiDung;
                    myCommand.Parameters.Add(pTomTatNoiDung);

                    SqlParameter pNamXB = new SqlParameter("@NamXB", SqlDbType.Int);
                    pNamXB.Value = model.NamXB;
                    myCommand.Parameters.Add(pNamXB);

                    SqlParameter pUrl = new SqlParameter("@Url", SqlDbType.NVarChar, 200);
                    pUrl.Value = model.Url;
                    myCommand.Parameters.Add(pUrl);

                    SqlParameter pDuyet = new SqlParameter("@Duyet", SqlDbType.Bit);
                    pDuyet.Value = model.Duyet;
                    myCommand.Parameters.Add(pDuyet);

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
                using (SqlCommand myCommand = new SqlCommand("NV_AnPham_del", myConnection))
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
