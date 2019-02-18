using Ext.Net;
using QLHS_Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NghiepVu_QuyTrinh_QuyTrinhXuLy : System.Web.UI.Page
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
            }
            Initialization();
        }
    }
    private void Initialization()
    {
        stTrangthai.DataSource = Sys_Common.NV_TrangThaiXuLy.GetAll();
        stQuyTrinhDN.DataSource = Sys_Common.NV_LoaiQuyTrinh.GetAll();
        DataBind();
        Role role = getRole();
        btnDelete.Visible = role.Duoc_Xoa;
        btnUpdate.Visible = role.Duoc_Nhap;
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

        string sql = @"select ID,Ten,NgayBatDau,      
	                    (select TenLoai from LoaiQuyTrinh l where l.ID=q.IDQuyTrinh) as QuyTrinhDN,
	                    (select Ten from TrangThaiXuLy t where t.ID=TrangThai) as TrangThai,
	                    (select Ho_Ten+'-'+Hom_Thu+' - '+Dien_Thoai from HT_Nguoi_Dung where Ma_Nguoi_Dung=q.NguoiTao) as NguoiTao,
	                    (NguoiYeuCau+' - '+Email+' - '+SoDienThoai+' - '+DiaChi+' - '+ThongTin) as NguoiYeuCau 
                    from QuyTrinhXuLy q where 1=1";
        if (!string.IsNullOrEmpty(txtTen.Text))
        {
            sql += " and Ten like '%" + txtTen.Text + "%'";
        }
        try
        {
            int trangthai = int.Parse(cbTrangThai.Value.ToString());
            sql += " and TrangThai=" + trangthai;
        }
        catch { }
        try
        {
            int loaiquytrinh = int.Parse(cbQuyTrinhDN.Value.ToString());
            sql += " and IDQuyTrinh=(select ID from QuyTrinhDinhNghia dn where dn.LoaiQuyTrinh=" + loaiquytrinh + ")";
        }
        catch { }
        this.odsData.SelectParameters["WhereString"].DefaultValue = @"(" + sql + ") as A";
        this.odsData.SelectParameters["SortString"].DefaultValue = e.Sort + " " + e.Dir;
        this.odsData.DataBind();
    }
    protected void btnExport_Click(object sender, DirectEventArgs e) { }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        this.wdDetail.AutoLoad.Url = "~/NghiepVu/QuyTrinh/CapNhatQuyTrinhXuLy.aspx";
        this.wdDetail.Icon = Icon.Add;
        this.wdDetail.Title = "Tạo quy trình, thủ tục mới";
        this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
        this.wdDetail.Render(this.Form);
        this.wdDetail.Show();
    }
    protected void btnDelete_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gvData.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            Sys_Common.NV_CanBo.Xoa(int.Parse(row.RecordID));
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
        X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
        X.Msg.AddScript("#{stData}.reload();");
    }
    protected void gvData_DbClick(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gvData.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            this.wdDetail.AutoLoad.Url = "~/Nghiepvu/QuyTrinh/CapNhatQuyTrinhXuLy.aspx?id=" + row.RecordID;
            this.wdDetail.Icon = Icon.ApplicationEdit;
            this.wdDetail.Title = "Chỉnh sửa quy trình, thủ tục";
            this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
            this.wdDetail.Render(this.Form);
            this.wdDetail.Show();
            break;
        }
    }
    [DirectMethod]
    public void Command(string command, string value)
    {
        int ID = int.Parse(value);
        if (command == "Delete")
        {
            Sys_Common.NV_QuyTrinhDinhNghia.Xoa(ID);
            X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
            X.Msg.AddScript("#{stData}.reload();");
        }
        else if (command == "Edit")
        {
            this.wdDetail.AutoLoad.Url = "~/Nghiepvu/QuyTrinh/CapNhatQuyTrinhXuLy.aspx?id=" + ID;
            this.wdDetail.Icon = Icon.ApplicationEdit;
            this.wdDetail.Title = "Chỉnh sửa quy trình, thủ tục";
            this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
            this.wdDetail.Render(this.Form);
            this.wdDetail.Show();
        }
        else if (command == "Show")
        {
            this.wdDetail.AutoLoad.Url = "~/Nghiepvu/QuyTrinh/XemQuyTrinh.aspx?id=" + ID;
            this.wdDetail.Icon = Icon.ApplicationEdit;
            this.wdDetail.Title = "Trạng thái quy trình xử lý";
            this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
            this.wdDetail.Render(this.Form);
            this.wdDetail.Show();
        }
    }
    protected void gvData_Command(object sender, DirectEventArgs e)
    {
        string ID = e.ExtraParams["ID"];
        string command = e.ExtraParams["command"];
        if (command == "Delete")
        {
            Sys_Common.NV_QuyTrinhDinhNghia.Xoa(int.Parse(ID));
            X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
            X.Msg.AddScript("#{stData}.reload();");
        }
        else if (command == "Edit")
        {
        }
        else if (command == "CreateTheard")
        {
            this.wdDetail.AutoLoad.Url = "~/HT/QuyTrinh/CapNhatLuongDinhNghia.aspx?id=" + ID;
            this.wdDetail.Icon = Icon.ApplicationEdit;
            this.wdDetail.Title = "Cập nhật luồng xử lý";
            this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
            this.wdDetail.Render(this.Form);
            this.wdDetail.Show();
        }
    }
    private void ClearData()
    {
        hdID.Value = "";
        txtTen.Text = "";
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        X.Msg.AddScript("#{stData}.reload();");
    }
}