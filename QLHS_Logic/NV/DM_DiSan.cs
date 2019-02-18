using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using QLHS_Logic;
namespace QLHS_Logic.NV
{
    public class NV_DM_DiSan_ChiTiet
    {
        public int DanhMucID { get; set; }
        public string TenDanhMuc { get; set; }
        public string EngName { get; set; }
        public string HinhAnh { get; set; }
        public string Url { get; set; }

    }
    public class NV_DM_DiSan
    {
        private string ConnectionString;
        public NV_DM_DiSan(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }

        #region Lấy tất cả
        public DataTable GetAll(string lang="vi")
        {
            string ten = lang == "vi" ? "TenDanhMuc" : "EngName";
            string sql = "select DanhMucID," + ten + " as TenDanhMuc,EngName,(select TenAnh from Image i where i.ImageID=d.HinhAnh) as HinhAnh,dbo.getUrl(DanhMucID,'DM_DiSan',null) as url from DM_DiSan d";
            DataTable dt = Sys_Common.getDataByQuery(sql);
            return dt;
        }

        #endregion

        #region Lấy theo url
        public NV_DM_DiSan_ChiTiet GetByUrl(string url)
        {
            string sql = "select DanhMucID,TenDanhMuc,EngName,(select TenAnh from Image i where i.ImageID=d.HinhAnh) as HinhAnh,dbo.getUrl(DanhMucID,'DM_DiSan',null) as url from DM_DiSan d where d.Url='" + url + "'";
            DataTable dt = Sys_Common.getDataByQuery(sql);
            NV_DM_DiSan_ChiTiet dm = new NV_DM_DiSan_ChiTiet();
            if (dt != null && dt.Rows.Count > 0)
            {
                dm.DanhMucID = int.Parse(dt.Rows[0]["DanhMucID"].ToString());
                dm.TenDanhMuc = dt.Rows[0]["TenDanhMuc"].ToString();
                dm.EngName = dt.Rows[0]["EngName"].ToString();
                dm.Url = dt.Rows[0]["url"].ToString();
                dm.HinhAnh = dt.Rows[0]["HinhAnh"].ToString();
            }
            return dm;
        }

        #endregion
    }
}
