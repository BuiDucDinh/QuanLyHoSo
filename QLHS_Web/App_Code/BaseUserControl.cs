using System.Collections.Generic;
using System.Web.UI;

namespace Ext.Net.Examples
{
    public class BaseUserControl : UserControl
    {
        public virtual List<string> ControlsToDestroy
        {
            get
            {
                // we should return none lazy controls only because lazy controls will be autodestroyed by parent container
                return new List<string>();
            }
        }
        public string GetLang()
        {
            return Session["langID"] != null ? Session["langID"].ToString() : "vi";
        }
        public string GetFieldByLang(string fViet, string fEng)
        {
            return GetLang() == "vi" ? fViet : fEng;
        }
    }
}
