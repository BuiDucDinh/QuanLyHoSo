<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="NghiepVu_Danhmuc_Menu" %>

<%@ Register Src="~/Control/Images/ImageOnly.ascx" TagPrefix="uc1" TagName="ImageOnly" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="/Scripts/jquery-1.7.1.min.js"></script>
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
            Ext.net.DirectMethods.GetInfo(node.id, {
                success: function (result) {
                },

                failure: function (errorMsg) {
                    Ext.Msg.alert('Failure', errorMsg);
                }
            });
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
        <asp:ObjectDataSource ID="osdMenuCha" runat="server" OnSelected="osdMenuCha_Selected" SelectMethod="GetChild" TypeName="QLHS_Logic.Sys_Common">
            <SelectParameters>
                <asp:Parameter Name="id" Type="Int32" />
                <asp:Parameter Name="chucnang" Type="Int32" />
                <asp:Parameter Name="vitri" Type="Int32" />
                <asp:Parameter Name="lang" Type="String" />
                <asp:Parameter Direction="Output" Name="Count" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
            <Items>
                <ext:Panel ID="Panel1" runat="server" Layout="border" Border="false" Region="Center">
                    <Items>
                        <ext:Panel ID="Panel3" runat="server" Region="West" Split="true" Margins="0 0 0 0"
                            Frame="true" DefaultAnchor="100%" Width="250" Title="Hệ thống menu website">
                            <Items>
                                <ext:ComboBox runat="server" ID="cbVitri" DisplayField="ViTri" ValueField="ID" EmptyText="Chọn vị trí menu" FieldLabel="Vị trí" LabelWidth="60" Width="200">

                                    <Store>
                                        <ext:Store runat="server" ID="stVitri">
                                            <Reader>
                                                <ext:JsonReader>
                                                    <Fields>
                                                        <ext:RecordField Name="ID" />
                                                        <ext:RecordField Name="ViTri" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <DirectEvents>
                                        <Change OnEvent="cbVitri_Change" />
                                    </DirectEvents>
                                </ext:ComboBox>
                                <ext:ComboBox runat="server" ID="cmbLang" FieldLabel="Ngôn ngữ" SelectedIndex="0" LabelWidth="60" Width="200">
                                    <Items>
                                        <ext:ListItem Text="Tiếng việt" Value="vi" />
                                        <ext:ListItem Text="Tiếng anh" Value="en" />
                                    </Items>
                                    <DirectEvents>
                                        <Change OnEvent="cbVitri_Change" />
                                    </DirectEvents>
                                </ext:ComboBox>

                                <ext:TreePanel
                                    ID="TreePanel1"
                                    runat="server"
                                    AutoHeight="true"
                                    Border="false">
                                    <Root>
                                        <ext:AsyncTreeNode NodeID="0" Text="Danh mục menu website" />
                                    </Root>
                                    <Listeners>
                                        <BeforeLoad Fn="nodeLoad" />
                                        <Click Fn="getInfo" />
                                    </Listeners>
                                </ext:TreePanel>

                            </Items>
                        </ext:Panel>

                        <ext:Panel ID="pnlExplorer" runat="server" Region="Center" Margins="0 0 0 0" Frame="true"
                            Title="Nội dung nhập liệu" Icon="LayoutHeader" Layout="FitLayout" AutoScroll="true">

                            <TopBar>
                                <ext:Toolbar ID="Toolbar2" runat="server">
                                    <Items>
                                        <ext:Button ID="btnUpdate" Text="Thêm mới" Icon="Add" runat="server">
                                            <DirectEvents>
                                                <Click OnEvent="btnUpdate_Click">
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button ID="Button1" Text="Hủy" Icon="BulletMinus" runat="server">
                                            <DirectEvents>
                                                <Click OnEvent="btnCancel_Click">
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button ID="btnDelete" Text="Xóa" Icon="BulletCross" runat="server">
                                            <DirectEvents>
                                                <Click OnEvent="btnDelete_Click">
                                                    <Confirmation ConfirmRequest="true" Title="Thông báo" Message="Bạn muốn xóa bản ghi này?" />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <Content>
                                <ext:Panel runat="server" ID="pnRight" AutoScroll="true" AutoHeight="true" LabelWidth="150" Cls="margin10">
                                    <Content>
                                        <ext:Hidden runat="server" ID="hdMenuID" />
                                        <ext:Hidden runat="server" ID="hdRole" />

                                        <ext:TextField runat="server" ID="txtTenMenu" FieldLabel="Tên menu" Width="600" Margins="2" IndicatorText="*" />

                                        <ext:ComboBox runat="server" ID="cmbChucnang" DisplayField="ChucNang" ValueField="FrameViewID" IndicatorText="*" FieldLabel="Chọn chức năng" Width="600">
                                            <Listeners>
                                                <Select Handler="#{cbParent}.clearValue(); #{stMenucha}.reload();" />
                                            </Listeners>
                                            <Store>
                                                <ext:Store runat="server" ID="stChucnang">
                                                    <Reader>
                                                        <ext:JsonReader>
                                                            <Fields>
                                                                <ext:RecordField Name="FrameViewID" />
                                                                <ext:RecordField Name="ChucNang" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                        </ext:ComboBox>
                                        <ext:ComboBox runat="server"
                                            ID="cbParent" FieldLabel="Danh mục cha" Width="600"
                                            Editable="true"
                                            DisplayField="TenMenu"
                                            ValueField="MenuID"
                                            TypeAhead="true"
                                            ForceSelection="true"
                                            EmptyText="--- Chọn danh mục cha ---"
                                            Resizable="true"
                                            SelectOnFocus="true">
                                            <Store>
                                                <ext:Store ID="stMenucha" runat="server" RemoteSort="true" DataSourceID="osdMenuCha" OnRefreshData="stMenucha_RefreshData">
                                                    <Proxy>
                                                        <ext:PageProxy />
                                                    </Proxy>
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="MenuID">
                                                            <Fields>
                                                                <ext:RecordField Name="MenuID" />
                                                                <ext:RecordField Name="TenMenu" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                    <Listeners>
                                                        <Load Handler="#{cbParent}.setValue(#{cbParent}.store.getAt(0).get('id'));" />
                                                    </Listeners>
                                                </ext:Store>
                                            </Store>
                                        </ext:ComboBox>
                                        <div>
                                            <ext:Panel runat="server" Border="false" Cls="left" Width="350">
                                                <Content>
                                                    <uc1:ImageOnly runat="server" ID="ImageOnly" LabelWidth="100" FieldLabel="Chọn ảnh" />
                                                </Content>
                                            </ext:Panel>
                                            <ext:Panel runat="server" Width="350" Border="false" Cls="left" LabelWidth="100">
                                                <Content>
                                                    <ext:Checkbox runat="server" ID="ckbDuyet" Checked="true" FieldLabel="Duyệt" />
                                                    <ext:Checkbox runat="server" ID="ckbNoiBat" Checked="false" FieldLabel="Nổi bật" />
                                                    <ext:NumberField ID="txtThuTu" runat="server" FieldLabel="Thứ tự" Margins="2" AllowDecimals="false" AllowNegative="false" MaxValue="1000" />
                                                </Content>
                                            </ext:Panel>
                                            <div style="clear: both"></div>
                                        </div>
                                        <ext:TextField runat="server" ID="txtUrl" FieldLabel="Link" Width="600" />
                                        <ext:TextField ID="txtPageTitle" runat="server" FieldLabel="Tiêu đề trang" Width="600" />
                                        <ext:TextField ID="txtTenUrl" runat="server" FieldLabel="Url SEO" Hidden="false" Margins="2" Width="600" />
                                        <ext:TextField ID="txtKeyword" runat="server" FieldLabel="Meta Keyword" Width="600" />
                                        <ext:TextField ID="txtDescription" runat="server" FieldLabel="Meta Description" Width="600" Margins="2" />
                                        <ext:HtmlEditor ID="txtMota" runat="server" FieldLabel="Mô tả" Width="700" />
                                    </Content>
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
