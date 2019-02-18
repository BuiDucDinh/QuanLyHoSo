using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using QLHS_Logic;
using Newtonsoft.Json;
using System.Data;
using System.Reflection;
using System.IO;
using System.ComponentModel;
using System.Linq.Expressions;
public partial class HT_HT_DMTuan : System.Web.UI.Page
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
            ClearData();

            Initialization();
        }
    }
    private void Initialization()
    {
        //Load combo data       
    }

    protected void odsData_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        (this.dsData.Proxy[0] as PageProxy).Total = (int)e.OutputParameters["Count"];
    }
    protected void dsData_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        this.odsData.SelectParameters["Start"].DefaultValue = (e.Start + 1).ToString();
        this.odsData.SelectParameters["Limit"].DefaultValue = (e.Limit + e.Start).ToString();

        if (e.Parameters["Filter"] == "")
        {
            this.odsData.SelectParameters["WhereString"].DefaultValue = "HT_DM_Tuan";
        }
        else
        {
            this.odsData.SelectParameters["WhereString"].DefaultValue = "HT_DM_Tuan WHERE "
                + " Tuan_So = '" + txtFilter.Text + "'"
                + " OR Nam_Tinh ='" + txtFilter.Text + "'";

        }
        this.odsData.SelectParameters["SortString"].DefaultValue = e.Sort + " " + e.Dir;

        this.odsData.DataBind();

    }


    protected void grid_DbClick(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gridData.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            int id = int.Parse(row.RecordID);
            this.SetData(Sys_Common.HT_DM_TUAN.Lay(id));
            break;
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
    }


    protected void btnDelete_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gridData.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            Sys_Common.HT_DM_TUAN.Xoa(int.Parse(row.RecordID.ToString()));
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
        X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();

        X.Msg.AddScript("#{dsData}.reload();");

    }

    private void SetData(HT_DM_Tuan_Chi_Tiet myDetail)
    {
        btnUpdate.Text = "Cập nhật";
        btnUpdate.Icon = Icon.ApplicationEdit;      
        //this.txtMat_Khau.Text = Sys_Common.Decrypt(myDetail.Mat_Khau, Sys_Common.Key);
        this.txtTuan_So.Text = myDetail.Tuan_So.ToString();
        this.txtNam_Tinh.Text = myDetail.Nam_Tinh.ToString();
        //this.cboHinh_Nen.Value = myDetail.Hinh_Nen;  
        this.dteTu_Ngay.SelectedDate = DateTime.Parse(myDetail.Tu_Ngay.ToString());
        this.dteDen_Ngay.SelectedDate = DateTime.Parse(myDetail.Den_Ngay.ToString());

        //hidden attributes       
        this.txtMa_Tuan.Text = myDetail.Ma_Tuan.ToString();
    }


    private void ClearData()
    {
        btnUpdate.Text = "Thêm mới";
        btnUpdate.Icon = Icon.Add;

        this.txtTuan_So.Text = "0";
        this.txtNam_Tinh.Text = DateTime.Now.Year.ToString() ;
        this.cboHinh_Nen.Value = "";
        this.dteTu_Ngay.SelectedDate = DateTime.Now;
        this.dteDen_Ngay.SelectedDate = DateTime.Now.AddDays(7);
        //hidden attributes
        this.txtMa_Tuan.Text = "0";

    }

    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        if (FormValidate())
        {

            if (this.txtMa_Tuan.Text == "0")
            {
                //INSERT
                Sys_Common.HT_DM_TUAN.Them(int.Parse(txtMa_Tuan.Text), int.Parse(txtTuan_So.Text),int.Parse(txtNam_Tinh.Text), dteTu_Ngay.SelectedDate, dteDen_Ngay.SelectedDate);
                   

                X.Msg.Alert("Thông báo", "Đã thêm mới thành công !!!", new JFunction { Fn = "" }).Show();
            }
            else
            {
                //UPDATE
                Sys_Common.HT_DM_TUAN.Cap_Nhat(int.Parse(txtMa_Tuan.Text), int.Parse(txtTuan_So.Text), int.Parse(txtNam_Tinh.Text), dteTu_Ngay.SelectedDate, dteDen_Ngay.SelectedDate);                   

                X.Msg.Alert("Thông báo", "Đã cập nhật thành công !!!", new JFunction { Fn = "" }).Show();

            }
            ClearData();

            X.Msg.AddScript("#{dsData}.reload();");
        }

    }

    protected void btnExport_Click(object sender, DirectEventArgs e)
    {
        #region Convert Data JSON
        List<HT_DM_Tuan_Chi_Tiet> lstData = JSON.Deserialize<List<HT_DM_Tuan_Chi_Tiet>>(e.ExtraParams["data"]);
        #endregion

        Type myDetail = typeof(HT_DM_Tuan_Chi_Tiet);

        int colCount = myDetail.GetProperties().Count();
        int rowCount = lstData.Count;

        string[,] range = new string[rowCount + 1, colCount];
        int colIndex = 0;
        int rowIndex = 0;

        // Header row
        foreach (PropertyInfo info in myDetail.GetProperties())
        {
            range[rowIndex, colIndex] = info.Name;
            colIndex++;
        }

        // Content row
        rowIndex++;
        for (int i = 0; i < rowCount; i++)
        {
            HT_DM_Tuan_Chi_Tiet appDetailItem = lstData[i];
            colIndex = 0;
            foreach (PropertyInfo info in myDetail.GetProperties())
            {
                object o = info.GetValue(appDetailItem, null);
                if (o != null)
                    range[rowIndex, colIndex] = o.ToString();
                else
                    range[rowIndex, colIndex] = "";
                colIndex++;
            }
            rowIndex++;
        }

        string data = ExcelHelper.CreateExcelContentXmlVersion(range, Server.MapPath("~/Template/HT_DM_Tuan.xml"));

        #region Clear Buffer
        Response.Clear();
        #endregion

        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment; filename=Report.xls");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Write(data);
        Response.Flush();

        #region Close Buffer
        Response.End();
        #endregion

        X.Msg.Alert("Thông báo", "Đã xuất báo cáo thành công!").Show();
    }

    public static class PropertyHelper<T>
    {
        public static PropertyInfo GetProperty<TValue>(
            Expression<Func<T, TValue>> selector)
        {
            Expression body = selector;
            if (body is LambdaExpression)
            {
                body = ((LambdaExpression)body).Body;
            }
            switch (body.NodeType)
            {
                case ExpressionType.MemberAccess:
                    return (PropertyInfo)((MemberExpression)body).Member;
                default:
                    throw new InvalidOperationException();
            }
        }
    }

    private bool FormValidate()
    {
        if (txtNam_Tinh.Text == "")
        {
            X.Msg.Alert("Thông báo", "Hãy nhập đủ các trường có dấu *").Show();
            return false;
        }
        if (txtTuan_So.Text == "")
        {
            X.Msg.Alert("Thông báo", "Hãy nhập đủ các trường có dấu *").Show();
            return false;
        }
        return true;
    }
}