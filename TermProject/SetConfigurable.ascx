<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SetConfigurable.ascx.cs" Inherits="TermProject.SetConfigurable" %>
<div class="trend-item" style="border: 10px groove rosybrown">
    <label>Configurable Name:</label><asp:TextBox CssClass="contact-form-input" ID="txtConfigurableName" placeholder="Size, Sauce, Flavor, etc" runat="server"></asp:TextBox>
                <h6 style="color:deeppink">Enter each value on its own line in the textbox below.</h6>
    <label>Configurable Values:</label><asp:TextBox CssClass="form-control" ID="txtConfigurableValues" TextMode="MultiLine" Rows="5" runat="server"></asp:TextBox>
</div>
