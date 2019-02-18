using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using QLHS_Logic;
public partial class HT_HT_DonViYTDanhSach : System.Web.UI.Page
{
    private string sqlWhere="";
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
            cboTuyen.Value = "3";
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
        //if (cboTuyen.Value.ToString() == "2")
        //{
        //    sqlWhere = " AND Ma_Huyen = '" + cboMa_Huyen.Value.ToString() + "'";
        //}
        //else
        //{
        //    sqlWhere = " AND Ma_Huyen = '' AND Ma_Xa = ''";
        //}
        if (e.Parameters["Filter"] == "")
        {
            this.odsHT_Don_Vi_YT.SelectParameters["WhereString"].DefaultValue = "HT_Don_Vi_YT WHERE 1=1";// +sqlWhere;
        }
        else
        {
            this.odsHT_Don_Vi_YT.SelectParameters["WhereString"].DefaultValue = "HT_Don_Vi_YT WHERE "
            + "Ma_Don_Vi LIKE N'%" + e.Parameters["Filter"] + "%'";// +sqlWhere;
        }
        this.odsHT_Don_Vi_YT.SelectParameters["SortString"].DefaultValue = e.Sort + " " + e.Dir;

        this.dsHT_Don_Vi_YT.DataBind();

    }

    protected void btnDelete_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gridHT_Don_Vi_YT.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            Sys_Common.HT_DON_VI_YT.Xoa(int.Parse(row.RecordID.ToString()));
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
        X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();

        X.Msg.AddScript("#{dsHT_Don_Vi_YT}.reload();");
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gridHT_Don_Vi_YT.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            string id = row.RecordID;
            this.winHT_Don_Vi_YT.AutoLoad.Url = "HT_DonViYT.aspx?id=" + Guid.NewGuid().ToString() + "&Ma_Don_Vi=" + id;
            this.winHT_Don_Vi_YT.AutoLoad.Mode = LoadMode.IFrame;
            this.winHT_Don_Vi_YT.Render(this.Form);
            this.winHT_Don_Vi_YT.Show();
            break;
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
    }
    protected void btnInsert_Click(object sender, DirectEventArgs e)
    {
        this.winHT_Don_Vi_YT.AutoLoad.Url = "HT_DonViYT.aspx?id=" + Guid.NewGuid().ToString();
        this.winHT_Don_Vi_YT.AutoLoad.Mode = LoadMode.IFrame;
        this.winHT_Don_Vi_YT.Render(this.Form);
        this.winHT_Don_Vi_YT.Show();
    }
    protected void winHT_Don_Vi_YT_Hide(object sender, DirectEventArgs e)
    {
        X.Msg.AddScript("#{dsHT_Don_Vi_YT}.reload();");
    }
    protected void cboTuyen_Selected(object sender, DirectEventArgs e)
    {
        if (cboTuyen.Value.ToString() == "2")
        {
            cboMa_Huyen.Disabled = false;
            dsHuyen.DataSource = Sys_Common.HT_DM_HUYEN.Lay_Boi_HT_DM_Tinh(Sys_Common.G_MA_TINH);
            dsHuyen.DataBind();
        }
        else
        {
            cboMa_Huyen.GetStore().RemoveAll();
            cboMa_Huyen.SelectedItem.Value = "";
            cboMa_Huyen.Disabled = true;
        }
    }
    protected void btnOK_Click(object sender, DirectEventArgs e)
    {
        if (cboTuyen.Value.ToString() == "2")
        {
            if (cboMa_Huyen.Text.ToString() == "")
            {
                X.Msg.Alert("Thông báo", "Bạn phải chọn một Huyện để lọc !!!", new JFunction { Fn = "" }).Show();
                return;
            }
        }
        X.Msg.AddScript("#{dsHT_Don_Vi_YT}.reload();");
    }
    
}
