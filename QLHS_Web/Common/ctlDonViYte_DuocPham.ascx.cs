using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using QLHS_Logic;
using System.Data;
public partial class Common_ctlDonViYte_DuocPham : System.Web.UI.UserControl
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
            cboLoaiHinhChon.Value = Sys_Common.G_LOAI_HINH_DU_PHONG;
            switch (Session["G_Ma_Loai_Hinh"].ToString())
            {
                case "1":
                    dsMaHuyenChon.DataSource = Sys_Common.HT_DM_HUYEN.Lay_Boi_HT_DM_Tinh(Sys_Common.G_MA_TINH);
                    dsMaHuyenChon.DataBind();

                    if (cboLoaiHinhChon.Value.ToString() == Sys_Common.G_LOAI_HINH_KHAM_CHUA_BENH.ToString())
                    {
                        DataTable myData = Sys_Common.RunTableBySQL("SELECT * FROM HT_Don_Vi_YT WHERE Loai_Hinh IN (4,5) or (Loai_Hinh = 6 and Thanh_Phan = 1) or (Loai_Hinh=3 and Loai_Dac_Biet=2) ");
                        if (myData != null)
                        {
                            dsDonViKhacChon.DataSource = myData;
                            dsDonViKhacChon.DataBind();
                        }
                    }
                    else
                    {
                        cboDonViKhacChon.Hidden = true;
                    }
                    break;
                case "2":
                    HT_Don_Vi_YT_Chi_Tiet myDonViChiTiet = Sys_Common.HT_DON_VI_YT.Lay(int.Parse(Session["G_Ma_Don_Vi"].ToString()));
                    dsMaHuyenChon.DataSource = Sys_Common.HT_DM_HUYEN.Lay_Boi_HT_DM_Tinh(Sys_Common.G_MA_TINH);
                    dsMaHuyenChon.DataBind();
                    cboMaHuyenChon.Value = myDonViChiTiet.Ma_Huyen;
                    cboMaHuyenChon_Selected(null, null);
                    cboMaHuyenChon.Hidden = true;
                    cboDonViKhacChon.Hidden = true;
                    cboLoaiHinhChon.Hidden = true;
                    break;
                default:
                    pnlDonViChon.Hidden = true;
                    cboDonViKhacChon.Hidden = false;
                    cboLoaiHinhChon.Value = Sys_Common.G_LOAI_HINH_KHAM_CHUA_BENH.ToString();
                    break;


            }

        }
    }
    protected void cboLoaiHinhChon_Selected(object sender, DirectEventArgs e)
    {
        if (cboLoaiHinhChon.Value.ToString() == Sys_Common.G_LOAI_HINH_KHAM_CHUA_BENH.ToString())
        {
            DataTable myData = Sys_Common.RunTableBySQL("SELECT * FROM HT_Don_Vi_YT WHERE Loai_Hinh IN (4,5) or (Loai_Hinh = 6 and Thanh_Phan = 1) ");
            if (myData != null)
            {
                dsDonViKhacChon.DataSource = myData;
                dsDonViKhacChon.DataBind();
            }
            cboDonViKhacChon.Hidden = false;
            cboMaHuyenChon.Hidden = true;
            cboDonViChon.Hidden = true;
        }
        else
        {
            cboDonViKhacChon.Hidden = true;
            if (Session["G_Ma_Loai_Hinh"].ToString() == "1")
            {
                cboMaHuyenChon.Hidden = false;
            }
            else
            {
                cboMaHuyenChon.Hidden = true;
            }
            cboDonViChon.Hidden = false;
        }
    }
    protected void cboMaHuyenChon_Selected(object sender, DirectEventArgs e)
    {
        DataTable myTable = Sys_Common.RunTableBySQL("SELECT Ma_Don_Vi, Ten_Don_Vi FROM HT_Don_Vi_YT WHERE Ma_Huyen='" + cboMaHuyenChon.Value.ToString() + "' and Loai_Hinh in (2,3,6) ");
        if (myTable != null)
        {
            dsDonViChon.DataSource = myTable;
            dsDonViChon.DataBind();
        }
        else
        {
            cboDonViChon.GetStore().RemoveAll();
            cboDonViChon.SelectedItem.Value = "";

        }
    }
    public string Ma_Huyen
    {
        get { return cboMaHuyenChon.Value == null ? "" : cboMaHuyenChon.Value.ToString(); }

    }
    public string Ma_Don_Vi
    {
        get { return cboDonViChon.Value == null ? "" : cboDonViChon.Value.ToString(); }

    }
    public string Ma_Don_Vi_Khac
    {
        get { return cboDonViKhacChon.Value == null ? "" : cboDonViKhacChon.Value.ToString(); }
    }
    public string Loai_Hinh
    {
        get { return cboLoaiHinhChon.Value == null ? "" : cboLoaiHinhChon.Value.ToString(); }
    }
}