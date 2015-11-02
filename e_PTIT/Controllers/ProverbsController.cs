using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_PTIT.Controllers
{
    public class ProverbsController : Controller
    {
        // GET: Proverbs
        public ActionResult Index()
        {
            return View();
        }
        // GET: Stories
        public ActionResult ProverbOne()
        {
            return View();
        }

        public ActionResult ProverbTwo()
        {
            return View();
        }
        public ActionResult ProverbThree()
        {
            return View();
        }
    }
}