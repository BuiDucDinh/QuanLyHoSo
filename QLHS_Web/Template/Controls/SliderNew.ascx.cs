using Ext.Net.Examples;
using QLHS_Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Template_Controls_SliderNew : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData();
        }
    }
    private void loadData()
    {
        string sql = @"select top 10 HoatDongID,TenGoi,'('+TenGoiKhac+')' as TenGoiKhac,
		                NgayDienRa,ThoiGianDienRa,GioiThieu,
		                dbo.getUrl(HoatDongID,'HoatDongVanHoa',null) as url,
		                (select TenDiSan from DiSanVanHoa ds where ds.DiSanID=hd.DiSanID) as DiSan,
		                (select TenCoQuan from DM_CoQuanHanhChinh cq where cq.CoQuanID=hd.DonViQuanLy) as DonViQuanLy,
		                (select TenCoQuan from DM_CoQuanHanhChinh cq where cq.CoQuanID=hd.DonViToChuc) as DonViToChuc,
		                (select TenAnh from Image where ImageID=hd.HinhAnh) as HinhAnh
	                from HoatDongVanHoa hd 
                    where Lang = '" + GetLang() + @"'
                    order by NgayDienRa";
        DataTable dt = Sys_Common.getDataByQuery(sql);
        rptSlider.DataSource = dt;
        rptSlider.DataBind();
    }
}