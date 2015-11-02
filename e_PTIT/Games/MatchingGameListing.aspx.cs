using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using e_PTIT.Models;

namespace e_PTIT.Games
{
    public partial class MatchingGameListing : System.Web.UI.Page
    {
        private EPtitDataClassesDataContext db = new EPtitDataClassesDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            using (db)
            {
                var games = db.GameGroups.Where(c => c.fkEditionId == 1 && c.fkGameTypeId==1).ToList();

                rptGames.DataSource = games;
                rptGames.DataBind();
            }
        }

        protected void rptGames_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.Item.ItemType == ListItemType.AlternatingItem ||e.Item.ItemType == ListItemType.Item)
            {
                GameGroup gg = e.Item.DataItem as GameGroup;
                Label lblGameName = e.Item.FindControl("lblGameName") as Label;

                lblGameName.Text = gg.GroupHeader;
            }
        }
    }
}