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
    public partial class SelectOneGame : System.Web.UI.Page
    {
        private EPtitDataClassesDataContext db = new EPtitDataClassesDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            using (db)
            {
                int groupId = int.Parse(Request.QueryString["ID"]);
                GameGroup group = db.GameGroups.Where(gmg => gmg.pkGameGroupID == groupId).FirstOrDefault();
                var games = db.GroupToGameInters.Where(c => c.fkGroupId == groupId).ToList();

                lblTitle.Text = group.GroupHeader;
                lblDescription.Text = group.GroupDescription;

                lblTitle.Attributes["style"] = group.TitleStyle;
                lblDescription.Attributes["style"] = group.DescStyle;
                
                divContent.Attributes["style"] = "background-image:url('../images/games/" + group.BackgroungImage + "');";

                rptGames.DataSource = games;
                rptGames.DataBind();
            }
        }

        protected void rptGames_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                GroupToGameInter grp = e.Item.DataItem as GroupToGameInter;
                Label lblAnswer = e.Item.FindControl("lblAnswer") as Label;
                TableRow trRow = e.Item.FindControl("trRow") as TableRow;
                HtmlGenericControl divAns = e.Item.FindControl("divQ2Ans") as HtmlGenericControl;
                HtmlAnchor lnkAns = e.Item.FindControl("lnkAns") as HtmlAnchor;

                e_PTIT.Models.SelectOneGame game = db.SelectOneGames.Where(gm => gm.pkSelectOneGameID == grp.fkGameId).FirstOrDefault();

                lnkAns.Attributes["data-modal-id"] = divAns.ClientID;
                foreach (var answer in game.SelectOneGameAnswers)
                {
                    string divStr = String.Format("<div class=\"col-md-2\">" +
                        "<div id=\"divA{0}\" class=\"col-md-1\" onclick=\"{2}\" style=\"{3}background-image:url('../images/games/{4}');\">{1}</div>" +
                        "</div>", answer.pkSelectGameAnswerID, String.IsNullOrEmpty(answer.AnswerHTML) ? answer.AnswerText : answer.AnswerHTML, answer.isCorrectAnswer ? "showAnswer('" + divAns.ClientID + "', true)" : "", game.AnswerStyle, game.AnswerBackgroundImage);

                    //divAnswers.InnerHtml += divStr;

                    if (answer.isCorrectAnswer)
                        lblAnswer.Text = answer.AnswerText;




                    System.Web.UI.HtmlControls.HtmlGenericControl div = e.Item.FindControl("divRow") as System.Web.UI.HtmlControls.HtmlGenericControl;
                    div.InnerHtml += divStr;
                }
            }
        }
    }
}