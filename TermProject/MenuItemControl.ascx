<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuItemControl.ascx.cs" Inherits="TermProject.MenuItemControl" %>
<div class="trend-item">
    <div class="trend-pic">
        <img id="imgMenuItem" src="img/trending/trending-1.jpg" alt="" runat="server">
        <div class="rating" id="txtPrice" runat="server">$3.25</div>
    </div>
    <div class="trend-cat">
        <asp:Repeater ID="repeaterCustomControls" runat="server" OnItemDataBound="OnItemDataBound">
            <ItemTemplate>
                <asp:Label ID="lblItemConfigurableTitle" runat="server" CssClass="pt-4 font" Text='<%# DataBinder.Eval(Container.DataItem, "Configurable_Title") %>'></asp:Label>
                <asp:DropDownList ID="ddItemConfigurableValues" CssClass="nice-select-tiny form-controls" runat="server">
                </asp:DropDownList>
                <br />
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="trend-text">
        <asp:HiddenField runat="server" ID="hfMenuItemID" />
        <h4 id="txtItemName" runat="server">Menu Item</h4>
        <span id="txtItemDescription" runat="server">Description</span> <br />


    <asp:Button ID="btnAddToCart" CssClass="contact-form-button" Text="Add To Cart" OnClick="btnAddToCart_Click" runat="server" />
    </div>
   <div class="tic-text">Menu Item</div>
</div>
