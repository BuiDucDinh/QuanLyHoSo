using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_VanBan_ChiTiet
    {
        public int VanBanID { get; set; }
        public string TenVanBan { get; set; }
        public int LoaiVanBan { get; set; }
        public string DonViBanHanh { get; set; }
        public DateTime NgayBanHanh { get; set; }
        public string MoTa { get; set; }
        public string NoiDung { get; set; }
        public bool Duyet { get; set; }
        public bool TonTai { get; set; }
        public string File { get; set; }
        public int NguoiTao { get; set; }
        public DateTime NgayTao { get; set; }
        public NV_VanBan_ChiTiet() { }
        public NV_VanBan_ChiTiet(DataRow dr)
        {
            VanBanID = int.Parse(dr["VanBanID"].ToString());
            TenVanBan = dr["TenVanBan"].ToString();
            LoaiVanBan = int.Parse(dr["LoaiVanBan"].ToString());
            DonViBanHanh = dr["DonViBanHanh"].ToString();
            NgayBanHanh = Convert.ToDateTime(dr["NgayBanHanh"].ToString());
            MoTa = dr["MoTa"].ToString();
            NoiDung = dr["NoiDung"].ToString();
            File = dr["File"].ToString();
            Duyet = Convert.ToBoolean(dr["Duyet"].ToString());
            TonTai = Convert.ToBoolean(dr["TonTai"].ToString());
            NguoiTao = int.Parse(dr["NguoiTao"].ToString());
            NgayTao = Convert.ToDateTime(dr["NgayTao"].ToString());
        }
    }
    public class NV_VanBan
    {
        private string ConnectionString;
        public NV_VanBan(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lấy theo ID
        public NV_VanBan_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_VanBan_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@id", SqlDbType.VarChar, 10);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    DataTable dt;
                    NV_VanBan_ChiTiet model = new NV_VanBan_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_VanBan_ChiTiet(dt.Rows[0]);
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
                using (SqlCommand myCommand = new SqlCommand("NV_VanBan_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_VanBan_getAll");
                    return myDataSet.Tables["NV_VanBan_getAll"];

                }
            }
        }

        #endregion
        #region Thêm
        public bool them(NV_VanBan_ChiTiet model, out int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_VanBan_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pVanBanID = new SqlParameter("@VanBanID", SqlDbType.Int);
                    pVanBanID.Value = ParameterDirection.Output;
                    myCommand.Parameters.Add(pVanBanID);
                    SqlParameter pTenVanBan = new SqlParameter("@TenVanBan", SqlDbType.NVarChar, 250);
                    pTenVanBan.Value = model.TenVanBan;
                    myCommand.Parameters.Add(pTenVanBan);

                    SqlParameter pLoaiVanBan = new SqlParameter("@LoaiVanBan", SqlDbType.Int);
                    pLoaiVanBan.Value = model.LoaiVanBan;
                    myCommand.Parameters.Add(pLoaiVanBan);

                    SqlParameter pDonViBanHanh = new SqlParameter("@DonViBanHanh", SqlDbType.NVarChar, 200);
                    pDonViBanHanh.Value = model.DonViBanHanh;
                    myCommand.Parameters.Add(pDonViBanHanh);

                    SqlParameter pNguoiTao = new SqlParameter("@NguoiTao", SqlDbType.Int);
                    pNguoiTao.Value = model.NguoiTao;
                    myCommand.Parameters.Add(pNguoiTao);

                    SqlParameter pNgayBanHanh = new SqlParameter("@NgayBanHanh", SqlDbType.DateTime);
                    pNgayBanHanh.Value = model.NgayBanHanh;
                    myCommand.Parameters.Add(pNgayBanHanh);

                    SqlParameter pMoTa = new SqlParameter("@MoTa", SqlDbType.NText);
                    pMoTa.Value = model.MoTa;
                    myCommand.Parameters.Add(pMoTa);

                    SqlParameter pNoiDung = new SqlParameter("@NoiDung", SqlDbType.NText);
                    pNoiDung.Value = model.NoiDung;
                    myCommand.Parameters.Add(pNoiDung);

                    SqlParameter pFile = new SqlParameter("@File", SqlDbType.NVarChar, 500);
                    pFile.Value = model.File;
                    myCommand.Parameters.Add(pFile);

                    SqlParameter pDuyet = new SqlParameter("@Duyet", SqlDbType.Bit);
                    pDuyet.Value = model.Duyet;
                    myCommand.Parameters.Add(pDuyet);

                    SqlParameter pTonTai = new SqlParameter("@TonTai", SqlDbType.Bit);
                    pTonTai.Value = model.TonTai;
                    myCommand.Parameters.Add(pTonTai);
                    id = 0;
                    try
                    {
                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                        id = (int)pVanBanID.Value;
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
        public bool update(NV_VanBan_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_VanBan_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@VanBanID", SqlDbType.Int);
                    pID.Value = model.VanBanID;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pTenVanBan = new SqlParameter("@TenVanBan", SqlDbType.NVarChar, 250);
                    pTenVanBan.Value = model.TenVanBan;
                    myCommand.Parameters.Add(pTenVanBan);

                    SqlParameter pLoaiVanBan = new SqlParameter("@LoaiVanBan", SqlDbType.Int);
                    pLoaiVanBan.Value = model.LoaiVanBan;
                    myCommand.Parameters.Add(pLoaiVanBan);

                    SqlParameter pDonViBanHanh = new SqlParameter("@DonViBanHanh", SqlDbType.NVarChar, 200);
                    pDonViBanHanh.Value = model.DonViBanHanh;
                    myCommand.Parameters.Add(pDonViBanHanh);

                    SqlParameter pNgayBanHanh = new SqlParameter("@NgayBanHanh", SqlDbType.DateTime);
                    pNgayBanHanh.Value = model.NgayBanHanh;
                    myCommand.Parameters.Add(pNgayBanHanh);

                    SqlParameter pMoTa = new SqlParameter("@MoTa", SqlDbType.NText);
                    pMoTa.Value = model.MoTa;
                    myCommand.Parameters.Add(pMoTa);

                    SqlParameter pNoiDung = new SqlParameter("@NoiDung", SqlDbType.NText);
                    pNoiDung.Value = model.NoiDung;
                    myCommand.Parameters.Add(pNoiDung);

                    SqlParameter pFile = new SqlParameter("@File", SqlDbType.NVarChar, 500);
                    pFile.Value = model.File;
                    myCommand.Parameters.Add(pFile);

                    SqlParameter pDuyet = new SqlParameter("@Duyet", SqlDbType.Bit);
                    pDuyet.Value = model.Duyet;
                    myCommand.Parameters.Add(pDuyet);

                    SqlParameter pTonTai = new SqlParameter("@TonTai", SqlDbType.Bit);
                    pTonTai.Value = model.TonTai;
                    myCommand.Parameters.Add(pTonTai);
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
                using (SqlCommand myCommand = new SqlCommand("NV_VanBan_del", myConnection))
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
