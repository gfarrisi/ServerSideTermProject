<%@ Page Title="" Language="C#" MasterPageFile="~/FoodOrder.Master" AutoEventWireup="true" CodeBehind="CustomerRegistration.aspx.cs" Inherits="TermProject.CustomerRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">

        <%-- <!-- Page Preloder -->
        <div id="preloder">
            <div class="loader"></div>
        </div>--%>

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
        <div class="row">
            <div class="col-lg-4 col-md-4 mt-5">
            </div>
            <div class="col-lg-4 col-md-8 mt-5">
                <br />
                <h3 class="pb-5 mt-5 p-4" align="center">Customer Sign Up</h3>
                <div class="mb-2">
                    <asp:Label ID="lbContactInfo" runat="server" Text="Contact Info" CssClass="mb-5"></asp:Label>

                </div>

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
                    <asp:TextBox CssClass="contact-form-input" ID="txtPassword" TextMode="Password" runat="server" placeholder="Password" required="true"></asp:TextBox>

                </div>
                <div class="mt-10">
                    <asp:TextBox CssClass="contact-form-input" ID="txtContactEmail" runat="server" placeholder="Backup Email (For account recovery):" required="true"></asp:TextBox>

                </div>
                <div class="mb-2">
                    <asp:Label ID="lblDeliveryInfo" runat="server" Text="Delivery Address" CssClass="mb-5"></asp:Label>
                </div>
                <div class="mt-10">
                    <asp:TextBox CssClass="contact-form-input" ID="txtDeliveryAddress" runat="server" placeholder="Delivery Address" required="true"></asp:TextBox>

                </div>
                <div class="row mt-2">
                    <div class="col-lg-4 mt-10">
                        <asp:TextBox CssClass="contact-form-input" ID="txtDeliveryCity" runat="server" placeholder="Delivery City" required="true"></asp:TextBox>

                    </div>
                    <div class="col-lg-4 mt-10">
                        <asp:DropDownList CssClass="nice-select" Style="height: 58px; width: 100%;" ID="ddDeliveryState" runat="server" required>
                            <asp:ListItem Value="Not Specified" Selected="True" disabled="disabled">Deliver State</asp:ListItem>
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
                    <div class="col-lg-4 mt-10">
                        <asp:TextBox CssClass="contact-form-input" ID="txtDeliveryZip" runat="server" placeholder="Delivery Zip" required="true"></asp:TextBox>

                    </div>
                </div>
                <div class="mb-2">
                    <asp:Label ID="lblBiliingInfo" runat="server" Text="Billing Address" CssClass="mb-5"></asp:Label><br />
                </div>
                <div class="mb-2">
                    <asp:CheckBox ID="chkSameAsDelivery" runat="server" AutoPostBack="True" OnCheckedChanged="chkSameAsDelivery_CheckedChanged" />
                    <asp:Label ID="Label1" runat="server" Text="Same as delivery" CssClass="mb-5"></asp:Label><br />
                </div>

                <div class="mt-10">
                    <asp:TextBox CssClass="contact-form-input" ID="txtBillingAddress" runat="server" placeholder="Billing Address" required="true"></asp:TextBox>

                </div>
                <div class="row">
                    <div class="col-lg-4 mt-10">
                        <asp:TextBox CssClass="contact-form-input" ID="txtBillingCity" runat="server" placeholder="Billing City" required="true"></asp:TextBox>

                    </div>
                    <div class="col-lg-4 mt-10">
                        <asp:DropDownList CssClass="nice-select" Style="height: 58px; width: 100%;" ID="ddBillingState" runat="server" required>
                            <asp:ListItem Value="Not Specified" Selected="True" disabled="disabled">Billing State</asp:ListItem>
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
                    <div class="col-lg-4 mt-10">
                        <asp:TextBox CssClass="contact-form-input" ID="txtBillingZip" runat="server" placeholder="Billing Zip" required="true"></asp:TextBox>

                    </div>
                </div>
                <div class="mb-2">
                    <asp:Label ID="Label2" ForeColor="#FF5581" runat="server" Text="Payment Account Info" CssClass="mb-5"></asp:Label>

                </div>


                <div class="mt-10">
                    <asp:TextBox CssClass="contact-form-input" ID="txtAccountName" runat="server" placeholder="Account Name" required="true"></asp:TextBox>
                </div>
                <div class="mt-10">
                    <asp:TextBox CssClass="contact-form-input" ID="txtAccountType" runat="server" placeholder="Account Type" required="true"></asp:TextBox>
                </div>
                <div class="mt-10">
                    <asp:TextBox CssClass="contact-form-input" ID="txtAccountNumber" runat="server" placeholder="Account Number (Max legnth of 9)" required="true"></asp:TextBox>

                </div>
                <div class="col-lg-12 text-center">
                    <asp:Label ID="lblError" runat="server" Text="" Visible="false" CssClass="mb-5"></asp:Label><br />

                    <div class="mb-5">
                        <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" OnClick="btnSignUp_Click" CssClass="contact-form-button" />
                    </div>
                </div>


            </div>

        </div>

    </form>

</asp:Content>
