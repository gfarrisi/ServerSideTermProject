<%@ Page Title="" Language="C#" MasterPageFile="~/FoodOrder.Master" AutoEventWireup="true" CodeBehind="ChooseAccountType.aspx.cs" Inherits="TermProject.ChooseAccountType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">

        <!-- Page Preloder -->
        <div id="preloder">
            <div class="loader"></div>
        </div>

        <!-- Header Section Begin -->
        <header class="header-section listings">
            <div class="container-fluid">
                <div class="logo">
                    <a href="./index.html">
                        <img src="img/logo0.png" alt=""></a>

                </div>
                <nav class="main-menu mobile-menu">
                </nav>
                <div class="header-right">
                    <div class="user-access">
                        <a href="Login.aspx">Register/Login</a>
                    </div>

                </div>
                <div id="mobile-menu-wrap"></div>
            </div>
        </header>
        <!-- Contact Section Begin -->
        <section class="contact-section spad" style="padding-top: 12%;">
            <div class="container">
                <div class="row">

                    <div class="col-lg-4">
                    </div>
                    <div class="col-lg-4 mb-4">
                        <div align="center">
                            <h2>Choose Account Type</h2>
                            <br />
                            <br />
                        </div>
                    </div>
                </div>
                <div class="contact-form">
                    <div class="row">
                        <div class="col-lg-4"></div>

                        <div class="col-lg-6">
                            <div class="ml-3">
                                <asp:Button ID="btnCustomer" runat="server" OnClick="btnCustomer_Click" Text="I am a Customer" CssClass="contact-form-button p-5 ml-5" />

                            </div>
                            <br />
                            <br />
                            <div>
                                <asp:Button ID="btnRestaurantRep" runat="server" OnClick="btnRestaurantRep_Click" Text="I am a Restaurant Representative" CssClass="contact-form-button p-5 mr-5" />

                            </div>

                        </div>
                        <div class="col-lg-5">
                        </div>
                    </div>
                    <div class="col-lg-12 text-center">
                        <div class="mb-1 mt-5">
                            <asp:LinkButton ID="lbLogin" runat="server" OnClick="lbLogin_Click" CssClass="mt-5"> Back to Log In >></asp:LinkButton>
                        </div>
                    </div>
                </div>


            </div>
        </section>

    </form>

</asp:Content>
