using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using QLHS_Logic;
public partial class HT_Main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            DataTable myTable = Sys_Common.RunTableBySQL(@"SELECT 
       [1],
       [2],
       [3],    
       [1] + [2] + [3] Total
FROM   (
SELECT Loai_Hinh,
       Ma_Nguoi_Dung
FROM   HT_Nguoi_Dung ND INNER JOIN HT_Don_Vi_YT DV ON ND.Ma_Don_Vi=DV.Ma_Don_Vi
) SourceTable
PIVOT(COUNT(Ma_Nguoi_Dung) FOR Loai_Hinh IN ([1], [2], [3]])) PivotTable");
            string temp = "";
            if (myTable != null)
            {
                temp += "['Văn phòng sở nông nghiệp',   " 
                    + Math.Round(double.Parse(myTable.Rows[0]["1"].ToString()) / double.Parse(myTable.Rows[0]["Total"].ToString()),2) + " ],";
                temp += "['Các đơn vị trực thuộc',   "
                    + Math.Round(double.Parse(myTable.Rows[0]["2"].ToString()) / double.Parse(myTable.Rows[0]["Total"].ToString()), 2) + " ],";
                temp += "['Trạm y tế xã',   " 
                    + Math.Round(double.Parse(myTable.Rows[0]["3"].ToString()) / double.Parse(myTable.Rows[0]["Total"].ToString()), 2) + " ]";
            }

            ltrChart.Text = @"
<!DOCTYPE HTML>
<html>
	<head>
		<meta http-equiv='Content-Type' content='text/html; charset=utf-8'>
		<title>Highcharts Example</title>

		<script type='text/javascript' src='../Resources/js/jquery.min.js'></script>
		<script type='text/javascript'>
$(function () {
    $('#container').highcharts({
        chart: {
            plotBackgroundColor: null,
            plotBorderWidth: null,
            plotShadow: false
        },
        title: {
            text: 'THỐNG KÊ SỐ LƯỢNG NGƯỜI SỬ DỤNG QUA LOẠI HÌNH'
        },
        tooltip: {
    	    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    color: '#000000',
                    connectorColor: '#000000',
                    format: '<b>{point.name}</b>: {point.percentage:.1f} %'
                }
            }
        },
        series: [{
            type: 'pie',
            name: 'Số lượng',
            data: [" + temp + @"
            ]
        }]
    });
});
    

		</script>
	</head>
	<body>
<script src='../Resources/js/highcharts.js'></script>
<script src='../Resources/js/modules/exporting.js'></script>

<div id='container' style='min-width: 400px; height: 400px; margin: 0 auto'></div>

	</body>
</html>
";
        }
    }
}