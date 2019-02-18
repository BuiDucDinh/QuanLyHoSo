﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DSVH_Baocao_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["G_Theme"] != null)
        {
            DHM_Common.SetTheme(this.Page, int.Parse(Session["G_Theme"].ToString()));
        }
        Tpl1.Overwrite("={#{plnTemplate}.body}", null);
    }
}