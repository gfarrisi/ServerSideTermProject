<%@ Page Title="" Language="C#" MasterPageFile="~/FoodOrder.Master" AutoEventWireup="true" CodeBehind="ViewRestaurant.aspx.cs" Inherits="TermProject.ViewRestaurant" %>
<%@ Register src="MenuItemControl.ascx" tagname="MenuItemControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <form id="form1" runat="server">
         <!-- Header Section Begin -->
        <header class="header-section listings">
            <div class="container-fluid">
                <div class="logo">
                    <a href="./index.html">
                        <img src="img/logo0.png" alt=""></a>

                </div>
                <nav class="main-menu mobile-menu">
                </nav>
                <div class="header-right">
                    <div class="user-access">
                           <a href="Login.aspx" class="mr-3">Explore Locals</a>    
                          <a href="Login.aspx" class="mr-3">Account Settings</a>                     
                    
                        <a href="Login.aspx"  class="mr-3">Logout <i class="fa fa-sign-out"></i></a>
                          <a href="#" class="primary-btn mr-3">View Cart</a>
                          
                    </div>

                </div>
                <div id="mobile-menu-wrap"></div>
            </div>
        </header>
     <!-- Page Preloder -->
    <div id="preloder">
        <div class="loader"></div>
    </div>

    <!-- Header Section Begin -->
    <!-- Hero Section Begin -->
    <div class="hero-listing set-bg" data-setbg="img/hero_listing.jpg">
    </div>
    <!-- Hero Section End -->

    <!-- About Secton Begin -->
    <section class="about-section">
        <div class="intro-item">
            <div class="container">
                <div class="row">
                    <div class="col-lg-2 offset-lg-1">
                        <div class="intro-share">
                            <div class="share-btn">
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-8">
                        <div class="about-intro">
                            <div class="intro-text">
                                <h2 id="txtRestaurantTitle">Trocadero Restaurant</h2>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-2 offset-lg-1">
                        <div class="intro-share">
                            <div class="share-btn">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="about-item">
            <div class="container">
                <div class="row">
                    <div class="col-lg-8">
                        <div class="about-left">
                            <div class="about-desc contact-info">
                                <h4>Menu</h4>                                               
                                <asp:Repeater ID="repeaterMenu" runat="server">
                                    <ItemTemplate>
                                        <uc1:MenuItemControl ID="MenuItemControl1" runat="server" />
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="about-right">
                            <div class="contact-info">
                                <div class="contact-text">
                                    <h4>Contact Info</h4>
                                    <span id="txtAddress" runat="server">Main Road , No 25/11</span><br />
                                    <ul>
                                        <li><label id="txtCity" runat="server">Philadelphia, </label> <label id="txtState">PA </label> <label id="txtZip" runat="server">19100</label></li>
                                        <li id="txtPhone" runat="server">+1 556-788-3221</li>
                                        <li id="txtEmail">restaurantemail@gmail.com</li> 
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
     </form>
</asp:Content>
