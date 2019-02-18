using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLHS_Logic;
using QLHS_Logic.NV;
using Ext.Net;
using Models;
using System.Data;
public partial class NghiepVu_Media_CapnhatMediaLib : System.Web.UI.Page
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
            hdMediaLibID.Text = Request.QueryString["id"].ToString();
            Initialization();
            if (hdMediaLibID.Text != "0")
            {
                SetData(Sys_Common.NV_MediaLib.GetById(int.Parse(hdMediaLibID.Text)));
            }
            else
            {
                ClearData();
            }
        }
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        if (FormValidate())
        {
            NV_MediaLib_ChiTiet model = new NV_MediaLib_ChiTiet();
            model.TenMediaLib = txtTenLib.Text;
            model.MoTa = txtMota.Text;
            model.PageTitle = txtPageTitle.Text;
            model.MetaKeyword = txtMetaKeyword.Text;
            model.MetaDescription = txtMetaDescription.Text;
            model.Url = txtUrl.Text != "" ? StringUtil.RemoveSign4VietnameseString(txtUrl.Text).Replace(' ', '-') : StringUtil.RemoveSign4VietnameseString(txtTenLib.Text).Replace(' ', '-');
            model.DanhMuc = ",";
            foreach (var item in mcbDanhmuc.SelectedItems)
            {
                model.DanhMuc += item.Value + ",";
            }
            try
            {
                model.DiSanID = int.Parse(cmbDiSan.Value.ToString());
            }
            catch { }
            try
            {
                model.HoatDongID = int.Parse(cmbHoatDong.Value.ToString());
            }
            catch { }
            model.NgayTao = Convert.ToDateTime(dfNgaytao.Value.ToString());
            model.NgaySua = Convert.ToDateTime(dfNgaysua.Value.ToString());
            model.NguoiTao = Session["G_Ten_Nguoi_Dung"].ToString();
            model.TypeMedia = Request.QueryString["type"] == "1" ? 1 : 2;
            model.Duyet = ckbDuyet.Checked;
            model.MediaArray = Request.QueryString["type"] == "1" ? ImageMutil.ImageID : Video.VideoID;
            try
            {
                model.HinhAnh = int.Parse(ImageOnly.ImageID);
            }
            catch { }
            if (hdMediaLibID.Text != "0")
            {
                model.MediaLibID = int.Parse(Request.QueryString["id"].ToString());
                Sys_Common.NV_MediaLib.update(model);
            }
            else
            {
                Sys_Common.NV_MediaLib.ThemMediaLib(model);
            }
            X.Msg.AddScript("parent.hdMsg.setValue('ok');");
            X.Msg.AddScript("parentAutoLoadControl.hide();");
        }
    }
    protected void btnCancel_Click(object sender, DirectEventArgs e)
    {
        ClearData();
    }
    private void Initialization()
    {
        string type = Request.QueryString["type"].ToString();
        if (type == "1")               //thư viện ảnh
        {
            txtTenLib.FieldLabel = "Tên thư viện ảnh";
            pnVideo.Hidden = true;
            stDanhmuc.DataSource = Sys_Common.GetChildMenu(0, 2, null,"vi");
        }
        else if (type == "2")             //thư viện video
        {
            txtTenLib.FieldLabel = "Tên thư viện video";
            pnBoAnh.Hidden = true;
            stDanhmuc.DataSource = Sys_Common.GetChildMenu(0, 3, null,"vi");
        }

        stHoatDong.DataSource = Sys_Common.NV_HoatDongVanHoa.GetAll();
        stDiSan.DataSource = Sys_Common.NV_DiSanVanHoa.GetAll(null,"vi");
        DataBind();
    }

    private bool FormValidate()
    {
        if (this.txtTenLib.Value == null || mcbDanhmuc.SelectedItems == null)
        {
            X.Msg.Alert("Thông báo", "Thiếu thông tin ", new JFunction { Fn = "" }).Show();
            return false;
        }
        return true;
    }
    private void SetData(NV_MediaLib_ChiTiet model)
    {
        btnUpdate.Text = "Cập nhật";
        btnUpdate.Icon = Icon.ApplicationEdit;

        ImageMutil.ImageID = model.MediaArray;
        Video.VideoID = model.MediaArray;
        txtTenLib.Text = model.TenMediaLib;
        txtMota.Text = model.MoTa;
        txtPageTitle.Text = model.PageTitle;
        txtUrl.Text = model.Url;
        txtMetaKeyword.Text = model.MetaKeyword;
        txtMetaDescription.Text = model.MetaDescription;
        cmbDiSan.Value = model.DiSanID;
        cmbHoatDong.Value = model.HoatDongID;
        dfNgaytao.Value = model.NgayTao;
        dfNgaysua.Value = model.NgaySua;
        ImageOnly.ImageID = model.HinhAnh.ToString();
        ckbDuyet.Checked = model.Duyet;
        string[] danhmuc = model.DanhMuc.Split(',');
        foreach (string item in danhmuc)
        {
            if (!string.IsNullOrEmpty(item))
            {
                mcbDanhmuc.SelectedItems.Add(new Ext.Net.SelectedListItem(item));
            }
        }
    }
    private void ClearData()
    {
        btnUpdate.Text = "Thêm mới";
        btnUpdate.Icon = Icon.Add;

        hdMediaLibID.Text = "";
        ImageMutil.ImageID = "0";
        txtTenLib.Text = "";
        txtMota.Text = "";
        txtPageTitle.Text = "";
        txtUrl.Text = "";
        txtMetaKeyword.Text = "";
        txtMetaDescription.Text = "";
        mcbDanhmuc.Value = "";
        cmbDiSan.Value = "";
        cmbHoatDong.Value = "";
        dfNgaytao.Value = DateTime.Now;
        dfNgaysua.Value = DateTime.Now;
        ImageOnly.ImageID = "0";
    }
}