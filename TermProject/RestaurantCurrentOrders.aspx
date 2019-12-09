<%@ Page Title="" Language="C#" MasterPageFile="~/RestaurantRepView.Master" AutoEventWireup="true" CodeBehind="RestaurantCurrentOrders.aspx.cs" Inherits="TermProject.RestaurantCurrentOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server">

    </asp:ScriptManager>
   
        <div class="container pt-5" style="padding-top: 10%;">
            <div class="row pt-5">
                <div class="col-md-3 mt-5" style="background-color: #4D4D4D; display: table;">
                    <div class="pt-5 pb-5 pl-4 pr-4">
                        <h4 class="" style="color: white">Restaurant Options</h4>
                        <hr style="background-color: #FF5581" />
                        <div class="pt-3 pl-2">
                            <asp:LinkButton ID="lbMenuManagement" runat="server" OnClick="lbMenuManagement_Click" ForeColor="White" CssClass="pt-4">Menu Management</asp:LinkButton>
                        </div>
                        <div class="pt-3 pl-2">
                            <asp:LinkButton ID="lbAccountSettings" runat="server" OnClick="lbAccountSettings_Click" ForeColor="White" CssClass="mt-5">Account Settings</asp:LinkButton>
                        </div>
                        <div class="pt-3 pl-2">
                            <asp:LinkButton ID="lbPaymentInfo" runat="server" OnClick="lbPaymentInfo_Click" ForeColor="White" CssClass="pt-4">Payment Info</asp:LinkButton>
                        </div>
                        <div class="pt-3 pl-2">
                            <asp:LinkButton ID="lbCurrentOrders" ForeColor="White" OnClick="lbCurrentOrders_Click" runat="server">Current Orders</asp:LinkButton>
                        </div>
                        <hr style="background-color: #FF5581" />
                        <div>
                            <asp:Repeater ID="rptContactInfo" runat="server">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hfRestaurantID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Restaurant_ID") %>' />
                                    <div class="pt-3 pl-2">
                                    <asp:Label ID="lbPhoneNumber" ForeColor="White" runat="server" CssClass="mt-5" Text='<%# DataBinder.Eval(Container.DataItem, "Restaurant_Phone") %>'></asp:Label>
                                    </div>
                                    <div class="pt-3 pl-2">
                                        <asp:Label ID="lbEmail" runat="server" ForeColor="White" CssClass="pt-4" Text='<%# DataBinder.Eval(Container.DataItem, "Restaurant_Email") %>'></asp:Label>
                                    </div>
                                    <div class="pt-3 pl-2">
                                        <asp:Label ID="lbAddress" ForeColor="White" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Restaurant_Address") %>'></asp:Label>
                                    </div>
                                    <div class="pt-3 pl-2">
                                        <asp:Label ID="lbCityStateZip" ForeColor="White" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Restaurant_City") + ", " + DataBinder.Eval(Container.DataItem, "Restaurant_State") + " " + DataBinder.Eval(Container.DataItem, "Restaurant_Zip") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
                <div class="col-md-9  mt-5">

                    <h4 style="text-align:center;">Update Orders</h4>
                    <br />
                    <asp:UpdatePanel ID="upOrder" style="width: 100%" runat="server">
                        <ContentTemplate>
                            <asp:Timer ID="tmOrderStatus" OnTick="tmOrderStatus_Tick" runat="server" Interval="35000" />
                            <asp:GridView ID="gvOrders" runat="server" CssClass="table table-borderless table-striped" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="Order_ID" HeaderText="Order ID" />
                                    <asp:BoundField DataField="Order_Customer_Email" HeaderText="Customer Name" />
                                    <asp:BoundField DataField="Order_Time" HeaderText="Time" />
                                    <asp:BoundField DataField="Order_Total_Cost" DataFormatString="{0:c2}" HeaderText="Price" />
                                    <asp:TemplateField HeaderText="Change Status">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" SelectedValue='<%# Bind("Order_Status") %>'>
                                                <asp:ListItem Value="Not Submitted" Enabled="false">Not Submitted</asp:ListItem>
                                                <asp:ListItem Value="Submitted">Submitted</asp:ListItem>
                                                <asp:ListItem Value="Being Prepared">Being Prepared</asp:ListItem>
                                                <asp:ListItem Value="Being Delivered">Being Delivered</asp:ListItem>
                                                <asp:ListItem Value="Completed">Completed</asp:ListItem>
                                                <asp:ListItem Value="Problem">Problem</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Updated?">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUpdate" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                       <asp:AsyncPostBackTrigger ControlID="tmOrderStatus" EventName="Tick" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
   
</asp:Content>
