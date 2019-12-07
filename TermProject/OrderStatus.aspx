<%@ Page Title="" Language="C#" MasterPageFile="~/UserView.Master" AutoEventWireup="true" CodeBehind="OrderStatus.aspx.cs" Inherits="TermProject.OrderStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Order Status
    </title>
    <style>
        .lbl {
            font-weight: bold;
            color: dimgray;
        }

        .changed {
            font-size: 18px;
            color: seagreen;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="scriptman" runat="server">
        </asp:ScriptManager>


        <div class="container" style="padding-top: 10%;">
            <div class="row">
                <div class="col-1">
                </div>
                <div class="col-10" style="text-align:center;">
                    <h2>Order Status</h2>
                    <br />
                    <asp:UpdatePanel ID="upOrder" style="width: 100%" runat="server">
                        <ContentTemplate>
                            <asp:Timer ID="tmOrderStatus" OnTick="tmOrderStatus_Tick" runat="server" Interval="5000" />
                            <div>
                                <asp:Label runat="server" CssClass="lbl" Text="Order ID: "></asp:Label>
                                <asp:Label ID="lblID" runat="server"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Time: "></asp:Label>
                                <asp:Label ID="lblTime" runat="server"> </asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Cost: "></asp:Label>
                                <asp:Label ID="lblCost" runat="server"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Status: "></asp:Label>
                                <b style="color:seagreen;font-size:1.5em;"><asp:Label ID="lblStatus" runat="server"></asp:Label></b>
                            </div>
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
