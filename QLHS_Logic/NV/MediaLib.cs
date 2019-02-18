using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_MediaLib_ChiTiet
    {
        public int MediaLibID { get; set; }
        public string TenMediaLib { get; set; }
        public int TypeMedia { get; set; }
        public int HoatDongID { get; set; }
        public int DiSanID { get; set; }
        public string MoTa { get; set; }
        public int HinhAnh { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgaySua { get; set; }
        public string NguoiTao { get; set; }
        public bool Duyet { get; set; }
        public string MediaArray { get; set; }
        public string DanhMuc { get; set; }
        public string PageTitle { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public string Url { get; set; }
        public string UrlFull { get; set; }
        public NV_MediaLib_ChiTiet() { }
        public NV_MediaLib_ChiTiet(DataRow dr)
        {
            MediaLibID = int.Parse(dr["MediaLibID"].ToString());
            TenMediaLib = dr["TenMediaLib"].ToString();
            TypeMedia = int.Parse(dr["TypeMedia"].ToString());
            try
            {
                DiSanID = int.Parse(dr["DiSanID"].ToString());
            }
            catch { }
            try
            {
                HoatDongID = int.Parse(dr["HoatDongID"].ToString());
            }
            catch { }
            MoTa = dr["MoTa"].ToString();
            HinhAnh = int.Parse(dr["HinhAnh"].ToString());
            try
            {
                NgayTao = Convert.ToDateTime(dr["NgayTao"].ToString());
            }
            catch
            {
                NgayTao = DateTime.Now;
            }
            try
            {
                NgaySua = Convert.ToDateTime(dr["NgaySua"].ToString());
            }
            catch
            {
                NgaySua = DateTime.Now;
            }
            NguoiTao = dr["NguoiTao"].ToString();
            Duyet = Convert.ToBoolean(dr["Duyet"].ToString());
            MediaArray = dr["MediaArray"].ToString();
            DanhMuc = dr["DanhMuc"].ToString();
            PageTitle = dr["PageTitle"].ToString();
            MetaKeyword = dr["MetaKeyword"].ToString();
            MetaDescription = dr["MetaDescription"].ToString();
            Url = dr["Url"].ToString();
            UrlFull = dr["UrlFull"].ToString();
        }
    }
    public class NV_MediaLib
    {
        private string ConnectionString;
        public NV_MediaLib(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lấy theo ID
        public NV_MediaLib_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_MediaLib_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@id", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    NV_MediaLib_ChiTiet model = new NV_MediaLib_ChiTiet();
                    DataTable dt;

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_MediaLib_ChiTiet(dt.Rows[0]);
                    }
                    return model;
                }
            }
        }
        public NV_MediaLib_ChiTiet GetByUrl(string url)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_MediaLib_getByUrl", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@Url", SqlDbType.NVarChar, 200);
                    pID.Value = url;
                    myCommand.Parameters.Add(pID);

                    NV_MediaLib_ChiTiet model = new NV_MediaLib_ChiTiet();
                    DataTable dt;

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_MediaLib_ChiTiet(dt.Rows[0]);
                    }
                    return model;
                }
            }
        }
        #endregion

        #region update
        public bool update(NV_MediaLib_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_MediaLib_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@MediaLibID", SqlDbType.Int);
                    pID.Value = model.MediaLibID;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pTenMediaLib = new SqlParameter("@TenMediaLib", SqlDbType.NVarChar, 500);
                    pTenMediaLib.Value = model.TenMediaLib;
                    myCommand.Parameters.Add(pTenMediaLib);

                    SqlParameter pTypeMedia = new SqlParameter("@TypeMedia", SqlDbType.Int);
                    pTypeMedia.Value = model.TypeMedia;
                    myCommand.Parameters.Add(pTypeMedia);

                    SqlParameter pMoTa = new SqlParameter("@MoTa", SqlDbType.NText);
                    pMoTa.Value = model.MoTa;
                    myCommand.Parameters.Add(pMoTa);

                    SqlParameter pHoatDongID = new SqlParameter("@HoatDongID", SqlDbType.Int);
                    pHoatDongID.Value = model.HoatDongID;
                    myCommand.Parameters.Add(pHoatDongID);

                    SqlParameter pHinhAnh = new SqlParameter("@HinhAnh", SqlDbType.Int);
                    pHinhAnh.Value = model.HinhAnh;
                    myCommand.Parameters.Add(pHinhAnh);

                    SqlParameter pDiSanID = new SqlParameter("@DiSanID", SqlDbType.Int);
                    pDiSanID.Value = model.DiSanID;
                    myCommand.Parameters.Add(pDiSanID);

                    SqlParameter pNgayTao = new SqlParameter("@NgayTao", SqlDbType.DateTime);
                    pNgayTao.Value = model.NgayTao;
                    myCommand.Parameters.Add(pNgayTao);

                    SqlParameter pNgaySua = new SqlParameter("@NgaySua", SqlDbType.DateTime);
                    pNgaySua.Value = model.NgaySua;
                    myCommand.Parameters.Add(pNgaySua);

                    SqlParameter pNguoiTao = new SqlParameter("@NguoiTao", SqlDbType.NVarChar, 200);
                    pNguoiTao.Value = model.NguoiTao;
                    myCommand.Parameters.Add(pNguoiTao);

                    SqlParameter pDuyet = new SqlParameter("@Duyet", SqlDbType.Bit);
                    pDuyet.Value = model.Duyet;
                    myCommand.Parameters.Add(pDuyet);

                    SqlParameter pMediaArray = new SqlParameter("@MediaArray", SqlDbType.NVarChar, 500);
                    pMediaArray.Value = model.MediaArray;
                    myCommand.Parameters.Add(pMediaArray);

                    SqlParameter pDanhMuc = new SqlParameter("@DanhMuc", SqlDbType.NVarChar, 200);
                    pDanhMuc.Value = model.DanhMuc;
                    myCommand.Parameters.Add(pDanhMuc);

                    SqlParameter pPageTitle = new SqlParameter("@PageTitle", SqlDbType.NVarChar, 200);
                    pPageTitle.Value = model.PageTitle;
                    myCommand.Parameters.Add(pPageTitle);

                    SqlParameter pMetaKeyword = new SqlParameter("@MetaKeyword", SqlDbType.NVarChar, 200);
                    pMetaKeyword.Value = model.MetaKeyword;
                    myCommand.Parameters.Add(pMetaKeyword);

                    SqlParameter pMetaDescription = new SqlParameter("@MetaDescription", SqlDbType.NVarChar, 300);
                    pMetaDescription.Value = model.MetaDescription;
                    myCommand.Parameters.Add(pMetaDescription);

                    SqlParameter pUrl = new SqlParameter("@Url", SqlDbType.NVarChar, 200);
                    pUrl.Value = model.Url;
                    myCommand.Parameters.Add(pUrl);
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
                using (SqlCommand myCommand = new SqlCommand("NV_MediaLib_del", myConnection))
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

        #region Lấy tất cả thư viện ảnh ảnh
        public DataTable GetAllImageLib()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_ImageLib_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_ImageLib_getAll");
                    return myDataSet.Tables["NV_ImageLib_getAll"];

                }
            }
        }

        #endregion

        #region Lấy tất cả thư viện video
        public DataTable GetAllVideoLib()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_VideoLib_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_VideoLib_getAll");
                    return myDataSet.Tables["NV_VideoLib_getAll"];

                }
            }
        }

        #endregion

        #region Thêm media lib
        public bool ThemMediaLib(NV_MediaLib_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_MediaLib_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pTenMediaLib = new SqlParameter("@TenMediaLib", SqlDbType.NVarChar, 500);
                    pTenMediaLib.Value = model.TenMediaLib;
                    myCommand.Parameters.Add(pTenMediaLib);

                    SqlParameter pTypeMedia = new SqlParameter("@TypeMedia", SqlDbType.Int);
                    pTypeMedia.Value = model.TypeMedia;
                    myCommand.Parameters.Add(pTypeMedia);

                    SqlParameter pMoTa = new SqlParameter("@MoTa", SqlDbType.NText);
                    pMoTa.Value = model.MoTa;
                    myCommand.Parameters.Add(pMoTa);

                    SqlParameter pHoatDongID = new SqlParameter("@HoatDongID", SqlDbType.Int);
                    pHoatDongID.Value = model.HoatDongID;
                    myCommand.Parameters.Add(pHoatDongID);

                    SqlParameter pHinhAnh = new SqlParameter("@HinhAnh", SqlDbType.Int);
                    pHinhAnh.Value = model.HinhAnh;
                    myCommand.Parameters.Add(pHinhAnh);

                    SqlParameter pDiSanID = new SqlParameter("@DiSanID", SqlDbType.Int);
                    pDiSanID.Value = model.DiSanID;
                    myCommand.Parameters.Add(pDiSanID);

                    SqlParameter pNgayTao = new SqlParameter("@NgayTao", SqlDbType.DateTime);
                    pNgayTao.Value = model.NgayTao;
                    myCommand.Parameters.Add(pNgayTao);

                    SqlParameter pNgaySua = new SqlParameter("@NgaySua", SqlDbType.DateTime);
                    pNgaySua.Value = model.NgaySua;
                    myCommand.Parameters.Add(pNgaySua);

                    SqlParameter pNguoiTao = new SqlParameter("@NguoiTao", SqlDbType.NVarChar, 200);
                    pNguoiTao.Value = model.NguoiTao;
                    myCommand.Parameters.Add(pNguoiTao);

                    SqlParameter pDuyet = new SqlParameter("@Duyet", SqlDbType.Bit);
                    pDuyet.Value = model.Duyet;
                    myCommand.Parameters.Add(pDuyet);

                    SqlParameter pMediaArray = new SqlParameter("@MediaArray", SqlDbType.NVarChar, 500);
                    pMediaArray.Value = model.MediaArray;
                    myCommand.Parameters.Add(pMediaArray);

                    SqlParameter pDanhMuc = new SqlParameter("@DanhMuc", SqlDbType.NVarChar, 200);
                    pDanhMuc.Value = model.DanhMuc;
                    myCommand.Parameters.Add(pDanhMuc);

                    SqlParameter pPageTitle = new SqlParameter("@PageTitle", SqlDbType.NVarChar, 200);
                    pPageTitle.Value = model.PageTitle;
                    myCommand.Parameters.Add(pPageTitle);

                    SqlParameter pMetaKeyword = new SqlParameter("@MetaKeyword", SqlDbType.NVarChar, 200);
                    pMetaKeyword.Value = model.MetaKeyword;
                    myCommand.Parameters.Add(pMetaKeyword);

                    SqlParameter pMetaDescription = new SqlParameter("@MetaDescription", SqlDbType.NVarChar, 300);
                    pMetaDescription.Value = model.MetaDescription;
                    myCommand.Parameters.Add(pMetaDescription);

                    SqlParameter pUrl = new SqlParameter("@Url", SqlDbType.NVarChar, 200);
                    pUrl.Value = model.Url;
                    myCommand.Parameters.Add(pUrl);

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

    }
}
