<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterMerchant.aspx.cs" Inherits="MerchantRegistration.RegisterMerchant" %>
<!DOCTYPE html>
<html lang="en">

<head>

  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="">
  <meta name="author" content="">

 <%--  <link rel="shortcut icon" href="img/logo.png" />--%>
  <title>Boston Payments</title>

  <!-- Bootstrap core CSS -->
  <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">

  <!-- Custom fonts for this template -->
  <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
  <link href="https://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet" type="text/css">
  <link href='https://fonts.googleapis.com/css?family=Kaushan+Script' rel='stylesheet' type='text/css'>
  <link href='https://fonts.googleapis.com/css?family=Droid+Serif:400,700,400italic,700italic' rel='stylesheet' type='text/css'>
  <link href='https://fonts.googleapis.com/css?family=Roboto+Slab:400,100,300,700' rel='stylesheet' type='text/css'>
  <link href="https://fonts.googleapis.com/css?family=Titillium+Web" rel='stylesheet' type='text/css'>
  <!-- Custom styles for this template -->
  <link href="css/agency.min.css" rel="stylesheet">
  <link href="css/agency.css" rel="stylesheet">


</head>

<body id="page-top">

    <!-- Navigation -->
    <nav class="navbar navbar-expand-lg navbar-dark fixed-top" id="mainNav">
        <div class="container">
            <a class="navbar-brand js-scroll-trigger" href="#page-top">Boston Payments</a>
            <!--<a class="navbar-brand navbar-logo js-scroll-trigger" href="#page-top"><img src="img/logos/sound-sol-white.png"></a>-->
            <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
                Menu
                <i class="fas fa-bars"></i>
            </button>
            <div class="collapse navbar-collapse" id="navbarResponsive">
                <ul class="navbar-nav text-uppercase ml-auto">
                    <li class="nav-item">
                        <a class="nav-link js-scroll-trigger" href="#services"></a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link js-scroll-trigger" href="#portfolio"></a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link js-scroll-trigger" href="#about"></a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link js-scroll-trigger" href="#team"></a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link js-scroll-trigger" href="#contact"></a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>

 
    <!-- Contact -->
    <section id="contact">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 text-center">
                    <h2 class="section-heading text-uppercase">Register for Boston Payments</h2>
                    <h3 class="section-subheading">We look forward to working with you!</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <form id="contactForm" name="sentMessage" novalidate="novalidate" runat="server">
                        <div class="row">
                              <div class="col-md-3"></div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtMerchantName" placeholder="Merchant Name *" runat="server" required="true"></asp:TextBox>
                                    <p class="help-block text-danger"></p>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtMerchantID" placeholder="Merchant ID *" runat="server" required="true"></asp:TextBox>
                                    <p class="help-block text-danger"></p>
                                </div>  
                                <div class="form-group">
                                    <asp:Label CssClass="help-block text-danger" ID="lblError" Visible="false" runat="server" Text="error"></asp:Label>
                                </div> 
                            </div>
                           
                            <div class="clearfix"></div>
                            <div class="col-lg-12 text-center">
                                <div id="success"></div>
                                <asp:Button ID="btnRegister" CssClass="btn btn-primary btn-xl text-uppercase" runat="server" Text="Register" OnClick="btnRegisterMerchant_Click" />
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </section>

    <!-- Footer -->
    <footer>
        <div class="container">
            <div class="row">
                <div class="col-md-4">
                    <span class="copyright">Copyright &copy; Boston Payments 2019</span>
                </div>
                <div class="col-md-4">
                    
                </div>
                <div class="col-md-4">
                    <ul class="list-inline quicklinks">
                        <li class="list-inline-item">
                            <a href="#">Privacy Policy</a>
                        </li>
                        <li class="list-inline-item">
                            <a href="#">Terms of Use</a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </footer>
        <!-- Bootstrap core JavaScript -->
        <script src="vendor/jquery/jquery.min.js"></script>
        <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

        <!-- Plugin JavaScript -->
        <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

        <!-- Contact form JavaScript -->
        <script src="js/jqBootstrapValidation.js"></script>
       <%-- <script src="js/contact_me.js"></script>--%>

        <!-- Custom scripts for this template -->
        <script src="js/agency.min.js"></script>

</body>

</html>

