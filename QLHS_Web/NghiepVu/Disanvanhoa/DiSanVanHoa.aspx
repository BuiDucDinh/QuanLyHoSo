<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DiSanVanHoa.aspx.cs" Inherits="NghiepVu_Disanvanhoa_DisanPhiVatThe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript" src="/Scripts/jquery-1.7.1.min.js"></script>
    <script type="text/javascript">
        var ExportYap = function () {
            Ext.net.Mask.show();
            Ext.net.Mask.hide.defer(200);
        };
        function NodeLoadAddress(node) {
            Ext.net.DirectMethods.NodeLoadAddress(node.id, {
                success: function (result) {
                    var data = eval("(" + result + ")");
                    node.loadNodes(data);
                },

                failure: function (errorMsg) {
                    Ext.Msg.alert('Failure', errorMsg);
                }
            });
        }
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

        function getInfoAddress(node) {
            Ext.net.DirectMethods.GetInfoAddress(node.id, {
                success: function (result) {
                },

                failure: function (errorMsg) {
                    Ext.Msg.alert('Failure', errorMsg);
                }
            });
        }
        var getTasksAddress = function () {
            var msg = ",",
                selNodes = TreePanel1.getChecked();
            Ext.each(selNodes, function (node) {
                node.expand();
                msg += this.id + ",";
            });
            Ext.getCmp('hdAddress').setValue(msg);
        };

        var getTasksType = function () {
            var msg = "",
                selNodes = TreePanel2.getChecked();
            Ext.each(selNodes, function (node) {
                if (msg.length > 0) {
                    msg += ", ";
                }
                msg += this.id;
            });
            Ext.getCmp('hdType').setValue(msg);
        };

        function childCheck(node, checked, msg) {
            node.expand();//childNodes
            var nodeAttr = node.attributes;
            if (!nodeAttr.leaf) {
                node.eachChild(function (child) {
                    if (child && child.getUI().checkbox != undefined) {
                        child.getUI().checkbox.checked = checked;
                        msg += this.id + ',';
                    }
                    msg += childCheck(child, checked);
                });
            }
            return msg;
        }
        function Cancel() {
            txtTenDiSan.setValue('');
            dfDenNgay.setValue('');
            dfTuNgay.setValue('');
            ckbNguoiTao.setValue(false);
            cbCapDS.setValue('');

            var selNodes1 = TreePanel1.getChecked();
            Ext.each(selNodes1, function (node) {
                node.set("checked", false);
            });
            var selNodes2 = TreePanel2.getChecked();
            Ext.each(selNodes2, function (node) {
                var a = node.attributes;
                node.attributes.checked = false;
            });
            stDisan.reload();
        }
        var fnCommand = function (command, value, trangthai) {
            if (command == "Delete") {
                Ext.Msg.confirm("Thông báo", "Bạn có chắc muốn xóa bản ghi này?", function (btn) {
                    if (btn == "yes") {
                        submitCommand(command, value);
                    }
                });
            }
            else if (command == "Active") {
                var mes = trangthai ? "Bạn muốn bỏ bản ghi này ra khỏi kho thông tin tham khảo?" : "Bạn muốn thêm bản ghi này vào kho thông tin thao khảo?";
                Ext.Msg.confirm("Thông báo", mes, function (btn) {
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

        var GetImage = function (value) {
            return "<img src='/FileUpload/Images/" + value + "' style=\'width:60px; height:auto\'/>";
        }

        var prepareToolbar = function (grid, toolbar, rowIndex, record) {
            var ma = Ext.getCmp('hdRole').getValue();
            var role = JSON.parse(ma);
            if (!role.Duoc_Duyet) {
                toolbar.items.itemAt(6).hide();
            }
            if (!role.Duoc_Sua) {
                toolbar.items.itemAt(2).hide();
                toolbar.items.itemAt(3).hide();
            }
            if (!role.Duoc_Sua && !role.Duoc_Nhap) {
                toolbar.items.itemAt(4).hide();
                toolbar.items.itemAt(5).hide();
            }
            if (!role.Duoc_Xoa) {
                toolbar.items.itemAt(0).hide();
                toolbar.items.itemAt(1).hide();
            }
        };
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
                if (!role.Duoc_Xuat) {
                    Ext.getCmp('btnExportDeTail').hide();
                }
            });
        });
    </script>
    <link href="/css/other.css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server">
        <asp:ObjectDataSource ID="odsData" runat="server" OnSelected="odsData_Selected" SelectMethod="Page_By_Filter" TypeName="QLHS_Logic.Sys_Common">
            <SelectParameters>
                <asp:Parameter Name="Start" Type="Int32" />
                <asp:Parameter Name="Limit" Type="Int32" />
                <asp:Parameter Name="WhereString" Type="String" />
                <asp:Parameter Name="SortString" Type="String" />
                <asp:Parameter Direction="Output" Name="Count" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <ext:ResourceManager ID="ResourceManager1" runat="server" />

        <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
            <Items>
                <ext:Panel ID="Panel1" runat="server" Layout="border" Border="false" Region="Center">
                    <Items>
                        <ext:Panel ID="Panel3" runat="server" Region="West" Split="true" Margins="0 0 0 0"
                            Frame="true" DefaultAnchor="100%" Width="250">
                            <Items>
                                <ext:Panel ID="Panel4" runat="server" Region="South" Split="true" Margins="0 0 0 0"
                                    Frame="true" Title="Loại hình văn hóa" Icon="BookAddresses" Height="300" AutoScroll="true"
                                    DefaultAnchor="100%">
                                    <Items>
                                        <ext:TreePanel
                                            ID="TreePanel2"
                                            runat="server"
                                            AutoHeight="true"
                                            Border="false">
                                            <Root>
                                                <ext:AsyncTreeNode NodeID="0" Text="Di sản văn hóa" Expanded="true" Leaf="true" />
                                            </Root>
                                            <Listeners>
                                                <BeforeLoad Fn="NodeLoadType" />
                                                <CheckChange Fn="getTasksType" />
                                                <%--<Click Fn="getInfoType" />--%>
                                            </Listeners>
                                        </ext:TreePanel>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel ID="Panel2" runat="server" Region="North" Split="true" Margins="0 0 0 0"
                                    Frame="true" Title="Địa điểm" Icon="House" Height="290" AutoScroll="true"
                                    DefaultAnchor="100%">
                                    <Items>
                                        <ext:TreePanel SingleExpand="true"
                                            ID="TreePanel1"
                                            runat="server"
                                            AutoHeight="true"
                                            Border="false">
                                            <Root>
                                                <ext:AsyncTreeNode NodeID="T36" Text="Địa điểm" Expanded="true" Leaf="false" />
                                            </Root>
                                            <Listeners>
                                                <BeforeLoad Fn="NodeLoadAddress" />
                                                <CheckChange Fn="getTasksAddress" />
                                                <%-- <Click Fn="getInfoAddress" />--%>
                                            </Listeners>
                                        </ext:TreePanel>
                                    </Items>
                                </ext:Panel>
                            </Items>
                        </ext:Panel>

                        <ext:Panel ID="pnlExplorer" runat="server" Region="Center" Margins="0 0 0 0" Frame="true"
                            Title="Danh sách di sản" Icon="LayoutHeader" Layout="FitLayout" AutoScroll="true">
                            <Content>
                                <ext:Panel ID="Panel5" runat="server" AutoScroll="true" Padding="10" AutoHeight="true" LabelWidth="150">
                                    <Content>
                                        <ext:Hidden runat="server" ID="hdRole" />
                                        <ext:Hidden runat="server" ID="hdAddress">
                                            <Listeners>
                                                <Change Handler="#{stDisan}.reload();" />
                                            </Listeners>
                                        </ext:Hidden>
                                        <ext:Hidden runat="server" ID="hdType">
                                            <Listeners>
                                                <Change Handler="#{stDisan}.reload();" />
                                            </Listeners>
                                        </ext:Hidden>
                                        <ext:Panel runat="server" ID="pnLoc" Width="700">
                                            <Content>
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                    <tbody>
                                                        <tr>
                                                            <td align="left">
                                                                <ext:ComboBox ID="cbCapDS" runat="server" FieldLabel="Cấp di sản" Width="300" EmptyText="--Chọn cấp di sản--"
                                                                    Mode="Local" AllowBlank="true" Hidden="false" DisplayField="TenCap" ValueField="ID"
                                                                    Disabled="false">
                                                                    <Store>
                                                                        <ext:Store runat="server" ID="stCapDiSan">
                                                                            <Reader>
                                                                                <ext:JsonReader IDProperty="ID">
                                                                                    <Fields>
                                                                                        <ext:RecordField Name="ID" />
                                                                                        <ext:RecordField Name="TenCap" />
                                                                                    </Fields>
                                                                                </ext:JsonReader>
                                                                            </Reader>
                                                                        </ext:Store>
                                                                    </Store>
                                                                    <Triggers>
                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                    </Triggers>
                                                                    <Listeners>
                                                                        <Select Handler="this.triggers[0].show();#{stDisan}.reload();" />
                                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();#{stDisan}.reload(); }" />
                                                                    </Listeners>
                                                                </ext:ComboBox>
                                                            </td>

                                                            <td align="left">
                                                                <ext:TextField ID="txtTenDiSan" runat="server" FieldLabel="Tên gọi" Hidden="false" Width="300">
                                                                    <Listeners>
                                                                        <Change Handler="#{stDisan}.reload();" />
                                                                    </Listeners>
                                                                </ext:TextField>
                                                            </td>

                                                            <td align="left">
                                                                <ext:Button runat="server" ID="Button1" ToggleGroup="Group1" Text="Tìm kiếm" Icon="Find">
                                                                    <Listeners>
                                                                        <Click Handler="#{stDisan}.reload()" />
                                                                    </Listeners>
                                                                </ext:Button>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <ext:DateField ID="dfTuNgay" runat="server" FieldLabel="Chứng nhận từ ngày" Width="300">
                                                                    <Listeners>
                                                                        <Select Handler="#{stDisan}.reload();" />
                                                                    </Listeners>
                                                                </ext:DateField>
                                                            </td>
                                                            <td align="left">
                                                                <ext:DateField ID="dfDenNgay" runat="server" FieldLabel="Đến ngày" Width="300">
                                                                    <Listeners>
                                                                        <Select Handler="#{stDisan}.reload();" />
                                                                    </Listeners>
                                                                </ext:DateField>
                                                            </td>

                                                            <td align="left">
                                                                <ext:Button runat="server" ID="btnCancel" ToggleGroup="Group1" Text="Bỏ điều kiện" Icon="Cross">
                                                                    <Listeners>
                                                                        <Click Fn="Cancel" />
                                                                    </Listeners>
                                                                </ext:Button>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <ext:ComboBox ID="cbNgonNgu" runat="server"  Width="250" FieldLabel="Ngôn ngữ" SelectOnFocus="true">
                                                                    <Items>
                                                                        <ext:ListItem Text="Tiếng việt" Value="vi" />
                                                                        <ext:ListItem Text="Tiếng Anh" Value="en" />
                                                                    </Items>
                                                                    <Listeners>
                                                                         <Change Handler="#{stDisan}.reload();" />
                                                                    </Listeners>
                                                                </ext:ComboBox>
                                                            </td>
                                                            <td>
                                                                <ext:Checkbox runat="server" ID="ckbNguoiTao" FieldLabel="Tin của bạn">
                                                                    <Listeners>
                                                                        <Change Handler="#{stDisan}.reload();" />
                                                                    </Listeners>
                                                                </ext:Checkbox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <div style="margin-bottom: 20px;"></div>
                                            </Content>
                                        </ext:Panel>
                                        <ext:GridPanel ID="gvDiSan" runat="server" Title="" Header="false" Border="true"
                                            Icon="UserSuit" AutoHeight="true" AutoExpandColumn="TenDiSan">
                                            <Store>
                                                <ext:Store ID="stDisan" runat="server" RemoteSort="true" DataSourceID="odsData" OnRefreshData="stDisan_RefreshData">
                                                    <AutoLoadParams>
                                                        <ext:Parameter Name="start" Value="0" Mode="Raw" />
                                                        <ext:Parameter Name="limit" Value="30" Mode="Raw" />
                                                    </AutoLoadParams>
                                                    <BaseParams>
                                                        <ext:Parameter Name="Filter" Value="#{txtFilter}.getValue()" Mode="Raw" />
                                                    </BaseParams>
                                                    <Proxy>
                                                        <ext:PageProxy />
                                                    </Proxy>
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="DiSanID">
                                                            <Fields>
                                                                <ext:RecordField Name="DiSanID" />
                                                                <ext:RecordField Name="MaDiSan" />
                                                                <ext:RecordField Name="TenDiSan" />
                                                                <ext:RecordField Name="DonViQuanLy" />
                                                                <ext:RecordField Name="LoaiDS" />
                                                                <ext:RecordField Name="AnhDaiDien" />
                                                                <ext:RecordField Name="CapDiSan" />
                                                                <ext:RecordField Name="NoiBat" />
                                                                <ext:RecordField Name="TrangThai" />
                                                                <ext:RecordField Name="STT" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                    <SortInfo Field="STT" Direction="ASC" />
                                                </ext:Store>
                                            </Store>
                                            <ColumnModel ID="ColumnModel1" runat="server">
                                                <Columns>
                                                    <ext:RowNumbererColumn Header="STT" Width="30" />
                                                    <ext:Column ColumnID="AnhDaiDien" DataIndex="AnhDaiDien" Header="Hình ảnh" Width="80" Align="Center">
                                                        <Renderer Fn="GetImage" />
                                                    </ext:Column>
                                                    <ext:Column ColumnID="MaDiSan" DataIndex="MaDiSan" Header="Mã di sản" Width="60" Hidden="false" />
                                                    <ext:Column ColumnID="TenDiSan" DataIndex="TenDiSan" Header="Tên di sản" Width="250" />
                                                    <ext:Column ColumnID="DonViQuanLy" DataIndex="DonViQuanLy" Header="Đơn vị quản lý" Width="150" Hidden="false" />
                                                    <ext:Column ColumnID="LoaiDS" DataIndex="LoaiDS" Header="Loại di sản" Width="100" Hidden="false" />
                                                    <ext:CheckColumn ColumnID="NoiBat" DataIndex="NoiBat" Header="Nổi bật" Width="40" />
                                                    <ext:CheckColumn ColumnID="TrangThai" DataIndex="TrangThai" Header="Duyệt" Width="40" />
                                                    <ext:CommandColumn Width="130">
                                                        <Commands>
                                                            <ext:GridCommand Icon="Delete" CommandName="Delete">
                                                                <ToolTip Text="Delete" />
                                                            </ext:GridCommand>
                                                            <ext:CommandSeparator />
                                                            <ext:GridCommand Icon="NoteEdit" CommandName="Edit">
                                                                <ToolTip Text="Edit" />
                                                            </ext:GridCommand>
                                                            <ext:CommandSeparator />
                                                            <%-- <ext:GridCommand Icon="MapAdd" CommandName="Mapping">
                                                                <ToolTip Text="Tạo bản đồ" />
                                                            </ext:GridCommand>
                                                            <ext:CommandSeparator />--%>
                                                            <ext:GridCommand Icon="Accept">
                                                                <Menu EnableScrolling="false">
                                                                    <Items>
                                                                        <ext:MenuCommand Text="Duyệt" Icon="Accept" CommandName="Active" />
                                                                        <ext:MenuCommand Text="Nổi bật" Icon="FlagChecked" CommandName="IsNew" />
                                                                    </Items>
                                                                </Menu>
                                                                <ToolTip Text="Menu" />
                                                            </ext:GridCommand>
                                                        </Commands>
                                                        <PrepareToolbar Fn="prepareToolbar" />
                                                    </ext:CommandColumn>
                                                </Columns>
                                            </ColumnModel>
                                            <SelectionModel>
                                                <ext:CheckboxSelectionModel SingleSelect="false" runat="server">
                                                    <Listeners>
                                                        <RowSelect Handler="#{btnDelete}.enable();#{btnExportDeTail}.enable();#{btnShow}.enable();" />
                                                        <RowDeselect Handler="if (!#{gvDiSan}.hasSelection()) {#{btnDelete}.disable();#{btnExportDeTail}.disable();#{btnShow}.disable();}" />
                                                    </Listeners>
                                                </ext:CheckboxSelectionModel>
                                            </SelectionModel>
                                            <Listeners>
                                                <Command Handler="fnCommand(command, record.data.DiSanID,record.data.TrangThai);" />
                                            </Listeners>
                                            <DirectEvents>
                                                <%-- <Command OnEvent="gvDiSan_Command">
                                                    <Confirmation ConfirmRequest="true" Title="Thông báo" Message="Bạn muốn xóa bản ghi này?" />
                                                    <ExtraParams>
                                                        <ext:Parameter Name="command" Value="command" Mode="Raw" />
                                                        <ext:Parameter Name="disanID" Value="record.data.DiSanID" Mode="Raw" />
                                                    </ExtraParams>
                                                </Command>--%>
                                                <DblClick OnEvent="gvDiSan_DbClick">
                                                </DblClick>
                                            </DirectEvents>
                                            <BottomBar>
                                                <ext:PagingToolbar ID="pageDiSan" runat="server" PageSize="30" DisplayInfo="true"
                                                    DisplayMsg="Hiển thị bản ghi {0} - {1} của {2}" EmptyMsg="Không có thông tin để hiển thị" />
                                            </BottomBar>
                                            <LoadMask ShowMask="true" />
                                        </ext:GridPanel>
                                    </Content>
                                    <TopBar>
                                        <ext:Toolbar ID="Toolbar1" runat="server">
                                            <Items>
                                                <ext:Button ID="btnUpdate" runat="server" Text="Thêm mới" Icon="Add">
                                                    <DirectEvents>
                                                        <Click OnEvent="btnUpdate_Click">
                                                            <ExtraParams>
                                                                <ext:Parameter Name="ID" Value="Ext.encode(#{gvDiSan}.getRowsValues({selectedOnly:true}))" Mode="Raw" />
                                                            </ExtraParams>
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:Button>
                                                <ext:Button ID="btnShow" runat="server" Text="Xem" Icon="ApplicationGet" Disabled="true">
                                                    <DirectEvents>
                                                        <Click OnEvent="btnShow_Click">
                                                            <ExtraParams>
                                                                <ext:Parameter Name="ID" Value="Ext.encode(#{gvDiSan}.getRowsValues({selectedOnly:true}))" Mode="Raw" />
                                                            </ExtraParams>
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:Button>
                                                <ext:Button ID="btnDelete" runat="server" Text="Xóa" Icon="Cross" Disabled="true">
                                                    <DirectEvents>
                                                        <Click OnEvent="btnDelete_Click">
                                                            <Confirmation ConfirmRequest="true" Title="Thông báo" Message="Bạn muốn xóa bản ghi này?" />
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:Button>
                                                <ext:Button ID="btnExportDeTail" Text="In phiếu" runat="server" Disabled="true" Icon="Report">
                                                    <DirectEvents>
                                                        <Click OnEvent="btnExportDeTail_Click" />
                                                    </DirectEvents>
                                                </ext:Button>
                                                <ext:Button ID="btnExport" runat="server" Text="Xuất báo cáo" Icon="PageExcel">
                                                    <DirectEvents>
                                                        <Click OnEvent="btnExport_Click" IsUpload="true" Before="ExportYap()">
                                                            <ExtraParams>
                                                                <ext:Parameter Name="data" Value="#{gvDiSan}.getRowsValues()" Mode="Raw" Encode="true" />
                                                            </ExtraParams>
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:Button>
                                                <ext:Hidden ID="txtFilter" runat="server" AutoDataBind="true">
                                                    <Listeners>
                                                        <Change Handler="#{pageDiSan}.changePage(1);" Delay="30" />
                                                    </Listeners>
                                                </ext:Hidden>
                                                <ext:ToolbarFill ID="ToolbarFill1" runat="server" />

                                            </Items>
                                        </ext:Toolbar>
                                    </TopBar>
                                </ext:Panel>
                            </Content>
                        </ext:Panel>
                    </Items>
                </ext:Panel>

            </Items>
        </ext:Viewport>
        <ext:Panel runat="server">
            <Items>
                <ext:Window runat="server" ID="wdDetail" Hidden="true"
                    DefaultButton="0" Border="false" AutoScroll="false" Maximizable="true" Collapsible="true"
                    MinWidth="1000" Height="550" Modal="true" Padding="3" Resizable="false" Maximized="true">
                    <%-- <Listeners>
                        <Hide Handler="if(hdMsg.getValue()=='ok'){hdMsg.setValue('');#{stDisan}.reload();Ext.Msg.alert('Thông báo','Đã cập nhật thành công');}" />
                    </Listeners>--%>
                </ext:Window>
                <ext:Hidden runat="server" ID="hdMsg">
                    <Listeners>
                        <Change Handler="if(hdMsg.getValue()=='ok'){wdDetail.hide();hdMsg.setValue('');#{stDisan}.reload();Ext.Msg.alert('Thông báo','Đã cập nhật thành công');}" />
                    </Listeners>
                </ext:Hidden>
            </Items>
        </ext:Panel>
    </form>
</body>
</html>
