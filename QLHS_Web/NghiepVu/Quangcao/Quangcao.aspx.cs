using Ext.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Ext.Net;
using QLHS_Logic;
using QLHS_Logic.NV;

public partial class NghiepVu_Quangcao_Quangcao : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            if (Session["G_Theme"] != null)
            {
                DHM_Common.SetTheme(this.Page, int.Parse(Session["G_Theme"].ToString()));
            }
            Initialization();
        }
    }
    protected void odsAdv_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        (this.stData.Proxy[0] as PageProxy).Total = (int)e.OutputParameters["Count"];
    }

    protected void stData_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        this.odsAdv.SelectParameters["Start"].DefaultValue = (e.Start + 1).ToString();
        this.odsAdv.SelectParameters["Limit"].DefaultValue = (e.Limit + e.Start).ToString();
        string where = "";
        int type = 0;
        try
        {
            type = int.Parse(cmbType.Value.ToString());
        }
        catch { }
        if (type != 0)
        {
            where = " and Type=" + type;
        }
        if (e.Parameters["Filter"] != "")
        {
            where = " and Name like '%," + e.Parameters["Filter"] + ",%'";
        }
        this.odsAdv.SelectParameters["WhereString"].DefaultValue = @"(select ID,(select TenAnh from Image i where i.ImageID=q.ImageID) as Image,
		                                                                    Link,Description,Target,IsImage,
		                                                                    Name,Type,Duyet,
		                                                                    (select TenMenu from Menu m where m.MenuID=q.MenuID) as Menu
                                                                     from Quangcao q where 1=1" + where + ") as A";
        this.odsAdv.SelectParameters["SortString"].DefaultValue = e.Sort + " " + e.Dir;

        this.odsAdv.DataBind();

    }
    public void Initialization()
    {
        string mappath = HttpContext.Current.Server.MapPath("~/XMLData/TypeOfAdv.xml");
        XDocument xmldoc = XDocument.Load(mappath);
        IEnumerable<XElement> q = from xe in xmldoc.Descendants("type") select xe;

        var dt = new DataTable();
        dt.Columns.Add("key");
        dt.Columns.Add("name");
        dt.Columns.Add("value");

        foreach (XElement xe in q)
        {
            DataRow row = dt.NewRow();
            row[0] = xe.Attribute("key").Value;
            row[1] = xe.Attribute("name").Value;
            row[2] = xe.Attribute("value").Value;
            dt.Rows.Add(row); // Thêm dòng mới vào dtb
        }
        stType.DataSource = dt;
        stType.DataBind();
    }

    protected void btnLoc_Click(object sender, DirectEventArgs e)
    {
        X.Msg.AddScript("#{stData}.reload();");
    }
    protected void gvData_DbClick(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gvData.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            this.wdDetail.AutoLoad.Url = "~/NghiepVu/Quangcao/CapNhatQuangcao.aspx?id=" + row.RecordID;
            this.wdDetail.Icon = Icon.ApplicationEdit;
            this.wdDetail.Title = "Sửa quảng cáo";
            this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
            this.wdDetail.Render(this.Form);
            this.wdDetail.Show();
            break;
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
    }

    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        this.wdDetail.AutoLoad.Url = "~/NghiepVu/Quangcao/CapNhatQuangcao.aspx";
        this.wdDetail.Icon = Icon.Add;
        this.wdDetail.Title = "Thêm mới quảng cáo";
        this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
        this.wdDetail.Render(this.Form);
        this.wdDetail.Show();
    }

    protected void btnDelete_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gvData.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            Sys_Common.NV_Quangcao.Xoa(int.Parse(row.RecordID));
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
        X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
        X.Msg.AddScript("#{stData}.reload();");
    }
    protected void btnExport_Click(object sender, DirectEventArgs e) { }

}