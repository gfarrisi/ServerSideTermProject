<%@ Page Title="" Language="C#" MasterPageFile="~/FoodOrder.Master" AutoEventWireup="true" CodeBehind="RestaurantRegistration.aspx.cs" Inherits="TermProject.RestaurantRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Restaurant Registration</title>
    <style>
        h1, h2, h3, h4, h5, h6 {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" class="contact-form" runat="server">

        <!-- Page Preloder -->
        <div id="preloder">
            <div class="loader"></div>
        </div>

        <!-- Header Section Begin -->
        <header class="header-section listings">
            <div class="container-fluid">
                <div class="logo">
                    <a href="Default.aspx">
                        <img src="img/logo0.png" alt=""></a>

                </div>
                <nav class="main-menu mobile-menu">
                </nav>
                <div class="header-right">
                    <div class="user-access">
                        <a href="Default.aspx">Register/Login</a>

                    </div>

                </div>
                <div id="mobile-menu-wrap"></div>
            </div>
        </header>


        <section class="contact-section" style="padding-bottom: 0px;" id="secError" runat="server" visible="false">
            <div style="background-color: crimson;">
                <h2 style="color: white;">Error...</h2>
                <br />
                <h5 style="color: white;">Something went wrong while creating your account. Did you forget a form? Is your representative account already in use?</h5>
                <br />
            </div>
        </section>

        <!-- Content Section Begin -->
        <section class="contact-section spad" id="secContent" runat="server" visible="true">
            <h3 class="pt-5 pb-4">Register your Restaurant</h3>
            <br />

            <div class="container">
                <div class="row">
                    <div class="col-lg-2"></div>
                    <div class="col-lg-8 pb-3">
                        <h5 style="text-align: left; color: #FF5581;">Restaurant Info</h5>
                        <span style="text-align: left;">These are the details that customers will see when interacting with your restaurant.</span>
                        <br />
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-2"></div>
                    <div class="col-lg-8">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Restaurant Name:</label><asp:TextBox CssClass="contact-form-input" ID="txtResName" placeholder="Restaurant Name" runat="server" required></asp:TextBox>
                            </div>
                            <div class="col-lg-6">
                                <label>Restaurant Category</label>
                                <asp:TextBox CssClass="contact-form-input" ID="txtResCategory" placeholder="Italian, diner, etc" runat="server" required></asp:TextBox>
                            </div>
                            <div class="col-lg-12">
                                <label>Restaurant Graphic (URL Format)</label>
                                <asp:TextBox CssClass="contact-form-input" ID="txtResImg" placeholder="Image URL" runat="server" required></asp:TextBox>
                            </div>

                            <div class="col-lg-6">
                                <label>Contact Phone:</label><asp:TextBox CssClass="contact-form-input" ID="txtResPhone" placeholder="Phone" runat="server" required></asp:TextBox>
                            </div>
                            <div class="col-lg-6">
                                <label>Contact Email:</label><asp:TextBox CssClass="contact-form-input" ID="txtResEmail" placeholder="Email" runat="server" required></asp:TextBox>
                            </div>
                            <div class="col-lg-12">
                                <label>Restaurant Address:</label><asp:TextBox CssClass="contact-form-input" ID="txtResAddr" placeholder="Address" runat="server" required></asp:TextBox>
                            </div>
                            <div class="col-lg-4">
                                <label>City</label><asp:TextBox CssClass="contact-form-input" ID="txtResCity" placeholder="City" runat="server" required></asp:TextBox>
                            </div>
                            <div class="col-lg-4">
                                <label>State</label>
                                <br />
                                <asp:DropDownList CssClass="nice-select" Style="height: 58px; width: 100%;" ID="ddlResState" runat="server" required>
                                    <asp:ListItem Value="Not Specified" Selected="True" disabled="disabled">Select a State</asp:ListItem>
                                    <asp:ListItem Value="AL">Alabama</asp:ListItem>
                                    <asp:ListItem Value="AK">Alaska</asp:ListItem>
                                    <asp:ListItem Value="AZ">Arizona</asp:ListItem>
                                    <asp:ListItem Value="AR">Arkansas</asp:ListItem>
                                    <asp:ListItem Value="CA">California</asp:ListItem>
                                    <asp:ListItem Value="CO">Colorado</asp:ListItem>
                                    <asp:ListItem Value="CT">Connecticut</asp:ListItem>
                                    <asp:ListItem Value="DC">District of Columbia</asp:ListItem>
                                    <asp:ListItem Value="DE">Delaware</asp:ListItem>
                                    <asp:ListItem Value="FL">Florida</asp:ListItem>
                                    <asp:ListItem Value="GA">Georgia</asp:ListItem>
                                    <asp:ListItem Value="HI">Hawaii</asp:ListItem>
                                    <asp:ListItem Value="ID">Idaho</asp:ListItem>
                                    <asp:ListItem Value="IL">Illinois</asp:ListItem>
                                    <asp:ListItem Value="IN">Indiana</asp:ListItem>
                                    <asp:ListItem Value="IA">Iowa</asp:ListItem>
                                    <asp:ListItem Value="KS">Kansas</asp:ListItem>
                                    <asp:ListItem Value="KY">Kentucky</asp:ListItem>
                                    <asp:ListItem Value="LA">Louisiana</asp:ListItem>
                                    <asp:ListItem Value="ME">Maine</asp:ListItem>
                                    <asp:ListItem Value="MD">Maryland</asp:ListItem>
                                    <asp:ListItem Value="MA">Massachusetts</asp:ListItem>
                                    <asp:ListItem Value="MI">Michigan</asp:ListItem>
                                    <asp:ListItem Value="MN">Minnesota</asp:ListItem>
                                    <asp:ListItem Value="MS">Mississippi</asp:ListItem>
                                    <asp:ListItem Value="MO">Missouri</asp:ListItem>
                                    <asp:ListItem Value="MT">Montana</asp:ListItem>
                                    <asp:ListItem Value="NE">Nebraska</asp:ListItem>
                                    <asp:ListItem Value="NV">Nevada</asp:ListItem>
                                    <asp:ListItem Value="NH">New Hampshire</asp:ListItem>
                                    <asp:ListItem Value="NJ">New Jersey</asp:ListItem>
                                    <asp:ListItem Value="NM">New Mexico</asp:ListItem>
                                    <asp:ListItem Value="NY">New York</asp:ListItem>
                                    <asp:ListItem Value="NC">North Carolina</asp:ListItem>
                                    <asp:ListItem Value="ND">North Dakota</asp:ListItem>
                                    <asp:ListItem Value="OH">Ohio</asp:ListItem>
                                    <asp:ListItem Value="OK">Oklahoma</asp:ListItem>
                                    <asp:ListItem Value="OR">Oregon</asp:ListItem>
                                    <asp:ListItem Value="PA">Pennsylvania</asp:ListItem>
                                    <asp:ListItem Value="RI">Rhode Island</asp:ListItem>
                                    <asp:ListItem Value="SC">South Carolina</asp:ListItem>
                                    <asp:ListItem Value="SD">South Dakota</asp:ListItem>
                                    <asp:ListItem Value="TN">Tennessee</asp:ListItem>
                                    <asp:ListItem Value="TX">Texas</asp:ListItem>
                                    <asp:ListItem Value="UT">Utah</asp:ListItem>
                                    <asp:ListItem Value="VT">Vermont</asp:ListItem>
                                    <asp:ListItem Value="VA">Virginia</asp:ListItem>
                                    <asp:ListItem Value="WA">Washington</asp:ListItem>
                                    <asp:ListItem Value="WV">West Virginia</asp:ListItem>
                                    <asp:ListItem Value="WI">Wisconsin</asp:ListItem>
                                    <asp:ListItem Value="WY">Wyoming</asp:ListItem>
                                    <asp:ListItem Value="OTHER">Other US territory</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-4">
                                <label>ZIP</label><asp:TextBox CssClass="contact-form-input" ID="txtResZip" placeholder="5-number ZIP code" runat="server" required></asp:TextBox>
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <%--  <div class="col-lg-2"></div>--%>
                            <div class="col-lg-12 pb-3">
                                <h5 style="text-align: left; color: #FF5581;">Representative Account Info</h5>
                                <span style="text-align: left;">These are the account credentials you will use when logging in to manage the restaurant.</span>
                                <br />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-6 mt-10">
                                <label>First Name:</label>
                                <asp:TextBox CssClass="contact-form-input" ID="txtFirstName" runat="server" placeholder="First Name" required="true"></asp:TextBox>

                            </div>
                            <div class="col-lg-6 mt-10">
                                <label>Last Name:</label>
                                <asp:TextBox CssClass="contact-form-input" ID="txtLastName" runat="server" placeholder="Last Name" required="true"></asp:TextBox>
                            </div>
                        </div>

                        <div class="mt-10">
                            <label>Representative Email:</label>
                            <asp:TextBox CssClass="contact-form-input" ID="txtEmail" runat="server" placeholder="Email Address" required="true"></asp:TextBox>

                        </div>
                        <div class="mt-10">
                            <label>Password:</label>
                            <asp:TextBox CssClass="contact-form-input" ID="txtPassword" TextMode="Password" runat="server" placeholder="Password" required="true"></asp:TextBox>

                        </div>
                        <div class="mt-10">
                            <label>Backup Email (For account recovery):</label>
                            <asp:TextBox CssClass="contact-form-input" ID="txtContactEmail" runat="server" placeholder="Backup Email Address" required="true"></asp:TextBox>
                        </div>
                       
                        <hr />
                        <div class="row">
                            <%--  <div class="col-lg-2"></div>--%>
                            <div class="col-lg-12 pb-3">
                                <h5 style="text-align: left; color: #FF5581;">Payment Account Info</h5>
                                <span style="text-align: left;">This is the payment accoutn info that will be used to process payments for your restaurant.</span>
                                <br />
                            </div>
                        </div>
                       
                        <div class="mt-10">
                            <label>Name on Payment Account:</label>
                            <asp:TextBox CssClass="contact-form-input" ID="txtAccountName" runat="server" placeholder="Account Name" required="true"></asp:TextBox>

                        </div>
                        <div class="mt-10">
                            <label>Payment Account Type:</label>
                            <asp:TextBox CssClass="contact-form-input" ID="txtAccountType" runat="server" placeholder="Account Type" required="true"></asp:TextBox>

                        </div>
                        <div class="mt-10">
                            <label>Payment Account Number:</label>
                            <asp:TextBox CssClass="contact-form-input" ID="txtAccountNumber" runat="server" placeholder="Account Number" required="true"></asp:TextBox>
                        </div>
                        <div class="row text-center">
                            <div class="col-lg-12">
                                <hr />
                                <p style="text-align: center;">Upon submitting this form, your user account will automatically be set as the representative of this restauraunt.</p>
                            </div>
                            <div class="col-lg-3">
                            </div>
                            <div class="col-lg-6">
                                <asp:Button ID="Button1" CssClass="contact-form-button" Text="Register Restaurant" OnClick="btnRegister_Click" runat="server" />
                            </div>
                        </div>
                    </div>
                    </div>

                </div>
        </section>
        <section id="secSuccess" class="contact-section spad" runat="server" visible="false">
            <div style="background-color: mediumseagreen;">
                <h2 style="color: white;">Success!</h2>
                <br />
                <h5 style="color: white;">Your account has now been created. Please <a style="color: aliceblue; text-decoration: underline" href="Login.aspx">log in</a> to manage your restaurant.</h5>
                <br />
            </div>
        </section>
    </form>
</asp:Content>
