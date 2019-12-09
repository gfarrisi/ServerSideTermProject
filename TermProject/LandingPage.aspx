<%@ Page Title="" Language="C#" MasterPageFile="~/UserView.Master" AutoEventWireup="true" CodeBehind="LandingPage.aspx.cs" Inherits="TermProject.WebForm1" %>

<%@ Register src="RestaurantControl.ascx" tagname="RestaurantControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%--    <script type="text/javascript">
        var xmlhttp = new XMLHttpRequest();

        function getSearch() {
            console.log("Happening");
            var params = "search=" + document.getElementById("search").value;
            // Open a new asynchronous request, set the callback function, and send the request.
            xmlhttp.open("GET", "SearchResults.aspx?" + params, true);
            xmlhttp.setRequestHeader("Content-Type", "application-json");
            xmlhttp.onreadystatechange = onComplete;
            xmlhttp.send();
        }

        // Callback function used to update the page when the server completes a response

        // to an asynchronous request.

        function onComplete() {

            //Response is READY and Status is OK

            if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                //document.getElementById("startResults").innerHTML = "";
                document.getElementById("ajaxtest").innerHTML = xmlhttp.responseText;
            }
        }

    </script>--%>
    <script type="text/javascript">
        function RefreshUpdatePanel() {
            __doPostBack('<%= txtSearch.ClientID %>', '');
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<form id="form1" runat="server">--%>
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <section class="contact-section spad" id="secContent" runat="server" visible="true">
        <h2 style="text-align: center; padding-top: 3%; padding-bottom: 2%;">Restaurants List</h2>
        <br />

        <div class="container">
            <div class="row">
                <div class="col-md-2">
                </div>
                <div class="col-md-8">
                    <div class="input-group md-form form-sm form-2 pl-0">
                        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control my-0 py-1 red-border" placeholder="Start typing to search" AutoPostBack="true" OnTextChanged="txtSearch_TextChanged" onkeyup="RefreshUpdatePanel()"></asp:TextBox>
                        <%--          <input class="form-control my-0 py-1 red-border" type="text" placeholder="Start typing to search" aria-label="Search" id="search" onkeyup="getSearch()">--%>
                        <asp:Button Cssclass="btn btn-warning" Text="🔍" runat="server" ID="btnSearch" OnClick="btnSearch_Click" >
                        </asp:Button>
                    </div>
                </div>
            </div>
            <br />
            <asp:UpdatePanel ID="upSearch" runat="server">
                <ContentTemplate>
                    <div class="row" id="startResults">
                        <div class="col-md-6" id="divRestaurantColumn" runat="server">
                        </div>
                        <div class="col-md-6" id="divRestaurantColumn2" runat="server">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12" id="ajaxtest">
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <%--<asp:AsyncPostBackTrigger ControlID="txtSearch" EventName="TextChanged" />--%>
                 <asp:AsyncPostBackTrigger ControlID="txtSearch" EventName="TextChanged" />
                    <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </section>
</asp:Content>
