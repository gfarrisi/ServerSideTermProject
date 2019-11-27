<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RestaurantControl.ascx.cs" Inherits="TermProject.RestaurantControl" %>
<%--    <link rel="stylesheet" href="css/bootstrap.min.css" type="text/css">
    <link rel="stylesheet" href="css/font-awesome.min.css" type="text/css">
    <link rel="stylesheet" href="css/flaticon.css" type="text/css">
    <link rel="stylesheet" href="css/nice-select.css" type="text/css">
    <link rel="stylesheet" href="css/owl.carousel.min.css" type="text/css">
    <link rel="stylesheet" href="css/magnific-popup.css" type="text/css">
    <link rel="stylesheet" href="css/slicknav.min.css" type="text/css">
    <link rel="stylesheet" href="css/style.css" type="text/css">--%>
<div class="trend-item">
    <div class="trend-pic">
        <img id="imgRestaurant" src="img/trending/trending-1.jpg" alt="" runat="server">
    </div>
    <div class="trend-text">
        <h4 id="txtRestaurantName" runat="server">New Place Restaurant</h4>
        <span id="txtAddress" runat="server">Main Road , No 25/11</span> <br />
    <asp:Button ID="btnRegister" CssClass="contact-form-button" Text="View" runat="server" OnClick="btnRegister_Click" />
    </div>
   <div class="tic-text">Restaurant</div>
</div>
