<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/Site.master" CodeFile="LoaiDiSan.aspx.cs" Inherits="Template_LoaiDiSan" %>

<%@ Register Src="~/Template/Controls/RightContent.ascx" TagPrefix="uc1" TagName="RightContent" %>


<asp:Content runat="server" ContentPlaceHolderID="Navigate">
    <a href="/"><%=Resources.labels.home %></a>
    <span>> </span>
    <a href="#"><%=Resources.labels.dsvh %></a>
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
                <asp:Repeater runat="server" ID="rptDiSan">
                    <ItemTemplate>
                        <div class="new block-cate">
                            <a href="<%#Eval("url") %>">
                                <img src="/FileUpload/images/<%#Eval("AnhDaiDienDS") %>" class="img-responsive home-img" style="height: 235px;" />
                            </a>
                            <div class="info">
                                <p><span class="bold"><%=Resources.labels.tendisan %> : </span><%#Eval("TenDiSan") %></p>
                                <p><span class="bold"><%=Resources.labels.city %> : </span><%#Eval("DiaDiem") %></p>
                                <p><span class="bold"><%=Resources.labels.loaidisan %> : </span><%#Eval("LoaiDiSan") %></p>
                            </div>
                        </div>
                        <div class="<%# (Container.ItemIndex+1)%2==0?"clearfix":""%>"></div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="clearfix"></div>
                <div id="pagination"></div>
            </div>


            <script type="text/javascript">
                $(document).ready(function () {
                    var totalrow = $("#divs .new").length;
                    var size = 10;
                    if (size > 10) size = 10;
                    $('#pagination').smartpaginator({ totalrecords: totalrow, recordsperpage: size, lenght: 4, datacontainer: 'divs', dataelement: '.new', initval: 0, next: 'Next', prev: 'Prev', first: 'First', last: 'Last', theme: 'black' });
                });
            </script>
        </div>
    </div><div class="right-main">
        <uc1:RightContent runat="server" ID="RightContent" />
    </div>
</asp:Content>
