using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLHS_Logic.NV;
using QLHS_Logic;
public partial class NghiepVu_XemBanTin : System.Web.UI.Page
{
    public NV_BaiViet_AnPham_ChiTiet bv = new NV_BaiViet_AnPham_ChiTiet();
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
            bv = Sys_Common.NV_BaiViet_AnPham.GetById(int.Parse(id));
        }
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        bv.Duyet = ckbDuyet.Checked;
        bv.NoiBat = ckbNoiBat.Checked;
        Sys_Common.NV_BaiViet_AnPham.Update(bv);
        X.Msg.AddScript("parent.hdMsg.setValue('" + ckbDuyet.Checked.ToString() + "');");
        X.Msg.AddScript("parentAutoLoadControl.hide();");
    }
}