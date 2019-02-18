using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic{
#region NL_Nhan_Vien_Nghi_Viec_Details
public class NL_Nhan_Vien_Nghi_Viec_Chi_Tiet
{		
	public int? Ma_Nghi_Viec=null; 
	public int? Ma_Nhan_Vien=null; 
	public DateTime? Ngay_Nghi=null; 
	public int? Loai_Nghi=null; // 1.Nghỉ hưu,2.Chuyển công tác,3.Thôi việc,4.Chết
	public string Ly_Do=null;
    public string Ghi_Chu = null; // Ghi chú
}
#endregion 
#region NL_Nhan_Vien_Nghi_Viec
public class NL_Nhan_Vien_Nghi_Viec
{	
private string ConnectionString;
public NL_Nhan_Vien_Nghi_Viec(string _ConnectionString)
{
	ConnectionString = _ConnectionString;
}
#region Lay
public NL_Nhan_Vien_Nghi_Viec_Chi_Tiet Lay(int Ma_Nghi_Viec)
{	
	using (SqlConnection myConnection = new SqlConnection(ConnectionString))
	{
    	using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Nghi_Viec_Lay", myConnection))
    	{
			myCommand.CommandType = CommandType.StoredProcedure;
        	
			SqlParameter pMa_Nghi_Viec = new SqlParameter("@Ma_Nghi_Viec",SqlDbType.Int,4);
			pMa_Nghi_Viec.Value = Ma_Nghi_Viec;
			myCommand.Parameters.Add(pMa_Nghi_Viec);				
	  		
			SqlDataAdapter myAdapter = new SqlDataAdapter();
			DataSet myDataSet = new DataSet();
			myConnection.Open();
			myAdapter.SelectCommand = myCommand;
			myAdapter.Fill(myDataSet,"NL_Nhan_Vien_Nghi_Viec_Chi_Tiet");                        		
			NL_Nhan_Vien_Nghi_Viec_Chi_Tiet myNL_Nhan_Vien_Nghi_Viec_Chi_Tiet = new NL_Nhan_Vien_Nghi_Viec_Chi_Tiet();
			if(myDataSet.Tables["NL_Nhan_Vien_Nghi_Viec_Chi_Tiet"]!=null)
			{				
				myNL_Nhan_Vien_Nghi_Viec_Chi_Tiet.Ma_Nghi_Viec = Ma_Nghi_Viec;
				myNL_Nhan_Vien_Nghi_Viec_Chi_Tiet.Ma_Nhan_Vien=myDataSet.Tables["NL_Nhan_Vien_Nghi_Viec_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"]!=DBNull.Value?(int?)myDataSet.Tables["NL_Nhan_Vien_Nghi_Viec_Chi_Tiet"].Rows[0]["Ma_Nhan_Vien"]:(int?)null;
				myNL_Nhan_Vien_Nghi_Viec_Chi_Tiet.Ngay_Nghi=myDataSet.Tables["NL_Nhan_Vien_Nghi_Viec_Chi_Tiet"].Rows[0]["Ngay_Nghi"]!=DBNull.Value?(DateTime?)myDataSet.Tables["NL_Nhan_Vien_Nghi_Viec_Chi_Tiet"].Rows[0]["Ngay_Nghi"]:(DateTime?)null;
				myNL_Nhan_Vien_Nghi_Viec_Chi_Tiet.Loai_Nghi=myDataSet.Tables["NL_Nhan_Vien_Nghi_Viec_Chi_Tiet"].Rows[0]["Loai_Nghi"]!=DBNull.Value?(int?)myDataSet.Tables["NL_Nhan_Vien_Nghi_Viec_Chi_Tiet"].Rows[0]["Loai_Nghi"]:(int?)null;
				myNL_Nhan_Vien_Nghi_Viec_Chi_Tiet.Ly_Do=myDataSet.Tables["NL_Nhan_Vien_Nghi_Viec_Chi_Tiet"].Rows[0]["Ly_Do"]!=DBNull.Value?(string)myDataSet.Tables["NL_Nhan_Vien_Nghi_Viec_Chi_Tiet"].Rows[0]["Ly_Do"]:(string)null;
                myNL_Nhan_Vien_Nghi_Viec_Chi_Tiet.Ghi_Chu = myDataSet.Tables["NL_Nhan_Vien_Nghi_Viec_Chi_Tiet"].Rows[0]["Ghi_Chu"] != DBNull.Value ? (string)myDataSet.Tables["NL_Nhan_Vien_Nghi_Viec_Chi_Tiet"].Rows[0]["Ghi_Chu"] : (string)null;
			}
			return myNL_Nhan_Vien_Nghi_Viec_Chi_Tiet;
    	}
	}
}
#endregion 
#region Them 
public void Them(int? Ma_Nghi_Viec = null, int? Ma_Nhan_Vien = null, DateTime? Ngay_Nghi = null, int? Loai_Nghi = null, string Ly_Do = null, string Ghi_Chu = null)
{
	using (SqlConnection myConnection = new SqlConnection(ConnectionString))
	{
    	using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Nghi_Viec_Them", myConnection))
    	{
			myCommand.CommandType = CommandType.StoredProcedure;
			
			SqlParameter pMa_Nghi_Viec = new SqlParameter("@Ma_Nghi_Viec",SqlDbType.Int,4);
			pMa_Nghi_Viec.Value = Ma_Nghi_Viec;
			myCommand.Parameters.Add(pMa_Nghi_Viec);	
			
			SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien",SqlDbType.Int,4);
			pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
			myCommand.Parameters.Add(pMa_Nhan_Vien);
		
			SqlParameter pNgay_Nghi = new SqlParameter("@Ngay_Nghi",SqlDbType.DateTime,8);
			pNgay_Nghi.Value = Ngay_Nghi;
			myCommand.Parameters.Add(pNgay_Nghi);
		
			SqlParameter pLoai_Nghi = new SqlParameter("@Loai_Nghi",SqlDbType.Int,4);
			pLoai_Nghi.Value = Loai_Nghi;
			myCommand.Parameters.Add(pLoai_Nghi);
		
			SqlParameter pLy_Do = new SqlParameter("@Ly_Do",SqlDbType.NVarChar,500);
			pLy_Do.Value = Ly_Do;
			myCommand.Parameters.Add(pLy_Do);

            SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 500);
            pGhi_Chu.Value = Ghi_Chu;
            myCommand.Parameters.Add(pGhi_Chu);

    		myConnection.Open();
    		myCommand.ExecuteNonQuery();			
		}
	}	     
}	
#endregion
#region Cap_Nhat
public void Cap_Nhat(int? Ma_Nghi_Viec = null, int? Ma_Nhan_Vien = null, DateTime? Ngay_Nghi = null, int? Loai_Nghi = null, string Ly_Do = null, string Ghi_Chu = null)
{
	using (SqlConnection myConnection = new SqlConnection(ConnectionString))
	{
    	using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Nghi_Viec_Cap_Nhat", myConnection))
    	{
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlParameter pMa_Nghi_Viec = new SqlParameter("@Ma_Nghi_Viec",SqlDbType.Int,4);
			pMa_Nghi_Viec.Value = Ma_Nghi_Viec;
			myCommand.Parameters.Add(pMa_Nghi_Viec);
	
			SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien",SqlDbType.Int,4);
			pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
			myCommand.Parameters.Add(pMa_Nhan_Vien);
		
			SqlParameter pNgay_Nghi = new SqlParameter("@Ngay_Nghi",SqlDbType.DateTime,8);
			pNgay_Nghi.Value = Ngay_Nghi;
			myCommand.Parameters.Add(pNgay_Nghi);
		
			SqlParameter pLoai_Nghi = new SqlParameter("@Loai_Nghi",SqlDbType.Int,4);
			pLoai_Nghi.Value = Loai_Nghi;
			myCommand.Parameters.Add(pLoai_Nghi);
		
			SqlParameter pLy_Do = new SqlParameter("@Ly_Do",SqlDbType.NVarChar,500);
			pLy_Do.Value = Ly_Do;
			myCommand.Parameters.Add(pLy_Do);

            SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 500);
            pGhi_Chu.Value = Ghi_Chu;
            myCommand.Parameters.Add(pGhi_Chu);
			
       		myConnection.Open();
        	myCommand.ExecuteNonQuery();
        	       
		}
	}
}		
#endregion
#region Cap_Nhat
public void Cap_Nhat(NL_Nhan_Vien_Nghi_Viec_Chi_Tiet myNL_Nhan_Vien_Nghi_Viec_Chi_Tiet)
{
	using (SqlConnection myConnection = new SqlConnection(ConnectionString))
	{
    	using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Nghi_Viec_Cap_Nhat", myConnection))
    	{    	
    		myCommand.CommandType = CommandType.StoredProcedure;
					
			SqlParameter pMa_Nghi_Viec = new SqlParameter("@Ma_Nghi_Viec",SqlDbType.Int,4);
			pMa_Nghi_Viec.Value = myNL_Nhan_Vien_Nghi_Viec_Chi_Tiet.Ma_Nghi_Viec;
			myCommand.Parameters.Add(pMa_Nghi_Viec);
			
			SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien",SqlDbType.Int,4);
			pMa_Nhan_Vien.Value = myNL_Nhan_Vien_Nghi_Viec_Chi_Tiet.Ma_Nhan_Vien;
			myCommand.Parameters.Add(pMa_Nhan_Vien);
			
			SqlParameter pNgay_Nghi = new SqlParameter("@Ngay_Nghi",SqlDbType.DateTime,8);
			pNgay_Nghi.Value = myNL_Nhan_Vien_Nghi_Viec_Chi_Tiet.Ngay_Nghi;
			myCommand.Parameters.Add(pNgay_Nghi);
			
			SqlParameter pLoai_Nghi = new SqlParameter("@Loai_Nghi",SqlDbType.Int,4);
			pLoai_Nghi.Value = myNL_Nhan_Vien_Nghi_Viec_Chi_Tiet.Loai_Nghi;
			myCommand.Parameters.Add(pLoai_Nghi);
			
			SqlParameter pLy_Do = new SqlParameter("@Ly_Do",SqlDbType.NVarChar,500);
			pLy_Do.Value = myNL_Nhan_Vien_Nghi_Viec_Chi_Tiet.Ly_Do;
			myCommand.Parameters.Add(pLy_Do);

            SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 500);
            pGhi_Chu.Value = myNL_Nhan_Vien_Nghi_Viec_Chi_Tiet.Ghi_Chu;
            myCommand.Parameters.Add(pGhi_Chu);
		
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
    	using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Nghi_Viec_Cap_Nhat_Them", myConnection))
    	{
			myConnection.Open();
			myCommand.CommandType = CommandType.StoredProcedure;
			for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++){
				
			SqlParameter pMa_Nghi_Viec = new SqlParameter("@Ma_Nghi_Viec",SqlDbType.Int,4);
			pMa_Nghi_Viec.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nghi_Viec"];
			myCommand.Parameters.Add(pMa_Nghi_Viec);
		
			SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien",SqlDbType.Int,4);
			pMa_Nhan_Vien.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nhan_Vien"];
			myCommand.Parameters.Add(pMa_Nhan_Vien);
		
			SqlParameter pNgay_Nghi = new SqlParameter("@Ngay_Nghi",SqlDbType.DateTime,8);
			pNgay_Nghi.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Ngay_Nghi"];
			myCommand.Parameters.Add(pNgay_Nghi);
		
			SqlParameter pLoai_Nghi = new SqlParameter("@Loai_Nghi",SqlDbType.Int,4);
			pLoai_Nghi.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Loai_Nghi"];
			myCommand.Parameters.Add(pLoai_Nghi);
		
			SqlParameter pLy_Do = new SqlParameter("@Ly_Do",SqlDbType.NVarChar,500);
			pLy_Do.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ly_Do"];
			myCommand.Parameters.Add(pLy_Do);

            SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 500);
            pGhi_Chu.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ghi_Chu"];
            myCommand.Parameters.Add(pGhi_Chu);
        	
			myConnection.Open();
        	myCommand.ExecuteNonQuery();
        
        	}
		}
	} 
}		
#endregion

#region Cap_Nhat_Them
public void Cap_Nhat_Them(int? Ma_Nghi_Viec = null, int? Ma_Nhan_Vien = null, DateTime? Ngay_Nghi = null, int? Loai_Nghi = null, string Ly_Do = null, string Ghi_Chu = null)
{
	using (SqlConnection myConnection = new SqlConnection(ConnectionString))
	{		
    	using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Nghi_Viec_Cap_Nhat_Them", myConnection))
    	{			
			myCommand.CommandType = CommandType.StoredProcedure;
			
			SqlParameter pMa_Nghi_Viec = new SqlParameter("@Ma_Nghi_Viec",SqlDbType.Int,4);
			pMa_Nghi_Viec.Value = Ma_Nghi_Viec;
			myCommand.Parameters.Add(pMa_Nghi_Viec);
	
			SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien",SqlDbType.Int,4);
			pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
			myCommand.Parameters.Add(pMa_Nhan_Vien);
		
			SqlParameter pNgay_Nghi = new SqlParameter("@Ngay_Nghi",SqlDbType.DateTime,8);
			pNgay_Nghi.Value = Ngay_Nghi;
			myCommand.Parameters.Add(pNgay_Nghi);
		
			SqlParameter pLoai_Nghi = new SqlParameter("@Loai_Nghi",SqlDbType.Int,4);
			pLoai_Nghi.Value = Loai_Nghi;
			myCommand.Parameters.Add(pLoai_Nghi);
		
			SqlParameter pLy_Do = new SqlParameter("@Ly_Do",SqlDbType.NVarChar,500);
			pLy_Do.Value = Ly_Do;
			myCommand.Parameters.Add(pLy_Do);

            SqlParameter pGhi_Chu = new SqlParameter("@Ghi_Chu", SqlDbType.NVarChar, 500);
            pGhi_Chu.Value = Ghi_Chu;
            myCommand.Parameters.Add(pGhi_Chu);
			
    	    myConnection.Open();
        	myCommand.ExecuteNonQuery();        	
		}
	}
}
#endregion

#region Xoa
public void Xoa(int Ma_Nghi_Viec)
{
	using (SqlConnection myConnection = new SqlConnection(ConnectionString))
	{		
    	using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Nghi_Viec_Xoa", myConnection))
    	{			
			myCommand.CommandType = CommandType.StoredProcedure;
			
			SqlParameter pMa_Nghi_Viec = new SqlParameter("@Ma_Nghi_Viec",SqlDbType.Int,4);
			pMa_Nghi_Viec.Value = Ma_Nghi_Viec;
			myCommand.Parameters.Add(pMa_Nghi_Viec);
					
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
    	using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Nghi_Viec_Danh_Sach", myConnection))
    	{
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter myAdapter = new SqlDataAdapter();
			DataSet myDataSet = new DataSet();		
			myConnection.Open();
			myAdapter.SelectCommand = myCommand;
			myAdapter.Fill(myDataSet,"NL_Nhan_Vien_Nghi_Viec_Danh_Sach");                    
    		return myDataSet.Tables["NL_Nhan_Vien_Nghi_Viec_Danh_Sach"];
		}
	}
}
#endregion

#region Lay_Boi_NL_Nhan_Vien
public DataTable Lay_Boi_NL_Nhan_Vien(int Ma_Nhan_Vien)
{
	using (SqlConnection myConnection = new SqlConnection(ConnectionString))
	{		
    	using (SqlCommand myCommand = new SqlCommand("NL_Nhan_Vien_Nghi_Viec_Lay_Boi_NL_Nhan_Vien", myConnection))
    	{
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter myAdapter = new SqlDataAdapter();
			DataSet myDataSet = new DataSet();
			SqlParameter pMa_Nhan_Vien = new SqlParameter("@Ma_Nhan_Vien",SqlDbType.Int,4);
			pMa_Nhan_Vien.Value = Ma_Nhan_Vien;
			myCommand.Parameters.Add(pMa_Nhan_Vien);
						
    		myConnection.Open();
			myAdapter.SelectCommand = myCommand;
			myAdapter.Fill(myDataSet,"NL_Nhan_Vien_Nghi_Viec_Lay_Boi_NL_Nhan_Vien");                		    
    		return myDataSet.Tables["NL_Nhan_Vien_Nghi_Viec_Lay_Boi_NL_Nhan_Vien"];
		}
	}
}
#endregion

}
#endregion
}