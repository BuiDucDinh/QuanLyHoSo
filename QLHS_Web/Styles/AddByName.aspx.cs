using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static List<MakerMap> loadMap()
    {
        string mappath = HttpContext.Current.Server.MapPath("~/XMLData/DataMap.xml");
        XDocument xmldoc = XDocument.Load(mappath);
        IEnumerable<XElement> q = from xe in xmldoc.Descendants("key") select xe;

        List<MakerMap> lst = new List<MakerMap>();
        foreach (XElement xe in q)
        {
            MakerMap m = new MakerMap();
            m.key = int.Parse(xe.Attribute("key").Value);
            m.name = xe.Attribute("name").Value;
            m.content = xe.Attribute("content").Value;
            m.lat = float.Parse(xe.Attribute("lat").Value);
            m.lng = float.Parse(xe.Attribute("lng").Value);
            lst.Add(m);
        }
        return lst;
    }
    [WebMethod]
    public static bool updateMap(MakerMap[] lst)
    {
        return true;
    }
}