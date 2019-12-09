<%@ Page Title="" Language="C#" MasterPageFile="~/RestaurantRepView.Master" AutoEventWireup="true" CodeBehind="RestaurantAccountSettings.aspx.cs" Inherits="TermProject.RestaurantAccountSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--        <!-- Page Preloder -->
        <div id="preloder">
            <div class="loader"></div>

        </div>--%>


    <div class="container pt-5" style="padding-top: 10%;">
        <div class="row pt-5">
            <div class="col-md-3 mt-5" style="background-color: #4D4D4D; display: table;">
                <div class="pt-5 pb-5 pl-4 pr-4">
                    <h4 class="" style="color: white">Restaurant Options</h4>
                    <hr style="background-color: #FF5581" />
                    <div class="pt-3 pl-2">
                        <asp:LinkButton ID="lbMenuManagement" runat="server" OnClick="lbMenuManagement_Click" ForeColor="White" CssClass="pt-4">Menu Management</asp:LinkButton>
                    </div>
                    <div class="pt-3 pl-2">
                        <asp:LinkButton ID="lbAccountSettings" runat="server" OnClick="lbAccountSettings_Click" ForeColor="White" CssClass="mt-5">Account Settings</asp:LinkButton>
                    </div>
                    <div class="pt-3 pl-2">
                        <asp:LinkButton ID="lbPaymentInfo" runat="server" OnClick="lbPaymentInfo_Click" ForeColor="White" CssClass="pt-4">Payment Info</asp:LinkButton>
                    </div>
                    <div class="pt-3 pl-2">
                        <asp:LinkButton ID="lbCurrentOrders" ForeColor="White" OnClick="lbCurrentOrders_Click" runat="server">Current Orders</asp:LinkButton>
                    </div>
                    <hr style="background-color: #FF5581" />
                    <div>
                        <asp:Repeater ID="rptContactInfo" runat="server">
                            <ItemTemplate>
                                <asp:HiddenField ID="hfRestaurantID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Restaurant_ID") %>' />
                                <div class="pt-3 pl-2">
                                    <%--                                        <asp:Label ID="lbPhoneNumber" ForeColor="White" runat="server" CssClass="mt-5" Text=""><%# !String.IsNullOrEmpty(Convert.ToString(Eval("Restaurant_Phone"))) ? String.Format("{0:(###) ###-####}", Convert.ToInt64(Eval("Restaurant_Phone").ToString())) : String.Empty%></asp:Label>--%>
                                    <asp:Label ID="lbPhoneNumber" ForeColor="White" runat="server" CssClass="mt-5" Text='<%# DataBinder.Eval(Container.DataItem, "Restaurant_Phone")%>'></asp:Label>
                                </div>
                                <div class="pt-3 pl-2">
                                    <asp:Label ID="lbEmail" runat="server" ForeColor="White" CssClass="pt-4" Text='<%# DataBinder.Eval(Container.DataItem, "Restaurant_Email") %>'></asp:Label>
                                </div>
                                <div class="pt-3 pl-2">
                                    <asp:Label ID="lbAddress" ForeColor="White" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Restaurant_Address") %>'></asp:Label>
                                </div>
                                <div class="pt-3 pl-2">
                                    <asp:Label ID="lbCityStateZip" ForeColor="White" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Restaurant_City") + ", " + DataBinder.Eval(Container.DataItem, "Restaurant_State") + " " + DataBinder.Eval(Container.DataItem, "Restaurant_Zip") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
            <div class="col-md-9  mt-5">
                <!-- Header Section Begin -->
                <!-- Hero Section Begin -->



                <!-- Panel for no exisitng menu -->
                <asp:Panel ID="pnlNoMenu" runat="server" CssClass="p-3 text-center" Visible="false">
                    <h4 class="mt-4">No menu found for your restaurant.</h4>
                    <asp:Button ID="btnStartMenu" runat="server" Text="Start New Menu" CssClass="contact-form-button m-4" />
                </asp:Panel>

                <!-- Panel for menu items -->
                <asp:Panel ID="pnlAccountSettings" runat="server" CssClass="pl-5 pr-5">
                    <h4 class="mt-4 mb-4 text-center">Account Settings</h4>
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                    <asp:Repeater ID="rptRestaurantInfo" runat="server">
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" ForeColor="#FF5581" Font-Size="Large" Font-Bold="true" Text="Restaurant Info"></asp:Label>
                            <asp:HiddenField ID="hfRestaurantID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Restaurant_ID") %>' />
                            <div class="row mt-4">
                                <div class="col-lg-3">
                                    <asp:Label ID="Label5" runat="server" Text="Restaurant Email:"></asp:Label>
                                </div>
                                <div class="col-lg-7">
                                    <asp:TextBox ID="txtResEmail" runat="server" Font-Italic="true" CssClass="form-control" Text='<%# DataBinder.Eval(Container.DataItem, "Restaurant_Email") %>' ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row mt-4">
                                <div class="col-lg-3">
                                    <asp:Label ID="Label2" runat="server" Text="Restaurant Phone:"></asp:Label>
                                </div>
                                <div class="col-lg-7">
                                    <asp:TextBox ID="txtPhone" runat="server" Font-Italic="true" CssClass="form-control" Text='<%# DataBinder.Eval(Container.DataItem, "Restaurant_Phone")%>'></asp:TextBox>
                                </div>
                            </div>

                            <div class="row mt-4">
                                <div class="col-lg-3">
                                    <asp:Label ID="Label10" runat="server" Text="Restaurant Image URL:"></asp:Label>
                                </div>
                                <div class="col-lg-7">
                                    <asp:TextBox ID="txtImageURL" runat="server" Font-Italic="true" CssClass="form-control" Text='<%# DataBinder.Eval(Container.DataItem, "Image_URL") %>'></asp:TextBox>
                                </div>
                            </div>
                            <div class="row mt-4">
                                <div class="col-lg-3">
                                    <asp:Label ID="Label3" runat="server" Text="Restaurant Address:"></asp:Label>
                                </div>
                                <div class="col-lg-7">
                                    <asp:TextBox ID="txtAddress" runat="server" Font-Italic="true" CssClass="form-control" Text='<%# DataBinder.Eval(Container.DataItem, "Restaurant_Address") %>'></asp:TextBox>
                                </div>
                            </div>
                            <div class="row mt-4">
                                <div class="col-lg-3">
                                    <asp:Label ID="Label4" runat="server" Text="Restaurant City:"></asp:Label>
                                </div>
                                <div class="col-lg-7">
                                    <asp:TextBox ID="txtCity" runat="server" Font-Italic="true" CssClass="form-control" Text='<%# DataBinder.Eval(Container.DataItem, "Restaurant_City") %>'></asp:TextBox>
                                </div>
                            </div>
                            <div class="row mt-4">
                                <div class="col-lg-3">
                                    <asp:Label ID="Label7" runat="server" Text="Restaurant State:"></asp:Label>
                                </div>
                                <div class="col-lg-7">
                                    <asp:DropDownList CssClass="nice-select" Style="width: 100%; height: 42px; color: #535353;" ID="txtState" runat="server" SelectedValue='<%# DataBinder.Eval(Container.DataItem,"Restaurant_State") %>'>
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
                            </div>
                            <div class="row mt-4">
                                <div class="col-lg-3">
                                    <asp:Label ID="Label8" runat="server" Text="Restaurant Zip:"></asp:Label>
                                </div>
                                <div class="col-lg-7">
                                    <asp:TextBox ID="txtZip" runat="server" CssClass="form-control" Font-Italic="true" Text='<%# DataBinder.Eval(Container.DataItem, "Restaurant_Zip") %>'></asp:TextBox>
                                </div>
                            </div>

                        </ItemTemplate>
                    </asp:Repeater>

                    <%--  Restaurant Representative Info--%>
                    <asp:Repeater ID="rptRepInfo" runat="server">
                        <ItemTemplate>
                            <div class="mt-4">
                                <asp:Label ID="Label6" CssClass="mt-5" runat="server" ForeColor="#FF5581" Font-Size="Large" Font-Bold="true" Text="Restaurant Representative Info"></asp:Label>

                            </div>
                            <div class="row mt-4">
                                <div class="col-lg-3">
                                    <asp:Label ID="Label1" runat="server" Text="First Name:"></asp:Label>
                                </div>
                                <div class="col-lg-7">
                                    <asp:TextBox ID="txtFirstName" runat="server" Font-Italic="true" CssClass="form-control" Text='<%# DataBinder.Eval(Container.DataItem, "First_Name") %>'></asp:TextBox>
                                </div>

                            </div>
                            <div class="row mt-4">
                                <div class="col-lg-3">
                                    <asp:Label ID="Label9" runat="server" Text="Last Name:"></asp:Label>
                                </div>
                                <div class="col-lg-7">
                                    <asp:TextBox ID="txtLastName" runat="server" Font-Italic="true" CssClass="form-control" Text='<%# DataBinder.Eval(Container.DataItem, "Last_Name") %>'></asp:TextBox>
                                </div>
                            </div>

                            <div class="row mt-4">
                                <div class="col-lg-3">
                                    <asp:Label ID="Label5" runat="server" Text="Email:"></asp:Label>
                                </div>
                                <div class="col-lg-7">
                                    <asp:TextBox ID="txtEmail" runat="server" Font-Italic="true" CssClass="form-control" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "Email") %>'></asp:TextBox>
                                </div>
                            </div>
                            <div class="row mt-4">
                                <div class="col-lg-3">
                                    <asp:Label ID="Label3" runat="server" Text="Password:"></asp:Label>
                                </div>
                                <div class="col-lg-7">
                                    <asp:TextBox ID="txtPassword" runat="server" Font-Italic="true" CssClass="form-control" Text='<%# DataBinder.Eval(Container.DataItem, "Password") %>'></asp:TextBox>
                                </div>
                            </div>
                            <div class="row mt-4">
                                <div class="col-lg-3">
                                    <asp:Label ID="Label4" runat="server" Text="Backup Email"></asp:Label>
                                </div>
                                <div class="col-lg-7">
                                    <asp:TextBox ID="txtBackup" runat="server" Font-Italic="true" CssClass="form-control" Text='<%# DataBinder.Eval(Container.DataItem, "Backup_Email") %>'></asp:TextBox>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div class="form-check mt-4">
                        <asp:CheckBox ID="chkDeleteCookie" CssClass="form-check-input" runat="server" />
                        <asp:Label ID="lblDeleteCookie" CssClass="form-check-label" runat="server" Text="Delete site cookies"></asp:Label>
                    </div>
                    <div class="m-5 text-center">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="contact-form-button" />
                    </div>

                </asp:Panel>
            </div>
        </div>
    </div>

</asp:Content>
