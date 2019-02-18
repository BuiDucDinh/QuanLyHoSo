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
                SetData(Sys_Common.NV_DonViKinhDoanh.GetById(int.Parse(id)));
                hdID.Text = id;
            }
        }
    }
    private void Initialization()
    {
        stLinhVuc.DataSource = Sys_Common.NV_DM_LinhVucKinhDoanh.GetAll();
        stLinhVuc.DataBind();
        //stTinh.DataSource = Sys_Common.LoadComboDiaDiem("", "tinh");
        //stTinh.DataBind();
        stHuyen.DataSource = Sys_Common.LoadComboDiaDiem("36", "huyen");
        stHuyen.DataBind();
    }
    //protected void stHuyen_RefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    if (cmbThuocTinh.Value != null)
    //    {
    //        this.stHuyen.DataSource = Sys_Common.LoadComboDiaDiem(this.cmbThuocTinh.Value.ToString(), "huyen");

    //        this.stHuyen.DataBind();
    //    }
    //    else
    //    {
    //        X.Msg.AddScript("#{cmbHuyen}.clearValue();");
    //    }
    //}
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
    private bool FormValidate()
    {
        if (string.IsNullOrEmpty(txtTen.Text.Trim()))
        {
            X.Msg.Alert("Thông báo", "Thiếu thông tin ", new JFunction { Fn = "" }).Show();
            return false;
        }
        else if (mcbLinhVuc.SelectedItems.Count <= 0)
        {
            X.Msg.Alert("Thông báo", "Bạn chưa chọn lĩnh vực kinh doanh nào !!!", new JFunction { Fn = "" }).Show();
            return false;
        }
        return true;
    }
    private void SetData(NV_DonViKinhDoanh_ChiTiet model)
    {
        btnUpdate.Text = "Cập nhật";
        btnUpdate.Icon = Icon.ApplicationEdit;

        hdID.Text = model.ID.ToString();
        txtTen.Text = model.TenDonVi;
        txtSoGiayPhep.Text = model.SoGiayPhep;
        txtDiaChi.Text = model.DiaChi;
        txtStt.Text = model.Stt.ToString();
        txtDienThoai.Text = model.DienThoai;
        txtLienHe.Text = model.ThongTinLienHe;
        txtChuKinhDoanh.Text = model.ChuKinhDoanh;
        dtNgayCap.Value = model.NgayCap;
        if (!string.IsNullOrEmpty(model.LinhVuc))
        {
            string[] danhmuc = model.LinhVuc.Split(',');

            foreach (string item in danhmuc)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    mcbLinhVuc.SelectedItems.Add(new Ext.Net.SelectedListItem(item));
                }
            }
        }
        //cmbThuocTinh.Value = model.ThuocTinh;
        cmbThuocHuyen.Value = model.ThuocHuyen;
        cmbThuocXa.Value = model.ThuocXa;
    }
    private void loadDiaDiem()
    {
        //stTinh.DataSource = Sys_Common.HT_DM_TINH.Danh_Sach();
        stHuyen.DataSource = Sys_Common.LoadComboDiaDiem("36", "huyen");
        DataBind();
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        if (FormValidate())
        {
            NV_DonViKinhDoanh_ChiTiet model = new NV_DonViKinhDoanh_ChiTiet();
            model.TenDonVi = txtTen.Text;
            model.SoGiayPhep = txtSoGiayPhep.Text;
            model.ChuKinhDoanh = txtChuKinhDoanh.Text;
            model.DiaChi = txtDiaChi.Text;
            model.DienThoai = txtDienThoai.Text;
            try
            {
                model.NgayCap = Convert.ToDateTime(dtNgayCap.Value);
            }
            catch
            {
                model.NgayCap = null;
            }
            try
            {
                model.Stt = int.Parse(txtStt.Text);
            }
            catch
            {
                model.Stt = 1;
            }
            model.ThuocTinh = "36";//cmbThuocTinh.Value.ToString();
            model.ThuocHuyen = cmbThuocHuyen.Value.ToString();
            model.ThuocXa = cmbThuocXa.Value.ToString();
            bool check;
            if (hdID.Text != "")
            {
                model.ID = int.Parse(hdID.Text);
                check = Sys_Common.NV_DonViKinhDoanh.update(model);
            }
            else
            {
                check = Sys_Common.NV_DonViKinhDoanh.them(model);
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

}