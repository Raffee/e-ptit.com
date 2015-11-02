<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Site.Master" AutoEventWireup="true" CodeBehind="MathGamesList.aspx.cs" Inherits="e_PTIT.Games.MathGamesList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/shortcodes.css" rel="stylesheet" type="text/css" />
    <link href="../css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../css/shortcodes.css" rel="stylesheet" type="text/css" />
    <!--prettyPhoto-->
    <link href="../css/prettyPhoto.css" rel="stylesheet" type="text/css" media="all" />
    <!--[if IE 7]>
<link href="../css/font-awesome-ie7.css" rel="stylesheet" type="text/css">
<![endif]-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="margin-top:10px !important;width:100%;" class="text-center">
        <div class="text-center">

            <img src="../images/header/aylKhager.jpg" />
        </div>
        <div class="text-center">
            <img src="../images/math-games.png" />
        </div>
    </div>
    
    <div class="dt-sc-hr-small"></div>
    <!--end of page title -->
    <asp:Repeater ID="rptGameGroups" runat="server" OnItemDataBound="rptGameGroups_ItemDataBound">
        <ItemTemplate>
            <div class="column dt-sc-one-half first" style="padding-bottom:15px">
                <a id="lnkGame" runat="server">
                <div class="dt-sc-titled-box mustard">
                    <h4 class="dt-sc-titled-box-title" style="background-color:#2a89d8">
                        <asp:Label ID="lblGameHeader" runat="server" /></h4>
                    <div class="dt-sc-titled-box-content" style="color:#2a89d8; height:100px">
                            <div class="col-md-3"><img id="imgIcon" runat="server" style="width:76px;" /></div>
                        <div class="col-md-9" style="color:#2a89d8">
                            <asp:Label ID="lblDesc" runat="server" /></div>
                    </div>
                </div>
                    </a>
            </div>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <div class="column dt-sc-one-half" style="padding-bottom:15px">
                <a id="lnkGame" runat="server">
                <div class="dt-sc-titled-box mustard">
                    <h4 class="dt-sc-titled-box-title" style="background-color:#2a89d8">
                        <asp:Label ID="lblGameHeader" runat="server" /></h4>
                    <div class="dt-sc-titled-box-content" style="color:#2a89d8; height:100px">
                            <div class="col-md-3"><img id="imgIcon" runat="server" style="width:76px;" /></div>
                        <div class="col-md-9" style="color:#2a89d8">
                            <asp:Label ID="lblDesc" runat="server" /></div>
                    </div>
                </div>
                    </a>
            </div>
        </AlternatingItemTemplate>
    </asp:Repeater>



</asp:Content>
