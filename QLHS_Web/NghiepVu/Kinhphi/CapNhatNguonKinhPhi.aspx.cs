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
public partial class NghiepVu_KinhPhi_CapNhatNguonKinhPhi : System.Web.UI.Page
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
                SetData(Sys_Common.NV_NguonKinhPhi.GetById(int.Parse(id)));
            }
        }
    }
    private void Initialization()
    {
        stNguoidautu.DataSource = Sys_Common.NV_NhaDauTu.GetAll();
        stLoainguon.DataSource = Sys_Common.NV_LoaiNguonKinhPhi.GetAll();
        DataBind();
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        if (FormValidate())
        {
            NV_NguonKinhPhi_ChiTiet model = new NV_NguonKinhPhi_ChiTiet();
            model.NguoiDauTuID = int.Parse(cbNguoidautu.Value.ToString());
            model.NguonKinhPhiID = int.Parse(cbLoainguon.Value.ToString());
            try
            {
                model.SoTien = decimal.Parse(txtSoTien.Text);
            }
            catch
            {
                X.Msg.Alert("Thông báo", "Số tiền nhập vào không đúng", new JFunction { Fn = "" }).Show();
                return;
            }
            model.TaiLieu = Document.DocumentID;
            model.MoTa = txtMota.Text;
            bool check = false;
            if (hdID.Text != "")
            {
                model.ID = int.Parse(hdID.Text);
                model.NgayDauTu = Convert.ToDateTime(txtNgaydautu.Text);
                NV_NguonKinhPhi_ChiTiet nguon = Sys_Common.NV_NguonKinhPhi.GetById(model.ID);
                if (model.SoTien != nguon.SoTien)
                {
                    model.TienConLai += model.SoTien - nguon.SoTien;
                    if (model.TienConLai < 0)
                    {
                        X.Msg.Alert("Thông báo", "Nguồn kinh phí này đã được sử dụng, không thể thay đổi số tiền đầu tư", new JFunction { Fn = "" }).Show();
                        return;
                    }
                }
                else
                {
                    model.TienConLai = decimal.Parse(txtTienconlai.Text);
                }
                check = Sys_Common.NV_NguonKinhPhi.update(model);
            }
            else
            {
                model.TienConLai = model.SoTien;
                model.NgayDauTu = DateTime.Now;
                check = Sys_Common.NV_NguonKinhPhi.them(model);
            }
            if (check == true)
            {
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
        if (string.IsNullOrEmpty(txtSoTien.Text.Trim()) || cbLoainguon.Value == null || cbNguoidautu.Value == null)
        {
            X.Msg.Alert("Thông báo", "Thiếu thông tin ", new JFunction { Fn = "" }).Show();
            return false;
        }
        return true;
    }
    private void SetData(NV_NguonKinhPhi_ChiTiet model)
    {
        btnUpdate.Text = "Cập nhật";
        btnUpdate.Icon = Icon.ApplicationEdit;

        hdID.Value = model.ID;
        txtMota.Text = model.MoTa;
        txtNgaydautu.SelectedValue = model.NgayDauTu;
        txtTienconlai.Text = model.TienConLai.ToString();
        txtSoTien.Text = model.SoTien.ToString();
        cbNguoidautu.Value = model.NguoiDauTuID;
        cbLoainguon.Value = model.NguonKinhPhiID;
        Document.DocumentID = model.TaiLieu;
    }

    private void ClearData()
    {
        btnUpdate.Text = "Thêm mới";
        btnUpdate.Icon = Icon.Add;

    }
}