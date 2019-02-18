using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using QLHS_Logic;

public partial class HT_HT_DonViYTChon : System.Web.UI.Page
{
    string sqlWhere = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["GIsLogin"] == null)
        {
            X.Msg.Show(new MessageBoxConfig
            {
                Title = "Thông báo",
                Message = "Phiên làm việc đã kết thúc do bạn ngưng sử dụng máy quá lâu. <br>Hãy ấn F5 để bắt đầu phiên làm việc mới.",
                Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING"),
                Closable = false
            });
            return;
        }
        if (!this.IsPostBack)
        {
            if (Session["G_Theme"] != null)
            {
                DHM_Common.SetTheme(this.Page, int.Parse(Session["G_Theme"].ToString()));
            }
        }
    }
    protected void odsHT_Don_Vi_YT_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        (this.dsHT_Don_Vi_YT.Proxy[0] as PageProxy).Total = (int)e.OutputParameters["Count"];
    }
    protected void dsHT_Don_Vi_YT_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        this.odsHT_Don_Vi_YT.SelectParameters["Start"].DefaultValue = (e.Start + 1).ToString();
        this.odsHT_Don_Vi_YT.SelectParameters["Limit"].DefaultValue = (e.Limit + e.Start).ToString();
        if (Request.QueryString["Module"] == "All")
        {
            sqlWhere = "1=1";
        }
        else
        {
            sqlWhere = Request.QueryString["Module"] + "=1";
        }
        if (e.Parameters["Filter"] == "")
        {
            this.odsHT_Don_Vi_YT.SelectParameters["WhereString"].DefaultValue = "HT_Don_Vi_YT WHERE " + sqlWhere;
        }
        else
        {
            this.odsHT_Don_Vi_YT.SelectParameters["WhereString"].DefaultValue = "HT_Don_Vi_YT WHERE " + sqlWhere + " AND "
            + "Ten_Don_Vi LIKE N'%" + e.Parameters["Filter"] + "%'";
        }
        this.odsHT_Don_Vi_YT.SelectParameters["SortString"].DefaultValue = e.Sort + " " + e.Dir;

        this.dsHT_Don_Vi_YT.DataBind();

    }

    
    protected void btnChoose_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gridHT_Don_Vi_YT.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            string id = row.RecordID;
            Session["HT_Ma_Don_Vi_Chon"] = id;
            X.Msg.AddScript("var parent = window.parent;parent.winHT_Don_Vi_YTe.hide();");
            break;
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
    }
    
    
}