using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Template_Export : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Clear Buffer
        Response.Clear();
        #endregion

        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment; filename=Report.xls");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.BinaryWrite((byte[])Session["Export-Content"]);
        Response.Flush();
        Session["Export-Content"] = null;
        #region Close Buffer
        Response.End();
        #endregion

    }
}