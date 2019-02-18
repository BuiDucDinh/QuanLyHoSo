using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLHS_Logic;
using Ext.Net;
using System.Data;
using System.Data.SqlClient;

public partial class HT_HT_VaiTroDuAn : System.Web.UI.Page
{
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
            DataGridBinding();
        }
    }
    protected void btnDuAnBo_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gridCoDuAn.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            Sys_Common.HT_VAI_TRO_DU_AN.Xoa(int.Parse(row.RecordID));
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
        DataGridBinding();
    }

    protected void btnDuAnThem_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gridKhongDuAn.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            Sys_Common.HT_VAI_TRO_DU_AN.Cap_Nhat_Them(0, int.Parse(Request.QueryString["Ma_Vai_Tro"].ToString()), row.RecordID);
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
        DataGridBinding();
    }
    private void DataGridBinding()
    {
        if (Request.QueryString["Ma_Vai_Tro"] != null)
        {
            dsCoDuAn.DataSource = Sys_Common.HT_VAI_TRO_DU_AN.Lay_Boi_HT_Du_An_Chon(int.Parse(Request.QueryString["Ma_Vai_Tro"].ToString()), true);
            dsCoDuAn.DataBind();

            dsKhongDuAn.DataSource = Sys_Common.HT_VAI_TRO_DU_AN.Lay_Boi_HT_Du_An_Chon(int.Parse(Request.QueryString["Ma_Vai_Tro"].ToString()), false);
            dsKhongDuAn.DataBind();
        }

    }
}