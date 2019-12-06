<%@ Page Title="" Language="C#" MasterPageFile="~/RestaurantRepView.Master" AutoEventWireup="true" CodeBehind="RestaurantPaymentInfo.aspx.cs" Inherits="TermProject.RestaurantPaymentInfo" %>

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
                    <asp:Panel ID="pnlPaymentInfo" runat="server" CssClass="pl-5 pr-5">


                        <%--<asp:Label ID="Label6" runat="server" ForeColor="#FF5581" Font-Size="Large" Font-Bold="true" Text="Restaurant Info"></asp:Label>--%>
                        <div class="row mt-4 mb-5">
                            <div class="col-lg-12">
                                <h4 class="mt-4 mb-4">Account Balance</h4>
                                <asp:Label ID="Label1" runat="server" Text="Current Balance:"></asp:Label>


                                <div class="col-lg-12">
                                    <asp:Label ID="lblBalance" Font-Bold="true" runat="server" Text=""></asp:Label>
                                    <%--<asp:LinkButton ForeColor="#FF5581" ID="lbUpdateName" runat="server">Update</asp:LinkButton>--%>
                                </div>
                            </div>
                        </div>
                        <div class="row mt-4">
                            <div class="col-lg-3">
                                <asp:Label ID="Label5" runat="server" Text="Enter amount to add to balance:"></asp:Label>
                            </div>
                            <div class="col-lg-7">
                                <asp:TextBox ID="txtAmount" runat="server" Font-Italic="true" CssClass="form-control" Text=""></asp:TextBox>
                            </div>
                        </div>

                        <div class="m-4 text-center">
                            <div class="pb-4">
                                <asp:Label ID="lblErrorDisplay" Visible="false" runat="server" Text="Please enter a decimal value"></asp:Label>
                                <asp:Label ID="lblFunded" Visible="false" runat="server" Text="The account was successfully funded"></asp:Label>

                            </div>
                            <asp:Button ID="btnFundAccount" runat="server" Text="Fund Account" OnClick="btnFundAccount_Click" CssClass="contact-form-button" />
                        </div>
                        <hr />
                        <h4 class="mt-4 mb-4">Payment Info</h4>
                        <asp:Repeater ID="rptPaymentInfo" runat="server">
                            <ItemTemplate>
                                <%--<asp:Label ID="Label6" runat="server" ForeColor="#FF5581" Font-Size="Large" Font-Bold="true" Text="Restaurant Info"></asp:Label>--%>
                                <asp:HiddenField ID="hfRestaurantID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Restaurant_ID") %>' />
                                <div class="row mt-5">
                                    <div class="col-lg-3">
                                        <asp:Label ID="Label2" runat="server" Text="Restaurant Name / Account Name:"></asp:Label>
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox ID="txtAccountName" runat="server" Font-Italic="true" CssClass="form-control" Text='<%# DataBinder.Eval(Container.DataItem, "Restaurant_Name") %>'></asp:TextBox>
                                    </div>                                  
                                </div>
                                <div class="row mt-5">
                                    <div class="col-lg-3">
                                        <asp:Label ID="Label1" runat="server" Text="Restaurant Payment Account Type:"></asp:Label>
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox ID="txtAccountType" runat="server" Font-Italic="true" CssClass="form-control" Text='<%# DataBinder.Eval(Container.DataItem, "Payment_Account_Type") %>'></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row mt-4">
                                    <div class="col-lg-3">
                                        <asp:Label ID="Label5" runat="server" Text="Restaurant Payment Account Number:"></asp:Label>
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox ID="txtAccountNumber" runat="server" Font-Italic="true" CssClass="form-control" Text='<%# DataBinder.Eval(Container.DataItem, "Payment_Account_Number") %>'></asp:TextBox>
                                    </div>
                                </div>

                            </ItemTemplate>
                        </asp:Repeater>
                        <div class=" mt-3 text-center">
                            <div class="pb-4">
                                <asp:Label ID="lblPaymentUpdatedMsg" Visible="false" runat="server" Text="Your payment info was successfully updated."></asp:Label>
                            </div>
                        </div>
                        <div class="mb-5 mt-3 text-center">
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="contact-form-button" />
                        </div>

                    </asp:Panel>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
