using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_NguonKinhPhi_ChiTiet
    {
        public int ID { get; set; }
        public int NguoiDauTuID { get; set; }
        public string NguoiDauTu { get; set; }
        public decimal SoTien { get; set; }
        public int NguonKinhPhiID { get; set; }
        public string NguonKinhPhi { get; set; }
        public DateTime? NgayDauTu { get; set; }
        public decimal TienConLai { get; set; }
        public string MoTa { get; set; }
        public string TaiLieu { get; set; }
        public NV_NguonKinhPhi_ChiTiet() { }

        public NV_NguonKinhPhi_ChiTiet(DataRow dr)
        {
            ID = int.Parse(dr["ID"].ToString());
            NguoiDauTu = dr["NguoiDauTu"].ToString();
            NguoiDauTuID = int.Parse(dr["NguoiDauTuID"].ToString());
            SoTien = decimal.Parse(dr["SoTien"].ToString());
            NguonKinhPhiID = int.Parse(dr["NguonKinhPhiID"].ToString());
            NguonKinhPhi = dr["NguonKinhPhi"].ToString();
            try
            {
                NgayDauTu = Convert.ToDateTime(dr["NgayDauTu"].ToString());
            }
            catch { }
            TienConLai = decimal.Parse(dr["TienConLai"].ToString());
            MoTa = dr["MoTa"].ToString();
            TaiLieu = dr["TaiLieu"].ToString();
        }
    }
    public class NV_NguonKinhPhi
    {
        private string ConnectionString;
        public NV_NguonKinhPhi(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lấy theo ID
        public NV_NguonKinhPhi_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_NguonKinhPhi_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.VarChar, 10);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    DataTable dt;
                    NV_NguonKinhPhi_ChiTiet model = new NV_NguonKinhPhi_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_NguonKinhPhi_ChiTiet(dt.Rows[0]);
                    }
                    return model;
                }
            }
        }
        #endregion

        #region Lấy theo nhà đầu tư
        public DataTable GetByNhaDauTu(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_NguonKinhPhi_getByNhaDauTu", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@NguoiDauTuID", SqlDbType.VarChar, 10);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_NguonKinhPhi_getAll");
                    return myDataSet.Tables["NV_NguonKinhPhi_getAll"];

                }
            }
        }

        #endregion
        #region Lấy tất cả
        public DataTable GetAll()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_NguonKinhPhi_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_NguonKinhPhi_getAll");
                    return myDataSet.Tables["NV_NguonKinhPhi_getAll"];

                }
            }
        }

        #endregion

        #region Thêm
        public bool them(NV_NguonKinhPhi_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_NguonKinhPhi_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pNguoiDauTu = new SqlParameter("@NguoiDauTuID", SqlDbType.Int);
                    pNguoiDauTu.Value = model.NguoiDauTuID;
                    myCommand.Parameters.Add(pNguoiDauTu);

                    SqlParameter pNguonKinhPhi = new SqlParameter("@NguonKinhPhiID", SqlDbType.Int);
                    pNguonKinhPhi.Value = model.NguonKinhPhiID;
                    myCommand.Parameters.Add(pNguonKinhPhi);

                    SqlParameter pSoTien = new SqlParameter("@SoTien", SqlDbType.Decimal, 18);
                    pSoTien.Value = model.SoTien;
                    myCommand.Parameters.Add(pSoTien);

                    SqlParameter pNgayDauTu = new SqlParameter("@NgayDauTu", SqlDbType.DateTime);
                    pNgayDauTu.Value = model.NgayDauTu;
                    myCommand.Parameters.Add(pNgayDauTu);

                    SqlParameter pTienConLai = new SqlParameter("@TienConLai", SqlDbType.Decimal);
                    pTienConLai.Value = model.TienConLai;
                    myCommand.Parameters.Add(pTienConLai);

                    SqlParameter pMoTa = new SqlParameter("@MoTa", SqlDbType.NVarChar, 500);
                    pMoTa.Value = model.MoTa;
                    myCommand.Parameters.Add(pMoTa);

                    SqlParameter pTaiLieu = new SqlParameter("@TaiLieu", SqlDbType.NVarChar, 50);
                    pTaiLieu.Value = model.TaiLieu;
                    myCommand.Parameters.Add(pTaiLieu);

                    try
                    {
                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
        }
        #endregion
        #region update
        public bool update(NV_NguonKinhPhi_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_NguonKinhPhi_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = model.ID;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pNguoiDauTu = new SqlParameter("@NguoiDauTuID", SqlDbType.Int);
                    pNguoiDauTu.Value = model.NguoiDauTuID;
                    myCommand.Parameters.Add(pNguoiDauTu);

                    SqlParameter pNguonKinhPhi = new SqlParameter("@NguonKinhPhiID", SqlDbType.Int);
                    pNguonKinhPhi.Value = model.NguonKinhPhiID;
                    myCommand.Parameters.Add(pNguonKinhPhi);

                    SqlParameter pSoTien = new SqlParameter("@SoTien", SqlDbType.Decimal, 18);
                    pSoTien.Value = model.SoTien;
                    myCommand.Parameters.Add(pSoTien);

                    SqlParameter pNgayDauTu = new SqlParameter("@NgayDauTu", SqlDbType.DateTime);
                    pNgayDauTu.Value = model.NgayDauTu;
                    myCommand.Parameters.Add(pNgayDauTu);

                    SqlParameter pTienConLai = new SqlParameter("@TienConLai", SqlDbType.Decimal);
                    pTienConLai.Value = model.TienConLai;
                    myCommand.Parameters.Add(pTienConLai);

                    SqlParameter pMoTa = new SqlParameter("@MoTa", SqlDbType.NVarChar, 500);
                    pMoTa.Value = model.MoTa;
                    myCommand.Parameters.Add(pMoTa);

                    SqlParameter pTaiLieu = new SqlParameter("@TaiLieu", SqlDbType.NVarChar, 50);
                    pTaiLieu.Value = model.TaiLieu;
                    myCommand.Parameters.Add(pTaiLieu);

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
                using (SqlCommand myCommand = new SqlCommand("NV_NguonKinhPhi_del", myConnection))
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
