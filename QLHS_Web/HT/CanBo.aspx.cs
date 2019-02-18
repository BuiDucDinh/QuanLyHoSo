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

public partial class HT_CanBo : System.Web.UI.Page
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
            //X.Msg.Alert("Thông báo", Session["G_Ma_Chuc_Nang"].ToString(), new JFunction { Fn = "" }).Show();
            if (Session["G_Theme"] != null)
            {
                DHM_Common.SetTheme(this.Page, int.Parse(Session["G_Theme"].ToString()));
            }
            Initialization();
        }
    }
    private void Initialization()
    {
        stChucVu.DataSource = Sys_Common.NV_DM_ChucVu.GetAll();

        DataTable datasource = Sys_Common.NV_CoQuanHanhChinh.GetDataToCombo();
        DataRow dr = datasource.NewRow();
        dr["CoQuanID"] = 0;
        dr["TenCoQuan"] = "Chọn cơ quan quản lý";
        datasource.Rows.InsertAt(dr, 0);
        stCoQuan.DataSource = datasource;
        DataBind();
    }
    protected void odsData_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        (this.stData.Proxy[0] as PageProxy).Total = (int)e.OutputParameters["Count"];
    }
    protected void btnExport_Click(object sender, DirectEventArgs e) { }
    protected void btnCancel_Click(object sender, DirectEventArgs e)
    {
        ClearData();
    }
    protected void btnDelete_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gvData.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            Sys_Common.NV_CanBo.Xoa(int.Parse(row.RecordID));
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
        X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
        X.Msg.AddScript("#{stData}.reload();");
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        if (FormValidate())
        {
            NV_CanBo_ChiTiet model = new NV_CanBo_ChiTiet();
            model.HoTen = txtTenCanBo.Text;
            model.GhiChu = txtGhiChu.Text;
            model.SoDienThoai = txtSoDienThoai.Text;
            model.Email = txtEmail.Text;
            model.DiaChi = txtDiaChi.Text;
            model.ChucVu = new NV_DM_ChucVu_ChiTiet();
            model.CoQuan = new NV_CoQuanHanhChinh_ChiTiet();
            model.ChucVu.ChucvuID = int.Parse(cbChucVu.Value.ToString());
            model.CoQuan.CoQuanID = int.Parse(cbNoiCongTac.Value.ToString());
            if (hdCanBoID.Text != "")
            {
                model.canBoID = int.Parse(hdCanBoID.Text);
                Sys_Common.NV_CanBo.update(model);
            }
            else
            {
                Sys_Common.NV_CanBo.them(model);
            }
            ClearData();
            X.Msg.Alert("Thông báo", "Đã cập nhật thành công !!!", new JFunction { Fn = "" }).Show();
            X.Msg.AddScript("#{stData}.reload();");
        }
    }
    protected void stData_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        this.odsData.SelectParameters["Start"].DefaultValue = (e.Start + 1).ToString();
        this.odsData.SelectParameters["Limit"].DefaultValue = (e.Limit + e.Start).ToString();
        if (e.Parameters["Filter"] == "")
        {
            this.odsData.SelectParameters["WhereString"].DefaultValue = @"(select *,(select TenChucVu from ChucVu c where c.ChucVuID=cb.ChucVuID) as ChucVu,
	                (select TenCoQuan from DM_CoQuanHanhChinh cq where cq.CoQuanID=cb.CoQuanID) as CoQuan,
                    (select Ten_Dang_Nhap from HT_Nguoi_Dung nd where nd.CanBoID=cb.CanBoID) as Username
	                from CanBo cb) as A";
        }
        else
        {
            this.odsData.SelectParameters["WhereString"].DefaultValue = "(select ChucVuID,TenChucVu,MoTa from ChucVu  WHERE  TenChucVu LIKE N'%" + e.Parameters["Filter"] + "%') as S";
        }
        this.odsData.SelectParameters["SortString"].DefaultValue = e.Sort + " " + e.Dir;

        this.odsData.DataBind();

    }
    protected void gvData_DbClick(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gvData.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            NV_CanBo_ChiTiet myDetail = Sys_Common.NV_CanBo.GetById(int.Parse(row.RecordID));  //Sys_Common.NL_DM_BIEN_CHE.Lay(int.Parse(row.RecordID));
            SetData(myDetail);
            break;
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
    }

    private void SetData(NV_CanBo_ChiTiet myDetail)
    {
        btnUpdate.Text = "Cập nhật";
        btnUpdate.Icon = Icon.ApplicationEdit;

        txtTenCanBo.Value = myDetail.HoTen;
        txtGhiChu.Value = myDetail.GhiChu;
        txtSoDienThoai.Value = myDetail.SoDienThoai;
        cbChucVu.Value = myDetail.ChucVu.ChucvuID.ToString();
        cbNoiCongTac.Value = myDetail.CoQuan.CoQuanID.ToString();
        txtDiaChi.Value = myDetail.DiaChi;
        txtEmail.Value = myDetail.Email;
        hdCanBoID.Value = myDetail.canBoID;
    }
    private void ClearData()
    {
        btnUpdate.Text = "Thêm mới";
        btnUpdate.Icon = Icon.Add;

        txtTenCanBo.Value = "";
        txtGhiChu.Value = "";
        txtSoDienThoai.Value = "";
        txtDiaChi.Value = "";
        txtEmail.Value = "";
        hdCanBoID.Value = "";
        cbChucVu.Value = "";
        cbNoiCongTac.Value = "";

    }
    private bool FormValidate()
    {
        if (string.IsNullOrEmpty(txtTenCanBo.Text.Trim()) || cbChucVu.Value == null || string.IsNullOrEmpty(cbChucVu.Value.ToString()) || cbNoiCongTac.Value == null || string.IsNullOrEmpty(cbNoiCongTac.Value.ToString()))
        {
            X.Msg.Alert("Thông báo", "Thiếu thông tin ", new JFunction { Fn = "" }).Show();
            return false;
        }
        return true;
    }
}