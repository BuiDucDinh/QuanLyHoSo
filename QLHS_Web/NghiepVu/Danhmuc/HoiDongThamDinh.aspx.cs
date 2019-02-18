using Ext.Net;
using Models;
using QLHS_Logic;
using QLHS_Logic.NV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NghiepVu_Danhmuc_HoiDongThamDinh : System.Web.UI.Page
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
        if (Session["G_Theme"] != null)
        {
            DHM_Common.SetTheme(this.Page, int.Parse(Session["G_Theme"].ToString()));
            Role role = getRole();
            hdRole.Value = new JavaScriptSerializer().Serialize(role);
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
        this.odsData.SelectParameters["WhereString"].DefaultValue = @"(select * from HoiDongThamDinh) as A";

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
                NV_HoiDongThamDinh_ChiTiet myDetail = Sys_Common.NV_HoiDongThamDinh.GetById(id);  //Sys_Common.NL_DM_BIEN_CHE.Lay(int.Parse(row.RecordID));
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

    private void SetData(NV_HoiDongThamDinh_ChiTiet model)
    {
        btnUpdate.Text = "Cập nhật";
        btnUpdate.Icon = Icon.ApplicationEdit;

        hdID.Text = model.ID.ToString();
        txtTen.Text = model.TenHoiDong;
        txtMoTa.Text = model.MoTa;
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
                Sys_Common.NV_HoiDongThamDinh.Xoa(int.Parse(row.RecordID));
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
            NV_HoiDongThamDinh_ChiTiet model = new NV_HoiDongThamDinh_ChiTiet();
            model.TenHoiDong = txtTen.Text;
            model.MoTa = txtMoTa.Text;
            if (hdID.Text != "")
            {
                model.ID = int.Parse(hdID.Text);
                Sys_Common.NV_HoiDongThamDinh.update(model);
            }
            else
            {
                Sys_Common.NV_HoiDongThamDinh.them(model);
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
        txtMoTa.Text = "";
    }
}