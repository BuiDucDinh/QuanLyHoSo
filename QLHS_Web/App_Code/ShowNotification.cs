using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLHS_Logic;
using System.Data;
//using QLHS_Logic;
/// <summary>
/// Summary description for ShowNotification
/// </summary>
public class ShowNotification
{
    private string TableName;
    private string Ma_Ho_So;
    
	public ShowNotification(string TableName, string Ma_Ho_So)
	{
        this.Ma_Ho_So = Ma_Ho_So;
        this.TableName = TableName;
	}
    public string GetNotification()
    {
        DataTable myTable = Sys_Common.RunTableBySQL("SELECT TOP 10 * FROM " + TableName + " A LEFT JOIN HT_Nguoi_Dung B ON A.Ma_Nguoi_Dung = B.Ma_Nguoi_Dung WHERE Ma_Don = '" + Ma_Ho_So + "' ORDER BY Ngay_Ghi_Nhan");
        string result = "<font face='Tahoma' size='2'>";
        if (myTable != null)
        {
            for (int i = 0; i < myTable.Rows.Count; i++)
            {
                result += "<b>" + myTable.Rows[i]["Ho_Ten"].ToString() + " phản hồi lúc " + DateTime.Parse(myTable.Rows[i]["Ngay_Ghi_Nhan"].ToString()).ToString("dd/MM/yyyy hh:mm:ss") + "</b><br>" + myTable.Rows[i]["Noi_Dung_Phan_Hoi"].ToString()+"<br>";
            }
        }
        result += "</font>";
        return result;
    }
}