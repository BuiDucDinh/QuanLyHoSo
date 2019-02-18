using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLHS_Logic;
using System.Data;
using QLHS_Logic.NV;
using Models;
using System.Web.Script.Serialization;
public partial class NghiepVu_Danhmuc_ChucVu : System.Web.UI.Page
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
                //Initialization();
            }
            Role role = getRole();
            hdRole.Value = new JavaScriptSerializer().Serialize(role);
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
            this.odsData.SelectParameters["WhereString"].DefaultValue = "(select * from DanhMucAnPham) as A";
        }
        else
        {
            this.odsData.SelectParameters["WhereString"].DefaultValue = "(select * from DanhMucAnPham  WHERE  TenDanhMuc LIKE N'%" + e.Parameters["Filter"] + "%') as S";
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
                NV_DanhMucAnPham_ChiTiet myDetail = Sys_Common.NV_DanhMucAnPham.GetById(int.Parse(row.RecordID));  //Sys_Common.NL_DM_BIEN_CHE.Lay(int.Parse(row.RecordID));
                SetData(myDetail);
                break;
            }
            sm.SelectedRows.Clear();
            sm.UpdateSelection();
        }
        else
        {
            X.Msg.Alert("Thông báo", "Bạn không có quyền sửa bản ghi !!!", new JFunction { Fn = "" }).Show();
        }
    }

    private void SetData(NV_DanhMucAnPham_ChiTiet myDetail)
    {
        btnUpdate.Text = "Cập nhật";
        btnUpdate.Icon = Icon.ApplicationEdit;
        txtTendanhmuc.Value = myDetail.TenDanhMuc;
        hdID.Text = myDetail.DanhMucID.ToString();
    }
    protected void btnCancel_Click(object sender, DirectEventArgs e)
    {
        ClearData();
    }
    protected void btnDelete_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gvData.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            int id = int.Parse(row.RecordID);
            Sys_Common.NV_DanhMucAnPham.Xoa(id);
            NV_Log_ChiTiet log = createLog(id, "delete");
            Sys_Common.NV_Log.them(log);
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
        X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
        X.Msg.AddScript("#{stData}.reload();");
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        Role role = getRole();
        if (hdID.Text != "" && !role.Duoc_Sua)
        {
            X.Msg.Alert("Thông báo", "Bạn không có quyền sửa bản ghi !!!", new JFunction { Fn = "" }).Show();
            return;
        }
        if (string.IsNullOrEmpty(hdID.Text) && !role.Duoc_Nhap)
        {
            X.Msg.Alert("Thông báo", "Bạn không có quyền thêm bản ghi !!!", new JFunction { Fn = "" }).Show();
            return;
        }
        if (FormValidate())
        {
            NV_DanhMucAnPham_ChiTiet model = new NV_DanhMucAnPham_ChiTiet();
            model.TenDanhMuc = txtTendanhmuc.Text;
            model.Url = StringUtil.RemoveSign4VietnameseString(model.TenDanhMuc).Replace(" ", "-");

            bool check;
            NV_Log_ChiTiet log;
            if (hdID.Text != "")
            {
                model.DanhMucID = int.Parse(hdID.Text);
                check=Sys_Common.NV_DanhMucAnPham.update(model);
                log = createLog(model.DanhMucID, "update");
            }
            else
            {
                int id = 0;
                check = Sys_Common.NV_DanhMucAnPham.them(model,out id);
                log = createLog(id, "update");
            }
            if (check)
            {
                Sys_Common.NV_Log.them(log);
                ClearData();
                X.Msg.Alert("Thông báo", "Đã cập nhật thành công !!!", new JFunction { Fn = "" }).Show();
                X.Msg.AddScript("#{stData}.reload();");
            }
        }
    }
    private bool FormValidate()
    {
        if (string.IsNullOrEmpty(txtTendanhmuc.Text.Trim()))
        {
            X.Msg.Alert("Thông báo", "Thiếu thông tin ", new JFunction { Fn = "" }).Show();
            return false;
        }
        return true;
    }
    private void ClearData()
    {
        btnUpdate.Text = "Thêm mới";
        btnUpdate.Icon = Icon.Add;
        hdID.Value = "";
        txtTendanhmuc.Value = "";

    }
    private Role getRole()
    {
        string maForm = Request.QueryString["cn"].ToString();
        int maND = int.Parse(Session["G_Ma_Nguoi_Dung"].ToString());
        Role role = Sys_Common.HT_NGUOI_DUNG_VAI_TRO.getRoleUserByForm(maND, maForm);
        return role;
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