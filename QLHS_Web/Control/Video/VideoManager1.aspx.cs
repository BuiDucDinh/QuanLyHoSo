using Ext.Net;
using QLHS_Logic;
using QLHS_Logic.NV;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NghiepVu_Control_VideoManager : System.Web.UI.Page
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
            LoadVideo("");
            X.Msg.AddScript("#{TreePanel1}.expandAll();");
        }
    }

    private void Initialization()
    {
        DataTable dt = new DataTable();
        dt = Sys_Common.NV_DanhMuc.GetAllDMVideo();

        stDanhmucUp.DataSource = dt;
        DataRow row = dt.NewRow();
        row["TenDanhMuc"] = "--Chọn danh mục--";
        row["DanhMucID"] = 0;
        dt.Rows.InsertAt(row, 0);
        stDanhmuc.DataSource = dt;
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
                        treeNode.Text = item["TenDanhMuc"].ToString();
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
            if (tabPanel.ActiveTab.ID == "Danhmucanh")
            {
                SetData(Sys_Common.NV_DanhMuc.GetById(int.Parse(hdDanhmuc.Text)));
            }
            //if (tabPanel.ActiveTab.ID == "Thuvienanh")
            {
                LoadVideo(nodeID);
            }
        }
    }

    #endregion


    #region Thư viện video

    public void LoadVideo(string danhmuc)
    {
        string sql = @"select VideoID,TenVideo,Url,FileUpload,
	            (select TenAnh from [Image] i where i.ImageID=v.ImageID) as AnhMoTa 
	            from Video v ";
        if (!string.IsNullOrEmpty(danhmuc))
        {
            sql += "where DanhMuc=" + danhmuc;
        }
        DataTable dt = Sys_Common.getDataByQuery(sql);
        rptVideo.DataSource = dt;
        rptVideo.DataBind();
        rptVideo.Update();
    }



    [DirectMethod]
    public void Insert(string[] arr)
    {
        string img = ",";
        foreach (var item in arr)
        {
            img += item + ",";
        }
        string lenh = "parent." + Request.QueryString["id"].ToString() + ".setValue('" + img + "');";
        X.Msg.AddScript(lenh);
        X.Msg.AddScript("parentAutoLoadControl.hide();");
    }

    [DirectMethod]
    public void Delete(string[] arr)
    {
        foreach (var item in arr)
        {
            Sys_Common.NV_Video.Xoa(int.Parse(item));
        }
        LoadVideo(null);
    }

    #endregion


    #region upload video
    [DirectMethod]
    public void SaveVideo(string[] arrVideo, string danhmuc)
    {
        if (!string.IsNullOrEmpty(danhmuc))
        {
            if (arrVideo.Length > 0)
            {
                foreach (string item in arrVideo)
                {
                    if (item != "")
                    {
                        NV_Video_ChiTiet model = new NV_Video_ChiTiet();
                        model.TenVideo = txtTenVideo.Text;
                        model.Url = txtUrl.Text;
                        model.ImageID = int.Parse(ImageOnly.ImageID);
                        model.DanhMuc = int.Parse(hdDanhmuc.Text);
                        model.FileUpload = item;
                        Sys_Common.NV_Video.them(model);
                    }
                }
                LoadVideo(danhmuc);
                tabPanel.SetActiveTab(Thuvienanh);
            }
        }
        else
        {
            X.Msg.Alert("Cảnh báo", "Bạn chưa chọn danh mục video");
        }
    }
    protected void btnUpload_Click(object sender, DirectEventArgs e)
    {
        if (this.fVideo.HasFile)
        {
            //string arrImage = "";
            int danhmuc = int.Parse(hdDanhmuc.Text);
            HttpFileCollection hfc = Request.Files;
            for (int i = 0; i < hfc.Count; i++)
            {
                HttpPostedFile file = hfc[i];
                string ets = System.IO.Path.GetExtension(file.FileName);
                if (file.ContentLength > 0 && (ets == ".mp4" || ets == ".svc" || ets == ".avi" || ets == ".mov" || ets == ".flv"))
                {
                    string filepath = HttpContext.Current.Server.MapPath("~/FileUpload/Video") + "\\" + file.FileName;
                    file.SaveAs(filepath);
                    NV_Video_ChiTiet model = new NV_Video_ChiTiet();
                    model.DanhMuc = danhmuc;
                    model.TenVideo = txtTenVideo.Text;
                    model.Url = txtUrl.Text;
                    model.FileUpload = file.FileName;
                    Sys_Common.NV_Video.them(model);
                }
            }
            LoadVideo(danhmuc.ToString());
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
                Sys_Common.NV_DanhMuc.themDMVideo(model);
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