using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLHS_Logic;
using System.Data;
using Ext.Net.Examples;

public partial class Template_Controls_RightContent : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData();
        }
    }
    private void loadData()
    {
        DataTable dt = Sys_Common.NV_DM_DiSan.GetAll();
       
        string sql = "select (select TenAnh from Image i where i.ImageID=q.ImageID) as Image,Link,Description,Target,IsImage from Quangcao q where Duyet=1 and Type=4";
        dt = Sys_Common.getDataByQuery(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            rptAdv.DataSource = dt;
            rptAdv.DataBind();
        }

        sql = "select (select TenAnh from Image i where i.ImageID=q.ImageID) as Image,Link,Description,Target,IsImage from Quangcao q where Duyet=1 and Type=5";
        dt = Sys_Common.getDataByQuery(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            rptAdvLink.DataSource = dt;
            rptAdvLink.DataBind();
        }
    }
}