using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_DiaDanh_ChiTiet
    {
        public int DiaDanhID { get; set; }
        public string MaDiaDanh { get; set; }

        public string TenDiaDanh { get; set; }

        public string TenGoiKhac { get; set; }
        public string ThuocTinh { get; set; }

        public string ThuocHuyen { get; set; }
        public string ThuocXa { get; set; }

        public int Stt { get; set; }
    }

    public class NV_DiaDanh
    {
        private string ConnectionString;
        public NV_DiaDanh(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lấy theo ID
        public NV_DiaDanh_ChiTiet GetById(int id)
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
                    NV_DiaDanh_ChiTiet model = new NV_DiaDanh_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model.MaDiaDanh = dt.Rows[0]["MaDiaDanh"].ToString();
                        model.TenDiaDanh = dt.Rows[0]["TenDiaDanh"].ToString();
                        model.TenGoiKhac = dt.Rows[0]["TenGoiKhac"].ToString();
                        model.ThuocTinh = dt.Rows[0]["ThuocTinh"].ToString();
                        model.ThuocHuyen = dt.Rows[0]["ThuocHuyen"].ToString();
                        model.ThuocXa = dt.Rows[0]["ThuocXa"].ToString();
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
                using (SqlCommand myCommand = new SqlCommand("NV_DiaDanh_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_DiaDanh_getAll");
                    return myDataSet.Tables["NV_DiaDanh_getAll"];

                }
            }
        }

        #endregion
        #region Thêm

        public bool them(NV_DiaDanh_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DangKyDiSan_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMadiadanh = new SqlParameter("@MaDiaDanh", SqlDbType.NVarChar, 50);
                    pMadiadanh.Value = model.MaDiaDanh;
                    myCommand.Parameters.Add(pMadiadanh);

                    SqlParameter pTendiadanh = new SqlParameter("@TenDiadanh", SqlDbType.NVarChar, 250);
                    pTendiadanh.Value = model.TenDiaDanh;
                    myCommand.Parameters.Add(pTendiadanh);

                    SqlParameter pTengoikhac = new SqlParameter("@TenGoiKhac", SqlDbType.NVarChar, 250);
                    pTengoikhac.Value = model.TenGoiKhac;
                    myCommand.Parameters.Add(pTengoikhac);

                    SqlParameter pThuocTinh = new SqlParameter("@ThuocTinh", SqlDbType.VarChar,10);
                    pThuocTinh.Value = model.ThuocTinh;
                    myCommand.Parameters.Add(pThuocTinh);

                    SqlParameter pThuochuyen = new SqlParameter("@ThuocHuyen", SqlDbType.VarChar,10);
                    pThuochuyen.Value = model.ThuocHuyen;
                    myCommand.Parameters.Add(pThuochuyen);

                    SqlParameter pThuocxa = new SqlParameter("@ThuocXa", SqlDbType.VarChar,10);
                    pThuocxa.Value = model.ThuocXa;
                    myCommand.Parameters.Add(pThuocxa);

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
        public bool Update(NV_DiaDanh_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DangKyDiSan_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@DiaDanhID", SqlDbType.Int);
                    pID.Value = model.DiaDanhID;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pMadiadanh = new SqlParameter("@MaDiaDanh", SqlDbType.NVarChar, 50);
                    pMadiadanh.Value = model.MaDiaDanh;
                    myCommand.Parameters.Add(pMadiadanh);

                    SqlParameter pTendiadanh = new SqlParameter("@TenDiadanh", SqlDbType.NVarChar, 250);
                    pTendiadanh.Value = model.TenDiaDanh;
                    myCommand.Parameters.Add(pTendiadanh);

                    SqlParameter pTengoikhac = new SqlParameter("@TenGoiKhac", SqlDbType.NVarChar, 250);
                    pTengoikhac.Value = model.TenGoiKhac;
                    myCommand.Parameters.Add(pTengoikhac);

                    SqlParameter pThuocTinh = new SqlParameter("@ThuocTinh", SqlDbType.VarChar,10);
                    pThuocTinh.Value = model.ThuocTinh;
                    myCommand.Parameters.Add(pThuocTinh);

                    SqlParameter pThuochuyen = new SqlParameter("@ThuocHuyen", SqlDbType.VarChar,10);
                    pThuochuyen.Value = model.ThuocHuyen;
                    myCommand.Parameters.Add(pThuochuyen);

                    SqlParameter pThuocxa = new SqlParameter("@ThuocXa", SqlDbType.VarChar,10);
                    pThuocxa.Value = model.ThuocXa;
                    myCommand.Parameters.Add(pThuocxa);

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
                using (SqlCommand myCommand = new SqlCommand("NV_DiaDanh_del", myConnection))
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
