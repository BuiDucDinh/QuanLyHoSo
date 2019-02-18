using Ext.Net;
using QLHS_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NghiepVu_QuyTrinh_Congvieccanxuly : System.Web.UI.Page
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
            Initialization();
        }
    }
    private void Initialization()
    {
        stTrangthai.DataSource = Sys_Common.NV_TrangThaiXuLy.GetAll();
        stLoaiQuyTrinh.DataSource = Sys_Common.NV_LoaiQuyTrinh.GetAll();
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
        string sql = @"select*,(case when Conlai<0 then N'Đã hết hạn '+ CAST(abs(Conlai) as nvarchar(100))+N' ngày'
                    else N'Còn lại '+ CAST(Conlai as nvarchar(100))+N' ngày' end) as ThongBao from (
                    select xl.ID, dn.Ten,dn.MoTa,ThoiGianHT,dn.Stt,xl.NgayXuLy,xl.TrangThai,lqt.TenLoai,
                    Conlai=-DATEDIFF(dd,dateadd(dd,thoigianht,ngayxuly),getdate())
                        from LuongDinhNghia dn join LuongXuLy xl on dn.ID=xl.IDLuong 
                            join QuyTrinhDinhNghia qtdn on qtdn.ID=dn.IDQuyTrinh 
                            join LoaiQuyTrinh lqt on lqt.ID=qtdn.LoaiQuyTrinh
                        where xl.TrangThai<>2 and xl.NguoiXuLy=" + Session["G_Ma_Nguoi_Dung"].ToString();
        int trangthai, loaiqt;
        try
        {
            trangthai = int.Parse(cbTrangThai.Value.ToString());
        }
        catch { trangthai = 0; }
        if (trangthai != 0)
        {
            sql += " and xl.TrangThai=" + trangthai;
        }
        try
        {
            loaiqt = int.Parse(cbLoaiQuyTrinh.Value.ToString());
        }
        catch { loaiqt = 0; }
        if (loaiqt != 0)
        {
            sql += " and lqt.ID=" + loaiqt;
        }
        if (!string.IsNullOrEmpty(txtTen.Text))
        {
            sql += " and dn.Ten like '%" + txtTen.Text + "%'";
        }
        sql += ") as tb";
        this.odsData.SelectParameters["WhereString"].DefaultValue = @"(" + sql + ") as A";
        this.odsData.SelectParameters["SortString"].DefaultValue = e.Sort + " " + e.Dir;
        this.odsData.DataBind();
    }
    protected void gvData_DbClick(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gvData.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            this.wdDetail.AutoLoad.Url = "~/Nghiepvu/QuyTrinh/TiepNhanHoSo.aspx?id=" + row.RecordID;
            this.wdDetail.Icon = Icon.ApplicationEdit;
            this.wdDetail.Title = "Tiếp nhận yêu cầu xử lý";
            this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
            this.wdDetail.Render(this.Form);
            this.wdDetail.Show();
            break;
        }
    }
    [DirectMethod]
    public void Command(string command, string value, string trangthai)
    {
        int ID = int.Parse(value);
        int Trangthai = int.Parse(trangthai);
        if (command == "Cancel" && Trangthai == 1)
        {
            Sys_Common.NV_LuongXuLy.Cancel(ID);
            X.Msg.Alert("Thông báo", "Đã hủy hồ sơ thành công !!!", new JFunction { Fn = "" }).Show();
            X.Msg.AddScript("#{stData}.reload();");
        }
        else if (command == "Show")
        {
            this.wdDetail.AutoLoad.Url = "~/Nghiepvu/QuyTrinh/TiepNhanHoSo.aspx?id=" + ID;
            this.wdDetail.Icon = Icon.ApplicationEdit;
            this.wdDetail.Title = "Tiếp nhận yêu cầu xử lý";
            this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
            this.wdDetail.Render(this.Form);
            this.wdDetail.Show();
        }
        else if (command == "ShowInfo")
        {
            NV_LuongXuLy_ChiTiet model = Sys_Common.NV_LuongXuLy.GetById(ID);
            this.wdDetail.AutoLoad.Url = "~/Nghiepvu/QuyTrinh/ThongTinHoSo.aspx?id=" + model.IDQTCuThe;
            this.wdDetail.Icon = Icon.ApplicationEdit;
            this.wdDetail.Title = "Thông tin về hồ sơ";
            this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
            this.wdDetail.Render(this.Form);
            this.wdDetail.Show();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        X.Msg.AddScript("#{stData}.reload();");
    }
}