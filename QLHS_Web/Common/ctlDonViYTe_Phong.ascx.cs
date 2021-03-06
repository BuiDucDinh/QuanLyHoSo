﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using QLHS_Logic;
using System.Data;
public partial class Common_ctlDonViYTe_Phong : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region cu
        /*
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
                        DataTable myData = Sys_Common.RunTableBySQL("SELECT * FROM HT_Don_Vi_YT WHERE Loai_Hinh IN (1,4,5,7)or (Loai_Hinh = 6 and Thanh_Phan = 1) ");
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
                    //cboDonViChon_Selected(null, null);
                    cboMaHuyenChon.Hidden = true;
                    cboDonViKhacChon.Hidden = true;
                    break;
                default:
                    pnlDonViChon.Hidden = true;
                    cboDonViKhacChon.Hidden = false;
                    cboLoaiHinhChon.Value = Sys_Common.G_LOAI_HINH_KHAM_CHUA_BENH.ToString();
                    break;
            }
        }
         */
        #endregion
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

            switch (Session["G_Ma_Loai_Hinh"].ToString())
            {
                case "1": //Phòng ban sở YT (1): Nhập và xem tất cả
                    cboLoaiHinhChon.Value = Sys_Common.G_LOAI_HINH_DU_PHONG;

                    dsMaHuyenChon.DataSource = Sys_Common.HT_DM_HUYEN.Lay_Boi_HT_DM_Tinh(Sys_Common.G_MA_TINH);
                    dsMaHuyenChon.DataBind();

                    cboDonViKhacChon.Hidden = true;
                    break;
                case "2": //TT Y tế Huyện (2): nhập cho Huyện và Xã (3)
                    HT_Don_Vi_YT_Chi_Tiet myDonViChiTiet = Sys_Common.HT_DON_VI_YT.Lay(int.Parse(Session["G_Ma_Don_Vi"].ToString()));
                    dsMaHuyenChon.DataSource = Sys_Common.HT_DM_HUYEN.Lay_Boi_HT_DM_Tinh(Sys_Common.G_MA_TINH);
                    dsMaHuyenChon.DataBind();
                    cboMaHuyenChon.Value = myDonViChiTiet.Ma_Huyen;
                    cboMaHuyenChon_Selected(null, null);
                    cboMaHuyenChon.Hidden = true;
                    cboDonViKhacChon.Hidden = true;
                    cboLoaiHinhChon.Hidden = true;
                    break;
                default: //Còn lại: BV Tỉnh (4), BV Huyện (5), các chi cục & TT chuyên ngành (7): Chỉ nhập cho đơn vị mình
                    pnlDonViChon.Hidden = false;
                     cboMaHuyenChon.Hidden = true;
                    cboDonViKhacChon.Hidden = true;
                    cboDonViChon.Hidden = true;
                    cboLoaiHinhChon.Hidden = true;
                    cboPhongBan.Hidden = false;
                    cboDonViKhacChon.Value = Session["G_Ma_Don_Vi"].ToString();
                     DataTable myTable = Sys_Common.RunTableBySQL("SELECT Ma_Phong, Ten_Phong FROM NL_DM_Phong_Ban WHERE Ma_Don_Vi=" + cboDonViKhacChon.Value.ToString());
                            if (myTable != null)
                            {
                                dsPhongBan.DataSource = myTable;
                                dsPhongBan.DataBind();
                            }
                            else
                            {
                                cboPhongBan.GetStore().RemoveAll();
                                cboPhongBan.SelectedItem.Value = "";
                            }
                    break;
            }

        }
    }
    #region cu
    /*
    protected void cboLoaiHinhChon_Selected(object sender, DirectEventArgs e)
    {
        if (cboLoaiHinhChon.Value.ToString() == Sys_Common.G_LOAI_HINH_KHAM_CHUA_BENH.ToString())
        {
            DataTable myData = Sys_Common.RunTableBySQL("SELECT * FROM HT_Don_Vi_YT WHERE Loai_Hinh IN (1,4,5,7) or (Loai_Hinh = 6 and Thanh_Phan = 1) ");
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

        cboPhongBan.GetStore().RemoveAll();
        cboPhongBan.SelectedItem.Value = "";
    }
    protected void cboMaHuyenChon_Selected(object sender, DirectEventArgs e)
    {
        DataTable myTable = Sys_Common.RunTableBySQL("SELECT Ma_Don_Vi, Ten_Don_Vi FROM HT_Don_Vi_YT WHERE Ma_Huyen='" + cboMaHuyenChon.Value.ToString() + "'");
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
        cboPhongBan.GetStore().RemoveAll();
        cboPhongBan.SelectedItem.Value = "";
    }
     */ 
    #endregion
    protected void cboLoaiHinhChon_Selected(object sender, DirectEventArgs e)
    {
        if (cboLoaiHinhChon.Value.ToString() == Sys_Common.G_LOAI_HINH_CHON_TUYEN_DU_PHONG.ToString())//Tuyến dự phòng
        {
            cboDonViKhacChon.Hidden = true;
            cboMaHuyenChon.Hidden = false;
            cboDonViChon.Hidden = false;
        }
        else if (cboLoaiHinhChon.Value.ToString() == Sys_Common.G_LOAI_HINH_CHON_TUYEN_DIEU_TRI.ToString()) //Tuyến điều trị
        {
            //DataTable myData = Sys_Common.RunTableBySQL("SELECT * FROM HT_Don_Vi_YT WHERE Loai_Hinh IN (4,5) and NL = 1 and Ma_Tinh = '" + Sys_Common.G_MA_TINH + "'");
            DataTable myData = Sys_Common.RunTableBySQL("SELECT * FROM HT_Don_Vi_YT WHERE Loai_Hinh IN (4,5) and Ma_Tinh = '" + Sys_Common.G_MA_TINH + "'");
            cboDonViKhacChon.Value = null;
            if (myData != null)
            {
                dsDonViKhacChon.DataSource = myData;
                dsDonViKhacChon.DataBind();
            }

            cboDonViKhacChon.Hidden = false;
            cboMaHuyenChon.Hidden = true;
            cboDonViChon.Hidden = true;
        }
        else //Tuyến nhà nước
        {
            //DataTable myData = Sys_Common.RunTableBySQL("SELECT * FROM HT_Don_Vi_YT WHERE (Loai_Hinh = 1 or (Loai_Hinh = 7 and Loai_Dac_Biet = 1)) and NL=1 and Ma_Tinh = '" + Sys_Common.G_MA_TINH + "'");
            DataTable myData = Sys_Common.RunTableBySQL("SELECT * FROM HT_Don_Vi_YT WHERE ((Loai_Hinh = 1 and Loai_Dac_Biet = 1 )or (Loai_Hinh = 7 and Loai_Dac_Biet = 1)) and Ma_Tinh = '" + Sys_Common.G_MA_TINH + "'");
            cboDonViKhacChon.Value = null;
            if (myData != null)
            {
                dsDonViKhacChon.DataSource = myData;
                dsDonViKhacChon.DataBind();
            }

            cboDonViKhacChon.Hidden = false;
            cboMaHuyenChon.Hidden = true;
            cboDonViChon.Hidden = true;
        }
        cboPhongBan.GetStore().RemoveAll();
        cboPhongBan.SelectedItem.Value = "";
        //cboMaHuyenChon.Value = null;
        //cboMaHuyenChon_Selected(null, null);
        //cboDonViKhacChon.Value = null;
    }
    protected void cboMaHuyenChon_Selected(object sender, DirectEventArgs e)
    {
        //DataTable myTable = Sys_Common.RunTableBySQL("SELECT Ma_Don_Vi, Ten_Don_Vi FROM HT_Don_Vi_YT WHERE Loai_Hinh in (2,3)  and Ma_Huyen='" + cboMaHuyenChon.Value.ToString() + "' and NL=1 and Ma_Tinh = '" + Sys_Common.G_MA_TINH + "'");
        DataTable myTable = Sys_Common.RunTableBySQL("SELECT DV.Ma_Don_Vi, case DV.Loai_Hinh When 2 then DV.Ten_Don_Vi when 3 then '---'+DV.Ten_Don_Vi end as Ten_Don_Vi FROM HT_Don_Vi_YT DV WHERE Loai_Hinh in (2,3)  and Ma_Huyen='" + cboMaHuyenChon.Value.ToString() + "' and Ma_Tinh = '" + Sys_Common.G_MA_TINH + "' order by DV.Loai_Hinh,DV.Ten_Don_Vi asc");
        if (myTable != null)
        {
            dsDonViChon.DataSource = myTable;
            dsDonViChon.DataBind();
        }
        else
        {
            cboDonViChon.GetStore().RemoveAll();
        }
        cboDonViChon.SelectedItem.Value = "";
        cboPhongBan.GetStore().RemoveAll();
        cboPhongBan.SelectedItem.Value = "";
    }

    protected void cboDonViChon_Selected(object sender, DirectEventArgs e)
    {
        DataTable myTable = Sys_Common.RunTableBySQL("SELECT Ma_Phong, Ten_Phong FROM NL_DM_Phong_Ban WHERE Ma_Don_Vi=" + cboDonViChon.Value.ToString());
        if (myTable != null)
        {
            dsPhongBan.DataSource = myTable;
            dsPhongBan.DataBind();
        }
        else
        {
            cboPhongBan.GetStore().RemoveAll();
            cboPhongBan.SelectedItem.Value = "";

        }
    }

    protected void cboDonViKhacChon_Selected(object sender, DirectEventArgs e)
    {
        DataTable myTable = Sys_Common.RunTableBySQL("SELECT Ma_Phong, Ten_Phong FROM NL_DM_Phong_Ban WHERE Ma_Don_Vi=" + cboDonViKhacChon.Value.ToString());
        if (myTable != null)
        {
            dsPhongBan.DataSource = myTable;
            dsPhongBan.DataBind();
        }
        else
        {
            cboPhongBan.GetStore().RemoveAll();
            cboPhongBan.SelectedItem.Value = "";
        }
    }

    public string Ma_Phong
    {
        get { return cboPhongBan.Value == null ? "" : cboPhongBan.Value.ToString(); }
        set 
        {
            cboPhongBan.Value = value;
        }

    }

    public string Ma_Huyen
    {
        get { return cboMaHuyenChon.Value == null ? "" : cboMaHuyenChon.Value.ToString(); }
        set
        {
            cboMaHuyenChon.Value = value;
            cboMaHuyenChon_Selected(null, null);
        }

    }
    public string Ma_Don_Vi
    {
        get { return cboDonViChon.Value == null ? "" : cboDonViChon.Value.ToString(); }
        set
        {
            cboDonViChon.Value = value;
            cboDonViChon_Selected(null, null);
        }

    }
    public string Ma_Don_Vi_Khac
    {
        get { return cboDonViKhacChon.Value == null ? "" : cboDonViKhacChon.Value.ToString(); }
        set
        {
            cboDonViKhacChon.Value = value;
            cboDonViKhacChon_Selected(null, null);
        }
    }
    public string Loai_Hinh
    {
        get { return cboLoaiHinhChon.Value == null ? "" : cboLoaiHinhChon.Value.ToString(); }
        set
        {
            cboLoaiHinhChon.Value = value;
            cboLoaiHinhChon_Selected(null, null);
        }
    }
}