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

    public string type = "only";
    public int LabelWidth = 150;
    private string _imageId = "0";
    public string FieldLabel = "";
    public bool Disabled = false;
    public string ImageID
    {
        get
        {

            string[] str = txtImageOnly.Text.Split(';')[0].Split(',');
            foreach (var item in str)
            {
                if (item != "")
                {
                    _imageId = item;
                    break;
                }
            }
            return _imageId;
        }
        set
        {
            _imageId = value;
            txtImageOnly.Value = value + ";" + btnUploadOnly.ClientID;
            if (type == "only")
            {
                if (value != "0")
                {
                    NV_Image_ChiTiet img = Sys_Common.NV_Image.GetById(int.Parse(ImageID));
                    if (img.ImageID != 0)
                    {
                        btnUploadOnly.ImageUrl = "/FileUpload/Images/" + img.TenAnh;
                    }
                }
            }
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
                btnUploadOnly.LabelWidth = LabelWidth;
                btnUploadOnly.FieldLabel = FieldLabel;
                btnUploadOnly.Disabled = Disabled;
                this.wdDetailOnly.AutoLoad.Url = "~/Control/Images/ImageManager1.aspx?type=only&control=" + txtImageOnly.ClientID + "&image=" + btnUploadOnly.ClientID;
                this.wdDetailOnly.Icon = Icon.ApplicationForm;
                this.wdDetailOnly.Title = "Hình ảnh";
                this.wdDetailOnly.AutoLoad.Mode = LoadMode.IFrame;
            }
            catch { }
        }

    }
}