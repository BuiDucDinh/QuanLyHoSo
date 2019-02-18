using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using System.Data;
using QLHS_Logic;
using QLHS_Logic.NV;
using System.Web.Script.Serialization;
using System.Xml.Xsl;
using System.Xml;
public partial class NghiepVu_DiSanVanHoa_DiVatCoVat : System.Web.UI.Page
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
        if (!IsPostBack)
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
        Role role = getRole();
        hdRole.Value = new JavaScriptSerializer().Serialize(role);
        stThoiky.DataSource = Sys_Common.NV_ThoiKy.GetAll();
        stNoiLuuTru.DataSource = Sys_Common.NV_NoiLuuTru.GetAll();
        stDiSan.DataSource = Sys_Common.NV_DiSanVanHoa.GetByLoai(1);
        cbNgonNgu.Value = "vi";
        DataBind();
    }
    protected void odsData_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        (this.stData.Proxy[0] as PageProxy).Total = (int)e.OutputParameters["Count"];
    }
    protected void stData_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        this.odsData.SelectParameters["Start"].DefaultValue = (e.Start + 1).ToString();
        this.odsData.SelectParameters["Limit"].DefaultValue = (e.Limit + e.Start).ToString();
        string dk = "";
        if (!string.IsNullOrEmpty(txtTen.Text))
        {
            dk += " and Ten like N'%" + txtTen.Text + "%'";
        }
        if (!string.IsNullOrEmpty(txtSodangky.Text))
        {
            dk += " and MaSo like N'%" + txtSodangky.Text + "%'";
        }
        if (txtTungay.SelectedDate != txtTungay.MinDate)
        {
            try
            {
                dk += " and (DATEDIFF(d,'" + txtTungay.SelectedDate.ToString("MM/dd/yyyy") + "',NgayGiamDinh)>=0 or NgayGiamDinh is null)";
            }
            catch { }
        }

        if (txtDenngay.SelectedDate != txtDenngay.MinDate)
        {
            try
            {
                dk += " and (DATEDIFF(d,NgayGiamDinh,'" + txtDenngay.SelectedDate.ToString("MM/dd/yyyy") + "')>=0 or NgayGiamDinh is null)";
            }
            catch { }
        }
        if (cbNoiLuuTru.Value != null && cbNoiLuuTru.Value.ToString() != "")
        {
            dk += " and NoiLuuTru=" + cbNoiLuuTru.Value.ToString();
        }
        if (cbDisan.Value != null && cbDisan.Value.ToString() != "")
        {
            dk += " and DiSanID=" + cbDisan.Value.ToString();
        }
        if (cbThoiKy.Value != null && cbThoiKy.Value.ToString() != "")
        {
            dk += " and ThoiKy=" + cbThoiKy.Value.ToString();
        }
        if (!string.IsNullOrEmpty(txtTenDiTich.Text))
        {
            dk += " and DiSanID in (SELECT DiSanID FROM DiSanVanHoa JOIN DM_LoaiDiSan ON DM_LoaiDiSan.LoaiID = DiSanVanHoa.LoaiDiSan WHERE DM_LoaiDiSan.Loai=1 AND TenDiSan like N'%" + txtTenDiTich.Text + "%')";
        }
        this.odsData.SelectParameters["WhereString"].DefaultValue = @"(SELECT *,(select TenHoiDong from HoiDongThamDinh hd where hd.ID=dv.HoiDongGiamDinh) as TenHoiDong
                                                                            ,(case PhanLoai when 1 then N'Di vật' when 2 then N'Cổ vật' when 3 then N'Bảo vật quốc gia' end) as TenLoai 
                                                                            ,(select TenThoiKy from ThoiKy tk where tk.ID=dv.ThoiKy) as TenThoiKy
                                                                            ,(select Ten from NoiLuuTruHienVat lt where lt.ID=dv.NoiLuuTru) as BaoTang
                                                                           ,(select TenAnh from Image i where i.ImageID=dv.AnhDaiDien) as TenAnh
                                                                     FROM [DiVatCoVat] dv where Lang='"+cbNgonNgu.Value.ToString()+"' and TonTai=1 " + dk + ") as A";
        this.odsData.SelectParameters["SortString"].DefaultValue = e.Sort + " " + e.Dir;

        this.odsData.DataBind();

    }
    protected void gvData_DbClick(object sender, DirectEventArgs e)
    {
        Role role = getRole();
        if (role.Duoc_Sua)
        {
            RowSelectionModel sm = gvData.SelectionModel.Primary as RowSelectionModel;
            string maForm = Request.QueryString["cn"].ToString();
            foreach (SelectedRow row in sm.SelectedRows)
            {
                this.wdDetail.AutoLoad.Url = "~/NghiepVu/Disanvanhoa/CapnhatDiVat.aspx?enable=1&id=" + row.RecordID + "&cn=" + maForm;
                this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
                this.wdDetail.Render(this.Form);
                this.wdDetail.Show();
                break;
            }
        }
        else
        {
            X.Msg.Alert("Thông báo", "Bạn không có quyền sửa bản ghi !!!", new JFunction { Fn = "" }).Show();
        }
    }
    [DirectMethod]
    public void Command(string command, string value)
    {
        int ID = int.Parse(value);
        if (command == "Delete")
        {
            Sys_Common.NV_DiVatCoVat.Xoa(ID);
            int maND = int.Parse(Session["G_Ma_Nguoi_Dung"].ToString());
            NV_Log_ChiTiet log = createLog(ID, "delete");
            Sys_Common.NV_Log.them(log);

            X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
            X.Msg.AddScript("#{stData}.reload();");
            return;
        }
        else if (command == "Edit")
        {
            string maForm = Request.QueryString["cn"].ToString();
            this.wdDetail.AutoLoad.Url = "~/NghiepVu/Disanvanhoa/CapnhatDiVat.aspx?enable=1&id=" + ID + "&cn=" + maForm;
            this.wdDetail.Title = "Cập nhật di sản văn hóa";
            this.wdDetail.Icon = Icon.ApplicationEdit;
            this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
            this.wdDetail.Render(this.Form);
            this.wdDetail.Show();
        }

        else if (command == "Active")
        {
            NV_DiVatCoVat_ChiTiet divat = Sys_Common.NV_DiVatCoVat.GetById(ID);
            divat.TrangThai = !divat.TrangThai;
            bool check = Sys_Common.NV_DiVatCoVat.update(divat);
            if (check)
            {
                string thaotac = divat.TrangThai ? "active" : "unactive";
                NV_Log_ChiTiet log = createLog(ID, thaotac);
                Sys_Common.NV_Log.them(log);
                X.Msg.AddScript("#{stData}.reload();");
            }
        }
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        string maForm = Request.QueryString["cn"].ToString();
        this.wdDetail.AutoLoad.Url = "~/NghiepVu/Disanvanhoa/CapnhatDiVat.aspx?cn=" + maForm;
        this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
        this.wdDetail.Render(this.Form);
        this.wdDetail.Show();
    }
    protected void btnShow_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gvData.SelectionModel.Primary as RowSelectionModel;
        int id = int.Parse(sm.SelectedRows[0].RecordID);
        this.wdDetail.AutoLoad.Url = "~/NghiepVu/Disanvanhoa/ChiTietDiVat.aspx?id=" + id;
        this.wdDetail.Icon = Icon.ApplicationGet;
        this.wdDetail.Title = "Thông tin di vật, cổ vât, bảo vật quốc gia";
        this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
        this.wdDetail.Render(this.Form);
        this.wdDetail.Show();
    }
    protected void btnDelete_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gvData.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            int id = int.Parse(row.RecordID);
            Sys_Common.NV_DiVatCoVat.Xoa(id);
            NV_Log_ChiTiet log = createLog(id, "delete");
            Sys_Common.NV_Log.them(log);
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
        X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
        X.Msg.AddScript("#{stData}.reload();");
    }
    protected void btnExportDeTail_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gvData.SelectionModel.Primary as RowSelectionModel;
        string maForm = Request.QueryString["cn"].ToString();

        int id = int.Parse(sm.SelectedRows[0].RecordID);
        NV_Log_ChiTiet log = createLog(id, "exportDetail");
        Sys_Common.NV_Log.them(log);
        this.wdDetail.Title = "In phiếu chi tiết di vật";
        this.wdDetail.AutoLoad.Url = "~/NghiepVu/ThongKe/ReportDiVat.aspx?id=" + id + "&cn=" + maForm;
        this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
        this.wdDetail.Render(this.Form);
        this.wdDetail.Show();
    }
    protected void btnExport_Click(object sender, DirectEventArgs e)
    {
        string json = e.ExtraParams["data"].ToString();
        StoreSubmitDataEventArgs eSubmit = new StoreSubmitDataEventArgs(json, null);
        XmlNode xml = eSubmit.Xml;

        this.Response.Clear();
        this.Response.ContentType = "application/vnd.ms-excel";
        this.Response.AddHeader("Content-Disposition", "attachment; filename=submittedData.xls");
        XslCompiledTransform xtExcel = new XslCompiledTransform();
        xtExcel.Load(Server.MapPath("/NghiepVu/Resources/Excel.xsl"));
        xtExcel.Transform(xml, null, this.Response.OutputStream);
        this.Response.End();

        NV_Log_ChiTiet log = createLog(0, "export");
        Sys_Common.NV_Log.them(log);
    }
    protected void btnCancel_Click(object sender, DirectEventArgs e)
    {
        txtTungay.Text = "";
        txtDenngay.Text = "";
        txtTen.Text = "";
        txtSodangky.Text = "";
        cbNoiLuuTru.Value = "";
        cbThoiKy.Value = "";
        X.Msg.AddScript("#{stData}.reload();");
    }
    private Role getRole()
    {
        string maForm = Request.QueryString["cn"].ToString();
        int maND = int.Parse(Session["G_Ma_Nguoi_Dung"].ToString());
        Role role = Sys_Common.HT_NGUOI_DUNG_VAI_TRO.getRoleUserByForm(maND, maForm);
        return role;
    }
    private NV_Log_ChiTiet createLog(int id, string thaotac)
    {
        int maND = int.Parse(Session["G_Ma_Nguoi_Dung"].ToString());
        string maForm = Request.QueryString["cn"].ToString();
        NV_Log_ChiTiet log = new NV_Log_ChiTiet(maND, maForm);
        log.ThaoTac = thaotac;
        log.IDBanGhi = id;
        return log;
    }
}