using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLHS_Logic;
using System.Data;
using QLHS_Logic.NV;
using Ext.Net.Examples;

public partial class Template_Controls_RightContent : BaseUserControl
{
    public string DiSanID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtTen.Attributes.Add("onkeypress", "return clickButton(event,'" + btnLogin.ClientID + "')");
            txtPassword.Attributes.Add("onkeypress", "return clickButton(event,'" + btnLogin.ClientID + "')");
            loadData();
        }
    }
    private void loadData()
    {
        DataTable dt = Sys_Common.NV_DM_DiSan.GetAll(GetLang());
        string sql = "";
        if (dt != null && dt.Rows.Count > 0)
        {
            rptDanhmuc.DataSource = dt;
            rptDanhmuc.DataBind();
        }
        dt = Sys_Common.NV_DM_LoaiDiSan.getDataCombo();
        if (dt != null && dt.Rows.Count > 0)
        {
            rptLoaiDS.DataSource = dt;
            rptLoaiDS.DataBind();
        }
        rptAnPham.DataSource = Sys_Common.NV_DanhMucAnPham.GetAll();
        rptAnPham.DataBind();

        sql = "select (select TenAnh from Image i where i.ImageID=q.ImageID) as Image,Link,Description,Target,IsImage from Quangcao q where Duyet=1 and Type=4";
        dt = Sys_Common.getDataByQuery(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            rptAdv.DataSource = dt;
            rptAdv.DataBind();
        }

        sql = "select (select TenAnh from Image i where i.ImageID=q.ImageID) as Image,Link,Description,Target,IsImage from Quangcao q where Duyet=1 and Type=5";
        dt = Sys_Common.getDataByQuery(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            rptAdvLink.DataSource = dt;
            rptAdvLink.DataBind();
        }

        sql = "select ID,TieuDe,NgayXuatBan,dbo.getUrl(ID,'BaiViet_AnPham',null) as url from BaiViet_AnPham bv where Duyet=1 and NoiBat=1 order by Stt";
        dt = Sys_Common.getDataByQuery(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            rptTintuc.DataSource = dt;
            rptTintuc.DataBind();
        }
        sql = "select (select TenAnh from Image i where i.ImageID=q.ImageID) as Image,Link,Description,Target,IsImage from Quangcao q where Duyet=1 and Type=8";
        dt = Sys_Common.getDataByQuery(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            rptVideoAdv.DataSource = dt;
            rptVideoAdv.DataBind();
        }
        if (!string.IsNullOrEmpty(DiSanID))
        {
            if (!string.IsNullOrEmpty(DiSanID))
            {
                sql = @"select top 1 FileUpload as Video,(select tenAnh from Image i where i.ImageID=v.ImageID) as HinhAnh,'/video-vd?ds=" + DiSanID + @"' as Link
                        from Video v where (select Video from DiSanVanHoa where DiSanID=" + DiSanID + ") like '%,'+cast(v.VideoID as nvarchar(10))+',%'";
                dt = Sys_Common.getDataByQuery(sql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    rptVideo.DataSource = dt;
                    rptVideo.DataBind();
                }

                sql = @"select [MediaLibID],[TenMediaLib],[MoTa],(select TenAnh from Image i where i.ImageID=m.HinhAnh) as [HinhAnh],[NgayTao]
                      ,dbo.getUrl(MediaLibID,'MediaLib',null) as [Url]
                    from MediaLib m where TypeMedia=1 and Duyet=1 and DiSanID=" + DiSanID;
                dt = Sys_Common.getDataByQuery(sql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    rptImageLib.DataSource = dt;
                    rptImageLib.DataBind();
                }
            }
        }
    }

    #region login
    public void CheckLogin()
    {
        HT_Nguoi_Dung_Chi_Tiet nguoi_Dung_Chi_Tiet;
        nguoi_Dung_Chi_Tiet = Sys_Common.HT_NGUOI_DUNG.Lay_Boi_Mat_Khau(txtTen.Text, Sys_Common.Encrypt(txtPassword.Text, Sys_Common.Key));
        if (nguoi_Dung_Chi_Tiet.Ma_Nguoi_Dung == 0)
        {
            ltrThongbao.Text = "Tên đăng nhập và mật khẩu không đúng !!!";
        }
        else
        {
            if (!nguoi_Dung_Chi_Tiet.Duoc_Kich_Hoat)
            {
                ltrThongbao.Text = "Người dùng này không có hiệu lực !!!";
                return;
            }
            Session["G_Ma_Nguoi_Dung"] = nguoi_Dung_Chi_Tiet.Ma_Nguoi_Dung.ToString();
            Session["G_Ten_Nguoi_Dung"] = nguoi_Dung_Chi_Tiet.Ten_Dang_Nhap.ToString().ToUpper();
            Session["G_Theme"] = nguoi_Dung_Chi_Tiet.Hinh_Nen.ToString();
            //Session["G_Ma_Du_An"] = cboDu_An.Value.ToString();
            Session["G_Ma_Don_Vi"] = nguoi_Dung_Chi_Tiet.Ma_Don_Vi;

            //Lấy thông tin Tuyến, Loại hình,Tên đơn vị
            HT_Don_Vi_YT_Chi_Tiet myDon_Vi = Sys_Common.HT_DON_VI_YT.Lay(nguoi_Dung_Chi_Tiet.Ma_Don_Vi);
            Session["G_Ma_Tuyen"] = myDon_Vi.Tuyen;
            Session["G_Tuyen"] = myDon_Vi.Tuyen;

            Session["G_Ma_Tinh"] = myDon_Vi.Ma_Tinh;
            Session["G_Ma_Huyen"] = myDon_Vi.Ma_Huyen;
            Session["G_Ma_Xa"] = myDon_Vi.Ma_Xa;
            Session["G_Ma_Loai_Hinh"] = myDon_Vi.Loai_Hinh;
            Session["G_Loai_Hinh"] = myDon_Vi.Loai_Hinh;
            Session["G_Thanh_Phan"] = myDon_Vi.Thanh_Phan;

            //nguoi_Dung_Chi_Tiet.Ten_Dang_Nhap = nguoi_Dung_Chi_Tiet.Ten_Dang_Nhap.ToUpper();
            //Sys_Common.HT_NGUOI_DUNG.Cap_Nhat(nguoi_Dung_Chi_Tiet);

            Session["GIsLogin"] = "OK";
            Sys_Common.HT_NGUOI_DUNG_DANG_NHAP.Them(0, nguoi_Dung_Chi_Tiet.Ma_Nguoi_Dung, DateTime.Now, "LG");
            //Response.Redirect("Default.aspx");
            DataTable myTable = Sys_Common.RunTableBySQL("SELECT Ma_Du_An, Ten_Du_An, Icon FROM HT_Du_An WHERE Ma_Du_An IN (SELECT Ma_Du_An FROM HT_Vai_Tro_Du_An WHERE Ma_Vai_Tro IN (SELECT Ma_Vai_Tro FROM HT_Nguoi_Dung_Vai_Tro WHERE Ma_Nguoi_Dung = " + Session["G_Ma_Nguoi_Dung"].ToString() + ")) UNION SELECT 'XX',N'Thoát','./images/Thoat.png' ORDER BY Ma_Du_An");
            if (myTable.Rows.Count == 2)
            {
                Session["G_Ma_Du_An"] = myTable.Rows[0]["Ma_Du_An"].ToString();
                Response.Redirect("Default.aspx");
            }
            else
                Response.Redirect("Module.aspx");
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        CheckLogin();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtTen.Text = "";
        txtPassword.Text = "";
    }
    #endregion
}