using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLHS_Logic;
using Ext.Net;
public partial class HT_HT_VaiTroChucNang : System.Web.UI.Page
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
            
            dsDu_An.DataSource = Sys_Common.HT_DU_AN.Danh_Sach_Boi_Vai_Tro(int.Parse(Request.QueryString["Ma_Vai_Tro"]));
            dsDu_An.DataBind();

            //cboMa_Du_An.SelectedIndex = 1;
            DataGridBinding();
        }
    }

    public void cboMa_Du_An_Click(object sender, DirectEventArgs e)
    {
        DataGridBinding();
    }

    private void DataGridBinding()
    {
        if ((Request.QueryString["Ma_Vai_Tro"] != null)&&(cboMa_Du_An.Value!=null))
        {
            dsVaiTroChucNang.DataSource = Sys_Common.HT_VAI_TRO_CHUC_NANG.HT_Vai_Tro_Chuc_Nang_Lay_Boi_HT_Vai_Tro_Du_An(int.Parse(Request.QueryString["Ma_Vai_Tro"]),cboMa_Du_An.Value.ToString());
            dsVaiTroChucNang.DataBind();
        }

    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        if (Request.QueryString["Ma_Vai_Tro"] != null)
        {

            string jsonValues = e.ExtraParams["values"];
            List<Dictionary<string, string>> records = JSON.Deserialize<List<Dictionary<string, string>>>(jsonValues);
            foreach (var record in records)                                                                                                                   
            {
                string Ma_Chuc_Nang = record["Ma_Chuc_Nang"];
                bool Duoc_Truy_Cap = (record["Duoc_Truy_Cap"] == "True" ? true : false);
                bool Duoc_Sua = (record["Duoc_Sua"] == "True" ? true : false);
                bool Duoc_Xoa = (record["Duoc_Xoa"] == "True" ? true : false);
                bool Duoc_Xuat = (record["Duoc_Xuat"] == "True" ? true : false);
                bool Duoc_Nhap = (record["Duoc_Nhap"] == "True" ? true : false);
                bool Duoc_Duyet = (record["Duoc_Duyet"] == "True" ? true : false);

                Sys_Common.HT_VAI_TRO_CHUC_NANG.Cap_Nhat_Them(0, cboMa_Du_An.Value.ToString(), int.Parse(Request.QueryString["Ma_Vai_Tro"]), Ma_Chuc_Nang, Duoc_Truy_Cap, Duoc_Xoa, Duoc_Sua, Duoc_Xuat, Duoc_Nhap, Duoc_Duyet);
            }

            X.Msg.Alert("Thông báo", "Đã cập nhật thành công !!!", new JFunction { Fn = "" }).Show();
        }
    }
}