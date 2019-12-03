<%@ Page Title="" Language="C#" MasterPageFile="~/RestaurantRepView.Master" AutoEventWireup="true" CodeBehind="RestaurantAccountSettings.aspx.cs" Inherits="TermProject.RestaurantAccountSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

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
                        <div class="pt-3 pl-2">
                            <asp:LinkButton ID="lbViewAsUser" ForeColor="White" runat="server">View As User</asp:LinkButton>
                        </div>
                        <hr style="background-color: #FF5581" />
                        <div>
                            <asp:Repeater ID="rptContactInfo" runat="server">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hfRestaurantID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Restaurant_ID") %>' />
                                    <div class="pt-3 pl-2">
                                        <asp:Label ID="lbPhoneNumber" ForeColor="White" runat="server" CssClass="mt-5" Text=""><%# !String.IsNullOrEmpty(Convert.ToString(Eval("Restaurant_Phone"))) ? String.Format("{0:(###) ###-####}", Convert.ToInt64(Eval("Restaurant_Phone").ToString())) : String.Empty%></asp:Label>
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
                        <asp:Repeater ID="rptRestaurantInfo" runat="server">
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" ForeColor="#FF5581" Font-Size="Large" Font-Bold="true" Text="Restaurant Info"></asp:Label>
                                <asp:HiddenField ID="hfRestaurantID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Restaurant_ID") %>' />
                                <div class="row mt-4">
                                    <div class="col-lg-3">
                                        <asp:Label ID="Label1" runat="server" Text="Restaurant Name:"></asp:Label>
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox ID="lblName" runat="server" Font-Italic="true" CssClass="form-control" Text='<%# DataBinder.Eval(Container.DataItem, "Restaurant_Name") %>'></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:LinkButton ForeColor="#FF5581" ID="lbUpdateName" runat="server">Update</asp:LinkButton>
                                    </div>
                                </div>
                                <div class="row mt-4">
                                    <div class="col-lg-3">
                                        <asp:Label ID="Label2" runat="server" Text="Restaurant Phone:"></asp:Label>
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox ID="txtPhoneNumber" runat="server" Font-Italic="true" CssClass="form-control" Text='<%# !String.IsNullOrEmpty(Convert.ToString(Eval("Restaurant_Phone"))) ? String.Format("{0:(###) ###-####}", Convert.ToInt64(Eval("Restaurant_Phone").ToString())) : String.Empty%>'></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:LinkButton ForeColor="#FF5581" ID="lbUpdatePhone" runat="server">Update</asp:LinkButton>
                                    </div>
                                </div>
                                <div class="row mt-4">
                                    <div class="col-lg-3">
                                        <asp:Label ID="Label5" runat="server" Text="Restaurant Email:"></asp:Label>
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox ID="lbEmail" runat="server" Font-Italic="true" CssClass="form-control" Text='<%# DataBinder.Eval(Container.DataItem, "Restaurant_Email") %>'></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:LinkButton ForeColor="#FF5581" ID="lbUpdateRestaurantEmail" runat="server">Update</asp:LinkButton>
                                    </div>
                                </div>
                                <div class="row mt-4">
                                    <div class="col-lg-3">
                                        <asp:Label ID="Label10" runat="server" Text="Restaurant Image URL:"></asp:Label>
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox ID="TextBox6" runat="server" Font-Italic="true" CssClass="form-control" Text='<%# DataBinder.Eval(Container.DataItem, "Image_URL") %>'></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:LinkButton ForeColor="#FF5581" ID="LinkButton6" runat="server">Update</asp:LinkButton>
                                    </div>
                                </div>
                                <div class="row mt-4">
                                    <div class="col-lg-3">
                                        <asp:Label ID="Label3" runat="server" Text="Restaurant Address:"></asp:Label>
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox ID="TextBox1" runat="server" Font-Italic="true" CssClass="form-control" Text='<%# DataBinder.Eval(Container.DataItem, "Restaurant_Address") %>'></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:LinkButton ForeColor="#FF5581" ID="LinkButton1" runat="server">Update</asp:LinkButton>
                                    </div>
                                </div>
                                <div class="row mt-4">
                                    <div class="col-lg-3">
                                        <asp:Label ID="Label4" runat="server" Text="Restaurant City:"></asp:Label>
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox ID="TextBox2" runat="server" Font-Italic="true" CssClass="form-control" Text='<%# DataBinder.Eval(Container.DataItem, "Restaurant_City") %>'></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:LinkButton ForeColor="#FF5581" ID="LinkButton2" runat="server">Update</asp:LinkButton>
                                    </div>
                                </div>
                                <div class="row mt-4">
                                    <div class="col-lg-3">
                                        <asp:Label ID="Label7" runat="server" Text="Restaurant State:"></asp:Label>
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox ID="TextBox3" runat="server" Font-Italic="true" CssClass="form-control" Text='<%# DataBinder.Eval(Container.DataItem, "Restaurant_State") %>'></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:LinkButton ForeColor="#FF5581" ID="LinkButton3" runat="server">Update</asp:LinkButton>
                                    </div>
                                </div>
                                <div class="row mt-4">
                                    <div class="col-lg-3">
                                        <asp:Label ID="Label8" runat="server" Text="Restaurant Zip:"></asp:Label>
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" Font-Italic="true" Text='<%# DataBinder.Eval(Container.DataItem, "Restaurant_Zip") %>'></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:LinkButton ForeColor="#FF5581" ID="LinkButton4" runat="server">Update</asp:LinkButton>
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
                                        <asp:TextBox ID="lblName" runat="server" Font-Italic="true" CssClass="form-control" Text='<%# DataBinder.Eval(Container.DataItem, "First_Name") %>'></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:LinkButton ForeColor="#FF5581" ID="lbUpdateName" runat="server">Update</asp:LinkButton>
                                    </div>
                                </div>
                                <div class="row mt-4">
                                    <div class="col-lg-3">
                                        <asp:Label ID="Label9" runat="server" Text="Last Name:"></asp:Label>
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox ID="TextBox5" runat="server" Font-Italic="true" CssClass="form-control" Text='<%# DataBinder.Eval(Container.DataItem, "Last_Name") %>'></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:LinkButton ForeColor="#FF5581" ID="LinkButton5" runat="server">Update</asp:LinkButton>
                                    </div>
                                </div>

                                <div class="row mt-4">
                                    <div class="col-lg-3">
                                        <asp:Label ID="Label5" runat="server" Text="Email:"></asp:Label>
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox ID="lbEmail" runat="server" Font-Italic="true" CssClass="form-control" Text='<%# DataBinder.Eval(Container.DataItem, "Email") %>'></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:LinkButton ForeColor="#FF5581" ID="lbUpdateRestaurantEmail" runat="server">Update</asp:LinkButton>
                                    </div>
                                </div>
                                <div class="row mt-4">
                                    <div class="col-lg-3">
                                        <asp:Label ID="Label3" runat="server" Text="Password:"></asp:Label>
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox ID="TextBox1" runat="server" Font-Italic="true" TextMode="Password" CssClass="form-control" Text='<%# DataBinder.Eval(Container.DataItem, "Password") %>'></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:LinkButton ForeColor="#FF5581" ID="LinkButton1" runat="server">Update</asp:LinkButton>
                                    </div>
                                </div>
                                <div class="row mt-4">
                                    <div class="col-lg-3">
                                        <asp:Label ID="Label4" runat="server" Text="Backup Email"></asp:Label>
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox ID="TextBox2" runat="server" Font-Italic="true" CssClass="form-control" Text='<%# DataBinder.Eval(Container.DataItem, "Backup_Email") %>'></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:LinkButton ForeColor="#FF5581" ID="LinkButton2" runat="server">Update</asp:LinkButton>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="m-5 text-center">
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="contact-form-button" />
                        </div>

                    </asp:Panel>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
