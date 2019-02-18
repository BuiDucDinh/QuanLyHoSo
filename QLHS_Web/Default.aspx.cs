using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Ext.Net;
using QLHS_Logic;
using System.Collections.Generic;
public partial class _Default : System.Web.UI.Page
{
    public string InnerString = "";
    private HT_Nguoi_Dung_Chi_Tiet nguoi_Dung_Chi_Tiet;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Session["G_Theme"] != null)
            {
                DHM_Common.SetTheme(this.Page, int.Parse(Session["G_Theme"].ToString()));
            }
            if (Session["G_Ma_Nguoi_Dung"] != null)
            {
                nguoi_Dung_Chi_Tiet = Sys_Common.HT_NGUOI_DUNG.Lay(int.Parse(Session["G_Ma_Nguoi_Dung"].ToString()));
                btnUserOnline.Text = nguoi_Dung_Chi_Tiet.Ten_Dang_Nhap;
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

            //Load danh sách Menu Branch
            if (Session["G_Ma_Nguoi_Dung"] != null && Session["G_Ma_Nguoi_Dung"].ToString() != "")
            {
            }
            LoadMenuContent();
            //Label1.Html = "CÔNG TY TNHH TM VÀ PHÁT TRIỂN CÔNG NGHỆ PHẦN MỀM TCSOFT - PHẦN MỀM: " + Sys_Common.HT_DU_AN.Lay(Session["G_Ma_Du_An"].ToString()).Ten_Du_An.ToUpper();
            Label1.Html = "CÔNG TY TNHH TM VÀ PHÁT TRIỂN CÔNG NGHỆ PHẦN MỀM TCSOFT - PHẦN MỀM: " + Sys_Common.HT_DU_AN.Lay(Session["G_Ma_Du_An"].ToString()).Ten_Du_An.ToUpper() + " - " + Sys_Common.HT_DON_VI_YT.Lay(int.Parse(Session["G_Ma_Don_Vi"].ToString())).Ten_Don_Vi.ToUpper();
        }
    }

    [DirectMethod]
    public void btnDefault_Click(object sender, DirectEventArgs e)
    {
        if (Session["G_Ma_Nguoi_Dung"] != null)
        {
            HT_Nguoi_Dung_Chi_Tiet myNguoiDung;
            myNguoiDung = Sys_Common.HT_NGUOI_DUNG.Lay(int.Parse(Session["G_Ma_Nguoi_Dung"].ToString()));
            myNguoiDung.Hinh_Nen = 1;
            Sys_Common.HT_NGUOI_DUNG.Cap_Nhat(myNguoiDung);
            Session["G_Theme"] = "1";
            if (Session["G_Theme"] != null)
            {
                DHM_Common.SetTheme(this.Page, 1);
            }
        }
    }
    public void btnSlate_Click(object sender, DirectEventArgs e)
    {
        if (Session["G_Ma_Nguoi_Dung"] != null)
        {
            HT_Nguoi_Dung_Chi_Tiet myNguoiDung;
            myNguoiDung = Sys_Common.HT_NGUOI_DUNG.Lay(int.Parse(Session["G_Ma_Nguoi_Dung"].ToString()));
            myNguoiDung.Hinh_Nen = 3;
            Sys_Common.HT_NGUOI_DUNG.Cap_Nhat(myNguoiDung);
            Session["G_Theme"] = "3";
            if (Session["G_Theme"] != null)
            {
                DHM_Common.SetTheme(this.Page, 3);
            }
        }
    }
    public void btnGray_Click(object sender, DirectEventArgs e)
    {
        if (Session["G_Ma_Nguoi_Dung"] != null)
        {
            HT_Nguoi_Dung_Chi_Tiet myNguoiDung;
            myNguoiDung = Sys_Common.HT_NGUOI_DUNG.Lay(int.Parse(Session["G_Ma_Nguoi_Dung"].ToString()));
            myNguoiDung.Hinh_Nen = 2;
            Sys_Common.HT_NGUOI_DUNG.Cap_Nhat(myNguoiDung);
            Session["G_Theme"] = "2";
            if (Session["G_Theme"] != null)
            {
                DHM_Common.SetTheme(this.Page, 2);
            }
        }
    }
    public void btnAccess_Click(object sender, DirectEventArgs e)
    {
        if (Session["G_Ma_Nguoi_Dung"] != null)
        {
            HT_Nguoi_Dung_Chi_Tiet myNguoiDung;
            myNguoiDung = Sys_Common.HT_NGUOI_DUNG.Lay(int.Parse(Session["G_Ma_Nguoi_Dung"].ToString()));
            myNguoiDung.Hinh_Nen = 4;
            Sys_Common.HT_NGUOI_DUNG.Cap_Nhat(myNguoiDung);
            Session["G_Theme"] = "4";
            if (Session["G_Theme"] != null)
            {
                DHM_Common.SetTheme(this.Page, 4);
            }
        }
    }
    public void btnLogout_Click(object sender, DirectEventArgs e)
    {
        Sys_Common.HT_NGUOI_DUNG_DANG_NHAP.Them(0, int.Parse(Session["G_Ma_Nguoi_Dung"].ToString()), DateTime.Now, "OUT");
        Session.Clear();
        Session.Abandon();
        Response.Redirect("Login.aspx");
    }
    public void UserConfigWindow_Show(object sender, DirectEventArgs e)
    {
        this.winHT_Don_Vi_YT.AutoLoad.Url = "~/HT/HT_NguoiDungCapNhat.aspx?id=" + Guid.NewGuid().ToString();
        this.winHT_Don_Vi_YT.AutoLoad.Mode = LoadMode.IFrame;
        this.winHT_Don_Vi_YT.Render(this.Form);
        this.winHT_Don_Vi_YT.Show();
    }

    [DirectMethod]

    public void CalByItems(string ID)
    {
        //Session["G_Ma_Chuc_Nang"] = ID;
    }
    public void LoadMenuContent()
    {
        AccordionLayout1.Items.Clear();
        if (Session["G_Ma_Nguoi_Dung"] != null)
        {
            HashSet<string> setChuc_Nang = new HashSet<string>();
            HashSet<string> setNhom_Chuc_Nang = new HashSet<string>();
            Dictionary<string, Ext.Net.MenuPanel> dicMP = new Dictionary<string, Ext.Net.MenuPanel>();

            //Lay danh sach ma vai tro cua nguoi dung
            DataTable lstNguoi_Dung_Vai_Tro = Sys_Common.HT_NGUOI_DUNG_VAI_TRO.Lay_Boi_HT_Nguoi_Dung(int.Parse(Session["G_Ma_Nguoi_Dung"].ToString()));

            //Lay danh sach ma chuc nang theo vai tro va du an
            for (int i = 0; i < lstNguoi_Dung_Vai_Tro.Rows.Count; i++)
            {
                DataTable lstChuc_Nang = Sys_Common.HT_VAI_TRO_CHUC_NANG.HT_Vai_Tro_Chuc_Nang_Lay_Boi_HT_Vai_Tro_Du_An(int.Parse(lstNguoi_Dung_Vai_Tro.Rows[i]["Ma_Vai_Tro"].ToString()), Session["G_Ma_Du_An"].ToString());
                for (int j = 0; j < lstChuc_Nang.Rows.Count; j++)
                {
                    if (bool.Parse(lstChuc_Nang.Rows[j]["Duoc_Truy_Cap"].ToString()))
                    {
                        setChuc_Nang.Add(lstChuc_Nang.Rows[j]["Ma_Chuc_Nang"].ToString());
                    }
                }
            }
            Dictionary<string, Ext.Net.Icon> dicIcons = new Dictionary<string, Ext.Net.Icon>();
            List<string> icons = Enum.GetNames(typeof(Icon)).ToList<string>();
            icons.Remove("None");
            icons.ForEach(icon => dicIcons.Add(icon, (Icon)Enum.Parse(typeof(Icon), icon)));

            //Lay thong tin danh sach chuc nang
            HT_Chuc_Nang_Chi_Tiet chuc_Nang;
            Ext.Net.MenuPanel mpTemp;
            ToolTip tt;
            Ext.Net.MenuItem miTemp;
            HT_Nhom_Chuc_Nang_Chi_Tiet nhom_Chuc_Nang;
            foreach (string item in setChuc_Nang)
            {
                chuc_Nang = Sys_Common.HT_CHUC_NANG.Lay(item);
                miTemp = new Ext.Net.MenuItem
                {
                    ID = "mi" + chuc_Nang.Ma_Chuc_Nang,
                    Text = chuc_Nang.Ten_Chuc_Nang,
                    Icon = dicIcons[chuc_Nang.Icon],
                    Visible = true
                };
                if (chuc_Nang.Duong_Dan.Contains("?"))
                {
                    miTemp.CustomConfig.Add(new ConfigItem { Name = "url", Value = chuc_Nang.Duong_Dan + "&cn=" + chuc_Nang.Ma_Chuc_Nang, Mode = ParameterMode.Value });
                }
                else
                {
                    miTemp.CustomConfig.Add(new ConfigItem { Name = "url", Value = chuc_Nang.Duong_Dan + "?cn=" + chuc_Nang.Ma_Chuc_Nang, Mode = ParameterMode.Value });
                }
                tt = new ToolTip();
                tt.Title = chuc_Nang.Ten_Chuc_Nang;
                miTemp.ToolTips.Add(tt);
                miTemp.Listeners.Click.Handler = "Ext.net.DirectMethods.CalByItems('" + chuc_Nang.Ma_Chuc_Nang + "');";
                if (dicMP.TryGetValue(chuc_Nang.Ma_Nhom_Chuc_Nang, out mpTemp))
                {
                    mpTemp.Menu.Items.Add(miTemp);
                    dicMP[chuc_Nang.Ma_Nhom_Chuc_Nang] = mpTemp;
                }
                else
                {
                    nhom_Chuc_Nang = Sys_Common.HT_NHOM_CHUC_NANG.Lay(chuc_Nang.Ma_Nhom_Chuc_Nang);
                    mpTemp = new Ext.Net.MenuPanel { ID = "mp" + nhom_Chuc_Nang.Ma_Nhom_Chuc_Nang, Border = false, SaveSelection = true, Collapsed = true, Title = nhom_Chuc_Nang.Ten_Nhom_Chuc_Nang, Visible = true };
                    //mpTemp.Menu.Listeners.ItemClick.Handler = "var tp = Ext.getCmp('tpMain');tp.closeTab('Tab1'); tp.addTab({ id:'Tab1', title: menuItem.text, url: menuItem.url, icon: menuItem.iconCls });";
                    mpTemp.Menu.Listeners.ItemClick.Handler = "DHM.addTab({ title: menuItem.text, url: menuItem.url, icon: menuItem.iconCls });";
                    mpTemp.Menu.Items.Add(miTemp);
                    dicMP.Add(chuc_Nang.Ma_Nhom_Chuc_Nang, mpTemp);
                }
            }

            foreach (KeyValuePair<string, MenuPanel> pair in dicMP)
            {
                AccordionLayout1.Items.Add(pair.Value);
            }
        }
    }
}
