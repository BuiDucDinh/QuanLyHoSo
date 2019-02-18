<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoaiDiSan.aspx.cs" Inherits="NghiepVu_Danhmuc_Loaidisan" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var ExportYap = function () {
            Ext.net.Mask.show();
            Ext.net.Mask.hide.defer(500);
        };
        function nodeLoad(node) {
            Ext.net.DirectMethods.NodeLoad(node.id, {
                success: function (result) {
                    var data = eval("(" + result + ")");
                    node.loadNodes(data);
                    console.log(node);

                },

                failure: function (errorMsg) {
                    Ext.Msg.alert('Failure', errorMsg);
                }
            });
        }

        function getInfo(node) {
            document.getElementById("hdLoaiID").value = node.id;
            Ext.net.DirectMethods.GetInfo(node.id, {
                success: function (result) {
                },

                failure: function (errorMsg) {
                    Ext.Msg.alert('Failure', errorMsg);
                }
            });
        }
        function setNodeDelete(node) {
            document.getElementById("hdDelete").value = node.id;
        }
        function checkToMessage() {
            var myElement = document.getElementById("hdDelete");
            var value = myElement.value;
            if (value == '' || value == '0') {
                Ext.Msg.alert('Thông báo', 'Bạn chưa chọn bản ghi nào');
            }
            else {
                Ext.Msg.confirm("Thông báo", "Bạn có chắc muốn xóa bản ghi này?", function (btn) {
                    if (btn == "yes") {
                        Ext.net.DirectMethods.Delete(value, {
                            success: function (result) {
                                document.getElementById("hdDelete").value = 0;
                            },
                            failure: function (errorMsg) {
                                Ext.Msg.alert('Failure', errorMsg);
                            }
                        });
                    }
                });
            }
        }
        $(document).ready(function () {
            Ext.onReady(function () {
                var ma = Ext.getCmp('hdRole').getValue();
                var role = JSON.parse(ma);
                if (!role.Duoc_Xoa) {
                    Ext.getCmp('btnDelete').hide();
                }
                if (!role.Duoc_Nhap && !role.Duoc_Sua) {
                    Ext.getCmp('btnUpdate').hide();
                }
            });
        });
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
                        <ext:Hidden runat="server" ID="hdDelete" ClientIDMode="Static"/>
                        <ext:Panel ID="Panel3" runat="server" Region="West" Split="true" Margins="0 0 0 0"
                            Frame="true" DefaultAnchor="100%" Width="250" Title="Loại hình văn hóa, di sản" Icon="House">
                            <Items>
                                <ext:TreePanel
                                    ID="TreePanel1"
                                    runat="server"
                                    AutoHeight="true"
                                    Border="false">
                                    <Root>
                                        <ext:AsyncTreeNode NodeID="0" Text="Di sản văn hóa" />
                                    </Root>
                                    <Listeners>
                                        <BeforeLoad Fn="nodeLoad" />
                                        <DblClick Fn="getInfo" />
                                        <Click Fn="setNodeDelete" />
                                    </Listeners>
                                </ext:TreePanel>

                            </Items>
                        </ext:Panel>

                        <ext:Panel ID="pnlExplorer" runat="server" Region="Center" Margins="0 0 0 0" Frame="true"
                            Title="Thông tin về loại hình văn hóa và di sản" Icon="LayoutHeader" Layout="FitLayout" AutoScroll="true">
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
                                        <ext:Hidden ID="Hidden1" runat="server" AutoDataBind="true">
                                            <Listeners>
                                                <Change Handler="#{pageData}.changePage(1);" Delay="30" />
                                            </Listeners>
                                        </ext:Hidden>
                                        <ext:ToolbarFill ID="ToolbarFill2" runat="server" />
                                        <ext:TriggerField ID="TriggerField1" runat="server" Width="250" EmptyText="Tìm kiếm">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Search" />
                                            </Triggers>
                                            <Listeners>
                                                <TriggerClick Handler="#{txtFilter}.setValue(this.getValue()); " />
                                            </Listeners>
                                        </ext:TriggerField>
                                    </Items>
                                </ext:Toolbar>

                            </TopBar>
                            <Items>
                                <ext:Panel runat="server" ID="pnRight" AutoScroll="false" AutoHeight="true" LabelWidth="150" Cls="margin10">
                                    <Items>
                                        <ext:Hidden runat="server" ID="hdLoaiID" ClientIDMode="Static"/>
                                        <ext:Hidden runat="server" ID="hdRole" />
                                        <ext:ComboBox runat="server"
                                            ID="cbParent" FieldLabel="Danh mục cha" Width="600"
                                            Editable="true"
                                            DisplayField="TenLoai"
                                            ValueField="LoaiID"
                                            TypeAhead="true"
                                            ForceSelection="true"
                                            EmptyText="--- Chọn danh mục cha ---"
                                            Resizable="true"
                                            SelectOnFocus="true" SelectedIndex="0">
                                            <Store>
                                                <ext:Store runat="server" ID="stParent" OnRefreshData="stParent_RefreshData">
                                                    <Reader>
                                                        <ext:JsonReader>
                                                            <Fields>
                                                                <ext:RecordField Name="LoaiID" />
                                                                <ext:RecordField Name="TenLoai" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                        </ext:ComboBox>

                                        <ext:ComboBox runat="server" ID="cbLoai" FieldLabel="Chọn di sản văn hóa" Width="600">
                                            <Items>
                                                <ext:ListItem Value="1" Text="Di sản văn hóa vật thể" />
                                                <ext:ListItem Value="0" Text="Di sản văn hóa phi vật thể" />
                                            </Items>
                                        </ext:ComboBox>
                                        <ext:TextField ID="txtMaLoai" runat="server" FieldLabel="Mã loại di sản" Width="600" IndicatorText="*" />
                                        <ext:TextField ID="txtTenLoai" runat="server" FieldLabel="Tên loại di sản" Hidden="false" Margins="2" IndicatorText="*" Width="600" />
                                        <ext:TextField ID="txtEngName" runat="server" FieldLabel="Tên tiếng anh" Hidden="false" Margins="2" IndicatorText="*" Width="600" />
                                        <ext:TextArea ID="txtGhiChu" runat="server" FieldLabel="Ghi chú" Width="600" />
                                        <ext:NumberField ID="txtSoThuTu" runat="server" FieldLabel="Số thứ tự" Width="600" Margins="2" AllowDecimals="false" AllowNegative="false" MaxValue="1000" />
                                    </Items>
                                </ext:Panel>
                            </Items>
                        </ext:Panel>
                    </Items>

                </ext:Panel>

            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
