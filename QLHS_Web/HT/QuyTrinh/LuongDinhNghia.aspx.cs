using Ext.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLHS_Logic;
public partial class HT_QuyTrinh_LuongDinhNghia : System.Web.UI.Page
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
            //X.Msg.Alert("Thông báo", Session["G_Ma_Chuc_Nang"].ToString(), new JFunction { Fn = "" }).Show();
            if (Session["G_Theme"] != null)
            {
                DHM_Common.SetTheme(this.Page, int.Parse(Session["G_Theme"].ToString()));
            }
            int id = 0;
            try
            {
                id = int.Parse(Request.QueryString["id"].ToString());
                lbTitle.Text = Sys_Common.NV_QuyTrinhDinhNghia.GetById(id).Ten;
                string sql = @"select N'Bước '+cast(STT as nvarchar(20)) as STT,ID,Ten,
	                        (select TenCoQuan from DM_CoQuanHanhChinh cq where cq.CoQuanID=l.CoQuanID) as CoQuan,
	                        (select HoTen+'-'+SoDienThoai+'-'+Email+'-'+DiaChi from CanBo cb where cb.CanBoID=l.NguoiXuLy) as NguoiXuLy,
	                        cast(ThoiGianHT as nvarchar(20))+N' ngày' as ThoiGianHT,MoTa
                        from LuongDinhNghia l where IDQuyTrinh=" + id + " order by STT";
                DataTable dt = Sys_Common.RunTableBySQL(sql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    rptData.DataSource = dt;
                    rptData.DataBind();
                }
                else
                {
                    lbMessage.Text = "<br/>Quy trình này chưa được tạo luồng xử lý";
                }
            }
            catch { }

        }
    }

}