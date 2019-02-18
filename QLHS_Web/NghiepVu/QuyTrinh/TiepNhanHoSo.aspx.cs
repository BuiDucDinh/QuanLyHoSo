using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLHS_Logic.NV;
using QLHS_Logic;
public partial class NghiepVu_QuyTrinh_TiepNhanHoSo : System.Web.UI.Page
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
        if (!this.IsPostBack)
        {
            if (Session["G_Theme"] != null)
            {
                DHM_Common.SetTheme(this.Page, int.Parse(Session["G_Theme"].ToString()));
            }
            Initialization();
            int id = 0;
            try
            {
                id = int.Parse(Request.QueryString["id"].ToString());
                SetData(id);
            }
            catch { }
        }
    }
    private void Initialization()
    {
    }
    private void SetData(int id)
    {
        try
        {
            NV_LuongXuLy_ChiTiet model = Sys_Common.NV_LuongXuLy.GetById(id);
            NV_LuongXuLy_ChiTiet modelLast = Sys_Common.NV_LuongXuLy.GetLast(model.IDQTCuThe);
            if (model.ID == modelLast.ID)
            {
                btnSubmit.Text = "Hoàn thành và kết thúc hồ sơ";
            }
            hdID.Value = model.ID;
            txtTen.Text = model.Ten;
            txtTen.Disabled = true;
            lbMota.Text = model.MoTa;
            hlFile.NavigateUrl = "/FileUpload/Document/" + model.FileTiepNhan;
            hlFile.Text = model.FileTiepNhan;
            try
            {
                dtNgayBatDau.SelectedDate = (DateTime)model.NgayXuLy;
            }
            catch
            {
                dtNgayBatDau.SelectedDate = DateTime.Now;
            }
            dtNgayBatDau.Disabled = true;

            Document.DocumentID = model.FileLienQuan.ToString();
            txtMota.Text = model.MoTa;
        }
        catch
        {
            X.Msg.AddScript("parent.hdMsg.setValue('error');");
            X.Msg.AddScript("parentAutoLoadControl.hide();");
        }
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        if (FormValidate() && Submit(1))
        {
            X.Msg.AddScript("parent.hdMsg.setValue('ok');");
            X.Msg.AddScript("parentAutoLoadControl.hide();");
        }
        else
        {
            X.Msg.Alert("Thông báo", "Đã có lỗi sảy ra...Xin thử lại", new JFunction { Fn = "" }).Show();
        }
    }
    private bool Submit(int trangthai)
    {
        int id = 0;
        try
        {
            id = int.Parse(hdID.Value.ToString());
        }
        catch { }
        NV_LuongXuLy_ChiTiet model = Sys_Common.NV_LuongXuLy.GetById(id);

        bool check = false;
        if (id != 0)
        {
            model.ID = id;
            model.MoTa = txtMota.Text;
            model.FileLienQuan = Document.DocumentID;
            model.TrangThai = trangthai;
            check = Sys_Common.NV_LuongXuLy.update(model);
        }
        return check;
    }
    protected void btnSubmit_Click(object sender, DirectEventArgs e)
    {
        if (FormValidate() && Submit(0))
        {
            X.Msg.AddScript("parent.hdMsg.setValue('ok');");
            X.Msg.AddScript("parentAutoLoadControl.hide();");
        }
        else
        {
            X.Msg.Alert("Thông báo", "Đã có lỗi sảy ra...Xin thử lại", new JFunction { Fn = "" }).Show();
        }
    }
    protected void btnShowInfo_Click(object sender, DirectEventArgs e)
    {
        int id = 0;
        try
        {
            id = int.Parse(hdID.Value.ToString());
        }
        catch { }
        NV_LuongXuLy_ChiTiet model = Sys_Common.NV_LuongXuLy.GetById(id);
        this.wdDetail.AutoLoad.Url = "~/Nghiepvu/QuyTrinh/ThongTinHoSo.aspx?id=" + model.IDQTCuThe;
        this.wdDetail.Icon = Icon.ApplicationEdit;
        this.wdDetail.Title = "Thông tin về hồ sơ";
        this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
        this.wdDetail.Render(this.Form);
        this.wdDetail.Show();
    }
    protected void btnShowProcess_Click(object sender, DirectEventArgs e)
    {
        int id = 0;
        try
        {
            id = int.Parse(hdID.Value.ToString());
        }
        catch { }
        NV_LuongXuLy_ChiTiet model = Sys_Common.NV_LuongXuLy.GetById(id);
        this.wdDetail.AutoLoad.Url = "~/Nghiepvu/QuyTrinh/ThongTinHoSo.aspx?id=" + model.IDQTCuThe;
        this.wdDetail.Icon = Icon.ApplicationEdit;
        this.wdDetail.Title = "Thông tin về hồ sơ";
        this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
        this.wdDetail.Render(this.Form);
        this.wdDetail.Show();
    }
    private bool FormValidate()
    {
        if (string.IsNullOrEmpty(Document.DocumentID))
        {
            return false;
        }
        return true;
    }
}