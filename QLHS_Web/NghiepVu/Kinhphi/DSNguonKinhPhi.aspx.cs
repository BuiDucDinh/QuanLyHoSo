using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using System.Data;
using QLHS_Logic;
using QLHS_Logic.NV;
public partial class NghiepVu_KinhPhi_DSNguonKinhPhi : System.Web.UI.Page
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

    #region Nhà đầu tư
    protected void odsNhadautu_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        (this.stDSNhadautu.Proxy[0] as PageProxy).Total = (int)e.OutputParameters["Count"];
    }
    protected void stDSNhadautu_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        this.odsNhadautu.SelectParameters["Start"].DefaultValue = (e.Start + 1).ToString();
        this.odsNhadautu.SelectParameters["Limit"].DefaultValue = (e.Limit + e.Start).ToString();

        this.odsNhadautu.SelectParameters["WhereString"].DefaultValue = @"(SELECT * FROM NhaDauTu ) as A";

        this.odsNhadautu.SelectParameters["SortString"].DefaultValue = e.Sort + " " + e.Dir;
        this.odsNhadautu.DataBind();

    }
    protected void btnUpdate1_Click(object sender, DirectEventArgs e)
    {
        if (validate())
        {
            NV_NhaDauTu_ChiTiet model = new NV_NhaDauTu_ChiTiet();
            model.Ten = txtTen.Text;
            model.DiaChi = txtDiachi.Text;
            model.DienThoai = txtDienthoai.Text;
            model.MoTa = txtMota.Text;
            model.Email = txtEmail.Text;
            bool check = false;
            try
            {
                int id = int.Parse(hdID.Value.ToString());
                model.ID = id;
                check = Sys_Common.NV_NhaDauTu.update(model);
            }
            catch
            {
                check = Sys_Common.NV_NhaDauTu.them(model);
            }
            if (check == true)
            {
                ClearData();
                X.Msg.AddScript("#{stDSNhadautu}.reload();");
                X.Msg.Alert("Thông báo", "Đã cập nhật thành công", new JFunction { Fn = "" }).Show();
            }
            else
            {
                X.Msg.Alert("Thông báo", "Đã có lỗi sảy ra...Xin thử lại", new JFunction { Fn = "" }).Show();
            }
        }
        else
        {
            X.Msg.Alert("Thông báo", "Bạn chưa nhập đủ thông tin", new JFunction { Fn = "" }).Show();
        }

    }
    protected void btnDelete1_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gvNhadautu.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            int id = int.Parse(row.RecordID);
            DataTable dt = Sys_Common.NV_NguonKinhPhi.GetByNhaDauTu(id);
            if (dt != null && dt.Rows.Count > 0)
            {
                X.Msg.Alert("Thông báo", "Đã phát sinh nguồn vốn đầu tư. Không thể xóa nhà đầu tư này !!!", new JFunction { Fn = "" }).Show();
            }
            else
            {
                Sys_Common.NV_NhaDauTu.Xoa(id);
                sm.SelectedRows.Clear();
                sm.UpdateSelection();
                X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
                X.Msg.AddScript("#{stData}.reload();");
            }
            break;
        }
    }
    protected void btnCanCel1_Click(object sender, DirectEventArgs e)
    {
        ClearData();
    }
    protected void gvNhadautu_DbClick(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gvNhadautu.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            int id = int.Parse(row.RecordID);
            NV_NhaDauTu_ChiTiet myDetail = Sys_Common.NV_NhaDauTu.GetById(id);
            SetData(myDetail);
            break;
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
    }
    private void SetData(NV_NhaDauTu_ChiTiet model)
    {
        btnUpdate1.Text = "Cập nhật";
        btnUpdate1.Icon = Icon.ApplicationEdit;
        hdID.Text = model.ID.ToString();
        txtTen.Text = model.Ten;
        txtMota.Text = model.MoTa;
        txtEmail.Text = model.Email;
        txtDienthoai.Text = model.DienThoai;
        txtDiachi.Text = model.DiaChi;
    }
    private bool validate()
    {
        if (string.IsNullOrEmpty(txtTen.Text))
        {
            return false;
        }
        return true;
    }
    private void ClearData()
    {
        hdID.Value = "";
        txtTen.Text = "";
        txtMota.Text = "";
        txtEmail.Text = "";
        txtDienthoai.Text = "";
        txtDiachi.Text = "";
    }
    [DirectMethod]
    public void Command(string command, string value)
    {
        int id = int.Parse(value);
        if (command == "Edit")
        {
            DataTable dt = Sys_Common.NV_NguonKinhPhi.GetByNhaDauTu(id);
            if (dt != null && dt.Rows.Count > 0)
            {
                X.Msg.Alert("Thông báo", "Đã phát sinh nguồn vốn đầu tư. Không thể xóa nhà đầu tư này !!!", new JFunction { Fn = "" }).Show();
            }
            else
            {
                Sys_Common.NV_NhaDauTu.Xoa(id);
                X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
                X.Msg.AddScript("#{stDSNhadautu}.reload();");
            }
        }
    }
    #endregion

    #region Nguồn kinh phí
    private void Initialization()
    {
        stNguonKinhPhi.DataSource = Sys_Common.NV_LoaiNguonKinhPhi.GetAll();
        stNhadautu.DataSource = Sys_Common.NV_NhaDauTu.GetAll();
        DataBind();
    }
    protected void odsData_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        (this.stData.Proxy[0] as PageProxy).Total = (int)e.OutputParameters["Count"];
    }
    protected void stData_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        this.odsData.SelectParameters["Start"].DefaultValue = (e.Start + 1).ToString();
        this.odsData.SelectParameters["Limit"].DefaultValue = (e.Limit + e.Start).ToString();
        string dk = "";
        if (cbNhadautu.Value != null && !string.IsNullOrEmpty(cbNhadautu.Value.ToString()))
        {
            dk += " and NguoiDauTuID = " + hdID.Value.ToString();
        }
        if (txtTungay.SelectedDate != txtTungay.MinDate)
        {
            try
            {
                dk += " and DATEDIFF(d," + txtTungay.SelectedDate.ToString("MM/dd/yyyy") + ",NgayDauTu)>=0";
            }
            catch { }
        }

        if (txtDenngay.SelectedDate != txtDenngay.MinDate)
        {
            try
            {
                dk += " and DATEDIFF(d,NgayDauTu," + txtDenngay.SelectedDate.ToString("MM/dd/yyyy") + ")>=0";
            }
            catch { }
        }
        if (cbNguonKinhPhi.Value != null)
        {
            dk += " and NguonKinhPhiID=" + cbNguonKinhPhi.Value.ToString();
        }
        this.odsData.SelectParameters["WhereString"].DefaultValue = @"(SELECT [ID]
                                                                          ,[NguoiDauTuID],[NguonKinhPhiID],[SoTien],[NgayDauTu],[TienConLai],[MoTa],[TaiLieu]
                                                                          ,(select Ten+' - '+DienThoai+' - '+Email+' - '+DiaChi from NhaDauTu dt where n.NguoiDauTuID=dt.ID) as NguoiDauTu      
                                                                          ,(select TenLoai from DM_LoaiNguonKinhPhi l where n.NguonKinhPhiID=l.ID) as NguonKinhPhi
                                                                      FROM [TC_Data_Disanvanhoa].[dbo].[NguonKinhPhi] n where 1=1" + dk + ") as A";

        this.odsData.SelectParameters["SortString"].DefaultValue = e.Sort + " " + e.Dir;

        this.odsData.DataBind();

    }
    protected void gvData_DbClick(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gvData.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            this.wdDetail.AutoLoad.Url = "~/NghiepVu/KinhPhi/CapnhatNguonKinhPhi.aspx?id=" + row.RecordID;
            this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
            this.wdDetail.Icon = Icon.ApplicationEdit;
            this.wdDetail.Title = "Cập nhật nguồn kinh phí";
            this.wdDetail.Render(this.Form);
            this.wdDetail.Show();
            break;
        }
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        this.wdDetail.AutoLoad.Url = "~/NghiepVu/KinhPhi/CapnhatNguonKinhPhi.aspx";
        this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
        this.wdDetail.Render(this.Form);
        this.wdDetail.Show();
    }
    protected void btnDelete_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gvData.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            int id = int.Parse(row.RecordID);
            DataTable dt = Sys_Common.NV_PhanBoKinhPhi.GetByNguon(id);
            if (dt.Rows.Count <= 0)
            {
                sm.SelectedRows.Clear();
                sm.UpdateSelection();
                X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
                X.Msg.AddScript("#{stData}.reload();");
                Sys_Common.NV_NguonKinhPhi.Xoa(id);
            }
            else
            {
                X.Msg.Alert("Thông báo", "Nguồn này đã được phân bổ, không thể xóa !!!", new JFunction { Fn = "" }).Show();
            }
        }
    }
    protected void btnExport_Click(object sender, DirectEventArgs e)
    {
    }
    protected void btnLoc_Click(object sender, DirectEventArgs e)
    {
        X.Msg.AddScript("#{stData}.reload();");
    }
    protected void btnCancel_Click(object sender, DirectEventArgs e)
    {
        cbNhadautu.Value = "";
        txtTungay.Text = "";
        txtDenngay.Text = "";
        X.Msg.AddScript("#{stData}.reload();");
    }
    #endregion
}