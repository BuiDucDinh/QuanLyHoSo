using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLHS_Logic.NV;
public partial class Control_Map_Map : System.Web.UI.UserControl
{
    private string _position = "{}";
    public List<PositionMap> LstPosition
    {
        get
        {

            List<PositionMap> lst = new List<PositionMap>();
            return lst;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}