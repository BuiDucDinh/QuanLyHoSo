using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class NV_Quangcao_ChiTiet
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string Link { get; set; }
        public int MenuID { get; set; }
        public int ImageID { get; set; }
        public string Description { get; set; }
        public bool Duyet { get; set; }
        public bool IsImage { get; set; }

        public string Target { get; set; }
        public int Stt { get; set; }
        public NV_Quangcao_ChiTiet() { }
        public NV_Quangcao_ChiTiet(DataTable dt)
        {
            ID = int.Parse(dt.Rows[0]["ID"].ToString());
            Name = dt.Rows[0]["Name"].ToString();
            Type = int.Parse(dt.Rows[0]["Type"].ToString());
            MenuID = int.Parse(dt.Rows[0]["MenuID"].ToString());
            Link = dt.Rows[0]["Link"].ToString();
            Duyet = Convert.ToBoolean(dt.Rows[0]["Duyet"].ToString());
            IsImage = Convert.ToBoolean(dt.Rows[0]["IsImage"].ToString());
            ImageID = int.Parse(dt.Rows[0]["ImageID"].ToString());
            Description = dt.Rows[0]["Description"].ToString();
            Target = dt.Rows[0]["Target"].ToString();
            Stt = int.Parse(dt.Rows[0]["Stt"].ToString());

        }
    }
    public class NV_Quangcao
    {
        private string ConnectionString;
        public NV_Quangcao(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        
        #region Lấy theo ID
        public NV_Quangcao_ChiTiet GetById(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_Quangcao_getByID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = id;
                    myCommand.Parameters.Add(pID);

                    DataTable dt;
                    NV_Quangcao_ChiTiet model = new NV_Quangcao_ChiTiet();

                    myConnection.Open();
                    using (SqlDataAdapter mData = new SqlDataAdapter(myCommand))
                    {
                        dt = new DataTable();
                        mData.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model = new NV_Quangcao_ChiTiet(dt);
                    }
                    return model;
                }
            }
        }
        #endregion


        #region Lấy tất cả
        public DataTable GetAll()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_Quangcao_getAll", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myConnection.Open();
                    DataSet myDataSet = new DataSet();
                    myAdapter.SelectCommand = myCommand;
                    myAdapter.Fill(myDataSet, "NV_Quangcao_getAll");
                    return myDataSet.Tables["NV_Quangcao_getAll"];

                }
            }
        }

        #endregion
        
        #region Thêm
        public bool them(NV_Quangcao_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_Quangcao_add", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;


                    SqlParameter pName = new SqlParameter("@Name", SqlDbType.NVarChar, 250);
                    pName.Value = model.Name;
                    myCommand.Parameters.Add(pName);

                    SqlParameter pType = new SqlParameter("@Type", SqlDbType.Int);
                    pType.Value = model.Type;
                    myCommand.Parameters.Add(pType);


                    SqlParameter pMenuID = new SqlParameter("@MenuID", SqlDbType.Int);
                    pMenuID.Value = model.MenuID;
                    myCommand.Parameters.Add(pMenuID);

                    SqlParameter pLink = new SqlParameter("@Link", SqlDbType.NVarChar, 250);
                    pLink.Value = model.Link;
                    myCommand.Parameters.Add(pLink);

                    SqlParameter pDescription = new SqlParameter("@Description", SqlDbType.NText);
                    pDescription.Value = model.Description;
                    myCommand.Parameters.Add(pDescription);

                    SqlParameter pDuyet = new SqlParameter("@Duyet", SqlDbType.Bit);
                    pDuyet.Value = model.Duyet;
                    myCommand.Parameters.Add(pDuyet);

                    SqlParameter pIsImage = new SqlParameter("@IsImage", SqlDbType.Bit);
                    pIsImage.Value = model.IsImage;
                    myCommand.Parameters.Add(pIsImage);

                    SqlParameter pImageID = new SqlParameter("@ImageID", SqlDbType.Int);
                    pImageID.Value = model.ImageID;
                    myCommand.Parameters.Add(pImageID);


                    SqlParameter pTarget = new SqlParameter("@Target", SqlDbType.NVarChar, 50);
                    pTarget.Value = model.Target;
                    myCommand.Parameters.Add(pTarget);

                    SqlParameter pStt = new SqlParameter("@Stt", SqlDbType.Int);
                    pStt.Value = model.Stt;
                    myCommand.Parameters.Add(pStt);
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
        #region update
        public bool update(NV_Quangcao_ChiTiet model)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("NV_Quangcao_update", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                    pID.Value = model.ID;
                    myCommand.Parameters.Add(pID);


                    SqlParameter pName = new SqlParameter("@Name", SqlDbType.NVarChar, 250);
                    pName.Value = model.Name;
                    myCommand.Parameters.Add(pName);

                    SqlParameter pType = new SqlParameter("@Type", SqlDbType.Int);
                    pType.Value = model.Type;
                    myCommand.Parameters.Add(pType);


                    SqlParameter pMenuID = new SqlParameter("@MenuID", SqlDbType.Int);
                    pMenuID.Value = model.MenuID;
                    myCommand.Parameters.Add(pMenuID);

                    SqlParameter pLink = new SqlParameter("@Link", SqlDbType.NVarChar, 250);
                    pLink.Value = model.Link;
                    myCommand.Parameters.Add(pLink);

                    SqlParameter pDescription = new SqlParameter("@Description", SqlDbType.NText);
                    pDescription.Value = model.Description;
                    myCommand.Parameters.Add(pDescription);

                    SqlParameter pDuyet = new SqlParameter("@Duyet", SqlDbType.Bit);
                    pDuyet.Value = model.Duyet;
                    myCommand.Parameters.Add(pDuyet);

                    SqlParameter pIsImage = new SqlParameter("@IsImage", SqlDbType.Bit);
                    pIsImage.Value = model.IsImage;
                    myCommand.Parameters.Add(pIsImage);

                    SqlParameter pImageID = new SqlParameter("@ImageID", SqlDbType.Int);
                    pImageID.Value = model.ImageID;
                    myCommand.Parameters.Add(pImageID);


                    SqlParameter pTarget = new SqlParameter("@Target", SqlDbType.NVarChar, 50);
                    pTarget.Value = model.Target;
                    myCommand.Parameters.Add(pTarget);

                    SqlParameter pStt = new SqlParameter("@Stt", SqlDbType.Int);
                    pStt.Value = model.Stt;
                    myCommand.Parameters.Add(pStt);

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
                using (SqlCommand myCommand = new SqlCommand("NV_Quangcao_del", myConnection))
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
