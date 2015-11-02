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
    public partial class LanguageGames : System.Web.UI.Page
    {
        private EPtitDataClassesDataContext db = new EPtitDataClassesDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            using (db)
            {
                var gameGroups = db.GameGroups.Where(c => c.fkEditionId == 1 && c.fkGameMenuTypeId == (int)PtitEnums.GameMenuType.Language).ToList();
                rptGameGroups.DataSource = gameGroups;
                rptGameGroups.DataBind();
            }
        }

        protected void rptGameGroups_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                GameGroup grp = e.Item.DataItem as GameGroup;

                Label lblGroupHeader = e.Item.FindControl("lblGameHeader") as Label;
                Label lblDesc = e.Item.FindControl("lblDesc") as Label;
                HtmlAnchor lnkGame = e.Item.FindControl("lnkGame") as HtmlAnchor;
                HtmlImage imgIcon = e.Item.FindControl("imgIcon") as HtmlImage;

                lblDesc.Text = grp.GroupDescription;
                lblGroupHeader.Text = grp.GroupHeader;

                if(grp.fkGameTypeId == (int)PtitEnums.GameType.Matching)
                {
                    GroupToGameInter inter = db.GroupToGameInters.Where(ggi => ggi.fkGroupId == grp.pkGameGroupID).FirstOrDefault();
                    e_PTIT.Models.MatchingGame gm = db.MatchingGames.Where(mm => mm.pkMatchingGameID == inter.fkGameId).FirstOrDefault() as e_PTIT.Models.MatchingGame;

                    if(gm.Direction == 1)
                    {
                        lnkGame.HRef = "MatchingGame.aspx?ID=" + gm.pkMatchingGameID;
                    }
                    else
                    {
                        lnkGame.HRef = "MatchingGameHoriz.aspx?ID=" + gm.pkMatchingGameID;
                    }
                    imgIcon.Src = "../images/games/icons/matching.jpg";
                }
                else if(grp.fkGameTypeId == (int)PtitEnums.GameType.Crossword)
                {
                    lnkGame.HRef = "Crossword.aspx?ID=";
                    imgIcon.Src = "../images/games/icons/crossword.png";
                }
            }
        }
    }
}