using Ext.Net;
using Models;
using QLHS_Logic;
using QLHS_Logic.NV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NghiepVu_KinhPhi_LoaiNguonKinhPhi : System.Web.UI.Page
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
            if (Session["G_Theme"] != null)
            {
                DHM_Common.SetTheme(this.Page, int.Parse(Session["G_Theme"].ToString()));
                Role role = getRole();
                btnDelete.Visible = role.Duoc_Xoa;
                btnUpdate.Visible = role.Duoc_Nhap;
            }
        }
    }
    private Role getRole()
    {
        string maForm = Request.QueryString["cn"].ToString();
        int maND = int.Parse(Session["G_Ma_Nguoi_Dung"].ToString());
        Role role = Sys_Common.HT_NGUOI_DUNG_VAI_TRO.getRoleUserByForm(maND, maForm);
        return role;
    }
    protected void odsData_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        (this.stData.Proxy[0] as PageProxy).Total = (int)e.OutputParameters["Count"];
    }
    protected void stData_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        this.odsData.SelectParameters["Start"].DefaultValue = (e.Start + 1).ToString();
        this.odsData.SelectParameters["Limit"].DefaultValue = (e.Limit + e.Start).ToString();
        if (e.Parameters["Filter"] == "")
        {
            this.odsData.SelectParameters["WhereString"].DefaultValue = "(select * from DM_LoaiNguonKinhPhi) as A";
        }
        this.odsData.SelectParameters["SortString"].DefaultValue = e.Sort + " " + e.Dir;

        this.odsData.DataBind();

    }
    protected void gvData_DbClick(object sender, DirectEventArgs e)
    {
        Role role = getRole();
        if (role.Duoc_Sua)
        {
            RowSelectionModel sm = gvData.SelectionModel.Primary as RowSelectionModel;
            foreach (SelectedRow row in sm.SelectedRows)
            {
                int id = int.Parse(row.RecordID);
                NV_LoaiNguonKinhPhi_ChiTiet myDetail = Sys_Common.NV_LoaiNguonKinhPhi.GetById(id);
                SetData(myDetail);
                break;
            }
            sm.SelectedRows.Clear();
            sm.UpdateSelection();
        }
        else
        {
            X.Msg.Alert("Thông báo", "Bạn không có quyền sửa bản ghi !!!", new JFunction { Fn = "" }).Show();
        }
    }

    private void SetData(NV_LoaiNguonKinhPhi_ChiTiet model)
    {
        btnUpdate.Text = "Cập nhật";
        btnUpdate.Icon = Icon.ApplicationEdit;
        hdID.Text = model.ID.ToString();
        txtTen.Text = model.TenLoai;
        txtMota.Text = model.MoTa;
    }
    protected void btnExport_Click(object sender, DirectEventArgs e) { }
    protected void btnCancel_Click(object sender, DirectEventArgs e)
    {
        ClearData();
    }
    protected void btnDelete_Click(object sender, DirectEventArgs e)
    {
        Role role = getRole();
        if (role.Duoc_Xoa)
        {
            RowSelectionModel sm = gvData.SelectionModel.Primary as RowSelectionModel;
            foreach (SelectedRow row in sm.SelectedRows)
            {
                Sys_Common.NV_LoaiNguonKinhPhi.Xoa(int.Parse(row.RecordID));
            }
            sm.SelectedRows.Clear();
            sm.UpdateSelection();
            X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
            X.Msg.AddScript("#{stData}.reload();");
        }
        else
        {
            X.Msg.Alert("Thông báo", "Bạn không có quyền xóa bản ghi !!!", new JFunction { Fn = "" }).Show();
        }
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        if (FormValidate())
        {
            NV_LoaiNguonKinhPhi_ChiTiet model = new NV_LoaiNguonKinhPhi_ChiTiet();
            model.TenLoai = txtTen.Text;
            model.MoTa = txtMota.Text;
            if (hdID.Text != "")
            {
                model.ID = int.Parse(hdID.Text);
                Sys_Common.NV_LoaiNguonKinhPhi.update(model);
            }
            else
            {
                Sys_Common.NV_LoaiNguonKinhPhi.them(model);
            }
            ClearData();
            X.Msg.Alert("Thông báo", "Đã cập nhật thành công !!!", new JFunction { Fn = "" }).Show();
            X.Msg.AddScript("#{stData}.reload();");
        }
    }
    private bool FormValidate()
    {
        if (string.IsNullOrEmpty(txtTen.Text.Trim()))
        {
            X.Msg.Alert("Thông báo", "Thiếu thông tin ", new JFunction { Fn = "" }).Show();
            return false;
        }
        return true;
    }
    private void ClearData()
    {
        btnUpdate.Text = "Thêm mới";
        btnUpdate.Icon = Icon.Add;
        hdID.Value = "";
        txtTen.Text = "";
        txtMota.Text = "";
    }
}