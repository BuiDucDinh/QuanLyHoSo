<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DanhSach.aspx.cs" Inherits="NghiepVu_Hoatdongvanhoa_DanhSach" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript" src="/Scripts/jquery-1.7.1.min.js"></script>
    <script type="text/javascript">
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
                childCheck(selNodes, true);
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

        function childCheck(node, checked) {
            node.expand();
            var nodeAttr = node.attributes;
            if (!nodeAttr.leaf) {
                node.eachChild(function (child) {
                    if (child && child.getUI().checkbox != undefined) {
                        child.getUI().checkbox.checked = checked;
                    }
                    childCheck(child, checked);
                });
            }
        }
        //var getTasks = function () {
        //    var msg = "",
        //        selNodes = TreePanel1.getChecked();

        //    Ext.each(selNodes, function (node) {
        //        if (msg.length > 0) {
        //            msg += ", ";
        //        }

        //        msg += node.text;
        //    });
        //};
        var GetImage = function (value) {
            return "<img src='/FileUpload/Images/" + value + "' style=\'width:60px; height:auto\'/>";
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
        var prepareToolbar = function (grid, toolbar, rowIndex, record) {
            var ma = Ext.getCmp('hdRole').getValue();
            var role = JSON.parse(ma);
            if (!role.Duoc_Duyet) {
                toolbar.items.itemAt(4).hide();
            }
            if (!role.Duoc_Sua) {
                toolbar.items.itemAt(2).hide();
                toolbar.items.itemAt(3).hide();
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
                    Ext.getCmp('btnExport').hide();
                }
            });
        });
    </script>
    <link href="/css/other.css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server">
        <asp:ObjectDataSource ID="dsNV_Hoatdongvanhoa_Obj" runat="server" OnSelected="odsNV_Hoatdongvanhoa_Selected" SelectMethod="Page_By_Filter" TypeName="QLHS_Logic.Sys_Common">
            <SelectParameters>
                <asp:Parameter Name="Start" Type="Int32" />
                <asp:Parameter Name="Limit" Type="Int32" />
                <asp:Parameter Name="WhereString" Type="String" />
                <asp:Parameter Name="SortString" Type="String" />
                <asp:Parameter Direction="Output" Name="Count" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>

        <ext:ResourceManager ID="ResourceManager1" runat="server">
        </ext:ResourceManager>
        <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
            <Items>
                <ext:Panel ID="Panel1" runat="server" Layout="border" Border="false" Region="Center">
                    <Items>
                        <ext:Panel ID="Panel3" runat="server" Region="West" Split="true" Margins="0 0 0 0"
                            Frame="true" DefaultAnchor="100%" Width="250">
                            <Items>
                                <ext:Panel ID="Panel4" runat="server" Region="South" Split="true" Margins="0 0 0 0"
                                    Frame="true" Title="Loại hình văn hóa" Icon="BookAddresses"
                                    DefaultAnchor="100%">
                                    <Items>
                                        <ext:TreePanel
                                            ID="TreePanel2"
                                            runat="server"
                                            AutoHeight="true"
                                            Border="false" Height="150" AutoScroll="true">
                                            <Root>
                                                <ext:AsyncTreeNode NodeID="0" Text="Di sản văn hóa" SingleClickExpand="true" Expanded="true" />
                                            </Root>
                                            <Listeners>
                                                <BeforeLoad Fn="NodeLoadType" />
                                                <CheckChange Fn="getTasksType" />
                                            </Listeners>
                                        </ext:TreePanel>
                                    </Items>
                                </ext:Panel>

                                <ext:Panel ID="Panel2" runat="server" Region="North" Split="true" Margins="0 0 0 0"
                                    Frame="true" Title="Địa điểm" Icon="House"
                                    DefaultAnchor="100%">
                                    <Items>
                                        <ext:TreePanel
                                            ID="TreePanel1" CheckedNodes=""
                                            runat="server"
                                            Border="false" Height="420" AutoScroll="true">
                                            <Root>
                                                <ext:AsyncTreeNode NodeID="T36" Text="Địa điểm" Expanded="true" Leaf="false" />
                                            </Root>
                                            <Listeners>
                                                <BeforeLoad Fn="NodeLoadAddress" />
                                                <CheckChange Fn="getTasksAddress" />
                                            </Listeners>
                                        </ext:TreePanel>
                                    </Items>
                                </ext:Panel>
                            </Items>
                        </ext:Panel>

                        <ext:Panel ID="pnlExplorer" runat="server" Region="Center" Margins="0 0 0 0" Frame="true" AutoScroll="true"
                            Icon="LayoutHeader" Layout="FitLayout">
                            <Content>
                                <ext:Panel ID="Panel5" Title="Danh sách Hoạt động văn hóa" runat="server" AutoScroll="true" AutoHeight="true" LabelWidth="150">
                                    <Items>
                                        <ext:Panel runat="server" ID="pnLoc" Padding="10" Width="700">
                                            <Items>
                                                <ext:Hidden runat="server" ID="hdRole" />
                                                <ext:Hidden runat="server" ID="hdAddress">
                                                    <Listeners>
                                                        <Change Handler="#{dsNV_Hoatdongvanhoa}.reload();" />
                                                    </Listeners>
                                                </ext:Hidden>
                                                <ext:Hidden runat="server" ID="hdType">
                                                    <Listeners>
                                                        <Change Handler="#{dsNV_Hoatdongvanhoa}.reload();" />
                                                    </Listeners>
                                                </ext:Hidden>
                                                <ext:TextField runat="server" ID="txtTenhoatdong" Width="600" FieldLabel="Tên hoạt động văn hóa">
                                                    <Listeners>
                                                        <Change Handler="#{dsNV_Hoatdongvanhoa}.reload();" />
                                                    </Listeners>
                                                </ext:TextField>
                                                <ext:ComboBox runat="server" ID="cmbDiSan" FieldLabel="Chọn di sản văn hóa" SelectedIndex="0" Width="600" DisplayField="TenDiSan" ValueField="DiSanID">
                                                    <Store>
                                                        <ext:Store runat="server" ID="stDiSan">
                                                            <Reader>
                                                                <ext:JsonReader>
                                                                    <Fields>
                                                                        <ext:RecordField Name="DiSanID" />
                                                                        <ext:RecordField Name="TenDiSan" />
                                                                    </Fields>
                                                                </ext:JsonReader>
                                                            </Reader>
                                                        </ext:Store>
                                                    </Store>
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Select Handler="this.triggers[0].show();#{dsNV_Hoatdongvanhoa}.reload();" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();#{dsNV_Hoatdongvanhoa}.reload(); }" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                                <ext:ComboBox runat="server" ID="cmbDonvitochuc" SelectedIndex="0" Width="600" FieldLabel="Đơn vị tổ chức" DisplayField="TenCoQuan" ValueField="CoQuanID">
                                                    <Store>
                                                        <ext:Store runat="server" ID="stCoQuan">
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
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Select Handler="this.triggers[0].show();#{dsNV_Hoatdongvanhoa}.reload();" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();#{dsNV_Hoatdongvanhoa}.reload(); }" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                                 <ext:ComboBox runat="server" ID="cmbLang" FieldLabel="Ngôn ngữ" SelectedIndex="0" Width="600">
                                                  <Items>
                                                      <ext:ListItem Text="Tiếng việt" Value="vi" />
                                                      <ext:ListItem Text="Tiếng anh" Value="en" />
                                                  </Items>
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="false" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Select Handler="this.triggers[0].show();#{dsNV_Hoatdongvanhoa}.reload();" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler=" {#{dsNV_Hoatdongvanhoa}.reload(); }" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                            </Items>
                                            <Buttons>
                                                <%--<ext:Button runat="server" ID="btnLoc" ToggleGroup="Group1" Text="Lọc" Icon="Find">
                                                    <Listeners>
                                                        <Click Handler="getTasks();" />
                                                    </Listeners>
                                                    <DirectEvents>
                                                        <Click OnEvent="btnLoc_Click" />
                                                    </DirectEvents>
                                                </ext:Button>--%>
                                                <ext:Button runat="server" ID="btnCancel" ToggleGroup="Group1" Text="Bỏ điều kiện" Icon="Cross">
                                                    <DirectEvents>
                                                        <Click OnEvent="btnCancel_Click" />
                                                    </DirectEvents>
                                                </ext:Button>
                                            </Buttons>
                                        </ext:Panel>
                                        <ext:GridPanel ID="gvHoatdong" runat="server" Title="Danh sách di sản văn hóa" Margins="0 0 5 5" Header="false"
                                            Icon="UserSuit" AutoHeight="true">
                                            <Store>
                                                <ext:Store ID="dsNV_Hoatdongvanhoa" runat="server" RemoteSort="true" DataSourceID="dsNV_Hoatdongvanhoa_Obj" OnRefreshData="dsNV_Hoatdongvanhoa_RefreshData">
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
                                                        <ext:JsonReader IDProperty="HoatDongID">
                                                            <Fields>
                                                                <ext:RecordField Name="HoatDongID" />
                                                                <ext:RecordField Name="TenGoi" />
                                                                <ext:RecordField Name="TenGoiKhac" />
                                                                <ext:RecordField Name="NgayDienRa" />
                                                                <ext:RecordField Name="ThoiGianDienRa" />
                                                                <ext:RecordField Name="DiSanID" />
                                                                <ext:RecordField Name="DiaDiem" />
                                                                <ext:RecordField Name="AnhDaiDien" />
                                                                <ext:RecordField Name="Duyet" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                    <SortInfo Field="HoatDongID" Direction="ASC" />
                                                </ext:Store>
                                            </Store>
                                            <ColumnModel ID="ColumnModel1" runat="server">
                                                <Columns>
                                                    <ext:RowNumbererColumn Header="STT" Width="20" />
                                                    <ext:Column ColumnID="AnhDaiDien" DataIndex="AnhDaiDien" Header="Hình ảnh" Width="80" Align="Center">
                                                        <Renderer Fn="GetImage" />
                                                    </ext:Column>
                                                    <ext:Column ColumnID="TenGoi" DataIndex="TenGoi" Header="Tên gọi" Width="250" />
                                                    <ext:Column ColumnID="TenGoiKhac" DataIndex="TenGoiKhac" Header="Tên gọi khác" Width="100" />
                                                    <ext:DateColumn ColumnID="NgayDienRa" DataIndex="NgayDienRa" Header="Ngày diễn ra" Width="100" Format="dd/MM/yyyy" />
                                                    <ext:Column ColumnID="ThoiGianDienRa" DataIndex="ThoiGianDienRa" Header="Thời gian diễn ra" Width="100" />
                                                    <ext:CheckColumn DataIndex="Duyet" Header="Duyệt" Width="50" />
                                                    <ext:CommandColumn Width="150" Align="Right">
                                                        <Commands>
                                                            <ext:GridCommand Icon="Delete" CommandName="Delete">
                                                                <ToolTip Text="Xóa" />
                                                            </ext:GridCommand>
                                                            <ext:CommandSeparator />
                                                            <ext:GridCommand Icon="NoteEdit" CommandName="Edit">
                                                                <ToolTip Text="Sửa" />
                                                            </ext:GridCommand>
                                                            <ext:CommandSeparator />
                                                            <ext:GridCommand Icon="Accept" CommandName="Active" Text="Duyệt">
                                                                <ToolTip Text="Duyệt" />
                                                            </ext:GridCommand>
                                                        </Commands>
                                                        <PrepareToolbar Fn="prepareToolbar" />
                                                    </ext:CommandColumn>
                                                </Columns>
                                            </ColumnModel>
                                            <Listeners>
                                                <Command Handler="fnCommand(command, record.data.HoatDongID, record.data.Duyet);" />
                                            </Listeners>
                                            <SelectionModel>
                                                <ext:RowSelectionModel runat="server" SingleSelect="true">
                                                    <Listeners>
                                                        <RowSelect Handler="#{btnDelete}.enable();#{btnShow}.enable();" />
                                                        <RowDeselect Handler="if (!#{gvHoatdong}.hasSelection()) {#{btnDelete}.disable();#{btnShow}.disable();}" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                            <DirectEvents>
                                                <DblClick OnEvent="gvHoatdong_DonViTuBo_DbClick">
                                                </DblClick>
                                            </DirectEvents>
                                            <BottomBar>
                                                <ext:PagingToolbar ID="pageHT_Don_Vi_YT" runat="server" PageSize="30" DisplayInfo="true"
                                                    DisplayMsg="Hiện thị bản ghi {0} - {1} của {2}" EmptyMsg="Không có thông tin để hiển thị" />
                                            </BottomBar>
                                            <LoadMask ShowMask="true" />
                                        </ext:GridPanel>
                                    </Items>
                                    <TopBar>
                                        <ext:Toolbar ID="Toolbar1" runat="server">
                                            <Items>
                                                <ext:Button ID="btnUpdate" runat="server" Text="Thêm mới" Icon="Add">
                                                    <DirectEvents>
                                                        <Click OnEvent="btnUpdate_Click">
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:Button>
                                                <ext:Button ID="btnShow" runat="server" Text="Xem" Icon="ApplicationGet" Disabled="true">
                                                    <DirectEvents>
                                                        <Click OnEvent="btnShow_Click">
                                                            <ExtraParams>
                                                                <ext:Parameter Name="ID" Value="Ext.encode(#{gvHoatdong}.getRowsValues({selectedOnly:true}))" Mode="Raw" />
                                                            </ExtraParams>
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:Button>
                                                <ext:Button ID="btnDelete" runat="server" Text="Xóa" Icon="BulletCross">
                                                    <DirectEvents>
                                                        <Click OnEvent="btnDelete_Click">
                                                            <Confirmation ConfirmRequest="true" Title="Thông báo" Message="Bạn muốn xóa bản ghi này?" />
                                                            <EventMask ShowMask="true" MinDelay="100" Msg="Xin vui lòng chờ đợi !!!" />
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:Button>
                                                <ext:Hidden ID="txtFilter" runat="server" AutoDataBind="true">
                                                    <Listeners>
                                                        <Change Handler="#{pageNV_Hoatdongvanhoa}.changePage(1);" Delay="30" />
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
                <ext:Window ID="winDetails" runat="server" Icon="ApplicationEdit" MinWidth="1000" MinHeight="550" Modal="true" Hidden="true"
                    Layout="Fit" Collapsible="true" Maximizable="true">
                </ext:Window>
                <ext:Hidden runat="server" ID="hdMsg">
                    <Listeners>
                        <Change Handler="if(hdMsg.getValue()=='ok'){winDetails.hide();hdMsg.setValue('');#{dsNV_Hoatdongvanhoa}.reload();Ext.Msg.alert('Thông báo','Đã cập nhật thành công');}" />
                    </Listeners>
                </ext:Hidden>
            </Items>
        </ext:Panel>
    </form>
</body>
</html>
