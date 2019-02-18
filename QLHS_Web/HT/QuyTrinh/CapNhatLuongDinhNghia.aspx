<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CapNhatLuongDinhNghia.aspx.cs" Inherits="HT_QuyTrinh_CapNhatLuongDinhNghia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>
    <script src="/Scripts/jquery-1.7.1.min.js"></script>
    <script type="text/javascript">
        var ExportYap = function () {
            Ext.net.Mask.show();
            Ext.net.Mask.hide.defer(500);
        };
        var lst = [];
        var currext = 1;
        var toStep = 1;

        $(document).ready(function () {
            var idQT = $.urlParam('id');
            if (idQT != null) {
                Ext.onReady(function () {
                    Ext.net.DirectMethods.Check(idQT, {
                        success: function (result) {
                            var i = 0;
                            for (i; i < result.length; i++) {
                                lst.push(result[i]);
                                toStep += 1;
                            }
                            toStep = toStep > 1 ? toStep + 1 : 1;
                            setValue(lst[0]);
                            Ext.getCmp('btnPrev').hide();
                        },

                        failure: function (errorMsg) {
                            Ext.Msg.alert('Failure', errorMsg);
                        }
                    });
                });
            }
        });
        $.urlParam = function (name) {
            var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
            if (results == null) {
                return null;
            }
            else {
                return results[1] || 0;
            }
        }
        function Update() {
            if (lst.length > 0) {
                Ext.Msg.confirm("Thông báo", "Sau khi lưu, nếu phát sinh hồ sơ liên quan đến quy trình này bạn sẽ không thể thay đổi các bước trong quy trình này?", function (btn) {
                    if (btn == "yes") {
                        Ext.net.DirectMethods.Update(lst, {
                            success: function (result) {
                                var data = eval("(" + result + ")");
                                node.loadNodes(data);
                            },

                            failure: function (errorMsg) {
                                Ext.Msg.alert('Failure', errorMsg);
                            }
                        });
                    }
                });
            }
            else {
                Ext.Msg.alert("Cảnh báo", "Bạn chưa tạo luồng xử lý nào cho quy trình này!!!");
            }
        }
        function CreateNewTheard() {
            Ext.getCmp('btnPrev').show();
            var c = currext;
            var step = toStep;
            if (currext < toStep) {
                ExportYap();
                NextTheard();
            }
            else {
                var obj = getValue();
                if (obj != null) {
                    ExportYap();
                    lst.push(obj);
                    currext += 1;
                    toStep += 1;
                    step = toStep;
                    ResetValue();
                }
            }
        }
        function ToTheard(count) {
            currext = currext + count;
            if (currext <= 1) {
                Ext.getCmp('btnPrev').hide();
            }
            if (currext == toStep) {
                ResetValue();
            }
            else {
                setValue(lst[currext - 1]);
            }
        }
        function setValue(obj) {
            Ext.getCmp('txtTen').setValue(obj.Ten);
            Ext.getCmp('cbCoQuan').setValue(obj.CoQuanID);
            Ext.getCmp('cbCanbo').setValue(obj.NguoiXuLy);
            Ext.getCmp('txtStt').setValue(currext);
            Ext.getCmp('hdID').setValue(obj.ID);
            Ext.getCmp('txtMoTa').setValue(obj.MoTa);
            Ext.getCmp('txtThoiGian').setValue(obj.ThoiGianHT);
        }
        function NextTheard() {
            if (currext == toStep) {
                ResetValue();
            }
            var obj = getValue();
            if (obj != null) {
                lst[currext - 1] = obj;
                ToTheard(1);
            }
        }
        function getValue() {
            var obj = {};
            obj.Ten = Ext.getCmp('txtTen').getValue();
            obj.ID = Ext.getCmp('hdID').getValue();
            obj.CoQuanID = Ext.getCmp('cbCoQuan').getValue();
            obj.NguoiXuLy = Ext.getCmp('cbCanbo').getValue();
            obj.MoTa = Ext.getCmp('txtMoTa').getValue();
            obj.STT = Ext.getCmp('txtStt').getValue();
            obj.ThoiGianHT = Ext.getCmp('txtThoiGian').getValue();

            if (obj.Ten == '' || obj.CoQuanID == '' || obj.NguoiXuLy == '') {
                Ext.Msg.alert("Cảnh báo", "Bạn chưa nhập đủ thông tin cho bước này!!!");
                return null;
            }
            else {
                return obj;
            }
        }
        function PrevTheard() {
            ToTheard(-1)
        }
        function ResetValue() {
            Ext.getCmp('txtTen').setValue('');
            Ext.getCmp('cbCoQuan').setValue('0');
            Ext.getCmp('cbCanbo').setValue('');
            var stt = Ext.getCmp('txtStt').getValue();
            if (stt == '') stt = 1;
            Ext.getCmp('txtStt').setValue(stt + 1);
            Ext.getCmp('txtMoTa').setValue('');
            Ext.getCmp('hdID').setValue('0');
            Ext.getCmp('txtThoiGian').setValue('5');
        }

        function CheckUser(canboID) {
            Ext.net.DirectMethods.CheckUser(canboID, {
                success: function (result) {
                    if (!result) {
                        Ext.Msg.alert("Thông báo", "Cán bộ này chưa có tài khoản. Cán bộ cần có tài khoản đăng nhập hệ thống trước để xử lý hồ sơ").Show();
                    }
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
        <!----Goi ung dung ext------>
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Store ID="stCanbo" runat="server" AutoLoad="true" OnRefreshData="stCanbo_RefreshData">
            <Reader>
                <ext:JsonReader IDProperty="CanBoID">
                    <Fields>
                        <ext:RecordField Name="CanBoID" />
                        <ext:RecordField Name="HoTen" />
                        <ext:RecordField Name="ChucVu" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="0" Mode="Raw" />
                <ext:Parameter Name="limit" Value="10" Mode="Raw" />
            </AutoLoadParams>
        </ext:Store>
        <ext:Panel ID="ViewPort1" Padding="10" runat="server" Layout="FormLayout" AutoScroll="true" LabelWidth="150" EnableTheming="false">
            <Content>
                <ext:Hidden runat="server" ID="hdID" Text="0" />
                <ext:TextField ID="txtTen" runat="server" FieldLabel="Tên giai đoạn" Width="350" Margins="2" IndicatorText="*" />
                <ext:ComboBox FieldLabel="Cơ quan" ID="cbCoQuan" runat="server"
                    SelectedIndex="0" DisplayField="TenCoQuan"
                    ValueField="CoQuanID" Width="350"
                    SelectOnFocus="true">
                    <Store>
                        <ext:Store runat="server" ID="stCoquan" AutoLoad="true">
                            <DirectEventConfig>
                                <EventMask ShowMask="false" />
                            </DirectEventConfig>
                            <Reader>
                                <ext:JsonReader IDProperty="CoQuanID">
                                    <Fields>
                                        <ext:RecordField Name="CoQuanID" />
                                        <ext:RecordField Name="TenCoQuan" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <Listeners>
                        <Select Handler="#{cbCanbo}.clearValue(); #{stCanbo}.reload()" />
                    </Listeners>
                </ext:ComboBox>
                <ext:ComboBox
                    ID="cbCanbo" FieldLabel="Cán bộ"
                    runat="server"
                    EmptyText="Chọn cán bộ"
                    TypeAhead="true"
                    ForceSelection="true"
                    StoreID="stCanbo"
                    Mode="Local"
                    DisplayField="HoTen"
                    ValueField="CanBoID"
                    MinChars="1"
                    ListWidth="300"
                    PageSize="10"
                    ItemSelector="tr.list-item">
                    <Template ID="Template1" runat="server">
                        <Html>
                            <tpl for=".">
						<tpl if="[xindex] == 1">
							<table class="cbStates-list">
								<tr>
									<th>Tên</th>
									<th>Chức vụ</th>
								</tr>
						</tpl>
						<tr class="list-item">
							<td style="padding:3px 5px">{HoTen}</td>
							<td>{ChucVu}</td>
						</tr>
						<tpl if="[xcount-xindex]==0">
							</table>
						</tpl>
					</tpl>
                        </Html>
                    </Template>
                    <Triggers>
                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                    </Triggers>
                    <Listeners>
                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                        <TriggerClick Handler="if (index == 0) { this.focus().clearValue(); trigger.hide();}" />
                        <Select Handler="this.triggers[0].show();CheckUser(this.getValue());" />
                    </Listeners>
                </ext:ComboBox>
                <ext:TextArea runat="server" ID="txtMoTa" FieldLabel="Mô tả công việc" Width="650" />
                <ext:NumberField runat="server" ID="txtThoiGian" FieldLabel="Thời gian xử lý" MinValue="1" Text="5" IndicatorText="Ngày" />
                <ext:NumberField runat="server" ID="txtStt" Disabled="true" FieldLabel="STT" MinValue="1" Text="1" />

            </Content>
            <Buttons>
                <ext:Button runat="server" ID="btnPrev" Text="Bước trước" Hidden="true">
                    <Listeners>
                        <Click Fn="PrevTheard" />
                    </Listeners>
                </ext:Button>
                <ext:Button runat="server" ID="btnAddTheard" Text="Bước tiếp theo">
                    <Listeners>
                        <Click Fn="CreateNewTheard" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <TopBar>
                <ext:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <ext:Button ID="btnUpdate" Text="Lưu lại" Icon="DatabaseSave" runat="server">
                            <Listeners>
                                <Click Fn="Update" />
                            </Listeners>
                        </ext:Button>
                        <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                    </Items>
                </ext:Toolbar>
            </TopBar>
        </ext:Panel>
    </form>
</body>
</html>
