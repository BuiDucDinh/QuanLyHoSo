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
using System.Xml;
using System.Xml.Xsl;

public partial class NghiepVu_Danhmuc_NoiLuuTru : System.Web.UI.Page
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
        if (!this.IsPostBack)
        {
            Initialization();
        }
    }
    private void Initialization()
    {
        Role role = getRole();
        hdRole.Value = new JavaScriptSerializer().Serialize(role);
        var stSThuocTinh = this.cbSTinh.GetStore();
        stSThuocTinh.DataSource = Sys_Common.LoadComboDiaDiem("", "tinh");
        stTinh.DataSource = Sys_Common.LoadComboDiaDiem("", "tinh");
        stLoaiBaoTang.DataSource = Sys_Common.NV_LoaiBaoTang.GetAll();
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
        this.odsData.SelectParameters["WhereString"].DefaultValue = @"(select ID,Ten,DiaChiCuThe,DienThoai,Email
                                                                        ,(select TenLoai from LoaiBaoTang l where l.ID=n.LoaiBaoTang) as TenLoaiBaoTang
	                                                                    ,(select Ten_Tinh from HT_DM_Tinh t where t.Ma_Tinh=n.ThuocTinh) as ThuocTinh
	                                                                    ,(select Ten_Huyen from HT_DM_Huyen h where h.Ma_Huyen=n.ThuocHuyen) as ThuocHuyen
	                                                                    ,dbo.getDiaDiem(ThuocTinh,ThuocHuyen,ThuocXa) as DiaChi 
                                                                    from NoiLuuTruHienVat n) as A";

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
                NV_NoiLuuTru_ChiTiet myDetail = Sys_Common.NV_NoiLuuTru.GetById(id);  //Sys_Common.NL_DM_BIEN_CHE.Lay(int.Parse(row.RecordID));
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

    private void SetData(NV_NoiLuuTru_ChiTiet model)
    {
        btnUpdate.Text = "Cập nhật";
        btnUpdate.Icon = Icon.ApplicationEdit;

        hdID.Text = model.ID.ToString();
        txtTen.Text = model.Ten;
        txtEngName.Value = model.EngName;
        txtMoTa.Text = model.MoTa;
        txtDienthoai.Text = model.DienThoai;
        txtEmail.Text = model.Email;
        txtWebsite.Text = model.Website;
        txtDiachi.Text = model.DiaChiCuThe;
        txtFax.Text = model.Fax;
        ImageOnly.ImageID = model.AnhDaiDien.ToString();
        cmbThuocTinh.Value = model.ThuocTinh;
        stHuyen.DataSource = Sys_Common.LoadComboDiaDiem(model.ThuocTinh, "huyen");
        stHuyen.DataBind();
        cmbThuocHuyen.Value = model.ThuocHuyen;
        stXa.DataSource = Sys_Common.LoadComboDiaDiem(model.ThuocHuyen, "xa");
        stXa.DataBind();
        cmbThuocXa.Value = model.ThuocXa;
        cmbLoaibaotang.Value = model.LoaiBaoTang;
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
        ClearData();
    }
    protected void btnDelete_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gvData.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            int id = int.Parse(row.RecordID);
            Sys_Common.NV_NoiLuuTru.Xoa(id);
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
        Role role = getRole();
        if (hdID.Text != "" && !role.Duoc_Sua)
        {
            X.Msg.Alert("Thông báo", "Bạn không có quyền sửa bản ghi !!!", new JFunction { Fn = "" }).Show();
            return;
        }
        if (string.IsNullOrEmpty(hdID.Text) && !role.Duoc_Nhap)
        {
            X.Msg.Alert("Thông báo", "Bạn không có quyền thêm bản ghi !!!", new JFunction { Fn = "" }).Show();
            return;
        }
        if (FormValidate())
        {
            NV_NoiLuuTru_ChiTiet model = new NV_NoiLuuTru_ChiTiet();
            model.Ten = txtTen.Text;
            model.EngName = txtEngName.Text;
            model.MoTa = txtMoTa.Text;
            model.DienThoai = txtDienthoai.Text;
            model.Email = txtEmail.Text;
            model.Website = txtWebsite.Text;
            model.DiaChiCuThe = txtDiachi.Text;
            model.Fax = txtFax.Text;
            try
            {
                model.AnhDaiDien = int.Parse(ImageOnly.ImageID);
            }
            catch
            {
                model.AnhDaiDien = 0;
            }
            model.LoaiBaoTang = int.Parse(cmbLoaibaotang.Value.ToString());
            model.Url = Models.StringUtil.RemoveSign4VietnameseString(txtTen.Text);
            try
            {
                model.ThuocTinh = cmbThuocTinh.Value.ToString();
            }
            catch
            {
                model.ThuocTinh = "";
            }
            try
            {
                model.ThuocHuyen = cmbThuocHuyen.Value.ToString();
            }
            catch { model.ThuocHuyen = ""; }
            try
            {
                model.ThuocXa = cmbThuocXa.Value.ToString();
            }
            catch { model.ThuocXa = ""; }

            NV_Log_ChiTiet log;
            if (hdID.Text != "")
            {
                model.ID = int.Parse(hdID.Text);
                Sys_Common.NV_NoiLuuTru.update(model);

                log = createLog(model.ID, "update");
                Sys_Common.NV_Log.them(log);
            }
            else
            {
                int id = 0;
                Sys_Common.NV_NoiLuuTru.them(model, out id);
                log = createLog(id, "insert");
                Sys_Common.NV_Log.them(log);
            }
            ClearData();
            X.Msg.Alert("Thông báo", "Đã cập nhật thành công !!!", new JFunction { Fn = "" }).Show();
            X.Msg.AddScript("#{stData}.reload();");
        }
    }
    private bool FormValidate()
    {
        if (string.IsNullOrEmpty(txtTen.Text.Trim()) || cmbLoaibaotang.Value == null || cmbLoaibaotang.Value.ToString() == "0" || string.IsNullOrEmpty(cmbLoaibaotang.Value.ToString()))
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
        txtEngName.Text = "";
        txtMoTa.Text = "";
        txtDienthoai.Text = "";
        txtEmail.Text = "";
        txtWebsite.Text = "";
        txtFax.Text = "";
        txtDiachi.Text = "";
        ImageOnly.ImageID = "0";
        cmbLoaibaotang.Value = "";
        X.Msg.AddScript("#{cmbThuocTinh}.clearValue();#{cmbThuocHuyen}.clearValue();#{cmbThuocXa}.clearValue();");
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

    protected void stHuyen_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        if (cmbThuocTinh.Value != null)
        {
            this.stHuyen.DataSource = Sys_Common.LoadComboDiaDiem(this.cmbThuocTinh.Value.ToString(), "huyen");

            this.stHuyen.DataBind();
        }
        else
        {
            X.Msg.AddScript("#{cmbHuyen}.clearValue();");
        }
    }

    protected void stXa_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        if (cmbThuocHuyen.Value != null)
        {
            this.stXa.DataSource = Sys_Common.LoadComboDiaDiem(this.cmbThuocHuyen.Value.ToString(), "xa");

            this.stXa.DataBind();
        }
        else
        {
            X.Msg.AddScript("#{cmbXa}.clearValue();");
        }
    }
}