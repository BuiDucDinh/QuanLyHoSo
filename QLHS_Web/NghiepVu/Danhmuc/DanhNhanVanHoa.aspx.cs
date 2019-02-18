using Ext.Net;
using Models;
using QLHS_Logic;
using QLHS_Logic.NV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Xsl;

public partial class NghiepVu_Danhmuc_DanhNhanVanHoa : System.Web.UI.Page
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
            this.odsData.SelectParameters["WhereString"].DefaultValue = "(select * from DanhNhan) as A";
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
                int id = int.Parse(row.RecordID);
                NV_DanhNhan_ChiTiet myDetail = Sys_Common.NV_DanhNhan.GetById(id);  //Sys_Common.NL_DM_BIEN_CHE.Lay(int.Parse(row.RecordID));
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

    private void SetData(NV_DanhNhan_ChiTiet model)
    {
        btnUpdate.Text = "Cập nhật";
        btnUpdate.Icon = Icon.ApplicationEdit;
        hdID.Text = model.DanhNhanID.ToString();
        txtTenDanhNhan.Text = model.TenDanhNhan;
        txtMota.Text = model.MoTa;
        txtStt.Text = model.Stt.ToString();
        txtThoidai.Text = model.Thoidai;
    }
    protected void btnExport_Click(object sender, DirectEventArgs e)
    {
        Role role = getRole();
        if (role.Duoc_Xuat)
        {
            string json = e.ExtraParams["data"].ToString();
            StoreSubmitDataEventArgs eSubmit = new StoreSubmitDataEventArgs(json, null);
            XmlNode xml = eSubmit.Xml;

            this.Response.Clear();
            this.Response.ContentType = "application/vnd.ms-excel";
            this.Response.AddHeader("Content-Disposition", "attachment; filename=submittedData.xls");
            XslCompiledTransform xtExcel = new XslCompiledTransform();
            xtExcel.Load(Server.MapPath("/NghiepVu/Resources/Excel.xsl"));
            xtExcel.Transform(xml, null, this.Response.OutputStream);
            this.Response.End();
            NV_Log_ChiTiet log = createLog(0, "export");
            Sys_Common.NV_Log.them(log);
        }
        else
        {
            X.Msg.Alert("Thông báo", "Bạn không có quyền sửa bản ghi !!!", new JFunction { Fn = "" }).Show();
        }
    }
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
                int id = int.Parse(row.RecordID);
                Sys_Common.NV_DanhNhan.Xoa(id);
                NV_Log_ChiTiet log = createLog(id, "delete");
                Sys_Common.NV_Log.them(log);
            }
            sm.SelectedRows.Clear();
            sm.UpdateSelection();
            X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
            X.Msg.AddScript("#{stData}.reload();");
        }
        else
        {
            X.Msg.Alert("Thông báo", "Bạn không có quyền xóa bản ghi !!!", new JFunction { Fn = "" }).Show();
        }
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
            NV_DanhNhan_ChiTiet model = new NV_DanhNhan_ChiTiet();
            model.TenDanhNhan = txtTenDanhNhan.Text;
            try
            {
                model.Stt = int.Parse(txtStt.Text);
            }
            catch { model.Stt = 1; }
            model.MoTa = txtMota.Text;
            model.Thoidai = txtThoidai.Text;
            model.Url = StringUtil.RemoveSign4VietnameseString(txtTenDanhNhan.Text).Replace(' ', '-');

            bool check;
            NV_Log_ChiTiet log;
            if (hdID.Text != "")
            {
                model.DanhNhanID = int.Parse(hdID.Text);
                check = Sys_Common.NV_DanhNhan.update(model);
                log = createLog(model.DanhNhanID, "update");
            }
            else
            {
                int id = 0;
                check = Sys_Common.NV_DanhNhan.them(model, out id);
                log = createLog(id, "insert");
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
        if (string.IsNullOrEmpty(txtTenDanhNhan.Text.Trim()))
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
        txtTenDanhNhan.Text = "";
        txtStt.Text = "1";
        txtMota.Text = "";
        txtThoidai.Text = "";
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