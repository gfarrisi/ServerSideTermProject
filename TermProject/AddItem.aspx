<%@ Page Title="" Language="C#" MasterPageFile="~/RestaurantRepView.Master" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="TermProject.AddItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        h1, h2, h3, h4, h5, h6 {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container mb-5" style="padding-top: 8%;">
        <h2 class="pb-3">Add/Edit a Menu Item</h2>

        <br />
        <div class="row">
            <div class="col-lg-2"></div>
            <div class="col-lg-8">
                <hr />
                <div class="row">
                    <div class="col-lg-6">
                        <label>Item Name:</label><asp:TextBox CssClass="contact-form-input" ID="txtItemName" placeholder="Item Name" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-6">
                        <label>Item Image (URL Format)</label>
                        <asp:TextBox CssClass="contact-form-input" ID="txtItemImg" placeholder="Image URL" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-6">
                        <label>Description</label><asp:TextBox CssClass="contact-form-input" ID="txtItemDescription" placeholder="Description" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-6">
                        <label>Price ($)</label><asp:TextBox CssClass="contact-form-input" ID="txtItemPrice" placeholder="0.00" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-6">
                        <label>Category</label>
                        <asp:DropDownList  CssClass="nice-select" Style="height: 58px; width: 100%;" ID="ddlCategory" runat="server" required>
                            <asp:ListItem Value="Not Specified" Selected="True" disabled="disabled">Category</asp:ListItem>
                            <asp:ListItem Value="Appetizers">Appetizers</asp:ListItem>
                            <asp:ListItem Value="Salads">Salads</asp:ListItem>
                            <asp:ListItem Value="Entrees">Entrees</asp:ListItem>
                            <asp:ListItem Value="Desserts">Desserts</asp:ListItem>
                            <asp:ListItem Value="Sides">Sides</asp:ListItem>
                            <asp:ListItem Value="Drinks">Drinks</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row pt-2 pb-3 ">
                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <asp:Label ID="Label1" CssClass="pl-2" Font-Size="Large" ForeColor="#FF5581" runat="server" Text="Configurable Items"></asp:Label><br />
                        <asp:Button ID="btnRemoveConfigurables" CssClass="btn btn-link" Text="Remove Configurables" OnClick="btnRemoveConfigurables_Click" runat="server" />
                    </div>
                    <div class="col-lg-6">
                        <asp:GridView ID="gvConfigurables" runat="server" AutoGenerateColumns="false" CssClass="table table-responsive-md table-striped table-bordered">
                            <Columns>
                                <asp:BoundField DataField="Title" HeaderText="Title" />
                                <asp:BoundField DataField="ValuesList" HeaderText="Values" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="col-lg-6" style="border: 5px solid #4D4D4D; border-radius: 5px; padding: 20px;">
                        <label id="configurableWarning" runat="server" style="color: #FF5581; font-size: .75em;"></label>
                        <label>Configurable Name:</label>
                        <asp:TextBox CssClass="contact-form-input" ID="txtConfigurableName" placeholder="Size, Sauce, Flavor, etc" runat="server" EnableViewState="false"></asp:TextBox>
                        <label style="color: deeppink; font-size: .75em;">Enter each value on its own line in the textbox below.</label>
                        <label>Configurable Values:</label>
                        <asp:TextBox CssClass="form-control" ID="txtConfigurableValues" TextMode="MultiLine" Rows="5" runat="server"></asp:TextBox>
                        <br />
                        <asp:Button ID="btnAddConfigurable" CssClass="btn btn-secondary" Text="Add Configurable" OnClick="btnAddConfigurable_Click" Style="width: 100%; background: #1d1d1d; opacity: 0.79" runat="server" />
                    </div>
                </div>
                <br />
                <hr />
                <div class="row pt-3">
                    <div class="col-lg-3">
                    </div>
                    <div class="col-lg-6">
                        <asp:Button ID="btnSubmit" CssClass="contact-form-button" Text="Add Item To Menu" OnClick="btnSubmit_Click" Style="width: 100%;" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
