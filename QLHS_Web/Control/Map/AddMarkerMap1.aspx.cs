using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class AddMarkerMap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static List<MarkerMap> loadMap()
    {
        string mappath = HttpContext.Current.Server.MapPath("~/XmlData/DataMap.xml");
        XDocument xmldoc = XDocument.Load(mappath);
        IEnumerable<XElement> q = from xe in xmldoc.Descendants("key") select xe;

        List<MarkerMap> lst = new List<MarkerMap>();
        foreach (XElement xe in q)
        {
            MarkerMap m = new MarkerMap();
            m.id = int.Parse(xe.Attribute("key").Value);
            m.name = xe.Attribute("name").Value;
            m.address = xe.Attribute("address").Value;
            m.content = xe.Attribute("content").Value;
            m.lat = float.Parse(xe.Attribute("lat").Value);
            m.lng = float.Parse(xe.Attribute("lng").Value);
            lst.Add(m);
        }
        return lst;
    }
    [WebMethod]
    public static bool updateMarker(MarkerMap marker)
    {
        string mappath = HttpContext.Current.Server.MapPath("~/XmlData/DataMap.xml");
        File.SetAttributes(mappath, FileAttributes.Normal);
        XDocument xmldoc = XDocument.Load(mappath);
        if (marker.id != 0) //update
        {
            try
            {
                XElement xmlelement = xmldoc.Element("content").Elements("key").Single(x => (int?)x.Attribute("key") == marker.id);
                xmlelement.Attribute("name").SetValue(marker.name);
                xmlelement.Attribute("address").SetValue(marker.address);
                xmlelement.Attribute("content").SetValue(marker.content);
                xmlelement.Attribute("lat").SetValue(marker.lat);
                xmlelement.Attribute("lng").SetValue(marker.lng);
                xmldoc.Save(mappath);
            }
            catch
            {
                return false;
            }
        }
        else //add
        {
            try
            {
                int newkey = 0;
                try { newkey = (int)xmldoc.Descendants("content").Elements().Last().Attribute("key") + 1; }
                catch (Exception)
                { newkey = 0; }
                bool b = xmldoc.Descendants("content").Elements().Attributes("key").Contains(new XAttribute("key", newkey));
                var xkey = new XElement("key", new XAttribute("key", newkey), new XAttribute("name", marker.name), new XAttribute("address", marker.address), new XAttribute("content", marker.content), new XAttribute("lat", marker.lat), new XAttribute("lng", marker.lng));
                xmldoc.Element("content").Add(xkey);
                xmldoc.Save(mappath);
            }
            catch
            { return false; }
        }
        return true;
    }
    [WebMethod]
    public static bool deleteMarker(int id)
    {
        string mappath = HttpContext.Current.Server.MapPath("~/XmlData/DataMap.xml");
        File.SetAttributes(mappath, FileAttributes.Normal);
        XDocument xmldoc = XDocument.Load(mappath);
        try
        {
            XElement xmlelement = xmldoc.Element("content").Elements("key").Single(x => (int?)x.Attribute("key") == id);
            xmlelement.Remove();
            xmldoc.Save(mappath);
            return true;
        }
        catch
        {
            return false;
        }
    }
}