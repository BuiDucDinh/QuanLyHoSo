using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_PhanBoKinhPhi_ChiTiet
    {
        public int ID { get; set; }
        public string TenDuAn { get; set; }
        public int NguonID { get; set; }
        public int DiSanID { get; set; }
        public DateTime? NgayThucHien { get; set; }
        public decimal SoTien { get; set; }
        public string LyDo { get; set; }
        public string NoiDung { get; set; }
        public string TaiLieu { get; set; }

        public NV_PhanBoKinhPhi_ChiTiet() { }

        public NV_PhanBoKinhPhi_ChiTiet(DataRow dr)
        {
            ID = int.Parse(dr["ID"].ToString());
            TenDuAn = dr["TenDuAn"].ToString();
            SoTien = decimal.Parse(dr["SoTien"].ToString());
            NguonID = int.Parse(dr["NguonID"].ToString());
            try
            {
                NgayThucHien = Convert.ToDateTime(dr["NgayDauTu"].ToString());
            }
            catch { }
            DiSanID = int.Parse(dr["DiSanID"].ToString());
            LyDo = dr["LyDo"].ToString();
            NoiDung = dr["NoiDung"].ToString();
            TaiLieu = dr["TaiLieu"].ToString();
        }
    }
    public class NV_PhanBoKinhPhi
    {
        private string ConnectionString;
        public NV_PhanBoKinhPhi(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lấy theo ID
        public NV_PhanBoKinhPhi_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_PhanBoKinhPhi_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.VarChar, 10);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    DataTable dt;
                    NV_PhanBoKinhPhi_ChiTiet model = new NV_PhanBoKinhPhi_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_PhanBoKinhPhi_ChiTiet(dt.Rows[0]);
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
                using (SqlCommand myCommand = new SqlCommand("NV_PhanBoKinhPhi_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_PhanBoKinhPhi_getAll");
                    return myDataSet.Tables["NV_PhanBoKinhPhi_getAll"];

                }
            }
        }

        #endregion
        #region Lấy theo nguồn kinh phí
        public DataTable GetByNguon(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_PhanBoKinhPhi_getByNguon", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pID = new SqlParameter("@IDNguon", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_PhanBoKinhPhi_getByNguon");
                    return myDataSet.Tables["NV_PhanBoKinhPhi_getByNguon"];

                }
            }
        }

        #endregion
        #region Thêm
        public bool them(NV_PhanBoKinhPhi_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_PhanBoKinhPhi_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pTenDuAn = new SqlParameter("@TenDuAn", SqlDbType.NVarChar, 200);
                    pTenDuAn.Value = model.TenDuAn;
                    myCommand.Parameters.Add(pTenDuAn);

                    SqlParameter pNguonID = new SqlParameter("@NguonID", SqlDbType.Int);
                    pNguonID.Value = model.NguonID;
                    myCommand.Parameters.Add(pNguonID);

                    SqlParameter pDiSanID = new SqlParameter("@DiSanID", SqlDbType.Int);
                    pDiSanID.Value = model.DiSanID;
                    myCommand.Parameters.Add(pDiSanID);

                    SqlParameter pSoTien = new SqlParameter("@SoTien", SqlDbType.Decimal, 18);
                    pSoTien.Value = model.SoTien;
                    myCommand.Parameters.Add(pSoTien);

                    SqlParameter pNgayThucHien = new SqlParameter("@NgayThucHien", SqlDbType.DateTime);
                    pNgayThucHien.Value = model.NgayThucHien;
                    myCommand.Parameters.Add(pNgayThucHien);

                    SqlParameter pLyDo = new SqlParameter("@LyDo", SqlDbType.NVarChar, 500);
                    pLyDo.Value = model.LyDo;
                    myCommand.Parameters.Add(pLyDo);

                    SqlParameter pNoiDung = new SqlParameter("@NoiDung", SqlDbType.NText);
                    pNoiDung.Value = model.NoiDung;
                    myCommand.Parameters.Add(pNoiDung);

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
        #region update
        public bool update(NV_PhanBoKinhPhi_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_PhanBoKinhPhi_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = model.ID;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pTenDuAn = new SqlParameter("@TenDuAn", SqlDbType.NVarChar, 200);
                    pTenDuAn.Value = model.TenDuAn;
                    myCommand.Parameters.Add(pTenDuAn);

                    SqlParameter pNguonID = new SqlParameter("@NguonID", SqlDbType.Int);
                    pNguonID.Value = model.NguonID;
                    myCommand.Parameters.Add(pNguonID);

                    SqlParameter pDiSanID = new SqlParameter("@DiSanID", SqlDbType.Int);
                    pDiSanID.Value = model.DiSanID;
                    myCommand.Parameters.Add(pDiSanID);

                    SqlParameter pSoTien = new SqlParameter("@SoTien", SqlDbType.Decimal, 18);
                    pSoTien.Value = model.SoTien;
                    myCommand.Parameters.Add(pSoTien);

                    SqlParameter pNgayThucHien = new SqlParameter("@NgayThucHien", SqlDbType.DateTime);
                    pNgayThucHien.Value = model.NgayThucHien;
                    myCommand.Parameters.Add(pNgayThucHien);

                    SqlParameter pLyDo = new SqlParameter("@LyDo", SqlDbType.NVarChar, 500);
                    pLyDo.Value = model.LyDo;
                    myCommand.Parameters.Add(pLyDo);

                    SqlParameter pNoiDung = new SqlParameter("@NoiDung", SqlDbType.NText);
                    pNoiDung.Value = model.NoiDung;
                    myCommand.Parameters.Add(pNoiDung);

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
                using (SqlCommand myCommand = new SqlCommand("NV_PhanBoKinhPhi_del", myConnection))
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
