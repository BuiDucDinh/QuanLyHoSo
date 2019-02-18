using QLHS_Logic;
using QLHS_Logic.NV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;

public partial class DSVH_Quanlykehoachtubo_Capnhatkehoachtubo : System.Web.UI.Page
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
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            Initialization();
            if (id == "")
            {
                ClearData();
            }
            else
            {
                SetData(Sys_Common.NV_KeHoachTuBo.GetById(int.Parse(id)));
                hdKeHoachID.Text = id;
            }
        }
    }
    private void Initialization()
    {

        stTinh.DataSource = Sys_Common.HT_DM_TINH.Danh_Sach();
        stDiSan.DataSource = Sys_Common.NV_DiSanVanHoa.GetAll(null,"vi");
        stChudautu.DataSource = Sys_Common.NV_DonViTuBo.GetByChucNang(1);
        stThietke.DataSource = Sys_Common.NV_DonViTuBo.GetByChucNang(2);
        stGiamsat.DataSource = Sys_Common.NV_DonViTuBo.GetByChucNang(3);
        stThiCong.DataSource = Sys_Common.NV_DonViTuBo.GetByChucNang(4);
        stCapquyetdinh.DataSource = Sys_Common.NV_DonViTuBo.GetByChucNang(5);

        DataBind();
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        if (FormValidate())
        {
            NV_KeHoachTuBo_ChiTiet myDetail = new NV_KeHoachTuBo_ChiTiet();
            myDetail.DiaDiem = txtDiaDiem.Text;
            try
            {
                myDetail.DonViGiamSat.DonViID = int.Parse(cmbGiamsat.Value.ToString());
            }
            catch { }
            try
            {
                myDetail.DonViThietKe.DonViID = int.Parse(cmbThietke.Value.ToString());
            }
            catch { }
            try
            {
                myDetail.DonViThiCong.DonViID = int.Parse(cmbThicong.Value.ToString());
            }
            catch { }
            try
            {
                myDetail.ChuDauTu.DonViID = int.Parse(cmbChudautu.Value.ToString());
            }
            catch { }
            try
            {
                myDetail.CapQD.DonViID = int.Parse(cmbCapquyetdinh.Value.ToString());
            }
            catch { }
            myDetail.ThuocTinh = cmbThuocTinh.Value.ToString();
            myDetail.DiSan = new NV_DiSanVanHoa_ChiTiet();
            myDetail.DiSan.DiSanID = int.Parse("0" + cmbTendisan.Value.ToString());
            myDetail.ChiPhiThucTe = decimal.Parse("0" + txtChiPhiThucte.Value);
            myDetail.ChiPhiDuKien = decimal.Parse("0" + txtChiphidukien.Value);
            myDetail.Lydo = txtLydotubo.Text;
            myDetail.MotaQuaTrinh = txtMotaquatrinh.Text;
            myDetail.NoiDung = txtNoidungcongviec.Text;
            myDetail.TrangThai = radDuyet.Items[0].Checked;
            myDetail.File = Document.DocumentID;
            myDetail.TenDuAn = txtTenduan.Text;
            try
            {
                myDetail.ThuocHuyen = cmbThuocHuyen.Value.ToString();
            }
            catch
            {
                myDetail.ThuocHuyen = "";
            }
            try
            {
                myDetail.ThuocXa = cmbThuocXa.Value.ToString();
            }
            catch
            {
                myDetail.ThuocXa = "";
            }

            if (dtNgaybatdau_dukien.SelectedValue != null)
            {
                myDetail.DuKienBatDau = Convert.ToDateTime(dtNgaybatdau_dukien.SelectedValue);
            }
            if (dtNgayketthuc_dukien.SelectedValue != null)
            {
                myDetail.DukienHoanThanh = Convert.ToDateTime(dtNgayketthuc_dukien.SelectedValue);
            }
            if (dtNgaybatdau_thucte.SelectedValue != null)
            {
                myDetail.ThucTeBatDau = Convert.ToDateTime(dtNgaybatdau_thucte.SelectedValue);
            }
            if (dtNgayketthuc_thucte.SelectedValue != null)
            {
                myDetail.ThucTeHoanThanh = Convert.ToDateTime(dtNgayketthuc_thucte.SelectedValue);
            }
            bool check;
            NV_Log_ChiTiet log;
            if (hdKeHoachID.Text != "")
            {
                myDetail.KeHoachID = int.Parse(hdKeHoachID.Text);
                check = Sys_Common.NV_KeHoachTuBo.update(myDetail);

                log = createLog(myDetail.KeHoachID, "update");
            }
            else
            {
                int id = 0;
                check = Sys_Common.NV_KeHoachTuBo.them(myDetail, out id);
                log = createLog(id, "insert");
            }
            if (check == true)
            {
                Sys_Common.NV_Log.them(log);
                ClearData();
                X.Msg.AddScript("parent.hdMsg.setValue('ok');");
                X.Msg.AddScript("parentAutoLoadControl.hide();");
            }
            else
            {
                X.Msg.Alert("Thông báo", "Đã có lỗi sảy ra...Xin thử lại", new JFunction { Fn = "" }).Show();
            }
            hdKeHoachID.Text = "";
        }
    }
    private bool FormValidate()
    {
        if (string.IsNullOrEmpty(txtTenduan.Text) || this.cmbTendisan.SelectedItem.Value == null)
        {
            X.Msg.Alert("Thông báo", "Thiếu thông tin ", new JFunction { Fn = "" }).Show();
            return false;
        }
        return true;
    }
    private void SetData(NV_KeHoachTuBo_ChiTiet myDetail)
    {
        btnUpdate.Text = "Cập nhật";
        btnUpdate.Icon = Icon.ApplicationEdit;


        //cmbDonvitrienkhai.Value = myDetail.DonViTuBo.DonViID;
        cmbTendisan.Value = myDetail.DiSan.DiSanID;
        cmbThuocTinh.Value = myDetail.ThuocTinh;

        stHuyen.DataSource = Sys_Common.LoadComboDiaDiem(myDetail.ThuocTinh, "huyen");
        stHuyen.DataBind();
        cmbThuocHuyen.Value = myDetail.ThuocHuyen;
        stXa.DataSource = Sys_Common.LoadComboDiaDiem(myDetail.ThuocHuyen, "xa");
        stXa.DataBind();
        cmbThuocXa.Value = myDetail.ThuocXa;

        cmbChudautu.Value = myDetail.ChuDauTu.DonViID;
        cmbGiamsat.Value = myDetail.DonViGiamSat.DonViID;
        cmbThicong.Value = myDetail.DonViThiCong.DonViID;
        cmbThietke.Value = myDetail.DonViThietKe.DonViID;
        cmbCapquyetdinh.Value = myDetail.CapQD.DonViID;
        txtTenduan.Text = myDetail.TenDuAn;
        txtDiaDiem.Value = myDetail.DiaDiem;
        txtChiphidukien.Value = myDetail.ChiPhiDuKien.ToString("0.##");
        txtChiPhiThucte.Value = myDetail.ChiPhiThucTe.ToString("0.##");
        txtLydotubo.Value = myDetail.Lydo;
        txtMotaquatrinh.Value = myDetail.MotaQuaTrinh;
        txtNoidungcongviec.Value = myDetail.NoiDung;
        dtNgaybatdau_dukien.Value = myDetail.DuKienBatDau;
        dtNgayketthuc_dukien.Value = myDetail.DukienHoanThanh;
        dtNgaybatdau_thucte.Value = myDetail.ThucTeBatDau;
        dtNgayketthuc_thucte.Value = myDetail.ThucTeHoanThanh;
        radDuyet.Value = myDetail.TrangThai == true ? "1" : "0";
        Document.DocumentID = myDetail.File;
    }

    private void ClearData()
    {
        btnUpdate.Text = "Thêm mới";
        btnUpdate.Icon = Icon.Add;
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
        this.stHuyen.DataSource = Sys_Common.HT_DM_HUYEN.Lay_Boi_HT_DM_Tinh(this.cmbThuocTinh.SelectedItem.Value.ToString());

        this.stHuyen.DataBind();
    }
    protected void stXa_RefreshData(object sender, EventArgs e)
    {
        this.stXa.DataSource = QLHS_Logic.Sys_Common.HT_DM_XA.Lay_Boi_HT_DM_Huyen(this.cmbThuocHuyen.SelectedItem.Value.ToString());

        this.stXa.DataBind();
    }
}