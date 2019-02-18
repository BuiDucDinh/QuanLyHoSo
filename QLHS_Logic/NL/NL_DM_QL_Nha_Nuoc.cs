using System;
using System.Data;
using System.Data.SqlClient;
namespace QLHS_Logic{
#region NL_DM_QL_Nha_Nuoc_Details
public class NL_DM_QL_Nha_Nuoc_Chi_Tiet
{		
	public int? Ma_QL_Nha_Nuoc=null; // Mã quản lý
	public string Trinh_Do=null; // Trình độ
	public int? Cap_Do=null; // 1.Dai hoc(cu nhan hanh chinh);2.Chuyen vien cao cap;3.Chuyen vien chinh;4.Chuyen vien
}
#endregion 
#region NL_DM_QL_Nha_Nuoc
public class NL_DM_QL_Nha_Nuoc
{	
private string ConnectionString;
public NL_DM_QL_Nha_Nuoc(string _ConnectionString)
{
	ConnectionString = _ConnectionString;
}
#region Lay
public NL_DM_QL_Nha_Nuoc_Chi_Tiet Lay(int Ma_QL_Nha_Nuoc)
{	
	using (SqlConnection myConnection = new SqlConnection(ConnectionString))
	{
    	using (SqlCommand myCommand = new SqlCommand("NL_DM_QL_Nha_Nuoc_Lay", myConnection))
    	{
			myCommand.CommandType = CommandType.StoredProcedure;
        	
			SqlParameter pMa_QL_Nha_Nuoc = new SqlParameter("@Ma_QL_Nha_Nuoc",SqlDbType.Int,4);
			pMa_QL_Nha_Nuoc.Value = Ma_QL_Nha_Nuoc;
			myCommand.Parameters.Add(pMa_QL_Nha_Nuoc);				
	  		
			SqlDataAdapter myAdapter = new SqlDataAdapter();
			DataSet myDataSet = new DataSet();
			myConnection.Open();
			myAdapter.SelectCommand = myCommand;
			myAdapter.Fill(myDataSet,"NL_DM_QL_Nha_Nuoc_Chi_Tiet");                        		
			NL_DM_QL_Nha_Nuoc_Chi_Tiet myNL_DM_QL_Nha_Nuoc_Chi_Tiet = new NL_DM_QL_Nha_Nuoc_Chi_Tiet();
			if(myDataSet.Tables["NL_DM_QL_Nha_Nuoc_Chi_Tiet"]!=null)
			{				
				myNL_DM_QL_Nha_Nuoc_Chi_Tiet.Ma_QL_Nha_Nuoc = Ma_QL_Nha_Nuoc;
				myNL_DM_QL_Nha_Nuoc_Chi_Tiet.Trinh_Do=myDataSet.Tables["NL_DM_QL_Nha_Nuoc_Chi_Tiet"].Rows[0]["Trinh_Do"]!=DBNull.Value?(string)myDataSet.Tables["NL_DM_QL_Nha_Nuoc_Chi_Tiet"].Rows[0]["Trinh_Do"]:(string)null;
				myNL_DM_QL_Nha_Nuoc_Chi_Tiet.Cap_Do=myDataSet.Tables["NL_DM_QL_Nha_Nuoc_Chi_Tiet"].Rows[0]["Cap_Do"]!=DBNull.Value?(int?)myDataSet.Tables["NL_DM_QL_Nha_Nuoc_Chi_Tiet"].Rows[0]["Cap_Do"]:(int?)null;
			}
			return myNL_DM_QL_Nha_Nuoc_Chi_Tiet;
    	}
	}
}
#endregion 
#region Them 
public void Them(int? Ma_QL_Nha_Nuoc=null,string Trinh_Do=null,int? Cap_Do=null)
{
	using (SqlConnection myConnection = new SqlConnection(ConnectionString))
	{
    	using (SqlCommand myCommand = new SqlCommand("NL_DM_QL_Nha_Nuoc_Them", myConnection))
    	{
			myCommand.CommandType = CommandType.StoredProcedure;
			
			SqlParameter pMa_QL_Nha_Nuoc = new SqlParameter("@Ma_QL_Nha_Nuoc",SqlDbType.Int,4);
			pMa_QL_Nha_Nuoc.Value = Ma_QL_Nha_Nuoc;
			myCommand.Parameters.Add(pMa_QL_Nha_Nuoc);	
			
			SqlParameter pTrinh_Do = new SqlParameter("@Trinh_Do",SqlDbType.NVarChar,500);
			pTrinh_Do.Value = Trinh_Do;
			myCommand.Parameters.Add(pTrinh_Do);
		
			SqlParameter pCap_Do = new SqlParameter("@Cap_Do",SqlDbType.Int,4);
			pCap_Do.Value = Cap_Do;
			myCommand.Parameters.Add(pCap_Do);
		
    		myConnection.Open();
    		myCommand.ExecuteNonQuery();			
		}
	}	     
}	
#endregion
#region Cap_Nhat
public void Cap_Nhat(int? Ma_QL_Nha_Nuoc=null,string Trinh_Do=null,int? Cap_Do=null)
{
	using (SqlConnection myConnection = new SqlConnection(ConnectionString))
	{
    	using (SqlCommand myCommand = new SqlCommand("NL_DM_QL_Nha_Nuoc_Cap_Nhat", myConnection))
    	{
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlParameter pMa_QL_Nha_Nuoc = new SqlParameter("@Ma_QL_Nha_Nuoc",SqlDbType.Int,4);
			pMa_QL_Nha_Nuoc.Value = Ma_QL_Nha_Nuoc;
			myCommand.Parameters.Add(pMa_QL_Nha_Nuoc);
	
			SqlParameter pTrinh_Do = new SqlParameter("@Trinh_Do",SqlDbType.NVarChar,500);
			pTrinh_Do.Value = Trinh_Do;
			myCommand.Parameters.Add(pTrinh_Do);
		
			SqlParameter pCap_Do = new SqlParameter("@Cap_Do",SqlDbType.Int,4);
			pCap_Do.Value = Cap_Do;
			myCommand.Parameters.Add(pCap_Do);
		
	
			
       		myConnection.Open();
        	myCommand.ExecuteNonQuery();
        	       
		}
	}
}		
#endregion
#region Cap_Nhat
public void Cap_Nhat(NL_DM_QL_Nha_Nuoc_Chi_Tiet myNL_DM_QL_Nha_Nuoc_Chi_Tiet)
{
	using (SqlConnection myConnection = new SqlConnection(ConnectionString))
	{
    	using (SqlCommand myCommand = new SqlCommand("NL_DM_QL_Nha_Nuoc_Cap_Nhat", myConnection))
    	{    	
    		myCommand.CommandType = CommandType.StoredProcedure;
					
			SqlParameter pMa_QL_Nha_Nuoc = new SqlParameter("@Ma_QL_Nha_Nuoc",SqlDbType.Int,4);
			pMa_QL_Nha_Nuoc.Value = myNL_DM_QL_Nha_Nuoc_Chi_Tiet.Ma_QL_Nha_Nuoc;
			myCommand.Parameters.Add(pMa_QL_Nha_Nuoc);
			
			SqlParameter pTrinh_Do = new SqlParameter("@Trinh_Do",SqlDbType.NVarChar,500);
			pTrinh_Do.Value = myNL_DM_QL_Nha_Nuoc_Chi_Tiet.Trinh_Do;
			myCommand.Parameters.Add(pTrinh_Do);
			
			SqlParameter pCap_Do = new SqlParameter("@Cap_Do",SqlDbType.Int,4);
			pCap_Do.Value = myNL_DM_QL_Nha_Nuoc_Chi_Tiet.Cap_Do;
			myCommand.Parameters.Add(pCap_Do);
			
		
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
    	using (SqlCommand myCommand = new SqlCommand("NL_DM_QL_Nha_Nuoc_Cap_Nhat_Them", myConnection))
    	{
			myConnection.Open();
			myCommand.CommandType = CommandType.StoredProcedure;
			for (int i = 0; i < myDataSet.Tables[strTableName].Rows.Count; i++){
				
			SqlParameter pMa_QL_Nha_Nuoc = new SqlParameter("@Ma_QL_Nha_Nuoc",SqlDbType.Int,4);
			pMa_QL_Nha_Nuoc.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Ma_QL_Nha_Nuoc"];
			myCommand.Parameters.Add(pMa_QL_Nha_Nuoc);
		
			SqlParameter pTrinh_Do = new SqlParameter("@Trinh_Do",SqlDbType.NVarChar,500);
			pTrinh_Do.Value = (string)myDataSet.Tables[strTableName].Rows[i]["Trinh_Do"];
			myCommand.Parameters.Add(pTrinh_Do);
		
			SqlParameter pCap_Do = new SqlParameter("@Cap_Do",SqlDbType.Int,4);
			pCap_Do.Value = (int)myDataSet.Tables[strTableName].Rows[i]["Cap_Do"];
			myCommand.Parameters.Add(pCap_Do);
		
        	
			myConnection.Open();
        	myCommand.ExecuteNonQuery();
        
        	}
		}
	} 
}		
#endregion

#region Cap_Nhat_Them
public void Cap_Nhat_Them(int? Ma_QL_Nha_Nuoc=null,string Trinh_Do=null,int? Cap_Do=null)
{
	using (SqlConnection myConnection = new SqlConnection(ConnectionString))
	{		
    	using (SqlCommand myCommand = new SqlCommand("NL_DM_QL_Nha_Nuoc_Cap_Nhat_Them", myConnection))
    	{			
			myCommand.CommandType = CommandType.StoredProcedure;
			
			SqlParameter pMa_QL_Nha_Nuoc = new SqlParameter("@Ma_QL_Nha_Nuoc",SqlDbType.Int,4);
			pMa_QL_Nha_Nuoc.Value = Ma_QL_Nha_Nuoc;
			myCommand.Parameters.Add(pMa_QL_Nha_Nuoc);
	
			SqlParameter pTrinh_Do = new SqlParameter("@Trinh_Do",SqlDbType.NVarChar,500);
			pTrinh_Do.Value = Trinh_Do;
			myCommand.Parameters.Add(pTrinh_Do);
		
			SqlParameter pCap_Do = new SqlParameter("@Cap_Do",SqlDbType.Int,4);
			pCap_Do.Value = Cap_Do;
			myCommand.Parameters.Add(pCap_Do);
		
			
    	    myConnection.Open();
        	myCommand.ExecuteNonQuery();        	
		}
	}
}
#endregion

#region Xoa
public void Xoa(int Ma_QL_Nha_Nuoc)
{
	using (SqlConnection myConnection = new SqlConnection(ConnectionString))
	{		
    	using (SqlCommand myCommand = new SqlCommand("NL_DM_QL_Nha_Nuoc_Xoa", myConnection))
    	{			
			myCommand.CommandType = CommandType.StoredProcedure;
			
			SqlParameter pMa_QL_Nha_Nuoc = new SqlParameter("@Ma_QL_Nha_Nuoc",SqlDbType.Int,4);
			pMa_QL_Nha_Nuoc.Value = Ma_QL_Nha_Nuoc;
			myCommand.Parameters.Add(pMa_QL_Nha_Nuoc);
					
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
    	using (SqlCommand myCommand = new SqlCommand("NL_DM_QL_Nha_Nuoc_Danh_Sach", myConnection))
    	{
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter myAdapter = new SqlDataAdapter();
			DataSet myDataSet = new DataSet();		
			myConnection.Open();
			myAdapter.SelectCommand = myCommand;
			myAdapter.Fill(myDataSet,"NL_DM_QL_Nha_Nuoc_Danh_Sach");                    
    		return myDataSet.Tables["NL_DM_QL_Nha_Nuoc_Danh_Sach"];
		}
	}
}
#endregion


}
#endregion
}