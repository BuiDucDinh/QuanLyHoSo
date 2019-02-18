using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Control_Images_ImageMutil : System.Web.UI.UserControl
{
    public string type = "mutil";
    public int LabelWidth = 0;
    public string FieldLabel = "";
    private string _imageId = "0";
    public int Width = 120;
    public bool Disabled = false;
    public string ImageID
    {
        get
        {
            _imageId = txtImageMutil.Text;
            return _imageId;
        }
        set
        {
            _imageId = value;
            txtImageMutil.Value = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["GIsLogin"] == null)
        {
            X.Msg.Show(new MessageBoxConfig
            {
                Title = "Thông báo",
                Message = "Phiên làm việc đã kết thúc do bạn ngưng sử dụng máy quá lâu. <br>Hãy ấn F5 để bắt đầu phiên làm việc mới.",
                Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING"),
                Closable = false
            });
            return;
        }
        if (Session["G_Theme"] != null)
        {
            DHM_Common.SetTheme(this.Page, int.Parse(Session["G_Theme"].ToString()));
        }
        if (!IsPostBack)
        {
            try
            {
                pnButton.Width = Width;
                btnUpload.LabelWidth = LabelWidth;
                btnUpload.FieldLabel = FieldLabel;
                btnUpload.Disabled = Disabled;
                this.wdDetailMutil.AutoLoad.Url = "~/Control/Images/ImageManager1.aspx?type=mutil&control=" + txtImageMutil.ClientID;
                this.wdDetailMutil.Icon = Icon.ApplicationForm;
                this.wdDetailMutil.Title = "Hình ảnh";
                this.wdDetailMutil.AutoLoad.Mode = LoadMode.IFrame;
            }
            catch { }
        }
    }
}