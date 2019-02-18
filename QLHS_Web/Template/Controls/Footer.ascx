<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Footer.ascx.cs" Inherits="Template_Controls_Footer" %>


<footer class="footer">
    <div class="content">
            <div class="footer-content">
                <div class="footer-center">
                       <%-- <h2>Bản quyền thuộc về Cục quản lý di sản văn hóa Thanh Hóa</h2>
                        <p class="info-footer">
                            Địa chỉ: 101 Nguyễn Trãi - Phường Ba Đình -TP. Thanh Hóa
                    <br />
                            Website : disanvanhoathanhhoa.gov.com * Tel : (034) 6234 345 * Fax: 08.7300.4555 * Email : Disanvanhoa@gmail.com
                        </p>--%>
                    <%=Resources.labels.footer %>

                        <%--                        <div class="col-md-3 col-sm-4 col-xs-12 col-footer">
                            <div class="footer-info">
                                <h3 class="footer-menu-heading">Thông tin liên quan</h3>
                                <p><span class="fa fa-map-marker"></span>Ngõ 110, Nguyễn Khánh Toàn, Cầu Giấy, Hà Nội</p>
                                <p><span class="fa fa-phone"></span>(04) 6674 2332  - <span class="fa fa-tty"></span>(04) 3786 8904</p>
                                <p><span class="fa fa-phone"></span>(08) 6680 9686</p>
                                <p><span class="fa fa-envelope"></span><a href="mailto:contact@tcsoft.vn">contact@tcsoft.vn</a></p>
                            </div>
                        </div>

                        <div class="col-md-3 col-sm-4 col-xs-12 col-footer">
                            <div class="letter-space">
                                <form accept-charset="UTF-8" action="/contact" id="contact" method="post">
                                    <input name="FormType" type="hidden" value="contact">
                                    <input name="utf8" type="hidden" value="true">
                                    <h4 class="footer-menu-heading"><span>Theo dõi bản tin</span></h4>
                                    <h5>Nhận được những thông tin mới nhất từ website</h5>
                                    <input id="name" name="contact[Name]" type="text" value="Guest" class="form-control hidden">
                                    <input type="text" class="form-control hidden" name="contact[phone]" value="NaN" placeholder="Phone number">
                                    <textarea id="message" name="contact[Body]" style="height: 120px;" class="form-control hidden" rows="7">Subcribe Email</textarea>
                                    <div class="input-group" id="mail-box">
                                        <span class="input-group-addon">
                                            <i class="fa fa-envelope"></i>
                                        </span>
                                        <input id="email" class="input_newsletter input-text required-entry validate-email form-control" name="contact[email]" type="email" value="" placeholder="Email nhận tin">
                                        <input type="submit" class="subcribe" value="Đăng ký">
                                    </div>
                                    <!-- /input-group -->


                                </form>
                            </div>
                            <div class="site-footer__social">
                                <h4>Kết nối</h4>
                                <ul class="list-inline social">
                                    <li><a class="fa fa-facebook" href="/">&nbsp;</a></li>
                                    <li><a class="fa fa-twitter" href="/">&nbsp;</a></li>
                                    <li><a class="fa fa-google-plus" href="/">&nbsp;</a></li>
                                    <li><a class="fa fa-pinterest" href="/">&nbsp;</a></li>
                                    <li><a class="fa fa-rss" href="/">&nbsp;</a></li>
                                </ul>
                            </div>
                        </div>--%>
                </div>
            </div>
    </div>
    <%--<div class="footer-bottom">
        <div class="container">
            <div class="row">
                <div class="col-sm-6">
                    <p class="copy-right">© Bản quyền thuộc về Cục quản lý di sản văn hóa Thanh Hóa | Cung cấp bởi <a href="#" title="TCSOFT">TCSOFT</a></p>
                </div>
                <div class="col-sm-6">
                    <img src="./images/payments.png" alt="Maxxshop" class="pull-right payments">
                </div>
            </div>
        </div>
    </div>--%>
</footer>
