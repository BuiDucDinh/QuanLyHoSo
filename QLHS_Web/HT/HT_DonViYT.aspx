<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HT_DonViYT.aspx.cs" Inherits="HT_HT_DonViYT" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="Form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    <ext:Panel ID="pnlHT_Don_Vi_YT" runat="server" Layout="FormLayout" LabelWidth="150">
        <Items>
            <ext:TextField ID="txtMa_Don_Vi" runat="server" FieldLabel="" Width="150" Hidden="true" />
            <ext:TextField ID="txtTen_Don_Vi" runat="server" FieldLabel="Tên đơn vị"  Width="450" />
            <ext:ComboBox ID="cboTuyen" runat="server" FieldLabel="Tuyến đơn vị trực thuộc" EmptyText="--Lựa chọn tuyến--" Hidden="true"
                Editable="false" Width="150">
                <Items>
                    <ext:ListItem Text="Xã" Value="1" />
                    <ext:ListItem Text="Huyện" Value="2" />
                    <ext:ListItem Text="Tỉnh" Value="3" />
                </Items>
            </ext:ComboBox>
            <ext:ComboBox ID="cboMa_Tinh" runat="server" FieldLabel="Mã tỉnh" Width="250" EmptyText="--Chọn Tỉnh--" Hidden="true"
                DisplayField="Ten_Tinh" ValueField="Ma_Tinh" Mode="Local">
                <Store>
                    <ext:Store ID="dsDM_Tinh" runat="server">
                        <Reader>
                            <ext:JsonReader>
                                <Fields>
                                    <ext:RecordField Name="Ten_Tinh" SortDir="ASC" />
                                    <ext:RecordField Name="Ma_Tinh" />
                                </Fields>
                            </ext:JsonReader>
                        </Reader>
                    </ext:Store>
                </Store>
            </ext:ComboBox>
            <ext:ComboBox ID="cboMa_Huyen" runat="server" FieldLabel="Mã Huyện" Width="250" EmptyText="--Chọn Huyện--"  Hidden="true"
                DisplayField="Ten_Huyen" ValueField="Ma_Huyen" Mode="Local" AllowBlank="true">
                <Store>
                    <ext:Store ID="dsHuyen" runat="server">
                        <Reader>
                            <ext:JsonReader>
                                <Fields>
                                    <ext:RecordField Name="Ten_Huyen" SortDir="ASC" />
                                    <ext:RecordField Name="Ma_Huyen" />
                                </Fields>
                            </ext:JsonReader>
                        </Reader>
                    </ext:Store>
                </Store>
                <Items>
                    <ext:ListItem Text="Không chọn" Value="" />                    
                </Items>
                <DirectEvents>
                    <Select OnEvent="cboMa_Huyen_Selected">
                    </Select>
                </DirectEvents>
            </ext:ComboBox>
            <ext:ComboBox ID="cboMa_Xa" runat="server" FieldLabel="Mã Xã" Width="250" EmptyText="--Chọn Xã--"  Hidden="true"
                DisplayField="Ten_Xa" ValueField="Ma_Xa" Mode="Local" AllowBlank="true"> 
                <Store>
                    <ext:Store ID="dsXa" runat="server">
                        <Reader>
                            <ext:JsonReader>
                                <Fields>
                                    <ext:RecordField Name="Ten_Xa" SortDir="ASC" />
                                    <ext:RecordField Name="Ma_Xa" />
                                </Fields>
                            </ext:JsonReader>
                        </Reader>
                    </ext:Store>
                </Store>
                <Items>
                    <ext:ListItem Text="Không chọn" Value="" />                    
                </Items>
            </ext:ComboBox>
            <ext:ComboBox ID="cboLoai_Hinh" runat="server" FieldLabel="Loại hình của đơn vị"
                EmptyText="--Lựa chọn loại hình--" Editable="false" Width="250">
                <Items>
                    <ext:ListItem Text="Chi cục" Value="4" />
                    <ext:ListItem Text="Sở nông nghiệp và PTNT" Value="1" />
                    <ext:ListItem Text="Các đơn vị trực thuộc sở" Value="2" />
                    <ext:ListItem Text="Đơn vị không trực thuộc sở" Value="3" />
                </Items>
            </ext:ComboBox>
            <ext:ComboBox ID="cboLoai_Dac_Biet" runat="server" FieldLabel="Loại đặc biệt" EmptyText="--Lựa loại đặc biệt--" Hidden="true"
                Editable="false" Width="450">
                <Items>
                    <ext:ListItem Text="Bình thường" Value="0" />
                    <ext:ListItem Text="Chi cục trực thuộc tuyến tỉnh (áp dụng cho phân hệ nhân sự)" Value="1" />
                    <ext:ListItem Text="Vừa là tuyến điều trị vừa là tuyến dự phòng" Value="2" />
                </Items>
            </ext:ComboBox>    
            <ext:ComboBox ID="cboThanh_Phan" runat="server" FieldLabel="Thành phần kinh tế " Hidden="true"
                EmptyText="--Lựa chọn thành phần kinh tế--" Editable="false" Width="150">
                <Items>
                    <ext:ListItem Text="Công lập" Value="1" />
                    <ext:ListItem Text="Tư nhân" Value="2" />                   
                </Items>
            </ext:ComboBox>
            <ext:Checkbox ID="chkKB" runat="server" FieldLabel="Module Khám bệnh" Hidden="true"/>
            <ext:Checkbox ID="chkDP" runat="server" FieldLabel="Module Dược phẩm" Hidden="true"/>
            <ext:Checkbox ID="chkTB" runat="server" FieldLabel="Module Thiết bị y tế" Hidden="true"/>
            <ext:Checkbox ID="chkBC" runat="server" FieldLabel="Module Báo cáo" Hidden="true"/>
            <ext:Checkbox ID="chkSK" runat="server" FieldLabel="Module Sức khỏe" Hidden="true"/>
            <ext:Checkbox ID="chkDB" runat="server" FieldLabel="Module Dịch bệnh" Hidden="true"/>
            <ext:Checkbox ID="chkCP" runat="server" FieldLabel="Module Cấp phép y dược" Hidden="true"/>
            <ext:Checkbox ID="chkNL" runat="server" FieldLabel="Module Quản lý nhân lực" Hidden="true"/>
            <ext:Checkbox ID="chkAT" runat="server" FieldLabel="Module An toàn vệ sinh thực phẩm" Hidden="true"/>
            <ext:Checkbox ID="chkDV" runat="server" FieldLabel="Module Dịch vụ công y tế dự phòng" Hidden="true"/>
        </Items>
        <TopBar>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnUpdate" runat="server" Text="Cập nhật" Icon="ApplicationFormEdit">
                        <DirectEvents>
                            <Click OnEvent="btnUpdate_Click">
                                <EventMask ShowMask="true" MinDelay="100" Msg="Xin vui lòng chờ đợi !!!" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="btnClose" runat="server" Text="Thoát" Icon="Cancel">
                        <DirectEvents>
                            <Click OnEvent="btnClose_Click">
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </TopBar>
    </ext:Panel>
    </form>
</body>
</html>
