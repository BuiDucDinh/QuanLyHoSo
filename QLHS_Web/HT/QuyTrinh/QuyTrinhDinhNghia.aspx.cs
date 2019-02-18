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

public partial class HT_QuyTrinhDinhNghia : System.Web.UI.Page
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
        stLoaiQuyTrinh.DataSource = Sys_Common.NV_LoaiQuyTrinh.GetAll();
        stCoQuan.DataSource = Sys_Common.NV_CoQuanHanhChinh.GetDataToCombo();
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
        string sql = @"select ID,Ten,(select TenLoai from LoaiQuyTrinh l where l.ID=q.LoaiQuyTrinh) as LoaiQuyTrinh,TrangThai,NgayHieuLuc,NgayTao,NguoiTao from QuyTrinhDinhNghia q";
        if (e.Parameters["Filter"] != "")
        {
            sql += " where Ten like '%" + e.Parameters["Filter"].ToString() + "%'";
        }
        this.odsData.SelectParameters["WhereString"].DefaultValue = @"(" + sql + ") as A";
        this.odsData.SelectParameters["SortString"].DefaultValue = e.Sort + " " + e.Dir;

        this.odsData.DataBind();

    }
    protected void btnExport_Click(object sender, DirectEventArgs e) { }
    protected void btnDelete_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gvData.SelectionModel.Primary as RowSelectionModel;
        bool check = true;
        int id = 0;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            id = int.Parse(row.RecordID);
            DataTable dt = Sys_Common.NV_QuyTrinhXuLy.GetByQuyTrinh(id);
            if (dt == null || dt.Rows.Count == 0)
            {
                check = true;
            }
            else
            {
                check = false;
                break;
            }
        }
        if (check)
        {
            foreach (SelectedRow row in sm.SelectedRows)
            {
                id = int.Parse(row.RecordID);
                Sys_Common.NV_CanBo.Xoa(id);
            }
            sm.SelectedRows.Clear();
            sm.UpdateSelection();
            X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
            X.Msg.AddScript("#{stData}.reload();");
        }
        else
        {
        }
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        this.wdDetail.AutoLoad.Url = "~/HT/QuyTrinh/CapNhatQuyTrinhDinhNghia.aspx";
        this.wdDetail.Icon = Icon.ApplicationEdit;
        this.wdDetail.Title = "Thêm mới quy trình, thủ tục";
        this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
        this.wdDetail.Render(this.Form);
        this.wdDetail.Show();
    }
    protected void gvData_DbClick(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gvData.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            this.wdDetail.AutoLoad.Url = "~/HT/QuyTrinh/CapNhatQuyTrinhDinhNghia.aspx?id=" + row.RecordID;
            this.wdDetail.Icon = Icon.ApplicationEdit;
            this.wdDetail.Title = "Chỉnh sửa quy trình, thủ tục";
            this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
            this.wdDetail.Render(this.Form);
            this.wdDetail.Show();
            break;
        }
    }
    [DirectMethod]
    public void Command(string command, string value)
    {
        int ID = int.Parse(value);
        if (command == "Delete")
        {
            DataTable dt = Sys_Common.NV_QuyTrinhXuLy.GetByQuyTrinh(ID);
            if (dt == null || dt.Rows.Count == 0)
            {
                Sys_Common.NV_QuyTrinhDinhNghia.Xoa(ID);
                X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
                X.Msg.AddScript("#{stData}.reload();");
            }
            else
            {
                X.Msg.Alert("Thông báo", "Quy trình này đã có các hồ sơ liên quan, Bạn không thể xóa !!!", new JFunction { Fn = "" }).Show();
            }
        }
        else if (command == "Edit")
        {
            this.wdDetail.AutoLoad.Url = "~/HT/QuyTrinh/CapNhatQuyTrinhDinhNghia.aspx?id=" + ID;
            this.wdDetail.Icon = Icon.ApplicationEdit;
            this.wdDetail.Title = "Chỉnh sửa quy trình, thủ tục";
            this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
            this.wdDetail.Render(this.Form);
            this.wdDetail.Show();
        }
        else if (command == "Show")
        {
            this.wdDetail.AutoLoad.Url = "~/HT/QuyTrinh/LuongDinhNghia.aspx?id=" + ID;
            this.wdDetail.Icon = Icon.ApplicationEdit;
            this.wdDetail.Title = "Quy trình xử lý";
            this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
            this.wdDetail.Render(this.Form);
            this.wdDetail.Show();
        }
        else if (command == "CreateTheard")
        {
            DataTable dt = Sys_Common.NV_QuyTrinhXuLy.GetByQuyTrinh(ID);
            if (dt.Rows.Count == 0)
            {
                this.wdDetail.AutoLoad.Url = "~/HT/QuyTrinh/CapNhatLuongDinhNghia.aspx?id=" + ID;
                this.wdDetail.Icon = Icon.ApplicationEdit;
                this.wdDetail.Title = "Cập nhật quy trình xử lý";
                this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
                this.wdDetail.Render(this.Form);
                this.wdDetail.Show();
            }
            else
            {
                X.Msg.Alert("Thông báo", "Bạn chỉ có thể xem nhưng không thể sửa quy trình này !!!", new JFunction { Fn = "" }).Show();
            }
        }
    }
    private void ClearData()
    {
        btnUpdate.Text = "Thêm mới";
        btnUpdate.Icon = Icon.Add;

        hdID.Value = "";
        txtTen.Text = "";
        dtNgayHieuLuc.Value = "";
    }
}