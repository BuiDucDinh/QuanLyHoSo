<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Don_Vi.aspx.cs" Inherits="Common_Don_Vi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Multi Node TreePanel built from code-behind - Ext.NET Examples</title>
    <script type="text/javascript">
        var filterTree = function (el, e) {
            var tree = TreePanel1,
                text = this.getRawValue();

            tree.clearFilter();

            if (Ext.isEmpty(text, false)) {
                return;
            }

            if (e.getKey() === Ext.EventObject.ESC) {
                clearFilter();
            } else {
                var re = new RegExp(".*" + text + ".*", "i");

                tree.filterBy(function (node) {
                    return re.test(node.text);
                });
            }
        };

        var clearFilter = function () {
            var field = TriggerField1,
                tree = TreePanel1;

            field.setValue("");
            tree.clearFilter();
            tree.getRootNode().collapseChildNodes(true);
            tree.getRootNode().ensureVisible();
        };
    </script>
</head>
<body>
    <form id="Form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
  <ext:Viewport ID="Viewport1" runat="server" AutoScroll="true"  StyleSpec="background-color:white">   
            <Items>
               
                <ext:BorderLayout ID="BorderLayout1" runat="server">
                    <North>
                    <ext:Toolbar runat="server" Height="25">
                        <Items>
                             <ext:Button ID="btnOK" Icon="Accept" Text="Chọn" runat="server" >
                                <DirectEvents>
                                    <Click OnEvent="btnOK_Click" />
                                </DirectEvents>
                             </ext:Button>
                               <ext:Button ID="btnBack" Icon="DoorOut" Text="Quay về" runat="server">
                                <DirectEvents>
                                    <Click OnEvent="btnBack_Click" />
                                </DirectEvents>
                             </ext:Button>
                        </Items>
                    </ext:Toolbar>
                   
                    </North>
                    <West>
                        <ext:TreePanel ID="TreePanel1" runat="server" Title="DANH MỤC ĐƠN VỊ" 
                            AutoScroll="true" AutoHeight="true" Border="true" Width="350">
                            <DirectEvents>
                                <Click OnEvent="tree1_Click">
                                    <ExtraParams>
                                        <ext:Parameter Name="Ma_Don_Vi" Value="#{TreePanel1}.getSelectionModel().getSelectedNode().id" Mode="Raw"/>
                                    </ExtraParams>
                                </Click>
                            </DirectEvents>
                            <Loader>
                                <ext:PageTreeLoader OnNodeLoad="NodeLoad">
                                </ext:PageTreeLoader>
                            </Loader>
                            <Root>
                                <ext:AsyncTreeNode NodeID="0" Text="SỞ NÔNG NGHIỆP VÀ PTNT" Expanded="true" />
                            </Root>
                            <TopBar>
                                <ext:Toolbar ID="Toolbar1" runat="server">
                                    <Items>
                                        <ext:ToolbarTextItem ID="ToolbarTextItem1" runat="server" Text="Lọc:" />
                                        <ext:ToolbarSpacer />
                                        <ext:TriggerField ID="TriggerField1" runat="server" EnableKeyEvents="true" Width="200">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" />
                                            </Triggers>
                                            <Listeners>
                                                <KeyUp Fn="filterTree" Buffer="250" />
                                                <TriggerClick Handler="clearFilter();" />
                                            </Listeners>
                                        </ext:TriggerField>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                        </ext:TreePanel>
                     </West>
                    
                    <Center>
                       <ext:GridPanel ID="gridPB" runat="server" Title="DANH SÁCH PHÒNG BAN" Margins="0 0 5 5"
                            Header="true" Icon="UserSuit" AutoHeight="true" Width="700">
                            <Store>
                                <ext:Store ID="dsPB" runat="server" RemoteSort="true" OnRefreshData="dsPBRefreshData">
                                    <Reader>
                                        <ext:JsonReader IDProperty="Ma_Phong">
                                            <Fields>
                                                <ext:RecordField Name="Ma_Phong" />
                                                <ext:RecordField Name="Ten_Phong" />
                                                <ext:RecordField Name="So_Nguoi" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                    <SortInfo Field="Ma_Phong" Direction="ASC" />
                                </ext:Store>
                            </Store>
                            <DirectEvents>
                                <RowClick OnEvent="gridPB_RowClick" />
                            </DirectEvents>
                            <ColumnModel ID="ColumnModel6" runat="server">
                                <Columns>
                                    <ext:Column ColumnID="Ma_Phong" DataIndex="Ma_Phong" Header="Mã quan hệ" Width="150"
                                        Hidden="true" />
                                    <ext:Column ColumnID="Ten_Phong" DataIndex="Ten_Phong" Header="Tên phòng ban"
                                        Width="250"  />
                                    <ext:Column ColumnID="So_Nguoi" DataIndex="So_Nguoi" Header="Số nhân viên"
                                        Width="150" />
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel6" runat="server" />
                            </SelectionModel>
                            <LoadMask ShowMask="true" />                            
                        </ext:GridPanel>
                        </Center>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
