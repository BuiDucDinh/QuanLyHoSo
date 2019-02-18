<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SoDiSan.aspx.cs" Inherits="NghiepVu_Thongke_SoDiSan" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/css/site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    <ext:Panel ID="Panel1" runat="server" Border="false" AutoScroll="true" LabelWidth="70" AutoHeight="false" >
        <Items>
           
        </Items>
       <TopBar>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:DateField ID="dtTungay" FieldLabel="Từ ngày" runat="server" Width="200" />
                    <ext:DateField ID="dtDenngay" FieldLabel="Đến ngày" runat="server" Width="200"/>
                    <ext:ComboBox ID="cmbDiadiem" runat="server" FieldLabel="Địa điểm" EmptyText="--Chọn địa điểm--" Editable="false" Width="200">
                        <Items>
                            <ext:ListItem Text="..." Value="1" />
                        </Items>
                    </ext:ComboBox>
                    <ext:ComboBox ID="cmbLoaidisan" runat="server" FieldLabel="Loại di sản" EmptyText="--Chọn loại di sản--" Editable="false" Width="300">
                        <Items>
                            <ext:ListItem Text="..." Value="1" />                    
                        </Items>
                    </ext:ComboBox>
                    <ext:Button ID="btnTimkiem" Text="Xem" Icon="ZoomIn" runat="server">
                        <DirectEvents>
                            <%-- <Click OnEvent="btnTimkiem_Click">
                            </Click>--%>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="btnExport" Text="In báo cáo" Icon="Report" runat="server">
                        <DirectEvents>
                            <%-- <Click OnEvent="btnTimkiem_Click">
                            </Click>--%>
                        </DirectEvents>
                    </ext:Button>                    
                </Items>
            </ext:Toolbar>
        </TopBar>

        <Content>         
            <ext:Panel ID="plnTemplate" runat="server" Border="false" AutoScroll="false" AutoHeight="false">
                <Content>
                    <ext:XTemplate ID="Tpl1" runat="server">
                        <Html>
                            <div>
                                    <div class="apartTitle titlefisrt">
                                        <p><b>Biểu số: 2206.3N/VH-SVHTTDL</b><br />
                                        Ban hành theo Thông tư số 04/2015/TT-BVHTTDL ngày 19 tháng 6 năm 2015 của Bộ trưởng Bộ Văn hóa, Thể thao và Du lịch
                                            <br />Ngày nhận báo cáo: Sau năm điều tra
                                        </p>
                                    </div>
                                    <div class="apartTitle titleCenter">
                                        <h3 style="font-weight:bold">SỔ DI TÍCH <br /></h3>
                                        <h5 style="font-style:italic;font-size:12px">Từ năm 2013 đến 2016</h5>
                                    </div>
                                    <div class="apartTitle">
                                        <p>Đơn vị báo cáo:<br />
                                        Sở VHTTDL………………………….<br />
                                        Đơn vị nhận báo cáo:<br />
                                        Cục Văn hóa cơ sở <br />
                                        - Bộ Văn hóa, Thể thao và Du lịch
                                        </p>
                                    </div>
                                </div>
                            <table cellspacing="0px" cellpadding="0px" width="95%" style="text-align:center;">      
                                <tbody>
                                <tr>
                                <td colspan="9" style="font-weight:bold;border-right:none; text-transform:uppercase; font-size:15px">
                                
                                </td>
                                </tr>
                                <tr>
                                    <td style="border-left:1px solid grey;" rowspan="3" nowrap=""><p><b>Số di tích </br> cấp tỉnh có </br> đến 31/12</b></p></td>
                                    <td colspan="5" nowrap=""><p><b>Số di tích quốc gia có đến 31/12</b></p></td>
                                    <td rowspan="3" nowrap=""><p><b>Số di tích </br> quốc gia đặc biệt </br> có đến 31/12</b></p></td>
                                    <td rowspan="3" nowrap=""><p><b>Số Di sản </br> Văn hóa Thế giới </br> có đến 31/12</b></p></td>
                                    <td rowspan="3" nowrap=""><p><b>Số Di sản </br> Thiên nhiên </br> Thế giới có </br> đến 31/12</b></p></td>
                                </tr>

                                <tr>
                                    <td rowspan="2" nowrap=""><p><b>Cả tỉnh</b></p></td>
                                    <td colspan="4" nowrap=""><p><b>Trong đó</b></p></td>                                    
                                </tr>

                                <tr>                                       
                                    <td nowrap=""><p><b>Di tích </br> lịch sử</b></p></td>
                                    <td nowrap=""><p><b>Di tích kiến </br>trúc nghệ thuật</b></p></td>     
                                    <td nowrap=""><p><b>Di tích </br> khảo cổ</b></p></td>
                                    <td nowrap=""><p><b>Danh lam </br> thắng cảnh</b></p></td>                               
                                </tr>
                                <%--<tpl for=".">--%>
                                <tr>
                                    <td style="border-left:1px solid grey;" valign="top">1</td>
                                    <td valign="top">2</td>
                                    <td valign="top">3</td>
                                    <td valign="top">4</td>
                                    <td valign="top">5</td>
                                    <td valign="top">6</td>
                                    <td valign="top">7</td>
                                    <td valign="top">8</td>  
                                    <td valign="top">9</td>                              
                                </tr>
                                <%--</tpl>--%>
                                </tbody>
                            </table>
                        </Html>
                    </ext:XTemplate>
                </Content>
            </ext:Panel>                                
        </Content>
    </ext:Panel>
    </form>
</body>
</html>
