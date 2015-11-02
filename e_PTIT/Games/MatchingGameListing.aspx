<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Site.Master" AutoEventWireup="true" CodeBehind="MatchingGameListing.aspx.cs" Inherits="e_PTIT.Games.MatchingGameListing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../fireworks/style/fireworks.css" media="screen" />
    <script type="text/javascript" src="../fireworks/script/soundmanager.js"></script>
    <script type="text/javascript" src="../fireworks/script/fireworks.js"></script>
    <style>
        .bordered {
            border: 1px solid grey;
        }

        .selected {
            border: 2px solid red;
        }

        div1 {
            border: 1px dashed green;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-md-12">
            <asp:Label ID="lblTitle" CssClass="h2" runat="server" />
            <br />
            <asp:Label ID="lblDescription" CssClass="h3" runat="server" />
        </div>
    </div>
    <br />
        <div class="row">

            <div class="col-md-4">
            </div>
            <div class="col-md-4">
                <asp:Repeater ID="rptGames" runat="server" OnItemDataBound="rptGames_ItemDataBound">
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div>
                            <asp:Label ID="lblGameName" runat="server" />
                        </div>

                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:Repeater>
                <div>This is below the repeater</div>
            </div>
            <div class="col-md-4">
            </div>
        </div>
    <script type="text/javascript">

    </script>
</asp:Content>


