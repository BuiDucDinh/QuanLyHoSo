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
            //LoadImage("");
            X.Msg.AddScript("#{TreePanel1}.expandAll();");
        }
    }

    private void Initialization()
    {
        DataTable dt = new DataTable();
        dt = Sys_Common.NV_DanhMuc.GetAllDMImage();

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
                LoadImage(nodeID,1);
            }
        }
    }

    #endregion


    #region Thư viện ảnh

    public void LoadImage(string danhmuc, int index)
    {
        string sql = "";
        if (!string.IsNullOrEmpty(danhmuc))
        {
            sql = "select top 10 * from (select ROW_NUMBER() over(order by ImageID) as rowindex,* from Image where DanhMuc=" + danhmuc + ") as tb where rowindex>" + index * 10;
        }
        else
        {
            sql = "select top 10 * from (select ROW_NUMBER() over(order by ImageID) as rowindex,* from Image) as tb where rowindex>" + index * 10;
        }
        DataTable dt = Sys_Common.getDataByQuery(sql);
        rptImage.DataSource = dt;
        rptImage.DataBind();
        rptImage.Update();
    }



    [DirectMethod]
    public void Insert(string[] arr)
    {
        if (Request.QueryString["type"] == "only" && arr.Length > 1)
        {
            X.Msg.Alert("Cảnh báo", "Bạn chỉ được chọn 1 ảnh");
            return;
        }
        else
        {
            string control = Request.QueryString["control"] != null ? Request.QueryString["control"].ToString() : "";
            string image = Request.QueryString["image"] != null ? Request.QueryString["image"].ToString() : "";
            string img = "";
            if (Request.QueryString["type"] == "only")
            {
                img = arr[0];
                X.Msg.AddScript("parent." + control + ".setValue('" + img + ";" + image + "');");
            }
            else
            {
                int i = 0;
                img = ",";
                foreach (var item in arr)
                {
                    img += item + ",";
                    i++;
                }
                X.Msg.AddScript("parent." + control + ".setValue('" + img + "');");
            }
            X.Msg.AddScript("parentAutoLoadControl.hide();");
        }
    }

    [DirectMethod]
    public void Delete(string[] arr)
    {
        foreach (var item in arr)
        {
            NV_Image_ChiTiet img = Sys_Common.NV_Image.GetById(int.Parse(item));
            File.Delete(HttpContext.Current.Server.MapPath("~/FileUpload/images/" + img.TenAnh));
            Sys_Common.NV_Image.Xoa(int.Parse(item));
        }
        LoadImage(null,1);
    }

    #endregion

    #region upload ảnh

    [DirectMethod]
    public void SaveImage(string[] arrImg, string danhmuc)
    {
        if (!string.IsNullOrEmpty(danhmuc))
        {
            if (arrImg.Length > 0)
            {
                foreach (string item in arrImg)
                {
                    if (item != "")
                    {
                        //string[] img = item.Split(':');
                        NV_Image_ChiTiet model = new NV_Image_ChiTiet();
                        model.TenAnh = item;//img[0];
                        model.NgayTao = DateTime.Now;
                        model.DanhMuc = int.Parse(hdDanhmuc.Text);
                        Sys_Common.NV_Image.them(model);
                    }
                }
                //LoadImage(danhmuc,1);
                tabPanel.SetActiveTab(Thuvienanh);
            }
        }
        else
        {
            X.Msg.Alert("Cảnh báo", "Bạn chưa chọn danh mục ảnh");
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