<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Module.aspx.cs" Inherits="Module" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Lựa chọn phân hệ</title>
    <link href="Resources/css/examples.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .body {
            position: fixed;
            width: 100%;
            height: 100%;
            background: url(/images/161020_background.jpg);
            background-size: 100% 100%;
        }

            .body .x-panel-body {
                background: none;
            }

        #main {
            width: 800px;
            margin: 0 auto;
        }

        #head {
            vertical-align: middle;
            width: 800px;
            color: #7BB037;
        }

        div.item-wrap {
            float: left;
            border: 1px solid transparent;
            margin: 5px 25px 5px 25px;
            width: 175px;
            cursor: pointer; /*height: 175px;*/
            text-align: center;
        }

            div.item-wrap img {
                margin: 5px 0px 0px 5px; /*width: 160px;
            height: 160px;*/
                width: auto;
                height: auto;
            }

            div.item-wrap h6 {
                font-size: 14px;
                color: #D7335B;
                font-family: tahoma,arial,san-serif;
                text-transform: uppercase;
            }

        .items-view .x-view-over {
            border: solid 1px silver;
        }

        #items-ct {
            padding: 0px 30px 24px 30px;
        }

            #items-ct h2 {
                border-bottom: 2px solid #3A4B5B;
                cursor: pointer;
            }

            #items-ct .collapsed h2 div {
                background-position: 3px 3px;
            }

            #items-ct dl {
                margin-left: 2px;
            }

            #items-ct .collapsed dl {
                display: none;
            }

        .bgPanel, .bgPanel .x-panel-body {
            background-color: none !important;
        }
    </style>

    <script type="text/javascript">
        var selectionChanged = function (dv, nodes) {
            if (nodes.length > 0) {
                var id = nodes[0].id;
                Ext.
                Ext.Msg.alert("Click", "The node with id='" + id + "' has been clicked");
            }
        }

        var viewClick = function (dv, e) {
            var group = e.getTarget("h2", 3, true);

            if (group) {
                group.up("div").toggleClass("collapsed");
            }
        }
    </script>

</head>
<body>
    <div class="body">
        <form id="Form1" runat="server">
            <ext:ResourceManager ID="ResourceManager1" runat="server" />
            <div id="main">
                <div id="head">
                    <table border="0" width="100%" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <p align="center">
                                    <img border="0" src="images/trangchinh01.png" alt="" />
                                </p>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <ext:Store ID="Store1" runat="server">
                    <Reader>
                        <ext:JsonReader IDProperty="Ma_Du_An">
                            <Fields>
                                <ext:RecordField Name="Ma_Du_An" />
                                <ext:RecordField Name="Ten_Du_An" />
                                <ext:RecordField Name="Icon" />
                            </Fields>
                        </ext:JsonReader>
                    </Reader>
                </ext:Store>
                <ext:Panel ID="DashBoardPanel" runat="server" Cls="items-view" Layout="fit" AutoHeight="true" bodycls="bgPanel"
                    Width="800" Border="false">
                    <Items>
                        <ext:DataView ID="Dashboard" runat="server" StoreID="Store1" SingleSelect="true"
                            OverClass="x-view-over" ItemSelector="div.item-wrap" AutoHeight="true" EmptyText="Không có thông tin để hiển thị">
                            <Template ID="Template1" runat="server">
                                <Html>
                                    <div id="items-ct">
							    <tpl for=".">
								    <div id="{Ma_Du_An}" class="item-wrap">
									    <img src="{Icon}"/>
									    <div>
										    <H6>{Ten_Du_An}</H6>
									    </div>
								    </div>
							    </tpl>
							    <div style="clear:left"></div>
						    </div>
                                </Html>
                            </Template>
                            <DirectEvents>
                                <SelectionChange OnEvent="SelectionChanged">
                                </SelectionChange>
                            </DirectEvents>
                        </ext:DataView>
                    </Items>
                </ext:Panel>
            </div>
        </form>
    </div>
</body>
</html>
