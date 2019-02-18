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

public partial class HT_QuyTrinh_CapNhatLuongDinhNghia : System.Web.UI.Page
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
        DataTable datasource = Sys_Common.NV_CoQuanHanhChinh.GetDataToCombo();
        DataRow dr = datasource.NewRow();
        dr["CoQuanID"] = 0;
        dr["TenCoQuan"] = "Chọn cơ quan quản lý";
        datasource.Rows.InsertAt(dr, 0);
        stCoquan.DataSource = datasource;

        string sql = "select (select Ma_Nguoi_Dung from HT_Nguoi_Dung nd where nd.CanBoID=cb.CanBoID) as CanBoID,HoTen,(select TenChucVu from ChucVu c where c.ChucVuID=cb.ChucVuID) as ChucVu from CanBo cb";
        DataTable dt = Sys_Common.RunTableBySQL(sql);
        stCanbo.DataSource = dt;
        DataBind();
    }
    protected void stCanbo_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {

        if (cbCoQuan.Value != null)
        {
            string sql = "select (select Ma_Nguoi_Dung from HT_Nguoi_Dung nd where nd.CanBoID=cb.CanBoID) as CanBoID,HoTen,(select TenChucVu from ChucVu c where c.ChucVuID=cb.ChucVuID) as ChucVu from CanBo cb where CoQuanID=" + this.cbCoQuan.Value.ToString();
            DataTable dt = Sys_Common.RunTableBySQL(sql);
            if (dt != null)
            {
                stCanbo.DataSource = dt;
                stCanbo.DataBind();
            }
            else
            {
                cbCanbo.GetStore().RemoveAll();
            }
        }
        else
        {
            X.Msg.AddScript("#{cbCanbo}.clearValue();");
        }
    }

    [DirectMethod]
    public bool CheckUser(int canboId)
    {

        string sql = "select * from HT_Nguoi_Dung where Ma_Nguoi_Dung=" + cbCanbo.Value.ToString();
        DataTable dt = Sys_Common.RunTableBySQL(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            return true;
        }
        else
        {
             return false;
        }
    }
    [DirectMethod]
    public List<NV_LuongDinhNghia_ChiTiet> Check(int idQT)
    {
        List<NV_LuongDinhNghia_ChiTiet> lst = Sys_Common.NV_LuongDinhNghia.GetByQT(idQT);
        return lst;
    }
    [DirectMethod]
    public void Update(List<NV_LuongDinhNghia_ChiTiet> lst)
    {
        string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
        int idQuyTrinh = int.Parse(id);
        bool check = true;
        foreach (var item in lst)
        {
            item.IDQuyTrinh = idQuyTrinh;
            if (item.ID == 0)
            {
                check = Sys_Common.NV_LuongDinhNghia.them(item);
            }
            else
            {
                check = Sys_Common.NV_LuongDinhNghia.update(item);
            }
            if (!check)
            {
                break;
            }
        }
        if (check == true)
        {
            X.Msg.AddScript("parent.hdMsg.setValue('ok');");
            X.Msg.AddScript("parentAutoLoadControl.hide();");
        }
        else
        {
            X.Msg.Alert("Thông báo", "Đã có lỗi sảy ra...Xin thử lại", new JFunction { Fn = "" }).Show();
        }
    }
}