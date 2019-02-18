using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using System.Data;
using QLHS_Logic;

public partial class Control_Video_Video : System.Web.UI.UserControl
{
    public int LabelWidth = 0;
    public bool Disabled = false;
    public string FieldLabel = "";
    private string _videoId = "0";
    public int Width = 120;
    public string VideoID
    {
        get
        {
            string arr = hdVideo.Text;
            if (!string.IsNullOrEmpty(arr))
                _videoId = arr;
            return _videoId;
        }
        set
        {
            _videoId = value;
            hdVideo.Text = value;
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
                btnUpload.LabelWidth = LabelWidth;
                btnUpload.FieldLabel = FieldLabel;
                btnUpload.Disabled = Disabled;
                pnButton.Width = Width;
                this.wdDetail.AutoLoad.Url = "~/Control/Video/VideoManager1.aspx?id=" + hdVideo.ClientID;
                this.wdDetail.Icon = Icon.ApplicationForm;
                this.wdDetail.Title = "Chọn video";
                this.wdDetail.AutoLoad.Mode = LoadMode.IFrame;
                hdPanel.Value = lstVideo.ClientID;
            }
            catch { }
        }
    }
}