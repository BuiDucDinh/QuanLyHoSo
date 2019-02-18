using System;
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

public partial class HT_HT_NhomChucNang : System.Web.UI.Page
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
            ClearDataNCN();

            Initialization();
        }
    }

    private void Initialization()
    {
        //Load combo data
        dsDu_An.DataSource = Sys_Common.HT_DU_AN.Danh_Sach();
        dsDu_An.DataBind();
        cboMa_Du_An.Value = "AT";
    }

    protected void odsNhomChucNang_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        (this.dsNhomChucNang.Proxy[0] as PageProxy).Total = (int)e.OutputParameters["Count"];
    }
    protected void dsNhomChucNang_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        this.odsNhomChucNang.SelectParameters["Start"].DefaultValue = (e.Start + 1).ToString();
        this.odsNhomChucNang.SelectParameters["Limit"].DefaultValue = (e.Limit + e.Start).ToString();

        if ((e.Parameters["Filter"] == "") || (e.Parameters["Filter"] == null))
        {
            this.odsNhomChucNang.SelectParameters["WhereString"].DefaultValue = "HT_Nhom_Chuc_Nang WHERE Ma_Du_An = N'" + cboMa_Du_An.Value.ToString() + "'";
        }
        else
        {
            this.odsNhomChucNang.SelectParameters["WhereString"].DefaultValue = "HT_Nhom_Chuc_Nang WHERE Ma_Du_An = N'" + cboMa_Du_An.Value.ToString() + "' AND"
                + " Ma_Nhom_Chuc_Nang  like N'%" + txtFilterNCN.Text + "%'"
                + " OR Ten_Nhom_Chuc_Nang like N'%" + txtFilterNCN.Text + "%'";

        }
        this.odsNhomChucNang.SelectParameters["SortString"].DefaultValue = e.Sort + " " + e.Dir;

        this.odsNhomChucNang.DataBind();

    }
    
    public void cboMa_Du_An_Click(object sender, DirectEventArgs e)
    {
        txtSearchNCN.Text = "";
        txtSearchCN.Text = "";
        ClearDataNCN();
        X.Msg.AddScript("#{dsNhomChucNang}.reload();");
        X.Msg.AddScript("#{dsChucNang}.reload();");
    }

    protected void gridNhomChucNang_DbClick(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gridNhomChucNang.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            string id = row.RecordID;
            this.SetDataNCN(Sys_Common.HT_NHOM_CHUC_NANG.Lay(id));
            txtSearchCN.Text = "";
            X.Msg.AddScript("#{dsChucNang}.reload();");
            break;
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
    }


    protected void btnDeleteNCN_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gridNhomChucNang.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            Sys_Common.HT_NHOM_CHUC_NANG.Xoa(row.RecordID.ToString());
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
        X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();

        X.Msg.AddScript("#{dsNhomChucNang}.reload();");
        X.Msg.AddScript("#{dsChucNang}.reload();");

    }

    private void SetDataNCN(HT_Nhom_Chuc_Nang_Chi_Tiet myDetail)
    {
        btnUpdateNCN.Text = "Cập nhật";
        btnUpdateNCN.Icon = Icon.ApplicationEdit;

        this.txtMa_Nhom_Chuc_Nang.Text = myDetail.Ma_Nhom_Chuc_Nang;
        this.txtTen_Nhom_Chuc_Nang.Text = myDetail.Ten_Nhom_Chuc_Nang;
        this.txtSTT.Text = myDetail.STT.ToString();
        this.chkDuoc_Hien_Thi.Checked = myDetail.Duoc_Hien_Thi;
    }

    private void ClearDataNCN()
    {
        btnUpdateNCN.Text = "Thêm mới";
        btnUpdateNCN.Icon = Icon.Add;

        this.txtMa_Nhom_Chuc_Nang.Text = "";
        this.txtTen_Nhom_Chuc_Nang.Text = "";        
        this.chkDuoc_Hien_Thi.Checked = true;

    }

    protected void btnUpdateNCN_Click(object sender, DirectEventArgs e)
    {
        if (FormValidateNCN())
        {
            
                //UPDATE
            Sys_Common.HT_NHOM_CHUC_NANG.Cap_Nhat_Them(txtMa_Nhom_Chuc_Nang.Text, cboMa_Du_An.Value.ToString(), txtTen_Nhom_Chuc_Nang.Text, int.Parse(txtSTT.Text), chkDuoc_Hien_Thi.Checked);

            X.Msg.Alert("Thông báo", "Đã cập nhật thành công !!!", new JFunction { Fn = "" }).Show();

            
            ClearDataNCN();

            X.Msg.AddScript("#{dsNhomChucNang}.reload();");
            X.Msg.AddScript("#{dsChucNang}.reload();");
        }

    }

    protected void btnExportNCN_Click(object sender, DirectEventArgs e)
    {
        #region Convert Data JSON
        List<HT_Nhom_Chuc_Nang_Chi_Tiet> lstData = JSON.Deserialize<List<HT_Nhom_Chuc_Nang_Chi_Tiet>>(e.ExtraParams["data"]);
        #endregion

        Type myDetail = typeof(HT_Nhom_Chuc_Nang_Chi_Tiet);

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
            HT_Nhom_Chuc_Nang_Chi_Tiet appDetailItem = lstData[i];
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

        string data = "";//ExcelHelper.CreateExcelContentXmlVersion(range, Server.MapPath"~/Template/HT_Nhom_Chuc_Nang.xml"));

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
    /*
    protected void btnExport_Click(object sender, DirectEventArgs e)
    {
        #region Convert Data JSON
        object o = JSON.Deserialize<object>(e.ExtraParams["data"]);
        #endregion

        #region JSON for use XML
        StringBuilder SB = new StringBuilder();
        SB.Append("{");
        SB.Append("\"?xml\":");
        SB.Append("{");
        SB.Append("\"@version\": \"1.0\",");
        SB.Append("\"@standalone\": \"no\"");
        SB.Append("},");
        SB.Append("\"records\":");
        SB.Append("{");
        SB.Append("\"record\":");
        SB.Append(o.ToString());
        SB.Append("}}");
        #endregion

        #region Convert JSON to XML
        XmlDocument XD = (XmlDocument)JsonConvert.DeserializeXmlNode(@SB.ToString());
        XmlNode XN = XD as XmlNode;
        #endregion

        #region Clear Buffer
        Response.Clear();
        #endregion

        switch (e.ExtraParams["format"].ToString())
        {
            #region Document Type XLS

            case "xls":
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment; filename=Report.xls");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                XslCompiledTransform XCT1 = new XslCompiledTransform();
                //XCT1.Load( Server.MapPath("~/Template/"));
                XmlDocument xDoc1 = new XmlDocument();
                xDoc1.Load(Server.MapPath("~/Template/HT_Nhom_Chuc_Nang.xml"));
                XCT1.Load(xDoc1);
                XCT1.Transform(XN, null, Response.OutputStream);
                break;
            #endregion

            //#region Document Type PDF
            //case "pdf":
            //    using (XmlNodeReader XNR = new XmlNodeReader(XN))
            //    {
            //        using (DataSet DS = new DataSet())
            //        {
            //            DS.ReadXml(XNR);

            //            using (System.Web.UI.WebControls.GridView GridView1 = new System.Web.UI.WebControls.GridView())
            //            {
            //                GridView1.AllowPaging = false;
            //                GridView1.DataSource = DS.Tables[0];
            //                GridView1.DataBind();

            //                Response.ContentType = "application/pdf";
            //                Response.AddHeader("content-disposition", "attachment;filename=Report.pdf");
            //                Response.Cache.SetCacheability(HttpCacheability.NoCache);

            //                using (StringWriter SW = new StringWriter())
            //                {
            //                    using (HtmlTextWriter hw = new HtmlTextWriter(SW))
            //                    {
            //                        GridView1.RenderControl(hw);

            //                        using (StringReader sr = new StringReader(SW.ToString()))
            //                        {
            //                            using (Document D = new Document(PageSize.A4, 10f, 10f, 10f, 0f))
            //                            {
            //                                using (HTMLWorker HW = new HTMLWorker(D))
            //                                {
            //                                    using (PdfWriter.GetInstance(D, Response.OutputStream))
            //                                    {
            //                                        D.Open();
            //                                        HW.Parse(sr);
            //                                        D.Close();
            //                                        Response.Write(D);
            //                                    }
            //                                };
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //    break;
            //#endregion

            #region Document Type DOC
            case "doc":
                using (XmlNodeReader XNR = new XmlNodeReader(XN))
                {
                    using (DataSet DS = new DataSet())
                    {
                        DS.ReadXml(XNR);

                        using (System.Web.UI.WebControls.GridView GridView1 = new System.Web.UI.WebControls.GridView())
                        {
                            GridView1.AllowPaging = false;
                            GridView1.DataSource = DS.Tables[0];
                            GridView1.DataBind();

                            Response.ContentType = "application/vnd.ms-word";
                            Response.AddHeader("content-disposition", "attachment;filename=Report.doc");
                            Response.Cache.SetCacheability(HttpCacheability.NoCache);

                            using (StringWriter SW = new StringWriter())
                            {
                                using (HtmlTextWriter HW = new HtmlTextWriter(SW))
                                {
                                    GridView1.RenderControl(HW);
                                    Response.Output.Write(SW.ToString());
                                }
                            }
                        }
                    }
                }
                break;
            #endregion
        }

        #region Close Buffer
        Response.End();
        #endregion
    }
    */

    private bool FormValidateNCN()
    {
        if (txtMa_Nhom_Chuc_Nang.Text == "")
        {
            X.Msg.Alert("Thông báo", "Hãy nhập đủ các trường có dấu *").Show();
            return false;
        }
        if (txtTen_Nhom_Chuc_Nang.Text == "")
        {
            X.Msg.Alert("Thông báo", "Hãy nhập đủ các trường có dấu *").Show();
            return false;
        }

        if (txtSTT.Text == "")
        {
            X.Msg.Alert("Thông báo", "Hãy nhập đủ các trường có dấu *").Show();
            return false;
        }

        return true;
    }



    protected void odsChucNang_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        (this.dsChucNang.Proxy[0] as PageProxy).Total = (int)e.OutputParameters["Count"];
    }
    protected void dsChucNang_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        this.odsChucNang.SelectParameters["Start"].DefaultValue = (e.Start + 1).ToString();
        this.odsChucNang.SelectParameters["Limit"].DefaultValue = (e.Limit + e.Start).ToString();

        if ((e.Parameters["Filter"] == "")||(e.Parameters["Filter"] == null))
        {
            this.odsChucNang.SelectParameters["WhereString"].DefaultValue = "HT_Chuc_Nang WHERE Ma_Nhom_Chuc_Nang = N'" + txtMa_Nhom_Chuc_Nang.Text + "'";
        }
        else
        {
            this.odsChucNang.SelectParameters["WhereString"].DefaultValue = "HT_Chuc_Nang WHERE Ma_Nhom_Chuc_Nang = N'" + txtMa_Nhom_Chuc_Nang.Text.ToString() + "' AND"
                + " Ma_Chuc_Nang  like N'%" + txtFilterCN.Text + "%'"
                + " OR Ten_Chuc_Nang like N'%" + txtFilterCN.Text + "%'";

        }
        this.odsChucNang.SelectParameters["SortString"].DefaultValue = e.Sort + " " + e.Dir;

        this.odsChucNang.DataBind();

    }


    protected void gridChucNang_DbClick(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gridChucNang.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            string id = row.RecordID;
            this.SetDataCN(Sys_Common.HT_CHUC_NANG.Lay(id));
            break;
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
    }


    protected void btnDeleteCN_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gridChucNang.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            Sys_Common.HT_CHUC_NANG.Xoa(row.RecordID.ToString());
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
        X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();

        X.Msg.AddScript("#{dsChucNang}.reload();");

    }

    private void SetDataCN(HT_Chuc_Nang_Chi_Tiet myDetail)
    {
        btnUpdateCN.Text = "Cập nhật";
        btnUpdateCN.Icon = Icon.ApplicationEdit;

        this.txtMa_Chuc_Nang.Text = myDetail.Ma_Chuc_Nang;
        this.txtTen_Chuc_Nang.Text = myDetail.Ten_Chuc_Nang;
        this.txtSTTCN.Text = myDetail.STT.ToString();
        this.chkDuoc_Hien_ThiCN.Checked = myDetail.Duoc_Hien_Thi;
        this.txtIcon.Text = myDetail.Icon;
        this.txtDuong_Dan.Text = myDetail.Duong_Dan;
    }

    private void ClearDataCN()
    {
        btnUpdateCN.Text = "Thêm mới";
        btnUpdateCN.Icon = Icon.Add;

        this.txtMa_Chuc_Nang.Text = "";
        this.txtTen_Chuc_Nang.Text = "";
        this.chkDuoc_Hien_ThiCN.Checked = true;
        this.txtDuong_Dan.Text = "";

    }

    protected void btnUpdateCN_Click(object sender, DirectEventArgs e)
    {
        if (FormValidateCN())
        {

            //UPDATE
            Sys_Common.HT_CHUC_NANG.Cap_Nhat_Them(txtMa_Chuc_Nang.Text, txtMa_Nhom_Chuc_Nang.Text, txtTen_Chuc_Nang.Text, int.Parse(txtSTTCN.Text), chkDuoc_Hien_ThiCN.Checked,txtIcon.Text,txtDuong_Dan.Text);

            X.Msg.Alert("Thông báo", "Đã cập nhật thành công !!!", new JFunction { Fn = "" }).Show();


            ClearDataCN();

            X.Msg.AddScript("#{dsChucNang}.reload();");
        }

    }

   
    private bool FormValidateCN()
    {
        if (txtMa_Nhom_Chuc_Nang.Text == "")
        {
            X.Msg.Alert("Thông báo", "Hãy nhập thông tin mã nhóm chức năng").Show();
            return false;
        }
        if (txtMa_Chuc_Nang.Text == "")
        {
            X.Msg.Alert("Thông báo", "Hãy nhập đủ các trường có dấu *").Show();
            return false;
        }
        if (txtTen_Chuc_Nang.Text == "")
        {
            X.Msg.Alert("Thông báo", "Hãy nhập đủ các trường có dấu *").Show();
            return false;
        }

        if (txtSTTCN.Text == "")
        {
            X.Msg.Alert("Thông báo", "Hãy nhập đủ các trường có dấu *").Show();
            return false;
        }

        return true;
    }
}