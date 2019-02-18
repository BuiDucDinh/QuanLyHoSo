using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
public partial class Control_Document_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ImageOnly.ImageID = "290";
            ImageOnly1.ImageID = "291";
        }
    }
    protected void Unnamed_Event(object sender, DirectEventArgs e)
    {
        string image = ImageOnly.ImageID;
        string image1 = ImageOnly1.ImageID;
        string image2 = ImageOnly2.ImageID;
        string image3 = ImageMutil.ImageID;
    }
}