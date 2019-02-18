using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePage : System.Web.UI.Page
{
    protected override void InitializeCulture()
    {
        if (!string.IsNullOrEmpty(Request["l"]))
        {
            Session["langID"] = Request["l"];
        }
        else
        {
            Session["langID"] = Session["langID"] != null ? Session["langID"].ToString() : "vi";
        }
        string lang = Convert.ToString(Session["langID"]);
        string culture = string.Empty;
        /* // In case, if you want to set vietnamese as default language, then removing this comment
        if(lang.ToLower().CompareTo("vi") == 0 ||string.IsNullOrEmpty(culture))
        {               
            culture = "vi-VN";
        }
         */
        if (lang.ToLower().CompareTo("en") == 0 || string.IsNullOrEmpty(culture))
        {
            culture = "en-US";
        }
        if (lang.ToLower().CompareTo("vi") == 0)
        {
            culture = "vi-VN";
        }
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

        base.InitializeCulture();
    }
    public string GetLang()
    {
        return Session["langID"] != null ? Session["langID"].ToString() : "vi";
    }
    //public string GetLang()
    //{
    //    string culture;
    //    string l = HttpContext.Current.Request["l"] != null ? HttpContext.Current.Request["l"].ToString() : "";
    //    if (string.IsNullOrEmpty(l))
    //    {
    //        if (HttpContext.Current.Session["langID"] == null)
    //        {
    //            culture = "vi";
    //        }
    //        else
    //        {
    //            culture = HttpContext.Current.Session["langID"].ToString();
    //        }
    //    }
    //    else if (l == "vi" || l == "en")
    //    {
    //        culture = l;// Utility.KillSqlInjection(Request["l"].ToString());
    //    }
    //    else
    //    {
    //        culture = "vi";
    //    }
    //    HttpContext.Current.Session["langID"] = culture;

    //    //OR This

    //    System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo(culture);
    //    System.Threading.Thread.CurrentThread.CurrentCulture = ci;
    //    System.Threading.Thread.CurrentThread.CurrentUICulture = ci;

    //    return culture;
    //}
}