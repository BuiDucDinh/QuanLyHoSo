using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NghiepVu_Thongke_ThongKeDiSan : System.Web.UI.Page
{
    protected void RowSelect(object sender, DirectEventArgs e)
    {

    }
    [DirectMethod]
    public static string NodeLoad(string nodeID)
    {
        Ext.Net.TreeNodeCollection nodes = new Ext.Net.TreeNodeCollection();

        if (!string.IsNullOrEmpty(nodeID))
        {
            for (int i = 1; i < 6; i++)
            {
                AsyncTreeNode asyncNode = new AsyncTreeNode();
                asyncNode.Text = nodeID + i;
                asyncNode.NodeID = nodeID + i;
                nodes.Add(asyncNode);
            }

            for (int i = 6; i < 11; i++)
            {
                Ext.Net.TreeNode treeNode = new Ext.Net.TreeNode();
                treeNode.Text = nodeID + i;
                treeNode.NodeID = nodeID + i;
                treeNode.Leaf = true;
                nodes.Add(treeNode);
            }
        }

        return nodes.ToJson();
    }
    protected void btnExport_Click(object sender, DirectEventArgs e) { }

    protected void btnDelete_Click(object sender, DirectEventArgs e)
    {
        string json = e.ExtraParams["ID"];
        Dictionary<string, string>[] companies = JSON.Deserialize<Dictionary<string, string>[]>(json);
        int id = 0;
        foreach (Dictionary<string, string> row in companies)
        {
            foreach (KeyValuePair<string, string> keyValuePair in row)
            {
                if (keyValuePair.Key.Equals("ID"))
                {
                    id = int.Parse(keyValuePair.Value);
                    break;
                }
            }
        }
        if (id != 0)
        {
            //delete record
        }
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        bool type = false;   //true: Di sản vật thể ; false: Di sản phi vật thể
        string json = e.ExtraParams["ID"];
        Dictionary<string, string>[] companies = JSON.Deserialize<Dictionary<string, string>[]>(json);
        int id = 0;
        foreach (Dictionary<string, string> row in companies)
        {
            foreach (KeyValuePair<string, string> keyValuePair in row)
            {
                if (keyValuePair.Key.Equals("ID"))
                {
                    id = int.Parse(keyValuePair.Value);
                    break;
                }
            }
        }
        //if (id != 0)      //Kiểm tra người dùng đã chọn 1 record để sửa hay chưa
        {
            //code
            if (type == false)
            {
                this.wdDetail.AutoLoad.Url = @"~/NghiepVu/Disanvanhoa/CapNhatDSPhiVatThe.aspx?id=" + id.ToString();
            }
            else
            {
                this.wdDetail.AutoLoad.Url = @"~/NghiepVu/Disanvanhoa/CapNhatDSVatThe.aspx?id=" + id.ToString();
            }
            this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
            this.wdDetail.Render(this.Form);
            this.wdDetail.Show();
            this.wdDetail.Title = "Sửa thông tin di sản";
        }
    }
    protected void btnInsert_Click(object sender, DirectEventArgs e)
    {
        bool type = true;   //true: Di sản vật thể ; false: Di sản phi vật thể
        if (type == true)
        {
            this.wdDetail.AutoLoad.Url = @"~/NghiepVu/Disanvanhoa/CapNhatDSVatThe.aspx";
        }
        else
        {
            this.wdDetail.AutoLoad.Url = @"~/NghiepVu/Disanvanhoa/CapNhatDSPhiVatThe.aspx";
        }
        this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
        this.wdDetail.Render(this.Form);
        this.wdDetail.Show();
        this.wdDetail.Title = "Thêm mới di sản";
    }

    protected void grid_DbClick(object sender, DirectEventArgs e)
    { }
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
            //X.Msg.Alert("Thông báo", Session["G_Ma_Chuc_Nang"].ToString(), new JFunction { Fn = "" }).Show();
            if (Session["G_Theme"] != null)
            {
                DHM_Common.SetTheme(this.Page, int.Parse(Session["G_Theme"].ToString()));
            }
        }
    }
}