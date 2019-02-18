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
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            Initialization();
            if (id == "")
            {
                ClearData();
            }
            else
            {
                SetData(Sys_Common.NV_BaiViet_AnPham.GetById(int.Parse(id)));
                hdBaiVietID.Text = id;
            }
        }
    }
    private void Initialization()
    {
        string lang = cmbLang.Value != null ? cmbLang.Value.ToString() : "vi";
        dtNgayxuatban.SelectedDate = DateTime.Now;
        stTheLoai.DataSource = Sys_Common.GetChildMenu(0, 1, null, lang);
        stDiSan.DataSource = Sys_Common.NV_DiSanVanHoa.GetAll(null, lang);
        stHoatdong.DataSource = Sys_Common.NV_HoatDongVanHoa.GetAll();
        DataBind();
    }

    protected void cmbLang_Change(object sender, DirectEventArgs e)
    {
        Initialization();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (FormValidate())
        {
            NV_BaiViet_AnPham_ChiTiet model = new NV_BaiViet_AnPham_ChiTiet();
            if (hdBaiVietID.Text != "")
            {
                int id = int.Parse(hdBaiVietID.Value.ToString());
                model = Sys_Common.NV_BaiViet_AnPham.GetById(id);
            }
            model.Lang = cmbLang.Value.ToString();
            model.TieuDe = txtTieuDe.Text;
            model.DanhMuc = ",";
            int i = 0;
            foreach (var item in mcbDanhmuc.SelectedItems)
            {
                if (i == 0) model.DanhMucChinh = int.Parse(item.Value);
                model.DanhMuc += item.Value + ",";
                i++;
            }
            model.NoiDung = txtNoidung.Value;
            model.GioiThieu = txtGioithieu.Text;
            model.MetaDescription = txtMetaDescription.Text;
            model.MetaKeyword = txtMetaKeyword.Text;
            model.PageTitle = txtTitlePage.Text;
            model.Url = txtUrl.Text != "" ? StringUtil.RemoveSign4VietnameseString(txtUrl.Text).Replace(" ", "-") : StringUtil.RemoveSign4VietnameseString(txtTieuDe.Text).Replace(" ", "-");
            try
            {
                model.DiSanID = int.Parse(cbDiSan.Value.ToString());
            }
            catch
            {
                model.DiSanID = 0;
            }
            try
            {
                model.HoatDongID = int.Parse(cbHoatDong.Value.ToString());
            }
            catch
            {
                model.HoatDongID = 0;
            }
            model.HinhAnh = int.Parse(ImageOnly.ImageID);
            model.File = Document.DocumentID;
            //model.Duyet = ckbDuyet.Checked;
            //model.NoiBat = ckbNoiBat.Checked;
            try
            {
                model.Stt = int.Parse(txtThuTu.Text);
            }
            catch
            {
                model.Stt = 1;
            }
            NV_Log_ChiTiet log;
            bool check;
            if (hdBaiVietID.Text != "")
            {
                model.ID = int.Parse(hdBaiVietID.Text);
                check = Sys_Common.NV_BaiViet_AnPham.Update(model);
                log = createLog(model.ID, "update");
            }
            else
            {
                model.Duyet = false;
                model.NoiBat = false;
                model.TonTai = true;
                model.NgayXuatBan = DateTime.Now;
                model.NguoiTao = int.Parse(Session["G_Ma_Nguoi_Dung"].ToString());
                int id = 0;
                check = Sys_Common.NV_BaiViet_AnPham.Them(model, out id);
                log = createLog(id, "insert");
            }
            if (check)
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
            hdBaiVietID.Text = "";
        }

    }

    private bool FormValidate()
    {
        if (string.IsNullOrEmpty(txtTieuDe.Text.Trim()))
        {
            X.Msg.Alert("Thông báo", "Thiếu thông tin ", new JFunction { Fn = "" }).Show();
            return false;
        }
        return true;
    }
    private void SetData(NV_BaiViet_AnPham_ChiTiet model)
    {
        btnUpdate.ImageUrl = "/images/btnsave.png";

        txtTieuDe.Text = model.TieuDe;
        cmbLang.Value = model.Lang;

        string[] danhmuc = model.DanhMuc.Split(',');
        foreach (string item in danhmuc)
        {
            if (!string.IsNullOrEmpty(item))
            {
                mcbDanhmuc.SelectedItems.Add(new Ext.Net.SelectedListItem(item));
            }
        }
        cbDiSan.Value = model.DiSanID;
        cbHoatDong.Value = model.HoatDongID;

        dtNgayxuatban.Value = model.NgayXuatBan;
        txtGioithieu.Text = model.GioiThieu;
        txtNoidung.Value = model.NoiDung;
        txtUrl.Value = model.Url;
        txtTitlePage.Value = model.PageTitle;
        txtMetaKeyword.Value = model.MetaKeyword;
        txtMetaDescription.Value = model.MetaDescription;
        ImageOnly.ImageID = model.HinhAnh.ToString();
        Document.DocumentID = model.File;
        txtThuTu.Text = model.Stt.ToString();
        //ckbDuyet.Checked = model.Duyet;
        //ckbNoiBat.Checked = model.NoiBat;
    }

    private void ClearData()
    {
        btnUpdate.ImageUrl = "/images/btnAdd.png";
        //btnUpdate.Icon = Icon.Add;

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