using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_DanhMucAnPham_ChiTiet
    {
        public int DanhMucID { get; set; }
        public string TenDanhMuc { get; set; }
        public string EngName { get; set; }
        public string Url { get; set; }
        public string UrlFull { get; set; }
        public NV_DanhMucAnPham_ChiTiet() { }
        public NV_DanhMucAnPham_ChiTiet(DataTable dt)
        {
            DanhMucID = int.Parse(dt.Rows[0]["DanhMucID"].ToString());
            TenDanhMuc = dt.Rows[0]["TenDanhMuc"].ToString();
            EngName = dt.Rows[0]["EngName"].ToString();
            Url = dt.Rows[0]["Url"].ToString();
            try
            {
                UrlFull = dt.Rows[0]["UrlFull"].ToString();
            }
            catch { }
        }
    }
    public class NV_DanhMucAnPham
    {
        private string ConnectionString;
        public NV_DanhMucAnPham(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }


        #region Lấy theo ID
        public NV_DanhMucAnPham_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DanhMucAnPham_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@DanhMucID", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    DataTable dt;
                    NV_DanhMucAnPham_ChiTiet model = new NV_DanhMucAnPham_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_DanhMucAnPham_ChiTiet(dt);
                    }
                    return model;
                }
            }
        }
        #endregion

        #region Lấy theo url
        public NV_DanhMucAnPham_ChiTiet GetByUrl(string url)
        {
            string sql = "select top 1 *,dbo.getUrl(DanhMucID,'DanhMucAnPham',null) as UrlFull from DanhMucAnPham where Url='" + url + "'";
            DataTable dt = Sys_Common.getDataByQuery(sql);
            NV_DanhMucAnPham_ChiTiet menu = new NV_DanhMucAnPham_ChiTiet();
            if (dt != null && dt.Rows.Count > 0)
            {
                menu = new NV_DanhMucAnPham_ChiTiet(dt);
            }
            return menu;
        }
        #endregion

        #region Lấy tất cả
        public DataTable GetAll()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DanhMucAnPham_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_DanhMucAnPham_getAll");
                    return myDataSet.Tables["NV_DanhMucAnPham_getAll"];

                }
            }
        }

        #endregion

        #region Thêm
        public bool them(NV_DanhMucAnPham_ChiTiet model, out int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DanhMucAnPham_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@DanhMucID", SqlDbType.Int);
                    pID.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pTenDanhMuc = new SqlParameter("@TenDanhMuc", SqlDbType.NVarChar, 500);
                    pTenDanhMuc.Value = model.TenDanhMuc;
                    myCommand.Parameters.Add(pTenDanhMuc);

                    SqlParameter pEngName = new SqlParameter("@EngName", SqlDbType.NVarChar, 500);
                    pEngName.Value = model.EngName;
                    myCommand.Parameters.Add(pEngName);

                    SqlParameter pUrl = new SqlParameter("@Url", SqlDbType.NVarChar, 500);
                    pUrl.Value = model.Url;
                    myCommand.Parameters.Add(pUrl);
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
        public bool update(NV_DanhMucAnPham_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DanhMucAnPham_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@DanhMucID", SqlDbType.Int);
                    pID.Value = model.DanhMucID;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pTenDanhMuc = new SqlParameter("@TenDanhMuc", SqlDbType.NVarChar, 500);
                    pTenDanhMuc.Value = model.TenDanhMuc;
                    myCommand.Parameters.Add(pTenDanhMuc);


                    SqlParameter pEngName = new SqlParameter("@EngName", SqlDbType.NVarChar, 500);
                    pEngName.Value = model.EngName;
                    myCommand.Parameters.Add(pEngName);
                    SqlParameter pUrl = new SqlParameter("@Url", SqlDbType.NVarChar, 500);
                    pUrl.Value = model.Url;
                    myCommand.Parameters.Add(pUrl);
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
                using (SqlCommand myCommand = new SqlCommand("NV_DanhMucAnPham_del", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@DanhMucID", SqlDbType.VarChar, 10);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        public DataTable getDataCombo()
        {
            DataTable dt = GetAll();
            DataRow dr = dt.NewRow();
            dr["DanhMucID"] = 0;
            dr["TenDanhMuc"] = "Chọn danh mục ấn phẩm";
            dt.Rows.InsertAt(dr, 0);

            return dt;
        }
    }
}
