using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
public partial class NghiepVu_Thongke_BaoCao : System.Web.UI.Page
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
        if (Session["G_Theme"] != null)
        {
            DHM_Common.SetTheme(this.Page, int.Parse(Session["G_Theme"].ToString()));
        }
        if (!IsPostBack)
        {
            string type = Request.QueryString["type"].ToString();
            string url = "/NghiepVu/ThongKe/KiemKeSoLuong.aspx?type=" + type;
            LoadPage(url);
        }
    }
    private void Initialization()
    {
        int count = DateTime.Now.Year - 2010;
        object[] year = new object[count];
        int j = 0;
        for (int i = DateTime.Now.Year; i > 2010; i--)
        {
            year[j] = new object[] { i };
            j++;
        }
        stNam.DataSource = year;
        stNam.DataBind();
    }
    protected void btnTimkiem_Click(object sender, DirectEventArgs e)
    {
        string nam = cbNam.Value.ToString();
        string type = Request.QueryString["type"].ToString();
        string url = "/NghiepVu/ThongKe/KiemKeSoLuong.aspx?type=" + type + "&nam=" + nam;
        LoadPage(url);
    }
    protected void LoadPage(string url)
    {
        Initialization();
        this.plnTemplate.AutoLoad.Url = url;
        this.plnTemplate.AutoLoad.Mode = LoadMode.IFrame;
        this.plnTemplate.Render(this.Form);


        //LoadConfig loadConfig = new LoadConfig();
        //loadConfig.Mode = LoadMode.IFrame;
        //loadConfig.ShowMask = true;
        //loadConfig.Url = url;
        //this.plnTemplate.LoadContent(loadConfig);
    }
}