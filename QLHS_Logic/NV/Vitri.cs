using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_Vitri_ChiTiet
    {
        public int FrameViewID { get; set; }
        public string ChucNang { get; set; }
        public bool Duyet { get; set; }
    }
    public class NV_Vitri
    {
        private string ConnectionString;
        public NV_Vitri(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }

        public DataTable GetAll()
        {
            string sql = "select * from VitriMenu";
            DataTable dt = Sys_Common.getDataByQuery(sql);
            return dt;
        }


    }
}
