<%@ Page Title="" Language="C#" MasterPageFile="~/UserLoginMasterPage.Master" AutoEventWireup="true"
    CodeBehind="index.aspx.cs" Inherits="groceryguys.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <style type="text/css">
        .style1 {
            width: 19px;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $('.flexslider').flexslider({
                animation: "slide",
                start: function (slider) {
                    $('body').removeClass('loading');
                }
            });
            $('.selectpicker').selectpicker();           
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div class="slider">
        <div class="container">
            <div class="row">
                <div class="col-md-8">
                    <div class="flexslider">
                        <ul class="slides">
                            <li>
                                <img src="images/banner.png" alt="" />
                                <div class="slider_text">
                                    Over <span>10,000</span><br />
                                    Items Available<br />
                                    <a href="Shop.aspx">
                                        <img src="images/start-shopping.png" alt="" /></a>
                                </div>
                            </li>
                            <li>
                                <img src="images/banner.png" />
                                <div class="slider_text">
                                    Over <span>10,000</span><br />
                                    Items Available<br />
                                    <a href="Shop.aspx">
                                        <img src="images/start-shopping.png" alt="" /></a>
                                </div>
                            </li>
                            <li>
                                <img src="images/banner.png" />
                                <div class="slider_text">
                                    Over <span>10,000</span><br />
                                    Items Available<br />
                                    <a href="Shop.aspx">
                                        <img src="images/start-shopping.png" alt="" /></a>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="boxes bg4">
                        <div class="title">Now Delivering to</div>
                        <div class="row">
                            <div class="col-xs-12 text-center">
                                <select runat="server" class="selectpicker" id="ddlZipCode">
                                </select>
                                <br />
                                <br />
                                <a href="Shop.aspx">
                                    <img src="images/start-shopping-btn.png" alt="Start Shopping" /></a>
                                <p>Don’t see your zip? <a href="Registration.aspx">Click here</a></p>
                                <a href="Registration.aspx">
                                    <img src="images/singnup-now-btn.png" alt="Signup" /></a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="extra-padding">
                    <h1>Welcome to Grocery guys</h1>
                    <p class="text-center">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.</p>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <div class="boxes">
                    <div class="title">Testimonial</div>
                    <div class="row extra-margin">
                        <div class="col-xs-3 text-right">
                            <img src="images/testimonila-1.png" alt="Testimonials" /></div>
                        <div class="col-xs-9">Lorem Ipsum is simply dummy text of the printing and typesetting industry.<div class="t-name">Sarah Sunny</div>
                        </div>
                    </div>
                    <div class="row extra-margin">
                        <div class="col-xs-3 text-right">
                            <img src="images/testimonila-2.png" alt="Testimonials" /></div>
                        <div class="col-xs-9">Lorem Ipsum is simply dummy text of the printing and typesetting industry.<div class="t-name">Micheal Jonny</div>
                        </div>
                    </div>
                    <div class="row extra-margin">
                        <div class="col-xs-3 text-right">
                            <img src="images/testimonila-3.png" alt="Testimonials" /></div>
                        <div class="col-xs-9">Lorem Ipsum is simply dummy text of the printing and typesetting industry.<div class="t-name">Barbi Black</div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="boxes bg2">
                    <div class="title">Weekly Sale Item</div>
                    <div class="row">
                        <div class="col-xs-5 text-right">
                            <img src="images/bag.png" alt="Weekly Sale Item" /></div>
                        <div class="col-xs-7">
                            <div class="price">$ 98.99</div>
                            <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry.</p>
                            <a href="" class="readmore">read more >></a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="boxes bg3">
                    <div class="title">Place your 1st order Now</div>
                    <div class="col-xs-7">
                        <div class="box3text">
                            And get <span class="price">5$</span><br />
                            in <span class="price">Free</span><br />
                            <span class="text">Groceries</span>
                            <a href="">
                                <img src="images/join-btn.png" alt="Join" /></a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
