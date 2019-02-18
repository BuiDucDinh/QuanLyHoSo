using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLHS_Logic;
using QLHS_Logic.NV;
using System.Data;
public partial class Control_Document_Document : System.Web.UI.UserControl
{
    //public delegate void Media(string str);
    //public Media sendData;

    public int LabelWidth = 0;
    public string FieldLabel = "";
    public bool Disabled = false;
    public int Width = 120;

    private string _documentId = "0";
    public string DocumentID
    {
        get
        {
            string arr = hdDocument.Text;
            if (!string.IsNullOrEmpty(arr))
                _documentId = arr;
            return _documentId;
        }
        set
        {
            _documentId = value;
            hdDocument.Text = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["G_Theme"] != null)
        {
            DHM_Common.SetTheme(this.Page, int.Parse(Session["G_Theme"].ToString()));
        }
        if (!IsPostBack)
        {
            try
            {
                btnUpload.LabelWidth = LabelWidth;
                btnUpload.FieldLabel = FieldLabel;
                btnUpload.Disabled = Disabled;
                pnButton.Width = Width;
                this.wdDetail.AutoLoad.Url = "~/Control/Document/DocmentManager.aspx?id=" + hdDocument.ClientID;
                this.wdDetail.Icon = Icon.ApplicationForm;
                this.wdDetail.Title = "Tài liệu";
                this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
                hdPanel.Value = lstDoc.ClientID;
            }
            catch { }
        }
    }
}