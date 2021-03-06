<%@ Page Title="" Language="C#" MasterPageFile="~/RestaurantRepView.Master" AutoEventWireup="true" CodeBehind="RestaurantLanding.aspx.cs" Inherits="TermProject.RestaurantLanding" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/js/bootstrap.min.js"></script>


    <%--    <!-- Page Preloder -->
        <div id="preloder">
            <div class="loader"></div>

        </div>--%>


    <div class="container pt-5" style="padding-top: 10%;">
        <div class="row pt-5 pb-5">
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
                                    <asp:Label ID="lbPhoneNumber" ForeColor="White" runat="server" CssClass="mt-5" Text='<%# DataBinder.Eval(Container.DataItem, "Restaurant_Phone") %>'></asp:Label>
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
                <div class="hero-listing set-bg" id="divHero" style="height: 200px;" runat="server" data-setbg="img/hero_listing.jpg">
                </div>


                <!-- Panel for no exisitng menu -->
                <asp:Panel ID="pnlNoMenu" runat="server" CssClass="p-3 text-center" Visible="false">
                    <h4 class="mt-4">No menu found for your restaurant.</h4>
                    <asp:Button ID="btnStartMenu" runat="server" Text="Start New Menu" CssClass="contact-form-button m-4" />
                </asp:Panel>


                <!-- Panel for menu items -->
                <asp:Panel ID="pnlMenu" runat="server" CssClass="pl-5 pr-5">

                    <div>

                        <h4 class="mt-4 mb-4 text-center" id="MenuTitle" runat="server">Menu</h4>
                    </div>
                    <div class="text-center">
                        <asp:Button ID="btnAddMenuItem" runat="server" Text="Add Menu Item" OnClick="btnAddMenuItem_Click" CssClass="contact-form-button m-4" />
                    </div>
                    <asp:Repeater ID="rptMenuItems" runat="server" OnItemDataBound="ItemBound" OnItemCommand="rptMenuItems_ItemCommand">
                        <ItemTemplate>
                            <div class="row">
                                <div class="col-md-1"></div>

                                <div class="col-md-10">
                                    <div class="trend-item">
                                        <div class="align-bottom float-right mt-3">
                                            <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Item_Price", "{0:c}") %>' ForeColor="#FF5581"></asp:Label>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-5 pt-2">
                                                <asp:HiddenField ID="hfMenuItemID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Menu_Item_ID") %>' />
                                                <div class="trend-pic">
                                                    <asp:Image ID="imgMenuItem" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Item_Image") %>' />
                                                </div>
                                            </div>

                                            <div class="col-lg-7 pt-2" style="display: inline-block;">
                                                <div>
                                                    <asp:Label ID="lblTitle" Font-Bold="true" runat="server" CssClass="pt-3" Text='<%# DataBinder.Eval(Container.DataItem, "Item_Title") %>'></asp:Label>
                                                </div>
                                                <div>
                                                    <asp:Label ID="lblDescriptionLabel" runat="server" Text="Description: "></asp:Label>
                                                    <asp:Label ID="lblDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Item_Description") %>'></asp:Label>
                                                </div>

                                                <asp:Repeater ID="rptItemConfigurableTitle" runat="server" OnItemDataBound="ItemBoundConfig">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hfMenuItemIDConf" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Configurable_ID") %>' />
                                                        <asp:Label ID="lblItemConfigurableTitle" runat="server" CssClass="pt-4 font" Text='<%# DataBinder.Eval(Container.DataItem, "Configurable_Title") %>'></asp:Label>
                                                        <asp:Label ID="lbl1" runat="server" Text=": "></asp:Label>

                                                        <div class="row pl-5">
                                                            <asp:Repeater ID="rptItemConfigurables" runat="server">
                                                                <ItemTemplate>
                                                                    <div class="col-12">
                                                                        <asp:Label ID="lblItemConfigurables" runat="server" CssClass="pt-4" Text='<%# Container.DataItem.ToString() %>'></asp:Label>

                                                                    </div>

                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </div>

                                                    </ItemTemplate>

                                                </asp:Repeater>
                                            </div>
                                            <div class="tic-text">
                                                <asp:Label ID="lblCategory" runat="server" CssClass="pt-4 font" Text='<%# DataBinder.Eval(Container.DataItem, "Item_Category") %>'></asp:Label>
                                            </div>

                                        </div>
                                        <div class="row pt-3">
                                            <div class="col-lg-6"></div>
                                            <div class="col-lg-3">
                                                <asp:Button ID="btnEdit" OnClick="btnEdit_Click" CommandName="EditItem" CssClass="btn btn-secondary" Text="Edit" Style="width: 100%; background: #1d1d1d; opacity: 0.79" runat="server" />

                                            </div>
                                            <div class="col-lg-3">
                                                <asp:Button ID="btnDelete" OnClick="btnDelete_Click" CommandName="DeleteItem" CssClass="btn btn-secondary" Text="Delete" Style="width: 100%; background: #1d1d1d; opacity: 0.79" runat="server" />

                                            </div>

                                        </div>
                                        <%-- <div class="tic-text">Restaurant</div>--%>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                    <%--<div class="text-center">
                            <asp:Button ID="btnAddNewItem" runat="server" data-toggle="modal" data-target="#mdlAddQuestion" Text="Add new menu item" OnClick="btnAddNewItem_Click" CssClass="contact-form-button" />
                        </div>--%>
                </asp:Panel>


            </div>
        </div>
    </div>


</asp:Content>
