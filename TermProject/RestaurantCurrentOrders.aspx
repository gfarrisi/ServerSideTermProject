<%@ Page Title="" Language="C#" MasterPageFile="~/RestaurantRepView.Master" AutoEventWireup="true" CodeBehind="RestaurantCurrentOrders.aspx.cs" Inherits="TermProject.RestaurantCurrentOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <form id="form1" runat="server">

        <!-- Page Preloder -->
        <div id="preloder">
            <div class="loader"></div>

        </div>


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
                   
                    <!-- Panel for menu items -->
                    <asp:Panel ID="pnlAccountSettings" runat="server" CssClass="pl-5 pr-5">
                        

                    </asp:Panel>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
