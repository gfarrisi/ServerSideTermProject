<%@ Page Title="" Language="C#" MasterPageFile="~/UserView.Master" AutoEventWireup="true" CodeBehind="UserOrder.aspx.cs" Inherits="TermProject.UserOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <form id="form1" runat="server">--%>
    <div class="container pt-5" style="padding-top: 10%;">
        <div class="row pt-5">
            <div class="col-md-3 mt-5" style="background-color: #4D4D4D; display: table;">
                <div class="pt-5 pb-5 pl-4 pr-4">
                    <h4 class="" style="color: white">Options</h4>
                    <hr style="background-color: #FF5581" />
                    <div class="pt-3 pl-2">
                        <asp:LinkButton ID="lbAccountSettings" runat="server" OnClick="lbAccountSettings_Click" ForeColor="White" CssClass="mt-5">Account Settings</asp:LinkButton>
                    </div>
                    <div class="pt-3 pl-2">
                        <asp:LinkButton ID="lbPaymentInfo" runat="server" OnClick="lbPaymentInfo_Click" ForeColor="White" CssClass="pt-4">Payment Info</asp:LinkButton>
                    </div>
                    <div class="pt-3 pl-2">
                        <asp:LinkButton ID="lbCurrentOrders" ForeColor="White" OnClick="lbCurrentOrders_Click" runat="server">My Order</asp:LinkButton>
                    </div>
                    <div class="pt-3 pl-2">
                        <asp:LinkButton ID="lbTransactions" ForeColor="White" OnClick="lbTransactions_Click" runat="server">View All Transactions</asp:LinkButton>
                    </div>
                    <hr style="background-color: #FF5581" />
                </div>
            </div>
            <div class="col-md-8 ml-3  mt-5">
                <div class="alert alert-danger" id="warning" runat="server" visible="false">
                    Your cart is empty! Please go to a restaurant and add some items.
                </div>
                <!-- Panel for menu items -->
                <asp:Panel ID="pnlMenu" runat="server" CssClass="pl-5 pr-5">
                    <h4 class="mt-4 mb-4 text-center">Review Your Order</h4>
                    <h6 class="mt-4 mb-4 text-center">Look over your order, then press Buy to pay for it.</h6>
                    <asp:Repeater ID="rptOrderItems" runat="server" OnItemDataBound="ItemBound">
                        <ItemTemplate>
                            <div class="row">
                                <div class="col-md-1"></div>

                                <div class="col-md-10">
                                    <div class="trend-item2">
                                        <div class="align-bottom float-right">
                                            <asp:Label ID="Label1" runat="server" Text="" ForeColor="#FF5581"><%# Eval("Item_Price", "{0:c}") %></asp:Label>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-5">
                                                <asp:HiddenField ID="hfOrderItemID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Order_Item_ID") %>' />
                                                <div class="trend-pic">
                                                    <asp:Image ID="imgMenuItem" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Item_Image") %>' />
                                                </div>
                                            </div>
                                            <div class="col-lg-7 pt-4" style="display: inline-block;">
                                                <div>
                                                    <asp:Label ID="lblTitle" Font-Bold="true" runat="server" CssClass="pt-3" Text='<%# DataBinder.Eval(Container.DataItem, "Item_Title") %>'></asp:Label>
                                                </div>
                                                <div>
                                                    <asp:Label ID="lblDescriptionLabel" runat="server" Text="Description: "></asp:Label>
                                                    <asp:Label ID="lblDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Item_Description") %>'></asp:Label>
                                                </div>

                                                <asp:Repeater ID="rptItemConfigurables" runat="server">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hfMenuItemIDConf" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Order_Item_Configurable_ID") %>' />
                                                        <asp:Label ID="lblItemConfigurableTitle" runat="server" CssClass="pt-4 font" Text='<%# DataBinder.Eval(Container.DataItem, "Order_Item_Configurable_Title") %>'></asp:Label>
                                                        <label>: </label>
                                                        <b>
                                                            <asp:Label ID="lblItemConfigurables" runat="server" CssClass="pt-4" Text='<%# DataBinder.Eval(Container.DataItem, "Order_Item_Configurable_Value") %>'></asp:Label></b>
                                                        <br />
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </asp:Panel>
                <br />
                <div class="col-md-11">
                    <div style="text-align: center;">
                        <b style="color: darkslategray">
                            <asp:Label ID="lblTotal" runat="server"></asp:Label></b><br />
                        <asp:Button ID="btnOrder" CssClass="contact-form-button-2 mb-3 mt-1" runat="server" Text="Buy" OnClick="btnOrder_Click" />
                    </div>
                </div>
            </div>

            <div class="pb-4">
                <asp:Label ID="lblErrorDisplay" Visible="false" runat="server" Text="You screwed up"></asp:Label>
                <asp:Label ID="lblFunded" Visible="false" runat="server" Text="The account was successfully funded"></asp:Label>
            </div>
        </div>
    </div>
    <%--    </form>--%>
</asp:Content>
