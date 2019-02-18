using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using QLHS_Logic;
using System.Data;
using QLHS_Logic.NV;
public partial class HT_HT_NguoiDungDanhSach : System.Web.UI.Page
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
            txtMaDonVi.Text = "0";
            txtMa_Nguoi_Dung.Text = "0";
            //X.Msg.AddScript("#{dsData}.reload();");
        }
    }

    protected void RowSelect(object sender, DirectEventArgs e)
    {
        string Ma_Don_Vi = e.ExtraParams["Ma_Don_Vi"];
        if (!Ma_Don_Vi.Equals(""))
        {
            txtMaDonVi.Text = Ma_Don_Vi;
            DataTable myTable = Sys_Common.RunTableBySQL("SELECT * FROM HT_Nguoi_Dung WHERE Ma_Don_Vi=" + txtMaDonVi.Text);
            if (myTable != null)
            {
                dsData.DataSource = myTable;
                dsData.DataBind();
            }
            else
            {
                gridData.GetStore().RemoveAll();
            }
        }
        txtMa_Nguoi_Dung.Text = "0";
        btnInsert.Disabled = false;
        btnUpdate.Disabled = true;
        btnVaiTroBo.Disabled = true;
        btnVaiTroThem.Disabled = true;
        ClearData();
        DataGridBinding();
    }
    protected void RowSelectNguoiDung(object sender, DirectEventArgs e)
    {
        string Ma_Nguoi_Dung = e.ExtraParams["Ma_Nguoi_Dung"];
        if (!Ma_Nguoi_Dung.Equals(""))
        {
            HT_Nguoi_Dung_Chi_Tiet myDetail = Sys_Common.HT_NGUOI_DUNG.Lay(int.Parse(Ma_Nguoi_Dung));
            this.txtTen_Dang_Nhap.Text = myDetail.Ten_Dang_Nhap;
            this.txtMat_Khau.Text = Sys_Common.Decrypt(myDetail.Mat_Khau, Sys_Common.Key);
            this.txtHom_Thu.Text = myDetail.Hom_Thu;
            this.cboHinh_Nen.Value = myDetail.Hinh_Nen;
            this.chkDuoc_Kich_Hoat.Checked = myDetail.Duoc_Kich_Hoat;
            this.txtHo_Ten.Text = myDetail.Ho_Ten;
            this.txtDien_Thoai.Text = myDetail.Dien_Thoai;
            this.cbCanbo.Value = myDetail.CanBoID;
            //hidden attributes
            this.txtMa_Nguoi_Dung.Text = myDetail.Ma_Nguoi_Dung.ToString();
            btnUpdate.Disabled = false;
            btnInsert.Disabled = true;
            btnVaiTroBo.Disabled = false;
            btnVaiTroThem.Disabled = false;

            DataGridBinding();
        }
    }
    protected void btnVaiTroThem_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gridKhongVaiTro.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            Sys_Common.HT_NGUOI_DUNG_VAI_TRO.Cap_Nhat_Them(0, int.Parse(txtMa_Nguoi_Dung.Text), int.Parse(row.RecordID));
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
        DataGridBinding();
    }
    protected void btnVaiTroBo_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gridCoVaiTro.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            Sys_Common.HT_NGUOI_DUNG_VAI_TRO.Xoa(int.Parse(row.RecordID));
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
        DataGridBinding();
    }
    private void DataGridBinding()
    {
        if (txtMa_Nguoi_Dung.Text != "")
        {
            dsCoVaiTro.DataSource = Sys_Common.HT_NGUOI_DUNG_VAI_TRO.Lay_Boi_HT_Vai_Tro_Chon(int.Parse(txtMa_Nguoi_Dung.Text), true);
            dsCoVaiTro.DataBind();

            dsKhongVaiTro.DataSource = Sys_Common.HT_NGUOI_DUNG_VAI_TRO.Lay_Boi_HT_Vai_Tro_Chon(int.Parse(txtMa_Nguoi_Dung.Text), false);
            dsKhongVaiTro.DataBind();
        }
        else
        {
            gridCoVaiTro.GetStore().RemoveAll();
            gridKhongVaiTro.GetStore().RemoveAll();
        }

    }
    protected void odsDonVi_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        (this.dsDonVi.Proxy[0] as PageProxy).Total = (int)e.OutputParameters["Count"];
    }
    protected void dsDonVi_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        this.odsDonVi.SelectParameters["Start"].DefaultValue = (e.Start + 1).ToString();
        this.odsDonVi.SelectParameters["Limit"].DefaultValue = (e.Limit + e.Start).ToString();

        if (e.Parameters["Filter"] == "")
        {
            this.odsDonVi.SelectParameters["WhereString"].DefaultValue = "DM_CoQuanHanhChinh";
        }
        else
        {
            this.odsDonVi.SelectParameters["WhereString"].DefaultValue = "DM_CoQuanHanhChinh WHERE"
                + " TenCoQuan LIKE N'%" + txtFilter.Text + "%'";

        }
        this.odsDonVi.SelectParameters["SortString"].DefaultValue = e.Sort + " " + e.Dir;

        this.odsDonVi.DataBind();

    }
    protected void btnInsert_Click(object sender, DirectEventArgs e)
    {

        this.txtMa_Nguoi_Dung.Text = "0";
        this.txtTen_Dang_Nhap.Text = "";
        this.txtMat_Khau.Text = "";
        this.txtHom_Thu.Text = "";
        this.cboHinh_Nen.Value = "1";
        this.chkDuoc_Kich_Hoat.Checked = true;
        this.txtHo_Ten.Text = "";
        this.txtDien_Thoai.Text = "";
        btnInsert.Disabled = true;
        btnUpdate.Disabled = false;
        btnVaiTroBo.Disabled = false;
        btnVaiTroThem.Disabled = false;
        DataGridBinding();
    }
    private bool FormValidate()
    {
        if (string.IsNullOrEmpty(txtTen_Dang_Nhap.Text.Trim()) || string.IsNullOrEmpty(txtMat_Khau.Text.Trim()) || (string.IsNullOrEmpty(txtHo_Ten.Text.Trim()) && cbCanbo.Value == null))
        {
            X.Msg.Alert("Thông báo", "Hãy nhập đủ các trường có dấu *").Show();
            return false;
        }
        return true;
    }
    private bool checkAdd()
    {
        if (cbCanbo.Value != null)
        {
            string sql = "select * from HT_Nguoi_Dung where CanBoID=" + cbCanbo.Value.ToString();
            DataTable dt = Sys_Common.RunTableBySQL(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                X.Msg.Alert("Thông báo", "Cán bộ này đã có tài khoản").Show();
                return false;
            }
        }
        return true;
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        if (FormValidate())
        {
            int canbo = 0;
            try { canbo = int.Parse(cbCanbo.Value.ToString()); }
            catch { }
            if (this.txtMa_Nguoi_Dung.Text == "0")
            {
                if (checkAdd())
                {
                    //INSERT
                    string count = Sys_Common.CalBySQL("SELECT COUNT(*) FROM HT_Nguoi_Dung WHERE Ten_Dang_Nhap = N'" + txtTen_Dang_Nhap.Text.Trim() + "'");
                    if (count != "0")
                    {
                        string temp = Sys_Common.CalBySQL("SELECT TenCoQuan FROM CoQuanHanhChinh WHERE CoQuanID = (SELECT Ma_Don_Vi FROM HT_Nguoi_Dung WHERE Ten_Dang_Nhap = N'" + txtTen_Dang_Nhap.Text.Trim() + "')");
                        X.Msg.Alert("Thông báo", "Đã có người dùng có tên đăng nhập là " + txtTen_Dang_Nhap.Text + " tại đơn vị " + temp + " trong hệ thống sử dụng tên đăng nhập này !!!", new JFunction { Fn = "" }).Show();
                        return;
                    }
                    else
                    {
                        txtMa_Nguoi_Dung.Text = Sys_Common.HT_NGUOI_DUNG.Them(int.Parse(txtMa_Nguoi_Dung.Text), int.Parse(txtMaDonVi.Text), txtTen_Dang_Nhap.Text,
                            Sys_Common.Encrypt(txtMat_Khau.Text, Sys_Common.Key), txtHo_Ten.Text, txtHom_Thu.Text, txtDien_Thoai.Text, chkDuoc_Kich_Hoat.Checked, int.Parse(cboHinh_Nen.Value.ToString()), canbo).ToString();

                        X.Msg.Alert("Thông báo", "Đã thêm mới thành công !!!", new JFunction { Fn = "" }).Show();
                        ClearData();

                    }
                }
            }
            else
            {
                //UPDATE

                Sys_Common.HT_NGUOI_DUNG.Cap_Nhat(int.Parse(txtMa_Nguoi_Dung.Text), int.Parse(txtMaDonVi.Text), txtTen_Dang_Nhap.Text,
                    Sys_Common.Encrypt(txtMat_Khau.Text, Sys_Common.Key), txtHo_Ten.Text, txtHom_Thu.Text, txtDien_Thoai.Text, chkDuoc_Kich_Hoat.Checked, int.Parse(cboHinh_Nen.Value.ToString()), canbo);

                X.Msg.Alert("Thông báo", "Đã cập nhật thành công !!!", new JFunction { Fn = "" }).Show();
                ClearData();

            }
            //ClearData();
            btnInsert.Disabled = false;
            btnUpdate.Disabled = true;

            DataTable myTable = Sys_Common.HT_NGUOI_DUNG.Lay_Boi_HT_Don_Vi_YT(int.Parse(txtMaDonVi.Text)); //Sys_Common.RunTableBySQL("SELECT * FROM HT_Nguoi_Dung WHERE Ma_Don_Vi=" + txtMaDonVi.Text);
            if (myTable != null)
            {
                dsData.DataSource = myTable;
                dsData.DataBind();
            }
            else
            {
                gridData.GetStore().RemoveAll();
            }
            X.Msg.AddScript("#{stData}.reload();");
        }
    }
    private void ClearData()
    {
        this.txtTen_Dang_Nhap.Text = "";
        this.txtMat_Khau.Text = "";
        this.txtHom_Thu.Text = "";
        this.cboHinh_Nen.Value = "";

        this.chkDuoc_Kich_Hoat.Checked = true;
        this.txtDien_Thoai.Text = "";
        this.txtHo_Ten.Text = "";
        this.cboHinh_Nen.Value = "1";
        //hidden attributes
        this.txtMa_Nguoi_Dung.Text = "0";
        this.cbCanbo.Value = "";
    }
    protected void btnDelete_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gridData.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            Sys_Common.HT_NGUOI_DUNG.Xoa(int.Parse(row.RecordID.ToString()));
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
        X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();

        DataTable myTable = Sys_Common.RunTableBySQL("SELECT * FROM HT_Nguoi_Dung WHERE Ma_Don_Vi=" + txtMaDonVi.Text);
        if (myTable != null)
        {
            dsData.DataSource = myTable;
            dsData.DataBind();
        }
        else
        {
            gridData.GetStore().RemoveAll();
        }
        txtMa_Nguoi_Dung.Text = "0";
        btnInsert.Disabled = false;
        btnUpdate.Disabled = true;
        btnVaiTroBo.Disabled = true;
        btnVaiTroThem.Disabled = true;

    }
    protected void stCanbo_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        string sql = "select CanBoID,HoTen,(select TenChucVu from ChucVu c where c.ChucVuID=cb.ChucVuID) as ChucVu,(select Ten_Dang_Nhap from HT_Nguoi_Dung nd where nd.CanBoID=cb.CanBoID) as Username from CanBo cb where CoQuanID=" + txtMaDonVi.Text;
        DataTable dt = Sys_Common.RunTableBySQL(sql);
        if (dt != null)
        {
            stCanbo.DataSource = dt;
            stCanbo.DataBind();
        }
        else
        {
            cbCanbo.GetStore().RemoveAll();
        }
    }
}