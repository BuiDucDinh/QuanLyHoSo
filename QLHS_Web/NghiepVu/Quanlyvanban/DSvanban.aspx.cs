using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using System.IO;
using System.Reflection;
using QLHS_Logic;
using QLHS_Logic.NV;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Xsl;

public partial class DSVH_Quanlyvanban_Capnhatbaiviet : System.Web.UI.Page
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
        }
        if (!IsPostBack)
        {
            Initialization();
        }
    }
    private void Initialization()
    {
        Role role = getRole();
        hdRole.Value = new JavaScriptSerializer().Serialize(role);
        stLoaiVB.DataSource = Sys_Common.NV_LoaiVanBan.GetAll();
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
        string where = "";
        if (cboLoaiVB.Value != null && !string.IsNullOrEmpty(cboLoaiVB.Value.ToString()))
        {
            where += " and LoaiVanBan=" + cboLoaiVB.Value.ToString();
        }
        if (!string.IsNullOrEmpty(txtTenvanban.Text))
        {
            where += " and TenVanBan like '%" + txtTenvanban.Text + "%'";
        }
        if (dtTuNgay.SelectedDate != dtTuNgay.MinDate)
        {
            try
            {
                where += " and (DATEDIFF(d,'" + dtTuNgay.SelectedDate.ToString("MM/dd/yyyy") + "',NgayBanHanh)>=0 or NgayBanHanh is null)";
            }
            catch { }
        }
        if (dtDenNgay.SelectedDate != dtDenNgay.MinDate)
        {
            try
            {
                where += " and (DATEDIFF(d,NgayBanHanh,'" + dtDenNgay.SelectedDate.ToString("MM/dd/yyyy") + "')>=0 or NgayBanHanh is null)";
            }
            catch { }
        }
        if (cmbCoquan.Value != null && !string.IsNullOrEmpty(cmbCoquan.Value.ToString()))
        {
            where += " and DonViBanHang=" + cmbCoquan.Value.ToString();
        }
        this.odsData.SelectParameters["WhereString"].DefaultValue = @"(SELECT VanBanID, TenVanBan,Duyet, (select TenLoaiVanBan from DM_LoaiVanBan where DM_LoaiVanBan.LoaiVanBanID = VanBan.LoaiVanBan) as TenLoaiVanBan,
                                                                                    DonViBanHanh, NgayBanHanh, MoTa FROM VanBan where TonTai=1" + where + ") as A";
        this.odsData.SelectParameters["SortString"].DefaultValue = e.Sort + " " + e.Dir;
        this.odsData.DataBind();
    }
    [DirectMethod]
    public void Command(string command, string value)
    {
        int ID = int.Parse(value);
        NV_VanBan_ChiTiet bv = Sys_Common.NV_VanBan.GetById(ID);
        if (command == "Delete")
        {
            Sys_Common.NV_VanBan.Xoa(ID);
            NV_Log_ChiTiet log = createLog(ID, "delete");
            Sys_Common.NV_Log.them(log);
            X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
            X.Msg.AddScript("#{stData}.reload();");
        }
        else if (command == "Edit")
        {
            string maForm = Request.QueryString["cn"].ToString();
            this.wdDetail.AutoLoad.Url = "~/NghiepVu/Quanlyvanban/CapnhatVanBan.aspx?id=" + ID + "&cn=" + maForm;
            this.wdDetail.Icon = Icon.ApplicationEdit;
            this.wdDetail.Title = "Cập nhật văn bản";
            this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
            this.wdDetail.Render(this.Form);
            this.wdDetail.Show();
        }
        else if (command == "Active")
        {
            NV_VanBan_ChiTiet vb = Sys_Common.NV_VanBan.GetById(ID);
            vb.Duyet = !vb.Duyet;
            bool check = Sys_Common.NV_VanBan.update(vb);
            if (check)
            {
                string thaotac = vb.Duyet ? "active" : "unactive";
                NV_Log_ChiTiet log = createLog(ID, thaotac);
                Sys_Common.NV_Log.them(log);
                X.Msg.AddScript("#{stData}.reload();");
            }
        }
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
                this.wdDetail.AutoLoad.Url = "~/NghiepVu/Quanlyvanban/CapnhatVanBan.aspx?id=" + row.RecordID + "&cn=" + maForm;
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

    protected void btnCancel_Click(object sender, DirectEventArgs e)
    {
        txtTenvanban.Text = "";
        dtDenNgay.Text = "";
        dtTuNgay.Text = "";
        cboLoaiVB.Value = "";
        cmbCoquan.Value = "";
        X.Msg.AddScript("#{stData}.reload();");
    }
    protected void btnLoc_Click(object sender, DirectEventArgs e)
    {
        X.Msg.AddScript("#{stData}.reload();");
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        string maForm = Request.QueryString["cn"].ToString();
        this.wdDetail.AutoLoad.Url = "~/NghiepVu/Quanlyvanban/CapnhatVanBan.aspx?cn=" + maForm;
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
            Sys_Common.NV_VanBan.Xoa(id);
            NV_Log_ChiTiet log = createLog(id, "delete");
            Sys_Common.NV_Log.them(log);
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
        X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
        X.Msg.AddScript("#{stData}.reload();");
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