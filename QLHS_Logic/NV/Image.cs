using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_Image_ChiTiet
    {
        public int ImageID { get; set; }
        public string TenAnh { get; set; }
        public DateTime? NgayTao { get; set; }
        public int DanhMuc { get; set; }

    }
    public class NV_Image
    {
        private string ConnectionString;
        public NV_Image(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lấy theo ID
        public NV_Image_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_Image_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@id", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    NV_Image_ChiTiet model = new NV_Image_ChiTiet();
                    DataTable dt;

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model.ImageID = id;
                        model.TenAnh = dt.Rows[0]["TenAnh"].ToString();
                        model.NgayTao = Convert.ToDateTime(dt.Rows[0]["NgayTao"].ToString());
                        model.DanhMuc = int.Parse(dt.Rows[0]["DanhMuc"].ToString());
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
                using (SqlCommand myCommand = new SqlCommand("NV_Image_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_Image_getAll");
                    return myDataSet.Tables["NV_Image_getAll"];

                }
            }
        }

        #endregion
        #region Thêm
        public bool them(NV_Image_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_Image_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pTenAnh = new SqlParameter("@TenAnh", SqlDbType.NVarChar, 300);
                    pTenAnh.Value = model.TenAnh;
                    myCommand.Parameters.Add(pTenAnh);

                    SqlParameter pDanhMuc = new SqlParameter("@DanhMuc", SqlDbType.Int);
                    pDanhMuc.Value = model.DanhMuc;
                    myCommand.Parameters.Add(pDanhMuc);

                    SqlParameter pNgayTao = new SqlParameter("@NgayTao", SqlDbType.DateTime);
                    pNgayTao.Value = model.NgayTao;
                    myCommand.Parameters.Add(pNgayTao);

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
        public bool update(NV_Image_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_Image_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ImageID", SqlDbType.Int);
                    pID.Value = model.ImageID;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pTenAnh = new SqlParameter("@TenAnh", SqlDbType.NVarChar, 300);
                    pTenAnh.Value = model.TenAnh;
                    myCommand.Parameters.Add(pTenAnh);

                    SqlParameter pDanhMuc = new SqlParameter("@DanhMuc", SqlDbType.Int);
                    pDanhMuc.Value = model.DanhMuc;
                    myCommand.Parameters.Add(pDanhMuc);

                    SqlParameter pNgayTao = new SqlParameter("@NgayTao", SqlDbType.DateTime);
                    pNgayTao.Value = model.NgayTao;
                    myCommand.Parameters.Add(pNgayTao);


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
                using (SqlCommand myCommand = new SqlCommand("NV_Image_del", myConnection))
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
            string sql = "select * from Image where DanhMuc=" + pID;
            DataTable dt = Sys_Common.getDataByQuery(sql);
            return dt;
        }
        #endregion

        #region Lấy theo list id
        public DataTable GetbyListID(string list = "")
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_Image_getByListID", myConnection))
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
