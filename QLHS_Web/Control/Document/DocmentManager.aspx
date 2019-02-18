<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DocmentManager.aspx.cs" Inherits="Control_Document_DocmentManager" %>

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
            return "<img src='/Images/icon_choi.png' style=\'width:12px; height:auto\'/>" + value;
        }
        var fnCommand = function (command, value) {
            if (command == "Delete") {
                Ext.Msg.confirm("Thông báo", "Bạn có chắc muốn xóa bản ghi này?", function (btn) {
                    if (btn == "yes") {
                        submitCommand(command, value);
                    }
                });
            }
            else {
                submitCommand(command, value);
            }
        };
        var submitCommand = function (command, value) {
            Ext.net.DirectMethods.Command(command, value, {
                success: function (result) {
                },
                failure: function (errorMsg) {
                    Ext.Msg.alert('Failure', errorMsg);
                }
            });
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">

        <asp:ObjectDataSource ID="odsDocument" runat="server" OnSelected="odsDocument_Selected" SelectMethod="Page_By_Filter" TypeName="QLHS_Logic.Sys_Common">
            <SelectParameters>
                <asp:Parameter Name="Start" Type="Int32" />
                <asp:Parameter Name="Limit" Type="Int32" />
                <asp:Parameter Name="WhereString" Type="String" />
                <asp:Parameter Name="SortString" Type="String" />
                <asp:Parameter Direction="Output" Name="Count" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>

        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Viewport runat="server" Layout="fit">
            <Items>
                <ext:Panel runat="server" ID="pnMain" Layout="BorderLayout" AutoScroll="true">
                    <TopBar>
                        <ext:Toolbar runat="server">
                            <Items>
                                <ext:Button ID="btnAddFoder" Icon="FolderAdd" runat="server">
                                    <Listeners>
                                        <Click Handler="#{wdFolder}.show();" />
                                    </Listeners>
                                </ext:Button>
                                <ext:Button ID="btnShowUpLoad" Text="Upload" Icon="Add" runat="server">
                                    <Listeners>
                                        <Click Handler="#{wdUpload}.show();" />
                                    </Listeners>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <Items>
                        <ext:Panel Region="West" runat="server" Split="true" Width="160">
                            <Items>
                                <ext:TreePanel
                                    ID="TreePanel1"
                                    runat="server"
                                    AutoHeight="true"
                                    Border="false">
                                    <Root>
                                        <ext:AsyncTreeNode NodeID="0" Text="Document" />
                                    </Root>
                                    <Listeners>
                                        <BeforeLoad Fn="NodeLoadType" />
                                        <Click Fn="getInfoType" />
                                    </Listeners>
                                </ext:TreePanel>
                                <ext:Hidden runat="server" ID="hdDanhmuc" Text="0" />
                            </Items>
                        </ext:Panel>

                        <ext:Panel runat="server" Region="Center" Border="true" Width="250">
                            <TopBar>
                                <ext:Toolbar ID="Toolbar1" runat="server">
                                    <Items>
                                        <ext:Button ID="btnInsert" Text="Chọn tài liệu" Icon="Accept" runat="server">
                                            <DirectEvents>
                                                <Click OnEvent="btnInsert_Click" />
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button ID="btnDelete" Icon="BulletCross" Text="Xóa tài liệu" runat="server" Disabled="true">
                                            <DirectEvents>
                                                <Click OnEvent="btnDelete_Click">
                                                    <Confirmation ConfirmRequest="true" Title="Thông báo" Message="Bạn muốn xóa tài liệu này?" />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <Items>
                                <ext:Hidden runat="server" ID="hdDocument" />
                                <ext:GridPanel ID="gridData" runat="server" Title="" Margins="0" Header="false" Height="360"
                                    Icon="UserSuit" AutoScroll="true" AutoExpandColumn="TenTaiLieu">
                                    <Store>
                                        <ext:Store ID="stDocument" runat="server" RemoteSort="true" DataSourceID="odsDocument" OnRefreshData="stDocument_RefreshData">
                                            <AutoLoadParams>
                                                <ext:Parameter Name="start" Value="0" Mode="Raw" />
                                                <ext:Parameter Name="limit" Value="12" Mode="Raw" />
                                            </AutoLoadParams>
                                            <Proxy>
                                                <ext:PageProxy />
                                            </Proxy>
                                            <Reader>
                                                <ext:JsonReader IDProperty="DocumentID">
                                                    <Fields>
                                                        <ext:RecordField Name="DocumentID" />
                                                        <ext:RecordField Name="TenTaiLieu" />
                                                        <ext:RecordField Name="NgayTao" Type="Date" />
                                                        <ext:RecordField Name="File" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                            <SortInfo Field="NgayTao" Direction="ASC" />
                                        </ext:Store>
                                    </Store>
                                    <ColumnModel ID="ColumnModel2" runat="server">
                                        <Columns>
                                            <ext:Column ColumnID="TenTaiLieu" DataIndex="TenTaiLieu" Header="Tên tài liệu">
                                            </ext:Column>
                                            <ext:Column ColumnID="File" DataIndex="File" Header="File Name" Width="200">
                                                <Renderer Fn="GetImage" />
                                            </ext:Column>
                                            <ext:DateColumn DataIndex="NgayTao" Header="Ngày tạo" Format="d/M/yyyy" />
                                            <ext:CommandColumn Width="60">
                                                <Commands>
                                                    <ext:GridCommand Icon="Delete" CommandName="Delete">
                                                        <ToolTip Text="Delete" />
                                                    </ext:GridCommand>
                                                    <ext:CommandSeparator />
                                                    <ext:GridCommand Icon="NoteEdit" CommandName="Edit">
                                                        <ToolTip Text="Edit" />
                                                    </ext:GridCommand>
                                                    <ext:CommandSeparator />
                                                </Commands>
<%--                                                <PrepareToolbar Fn="prepareToolbar" />--%>
                                            </ext:CommandColumn>
                                        </Columns>
                                    </ColumnModel>
                                    <SelectionModel>

                                        <ext:CheckboxSelectionModel runat="server">
                                            <Listeners>
                                                <RowSelect Handler="#{btnDelete}.enable();" />
                                                <RowDeselect Handler="if (!#{gridData}.hasSelection()) {#{btnDelete}.disable();}" />
                                            </Listeners>
                                        </ext:CheckboxSelectionModel>
                                    </SelectionModel>
                                    <Listeners>
                                        <Command Handler="fnCommand(command, record.data.DocumentID);" />
                                    </Listeners>
                                    <DirectEvents>
                                        <DblClick OnEvent="gridData_DbClick">
                                        </DblClick>
                                    </DirectEvents>
                                    <BottomBar>
                                        <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="12" DisplayInfo="true"
                                            DisplayMsg="Hiển thị bản ghi {0} - {1} của {2}" />
                                    </BottomBar>
                                    <LoadMask ShowMask="true" />
                                </ext:GridPanel>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:Panel>
            </Items>
        </ext:Viewport>
        <ext:Window runat="server" Hidden="true" Title="Thêm mới folder" ID="wdFolder" Icon="FolderAdd" Height="180" Width="300" Layout="column" Maximizable="true" Collapsible="true">
            <Items>
                <ext:Panel ID="Panel1" runat="server" Layout="AbsoluteLayout" Padding="10" ColumnWidth="0.5">
                    <Items>
                        <ext:Label runat="server" X="5" Y="15" Text="Nhập tên folder :" />
                        <ext:TextField runat="server" ID="txtTenDanhmuc" X="100" Y="10" AnchorHorizontal="100%" />

                        <ext:Label runat="server" X="5" Y="37" Text="Mô tả:" />
                        <ext:TextArea runat="server" ID="txtMota" X="100" Y="37" AnchorHorizontal="100%" />

                        <ext:Button runat="server" ID="btnOKFolder" Text="OK" X="100" Y="110" Width="40">
                            <DirectEvents>
                                <Click OnEvent="btnOKFolder_Click" />
                            </DirectEvents>
                        </ext:Button>
                        <ext:Button runat="server" ID="btnCancelFolder" Text="Cancel" X="150" Y="110" Width="70">
                            <DirectEvents>
                                <Click OnEvent="btnCancelFolder_Click" />
                            </DirectEvents>
                        </ext:Button>
                    </Items>
                </ext:Panel>
            </Items>
        </ext:Window>
        <ext:Window runat="server" ID="wdUpload" Hidden="true" Title="Upload tài liệu" Icon="Add" Layout="fit" Maximizable="true" Collapsible="true" Height="250" Width="400">
            <Items>
                <ext:Panel runat="server" Padding="10" Frame="true">
                    <Content>
                        <ext:Hidden runat="server" ID="hdImgUpload" Text="" />
                        <asp:FileUpload ID="fDocument" multiple="true" runat="server" ClientIDMode="Static" />
                        <ext:DisplayField runat="server" Text="Kích cỡ tối đa cho phép:48.83 MB" />
                        <ext:DisplayField runat="server" Text="File mở rộng cho phép: *.txt, *.doc, *.docx, *.ppt, *.pptx, *.pps, *.ppsx, *.xls, *.xlsx, *.pdf, *.tif, *.zip, *.rar, *.xps" />
                        <ext:TextField runat="server" ID="txtTentailieu" Width="300" FieldLabel="Tên tài liệu" LabelWidth="100" AllowBlank="false" />
                        <ext:Button runat="server" ID="btnUpload" Text="Upload">
                            <DirectEvents>
                                <Click OnEvent="btnUpload_Click" />
                            </DirectEvents>
                        </ext:Button>
                    </Content>
                </ext:Panel>
            </Items>
        </ext:Window>
         <ext:Window runat="server" ID="wdEdit" Hidden="true" Title="Upload tài liệu" Icon="Add" Layout="fit" Maximizable="true" Collapsible="true" Height="250" Width="400">
            <Items>
                <ext:Panel runat="server" Padding="10" Frame="true">
                    <Content>                       
                         <ext:TextField runat="server" ID="txtName" Width="300" FieldLabel="Tên tài liệu" LabelWidth="100" AllowBlank="false" />
                        <ext:Button runat="server" ID="btnSave" Text="Lưu">
                            <DirectEvents>
                                <Click OnEvent="btnSave_Click" />
                            </DirectEvents>
                        </ext:Button>
                    </Content>
                </ext:Panel>
            </Items>
        </ext:Window>
    </form>
</body>
</html>
