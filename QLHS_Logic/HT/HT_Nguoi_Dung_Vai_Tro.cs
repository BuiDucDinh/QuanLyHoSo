
using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
    #region HT_Nguoi_Dung_Vai_Tro_Details
    public class HT_Nguoi_Dung_Vai_Tro_Chi_Tiet
    {
        public int Ma_Nguoi_Dung_Vai_Tro;
        public int Ma_Nguoi_Dung; // Mã người dùng
        public int Ma_Vai_Tro; // Mã vai trò
    }
    #endregion
    public class Role
    {
        public bool Duoc_TruyCap { get; set; }
        public bool Duoc_Nhap { get; set; }
        public bool Duoc_Sua { get; set; }
        public bool Duoc_Xuat { get; set; }
        public bool Duoc_Xoa { get; set; }
        public bool Duoc_Duyet { get; set; }
       
    }
    #region HT_Nguoi_Dung_Vai_Tro
    public class HT_Nguoi_Dung_Vai_Tro
    {
        private string ConnectionString;
        public HT_Nguoi_Dung_Vai_Tro(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        #region Lay
        public HT_Nguoi_Dung_Vai_Tro_Chi_Tiet Lay(int Ma_Nguoi_Dung_Vai_Tro)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Vai_Tro_Lay", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nguoi_Dung_Vai_Tro = new SqlParameter("@Ma_Nguoi_Dung_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung_Vai_Tro.Value = Ma_Nguoi_Dung_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung_Vai_Tro);

                    SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung);

                    SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Vai_Tro.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pMa_Vai_Tro);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();


                    HT_Nguoi_Dung_Vai_Tro_Chi_Tiet myHT_Nguoi_Dung_Vai_Tro_Chi_Tiet = new HT_Nguoi_Dung_Vai_Tro_Chi_Tiet();
                    myHT_Nguoi_Dung_Vai_Tro_Chi_Tiet.Ma_Nguoi_Dung_Vai_Tro = Ma_Nguoi_Dung_Vai_Tro;
                    myHT_Nguoi_Dung_Vai_Tro_Chi_Tiet.Ma_Nguoi_Dung = (int)pMa_Nguoi_Dung.Value;
                    myHT_Nguoi_Dung_Vai_Tro_Chi_Tiet.Ma_Vai_Tro = (int)pMa_Vai_Tro.Value;
                    return myHT_Nguoi_Dung_Vai_Tro_Chi_Tiet;
                }
            }
        }
        #endregion
        #region Them
        public int Them(int Ma_Nguoi_Dung_Vai_Tro, int Ma_Nguoi_Dung, int Ma_Vai_Tro)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Vai_Tro_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nguoi_Dung_Vai_Tro = new SqlParameter("@Ma_Nguoi_Dung_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung_Vai_Tro.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung_Vai_Tro);

                    SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung.Value = Ma_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung);

                    SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Vai_Tro.Value = Ma_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Vai_Tro);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    return (int)pMa_Nguoi_Dung_Vai_Tro.Value;
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(int Ma_Nguoi_Dung_Vai_Tro, int Ma_Nguoi_Dung, int Ma_Vai_Tro)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Vai_Tro_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter pMa_Nguoi_Dung_Vai_Tro = new SqlParameter("@Ma_Nguoi_Dung_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung_Vai_Tro.Value = Ma_Nguoi_Dung_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung_Vai_Tro);

                    SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung.Value = Ma_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung);

                    SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Vai_Tro.Value = Ma_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Vai_Tro);



                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(HT_Nguoi_Dung_Vai_Tro_Chi_Tiet myHT_Nguoi_Dung_Vai_Tro_Chi_Tiet)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Vai_Tro_Cap_Nhat", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nguoi_Dung_Vai_Tro = new SqlParameter("@Ma_Nguoi_Dung_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung_Vai_Tro.Value = myHT_Nguoi_Dung_Vai_Tro_Chi_Tiet.Ma_Nguoi_Dung_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung_Vai_Tro);

                    SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung.Value = myHT_Nguoi_Dung_Vai_Tro_Chi_Tiet.Ma_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung);

                    SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Vai_Tro.Value = myHT_Nguoi_Dung_Vai_Tro_Chi_Tiet.Ma_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Vai_Tro);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Cap_Nhat
        public void Cap_Nhat(DataSet myDataSet, String strTableName)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Vai_Tro_Cap_Nhat_Them", myConnection))
                {
                    myConnection.Open();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++)
                    {

                        SqlParameter pMa_Nguoi_Dung_Vai_Tro = new SqlParameter("@Ma_Nguoi_Dung_Vai_Tro", SqlDbType.Int, 4);
                        pMa_Nguoi_Dung_Vai_Tro.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nguoi_Dung_Vai_Tro"];
                        myCommand.Parameters.Add(pMa_Nguoi_Dung_Vai_Tro);

                        SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int, 4);
                        pMa_Nguoi_Dung.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nguoi_Dung"];
                        myCommand.Parameters.Add(pMa_Nguoi_Dung);

                        SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                        pMa_Vai_Tro.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Vai_Tro"];
                        myCommand.Parameters.Add(pMa_Vai_Tro);


                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region Cap_Nhat_Them
        public void Cap_Nhat_Them(int Ma_Nguoi_Dung_Vai_Tro, int Ma_Nguoi_Dung, int Ma_Vai_Tro)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Vai_Tro_Cap_Nhat_Them", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nguoi_Dung_Vai_Tro = new SqlParameter("@Ma_Nguoi_Dung_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung_Vai_Tro.Value = Ma_Nguoi_Dung_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung_Vai_Tro);

                    SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung.Value = Ma_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung);

                    SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Vai_Tro.Value = Ma_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Vai_Tro);


                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Xoa
        public void Xoa(int Ma_Nguoi_Dung_Vai_Tro)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Vai_Tro_Xoa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nguoi_Dung_Vai_Tro = new SqlParameter("@Ma_Nguoi_Dung_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung_Vai_Tro.Value = Ma_Nguoi_Dung_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung_Vai_Tro);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Danh_Sach
        public DataTable Danh_Sach()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Vai_Tro_Danh_Sach", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Nguoi_Dung_Vai_Tro_Danh_Sach");
                    return myDataSet.Tables["HT_Nguoi_Dung_Vai_Tro_Danh_Sach"];
                }
            }
        }
        #endregion

        #region Lay_Boi_HT_Nguoi_Dung
        public DataTable Lay_Boi_HT_Nguoi_Dung(int Ma_Nguoi_Dung)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Vai_Tro_Lay_Boi_HT_Nguoi_Dung", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung.Value = Ma_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Nguoi_Dung_Vai_Tro_Lay_Boi_HT_Nguoi_Dung");
                    return myDataSet.Tables["HT_Nguoi_Dung_Vai_Tro_Lay_Boi_HT_Nguoi_Dung"];
                }
            }
        }
        #endregion
        #region Lay_Boi_HT_Vai_Tro
        public DataTable Lay_Boi_HT_Vai_Tro(int Ma_Vai_Tro)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Vai_Tro_Lay_Boi_HT_Vai_Tro", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Vai_Tro = new SqlParameter("@Ma_Vai_Tro", SqlDbType.Int, 4);
                    pMa_Vai_Tro.Value = Ma_Vai_Tro;
                    myCommand.Parameters.Add(pMa_Vai_Tro);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Nguoi_Dung_Vai_Tro_Lay_Boi_HT_Vai_Tro");
                    return myDataSet.Tables["HT_Nguoi_Dung_Vai_Tro_Lay_Boi_HT_Vai_Tro"];
                }
            }
        }
        #endregion

        //new
        #region Lay_Boi_HT_Vai_Tro_Chon
        public DataTable Lay_Boi_HT_Vai_Tro_Chon(int Ma_Nguoi_Dung, bool Chon)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Lay_Boi_HT_Vai_Tro_Chon", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung.Value = Ma_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung);

                    SqlParameter pChon = new SqlParameter("@Chon", SqlDbType.Bit);
                    pChon.Value = Chon;
                    myCommand.Parameters.Add(pChon);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "HT_Nguoi_Dung_Lay_Boi_HT_Vai_Tro_Chon");
                    return myDataSet.Tables["HT_Nguoi_Dung_Lay_Boi_HT_Vai_Tro_Chon"];
                }
            }
        }
        #endregion
        #region lấy ra quyền của user
        public DataTable getRoleUser(int Ma_Nguoi_Dung)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("getRoleUser", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int, 4);
                    pMa_Nguoi_Dung.Value = Ma_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung);

                    myConnection.Open();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "getRoleUser");
                    return myDataSet.Tables["getRoleUser"];
                }
            }
        }
        #endregion
        #region Kiểm tra quyền user
        public bool checkRoleUser(int Ma_Nguoi_Dung, string Ma_Chuc_Nang, string thaotac)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("checkRoleUser", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int);
                    pMa_Nguoi_Dung.Value = Ma_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung);

                    SqlParameter pMa_Chuc_Nang = new SqlParameter("@Ma_Chuc_Nang", SqlDbType.VarChar, 10);
                    pMa_Chuc_Nang.Value = Ma_Chuc_Nang;
                    myCommand.Parameters.Add(pMa_Chuc_Nang);

                    DataTable dt;
                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (Convert.ToBoolean(dr[thaotac].ToString())) return true;
                        }
                    }
                    return false;
                }
            }
        }

        #endregion
        #region Lấy quyền user theo form
        public Role getRoleUserByForm(int Ma_Nguoi_Dung, string Ma_Chuc_Nang)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("checkRoleUser", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung", SqlDbType.Int);
                    pMa_Nguoi_Dung.Value = Ma_Nguoi_Dung;
                    myCommand.Parameters.Add(pMa_Nguoi_Dung);

                    SqlParameter pMa_Chuc_Nang = new SqlParameter("@Ma_Chuc_Nang", SqlDbType.VarChar, 10);
                    pMa_Chuc_Nang.Value = Ma_Chuc_Nang;
                    myCommand.Parameters.Add(pMa_Chuc_Nang);

                    DataTable dt;
                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    Role role = new Role();
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (!role.Duoc_Duyet)
                        {
                            role.Duoc_Duyet = bool.Parse(dr["Duoc_Duyet"].ToString());
                        }
                        if (!role.Duoc_Nhap)
                        {
                            role.Duoc_Nhap = bool.Parse(dr["Duoc_Nhap"].ToString());
                        }
                        if (!role.Duoc_Sua)
                        {
                            role.Duoc_Sua = bool.Parse(dr["Duoc_Sua"].ToString());
                        }
                        if (!role.Duoc_TruyCap)
                        {
                            role.Duoc_TruyCap = bool.Parse(dr["Duoc_Truy_Cap"].ToString());
                        }
                        if (!role.Duoc_Xoa)
                        {
                            role.Duoc_Xoa = bool.Parse(dr["Duoc_Xoa"].ToString());
                        }
                        if (!role.Duoc_Xuat)
                        {
                            role.Duoc_Xuat = bool.Parse(dr["Duoc_Xuat"].ToString());
                        }
                    }

                    return role;
                }
            }
        }

        #endregion
    }
    #endregion
}