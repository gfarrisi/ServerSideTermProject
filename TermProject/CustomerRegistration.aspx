<%@ Page Title="" Language="C#" MasterPageFile="~/FoodOrder.Master" AutoEventWireup="true" CodeBehind="CustomerRegistration.aspx.cs" Inherits="TermProject.CustomerRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">

        <!-- Page Preloder -->
        <div id="preloder">
            <div class="loader"></div>
        </div>

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
                        <a href="#">Register/</a>
                        <a href="#">Login</a>
                    </div>

                </div>
                <div id="mobile-menu-wrap"></div>
            </div>
        </header>
        <div class="row">
            <div class="col-lg-4 col-md-4 mt-5">
            </div>
            <div class="col-lg-4 col-md-8 mt-5">
                <br />
                <h3 class="pb-5 mt-5 p-4" align="center">Customer Sign Up</h3>
                <div class="row">
                    <div class="col-lg-6 mt-10">
                        <asp:TextBox CssClass="contact-form-input" ID="txtFirstName" runat="server" placeholder="First Name" required="true"></asp:TextBox>

                    </div>
                    <div class="col-lg-6 mt-10">
                        <asp:TextBox CssClass="contact-form-input" ID="txtLastName" runat="server" placeholder="Last Name" required="true"></asp:TextBox>

                    </div>
                </div>

                <div class="mt-10">
                    <asp:TextBox CssClass="contact-form-input" ID="txtEmail" runat="server" placeholder="Email Address" required="true"></asp:TextBox>

                </div>
                <div class="mt-10">
                    <asp:TextBox CssClass="contact-form-input" ID="txtPassword" runat="server" placeholder="Password" required="true"></asp:TextBox>

                </div>
                 <div class="mt-10">
                    <asp:TextBox CssClass="contact-form-input" ID="txtContactEmail" runat="server" placeholder="Contact Email Address" required="true"></asp:TextBox>

                </div>
                <asp:Label ID="Label2" runat="server" Text="Delivery Info"></asp:Label>
                <div class="mt-10">
                    <asp:TextBox CssClass="contact-form-input" ID="txtDeliveryAddress" runat="server" placeholder="Delivery Address" required="true"></asp:TextBox>

                </div>
                <div class="row mt-2">
                    <div class="col-lg-4 mt-10">
                        <asp:TextBox CssClass="contact-form-input" ID="txtDeliveryCity" runat="server" placeholder="Delivery City" required="true"></asp:TextBox>

                    </div>
                    <div class="col-lg-4 mt-10">
                        <asp:TextBox CssClass="contact-form-input" ID="txtDeliveryState" runat="server" placeholder="Delivery State" required="true"></asp:TextBox>

                    </div>
                    <div class="col-lg-4 mt-10">
                        <asp:TextBox CssClass="contact-form-input" ID="txtDeliveryZip" runat="server" placeholder="Delivery Zip" required="true"></asp:TextBox>

                    </div>
                </div>
                <div class="mb-2">
                    <asp:Label ID="lblBiliingInfo" runat="server" Text="Billing Info" CssClass="mb-5"></asp:Label><br />
                </div>
                <asp:CheckBox ID="CheckBox1" runat="server" />
                <asp:Label ID="Label1" runat="server" Text="Same as delivery" CssClass="mb-5"></asp:Label><br />

                <div class="mt-10">
                    <asp:TextBox CssClass="contact-form-input" ID="TextBox1" runat="server" placeholder="Billing Address" required="true"></asp:TextBox>

                </div>
                <div class="row">
                    <div class="col-lg-4 mt-10">
                        <asp:TextBox CssClass="contact-form-input" ID="TextBox2" runat="server" placeholder="Billing City" required="true"></asp:TextBox>

                    </div>
                    <div class="col-lg-4 mt-10">
                        <asp:TextBox CssClass="contact-form-input" ID="TextBox3" runat="server" placeholder="Billing State" required="true"></asp:TextBox>

                    </div>
                    <div class="col-lg-4 mt-10">
                        <asp:TextBox CssClass="contact-form-input" ID="TextBox4" runat="server" placeholder="Billing Zip" required="true"></asp:TextBox>

                    </div>
                </div>
                <div class="col-lg-12 text-center">
                    <div class="mb-1">
                        <asp:Button ID="Button2" runat="server" Text="Log In" CssClass="contact-form-button" />
                    </div>
                </div>


            </div>

        </div>

    </form>

</asp:Content>
