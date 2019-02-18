<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/Site.master" CodeFile="DanhSachDiVat.aspx.cs" Inherits="Template_LoaiDiSan" %>

<%@ Register Src="~/Template/Controls/RightContent.ascx" TagPrefix="uc1" TagName="RightContent" %>


<asp:Content runat="server" ContentPlaceHolderID="Navigate">
    <a href="/"><%=Resources.labels.home %></a>
    <span>> </span>
    <a href="#"><%=Resources.labels.divatcovat %></a>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

    <div class="left-main">
        <div class="module">
            <div class="module-title">
                <a href="#" class="TitleCate" title="<%=tenloaids %>">
                    <span><%=tenloaids %></span>
                </a>
            </div>
            <div class="module-content" id="divs">
                <div class="search-box welcome">
                    <div class="haft search-item">
                        <label for="txtSearch"><%=Resources.labels.key %> : </label>
                        <asp:TextBox runat="server" ID="txtTen" ClientIDMode="Static" MaxLength="100" OnTextChanged="btnSubmit_Click" AutoPostBack="true" />
                    </div>

                    <div class="haft search-item">
                        <label for="ddlLoai"><%=Resources.labels.loaidisan %> : </label>
                        <div class="styled-select slate">
                            <asp:DropDownList runat="server" ID="ddlLoai" OnSelectedIndexChanged="btnSubmit_Click" AutoPostBack="true">
                                <asp:ListItem Text='<%$ Resources:labels, chondivat %>' Value="0" />
                                <asp:ListItem Text='<%$ Resources:labels, divat %>' Value="1" />
                                <asp:ListItem Text='<%$ Resources:labels, covat %>' Value="2" />
                                <asp:ListItem Text='<%$ Resources:labels, baovat %>' Value="3" />
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="haft search-item">
                        <label for="ddlDiSan"><%=Resources.labels.khudisan %> : </label>
                        <div class="styled-select slate">
                            <asp:DropDownList runat="server" ID="ddlDiSan" DataValueField="DiSanID" DataTextField="TenDiSan" OnSelectedIndexChanged="btnSubmit_Click" AutoPostBack="true" />
                        </div>
                    </div>
                    <div class="haft search-item">
                        <label for="ddlBaotang"><%=Resources.labels.baotang %> : </label>
                        <div class="styled-select slate">
                            <asp:DropDownList runat="server" ID="ddlBaotang" DataValueField="ID" DataTextField="Ten" OnSelectedIndexChanged="btnSubmit_Click" AutoPostBack="true" />
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <div class="sumbit-btn" style="padding: 10px;">
                        <asp:Button runat="server" ID="btnCancel" OnClick="btnCancel_Click" CssClass="btn-default btn-search" Text='<%$ Resources:labels, bodieukien %>' />
                    </div>
                </div>
                <div class="clearfix"></div>
                <div class="result">
                    <asp:Repeater runat="server" ID="rptDiVat">
                        <ItemTemplate>
                            <div class="image_chitiet_home">
                                <div class="image_chitiet_home_image">
                                    <a href="<%#Eval("url") %>">
                                        <img class="example-image" src="/FileUpload/images/<%#Eval("TenAnh") %>" alt="image-1" /></a>
                                </div>
                                <div class="info">
                                    <p><span class="bold"><%=Resources.labels.tendivat %> : </span><%#Eval("Ten") %> <%#" - "+Eval("TenKhac") %></p>
                                    <p><span class="bold"><%=Resources.labels.noiluutru %> : </span><%#Eval("DiSan") %><%#Eval("BaoTang") %></p>
                                    <p><span class="bold"><%=Resources.labels.loaids %> : </span><%#Eval("TenLoai") %></p>
                                </div>
                            </div>
                            <%--  <div class="new block-cate">
                                <a href="<%#Eval("url") %>">
                                    <img src="/FileUpload/images/<%#Eval("TenAnh") %>" class="img-responsive home-img" style="height: 235px;" />
                                </a>
                               
                            </div>--%>
                            <div class="<%# (Container.ItemIndex+1)%3==0?"clearfix":""%>"></div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div class="clearfix"></div>
                    <div id="pagination"></div>
                </div>
            </div>


            <script type="text/javascript">
                var totalrow = $("#divs .image_chitiet_home").length;
                var size = 15;
                $('#pagination').smartpaginator({ totalrecords: totalrow, recordsperpage: size, lenght: 4, datacontainer: 'divs', dataelement: '.image_chitiet_home', initval: 0, next: 'Next', prev: 'Prev', first: 'First', last: 'Last', theme: 'black' });
            </script>
        </div>
    </div>
    <div class="right-main">
        <uc1:RightContent runat="server" ID="RightContent" />
    </div>
</asp:Content>
