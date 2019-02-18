<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cltDonViYTe_TuyenDT.ascx.cs" Inherits="Common_cltDonViYTe_TuyenDT" %>
<ext:Panel runat="server" ID="pnlDonViChon" Border="false" Layout="HBoxLayout" Padding="5"
    Margins="0 0 5 5">
    <Items>
        <ext:TableLayout ID="TableLayout1" runat="server" Columns="4">
            <Cells>
                <ext:Cell>
                    <ext:ComboBox ID="cboLoaiHinhChon" runat="server" FieldLabel="Loại hình" Width="200" Hidden="true"
                        EmptyText="--Chọn Loại hình--" AllowBlank="true" LabelWidth="60">
                        <Items>
                            <ext:ListItem Value="1" Text="Tuyến điều trị" />
                            <ext:ListItem Value="0" Text="Tuyến dự phòng" />
                        </Items>
                        <DirectEvents> 
                            <Select OnEvent="cboLoaiHinhChon_Selected">
                            </Select>
                        </DirectEvents>
                    </ext:ComboBox>
                </ext:Cell>
                <ext:Cell>
                    <ext:ComboBox ID="cboMaHuyenChon" runat="server" FieldLabel="&nbsp;&nbsp;Huyện" Width="200" EmptyText="--Chọn Huyện--"
                        DisplayField="Ten_Huyen" ValueField="Ma_Huyen" Mode="Local" AllowBlank="true" LabelWidth="50" Hidden="true">
                        <Items>
                            <ext:ListItem Value="" Text="--Chọn Huyện--" />
                        </Items>
                        <Store>
                            <ext:Store ID="dsMaHuyenChon" runat="server">
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
                        <DirectEvents>
                            <Select OnEvent="cboMaHuyenChon_Selected">
                            </Select>
                        </DirectEvents>
                    </ext:ComboBox>
                </ext:Cell>
                <ext:Cell>
                    <ext:ComboBox ID="cboDonViChon" runat="server" FieldLabel="&nbsp;&nbsp;Đơn vị" Width="350" EmptyText="--Chọn Đơn vị--" Hidden="true"
                        DisplayField="Ten_Don_Vi" ValueField="Ma_Don_Vi" Mode="Local" AllowBlank="true" LabelWidth="50">
                        <Items>
                            <ext:ListItem Value="" Text="--Chọn Đơn vị--" />
                        </Items>
                        <Store>
                            <ext:Store ID="dsDonViChon" runat="server">
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
                <ext:Cell>
                    <ext:ComboBox ID="cboDonViKhacChon" runat="server" FieldLabel="&nbsp;&nbsp;Đơn vị khác" Width="350"
                        EmptyText="--Chọn đơn vị khác--" DisplayField="Ten_Don_Vi" ValueField="Ma_Don_Vi" LabelWidth="80"
                        Mode="Local" AllowBlank="true">
                        <Items>
                            <ext:ListItem Value="" Text="--Chọn đơn vị khác--" />
                        </Items>
                        <Store>
                            <ext:Store ID="dsDonViKhacChon" runat="server">
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