<%@ Page Title="" Language="C#" MasterPageFile="~/RestaurantRepView.Master" AutoEventWireup="true" CodeBehind="RestaurantLanding.aspx.cs" Inherits="TermProject.RestaurantLanding" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <!-- Page Preloder -->
        <div id="preloder">
            <div class="loader"></div>
        </div>


        <div class="container pt-5" style="padding-top: 10%; height: 90vh;">
            <div class="row pt-5">
                <div class="col-md-3 mt-5" style="background-color: #4D4D4D;">
                    <div class="pt-5 pb-5 pl-4 pr-4">
                        <h4 class="" style="color: white">Restaurant Options</h4>
                        <hr style="background-color: #FF5581" />
                        <div class="pt-3 pl-2">
                            <asp:LinkButton ID="lbAccountSettings" runat="server" CssClass="mt-5">Account Settings</asp:LinkButton>
                        </div>
                        <div class="pt-3 pl-2">
                            <asp:LinkButton ID="lbMenuManagement" runat="server" CssClass="pt-4">Menu Management</asp:LinkButton>
                        </div>
                        <div class="pt-3 pl-2">
                            <asp:LinkButton ID="lbCurrentOrders" runat="server">Current Orders</asp:LinkButton>
                        </div>
                        <div class="pt-3 pl-2">
                            <asp:LinkButton ID="lbViewAsUser" runat="server">View As User</asp:LinkButton>
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
                <div class="col-md-8 ml-3  mt-5">
                    <!-- Header Section Begin -->
                    <!-- Hero Section Begin -->
                    <div class="hero-listing set-bg" style="height: 200px;" data-setbg="img/hero_listing.jpg">
                    </div>


                    <!-- Panel for no exisitng menu -->
                    <asp:Panel ID="pnlNoMenu" runat="server" CssClass="p-3 text-center" Visible="false">
                        <h4 class="mt-4">No menu found for your restaurant.</h4>
                        <asp:Button ID="btnStartMenu" runat="server" Text="Start New Menu" CssClass="contact-form-button m-4" />
                    </asp:Panel>

                    <!-- Panel for menu items -->
                    <asp:Panel ID="pnlMenu" runat="server" CssClass="pl-5 pr-5">
                        <h4 class="mt-4 mb-4 text-center">Menu</h4>
                        <asp:Repeater ID="rptMenuItems" runat="server" OnItemDataBound="ItemBound">
                            <ItemTemplate>
                                <div class="row">
                                    <div class="col-md-1"></div>

                                    <div class="col-md-10">
                                        <div class="trend-item">
                                            <div class="row">
                                                <div class="col-lg-5">
                                                    <asp:HiddenField ID="hfMenuItemID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Menu_Item_ID") %>' />
                                                    <div class="trend-pic">
                                                        <asp:Image ID="imgMenuItem" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Item_Image") %>' />
                                                    </div>
                                                </div>

                                                <div class="pt-4" style="display: inline-block;">
                                                    <div>
                                                        <asp:Label ID="lblTitle" Font-Bold="true" runat="server" CssClass="pt-3" Text='<%# DataBinder.Eval(Container.DataItem, "Item_Title") %>'></asp:Label>
                                                    </div>
                                                    <div>
                                                        <asp:Label ID="lblDescriptionLabel" runat="server" Text="Description: "></asp:Label>
                                                        <asp:Label ID="lblDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Item_Description") %>'></asp:Label>
                                                    </div>
                                                    <asp:Repeater ID="rptItemConfigurableTitle" runat="server">
                                                        <ItemTemplate>

                                                            <asp:Label ID="lblItemConfigurableTitle" runat="server" CssClass="pt-4 font" Text='<%# DataBinder.Eval(Container.DataItem, "Configurable_Title") %>'></asp:Label>
                                                            <asp:Label ID="lblDescriptionLabel" runat="server" Text=": "></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:Repeater>

                                                    <div class="row pl-5">
                                                        <asp:Repeater ID="rptItemConfigurables" runat="server">
                                                            <ItemTemplate>
                                                                <div class="col-lg-4">
                                                                    <asp:Label ID="lblItemConfigurables" runat="server" CssClass="pt-4" Text='<%# Container.DataItem.ToString() %>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </div>
                                                </div>
                                                <div class="align-bottom float-right">
                                                    <asp:Label ID="lblPrice" runat="server" Text="" ForeColor="#FF5581"><%# Eval("Item_Price", "{0:c}") %></asp:Label>
                                                </div>

                                            </div>
                                            <%-- <div class="tic-text">Restaurant</div>--%>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </asp:Panel>

                </div>
            </div>

        </div>
    </form>
</asp:Content>
