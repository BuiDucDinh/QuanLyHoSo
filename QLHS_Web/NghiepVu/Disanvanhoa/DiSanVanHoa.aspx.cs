using Ext.Net;
using QLHS_Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLHS_Logic.NV;
using System.Xml;
using System.Xml.Xsl;
using Models;
public partial class NghiepVu_Disanvanhoa_DisanPhiVatThe : System.Web.UI.Page
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
            //Load_Data_For_DM_Cha_Combobox();
        }
        //X.Msg.AddScript("#{TreePanel1}.expandAll();");
        X.Msg.AddScript("#{TreePanel2}.expandAll();");
    }
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
                        asyncNode.Icon = Icon.House;
                        asyncNode.Text = tenHuyen;
                        asyncNode.NodeID = "H" + maHuyen;
                        asyncNode.Checked = ThreeStateBool.False;
                        nodes.Add(asyncNode);
                    }
                    else
                    {
                        Ext.Net.TreeNode treeNode = new Ext.Net.TreeNode(tenHuyen, Icon.House);//new Ext.Net.TreeNode(Icon.House);
                        //treeNode.Text = tenHuyen;
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
                        asyncNode.Icon = Icon.HouseGo;
                        asyncNode.Text = tenTinh;
                        asyncNode.NodeID = "T" + maTinh;
                        asyncNode.Checked = ThreeStateBool.False;
                        nodes.Add(asyncNode);
                    }
                    else
                    {
                        Ext.Net.TreeNode treeNode = new Ext.Net.TreeNode(tenTinh, Icon.HouseGo);
                        //treeNode.Text = tenTinh;
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
                    Ext.Net.TreeNode treeNode = new Ext.Net.TreeNode(item["Ten_Huyen"].ToString(), Icon.House);
                    //treeNode.Text = item["Ten_Huyen"].ToString();
                    treeNode.NodeID = "H" + item["Ma_Huyen"].ToString();
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
                        Ext.Net.TreeNode treeNode = new Ext.Net.TreeNode(item["TenLoai"].ToString(), Icon.StarGold);
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

    protected void btnCancel_Click(object sender, DirectEventArgs e)
    {
        txtTenDiSan.Text = "";
        dfDenNgay.Text = "";
        dfTuNgay.Text = "";
        ckbNguoiTao.Checked = false;
        cbCapDS.Value = "";
        cbNgonNgu.Value = "vi";
        X.Msg.AddScript("#{stDisan}.reload();");

    }
    protected void btnExport_Click(object sender, DirectEventArgs e)
    {
        string json = e.ExtraParams["data"].ToString();
        RowSelectionModel sm = gvDiSan.SelectionModel.Primary as RowSelectionModel;
        if (sm.SelectedRows.Count > 0)
        {
            foreach (SelectedRow row in sm.SelectedRows)
            {
                int id = int.Parse(row.RecordID);
            }
        }
        else
        {
            StoreSubmitDataEventArgs eSubmit = new StoreSubmitDataEventArgs(json, null);
            XmlNode xml = eSubmit.Xml;

            this.Response.Clear();
            this.Response.ContentType = "application/vnd.ms-excel";
            this.Response.AddHeader("Content-Disposition", "attachment; filename=submittedData.xls");
            XslCompiledTransform xtExcel = new XslCompiledTransform();
            xtExcel.Load(Server.MapPath("/NghiepVu/Resources/Excel.xsl"));
            xtExcel.Transform(xml, null, this.Response.OutputStream);
            this.Response.End();
        }

        NV_Log_ChiTiet log = createLog(0, "export");
        Sys_Common.NV_Log.them(log);
    }
    protected void btnExportDeTail_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gvDiSan.SelectionModel.Primary as RowSelectionModel;
        string maForm = Request.QueryString["cn"].ToString();

        int id = int.Parse(sm.SelectedRows[0].RecordID);
        NV_Log_ChiTiet log = createLog(id, "exportDetail");
        Sys_Common.NV_Log.them(log);
        this.wdDetail.Title = "In phiếu chi tiết di sản";
        this.wdDetail.AutoLoad.Url = "~/NghiepVu/ThongKe/ReportDiVat.aspx?id=" + id + "&cn=" + maForm;
        this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
        this.wdDetail.Render(this.Form);
        this.wdDetail.Show();
    }
    protected void btnDelete_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gvDiSan.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            int id = int.Parse(row.RecordID);
            Sys_Common.NV_DiSanVanHoa.Xoa(id);
            NV_Log_ChiTiet log = createLog(id, "delete");
            Sys_Common.NV_Log.them(log);
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
        X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
        X.Msg.AddScript("#{stDisan}.reload();");
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        string maForm = Request.QueryString["cn"].ToString();
        this.wdDetail.AutoLoad.Url = "~/NghiepVu/Disanvanhoa/CapNhatDSVanHoa.aspx?enable=1&cn=" + maForm;
        this.wdDetail.Icon = Icon.Add;
        this.wdDetail.Title = "Thêm mới di sản văn hóa";
        this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
        this.wdDetail.Render(this.Form);
        this.wdDetail.Show();
    }

    protected void btnShow_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gvDiSan.SelectionModel.Primary as RowSelectionModel;
        int id = 0;// int.Parse(sm.SelectedRows[0].RecordID);

        foreach (SelectedRow row in sm.SelectedRows)
        {
            id = int.Parse(row.RecordID);
        }

            NV_DiSanVanHoa_ChiTiet ds = Sys_Common.NV_DiSanVanHoa.GetById(id);
        // Response.Redirect("~/NghiepVu/Disanvanhoa/ChiTietDiSan.aspx?id=" + id);

        this.wdDetail.AutoLoad.Url = "~/NghiepVu/Disanvanhoa/ChiTietDiSan.aspx?id=" + id;
        this.wdDetail.Icon = Icon.ApplicationGet;
        this.wdDetail.Title = "Thông tin di sản văn hóa";
        this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
        this.wdDetail.Render(this.Form);
        this.wdDetail.Show();
    }
    [DirectMethod]
    public void Command(string command, string value)
    {
        int disanID = int.Parse(value);
        string maForm = Request.QueryString["cn"].ToString();
        Role role = getRole();
        if (command == "Delete")
        {
            if (role.Duoc_Xoa)
            {
                Sys_Common.NV_DiSanVanHoa.Xoa(disanID);
                NV_Log_ChiTiet log = createLog(disanID, "delete");
                Sys_Common.NV_Log.them(log);
                X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
                X.Msg.AddScript("#{stDisan}.reload();");
            }
            else
            {
                X.Msg.Alert("Thông báo", "Bạn không có quyền xóa", new JFunction { Fn = "" }).Show();
            }
            return;
        }
        else if (command == "Edit")
        {
            if (role.Duoc_Sua)
            {
                this.wdDetail.AutoLoad.Url = "~/NghiepVu/Disanvanhoa/CapNhatDSVanHoa.aspx?enable=1&id=" + disanID + "&cn=" + maForm;
                this.wdDetail.Title = "Cập nhật di sản văn hóa";
                this.wdDetail.Icon = Icon.ApplicationEdit;
                this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
                this.wdDetail.Render(this.Form);
                this.wdDetail.Show();
            }
            else
            {
                X.Msg.Alert("Thông báo", "Bạn không có quyền sửa bản ghi.", new JFunction { Fn = "" }).Show();
            }
        }
        else if (command == "Mapping")
        {
            if (role.Duoc_Sua)
            {
                NV_DiSanVanHoa_ChiTiet disan = Sys_Common.NV_DiSanVanHoa.GetById(disanID);
                //if (disan.NguoiTao.ToString().Equals(Session["G_Ma_Nguoi_Dung"].ToString()))
                {
                    this.wdDetail.AutoLoad.Url = "~/Control/Map/AddMarkerMap.aspx?id=" + disanID + "&cn=" + maForm;
                    this.wdDetail.Title = "Thêm bản đồ";
                    this.wdDetail.Icon = Icon.ApplicationEdit;
                    this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
                    this.wdDetail.Render(this.Form);
                    this.wdDetail.Show();
                }
                //else
                //{
                //    X.Msg.Alert("Thông báo", "Bạn chỉ có quyền tạo bản đồ đối với di sản mà bạn nhập !!!", new JFunction { Fn = "" }).Show();
                //}
            }
            else { X.Msg.Alert("Thông báo", "Bạn không có quyền sửa bản đồ.", new JFunction { Fn = "" }).Show(); }
        }
        else if (command == "Active")
        {
            if (role.Duoc_Duyet)
            {
                NV_DiSanVanHoa_ChiTiet disan = Sys_Common.NV_DiSanVanHoa.GetById(disanID);
                disan.TrangThai = !disan.TrangThai;
                bool check = Sys_Common.NV_DiSanVanHoa.Update(disan);
                if (check)
                {
                    string thaotac = disan.TrangThai ? "active" : "unactive";
                    NV_Log_ChiTiet log = createLog(disanID, thaotac);
                    Sys_Common.NV_Log.them(log);
                    X.Msg.AddScript("#{stDisan}.reload();");
                }
            }
            else
            {
                X.Msg.Alert("Thông báo", "Bạn không có quyền duyệt bản ghi.", new JFunction { Fn = "" }).Show();
            }
        }
        else if (command == "IsNew")
        {
            if (role.Duoc_Duyet)
            {
                NV_DiSanVanHoa_ChiTiet disan = Sys_Common.NV_DiSanVanHoa.GetById(disanID);
                disan.NoiBat = !disan.NoiBat;
                bool check = Sys_Common.NV_DiSanVanHoa.Update(disan);
                X.Msg.AddScript("#{stDisan}.reload();");
            }
            else
            {
                X.Msg.Alert("Thông báo", "Bạn không có quyền sửa bản ghi.", new JFunction { Fn = "" }).Show();
            }
        }
    }
    protected void gvDiSan_DbClick(object sender, DirectEventArgs e)
    {
        string maForm = Request.QueryString["cn"].ToString();
        Role role = getRole();
        if (role.Duoc_Sua)
        {
            RowSelectionModel sm = gvDiSan.SelectionModel.Primary as RowSelectionModel;
            foreach (SelectedRow row in sm.SelectedRows)
            {
                this.wdDetail.AutoLoad.Url = "~/NghiepVu/Disanvanhoa/CapNhatDSVanHoa.aspx?id=" + row.RecordID + "&cn=" + maForm;
                this.wdDetail.Icon = Icon.ApplicationEdit;
                this.wdDetail.Title = "Cập nhật di sản văn hóa";
                this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
                this.wdDetail.Render(this.Form);
                this.wdDetail.Show();
                break;
            }
            sm.SelectedRows.Clear();
            sm.UpdateSelection();
        }
        else
        {
            X.Msg.Alert("Thông báo", "Bạn không có quyền sửa bản ghi !!!", new JFunction { Fn = "" }).Show();
        }
    }

    private void Initialization()
    {
        cbNgonNgu.Value = "vi";
        Role role = getRole();
        hdRole.Value = new JavaScriptSerializer().Serialize(role);
        stCapDiSan.DataSource = Sys_Common.NV_DM_CapDiSan.GetAll();
        DataBind();
    }
    protected void odsData_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        (this.stDisan.Proxy[0] as PageProxy).Total = (int)e.OutputParameters["Count"];

    }
    protected void stDisan_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        string address = hdAddress.Text;
        string type = hdType.Text;
        //string capdisan = cbCapDS.Value.ToString();
        string tendisan = txtTenDiSan.Text;
        string where = @"select DiSanID,MaDiSan,TenDiSan,TenGoiKhac,ChuTheVanHoa,TrangThai,NoiBat,
                        (select TenCoQuan from DM_CoQuanHanhChinh cq where cq.CoQuanID=d.DonViQuanLy) as DonViQuanLy,
                        (select TenLoai from DM_LoaiDiSan lds where lds.LoaiID=d.LoaiDiSan) as LoaiDS,
                        (select TenCap from DM_CapDiSan cds where cds.ID=d.CapDiSan) as CapDiSan,
                        (select TenAnh from Image i where i.ImageID=d.AnhDaiDien) as AnhDaiDien,STT
                        from DiSanVanHoa d where TonTai=1 and Lang='"+cbNgonNgu.Value.ToString()+"' ";
        if (address != "" && address != ",")
        {
            where += " and ('" + address + "' like '%,' + ThuocTinh + ',%' or '" + address + "' like '%,H'+ ThuocHuyen + ',%' or '" + address + "' like '%,X' + ThuocXa +',%')";
        }
        if (type != "")
        {
            where += " and LoaiDiSan in (" + type + ")";
        }
        if (ckbNguoiTao.Checked)
        {
            where += " and NguoiTao=" + Session["G_Ma_Nguoi_Dung"].ToString();
        }
        if (cbCapDS.Value != null && !string.IsNullOrEmpty(cbCapDS.Value.ToString()))
        {
            where += " and CapDiSan=" + cbCapDS.Value.ToString();
        }
        if (!string.IsNullOrEmpty(tendisan))
        {
            where += " and (Url like N'%" + StringUtil.RemoveSign4VietnameseString(tendisan).Replace(" ","-") + "%')";
        }
        if (dfTuNgay.SelectedDate != dfTuNgay.MinDate)
        {
            try
            {
                where += " and (DATEDIFF(d,'" + dfTuNgay.SelectedDate.ToString("MM/dd/yyyy") + "',NgayChungNhan)>=0 or NgayChungNhan is null)";
            }
            catch { }
        }
        if (dfDenNgay.SelectedDate != dfDenNgay.MinDate)
        {
            try
            {
                where += " and (DATEDIFF(d,NgayChungNhan,'" + dfDenNgay.SelectedDate.ToString("MM/dd/yyyy") + "')>=0 or NgayChungNhan is null)";
            }
            catch { }
        }

        this.odsData.SelectParameters["Start"].DefaultValue = (e.Start + 1).ToString();
        this.odsData.SelectParameters["Limit"].DefaultValue = (e.Limit + e.Start).ToString();
        this.odsData.SelectParameters["WhereString"].DefaultValue = @"(" + where + ") as A";
        this.odsData.SelectParameters["SortString"].DefaultValue = e.Sort + " " + e.Dir;

        this.odsData.DataBind();
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