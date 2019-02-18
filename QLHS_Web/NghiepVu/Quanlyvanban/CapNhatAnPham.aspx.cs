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
using FredCK.FCKeditorV2;
public partial class NghiepVu_Quanlyvanban_CapNhatDSBaiViet : System.Web.UI.Page
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
            if (!string.IsNullOrEmpty(id))
            {
                SetData(Sys_Common.NV_AnPham.GetById(int.Parse(id)));
            }
        }
    }
    private void Initialization()
    {
        string lang = cmbLang.Value != null ? cmbLang.Value.ToString() : "vi";
        stDiSan.DataSource = Sys_Common.NV_DiSanVanHoa.GetAll(null,lang);
        stDanhMuc.DataSource = Sys_Common.NV_DanhMucAnPham.GetAll();
        int yearNow = DateTime.Now.Year;
        int count = yearNow - 1989;
        object[] year = new object[count];
        for (int i = 0; i < count; i++)
        {
            year[i] = new object[]{
                yearNow - i
            };
        }
        stNamXB.DataSource = year;
        DataBind();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (FormValidate())
        {
            NV_AnPham_ChiTiet model = new NV_AnPham_ChiTiet();
            model.MaSach = txtMaanpham.Text;
            model.Lang = cmbLang.Value.ToString();
            model.TenSach = txtTenanpham.Text;
            model.TacGia = txtTacgia.Text;
            model.GioiThieu = txtGioithieu.Text;
            model.TomTatNoiDung = txtTomtat.Text;
            model.TacGia = txtTacgia.Text;
            try
            {
                model.DanhMucID = int.Parse(cbDanhMuc.Value.ToString());
            }
            catch { }
            try
            {
                model.SoTrang = int.Parse(txtSoTrang.Text);
            }
            catch
            {
                model.SoTrang = 0;
            }
            model.KichCo = txtKichco.Text;
            model.NamXB = int.Parse(cbNamXB.Value.ToString());
            model.NhaXB = txtNhaXuatBan.Text;
            model.Url = StringUtil.RemoveSign4VietnameseString(txtTenanpham.Text).Replace(" ", "-");
            try
            {
                model.DiSanID = int.Parse(cbDiSan.Value.ToString());
            }
            catch
            {
                model.DiSanID = 0;
            }

            model.AnhDaiDien = ImageOnly.ImageID;
            model.FileDinhKem = Document.DocumentID;

            int maND = int.Parse(Session["G_Ma_Nguoi_Dung"].ToString());
            NV_Log_ChiTiet log;

            bool check;
            if (hdID.Text != "")
            {
                model.ID = int.Parse(hdID.Text);
                check = Sys_Common.NV_AnPham.Update(model);

                log = createLog(model.ID, "update");
            }
            else
            {
                int id = 0;
                check = Sys_Common.NV_AnPham.Them(model, out id);
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
        }

    }

    private bool FormValidate()
    {
        if (string.IsNullOrEmpty(txtTenanpham.Text.Trim()) || string.IsNullOrEmpty(txtMaanpham.Text.Trim()))
        {
            X.Msg.Alert("Thông báo", "Thiếu thông tin ", new JFunction { Fn = "" }).Show();
            return false;
        }
        else if (cbDanhMuc.Value == null)
        {
            X.Msg.Alert("Thông báo", "Bạn chưa chọn danh mục ấn phẩm", new JFunction { Fn = "" }).Show();
            return false;
        }
        return true;
    }
    private void SetData(NV_AnPham_ChiTiet model)
    {
        btnUpdate.ImageUrl = "/images/btnsave.png";

        hdID.Value = model.ID;
        txtMaanpham.Text = model.MaSach;
        txtTenanpham.Text = model.TenSach;
        cbDiSan.Value = model.DiSanID;
        cbNamXB.Value = model.NamXB;
        txtNhaXuatBan.Text = model.NhaXB;
        txtGioithieu.Text = model.GioiThieu;
        txtTomtat.Text = model.TomTatNoiDung;
        txtKichco.Text = model.KichCo;
        txtSoTrang.Text = model.SoTrang.ToString();
        Document.DocumentID = model.FileDinhKem;
        ImageOnly.ImageID = model.AnhDaiDien;
        txtTacgia.Text = model.TacGia;
        cbDanhMuc.Value = model.DanhMucID;
        cmbLang.Value = model.Lang;
    }

    private void ClearData()
    {
        btnUpdate.ImageUrl = "/images/btnAdd.png";
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