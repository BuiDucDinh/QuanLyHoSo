using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic{
#region NL_DM_Ngach_Bac_He_So_Details
public class NL_DM_Ngach_Bac_He_So_Chi_Tiet
{		
	public int? Ma_Ngach_Bac_He_So=null; 
	public string Ma_Ngach=null; 
	public DateTime? Ngay_Quyet_Dinh=null; 
	public int? Bac=null; 
	public decimal? He_So=null; 
}
#endregion 
#region NL_DM_Ngach_Bac_He_So
public class NL_DM_Ngach_Bac_He_So
{	
private string ConnectionString;
public NL_DM_Ngach_Bac_He_So(string _ConnectionString)
{
	ConnectionString = _ConnectionString;
}
#region Lay
public NL_DM_Ngach_Bac_He_So_Chi_Tiet Lay(int Ma_Ngach_Bac_He_So)
{	
	using (SqlConnection myConnection = new SqlConnection(ConnectionString))
	{
    	using (SqlCommand myCommand = new SqlCommand("NL_DM_Ngach_Bac_He_So_Lay", myConnection))
    	{
			myCommand.CommandType = CommandType.StoredProcedure;
        	
			SqlParameter pMa_Ngach_Bac_He_So = new SqlParameter("@Ma_Ngach_Bac_He_So",SqlDbType.Int,4);
			pMa_Ngach_Bac_He_So.Value = Ma_Ngach_Bac_He_So;
			myCommand.Parameters.Add(pMa_Ngach_Bac_He_So);				
	  		
			SqlDataAdapter myAdapter = new SqlDataAdapter();
			DataSet myDataSet = new DataSet();
			myConnection.Open();
			myAdapter.SelectCommand = myCommand;
			myAdapter.Fill(myDataSet,"NL_DM_Ngach_Bac_He_So_Chi_Tiet");                        		
			NL_DM_Ngach_Bac_He_So_Chi_Tiet myNL_DM_Ngach_Bac_He_So_Chi_Tiet = new NL_DM_Ngach_Bac_He_So_Chi_Tiet();
			if(myDataSet.Tables["NL_DM_Ngach_Bac_He_So_Chi_Tiet"]!=null)
			{				
				myNL_DM_Ngach_Bac_He_So_Chi_Tiet.Ma_Ngach_Bac_He_So = Ma_Ngach_Bac_He_So;
				myNL_DM_Ngach_Bac_He_So_Chi_Tiet.Ma_Ngach=myDataSet.Tables["NL_DM_Ngach_Bac_He_So_Chi_Tiet"].Rows[0]["Ma_Ngach"]!=DBNull.Value?(string)myDataSet.Tables["NL_DM_Ngach_Bac_He_So_Chi_Tiet"].Rows[0]["Ma_Ngach"]:(string)null;
				myNL_DM_Ngach_Bac_He_So_Chi_Tiet.Ngay_Quyet_Dinh=myDataSet.Tables["NL_DM_Ngach_Bac_He_So_Chi_Tiet"].Rows[0]["Ngay_Quyet_Dinh"]!=DBNull.Value?(DateTime?)myDataSet.Tables["NL_DM_Ngach_Bac_He_So_Chi_Tiet"].Rows[0]["Ngay_Quyet_Dinh"]:(DateTime?)null;
				myNL_DM_Ngach_Bac_He_So_Chi_Tiet.Bac=myDataSet.Tables["NL_DM_Ngach_Bac_He_So_Chi_Tiet"].Rows[0]["Bac"]!=DBNull.Value?(int?)myDataSet.Tables["NL_DM_Ngach_Bac_He_So_Chi_Tiet"].Rows[0]["Bac"]:(int?)null;
				myNL_DM_Ngach_Bac_He_So_Chi_Tiet.He_So=myDataSet.Tables["NL_DM_Ngach_Bac_He_So_Chi_Tiet"].Rows[0]["He_So"]!=DBNull.Value?(decimal?)myDataSet.Tables["NL_DM_Ngach_Bac_He_So_Chi_Tiet"].Rows[0]["He_So"]:(decimal?)null;
			}
			return myNL_DM_Ngach_Bac_He_So_Chi_Tiet;
    	}
	}
}
#endregion 
#region Them 
public void Them(int? Ma_Ngach_Bac_He_So=null,string Ma_Ngach=null,DateTime? Ngay_Quyet_Dinh=null,int? Bac=null,decimal? He_So=null)
{
	using (SqlConnection myConnection = new SqlConnection(ConnectionString))
	{
    	using (SqlCommand myCommand = new SqlCommand("NL_DM_Ngach_Bac_He_So_Them", myConnection))
    	{
			myCommand.CommandType = CommandType.StoredProcedure;
			
			SqlParameter pMa_Ngach_Bac_He_So = new SqlParameter("@Ma_Ngach_Bac_He_So",SqlDbType.Int,4);
			pMa_Ngach_Bac_He_So.Value = Ma_Ngach_Bac_He_So;
			myCommand.Parameters.Add(pMa_Ngach_Bac_He_So);	
			
			SqlParameter pMa_Ngach = new SqlParameter("@Ma_Ngach",SqlDbType.VarChar,50);
			pMa_Ngach.Value = Ma_Ngach;
			myCommand.Parameters.Add(pMa_Ngach);
		
			SqlParameter pNgay_Quyet_Dinh = new SqlParameter("@Ngay_Quyet_Dinh",SqlDbType.DateTime,8);
			pNgay_Quyet_Dinh.Value = Ngay_Quyet_Dinh;
			myCommand.Parameters.Add(pNgay_Quyet_Dinh);
		
			SqlParameter pBac = new SqlParameter("@Bac",SqlDbType.Int,4);
			pBac.Value = Bac;
			myCommand.Parameters.Add(pBac);
		
			SqlParameter pHe_So = new SqlParameter("@He_So",SqlDbType.Float,8);
			pHe_So.Value = He_So;
			myCommand.Parameters.Add(pHe_So);
		
    		myConnection.Open();
    		myCommand.ExecuteNonQuery();			
		}
	}	     
}	
#endregion
#region Cap_Nhat
public void Cap_Nhat(int? Ma_Ngach_Bac_He_So=null,string Ma_Ngach=null,DateTime? Ngay_Quyet_Dinh=null,int? Bac=null,decimal? He_So=null)
{
	using (SqlConnection myConnection = new SqlConnection(ConnectionString))
	{
    	using (SqlCommand myCommand = new SqlCommand("NL_DM_Ngach_Bac_He_So_Cap_Nhat", myConnection))
    	{
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlParameter pMa_Ngach_Bac_He_So = new SqlParameter("@Ma_Ngach_Bac_He_So",SqlDbType.Int,4);
			pMa_Ngach_Bac_He_So.Value = Ma_Ngach_Bac_He_So;
			myCommand.Parameters.Add(pMa_Ngach_Bac_He_So);
	
			SqlParameter pMa_Ngach = new SqlParameter("@Ma_Ngach",SqlDbType.VarChar,50);
			pMa_Ngach.Value = Ma_Ngach;
			myCommand.Parameters.Add(pMa_Ngach);
		
			SqlParameter pNgay_Quyet_Dinh = new SqlParameter("@Ngay_Quyet_Dinh",SqlDbType.DateTime,8);
			pNgay_Quyet_Dinh.Value = Ngay_Quyet_Dinh;
			myCommand.Parameters.Add(pNgay_Quyet_Dinh);
		
			SqlParameter pBac = new SqlParameter("@Bac",SqlDbType.Int,4);
			pBac.Value = Bac;
			myCommand.Parameters.Add(pBac);
		
			SqlParameter pHe_So = new SqlParameter("@He_So",SqlDbType.Float,8);
			pHe_So.Value = He_So;
			myCommand.Parameters.Add(pHe_So);
		
	
			
       		myConnection.Open();
        	myCommand.ExecuteNonQuery();
        	       
		}
	}
}		
#endregion
#region Cap_Nhat
public void Cap_Nhat(NL_DM_Ngach_Bac_He_So_Chi_Tiet myNL_DM_Ngach_Bac_He_So_Chi_Tiet)
{
	using (SqlConnection myConnection = new SqlConnection(ConnectionString))
	{
    	using (SqlCommand myCommand = new SqlCommand("NL_DM_Ngach_Bac_He_So_Cap_Nhat", myConnection))
    	{    	
    		myCommand.CommandType = CommandType.StoredProcedure;
					
			SqlParameter pMa_Ngach_Bac_He_So = new SqlParameter("@Ma_Ngach_Bac_He_So",SqlDbType.Int,4);
			pMa_Ngach_Bac_He_So.Value = myNL_DM_Ngach_Bac_He_So_Chi_Tiet.Ma_Ngach_Bac_He_So;
			myCommand.Parameters.Add(pMa_Ngach_Bac_He_So);
			
			SqlParameter pMa_Ngach = new SqlParameter("@Ma_Ngach",SqlDbType.VarChar,50);
			pMa_Ngach.Value = myNL_DM_Ngach_Bac_He_So_Chi_Tiet.Ma_Ngach;
			myCommand.Parameters.Add(pMa_Ngach);
			
			SqlParameter pNgay_Quyet_Dinh = new SqlParameter("@Ngay_Quyet_Dinh",SqlDbType.DateTime,8);
			pNgay_Quyet_Dinh.Value = myNL_DM_Ngach_Bac_He_So_Chi_Tiet.Ngay_Quyet_Dinh;
			myCommand.Parameters.Add(pNgay_Quyet_Dinh);
			
			SqlParameter pBac = new SqlParameter("@Bac",SqlDbType.Int,4);
			pBac.Value = myNL_DM_Ngach_Bac_He_So_Chi_Tiet.Bac;
			myCommand.Parameters.Add(pBac);
			
			SqlParameter pHe_So = new SqlParameter("@He_So",SqlDbType.Float,8);
			pHe_So.Value = myNL_DM_Ngach_Bac_He_So_Chi_Tiet.He_So;
			myCommand.Parameters.Add(pHe_So);
			
		
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
    	using (SqlCommand myCommand = new SqlCommand("NL_DM_Ngach_Bac_He_So_Cap_Nhat_Them", myConnection))
    	{
			myConnection.Open();
			myCommand.CommandType = CommandType.StoredProcedure;
			for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++){
				
			SqlParameter pMa_Ngach_Bac_He_So = new SqlParameter("@Ma_Ngach_Bac_He_So",SqlDbType.Int,4);
			pMa_Ngach_Bac_He_So.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_Ngach_Bac_He_So"];
			myCommand.Parameters.Add(pMa_Ngach_Bac_He_So);
		
			SqlParameter pMa_Ngach = new SqlParameter("@Ma_Ngach",SqlDbType.VarChar,50);
			pMa_Ngach.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Ma_Ngach"];
			myCommand.Parameters.Add(pMa_Ngach);
		
			SqlParameter pNgay_Quyet_Dinh = new SqlParameter("@Ngay_Quyet_Dinh",SqlDbType.DateTime,8);
			pNgay_Quyet_Dinh.Value = (DateTime)myDataSet.Tables[strTableName].Rows[i]["Ngay_Quyet_Dinh"];
			myCommand.Parameters.Add(pNgay_Quyet_Dinh);
		
			SqlParameter pBac = new SqlParameter("@Bac",SqlDbType.Int,4);
			pBac.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Bac"];
			myCommand.Parameters.Add(pBac);
		
			SqlParameter pHe_So = new SqlParameter("@He_So",SqlDbType.Float,8);
			pHe_So.Value = (decimal)myDataSet.Tables[strTableName].Rows[i]["He_So"];
			myCommand.Parameters.Add(pHe_So);
		
        	
			myConnection.Open();
        	myCommand.ExecuteNonQuery();
        
        	}
		}
	} 
}		
#endregion

#region Cap_Nhat_Them
public void Cap_Nhat_Them(int? Ma_Ngach_Bac_He_So=null,string Ma_Ngach=null,DateTime? Ngay_Quyet_Dinh=null,int? Bac=null,decimal? He_So=null)
{
	using (SqlConnection myConnection = new SqlConnection(ConnectionString))
	{		
    	using (SqlCommand myCommand = new SqlCommand("NL_DM_Ngach_Bac_He_So_Cap_Nhat_Them", myConnection))
    	{			
			myCommand.CommandType = CommandType.StoredProcedure;
			
			SqlParameter pMa_Ngach_Bac_He_So = new SqlParameter("@Ma_Ngach_Bac_He_So",SqlDbType.Int,4);
			pMa_Ngach_Bac_He_So.Value = Ma_Ngach_Bac_He_So;
			myCommand.Parameters.Add(pMa_Ngach_Bac_He_So);
	
			SqlParameter pMa_Ngach = new SqlParameter("@Ma_Ngach",SqlDbType.VarChar,50);
			pMa_Ngach.Value = Ma_Ngach;
			myCommand.Parameters.Add(pMa_Ngach);
		
			SqlParameter pNgay_Quyet_Dinh = new SqlParameter("@Ngay_Quyet_Dinh",SqlDbType.DateTime,8);
			pNgay_Quyet_Dinh.Value = Ngay_Quyet_Dinh;
			myCommand.Parameters.Add(pNgay_Quyet_Dinh);
		
			SqlParameter pBac = new SqlParameter("@Bac",SqlDbType.Int,4);
			pBac.Value = Bac;
			myCommand.Parameters.Add(pBac);
		
			SqlParameter pHe_So = new SqlParameter("@He_So",SqlDbType.Float,8);
			pHe_So.Value = He_So;
			myCommand.Parameters.Add(pHe_So);
		
			
    	    myConnection.Open();
        	myCommand.ExecuteNonQuery();        	
		}
	}
}
#endregion

#region Xoa
public void Xoa(int Ma_Ngach_Bac_He_So)
{
	using (SqlConnection myConnection = new SqlConnection(ConnectionString))
	{		
    	using (SqlCommand myCommand = new SqlCommand("NL_DM_Ngach_Bac_He_So_Xoa", myConnection))
    	{			
			myCommand.CommandType = CommandType.StoredProcedure;
			
			SqlParameter pMa_Ngach_Bac_He_So = new SqlParameter("@Ma_Ngach_Bac_He_So",SqlDbType.Int,4);
			pMa_Ngach_Bac_He_So.Value = Ma_Ngach_Bac_He_So;
			myCommand.Parameters.Add(pMa_Ngach_Bac_He_So);
					
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
    	using (SqlCommand myCommand = new SqlCommand("NL_DM_Ngach_Bac_He_So_Danh_Sach", myConnection))
    	{
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter myAdapter = new SqlDataAdapter();
			DataSet myDataSet = new DataSet();		
			myConnection.Open();
			myAdapter.SelectCommand = myCommand;
			myAdapter.Fill(myDataSet,"NL_DM_Ngach_Bac_He_So_Danh_Sach");                    
    		return myDataSet.Tables["NL_DM_Ngach_Bac_He_So_Danh_Sach"];
		}
	}
}
#endregion




}
#endregion
}