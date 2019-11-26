<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuItemControl.ascx.cs" Inherits="TermProject.MenuItemControl" %>
<div class="trend-item">
    <div class="trend-pic">
        <img id="imgMenuItem" src="img/trending/trending-1.jpg" alt="" runat="server">
        <div class="rating" id="txtPrice" runat="server">$3.25</div>
    </div>
    <div class="trend-text">
        <h4 id="txtItemName" runat="server">Menu Item</h4>
        <span id="txtItemDescription" runat="server">Description</span> <br />
        <asp:Repeater ID="repeaterCustomControls" runat="server" OnItemDataBound="OnItemDataBound"> 
            <ItemTemplate>
                <label id="txtCustomControl" runat="server">
                    <%-- Add control name here (size, toppings, etc) --%>
                </label>
                <asp:DropDownList ID="ddlCustomControl" runat="server">
                    <%-- Add dropdown value items here --%>
                </asp:DropDownList>
            </ItemTemplate>
        </asp:Repeater>
    <asp:Button ID="btnAddToCart" CssClass="contact-form-button" Text="Add To Cart" runat="server" />
    </div>
   <div class="tic-text">Menu Item</div>
</div>