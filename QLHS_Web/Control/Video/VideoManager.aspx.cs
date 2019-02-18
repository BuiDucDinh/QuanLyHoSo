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

public partial class Control_Video_VideoManager : System.Web.UI.Page
{

    #region load

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ImageOnly.type = "only";
            if (Session["G_Theme"] != null)
            {
                DHM_Common.SetTheme(this.Page, int.Parse(Session["G_Theme"].ToString()));
            }
            Initialization();
            X.Msg.AddScript("#{TreePanel1}.expandAll();");
        }
    }

    private void Initialization()
    {
        ImageOnly.LabelWidth = 100;
        DataTable dt = new DataTable();
        dt = Sys_Common.NV_DanhMuc.GetAllDMImage();
        DataRow row = dt.NewRow();
        row["TenDanhMuc"] = "--Chọn danh mục--";
        row["DanhMucID"] = 0;
        dt.Rows.Add(row);
        stDanhmuccha.DataSource = dt;
        DataBind();
    }
    [DirectMethod]
    public static string NodeLoadType(string nodeID)
    {
        Ext.Net.TreeNodeCollection nodes = new Ext.Net.TreeNodeCollection();

        if (!string.IsNullOrEmpty(nodeID))
        {
            DataTable dt = Sys_Common.NV_DanhMuc.GetByParent(nodeID, 2);
            if (dt != null && dt.Rows.Count > 0 && !string.IsNullOrEmpty(nodeID))
            {
                foreach (DataRow item in dt.Rows)
                {
                    DataTable dtXa = Sys_Common.NV_DanhMuc.GetByParent(item["DanhMucID"].ToString(), 2);
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
        if (nodeID != "0")
        {
            hdDanhmuc.Text = nodeID;
            if (tabPanel.ActiveTab.ID == "Danhmucvideo")
            {
                SetData(Sys_Common.NV_DanhMuc.GetById(int.Parse(hdDanhmuc.Text)));
            }
            if (tabPanel.ActiveTab.ID == "Thuvienvideo")
            {
                X.Msg.AddScript("#{gridVideo}.reload();");
            }
        }
    }
    #endregion


    #region Thư viện video
    protected void odsVideo_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        (this.stVideo.Proxy[0] as PageProxy).Total = (int)e.OutputParameters["Count"];
    }
    protected void stVideo_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        this.odsVideo.SelectParameters["Start"].DefaultValue = (e.Start + 1).ToString();
        this.odsVideo.SelectParameters["Limit"].DefaultValue = (e.Limit + e.Start).ToString();
        if (hdDanhmuc.Text != "" && hdDanhmuc.Text != null && hdDanhmuc.Text != "0")
        {
            this.odsVideo.SelectParameters["WhereString"].DefaultValue = "(select TenVideo,VideoID,(select TenAnh from Image i where i.ImageID=v.ImageID) as AnhMoTa from Video v where DanhMuc=" + hdDanhmuc.Text + ") as A";
        }
        else
        {
            this.odsVideo.SelectParameters["WhereString"].DefaultValue = "(select TenVideo,VideoID,(select TenAnh from Image i where i.ImageID=v.ImageID) as AnhMoTa from Video v) as A";
        }
        this.odsVideo.SelectParameters["SortString"].DefaultValue = e.Sort + " " + e.Dir;

        this.odsVideo.DataBind();

    }
    protected void DelVideo(object sender, DirectEventArgs e)
    {
        string command = e.ExtraParams["command"].ToString();
        string RowIndex = e.ExtraParams["rowIndex"].ToString();

        if (command == "Del")
        {
            Sys_Common.NV_Video.Xoa(int.Parse(RowIndex));
            X.Msg.AddScript("#{gridVideo}.reload();");
        }
    }
    protected void lbnInsert_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = this.gridVideo.SelectionModel.Primary as RowSelectionModel;
        int i = 0;
        string img = ",";
        foreach (SelectedRow row in sm.SelectedRows)
        {
            img += row.RecordID + ",";
            i++;
        }
        string lenh = "parent." + Request.QueryString["id"].ToString() + ".setValue('" + img + "');";
        X.Msg.AddScript(lenh);
        X.Msg.AddScript("parentAutoLoadControl.hide();");
    }
    protected void lbnDelete_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = this.gridVideo.SelectionModel.Primary as RowSelectionModel;
        int i = 0;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            Sys_Common.NV_Image.Xoa(int.Parse(row.RecordID));
        }
        X.Msg.AddScript("#{gridImage}.reload();");
    }
    #endregion

    #region upload video

    protected void FileUploadField_FileSelected(object sender, DirectEventArgs e)
    {
        if (fFile.HasFile)
        {
            HttpFileCollection hfc = Request.Files;
            string file = fFile.FileName;
            string path = HttpContext.Current.Server.MapPath("~/FileUpload/Video");
            this.fFile.PostedFile.SaveAs(path + file);
        }
    }
    protected void btnFinish_Click(object sender, DirectEventArgs e)
    {
        if (fFile.HasFile || txtUrl.Text != "")
        {
            NV_Video_ChiTiet model = new NV_Video_ChiTiet();
            model.FileUpload = fFile.Text;
            model.ImageID = int.Parse(hdAnhMoTa.Text);
            model.Url = txtUrl.Text;
            model.TenVideo = txtTenVideo.Text;
            model.DanhMuc = int.Parse("0" + hdDanhmuc.Text);
            Sys_Common.NV_Video.them(model);

            X.Msg.AddScript("#{gridVideo}.reload();");
            tabPanel.SetActiveTab(Thuvienvideo);
            ClearDataUpload();
        }
    }
    private void ClearDataUpload()
    {
        txtTenVideo.Text = "";
        txtUrl.Text = "";
    }
    #endregion

    #region Danh mục video
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        if (FormValidate())
        {
            NV_DanhMuc_ChiTiet model = new NV_DanhMuc_ChiTiet();
            model.TenDanhMuc = txtTendanhmuc.Text;
            model.MoTa = txtMota.Text;
            model.TheLoai = 2;
            try
            {
                model.DanhMucCha = int.Parse(cmbDanhmuccha.Value.ToString());
            }
            catch
            {
                model.DanhMucCha = 0;
            }
            if (hdDanhmuc.Text != "")
            {
                model.DanhMucID = int.Parse(hdDanhmuc.Text);
                Sys_Common.NV_DanhMuc.update(model);
            }
            else
            {
                Sys_Common.NV_DanhMuc.themDMImage(model);
            }

            X.Msg.Alert("Thông báo", "Đã cập nhật thành công !!!", new JFunction { Fn = "" }).Show();
            TreePanel1.ReloadAsyncNode("0", null);
            ClearData();
            X.Msg.AddScript("#{TreePanel1}.expandAll();");
        }
    }
    protected void btnDelete_Click(object sender, DirectEventArgs e)
    {
        if (hdDanhmuc.Value != null && hdDanhmuc.Value.ToString() != "" && hdDanhmuc.Value.ToString() != "0")
        {
            int danhmuc = int.Parse(hdDanhmuc.Value.ToString());
            Sys_Common.NV_DanhMuc.Xoa(danhmuc);
            ClearData();
            TreePanel1.ReloadAsyncNode("0", null);

            X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
            X.Msg.AddScript("#{TreePanel1}.expandAll();");
        }
    }
    private bool FormValidate()
    {
        if (this.txtTendanhmuc.Text.ToString() == "")
        {
            X.Msg.Alert("Thông báo", "Thiếu thông tin ", new JFunction { Fn = "" }).Show();
            return false;
        }
        return true;
    }
    private void ClearData()
    {
        btnUpdate.Text = "Thêm mới";
        btnUpdate.Icon = Icon.Add;

        hdDanhmuc.Text = "";
        txtTendanhmuc.Text = "";
        txtMota.Text = "";
        cmbDanhmuccha.Value = "";
    }
    private void SetData(NV_DanhMuc_ChiTiet model)
    {
        btnUpdate.Text = "Cập nhật";
        btnUpdate.Icon = Icon.ApplicationEdit;

        txtTendanhmuc.Text = model.TenDanhMuc;
        cmbDanhmuccha.Value = model.DanhMucCha;
        txtMota.Text = model.MoTa;
    }
    #endregion
}