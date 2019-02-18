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

public partial class NghiepVu_Control_ImageManager : System.Web.UI.Page
{

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
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
            DataTable dt = Sys_Common.NV_DanhMuc.GetByParent(nodeID, 1);
            if (dt != null && dt.Rows.Count > 0 && !string.IsNullOrEmpty(nodeID))
            {
                foreach (DataRow item in dt.Rows)
                {
                    DataTable dtXa = Sys_Common.NV_DanhMuc.GetByParent(item["DanhMucID"].ToString(), 1);
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
            hdDanhmuc.Text = nodeID;
            if (tabPanel.ActiveTab.ID == "Danhmucanh")
            {
                SetData(Sys_Common.NV_DanhMuc.GetById(int.Parse(hdDanhmuc.Text)));
            }
            if (tabPanel.ActiveTab.ID == "Thuvienanh")
            {
                X.Msg.AddScript("#{gridImage}.reload();");
            }
        }
    }


    #endregion

    #region Thư viện ảnh
    protected void odsImage_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        (this.stImage.Proxy[0] as PageProxy).Total = (int)e.OutputParameters["Count"];
    }
    protected void stImage_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        this.odsImage.SelectParameters["Start"].DefaultValue = (e.Start + 1).ToString();
        this.odsImage.SelectParameters["Limit"].DefaultValue = (e.Limit + e.Start).ToString();
        if (hdDanhmuc.Text != "" && hdDanhmuc.Text != null && hdDanhmuc.Text != "0")
        {
            this.odsImage.SelectParameters["WhereString"].DefaultValue = "(select * from Image where DanhMuc=" + hdDanhmuc.Text + ") as A";
        }
        else
        {
            this.odsImage.SelectParameters["WhereString"].DefaultValue = "(select * from Image) as A";
        }
        this.odsImage.SelectParameters["SortString"].DefaultValue = e.Sort + " " + e.Dir;

        this.odsImage.DataBind();

    }
    protected void DelImage(object sender, DirectEventArgs e)
    {
        string command = e.ExtraParams["command"].ToString();
        string RowIndex = e.ExtraParams["rowIndex"].ToString();

        if (command == "Del")
        {
            Sys_Common.NV_Image.Xoa(int.Parse(RowIndex));
            X.Msg.AddScript("#{gridImage}.reload();");
        }
    }
    protected void lbnInsert_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = this.gridImage.SelectionModel.Primary as RowSelectionModel;
        if (Request.QueryString["type"] == "only" && sm.SelectedRows.Count > 1)
        {
            X.Msg.Alert("Cảnh báo", "Bạn chỉ được chọn 1 ảnh");
        }
        else
        {
            string img = "";
            if (Request.QueryString["type"] == "only")
            {
                img = sm.SelectedRows[0].RecordID;
            }
            else
            {
                int i = 0;
                img = ",";
                foreach (SelectedRow row in sm.SelectedRows)
                {
                    img += row.RecordID + ",";
                    i++;
                }
            }           
            X.Msg.AddScript("parent.txtTextField.setValue('" + img + "');");
            X.Msg.AddScript("parentAutoLoadControl.hide();");
        }
    }
    protected void lbnDelete_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = this.gridImage.SelectionModel.Primary as RowSelectionModel;        
        foreach (SelectedRow row in sm.SelectedRows)
        {
            Sys_Common.NV_Image.Xoa(int.Parse(row.RecordID));
        }
        X.Msg.AddScript("#{gridImage}.reload();");
    }
    #endregion

    #region upload ảnh
    protected void odsDsAnh_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        (this.stDsAnh.Proxy[0] as PageProxy).Total = (int)e.OutputParameters["Count"];

    }
    protected void stDsAnh_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        this.odsDsAnh.SelectParameters["Start"].DefaultValue = (e.Start + 1).ToString();
        this.odsDsAnh.SelectParameters["Limit"].DefaultValue = (e.Limit + e.Start).ToString();
        this.odsDsAnh.SelectParameters["ImgArr"].DefaultValue = hdImgUpload.Text;
        this.odsDsAnh.DataBind();
    }
    protected void Upload(object sender, EventArgs e)
    {
        uploadFile();
    }
    protected void btnFinish_Click(object sender, DirectEventArgs e)
    {
        if (hdDanhmuc.Text != "")
        {
            if (hdImgUpload.Text != "")
            {
                string[] arr = hdImgUpload.Text.Split(';');
                foreach (string item in arr)
                {
                    if (item != "")
                    {
                        string[] img = item.Split(':');
                        NV_Image_ChiTiet model = new NV_Image_ChiTiet();
                        model.TenAnh = img[1];
                        model.NgayTao = DateTime.Now;
                        model.DanhMuc = int.Parse(hdDanhmuc.Text);
                        Sys_Common.NV_Image.them(model);
                    }
                }
                X.Msg.AddScript("#{gridImage}.reload();");
                tabPanel.SetActiveTab(Thuvienanh);
            }
        }
        else
        {
            X.Msg.Alert("Cảnh báo", "Bạn chưa chọn danh mục ảnh");
        }
    }
    private void uploadFile()
    {
        if (this.FileUpload1.HasFile)
        {
            string arrImage = "";
            string path = HttpContext.Current.Server.MapPath("~/FileUpload/Images");
            HttpFileCollection hfc = Request.Files;
            for (int i = 0; i < hfc.Count; i++)
            {
                HttpPostedFile file = hfc[i];
                string ets = System.IO.Path.GetExtension(file.FileName);
                if (file.ContentLength > 0 && (ets == ".jpg" || ets == ".png" || ets == ".jpeg" || ets == ".gif" || ets == ".bmp"))
                {
                    string filepath = path + "\\" + file.FileName;
                    file.SaveAs(filepath);
                    arrImage += i + ":" + file.FileName + ";";
                }
            }
            hdImgUpload.Text = arrImage;
            X.Msg.AddScript("#{gridData}.reload();");
        }
    }
    protected void Action_Click(object sender, DirectEventArgs e)
    {
        string command = e.ExtraParams["command"].ToString();
        string RowIndex = e.ExtraParams["rowIndex"].ToString();

        if (command == "Del")
        {
            string str = hdImgUpload.Text;
            string[] arr = str.Split(';');
            string result = "";
            foreach (string item in arr)
            {
                if (item != "")
                {
                    string[] img = item.Split(':');
                    if (img[0] != RowIndex)
                    {
                        result += item + ";";
                    }
                }
            }
            hdImgUpload.Text = result;
            X.Msg.AddScript("#{gridData}.reload();");
        }
    }

    #endregion

    #region Danh mục ảnh
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        if (FormValidate())
        {
            NV_DanhMuc_ChiTiet model = new NV_DanhMuc_ChiTiet();
            model.TenDanhMuc = txtTendanhmuc.Text;
            model.MoTa = txtMota.Text;
            model.TheLoai = 1;
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