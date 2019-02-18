using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_ChucNang_ChiTiet
    {
        public int FrameViewID { get; set; }
        public string ChucNang { get; set; }
        public bool Duyet { get; set; }
    }
    public class NV_ChucNang
    {
        private string ConnectionString;
        public NV_ChucNang(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }

        #region Lấy tất cả Frame đc duyệt
        public DataTable GetAll()
        {
            string sql = "select * from FrameView where Duyet=1";
            DataTable dt = Sys_Common.getDataByQuery(sql);
            return dt;
        }
        #endregion


    }
}
