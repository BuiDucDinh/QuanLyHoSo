using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_ChucNangTuBo_ChiTiet
    {
        public int ID { get; set; }
        public string TenChucNang { get; set; }
        public string MoTa { get; set; }
    }
    public class NV_ChucNangTuBo
    {
        private string ConnectionString;
        public NV_ChucNangTuBo(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        
        #region Lấy tất cả
        public DataTable GetAll()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_ChucNangTuBo_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_ChucNangTuBo_getAll");
                    return myDataSet.Tables["NV_ChucNangTuBo_getAll"];
                }
            }
        }
        #endregion
        //#region Lấy theo ID
        //public NV_ChucNangTuBo_ChiTiet GetById(int id)
        //{
        //    using (SqlConnection myConnection = new SqlConnection(ConnectionString))
        //    {
        //        using (SqlCommand myCommand = new SqlCommand("NV_ChucNangTuBo_getByID", myConnection))
        //        {
        //            myCommand.CommandType = CommandType.StoredProcedure;

        //            SqlParameter pID = new SqlParameter("@id", SqlDbType.VarChar, 10);
        //            pID.Value = id;
        //            myCommand.Parameters.Add(pID);

        //            DataTable dt;
        //            NV_ChucNangTuBo_ChiTiet model = new NV_ChucNangTuBo_ChiTiet();

        //            myConnection.Open();
        //            using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
        //            {
        //                dt = new DataTable();
        //                mData.Fill(dt);
        //            }
        //            if (dt != null && dt.Rows.Count > 0)
        //            {
        //                model.ChucNangTuBoID = id;
        //                model.HoTen = dt.Rows[0]["HoTen"].ToString();
        //                try
        //                {
        //                    model.ChucVu = Sys_Common.NV_DM_ChucVu.GetById(int.Parse(dt.Rows[0]["ChucVuID"].ToString())); //(int)pChucVuID.Value;
        //                }
        //                catch { }
        //                try
        //                {
        //                    model.CoQuan = Sys_Common.NV_CoQuanHanhChinh.GetById(int.Parse(dt.Rows[0]["CoQuanID"].ToString()));
        //                }
        //                catch
        //                {
        //                    model.CoQuan = new NV_CoQuanHanhChinh_ChiTiet();
        //                }
        //                model.DiaChi = dt.Rows[0]["DiaChi"].ToString();
        //                model.GhiChu = dt.Rows[0]["GhiChu"].ToString();
        //                model.Email = dt.Rows[0]["Email"].ToString();
        //                model.SoDienThoai = dt.Rows[0]["SoDienThoai"].ToString();
        //            }
        //            return model;
        //        }
        //    }
        //}
        //#endregion
        //#region Thêm
        //public bool them(NV_ChucNangTuBo_ChiTiet model)
        //{
        //    using (SqlConnection myConnection = new SqlConnection(ConnectionString))
        //    {
        //        using (SqlCommand myCommand = new SqlCommand("NV_ChucNangTuBo_add", myConnection))
        //        {
        //            myCommand.CommandType = CommandType.StoredProcedure;

        //            SqlParameter pHoTen = new SqlParameter("@HoTen", SqlDbType.NVarChar, 100);
        //            pHoTen.Value = model.HoTen;
        //            myCommand.Parameters.Add(pHoTen);

        //            SqlParameter pChucvuID = new SqlParameter("@ChucVuID", SqlDbType.Int);
        //            pChucvuID.Value = model.ChucVu.ChucvuID;
        //            myCommand.Parameters.Add(pChucvuID);

        //            SqlParameter pCoquanID = new SqlParameter("@CoQuanID", SqlDbType.Int);
        //            pCoquanID.Value = model.CoQuan.CoQuanID;
        //            myCommand.Parameters.Add(pCoquanID);

        //            SqlParameter pSodienthoai = new SqlParameter("@SoDienThoai", SqlDbType.NVarChar, 50);
        //            pSodienthoai.Value = model.SoDienThoai;
        //            myCommand.Parameters.Add(pSodienthoai);

        //            SqlParameter pDiachi = new SqlParameter("@DiaChi", SqlDbType.NVarChar, 500);
        //            pDiachi.Value = model.DiaChi;
        //            myCommand.Parameters.Add(pDiachi);

        //            SqlParameter pGhiChu = new SqlParameter("@GhiChu", SqlDbType.NVarChar, 4000);
        //            pGhiChu.Value = model.GhiChu;
        //            myCommand.Parameters.Add(pGhiChu);

        //            SqlParameter pEmail = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
        //            pEmail.Value = model.Email;
        //            myCommand.Parameters.Add(pEmail);

        //            try
        //            {
        //                myConnection.Open();
        //                myCommand.ExecuteNonQuery();
        //                return true;
        //            }
        //            catch
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //}
        //#endregion
        //#region update
        //public bool update(NV_ChucNangTuBo_ChiTiet model)
        //{
        //    using (SqlConnection myConnection = new SqlConnection(ConnectionString))
        //    {
        //        using (SqlCommand myCommand = new SqlCommand("NV_ChucNangTuBo_update", myConnection))
        //        {
        //            myCommand.CommandType = CommandType.StoredProcedure;

        //            SqlParameter pID = new SqlParameter("@ChucNangTuBoID", SqlDbType.NVarChar, 100);
        //            pID.Value = model.ChucNangTuBoID;
        //            myCommand.Parameters.Add(pID);

        //            SqlParameter pHoTen = new SqlParameter("@HoTen", SqlDbType.NVarChar, 100);
        //            pHoTen.Value = model.HoTen;
        //            myCommand.Parameters.Add(pHoTen);

        //            SqlParameter pChucvuID = new SqlParameter("@ChucVuID", SqlDbType.Int);
        //            pChucvuID.Value = model.ChucVu.ChucvuID;
        //            myCommand.Parameters.Add(pChucvuID);

        //            SqlParameter pCoquanID = new SqlParameter("@CoQuanID", SqlDbType.Int);
        //            pCoquanID.Value = model.CoQuan.CoQuanID;
        //            myCommand.Parameters.Add(pCoquanID);

        //            SqlParameter pSodienthoai = new SqlParameter("@SoDienThoai", SqlDbType.NVarChar, 50);
        //            pSodienthoai.Value = model.SoDienThoai;
        //            myCommand.Parameters.Add(pSodienthoai);

        //            SqlParameter pDiachi = new SqlParameter("@DiaChi", SqlDbType.NVarChar, 500);
        //            pDiachi.Value = model.DiaChi;
        //            myCommand.Parameters.Add(pDiachi);

        //            SqlParameter pGhiChu = new SqlParameter("@GhiChu", SqlDbType.NVarChar, 4000);
        //            pGhiChu.Value = model.GhiChu;
        //            myCommand.Parameters.Add(pGhiChu);

        //            SqlParameter pEmail = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
        //            pEmail.Value = model.Email;
        //            myCommand.Parameters.Add(pEmail);

        //            try
        //            {
        //                myConnection.Open();
        //                myCommand.ExecuteNonQuery();
        //                return true;
        //            }
        //            catch
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //}
        //#endregion
        //#region Xóa
        //public void Xoa(int id)
        //{
        //    using (SqlConnection myConnection = new SqlConnection(ConnectionString))
        //    {
        //        using (SqlCommand myCommand = new SqlCommand("NV_ChucNangTuBo_del", myConnection))
        //        {
        //            myCommand.CommandType = CommandType.StoredProcedure;

        //            SqlParameter pID = new SqlParameter("@id", SqlDbType.VarChar, 10);
        //            pID.Value = id;
        //            myCommand.Parameters.Add(pID);

        //            myConnection.Open();
        //            myCommand.ExecuteNonQuery();
        //        }
        //    }
        //}
        //#endregion
    }
}
