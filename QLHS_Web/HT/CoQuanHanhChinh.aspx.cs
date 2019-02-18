using Ext.Net;
using QLHS_Logic;
using QLHS_Logic.NV;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HT_CoQuanHanhChinh : System.Web.UI.Page
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

            TreePanel1.ReloadAsyncNode("0", null);

            Load_Data_For_DM_Cha_Combobox();
            Load_Data_For_Tinh_Combobox();
        }

        X.Msg.AddScript("#{TreePanel1}.expandAll();");
    }


    protected void btnCancel_Click(object sender, DirectEventArgs e)
    {
        ClearData();
    }
    protected void btnExport_Click(object sender, DirectEventArgs e) { }
    protected void btnInsert_Click(object sender, DirectEventArgs e) { }

    [DirectMethod]
    public void Delete(string value)
    {
        int id = int.Parse(value);

        NV_CoQuanHanhChinh_ChiTiet cq = Sys_Common.NV_CoQuanHanhChinh.GetById(id);
        if (id != null)
        {
            Sys_Common.NV_CoQuanHanhChinh.Xoa(id);

            X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
            TreePanel1.ReloadAsyncNode(cq.CoQuanQuanLy, null);
            ClearData();
            X.AddScript("#{stParent}.reload()");
        }
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        if (FormValidate())
        {
            NV_CoQuanHanhChinh_ChiTiet model = new NV_CoQuanHanhChinh_ChiTiet();

            model.TenCoQuan = txtTenCoQuan.Text;
            if (!string.IsNullOrEmpty(cbCoQuanQuanLy.SelectedItem.Value))
            {
                model.CoQuanQuanLy = cbCoQuanQuanLy.SelectedItem.Value;
            }
            else
            {
                model.CoQuanQuanLy = "0";
            }
            model.CapCoQuan = (txtCapCoQuan.Text == "" || txtCapCoQuan.Text == null) ? 1 : int.Parse(txtCapCoQuan.Text);
            model.ChucNang = txtChucNang.Text;
            model.LichSu = txtLichSu.Text;
            model.DiaChi = txtDiaChi.Text;
            model.ThuocTinh = cbxTinh.SelectedItem.Value;
            model.ThuocHuyen = cbxHuyen.SelectedItem.Value;
            model.ThuocXa = cbxXa.SelectedItem.Value;
            model.Mota = txtMoTa.Text;

            try
            {
                model.CoQuanID = int.Parse(hdCoQuanID.Text);
                Sys_Common.NV_CoQuanHanhChinh.update(model);
            }
            catch
            {
                Sys_Common.NV_CoQuanHanhChinh.them(model);
            }

            X.Msg.Alert("Thông báo", "Đã cập nhật thành công !!!", new JFunction { Fn = "" }).Show();
            TreePanel1.ReloadAsyncNode(cbCoQuanQuanLy.SelectedItem.Value, null);
            ClearData();
            // Reload combobox after update
            X.AddScript("#{stParent}.reload()");
        }
    }

    protected void grid_DbClick(object sender, DirectEventArgs e)
    {

    }

    [DirectMethod]
    public void GetInfo(string nodeID)
    {
        if (nodeID != "0")
        {
            NV_CoQuanHanhChinh_ChiTiet myDetail = new NV_CoQuanHanhChinh_ChiTiet();
            myDetail = Sys_Common.NV_CoQuanHanhChinh.GetById(int.Parse(nodeID));

            SetData(myDetail);
        }
    }


    [DirectMethod]
    public static string NodeLoad(string nodeID)
    {
        Ext.Net.TreeNodeCollection nodes = new Ext.Net.TreeNodeCollection();

        DataTable dt = Sys_Common.NV_CoQuanHanhChinh.GetByParent(nodeID);
        if (dt != null && dt.Rows.Count > 0 && !string.IsNullOrEmpty(nodeID))
        {
            foreach (DataRow item in dt.Rows)
            {
                DataTable dtXa = Sys_Common.NV_CoQuanHanhChinh.GetByParent(item["CoQuanID"].ToString());
                if (dtXa != null && dtXa.Rows.Count > 0)
                {
                    AsyncTreeNode asyncNode = new AsyncTreeNode();
                    asyncNode.Text = item["TenCoQuan"].ToString();
                    asyncNode.NodeID = item["CoQuanID"].ToString();
                    nodes.Add(asyncNode);
                }
                else
                {
                    Ext.Net.TreeNode treeNode = new Ext.Net.TreeNode();
                    treeNode.Text = item["TenCoQuan"].ToString();
                    treeNode.NodeID = item["CoQuanID"].ToString();
                    treeNode.Leaf = true;
                    nodes.Add(treeNode);
                }
            }
        }
        return nodes.ToJson();
    }

    protected void stParent_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        Load_Data_For_DM_Cha_Combobox();
    }

    #region supported method

    private bool FormValidate()
    {
        if (this.txtTenCoQuan.Text.ToString() == "")
        {
            X.Msg.Alert("Thông báo", "Thiếu thông tin ", new JFunction { Fn = "" }).Show();
            return false;
        }
        return true;
    }

    private void Load_Data_For_DM_Cha_Combobox()
    {
        DataTable datasource = Sys_Common.NV_CoQuanHanhChinh.GetDataToCombo();
        DataRow dr = datasource.NewRow();
        dr["CoQuanID"] = 0;
        dr["TenCoQuan"] = "Chọn cơ quan quản lý";
        datasource.Rows.InsertAt(dr, 0);
        stParent.DataSource = datasource;
        stParent.DataBind();
    }

    private void SetData(NV_CoQuanHanhChinh_ChiTiet myDetail)
    {
        btnUpdate.Text = "Cập nhật";
        btnUpdate.Icon = Icon.ApplicationEdit;

        hdCoQuanID.Value = myDetail.CoQuanID;
        txtTenCoQuan.Value = myDetail.TenCoQuan;
        cbCoQuanQuanLy.SelectedItem.Value = myDetail.CoQuanQuanLy;
        txtCapCoQuan.Value = myDetail.CapCoQuan;
        txtChucNang.Value = myDetail.ChucNang;
        txtLichSu.Value = myDetail.LichSu;
        txtDiaChi.Value = myDetail.DiaChi;
        txtMoTa.Value = myDetail.Mota;

        cbxTinh.SelectedItem.Value = myDetail.ThuocTinh;

        Load_Data_For_Huyen_Combobox(myDetail.ThuocTinh);
        cbxHuyen.SelectedItem.Value = myDetail.ThuocHuyen;
        string a = cbxHuyen.Text;
        Load_Data_For_Xa_Combobox(myDetail.ThuocHuyen);
        cbxXa.SelectedItem.Value = myDetail.ThuocXa;
    }

    private void ClearData()
    {
        btnUpdate.Text = "Thêm mới";
        btnUpdate.Icon = Icon.Add;

        hdCoQuanID.Value = "";
        txtTenCoQuan.Value = "";
        txtCapCoQuan.Value = "";
        txtChucNang.Value = "";
        txtLichSu.Value = "";
        txtDiaChi.Value = "";
        txtMoTa.Value = "";
        cbxTinh.Text = "";
        cbxHuyen.Text = "";
        cbxXa.Text = "";
        cbCoQuanQuanLy.SelectedIndex = -1;
    }

    private void Load_Data_For_Tinh_Combobox()
    {
        DataTable datasource = Sys_Common.HT_DM_TINH.Danh_Sach();
        stTinh.DataSource = datasource;
        stTinh.DataBind();
    }

    private void Load_Data_For_Huyen_Combobox(string maTinh)
    {
        DataTable datasource = Sys_Common.HT_DM_HUYEN.Lay_Boi_HT_DM_Tinh(maTinh);
        stHuyen.DataSource = datasource;
        stHuyen.DataBind();
    }

    private void Load_Data_For_Xa_Combobox(string maHuyen)
    {
        DataTable datasource = Sys_Common.HT_DM_XA.Lay_Boi_HT_DM_Huyen(maHuyen);
        stXa.DataSource = datasource;
        stXa.DataBind();
    }
    #endregion

    protected void stHuyen_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        Load_Data_For_Huyen_Combobox(cbxTinh.SelectedItem.Value);
    }

    protected void stXa_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        Load_Data_For_Xa_Combobox(cbxHuyen.SelectedItem.Value);
    }
}

