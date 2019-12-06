﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UserView.Master" AutoEventWireup="true" CodeBehind="UserCart.aspx.cs" Inherits="TermProject.UserCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
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
                        <hr style="background-color: #FF5581" />
                    </div>
                </div>
                <div class="col-md-8 ml-3  mt-5">

                    <!-- Panel for menu items -->
                    <asp:Panel ID="pnlMenu" runat="server" CssClass="pl-5 pr-5">
                        <h4 class="mt-4 mb-4 text-center">Your Order</h4>
                        <asp:Repeater ID="rptOrderItems" runat="server" OnItemDataBound="ItemBound" OnItemCommand="rptOrderItems_ItemCommand">
                            <ItemTemplate>
                                <div class="row">
                                    <div class="col-md-1"></div>

                                    <div class="col-md-10">
                                        <div class="trend-item">
                                            <div class="row">
                                                <div class="col-lg-5">
                                                    <asp:HiddenField ID="hfOrderItemID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Order_Item_ID") %>' />
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
                                                <div class="align-bottom float-right">
                                                    <asp:Label ID="lblPrice" runat="server" Text="" ForeColor="#FF5581"><%# Eval("Item_Price", "{0:c}") %></asp:Label>
                                                </div>
                                            </div>
                                            <div style="text-align: center;">
                                                <asp:LinkButton ID="lbDelete" runat="server" CssClass="contact-form-button-timy" CommandName="DeleteItem"><i class="fa fa-remove"></i>Delete</asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                            </ItemTemplate>
                        </asp:Repeater>

                        <div class="text-center">
                            <asp:Button ID="btnCheckout" CssClass="contact-form-button" runat="server" Text="Checkout" OnClick="btnCheckout_Click" />
                        </div>
                        <%--                        <div class="text-center">
                            <button type="button" class="contact-form-button" data-toggle="modal" data-target="#mdlAddQuestion" data-whatever="@fat">Add Menu Item</button>
                        </div>--%>

                        <!-- Modal -->
                        <div class="modal fade" id="mdlAddQuestion" tabindex="-1" role="dialog" aria-labelledby="mdlAddQuestion" aria-hidden="true">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-body">
                                        ...
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                        <button type="button" class="btn btn-primary">Save changes</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </form>
</asp:Content>