using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using QLHS_Logic;
using QLHS_Logic.NV;
using Ext.Net.Examples;
using System.Reflection;
public partial class DSVH_Quanlydisan_Dangkycapdisan : System.Web.UI.Page
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

        }
    }
    protected void odsData_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        (this.stData.Proxy[0] as PageProxy).Total = (int)e.OutputParameters["Count"];
    }
    protected void stData_RefreshData(object sender, Ext.Net.StoreRefreshDataEventArgs e)
    {
        this.odsData.SelectParameters["Start"].DefaultValue = (e.Start + 1).ToString();
        this.odsData.SelectParameters["Limit"].DefaultValue = (e.Limit + e.Start).ToString();
        if (e.Parameters["Filter"] == "")
        {
            this.odsData.SelectParameters["WhereString"].DefaultValue = @"(select *,(select TenCap from DM_CapDiSan cds where cds.ID=dk.CapDiSan) as TenCapDiSan,
                                                                                    (select TenDiSan from DiSanVanHoa ds where ds.DiSanID=dk.DiSanID) as DiSan
                                                                                    from DangKyDiSan dk) as A";
        }
        else
        {
            this.odsData.SelectParameters["WhereString"].DefaultValue = @"(select *,(select TenCap from DM_CapDiSan cds where cds.ID=dk.CapDiSan) as TenCapDiSan,
                                                                                    (select TenDiSan from DiSanVanHoa ds where ds.DiSanID=dk.DiSanID) as DiSan
                                                                                    from DangKyDiSan dk WHERE  TenChucVu LIKE N'%" + e.Parameters["Filter"] + "%') as S";
        }
        this.odsData.SelectParameters["SortString"].DefaultValue = e.Sort + " " + e.Dir;

        this.odsData.DataBind();
    }

    protected void btnExport_Click(object sender, DirectEventArgs e) { }

    protected void btnDelete_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gvData.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            Sys_Common.NV_DangKyDiSan.Xoa(int.Parse(row.RecordID));
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
        X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
        X.Msg.AddScript("#{stData}.reload();");
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        this.wdDetail.AutoLoad.Url = "~/NghiepVu/Disanvanhoa/CapNhatDKDS.aspx";
        this.wdDetail.Icon = Icon.ApplicationEdit;
        this.wdDetail.Title = "Thêm mới đăng ký di sản";
        this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
        this.wdDetail.Render(this.Form);
        this.wdDetail.Show();
    }
    protected void gvData_DbClick(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gvData.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            this.wdDetail.AutoLoad.Url = "~/NghiepVu/Disanvanhoa/CapNhatDKDS.aspx?id=" + row.RecordID;
            this.wdDetail.Icon = Icon.ApplicationEdit;
            this.wdDetail.Title = "Cập nhật đăng ký di sản";
            this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
            this.wdDetail.Render(this.Form);
            this.wdDetail.Show();
            break;
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
    }

}