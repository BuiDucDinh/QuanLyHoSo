using Ext.Net;
using QLHS_Logic;
using QLHS_Logic.NV;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NghiepVu_Media_MediaLib : System.Web.UI.Page
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
        }
    }
    private void Initialization()
    {
        int type = int.Parse(Request.QueryString["type"].ToString());
        DataTable dt = new DataTable();
        if (type == 1)
        {
            txtTenLib.FieldLabel = "Nhập tên thư viện ảnh";
            dt = Sys_Common.GetChildMenu(0, 2, null,"vi");
        }
        else
        {
            txtTenLib.FieldLabel = "Nhập tên thư viện video";
            dt = Sys_Common.GetChildMenu(0, 3, null,"vi");
        }
        DataRow row = dt.NewRow();
        row["MenuID"] = 0;
        row["TenMenu"] = "Chọn danh mục";
        dt.Rows.InsertAt(row, 0);

        stDanhmuc.DataSource = dt;

        stDiSan.DataSource = Sys_Common.LoadCombo("DiSan");
        stHoatDong.DataSource = Sys_Common.LoadCombo("HoatDong");
        DataBind();
        Role role = getRole();
        btnUpdate.Visible = role.Duoc_Nhap;
        btnDelete.Visible = role.Duoc_Xoa;
    }
    private Role getRole()
    {
        string maForm = Request.QueryString["cn"].ToString();
        int maND = int.Parse(Session["G_Ma_Nguoi_Dung"].ToString());
        Role role = Sys_Common.HT_NGUOI_DUNG_VAI_TRO.getRoleUserByForm(maND, maForm);
        return role;
    }
    protected void odsMediaLib_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        (this.stMediaLib.Proxy[0] as PageProxy).Total = (int)e.OutputParameters["Count"];
    }
    protected void stMediaLib_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        this.odsMediaLib.SelectParameters["Start"].DefaultValue = (e.Start + 1).ToString();
        this.odsMediaLib.SelectParameters["Limit"].DefaultValue = (e.Limit + e.Start).ToString();
        string where = @"(select MediaLibID,TenMediaLib,NgaySua,Duyet,TypeMedia,
                        (select TenDiSan from DiSanVanHoa ds where ds.DiSanID=m.DiSanID) as DiSan,
                        (select TenGoi from HoatDongVanHoa hd where hd.HoatDongID=m.HoatDongID) as HoatDong,
                        (select TenAnh from [Image] i where i.ImageID=m.HinhAnh) as HinhAnh,
                        (SELECT DISTINCT SUBSTRING((SELECT ','+TenMenu FROM Menu  where m.DanhMuc like '%,'+CAST(MenuID as nvarchar(20))+',%' FOR XML PATH ('')), 2, 1000)) DanhMuc
                        from MediaLib m where TypeMedia=" + Request.QueryString["type"].ToString();
        if (cmbHoatDong.Value != null && cmbHoatDong.Value.ToString() != "0")
        {
            where += " and HoatDongID=" + cmbHoatDong.Value.ToString();
        }
        if (cmbDanhmuc.Value != null && cmbDanhmuc.Value.ToString() != "0")
        {
            where += " and DanhMuc='," + cmbDanhmuc.Value.ToString() + ",'";
        }
        if (cmbDiSan.Value != null && cmbDiSan.Value.ToString() != "0")
        {
            where += " and DiSanID=" + cmbDiSan.Value.ToString();
        }
        if (txtTenLib.Text != "")
        {
            where += " and TenMeDiaLib like '%" + txtTenLib.Text + "%'";
        }
        where += ") as A";
        this.odsMediaLib.SelectParameters["WhereString"].DefaultValue = where;

        this.odsMediaLib.SelectParameters["SortString"].DefaultValue = e.Sort + " " + e.Dir;

        this.odsMediaLib.DataBind();

    }
    protected void gridMediaLib_DbClick(object sender, DirectEventArgs e)
    {
        Role role = getRole();
        if (role.Duoc_Sua)
        {
            RowSelectionModel sm = gridMediaLib.SelectionModel.Primary as RowSelectionModel;
            foreach (SelectedRow row in sm.SelectedRows)
            {
                this.wdDetail.AutoLoad.Url = "~/NghiepVu/Media/CapnhatMediaLib.aspx?type=" + Request.QueryString["type"].ToString() + "&id=" + row.RecordID;
                this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
                this.wdDetail.Render(this.Form);
                this.wdDetail.Show();
                break;
            }
        }
        else
        {
            X.Msg.Alert("Thông báo", "Bạn không có quyền sửa bản ghi !!!", new JFunction { Fn = "" }).Show();
        }
    }
    protected void btnLoc_Click(object sender, DirectEventArgs e)
    {
        X.Msg.AddScript("#{stMediaLib}.reload();");
    }
    protected void btnCancel_Click(object sender, DirectEventArgs e)
    {
        txtTenLib.Text = "";
        cmbDanhmuc.SelectedIndex = 0;
        cmbDiSan.SelectedIndex = 0;
        cmbHoatDong.SelectedIndex = 0;
    }
    protected void Command_Event(object sender, DirectEventArgs e)
    {
        string command = e.ExtraParams["command"].ToString();
        string RowIndex = e.ExtraParams["rowIndex"].ToString();
        string typeMedia = Request.QueryString["type"].ToString();
        Role role = getRole();
        if (command == "Show")
        {
            NV_MediaLib_ChiTiet model = Sys_Common.NV_MediaLib.GetById(int.Parse(RowIndex));
            string url = model.Url;
            string script = string.Format("window.open('{0}');", url);
            X.AddScript(script);
        }
        else if (command == "Add")
        {
            if (role.Duoc_Nhap || role.Duoc_Sua)
            {
                hdMedia.Text = RowIndex;
                if (typeMedia == "1")    //ảnh
                {
                    wdMedia.Title = "Add ảnh vào album";
                }
                else if (typeMedia == "2")
                {
                    wdMedia.Title = "Add video vào thư viện";
                }
                wdMedia.AutoLoad.Url = "~/NghiepVu/Media/AddMediaInLib.aspx?type=" + typeMedia + "&id=" + RowIndex;
                wdMedia.AutoLoad.Mode = LoadMode.IFrame;
                wdMedia.Render(this.Form);
                wdMedia.Show();
            }
            else
            {
                X.Msg.Alert("Thông báo", "Bạn không có quyền sửa bản ghi !!!", new JFunction { Fn = "" }).Show();
            }
        }
    }
    protected void wdMedia_Hide(object sender, DirectEventArgs e)
    {
        NV_MediaLib_ChiTiet model = Sys_Common.NV_MediaLib.GetById(int.Parse(hdMedia.Text));
        string array = "";
        if (model.TypeMedia == 1)
        {
            array = Image_txtTextField.Text != "" ? Image_txtTextField.Text : model.MediaArray;
        }
        else
        {
            array = Video_hdVideo.Text != "" ? Video_hdVideo.Text : model.MediaArray;
        }
        if (array != model.MediaArray)
        {
            model.MediaArray = array;
            bool check = Sys_Common.NV_MediaLib.update(model);
            if (check == true)
            {
                hdMedia.Text = "";
                Video_hdVideo.Text = "";
                Image_txtTextField.Text = "";
                X.Msg.Alert("Thông báo", "Đã cập nhật thành công !!!", new JFunction { Fn = "" }).Show();
            }
        }
    }
    protected void btnExport_Click(object sender, DirectEventArgs e) { }

    protected void btnDelete_Click(object sender, DirectEventArgs e)
    {
        Role role = getRole();
        if (role.Duoc_Xoa)
        {
            RowSelectionModel sm = gridMediaLib.SelectionModel.Primary as RowSelectionModel;
            foreach (SelectedRow row in sm.SelectedRows)
            {
                Sys_Common.NV_KeHoachTuBo.Xoa(int.Parse(row.RecordID));
            }
            sm.SelectedRows.Clear();
            sm.UpdateSelection();
            X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
            X.Msg.AddScript("#{stMediaLib}.reload();");
        }
        else
        {
            X.Msg.Alert("Thông báo", "Bạn không có quyền xóa bản ghi !!!", new JFunction { Fn = "" }).Show();
        }
    }

    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        Role role = getRole();
        if (role.Duoc_Nhap)
        {
            this.wdDetail.AutoLoad.Url = "~/NghiepVu/Media/CapNhatMediaLib.aspx?id=0&type=" + Request.QueryString["type"].ToString();
            this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
            this.wdDetail.Render(this.Form);
            this.wdDetail.Show();
        }
        else
        {
            X.Msg.Alert("Thông báo", "Bạn không có quyền thêm mới bản ghi !!!", new JFunction { Fn = "" }).Show();
        }
    }
}