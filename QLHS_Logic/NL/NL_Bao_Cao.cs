using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{

    #region NL_Bao_Cao
    public class NL_Bao_Cao
    {
        public string ConnectionString;
        public NL_Bao_Cao(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }

        /// <summary>
        /// Params: string pstrSQl
        /// Purpose: get Records from SQL string to Datatable
        /// </summary>
        public DataTable GetDataTable(string pstrSQL)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection SQLconn = new SqlConnection(ConnectionString);
            DataTable rsData = new DataTable();
            SqlDataAdapter adpAdapter = new SqlDataAdapter();

            try
            {
                SQLconn.Open();
                cmd.Connection = SQLconn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = pstrSQL;
                cmd.CommandTimeout = 30000;

                adpAdapter.SelectCommand = cmd;
                adpAdapter.Fill(rsData);

                cmd.Dispose();
                SQLconn.Close();
                SQLconn.Dispose();
                adpAdapter.Dispose();
                return rsData;
            }
            catch (Exception exp)
            {
                cmd.Dispose();
                SQLconn.Close();
                SQLconn.Dispose();
                adpAdapter.Dispose();
                string strErr = exp.Message;
                return null;
            }
        }

        /// <summary>
        /// Params: string pstrSQl
        /// Purpose: get Records from SQL string to Datatable, export to excel
        /// </summary>
        public DataTable GetDataTable_Export(string pstrSQL, string sNameDataSet)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection SQLconn = new SqlConnection(ConnectionString);
            SqlDataAdapter adpAdapter = new SqlDataAdapter();
            DataSet myDataSet = new DataSet();

            try
            {
                SQLconn.Open();
                cmd.Connection = SQLconn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = pstrSQL;
                cmd.CommandTimeout = 30000;

                adpAdapter.SelectCommand = cmd;
                adpAdapter.Fill(myDataSet, sNameDataSet);

                cmd.Dispose();
                SQLconn.Close();
                SQLconn.Dispose();
                adpAdapter.Dispose();
                return myDataSet.Tables[sNameDataSet];
            }
            catch (Exception exp)
            {
                cmd.Dispose();
                SQLconn.Close();
                SQLconn.Dispose();
                adpAdapter.Dispose();
                string strErr = exp.Message;
                return null;
            }
        }

        #region Bieu_So_01
        public DataTable Bieu_So_01(DateTime Den_Ngay, int Ma_Tuyen, string Ma_Tinh, string Ma_Huyen, string Ma_Xa, int Ma_Don_Vi, int Ma_Loai_Hinh)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_BC_Bieu_So_01", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pMa_Tuyen = new SqlParameter("@Ma_Tuyen", SqlDbType.Int, 4);
                    pMa_Tuyen.Value = Ma_Tuyen;
                    myCommand.Parameters.Add(pMa_Tuyen);

                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pMa_Tinh.Value = Ma_Tinh;
                    myCommand.Parameters.Add(pMa_Tinh);

                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pMa_Huyen.Value = Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

                    SqlParameter pMa_Xa = new SqlParameter("@Ma_Xa", SqlDbType.VarChar, 10);
                    pMa_Xa.Value = Ma_Xa;
                    myCommand.Parameters.Add(pMa_Xa);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pMa_Loai_Hinh = new SqlParameter("@Ma_Loai_Hinh", SqlDbType.Int, 4);
                    pMa_Loai_Hinh.Value = Ma_Loai_Hinh;
                    myCommand.Parameters.Add(pMa_Loai_Hinh);

                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_BC_Bieu_So_01");
                    return myDataSet.Tables["NL_BC_Bieu_So_01"];
                }
            }
        }
        #endregion
        #region Bieu_So_02
        public DataTable Bieu_So_02(DateTime Den_Ngay, int Ma_Tuyen, string Ma_Tinh, string Ma_Huyen, string Ma_Xa, int Ma_Don_Vi, int Ma_Loai_Hinh)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_BC_Bieu_So_02", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pMa_Tuyen = new SqlParameter("@Ma_Tuyen", SqlDbType.Int, 4);
                    pMa_Tuyen.Value = Ma_Tuyen;
                    myCommand.Parameters.Add(pMa_Tuyen);

                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pMa_Tinh.Value = Ma_Tinh;
                    myCommand.Parameters.Add(pMa_Tinh);

                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pMa_Huyen.Value = Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

                    SqlParameter pMa_Xa = new SqlParameter("@Ma_Xa", SqlDbType.VarChar, 10);
                    pMa_Xa.Value = Ma_Xa;
                    myCommand.Parameters.Add(pMa_Xa);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi1", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pMa_Loai_Hinh = new SqlParameter("@Ma_Loai_Hinh", SqlDbType.Int, 4);
                    pMa_Loai_Hinh.Value = Ma_Loai_Hinh;
                    myCommand.Parameters.Add(pMa_Loai_Hinh);

                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_BC_Bieu_So_02");
                    return myDataSet.Tables["NL_BC_Bieu_So_02"];
                }
            }
        }
        #endregion
        #region Bieu_So_03
        public DataTable Bieu_So_03(DateTime Den_Ngay, int Ma_Tuyen, string Ma_Tinh, string Ma_Huyen, string Ma_Xa, int Ma_Don_Vi, int Ma_Loai_Hinh)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_BC_Bieu_So_03", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pMa_Tuyen = new SqlParameter("@Ma_Tuyen", SqlDbType.Int, 4);
                    pMa_Tuyen.Value = Ma_Tuyen;
                    myCommand.Parameters.Add(pMa_Tuyen);

                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pMa_Tinh.Value = Ma_Tinh;
                    myCommand.Parameters.Add(pMa_Tinh);

                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pMa_Huyen.Value = Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

                    SqlParameter pMa_Xa = new SqlParameter("@Ma_Xa", SqlDbType.VarChar, 10);
                    pMa_Xa.Value = Ma_Xa;
                    myCommand.Parameters.Add(pMa_Xa);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pMa_Loai_Hinh = new SqlParameter("@Ma_Loai_Hinh", SqlDbType.Int, 4);
                    pMa_Loai_Hinh.Value = Ma_Loai_Hinh;
                    myCommand.Parameters.Add(pMa_Loai_Hinh);

                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_BC_Bieu_So_03");
                    return myDataSet.Tables["NL_BC_Bieu_So_03"];
                }
            }
        }
        #endregion
        #region Bieu_So_04
        public DataTable Bieu_So_04(DateTime Den_Ngay, int Ma_Tuyen, string Ma_Tinh, string Ma_Huyen, string Ma_Xa, int Ma_Don_Vi, int Ma_Loai_Hinh)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_BC_Bieu_So_04", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pMa_Tuyen = new SqlParameter("@Ma_Tuyen", SqlDbType.Int, 4);
                    pMa_Tuyen.Value = Ma_Tuyen;
                    myCommand.Parameters.Add(pMa_Tuyen);

                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pMa_Tinh.Value = Ma_Tinh;
                    myCommand.Parameters.Add(pMa_Tinh);

                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pMa_Huyen.Value = Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

                    SqlParameter pMa_Xa = new SqlParameter("@Ma_Xa", SqlDbType.VarChar, 10);
                    pMa_Xa.Value = Ma_Xa;
                    myCommand.Parameters.Add(pMa_Xa);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pMa_Loai_Hinh = new SqlParameter("@Ma_Loai_Hinh", SqlDbType.Int, 4);
                    pMa_Loai_Hinh.Value = Ma_Loai_Hinh;
                    myCommand.Parameters.Add(pMa_Loai_Hinh);

                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_BC_Bieu_So_04");
                    return myDataSet.Tables["NL_BC_Bieu_So_04"];
                }
            }
        }
        #endregion
        #region Bieu_So_05
        public DataTable Bieu_So_05(DateTime Den_Ngay, int Ma_Tuyen, string Ma_Tinh, string Ma_Huyen, string Ma_Xa, int Ma_Don_Vi, int Ma_Loai_Hinh)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_BC_Bieu_So_05", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pMa_Tuyen = new SqlParameter("@Ma_Tuyen", SqlDbType.Int, 4);
                    pMa_Tuyen.Value = Ma_Tuyen;
                    myCommand.Parameters.Add(pMa_Tuyen);

                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pMa_Tinh.Value = Ma_Tinh;
                    myCommand.Parameters.Add(pMa_Tinh);

                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pMa_Huyen.Value = Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

                    SqlParameter pMa_Xa = new SqlParameter("@Ma_Xa", SqlDbType.VarChar, 10);
                    pMa_Xa.Value = Ma_Xa;
                    myCommand.Parameters.Add(pMa_Xa);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pMa_Loai_Hinh = new SqlParameter("@Ma_Loai_Hinh", SqlDbType.Int, 4);
                    pMa_Loai_Hinh.Value = Ma_Loai_Hinh;
                    myCommand.Parameters.Add(pMa_Loai_Hinh);

                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_BC_Bieu_So_05");
                    return myDataSet.Tables["NL_BC_Bieu_So_05"];
                }
            }
        }
        #endregion
        #region Bieu_So_06
        public DataTable Bieu_So_06(DateTime Den_Ngay, int Ma_Tuyen, string Ma_Tinh, string Ma_Huyen, string Ma_Xa, int Ma_Don_Vi, int Ma_Loai_Hinh)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_BC_Bieu_So_06", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pMa_Tuyen = new SqlParameter("@Ma_Tuyen", SqlDbType.Int, 4);
                    pMa_Tuyen.Value = Ma_Tuyen;
                    myCommand.Parameters.Add(pMa_Tuyen);

                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pMa_Tinh.Value = Ma_Tinh;
                    myCommand.Parameters.Add(pMa_Tinh);

                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pMa_Huyen.Value = Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

                    SqlParameter pMa_Xa = new SqlParameter("@Ma_Xa", SqlDbType.VarChar, 10);
                    pMa_Xa.Value = Ma_Xa;
                    myCommand.Parameters.Add(pMa_Xa);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pMa_Loai_Hinh = new SqlParameter("@Ma_Loai_Hinh", SqlDbType.Int, 4);
                    pMa_Loai_Hinh.Value = Ma_Loai_Hinh;
                    myCommand.Parameters.Add(pMa_Loai_Hinh);

                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_BC_Bieu_So_06");
                    return myDataSet.Tables["NL_BC_Bieu_So_06"];
                }
            }
        }
        #endregion
        #region Bieu_So_07
        public DataTable Bieu_So_07(DateTime Den_Ngay, int Ma_Tuyen, string Ma_Tinh, string Ma_Huyen, string Ma_Xa, int Ma_Don_Vi, int Ma_Loai_Hinh)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_BC_Bieu_So_07", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pMa_Tuyen = new SqlParameter("@Ma_Tuyen", SqlDbType.Int, 4);
                    pMa_Tuyen.Value = Ma_Tuyen;
                    myCommand.Parameters.Add(pMa_Tuyen);

                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pMa_Tinh.Value = Ma_Tinh;
                    myCommand.Parameters.Add(pMa_Tinh);

                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pMa_Huyen.Value = Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

                    SqlParameter pMa_Xa = new SqlParameter("@Ma_Xa", SqlDbType.VarChar, 10);
                    pMa_Xa.Value = Ma_Xa;
                    myCommand.Parameters.Add(pMa_Xa);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pMa_Loai_Hinh = new SqlParameter("@Ma_Loai_Hinh", SqlDbType.Int, 4);
                    pMa_Loai_Hinh.Value = Ma_Loai_Hinh;
                    myCommand.Parameters.Add(pMa_Loai_Hinh);

                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_BC_Bieu_So_07");
                    return myDataSet.Tables["NL_BC_Bieu_So_07"];
                }
            }
        }
        #endregion
        #region Bieu_So_08
        public DataTable Bieu_So_08(DateTime Den_Ngay, int Ma_Tuyen, string Ma_Tinh, string Ma_Huyen, string Ma_Xa, int Ma_Don_Vi, int Ma_Loai_Hinh)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_BC_Bieu_So_08", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pMa_Tuyen = new SqlParameter("@Ma_Tuyen", SqlDbType.Int, 4);
                    pMa_Tuyen.Value = Ma_Tuyen;
                    myCommand.Parameters.Add(pMa_Tuyen);

                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pMa_Tinh.Value = Ma_Tinh;
                    myCommand.Parameters.Add(pMa_Tinh);

                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pMa_Huyen.Value = Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

                    SqlParameter pMa_Xa = new SqlParameter("@Ma_Xa", SqlDbType.VarChar, 10);
                    pMa_Xa.Value = Ma_Xa;
                    myCommand.Parameters.Add(pMa_Xa);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pMa_Loai_Hinh = new SqlParameter("@Ma_Loai_Hinh", SqlDbType.Int, 4);
                    pMa_Loai_Hinh.Value = Ma_Loai_Hinh;
                    myCommand.Parameters.Add(pMa_Loai_Hinh);

                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_BC_Bieu_So_08");
                    return myDataSet.Tables["NL_BC_Bieu_So_08"];
                }
            }
        }
        #endregion
        #region Bieu_So_09
        public DataTable Bieu_So_09(DateTime Den_Ngay, int Ma_Tuyen, string Ma_Tinh, string Ma_Huyen, string Ma_Xa, int Ma_Don_Vi, int Ma_Loai_Hinh)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_BC_Bieu_So_09", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pMa_Tuyen = new SqlParameter("@Ma_Tuyen", SqlDbType.Int, 4);
                    pMa_Tuyen.Value = Ma_Tuyen;
                    myCommand.Parameters.Add(pMa_Tuyen);

                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pMa_Tinh.Value = Ma_Tinh;
                    myCommand.Parameters.Add(pMa_Tinh);

                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pMa_Huyen.Value = Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

                    SqlParameter pMa_Xa = new SqlParameter("@Ma_Xa", SqlDbType.VarChar, 10);
                    pMa_Xa.Value = Ma_Xa;
                    myCommand.Parameters.Add(pMa_Xa);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pMa_Loai_Hinh = new SqlParameter("@Ma_Loai_Hinh", SqlDbType.Int, 4);
                    pMa_Loai_Hinh.Value = Ma_Loai_Hinh;
                    myCommand.Parameters.Add(pMa_Loai_Hinh);

                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_BC_Bieu_So_09");
                    return myDataSet.Tables["NL_BC_Bieu_So_09"];
                }
            }
        }
        #endregion
        #region Bieu_So_10
        public DataTable Bieu_So_10(DateTime Den_Ngay, int Ma_Tuyen, string Ma_Tinh, string Ma_Huyen, string Ma_Xa, int Ma_Don_Vi, int Ma_Loai_Hinh)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_BC_Bieu_So_10", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pMa_Tuyen = new SqlParameter("@Ma_Tuyen", SqlDbType.Int, 4);
                    pMa_Tuyen.Value = Ma_Tuyen;
                    myCommand.Parameters.Add(pMa_Tuyen);

                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pMa_Tinh.Value = Ma_Tinh;
                    myCommand.Parameters.Add(pMa_Tinh);

                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pMa_Huyen.Value = Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

                    SqlParameter pMa_Xa = new SqlParameter("@Ma_Xa", SqlDbType.VarChar, 10);
                    pMa_Xa.Value = Ma_Xa;
                    myCommand.Parameters.Add(pMa_Xa);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pMa_Loai_Hinh = new SqlParameter("@Ma_Loai_Hinh", SqlDbType.Int, 4);
                    pMa_Loai_Hinh.Value = Ma_Loai_Hinh;
                    myCommand.Parameters.Add(pMa_Loai_Hinh);

                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_BC_Bieu_So_10");
                    return myDataSet.Tables["NL_BC_Bieu_So_10"];
                }
            }
        }

        public DataTable Bieu_So_10_New(DateTime Den_Ngay, int Ma_Tuyen, string Ma_Tinh, string Ma_Huyen, string Ma_Xa, string Ma_Don_Vi, string Ma_Loai_Hinh)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_BC_Bieu_So_10_new", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pMa_Tuyen = new SqlParameter("@Ma_Tuyen", SqlDbType.Int, 4);
                    pMa_Tuyen.Value = Ma_Tuyen;
                    myCommand.Parameters.Add(pMa_Tuyen);

                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.NVarChar, 10);
                    pMa_Tinh.Value = Ma_Tinh;
                    myCommand.Parameters.Add(pMa_Tinh);

                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.NVarChar, 10);
                    pMa_Huyen.Value = Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

                    SqlParameter pMa_Xa = new SqlParameter("@Ma_Xa", SqlDbType.NVarChar, 10);
                    pMa_Xa.Value = Ma_Xa;
                    myCommand.Parameters.Add(pMa_Xa);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.NVarChar, 10);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pMa_Loai_Hinh = new SqlParameter("@Ma_Loai_Hinh", SqlDbType.NVarChar, 10);
                    pMa_Loai_Hinh.Value = Ma_Loai_Hinh;
                    myCommand.Parameters.Add(pMa_Loai_Hinh);

                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_BC_Bieu_So_10_New");
                    return myDataSet.Tables["NL_BC_Bieu_So_10_New"];
                }
            }
        }
        #endregion
        #region Bieu_So_11
        public DataTable Bieu_So_11(DateTime Den_Ngay, int Ma_Tuyen, string Ma_Tinh, string Ma_Huyen, string Ma_Xa, int Ma_Don_Vi, int Ma_Loai_Hinh)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_BC_Bieu_So_11", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pMa_Tuyen = new SqlParameter("@Ma_Tuyen", SqlDbType.Int, 4);
                    pMa_Tuyen.Value = Ma_Tuyen;
                    myCommand.Parameters.Add(pMa_Tuyen);

                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pMa_Tinh.Value = Ma_Tinh;
                    myCommand.Parameters.Add(pMa_Tinh);

                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pMa_Huyen.Value = Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

                    SqlParameter pMa_Xa = new SqlParameter("@Ma_Xa", SqlDbType.VarChar, 10);
                    pMa_Xa.Value = Ma_Xa;
                    myCommand.Parameters.Add(pMa_Xa);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pMa_Loai_Hinh = new SqlParameter("@Ma_Loai_Hinh", SqlDbType.Int, 4);
                    pMa_Loai_Hinh.Value = Ma_Loai_Hinh;
                    myCommand.Parameters.Add(pMa_Loai_Hinh);

                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_BC_Bieu_So_11");
                    return myDataSet.Tables["NL_BC_Bieu_So_11"];
                }
            }
        }
        #endregion
        #region Bieu_So_12

        public DataTable Bieu_So_12(DateTime Den_Ngay, int Ma_Tuyen, string Ma_Tinh, string Ma_Huyen, string Ma_Xa, int Ma_Don_Vi, int Ma_Loai_Hinh)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_BC_Bieu_So_12", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pMa_Tuyen = new SqlParameter("@Ma_Tuyen", SqlDbType.Int, 4);
                    pMa_Tuyen.Value = Ma_Tuyen;
                    myCommand.Parameters.Add(pMa_Tuyen);

                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pMa_Tinh.Value = Ma_Tinh;
                    myCommand.Parameters.Add(pMa_Tinh);

                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pMa_Huyen.Value = Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

                    SqlParameter pMa_Xa = new SqlParameter("@Ma_Xa", SqlDbType.VarChar, 10);
                    pMa_Xa.Value = Ma_Xa;
                    myCommand.Parameters.Add(pMa_Xa);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pMa_Loai_Hinh = new SqlParameter("@Ma_Loai_Hinh", SqlDbType.Int, 4);
                    pMa_Loai_Hinh.Value = Ma_Loai_Hinh;
                    myCommand.Parameters.Add(pMa_Loai_Hinh);

                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_BC_Bieu_So_12");
                    return myDataSet.Tables["NL_BC_Bieu_So_12"];
                }
            }
        }
        #endregion
        #region Bieu_So_13
        public DataTable Bieu_So_13(DateTime Den_Ngay, int Ma_Tuyen, string Ma_Tinh, string Ma_Huyen, string Ma_Xa, int Ma_Don_Vi, int Ma_Loai_Hinh)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_BC_Bieu_So_13", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pMa_Tuyen = new SqlParameter("@Ma_Tuyen", SqlDbType.Int, 4);
                    pMa_Tuyen.Value = Ma_Tuyen;
                    myCommand.Parameters.Add(pMa_Tuyen);

                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pMa_Tinh.Value = Ma_Tinh;
                    myCommand.Parameters.Add(pMa_Tinh);

                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pMa_Huyen.Value = Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

                    SqlParameter pMa_Xa = new SqlParameter("@Ma_Xa", SqlDbType.VarChar, 10);
                    pMa_Xa.Value = Ma_Xa;
                    myCommand.Parameters.Add(pMa_Xa);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pMa_Loai_Hinh = new SqlParameter("@Ma_Loai_Hinh", SqlDbType.Int, 4);
                    pMa_Loai_Hinh.Value = Ma_Loai_Hinh;
                    myCommand.Parameters.Add(pMa_Loai_Hinh);

                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_BC_Bieu_So_13");
                    return myDataSet.Tables["NL_BC_Bieu_So_13"];
                }
            }
        }
        #endregion
        #region Bieu_So_14
        public DataTable Bieu_So_14(DateTime Den_Ngay, int Ma_Tuyen, string Ma_Tinh, string Ma_Huyen, string Ma_Xa, int Ma_Don_Vi, int Ma_Loai_Hinh)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_BC_Bieu_So_14", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pMa_Tuyen = new SqlParameter("@Ma_Tuyen", SqlDbType.Int, 4);
                    pMa_Tuyen.Value = Ma_Tuyen;
                    myCommand.Parameters.Add(pMa_Tuyen);

                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pMa_Tinh.Value = Ma_Tinh;
                    myCommand.Parameters.Add(pMa_Tinh);

                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pMa_Huyen.Value = Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

                    SqlParameter pMa_Xa = new SqlParameter("@Ma_Xa", SqlDbType.VarChar, 10);
                    pMa_Xa.Value = Ma_Xa;
                    myCommand.Parameters.Add(pMa_Xa);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pMa_Loai_Hinh = new SqlParameter("@Ma_Loai_Hinh", SqlDbType.Int, 4);
                    pMa_Loai_Hinh.Value = Ma_Loai_Hinh;
                    myCommand.Parameters.Add(pMa_Loai_Hinh);

                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_BC_Bieu_So_14");
                    return myDataSet.Tables["NL_BC_Bieu_So_14"];
                }
            }
        }
        public DataTable Bieu_So_14_Export_Excel(DateTime Den_Ngay, int Ma_Tuyen, string Ma_Tinh, string Ma_Huyen, string Ma_Xa, int Ma_Don_Vi, int Ma_Loai_Hinh)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_BC_Bieu_So_14_Export_Excel", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pMa_Tuyen = new SqlParameter("@Ma_Tuyen", SqlDbType.Int, 4);
                    pMa_Tuyen.Value = Ma_Tuyen;
                    myCommand.Parameters.Add(pMa_Tuyen);

                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pMa_Tinh.Value = Ma_Tinh;
                    myCommand.Parameters.Add(pMa_Tinh);

                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pMa_Huyen.Value = Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

                    SqlParameter pMa_Xa = new SqlParameter("@Ma_Xa", SqlDbType.VarChar, 10);
                    pMa_Xa.Value = Ma_Xa;
                    myCommand.Parameters.Add(pMa_Xa);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pMa_Loai_Hinh = new SqlParameter("@Ma_Loai_Hinh", SqlDbType.Int, 4);
                    pMa_Loai_Hinh.Value = Ma_Loai_Hinh;
                    myCommand.Parameters.Add(pMa_Loai_Hinh);

                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_BC_Bieu_So_14");
                    return myDataSet.Tables["NL_BC_Bieu_So_14"];
                }
            }
        }
        #endregion
        #region Bieu_So_15
        public DataTable Bieu_So_15(DateTime Den_Ngay, int Ma_Tuyen, string Ma_Tinh, string Ma_Huyen, string Ma_Xa, int Ma_Don_Vi, int Ma_Loai_Hinh
            , string chkNgach, string chkChuc_Vu, string chkChuyen_Mon, string chkDao_Tao, string chkTrinh_Do, string chkSo_Hieu, string Tu_Khoa)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_BC_Bieu_So_15", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pMa_Tuyen = new SqlParameter("@Ma_Tuyen", SqlDbType.Int, 4);
                    pMa_Tuyen.Value = Ma_Tuyen;
                    myCommand.Parameters.Add(pMa_Tuyen);

                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pMa_Tinh.Value = Ma_Tinh;
                    myCommand.Parameters.Add(pMa_Tinh);

                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pMa_Huyen.Value = Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

                    SqlParameter pMa_Xa = new SqlParameter("@Ma_Xa", SqlDbType.VarChar, 10);
                    pMa_Xa.Value = Ma_Xa;
                    myCommand.Parameters.Add(pMa_Xa);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pMa_Loai_Hinh = new SqlParameter("@Ma_Loai_Hinh", SqlDbType.Int, 4);
                    pMa_Loai_Hinh.Value = Ma_Loai_Hinh;
                    myCommand.Parameters.Add(pMa_Loai_Hinh);

                    SqlParameter pNgach = new SqlParameter("@chkNgach", SqlDbType.NVarChar, 250);
                    pNgach.Value = chkNgach;
                    myCommand.Parameters.Add(pNgach);

                    SqlParameter pChuc_Vu = new SqlParameter("@chkChuc_Vu", SqlDbType.NVarChar, 250);
                    pChuc_Vu.Value = chkChuc_Vu;
                    myCommand.Parameters.Add(pChuc_Vu);

                    SqlParameter pchkChuyen_Mon = new SqlParameter("@chkChuyen_Mon", SqlDbType.NVarChar, 250);
                    pchkChuyen_Mon.Value = chkChuyen_Mon;
                    myCommand.Parameters.Add(pchkChuyen_Mon);

                    SqlParameter pchkDao_Tao = new SqlParameter("@chkDao_Tao", SqlDbType.NVarChar, 250);
                    pchkDao_Tao.Value = chkDao_Tao;
                    myCommand.Parameters.Add(pchkDao_Tao);

                    SqlParameter pchkTrinh_Do = new SqlParameter("@chkTrinh_Do", SqlDbType.NVarChar, 250);
                    pchkTrinh_Do.Value = chkTrinh_Do;
                    myCommand.Parameters.Add(pchkTrinh_Do);

                    SqlParameter pchkSo_Hieu = new SqlParameter("@chkSo_Hieu", SqlDbType.NVarChar, 250);
                    pchkSo_Hieu.Value = chkSo_Hieu;
                    myCommand.Parameters.Add(pchkSo_Hieu);

                    SqlParameter pTu_Khoa = new SqlParameter("@Tu_Khoa", SqlDbType.NVarChar, 250);
                    pTu_Khoa.Value = Tu_Khoa;
                    myCommand.Parameters.Add(pTu_Khoa);

                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_BC_Bieu_So_15");
                    return myDataSet.Tables["NL_BC_Bieu_So_15"];
                }
            }
        }
        public DataTable Bieu_So_15_Export_Excel(DateTime Den_Ngay, int Ma_Tuyen, string Ma_Tinh, string Ma_Huyen, string Ma_Xa, int Ma_Don_Vi, int Ma_Loai_Hinh
           , string chkNgach, string chkChuc_Vu, string chkChuyen_Mon, string chkDao_Tao, string chkTrinh_Do, string chkSo_Hieu, string Tu_Khoa)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NL_BC_Bieu_So_15_Export_Excel", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();

                    SqlParameter pDen_Ngay = new SqlParameter("@Den_Ngay", SqlDbType.DateTime, 8);
                    pDen_Ngay.Value = Den_Ngay;
                    myCommand.Parameters.Add(pDen_Ngay);

                    SqlParameter pMa_Tuyen = new SqlParameter("@Ma_Tuyen", SqlDbType.Int, 4);
                    pMa_Tuyen.Value = Ma_Tuyen;
                    myCommand.Parameters.Add(pMa_Tuyen);

                    SqlParameter pMa_Tinh = new SqlParameter("@Ma_Tinh", SqlDbType.VarChar, 10);
                    pMa_Tinh.Value = Ma_Tinh;
                    myCommand.Parameters.Add(pMa_Tinh);

                    SqlParameter pMa_Huyen = new SqlParameter("@Ma_Huyen", SqlDbType.VarChar, 10);
                    pMa_Huyen.Value = Ma_Huyen;
                    myCommand.Parameters.Add(pMa_Huyen);

                    SqlParameter pMa_Xa = new SqlParameter("@Ma_Xa", SqlDbType.VarChar, 10);
                    pMa_Xa.Value = Ma_Xa;
                    myCommand.Parameters.Add(pMa_Xa);

                    SqlParameter pMa_Don_Vi = new SqlParameter("@Ma_Don_Vi", SqlDbType.Int, 4);
                    pMa_Don_Vi.Value = Ma_Don_Vi;
                    myCommand.Parameters.Add(pMa_Don_Vi);

                    SqlParameter pMa_Loai_Hinh = new SqlParameter("@Ma_Loai_Hinh", SqlDbType.Int, 4);
                    pMa_Loai_Hinh.Value = Ma_Loai_Hinh;
                    myCommand.Parameters.Add(pMa_Loai_Hinh);

                    SqlParameter pNgach = new SqlParameter("@chkNgach", SqlDbType.NVarChar, 250);
                    pNgach.Value = chkNgach;
                    myCommand.Parameters.Add(pNgach);

                    SqlParameter pChuc_Vu = new SqlParameter("@chkChuc_Vu", SqlDbType.NVarChar, 250);
                    pChuc_Vu.Value = chkChuc_Vu;
                    myCommand.Parameters.Add(pChuc_Vu);

                    SqlParameter pchkChuyen_Mon = new SqlParameter("@chkChuyen_Mon", SqlDbType.NVarChar, 250);
                    pchkChuyen_Mon.Value = chkChuyen_Mon;
                    myCommand.Parameters.Add(pchkChuyen_Mon);

                    SqlParameter pchkDao_Tao = new SqlParameter("@chkDao_Tao", SqlDbType.NVarChar, 250);
                    pchkDao_Tao.Value = chkDao_Tao;
                    myCommand.Parameters.Add(pchkDao_Tao);

                    SqlParameter pchkTrinh_Do = new SqlParameter("@chkTrinh_Do", SqlDbType.NVarChar, 250);
                    pchkTrinh_Do.Value = chkTrinh_Do;
                    myCommand.Parameters.Add(pchkTrinh_Do);

                    SqlParameter pchkSo_Hieu = new SqlParameter("@chkSo_Hieu", SqlDbType.NVarChar, 250);
                    pchkSo_Hieu.Value = chkSo_Hieu;
                    myCommand.Parameters.Add(pchkSo_Hieu);

                    SqlParameter pTu_Khoa = new SqlParameter("@Tu_Khoa", SqlDbType.NVarChar, 250);
                    pTu_Khoa.Value = Tu_Khoa;
                    myCommand.Parameters.Add(pTu_Khoa);

                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NL_BC_Bieu_So_15");
                    return myDataSet.Tables["NL_BC_Bieu_So_15"];
                }
            }
        }
        #endregion
    }
    #endregion
}
