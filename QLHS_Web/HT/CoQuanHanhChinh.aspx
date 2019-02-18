<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CoQuanHanhChinh.aspx.cs" Inherits="HT_CoQuanHanhChinh" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var ExportYap = function () {
            Ext.net.Mask.show();
            Ext.net.Mask.hide.defer(500);
        };
    </script>
    <script type="text/javascript">
        function nodeLoad(node) {
            Ext.net.DirectMethods.NodeLoad(node.id, {
                success: function (result) {
                    var data = eval("(" + result + ")");
                    node.loadNodes(data);
                },

                failure: function (errorMsg) {
                    Ext.Msg.alert('Failure', errorMsg);
                }
            });
        }

        function getInfo(node) {
            Ext.net.DirectMethods.GetInfo(node.id, {
                success: function (result) {
                },

                failure: function (errorMsg) {
                    Ext.Msg.alert('Failure', errorMsg);
                }
            });
        }
        function setValue(node) {
            document.getElementById("hdCoQuanID").value = node.id;
        }

        function checkToMessage() {
            var myElement = document.getElementById("hdCoQuanID");
            var value = myElement.value;
            if (value == '' || value == '0') {
                Ext.Msg.alert('Thông báo', 'Bạn chưa chọn bản ghi nào');
            }
            else {
                Ext.Msg.confirm("Thông báo", "Bạn có chắc muốn xóa bản ghi này?", function (btn) {
                    if (btn == "yes") {
                        Ext.net.DirectMethods.Delete(value, {
                            success: function (result) {
                            },
                            failure: function (errorMsg) {
                                Ext.Msg.alert('Failure', errorMsg);
                            }
                        });
                    }
                });
            }
        }
    </script>
    <link href="/css/other.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <!----Goi ung dung ext------>
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
            <Items>
                <ext:Panel ID="Panel1" runat="server" Layout="border" Border="false" Region="Center">
                    <Items>
                        <ext:Panel ID="Panel3" runat="server" Region="West" Split="true" Margins="0 0 0 0"
                            Frame="true" DefaultAnchor="100%" Width="250" Title="Danh mục cơ quan" Icon="House">
                            <Items>
                                <ext:TreePanel
                                    ID="TreePanel1"
                                    runat="server"
                                    AutoHeight="true"
                                    Border="false">
                                    <Root>
                                        <ext:AsyncTreeNode NodeID="0" Text="Hệ thống cơ cấu tổ chức hành chính" />
                                    </Root>
                                    <Listeners>
                                        <BeforeLoad Fn="nodeLoad" />
                                        <DblClick Fn="getInfo" />
                                        <Click Fn="setValue" />
                                    </Listeners>

                                </ext:TreePanel>
                            </Items>
                        </ext:Panel>

                        <ext:Panel ID="pnlExplorer" runat="server" Region="Center" Margins="0 0 0 0" Frame="true"
                            Title="Thông tin chi tiết về cơ quan hành chính" Icon="LayoutHeader" Layout="FitLayout" AutoScroll="true">
                            <TopBar>
                                <ext:Toolbar ID="Toolbar2" runat="server">
                                    <Items>
                                        <ext:Button ID="btnUpdate" Text="Thêm mới" Icon="Add" runat="server">
                                            <DirectEvents>
                                                <Click OnEvent="btnUpdate_Click">
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button ID="btnCancel" Text="Hủy" Icon="BulletMinus" runat="server">
                                            <DirectEvents>
                                                <Click OnEvent="btnCancel_Click">
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button ID="btnDelete" Text="Xóa" Icon="BulletCross" runat="server">
                                            <Listeners>
                                                <Click Handler="checkToMessage();" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button ID="btnExport" runat="server" Text="Xuất báo cáo" Icon="Report">
                                            <DirectEvents>
                                                <Click OnEvent="btnExport_Click" IsUpload="true" Before="ExportYap()">
                                                    <ExtraParams>
                                                        <ext:Parameter Name="data" Value="#{TreePanel1}.getRowsValues()" Mode="Raw" Encode="true" />
                                                        <ext:Parameter Name="format" Value="xls" Mode="Value" />
                                                    </ExtraParams>
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <Content>
                                <ext:Panel runat="server" ID="pnRight" AutoScroll="true"  Padding="10" LabelWidth="150">
                                    <Items>
                                        <ext:Hidden runat="server" ID="hdCoQuanID" />
                                        <ext:ComboBox ID="cbCoQuanQuanLy" runat="server"
                                            FieldLabel="Cơ quan quản lý"
                                            EmptyText="--Chọn loại cơ quan--"
                                            DisplayField="TenCoQuan"
                                            ValueField="CoQuanID"
                                            Mode="Local"
                                            AllowBlank="true"
                                            Hidden="false"
                                            Width="700"
                                            Disabled="false" SelectedIndex="0">
                                            <Store>
                                                <ext:Store runat="server" ID="stParent" OnRefreshData="stParent_RefreshData">
                                                    <Reader>
                                                        <ext:JsonReader>
                                                            <Fields>
                                                                <ext:RecordField Name="CoQuanID" />
                                                                <ext:RecordField Name="TenCoQuan" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                        </ext:ComboBox>
                                        <ext:TextField ID="txtTenCoQuan" runat="server" FieldLabel="Tên cơ quan" Hidden="false" Margins="2" IndicatorText="*" Width="700" />
                                        <ext:NumberField ID="txtCapCoQuan" runat="server" FieldLabel="Cấp cơ quan" Hidden="false" Margins="2" Width="700" />
                                        <ext:HtmlEditor ID="txtChucNang" runat="server" FieldLabel="Chức năng, quyền hạn, nhiệm vụ" Width="800" />
                                        <ext:HtmlEditor ID="txtLichSu" runat="server" FieldLabel="Lịch sử" Width="800" />
                                        <ext:TextArea ID="txtDiaChi" runat="server" FieldLabel="Địa chỉ" Width="800" />

                                        <ext:ComboBox ID="cbxTinh" runat="server"
                                            FieldLabel="Tỉnh"
                                            EmptyText="--Chọn tỉnh--"
                                            DisplayField="Ten_Tinh"
                                            ValueField="Ma_Tinh"
                                            Mode="Local"
                                            AllowBlank="true"
                                            Hidden="false"
                                            Width="700"
                                            Disabled="false">
                                            <Store>
                                                <ext:Store runat="server" ID="stTinh">
                                                    <Reader>
                                                        <ext:JsonReader>
                                                            <Fields>
                                                                <ext:RecordField Name="Ma_Tinh" />
                                                                <ext:RecordField Name="Ten_Tinh" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <Listeners>
                                                <Select Handler="#{cbxHuyen}.clearValue(); #{stHuyen}.reload();" />
                                            </Listeners>
                                        </ext:ComboBox>

                                        <ext:ComboBox ID="cbxHuyen" runat="server"
                                            FieldLabel="Huyện"
                                            EmptyText="--Chọn huyện--"
                                            DisplayField="Ten_Huyen"
                                            ValueField="Ma_Huyen"
                                            Mode="Local"
                                            AllowBlank="true"
                                            Hidden="false"
                                            Width="700"
                                            Disabled="false">
                                            <Store>
                                                <ext:Store runat="server" ID="stHuyen" OnRefreshData="stHuyen_RefreshData">
                                                    <Reader>
                                                        <ext:JsonReader>
                                                            <Fields>
                                                                <ext:RecordField Name="Ma_Huyen" />
                                                                <ext:RecordField Name="Ten_Huyen" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <Listeners>
                                                <Select Handler="#{cbxXa}.clearValue(); #{stXa}.reload();" />
                                            </Listeners>
                                        </ext:ComboBox>

                                        <ext:ComboBox ID="cbxXa" runat="server"
                                            FieldLabel="Xã"
                                            EmptyText="--Chọn xã--"
                                            DisplayField="Ten_Xa"
                                            ValueField="Ma_Xa"
                                            Mode="Local"
                                            AllowBlank="true"
                                            Hidden="false"
                                            Width="700"
                                            Disabled="false">
                                            <Store>
                                                <ext:Store runat="server" ID="stXa" OnRefreshData="stXa_RefreshData">
                                                    <Reader>
                                                        <ext:JsonReader>
                                                            <Fields>
                                                                <ext:RecordField Name="Ma_Xa" />
                                                                <ext:RecordField Name="Ten_Xa" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                        </ext:ComboBox>

                                        <ext:HtmlEditor ID="txtMoTa" runat="server" FieldLabel="Mô tả" Hidden="false" Margins="2" Width="800" />
                                    </Items>
                                </ext:Panel>
                            </Content>
                        </ext:Panel>
                    </Items>

                </ext:Panel>

            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
