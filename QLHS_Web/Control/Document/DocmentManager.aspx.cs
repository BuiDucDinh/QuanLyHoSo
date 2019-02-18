using Ext.Net;
using QLHS_Logic;
using QLHS_Logic.NV;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Control_Document_DocmentManager : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            X.Msg.AddScript("#{TreePanel1}.expandAll();");

        }
    }

    [DirectMethod]
    public static string NodeLoadType(string nodeID)
    {
        Ext.Net.TreeNodeCollection nodes = new Ext.Net.TreeNodeCollection();

        if (!string.IsNullOrEmpty(nodeID))
        {
            DataTable dt = Sys_Common.NV_DanhMuc.GetByParent(nodeID, 3);
            if (dt != null && dt.Rows.Count > 0 && !string.IsNullOrEmpty(nodeID))
            {
                foreach (DataRow item in dt.Rows)
                {
                    DataTable dtXa = Sys_Common.NV_DanhMuc.GetByParent(item["DanhMucID"].ToString(), 3);
                    if (dtXa != null && dtXa.Rows.Count > 0)
                    {
                        AsyncTreeNode asyncNode = new AsyncTreeNode();
                        asyncNode.Icon = Icon.Folder;
                        asyncNode.Text = item["TenDanhMuc"].ToString();
                        asyncNode.NodeID = item["DanhMucID"].ToString();
                        nodes.Add(asyncNode);
                    }
                    else
                    {
                        Ext.Net.TreeNode treeNode = new Ext.Net.TreeNode(item["TenDanhMuc"].ToString(), Icon.Folder);
                        //treeNode.Text = item["TenLoai"].ToString();
                        treeNode.NodeID = item["DanhMucID"].ToString();
                        treeNode.Leaf = true;
                        nodes.Add(treeNode);
                    }
                }
            }
        }
        string str = nodes.ToJson();
        return nodes.ToJson();
    }

    [DirectMethod]
    public void GetInfoType(string nodeID)
    {
        hdDanhmuc.Text = nodeID;
        X.Msg.AddScript("#{gridData}.reload();");
    }
    [DirectMethod]
    public void Command(string command, string value)
    {
        int documentID = int.Parse(value);
        if (command == "Delete")
        {
            Sys_Common.NV_Document.Xoa(documentID);
            X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
            X.Msg.AddScript("#{stDisan}.reload();");

        }
        else if (command == "Edit")
        {
            NV_Document_ChiTiet document = Sys_Common.NV_Document.GetById(documentID);
            txtName.Text = document.TenTaiLieu;
            hdImgUpload.Text = documentID.ToString();
            wdEdit.Show();
        }

    }
    protected void odsDocument_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        (this.stDocument.Proxy[0] as PageProxy).Total = (int)e.OutputParameters["Count"];
    }
    protected void stDocument_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        this.odsDocument.SelectParameters["Start"].DefaultValue = (e.Start + 1).ToString();
        this.odsDocument.SelectParameters["Limit"].DefaultValue = (e.Limit + e.Start).ToString();

        string where = "(select * from Document where 1=1 ";
        if (hdDanhmuc.Text != "" && hdDanhmuc.Text != null)
        {
            if (hdDanhmuc.Text != "0")
            {
                where += " and DanhMuc=" + hdDanhmuc.Text;
            }
        }
        where += ") as A";
        this.odsDocument.SelectParameters["WhereString"].DefaultValue = where;
        this.odsDocument.SelectParameters["SortString"].DefaultValue = e.Sort + " " + e.Dir;

        this.odsDocument.DataBind();

    }
    protected void btnDelete_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gridData.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            Sys_Common.NV_Document.Xoa(int.Parse(row.RecordID));
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
        X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
        X.Msg.AddScript("#{gridData}.reload();");
    }

    protected void btnUpload_Click(object sender, DirectEventArgs e)
    {
        if (this.fDocument.HasFile)
        {
            string arrImage = "";
            HttpFileCollection hfc = Request.Files;
            for (int i = 0; i < hfc.Count; i++)
            {
                HttpPostedFile file = hfc[i];
                string ets = System.IO.Path.GetExtension(file.FileName);
                if (file.ContentLength > 0 && (ets == ".pdf" || ets == ".doc" || ets == ".txt" || ets == ".docx" || ets == ".xls" || ets == ".xlsx" || ets == ".zip" || ets == ".rar"))
                {
                    string filename = file.FileName.Substring(0, file.FileName.LastIndexOf(".")) + "_" + DateTime.Now.ToString("MM_dd_yyyy_hh_mm_ss") + ets;
                    string filepath = HttpContext.Current.Server.MapPath("~/FileUpload/Document") + "/" + filename;
                    file.SaveAs(filepath);
                    arrImage += i + ":" + file.FileName + ";";
                    NV_Document_ChiTiet model = new NV_Document_ChiTiet();
                    model.DanhMuc = int.Parse(hdDanhmuc.Text);
                    model.File = filename;
                    model.TenTaiLieu = txtTentailieu.Text;
                    model.NgayTao = DateTime.Now;
                    Sys_Common.NV_Document.them(model);
                }
            }
            hdImgUpload.Text = arrImage;
            wdUpload.Hidden = true;
            X.Msg.AddScript("#{gridData}.reload();");
        }
    }
    protected void btnSave_Click(object sender, DirectEventArgs e)
    {
        try
        {
            int id = int.Parse(hdImgUpload.Text);
            NV_Document_ChiTiet document = Sys_Common.NV_Document.GetById(id);
            document.TenTaiLieu = txtName.Text;
            Sys_Common.NV_Document.update(document);
            wdEdit.Hidden = true;
            X.Msg.AddScript("#{gridData}.reload();");
        }
        catch { }
    }
    #region add new folder
    protected void btnCancelFolder_Click(object sender, DirectEventArgs e)
    {
        txtTenDanhmuc.Text = "";
        txtMota.Text = "";
        wdFolder.Hidden = true;
    }
    protected void btnOKFolder_Click(object sender, DirectEventArgs e)
    {
        if (txtTenDanhmuc.Text != "")
        {
            NV_DanhMuc_ChiTiet model = new NV_DanhMuc_ChiTiet();
            model.TenDanhMuc = txtTenDanhmuc.Text;
            model.MoTa = txtMota.Text;
            model.TheLoai = 3;
            Sys_Common.NV_DanhMuc.themDMDocument(model);
            TreePanel1.ReloadAsyncNode("0", null);
            X.Msg.Alert("Thông báo", "Đã cập nhật thành công !!!", new JFunction { Fn = "" }).Show();
            wdFolder.Hidden = true;
        }
        else
        {
            X.Msg.Alert("Cảnh bảo", "Bạn chưa nhập tên danh mục !!!", new JFunction { Fn = "" }).Show();
        }
    }
    #endregion

    protected void gridData_DbClick(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gridData.SelectionModel.Primary as RowSelectionModel;
        int i = 0;
        string img = ",";
        foreach (SelectedRow row in sm.SelectedRows)
        {
            img += row.RecordID + ",";
            i++;
        }
        string addValue = "parent." + Request.QueryString["id"].ToString() + ".setValue('" + img + "');";
        X.Msg.AddScript(addValue);

        sm.SelectedRows.Clear();
        sm.UpdateSelection();
        X.Msg.AddScript("parentAutoLoadControl.hide();");
    }
    protected void btnInsert_Click(object sender, DirectEventArgs e)
    {
        gridData_DbClick(null, null);
    }
}