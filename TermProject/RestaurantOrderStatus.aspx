<%@ Page Title="" Language="C#" MasterPageFile="~/RestaurantRepView.Master" AutoEventWireup="true" CodeBehind="RestaurantOrderStatus.aspx.cs" Inherits="TermProject.RestaurantOrderStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="scriptman" runat="server">
        </asp:ScriptManager>


        <div class="container" style="padding-top: 10%;">
            <div class="row">
                <div class="col-1">
                </div>
                <div class="col-10" style="text-align: center;">
                    <h2>Update Orders</h2>
                    <br />
                    <asp:UpdatePanel ID="upOrder" style="width: 100%" runat="server">
                        <ContentTemplate>
                            <asp:Timer ID="tmOrderStatus" OnTick="tmOrderStatus_Tick" runat="server" Interval="35000" />

                            <asp:Repeater ID="rptOrders" runat="server">
                            </asp:Repeater>

                            <asp:GridView ID="gvOrders" runat="server" CssClass="table table-borderless table-striped" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="Order_ID" HeaderText="Order ID" />
                                    <asp:BoundField DataField="Order_Customer_Email" HeaderText="Customer Name" />
                                    <asp:BoundField DataField="Order_Time" HeaderText="Time" />
                                    <asp:BoundField DataField="Order_Total_Cost" DataFormatString="{0:c2}" HeaderText="Price" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                                <asp:ListItem Value="Submitted">Submitted</asp:ListItem>
                                                <asp:ListItem Value="Being Prepared">Being Prepared</asp:ListItem>
                                                <asp:ListItem Value="Being Delivered">Being Delivered</asp:ListItem>
                                                <asp:ListItem Value="Completed">Completed</asp:ListItem>
                                                <asp:ListItem Value="Problem">Problem</asp:ListItem>
                                            </asp:DropDownList>
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
        <br />
    </form>
</asp:Content>
