using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLHS_Logic;
using Ext.Net;
public partial class HT_HT_NguoiDungVaiTro : System.Web.UI.Page
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
    protected void btnVaiTroBo_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gridCoVaiTro.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            Sys_Common.HT_NGUOI_DUNG_VAI_TRO.Xoa(int.Parse(row.RecordID));
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
        DataGridBinding();
    }

    protected void btnVaiTroThem_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gridKhongVaiTro.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            Sys_Common.HT_NGUOI_DUNG_VAI_TRO.Cap_Nhat_Them(0, int.Parse(Request.QueryString["Ma_Nguoi_Dung"].ToString()), int.Parse(row.RecordID));
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
        DataGridBinding();
    }
    private void DataGridBinding()
    {
        if (Request.QueryString["Ma_Nguoi_Dung"] != null)
        {
            dsCoVaiTro.DataSource = Sys_Common.HT_NGUOI_DUNG_VAI_TRO.Lay_Boi_HT_Vai_Tro_Chon(int.Parse(Request.QueryString["Ma_Nguoi_Dung"].ToString()), true);
            dsCoVaiTro.DataBind();

            dsKhongVaiTro.DataSource = Sys_Common.HT_NGUOI_DUNG_VAI_TRO.Lay_Boi_HT_Vai_Tro_Chon(int.Parse(Request.QueryString["Ma_Nguoi_Dung"].ToString()), false);
            dsKhongVaiTro.DataBind();
        }

    }
}