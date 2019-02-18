using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_DangKyDiSan_ChiTiet
    {
        public int DangKyId { get; set; }
        public string SoDangKy { get; set; }
        public DateTime? NgayDangKy { get; set; }
        public string Mota { get; set; }
        public string TinhTrang { get; set; }
        public int CapDiSan { get; set; }
        public string File { get; set; }
        public bool Duyet { get; set; }
        public int DiSanID { get; set; }

    }
    public class NV_DangKyDiSan
    {
        private string ConnectionString;
        public NV_DangKyDiSan(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lấy theo ID
        public NV_DangKyDiSan_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DangKyDiSan_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@id", SqlDbType.VarChar, 10);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    DataTable dt;
                    NV_DangKyDiSan_ChiTiet model = new NV_DangKyDiSan_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model.DangKyId = id;
                        model.DiSanID = int.Parse(dt.Rows[0]["DiSanID"].ToString());
                        model.SoDangKy = dt.Rows[0]["SoDangKy"].ToString();
                        try
                        {
                            model.NgayDangKy = Convert.ToDateTime(dt.Rows[0]["NgayDangKy"].ToString());
                        }
                        catch { }
                        model.Mota = dt.Rows[0]["MoTa"].ToString();
                        model.TinhTrang = dt.Rows[0]["TinhTrang"].ToString();
                        try
                        {
                            model.CapDiSan = int.Parse(dt.Rows[0]["CapDiSan"].ToString());
                        }
                        catch { }
                        model.File = dt.Rows[0]["File"].ToString();
                        model.Duyet = Convert.ToBoolean(dt.Rows[0]["Duyet"].ToString());
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
                using (SqlCommand myCommand = new SqlCommand("NV_DangKyDiSan_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_DangKyDiSan_getAll");
                    return myDataSet.Tables["NV_DangKyDiSan_getAll"];

                }
            }
        }

        #endregion
        #region Thêm

        public bool them(NV_DangKyDiSan_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DangKyDiSan_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pSodangky = new SqlParameter("@SoDangKy", SqlDbType.NVarChar, 50);
                    pSodangky.Value = model.SoDangKy;
                    myCommand.Parameters.Add(pSodangky);

                    SqlParameter pDiSanID = new SqlParameter("@DiSanID", SqlDbType.Int);
                    pDiSanID.Value = model.DiSanID;
                    myCommand.Parameters.Add(pDiSanID);

                    SqlParameter pNgaydangky = new SqlParameter("@NgayDangKy", SqlDbType.DateTime, 8);
                    pNgaydangky.Value = model.NgayDangKy;
                    myCommand.Parameters.Add(pNgaydangky);

                    SqlParameter pMota = new SqlParameter("@Mota", SqlDbType.NText);
                    pMota.Value = model.Mota;
                    myCommand.Parameters.Add(pMota);

                    SqlParameter pTinhtrang = new SqlParameter("@Tinhtrang", SqlDbType.NVarChar, 250);
                    pTinhtrang.Value = model.TinhTrang;
                    myCommand.Parameters.Add(pTinhtrang);

                    SqlParameter pCapdisan = new SqlParameter("@CapDiSan", SqlDbType.Int);
                    pCapdisan.Value = model.CapDiSan;
                    myCommand.Parameters.Add(pCapdisan);

                    SqlParameter pFile = new SqlParameter("@File", SqlDbType.NVarChar, 500);
                    pFile.Value = model.File;
                    myCommand.Parameters.Add(pFile);

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
        #region update
        public bool Update(NV_DangKyDiSan_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DangKyDiSan_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@DangKyID", SqlDbType.Int);
                    pID.Value = model.DangKyId;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pSodangky = new SqlParameter("@SoDangKy", SqlDbType.NVarChar, 50);
                    pSodangky.Value = model.SoDangKy;
                    myCommand.Parameters.Add(pSodangky);

                    SqlParameter pDiSanID = new SqlParameter("@DiSanID", SqlDbType.Int);
                    pDiSanID.Value = model.DiSanID;
                    myCommand.Parameters.Add(pDiSanID);

                    SqlParameter pNgaydangky = new SqlParameter("@NgayDangKy", SqlDbType.DateTime, 8);
                    pNgaydangky.Value = model.NgayDangKy;
                    myCommand.Parameters.Add(pNgaydangky);

                    SqlParameter pMota = new SqlParameter("@Mota", SqlDbType.NText);
                    pMota.Value = model.Mota;
                    myCommand.Parameters.Add(pMota);

                    SqlParameter pTinhtrang = new SqlParameter("@Tinhtrang", SqlDbType.NVarChar, 250);
                    pTinhtrang.Value = model.TinhTrang;
                    myCommand.Parameters.Add(pTinhtrang);

                    SqlParameter pCapdisan = new SqlParameter("@CapDiSan", SqlDbType.Int);
                    pCapdisan.Value = model.CapDiSan;
                    myCommand.Parameters.Add(pCapdisan);

                    SqlParameter pFile = new SqlParameter("@File", SqlDbType.NVarChar, 500);
                    pFile.Value = model.File;
                    myCommand.Parameters.Add(pFile);

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
                using (SqlCommand myCommand = new SqlCommand("NV_DangKyDiSan_del", myConnection))
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
