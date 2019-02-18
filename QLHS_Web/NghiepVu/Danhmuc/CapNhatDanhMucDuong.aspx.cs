using Ext.Net;
using QLHS_Logic;
using QLHS_Logic.NV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using System.Data;
public partial class NghiepVu_Disanvanhoa_CapNhatDSPhiVatThe : System.Web.UI.Page
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
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            if (id != "")
            {
                //loadDiaDiem();
                SetData(Sys_Common.NV_DanhMucDuong.GetById(int.Parse(id)));
                hdID.Text = id;
            }
        }
    }
    private void Initialization()
    {
        stTinh.DataSource = Sys_Common.LoadComboDiaDiem("", "tinh");
        stTinh.DataBind();

        stHuyen.DataSource = Sys_Common.LoadComboDiaDiem("", "huyen");
        stHuyen.DataBind();
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
    private bool FormValidate()
    {
        if (string.IsNullOrEmpty(txtTenDuong.Text.Trim())||cmbThuocTinh.Value=="0")
        {
            X.Msg.Alert("Thông báo", "Thiếu thông tin ", new JFunction { Fn = "" }).Show();
            return false;
        }
        return true;
    }
    private void SetData(NV_DanhMucDuong_ChiTiet model)
    {
        btnUpdate.Text = "Cập nhật";
        btnUpdate.Icon = Icon.ApplicationEdit;

        hdID.Text = model.ID.ToString();
        txtTenDuong.Text = model.TenDuong;
        txtSoHieu.Text = model.SoHieuDuongBo;
        txtChieuDai.Text = model.ChieuDai;
        txtDiemDau.Value = model.DiemDau;
        txtDiemCuoi.Value = model.DiemCuoi;
        txtMatDuong.Value = model.MatDuong;
        txtQuyetDinh.Value = model.QuyetDinh;
        txtDanhNhan.Value = model.DanhNhan;
        txtTieuSu.Value = model.TieuSu;
        txtThayDoi.Value = model.ThayDoi;
        cmbThuocTinh.Value = model.ThuocTinh;

        stHuyen.DataSource = Sys_Common.LoadComboDiaDiem(cmbThuocTinh.SelectedItem.Value, "huyen");
        stHuyen.DataBind();

        cmbThuocHuyen.Value = model.ThuocHuyen;
    }
    private void loadDiaDiem()
    {
        stTinh.DataSource = Sys_Common.HT_DM_TINH.Danh_Sach();
        stHuyen.DataSource = Sys_Common.HT_DM_HUYEN.Danh_Sach();
        DataBind();
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        if (FormValidate())
        {
            NV_DanhMucDuong_ChiTiet model = new NV_DanhMucDuong_ChiTiet();
            model.TenDuong = txtTenDuong.Text;
            model.SoHieuDuongBo = txtSoHieu.Text;
            model.ChieuDai = txtChieuDai.Text;
            model.DiemDau = txtDiemDau.Text;
            model.DiemCuoi = txtDiemCuoi.Text;
            model.MatDuong = txtMatDuong.Text;
            model.QuyetDinh = txtQuyetDinh.Text;
            model.DanhNhan = txtDanhNhan.Text;
            model.TieuSu = txtTieuSu.Text;
            model.ThayDoi = txtThayDoi.Text;
            model.Url = StringUtil.RemoveSign4VietnameseString(txtTenDuong.Text).Replace(" ", "-");
            model.ThuocTinh = cmbThuocTinh.Value.ToString();
            model.ThuocHuyen = cmbThuocHuyen.Value.ToString();
            bool check;
            NV_Log_ChiTiet log;
            if (hdID.Text != "")
            {
                model.ID = int.Parse(hdID.Text);
                check = Sys_Common.NV_DanhMucDuong.update(model);
                log = createLog(model.ID, "update");
            }
            else
            {
                int id = 0;
                check = Sys_Common.NV_DanhMucDuong.them(model, out id);
                log = createLog(id, "insert");
            }
            if (check == true)
            {
                X.Msg.AddScript("parent.hdMsg.setValue('ok');");
                X.Msg.AddScript("parentAutoLoadControl.hide();");
            }
            else
            {
                X.Msg.Alert("Thông báo", "Đã có lỗi sảy ra...Xin thử lại", new JFunction { Fn = "" }).Show();
            }
        }
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