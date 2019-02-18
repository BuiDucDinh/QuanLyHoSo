using Ext.Net;
using QLHS_Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using QLHS_Logic.NV;
public partial class NghiepVu_Quangcao_CapNhatQuangcao : System.Web.UI.Page
{
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
        if (!IsPostBack)
        {
            if (Session["G_Theme"] != null)
            {
                DHM_Common.SetTheme(this.Page, int.Parse(Session["G_Theme"].ToString()));
            }
            Initialization();
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            if (!string.IsNullOrEmpty(id))
            {
                SetData(Sys_Common.NV_Quangcao.GetById(int.Parse(id)));
                hdID.Text = id;
            }
        }
    }

    public void Initialization()
    {
        string mappath = HttpContext.Current.Server.MapPath("~/XMLData/TypeOfAdv.xml");
        XDocument xmldoc = XDocument.Load(mappath);
        IEnumerable<XElement> q = from xe in xmldoc.Descendants("type") select xe;

        var dt = new DataTable();
        dt.Columns.Add("key");
        dt.Columns.Add("name");
        dt.Columns.Add("value");

        foreach (XElement xe in q)
        {
            DataRow row = dt.NewRow();
            row[0] = xe.Attribute("key").Value;
            row[1] = xe.Attribute("name").Value;
            row[2] = xe.Attribute("value").Value;
            dt.Rows.Add(row); // Thêm dòng mới vào dtb
        }
        stType.DataSource = dt;
        stType.DataBind();

        stMenu.DataSource = Sys_Common.GetChildMenu(0, null, null,"vi");
        stMenu.DataBind();

        if (ckbIsImage.Checked)
        {
            pnImage.Show();
            pnDes.Hide();
        }
        else
        {
            pnImage.Hide();
            pnDes.Show();
        }
    }
    private void SetData(NV_Quangcao_ChiTiet model)
    {
        btnUpdate.Text = "Cập nhật";
        btnUpdate.Icon = Icon.ApplicationEdit;

        txtName.Text = model.Name;
        txtLink.Text = model.Link;
        txtThuTu.Text = model.Stt.ToString();
        txtDescription.Text = model.Description;

        ckbDuyet.Checked = model.Duyet;
        ImageOnly.ImageID = model.ImageID.ToString();
        ckbIsImage.Checked = model.IsImage;
        cbTarget.Value = model.Target;
        cbType.Value = model.Type;
        txtDescription.Text = model.Description;
    }
    private bool FormValidate()
    {
        if (string.IsNullOrEmpty(txtName.Text) || cbType.Value == null)
        {
            return false;
        }
        return true;
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        if (FormValidate())
        {
            NV_Quangcao_ChiTiet model = new NV_Quangcao_ChiTiet();
            model.Name = txtName.Text;
            model.Link = txtLink.Text;
            try
            {
                model.Stt = int.Parse(txtThuTu.Text);
            }
            catch { model.Stt = 1; }
            model.Description = txtDescription.Text;

            model.Duyet = ckbDuyet.Checked;
            try
            {
                model.ImageID = int.Parse(ImageOnly.ImageID);
            }
            catch { model.ImageID = 0; }
            model.IsImage = ckbIsImage.Checked;
            model.Target = cbTarget.Value.ToString();
            model.Type = int.Parse(cbType.Value.ToString());
            model.Description = txtDescription.Text;

            bool check;
            if (hdID.Text != "")
            {
                model.ID = int.Parse(hdID.Text);
                check = Sys_Common.NV_Quangcao.update(model);
            }
            else
            {
                check = Sys_Common.NV_Quangcao.them(model);
            }
            if (check == true)
            {
                X.Msg.AddScript("parent.hdMsg.setValue('ok');");
                X.Msg.AddScript("parentAutoLoadControl.hide();");
            }
            else
            {
                X.Msg.Alert("Thông báo", "Đã có lỗi sảy ra...Xin thử lại", new JFunction { Fn = "" }).Show();
            }
        }
    }
}