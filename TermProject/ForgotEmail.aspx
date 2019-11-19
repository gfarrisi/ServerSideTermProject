<%@ Page Title="" Language="C#" MasterPageFile="~/FoodOrder.Master" AutoEventWireup="true" CodeBehind="ForgotEmail.aspx.cs" Inherits="TermProject.Forgot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" class="contact-form">

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
        <section class="contact-section spad" style="padding-top: 10%;">
            <div class="container">
                <div class="row">

                    <div class="col-lg-4">
                    </div>
                    <div class="col-lg-4">
                        <div align="center">
                            <h2>Forgot Email</h2>
                                <br /><br /><br />

                        
                        </div>
                        <div class="contact-form">
                            <div class="mb-2">
                                <asp:Label ID="lblEnterEmail" runat="server" Text="Please enter backup contact email" CssClass="mb-5"></asp:Label>
                            </div>

                            <div class="row">
                                <div class="col-lg-12">
                                    <asp:TextBox CssClass="contact-form-input" ID="txtEmail" runat="server" placeholder="Your Contact Email"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-12 text-center">
                                <div class="mb-1 mt-5">
                                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" CssClass="contact-form-button" />
                                </div>
                                <br />
                                <br />


                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

    </form>
</asp:Content>
