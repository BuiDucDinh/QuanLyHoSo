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

public partial class NghiepVu_Hoatdongvanhoa_DanhSach : System.Web.UI.Page
{

    [DirectMethod]
    public static string NodeLoadAddress(string nodeID)
    {
        Ext.Net.TreeNodeCollection nodes = new Ext.Net.TreeNodeCollection();

        DataTable dt;
        if (nodeID != "0")
        {
            nodeID = nodeID.Substring(1, nodeID.Length - 1);
            dt = Sys_Common.HT_DM_HUYEN.Lay_Boi_HT_DM_Tinh(nodeID);
            if (dt != null && dt.Rows.Count > 0 && !string.IsNullOrEmpty(nodeID))
            {
                foreach (DataRow item in dt.Rows)
                {
                    string maHuyen = item["Ma_Huyen"].ToString();
                    string tenHuyen = item["Ten_Huyen"].ToString();
                    DataTable dtXa = Sys_Common.HT_DM_XA.Lay_Boi_HT_DM_Huyen(maHuyen);
                    if (dtXa != null && dtXa.Rows.Count > 0)
                    {
                        AsyncTreeNode asyncNode = new AsyncTreeNode();
                        asyncNode.Text = tenHuyen;
                        asyncNode.NodeID = "H" + maHuyen;
                        asyncNode.Checked = ThreeStateBool.False;
                        nodes.Add(asyncNode);
                    }
                    else
                    {
                        Ext.Net.TreeNode treeNode = new Ext.Net.TreeNode();
                        treeNode.Text = tenHuyen;
                        treeNode.NodeID = "H" + maHuyen;
                        treeNode.Leaf = true;
                        treeNode.Checked = ThreeStateBool.False;
                        nodes.Add(treeNode);
                    }
                }
            }
            else
            {
                dt = Sys_Common.HT_DM_XA.Lay_Boi_HT_DM_Huyen(nodeID);
                foreach (DataRow item in dt.Rows)
                {
                    Ext.Net.TreeNode treeNode = new Ext.Net.TreeNode();
                    treeNode.Text = item["Ten_Xa"].ToString();
                    treeNode.NodeID = "X" + item["Ma_Xa"].ToString();
                    treeNode.Leaf = true;
                    treeNode.Checked = ThreeStateBool.False;
                    nodes.Add(treeNode);
                }
            }
        }
        else
        {
            dt = Sys_Common.HT_DM_TINH.Danh_Sach();
            if (dt != null && dt.Rows.Count > 0 && !string.IsNullOrEmpty(nodeID))
            {
                foreach (DataRow item in dt.Rows)
                {
                    string maTinh = item["Ma_Tinh"].ToString();
                    string tenTinh = item["Ten_Tinh"].ToString();
                    DataTable dtHuyen = Sys_Common.HT_DM_HUYEN.Lay_Boi_HT_DM_Tinh(maTinh);
                    if (dtHuyen != null && dtHuyen.Rows.Count > 0)
                    {
                        AsyncTreeNode asyncNode = new AsyncTreeNode();
                        asyncNode.Text = tenTinh;
                        asyncNode.NodeID = "T" + maTinh;
                        asyncNode.Checked = ThreeStateBool.False;
                        nodes.Add(asyncNode);
                    }
                    else
                    {
                        Ext.Net.TreeNode treeNode = new Ext.Net.TreeNode();
                        treeNode.Text = tenTinh;
                        treeNode.NodeID = "T" + maTinh;
                        treeNode.Leaf = true;
                        treeNode.Checked = ThreeStateBool.False;
                        nodes.Add(treeNode);
                    }
                }
            }
            else
            {
                dt = Sys_Common.HT_DM_HUYEN.Lay_Boi_HT_DM_Tinh(nodeID);
                foreach (DataRow item in dt.Rows)
                {
                    Ext.Net.TreeNode treeNode = new Ext.Net.TreeNode();
                    treeNode.Text = "H" + item["Ten_Huyen"].ToString();
                    treeNode.NodeID = item["Ma_Huyen"].ToString();
                    treeNode.Leaf = true;
                    treeNode.Checked = ThreeStateBool.False;
                    nodes.Add(treeNode);
                }
            }
        }
        return nodes.ToJson();
    }
    [DirectMethod]
    public static string NodeLoadType(string nodeID)
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
                        asyncNode.Checked = ThreeStateBool.False;
                        nodes.Add(asyncNode);
                    }
                    else
                    {
                        Ext.Net.TreeNode treeNode = new Ext.Net.TreeNode();
                        treeNode.Text = item["TenLoai"].ToString();
                        treeNode.NodeID = item["LoaiID"].ToString();
                        treeNode.Leaf = true;
                        treeNode.Checked = ThreeStateBool.False;
                        nodes.Add(treeNode);
                    }
                }
            }
        }

        return nodes.ToJson();
    }

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

        //X.Msg.AddScript("#{TreePanel1}.expandAll();");
        X.Msg.AddScript("#{TreePanel2}.expandAll();");
    }

    [DirectMethod]
    public void Command(string command, string value)
    {
        int ID = int.Parse(value);
        string maForm = Request.QueryString["cn"].ToString();
        NV_VanBan_ChiTiet bv = Sys_Common.NV_VanBan.GetById(ID);
        if (command == "Delete")
        {
            Sys_Common.NV_HoatDongVanHoa.Xoa(ID);
            NV_Log_ChiTiet log = createLog(ID, "delete");
            Sys_Common.NV_Log.them(log);
            X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
            X.Msg.AddScript("#{dsNV_Hoatdongvanhoa}.reload();");
        }
        else if (command == "Edit")
        {
            this.winDetails.AutoLoad.Url = "~/NghiepVu/Hoatdongvanhoa/CapNhatHDVH.aspx?id=" + ID + "&cn=" + maForm;
            this.winDetails.Icon = Icon.ApplicationEdit;
            this.winDetails.Title = "Cập nhật hoạt động văn hóa";
            this.winDetails.AutoLoad.Mode = LoadMode.IFrame;
            this.winDetails.Render(this.Form);
            this.winDetails.Show();
        }
        else if (command == "Active")
        {
            NV_HoatDongVanHoa_ChiTiet hd = Sys_Common.NV_HoatDongVanHoa.GetById(ID);
            hd.Duyet = !hd.Duyet;
            bool check = Sys_Common.NV_HoatDongVanHoa.Update(hd);
            if (check)
            {
                string thaotac = hd.Duyet ? "active" : "unactive";
                NV_Log_ChiTiet log = createLog(ID, thaotac);
                Sys_Common.NV_Log.them(log);
                X.Msg.AddScript("#{dsNV_Hoatdongvanhoa}.reload();");
            }
        }
    }
    private void Initialization()
    {
        Role role = getRole();
        hdRole.Value = new JavaScriptSerializer().Serialize(role);
        stDiSan.DataSource = Sys_Common.LoadCombo("DiSan");
        stCoQuan.DataSource = Sys_Common.LoadCombo("CoQuan");

        DataBind();
    }
    protected void odsNV_Hoatdongvanhoa_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        (this.dsNV_Hoatdongvanhoa.Proxy[0] as PageProxy).Total = (int)e.OutputParameters["Count"];
    }
    protected void dsNV_Hoatdongvanhoa_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        this.dsNV_Hoatdongvanhoa_Obj.SelectParameters["Start"].DefaultValue = (e.Start + 1).ToString();
        this.dsNV_Hoatdongvanhoa_Obj.SelectParameters["Limit"].DefaultValue = (e.Limit + e.Start).ToString();
        string address = hdAddress.Text;
        string type = hdType.Text;
        string where = "Lang='" + cmbLang.Value.ToString() + "'";
        if (address != "")
        {
            where += " and '" + address + "' like '%,' + ThuocTinh + ',%' or '" + address + "' like '%,H'+ ThuocHuyen + ',%' or '" + address + "' like '%,X' + ThuocXa +',%'";
        }
        if (type != "")
        {
            where += " and LoaiDiSan in (" + type + ")";
        }
        if (cmbDiSan.Value != null && !string.IsNullOrEmpty(cmbDiSan.Value.ToString()))
        {
            where += " and DiSanID=" + cmbDiSan.Value.ToString();
        }
        if (cmbDonvitochuc.Value != null && !string.IsNullOrEmpty(cmbDonvitochuc.Value.ToString()))
        {
            where += " and DonViToChuc=" + cmbDonvitochuc.Value.ToString();
        }
        if (!string.IsNullOrEmpty(txtTenhoatdong.Text))
        {
            where += " and (TenGoi like '%" + txtTenhoatdong.Text + "%' or TenGoiKhac like '%" + txtTenhoatdong.Text + "%')";
        }
        //string a = "(select *,(select TenAnh from Image i where i.ImageID=hd.HinhAnh) as AnhDaiDien from HoatDongVanHoa hd Where " + where + ") as A";
        this.dsNV_Hoatdongvanhoa_Obj.SelectParameters["WhereString"].DefaultValue = "(select *,(select TenAnh from Image i where i.ImageID=hd.HinhAnh) as AnhDaiDien from HoatDongVanHoa hd Where Lang='" + cmbLang.Value.ToString() + "') as A";
        this.dsNV_Hoatdongvanhoa_Obj.SelectParameters["SortString"].DefaultValue = e.Sort + " " + e.Dir;
        this.dsNV_Hoatdongvanhoa_Obj.DataBind();
    }
    protected void gvHoatdong_DonViTuBo_DbClick(object sender, DirectEventArgs e)
    {
        Role role = getRole();
        if (role.Duoc_Sua)
        {
            RowSelectionModel sm = gvHoatdong.SelectionModel.Primary as RowSelectionModel;
            string maForm = Request.QueryString["cn"].ToString();
            foreach (SelectedRow row in sm.SelectedRows)
            {
                this.winDetails.AutoLoad.Url = "~/NghiepVu/Hoatdongvanhoa/CapNhatHDVH.aspx?enable=1&id=" + row.RecordID + "&cn=" + maForm;
                this.winDetails.AutoLoad.Mode = LoadMode.IFrame;
                this.winDetails.Render(this.Form);
                this.winDetails.Show();
                this.winDetails.Height = 800;
                break;
            }
        }
        else
        {
            X.Msg.Alert("Thông báo", "Bạn không có quyền sửa bản ghi !!!", new JFunction { Fn = "" }).Show();
        }
    }
    protected void btnLoc_Click(object sender, DirectEventArgs e)
    {
        X.Msg.AddScript("#{dsNV_Hoatdongvanhoa}.reload();");
    }
    protected void btnCancel_Click(object sender, DirectEventArgs e)
    {

    }
    protected void btnExport_Click(object sender, DirectEventArgs e) { }
    protected void btnDelete_Click(object sender, DirectEventArgs e)
    {
        string maForm = Request.QueryString["cn"].ToString();
        Role role = getRole();
        if (role.Duoc_Sua)
        {
            RowSelectionModel sm = gvHoatdong.SelectionModel.Primary as RowSelectionModel;
            foreach (SelectedRow row in sm.SelectedRows)
            {
                int id = int.Parse(row.RecordID);
                Sys_Common.NV_HoatDongVanHoa.Xoa(id);
                NV_Log_ChiTiet log = createLog(id, "delete");
                Sys_Common.NV_Log.them(log);
            }
            sm.SelectedRows.Clear();
            sm.UpdateSelection();
            X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
            X.Msg.AddScript("#{dsNV_Hoatdongvanhoa}.reload();");
        }
        else
        {
            X.Msg.Alert("Thông báo", "Bạn không có quyền sửa bản ghi !!!", new JFunction { Fn = "" }).Show();
        }
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        string maForm = Request.QueryString["cn"].ToString();
        this.winDetails.AutoLoad.Url = "/NghiepVu/Hoatdongvanhoa/CapNhatHDVH.aspx?enable=1&id=0&cn=" + maForm;
        this.winDetails.AutoLoad.Mode = LoadMode.IFrame;
        this.winDetails.Render(this.Form);
        this.winDetails.Show();
        this.winDetails.Height = 800;
        this.winDetails.Title = "Thêm mới hoạt động văn hóa";
    }
    protected void btnShow_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gvHoatdong.SelectionModel.Primary as RowSelectionModel;
        int id = int.Parse(sm.SelectedRows[0].RecordID);
        this.winDetails.AutoLoad.Url = "~/NghiepVu/Hoatdongvanhoa/CapNhatHDVH.aspx?enable=0&id=" + id;
        this.winDetails.Icon = Icon.ApplicationGet;
        this.winDetails.Title = "Thông tin hoạt động văn hóa";
        this.winDetails.AutoLoad.Mode = LoadMode.IFrame;
        this.winDetails.Render(this.Form);
        this.winDetails.Show();
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