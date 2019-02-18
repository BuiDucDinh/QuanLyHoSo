using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using QLHS_Logic;
using Ext.Net;
using System.Data;
using QLHS_Logic;
public partial class Module : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["G_Ma_Nguoi_Dung"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!this.IsPostBack)
        {
            DataTable myTable = Sys_Common.RunTableBySQL("SELECT Ma_Du_An, Ten_Du_An, Icon FROM HT_Du_An WHERE Ma_Du_An IN (SELECT Ma_Du_An FROM HT_Vai_Tro_Du_An WHERE Ma_Vai_Tro IN (SELECT Ma_Vai_Tro FROM HT_Nguoi_Dung_Vai_Tro WHERE Ma_Nguoi_Dung = " + Session["G_Ma_Nguoi_Dung"].ToString() + ")) UNION SELECT 'XX',N'Thoát','./images/Thoat.png' ORDER BY Ma_Du_An");
            if (myTable != null)
            {
                this.Store1.DataSource = myTable;
                this.Store1.DataBind();
            }
        }
    }
    protected void SelectionChanged(object sender, DirectEventArgs e)
    {
        foreach (SelectedRow row in Dashboard.SelectedRows)
        {
            Session["G_Ma_Du_An"] = row.RecordID.ToString();
            break;
        }
        if (Session["G_Ma_Du_An"].ToString() == "XX")
        {
            Sys_Common.HT_NGUOI_DUNG_DANG_NHAP.Them(0, int.Parse(Session["G_Ma_Nguoi_Dung"].ToString()), DateTime.Now, "OUT");
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
        else
        {
            Sys_Common.HT_NGUOI_DUNG_DANG_NHAP.Them(0, int.Parse(Session["G_Ma_Nguoi_Dung"].ToString()), DateTime.Now, Session["G_Ma_Du_An"].ToString());
            Response.Redirect("Default.aspx");
        }
    }
}