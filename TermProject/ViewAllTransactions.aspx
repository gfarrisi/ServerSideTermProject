<%@ Page Title="" Language="C#" MasterPageFile="~/UserView.Master" AutoEventWireup="true" CodeBehind="ViewAllTransactions.aspx.cs" Inherits="TermProject.ViewAllTransactions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
            <div class="col-md-9  mt-5">
                <!-- Header Section Begin -->
                <!-- Hero Section Begin -->

                <!-- Panel for menu items -->
                <asp:Panel ID="pnlAccountSettings" runat="server" CssClass="pl-5 pr-5 pb-5">
                    <h4 class="mt-4 mb-4 text-center">Transaction History</h4>
                    <%--  User Info--%>
                    <asp:GridView ID="gvTransactions" runat="server" CssClass="table table-borderless table-striped" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="VirtualWalletSenderID" HeaderText="Sender" />
                            <asp:BoundField DataField="VirtualWalletReceiverID" HeaderText="Receiver" />
                            <asp:BoundField DataField="Transaction_Type" HeaderText="Type" />
                            <asp:BoundField DataField="Transaction_Amount" HeaderText="Amount" DataFormatString="{0:c}" />
                           <asp:BoundField DataField="Transaction_DateTime" HeaderText="Date/Time" />
                        </Columns>
                    </asp:GridView>
                    <asp:Label ID="lblError" Visible="false" runat="server" Text=""></asp:Label>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
