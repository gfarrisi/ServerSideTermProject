<%@ Page Title="" Language="C#" MasterPageFile="~/FoodOrder.Master" AutoEventWireup="true" CodeBehind="AccountSettings.aspx.cs" Inherits="TermProject.AccountSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
    <asp:Button ID="btnViewAll" runat="server" Text="View All Transactions" OnClick="btnViewAll_Click" />

    </form>
</asp:Content>
