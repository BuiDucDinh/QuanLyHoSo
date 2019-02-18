<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctlDonViYTeDB_DuPhong.ascx.cs" Inherits="Common_ctlDonViYTeDB_DuPhong" %>
<ext:Panel runat="server" ID="pnlDonViChon" Border="false" Layout="HBoxLayout" Padding="5"
    Margins="0 0 5 5">
    <Items>
        
        <ext:TableLayout ID="TableLayout1" runat="server" Columns="3">
            <Cells>
                <ext:Cell>
                    <ext:ComboBox ID="cboMa_Huyen" runat="server" FieldLabel="Chọn huyện" EmptyText="--Tất cả--"
                        DisplayField="Ten_Huyen" ValueField="Ma_Huyen" Mode="Local" Width="250" LabelWidth="70">
                        <Items>
                            <ext:ListItem Text="--Tất cả--" Value="" />
                        </Items>
                        <Store>
                            <ext:Store ID="dsMa_Huyen" runat="server">
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
                            <Select OnEvent="cboMa_Huyen_Selected" />
                        </DirectEvents>
                    </ext:ComboBox>                    
                </ext:Cell>
                <ext:Cell>
                    <ext:ComboBox ID="cboMa_Xa" runat="server" FieldLabel="Chọn xã/phường" Width="250"
                        EmptyText="--Tất cả--" DisplayField="Ten_Xa" ValueField="Ma_Xa" Mode="Local"
                        AllowBlank="true" LabelWidth="100">
                        <Items>
                            <ext:ListItem Text="--Tất cả--" Value="" />
                        </Items>
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
                        <DirectEvents>
                            <Select OnEvent="cboMa_Xa_Selected" />
                        </DirectEvents>
                    </ext:ComboBox>
                </ext:Cell>               
                <ext:Cell>
                <ext:TextField ID = "txtMa_Don_Vi" runat="server" Hidden="true" />
                </ext:Cell>
            </Cells>
        </ext:TableLayout>
    </Items>
</ext:Panel>