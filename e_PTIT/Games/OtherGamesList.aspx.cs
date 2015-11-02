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
    public partial class OtherGamesList : System.Web.UI.Page
    {
        private EPtitDataClassesDataContext db = new EPtitDataClassesDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            using (db)
            {
                var gameGroups = db.GameGroups.Where(c => c.fkEditionId == 1 && c.fkGameMenuTypeId == (int)PtitEnums.GameMenuType.Others).ToList();
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

                if (grp.fkGameTypeId == (int)PtitEnums.GameType.FindDifference)
                {
                    GroupToGameInter inter = db.GroupToGameInters.Where(ggi => ggi.fkGroupId == grp.pkGameGroupID).FirstOrDefault();
                    e_PTIT.Models.FindDifferenceGame gm = db.FindDifferenceGames.Where(mm => mm.pkFindDifferenceGameID == inter.fkGameId).FirstOrDefault() as e_PTIT.Models.FindDifferenceGame;

                    lnkGame.HRef = "FindDifferenceGame.aspx?ID=" + gm.pkFindDifferenceGameID;
                    imgIcon.Src = "../images/games/icons/difference.jpg";
                }
            }
        }
    }
}