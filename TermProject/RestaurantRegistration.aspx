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
        <!-- Contact Section Begin -->
        <section class="contact-section spad">
            <h2>Register your Restaurant</h2>
            <br />
            <div class="container">
                <div class="row">
                    <div class="col-lg-2"></div>
                    <div class="col-lg-8">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Restaurant Name:</label><asp:TextBox ID="txtResName" placeholder="Restaurant Name" runat="server" required></asp:TextBox>
                            </div>
                            <div class="col-lg-6">
                                <label>Restaurant Graphic (URL Format)</label>
                                <asp:TextBox ID="txtResImg" placeholder="Image URL" runat="server" required></asp:TextBox>
                            </div>
                            <div class="col-lg-6">
                                <label>Contact Phone:</label><asp:TextBox ID="txtResPhone" placeholder="Phone" runat="server" required></asp:TextBox>
                            </div>
                            <div class="col-lg-6">
                                <label>Contact Email:</label><asp:TextBox ID="txtResEmail" placeholder="Email" runat="server" required></asp:TextBox>
                            </div>
                            <div class="col-lg-12">
                                <label>Restaurant Address:</label><asp:TextBox ID="txtResAddr" placeholder="Address" runat="server" required></asp:TextBox>
                            </div>
                            <div class="col-lg-4">
                                <label>City</label><asp:TextBox ID="txtResCity" placeholder="City" runat="server" required></asp:TextBox>
                            </div>
                            <div class="col-lg-4">
                                <label>State</label>
                                <br />
                                <asp:DropDownList CssClass="nice-select" Style="height: 58px; width: 100%;" ID="ddlResState" runat="server" required>
                                    <asp:ListItem Value="" Selected="True" disabled>Select a State</asp:ListItem>
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
                                <label>ZIP</label><asp:TextBox ID="txtResZip" placeholder="5-number ZIP code" runat="server" required></asp:TextBox>
                            </div>
                            <div class="col-lg-12">
                                <hr />
                                <p style="text-align: center;">Upon submitting this form, your user account will automatically be set as the representative of this restauraunt.</p>
                            </div>
                            <div class="col-lg-3">
                            </div>
                            <div class="col-lg-6">
                                <asp:Button ID="btnRegister" CssClass="contact-form-button" Text="Register Restaurant" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </form>
</asp:Content>
