using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using System.Data;
using QLHS_Logic;
using System.Web.Script.Serialization;
using QLHS_Logic.NV;
public partial class NghiepVu_LichSu_LichSuCaNhan : System.Web.UI.Page
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
        }
    }
    private void Initialization()
    {
        string maND = Session["G_Ma_Nguoi_Dung"].ToString();
        string sql = @"select distinct Ma_Chuc_Nang as MaChucNang,
	                    (select Ten_Chuc_Nang from HT_Chuc_Nang cn where cn.Ma_Chuc_Nang=vc.Ma_Chuc_Nang) as TenChucNang
                    from HT_Vai_Tro_Chuc_Nang vc where Ma_Vai_Tro in
	                    (select Ma_Vai_Tro from HT_Nguoi_Dung_Vai_Tro where Ma_Nguoi_Dung=" + maND + ")";
        DataTable dt = Sys_Common.RunTableBySQL(sql);
        stChucnang.DataSource = dt;
        DataBind();
    }
    protected void odsData_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        (this.stData.Proxy[0] as PageProxy).Total = (int)e.OutputParameters["Count"];
    }
    protected void stData_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        this.odsData.SelectParameters["Start"].DefaultValue = (e.Start + 1).ToString();
        this.odsData.SelectParameters["Limit"].DefaultValue = (e.Limit + e.Start).ToString();
        string dk = "";
        if (cmbChucNang.Value != null && !string.IsNullOrEmpty(cmbChucNang.Value.ToString()))
        {
            dk += " and MaForm='" + cmbChucNang.Value.ToString() + "'";
        }
        if (txtTungay.SelectedDate != txtTungay.MinDate)
        {
            try
            {
                dk += " and DATEDIFF(d,'" + txtTungay.SelectedDate.ToString("MM/dd/yyyy") + "',NgayThaoTac)>=0";
            }
            catch { }
        }

        if (txtDenngay.SelectedDate != txtDenngay.MinDate)
        {
            try
            {
                dk += " and DATEDIFF(d,NgayThaoTac,'" + txtDenngay.SelectedDate.ToString("MM/dd/yyyy") + "')>=0";
            }
            catch { }
        }
        string maND = Session["G_Ma_Nguoi_Dung"].ToString();
        this.odsData.SelectParameters["WhereString"].DefaultValue = @"(select ID,NgayThaoTac,(select Ten_Chuc_Nang from HT_Chuc_Nang dn where dn.Ma_Chuc_Nang=lg.MaForm) as ChucNang,
	                                                                    (select (case ThaoTac 
		                                                                    when 'active' then N'Duyệt bản ghi' 
		                                                                    when 'unactive' then N'Bỏ duyệt'
		                                                                    when 'insert' then N'Thêm bản ghi'
		                                                                    when 'update' then N'Sửa bản ghi'
		                                                                    when 'delete' then N'Xóa bản ghi'
		                                                                    when 'insertMap' then N'Thêm bản đồ'
		                                                                    when 'updateMap' then N'Sửa bản đồ'
		                                                                    when 'export' then N'Xuất file exel'
		                                                                    when 'exportDetail' then N'In phiếu chi tiết'
		                                                                    end)) as ThaoTac,
	                                                                    (select Ten from
		                                                                    (select DiSanID as ID,TenDiSan as Ten,(select MaForm from TableLog tl where tl.TenBang='DiSanVanHoa') as MaForm from DiSanVanHoa
		                                                                    union all
		                                                                    select ID,Ten,(select MaForm from TableLog tl where tl.TenBang='DiVatCoVat') as MaForm from DiVatCoVat
		                                                                    union all
		                                                                    select ID,TieuDe as Ten,(select MaForm from TableLog tl where tl.TenBang='BaiViet_AnPham') as MaForm from BaiViet_AnPham
		                                                                    union all
		                                                                    select VanBanID as ID,TenVanBan as Ten,(select MaForm from TableLog tl where tl.TenBang='VanBan') as MaForm from VanBan
		                                                                    union all
		                                                                    select ID,TenSach as Ten,(select MaForm from TableLog tl where tl.TenBang='AnPham') as MaForm from AnPham
		                                                                    union all
		                                                                    select HoatDongID as ID,TenGoi as Ten,(select MaForm from TableLog tl where tl.TenBang='HoatDongvanHoa') as MaForm from HoatDongvanHoa
                                                                            union all
                                                                            select DonViID as ID,TenDonVi as Ten,(select MaForm from TableLog tl where tl.TenBang='DonViTuBo') as MaForm from DonViTuBo
                                                                            union all
                                                                            select KeHoachID as ID,TenDuAn as Ten,(select MaForm from TableLog tl where tl.TenBang='KeHoachTuBo') as MaForm from KeHoachTuBo
                                                                            union all
                                                                            select ID,HoTen as Ten,(select MaForm from TableLog tl where tl.TenBang='NgheNhan') as MaForm from NgheNhan
                                                                            union all
                                                                            select MenuID as ID,TenMenu as Ten,(select MaForm from TableLog tl where tl.TenBang='Menu') as MaForm from Menu
                                                                            union all
                                                                            select ID,Ten,(select MaForm from TableLog tl where tl.TenBang='NoiLuuTruHienVat') as MaForm from NoiLuuTruHienVat
                                                                            ) as A
		                                                                    where A.ID=lg.IDBanGhi and a.MaForm=lg.MaForm) as TenBanGhi
                                                                    from Log lg where MaND=" + maND + dk + ") as A";

        this.odsData.SelectParameters["SortString"].DefaultValue = e.Sort + " " + e.Dir;

        this.odsData.DataBind();

    }
    protected void btnExport_Click(object sender, DirectEventArgs e)
    {
    }
    protected void btnCancel_Click(object sender, DirectEventArgs e)
    {
        txtTungay.Text = "";
        txtDenngay.Text = "";
        cmbChucNang.Value = "";
        X.Msg.AddScript("#{stData}.reload();");
    }
    private Role getRole()
    {
        string maForm = Request.QueryString["cn"].ToString();
        int maND = int.Parse(Session["G_Ma_Nguoi_Dung"].ToString());
        Role role = Sys_Common.HT_NGUOI_DUNG_VAI_TRO.getRoleUserByForm(maND, maForm);
        return role;
    }
}