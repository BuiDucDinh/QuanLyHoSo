<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/Site.master" CodeFile="HoatDongVanHoa.aspx.cs" Inherits="Template_DanhMucDiSan" %>

<%@ Register Src="~/Template/Controls/RightContent.ascx" TagPrefix="uc1" TagName="RightContent" %>


<asp:Content runat="server" ContentPlaceHolderID="Navigate">
    <a href="/"><%=Resources.labels.home %></a>
    <span>> </span>
    <a href="#"><%=Resources.labels.hoatdongvanhoa %></a>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="left-main">
        <div class="module">
             <div class="module-title">
                <a href="#" class="TitleCate" title="<%=Resources.labels.hoatdongvanhoa %>">
                    <span><%=Resources.labels.hoatdongvanhoa %></span>
                </a>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="module-content">
                        <div class="search-box welcome">
                                <div class="search-item">
                                    <div class="styled-select slate">
                                        <asp:DropDownList runat="server" ID="ddlDisan" DataValueField="DiSanID" DataTextField="TenDiSan" ClientIDMode="Static" />
                                    </div>
                                </div>
                                <div class="search-item">
                                    <asp:TextBox runat="server" ID="txtNgay" ClientIDMode="Static" MaxLength="70" placeholder='<%$ Resources:labels, from %>'/>
                                </div>

                                <div class="search-item">
                                    <div class="styled-select slate">
                                        <asp:DropDownList runat="server" ID="ddlTinh" DataValueField="Ma_Tinh" DataTextField="Ten_Tinh" ClientIDMode="Static" OnSelectedIndexChanged="ddlTinh_SelectedIndexChanged" AutoPostBack="true" />
                                    </div>
                                </div>

                                <div class="search-item">
                                    <div class="styled-select slate">
                                        <asp:DropDownList runat="server" ID="ddlHuyen" DataValueField="Ma_Huyen" DataTextField="Ten_Huyen" ClientIDMode="Static" />
                                    </div>
                                </div>
                            <div class="clearfix"></div>
                            <div class="sumbit-btn">
                                <asp:Button runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" CssClass="btn-default btn-search" Text='<%$ Resources:labels, search %>' />
                                <asp:Button runat="server" ID="btnCancel" OnClick="btnCancel_Click" CssClass="btn-default btn-search" Text='<%$ Resources:labels, bodieukien %>' />
                            </div>
                        </div>

                        <div class="result" id="divs">
                            <asp:Repeater runat="server" ID="rptTintuc">
                                <ItemTemplate>
                                    <div class="new-item-search">
                                        <div class="left-new">
                                            <a href="<%#Eval("url") %>">
                                                <img src="/FileUpload/Images/<%#Eval("HinhAnh") %>" />
                                            </a>
                                        </div>
                                        <div class="right-new">
                                            <a href="<%#Eval("url") %>" class="new-title">
                                                <h3><%#Eval("TenGoi") %> <%#Eval("TenGoiKhac") %></h3>

                                            </a>
                                            <p><%=Resources.labels.ngaykhiamac %> : <%#DataBinder.Eval(Container.DataItem, "NgayDienRa", "{0:d/M/yyyy}")%></p>
                                            <p><%=Resources.labels.thoigiandienra %> : <%#Eval("ThoiGianDienRa") %></p>
                                            <p><%=Resources.labels.dsvh %> : <%#Eval("DiSan") %></p>
                                            <p><%=Resources.labels.donvitochuc %> : <%#Eval("DonViToChuc") %></p>
                                            <%-- <p class="new-description">
                                            <%#Eval("GioiThieu") %>
                                        </p>--%>
                                        </div>
                                        <div class="clearfix"></div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div id="pagination"></div>
                    </div>


                    <link href="/Template/css/jsDatePick_ltr.min.css" rel="stylesheet" />
                    <script src="/Template/js/jsDatePick.jquery.min.1.3.js"></script>

                    <script type="text/javascript">
                        $(document).ready(function () {
                            Initialize();
                            var totalrow = $("#divs .new-item-search").length;
                            $('#pagination').smartpaginator({ totalrecords: totalrow, recordsperpage: 10, lenght: 4, datacontainer: 'divs', dataelement: '.new-item-search', initval: 0, next: 'Next', prev: 'Prev', first: 'First', last: 'Last', theme: 'black' });
                        });

                        var prm = Sys.WebForms.PageRequestManager.getInstance();
                        prm.add_initializeRequest(InitializeRequest);
                        prm.add_endRequest(EndRequest);

                        function InitializeRequest(sender, args) {
                        }
                        function EndRequest(sender, args) {
                            // here initialize again your javascript
                            Initialize();
                        }

                        function Initialize() {
                            g_globalObject = new JsDatePick({
                                useMode: 2,
                                target: "txtNgay",
                                dateFormat: "%d-%M-%Y",
                                limitToToday: false
                            });
                        }
                    </script>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div><div class="right-main">
        <uc1:RightContent runat="server" ID="RightContent" />
    </div>
</asp:Content>
