<%@ Page Title="" Language="C#" MasterPageFile="~/UserView.Master" AutoEventWireup="true" CodeBehind="OrderStatus.aspx.cs" Inherits="TermProject.OrderStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Order Status
    </title>
    <style>
        .lbl {
            font-weight: bold;
            color: dimgray;
        }

        .changed {
            font-size: 18px;
            color: seagreen;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="scriptman" runat="server">
    </asp:ScriptManager>


    <div class="container" style="padding-top: 10%;">
        <div class="row">
            <div class="col-md-3" style="background-color: #4D4D4D; display: table;">
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
            <div class="col-1"></div>
            <div class="col-7 pt-4" style="text-align: center;">

                <h4 class="text-center pb-5">Order Status</h4>
                <div class="alert alert-danger" id="warning" runat="server" visible="false">
                    You haven't made an order yet!
                </div>
                <div class="pl-5 pt-3 pb-3 pr-5 shadow" style="background: #F7F8FB;" id="dvPanel" runat="server">
                    <br />
                    <asp:UpdatePanel ID="upOrder" style="width: 100%" runat="server">
                        <ContentTemplate>
                            <asp:Timer ID="tmOrderStatus" OnTick="tmOrderStatus_Tick" runat="server" Interval="3000" />
                            <div>
                                <asp:Label runat="server" CssClass="lbl" Text="Order ID: "></asp:Label>
                                <asp:Label ID="lblID" runat="server"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Time: "></asp:Label>
                                <asp:Label ID="lblTime" runat="server"> </asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Cost: "></asp:Label>
                                <asp:Label ID="lblCost" runat="server"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Status: "></asp:Label>
                                <b style="color: seagreen; font-size: 1.5em;">
                                    <asp:Label ID="lblStatus" runat="server"></asp:Label></b>
                                <img id="imgStatus" runat="server" src="" style="width: 150px; height: 150px; object-fit: cover" />
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="tmOrderStatus" EventName="Tick" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
                <br />
                <asp:Panel ID="pnlMenu" runat="server" CssClass="pl-5 pr-5">
                                    <h6>My Order</h6>
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
            </div>
        </div>
    </div>
    <br />

</asp:Content>
