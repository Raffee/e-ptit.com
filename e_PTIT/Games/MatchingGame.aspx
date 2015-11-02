<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Lezvagan.Master" AutoEventWireup="true" CodeBehind="MatchingGame.aspx.cs" Inherits="e_PTIT.Games.MatchingGame" %>

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
    <script type="text/javascript">
        var selectedQ;
        var selectedA;

        function qClicked(div, id) {
            debugger;
            ClearQ();
            selectedQ = div.attributes["data-q-id"].value;
            var divQuestion = $('#divQ' + selectedQ);
            var divAnswer = $('#divA' + selectedA);
            divQuestion.addClass('selected');

            if (selectedA == selectedQ) {
                //alert('MATCH!');
                var aDiv = document.getElementById('divA' + selectedA);
                connect(div, aDiv, "#0F0", 5);
                markFound($('#divQ' + selectedQ));
                markFound($('#' + aDiv.id));
                DoFireworks();
                playSound();
                selectedA = "";
                selectedQ = "";
            }
            else if (selectedA) {
                //alert("Nope, try again :(");

                divQuestion.removeClass('selected');
                divAnswer.removeClass('selected');
                selectedA = "";
                selectedQ = "";
            }
        }

        function aClicked(div, id) {
            ClearA();
            selectedA = div.attributes["data-a-id"].value;
            var divQuestion = $('#divQ' + selectedQ);
            var divAnswer = $('#divA' + selectedA);
            divAnswer.addClass('selected');
            debugger;
            if (selectedA == selectedQ) {
                //alert('MATCH!');
                var qDiv = document.getElementById('divQ' + selectedQ);
                connect(qDiv, div, "#0F0", 5);
                markFound($('#divQ' + selectedQ));
                markFound($('#' + div.id));
                DoFireworks();
                playSound();
                selectedA = "";
                selectedQ = "";
            }
            else if (selectedQ) {
                //alert("Nope, try again :(");

                divQuestion.removeClass('selected');
                divAnswer.removeClass('selected');
                selectedA = "";
                selectedQ = "";
            }
        }

        function markFound(myDiv) {
            myDiv.css("opacity", "0.5")
            myDiv.css("border", "2px solid red");
        }

        function ClearQ()
        {
            $('#divQ' + selectedQ).removeClass('selected');
        }

        function ClearA() {
            $('#divA' + selectedA).removeClass('selected');
        }

        function connect(div1, div2, color, thickness) {
            var off1 = getOffset(div1);
            var off2 = getOffset(div2);
            // bottom right
            var x1 = off1.left + off1.width;
            var y1 = off1.top + (off1.height / 2);
            // top left
            var x2 = off2.left;
            var y2 = off2.top + (off2.height / 2);
            // distance
            var length = Math.sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            // center
            var cx = ((x1 + x2) / 2) - (length / 2);
            var cy = ((y1 + y2) / 2) - (thickness / 2);
            // angle
            var angle = Math.atan2((y1 - y2), (x1 - x2)) * (180 / Math.PI);
            // make hr
            var htmlLine = "<div style='padding:0px; margin:0px; height:" + thickness + "px; background-color:" + color + "; line-height:1px; position:absolute; left:" + cx + "px; top:" + cy + "px; width:" + length + "px; -moz-transform:rotate(" + angle + "deg); -webkit-transform:rotate(" + angle + "deg); -o-transform:rotate(" + angle + "deg); -ms-transform:rotate(" + angle + "deg); transform:rotate(" + angle + "deg);' />";
            //
            //alert(htmlLine);
            document.body.innerHTML += htmlLine;
        }

        function getOffset(el) {
            var rect = el.getBoundingClientRect();
            return {
                left: rect.left + window.pageXOffset,
                top: rect.top + window.pageYOffset,
                width: rect.width || el.offsetWidth,
                height: rect.height || el.offsetHeight
            };
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

    <div style="margin-top:10px !important;width:100%;" class="text-center">
        <div class="text-center">

            <img src="../images/header/lezvaganKhagher.jpg" />
        </div>
        <div class="text-center">
            <img src="../images/language-games.png" />
        </div>
    </div>
    
    <div class="dt-sc-hr-small"></div>
    <!--end of page title -->
    <div class="row">
        <div class="col-md-12">
            <asp:Label ID="lblTitle" CssClass="h2" runat="server" ForeColor="Navy" />
            <br />
            <asp:Label ID="lblDescription" CssClass="h3" runat="server" ForeColor="Navy" />
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-1">&nbsp;</div>
        <div class="col-md-4" runat="server" id="divQuestions">

            <table style="width: 350px; height: 500px;" cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td style="height: 140px;">
                        <img id="imgQHead" runat="server" /></td>
                </tr>
                <tr>
                    <td id="tdContainer" runat="server">
                        <asp:Repeater ID="rptQuestions" runat="server" OnItemDataBound="rptQuestions_ItemDataBound">
                            <HeaderTemplate>

                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td></td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td style="width: 50px">&nbsp;</td>
                                    <td id="tdQuestion" runat="server"></td>
                                    <td style="width: 10px">&nbsp;</td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate></table></FooterTemplate>
                        </asp:Repeater>

                    </td>
                </tr>
                <tr>
                    <td style="height: 140px;">
                        <img id="imgQFoot" runat="server" /></td>
                </tr>

            </table>
        </div>
        <div class="col-md-2"></div>
        <div class="col-md-4" runat="server" id="divAnswers">
            <table style="width: 350px; height: 500px;" cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td style="height: 140px;">
                        <img id="imgAHeader" runat="server" /></td>
                </tr>
                <tr>
                    <td id="tdAContainer" runat="server">
                        <asp:Repeater ID="rptAnswers" runat="server" OnItemDataBound="rptAnswers_ItemDataBound">
                            <HeaderTemplate>

                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td></td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td style="width: 50px">&nbsp;</td>
                                    <td id="tdAnswer" runat="server"></td>
                                    <td style="width: 50px">&nbsp;</td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate></table></FooterTemplate>
                        </asp:Repeater>

                    </td>
                </tr>
                <tr>
                    <td style="height: 140px;">
                        <img id="imgAFooter" runat="server" /></td>
                </tr>

            </table>
        </div>
        <div class="col-md-1">&nbsp;</div>
    </div>
    <audio id="myAudio">
        <source src="../audio/bell_sound.mp3" type="audio/mp3" />
        Your browser does not support audio!
    </audio>
    <script type="text/javascript">

        $(".question").each(function () {
            $(this).attr("onclick", "qClicked(this, this.id)");

        });
        $(".answer").each(function () {
            $(this).attr("onclick", "aClicked(this, this.id)");

        });

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


