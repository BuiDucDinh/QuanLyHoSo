using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic
{
#region HT_Nguoi_Dung_Dang_Nhap_Details
public class HT_Nguoi_Dung_Dang_Nhap_Chi_Tiet
{		
	public int? Ma_Dang_Nhap=null; // Mã đăng nhập
	public int? Ma_Nguoi_Dung=null; // Mã người dùng
	public DateTime? Ngay_Dang_Nhap=null; // Ngày giờ thực hiện
	public string Kieu_Dang_Nhap=null; // LG:Login;AT:An toàn vệ sinh thực phẩm;BC:Báo cáo thống kê ngành;CP:Cấp  phép hành nghề Y Dược tư nhân;DB:Phòng chống dịch bệnh;DP:Quản lý dược phẩm;DV:Dịch vụ công trong lĩnh vực y tế dự phòng;HT:Quản trị hệ thống;KB:Quản lý thông tin công tác khám chữa bệnh;NL:Quản lý nguồn nhân lực;SK:Sức khỏe sinh sản, KHHGD;TB:Quản lý trang thiết bị y tế;OUT:Thoát khỏi hệ thống;
}
#endregion 
#region HT_Nguoi_Dung_Dang_Nhap
public class HT_Nguoi_Dung_Dang_Nhap
{	
private string ConnectionString;
public HT_Nguoi_Dung_Dang_Nhap(string _ConnectionString)
{
	ConnectionString = _ConnectionString;
}
#region Lay
public HT_Nguoi_Dung_Dang_Nhap_Chi_Tiet Lay(int Ma_Dang_Nhap)
{	
	using (SqlConnection myConnection = new SqlConnection(ConnectionString))
	{
    	using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Dang_Nhap_Lay", myConnection))
    	{
			myCommand.CommandType = CommandType.StoredProcedure;
        	
			SqlParameter pMa_Dang_Nhap = new SqlParameter("@Ma_Dang_Nhap",SqlDbType.Int,4);
			pMa_Dang_Nhap.Value = Ma_Dang_Nhap;
			myCommand.Parameters.Add(pMa_Dang_Nhap);				
	  		
			SqlDataAdapter myAdapter = new SqlDataAdapter();
			DataSet myDataSet = new DataSet();
			myConnection.Open();
			myAdapter.SelectCommand = myCommand;
			myAdapter.Fill(myDataSet,"HT_Nguoi_Dung_Dang_Nhap_Chi_Tiet");                        		
			HT_Nguoi_Dung_Dang_Nhap_Chi_Tiet myHT_Nguoi_Dung_Dang_Nhap_Chi_Tiet = new HT_Nguoi_Dung_Dang_Nhap_Chi_Tiet();
			if(myDataSet.Tables["HT_Nguoi_Dung_Dang_Nhap_Chi_Tiet"]!=null)
			{				
				myHT_Nguoi_Dung_Dang_Nhap_Chi_Tiet.Ma_Dang_Nhap = Ma_Dang_Nhap;
				myHT_Nguoi_Dung_Dang_Nhap_Chi_Tiet.Ma_Nguoi_Dung=myDataSet.Tables["HT_Nguoi_Dung_Dang_Nhap_Chi_Tiet"].Rows[0]["Ma_Nguoi_Dung"]!=DBNull.Value?(int?)myDataSet.Tables["HT_Nguoi_Dung_Dang_Nhap_Chi_Tiet"].Rows[0]["Ma_Nguoi_Dung"]:(int?)null;
				myHT_Nguoi_Dung_Dang_Nhap_Chi_Tiet.Ngay_Dang_Nhap=myDataSet.Tables["HT_Nguoi_Dung_Dang_Nhap_Chi_Tiet"].Rows[0]["Ngay_Dang_Nhap"]!=DBNull.Value?(DateTime?)myDataSet.Tables["HT_Nguoi_Dung_Dang_Nhap_Chi_Tiet"].Rows[0]["Ngay_Dang_Nhap"]:(DateTime?)null;
				myHT_Nguoi_Dung_Dang_Nhap_Chi_Tiet.Kieu_Dang_Nhap=myDataSet.Tables["HT_Nguoi_Dung_Dang_Nhap_Chi_Tiet"].Rows[0]["Kieu_Dang_Nhap"]!=DBNull.Value?(string)myDataSet.Tables["HT_Nguoi_Dung_Dang_Nhap_Chi_Tiet"].Rows[0]["Kieu_Dang_Nhap"]:(string)null;
			}
			return myHT_Nguoi_Dung_Dang_Nhap_Chi_Tiet;
    	}
	}
}
#endregion 
#region Them 
public void Them(int? Ma_Dang_Nhap=null,int? Ma_Nguoi_Dung=null,DateTime? Ngay_Dang_Nhap=null,string Kieu_Dang_Nhap=null)
{
	using (SqlConnection myConnection = new SqlConnection(ConnectionString))
	{
    	using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Dang_Nhap_Them", myConnection))
    	{
			myCommand.CommandType = CommandType.StoredProcedure;
			
			SqlParameter pMa_Dang_Nhap = new SqlParameter("@Ma_Dang_Nhap",SqlDbType.Int,4);
			pMa_Dang_Nhap.Value = Ma_Dang_Nhap;
			myCommand.Parameters.Add(pMa_Dang_Nhap);	
			
			SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung",SqlDbType.Int,4);
			pMa_Nguoi_Dung.Value = Ma_Nguoi_Dung;
			myCommand.Parameters.Add(pMa_Nguoi_Dung);
		
			SqlParameter pNgay_Dang_Nhap = new SqlParameter("@Ngay_Dang_Nhap",SqlDbType.DateTime,8);
			pNgay_Dang_Nhap.Value = Ngay_Dang_Nhap;
			myCommand.Parameters.Add(pNgay_Dang_Nhap);
		
			SqlParameter pKieu_Dang_Nhap = new SqlParameter("@Kieu_Dang_Nhap",SqlDbType.VarChar,10);
			pKieu_Dang_Nhap.Value = Kieu_Dang_Nhap;
			myCommand.Parameters.Add(pKieu_Dang_Nhap);
		
    		myConnection.Open();
    		myCommand.ExecuteNonQuery();			
		}
	}	     
}	
#endregion
#region Cap_Nhat
public void Cap_Nhat(int? Ma_Dang_Nhap=null,int? Ma_Nguoi_Dung=null,DateTime? Ngay_Dang_Nhap=null,string Kieu_Dang_Nhap=null)
{
	using (SqlConnection myConnection = new SqlConnection(ConnectionString))
	{
    	using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Dang_Nhap_Cap_Nhat", myConnection))
    	{
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlParameter pMa_Dang_Nhap = new SqlParameter("@Ma_Dang_Nhap",SqlDbType.Int,4);
			pMa_Dang_Nhap.Value = Ma_Dang_Nhap;
			myCommand.Parameters.Add(pMa_Dang_Nhap);
	
			SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung",SqlDbType.Int,4);
			pMa_Nguoi_Dung.Value = Ma_Nguoi_Dung;
			myCommand.Parameters.Add(pMa_Nguoi_Dung);
		
			SqlParameter pNgay_Dang_Nhap = new SqlParameter("@Ngay_Dang_Nhap",SqlDbType.DateTime,8);
			pNgay_Dang_Nhap.Value = Ngay_Dang_Nhap;
			myCommand.Parameters.Add(pNgay_Dang_Nhap);
		
			SqlParameter pKieu_Dang_Nhap = new SqlParameter("@Kieu_Dang_Nhap",SqlDbType.VarChar,10);
			pKieu_Dang_Nhap.Value = Kieu_Dang_Nhap;
			myCommand.Parameters.Add(pKieu_Dang_Nhap);
		
	
			
       		myConnection.Open();
        	myCommand.ExecuteNonQuery();
        	       
		}
	}
}		
#endregion
#region Cap_Nhat
public void Cap_Nhat(HT_Nguoi_Dung_Dang_Nhap_Chi_Tiet myHT_Nguoi_Dung_Dang_Nhap_Chi_Tiet)
{
	using (SqlConnection myConnection = new SqlConnection(ConnectionString))
	{
    	using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Dang_Nhap_Cap_Nhat", myConnection))
    	{    	
    		myCommand.CommandType = CommandType.StoredProcedure;
					
			SqlParameter pMa_Dang_Nhap = new SqlParameter("@Ma_Dang_Nhap",SqlDbType.Int,4);
			pMa_Dang_Nhap.Value = myHT_Nguoi_Dung_Dang_Nhap_Chi_Tiet.Ma_Dang_Nhap;
			myCommand.Parameters.Add(pMa_Dang_Nhap);
			
			SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung",SqlDbType.Int,4);
			pMa_Nguoi_Dung.Value = myHT_Nguoi_Dung_Dang_Nhap_Chi_Tiet.Ma_Nguoi_Dung;
			myCommand.Parameters.Add(pMa_Nguoi_Dung);
			
			SqlParameter pNgay_Dang_Nhap = new SqlParameter("@Ngay_Dang_Nhap",SqlDbType.DateTime,8);
			pNgay_Dang_Nhap.Value = myHT_Nguoi_Dung_Dang_Nhap_Chi_Tiet.Ngay_Dang_Nhap;
			myCommand.Parameters.Add(pNgay_Dang_Nhap);
			
			SqlParameter pKieu_Dang_Nhap = new SqlParameter("@Kieu_Dang_Nhap",SqlDbType.VarChar,10);
			pKieu_Dang_Nhap.Value = myHT_Nguoi_Dung_Dang_Nhap_Chi_Tiet.Kieu_Dang_Nhap;
			myCommand.Parameters.Add(pKieu_Dang_Nhap);
			
		
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
    	using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Dang_Nhap_Cap_Nhat_Them", myConnection))
    	{
			myConnection.Open();
			myCommand.CommandType = CommandType.StoredProcedure;
			for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++){
				
			SqlParameter pMa_Dang_Nhap = new SqlParameter("@Ma_Dang_Nhap",SqlDbType.Int,4);
			pMa_Dang_Nhap.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Dang_Nhap"];
			myCommand.Parameters.Add(pMa_Dang_Nhap);
		
			SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung",SqlDbType.Int,4);
			pMa_Nguoi_Dung.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Nguoi_Dung"];
			myCommand.Parameters.Add(pMa_Nguoi_Dung);
		
			SqlParameter pNgay_Dang_Nhap = new SqlParameter("@Ngay_Dang_Nhap",SqlDbType.DateTime,8);
			pNgay_Dang_Nhap.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Ngay_Dang_Nhap"];
			myCommand.Parameters.Add(pNgay_Dang_Nhap);
		
			SqlParameter pKieu_Dang_Nhap = new SqlParameter("@Kieu_Dang_Nhap",SqlDbType.VarChar,10);
			pKieu_Dang_Nhap.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Kieu_Dang_Nhap"];
			myCommand.Parameters.Add(pKieu_Dang_Nhap);
		
        	
			myConnection.Open();
        	myCommand.ExecuteNonQuery();
        
        	}
		}
	} 
}		
#endregion

#region Cap_Nhat_Them
public void Cap_Nhat_Them(int? Ma_Dang_Nhap=null,int? Ma_Nguoi_Dung=null,DateTime? Ngay_Dang_Nhap=null,string Kieu_Dang_Nhap=null)
{
	using (SqlConnection myConnection = new SqlConnection(ConnectionString))
	{		
    	using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Dang_Nhap_Cap_Nhat_Them", myConnection))
    	{			
			myCommand.CommandType = CommandType.StoredProcedure;
			
			SqlParameter pMa_Dang_Nhap = new SqlParameter("@Ma_Dang_Nhap",SqlDbType.Int,4);
			pMa_Dang_Nhap.Value = Ma_Dang_Nhap;
			myCommand.Parameters.Add(pMa_Dang_Nhap);
	
			SqlParameter pMa_Nguoi_Dung = new SqlParameter("@Ma_Nguoi_Dung",SqlDbType.Int,4);
			pMa_Nguoi_Dung.Value = Ma_Nguoi_Dung;
			myCommand.Parameters.Add(pMa_Nguoi_Dung);
		
			SqlParameter pNgay_Dang_Nhap = new SqlParameter("@Ngay_Dang_Nhap",SqlDbType.DateTime,8);
			pNgay_Dang_Nhap.Value = Ngay_Dang_Nhap;
			myCommand.Parameters.Add(pNgay_Dang_Nhap);
		
			SqlParameter pKieu_Dang_Nhap = new SqlParameter("@Kieu_Dang_Nhap",SqlDbType.VarChar,10);
			pKieu_Dang_Nhap.Value = Kieu_Dang_Nhap;
			myCommand.Parameters.Add(pKieu_Dang_Nhap);
		
			
    	    myConnection.Open();
        	myCommand.ExecuteNonQuery();        	
		}
	}
}
#endregion

#region Xoa
public void Xoa(int Ma_Dang_Nhap)
{
	using (SqlConnection myConnection = new SqlConnection(ConnectionString))
	{		
    	using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Dang_Nhap_Xoa", myConnection))
    	{			
			myCommand.CommandType = CommandType.StoredProcedure;
			
			SqlParameter pMa_Dang_Nhap = new SqlParameter("@Ma_Dang_Nhap",SqlDbType.Int,4);
			pMa_Dang_Nhap.Value = Ma_Dang_Nhap;
			myCommand.Parameters.Add(pMa_Dang_Nhap);
					
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
    	using (SqlCommand myCommand = new SqlCommand("HT_Nguoi_Dung_Dang_Nhap_Danh_Sach", myConnection))
    	{
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter myAdapter = new SqlDataAdapter();
			DataSet myDataSet = new DataSet();		
			myConnection.Open();
			myAdapter.SelectCommand = myCommand;
			myAdapter.Fill(myDataSet,"HT_Nguoi_Dung_Dang_Nhap_Danh_Sach");                    
    		return myDataSet.Tables["HT_Nguoi_Dung_Dang_Nhap_Danh_Sach"];
		}
	}
}
#endregion


}
#endregion
}