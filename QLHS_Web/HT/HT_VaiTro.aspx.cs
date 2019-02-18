﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
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
public partial class HT_HT_VaiTro : System.Web.UI.Page
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
                        
        }
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
            this.odsData.SelectParameters["WhereString"].DefaultValue = "HT_Vai_Tro";
        }
        else
        {
            this.odsData.SelectParameters["WhereString"].DefaultValue = "HT_Vai_Tro WHERE "                
                + " Ten_Vai_Tro like N'%" + txtFilter.Text + "%'";

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
            this.SetData(Sys_Common.HT_VAI_TRO.Lay(id));
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
            Sys_Common.HT_VAI_TRO.Xoa(int.Parse(row.RecordID.ToString()));
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
        X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();

        X.Msg.AddScript("#{dsData}.reload();");

    }

    protected void btnDuAn_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gridData.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {            
            this.winDuAn.AutoLoad.Url = "HT_VaiTroDuAn.aspx?Ma_Vai_Tro=" + row.RecordID.ToString();
            this.winDuAn.AutoLoad.Mode = LoadMode.IFrame;

            this.winDuAn.Render(this.Form);
            this.winDuAn.Show();
            break;
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
    }

    protected void btnChucNang_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gridData.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            this.winChucNang.AutoLoad.Url = "HT_VaiTroChucNang.aspx?Ma_Vai_Tro=" + row.RecordID.ToString();
            this.winChucNang.AutoLoad.Mode = LoadMode.IFrame;

            this.winChucNang.Render(this.Form);
            this.winChucNang.Show();
            break;
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
    }

    private void SetData(HT_Vai_Tro_Chi_Tiet myDetail)
    {
        btnUpdate.Text = "Cập nhật";
        btnUpdate.Icon = Icon.ApplicationEdit;

        this.txtMa_Vai_Tro.Text = myDetail.Ma_Vai_Tro.ToString();
        this.txtTen_Vai_Tro.Text = myDetail.Ten_Vai_Tro;
        this.txtSTT.Text = myDetail.STT.ToString();
        
    }

    private void ClearData()
    {
        btnUpdate.Text = "Thêm mới";
        btnUpdate.Icon = Icon.Add;

        this.txtMa_Vai_Tro.Text = "0";
        this.txtTen_Vai_Tro.Text = "";
        
    }

    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        if (FormValidate())
        {
            if (this.txtMa_Vai_Tro.Text == "0")
            {
                //INSERT
                Sys_Common.HT_VAI_TRO.Them(int.Parse(txtMa_Vai_Tro.Text), txtTen_Vai_Tro.Text,int.Parse(txtSTT.Text));

                X.Msg.Alert("Thông báo", "Đã thêm mới thành công !!!", new JFunction { Fn = "" }).Show();
            }
            else
            {
                //UPDATE
                Sys_Common.HT_VAI_TRO.Cap_Nhat(int.Parse(txtMa_Vai_Tro.Text), txtTen_Vai_Tro.Text, int.Parse(txtSTT.Text));

                X.Msg.Alert("Thông báo", "Đã cập nhật thành công !!!", new JFunction { Fn = "" }).Show();

            }
            ClearData();

            X.Msg.AddScript("#{dsData}.reload();");
        }

    }

    protected void btnExport_Click(object sender, DirectEventArgs e)
    {
        #region Convert Data JSON
        List<HT_Vai_Tro_Chi_Tiet> lstData = JSON.Deserialize<List<HT_Vai_Tro_Chi_Tiet>>(e.ExtraParams["data"]);
        #endregion

        Type myDetail = typeof(HT_Vai_Tro_Chi_Tiet);

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
            HT_Vai_Tro_Chi_Tiet appDetailItem = lstData[i];
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

        string data = "";//ExcelHelper.CreateExcelContentXmlVersion(range, Server.MapPath("~/Template/HT_Vai_Tro.xml"));

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
        if (txtTen_Vai_Tro.Text == "")
        {
            X.Msg.Alert("Thông báo", "Hãy nhập đủ các trường có dấu *").Show();
            return false;
        }
        
        return true;
    }
}