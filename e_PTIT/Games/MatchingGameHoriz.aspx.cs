using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using e_PTIT.Models;

namespace e_PTIT.Games
{
    public partial class MatchingGameHoriz : System.Web.UI.Page
    {
        private EPtitDataClassesDataContext db = new EPtitDataClassesDataContext();
        protected e_PTIT.Models.MatchingGame game;

        protected void Page_Load(object sender, EventArgs e)
        {
            using(db)
            {
                int gameId = int.Parse(Request.QueryString["ID"]);
                game = db.MatchingGames.Where(gm => gm.pkMatchingGameID == gameId).FirstOrDefault();

                rptQuestions.DataSource = game.MatchingGameQuestions;
                rptQuestions.DataBind();

                rptAnswers.DataSource = game.MatchingGameAnswers;
                rptAnswers.DataBind();

                lblTitle.Text = game.Title;
                lblDescription.Text = game.Description;

                mainContainer.Attributes["style"] = game.MainContainerStyle;

                //images
                #region Images

                if (!String.IsNullOrEmpty(game.QuestionsHeader))
                {
                    Image imgQHead = new Image();
                    imgQHead.ImageUrl = "../images/games/" + game.QuestionsHeader;
                    tdQHeader.Controls.Add(imgQHead);
                }

                if (!String.IsNullOrEmpty(game.QuestionsFooter))
                {
                    Image imgQRight = new Image();
                    imgQRight.ImageUrl = "../images/games/" + game.QuestionsFooter;
                    tdQFooter.Controls.Add(imgQRight);
                }

                if (!String.IsNullOrEmpty(game.AnswersHeader))
                {
                    Image imgALeft = new Image();
                    imgALeft.ImageUrl = "../images/games/" + game.AnswersHeader;
                    tdAHeader.Controls.Add(imgALeft);
                }

                if (!String.IsNullOrEmpty(game.AnswersFooter))
                {
                    Image imgARight = new Image();
                    imgARight.ImageUrl = "../images/games/" + game.AnswersFooter;
                    tdAFooter.Controls.Add(imgARight);
                }

                if(!String.IsNullOrEmpty(game.QuestionsLeft))
                {
                    Image imgQLeft = new Image();
                    imgQLeft.ImageUrl = "../images/games/" + game.QuestionsLeft;
                    tdQLeft.Controls.Add(imgQLeft);
                }

                if (!String.IsNullOrEmpty(game.QuestionsRight))
                {
                    Image imgQRight = new Image();
                    imgQRight.ImageUrl = "../images/games/" + game.QuestionsRight;
                    tdQRight.Controls.Add(imgQRight);
                }

                if (!String.IsNullOrEmpty(game.AnswersLeft))
                {
                    Image imgALeft = new Image();
                    imgALeft.ImageUrl = "../images/games/" + game.AnswersLeft;
                    tdALeft.Controls.Add(imgALeft);
                }

                if (!String.IsNullOrEmpty(game.AnswersRight))
                {
                    Image imgARight = new Image();
                    imgARight.ImageUrl = "../images/games/" + game.AnswersRight;
                    tdARight.Controls.Add(imgARight);
                }

                #endregion

                //styles
                tdQHeader.Attributes["style"] = game.QHStyle;
                tdQFooter.Attributes["style"] = game.QFStyle;
                tdQLeft.Attributes["style"] = game.QLStyle;
                tdQRight.Attributes["style"] = game.QRStyle;

                tdAHeader.Attributes["style"] = game.AHStyle;
                tdAFooter.Attributes["style"] = game.AFStyle;
                tdALeft.Attributes["style"] = game.ALStyle;
                tdARight.Attributes["style"] = game.ARStyle;

                tdContainer.Attributes["style"] = String.Format("background-image: url('../images/games/{0}'); width: 100%; height: 100%; {1}", game.QuestionTblBG, game.QContainerStyle);
                tdAContainer.Attributes["style"] = String.Format("background-image: url('../images/games/{0}'); width: 100%; height: 100%; {1}", game.AnswerTblBG, game.AContainerStyle);
            }
        }

        protected void rptQuestions_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                MatchingGameQuestion question = e.Item.DataItem as MatchingGameQuestion;
                HtmlTableCell tdQuestion = e.Item.FindControl("tdQuestion") as HtmlTableCell;

                tdQuestion.Attributes["style"] = String.Format("{0}background-image:url('../images/games/{1}');", game.QuestionsStyle, game.QuestionsBG);

                tdQuestion.Attributes["class"] = "question";
                tdQuestion.Attributes.Add("data-q-id", question.pkMatchGameQuestionID.ToString());
                tdQuestion.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                tdQuestion.Attributes["id"] = "divQ" + question.pkMatchGameQuestionID.ToString();
                tdQuestion.ID = "divQ" + question.pkMatchGameQuestionID.ToString();

                if (String.IsNullOrEmpty(question.QuestionHTML))
                    tdQuestion.InnerText = question.QuestionText;
                else
                    tdQuestion.InnerHtml = question.QuestionHTML;
            }
        }

        protected void rptAnswers_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                MatchingGameAnswer answer = e.Item.DataItem as MatchingGameAnswer;
                HtmlTableCell tdAnswer = e.Item.FindControl("tdAnswer") as HtmlTableCell;

                tdAnswer.Attributes["style"] = String.Format("{0}background-image:url('../images/games/{1}');", game.AnswersStyle, game.AnswersBG);

                tdAnswer.Attributes["class"] = "answer";
                tdAnswer.Attributes.Add("data-a-id", answer.fkQuestionId.ToString());
                tdAnswer.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                tdAnswer.Attributes["id"] = "divA" + answer.fkQuestionId.ToString();
                tdAnswer.ID = "divA" + answer.fkQuestionId.ToString();

                if (String.IsNullOrEmpty(answer.AnswerHTML))
                    tdAnswer.InnerText = answer.AnswerText;
                else
                    tdAnswer.InnerHtml = answer.AnswerHTML;

            }
        }
    }
}