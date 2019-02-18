using Ext.Net;
using QLHS_Logic;
using QLHS_Logic.NV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NghiepVu_Disanvanhoa_CapNhatDKDS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
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
            Initialization();
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            if (id != "")
            {
                SetData(Sys_Common.NV_DangKyDiSan.GetById(int.Parse(id)));
            }
            else
            {
                ClearData();
            }
        }
    }
    private void Initialization()
    {
        stCapDiSan.DataSource = Sys_Common.NV_DM_CapDiSan.GetAll();
        stDiSan.DataSource = Sys_Common.NV_DiSanVanHoa.GetAll(null,"vi");
        DataBind();
    }

    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        if (FormValidate())
        {
            NV_DangKyDiSan_ChiTiet model = new NV_DangKyDiSan_ChiTiet();
            model.SoDangKy = txtSodangky.Text;
            model.Mota = txtMota.Text;
            if (dtNgaydangky.SelectedDate != null)
            {
                model.NgayDangKy = dtNgaydangky.SelectedDate;
            }
            else
            {
                model.NgayDangKy = null;
            }
            model.CapDiSan = int.Parse(cmbCapdisan.Value.ToString());
            model.DiSanID = int.Parse(cmbTendisan.Value.ToString());
            model.TinhTrang = txtTinhtrang.Text;
            model.Duyet = radDuyet.Items[0].Checked;
            model.File = Document.DocumentID;
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            if (id != "")
            {
                model.DangKyId = int.Parse(id);
                Sys_Common.NV_DangKyDiSan.Update(model);
            }
            else
            {
                Sys_Common.NV_DangKyDiSan.them(model);
            }
            X.Msg.AddScript("parent.hdMsg.setValue('ok');");
            X.Msg.AddScript("parentAutoLoadControl.hide();");
        }
    }
    private void SetData(NV_DangKyDiSan_ChiTiet model)
    {
        btnUpdate.Text = "Cập nhật";
        btnUpdate.Icon = Icon.ApplicationEdit;

        txtSodangky.Text = model.SoDangKy;
        txtMota.Text = model.Mota;
        dtNgaydangky.Value = model.NgayDangKy;
        cmbCapdisan.Value = model.CapDiSan;
        cmbTendisan.Value = model.DiSanID;
        txtTinhtrang.Text = model.TinhTrang;
        radDuyet.Value = model.Duyet == true ? "1" : "0";
        Document.DocumentID = model.File;
    }
    private void ClearData()
    {
        btnUpdate.Text = "Thêm mới";
        btnUpdate.Icon = Icon.Add;
    }
    private bool FormValidate()
    {
        if (string.IsNullOrEmpty(txtSodangky.Text.Trim()) || cmbTendisan.Value == null || cmbCapdisan.Value == null)
        {
            X.Msg.Alert("Thông báo", "Thiếu thông tin ", new JFunction { Fn = "" }).Show();
            return false;
        }
        return true;
    }
}