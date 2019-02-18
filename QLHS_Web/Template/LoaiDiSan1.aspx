<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/Site.master" CodeFile="LoaiDiSan1.aspx.cs" Inherits="Template_LoaiDiSan" %>

<%@ Register Src="~/Template/Controls/RightContent.ascx" TagPrefix="uc1" TagName="RightContent" %>


<asp:Content runat="server" ContentPlaceHolderID="Navigate">
    <a href="/"><%=Resources.labels.home %></a>
    <span>> </span>
    <a href="#"><%=Resources.labels.dsvh %></a>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="left-main">
                <div class="module">
                    <div class="module-title">
                        <a href="#" class="TitleCate" title="<%=loaids.TenLoai %>">
                            <span><%=tenloaids %></span>
                        </a>
                    </div>
                    <div class="module-content" style="padding: 0">

                        <div class="search-box welcome">
                            <div class="haft search-item">
                                <label for="txtSearch"><%=Resources.labels.key %> : </label>
                                <asp:TextBox runat="server" ID="txtTen" ClientIDMode="Static" MaxLength="100" OnTextChanged="btnSubmit_Click" AutoPostBack="true" />
                            </div>

                            <div class="haft search-item">
                                <label for="ddlLoai"><%=Resources.labels.loaidisan %> : </label>
                                <div class="styled-select slate">
                                    <asp:DropDownList runat="server" ID="ddlLoai" DataValueField="LoaiID" DataTextField="TenLoai" OnSelectedIndexChanged="btnSubmit_Click" AutoPostBack="true" />
                                </div>
                            </div>
                            <div class="haft search-item">
                                <label for="ddlCap"><%=Resources.labels.capdisan %> : </label>
                                <div class="styled-select slate">
                                    <asp:DropDownList runat="server" ID="ddlCap" DataValueField="ID" DataTextField="TenCap" OnSelectedIndexChanged="btnSubmit_Click" AutoPostBack="true" />
                                </div>
                            </div>
                            <%-- <div class="haft search-item">
                                <label for="dtFrom">Từ ngày : </label>
                                <asp:TextBox runat="server" ID="txtTuNgay" ClientIDMode="Static" MaxLength="70" OnTextChanged="btnSubmit_Click" AutoPostBack="true" />
                            </div>
                            <div class="haft search-item">
                                <label for="dtTo">Đến ngày : </label>
                                <asp:TextBox runat="server" ID="txtDenNgay" ClientIDMode="Static" MaxLength="70" OnTextChanged="btnSubmit_Click" AutoPostBack="true" />
                            </div>--%>
                            <div class="clearfix"></div>
                            <div class="sumbit-btn">
                                <%--                                <asp:Button runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" CssClass="btn-default btn-search" Text="Tìm kiếm" />--%>
                                <asp:Button runat="server" ID="btnCancel" OnClick="btnCancel_Click" CssClass="btn-default btn-search" Text='<%$ Resources:labels, bodieukien %>' />
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="result">
                            <div class="table-responsive">
                                <table class="table table-striped table-bordered table-hover" id="dataTables-result">
                                    <thead>
                                        <tr>
                                            <th><%=Resources.labels.stt %>
                                            </th>
                                            <th> <%=Resources.labels.year %>
                                            </th>
                                            <th><%=Resources.labels.tendisan %>
                                            </th>
                                            <th><%=Resources.labels.vitridialy %>
                                            </th>
                                            <th><%=Resources.labels.loaidisan %>
                                            </th>
                                            <th><%=Resources.labels.capdisan %>
                                            </th>
                                            <th><%=Resources.labels.details %></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater runat="server" ID="rptDiSan">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Container.ItemIndex + 1 %>
                                                    </td>
                                                    <td><%#Eval("Nam") %>
                                                    </td>
                                                    <td><%#Eval("TenDiSan") %>
                                                    </td>
                                                    <td><%#Eval("DiaDiem") %>
                                                    </td>
                                                    <td class="center"><%#Eval("TenLoaiDiSan") %>
                                                    </td>
                                                    <td class="center"><%#Eval("TenCapDiSan") %>
                                                    </td>
                                                    <td><a href="<%#Eval("url") %>" target="_blank"><%=Resources.labels.details %></a></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
            <div class="right-main">
                <div class="border">
                    <div class="box">
                        <div class="box-heading">
                            <h2><%=Resources.labels.diadiem %></h2>
                        </div>
                        <div class="box-content">
                            <div class="nav-category" id="menuright">
                                <div class="search-item">
                                    <div class="styled-select slate">
                                        <asp:DropDownList runat="server" ID="ddlTinh" DataValueField="Ma_Tinh" DataTextField="Ten_Tinh" OnSelectedIndexChanged="ddlTinh_SelectedIndexChanged" AutoPostBack="true" />
                                    </div>
                                </div>
                                <div class="search-item">
                                    <div class="styled-select slate">
                                        <asp:DropDownList runat="server" ID="ddlHuyen" DataValueField="Ma_Huyen" DataTextField="Ten_Huyen" OnSelectedIndexChanged="ddlHuyen_SelectedIndexChanged" AutoPostBack="true" />
                                    </div>
                                </div>
                                <div class="search-item">
                                    <div class="styled-select slate">
                                        <asp:DropDownList runat="server" ID="ddlXa" DataValueField="Ma_Xa" DataTextField="Ten_Xa" OnSelectedIndexChanged="btnSubmit_Click" AutoPostBack="true" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <uc1:RightContent runat="server" ID="RightContent" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <link href="/Template/css/jsDatePick_ltr.min.css" rel="stylesheet" />
    <script src="/Template/js/jsDatePick.jquery.min.1.3.js"></script>


    <link href="/Template/css/dataTables.bootstrap.css" rel="stylesheet" />
    <script src="/Template/js/bootstrap.min.js"></script>
    <script src="/Template/js/modernizr-2.6.2-respond-1.1.0.min.js"></script>

    <script src="/Template/js/jquery.dataTables.js"></script>
    <script src="/Template/js/dataTables.bootstrap.js"></script>

    <script type="text/javascript">
        //var prm = Sys.WebForms.PageRequestManager.getInstance();
        //prm.add_initializeRequest(InitializeRequest);
        //prm.add_endRequest(EndRequest);

        //function InitializeRequest(sender, args) {
        //}

        //function EndRequest(sender, args) {
        //    // here initialize again your javascript
        //    Initialize();
        //}

        $(document).ready(function () {
            Initialize();
        });
        function Initialize() {
            //g_globalObject = new JsDatePick({
            //    useMode: 2,
            //    target: "txtTuNgay",
            //    dateFormat: "%d-%M-%Y",
            //    limitToToday: true
            //});

            //g_globalObject2 = new JsDatePick({
            //    useMode: 2,
            //    target: "txtDenNgay",
            //    dateFormat: "%d-%M-%Y",
            //    limitToToday: true

            //});

            $('#dataTables-result').dataTable({
                "bFilter": false,
                "lengthMenu": [[ 25, 50, -1], [25, 50, "All"]],
                "sPaginationType": "full_numbers",
                //"bJQueryUI": true,
                "bAutoWidth": false // Disable the auto width calculation
                //"aoColumns": [
                //  { "sWidth": "3%" }, // 1st column width
                //  { "sWidth": "5%" }, // 2nd column width
                //  { "sWidth": "20%" }, // 3rd column width and so on
                //  { "sWidth": "18%" },
                //{ "sWidth": "15%" },
                //{ "sWidth": "17%" },
                //{ "sWidth": "14%" }
                //]
            });
        }
    </script>
</asp:Content>
