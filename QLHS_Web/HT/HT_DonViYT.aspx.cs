using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using QLHS_Logic;
using System.Data;
public partial class HT_HT_DonViYT : System.Web.UI.Page
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

            if (Session["G_Theme"] != null)
            {
                DHM_Common.SetTheme(this.Page, int.Parse(Session["G_Theme"].ToString()));
            }

            if (Request.QueryString["Ma_Don_Vi"] != null)
            {
                HT_Don_Vi_YT_Chi_Tiet myDetail = Sys_Common.HT_DON_VI_YT.Lay(int.Parse(Request.QueryString["Ma_Don_Vi"].ToString()));
                SetData(myDetail);
                Initialization();
            }
            else
            {
                ClearData();
                Initialization();
            }
        }
    }
    protected void cboMa_Huyen_Selected(object sender, DirectEventArgs e)
    {
        dsXa.DataSource = Sys_Common.HT_DM_XA.Lay_Boi_HT_DM_Huyen(cboMa_Huyen.Value.ToString());
        dsXa.DataBind();
        
    }
    private void Initialization()
    {
        //Load combo data
        dsDM_Tinh.DataSource = Sys_Common.HT_DM_TINH.Danh_Sach();
        dsDM_Tinh.DataBind();
                
        dsHuyen.DataSource = Sys_Common.HT_DM_HUYEN.Lay_Boi_HT_DM_Tinh(Sys_Common.G_MA_TINH);
        dsHuyen.DataBind();
    }
    private void SetData(HT_Don_Vi_YT_Chi_Tiet myDetail)
    {
        btnUpdate.Text = "Cập nhật";
        btnUpdate.Icon = Icon.ApplicationEdit;

        txtMa_Don_Vi.Text = myDetail.Ma_Don_Vi.ToString();

        txtTen_Don_Vi.Text = myDetail.Ten_Don_Vi;
        cboTuyen.Value = myDetail.Tuyen.ToString();
        cboMa_Tinh.Value = myDetail.Ma_Tinh;
        cboMa_Huyen.Text = myDetail.Ma_Huyen;
        if (cboMa_Huyen.Text != "")
        {
            cboMa_Huyen_Selected(null, null);
        }
        cboMa_Xa.Text = myDetail.Ma_Xa;
        cboLoai_Hinh.Value = myDetail.Loai_Hinh.ToString();
        cboThanh_Phan.Value = myDetail.Thanh_Phan.ToString();
        chkKB.Checked = myDetail.KB;
        chkDP.Checked = myDetail.DP;
        chkTB.Checked = myDetail.TB;
        chkBC.Checked = myDetail.BC;
        chkSK.Checked = myDetail.SK;
        chkDB.Checked = myDetail.DB;
        chkCP.Checked = myDetail.CP;
        chkNL.Checked = myDetail.NL;
        chkAT.Checked = myDetail.AT;
        chkDV.Checked = myDetail.DV;
        cboLoai_Dac_Biet.Value = myDetail.Loai_Dac_Biet.ToString();
    }
    private void ClearData()
    {
        txtMa_Don_Vi.Text = "0";

        txtTen_Don_Vi.Text = "";
        cboTuyen.Value= "";
        cboMa_Tinh.Value = "22";
        cboMa_Huyen.Text = "";
        cboMa_Xa.Text = "";
        cboLoai_Hinh.Value = "";
        cboThanh_Phan.Value = "";
        chkKB.Checked = false;
        chkDP.Checked = false;
        chkTB.Checked = false;
        chkBC.Checked = false;
        chkSK.Checked = false;
        chkDB.Checked = false;
        chkCP.Checked = false;
        chkNL.Checked = true;
        chkAT.Checked = false;
        chkDV.Checked = false;
        cboLoai_Dac_Biet.Value = "0";
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        if (FormValidate())
        {
            string idHuyen,idXa;
            if (cboMa_Huyen.Value == null)
            {
                idHuyen = "";
            }
            else
            {
                idHuyen = cboMa_Huyen.Value.ToString();
            }
            if (cboMa_Xa.Value == null)
            {
                idXa = "";
            }
            else
            {
                idXa = cboMa_Xa.Value.ToString();
            }
            if (Request.QueryString["Ma_Don_Vi"] != null)
            {
                Sys_Common.HT_DON_VI_YT.Cap_Nhat(int.Parse(Request.QueryString["Ma_Don_Vi"].ToString()), txtTen_Don_Vi.Text, 1, "22", idHuyen, idXa, 
                    int.Parse(cboLoai_Hinh.Value.ToString()), 1, chkKB.Checked, chkDP.Checked, chkTB.Checked, chkBC.Checked, chkSK.Checked, chkDB.Checked, chkCP.Checked, chkNL.Checked, chkAT.Checked, chkDV.Checked, 1);
            }
            else
            {
                Sys_Common.HT_DON_VI_YT.Them(0, txtTen_Don_Vi.Text, 1,"22", idHuyen, idXa, int.Parse(cboLoai_Hinh.Value.ToString()), 1, chkKB.Checked, chkDP.Checked, chkTB.Checked, chkBC.Checked, chkSK.Checked, chkDB.Checked, chkCP.Checked, chkNL.Checked, chkAT.Checked, chkDV.Checked, 1);
                ClearData();
            }

            X.Msg.Alert("Thông báo", "Đã Cập nhật thành công !!!", new JFunction { Fn = "" }).Show();
        }
    }
    private bool FormValidate()
    {
        if (this.txtMa_Don_Vi.Text.ToString() == "")
        {
            X.Msg.Alert("Thông báo", "Thiếu thông tin ", new JFunction { Fn = "" }).Show();
            return false;
        }

        if (this.txtTen_Don_Vi.Text.ToString() == "")
        {
            X.Msg.Alert("Thông báo", "Thiếu thông tin Tên đơn vị", new JFunction { Fn = "" }).Show();
            return false;
        }

        if (this.cboLoai_Hinh.Text.ToString() == "")
        {
            X.Msg.Alert("Thông báo", "Thiếu thông tin Loại hình của đơn vị", new JFunction { Fn = "" }).Show();
            return false;
        }
        return true;
    }
    protected void btnClose_Click(object sender, DirectEventArgs e)
    {
        X.Msg.AddScript("var parent = window.parent;parent.winHT_Don_Vi_YT.hide();");
    }
}
