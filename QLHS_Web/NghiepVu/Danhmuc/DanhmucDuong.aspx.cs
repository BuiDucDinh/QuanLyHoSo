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
using System.Xml;
using System.Xml.Xsl;

public partial class NghiepVu_Danhmuc_DanhmucDuong : System.Web.UI.Page
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
            Role role = getRole();
            hdRole.Value = new JavaScriptSerializer().Serialize(role);
            if (!role.Duoc_Nhap)
            {
                btnUpdate.Visible = false;
            }
        }
        //X.Msg.AddScript("#{TreePanel1}.expandAll();");
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

    protected void odsData_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        (this.stData.Proxy[0] as PageProxy).Total = (int)e.OutputParameters["Count"];

    }
    protected void stData_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        string address = hdAddress.Text;

        string where = "";
        if (address.Length > 1)
        {
            where += " and ('" + address + "' like '%,' + ThuocTinh + ',%' or '" + address + "' like '%,' + ThuocHuyen + ',%')";
        }
        this.odsData.SelectParameters["Start"].DefaultValue = (e.Start + 1).ToString();
        this.odsData.SelectParameters["Limit"].DefaultValue = (e.Limit + e.Start).ToString();
        this.odsData.SelectParameters["WhereString"].DefaultValue = @"(select * from DanhMucDuong where 1=1" + where + ") as A";
        this.odsData.SelectParameters["SortString"].DefaultValue = e.Sort + " " + e.Dir;

        this.odsData.DataBind();
    }

    protected void gvData_DbClick(object sender, DirectEventArgs e)
    {
        Role role = getRole();
        if (role.Duoc_Sua)
        {
            RowSelectionModel sm = gvData.SelectionModel.Primary as RowSelectionModel;
            string maForm = Request.QueryString["cn"].ToString();
            foreach (SelectedRow row in sm.SelectedRows)
            {
                this.wdDetail.AutoLoad.Url = "~/NghiepVu/DanhMuc/CapNhatDanhMucDuong.aspx?id=" + row.RecordID + "&cn=" + maForm;
                this.wdDetail.Icon = Icon.ApplicationEdit;
                this.wdDetail.Title = "Cập nhật thông tin đường";
                this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
                this.wdDetail.Render(this.Form);
                this.wdDetail.Show();
                break;
            }
        }
        else
        {
            X.Msg.Alert("Thông báo", "Bạn không có quyền sửa bản ghi !!!", new JFunction { Fn = "" }).Show();
        }
    }
    protected void btnExport_Click(object sender, DirectEventArgs e)
    {
        Role role = getRole();
        if (role.Duoc_Xuat)
        {
            string json = e.ExtraParams["data"].ToString();
            StoreSubmitDataEventArgs eSubmit = new StoreSubmitDataEventArgs(json, null);
            XmlNode xml = eSubmit.Xml;

            this.Response.Clear();
            this.Response.ContentType = "application/vnd.ms-excel";
            this.Response.AddHeader("Content-Disposition", "attachment; filename=submittedData.xls");
            XslCompiledTransform xtExcel = new XslCompiledTransform();
            xtExcel.Load(Server.MapPath("/NghiepVu/Resources/Excel.xsl"));
            xtExcel.Transform(xml, null, this.Response.OutputStream);
            this.Response.End();
            NV_Log_ChiTiet log = createLog(0, "export");
            Sys_Common.NV_Log.them(log);
        }
        else
        {
            X.Msg.Alert("Thông báo", "Bạn không có quyền xuất dữ liệu.", new JFunction { Fn = "" }).Show();
        }
    }

    protected void btnDelete_Click(object sender, DirectEventArgs e)
    {
        Role role = getRole();
        if (role.Duoc_Xoa)
        {
            RowSelectionModel sm = gvData.SelectionModel.Primary as RowSelectionModel;
            foreach (SelectedRow row in sm.SelectedRows)
            {
                int id = int.Parse(row.RecordID);
                Sys_Common.NV_DanhMucDuong.Xoa(id);
                NV_Log_ChiTiet log = createLog(id, "delete");
                Sys_Common.NV_Log.them(log);
            }
            sm.SelectedRows.Clear();
            sm.UpdateSelection();
            X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
            X.Msg.AddScript("#{stData}.reload();");
        }
        else
        {
            X.Msg.Alert("Thông báo", "Bạn không có quyền xóa", new JFunction { Fn = "" }).Show();
        }
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        Role role = getRole();
        if (role.Duoc_Nhap)
        {
            string maForm = Request.QueryString["cn"].ToString();
            this.wdDetail.AutoLoad.Url = "~/NghiepVu/DanhMuc/CapNhatDanhMucDuong.aspx?cn=" + maForm;
            this.wdDetail.Icon = Icon.Add;
            this.wdDetail.Title = "Thêm mới đường";
            this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
            this.wdDetail.Render(this.Form);
            this.wdDetail.Show();
        }
        else
        {
            X.Msg.Alert("Thông báo", "Bạn không có quyền thêm mới bản ghi.", new JFunction { Fn = "" }).Show();
        }
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