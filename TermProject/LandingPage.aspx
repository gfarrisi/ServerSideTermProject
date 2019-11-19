<%@ Page Title="" Language="C#" MasterPageFile="~/FoodOrder.Master" AutoEventWireup="true" CodeBehind="LandingPage.aspx.cs" Inherits="TermProject.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <form id="form1" class runat="server">
         <h2 style="text-align:center;">Restaurants List</h2>
         <br />
         <div class="container">
             <div class="row">
                 <div class="col-md-2">

                 </div>
                 <div class="col-md-8">
                     <div class="input-group md-form form-sm form-2 pl-0">
                         <input class="form-control my-0 py-1 red-border" type="text" placeholder="Search" aria-label="Search">
                         <div class="input-group-append">
                             <asp:LinkButton ID="linkBtnSearch" runat="server"><span class="input-group-text alert-warning lighten-3" id="spnSearch" style="padding: .65rem .75rem"><i class="fa fa-search text-grey"
                                 aria-hidden="true"></i></span></asp:LinkButton>
                         </div>
                     </div>
                 </div>
             </div>
             <br />
             <div class="row">
             <div class="col-md-6" id="divRestaurantColumn" runat="server">


             </div>
             <div class="col-md-6" id="divRestaurantColumn2" runat="server">

             </div>
                 </div>
         </div>
         </form>
</asp:Content>
