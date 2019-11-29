﻿<%@ Page Title="" Language="C#" MasterPageFile="~/FoodOrder.Master" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="TermProject.AddItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        h1, h2, h3, h4, h5, h6 {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <h2>Add/Edit a Menu Item</h2>
        <br />
        <div class="container">
            <div class="row">
                <div class="col-lg-2"></div>
                <div class="col-lg-8">
                    <div class="row">
                        <div class="col-lg-6">
                            <label>Item Name:</label><asp:TextBox CssClass="contact-form-input" ID="txtItemName" placeholder="Item Name" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-lg-6">
                            <label>Item Image (URL Format)</label>
                            <asp:TextBox CssClass="contact-form-input" ID="txtItemImg" placeholder="Image URL" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-lg-6">
                            <label>Description</label><asp:TextBox CssClass="contact-form-input" ID="txtItemDescription" TextMode="MultiLine" Rows="2" placeholder="Description" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-lg-6">
                            <label>Price ($)</label><asp:TextBox CssClass="contact-form-input" ID="txtItemPrice" placeholder="0.00" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <h3>Configurable Items</h3>
                    <div class="row">
                        <div class="col-lg-12">     
                            <asp:Button ID="btnRemoveConfigurables" CssClass="btn btn-link" Text="Remove Configurables" OnClick="btnRemoveConfigurables_Click" runat="server" />
                        </div>
                        <div class="col-lg-6">
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                            <asp:UpdatePanel ID="panelConfigure" runat="server">
                                 <contenttemplate>
                                 </contenttemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col-lg-6" style="border:8px groove rosybrown;border-radius:5px;padding:20px;">
                              <label>Configurable Name:</label><asp:TextBox CssClass="contact-form-input" ID="txtConfigurableName" placeholder="Size, Sauce, Flavor, etc" runat="server"></asp:TextBox>
                <h6 style="color:deeppink">Enter each value on its own line in the textbox below.</h6>
    <label>Configurable Values:</label><asp:TextBox CssClass="form-control" ID="txtConfigurableValues" TextMode="MultiLine" Rows="5" runat="server"></asp:TextBox>
                       <br />
                            <asp:Button ID="btnAddConfigurable" CssClass="btn btn-secondary" Text="Add Configurable" OnClick="btnSubmit_Click" style="width:100%;" runat="server" />
                        </div>
                        </div>
                        <br />
                    <hr />
                        <div class="row">
                            
                            <div class="col-lg-3">
                            </div>
                            <div class="col-lg-6">
                                <asp:Button ID="btnSubmit" CssClass="contact-form-button-2" Text="Add Item To Menu" OnClick="btnSubmit_Click" style="width:100%;" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </form>
</asp:Content>
