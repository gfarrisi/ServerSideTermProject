<%@ Page Title="" Language="C#" MasterPageFile="~/RestaurantRepView.Master" AutoEventWireup="true" CodeBehind="RestaurantLanding.aspx.cs" Inherits="TermProject.RestaurantLanding" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

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


                    </div>
                </div>
                <div class="col-md-8 ml-3  mt-5">
                    <asp:Panel ID="Panel1" runat="server" CssClass="p-3 text-center">
                        <h4 class="mt-4">No menu found for your restaurant.</h4>
                        <asp:Button ID="btnStartMenu" runat="server" Text="Start New Menu" CssClass="contact-form-button m-4" />
                    </asp:Panel>

                    <div class="input-group md-form form-sm form-2 pl-0">
                    </div>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-6" id="newrow" runat="server">
                </div>
                <div class="col-md-6" id="newrow2" runat="server">
                </div>
            </div>
            <div class="row">
                <div class="col-md-12" id="ajaxtest">
                </div>
            </div>
        </div>
    </form>
</asp:Content>
