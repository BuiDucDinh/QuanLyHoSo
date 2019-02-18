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
        if (!this.IsPostBack)
            if (Session["G_Theme"] != null)
            {
                DHM_Common.SetTheme(this.Page, int.Parse(Session["G_Theme"].ToString()));
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
            this.odsData.SelectParameters["WhereString"].DefaultValue = "(select ID,TenLinhVuc,Stt from DM_LinhVucKinhDoanh) as A";
        }
        else
        {
            this.odsData.SelectParameters["WhereString"].DefaultValue = "(select ID,TenLinhVuc,Stt from DM_LinhVucKinhDoanh WHERE TenLinhVuc LIKE N'%" + e.Parameters["Filter"] + "%') as S";
        }
        this.odsData.SelectParameters["SortString"].DefaultValue = e.Sort + " " + e.Dir;

        this.odsData.DataBind();

    }
    protected void gvData_DbClick(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gvData.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            NV_DM_LinhVucKinhDoanh_ChiTiet myDetail = Sys_Common.NV_DM_LinhVucKinhDoanh.GetById(int.Parse(row.RecordID));  //Sys_Common.NL_DM_BIEN_CHE.Lay(int.Parse(row.RecordID));
            SetData(myDetail);
            break;
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
    }

    private void SetData(NV_DM_LinhVucKinhDoanh_ChiTiet myDetail)
    {
        btnUpdate.Text = "Cập nhật";
        btnUpdate.Icon = Icon.ApplicationEdit;
        txtTenLinhVuc.Value = myDetail.TenLinhVuc;
        txtStt.Text = myDetail.Stt.ToString();
        hdID.Text = myDetail.ID.ToString();
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
            Sys_Common.NV_DM_LinhVucKinhDoanh.Xoa(int.Parse(row.RecordID));
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
            NV_DM_LinhVucKinhDoanh_ChiTiet model = new NV_DM_LinhVucKinhDoanh_ChiTiet();
            model.TenLinhVuc = txtTenLinhVuc.Text;
            try
            {
                model.Stt = int.Parse(txtStt.Text);
            }
            catch
            {
                model.Stt = 1;
            }
            if (hdID.Text != "")
            {
                model.ID = int.Parse(hdID.Text);
                Sys_Common.NV_DM_LinhVucKinhDoanh.update(model);
            }
            else
            {
                Sys_Common.NV_DM_LinhVucKinhDoanh.them(model);
            }
            ClearData();
            X.Msg.Alert("Thông báo", "Đã cập nhật thành công !!!", new JFunction { Fn = "" }).Show();
            X.Msg.AddScript("#{stData}.reload();");
        }
    }
    private bool FormValidate()
    {
        if (string.IsNullOrEmpty(txtTenLinhVuc.Text.Trim()))
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
        txtTenLinhVuc.Value = "";
        txtStt.Value = "";

    }
}