﻿<%@ Page Title="" Language="C#" MasterPageFile="~/FoodOrder.Master" AutoEventWireup="true" CodeBehind="LandingPage.aspx.cs" Inherits="TermProject.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
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

                document.getElementById("ajaxtest").innerHTML = xmlhttp.responseText;
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <h2 style="text-align: center;">Restaurants List</h2>
        <br />
        <div class="container">
            <div class="row">
                <div class="col-md-2">
                </div>
                <div class="col-md-8">
                    <div class="input-group md-form form-sm form-2 pl-0">                 
                        <input class="form-control my-0 py-1 red-border" type="text" placeholder="Search" aria-label="Search" id="search" onkeyup="getSearch()">
                        <div class="input-group-append">
                            <asp:LinkButton ID="linkBtnSearch" OnClick="linkBtnSearch_Click" runat="server"><span class="input-group-text alert-warning lighten-3" id="spnSearch" style="padding: .65rem .75rem"><i class="fa fa-search text-grey"
                                 aria-hidden="true"></i></span></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-6" id="divRestaurantColumn" runat="server">
                </div>
                <div class="col-md-6" id="divRestaurantColumn2" runat="server">
                </div>
            </div>
            <div class="row">
                <div class="col-md-12" id="ajaxtest">

                </div>
            </div>
        </div>
    </form>
</asp:Content>