﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Xsl;
using Ext.Net;
using Newtonsoft.Json;
using QLHS_Logic;
using System.Data;
using System.Reflection;
using System.IO;
using System.ComponentModel;
using System.Linq.Expressions;
public partial class HT_HT_DMHuyen : System.Web.UI.Page
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
        dsDM_Tinh.DataSource = Sys_Common.HT_DM_TINH.Danh_Sach();
        dsDM_Tinh.DataBind();
    }

    protected void odsData_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        (this.dsData.Proxy[0] as PageProxy).Total = (int)e.OutputParameters["Count"];
    }
    protected void dsData_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        this.odsData.SelectParameters["Start"].DefaultValue = (e.Start + 1).ToString();
        this.odsData.SelectParameters["Limit"].DefaultValue = (e.Limit + e.Start).ToString();

        string where = "";
        try
        {
            if (cboMa_Tinh.Value.ToString() != "")
            {
                where = " and Ma_Tinh='" + cboMa_Tinh.Value.ToString() + "'";
            }
        }
        catch { }
        if (e.Parameters["Filter"] == "")
        {
            this.odsData.SelectParameters["WhereString"].DefaultValue = "(select * from HT_DM_Huyen where 1=1" + where + ") as A";
        }
        else
        {
            this.odsData.SelectParameters["WhereString"].DefaultValue = "HT_DM_Huyen WHERE "
                + "(Ten_Huyen like N'%" + txtFilter.Text + "%'"
                + " OR Ma_Huyen ='" + txtFilter.Text + "')";

        }
        this.odsData.SelectParameters["SortString"].DefaultValue = e.Sort + " " + e.Dir;

        this.odsData.DataBind();

    }

    protected void cboMa_Tinh_Change(object sender, DirectEventArgs e)
    {
        X.Msg.AddScript("#{dsData}.reload();");
    }

    protected void grid_DbClick(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gridData.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            string id = row.RecordID;
            this.SetData(Sys_Common.HT_DM_HUYEN.Lay(id));
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
            Sys_Common.HT_DM_HUYEN.Xoa(row.RecordID.ToString());
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
        X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();

        X.Msg.AddScript("#{dsData}.reload();");

    }

    private void SetData(HT_DM_Huyen_Chi_Tiet myDetail)
    {
        btnUpdate.Text = "Cập nhật";
        btnUpdate.Icon = Icon.ApplicationEdit;

        this.txtTen_Huyen.Text = myDetail.Ten_Huyen;
        this.txtSo_Thu_Tu.Text = myDetail.STT.ToString();
        this.cboMa_Tinh.Value = myDetail.Ma_Tinh;


        //hidden attributes
        this.txtMa_Huyen.Text = myDetail.Ma_Huyen.ToString();
    }

    private void ClearData()
    {
        btnUpdate.Text = "Thêm mới";
        btnUpdate.Icon = Icon.Add;

        this.txtTen_Huyen.Text = "";

        this.txtSo_Thu_Tu.Text = "";
        this.cboHinh_Nen.Value = "";
        this.cboMa_Tinh.Value = "";

        //hidden attributes
        this.txtMa_Huyen.Text = "";

    }

    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        if (FormValidate())
        {

            Sys_Common.HT_DM_HUYEN.Cap_Nhat_Them(txtMa_Huyen.Text, cboMa_Tinh.Value.ToString(), txtTen_Huyen.Text, int.Parse("0" + txtSo_Thu_Tu.Text));


            X.Msg.Alert("Thông báo", "Đã cập nhật thành công !!!", new JFunction { Fn = "" }).Show();

            ClearData();

            X.Msg.AddScript("#{dsData}.reload();");
        }

    }

    protected void btnExport_Click(object sender, DirectEventArgs e)
    {
        #region Convert Data JSON
        List<HT_DM_Huyen_Chi_Tiet> lstData = JSON.Deserialize<List<HT_DM_Huyen_Chi_Tiet>>(e.ExtraParams["data"]);
        #endregion

        Type myDetail = typeof(HT_DM_Huyen_Chi_Tiet);

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
            HT_DM_Huyen_Chi_Tiet appDetailItem = lstData[i];
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

        string data = ExcelHelper.CreateExcelContentXmlVersion(range, Server.MapPath("~/Template/HT_DM_Huyen.xml"));

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
        if (txtMa_Huyen.Text == "")
        {
            X.Msg.Alert("Thông báo", "Hãy nhập đủ các trường có dấu *").Show();
            return false;
        }

        if (txtTen_Huyen.Text == "")
        {
            X.Msg.Alert("Thông báo", "Hãy nhập đủ các trường có dấu *").Show();
            return false;
        }

        return true;
    }
}