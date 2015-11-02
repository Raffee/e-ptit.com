<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Lezvagan.Master" AutoEventWireup="true" CodeBehind="Crossword.aspx.cs" Inherits="e_PTIT.Games.Crossword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Խաչբառ</title>
    <link rel="stylesheet" type="text/css" href="../fireworks/style/fireworks.css" media="screen" />
    <script type="text/javascript" src="../fireworks/script/soundmanager.js"></script>
    <script type="text/javascript" src="../fireworks/script/fireworks.js"></script>
    <style>
        table.crossword {
            border: 0;
            width: 400px;
        }

        strikeout{
            text-decoration: line-through;
        }

            table.crossword td {
                width: 50px;
                height: 50px;
                border: 1px solid red;
                color: red;
                font-size: 30px;
                background-color: yellow;
            }

                table.crossword td.black {
                    background-color: black;
                }

                table.crossword td.invisible {
                    border: 0;
                    color: red;
                }

            table.crossword input {
                border: 0;
                width: 50px;
                font-size: 30px;
                color: red;
                background-color: yellow;
                text-align: center;
            }

        ul.hints li {
            font-size: 25px;
            color: maroon;
            text-align: left;
        }
    </style>
    <script>
        function validateLetter(inp) {
            if (inp.value == inp.attributes["data-letter-id"].value) {
                inp.attributes["style"] += "border; 1px solid green;"
                inp.attributes["readonly"] = "true";
                inp.readonly = true;
                inp.disable = true;
                debugger;
                var txt = document.getElementById(inp.id);
                txt.readonly = true;
                txt.attributes["readonly"] = "true";
                txt.readonly = true;
                txt.disabled = true;

                var txtJ = $('#' + inp.id);
                txtJ.attr("data-is-solved", "true");

                debugger;
                var words = txtJ.attr("data-word").split(" ");
                for (i = 0; i < words.length; i++) {
                    checkIfWordCompleted(words[i]);
                }
                checkIfCompleted();
            }
            else
                inp.value = "";
        }

        function checkIfCompleted() {
            debugger;
            var toSolve = $("input[data-is-solved='false']");
            //alert(toSolve.length);
            if (toSolve.length == 0) {
                {
                    DoFireworks();
                    playApplause();
                }
            }
        }

        function checkIfWordCompleted(word) {
            debugger;
            var toSolve = $("input[data-is-solved='false'][data-word~='" + word + "']");
            //alert(toSolve.length);
            if (toSolve.length == 0) {
                playSound();
                $("li[data-hint='" + word + "']").css('text-decoration', 'line-through');
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

    <div style="margin-top: 10px !important; width: 100%;">
        <div class="text-center">

            <img src="../images/header/lezvaganKhagher.jpg" />
        </div>
        <div class="text-center">
            <img src="../images/language-games.png" />
        </div>
    </div>

    <div class="dt-sc-hr-small"></div>
    <!--end of page title -->

    <div class="row" style=" padding: 25px;">
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblTitle" CssClass="h2" runat="server" Text="Գիտէ՞ք Փոխադրամիջոցներու Անունները" ForeColor="Navy" />
                <br />
                <asp:Label ID="lblDescription" CssClass="h3" runat="server" Text="Հետեւեալ փոխադրամիջոցներու անունները զետեղեցէք 
վարի խաչբառին  մէջ։"
                    ForeColor="Navy" />
            </div>
        </div>
        <br />
        <div class="row" style="background-image:url('../images/games/crossword/gm1/bg.png'); background-repeat: no-repeat; padding-left:112px; padding-top:6px;">

            <div class="pull-left" >
                <table class="crossword">
                    <tr>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td>
                            <input type="text" data-letter-id="ի" maxlength="1" onblur="validateLetter(this)" id="data19" data-is-solved="false"" data-word="car" /></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                    </tr>
                    <tr>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td>
                            <input type="text" data-letter-id="ն" maxlength="1" onblur="validateLetter(this)" id="data29" data-is-solved="false"" data-word="car" /></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                    </tr>
                    <tr>
                        <td class="invisible"></td>
                        <td>
                            <input type="text" data-letter-id="շ" maxlength="1" onblur="validateLetter(this)" id="data32" data-is-solved="false"" data-word="ship train" /></td>
                        <td>
                            <input type="text" data-letter-id="ո" maxlength="1" onblur="validateLetter(this)" id="data33" data-is-solved="false"" data-word="train" /></td>
                        <td>
                            <input type="text" data-letter-id="գ" maxlength="1" onblur="validateLetter(this)" id="data34" data-is-solved="false" data-word="train" /></td>
                        <td>
                            <input type="text" data-letter-id="ե" maxlength="1" onblur="validateLetter(this)" id="data35" data-is-solved="false" data-word="train" /></td>
                        <td>
                            <input type="text" data-letter-id="կ" maxlength="1" onblur="validateLetter(this)" id="data36" data-is-solved="false" data-word="train" /></td>
                        <td>
                            <input type="text" data-letter-id="ա" maxlength="1" onblur="validateLetter(this)" id="data37" data-is-solved="false" data-word="train" onkeypress="" /></td>
                        <td>
                            <input type="text" data-letter-id="ռ" maxlength="1" onblur="validateLetter(this)" id="data38" data-is-solved="false" data-word="train" /></td>
                        <td style="width:50px!important;">ք</td>

                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                    </tr>
                    <tr>
                        <td class="invisible"></td>
                        <td>
                            <input type="text" data-letter-id="ո" maxlength="1" onblur="validateLetter(this)" id="data42" data-is-solved="false" data-word="ship" /></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td>
                            <input type="text" data-letter-id="ն" maxlength="1" onblur="validateLetter(this)" id="data49" data-is-solved="false" data-word="car" /></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td>ո</td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                    </tr>
                    <tr>
                        <td class="invisible"></td>
                        <td>
                            <input type="text" data-letter-id="գ" maxlength="1" onblur="validateLetter(this)" id="data52" data-is-solved="false" data-word="ship" /></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td>
                            <input type="text" data-letter-id="ա" maxlength="1" onblur="validateLetter(this)" id="data59" data-is-solved="false" data-word="car" /></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td>
                            <input type="text" data-letter-id="ւ" maxlength="1" onblur="validateLetter(this)" id="data512" data-is-solved="false" data-word="chopper" /></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                    </tr>
                    <tr>
                        <td class="invisible"></td>
                        <td>
                            <input type="text" data-letter-id="ե" maxlength="1" onblur="validateLetter(this)" id="data62" data-is-solved="false" data-word="ship" /></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td>
                            <input type="text" data-letter-id="շ" maxlength="1" onblur="validateLetter(this)" id="data69" data-is-solved="false" data-word="car" /></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td>
                            <input type="text" data-letter-id="ղ" maxlength="1" onblur="validateLetter(this)" id="data612" data-is-solved="false" data-word="chopper" /></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                    </tr>
                    <tr>
                        <td class="invisible"></td>
                        <td>
                            <input type="text" data-letter-id="ն" maxlength="1" onblur="validateLetter(this)" id="data72" data-is-solved="false" data-word="ship" /></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td>
                            <input type="text" data-letter-id="ա" maxlength="1" onblur="validateLetter(this)" id="data79" data-is-solved="false" data-word="car" /></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td>
                            <input type="text" data-letter-id="ղ" maxlength="1" onblur="validateLetter(this)" id="data712" data-is-solved="false" data-word="chopper" /></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                    </tr>
                    <tr>
                        <td class="invisible"></td>
                        <td>
                            <input type="text" data-letter-id="ա" maxlength="1" onblur="validateLetter(this)" id="data82" data-is-solved="false" data-word="ship" /></td>

                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td>հ</td>
                        <td>
                            <input type="text" data-letter-id="ա" maxlength="1" onblur="validateLetter(this)" id="data87" data-is-solved="false" data-word="metro" /></td>
                        <td>
                            <input type="text" data-letter-id="ն" maxlength="1" onblur="validateLetter(this)" id="data88" data-is-solved="false" data-word="metro" /></td>
                        <td>
                            <input type="text" data-letter-id="ր" maxlength="1" onblur="validateLetter(this)" id="data89" data-is-solved="false" data-word="metro car" /></td>
                        <td>
                            <input type="text" data-letter-id="ա" maxlength="1" onblur="validateLetter(this)" id="data810" data-is-solved="false" data-word="metro" onkeypress="" /></td>
                        <td>
                            <input type="text" data-letter-id="կ" maxlength="1" onblur="validateLetter(this)" id="data811" data-is-solved="false" data-word="metro" /></td>
                        <td>ա</td>
                        <td>
                            <input type="text" data-letter-id="ռ" maxlength="1" onblur="validateLetter(this)" id="data813" data-is-solved="false" data-word="metro" /></td>
                        <td style="width:50px;"> ք</td>
                    </tr>
                    <tr>
                        <td class="invisible"></td>
                        <td>
                            <input type="text" data-letter-id="ւ" maxlength="1" onblur="validateLetter(this)" id="data92" data-is-solved="false" data-word="ship" /></td>

                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td>
                            <input type="text" data-letter-id="ե" maxlength="1" onblur="validateLetter(this)" id="data96" data-is-solved="false" data-word="bike" /></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td>
                            <input type="text" data-letter-id="ժ" maxlength="1" onblur="validateLetter(this)" id="data99" data-is-solved="false" data-word="car" /></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td>
                            <input type="text" data-letter-id="թ" maxlength="1" onblur="validateLetter(this)" id="data912" data-is-solved="false" data-word="chopper" /></td>

                        <td class="invisible"></td>
                        <td class="invisible"></td>
                    </tr>
                    <tr>
                        <td class="invisible"></td>

                        <td class="invisible"></td>

                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td>
                            <input type="text" data-letter-id="ծ" maxlength="1" onblur="validateLetter(this)" id="data106" data-is-solved="false" data-word="bike" /></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>

                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td>
                            <input type="text" data-letter-id="ի" maxlength="1" onblur="validateLetter(this)" id="data1012" data-is-solved="false" data-word="chopper" /></td>

                        <td class="invisible"></td>
                        <td class="invisible"></td>
                    </tr>
                    <tr>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td>
                            <input type="text" data-letter-id="ա" maxlength="1" onblur="validateLetter(this)" id="data116" data-is-solved="false" data-word="bike" /></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>

                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td>
                            <input type="text" data-letter-id="ռ" maxlength="1" onblur="validateLetter(this)" id="data1112" data-is-solved="false" data-word="chopper" /></td>

                        <td class="invisible"></td>
                        <td class="invisible"></td>
                    </tr>
                    <tr>
                        <td class="invisible"></td>

                        <td class="invisible"></td>

                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td>
                            <input type="text" data-letter-id="ն" maxlength="1" onblur="validateLetter(this)" id="data126" data-is-solved="false" data-word="bike" /></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>

                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>

                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                    </tr>
                    <tr>
                        <td class="invisible"></td>

                        <td class="invisible"></td>

                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td>
                            <input type="text" data-letter-id="ի" maxlength="1" onblur="validateLetter(this)" id="data136" data-is-solved="false" data-word="bike" /></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>

                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>

                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                    </tr>
                    <tr>
                        <td>
                            <input type="text" data-letter-id="օ" maxlength="1" onblur="validateLetter(this)" id="data161" data-is-solved="false" data-word="plane" /></td>
                        <td>
                            <input type="text" data-letter-id="դ" maxlength="1" onblur="validateLetter(this)" id="data162" data-is-solved="false" data-word="plane" /></td>
                        <td>
                            <input type="text" data-letter-id="ա" maxlength="1" onblur="validateLetter(this)" id="data163" data-is-solved="false" data-word="plane" /></td>
                        <td>
                            <input type="text" data-letter-id="ն" maxlength="1" onblur="validateLetter(this)" id="data164" data-is-solved="false" data-word="plane" /></td>
                        <td>
                            <input type="text" data-letter-id="ա" maxlength="1" onblur="validateLetter(this)" id="data165" data-is-solved="false" data-word="plane" /></td>
                        <td>
                            <input type="text" data-letter-id="ւ" maxlength="1" onblur="validateLetter(this)" id="data166" data-is-solved="false" data-word="plane bike" onkeypress="" /></td>

                        <td class="invisible"></td>

                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                        <td class="invisible"></td>
                    </tr>
                </table>
            </div>
            <div class="pull-left" style="vertical-align: middle;">
                <ul class="hints pull-left">
                    <li data-hint="bike">հեծանիւ</li>
                    <li data-hint="plane">օդանաւ</li>
                    <li>ինքնաշարժ</li>
                    <li>շոգեկառք</li>
                    <li>ուղղաթիռ</li>
                    <li>շոգենաւ</li>
                    <li>հանրակառք</li>
                </ul>
            </div>


        </div>
    </div>

    <audio id="myAudio">
        <source src="../audio/bell_sound.mp3" type="audio/mp3" />
        Your browser does not support audio!
    </audio>
        <audio id="audioApplause">
        <source src="../audio/Audience_Applause-Matthiew11-1206899159.mp3" type="audio/mp3" />
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

        function playApplause() {
            var vid = document.getElementById("audioApplause");
            vid.play();
        }
    </script>
</asp:Content>
