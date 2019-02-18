using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_DanhMucDuong_ChiTiet
    {
        public int ID { get; set; }
        public string TenDuong { get; set; }
        public string SoHieuDuongBo { get; set; }
        public string ChieuDai { get; set; }
        public string DiemDau { get; set; }
        public string DiemCuoi { get; set; }
        public string MatDuong { get; set; }
        public string QuyetDinh { get; set; }
        public string DanhNhan { get; set; }
        public string TieuSu { get; set; }
        public string ThayDoi { get; set; }
        public string Url { get; set; }
        public string ThuocTinh { get; set; }
        public string ThuocHuyen { get; set; }
        public NV_DanhMucDuong_ChiTiet() { }
        public NV_DanhMucDuong_ChiTiet(DataTable dt)
        {
            ID = int.Parse(dt.Rows[0]["ID"].ToString());
            TenDuong = dt.Rows[0]["TenDuong"].ToString();
            SoHieuDuongBo = dt.Rows[0]["SoHieuDuongBo"].ToString();
            ChieuDai = dt.Rows[0]["ChieuDai"].ToString();
            DiemDau = dt.Rows[0]["DiemDau"].ToString();
            DiemCuoi = dt.Rows[0]["DiemCuoi"].ToString();
            MatDuong = dt.Rows[0]["MatDuong"].ToString();
            QuyetDinh = dt.Rows[0]["QuyetDinh"].ToString();
            DanhNhan = dt.Rows[0]["DanhNhan"].ToString();
            TieuSu = dt.Rows[0]["TieuSu"].ToString();
            ThayDoi = dt.Rows[0]["ThayDoi"].ToString();
            Url = dt.Rows[0]["Url"].ToString();
            ThuocHuyen = dt.Rows[0]["ThuocHuyen"].ToString();
            ThuocTinh = dt.Rows[0]["ThuocTinh"].ToString();
        }
    }
    public class NV_DanhMucDuong
    {
        private string ConnectionString;
        public NV_DanhMucDuong(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }


        #region Lấy theo ID
        public NV_DanhMucDuong_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DanhMucDuong_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    DataTable dt;
                    NV_DanhMucDuong_ChiTiet model = new NV_DanhMucDuong_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_DanhMucDuong_ChiTiet(dt);
                    }
                    return model;
                }
            }
        }
        #endregion

        #region Lấy theo url
        public NV_DanhMucDuong_ChiTiet GetByUrl(string url)
        {
            string sql = "select top 1 * from DanhMucDuong where Url='" + url + "'";
            DataTable dt = Sys_Common.getDataByQuery(sql);
            NV_DanhMucDuong_ChiTiet menu = new NV_DanhMucDuong_ChiTiet();
            if (dt != null && dt.Rows.Count > 0)
            {
                menu = new NV_DanhMucDuong_ChiTiet(dt);
            }
            return menu;
        }
        #endregion

        #region Lấy tất cả
        public DataTable GetAll()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DanhMucDuong_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_DanhMucDuong_getAll");
                    return myDataSet.Tables["NV_DanhMucDuong_getAll"];

                }
            }
        }

        #endregion

        #region Thêm
        public bool them(NV_DanhMucDuong_ChiTiet model, out int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DanhMucDuong_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pTenDuong = new SqlParameter("@TenDuong", SqlDbType.NVarChar, 250);
                    pTenDuong.Value = model.TenDuong;
                    myCommand.Parameters.Add(pTenDuong);


                    SqlParameter pSoHieuDuongBo = new SqlParameter("@SoHieuDuongBo", SqlDbType.NVarChar, 250);
                    pSoHieuDuongBo.Value = model.SoHieuDuongBo;
                    myCommand.Parameters.Add(pSoHieuDuongBo);


                    SqlParameter pChieuDai = new SqlParameter("@ChieuDai", SqlDbType.NVarChar, 250);
                    pChieuDai.Value = model.ChieuDai;
                    myCommand.Parameters.Add(pChieuDai);

                    SqlParameter pDiemDau = new SqlParameter("@DiemDau", SqlDbType.NVarChar, 250);
                    pDiemDau.Value = model.DiemDau;
                    myCommand.Parameters.Add(pDiemDau);

                    SqlParameter pDiemCuoi = new SqlParameter("@DiemCuoi", SqlDbType.NVarChar, 250);
                    pDiemCuoi.Value = model.DiemCuoi;
                    myCommand.Parameters.Add(pDiemCuoi);

                    SqlParameter pMatDuong = new SqlParameter("@MatDuong", SqlDbType.NVarChar, 250);
                    pMatDuong.Value = model.MatDuong;
                    myCommand.Parameters.Add(pMatDuong);

                    SqlParameter pQuyetDinh = new SqlParameter("@QuyetDinh", SqlDbType.NText);
                    pQuyetDinh.Value = model.QuyetDinh;
                    myCommand.Parameters.Add(pQuyetDinh);

                    SqlParameter pDanhNhan = new SqlParameter("@DanhNhan", SqlDbType.NVarChar, 250);
                    pDanhNhan.Value = model.DanhNhan;
                    myCommand.Parameters.Add(pDanhNhan);

                    SqlParameter pTieuSu = new SqlParameter("@TieuSu", SqlDbType.NText);
                    pTieuSu.Value = model.TieuSu;
                    myCommand.Parameters.Add(pTieuSu);

                    SqlParameter pThayDoi = new SqlParameter("@ThayDoi", SqlDbType.NText);
                    pThayDoi.Value = model.ThayDoi;
                    myCommand.Parameters.Add(pThayDoi);

                    SqlParameter pUrl = new SqlParameter("@Url", SqlDbType.NVarChar, 250);
                    pUrl.Value = model.Url;
                    myCommand.Parameters.Add(pUrl);

                    SqlParameter pThuocTinh = new SqlParameter("@ThuocTinh", SqlDbType.VarChar, 10);
                    pThuocTinh.Value = model.ThuocTinh;
                    myCommand.Parameters.Add(pThuocTinh);

                    SqlParameter pThuocHuyen = new SqlParameter("@ThuocHuyen", SqlDbType.VarChar, 10);
                    pThuocHuyen.Value = model.ThuocHuyen;
                    myCommand.Parameters.Add(pThuocHuyen);
                    id = 0;
                    try
                    {
                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                        id = (int)pID.Value;
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
        public bool update(NV_DanhMucDuong_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DanhMucDuong_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = model.ID;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pTenDuong = new SqlParameter("@TenDuong", SqlDbType.NVarChar, 250);
                    pTenDuong.Value = model.TenDuong;
                    myCommand.Parameters.Add(pTenDuong);


                    SqlParameter pSoHieuDuongBo = new SqlParameter("@SoHieuDuongBo", SqlDbType.NVarChar, 250);
                    pSoHieuDuongBo.Value = model.SoHieuDuongBo;
                    myCommand.Parameters.Add(pSoHieuDuongBo);


                    SqlParameter pChieuDai = new SqlParameter("@ChieuDai", SqlDbType.NVarChar, 250);
                    pChieuDai.Value = model.ChieuDai;
                    myCommand.Parameters.Add(pChieuDai);

                    SqlParameter pDiemDau = new SqlParameter("@DiemDau", SqlDbType.NVarChar, 250);
                    pDiemDau.Value = model.DiemDau;
                    myCommand.Parameters.Add(pDiemDau);

                    SqlParameter pDiemCuoi = new SqlParameter("@DiemCuoi", SqlDbType.NVarChar, 250);
                    pDiemCuoi.Value = model.DiemCuoi;
                    myCommand.Parameters.Add(pDiemCuoi);

                    SqlParameter pMatDuong = new SqlParameter("@MatDuong", SqlDbType.NVarChar, 250);
                    pMatDuong.Value = model.MatDuong;
                    myCommand.Parameters.Add(pMatDuong);

                    SqlParameter pQuyetDinh = new SqlParameter("@QuyetDinh", SqlDbType.NText);
                    pQuyetDinh.Value = model.QuyetDinh;
                    myCommand.Parameters.Add(pQuyetDinh);

                    SqlParameter pDanhNhan = new SqlParameter("@DanhNhan", SqlDbType.NVarChar, 250);
                    pDanhNhan.Value = model.DanhNhan;
                    myCommand.Parameters.Add(pDanhNhan);

                    SqlParameter pTieuSu = new SqlParameter("@TieuSu", SqlDbType.NText);
                    pTieuSu.Value = model.TieuSu;
                    myCommand.Parameters.Add(pTieuSu);

                    SqlParameter pThayDoi = new SqlParameter("@ThayDoi", SqlDbType.NText);
                    pThayDoi.Value = model.ThayDoi;
                    myCommand.Parameters.Add(pThayDoi);

                    SqlParameter pUrl = new SqlParameter("@Url", SqlDbType.NVarChar, 250);
                    pUrl.Value = model.Url;
                    myCommand.Parameters.Add(pUrl);

                    SqlParameter pThuocTinh = new SqlParameter("@ThuocTinh", SqlDbType.VarChar, 10);
                    pThuocTinh.Value = model.ThuocTinh;
                    myCommand.Parameters.Add(pThuocTinh);

                    SqlParameter pThuocHuyen = new SqlParameter("@ThuocHuyen", SqlDbType.VarChar, 10);
                    pThuocHuyen.Value = model.ThuocHuyen;
                    myCommand.Parameters.Add(pThuocHuyen);
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
                using (SqlCommand myCommand = new SqlCommand("NV_DanhMucDuong_del", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.VarChar, 10);
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
