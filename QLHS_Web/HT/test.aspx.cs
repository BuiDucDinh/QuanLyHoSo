using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using QLHS_Logic;
using System.Data;
public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            this.Store1.DataSource = new object[]
            {
                new object[] {"3m Co", 71.72, 0.02, 0.03, "9/1 12:00am"},
                new object[] {"Alcoa Inc", 29.01, 0.42, 1.47, "9/1 12:00am"},
                new object[] {"Altria Group Inc", 83.81, 0.28, 0.34, "9/1 12:00am"}
            };

            this.Store1.DataBind();
        }
    }
}