using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using QLHS_Logic;
using QLHS_Logic.NV;
using Models;
public partial class NghiepVu_Hoatdongvanhoa_CapNhatHDVH : System.Web.UI.Page
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
            Load_Data();
            string enable = Request.QueryString["enable"] != null ? Request.QueryString["enable"].ToString() : "";
            if (string.IsNullOrEmpty(enable) || enable != "1")
            {
                DisableControl();
            }
        }
    }
    private void Initialization()
    {
        stTinh.DataSource = Sys_Common.LoadComboDiaDiem("", "tinh");
        stDiSan.DataSource = Sys_Common.LoadCombo("DiSan");
        stCoQuanQuanLy.DataSource = Sys_Common.LoadCombo("CoQuan");
        stCoQuanToChuc.DataSource = Sys_Common.LoadCombo("CoQuan");
        DataBind();
    }
    private void DisableControl()
    {
        btnUpdate.Visible = false;
        txtID.Disabled = true;
        cmbLang.Disabled = true;
        txtTengoi.Disabled = true;
        txtTenkhac.Disabled = true;
        dtpNgay.Disabled = true;
        txtThoiGian.Disabled = true;
        cmbDiSan.Disabled = true;
        //txtNoidung.Disabled = true;
        txtDiadiem.Disabled = true;
        cmbTinh.Disabled = true;
        cmbHuyen.Disabled = true;
        cmbXa.Disabled = true;
        cmbDonvitochuc.Disabled = true;
        cmbDonviquanly.Disabled = true;
        txtGioithieu.Disabled = true;
        ImageOnly.Disabled = true;
        txtUrl.Hidden = true;
    }
    private void Load_Data()
    {
        int id = int.Parse("0" + Request.QueryString["id"]);
        if (id == 0)
        {
            Clear_Data();
        }
        else
        {
            stHuyen.DataSource = Sys_Common.HT_DM_HUYEN.Danh_Sach();
            stXa.DataSource = Sys_Common.HT_DM_XA.Danh_Sach();
            DataBind();
            NV_HoatDongVanHoa_ChiTiet objHoatdong = Sys_Common.NV_HoatDongVanHoa.GetById(id);
            Detail(objHoatdong);
        }
    }
    private void Clear_Data()
    {
        btnUpdate.ImageUrl = "/images/btnadd.png";

        txtID.Value = "";
        txtTengoi.Value = "";
        txtTenkhac.Value = "";
        cmbLang.SelectedIndex = 0;
        dtpNgay.Value = DateTime.Now;
        txtThoiGian.Value = "";
        cmbDiSan.Value = "0";
        txtNoidung.Value = "";
        txtDiadiem.Value = "";
        cmbTinh.Value = "0";
        cmbHuyen.Value = "0";
        cmbXa.Value = "0";
        cmbDonvitochuc.Value = "0";
        cmbDonviquanly.Value = "0";
        txtGioithieu.Value = "";
        ImageOnly.ImageID = "0";
        txtUrl.Text = "";
    }
    private void Detail(NV_HoatDongVanHoa_ChiTiet obj)
    {
        btnUpdate.ImageUrl = "/images/btnsave.png";
        txtID.Value = obj.HoatDongID;
        txtTengoi.Value = obj.TenGoi;
        cmbLang.Value = obj.Lang;
        txtTenkhac.Value = obj.TenGoiKhac;
        dtpNgay.Value = obj.NgayDienRa;
        txtThoiGian.Value = obj.ThoiGianDienRa;
        cmbDiSan.Value = obj.DiSanID;
        txtNoidung.Value = obj.NoiDung;
        txtDiadiem.Value = obj.DiaDiem;
        cmbTinh.Value = obj.ThuocTinh;
        cmbHuyen.Value = obj.ThuocHuyen;
        cmbXa.Value = obj.ThuocXa;
        cmbDonvitochuc.Value = obj.DonViToChucID;
        cmbDonviquanly.Value = obj.DonViQuanLyID;
        txtGioithieu.Value = obj.GioiThieu;
        ImageOnly.ImageID = obj.HinhAnh;
        txtUrl.Text = obj.Url;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        NV_HoatDongVanHoa_ChiTiet obj = new NV_HoatDongVanHoa_ChiTiet();
        obj.Lang = (string)cmbLang.Value;
        obj.TenGoi = (string)txtTengoi.Value;
        obj.TenGoiKhac = (string)txtTenkhac.Value;
        obj.NgayDienRa = (DateTime)dtpNgay.SelectedValue;
        obj.ThoiGianDienRa = (string)txtThoiGian.Value;
        obj.DiSanID = int.Parse("0" + cmbDiSan.Value);
        obj.NoiDung = (string)txtNoidung.Value;
        obj.DiaDiem = (string)txtDiadiem.Value;
        obj.ThuocTinh = (string)cmbTinh.Value;
        obj.ThuocHuyen = (string)cmbHuyen.Value;
        obj.ThuocXa = (string)cmbXa.Value;
        obj.DonViToChucID = int.Parse("0" + cmbDonvitochuc.Value);
        obj.DonViQuanLyID = int.Parse("0" + cmbDonviquanly.Value);
        obj.Url = txtUrl.Text != "" ? StringUtil.RemoveSign4VietnameseString(txtUrl.Text).Replace(" ", "-") : StringUtil.RemoveSign4VietnameseString(txtTengoi.Text).Replace(" ", "-");
        obj.GioiThieu = (string)txtGioithieu.Value;
        obj.HinhAnh = ImageOnly.ImageID;//getImage();

        int maND = int.Parse(Session["G_Ma_Nguoi_Dung"].ToString());
        NV_Log_ChiTiet log;

        bool check;
        if (string.IsNullOrEmpty(txtID.Value.ToString()))
        {
            int id = 0;
            check = Sys_Common.NV_HoatDongVanHoa.them(obj, out id);
            log = createLog(id, "insert");
        }
        else
        {
            obj.HoatDongID = int.Parse("0" + txtID.Value);
            check = Sys_Common.NV_HoatDongVanHoa.Update(obj);
            log = createLog(obj.HoatDongID, "update");
        }
        if (check)
        {
            Clear_Data();
            Sys_Common.NV_Log.them(log);
            //X.Msg.Alert("Thông báo", "Đã cập nhật thành công !!!", new JFunction { Fn = "" }).Show();
            X.Msg.AddScript("parent.hdMsg.setValue('ok');");
            //X.Msg.AddScript("parentAutoLoadControl.hide();");
        }
    }
    private bool validateForm()
    {
        if (string.IsNullOrEmpty(txtTengoi.Text))
        {
            return false;
        }
        return true;
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
        if (cmbTinh.Value != null)
        {
            this.stHuyen.DataSource = Sys_Common.LoadComboDiaDiem(this.cmbTinh.Value.ToString(), "huyen");

            this.stHuyen.DataBind();
        }
        else
        {
            X.Msg.AddScript("#{cmbHuyen}.clearValue();");
        }
    }
    protected void stXa_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        if (cmbHuyen.Value != null)
        {
            this.stXa.DataSource = Sys_Common.LoadComboDiaDiem(this.cmbHuyen.Value.ToString(), "xa");

            this.stXa.DataBind();
        }
        else
        {
            X.Msg.AddScript("#{cmbXa}.clearValue();");
        }
    }
}