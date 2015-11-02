<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Site.Master" AutoEventWireup="true" CodeBehind="FindDifferenceGame.aspx.cs" Inherits="e_PTIT.Games.FindDifferenceGame" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../fireworks/style/fireworks.css" media="screen" />
    <script type="text/javascript" src="../fireworks/script/soundmanager.js"></script>
    <script type="text/javascript" src="../fireworks/script/fireworks.js"></script>
    <style>
        .modal-box {
            display: none;
            position: absolute;
            z-index: 1000;
            width: 98%;
            background: white;
            border-bottom: 1px solid #aaa;
            border-radius: 4px;
            box-shadow: 0 3px 9px rgba(0, 0, 0, 0.5);
            border: 1px solid rgba(0, 0, 0, 0.1);
            background-clip: padding-box;
        }

            .modal-box header,
            .modal-box .modal-header {
                padding: 1.25em 1.5em;
                border-bottom: 1px solid #ddd;
            }

                .modal-box header h3,
                .modal-box header h4,
                .modal-box .modal-header h3,
                .modal-box .modal-header h4 {
                    margin: 0;
                }

            .modal-box .modal-body {
                padding: 2em 1.5em;
            }

            .modal-box footer,
            .modal-box .modal-footer {
                padding: 1em;
                border-top: 1px solid #ddd;
                background: rgba(0, 0, 0, 0.02);
                text-align: right;
            }

        .modal-overlay {
            opacity: 0;
            filter: alpha(opacity=0);
            position: absolute;
            top: 0;
            left: 0;
            z-index: 900;
            width: 100%;
            height: 100%;
            background: rgba(0, 0, 0, 0.3) !important;
        }

        a.close {
            line-height: 1;
            font-size: 1.5em;
            position: absolute;
            top: 5%;
            right: 2%;
            text-decoration: none;
            color: #bbb;
        }

            a.close:hover {
                color: #222;
                -webkit-transition: color 1s ease;
                -moz-transition: color 1s ease;
                transition: color 1s ease;
            }

        @media (min-width: 32em) {
            .modal-box {
                width: 20%;
            }
        }
    </style>
    <script type="text/javascript">

        $(function () {

            var appendthis = ("<div class='modal-overlay js-modal-close'></div>");

            $('a[data-modal-id]').click(function (e) {
                e.preventDefault();
                $("body").append(appendthis);
                $(".modal-overlay").fadeTo(500, 0.7);
                //$(".js-modalbox").fadeIn(500);
                var modalBox = $(this).attr('data-modal-id');
                $('#' + modalBox).fadeIn($(this).data());
            });


            $(".js-modal-close, .modal-overlay").click(function () {
                $(".modal-box, .modal-overlay").fadeOut(500, function () {
                    $(".modal-overlay").remove();
                });
            });

            $(window).resize(function () {
                $(".modal-box").css({
                    top: ($(window).height() - $(".modal-box").outerHeight()) / 2,
                    left: ($(window).width() - $(".modal-box").outerWidth()) / 2
                });
            });

            $(window).resize();

        });


        function showAnswer(divId, guessed) {
            debugger;
            var divAnswer = $('#' + divId);
            if (guessed) {
                DoFireworks();
                playSound();
            }
            else {
                divAnswer.dialog();
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>

        <div id="sound">
        </div>

        <div id="fireworks-template">
            <div id="fw" class="firework"></div>
            <div id="fp" class="fireworkParticle">
                <img src="../fireworks/image/particles.gif" alt="" />
            </div>
        </div>

        <div id="fireContainer"></div>
    </div>

    <div style="margin-top: 10px !important; width: 100%;" class="text-center">
        <div class="text-center">

            <img src="../images/header/aylKhager.jpg" />
        </div>
        <div class="text-center">
            <img src="../images/other-games.png" />
        </div>
    </div>

    <div class="dt-sc-hr-small"></div>
    <!--end of page title -->
    <div class="row">
        <div class="col-md-12">
            <asp:Label ID="lblTitle" CssClass="h2" runat="server" ForeColor="#2a89d8" />
            <br />
            <asp:Label ID="lblDescription" CssClass="h3" runat="server" ForeColor="#2a89d8" />
        </div>
    </div>
    <br />
    <div class="row" style="cursor: pointer;">

        <div class="col-md-4" runat="server" id="div1">
        </div>
        <div class="col-md-2" style="vertical-align: bottom;">
            <a id="lnkAns" data-modal-id="divQ2Ans" href="#" runat="server" class="btn btn-info small pink danger"><%= e_PTIT.Constants.SHOW_ANSWER %></a>
        </div>

        <div class="col-md-4" runat="server" id="div2">
        </div>
    </div>
    <div class="row">
        <div id="divQ2Ans" class="modal-box">
            <header style="background-color: cadetblue; color:white;"><h3><%= e_PTIT.Constants.SHOW_ANSWER %></h3></header>
            <img id="imgAnswer" runat="server" />
            <footer>
                <a href="#" class="js-modal-close">X</a>
            </footer>
        </div>
    </div>
</asp:Content>
