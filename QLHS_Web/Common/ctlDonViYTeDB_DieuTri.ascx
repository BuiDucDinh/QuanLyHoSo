<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctlDonViYTeDB_DieuTri.ascx.cs" Inherits="Common_ctlDonViYTeDB_DuPhong" %>
<ext:Panel runat="server" ID="pnlDonViChon" Border="false" Layout="HBoxLayout" Padding="5"
    Margins="0 0 5 5">
    <Items>
        <ext:TableLayout ID="TableLayout1" runat="server" Columns="2">
            <Cells>
                <ext:Cell>
                    <ext:ComboBox ID="cboLoaiHinh" runat="server" FieldLabel="Loại hình" Width="250"
                        EmptyText="--Chọn Loại hình--" AllowBlank="true" LabelWidth="60">
                        <Items>
                            <ext:ListItem Value="4" Text="Bệnh viện tuyến tỉnh" />
                            <ext:ListItem Value="5" Text="Bệnh viện tuyến huyện" />
                            <ext:ListItem Value="6" Text="Phòng khám/nhà thuốc" />
                        </Items>
                        <DirectEvents>
                            <Select OnEvent="cboLoaiHinh_Selected">
                            </Select>
                        </DirectEvents>
                    </ext:ComboBox>                              
                </ext:Cell>
                <ext:Cell>
                    <ext:ComboBox ID="cboDonVi" runat="server" FieldLabel="&nbsp;&nbsp;Đơn vị" Width="350"
                        EmptyText="--Tất cả--" DisplayField="Ten_Don_Vi" ValueField="Ma_Don_Vi" LabelWidth="80"
                        Mode="Local" AllowBlank="true">
                        <Items>
                            <ext:ListItem Value="" Text="--Tất cả--" />
                        </Items>
                        <Store>
                            <ext:Store ID="dsDonVi" runat="server">
                                <Reader>
                                    <ext:JsonReader>
                                        <Fields>
                                            <ext:RecordField Name="Ten_Don_Vi" SortDir="ASC" />
                                            <ext:RecordField Name="Ma_Don_Vi" />
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                    </ext:ComboBox>    
                </ext:Cell>                
                
            </Cells>
        </ext:TableLayout>
    </Items>
</ext:Panel>