using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_LoaiBaoTang_ChiTiet
    {
        public int ID { get; set; }
        public string TenLoai { get; set; }
    }
    public class NV_LoaiBaoTang
    {
        private string ConnectionString;
        public NV_LoaiBaoTang(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }

        #region Lấy tất cả
        public DataTable GetAll()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_LoaiBaoTang_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_LoaiBaoTang_getAll");
                    return myDataSet.Tables["NV_LoaiBaoTang_getAll"];

                }
            }
        }

        #endregion
    }
}
