﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLHS_Logic;
using QLHS_Logic.NV;
using System.Data;
public partial class Template_ThuVienAnh : BasePage
{
    public NV_Menu_ChiTiet menu = new NV_Menu_ChiTiet();
    public NV_MediaLib_ChiTiet lib = new NV_MediaLib_ChiTiet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string menu = RouteData.Values["menu"].ToString();
            string lib = RouteData.Values["anh"].ToString();
            loadData(menu, lib);
        }
    }
    private void loadData(string urlMenu, string urlLib)
    {
        if (!string.IsNullOrEmpty(urlLib))
        {
            lib = Sys_Common.NV_MediaLib.GetByUrl(urlLib);
            string sql = "select TenAnh from Image where '" + lib.MediaArray + "' like '%,'+cast(ImageID as nvarchar(20))+',%'";
            DataTable dt = Sys_Common.getDataByQuery(sql);
            rptImage.DataSource = dt;
            rptImage.DataBind();

            if (!string.IsNullOrEmpty(urlMenu))
            {
                menu = Sys_Common.NV_Menu.GetByUrl(urlMenu);
                sql = @"select MediaLibID,TenMediaLib
	                            ,(select TenAnh from Image i where i.ImageID=m.HinhAnh) as HinhAnh
	                            ,dbo.getUrl(MediaLibID,'MediaLib',null) as url
                            from MediaLib m where Duyet=1 and TypeMedia=1 and DanhMuc like '%," + menu.MenuID + ",%' and MediaLibID<>" + lib.MediaLibID;
                dt = Sys_Common.getDataByQuery(sql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    rptOrther.DataSource = dt;
                    rptOrther.DataBind();
                }
            }
        }
        else
        {
            Response.Redirect("PageError.html");
        }
    }
}