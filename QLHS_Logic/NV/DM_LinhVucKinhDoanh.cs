using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic
{
    public class NV_DM_LinhVucKinhDoanh_ChiTiet
    {
        public int ID { get; set; }
        public string TenLinhVuc { get; set; }
        public int Stt { get; set; }

    }
    public class NV_DM_LinhVucKinhDoanh
    {
        private string ConnectionString;
        public NV_DM_LinhVucKinhDoanh(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }

        #region Lấy theo ID
        public NV_DM_LinhVucKinhDoanh_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_LinhVucKinhDoanh_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    DataTable dt;
                    NV_DM_LinhVucKinhDoanh_ChiTiet model = new NV_DM_LinhVucKinhDoanh_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {

                        model.ID = id;
                        model.TenLinhVuc = dt.Rows[0]["TenLinhVuc"].ToString();
                        model.Stt = int.Parse(dt.Rows[0]["Stt"].ToString());
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
                using (SqlCommand myCommand = new SqlCommand("NV_LinhVucKinhDoanh_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_LinhVucKinhDoanh_getAll");
                    return myDataSet.Tables["NV_LinhVucKinhDoanh_getAll"];

                }
            }
        }

        #endregion
        #region Thêm
        public bool them(NV_DM_LinhVucKinhDoanh_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_LinhVucKinhDoanh_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;


                    SqlParameter pTenLinhVuc = new SqlParameter("@TenLinhVuc", SqlDbType.NVarChar, 250);
                    pTenLinhVuc.Value = model.TenLinhVuc;
                    myCommand.Parameters.Add(pTenLinhVuc);


                    SqlParameter pStt = new SqlParameter("@Stt", SqlDbType.Int);
                    pStt.Value = model.Stt;
                    myCommand.Parameters.Add(pStt);

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
        public bool update(NV_DM_LinhVucKinhDoanh_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_LinhVucKinhDoanh_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = model.ID;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pTenLinhVuc = new SqlParameter("@TenLinhVuc", SqlDbType.NVarChar, 250);
                    pTenLinhVuc.Value = model.TenLinhVuc;
                    myCommand.Parameters.Add(pTenLinhVuc);


                    SqlParameter pStt = new SqlParameter("@Stt", SqlDbType.Int);
                    pStt.Value = model.Stt;
                    myCommand.Parameters.Add(pStt);
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
                using (SqlCommand myCommand = new SqlCommand("NV_LinhVucKinhDoanh_del", myConnection))
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
