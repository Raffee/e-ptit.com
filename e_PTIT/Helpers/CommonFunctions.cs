using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;


namespace e_PTIT.Helpers
{

    public class CommonFunctions
    {
        public bool isValidSession()
        {
            try
            {
                return ((HttpContext.Current.Session["IsValid"].ToString() != null) && (HttpContext.Current.Session["IsValid"].ToString().ToLower() == "true"));
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public string GetCurrentUser()
        {
            try
            {
                return HttpContext.Current.Session["CurrentUser"].ToString();

            }
            catch (Exception ex)
            {
                return "";

            }
        }


        public enum ModuleId
        {
            Stories=1,
            Proverbs=2,
            Riddles=3,
            PhotoGallery=4 
        };
    }
}