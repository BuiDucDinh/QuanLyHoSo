using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_Menu_ChiTiet
    {
        public int MenuID { get; set; }
        public string TenMenu { get; set; }
        public int ChucNangID { get; set; }
        public string Url { get; set; }
        public string TenUrl { get; set; }
        public bool Duyet { get; set; }
        public bool NoiBat { get; set; }
        public int Stt { get; set; }
        public int ParentID { get; set; }
        public string PageTitle { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public string Mota { get; set; }
        public int HinhAnh { get; set; }
        public int Vitri { get; set; }
        public int Level { get; set; }
        public string UrlFull { get; set; }
        public string Lang { get; set; }
        public NV_Menu_ChiTiet() { }
        public NV_Menu_ChiTiet(DataTable dt)
        {
            MenuID = int.Parse(dt.Rows[0]["MenuID"].ToString());
            TenMenu = dt.Rows[0]["TenMenu"].ToString();
            ChucNangID = int.Parse(dt.Rows[0]["ChucNangID"].ToString());
            Url = dt.Rows[0]["Url"].ToString();
            TenUrl = dt.Rows[0]["TenUrl"].ToString();
            Duyet = Convert.ToBoolean(dt.Rows[0]["Duyet"].ToString());
            NoiBat = Convert.ToBoolean(dt.Rows[0]["NoiBat"].ToString());
            Stt = int.Parse(dt.Rows[0]["Stt"].ToString());
            ParentID = int.Parse(dt.Rows[0]["ParentID"].ToString());
            Level = int.Parse(dt.Rows[0]["Level"].ToString());
            Vitri = int.Parse(dt.Rows[0]["Vitri"].ToString());
            PageTitle = dt.Rows[0]["PageTitle"].ToString();
            MetaKeyword = dt.Rows[0]["MetaKeyword"].ToString();
            MetaDescription = dt.Rows[0]["MetaDescription"].ToString();
            Mota = dt.Rows[0]["Mota"].ToString();
            HinhAnh = int.Parse(dt.Rows[0]["HinhAnh"].ToString());
            UrlFull = !string.IsNullOrEmpty(Url) ? Url : dt.Rows[0]["UrlFull"].ToString();
            Lang = dt.Rows[0]["Lang"].ToString();
        }
    }
    public class NV_Menu
    {
        private string ConnectionString;
        public NV_Menu(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region lấy level menu
        public int getLevel(int menuCha)
        {
            try
            {
                NV_Menu_ChiTiet ct = GetById(menuCha);
                return ct.Level + 1;
            }
            catch
            {
                return 1;
            }
        }
        #endregion

        #region Lấy theo ID
        public NV_Menu_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_Menu_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@id", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    DataTable dt;
                    NV_Menu_ChiTiet model = new NV_Menu_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_Menu_ChiTiet(dt);
                    }
                    return model;
                }
            }
        }
        #endregion
        #region Lấy theo url
        public NV_Menu_ChiTiet GetByUrl(string url)
        {
            string sql = "select top 1 *,dbo.getUrl(MenuID,'Menu',null) as UrlFull from Menu where Duyet=1 and TenUrl='" + url + "'";
            DataTable dt = Sys_Common.getDataByQuery(sql);
            NV_Menu_ChiTiet menu = new NV_Menu_ChiTiet();
            if (dt != null && dt.Rows.Count > 0)
            {
                menu = new NV_Menu_ChiTiet(dt);
            }
            return menu;
        }
        #endregion
        #region Lấy tất cả
        public DataTable GetAll(string lang = "vi")
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_Menu_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pLang = new SqlParameter("@Lang", SqlDbType.VarChar);
                    pLang.Value = lang;
                    myCommand.Parameters.Add(pLang);

                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_Menu_getAll");
                    return myDataSet.Tables["NV_Menu_getAll"];

                }
            }
        }

        #endregion
        #region Lấy theo frameview
        public DataTable GetByFrame(int frame)
        {
            string sql = "select * from Menu where Duyet=1 and FrameViewID=" + frame;
            DataTable dt = Sys_Common.getDataByQuery(sql);
            return dt;
        }
        #endregion
        #region Thêm
        public bool them(NV_Menu_ChiTiet model, out int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_Menu_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pID = new SqlParameter("@MenuID", SqlDbType.Int);
                    pID.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pTenMenu = new SqlParameter("@TenMenu", SqlDbType.NVarChar, 250);
                    pTenMenu.Value = model.TenMenu;
                    myCommand.Parameters.Add(pTenMenu);

                    SqlParameter pFrameViewID = new SqlParameter("@ChucNangID", SqlDbType.Int);
                    pFrameViewID.Value = model.ChucNangID;
                    myCommand.Parameters.Add(pFrameViewID);

                    SqlParameter pUrl = new SqlParameter("@Url", SqlDbType.NVarChar, 250);
                    pUrl.Value = model.Url;
                    myCommand.Parameters.Add(pUrl);

                    SqlParameter pTenUrl = new SqlParameter("@TenUrl", SqlDbType.NVarChar, 250);
                    pTenUrl.Value = model.TenUrl;
                    myCommand.Parameters.Add(pTenUrl);

                    SqlParameter pDuyet = new SqlParameter("@Duyet", SqlDbType.Bit);
                    pDuyet.Value = model.Duyet;
                    myCommand.Parameters.Add(pDuyet);

                    SqlParameter pNoiBat = new SqlParameter("@NoiBat", SqlDbType.Bit);
                    pNoiBat.Value = model.NoiBat;
                    myCommand.Parameters.Add(pNoiBat);

                    SqlParameter pStt = new SqlParameter("@Stt", SqlDbType.Int);
                    pStt.Value = model.Stt;
                    myCommand.Parameters.Add(pStt);

                    SqlParameter pVitri = new SqlParameter("@Vitri", SqlDbType.Int);
                    pVitri.Value = model.Vitri;
                    myCommand.Parameters.Add(pVitri);

                    SqlParameter pLevel = new SqlParameter("@Level", SqlDbType.Int);
                    pLevel.Value = model.Level;
                    myCommand.Parameters.Add(pLevel);

                    SqlParameter pParentID = new SqlParameter("@ParentID", SqlDbType.Int);
                    pParentID.Value = model.ParentID;
                    myCommand.Parameters.Add(pParentID);

                    SqlParameter pPageTitle = new SqlParameter("@PageTitle", SqlDbType.NVarChar, 200);
                    pPageTitle.Value = model.PageTitle;
                    myCommand.Parameters.Add(pPageTitle);

                    SqlParameter pMetaKeyword = new SqlParameter("@MetaKeyword", SqlDbType.NVarChar, 200);
                    pMetaKeyword.Value = model.MetaKeyword;
                    myCommand.Parameters.Add(pMetaKeyword);

                    SqlParameter pMetaDescription = new SqlParameter("@MetaDescription", SqlDbType.NVarChar, 300);
                    pMetaDescription.Value = model.MetaDescription;
                    myCommand.Parameters.Add(pMetaDescription);

                    SqlParameter pMota = new SqlParameter("@Mota", SqlDbType.NVarChar, 300);
                    pMota.Value = model.Mota;
                    myCommand.Parameters.Add(pMota);

                    SqlParameter pHinhAnh = new SqlParameter("@HinhAnh", SqlDbType.Int, 300);
                    pHinhAnh.Value = model.HinhAnh;
                    myCommand.Parameters.Add(pHinhAnh);


                    SqlParameter pLang = new SqlParameter("@Lang", SqlDbType.VarChar);
                    pLang.Value = model.Lang;
                    myCommand.Parameters.Add(pLang);


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
        public bool update(NV_Menu_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_Menu_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@MenuID", SqlDbType.Int);
                    pID.Value = model.MenuID;
                    myCommand.Parameters.Add(pID);

                    SqlParameter pTenMenu = new SqlParameter("@TenMenu", SqlDbType.NVarChar, 250);
                    pTenMenu.Value = model.TenMenu;
                    myCommand.Parameters.Add(pTenMenu);

                    SqlParameter pFrameViewID = new SqlParameter("@ChucNangID", SqlDbType.Int);
                    pFrameViewID.Value = model.ChucNangID;
                    myCommand.Parameters.Add(pFrameViewID);

                    SqlParameter pUrl = new SqlParameter("@Url", SqlDbType.NVarChar, 250);
                    pUrl.Value = model.Url;
                    myCommand.Parameters.Add(pUrl);

                    SqlParameter pTenUrl = new SqlParameter("@TenUrl", SqlDbType.NVarChar, 250);
                    pTenUrl.Value = model.TenUrl;
                    myCommand.Parameters.Add(pTenUrl);

                    SqlParameter pDuyet = new SqlParameter("@Duyet", SqlDbType.Bit);
                    pDuyet.Value = model.Duyet;
                    myCommand.Parameters.Add(pDuyet);

                    SqlParameter pNoiBat = new SqlParameter("@NoiBat", SqlDbType.Bit);
                    pNoiBat.Value = model.NoiBat;
                    myCommand.Parameters.Add(pNoiBat);

                    SqlParameter pStt = new SqlParameter("@Stt", SqlDbType.Int);
                    pStt.Value = model.Stt;
                    myCommand.Parameters.Add(pStt);

                    SqlParameter pVitri = new SqlParameter("@Vitri", SqlDbType.Int);
                    pVitri.Value = model.Vitri;
                    myCommand.Parameters.Add(pVitri);

                    SqlParameter pLevel = new SqlParameter("@Level", SqlDbType.Int);
                    pLevel.Value = model.Level;
                    myCommand.Parameters.Add(pLevel);

                    SqlParameter pParentID = new SqlParameter("@ParentID", SqlDbType.Int);
                    pParentID.Value = model.ParentID;
                    myCommand.Parameters.Add(pParentID);

                    SqlParameter pPageTitle = new SqlParameter("@PageTitle", SqlDbType.NVarChar, 200);
                    pPageTitle.Value = model.PageTitle;
                    myCommand.Parameters.Add(pPageTitle);

                    SqlParameter pMetaKeyword = new SqlParameter("@MetaKeyword", SqlDbType.NVarChar, 200);
                    pMetaKeyword.Value = model.MetaKeyword;
                    myCommand.Parameters.Add(pMetaKeyword);

                    SqlParameter pMetaDescription = new SqlParameter("@MetaDescription", SqlDbType.NVarChar, 300);
                    pMetaDescription.Value = model.MetaDescription;
                    myCommand.Parameters.Add(pMetaDescription);

                    SqlParameter pMota = new SqlParameter("@Mota", SqlDbType.NVarChar, 300);
                    pMota.Value = model.Mota;
                    myCommand.Parameters.Add(pMota);

                    SqlParameter pHinhAnh = new SqlParameter("@HinhAnh", SqlDbType.Int, 300);
                    pHinhAnh.Value = model.HinhAnh;
                    myCommand.Parameters.Add(pHinhAnh);

                    SqlParameter pLang = new SqlParameter("@Lang", SqlDbType.VarChar);
                    pLang.Value = model.Lang;
                    myCommand.Parameters.Add(pLang);


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
                using (SqlCommand myCommand = new SqlCommand("NV_Menu_del", myConnection))
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
        #region Lấy theo danh mục cha
        public DataTable GetByParent(string p, string vitri, string lang = "vi")
        {
            string sql = "select MenuID,TenMenu,dbo.getUrl(MenuID,'Menu',null) as url,ChucNangID from Menu where Duyet=1 and Vitri =" + vitri + " and ParentID=" + p + " and Lang='" + lang + "' order by Stt";
            DataTable dt = Sys_Common.getDataByQuery(sql);
            return dt;
        }
        #endregion

        #region Lấy theo vị trí hiển thị
        public DataTable GetByPosition(string p, string lang = "vi")
        {
            string sql = "select * from Menu where Vitri=" + p + " and Lang='" + lang + "'";
            DataTable dt = Sys_Common.getDataByQuery(sql);
            return dt;
        }
        #endregion

    }
}
