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


    <div class="container" style="padding-top: 10%; height: 90vh;">
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
            <div class="col-2"></div>
            <div class="col-6 pt-4" style="text-align:center;">
                <h4 class="text-center pb-5">Order Status</h4>
                <div class="pl-5 pt-3 pb-3 pr-5 shadow" style="background: #F7F8FB;">

                    <br />
                    <asp:UpdatePanel ID="upOrder" style="width: 100%" runat="server">
                        <ContentTemplate>
                            <asp:Timer ID="tmOrderStatus" OnTick="tmOrderStatus_Tick" runat="server" Interval="5000" />
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
                                <img id="imgStatus" runat="server" src="" style="width:150px;height:150px;object-fit:cover" />
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="tmOrderStatus" EventName="Tick" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <br />

</asp:Content>
