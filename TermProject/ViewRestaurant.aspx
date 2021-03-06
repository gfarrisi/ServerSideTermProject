<%@ Page Title="" Language="C#" MasterPageFile="~/UserView.Master" AutoEventWireup="true" CodeBehind="ViewRestaurant.aspx.cs" Inherits="TermProject.ViewRestaurant" %>
<%@ Register src="MenuItemControl.ascx" tagname="MenuItemControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <!-- Page Preloder -->
    <div id="preloder">
        <div class="loader"></div>
    </div>

         <div class="alert alert-danger" id="warning" runat="server" visible="false">
             <div style="margin-top:10%"></div>
             Error! Please select a restaurant first.
              
         </div>

         <!-- Header Section Begin -->
    <!-- Hero Section Begin -->
    <div id="dvImgRes" class="hero-listing set-bg" data-setbg="img/hero_listing.jpg" runat="server">
    </div>
    <!-- Hero Section End -->

    <!-- About Secton Begin -->
    <section class="about-section" id="abt" runat="server">
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
                                <h2 id="txtRestaurantTitle" runat="server">Trocadero Restaurant</h2>
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
                                        <uc1:MenuItemControl runat="server" />
                                    </ItemTemplate>
                                </asp:Repeater>
                                <div id="divMenu" runat="server">

                                </div>
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
                                        <li><label id="txtCity" runat="server">Philadelphia, </label>, <label id="txtState" runat="server">PA </label> <label id="txtZip" runat="server">19100</label></li>
                                        <li id="txtPhone" runat="server">+1 556-788-3221</li>
                                        <li id="txtEmail" runat="server">restaurantemail@gmail.com</li> 
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
