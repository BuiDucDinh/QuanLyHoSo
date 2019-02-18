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

public partial class DSVH_Quanlykehoachtubo_Donvitubo : System.Web.UI.Page
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
        stChucnang.DataSource = Sys_Common.NV_ChucNangTuBo.GetAll();
        stChucnangLoc.DataSource = Sys_Common.NV_ChucNangTuBo.GetAll();
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
        string sql = @"select *,SUBSTRING((select ','+TenChucNang from ChucNangTuBo cn 
                            where dv.ChucNang like '%,'+CAST(cn.ID as nvarchar(10))+',%' 
                            FOR XML PATH ('')), 2, 1000) as ChucNangDs
                        from DonViTuBo dv where 1=1";
        if (!string.IsNullOrEmpty(txtTen.Text))
        {
            sql += " and TenDonVi like '%" + txtTen.Text + "%'";
        }
        if (cbChucnang.Value != null && !string.IsNullOrEmpty(cbChucnang.Value.ToString()))
        {
            sql += " and ChucNang like '%," + cbChucnang.Value.ToString() + ",%'";
        }
        this.odsData.SelectParameters["WhereString"].DefaultValue = @"(" + sql + ") as A";
        this.odsData.SelectParameters["SortString"].DefaultValue = e.Sort + " " + e.Dir;

        this.odsData.DataBind();
    }
    protected void RowSelect(object sender, DirectEventArgs e)
    {
        string id = e.ExtraParams["ID"];
        NV_DonViTuBo_ChiTiet model = Sys_Common.NV_DonViTuBo.GetById(int.Parse(id));
        SetData(model);
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
        Role role = getRole();
        if (role.Duoc_Xoa)
        {
            RowSelectionModel sm = gvData.SelectionModel.Primary as RowSelectionModel;
            foreach (SelectedRow row in sm.SelectedRows)
            {
                int id = int.Parse(row.RecordID);
                Sys_Common.NV_DonViTuBo.Xoa(id);
                NV_Log_ChiTiet log = createLog(id, "delete");
                Sys_Common.NV_Log.them(log);
            }
            sm.SelectedRows.Clear();
            sm.UpdateSelection();
            X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
            X.Msg.AddScript("#{stData}.reload();");
        }
        else
        {
            X.Msg.Alert("Thông báo", "Bạn không có quyền xóa đơn vị tu bổ !!!", new JFunction { Fn = "" }).Show();
        }
    }
    protected void btnCancel_Click(object sender, DirectEventArgs e)
    {
        ClearData();
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        Role role = getRole();
        if (FormValidate())
        {
            NV_DonViTuBo_ChiTiet model = new NV_DonViTuBo_ChiTiet();
            if (!string.IsNullOrEmpty(hdDonViID.Text) && !role.Duoc_Sua)
            {
                X.Msg.Alert("Thông báo", "Bạn không có quyền sửa đơn vị tu bổ !!!", new JFunction { Fn = "" }).Show();
                return;
            }
            if (string.IsNullOrEmpty(hdDonViID.Text) && !role.Duoc_Nhap)
            {
                X.Msg.Alert("Thông báo", "Bạn không có quyền thêm mới đơn vị tu bổ !!!", new JFunction { Fn = "" }).Show();
                return;
            }
            model.TenDonVi = txtTenCongTy.Text;
            model.NguoiDaiDien = txtNguoiDaiDien.Text;
            model.DiaChi = txtDiaChi.Text;
            model.SoDienThoai = txtDienThoai.Text;
            model.GhiChu = txtGhichu.Text;
            model.CapDonVi = int.Parse(cbCapDonVi.Value.ToString());
            model.ChungChihanhNghe = txtChungChi.Text;
            model.File = Document.DocumentID;
            model.ChucNang = ",";
            foreach (var item in mcbChucnang.SelectedItems)
            {
                model.ChucNang += item.Value + ",";
            }
            NV_Log_ChiTiet log;
            if (hdDonViID.Text != "")
            {
                model.DonViID = int.Parse(hdDonViID.Text);
                Sys_Common.NV_DonViTuBo.update(model);
                log = createLog(model.DonViID, "update");
                Sys_Common.NV_Log.them(log);
            }
            else
            {
                int id = 0;
                Sys_Common.NV_DonViTuBo.them(model, out id);
                log = createLog(id, "insert");
                Sys_Common.NV_Log.them(log);
            }
            ClearData();
            X.Msg.AddScript("#{stData}.reload();");
        }
    }
    private void SetData(NV_DonViTuBo_ChiTiet myDetail)
    {
        btnUpdate.Text = "Cập nhật";
        btnUpdate.Icon = Icon.ApplicationEdit;

        txtTenCongTy.Value = myDetail.TenDonVi;
        txtNguoiDaiDien.Value = myDetail.NguoiDaiDien;
        txtDiaChi.Value = myDetail.DiaChi;
        txtDienThoai.Value = myDetail.SoDienThoai;
        txtGhichu.Value = myDetail.GhiChu;
        hdDonViID.Value = myDetail.DonViID;
        cbCapDonVi.Value = myDetail.CapDonVi;
        txtChungChi.Value = myDetail.ChungChihanhNghe;
        Document.DocumentID = myDetail.File;
        if (!string.IsNullOrEmpty(myDetail.ChucNang))
        {
            string[] chucnang = myDetail.ChucNang.Split(',');

            foreach (string item in chucnang)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    mcbChucnang.SelectedItems.Add(new Ext.Net.SelectedListItem(item));
                }
            }
        }
    }
    private bool FormValidate()
    {
        if (string.IsNullOrEmpty(txtTenCongTy.Text.Trim()))
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
        hdDonViID.Value = "";
        txtTenCongTy.Value = "";
        txtNguoiDaiDien.Value = "";
        txtDiaChi.Value = "";
        txtDienThoai.Value = "";
        txtGhichu.Value = "";
        hdDonViID.Value = "";
        cbCapDonVi.Value = "";
        txtChungChi.Value = "";
        Document.DocumentID = "";
        if (mcbChucnang.SelectedItems.Count > 0)
        {
            mcbChucnang.SelectedItems.Clear();
        }
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