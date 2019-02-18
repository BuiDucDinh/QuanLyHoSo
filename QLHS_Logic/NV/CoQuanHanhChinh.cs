using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_CoQuanHanhChinh_ChiTiet
    {
        public int CoQuanID { get; set; }
        public string TenCoQuan { get; set; }
        public string CoQuanQuanLy { get; set; }
        public int CapCoQuan { get; set; }
        public string ChucNang { get; set; }
        public string LichSu { get; set; }
        public string DiaChi { get; set; }
        public string ThuocTinh { get; set; }
        public string ThuocHuyen { get; set; }
        public string ThuocXa { get; set; }
        public string Mota { get; set; }
    }
    public class NV_CoQuanHanhChinh
    {
        private string ConnectionString;
        public NV_CoQuanHanhChinh(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lấy theo ID
        public NV_CoQuanHanhChinh_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DM_CoQuanHanhChinh_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@id", SqlDbType.VarChar, 10);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    DataTable dt;
                    NV_CoQuanHanhChinh_ChiTiet model = new NV_CoQuanHanhChinh_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model.CoQuanID = id;
                        model.TenCoQuan = dt.Rows[0]["TenCoQuan"].ToString();
                        try
                        {
                            model.CapCoQuan = int.Parse(dt.Rows[0]["CapCoQuan"].ToString());
                        }
                        catch { }
                        model.ChucNang = dt.Rows[0]["ChucNang"].ToString();
                        model.LichSu = dt.Rows[0]["LichSu"].ToString();
                        model.DiaChi = dt.Rows[0]["DiaChi"].ToString();
                        model.ThuocTinh = dt.Rows[0]["ThuocTinh"].ToString();
                        model.ThuocHuyen = dt.Rows[0]["ThuocHuyen"].ToString();
                        model.ThuocXa =dt.Rows[0]["ThuocXa"].ToString();
                        model.Mota = dt.Rows[0]["MoTa"].ToString();
                        model.CoQuanQuanLy = dt.Rows[0]["CoQuanQuanLy"].ToString();
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
                using (SqlCommand myCommand = new SqlCommand("NV_DM_CoQuanHanhChinh_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_DM_CoQuanHanhChinh_getAll");
                    return myDataSet.Tables["NV_DM_CoQuanHanhChinh_getAll"];

                }
            }
        }

        #endregion

        #region Lấy đổ combo
        public DataTable GetDataToCombo()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DM_CoQuanHanhChinh_getCombo", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_DM_CoQuanHanhChinh_getCombo");
                    return myDataSet.Tables["NV_DM_CoQuanHanhChinh_getCombo"];

                }
            }
        }
             #endregion

        #region Lấy theo danh muc cha
        public DataTable GetByParent(string pID)
        {
            string sql = "select * from DM_CoQuanHanhChinh where CoQuanQuanLy=" + pID;
            DataTable dt = Sys_Common.getDataByQuery(sql);
            return dt;
        }
        #endregion

        #region Thêm
        public bool them(NV_CoQuanHanhChinh_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DM_CoQuanHanhChinh_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pTencoquan = new SqlParameter("@TenCoQuan", SqlDbType.NVarChar, 500);
                    pTencoquan.Value = model.TenCoQuan;
                    myCommand.Parameters.Add(pTencoquan);

                    SqlParameter pCapcoquan = new SqlParameter("@CapCoQuan", SqlDbType.Int);
                    pCapcoquan.Value = model.CapCoQuan;
                    myCommand.Parameters.Add(pCapcoquan);

                    SqlParameter pChucnang = new SqlParameter("@ChucNang", SqlDbType.NText);
                    pChucnang.Value = model.ChucNang;
                    myCommand.Parameters.Add(pChucnang);

                    SqlParameter pLichsu = new SqlParameter("@LichSu", SqlDbType.NText);
                    pLichsu.Value = model.LichSu;
                    myCommand.Parameters.Add(pLichsu);

                    SqlParameter pDiachi = new SqlParameter("@DiaChi", SqlDbType.NVarChar, 500);
                    pDiachi.Value = model.DiaChi;
                    myCommand.Parameters.Add(pDiachi);

                    SqlParameter pThuocTinh = new SqlParameter("@ThuocTinh", SqlDbType.VarChar, 10);
                    pThuocTinh.Value = model.ThuocTinh;
                    myCommand.Parameters.Add(pThuocTinh);

                    SqlParameter pThuochuyen = new SqlParameter("@ThuocHuyen", SqlDbType.VarChar,10);
                    pThuochuyen.Value = model.ThuocHuyen;
                    myCommand.Parameters.Add(pThuochuyen);

                    SqlParameter pThuocxa = new SqlParameter("@ThuocXa", SqlDbType.VarChar, 10);
                    pThuocxa.Value = model.ThuocXa;
                    myCommand.Parameters.Add(pThuocxa);

                    SqlParameter pCoQuanQuanLy= new SqlParameter("@CoQuanQuanLy", SqlDbType.Int);
                    pCoQuanQuanLy.Value = model.CoQuanQuanLy;
                    myCommand.Parameters.Add(pCoQuanQuanLy);

                    SqlParameter pMota = new SqlParameter("@Mota", SqlDbType.NText);
                    pMota.Value = model.Mota;
                    myCommand.Parameters.Add(pMota);

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
        public bool update(NV_CoQuanHanhChinh_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DM_CoQuanHanhChinh_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@CoQuanID", SqlDbType.Int);
                    pID.Value = model.CoQuanID;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pTencoquan = new SqlParameter("@TenCoQuan", SqlDbType.NVarChar, 500);
                    pTencoquan.Value = model.TenCoQuan;
                    myCommand.Parameters.Add(pTencoquan);

                    SqlParameter pCapcoquan = new SqlParameter("@CapCoQuan", SqlDbType.Int);
                    pCapcoquan.Value = model.CapCoQuan;
                    myCommand.Parameters.Add(pCapcoquan);

                    SqlParameter pChucnang = new SqlParameter("@ChucNang", SqlDbType.NText);
                    pChucnang.Value = model.ChucNang;
                    myCommand.Parameters.Add(pChucnang);

                    SqlParameter pLichsu = new SqlParameter("@LichSu", SqlDbType.NText);
                    pLichsu.Value = model.LichSu;
                    myCommand.Parameters.Add(pLichsu);

                    SqlParameter pDiachi = new SqlParameter("@DiaChi", SqlDbType.NVarChar, 500);
                    pDiachi.Value = model.DiaChi;
                    myCommand.Parameters.Add(pDiachi);

                    SqlParameter pThuocTinh = new SqlParameter("@ThuocTinh", SqlDbType.VarChar, 10);
                    pThuocTinh.Value = model.ThuocTinh;
                    myCommand.Parameters.Add(pThuocTinh);

                    SqlParameter pThuochuyen = new SqlParameter("@ThuocHuyen", SqlDbType.VarChar, 10);
                    pThuochuyen.Value = model.ThuocHuyen;
                    myCommand.Parameters.Add(pThuochuyen);

                    SqlParameter pThuocxa = new SqlParameter("@ThuocXa", SqlDbType.VarChar, 10);
                    pThuocxa.Value = model.ThuocXa;
                    myCommand.Parameters.Add(pThuocxa);

                    SqlParameter pCoQuanQuanLy = new SqlParameter("@CoQuanQuanLy", SqlDbType.Int);
                    pCoQuanQuanLy.Value = model.CoQuanQuanLy;
                    myCommand.Parameters.Add(pCoQuanQuanLy);

                    SqlParameter pMota = new SqlParameter("@Mota", SqlDbType.NText);
                    pMota.Value = model.Mota;
                    myCommand.Parameters.Add(pMota);

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
                using (SqlCommand myCommand = new SqlCommand("NV_DM_CoQuanHanhChinh_del", myConnection))
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
