<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImageManager.aspx.cs" Inherits="NghiepVu_Control_ImageManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function NodeLoadType(node) {
            Ext.net.DirectMethods.NodeLoadType(node.id, {
                success: function (result) {
                    var data = eval("(" + result + ")");
                    node.loadNodes(data);
                    console.log();
                },

                failure: function (errorMsg) {
                    Ext.Msg.alert('Failure', errorMsg);
                }
            });
        }

        function getInfoType(node) {
            Ext.net.DirectMethods.GetInfoType(node.id, {
                success: function (result) {
                },
                failure: function (errorMsg) {
                    Ext.Msg.alert('Failure', errorMsg);
                }
            });
        }
        function UploadFile(fileUpload) {
            if (fileUpload.value != '') {
                document.getElementById("btnUpload").click();
            }
        }
        var GetImage = function (value) {
            return "<img src='/FileUpload/Images/" + value + "' style=\'width:100px; height:auto\'/>";
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ObjectDataSource ID="odsDsAnh" runat="server" OnSelected="odsDsAnh_Selected" SelectMethod="Page_By_Filter_Image" TypeName="QLHS_Logic.Sys_Common">
            <SelectParameters>
                <asp:Parameter Name="Start" Type="Int32" />
                <asp:Parameter Name="Limit" Type="Int32" />
                <asp:Parameter Name="ImgArr" Type="String" />
                <asp:Parameter Direction="Output" Name="Count" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>

        <asp:ObjectDataSource ID="odsImage" runat="server" OnSelected="odsImage_Selected" SelectMethod="Page_By_Filter" TypeName="QLHS_Logic.Sys_Common">
            <SelectParameters>
                <asp:Parameter Name="Start" Type="Int32" />
                <asp:Parameter Name="Limit" Type="Int32" />
                <asp:Parameter Name="WhereString" Type="String" />
                <asp:Parameter Name="SortString" Type="String" />
                <asp:Parameter Direction="Output" Name="Count" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <!----Goi ung dung ext------>
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Hidden runat="server" ID="hdValue" />
        <ext:Viewport runat="server" Layout="border">
            <Items>
                <ext:Panel Region="West" runat="server" Split="true" Width="200"
                    Collapsible="true" Title="Chọn danh mục ảnh" Icon="BookAddresses">
                    <Items>
                        <ext:TreePanel
                            ID="TreePanel1"
                            runat="server"
                            AutoHeight="true"
                            Border="false">
                            <Root>
                                <ext:AsyncTreeNode NodeID="0" Text="Danh mục gốc" />
                            </Root>
                            <Listeners>
                                <BeforeLoad Fn="NodeLoadType" />
                                <Click Fn="getInfoType" />
                            </Listeners>
                        </ext:TreePanel>
                    </Items>
                </ext:Panel>

                <ext:TabPanel runat="server" Region="Center" ID="tabPanel">
                    <Items>
                        <ext:Panel runat="server" ID="Thuvienanh" Title="Thư viện ảnh" Icon="Pictures" Layout="fit" Border="false">
                            <TopBar>
                                <ext:Toolbar runat="server">
                                    <Items>
                                        <ext:Hidden runat="server" ID="hdimg" />
                                        <ext:Button runat="server" ID="lbnInsert" Text="Chèn ảnh đã chọn" Margins="0 20">
                                            <DirectEvents>
                                                <Click OnEvent="lbnInsert_Click">
                                                    <EventMask ShowMask="true"/>
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button runat="server" ID="lbnDelete" Text="Xóa ảnh đã chọn">
                                            <DirectEvents>
                                                <Click OnEvent="lbnDelete_Click">
                                                    <Confirmation ConfirmRequest="true" Title="Thông báo" Message="Bạn muốn xóa những ảnh đã chọn?" />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <Items>
                                <ext:Hidden runat="server" ID="hdDanhmuc" />
                                <ext:GridPanel ID="gridImage" runat="server" Title="" Margins="0" Header="false"
                                    Icon="UserSuit" AutoHeight="true" AutoWidth="true" AutoExpandColumn="TenAnh">
                                    <Store>
                                        <ext:Store ID="stImage" runat="server" RemoteSort="true" DataSourceID="odsImage" OnRefreshData="stImage_RefreshData">
                                            <AutoLoadParams>
                                                <ext:Parameter Name="start" Value="0" Mode="Raw" />
                                                <ext:Parameter Name="limit" Value="30" Mode="Raw" />
                                            </AutoLoadParams>
                                            <Proxy>
                                                <ext:PageProxy />
                                            </Proxy>
                                            <Reader>
                                                <ext:JsonReader IDProperty="ImageID">
                                                    <Fields>
                                                        <ext:RecordField Name="ImageID" />
                                                        <ext:RecordField Name="TenAnh" />
                                                        <ext:RecordField Name="NgayTao" Type="Date" />
                                                        <ext:RecordField Name="Chon" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                            <SortInfo Field="ImageID" Direction="ASC" />
                                        </ext:Store>
                                    </Store>
                                    <ColumnModel ID="ColumnModel2" runat="server">
                                        <Columns>
                                            <ext:Column ColumnID="TenAnh" DataIndex="TenAnh" Header="Tên ảnh" Width="150">
                                            </ext:Column>
                                            <ext:Column ColumnID="image" Header="Ảnh" DataIndex="TenAnh">
                                                <Renderer Fn="GetImage" />
                                            </ext:Column>
                                            <ext:Column Align="Center" Sortable="false" Header="Xóa" Width="100">
                                                <Commands>
                                                    <ext:ImageCommand CommandName="Del" Icon="Delete" Text="Xóa" />
                                                </Commands>
                                            </ext:Column>
                                        </Columns>
                                    </ColumnModel>
                                    <SelectionModel>
                                        <ext:CheckboxSelectionModel runat="server" />
                                    </SelectionModel>
                                    <DirectEvents>
                                        <Command OnEvent="DelImage" Buffer="250">
                                            <Confirmation ConfirmRequest="true" Title="Thông báo" Message="Bạn muốn xóa ảnh này?" />
                                            <EventMask ShowMask="true" />
                                            <ExtraParams>
                                                <ext:Parameter Name="command" Value="command" Mode="Raw" />
                                                <ext:Parameter Name="rowIndex" Value="record.data.ImageID" Mode="Raw" />
                                            </ExtraParams>
                                        </Command>
                                    </DirectEvents>
                                    <BottomBar>
                                        <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="30" DisplayInfo="true"
                                            DisplayMsg="Hiển thị bản ghi {0} - {1} của {2}" />
                                    </BottomBar>
                                    <LoadMask ShowMask="true" />
                                </ext:GridPanel>
                            </Items>
                        </ext:Panel>

                        <ext:Panel ID="Uploadanh" runat="server" Title="Upload ảnh" Layout="fit" Icon="PictureAdd">
                            <Items>
                                <ext:Panel ID="Panel2" runat="server" Region="Center" Margins="0" Frame="true"
                                    Title="Chọn ảnh tải lên" Icon="LayoutHeader" Padding="10" Width="500">
                                    <Content>
                                        <ext:Hidden runat="server" ID="hdImgUpload" Text=""/>
                                        <asp:FileUpload ID="FileUpload1" multiple="true" runat="server" ClientIDMode="Static" onchange="UploadFile(this)" />
                                        <asp:Button ID="btnUpload" Text="Upload" runat="server" OnClick="Upload" Style="display: none" />


                                        <ext:GridPanel ID="gridData" runat="server" Title="" Margins="0" Header="false"
                                            Icon="UserSuit" AutoHeight="true" Width="900">
                                            <Store>
                                                <ext:Store ID="stDsAnh" runat="server" RemoteSort="true" DataSourceID="odsDsAnh" OnRefreshData="stDsAnh_RefreshData">
                                                    <AutoLoadParams>
                                                        <ext:Parameter Name="start" Value="0" Mode="Raw" />
                                                        <ext:Parameter Name="limit" Value="30" Mode="Raw" />
                                                    </AutoLoadParams>
                                                    <Proxy>
                                                        <ext:PageProxy />
                                                    </Proxy>
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="Stt">
                                                            <Fields>
                                                                <ext:RecordField Name="Stt" />
                                                                <ext:RecordField Name="TenAnh" />

                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <ColumnModel ID="ColumnModel1" runat="server">
                                                <Columns>
                                                    <ext:Column ColumnID="TenAnh" DataIndex="TenAnh" Header="Tên ảnh" Width="150">
                                                    </ext:Column>

                                                    <ext:Column Align="Center" Sortable="false">
                                                        <Commands>
                                                            <ext:ImageCommand CommandName="Del" Icon="Delete" Text="Xóa" />
                                                        </Commands>
                                                    </ext:Column>
                                                </Columns>
                                            </ColumnModel>
                                            <DirectEvents>
                                                <Command OnEvent="Action_Click" Buffer="250">
                                                    <EventMask ShowMask="true" />
                                                    <ExtraParams>
                                                        <ext:Parameter Name="command" Value="command" Mode="Raw" />
                                                        <ext:Parameter Name="rowIndex" Value="record.data.Stt" Mode="Raw" />
                                                    </ExtraParams>
                                                </Command>
                                            </DirectEvents>
                                            <BottomBar>

                                                <ext:PagingToolbar ID="pageNL_DM_ChucVu" runat="server" PageSize="30" DisplayInfo="true"
                                                    DisplayMsg="Hiển thị bản ghi {0} - {1} của {2}" />
                                            </BottomBar>
                                            <LoadMask ShowMask="true" />
                                        </ext:GridPanel>
                                        <ext:Button runat="server" ID="btnFinish" Text="Hoàn thành">
                                            <DirectEvents>
                                                <Click OnEvent="btnFinish_Click" />
                                            </DirectEvents>
                                        </ext:Button>

                                    </Content>
                                </ext:Panel>

                            </Items>
                        </ext:Panel>

                        <ext:Panel ID="Danhmucanh" runat="server" Title="Danh mục ảnh" Padding="10" Layout="" Icon="PictureEdit">
                            <TopBar>
                                <ext:Toolbar runat="server">
                                    <Items>
                                        <ext:Button ID="btnUpdate" runat="server" Text="Thêm mới" Icon="Add">
                                            <DirectEvents>
                                                <Click OnEvent="btnUpdate_Click" />
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button ID="btnDelete" runat="server" Text="Xóa" Icon="Delete">
                                            <DirectEvents>
                                                <Click OnEvent="btnDelete_Click">
                                                    <Confirmation ConfirmRequest="true" Title="Thông báo" Message="Bạn muốn xóa bản ghi này?" />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <Items>

                                <ext:TextField runat="server" ID="txtTendanhmuc" Width="300" FieldLabel="Tên danh mục" />
                                <ext:ComboBox runat="server" ID="cmbDanhmuccha" FieldLabel="Danh mục cha"
                                    DisplayField="TenDanhMuc" ValueField="DanhMucID" Width="300" EmptyText="--Chọn danh mục cha--">
                                    <Store>
                                        <ext:Store runat="server" ID="stDanhmuccha">
                                            <Reader>
                                                <ext:JsonReader>
                                                    <Fields>
                                                        <ext:RecordField Name="DanhMucID" />
                                                        <ext:RecordField Name="TenDanhMuc" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                </ext:ComboBox>
                                <ext:TextArea runat="server" ID="txtMota" Width="300" FieldLabel="Mô tả" />

                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:TabPanel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
