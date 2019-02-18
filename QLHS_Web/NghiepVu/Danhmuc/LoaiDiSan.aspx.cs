using Ext.Net;
using QLHS_Logic;
using QLHS_Logic.NV;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NghiepVu_Danhmuc_Loaidisan : System.Web.UI.Page
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
            Role role = getRole();
            hdRole.Value = new JavaScriptSerializer().Serialize(role);
        }
        X.Msg.AddScript("#{TreePanel1}.expandAll();");
    }

    [DirectMethod]
    public void Delete(string value)
    {
        int loaiDiSanId = int.Parse(value);

        NV_DM_LoaiDiSan_ChiTiet loaiDiSan = Sys_Common.NV_DM_LoaiDiSan.GetById(loaiDiSanId);
        if (loaiDiSan != null)
        {
            Sys_Common.NV_DM_LoaiDiSan.Xoa(loaiDiSanId);

            NV_Log_ChiTiet log = createLog(loaiDiSanId, "delete");
            Sys_Common.NV_Log.them(log);

            X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
            TreePanel1.ReloadAsyncNode(cbParent.SelectedItem.Value, null);
            ClearData();
            X.AddScript("#{stParent}.reload()");
        }
    }

    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        Role role = getRole();
        if (hdLoaiID.Text != "" && !role.Duoc_Sua)
        {
            X.Msg.Alert("Thông báo", "Bạn không có quyền sửa bản ghi !!!", new JFunction { Fn = "" }).Show();
            return;
        }
        if (string.IsNullOrEmpty(hdLoaiID.Text) && !role.Duoc_Nhap)
        {
            X.Msg.Alert("Thông báo", "Bạn không có quyền thêm bản ghi !!!", new JFunction { Fn = "" }).Show();
            return;
        }
        if (FormValidate())
        {
            NV_DM_LoaiDiSan_ChiTiet model = new NV_DM_LoaiDiSan_ChiTiet();
            model.TenLoai = txtTenLoai.Text;
            model.MaLoai = txtMaLoai.Text;
            model.EngName = txtEngName.Text;
            try
            {
                model.ParentID = int.Parse(cbParent.SelectedItem.Value);
                model.Loai = 0;
            }
            catch
            {
                model.ParentID = 0;
                model.Loai = int.Parse(cbLoai.Value.ToString());
            }
            model.GhiChu = txtGhiChu.Text;
            model.Stt = Sys_Common.NV_DM_LoaiDiSan.taoStt(txtSoThuTu.Text, model.ParentID);
            bool check;
            NV_Log_ChiTiet log;
            try
            {
                model.LoaiID = int.Parse(hdLoaiID.Text);
                check=Sys_Common.NV_DM_LoaiDiSan.update(model);

                log = createLog(model.LoaiID, "update");
            }
            catch
            {
                int id = 0;
                check = Sys_Common.NV_DM_LoaiDiSan.them(model,out id);
                log = createLog(id, "insert");
            }
            if (check)
            {
                X.Msg.Alert("Thông báo", "Đã cập nhật thành công !!!", new JFunction { Fn = "" }).Show();
                TreePanel1.ReloadAsyncNode(cbParent.SelectedItem.Value, null);
                ClearData();
                X.AddScript("#{stParent}.reload()");
            }

        }

    }
    protected void btnCancel_Click(object sender, DirectEventArgs e)
    {
        ClearData();
    }


    [DirectMethod]
    public static string NodeLoad(string nodeID)
    {
        Ext.Net.TreeNodeCollection nodes = new Ext.Net.TreeNodeCollection();

        if (!string.IsNullOrEmpty(nodeID))
        {
            DataTable dt = Sys_Common.NV_DM_LoaiDiSan.GetByParent(nodeID);
            if (dt != null && dt.Rows.Count > 0 && !string.IsNullOrEmpty(nodeID))
            {
                foreach (DataRow item in dt.Rows)
                {
                    DataTable dtXa = Sys_Common.NV_DM_LoaiDiSan.GetByParent(item["LoaiID"].ToString());
                    if (dtXa != null && dtXa.Rows.Count > 0)
                    {
                        AsyncTreeNode asyncNode = new AsyncTreeNode();
                        asyncNode.Text = item["TenLoai"].ToString();
                        asyncNode.NodeID = item["LoaiID"].ToString();
                        nodes.Add(asyncNode);
                    }
                    else
                    {
                        Ext.Net.TreeNode treeNode = new Ext.Net.TreeNode();
                        treeNode.Text = item["TenLoai"].ToString();
                        treeNode.NodeID = item["LoaiID"].ToString();
                        treeNode.Leaf = true;
                        nodes.Add(treeNode);
                    }
                }
            }
        }

        return nodes.ToJson();
    }

    [DirectMethod]
    public void GetInfo(string nodeID)
    {
        if (nodeID != "0")
        {
            Role role = getRole();
            if (role.Duoc_Sua)
            {
                NV_DM_LoaiDiSan_ChiTiet myDetail = new NV_DM_LoaiDiSan_ChiTiet();
                myDetail = Sys_Common.NV_DM_LoaiDiSan.GetById(int.Parse(nodeID));

                SetData(myDetail);
            }
            else
            {
                X.Msg.Alert("Thông báo", "Bạn không có quyền sửa bản ghi !!!", new JFunction { Fn = "" }).Show();
            }
        }
    }

    private bool FormValidate()
    {
        if (string.IsNullOrEmpty(txtMaLoai.Text.Trim()) || string.IsNullOrEmpty(txtTenLoai.Text.Trim()) || (cbParent.Value.ToString() == "0" && cbLoai.Value == null))
        {
            X.Msg.Alert("Thông báo", "Thiếu thông tin ", new JFunction { Fn = "" }).Show();
            return false;
        }
        return true;
    }

    private void SetData(NV_DM_LoaiDiSan_ChiTiet myDetail)
    {
        btnUpdate.Text = "Cập nhật";
        btnUpdate.Icon = Icon.ApplicationEdit;

        txtMaLoai.Value = myDetail.MaLoai;
        txtGhiChu.Value = myDetail.GhiChu;
        txtSoThuTu.Text = myDetail.Stt.ToString();
        hdLoaiID.Value = myDetail.LoaiID;
        txtTenLoai.Value = myDetail.TenLoai;
        txtEngName.Value = myDetail.EngName;
        cbParent.SelectedItem.Value = myDetail.ParentID.ToString();
        cbLoai.Value = myDetail.Loai.ToString();
    }

    private void ClearData()
    {
        btnUpdate.Text = "Thêm mới";
        btnUpdate.Icon = Icon.Add;

        txtMaLoai.Value = "";
        txtGhiChu.Value = "";
        hdLoaiID.Value = "";
        txtSoThuTu.Value = "";
        txtTenLoai.Value = "";
        txtEngName.Value = "";
        cbParent.SelectedIndex = -1;
        cbLoai.Value = "";
    }

    protected void stParent_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        Load_Data_For_DM_Cha_Combobox();
    }

    #region Supported method
    private void Load_Data_For_DM_Cha_Combobox()
    {
        DataTable dt = Sys_Common.NV_DM_LoaiDiSan.getDataCombo();
        DataRow dr = dt.NewRow();
        dr["LoaiID"] = 0;
        dr["TenLoai"] = "Danh mục gốc";
        dt.Rows.InsertAt(dr, 0);
        stParent.DataSource = dt;
        stParent.DataBind();
    }
    private Role getRole()
    {
        string maForm = Request.QueryString["cn"].ToString();
        int maND = int.Parse(Session["G_Ma_Nguoi_Dung"].ToString());
        Role role = Sys_Common.HT_NGUOI_DUNG_VAI_TRO.getRoleUserByForm(maND, maForm);
        return role;
    }
    private NV_Log_ChiTiet createLog(int id, string thaotac)
    {
        int maND = int.Parse(Session["G_Ma_Nguoi_Dung"].ToString());
        string maForm = Request.QueryString["cn"].ToString();
        NV_Log_ChiTiet log = new NV_Log_ChiTiet(maND, maForm);
        log.ThaoTac = thaotac;
        log.IDBanGhi = id;
        return log;
    }
    #endregion
}