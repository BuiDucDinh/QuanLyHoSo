using Ext.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLHS_Logic;
using QLHS_Logic.NV;
using System.Web.Services;

public partial class NghiepVu_Control_Image : System.Web.UI.UserControl
{
    //public delegate void Media(string str);
    //public Media sendData;

    public string type = "mutil";
    public int LabelWidth;
    private string _imageId = "0";
    public string FieldLabel = "";
    public string ImageID
    {
        get
        {
            if (type == "mutil")
            {
                _imageId = txtImage.Text;
            }
            else
            {
                string[] str = txtImage.Text.Split(',');
                foreach (var item in str)
                {
                    if (item != "")
                    {
                        _imageId = item;
                        break;
                    }
                }
            }
            return _imageId;
        }
        set
        {
            _imageId = value;
            txtImage.Value = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnUpload.LabelWidth = LabelWidth;
            btnUpload.FieldLabel = FieldLabel;
        }
    }
}