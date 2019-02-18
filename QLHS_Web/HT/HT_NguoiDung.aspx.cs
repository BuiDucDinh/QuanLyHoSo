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

public partial class HT_NguoiDung : System.Web.UI.Page
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
        dsDon_Vi.DataSource = Sys_Common.HT_DON_VI_YT.Danh_Sach();
        dsDon_Vi.DataBind();
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
            this.odsData.SelectParameters["WhereString"].DefaultValue = "HT_Nguoi_Dung";
        }
        else
        {
            this.odsData.SelectParameters["WhereString"].DefaultValue = "HT_Nguoi_Dung WHERE "
                + " Ten_Dang_Nhap LIKE N'%" + txtFilter.Text + "%'"
                + " OR Ho_Ten like N'%" + txtFilter.Text + "%'"
                + " OR Hom_Thu = '" + txtFilter.Text + "'"
                + " OR Dien_Thoai ='" + txtFilter.Text + "'";

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
            this.SetData(Sys_Common.HT_NGUOI_DUNG.Lay(id));
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
            Sys_Common.HT_NGUOI_DUNG.Xoa(int.Parse(row.RecordID.ToString()));
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
        X.Msg.Alert("Thông báo", "Đã xóa thành công !!!", new JFunction { Fn = "" }).Show();
        X.Msg.AddScript("#{dsData}.reload();");
    }

    private void SetData(HT_Nguoi_Dung_Chi_Tiet myDetail)
    {
        btnUpdate.Text = "Cập nhật";
        btnUpdate.Icon = Icon.ApplicationEdit;

        this.txtTen_Dang_Nhap.Text = myDetail.Ten_Dang_Nhap;
        this.txtMat_Khau.Text = Sys_Common.Decrypt(myDetail.Mat_Khau, Sys_Common.Key);
        this.txtHom_Thu.Text = myDetail.Hom_Thu;
        this.cboHinh_Nen.Value = myDetail.Hinh_Nen;
        this.cboMa_Don_Vi.Value = myDetail.Ma_Don_Vi;
        this.chkDuoc_Kich_Hoat.Checked = myDetail.Duoc_Kich_Hoat;
        this.txtHo_Ten.Text = myDetail.Ho_Ten;
        this.txtDien_Thoai.Text = myDetail.Dien_Thoai;

        //hidden attributes
        this.txtMa_Nguoi_Dung.Text = myDetail.Ma_Nguoi_Dung.ToString();
    }

    private void ClearData()
    {
        btnUpdate.Text = "Thêm mới";
        btnUpdate.Icon = Icon.Add;

        this.txtTen_Dang_Nhap.Text = "";
        this.txtMat_Khau.Text = "";
        this.txtHom_Thu.Text = "";
        this.cboHinh_Nen.Value = "";
        this.cboMa_Don_Vi.Value = "";
        this.chkDuoc_Kich_Hoat.Checked = true;
        this.txtDien_Thoai.Text = "";
        this.txtHo_Ten.Text = "";
        this.cboHinh_Nen.Value = "1";
        //hidden attributes
        this.txtMa_Nguoi_Dung.Text = "0";
    }

    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        if (FormValidate())
        {
            if (this.txtMa_Nguoi_Dung.Text == "0")
            {
                //INSERT
                string count = Sys_Common.CalBySQL("SELECT COUNT(*) FROM HT_Nguoi_Dung WHERE Ten_Dang_Nhap = N'" + txtTen_Dang_Nhap.Text.Trim() + "'");
                if (count != "0")
                {
                    X.Msg.Alert("Thông báo", "Đã có một người dùng trong hệ thống sử dụng tên đăng nhập này !!!", new JFunction { Fn = "" }).Show();
                    return;
                }
                Sys_Common.HT_NGUOI_DUNG.Them(int.Parse(txtMa_Nguoi_Dung.Text), int.Parse(cboMa_Don_Vi.Value.ToString()), txtTen_Dang_Nhap.Text,
                    Sys_Common.Encrypt(txtMat_Khau.Text, Sys_Common.Key), txtHo_Ten.Text, txtHom_Thu.Text, txtDien_Thoai.Text, chkDuoc_Kich_Hoat.Checked, int.Parse(cboHinh_Nen.Value.ToString()));

                X.Msg.Alert("Thông báo", "Đã thêm mới thành công !!!", new JFunction { Fn = "" }).Show();
            }
            else
            {
                //UPDATE
                //Sys_Common.HT_NGUOI_DUNG.Cap_Nhat(int.Parse(txtMa_Nguoi_Dung.Text), int.Parse(cboMa_Don_Vi.Value.ToString()), txtTen_Dang_Nhap.Text,
                //    Sys_Common.Encrypt(txtMat_Khau.Text, Sys_Common.Key), txtHo_Ten.Text, txtHom_Thu.Text, txtDien_Thoai.Text, chkDuoc_Kich_Hoat.Checked, int.Parse(cboHinh_Nen.Value.ToString()));

                X.Msg.Alert("Thông báo", "Đã cập nhật thành công !!!", new JFunction { Fn = "" }).Show();
            }
            ClearData();
            X.Msg.AddScript("#{dsData}.reload();");
        }
    }
    protected void btnVaiTro_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = gridData.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            this.winVaiTro.AutoLoad.Url = "HT_NguoiDungVaiTro.aspx?Ma_Nguoi_Dung=" + row.RecordID.ToString();
            this.winVaiTro.AutoLoad.Mode = LoadMode.IFrame;

            this.winVaiTro.Render(this.Form);
            this.winVaiTro.Show();
            break;
        }
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
    }
    [DirectMethod]
    public void btnUrl_Click(String Where)
    {        
        this.winHT_Don_Vi_YTe.AutoLoad.Url = "HT_DonViYTChon.aspx?Module="+Where;
        this.winHT_Don_Vi_YTe.AutoLoad.Mode = LoadMode.IFrame;
        this.winHT_Don_Vi_YTe.Render(this.Form);
        this.winHT_Don_Vi_YTe.Show();
    }
    protected void winHT_Don_Vi_YTe_Hide(object sender, DirectEventArgs e)
    {
        if (Session["HT_Ma_Don_Vi_Chon"] != null)
        {
            cboMa_Don_Vi.Value = Session["HT_Ma_Don_Vi_Chon"].ToString();
            Session["HT_Ma_Don_Vi_Chon"] = null;
        }
    }
    protected void btnExport_Click(object sender, DirectEventArgs e)
    {
        #region Convert Data JSON
        List<HT_Nguoi_Dung_Chi_Tiet> lstData = JSON.Deserialize<List<HT_Nguoi_Dung_Chi_Tiet>>(e.ExtraParams["data"]);
        #endregion

        Type myDetail = typeof(HT_Nguoi_Dung_Chi_Tiet);

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
            HT_Nguoi_Dung_Chi_Tiet appDetailItem = lstData[i];
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

        string data = "";//ExcelHelper.CreateExcelContentXmlVersion(range, Server.MapPath"~/Template/HT_Nguoi_Dung.xml"));

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
                xDoc1.Load(Server.MapPath("~/Template/HT_Nguoi_Dung.xml"));
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

    private bool FormValidate()
    {
        if (txtTen_Dang_Nhap.Text == "")
        {
            X.Msg.Alert("Thông báo", "Hãy nhập đủ các trường có dấu *").Show();
            return false;
        }
        if (txtMat_Khau.Text == "")
        {
            X.Msg.Alert("Thông báo", "Hãy nhập đủ các trường có dấu *").Show();
            return false;
        }

        if (txtHo_Ten.Text == "")
        {
            X.Msg.Alert("Thông báo", "Hãy nhập đủ các trường có dấu *").Show();
            return false;
        }
        return true;
    }
}