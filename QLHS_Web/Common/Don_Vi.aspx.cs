using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using QLHS_Logic;
using System.Data;

public partial class Common_Don_Vi : System.Web.UI.Page
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
            Session["DV_Ma_Phong"] = null;
            Session["DV_Ma_Don_Vi"] = null;
        }
    }
    protected void NodeLoad(object sender, NodeLoadEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.NodeID))
        {
            switch (e.NodeID)
            {
                case "0": //Sở Y Tế

                    //DataTable myTable = Sys_Common.RunTableBySQL("SELECT DV.Loai_Hinh, DV.Ma_Don_Vi, DV.Ten_Don_Vi FROM HT_Don_Vi_YT DV WHERE (DV.Loai_Hinh in (2) or(DV.Loai_Hinh =1 and DV.Loai_Dac_Biet=1)) and Ma_Tinh = '" + Sys_Common.G_MA_TINH + "' order by DV.Loai_Hinh DESC, DV.Ten_Don_Vi asc");
                    DataTable myTable = Sys_Common.RunTableBySQL("SELECT DV.Loai_Hinh, DV.Ma_Don_Vi, DV.Ten_Don_Vi FROM HT_Don_Vi_YT DV WHERE (DV.Loai_Hinh in (2)) and Ma_Tinh = '" + Sys_Common.G_MA_TINH + "' order by DV.Loai_Hinh DESC, DV.Ten_Don_Vi asc ");
                    //myTable.Rows.Add("-4", "-4", "BỆNH VIỆN TUYẾN TỈNH");
                    //myTable.Rows.Add("-5", "-5", "BỆNH VIỆN TUYẾN HUYỆN");
                    //myTable.Rows.Add("-7", "-7", "TRUNG TÂM Y TẾ TUYỂN TỈNH");
                    //myTable.Rows.Add("-1", "-1", "Ngành ngoài tỉnh ngoài");
                    //myTable.Rows.Add("1", "23", "Văn phòng Sở Nông nghiệp");

                    GenTreeNode(e, myTable);
                    break;

                //case "-4": //CÁC Bệnh viện tuyến Tỉnh
                //    myTable = Sys_Common.RunTableBySQL("SELECT DV.Loai_Hinh, DV.Ma_Don_Vi, DV.Ten_Don_Vi FROM HT_Don_Vi_YT DV WHERE (DV.Loai_Hinh = 4) and Ma_Tinh = '" + Sys_Common.G_MA_TINH + "' order by DV.Ten_Don_Vi asc");

                    //GenTreeNode(e, myTable);
                    //break;
                //case "-5": //CÁC Bệnh viện tuyến Huyện
                //    myTable = Sys_Common.RunTableBySQL("SELECT DV.Loai_Hinh, DV.Ma_Don_Vi, DV.Ten_Don_Vi FROM HT_Don_Vi_YT DV WHERE (DV.Loai_Hinh = 5) and Ma_Tinh = '" + Sys_Common.G_MA_TINH + "' order by DV.Ten_Don_Vi asc");

                //    GenTreeNode(e, myTable);
                //    break;
                //case "-7": //CÁC Trung tâm
                //    myTable = Sys_Common.RunTableBySQL("SELECT DV.Loai_Hinh, DV.Ma_Don_Vi, DV.Ten_Don_Vi FROM HT_Don_Vi_YT DV WHERE (DV.Loai_Hinh =  7) and Ma_Tinh = '" + Sys_Common.G_MA_TINH + "' order by DV.Ten_Don_Vi asc");

                //    GenTreeNode(e, myTable);
                //    break;
                //default:
                //    HT_Don_Vi_YT_Chi_Tiet myDon_Vi = Sys_Common.HT_DON_VI_YT.Lay(int.Parse(e.NodeID));

                //    switch (myDon_Vi.Loai_Hinh)
                //    {
                //        case 2:
                //            myTable = Sys_Common.RunTableBySQL("SELECT DV.Loai_Hinh, DV.Ma_Don_Vi, DV.Ten_Don_Vi FROM HT_Don_Vi_YT DV WHERE Loai_Hinh = 3 and Ma_Huyen = '" + myDon_Vi.Ma_Huyen + "' order by DV.Ten_Don_Vi asc");
                //            GenTreeNode(e, myTable);
                //            break;
                //        default:
                //            break;
                //    }
                //    break;

            }
        }
    }


    protected void tree1_Click(object sender, DirectEventArgs e)
    {
        //var myobj = TreePanel1.get .getSelectionModel().getSelectedNode();

        string Ma_Don_Vi = e.ExtraParams["Ma_Don_Vi"];
        //if (Ma_Don_Vi == "-1")
        //{
        //    Session["DV_Ma_Don_Vi"] = 0;
        //}
        //else
        //{
        Session["DV_Ma_Don_Vi"] = Ma_Don_Vi;
        //}
        Session["DV_Ma_Phong"] = null;
        X.Msg.AddScript("#{dsPB}.reload();");
    }

    protected void dsPBRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        DataTable myTable = Sys_Common.RunTableBySQL("SELECT [Ma_Phong],[Ten_Phong],[Ma_Don_Vi],[So_Nguoi] FROM [NL_DM_Phong_Ban] where Ma_Don_Vi = " + Session["DV_Ma_Don_Vi"] + " order by Ten_Phong asc");

        if (myTable == null) myTable = new DataTable();

        this.dsPB.DataSource = myTable;

        this.dsPB.DataBind();
    }
    protected void gridPB_RowClick(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gridPB.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            Session["DV_Ma_Phong"] = row.RecordID.ToString();
            break;
        }
    }
    protected void btnOK_Click(object sender, DirectEventArgs e)
    {
        if (Session["DV_Ma_Don_Vi"] == null || Session["DV_Ma_Don_Vi"].ToString() == "0")
        {
            X.Msg.Alert("Thông báo", "Hãy chọn 1 đơn vị trong Danh mục Đơn vị Y Tế").Show();
        }
       
        else
        {
            X.Msg.AddScript("var parent = window.parent; parent.winDetail.hide();");
        }
        //X.Msg.Alert("", Session["DV_Ma_Phong"] + " -- " + Session["DV_Ma_Don_Vi"]).Show();

    }

    protected void btnBack_Click(object sender, DirectEventArgs e)
    {
        Session["DV_Ma_Phong"] = null;
        Session["DV_Ma_Don_Vi"] = null;
        X.Msg.AddScript("var parent = window.parent; parent.winDetail.hide();");
    }

    private void GenTreeNode(NodeLoadEventArgs e, DataTable myTable)
    {
        for (int i = myTable.Rows.Count-1; i >=0; i--)
        {
            switch (myTable.Rows[i]["Loai_Hinh"].ToString())
            {
                case "2": //Huyện

                case "-4": //CÁC Bệnh viện tuyến Tỉnh

                case "-5": //CÁC Bệnh viện tuyến Huyện

                case "-7": //CÁC Trung tâm tuyến tỉnh
                    AsyncTreeNode asyncNode = new AsyncTreeNode();
                    asyncNode.Text = myTable.Rows[i]["Ten_Don_Vi"].ToString();
                    asyncNode.NodeID = myTable.Rows[i]["Ma_Don_Vi"].ToString();
                    e.Nodes.Add(asyncNode);
                    break;
                default: //Node only
                    Ext.Net.TreeNode treeNode = new Ext.Net.TreeNode();
                    treeNode.Text = myTable.Rows[i]["Ten_Don_Vi"].ToString();
                    treeNode.NodeID = myTable.Rows[i]["Ma_Don_Vi"].ToString();
                    treeNode.Leaf = true;
                    e.Nodes.Add(treeNode);
                    break;
            }
        }
    }
}