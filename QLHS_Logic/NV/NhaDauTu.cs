using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_NhaDauTu_ChiTiet
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string MoTa { get; set; }
        public NV_NhaDauTu_ChiTiet() { }
        public NV_NhaDauTu_ChiTiet(DataRow dr)
        {
            ID = int.Parse(dr["ID"].ToString());
            Ten = dr["Ten"].ToString();           
            DiaChi = dr["DiaChi"].ToString();
            MoTa = dr["MoTa"].ToString();
            Email = dr["Email"].ToString();
            DienThoai = dr["DienThoai"].ToString();
        }
    }
    public class NV_NhaDauTu
    {
        private string ConnectionString;
        public NV_NhaDauTu(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lấy theo ID
        public NV_NhaDauTu_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_NhaDauTu_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    DataTable dt;
                    NV_NhaDauTu_ChiTiet model = new NV_NhaDauTu_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_NhaDauTu_ChiTiet(dt.Rows[0]);
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
                using (SqlCommand myCommand = new SqlCommand("NV_NhaDauTu_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_NhaDauTu_getAll");
                    return myDataSet.Tables["NV_NhaDauTu_getAll"];

                }
            }
        }

        #endregion
        #region Thêm
        public bool them(NV_NhaDauTu_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_NhaDauTu_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pTen = new SqlParameter("@Ten", SqlDbType.NVarChar, 200);
                    pTen.Value = model.Ten;
                    myCommand.Parameters.Add(pTen);

                    SqlParameter pSodienthoai = new SqlParameter("@DienThoai", SqlDbType.NVarChar, 50);
                    pSodienthoai.Value = model.DienThoai;
                    myCommand.Parameters.Add(pSodienthoai);

                    SqlParameter pDiachi = new SqlParameter("@DiaChi", SqlDbType.NVarChar, 200);
                    pDiachi.Value = model.DiaChi;
                    myCommand.Parameters.Add(pDiachi);

                    SqlParameter pGhiChu = new SqlParameter("@MoTa", SqlDbType.NVarChar, 1000);
                    pGhiChu.Value = model.MoTa;
                    myCommand.Parameters.Add(pGhiChu);

                    SqlParameter pEmail = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
                    pEmail.Value = model.Email;
                    myCommand.Parameters.Add(pEmail);

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
        public bool update(NV_NhaDauTu_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_NhaDauTu_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.NVarChar, 100);
                    pID.Value = model.ID;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pTen = new SqlParameter("@Ten", SqlDbType.NVarChar, 200);
                    pTen.Value = model.Ten;
                    myCommand.Parameters.Add(pTen);

                    SqlParameter pSodienthoai = new SqlParameter("@DienThoai", SqlDbType.NVarChar, 50);
                    pSodienthoai.Value = model.DienThoai;
                    myCommand.Parameters.Add(pSodienthoai);

                    SqlParameter pDiachi = new SqlParameter("@DiaChi", SqlDbType.NVarChar, 200);
                    pDiachi.Value = model.DiaChi;
                    myCommand.Parameters.Add(pDiachi);

                    SqlParameter pGhiChu = new SqlParameter("@MoTa", SqlDbType.NVarChar, 1000);
                    pGhiChu.Value = model.MoTa;
                    myCommand.Parameters.Add(pGhiChu);

                    SqlParameter pEmail = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
                    pEmail.Value = model.Email;
                    myCommand.Parameters.Add(pEmail);


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
                using (SqlCommand myCommand = new SqlCommand("NV_NhaDauTu_del", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.VarChar, 10);
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
