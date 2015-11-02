<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Site.Master" AutoEventWireup="true" CodeBehind="WriteAnswerGame.aspx.cs" Inherits="e_PTIT.Games.WriteAnswerGame" %>

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

        function showAnswer(thisObj, correctAnswer, guessed) {
            debugger;
            if (thisObj.value == correctAnswer) {
                //divAnswer.show();
                if (guessed) {
                    DoFireworks();
                    playSound();
                    thisObj.style.borderColor = "green";
                }
            }
            else {
                thisObj.value = "";
                thisObj.style.borderColor = "red";
            }
        }

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

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-top: 10px !important; width: 100%;" class="text-center">
        <div class="text-center">

            <img src="../images/header/aylKhager.jpg" />
        </div>
        <div class="text-center">
            <img src="../images/math-games.png" />
        </div>
    </div>

    <div class="dt-sc-hr-small"></div>
    <!--end of page title -->

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
    <div style="width: 100%;">

        <div id="divContent" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <asp:Label ID="lblTitle" CssClass="h2" runat="server" ForeColor="#2a89d8" />
                    <br />
                    <asp:Label ID="lblDescription" CssClass="h3" runat="server" ForeColor="#2a89d8" />
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-1">&nbsp;</div>
                <div>
                    <asp:DataList ID="rptGames" runat="server" RepeatColumns="5" OnItemDataBound="rptGames_ItemDataBound">
                        <ItemTemplate>

                            <div class="row" runat="server" id="divAnswers" style="position: relative;">
                                <div id="divQuestion" runat="server" />
                            </div>
                            <div class="row">
                                <div id="divQ2Ans" class="modal-box" runat="server">
                                   <header style="background-color: cadetblue; color:white;"><h3><%= e_PTIT.Constants.SHOW_ANSWER %></h3></header>
             <h2>
                                        <asp:Label ID="lblAnswer" ForeColor="CadetBlue" runat="server" /></h2>
                                    <footer>
                                        <a href="#" class="js-modal-close">X</a>
                                    </footer>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-2">
                                    <a href="#" id="lnkShowAnswer" runat="server" class="btn btn-info small blue danger js-open-modal"><%= e_PTIT.Constants.SHOW_ANSWER %></a>
                                </div>
                            </div>
                            <div class="row" style="padding: 25px;">&nbsp;</div>
                        </ItemTemplate>
                    </asp:DataList>

                </div>
            </div>
        </div>


    </div>
    <audio id="myAudio">
        <source src="../audio/bell_sound.mp3" type="audio/mp3" />
        Your browser does not support audio!
    </audio>

    <script type="text/javascript">
        if (typeof (soundManagerInit) != 'undefined') soundManagerInit();

        function DoFireworks() {
            var r = 4 + parseInt(Math.random() * 16);
            for (var i = r; i--;) {
                setTimeout('createFirework(8,14,2,null,null,null,null,null,Math.random()>0.5,true)', (i + 1) * (1 + parseInt(Math.random() * 1000)));
            }
            return false;
        }

        function playSound() {
            var vid = document.getElementById("myAudio");
            vid.play();
        }
    </script>
</asp:Content>
