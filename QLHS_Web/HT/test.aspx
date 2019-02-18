<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs"
    Inherits="Test" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server">
        </ext:ResourceManager>
        <ext:Store ID="Store1" runat="server">
            <Reader>
                <ext:ArrayReader>
                    <Fields>
                        <ext:RecordField Name="company" />
                        <ext:RecordField Name="price" Type="Float" />
                        <ext:RecordField Name="change" Type="Float" />
                        <ext:RecordField Name="pctChange" Type="Float" />
                        <ext:RecordField Name="lastChange" Type="Date" DateFormat="n/j h:ia" />
                    </Fields>
                </ext:ArrayReader>
            </Reader>
        </ext:Store>

        <ext:GridPanel ContextMenuID="RowContextMenu"
            ID="GridPanel1"
            runat="server"
            StoreID="Store1"
            StripeRows="true"
            Title="Array Grid"
            TrackMouseOver="true"
            Width="600"
            Height="350"
            AutoExpandColumn="Company">
            <ColumnModel ID="ColumnModel1" runat="server">
                <Columns>
                    <ext:Column ColumnID="Company" Header="Company" Width="160" Sortable="true" DataIndex="company" />
                    <ext:Column Header="Price" Width="75" Sortable="true" DataIndex="price">
                        <Renderer Format="UsMoney" />
                    </ext:Column>
                    <ext:Column Header="Change" Width="75" Sortable="true" DataIndex="change" />
                    <ext:Column Header="Change" Width="75" Sortable="true" DataIndex="pctChange" />
                    <ext:Column Header="Last Updated" Width="85" Sortable="true" DataIndex="lastChange">
                        <Renderer Fn="Ext.util.Format.dateRenderer('m/d/Y')" />
                    </ext:Column>
                </Columns>
            </ColumnModel>
            <SelectionModel>
                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
            </SelectionModel>
            <Listeners>
                <ContextMenu Handler="e.preventDefault(); #{RowContextMenu}.dataRecord = this.store.getAt(rowIndex);#{RowContextMenu}.show();" />
            </Listeners>
        </ext:GridPanel>

        <ext:Menu ID="RowContextMenu" runat="server">
            <Items>
                <ext:MenuTextItem ID="CompanyLabel" runat="server" CtCls="company-label" Text='this.parentMenu.dataRecord.data.company'/>
                <ext:MenuItem runat="server" Text="Delete" Icon="Delete">
                    <Listeners>
                        <Click Handler="Ext.Msg.alert(this.getColumnModel().getDataIndex(colIndex)), 'Delete');" />
                    </Listeners>
                </ext:MenuItem>
                <ext:MenuItem runat="server" Text="Print" Icon="Printer">
                    <Listeners>
                        <Click Handler="Ext.Msg.alert(this.getColumnModel().getDataIndex(colIndex));, 'Print');" />
                    </Listeners>
                </ext:MenuItem>
            </Items>
        </ext:Menu>
    </form>
</body>
</html>
