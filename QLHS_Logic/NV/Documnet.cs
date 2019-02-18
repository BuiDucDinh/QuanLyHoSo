using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_Document_ChiTiet
    {
        public int DocumentID { get; set; }
        public string TenTaiLieu { get; set; }
        public DateTime? NgayTao { get; set; }
        public int DanhMuc { get; set; }
        public string File { get; set; }
    }
    public class NV_Document
    {
        private string ConnectionString;
        public NV_Document(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }

        #region Lấy theo ID
        public NV_Document_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_Document_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@id", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    NV_Document_ChiTiet model = new NV_Document_ChiTiet();
                    DataTable dt;

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model.DocumentID = id;
                        model.TenTaiLieu = dt.Rows[0]["TenTaiLieu"].ToString();
                        try
                        {
                            model.NgayTao = Convert.ToDateTime(dt.Rows[0]["NgayTao"].ToString());
                        }
                        catch { }
                        model.DanhMuc = int.Parse(dt.Rows[0]["DanhMuc"].ToString());
                        model.File = dt.Rows[0]["File"].ToString();
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
                using (SqlCommand myCommand = new SqlCommand("NV_Document_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_Document_getAll");
                    return myDataSet.Tables["NV_Document_getAll"];

                }
            }
        }

        #endregion
        #region Thêm
        public bool them(NV_Document_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_Document_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pTenAnh = new SqlParameter("@TenTaiLieu", SqlDbType.NVarChar, 300);
                    pTenAnh.Value = model.TenTaiLieu;
                    myCommand.Parameters.Add(pTenAnh);

                    SqlParameter pDanhMuc = new SqlParameter("@DanhMuc", SqlDbType.Int);
                    pDanhMuc.Value = model.DanhMuc;
                    myCommand.Parameters.Add(pDanhMuc);

                    SqlParameter pNgayTao = new SqlParameter("@NgayTao", SqlDbType.DateTime);
                    pNgayTao.Value = model.NgayTao;
                    myCommand.Parameters.Add(pNgayTao);

                    SqlParameter pFile = new SqlParameter("@File", SqlDbType.NVarChar, 300);
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
        #region update
        public bool update(NV_Document_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_Document_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@DocumentID", SqlDbType.Int);
                    pID.Value = model.DocumentID;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pTenAnh = new SqlParameter("@TenTaiLieu", SqlDbType.NVarChar, 300);
                    pTenAnh.Value = model.TenTaiLieu;
                    myCommand.Parameters.Add(pTenAnh);

                    SqlParameter pDanhMuc = new SqlParameter("@DanhMuc", SqlDbType.Int);
                    pDanhMuc.Value = model.DanhMuc;
                    myCommand.Parameters.Add(pDanhMuc);

                    SqlParameter pNgayTao = new SqlParameter("@NgayTao", SqlDbType.DateTime);
                    pNgayTao.Value = model.NgayTao;
                    myCommand.Parameters.Add(pNgayTao);

                    SqlParameter pFile = new SqlParameter("@File", SqlDbType.NVarChar, 300);
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
                using (SqlCommand myCommand = new SqlCommand("NV_Document_del", myConnection))
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
        #region Lấy theo danh muc cha
        public DataTable GetByParent(string pID)
        {
            string sql = "select * from Document where DanhMuc=" + pID;
            DataTable dt = Sys_Common.getDataByQuery(sql);
            return dt;
        }
        #endregion

        #region Lấy theo list id
        public DataTable GetbyListID(string list)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_Document_getByListID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pList = new SqlParameter("@list", SqlDbType.NVarChar, 200);
                    pList.Value = list;
                    myCommand.Parameters.Add(pList);
                    DataTable dt = new DataTable();
                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        #endregion
    }
}
