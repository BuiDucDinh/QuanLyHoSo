using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_DanhMuc_ChiTiet
    {
        public int DanhMucID { get; set; }
        public string TenDanhMuc { get; set; }
        public int DanhMucCha { get; set; }
        public string MoTa { get; set; }
        public int TheLoai { get; set; }
    }
    public class NV_DanhMuc
    {
        private string ConnectionString;
        public NV_DanhMuc(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }

        #region Lấy theo ID
        public NV_DanhMuc_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DanhMuc_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@id", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    NV_DanhMuc_ChiTiet model = new NV_DanhMuc_ChiTiet();
                    DataTable dt;

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model.DanhMucID = id;
                        model.TenDanhMuc = dt.Rows[0]["TenDanhMuc"].ToString();
                        model.DanhMucCha = int.Parse(dt.Rows[0]["DanhMucCha"].ToString());
                        model.MoTa = dt.Rows[0]["MoTa"].ToString();
                        model.TheLoai = int.Parse(dt.Rows[0]["TheLoai"].ToString());
                    }
                    return model;
                }
            }
        }
        #endregion

        #region update
        public bool update(NV_DanhMuc_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_Danhmuc_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@DanhMucID", SqlDbType.Int);
                    pID.Value = model.DanhMucID;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pTenDanhMuc = new SqlParameter("@TenDanhMuc", SqlDbType.NVarChar, 200);
                    pTenDanhMuc.Value = model.TenDanhMuc;
                    myCommand.Parameters.Add(pTenDanhMuc);

                    SqlParameter pDanhMucCha = new SqlParameter("@DanhMucCha", SqlDbType.Int);
                    pDanhMucCha.Value = model.DanhMucCha;
                    myCommand.Parameters.Add(pDanhMucCha);

                    SqlParameter pMoTa = new SqlParameter("@MoTa", SqlDbType.NText);
                    pMoTa.Value = model.MoTa;
                    myCommand.Parameters.Add(pMoTa);

                    SqlParameter pTheLoai = new SqlParameter("@TheLoai", SqlDbType.Int);
                    pTheLoai.Value = model.TheLoai;
                    myCommand.Parameters.Add(pTheLoai);
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
                using (SqlCommand myCommand = new SqlCommand("NV_DanhMuc_del", myConnection))
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
        public DataTable GetByParent(string pID, int type)
        {
            string sql = "select DanhMucID,TenDanhMuc from DanhMucMedia where DanhMucCha=" + pID + " and TheLoai=" + type;
            DataTable dt = Sys_Common.getDataByQuery(sql);
            return dt;
        }
        #endregion
        #region Lấy tất cả DM ảnh
        public DataTable GetAllDMImage()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DanhMucAnh_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_DanhMucAnh_getAll");
                    return myDataSet.Tables["NV_DanhMucAnh_getAll"];

                }
            }
        }

        #endregion
        #region Lấy tất cả DM video
        public DataTable GetAllDMVideo()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DanhMucVideo_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_DanhMucVideo_getAll");
                    return myDataSet.Tables["NV_DanhMucVideo_getAll"];

                }
            }
        }

        #endregion
        #region Lấy tất cả DM document
        public DataTable GetAllDMDocument()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DanhMucDocument_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_DanhMucDocument_getAll");
                    return myDataSet.Tables["NV_DanhMucDocument_getAll"];

                }
            }
        }

        #endregion

        #region Thêm DM ảnh
        public bool themDMImage(NV_DanhMuc_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DanhMucAnh_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pTenDanhMuc = new SqlParameter("@TenDanhMuc", SqlDbType.NVarChar, 300);
                    pTenDanhMuc.Value = model.TenDanhMuc;
                    myCommand.Parameters.Add(pTenDanhMuc);

                    SqlParameter pDanhMucCha = new SqlParameter("@DanhMucCha", SqlDbType.Int);
                    pDanhMucCha.Value = model.DanhMucCha;
                    myCommand.Parameters.Add(pDanhMucCha);

                    SqlParameter pMoTa = new SqlParameter("@MoTa", SqlDbType.NText);
                    pMoTa.Value = model.MoTa;
                    myCommand.Parameters.Add(pMoTa);

                    SqlParameter pTheLoai = new SqlParameter("@TheLoai", SqlDbType.Int);
                    pTheLoai.Value = model.TheLoai;
                    myCommand.Parameters.Add(pTheLoai);

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
        #region Thêm DM Video
        public bool themDMVideo(NV_DanhMuc_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DanhMucVideo_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pTenDanhMuc = new SqlParameter("@TenDanhMuc", SqlDbType.NVarChar, 300);
                    pTenDanhMuc.Value = model.TenDanhMuc;
                    myCommand.Parameters.Add(pTenDanhMuc);

                    SqlParameter pDanhMucCha = new SqlParameter("@DanhMucCha", SqlDbType.Int);
                    pDanhMucCha.Value = model.DanhMucCha;
                    myCommand.Parameters.Add(pDanhMucCha);

                    SqlParameter pMoTa = new SqlParameter("@MoTa", SqlDbType.NText);
                    pMoTa.Value = model.MoTa;
                    myCommand.Parameters.Add(pMoTa);

                    SqlParameter pTheLoai = new SqlParameter("@TheLoai", SqlDbType.Int);
                    pTheLoai.Value = model.TheLoai;
                    myCommand.Parameters.Add(pTheLoai);

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
        #region Thêm DM Document
        public bool themDMDocument(NV_DanhMuc_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DanhMucDocument_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pTenDanhMuc = new SqlParameter("@TenDanhMuc", SqlDbType.NVarChar, 300);
                    pTenDanhMuc.Value = model.TenDanhMuc;
                    myCommand.Parameters.Add(pTenDanhMuc);

                    SqlParameter pDanhMucCha = new SqlParameter("@DanhMucCha", SqlDbType.Int);
                    pDanhMucCha.Value = model.DanhMucCha;
                    myCommand.Parameters.Add(pDanhMucCha);

                    SqlParameter pMoTa = new SqlParameter("@MoTa", SqlDbType.NText);
                    pMoTa.Value = model.MoTa;
                    myCommand.Parameters.Add(pMoTa);

                    SqlParameter pTheLoai = new SqlParameter("@TheLoai", SqlDbType.Int);
                    pTheLoai.Value = model.TheLoai;
                    myCommand.Parameters.Add(pTheLoai);

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
    }
}
