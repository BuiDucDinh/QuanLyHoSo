<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RightContent.ascx.cs" Inherits="Template_Controls_RightContent" %>

<asp:Repeater runat="server" ID="rptVideo">
    <ItemTemplate>
        <div class="border">
            <div class="box">
                <div class="box-heading">
                    <a href="<%#Eval("Link") %>">
                        <h2><%=Resources.labels.videolienquan %></h2>
                    </a>
                </div>
                <div class="box-content ">
                    <video width="100%" controls poster="/FileUpload/Images/<%#Eval("HinhAnh") %>">
                        <source src="<%#"http://"+HttpContext.Current.Request.Url.Host +"/FileUpload/Video/"+Eval("Video") %>" type="video/mp4">
                        <source src="<%#"http://"+HttpContext.Current.Request.Url.Host +"/FileUpload/Video/"+Eval("Video") %>" type="video/ogg">
                        Your browser does not support HTML5 video.
                    </video>
                    <div class="cleafix"></div>
                </div>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>

<asp:Repeater runat="server" ID="rptImageLib">
    <ItemTemplate>
        <div class="border">
            <div class="box">
                <div class="box-heading">
                    <a href="<%#Eval("Url") %>">
                        <h2><%=Resources.labels.dsthuvienanhlienquan %></h2>
                    </a>
                </div>
                <div class="box-content ">
                    <img src="/FileUpload/Images/<%#Eval("HinhAnh") %>" />
                    <a href="<%#Eval("Url") %>"><%#Eval("TenMediaLib") %></a>
                    <div class="cleafix"></div>
                </div>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>

<div class="border">
    <div class="box">
        <div class="box-heading">
            <h2><%=Resources.labels.account %></h2>
        </div>
        <div class="box-content ">
            <div class="login-form">
                <label for="txtSearch" class="login-label"><%=Resources.labels.account %> : </label>
                <asp:TextBox runat="server" ID="txtTen" ClientIDMode="Static" MaxLength="100" />
            </div>
            <div class="login-form">
                <label for="txtSearch" class="login-label"><%=Resources.labels.password %> : </label>
                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" ClientIDMode="Static" MaxLength="100" />
            </div>
            <asp:Literal runat="server" ID="ltrThongbao" />
            <div class="login-form sumbit-btn btnlogin">
                <asp:Button runat="server" ID="btnLogin" Text='<%$ Resources:labels, login %>' OnClick="btnLogin_Click" CssClass=" btn-default" />
            </div>
            <div class="cleafix"></div>
        </div>
    </div>
</div>
<div class="border hidden">
    <div class="box">
        <div>
            <%--                <a href="hoatdongbotruong.aspx?idcm=389">
                    <img alt="Hoạt động của Bộ Trưởng" src="http://www.mpi.gov.vn/img/logobt.png" class="myTopBanner"></a>--%>
            <div class="box-heading">
                <%--myheaderbox2 --%>
                <div>
                    <h2><%=Resources.labels.alert %></h2>
                </div>
            </div>
            <div class="mycontentbox2">
                <marquee onmouseover="this.stop()" onmouseout="this.start()" scrollamount="1" scrolldelay="75" direction="up" height="190" behavior="Scroll">
                        <ul>
                            <asp:Repeater runat="server" ID="rptTintuc">
                                <ItemTemplate>
                                    <li>
                                        <a href="<%#Eval("url") %>"><%#Eval("TieuDe") %>
                                            <span class="mytime"> (<%# DataBinder.Eval(Container.DataItem, "NgayXuatBan", "{0:d/M/yyyy}") %>)</span></a>
                                     </li>                            
                            </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </marquee>
            </div>

        </div>
    </div>
</div>
<div class="border hidden">
    <div class="box">
        <div class="box-heading">
            <h2><%=Resources.labels.category %></h2>
        </div>
        <div class="box-content disan">
            <div class="nav-category" id="menuright">
                <ul class="ul-danhmuc">
                    <asp:Repeater runat="server" ID="rptDanhmuc">
                        <ItemTemplate>
                            <li class="clearfix">
                                <%--                                    <img src="/uploads/Images/<%#Eval("HinhAnh") %>" class="bg-listitem" />--%>
                                <a href="<%#Eval("url") %>"><%# Eval("TenDanhMuc") %></a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>

                </ul>
            </div>
        </div>
    </div>
</div>
<div class="border">
    <div class="box">
        <div class="box-heading">
            <h2><%=Resources.labels.danhmucdisan %></h2>
        </div>
        <div class="box-content disan">
            <div class="nav-category">
                <ul class="ul-danhmuc">
                    <asp:Repeater runat="server" ID="rptLoaiDS">
                        <ItemTemplate>
                            <li class="clearfix">
                                <%--                                    <img src="/uploads/Images/<%#Eval("HinhAnh") %>" class="bg-listitem" />--%>
                                <a href="<%#Eval("url") +"-lds"%>"><%#GetLang()=="vi"? Eval("TenLoai") : Eval("EngName")%></a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>

                </ul>
            </div>
        </div>
    </div>
</div>


<asp:Repeater runat="server" ID="rptVideoAdv">
    <HeaderTemplate>
        <div class="border">
            <div class="box">
                <div class="box-heading">
                    <h2><%=Resources.labels.videoclip %></h2>
                </div>
    </HeaderTemplate>
    <ItemTemplate>
        <div class="box-content">
            <%#Eval("Description") %>
            <%--<iframe width="100%" height="100%" src="https://www.youtube.com/embed/ADeEspydZWQ" frameborder="0" allowfullscreen></iframe>--%>
        </div>
    </ItemTemplate>
    <FooterTemplate>
        </div>
    </div>       
    </FooterTemplate>
</asp:Repeater>

<asp:Repeater runat="server" ID="rptAnPham">
    <HeaderTemplate>
        <div class="border">
            <div class="box">
                <div class="box-heading">
                    <h2><%=Resources.labels.anphamtailieu %></h2>
                </div>
                <div class="box-content anpham">
                    <div class="nav-category">
                        <ul class="anpham">
    </HeaderTemplate>
    <ItemTemplate>
        <li>
            <a href="<%#Eval("url") %>"><%# GetLang()=="vi"? Eval("TenDanhMuc"): Eval("EngName") %></a>
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
                </div>
            </div>
        </div>
    </div>
    </FooterTemplate>
</asp:Repeater>
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
            <%-- <a href="#">
                    <img src="/Template/images/LienKet/Lk2.png" class="img-responsive" />
                </a>
                <a href="#">
                    <img src="/Template/images/LienKet/Lk3.png" class="img-responsive" />
                </a>
                <a href="#">
                    <img src="/Template/images/LienKet/Lk4.png" class="img-responsive" />
                </a>--%>
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
<script type="text/javascript">

    function clickButton(e, buttonid) {
        var evt = e ? e : window.event;
        var bt = document.getElementById(buttonid);

        if (bt) {
            if (evt.keyCode == 13) {
                bt.click();
                return false;
            }
        }
    }
</script>
