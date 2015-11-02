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
    public partial class MatchingGame : System.Web.UI.Page
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

                imgQHead.Src = "../images/games/" + game.QuestionsHeader;
                imgQFoot.Src = "../images/games/" + game.QuestionsFooter;
                imgAHeader.Src = "../images/games/" + game.AnswersHeader;
                imgAFooter.Src = "../images/games/" + game.AnswersFooter;

                tdContainer.Attributes["style"] = String.Format("background-image: url('../images/games/{0}'); width: 100%; height: 100%", game.QuestionTblBG);
                tdAContainer.Attributes["style"] = String.Format("background-image: url('../images/games/{0}'); width: 100%; height: 100%", game.AnswerTblBG);
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
                tdQuestion.InnerText = question.QuestionText;
            }
            else if(e.Item.ItemType == ListItemType.Header)
            {
            }
        }

        protected void rptAnswers_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
                tdAnswer.InnerText = answer.AnswerText;

            }
            else if (e.Item.ItemType == ListItemType.Header)
            {
            }
        }
    }
}