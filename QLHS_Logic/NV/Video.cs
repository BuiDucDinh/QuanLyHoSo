using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_Video_ChiTiet
    {
        public int VideoID { get; set; }
        public string TenVideo { get; set; }
        public int ImageID { get; set; }
        public int DanhMuc { get; set; }
        public string Url { get; set; }
        public string FileUpload { get; set; }
        public NV_Video_ChiTiet() { }
        public NV_Video_ChiTiet(DataRow dr)
        {
            VideoID = int.Parse(dr["VideoID"].ToString());
            TenVideo = dr["TenVideo"].ToString();
            ImageID = int.Parse(dr["Image"].ToString());
            FileUpload = dr["FileUpload"].ToString();
            Url = dr["Url"].ToString();
            DanhMuc = int.Parse(dr["DanhMuc"].ToString());
        }
    }
    public class NV_Video
    {
        private string ConnectionString;
        public NV_Video(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lấy theo ID
        public NV_Video_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_Video_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@id", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    NV_Video_ChiTiet model = new NV_Video_ChiTiet();
                    DataTable dt;

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_Video_ChiTiet(dt.Rows[0]);
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
                using (SqlCommand myCommand = new SqlCommand("NV_Video_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_Video_getAll");
                    return myDataSet.Tables["NV_Video_getAll"];

                }
            }
        }

        #endregion
        #region Thêm
        public bool them(NV_Video_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_Video_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pTenVideo = new SqlParameter("@TenVideo", SqlDbType.NVarChar, 500);
                    pTenVideo.Value = model.TenVideo;
                    myCommand.Parameters.Add(pTenVideo);

                    SqlParameter pDanhMuc = new SqlParameter("@DanhMuc", SqlDbType.Int);
                    pDanhMuc.Value = model.DanhMuc;
                    myCommand.Parameters.Add(pDanhMuc);

                    SqlParameter pAnhMoTa = new SqlParameter("@ImageID", SqlDbType.Int);
                    pAnhMoTa.Value = model.ImageID;
                    myCommand.Parameters.Add(pAnhMoTa);

                    SqlParameter pUrl = new SqlParameter("@Url", SqlDbType.NVarChar, 500);
                    pUrl.Value = model.Url;
                    myCommand.Parameters.Add(pUrl);

                    SqlParameter pFileUpload = new SqlParameter("@FileUpload", SqlDbType.NVarChar, 300);
                    pFileUpload.Value = model.FileUpload;
                    myCommand.Parameters.Add(pFileUpload);

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
        public bool update(NV_Video_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_Video_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@VideoID", SqlDbType.Int);
                    pID.Value = model.VideoID;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pTenVideo = new SqlParameter("@TenVideo", SqlDbType.NVarChar, 500);
                    pTenVideo.Value = model.TenVideo;
                    myCommand.Parameters.Add(pTenVideo);

                    SqlParameter pDanhMuc = new SqlParameter("@DanhMuc", SqlDbType.Int);
                    pDanhMuc.Value = model.DanhMuc;
                    myCommand.Parameters.Add(pDanhMuc);

                    SqlParameter pAnhMoTa = new SqlParameter("@ImageID", SqlDbType.Int);
                    pAnhMoTa.Value = model.ImageID;
                    myCommand.Parameters.Add(pAnhMoTa);

                    SqlParameter pUrl = new SqlParameter("@Url", SqlDbType.NVarChar, 500);
                    pUrl.Value = model.Url;
                    myCommand.Parameters.Add(pUrl);

                    SqlParameter pFileUpload = new SqlParameter("@FileUpload", SqlDbType.NVarChar, 300);
                    pFileUpload.Value = model.FileUpload;
                    myCommand.Parameters.Add(pFileUpload);


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
                using (SqlCommand myCommand = new SqlCommand("NV_Video_del", myConnection))
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
        #region Lấy theo danh muc
        public DataTable GetByParent(int danhmuc)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_Video_getByDanhMuc", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pList = new SqlParameter("@DanhMuc", SqlDbType.Int);
                    pList.Value = danhmuc;
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

        #region Lấy theo list id
        public DataTable GetbyListID(string list)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_Video_getByListID", myConnection))
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
