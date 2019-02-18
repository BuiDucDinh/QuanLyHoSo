using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using QLHS_Logic;
using System.Data;
public partial class Common_ctlDonViYTeDB_DuPhong : System.Web.UI.UserControl
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

            HT_Don_Vi_YT_Chi_Tiet myDonViChiTiet = Sys_Common.HT_DON_VI_YT.Lay(int.Parse(Session["G_Ma_Don_Vi"].ToString()));
            dsMa_Huyen.DataSource = Sys_Common.HT_DM_HUYEN.Lay_Boi_HT_DM_Tinh(Sys_Common.G_MA_TINH);
            dsMa_Huyen.DataBind();
            txtMa_Don_Vi.Text = "";
            if (myDonViChiTiet.Loai_Hinh == 1 || myDonViChiTiet.Loai_Hinh == 7)
            {

            }
            else if (myDonViChiTiet.Loai_Hinh == 2)
            {
                cboMa_Huyen.Value = myDonViChiTiet.Ma_Huyen;
                cboMa_Huyen.Disabled = true;
                cboMa_Huyen_Selected(null, null);
            }
            else if (myDonViChiTiet.Loai_Hinh == 3)
            {
                cboMa_Huyen.Value = myDonViChiTiet.Ma_Huyen;
                cboMa_Huyen.Disabled = true;
                cboMa_Huyen_Selected(null, null);
                cboMa_Xa.Value = myDonViChiTiet.Ma_Xa;
                cboMa_Xa.Disabled = true;
                txtMa_Don_Vi.Text = Sys_Common.CalBySQL("select Ma_Don_Vi from HT_Don_Vi_YT where Ma_Xa = '" + cboMa_Xa.Value.ToString() + "' and Loai_Hinh = 3");
            }
            else
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Bạn không có quyền vào chức năng này!",
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "ERROR"),
                    Closable = false
                });
                return;
            }
        }
    }
    protected void cboMa_Huyen_Selected(object sender, DirectEventArgs e)
    {
        cboMa_Xa.Value = null;
        txtMa_Don_Vi.Text = "";
        dsXa.DataSource = Sys_Common.HT_DM_XA.Lay_Boi_HT_DM_Huyen(cboMa_Huyen.Value.ToString());
        dsXa.DataBind();
    }
    protected void cboMa_Xa_Selected(object sender, DirectEventArgs e)
    {
        if (cboMa_Xa.Value != null)
        {
            txtMa_Don_Vi.Text = Sys_Common.CalBySQL("select Ma_Don_Vi from HT_Don_Vi_YT where Ma_Xa = '" + cboMa_Xa.Value.ToString() + "' and Loai_Hinh = 3");
        }
    }

    //==================Thuoc tinh Properties
    public string Ma_Don_Vi
    {
        get
        {
            return txtMa_Don_Vi.Text;
        }
        
    }
    public string Ma_Huyen
    {
        get { return cboMa_Huyen.Value == null ? "" : cboMa_Huyen.Value.ToString(); }
        set
        {
            cboMa_Huyen.Value = value;
            cboMa_Huyen_Selected(null, null);
        }

    }
    public string Ma_Xa
    {
        get { return cboMa_Xa.Value == null ? "" : cboMa_Xa.Value.ToString(); }
        set
        {
            cboMa_Xa.Value = value;
            //cboDonViChon_Selected(null, null);
            txtMa_Don_Vi.Text = Sys_Common.CalBySQL("select Ma_Don_Vi from HT_Don_Vi_YT where Ma_Xa = '" + cboMa_Xa.Value.ToString() + "' and Loai_Hinh = 3");
        }

    }

}