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
using Models;
using System.Web.Script.Serialization;
public partial class NghiepVu_Danhmuc_Menu : System.Web.UI.Page
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
            Initialization();
        }
        X.Msg.AddScript("#{TreePanel1}.expandAll();");
    }
    private void Initialization()
    {
        Role role = getRole();
        hdRole.Value = new JavaScriptSerializer().Serialize(role);
        stChucnang.DataSource = Sys_Common.NV_ChucNang.GetAll();
        stVitri.DataSource = Sys_Common.NV_Vitri.GetAll();
        DataBind();
        try
        {
            cbVitri.SelectedItem.Value = Session["Vitri"].ToString();
        }
        catch
        {
            cbVitri.SelectedIndex = 0;
            Session["Vitri"] = "1";
        }
        try
        {
            cmbLang.SelectedItem.Value = Session["Lang"].ToString();
        }
        catch
        {
            cmbLang.SelectedIndex = 0;
            Session["Lang"] = "vi";
        }
    }
    [DirectMethod]
    public static string NodeLoad(string nodeID)
    {
        Ext.Net.TreeNodeCollection nodes = new Ext.Net.TreeNodeCollection();

        if (!string.IsNullOrEmpty(nodeID))
        {
            string vitri = HttpContext.Current.Session["Vitri"].ToString();
            string lang = HttpContext.Current.Session["Lang"].ToString();
            DataTable dt = Sys_Common.NV_Menu.GetByParent(nodeID, vitri, lang);
            if (dt != null && dt.Rows.Count > 0 && !string.IsNullOrEmpty(nodeID))
            {
                foreach (DataRow item in dt.Rows)
                {
                    DataTable dtXa = Sys_Common.NV_Menu.GetByParent(item["MenuID"].ToString(), vitri, lang);
                    if (dtXa != null && dtXa.Rows.Count > 0)
                    {
                        AsyncTreeNode asyncNode = new AsyncTreeNode();
                        asyncNode.Text = item["TenMenu"].ToString();
                        asyncNode.NodeID = item["MenuID"].ToString();
                        nodes.Add(asyncNode);
                    }
                    else
                    {
                        Ext.Net.TreeNode treeNode = new Ext.Net.TreeNode();
                        treeNode.Text = item["TenMenu"].ToString();
                        treeNode.NodeID = item["MenuID"].ToString();
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
                NV_Menu_ChiTiet myDetail = new NV_Menu_ChiTiet();
                myDetail = Sys_Common.NV_Menu.GetById(int.Parse(nodeID));

                SetData(myDetail);
            }
            else
            {
                X.Msg.Alert("Thông báo", "Bạn không có quyền sửa bản ghi !!!", new JFunction { Fn = "" }).Show();
            }
        }
    }
    protected void osdMenuCha_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        (this.stMenucha.Proxy[0] as PageProxy).Total = (int)e.OutputParameters["Count"];
    }
    protected void stMenucha_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            this.osdMenuCha.SelectParameters["id"].DefaultValue = "0";
            this.osdMenuCha.SelectParameters["chucnang"].DefaultValue = cmbChucnang.SelectedItem.Value;
            this.osdMenuCha.SelectParameters["vitri"].DefaultValue = Session["Vitri"].ToString();
            this.osdMenuCha.SelectParameters["lang"].DefaultValue = Session["Lang"].ToString();
            this.osdMenuCha.DataBind();
        }
        catch (Exception ex) { }
    }
    protected void btnDelete_Click(object sender, DirectEventArgs e)
    {
        if (hdMenuID.Value != null && hdMenuID.Value.ToString() != "" && hdMenuID.Value.ToString() != "0")
        {
            int menuID = int.Parse(hdMenuID.Value.ToString());
            Sys_Common.NV_Menu.Xoa(menuID);

            NV_Log_ChiTiet log = createLog(menuID, "delete");
            Sys_Common.NV_Log.them(log);
            ClearData();

            TreePanel1.ReloadAsyncNode(cbParent.SelectedItem.Value, null);

            X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
            X.AddScript("#{stMenucha}.reload()");
        }
    }

    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        Role role = getRole();
        if (hdMenuID.Text != "" && !role.Duoc_Sua)
        {
            X.Msg.Alert("Thông báo", "Bạn không có quyền sửa bản ghi !!!", new JFunction { Fn = "" }).Show();
            return;
        }
        if (string.IsNullOrEmpty(hdMenuID.Text) && !role.Duoc_Nhap)
        {
            X.Msg.Alert("Thông báo", "Bạn không có quyền thêm bản ghi !!!", new JFunction { Fn = "" }).Show();
            return;
        }
        if (FormValidate())
        {
            NV_Menu_ChiTiet model = new NV_Menu_ChiTiet();
            model.TenMenu = txtTenMenu.Text;
            model.Lang = cmbLang.Value.ToString();
            model.MetaDescription = txtDescription.Text;
            try
            {
                model.ChucNangID = int.Parse(cmbChucnang.Value.ToString());
            }
            catch
            {
                X.Msg.Alert("Thông báo", "Bạn chưa chọn chức năng cho menu này !!!", new JFunction { Fn = "" }).Show();
                return;
            }
            model.Duyet = ckbDuyet.Checked;
            model.NoiBat = ckbNoiBat.Checked;
            model.MetaKeyword = txtKeyword.Text;
            model.PageTitle = txtPageTitle.Text;
            model.Mota = txtMota.Text;

            model.ParentID = cbParent.Value != null ? int.Parse(cbParent.Value.ToString()) : 0;
            model.Url = txtUrl.Text;
            model.TenUrl = txtTenUrl.Text != "" ? StringUtil.RemoveSign4VietnameseString(txtTenUrl.Text).Replace(" ", "-") : StringUtil.RemoveSign4VietnameseString(txtTenMenu.Text).Replace(" ", "-");
            model.Level = Sys_Common.NV_Menu.getLevel(model.ParentID);
            model.HinhAnh = int.Parse(ImageOnly.ImageID.ToString());
            model.Vitri = int.Parse(cbVitri.Value.ToString());
            try
            {
                model.Stt = int.Parse(txtThuTu.Text);
            }
            catch
            {
                model.Stt = 1;
            }
            NV_Log_ChiTiet log;
            bool check;
            if (hdMenuID.Text != "")
            {
                model.MenuID = int.Parse(hdMenuID.Text);
                check = Sys_Common.NV_Menu.update(model);

                log = createLog(model.MenuID, "update");
            }
            else
            {
                int id = 0;
                check = Sys_Common.NV_Menu.them(model, out id);
                log = createLog(id, "insert");
            }
            if (check)
            {
                Sys_Common.NV_Log.them(log);
                X.Msg.Alert("Thông báo", "Đã cập nhật thành công !!!", new JFunction { Fn = "" }).Show();
                TreePanel1.ReloadAsyncNode(cbParent.SelectedItem.Value, null);
                ClearData();
                X.AddScript("#{stMenucha}.reload()");
            }
        }
    }
    protected void btnCancel_Click(object sender, DirectEventArgs e)
    {
        ClearData();
    }

    private void SetData(NV_Menu_ChiTiet model)
    {
        btnUpdate.Text = "Cập nhật";
        btnUpdate.Icon = Icon.ApplicationEdit;

        hdMenuID.Text = model.MenuID.ToString();
        txtTenMenu.Text = model.TenMenu;
        cmbLang.Value = model.Lang;
        cmbChucnang.Value = model.ChucNangID;
        cbParent.Value = model.ParentID;
        ckbDuyet.Checked = model.Duyet;
        ckbNoiBat.Checked = model.NoiBat;
        txtPageTitle.Text = model.PageTitle;
        txtDescription.Text = model.MetaDescription;
        txtKeyword.Text = model.MetaKeyword;
        txtUrl.Text = model.Url;
        txtTenUrl.Text = model.TenUrl;
        ImageOnly.ImageID = model.HinhAnh.ToString();
        txtMota.Text = model.Mota;
        txtThuTu.Text = model.Stt.ToString();
    }
    private void ClearData()
    {
        btnUpdate.Text = "Thêm mới";
        btnUpdate.Icon = Icon.Add;

        hdMenuID.Text = "";
        txtUrl.Text = "";
        txtTenMenu.Text = "";
        cmbLang.SelectedIndex = 0;
        txtTenUrl.Text = "";
        cmbChucnang.Value = "";
        cbParent.Value = "";
        ckbDuyet.Checked = false;
        ckbNoiBat.Checked = false;
        txtPageTitle.Text = "";
        txtDescription.Text = "";
        txtKeyword.Text = "";
        txtThuTu.Text = "1";
        ImageOnly.ImageID = "0";

    }
    private bool FormValidate()
    {
        if (txtTenMenu.Text.ToString() == "" || cmbChucnang.Value == "")
        {
            X.Msg.Alert("Thông báo", "Thiếu thông tin ", new JFunction { Fn = "" }).Show();
            return false;
        }
        return true;
    }

    protected void cbVitri_Change(object sender, DirectEventArgs e)
    {
        Session["Vitri"] = cbVitri.SelectedItem.Value;
        Session["Lang"] = cmbLang.SelectedItem.Value;
        TreePanel1.ReloadAsyncNode("0", null);
        ClearData();
        X.AddScript("#{stMenucha}.reload()");
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
}