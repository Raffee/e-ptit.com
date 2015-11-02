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
    public partial class WriteAnswerGame : System.Web.UI.Page
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

                rptGames.RepeatColumns = group.ItemsPerRow ?? 1;
                rptGames.DataSource = games;
                rptGames.DataBind(); 
            }
        }

        protected void rptGames_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                GroupToGameInter grp = e.Item.DataItem as GroupToGameInter;
                e_PTIT.Models.WriteAnswerGame game = db.WriteAnswerGames.Where(gm => gm.pkWriteAnswerGameId == grp.fkGameId).FirstOrDefault();
                HtmlGenericControl divQuestion = e.Item.FindControl("divQuestion") as HtmlGenericControl;
                HtmlGenericControl divQ2Ans = e.Item.FindControl("divQ2Ans") as HtmlGenericControl;
                HtmlAnchor lnkShowAnswer = e.Item.FindControl("lnkShowAnswer") as HtmlAnchor;
                Label lblAnswer = e.Item.FindControl("lblAnswer") as Label;

                string inputStr = String.Format("<input id='txtInput{0}' type='text' style='width:40px' onblur='showAnswer(this, \"{1}\", true);' />", game.pkWriteAnswerGameId, game.AnswerText);
                string innerHTML = String.Format(game.QuestionHTML, inputStr);

                divQuestion.InnerHtml = innerHTML;
                divQuestion.Attributes["style"] = String.Format(" background-image:url('../images/games/{0}'); {1}", game.ImageBG, game.QuestionStyle);

                lnkShowAnswer.Attributes["data-modal-id"] = divQ2Ans.ClientID;

                lblAnswer.Text = game.AnswerText;
            }
        }
    }
}