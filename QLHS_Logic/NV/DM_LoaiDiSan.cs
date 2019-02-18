using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_DM_LoaiDiSan_ChiTiet
    {
        public int LoaiID { get; set; }
        public string MaLoai { get; set; }
        public string TenLoai { get; set; }
        public string Url { get; set; }
        public string GhiChu { get; set; }
        public int Stt { get; set; }
        public int ParentID { get; set; }
        public int Loai { get; set; }
        public string EngName { get; set; }
        public NV_DM_LoaiDiSan_ChiTiet() { }
        public NV_DM_LoaiDiSan_ChiTiet(DataRow dr)
        {
            LoaiID = int.Parse(dr["LoaiID"].ToString());
            MaLoai = dr["MaLoai"].ToString();
            TenLoai = dr["TenLoai"].ToString();
            Url = dr["Url"].ToString();
            try
            {
                ParentID = int.Parse(dr["ParentID"].ToString());
            }
            catch { }
            GhiChu = dr["GhiChu"].ToString();
            EngName = dr["EngName"].ToString();
            Stt = int.Parse(dr["Stt"].ToString());
            try
            {
                Loai = int.Parse(dr["Loai"].ToString());
            }
            catch { }
        }
    }

    public class NV_DM_LoaiDiSan
    {
        private string ConnectionString;
        public NV_DM_LoaiDiSan(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lấy theo ID
        public NV_DM_LoaiDiSan_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DM_LoaiDiSan_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@id", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    NV_DM_LoaiDiSan_ChiTiet model = new NV_DM_LoaiDiSan_ChiTiet();
                    DataTable dt;

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_DM_LoaiDiSan_ChiTiet(dt.Rows[0]);
                    }
                    return model;
                }
            }
        }
        #endregion
        
        #region Lấy theo url
        public NV_DM_LoaiDiSan_ChiTiet GetByUrl(string url)
        {

            string sql = "select * from DM_LoaiDiSan where Url='" + url + "'";
            DataTable dt = Sys_Common.getDataByQuery(sql);
            NV_DM_LoaiDiSan_ChiTiet model = new NV_DM_LoaiDiSan_ChiTiet();
            if (dt != null && dt.Rows.Count > 0)
            {
                model.LoaiID = int.Parse(dt.Rows[0]["LoaiID"].ToString());
                model.MaLoai = dt.Rows[0]["MaLoai"].ToString();
                model.TenLoai = dt.Rows[0]["TenLoai"].ToString();
                model.EngName = dt.Rows[0]["EngName"].ToString();
                try
                {
                    model.ParentID = int.Parse(dt.Rows[0]["ParentID"].ToString());
                }
                catch { }
                model.GhiChu = dt.Rows[0]["GhiChu"].ToString();
                model.Stt = int.Parse(dt.Rows[0]["Stt"].ToString());
            }
            return model;
        }
        #endregion
        #region Lấy tất cả
        public DataTable GetAll()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DM_LoaiDiSan_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_DM_LoaiDiSan_getAll");
                    return myDataSet.Tables["NV_DM_LoaiDiSan_getAll"];

                }
            }
        }

        #endregion
        #region Lấy theo loai vật thể và phi vật thể
        public DataTable getByLoai(int loai)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DM_LoaiDiSan_getByLoai", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@Loai", SqlDbType.Bit);
                    pID.Value = loai;
                    myCommand.Parameters.Add(pID);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_LoaiDiSan_getByLoai");
                    return myDataSet.Tables["NV_LoaiDiSan_getByLoai"];

                }
            }
        }
        public NV_DM_LoaiDiSan_ChiTiet getByLoai_Parent(int loai)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DM_LoaiDiSan_getByLoai_Parent", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@Loai", SqlDbType.Bit);
                    pID.Value = loai;
                    myCommand.Parameters.Add(pID);

                    NV_DM_LoaiDiSan_ChiTiet model = new NV_DM_LoaiDiSan_ChiTiet();
                    DataTable dt;

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_DM_LoaiDiSan_ChiTiet(dt.Rows[0]);
                    }
                    return model;

                }
            }
        }
        #endregion
        #region Lấy đổ combo
        public DataTable getDataCombo(string lang="vi")
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_LoaiDiSan_getCombo", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pLang = new SqlParameter("@Lang", SqlDbType.VarChar);
                    pLang.Value = lang;
                    myCommand.Parameters.Add(pLang);


                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_LoaiDiSan_getCombo");
                    return myDataSet.Tables["NV_LoaiDiSan_getCombo"];

                }
            }
        }

        #endregion
        #region Thêm
        public bool them(NV_DM_LoaiDiSan_ChiTiet model,out int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DM_LoaiDiSan_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@LoaiID", SqlDbType.Int);
                    pID.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pMaLoai = new SqlParameter("@MaLoai", SqlDbType.NVarChar, 50);
                    pMaLoai.Value = model.MaLoai;
                    myCommand.Parameters.Add(pMaLoai);

                    SqlParameter pTenLoai = new SqlParameter("@TenLoai", SqlDbType.NVarChar, 300);
                    pTenLoai.Value = model.TenLoai;
                    myCommand.Parameters.Add(pTenLoai);

                    SqlParameter pParentID = new SqlParameter("@ParentID", SqlDbType.Int);
                    pParentID.Value = model.ParentID;
                    myCommand.Parameters.Add(pParentID);

                    SqlParameter pGhichu = new SqlParameter("@Ghichu", SqlDbType.NVarChar, 500);
                    pGhichu.Value = model.GhiChu;
                    myCommand.Parameters.Add(pGhichu);

                    SqlParameter pStt = new SqlParameter("@Stt", SqlDbType.Int);
                    pStt.Value = model.Stt;
                    myCommand.Parameters.Add(pStt);

                    SqlParameter pLoai = new SqlParameter("@Loai", SqlDbType.Int);
                    pLoai.Value = model.Loai;
                    myCommand.Parameters.Add(pLoai);

                    SqlParameter pEngName = new SqlParameter("@EngName", SqlDbType.NVarChar, 300);
                    pEngName.Value = model.EngName;
                    myCommand.Parameters.Add(pEngName);

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
        public bool update(NV_DM_LoaiDiSan_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_DM_LoaiDiSan_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@LoaiID", SqlDbType.Int);
                    pID.Value = model.LoaiID;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pMaLoai = new SqlParameter("@MaLoai", SqlDbType.NVarChar, 50);
                    pMaLoai.Value = model.MaLoai;
                    myCommand.Parameters.Add(pMaLoai);

                    SqlParameter pTenLoai = new SqlParameter("@TenLoai", SqlDbType.NVarChar, 300);
                    pTenLoai.Value = model.TenLoai;
                    myCommand.Parameters.Add(pTenLoai);

                    SqlParameter pParentID = new SqlParameter("@ParentID", SqlDbType.Int);
                    pParentID.Value = model.ParentID;
                    myCommand.Parameters.Add(pParentID);

                    SqlParameter pGhichu = new SqlParameter("@Ghichu", SqlDbType.NVarChar, 500);
                    pGhichu.Value = model.GhiChu;
                    myCommand.Parameters.Add(pGhichu);

                    SqlParameter pStt = new SqlParameter("@Stt", SqlDbType.Int);
                    pStt.Value = model.Stt;
                    myCommand.Parameters.Add(pStt);

                    SqlParameter pLoai = new SqlParameter("@Loai", SqlDbType.Int);
                    pLoai.Value = model.Loai;
                    myCommand.Parameters.Add(pLoai);

                    SqlParameter pEngName = new SqlParameter("@EngName", SqlDbType.NVarChar, 300);
                    pEngName.Value = model.EngName;
                    myCommand.Parameters.Add(pEngName);
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
                using (SqlCommand myCommand = new SqlCommand("NV_DM_LoaiDiSan_del", myConnection))
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
        #region Lấy tất cả con
        public DataTable GetChild(string ma)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("getChild", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@id", SqlDbType.NVarChar, 30);
                    pID.Value = ma;
                    myCommand.Parameters.Add(pID);
                    DataTable dt;
                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    return dt;
                }
            }
        }
        public string GetStringChild(string ma)
        {
            string arr = "";
            DataTable dt = GetChild(ma);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    arr += row["LoaiID"].ToString() + ",";
                }
                arr = arr.Substring(0, arr.Length - 1);
            }
            return arr;
        }
        #endregion
        #region Lấy theo danh muc cha
        public DataTable GetByParent(string pID)
        {
            string sql = "select LoaiID,MaLoai,TenLoai,ParentID,Stt from DM_LoaiDiSan where ParentID=" + pID + " order by Stt";
            DataTable dt = Sys_Common.getDataByQuery(sql);
            return dt;
        }
        #endregion
        #region tạo số thứ tự
        public int taoStt(int stt, int pID)
        {
            string sql = "select Stt from DM_LoaiDisan where ParentID=" + pID + " order by Stt";
            DataTable dt = Sys_Common.getDataByQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["Stt"].ToString().Equals("1"))
                {
                    dt.Rows[0]["Stt"] = "2";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //if(dt.Rows[""])
                    }
                }

            }
            return 1;
        }

        public int taoStt(string stt, int pID)
        {
            int index = 1;
            int.TryParse(stt, out index);
            return index;
        }
        #endregion
    }
}
