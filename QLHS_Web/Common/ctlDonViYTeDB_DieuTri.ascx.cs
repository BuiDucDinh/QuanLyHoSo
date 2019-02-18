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
            if (myDonViChiTiet.Loai_Hinh == 1 || myDonViChiTiet.Loai_Hinh == 7)
            {

            }
            else if (myDonViChiTiet.Loai_Hinh == 4 || myDonViChiTiet.Loai_Hinh == 5 || myDonViChiTiet.Loai_Hinh == 6) //Bệnh viện: chỉ xem được mình
            {
                cboLoaiHinh.Value = myDonViChiTiet.Loai_Hinh;
                cboLoaiHinh_Selected(null, null);
                cboLoaiHinh.Disabled = true;
                cboDonVi.Value = myDonViChiTiet.Ma_Don_Vi;
                cboDonVi.Disabled = true;
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
    protected void cboLoaiHinh_Selected(object sender, DirectEventArgs e)
    {
        DataTable myData = Sys_Common.RunTableBySQL("SELECT * FROM HT_Don_Vi_YT WHERE Loai_Hinh = " + cboLoaiHinh.Value.ToString() + " and Ma_Tinh = '" + Sys_Common.G_MA_TINH + "'");
        cboDonVi.Value = null;
        if (myData != null)
        {
            dsDonVi.DataSource = myData;
            dsDonVi.DataBind();
        }
    }


    //==================Thuoc tinh Properties
    public string Loai_Hinh
    {
        get { return cboLoaiHinh.Value == null ? "" : cboLoaiHinh.Value.ToString(); }
        set
        {
            cboLoaiHinh.Value = value;
            cboLoaiHinh_Selected(null, null);
        }

    }
    public string Ma_Don_Vi
    {
        get { return cboDonVi.Value == null ? "" : cboDonVi.Value.ToString(); }
        set
        {
            cboDonVi.Value = value;
            //cboDonViChon_Selected(null, null);
        }

    }

}