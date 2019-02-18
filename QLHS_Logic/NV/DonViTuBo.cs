using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_DonViTuBo_ChiTiet
    {
        public int DonViID { get; set; }
        public string TenDonVi { get; set; }
        public string NguoiDaiDien { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public int CapDonVi { get; set; }
        public string ChungChihanhNghe { get; set; }
        public string GhiChu { get; set; }
        public string File { get; set; }
        public string ChucNang { get; set; }
        public string ChucNangDs { get; set; }
        public NV_DonViTuBo_ChiTiet() { }
        public NV_DonViTuBo_ChiTiet(DataRow dr)
        {
            DonViID = int.Parse(dr["DonViID"].ToString());
            TenDonVi = dr["TenDonVi"].ToString();
            NguoiDaiDien = dr["NguoiDaiDien"].ToString();
            DiaChi = dr["DiaChi"].ToString();
            SoDienThoai = dr["SoDienThoai"].ToString();
            ChucNang = dr["ChucNang"].ToString();
            ChucNangDs = dr["ChucNangDs"].ToString();
            try
            {
                CapDonVi = int.Parse(dr["CapDonVi"].ToString());
            }
            catch { }
            ChungChihanhNghe = dr["ChungChiHanhNghe"].ToString();
            File = dr["File"].ToString();
        }
    }
    public class NV_DonViTuBo
    {
        private string ConnectionString;
        public NV_DonViTuBo(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lấy theo ID
        public NV_DonViTuBo_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DonViTuBo_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@id", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    DataTable dt;
                    NV_DonViTuBo_ChiTiet model = new NV_DonViTuBo_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_DonViTuBo_ChiTiet(dt.Rows[0]);
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
                using (SqlCommand myCommand = new SqlCommand("NV_DonViTuBo_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_DonViTuBo_getAll");
                    return myDataSet.Tables["NV_DonViTuBo_getAll"];

                }
            }
        }

        #endregion
        #region Lấy theo chức năng
        public DataTable GetByChucNang(int idChucnang)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DonViTuBo_getByChucNang", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pID = new SqlParameter("@IDChucNang", SqlDbType.Int);
                    pID.Value = idChucnang;
                    myCommand.Parameters.Add(pID);
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_DonViTuBo_getByChucNang");
                    return myDataSet.Tables["NV_DonViTuBo_getByChucNang"];

                }
            }
        }

        #endregion
        #region Thêm
        public bool them(NV_DonViTuBo_ChiTiet model, out int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DonViTuBo_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pDonViID = new SqlParameter("@DonViID", SqlDbType.Int);
                    pDonViID.Value = ParameterDirection.Output;
                    myCommand.Parameters.Add(pDonViID);

                    SqlParameter pTenDonVi = new SqlParameter("@TenDonVi", SqlDbType.NVarChar, 50);
                    pTenDonVi.Value = model.TenDonVi;
                    myCommand.Parameters.Add(pTenDonVi);

                    SqlParameter pNguoiDaiDien = new SqlParameter("@NguoiDaiDien", SqlDbType.NVarChar, 50);
                    pNguoiDaiDien.Value = model.NguoiDaiDien;
                    myCommand.Parameters.Add(pNguoiDaiDien);

                    SqlParameter pDiaChi = new SqlParameter("@DiaChi", SqlDbType.NVarChar, 500);
                    pDiaChi.Value = model.DiaChi;
                    myCommand.Parameters.Add(pDiaChi);

                    SqlParameter pSoDienThoai = new SqlParameter("@SoDienThoai", SqlDbType.NVarChar, 50);
                    pSoDienThoai.Value = model.SoDienThoai;
                    myCommand.Parameters.Add(pSoDienThoai);

                    SqlParameter pCapDonVi = new SqlParameter("@CapDonVi", SqlDbType.Int);
                    pCapDonVi.Value = model.CapDonVi;
                    myCommand.Parameters.Add(pCapDonVi);

                    SqlParameter pChungChiHanhNghe = new SqlParameter("@ChungChiHanhNghe", SqlDbType.NVarChar, 100);
                    pChungChiHanhNghe.Value = model.ChungChihanhNghe;
                    myCommand.Parameters.Add(pChungChiHanhNghe);

                    SqlParameter pGhiChu = new SqlParameter("@GhiChu", SqlDbType.NVarChar, 4000);
                    pGhiChu.Value = model.GhiChu;
                    myCommand.Parameters.Add(pGhiChu);

                    SqlParameter pFile = new SqlParameter("@File", SqlDbType.NVarChar, 200);
                    pFile.Value = model.File;
                    myCommand.Parameters.Add(pFile);

                    SqlParameter pChucNang = new SqlParameter("@ChucNang", SqlDbType.NVarChar, 20);
                    pChucNang.Value = model.ChucNang;
                    myCommand.Parameters.Add(pChucNang);
                    id = 0;
                    try
                    {
                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                        id = (int)pDonViID.Value;
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
        public bool update(NV_DonViTuBo_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DonViTuBo_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@DonViID", SqlDbType.Int);
                    pID.Value = model.DonViID;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pTenDonVi = new SqlParameter("@TenDonVi", SqlDbType.NVarChar, 50);
                    pTenDonVi.Value = model.TenDonVi;
                    myCommand.Parameters.Add(pTenDonVi);

                    SqlParameter pNguoiDaiDien = new SqlParameter("@NguoiDaiDien", SqlDbType.NVarChar, 50);
                    pNguoiDaiDien.Value = model.NguoiDaiDien;
                    myCommand.Parameters.Add(pNguoiDaiDien);

                    SqlParameter pDiaChi = new SqlParameter("@DiaChi", SqlDbType.NVarChar, 500);
                    pDiaChi.Value = model.DiaChi;
                    myCommand.Parameters.Add(pDiaChi);

                    SqlParameter pSoDienThoai = new SqlParameter("@SoDienThoai", SqlDbType.NVarChar, 50);
                    pSoDienThoai.Value = model.SoDienThoai;
                    myCommand.Parameters.Add(pSoDienThoai);

                    SqlParameter pCapDonVi = new SqlParameter("@CapDonVi", SqlDbType.Int);
                    pCapDonVi.Value = model.CapDonVi;
                    myCommand.Parameters.Add(pCapDonVi);

                    SqlParameter pChungChiHanhNghe = new SqlParameter("@ChungChiHanhNghe", SqlDbType.NVarChar, 100);
                    pChungChiHanhNghe.Value = model.ChungChihanhNghe;
                    myCommand.Parameters.Add(pChungChiHanhNghe);

                    SqlParameter pGhiChu = new SqlParameter("@GhiChu", SqlDbType.NVarChar, 4000);
                    pGhiChu.Value = model.GhiChu;
                    myCommand.Parameters.Add(pGhiChu);


                    SqlParameter pFile = new SqlParameter("@File", SqlDbType.NVarChar, 200);
                    pFile.Value = model.File;
                    myCommand.Parameters.Add(pFile);

                    SqlParameter pChucNang = new SqlParameter("@ChucNang", SqlDbType.NVarChar, 20);
                    pChucNang.Value = model.ChucNang;
                    myCommand.Parameters.Add(pChucNang);
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
                using (SqlCommand myCommand = new SqlCommand("NV_DonViTuBo_del", myConnection))
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
