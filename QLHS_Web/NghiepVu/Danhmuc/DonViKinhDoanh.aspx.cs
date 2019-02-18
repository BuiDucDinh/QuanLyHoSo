using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLHS_Logic;
using System.Data;
public partial class NghiepVu_Danhmuc_LinhVucKinhDoanh : System.Web.UI.Page
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
        if (Session["G_Theme"] != null)
        {
            DHM_Common.SetTheme(this.Page, int.Parse(Session["G_Theme"].ToString()));
        }
        if (!this.IsPostBack)
        {
            Initialization();
        }

    }
    private void Initialization()
    {
        Role role = getRole();
        if (role.Duoc_Nhap)
        {
            btnUpdate.Visible = true;
        }
        else btnUpdate.Visible = false;
        stHuyen.DataSource = Sys_Common.LoadComboDiaDiem("36", "huyen");
        stLinhVuc.DataSource = Sys_Common.NV_DM_LinhVucKinhDoanh.GetAll();
        DataBind();
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
    protected void odsData_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        (this.stData.Proxy[0] as PageProxy).Total = (int)e.OutputParameters["Count"];
    }
    protected void stData_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        this.odsData.SelectParameters["Start"].DefaultValue = (e.Start + 1).ToString();
        this.odsData.SelectParameters["Limit"].DefaultValue = (e.Limit + e.Start).ToString();
        if (e.Parameters["Filter"] == "")
        {
            this.odsData.SelectParameters["WhereString"].DefaultValue = "(select *,(select TenLinhVuc from DM_LinhVucKinhDoanh lv where LinhVuc like '%,'+CAST(lv.ID as nvarchar(20))+',%') as LinhVucKD from DonViKinhDoanh) as A";
        }
        else
        {
            this.odsData.SelectParameters["WhereString"].DefaultValue = "select *,(select TenLinhVuc from DM_LinhVucKinhDoanh lv where LinhVuc like '%,'+CAST(lv.ID as nvarchar(20))+',%') as LinhVucKD from DonViKinhDoanh WHERE TenDonVi LIKE N'%" + e.Parameters["Filter"] + "%') as S";
        }
        this.odsData.SelectParameters["SortString"].DefaultValue = e.Sort + " " + e.Dir;

        this.odsData.DataBind();

    }
    protected void gvData_DbClick(object sender, DirectEventArgs e)
    {
        Role role = getRole();
        if (role.Duoc_Sua)
        {
            RowSelectionModel sm = gvData.SelectionModel.Primary as RowSelectionModel;
            foreach (SelectedRow row in sm.SelectedRows)
            {
                this.wdDetail.AutoLoad.Url = "~/NghiepVu/Danhmuc/CapNhatDonViKinhDoanh.aspx?id=" + row.RecordID;
                this.wdDetail.Icon = Icon.ApplicationEdit;
                this.wdDetail.Title = "Cập nhật đơn vị kinh doanh";
                this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
                this.wdDetail.Render(this.Form);
                this.wdDetail.Show();
                break;
            }
            sm.SelectedRows.Clear();
            sm.UpdateSelection();
        }
        else
        {
            X.Msg.Alert("Thông báo", "Bạn không có quyền sửa bản ghi.", new JFunction { Fn = "" }).Show();
        }
    }


    protected void btnExport_Click(object sender, DirectEventArgs e) { }
    protected void btnCancel_Click(object sender, DirectEventArgs e)
    {
        ClearData();
    }
    protected void btnDelete_Click(object sender, DirectEventArgs e)
    {
        Role role = getRole();
        if (role.Duoc_Xoa)
        {
            RowSelectionModel sm = gvData.SelectionModel.Primary as RowSelectionModel;
            foreach (SelectedRow row in sm.SelectedRows)
            {
                Sys_Common.NV_DM_LinhVucKinhDoanh.Xoa(int.Parse(row.RecordID));
            }
            sm.SelectedRows.Clear();
            sm.UpdateSelection();
            X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
            X.Msg.AddScript("#{stData}.reload();");
        }
        else
        {
            X.Msg.Alert("Thông báo", "Bạn không có quyền xóa bản ghi.", new JFunction { Fn = "" }).Show();
        }
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        Role role = getRole();
        if (role.Duoc_Nhap)
        {
            this.wdDetail.AutoLoad.Url = "~/NghiepVu/Danhmuc/CapNhatDonViKinhDoanh.aspx";
            this.wdDetail.Icon = Icon.Add;
            this.wdDetail.Title = "Thêm mới đơn vị kinh doanh";
            this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
            this.wdDetail.Render(this.Form);
            this.wdDetail.Show();
        }
        else
        {
            X.Msg.Alert("Thông báo", "Bạn không có quyền thêm mới bản ghi.", new JFunction { Fn = "" }).Show();
        }
    }
    private void ClearData()
    {
        btnUpdate.Text = "Thêm mới";
        btnUpdate.Icon = Icon.Add;
        txtTen.Text = "";
        txtSoGiayPhep.Text = "";
        //cmbThuocTinh.SelectedIndex = 0;
        cmbThuocHuyen.SelectedIndex = 0;
        cmbThuocXa.SelectedIndex = 0;
        cmbLinhVuc.SelectedIndex = 0;
    }
    private Role getRole()
    {
        string maForm = Request.QueryString["cn"].ToString();
        int maND = int.Parse(Session["G_Ma_Nguoi_Dung"].ToString());
        Role role = Sys_Common.HT_NGUOI_DUNG_VAI_TRO.getRoleUserByForm(maND, maForm);
        return role;
    }
}