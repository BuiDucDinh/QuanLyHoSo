using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_Log_ChiTiet
    {
        public int ID { get; set; }
        public int MaND { get; set; }
        public string MaForm { get; set; }
        public string ThaoTac { get; set; }
        public int IDBanGhi { get; set; }
        public DateTime NgayThaoTac { get; set; }
        public string File { get; set; }
        public NV_Log_ChiTiet(int maND,string maForm)
        {
            NgayThaoTac = DateTime.Now;
            MaND = maND;
            MaForm = maForm;
        }
        public NV_Log_ChiTiet() { }
    }
    public class NV_Log
    {
        private string ConnectionString;
        public NV_Log(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Thêm
        public bool them(NV_Log_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_Log_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMaND = new SqlParameter("@MaND", SqlDbType.Int);
                    pMaND.Value = model.MaND;
                    myCommand.Parameters.Add(pMaND);

                    SqlParameter pTenBang = new SqlParameter("@MaForm", SqlDbType.VarChar, 50);
                    pTenBang.Value = model.MaForm;
                    myCommand.Parameters.Add(pTenBang);

                    SqlParameter pThaoTac = new SqlParameter("@ThaoTac", SqlDbType.VarChar,20);
                    pThaoTac.Value = model.ThaoTac;
                    myCommand.Parameters.Add(pThaoTac);

                    SqlParameter pIDBanGhi = new SqlParameter("@IDBanGhi", SqlDbType.Int);
                    pIDBanGhi.Value = model.IDBanGhi;
                    myCommand.Parameters.Add(pIDBanGhi);

                    SqlParameter pNgayThaoTac = new SqlParameter("@NgayThaoTac", SqlDbType.DateTime);
                    pNgayThaoTac.Value = model.NgayThaoTac;
                    myCommand.Parameters.Add(pNgayThaoTac);

                    SqlParameter pFile = new SqlParameter("@File", SqlDbType.NVarChar, 200);
                    pFile.Value = model.File;
                    myCommand.Parameters.Add(pFile);

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
                using (SqlCommand myCommand = new SqlCommand("NV_Log_del", myConnection))
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
