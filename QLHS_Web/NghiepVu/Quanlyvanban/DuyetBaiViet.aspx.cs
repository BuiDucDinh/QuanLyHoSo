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
public partial class DSVH_Quanlyvanban_Capnhatvanban : System.Web.UI.Page
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
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            if (!string.IsNullOrEmpty(id))
            {
                NV_BaiViet_AnPham_ChiTiet bv = Sys_Common.NV_BaiViet_AnPham.GetById(int.Parse(id));
                ckbDuyet.Checked = bv.Duyet;
                ckbNoiBat.Checked = bv.NoiBat;
                txtTieude.Text = bv.TieuDe;
            }
        }
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
        if (!string.IsNullOrEmpty(id))
        {
            NV_BaiViet_AnPham_ChiTiet bv = Sys_Common.NV_BaiViet_AnPham.GetById(int.Parse(id));
            if (ckbDuyet.Checked != bv.Duyet)
            {
                bv.Duyet = ckbDuyet.Checked;
                bv.NoiBat = ckbNoiBat.Checked;
                bool check = Sys_Common.NV_BaiViet_AnPham.Update(bv);
                if (check)
                {
                    string thaotac = ckbDuyet.Checked ? "active" : "unactive";
                    NV_Log_ChiTiet log = createLog(bv.ID, thaotac);
                    Sys_Common.NV_Log.them(log);
                    X.Msg.AddScript("parent.hdMsg.setValue('ok');");
                    X.Msg.AddScript("parentAutoLoadControl.hide();");
                }
                else
                {
                    X.Msg.Alert("Thông báo", "Đã có lỗi sảy ra...Xin thử lại", new JFunction { Fn = "" }).Show();
                }
            }
        }
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