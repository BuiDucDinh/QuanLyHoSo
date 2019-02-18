using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_KeHoachTuBo_ChiTiet
    {
        public int KeHoachID { get; set; }
        public string TenDuAn { get; set; }
        public string DiaDiem { get; set; }
        public string ThuocTinh { get; set; }
        public string ThuocHuyen { get; set; }
        public string ThuocXa { get; set; }
        public NV_DiSanVanHoa_ChiTiet DiSan { get; set; }
        public NV_DonViTuBo_ChiTiet DonViThietKe { get; set; }
        public NV_DonViTuBo_ChiTiet DonViThiCong { get; set; }
        public NV_DonViTuBo_ChiTiet DonViGiamSat { get; set; }
        public NV_DonViTuBo_ChiTiet ChuDauTu { get; set; }
        public NV_DonViTuBo_ChiTiet CapQD { get; set; }
        public bool TonTai { get; set; }
        public string NoiDung { get; set; }
        public string Lydo { get; set; }
        public string MotaQuaTrinh { get; set; }
        public DateTime? DuKienBatDau = null;
        public DateTime? DukienHoanThanh = null;
        public bool TrangThai { get; set; }
        public DateTime? ThucTeBatDau = null;
        public DateTime? ThucTeHoanThanh = null;
        public decimal ChiPhiDuKien { get; set; }
        public decimal ChiPhiThucTe { get; set; }
        public string File { get; set; }
        public NV_KeHoachTuBo_ChiTiet(DataRow dr)
        {
            KeHoachID = int.Parse(dr["KeHoachID"].ToString());
            TenDuAn = dr["TenDuAn"].ToString();
            Lydo = dr["LyDo"].ToString();
            MotaQuaTrinh = dr["MoTaQuaTrinh"].ToString();
            try
            {
                DiSan = Sys_Common.NV_DiSanVanHoa.GetById(int.Parse(dr["DiSanID"].ToString()));
            }
            catch { }
            DiaDiem = dr["DiaDiem"].ToString();
            ThuocTinh = dr["ThuocTinh"].ToString();
            ThuocHuyen = dr["ThuocHuyen"].ToString();
            ThuocXa = dr["ThuocXa"].ToString();
            try
            {
                DuKienBatDau = Convert.ToDateTime(dr["DuKienBatDau"].ToString());
            }
            catch { }
            try
            {
                DukienHoanThanh = Convert.ToDateTime(dr["DuKienHoanThanh"].ToString());
            }
            catch { }
            try
            {
                ThucTeBatDau = Convert.ToDateTime(dr["ThucTeBatDau"].ToString());
            }
            catch { }
            try
            {
                ThucTeHoanThanh = Convert.ToDateTime(dr["ThucTeHoanThanh"].ToString());
            }
            catch { }
            NoiDung = dr["NoiDung"].ToString();
            try
            {
                DonViThietKe = Sys_Common.NV_DonViTuBo.GetById(int.Parse(dr["DonViThietKe"].ToString()));
            }
            catch { }
            try
            {
                DonViThiCong = Sys_Common.NV_DonViTuBo.GetById(int.Parse(dr["DonViThiCong"].ToString()));
            }
            catch { }
            try
            {
                DonViGiamSat = Sys_Common.NV_DonViTuBo.GetById(int.Parse(dr["DonViGiamSat"].ToString()));
            }
            catch { }
            try
            {
                ChuDauTu = Sys_Common.NV_DonViTuBo.GetById(int.Parse(dr["ChuDauTu"].ToString()));
            }
            catch { }
            try
            {
                CapQD = Sys_Common.NV_DonViTuBo.GetById(int.Parse(dr["CapQD"].ToString()));
            }
            catch { }
            TrangThai = bool.Parse(dr["TrangThai"].ToString());
            try
            {
                ChiPhiThucTe = Convert.ToDecimal(dr["ChiPhiThucTe"].ToString());
            }
            catch { }
            try
            {
                ChiPhiDuKien = Convert.ToDecimal(dr["ChiPhiDuKien"].ToString());
            }
            catch { }
            File = dr["File"].ToString();
        }
        public NV_KeHoachTuBo_ChiTiet() {
            ChuDauTu = new NV_DonViTuBo_ChiTiet();
            CapQD = new NV_DonViTuBo_ChiTiet();
            DonViGiamSat = new NV_DonViTuBo_ChiTiet();
            DonViThiCong = new NV_DonViTuBo_ChiTiet();
            DonViThietKe = new NV_DonViTuBo_ChiTiet();
        }
    }
    public class NV_KeHoachTuBo
    {
        private string ConnectionString;
        public NV_KeHoachTuBo(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }

        #region Lấy theo ID
        public NV_KeHoachTuBo_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_KeHoachTuBo_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@id", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    DataTable dt;
                    NV_KeHoachTuBo_ChiTiet model = new NV_KeHoachTuBo_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_KeHoachTuBo_ChiTiet(dt.Rows[0]);
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
                using (SqlCommand myCommand = new SqlCommand("NV_KeHoachTuBo_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_KeHoachTuBo_getAll");
                    return myDataSet.Tables["NV_KeHoachTuBo_getAll"];

                }
            }
        }

        #endregion
        #region Thêm

        public bool them(NV_KeHoachTuBo_ChiTiet model, out int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_KeHoachTuBo_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@KeHoachID", SqlDbType.Int);
                    pID.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pTenDuAn = new SqlParameter("@TenDuAn", SqlDbType.NVarChar, 200);
                    pTenDuAn.Value = model.TenDuAn;
                    myCommand.Parameters.Add(pTenDuAn);

                    SqlParameter pDiaDiem = new SqlParameter("@DiaDiem", SqlDbType.NVarChar, 250);
                    pDiaDiem.Value = model.DiaDiem;
                    myCommand.Parameters.Add(pDiaDiem);

                    SqlParameter pDonViGiamSat = new SqlParameter("@DonViGiamSat", SqlDbType.Int);
                    pDonViGiamSat.Value = model.DonViGiamSat.DonViID;
                    myCommand.Parameters.Add(pDonViGiamSat);

                    SqlParameter pDonViThiCong = new SqlParameter("@DonViThiCong", SqlDbType.Int);
                    pDonViThiCong.Value = model.DonViThiCong.DonViID;
                    myCommand.Parameters.Add(pDonViThiCong);

                    SqlParameter pDonViThietKe = new SqlParameter("@DonViThietKe", SqlDbType.Int);
                    pDonViThietKe.Value = model.DonViThietKe.DonViID;
                    myCommand.Parameters.Add(pDonViThietKe);

                    SqlParameter pChuDauTu = new SqlParameter("@ChuDauTu", SqlDbType.Int);
                    pChuDauTu.Value = model.ChuDauTu.DonViID;
                    myCommand.Parameters.Add(pChuDauTu);

                    SqlParameter pCapQD = new SqlParameter("@CapQD", SqlDbType.Int);
                    pCapQD.Value = model.CapQD.DonViID;
                    myCommand.Parameters.Add(pCapQD);

                    SqlParameter pLyDo = new SqlParameter("@LyDo", SqlDbType.NVarChar, 250);
                    pLyDo.Value = model.Lydo;
                    myCommand.Parameters.Add(pLyDo);

                    SqlParameter pMotaQuaTrinh = new SqlParameter("@MotaQuaTrinh", SqlDbType.NText);
                    pMotaQuaTrinh.Value = model.MotaQuaTrinh;
                    myCommand.Parameters.Add(pMotaQuaTrinh);

                    SqlParameter pDiSanID = new SqlParameter("@DiSanID", SqlDbType.Int);
                    pDiSanID.Value = model.DiSan.DiSanID;
                    myCommand.Parameters.Add(pDiSanID);

                    SqlParameter pNoiDung = new SqlParameter("@NoiDung", SqlDbType.NText);
                    pNoiDung.Value = model.NoiDung;
                    myCommand.Parameters.Add(pNoiDung);

                    SqlParameter pThuocTinh = new SqlParameter("@ThuocTinh", SqlDbType.VarChar, 10);
                    pThuocTinh.Value = model.ThuocTinh;
                    myCommand.Parameters.Add(pThuocTinh);

                    SqlParameter pThuocHuyen = new SqlParameter("@ThuocHuyen", SqlDbType.VarChar, 10);
                    pThuocHuyen.Value = model.ThuocHuyen;
                    myCommand.Parameters.Add(pThuocHuyen);

                    SqlParameter pThuocXa = new SqlParameter("@ThuocXa", SqlDbType.VarChar, 10);
                    pThuocXa.Value = model.ThuocTinh;
                    myCommand.Parameters.Add(pThuocXa);

                    SqlParameter pDuKienBatDau = new SqlParameter("@DuKienBatDau", SqlDbType.DateTime);
                    pDuKienBatDau.Value = model.DuKienBatDau;
                    myCommand.Parameters.Add(pDuKienBatDau);

                    SqlParameter pDuKienHoanThanh = new SqlParameter("@DuKienHoanThanh", SqlDbType.DateTime);
                    pDuKienHoanThanh.Value = model.DukienHoanThanh;
                    myCommand.Parameters.Add(pDuKienHoanThanh);

                    SqlParameter pTrangThai = new SqlParameter("@TrangThai", SqlDbType.Bit);
                    pTrangThai.Value = model.TrangThai;
                    myCommand.Parameters.Add(pTrangThai);

                    SqlParameter pThucTeBatDau = new SqlParameter("@ThucTeBatDau", SqlDbType.DateTime);
                    pThucTeBatDau.Value = model.ThucTeBatDau;
                    myCommand.Parameters.Add(pThucTeBatDau);

                    SqlParameter pThucTeHoanThanh = new SqlParameter("@ThucTeHoanThanh", SqlDbType.DateTime);
                    pThucTeHoanThanh.Value = model.ThucTeHoanThanh;
                    myCommand.Parameters.Add(pThucTeHoanThanh);

                    SqlParameter pChiPhiDuKien = new SqlParameter("@ChiPhiDuKien", SqlDbType.Decimal);
                    pChiPhiDuKien.Value = model.ChiPhiDuKien;
                    myCommand.Parameters.Add(pChiPhiDuKien);

                    SqlParameter pChiPhiThucTe = new SqlParameter("@ChiPhiThucTe", SqlDbType.Decimal);
                    pChiPhiThucTe.Value = model.ChiPhiThucTe;
                    myCommand.Parameters.Add(pChiPhiThucTe);

                    SqlParameter pFile = new SqlParameter("@File", SqlDbType.NVarChar, 500);
                    pFile.Value = model.File;
                    myCommand.Parameters.Add(pFile);
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
        public bool update(NV_KeHoachTuBo_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_KeHoachTuBo_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@KeHoachID", SqlDbType.Int);
                    pID.Value = model.KeHoachID;
                    myCommand.Parameters.Add(pID);


                    SqlParameter pTenDuAn = new SqlParameter("@TenDuAn", SqlDbType.NVarChar, 200);
                    pTenDuAn.Value = model.TenDuAn;
                    myCommand.Parameters.Add(pTenDuAn);

                    SqlParameter pDiaDiem = new SqlParameter("@DiaDiem", SqlDbType.NVarChar, 250);
                    pDiaDiem.Value = model.DiaDiem;
                    myCommand.Parameters.Add(pDiaDiem);


                    SqlParameter pDonViGiamSat = new SqlParameter("@DonViGiamSat", SqlDbType.Int);
                    pDonViGiamSat.Value = model.DonViGiamSat.DonViID;
                    myCommand.Parameters.Add(pDonViGiamSat);

                    SqlParameter pDonViThiCong = new SqlParameter("@DonViThiCong", SqlDbType.Int);
                    pDonViThiCong.Value = model.DonViThiCong.DonViID;
                    myCommand.Parameters.Add(pDonViThiCong);

                    SqlParameter pDonViThietKe = new SqlParameter("@DonViThietKe", SqlDbType.Int);
                    pDonViThietKe.Value = model.DonViThietKe.DonViID;
                    myCommand.Parameters.Add(pDonViThietKe);

                    SqlParameter pChuDauTu = new SqlParameter("@ChuDauTu", SqlDbType.Int);
                    pChuDauTu.Value = model.ChuDauTu.DonViID;
                    myCommand.Parameters.Add(pChuDauTu);

                    SqlParameter pCapQD = new SqlParameter("@CapQD", SqlDbType.Int);
                    pCapQD.Value = model.CapQD.DonViID;
                    myCommand.Parameters.Add(pCapQD);

                    SqlParameter pLyDo = new SqlParameter("@LyDo", SqlDbType.NVarChar, 250);
                    pLyDo.Value = model.Lydo;
                    myCommand.Parameters.Add(pLyDo);

                    SqlParameter pMotaQuaTrinh = new SqlParameter("@MotaQuaTrinh", SqlDbType.NText);
                    pMotaQuaTrinh.Value = model.MotaQuaTrinh;
                    myCommand.Parameters.Add(pMotaQuaTrinh);

                    SqlParameter pDiSanID = new SqlParameter("@DiSanID", SqlDbType.Int);
                    pDiSanID.Value = model.DiSan.DiSanID;
                    myCommand.Parameters.Add(pDiSanID);

                    SqlParameter pNoiDung = new SqlParameter("@NoiDung", SqlDbType.NText);
                    pNoiDung.Value = model.NoiDung;
                    myCommand.Parameters.Add(pNoiDung);

                    SqlParameter pThuocTinh = new SqlParameter("@ThuocTinh", SqlDbType.VarChar, 10);
                    pThuocTinh.Value = model.ThuocTinh;
                    myCommand.Parameters.Add(pThuocTinh);

                    SqlParameter pThuocHuyen = new SqlParameter("@ThuocHuyen", SqlDbType.VarChar, 10);
                    pThuocHuyen.Value = model.ThuocHuyen;
                    myCommand.Parameters.Add(pThuocHuyen);

                    SqlParameter pThuocXa = new SqlParameter("@ThuocXa", SqlDbType.VarChar, 10);
                    pThuocXa.Value = model.ThuocXa;
                    myCommand.Parameters.Add(pThuocXa);

                    SqlParameter pDuKienBatDau = new SqlParameter("@DuKienBatDau", SqlDbType.DateTime);
                    pDuKienBatDau.Value = model.DuKienBatDau;
                    myCommand.Parameters.Add(pDuKienBatDau);

                    SqlParameter pDuKienHoanThanh = new SqlParameter("@DuKienHoanThanh", SqlDbType.DateTime);
                    pDuKienHoanThanh.Value = model.DukienHoanThanh;
                    myCommand.Parameters.Add(pDuKienHoanThanh);

                    SqlParameter pTrangThai = new SqlParameter("@TrangThai", SqlDbType.Bit);
                    pTrangThai.Value = model.TrangThai;
                    myCommand.Parameters.Add(pTrangThai);

                    SqlParameter pThucTeBatDau = new SqlParameter("@ThucTeBatDau", SqlDbType.DateTime);
                    pThucTeBatDau.Value = model.ThucTeBatDau;
                    myCommand.Parameters.Add(pThucTeBatDau);

                    SqlParameter pThucTeHoanThanh = new SqlParameter("@ThucTeHoanThanh", SqlDbType.DateTime);
                    pThucTeHoanThanh.Value = model.ThucTeHoanThanh;
                    myCommand.Parameters.Add(pThucTeHoanThanh);

                    SqlParameter pChiPhiDuKien = new SqlParameter("@ChiPhiDuKien", SqlDbType.Decimal);
                    pChiPhiDuKien.Value = model.ChiPhiDuKien;
                    myCommand.Parameters.Add(pChiPhiDuKien);

                    SqlParameter pChiPhiThucTe = new SqlParameter("@ChiPhiThucTe", SqlDbType.Decimal);
                    pChiPhiThucTe.Value = model.ChiPhiThucTe;
                    myCommand.Parameters.Add(pChiPhiThucTe);

                    SqlParameter pFile = new SqlParameter("@File", SqlDbType.NVarChar, 500);
                    pFile.Value = model.File;
                    myCommand.Parameters.Add(pFile);
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
                using (SqlCommand myCommand = new SqlCommand("NV_KeHoachTuBo_del", myConnection))
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
