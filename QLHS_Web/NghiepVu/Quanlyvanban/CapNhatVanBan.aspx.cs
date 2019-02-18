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
public partial class NghiepVu_Quanlyvanban_CapNhatVanBan : System.Web.UI.Page
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
                SetData(Sys_Common.NV_VanBan.GetById(int.Parse(id)));
            }
        }
    }
    private void Initialization()
    {
        stLoaiVB.DataSource = Sys_Common.NV_LoaiVanBan.GetAll();
        DataBind();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (FormValidate())
        {
            NV_VanBan_ChiTiet model = new NV_VanBan_ChiTiet();
            model.TenVanBan = txtTenVB.Text;

            model.LoaiVanBan = int.Parse(cbLoaiVB.Value.ToString());
            model.DonViBanHanh = txtDonViBanHanh.Text;
            model.NgayBanHanh = dtNgayBanHanh.SelectedValue != null ? Convert.ToDateTime(dtNgayBanHanh.SelectedValue.ToString()) : DateTime.Now;
            model.NoiDung = txtNoidung.Text;
            model.File = Document.DocumentID;
            model.MoTa = txtMoTa.Text;
            model.NguoiTao = int.Parse(Session["G_Ma_Nguoi_Dung"].ToString());
            NV_Log_ChiTiet log;

            bool check;
            if (hdID.Text != "")
            {
                model.VanBanID = int.Parse(hdID.Text);
                check = Sys_Common.NV_VanBan.update(model);
                log = createLog(model.VanBanID, "update");
            }
            else
            {
                model.Duyet = false;
                model.TonTai = true;
                int id = 0;
                check = Sys_Common.NV_VanBan.them(model, out id);
                log = createLog(model.VanBanID, "insert");
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
        if (string.IsNullOrEmpty(txtTenVB.Text.Trim()) || cbLoaiVB.Value == null)
        {
            X.Msg.Alert("Thông báo", "Thiếu thông tin ", new JFunction { Fn = "" }).Show();
            return false;
        }
        return true;
    }
    private void SetData(NV_VanBan_ChiTiet model)
    {
        btnUpdate.ImageUrl = "/images/btnsave.png";

        txtTenVB.Text = model.TenVanBan;
        hdID.Value = model.VanBanID;
        cbLoaiVB.Value = model.LoaiVanBan;

        dtNgayBanHanh.Value = model.NgayBanHanh;
        txtMoTa.Text = model.MoTa;
        txtNoidung.Text = model.NoiDung;
        txtDonViBanHanh.Text = model.DonViBanHanh;
        Document.DocumentID = model.File;
    }

    private void ClearData()
    {
        btnUpdate.ImageUrl = "/images/btnadd.png";

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