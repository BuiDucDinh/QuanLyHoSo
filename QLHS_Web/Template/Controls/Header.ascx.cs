using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net.Examples;
using QLHS_Logic;

public partial class Template_Controls_Header : BaseUserControl
{
    public string logo = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        {
            loadData();
        }
    }
    private void loadData()
    {
        DataTable dt = Sys_Common.NV_Menu.GetByParent("0", "1", GetLang());
        if (dt != null && dt.Rows.Count > 0)
        {
            rptMenu.DataSource = dt;
            rptMenuDesktop.DataSource = dt;
            DataBind();
        }
        lbTime.Text = getTime();
        string sql = "select top 1 (select TenAnh from Image i where i.ImageID=q.ImageID) as Image,Link,Description,Target,IsImage from Quangcao q where Duyet=1 and Type=2 order by Stt";
        dt = Sys_Common.getDataByQuery(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            pnBanber.BackImageUrl = "/FileUpload/Images/" + dt.Rows[0]["Image"].ToString();
        }
        sql = "select top 1 (select TenAnh from Image i where i.ImageID=q.ImageID) as Image,Link,Description,Target,IsImage from Quangcao q where Duyet=1 and Type=1 order by Stt";
        dt = Sys_Common.getDataByQuery(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            bool isImage = Convert.ToBoolean(dt.Rows[0]["IsImage"]);
            if (isImage)
            {
                string srcImg = "/Template/images/logo.png";
                try
                {
                    srcImg = "/FileUpload/images/" + dt.Rows[0]["Image"].ToString();
                }
                catch { }
                logo = @"<a href=""/"" class=""header-logo"">
                                <img src=""" + srcImg + @""" alt=""Di sản văn hóa Thanh Hóa"" class=""img-responsive"">
                            </a>";

            }
            else
            {
                logo = dt.Rows[0]["Description"].ToString();
            }
        }
    }
    protected void rptMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string id, frame;
            id = ((DataRowView)e.Item.DataItem).Row.ItemArray[0].ToString();
            frame = ((DataRowView)e.Item.DataItem).Row.ItemArray[3].ToString();
            DataTable dt = new DataTable();
            Repeater rptMenuCon = e.Item.FindControl("rptMenuCon") as Repeater;
            string nameds = GetFieldByLang("TenLoai", "EngName");
            if (frame == "8")
            {
                string sql = "select LoaiID as MenuID," + nameds + " as TenMenu,(case MaLoai when 'VT02' then '/'+Url+'-ldv' else '/'+Url+'-lds' end) as url,0 as ChucNangID from DM_LoaiDiSan where ParentID=0 order by Stt";
                dt = Sys_Common.getDataByQuery(sql);
            }
            else if (frame == "0")
            {
                string sql = "select LoaiID as MenuID," + nameds + " as TenMenu,(case MaLoai when 'VT02' then '/'+Url+'-ldv' else '/'+Url+'-lds' end) as url,0 as ChucNangID from DM_LoaiDiSan where ParentID=" + id + " order by Stt";
                dt = Sys_Common.getDataByQuery(sql);
            }
            else
            {
                dt = Sys_Common.NV_Menu.GetByParent(id, "1");
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                rptMenuCon.DataSource = dt;
                rptMenuCon.DataBind();
            }
        }
    }
    private string loadMenuDS()
    {
        string result = "";


        return result;
    }
    private string getTime()
    {
        string day = DateTime.Now.ToString("d/M/yyyy");
        string dayofweek = DateTime.Now.DayOfWeek.ToString();
        string time = "";
        if (Session["lag"] != null && Session["lag"].ToString().Equals("en"))
        {
            time = dayofweek + ", " + day + " | ";
        }
        else
        {
            switch (dayofweek)
            {
                case "Monday": time = Resources.labels.monday; break;
                case "Tuesday": time = Resources.labels.tuesday; break;
                case "Wednesday": time = Resources.labels.webnesday; break;
                case "Thursday": time = Resources.labels.thurday; break;
                case "Friday": time = Resources.labels.friday; break;
                case "Saturday": time = Resources.labels.saturday; break;
                case "Sunday": time = Resources.labels.sunday; break;
            }
            time += ", " + day + " | ";
        }
        return time;
    }

    protected void btnViet_Click(object sender, ImageClickEventArgs e)
    {
        Session["LangID"] = "vi";
        Response.Redirect("\\");
    }

    protected void btnEng_Click(object sender, ImageClickEventArgs e)
    {

        Session["LangID"] = "en";
        Response.Redirect("\\");
    }
}