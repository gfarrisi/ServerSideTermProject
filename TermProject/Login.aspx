<%@ Page Title="" Language="C#" MasterPageFile="~/FoodOrder.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TermProject.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .login {
            color: #fff;
            font-size: 20px;
            border: 1px solid #FF5581;
            background: #FF5581;
            padding: 6px 42px;
            cursor: pointer;
            display: inline-block;
        }
    </style>
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
                <a href="./index.html"><img src="img/logo0.png" alt=""></a>
              
            </div>
            <nav class="main-menu mobile-menu">
                
            </nav>
            <div class="header-right">
                <div class="user-access">
                    <a href="#">Register/</a>
                    <a href="#">Login</a>
                </div>
             
            </div>
            <div id="mobile-menu-wrap"></div>
        </div>
    </header>
        <!-- Contact Section Begin -->
    <section class="contact-section spad" style="padding-top:12%;">
        <div class="container">
            <div class="row">
               
                 <div class="col-lg-4">
                     </div>
                <div class="col-lg-4">
                      <div align="center">
                                 <h2 >Log in to Locals</h2><br /><br />
                            </div>
                    <div class="contact-form">
                        <div class="row">
                          
                           
                            <div class="col-lg-12">
                                <input class="contact-form-input" type="text" placeholder="Your Email">
                            </div>
                            <div class="col-lg-12">
                                <input class="contact-form-input" type="password" placeholder="Your Password">
                            </div>
                        </div>
                    <div class="col-lg-12 text-center">                               
                         <button type="submit">Log In</button><br /><br />
                         
                          <asp:LinkButton ID="lbForgotEmail" runat="server" OnClick="lbForgotEmail_Click">Forgot Email?</asp:LinkButton><br />
                                    <asp:LinkButton ID="lbForgotPassword" runat="server" OnClick="lbForgotPassword_Click">Forgot Password?</asp:LinkButton>   

                         <br /><br />
                        <span style="padding-right:5px;">New to Locals? </span>
                         <asp:LinkButton ID="lbCreateAccount" runat="server" OnClick="lbCreateAccount_Click"> Sign up now >></asp:LinkButton> 
                       
                </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

</form>
</asp:Content>
