using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using QLHS_Logic;
using QLHS_Logic.NV;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Xsl;

public partial class DSVH_Quanlykehoachtubo_Dachsachkehoachtubo : System.Web.UI.Page
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

        this.odsData.SelectParameters["WhereString"].DefaultValue = @"(select KeHoachID,TenDuAn,DiaDiem,TrangThai,ChiPhiDuKien,ChiPhiThucTe,DuKienBatDau,DuKienHoanThanh,ThucTeBatDau,ThucTeHoanThanh,
	                                                                        (select TenDonVi from DonViTuBo dv where dv.DonViID=k.ChuDauTu) as ChuDauTu,
	                                                                        (select TenDonVi from DonViTuBo dv where dv.DonViID=k.CapQD) as CapQD,
	                                                                        (select TenDiSan from DiSanVanHoa d where d.DiSanID=k.DiSanID) as DiSan ,
                                                                            (select TenDonVi from DonViTuBo dv where dv.DonViID=k.DonViThietKe) as DonVi
                                                                       from KeHoachTuBo k" + where + ") as A";
        this.odsData.SelectParameters["SortString"].DefaultValue = e.Sort + " " + e.Dir;

        this.odsData.DataBind();

    }

    [DirectMethod]
    public void Command(string command, string value)
    {
        int ID = int.Parse(value);
        NV_KeHoachTuBo_ChiTiet bv = Sys_Common.NV_KeHoachTuBo.GetById(ID);
        if (command == "Delete")
        {
            Sys_Common.NV_KeHoachTuBo.Xoa(ID);
            NV_Log_ChiTiet log = createLog(ID, "delete");
            Sys_Common.NV_Log.them(log);
            X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
            X.Msg.AddScript("#{stData}.reload();");
        }
        else if (command == "Edit")
        {
            string maForm = Request.QueryString["cn"].ToString();
            this.wdDetail.AutoLoad.Url = "~/NghiepVu/Duantubo/Capnhatkehoachtubo.aspx?id=" + ID + "&cn=" + maForm;
            this.wdDetail.Icon = Icon.ApplicationEdit;
            this.wdDetail.Title = "Cập nhật dự án tu bổ";
            this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
            this.wdDetail.Render(this.Form);
            this.wdDetail.Show();
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
                this.wdDetail.AutoLoad.Url = "~/NghiepVu/Duantubo/Capnhatkehoachtubo.aspx?id=" + row.RecordID + "&cn=" + maForm;
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
    protected void btnLoc_Click(object sender, DirectEventArgs e)
    {
        X.Msg.AddScript("#{stData}.reload();");
    }
    protected void btnCancel_Click(object sender, DirectEventArgs e)
    {
        txtTieuDe.Text = "";
        txtTungay.Text = "";
        txtDenngay.Text = "";
        if (mcbDanhmuc.SelectedItems.Count > 0)
        {
            mcbDanhmuc.SelectedItems.Clear();
        }
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

    protected void btnDelete_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gvData.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            int id = int.Parse(row.RecordID);
            Sys_Common.NV_KeHoachTuBo.Xoa(id);
            NV_Log_ChiTiet log = createLog(id, "delete");
            Sys_Common.NV_Log.them(log);
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
        X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
        X.Msg.AddScript("#{stData}.reload();");
    }

    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        string maForm = Request.QueryString["cn"].ToString();
        this.wdDetail.AutoLoad.Url = "~/NghiepVu/Duantubo/Capnhatkehoachtubo.aspx?cn=" + maForm;
        this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
        this.wdDetail.Render(this.Form);
        this.wdDetail.Show();
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