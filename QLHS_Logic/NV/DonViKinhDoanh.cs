using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic
{
    public class NV_DonViKinhDoanh_ChiTiet
    {
        public int ID { get; set; }
        public string TenDonVi { get; set; }
        public string SoGiayPhep { get; set; }
        public DateTime? NgayCap { get; set; }
        public string DienThoai { get; set; }
        public string ThongTinLienHe { get; set; }
        public string ChuKinhDoanh { get; set; }
        public string LinhVuc { get; set; }
        public string ThuocTinh { get; set; }
        public string ThuocHuyen { get; set; }
        public string ThuocXa { get; set; }
        public string DiaChi { get; set; }
        public int Stt { get; set; }
        public NV_DonViKinhDoanh_ChiTiet() { }
        public NV_DonViKinhDoanh_ChiTiet(DataTable dt)
        {
            ID = int.Parse(dt.Rows[0]["ID"].ToString());
            TenDonVi = dt.Rows[0]["TenDonVi"].ToString();
            SoGiayPhep = dt.Rows[0]["SoGiayPhep"].ToString();
            try
            {
                NgayCap = Convert.ToDateTime(dt.Rows[0]["NgayCap"].ToString());
            }
            catch
            {
                NgayCap = null;
            }
            DienThoai = dt.Rows[0]["DienThoai"].ToString();
            ThongTinLienHe = dt.Rows[0]["ThongTinLienHe"].ToString();
            ChuKinhDoanh = dt.Rows[0]["ChuKinhDoanh"].ToString();
            ThuocTinh = dt.Rows[0]["ThuocTinh"].ToString();
            ThuocHuyen = dt.Rows[0]["ThuocHuyen"].ToString();
            ThuocXa = dt.Rows[0]["ThuocXa"].ToString();
            DiaChi = dt.Rows[0]["DiaChi"].ToString();
            Stt = int.Parse(dt.Rows[0]["Stt"].ToString());

            LinhVuc = dt.Rows[0]["LinhVuc"].ToString();
        }
    }
    public class NV_DonViKinhDoanh
    {
        private string ConnectionString;
        public NV_DonViKinhDoanh(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }

        #region Lấy theo ID
        public NV_DonViKinhDoanh_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DonViKinhDoanh_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    DataTable dt;
                    NV_DonViKinhDoanh_ChiTiet model = new NV_DonViKinhDoanh_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_DonViKinhDoanh_ChiTiet(dt);
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
                using (SqlCommand myCommand = new SqlCommand("NV_DonViKinhDoanh_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_DonViKinhDoanh_getAll");
                    return myDataSet.Tables["NV_DonViKinhDoanh_getAll"];

                }
            }
        }

        #endregion
        #region Thêm
        public bool them(NV_DonViKinhDoanh_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DonViKinhDoanh_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pTenDonVi = new SqlParameter("@TenDonVi", SqlDbType.NVarChar, 250);
                    pTenDonVi.Value = model.TenDonVi;
                    myCommand.Parameters.Add(pTenDonVi);

                    SqlParameter pSoGiayPhep = new SqlParameter("@SoGiayPhep", SqlDbType.NVarChar, 50);
                    pSoGiayPhep.Value = model.SoGiayPhep;
                    myCommand.Parameters.Add(pSoGiayPhep);

                    SqlParameter pNgayCap = new SqlParameter("@NgayCap", SqlDbType.DateTime);
                    pNgayCap.Value = model.NgayCap;
                    myCommand.Parameters.Add(pNgayCap);

                    SqlParameter pDienThoai = new SqlParameter("@DienThoai", SqlDbType.NVarChar, 50);
                    pDienThoai.Value = model.DienThoai;
                    myCommand.Parameters.Add(pDienThoai);

                    SqlParameter pThongTinLienHe = new SqlParameter("@ThongTinLienHe", SqlDbType.NVarChar, 250);
                    pThongTinLienHe.Value = model.ThongTinLienHe;
                    myCommand.Parameters.Add(pThongTinLienHe);

                    SqlParameter pChuKinhDoanh = new SqlParameter("@ChuKinhDoanh", SqlDbType.NVarChar, 250);
                    pChuKinhDoanh.Value = model.ChuKinhDoanh;
                    myCommand.Parameters.Add(pChuKinhDoanh);

                    SqlParameter pLinhVuc = new SqlParameter("@LinhVuc", SqlDbType.NVarChar, 50);
                    pLinhVuc.Value = model.LinhVuc;
                    myCommand.Parameters.Add(pLinhVuc);

                    SqlParameter pThuocTinh = new SqlParameter("@ThuocTinh", SqlDbType.VarChar, 10);
                    pThuocTinh.Value = model.ThuocTinh;
                    myCommand.Parameters.Add(pThuocTinh);

                    SqlParameter pThuocHuyen = new SqlParameter("@ThuocHuyen", SqlDbType.VarChar, 10);
                    pThuocHuyen.Value = model.ThuocHuyen;
                    myCommand.Parameters.Add(pThuocHuyen);

                    SqlParameter pThuocXa = new SqlParameter("@ThuocXa", SqlDbType.VarChar, 10);
                    pThuocXa.Value = model.ThuocXa;
                    myCommand.Parameters.Add(pThuocXa);

                    SqlParameter pDiaChi = new SqlParameter("@DiaChi", SqlDbType.NVarChar, 250);
                    pDiaChi.Value = model.DiaChi;
                    myCommand.Parameters.Add(pDiaChi);

                    SqlParameter pStt = new SqlParameter("@Stt", SqlDbType.Int);
                    pStt.Value = model.Stt;
                    myCommand.Parameters.Add(pStt);

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
        public bool update(NV_DonViKinhDoanh_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DonViKinhDoanh_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = model.ID;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pTenDonVi = new SqlParameter("@TenDonVi", SqlDbType.NVarChar, 250);
                    pTenDonVi.Value = model.TenDonVi;
                    myCommand.Parameters.Add(pTenDonVi);

                    SqlParameter pSoGiayPhep = new SqlParameter("@SoGiayPhep", SqlDbType.NVarChar, 50);
                    pSoGiayPhep.Value = model.SoGiayPhep;
                    myCommand.Parameters.Add(pSoGiayPhep);

                    SqlParameter pNgayCap = new SqlParameter("@NgayCap", SqlDbType.DateTime);
                    pNgayCap.Value = model.NgayCap;
                    myCommand.Parameters.Add(pNgayCap);

                    SqlParameter pDienThoai = new SqlParameter("@DienThoai", SqlDbType.NVarChar, 50);
                    pDienThoai.Value = model.DienThoai;
                    myCommand.Parameters.Add(pDienThoai);

                    SqlParameter pThongTinLienHe = new SqlParameter("@ThongTinLienHe", SqlDbType.NVarChar, 250);
                    pThongTinLienHe.Value = model.ThongTinLienHe;
                    myCommand.Parameters.Add(pThongTinLienHe);

                    SqlParameter pChuKinhDoanh = new SqlParameter("@ChuKinhDoanh", SqlDbType.NVarChar, 250);
                    pChuKinhDoanh.Value = model.ChuKinhDoanh;
                    myCommand.Parameters.Add(pChuKinhDoanh);

                    SqlParameter pLinhVuc = new SqlParameter("@LinhVuc", SqlDbType.NVarChar, 50);
                    pLinhVuc.Value = model.LinhVuc;
                    myCommand.Parameters.Add(pLinhVuc);

                    SqlParameter pThuocTinh = new SqlParameter("@ThuocTinh", SqlDbType.VarChar, 10);
                    pThuocTinh.Value = model.ThuocTinh;
                    myCommand.Parameters.Add(pThuocTinh);

                    SqlParameter pThuocHuyen = new SqlParameter("@ThuocHuyen", SqlDbType.VarChar, 10);
                    pThuocHuyen.Value = model.ThuocHuyen;
                    myCommand.Parameters.Add(pThuocHuyen);

                    SqlParameter pThuocXa = new SqlParameter("@ThuocXa", SqlDbType.VarChar, 10);
                    pThuocXa.Value = model.ThuocXa;
                    myCommand.Parameters.Add(pThuocXa);

                    SqlParameter pDiaChi = new SqlParameter("@DiaChi", SqlDbType.NVarChar, 250);
                    pDiaChi.Value = model.DiaChi;
                    myCommand.Parameters.Add(pDiaChi);

                    SqlParameter pStt = new SqlParameter("@Stt", SqlDbType.Int);
                    pStt.Value = model.Stt;
                    myCommand.Parameters.Add(pStt);

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
                using (SqlCommand myCommand = new SqlCommand("NV_DonViKinhDoanh_del", myConnection))
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
