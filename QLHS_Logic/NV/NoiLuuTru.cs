using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_NoiLuuTru_ChiTiet
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public string EngName { get; set; }
        public string ThuocTinh { get; set; }
        public string ThuocHuyen { get; set; }
        public string ThuocXa { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string MoTa { get; set; }
        public string DiaChiCuThe { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public int AnhDaiDien { get; set; }
        public string Url { get; set; }
        public int LoaiBaoTang { get; set; }
        public string TenLoaiBaoTang { get; set; }
        public NV_NoiLuuTru_ChiTiet() { }
        public NV_NoiLuuTru_ChiTiet(DataRow dr)
        {
            ID = int.Parse(dr["ID"].ToString());
            Ten = dr["Ten"].ToString();
            EngName = dr["EngName"].ToString();
            ThuocTinh = dr["ThuocTinh"].ToString();
            ThuocHuyen = dr["ThuocHuyen"].ToString();
            ThuocXa = dr["ThuocXa"].ToString();
            DienThoai = dr["DienThoai"].ToString();
            Email = dr["Email"].ToString();
            DiaChi = dr["DiaChi"].ToString();
            MoTa = dr["MoTa"].ToString();
            DiaChiCuThe = dr["DiaChiCuThe"].ToString();
            Website = dr["Website"].ToString();
            Fax = dr["Fax"].ToString();
            try
            {
                AnhDaiDien = int.Parse(dr["AnhDaiDien"].ToString());
            }
            catch
            {
                AnhDaiDien = 0;
            }
            Url = dr["Url"].ToString();
            LoaiBaoTang = int.Parse(dr["LoaiBaoTang"].ToString());
            TenLoaiBaoTang = dr["TenLoaiBaoTang"].ToString();
        }
    }
    public class NV_NoiLuuTru
    {
        private string ConnectionString;
        public NV_NoiLuuTru(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lấy theo ID
        public NV_NoiLuuTru_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_NoiLuuTru_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    DataTable dt;
                    NV_NoiLuuTru_ChiTiet model = new NV_NoiLuuTru_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_NoiLuuTru_ChiTiet(dt.Rows[0]);
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
                using (SqlCommand myCommand = new SqlCommand("NV_NoiLuuTru_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_NoiLuuTru_getAll");
                    return myDataSet.Tables["NV_NoiLuuTru_getAll"];

                }
            }
        }

        #endregion
        #region Thêm
        public bool them(NV_NoiLuuTru_ChiTiet model, out int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_NoiLuuTru_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pTen = new SqlParameter("@Ten", SqlDbType.NVarChar, 200);
                    pTen.Value = model.Ten;
                    myCommand.Parameters.Add(pTen);

                    SqlParameter pEngName = new SqlParameter("@EngName", SqlDbType.NVarChar, 200);
                    pEngName.Value = model.EngName;
                    myCommand.Parameters.Add(pEngName);

                    SqlParameter pThuocTinh = new SqlParameter("@ThuocTinh", SqlDbType.VarChar, 10);
                    pThuocTinh.Value = model.ThuocTinh;
                    myCommand.Parameters.Add(pThuocTinh);

                    SqlParameter pThuocHuyen = new SqlParameter("@ThuocHuyen", SqlDbType.VarChar, 10);
                    pThuocHuyen.Value = model.ThuocHuyen;
                    myCommand.Parameters.Add(pThuocHuyen);

                    SqlParameter pThuocXa = new SqlParameter("@ThuocXa", SqlDbType.VarChar, 10);
                    pThuocXa.Value = model.ThuocXa;
                    myCommand.Parameters.Add(pThuocXa);

                    SqlParameter pDienThoai = new SqlParameter("@DienThoai", SqlDbType.NVarChar, 50);
                    pDienThoai.Value = model.DienThoai;
                    myCommand.Parameters.Add(pDienThoai);

                    SqlParameter pFax = new SqlParameter("@Fax", SqlDbType.NVarChar, 50);
                    pFax.Value = model.Fax;
                    myCommand.Parameters.Add(pFax);

                    SqlParameter pWebsite = new SqlParameter("@Website", SqlDbType.NVarChar, 200);
                    pWebsite.Value = model.Website;
                    myCommand.Parameters.Add(pWebsite);

                    SqlParameter pDiaChiCuThe = new SqlParameter("@DiaChiCuThe", SqlDbType.NVarChar, 200);
                    pDiaChiCuThe.Value = model.DiaChiCuThe;
                    myCommand.Parameters.Add(pDiaChiCuThe);

                    SqlParameter pEmail = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
                    pEmail.Value = model.Email;
                    myCommand.Parameters.Add(pEmail);

                    SqlParameter pAnhDaiDien = new SqlParameter("@AnhDaiDien", SqlDbType.Int);
                    pAnhDaiDien.Value = model.AnhDaiDien;
                    myCommand.Parameters.Add(pAnhDaiDien);
                    SqlParameter pMoTa = new SqlParameter("@MoTa", SqlDbType.NVarChar, 2000);
                    pMoTa.Value = model.MoTa;
                    myCommand.Parameters.Add(pMoTa);

                    SqlParameter pUrl = new SqlParameter("@Url", SqlDbType.NVarChar, 200);
                    pUrl.Value = model.Url;
                    myCommand.Parameters.Add(pUrl);
                    SqlParameter pLoaiBaoTang = new SqlParameter("@LoaiBaoTang", SqlDbType.Int);
                    pLoaiBaoTang.Value = model.LoaiBaoTang;
                    myCommand.Parameters.Add(pLoaiBaoTang);

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
        public bool update(NV_NoiLuuTru_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_NoiLuuTru_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = model.ID;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pTen = new SqlParameter("@Ten", SqlDbType.NVarChar, 200);
                    pTen.Value = model.Ten;
                    myCommand.Parameters.Add(pTen);


                    SqlParameter pEngName = new SqlParameter("@EngName", SqlDbType.NVarChar, 200);
                    pEngName.Value = model.EngName;
                    myCommand.Parameters.Add(pEngName);

                    SqlParameter pThuocTinh = new SqlParameter("@ThuocTinh", SqlDbType.VarChar, 10);
                    pThuocTinh.Value = model.ThuocTinh;
                    myCommand.Parameters.Add(pThuocTinh);

                    SqlParameter pThuocHuyen = new SqlParameter("@ThuocHuyen", SqlDbType.VarChar, 10);
                    pThuocHuyen.Value = model.ThuocHuyen;
                    myCommand.Parameters.Add(pThuocHuyen);

                    SqlParameter pThuocXa = new SqlParameter("@ThuocXa", SqlDbType.VarChar, 10);
                    pThuocXa.Value = model.ThuocXa;
                    myCommand.Parameters.Add(pThuocXa);

                    SqlParameter pDienThoai = new SqlParameter("@DienThoai", SqlDbType.NVarChar, 50);
                    pDienThoai.Value = model.DienThoai;
                    myCommand.Parameters.Add(pDienThoai);

                    SqlParameter pFax = new SqlParameter("@Fax", SqlDbType.NVarChar, 50);
                    pFax.Value = model.Fax;
                    myCommand.Parameters.Add(pFax);

                    SqlParameter pWebsite = new SqlParameter("@Website", SqlDbType.NVarChar, 200);
                    pWebsite.Value = model.Website;
                    myCommand.Parameters.Add(pWebsite);

                    SqlParameter pDiaChiCuThe = new SqlParameter("@DiaChiCuThe", SqlDbType.NVarChar, 200);
                    pDiaChiCuThe.Value = model.DiaChiCuThe;
                    myCommand.Parameters.Add(pDiaChiCuThe);

                    SqlParameter pEmail = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
                    pEmail.Value = model.Email;
                    myCommand.Parameters.Add(pEmail);

                    SqlParameter pAnhDaiDien = new SqlParameter("@AnhDaiDien", SqlDbType.Int);
                    pAnhDaiDien.Value = model.AnhDaiDien;
                    myCommand.Parameters.Add(pAnhDaiDien);
                    SqlParameter pMoTa = new SqlParameter("@MoTa", SqlDbType.NVarChar, 2000);
                    pMoTa.Value = model.MoTa;
                    myCommand.Parameters.Add(pMoTa);

                    SqlParameter pUrl = new SqlParameter("@Url", SqlDbType.NVarChar, 200);
                    pUrl.Value = model.Url;
                    myCommand.Parameters.Add(pUrl);

                    SqlParameter pLoaiBaoTang = new SqlParameter("@LoaiBaoTang", SqlDbType.Int);
                    pLoaiBaoTang.Value = model.LoaiBaoTang;
                    myCommand.Parameters.Add(pLoaiBaoTang);
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
                using (SqlCommand myCommand = new SqlCommand("NV_NoiLuuTru_del", myConnection))
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
