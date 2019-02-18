using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using System.Data;
using QLHS_Logic;
using System.Web.Script.Serialization;
using QLHS_Logic.NV;
using System.Xml;
using System.Xml.Xsl;
public partial class NghiepVu_DiSanVanHoa_NgheNhan : System.Web.UI.Page
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
        string maForm = Request.QueryString["cn"].ToString();
        int maND = int.Parse(Session["G_Ma_Nguoi_Dung"].ToString());
        Role role = Sys_Common.HT_NGUOI_DUNG_VAI_TRO.getRoleUserByForm(maND, maForm);
        hdRole.Value = new JavaScriptSerializer().Serialize(role);
        stDiSan.DataSource = Sys_Common.NV_DiSanVanHoa.GetByLoai(0);
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
        if (txtHoTen.Text != "")
        {
            dk += " and HoTen like '%" + txtHoTen.Text + "%' or TenKhac like '%" + txtHoTen.Text + "%'";
        }
        if (cmbDiSan.Value != null && !string.IsNullOrEmpty(cmbDiSan.Value.ToString()))
        {
            dk += " and DiSanID=" + cmbDiSan.Value.ToString();
        }
        if (txtTungay.SelectedDate != txtTungay.MinDate)
        {
            try
            {
                dk += " and DATEDIFF(d," + txtTungay.SelectedDate.ToString("MM/dd/yyyy") + ",NgayCap)>=0";
            }
            catch { }
        }

        if (txtDenngay.SelectedDate != txtDenngay.MinDate)
        {
            try
            {
                dk += " and DATEDIFF(d,NgayCap," + txtDenngay.SelectedDate.ToString("MM/dd/yyyy") + ")>=0";
            }
            catch { }
        }
        this.odsData.SelectParameters["WhereString"].DefaultValue = @"(select * ,(select TenDiSan from DiSanVanHoa ds where ds.DiSanID=n.DiSanID) as DiSan	,(select  Ten_Dan_Toc from HT_Dan_Toc dt where dt.Ma_Dan_Toc=n.MaDanToc) as TenDanToc
                                                                    ,(select TenDanhHieu from DanhHieuNgheNhan dh where n.DanhHieu=dh.ID) as TenDanhHieu
                                                                    from NgheNhan n where 1=1" + dk + ") as A";

        this.odsData.SelectParameters["SortString"].DefaultValue = e.Sort + " " + e.Dir;

        this.odsData.DataBind();

    }
    protected void gvData_DbClick(object sender, DirectEventArgs e)
    {
        string maForm = Request.QueryString["cn"].ToString();
        Role role = getRole();
        if (role.Duoc_Sua)
        {
            RowSelectionModel sm = gvData.SelectionModel.Primary as RowSelectionModel;
            foreach (SelectedRow row in sm.SelectedRows)
            {
                this.wdDetail.AutoLoad.Url = "~/NghiepVu/Disanvanhoa/CapnhatNgheNhan.aspx?id=" + row.RecordID + "&cn=" + maForm;
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
            Sys_Common.NV_NgheNhan.Xoa(ID);
            NV_Log_ChiTiet log = createLog(ID, "delete");
            Sys_Common.NV_Log.them(log);

            X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
            X.Msg.AddScript("#{stData}.reload();");
            return;
        }
        else if (command == "Edit")
        {
            string maForm = Request.QueryString["cn"].ToString();
            this.wdDetail.AutoLoad.Url = "~/NghiepVu/Disanvanhoa/CapnhatNgheNhan.aspx?enable=1&id=" + ID + "&cn=" + maForm;
            this.wdDetail.Title = "Cập nhật di sản văn hóa";
            this.wdDetail.Icon = Icon.ApplicationEdit;
            this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
            this.wdDetail.Render(this.Form);
            this.wdDetail.Show();
        }
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        string maForm = Request.QueryString["cn"].ToString();
        this.wdDetail.AutoLoad.Url = "~/NghiepVu/Disanvanhoa/CapnhatNgheNhan.aspx?cn=" + maForm;
        this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
        this.wdDetail.Render(this.Form);
        this.wdDetail.Show();
    }
    protected void btnShow_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gvData.SelectionModel.Primary as RowSelectionModel;
        int id = int.Parse(sm.SelectedRows[0].RecordID);
        this.wdDetail.AutoLoad.Url = "~/NghiepVu/Disanvanhoa/ChiTietNgheNhan.aspx?id=" + id;
        this.wdDetail.Icon = Icon.ApplicationGet;
        this.wdDetail.Title = "Thông tin về nghệ nhân";
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
            Sys_Common.NV_NgheNhan.Xoa(id);

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
        RowSelectionModel sm = gvData.SelectionModel.Primary as RowSelectionModel;
        if (sm.SelectedRows.Count > 0)
        {
            //foreach (SelectedRow row in sm.SelectedRows)
            //{
            //    int id = int.Parse(row.RecordID);
            //}
        }
        else
        {
            StoreSubmitDataEventArgs eSubmit = new StoreSubmitDataEventArgs(json, null);
            XmlNode xml = eSubmit.Xml;

            this.Response.Clear();
            this.Response.ContentType = "application/vnd.ms-excel";
            this.Response.AddHeader("Content-Disposition", "attachment; filename=submittedData.xls");
            XslCompiledTransform xtExcel = new XslCompiledTransform();
            xtExcel.Load(Server.MapPath("/NghiepVu/Resources/Excel.xsl"));
            xtExcel.Transform(xml, null, this.Response.OutputStream);
            this.Response.End();
        }

        NV_Log_ChiTiet log = createLog(0, "export");
        Sys_Common.NV_Log.them(log);
    }
    protected void btnExportDeTail_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gvData.SelectionModel.Primary as RowSelectionModel;
        string maForm = Request.QueryString["cn"].ToString();

        int id = int.Parse(sm.SelectedRows[0].RecordID);
        NV_Log_ChiTiet log = createLog(id, "exportDetail");
        Sys_Common.NV_Log.them(log);
        this.wdDetail.Title = "In phiếu chi tiết nghệ nhân";
        this.wdDetail.AutoLoad.Url = "~/NghiepVu/ThongKe/ReportDiVat.aspx?id=" + id + "&cn=" + maForm;
        this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
        this.wdDetail.Render(this.Form);
        this.wdDetail.Show();
    }
    protected void btnLoc_Click(object sender, DirectEventArgs e)
    {
        X.Msg.AddScript("#{stData}.reload();");
    }
    protected void btnCancel_Click(object sender, DirectEventArgs e)
    {
        txtHoTen.Text = "";
        txtTungay.Text = "";
        txtDenngay.Text = "";
        cmbDiSan.Value = "";
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