<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RightTree.ascx.cs" Inherits="Template_Controls_RightContent" %>

<style type="text/css" id="treeview-checkable-style">
    .treeview .list-group-item {
        cursor: pointer;
    }

    .treeview span.indent {
        margin-left: 10px;
        margin-right: 10px;
    }

    .treeview span.icon {
        width: 12px;
        margin-right: 5px;
    }

    .treeview .node-disabled {
        color: silver;
        cursor: not-allowed;
    }

    .node-treeview-checkable {
    }

        .node-treeview-checkable:not(.node-disabled):hover {
            background-color: #F5F5F5;
        }

    .treeview .list-group-item {
        cursor: pointer;
    }

    .treeview span.indent {
        margin-left: 10px;
        margin-right: 10px;
    }

    .treeview span.icon {
        width: 12px;
        margin-right: 5px;
    }

    .treeview .node-disabled {
        color: silver;
        cursor: not-allowed;
    }

    .node-treeview-disabled {
    }

        .node-treeview-disabled:not(.node-disabled):hover {
            background-color: #F5F5F5;
        }
</style>
<div class="right-main">
    <div class="border">
        <div class="box">
            <div class="box-heading">
                <h2><%=Resources.labels.category %></h2>
            </div>
            <div class="box-content">
                <div class="nav-category" id="menuright">
                    <div id="treeview-checkable" class=""></div>
                </div>
            </div>
        </div>
    </div>
    <div class="adv-right">
        <asp:Repeater runat="server" ID="rptAdvLink">
            <ItemTemplate>
                <a href="<%#Eval("Link") %>" target="<%#Eval("Target") %>">
                    <img src="/FileUpload/Images/<%#Eval("Image") %>" class="img-responsive" />
                </a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="border">
        <div class="box">
            <div class="box-heading">
                <h2><%=Resources.labels.videoclip %></h2>
            </div>
            <div class="box-content">
                <iframe width="100%" height="100%" src="https://www.youtube.com/embed/JY2Qi1DTzE4" frameborder="0" allowfullscreen></iframe>
            </div>
        </div>
    </div>

    <div class="border">
        <div class="box">
            <div class="box-heading">
                <h2><%=Resources.labels.anphamtailieu %></h2>
            </div>
            <div class="box-content">
                <div class="nav-category">
                    <ul class="anpham">
                        <li>
                            <a href="#"><%=Resources.labels.tapchidisan %></a>
                        </li>
                        <li>
                            <a href="#"><%=Resources.labels.sachbaoxuatban %></a>
                        </li>
                        <li>
                            <a href="#"><%=Resources.labels.detainghiencuu %></a>
                        </li>
                        <li>
                            <a href="#"><%=Resources.labels.tailieuhoctap %></a>
                        </li>
                        <li>
                            <a href="#"><%=Resources.labels.kyyeuhoinghi %></a>
                        </li>
                        <li>
                            <a href="#"><%=Resources.labels.thumuctailieu %></a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>

    <div class="">
        <div class="box">
            <div class="box-heading">
                <h2><%=Resources.labels.Lienket %></h2>
            </div>
            <div class="box-content">
                <asp:Repeater runat="server" ID="rptAdv">
                    <ItemTemplate>
                        <a href="<%#Eval("Link") %>" target="<%#Eval("Target") %>">
                            <img src="/FileUpload/Images/<%#Eval("Image") %>" class="img-responsive" />
                        </a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>

</div>
<script src="/Template/js/bootstrap-treeview.min.js"></script>
<script>
    $(document).ready(function () {
        var defaultData = [];

        $.ajax({
            type: "POST",
            url: "/WebService/Search.asmx/getAddress",
            //data: JSON.stringify(obj),
            async: true,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                defaultData = data.d;
                var $checkableTree = $('#treeview-checkable').treeview({
                    data: defaultData,
                    showIcon: false,
                    showCheckbox: true,
                    //onNodeChecked: function (event, node) {
                    //    $('#checkable-output').prepend('<p>' + node.text + ' was checked</p>');
                    //},
                    //onNodeUnchecked: function (event, node) {
                    //    $('#checkable-output').prepend('<p>' + node.text + ' was unchecked</p>');
                    //}
                });
            },
            error: function (xhr, status, error) {
                $('.error').html(xhr.responseText);
                //alert(xhr.responseText);
            }
        });

    });
        </script>