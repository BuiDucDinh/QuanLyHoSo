using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_DanhHieuNgheNhan_ChiTiet
    {
        public int ID { get; set; }
        public string TenDanhHieu { get; set; }
        public string GhiChu { get; set; }
    }
    public class NV_DanhHieuNgheNhan
    {
        private string ConnectionString;
        public NV_DanhHieuNgheNhan(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }

        #region Lấy tất cả 
        public DataTable GetAll()
        {
            string sql = "select * from DanhHieuNgheNhan";
            DataTable dt = Sys_Common.getDataByQuery(sql);
            return dt;
        }
        #endregion


    }
}
