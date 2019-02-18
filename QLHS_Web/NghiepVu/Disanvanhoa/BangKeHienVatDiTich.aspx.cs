using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using System.Data;
using QLHS_Logic;
using QLHS_Logic.NV;
using System.Web.Script.Serialization;
using System.Xml.Xsl;
using System.Xml;
public partial class NghiepVu_DiSanVanHoa_BangKeHienVatDiTich : System.Web.UI.Page
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
    private void Initialization()
    {
        Role role = getRole();
        hdRole.Value = new JavaScriptSerializer().Serialize(role);       
        DataBind();
    }
    protected void odsData_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        (this.stData.Proxy[0] as PageProxy).Total = (int)e.OutputParameters["Count"];
    }
    protected void stData_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        this.odsData.SelectParameters["Start"].DefaultValue = (e.Start + 1).ToString();
        this.odsData.SelectParameters["Limit"].DefaultValue = (e.Limit + e.Start).ToString();
        string dk = "";       
        if (!string.IsNullOrEmpty(txtTenDiTich.Text))
        {
            dk += " and DiSanID in (SELECT DiSanID FROM DiSanVanHoa JOIN DM_LoaiDiSan ON DM_LoaiDiSan.LoaiID = DiSanVanHoa.LoaiDiSan WHERE DM_LoaiDiSan.Loai=1 AND TenDiSan like N'%" + txtTenDiTich.Text + "%')";
        }
        this.odsData.SelectParameters["WhereString"].DefaultValue = @"(SELECT ROW_NUMBER()OVER(ORDER BY ID) AS TT,TenDiSan,SoDangKy,SLDiVat,B.SLCoVat,B.SLBaoVat,(SLDiVat+B.SLCoVat+B.SLBaoVat) AS TongSl 
FROM (SELECT DiSanID AS ID,TenDiSan,SoDangKy
,(SELECT COUNT(ID) FROM dbo.DiVatCoVat WHERE DiSanID=dbo.DiSanVanHoa.DiSanID AND dbo.DiVatCoVat.PhanLoai=1) AS SLDiVat
,(SELECT COUNT(ID) FROM dbo.DiVatCoVat WHERE DiSanID=dbo.DiSanVanHoa.DiSanID AND dbo.DiVatCoVat.PhanLoai=2) AS SLCoVat
,(SELECT COUNT(ID) FROM dbo.DiVatCoVat WHERE DiSanID=dbo.DiSanVanHoa.DiSanID AND dbo.DiVatCoVat.PhanLoai=3) AS SLBaoVat
FROM dbo.DiSanVanHoa WHERE TonTai=1 " + dk + ")B) AS A";
        this.odsData.SelectParameters["SortString"].DefaultValue = e.Sort + " " + e.Dir;

        this.odsData.DataBind();

    }
    protected void gvData_DbClick(object sender, DirectEventArgs e)
    {
        
    }
    [DirectMethod]
    public void Command(string command, string value)
    {
        int ID = int.Parse(value);
        if (command == "Delete")
        {
            Sys_Common.NV_DiVatCoVat.Xoa(ID);
            int maND = int.Parse(Session["G_Ma_Nguoi_Dung"].ToString());
            NV_Log_ChiTiet log = createLog(ID, "delete");
            Sys_Common.NV_Log.them(log);

            X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
            X.Msg.AddScript("#{stData}.reload();");
            return;
        }
        else if (command == "Active")
        {
            NV_DiVatCoVat_ChiTiet divat = Sys_Common.NV_DiVatCoVat.GetById(ID);
            divat.TrangThai = !divat.TrangThai;
            bool check = Sys_Common.NV_DiVatCoVat.update(divat);
            if (check)
            {
                string thaotac = divat.TrangThai ? "active" : "unactive";
                NV_Log_ChiTiet log = createLog(ID, thaotac);
                Sys_Common.NV_Log.them(log);
                X.Msg.AddScript("#{stData}.reload();");
            }
        }
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        
    }
    protected void btnShow_Click(object sender, DirectEventArgs e)
    {
       
    }
    protected void btnDelete_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gvData.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            int id = int.Parse(row.RecordID);
            Sys_Common.NV_DiVatCoVat.Xoa(id);
            NV_Log_ChiTiet log = createLog(id, "delete");
            Sys_Common.NV_Log.them(log);
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
        X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
        X.Msg.AddScript("#{stData}.reload();");
    }
    protected void btnExportDeTail_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gvData.SelectionModel.Primary as RowSelectionModel;
        string maForm = Request.QueryString["cn"].ToString();

        int id = int.Parse(sm.SelectedRows[0].RecordID);        
    }
    protected void btnExport_Click(object sender, DirectEventArgs e)
    {
        string json = e.ExtraParams["data"].ToString();
        StoreSubmitDataEventArgs eSubmit = new StoreSubmitDataEventArgs(json, null);
        XmlNode xml = eSubmit.Xml;

        this.Response.Clear();
        this.Response.ContentType = "application/vnd.ms-excel";
        this.Response.AddHeader("Content-Disposition", "attachment; filename=TKHienVatDiTich.xls");
        XslCompiledTransform xtExcel = new XslCompiledTransform();
        xtExcel.Load(Server.MapPath("/NghiepVu/Resources/Excel.xsl"));
        xtExcel.Transform(xml, null, this.Response.OutputStream);
        this.Response.End();
    }
    protected void btnCancel_Click(object sender, DirectEventArgs e)
    {
        txtTenDiTich.Text = "";
        X.Msg.AddScript("#{stData}.reload();");
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