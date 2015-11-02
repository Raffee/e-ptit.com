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
    public partial class FindDifferenceGame : System.Web.UI.Page
    {
        private EPtitDataClassesDataContext db = new EPtitDataClassesDataContext();
        protected e_PTIT.Models.FindDifferenceGame game;

        protected void Page_Load(object sender, EventArgs e)
        {
            using(db)
            {
                int gameId = int.Parse(Request.QueryString["ID"]);
                game = db.FindDifferenceGames.Where(gm => gm.pkFindDifferenceGameID == gameId).FirstOrDefault();

                div1.InnerHtml = String.Format(game.HTML1, game.Picture1);
                div2.InnerHtml = String.Format(game.HTML2, game.Picture2);

                lblTitle.Text = game.Title;
                lblDescription.Text = game.Description;

                imgAnswer.Src = "../images/Games/" + game.PictureAnswer;
            }
        }
    }
}