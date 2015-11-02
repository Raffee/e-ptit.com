<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Site.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="e_PTIT.Pages.ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="http://code.jquery.com/jquery-1.11.1.min.js"></script>

    <script src="http://code.jquery.com/ui/1.11.1/jquery-ui.min.js"></script>

    <link rel="stylesheet" href="https://code.jquery.com/ui/1.11.1/themes/smoothness/jquery-ui.css" />

    <title>Contact Us</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="margin-top: 130px !important; width: 100%;" class="text-center">
        <div class="text-center">

            <img src="../images/header/aylKhager.jpg" />
        </div>
        <div class="text-center">
            <img src="../images/contactus_title.png" />
        </div>
    </div>
    <div class="dt-sc-hr-small"></div>
    <!--end of page title -->
    <div style="text-align: left; color: black;">
        <div class="h2" style="color: black;">We will be very happy to have your feedback</div>
        <div class="h3" style="color: black;">Please contact as at the following addresses:</div>

        <div class="h4" style="color: black;">P.O. BOX: 11-9730 Beirut-Lebanon</div>
        <div class="h4" style="color: black;">Email: <a href="mailto:ptit.vega@gmail.com">Ptit.vega@gmail.com</a></div>
        <div class="row">
            <div class="col-md-3 h4">Name:*</div>
            <div class="col-md-6">
                <asp:TextBox ID="txtName" runat="server" Width="60%" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-3 h4">E-Mail:*</div>
            <div class="col-md-6">
                <asp:TextBox ID="txtEmail" TextMode="Email" runat="server" Width="60%" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-3 h4">Country:*</div>
            <div class="col-md-6">
                <asp:DropDownList ID="ddlCountry" runat="server" Width="60%" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-3 h4">Your Message:*</div>
            <div class="col-md-6">
                <asp:TextBox ID="txtMessage" Rows="7" TextMode="MultiLine" runat="server" Width="100%" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-3 h4"></div>
            <div class="col-md-6">
                <asp:Button ID="btnSend" Rows="7" CssClass="btn btn-info btn-sm" Text="Send" OnClick="btnSend_Click" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
