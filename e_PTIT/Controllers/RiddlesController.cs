using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_PTIT.Controllers
{
    public class RiddlesController : Controller
    {
        // GET: Riddles
        public ActionResult Index()
        {
            return View();
        }
    }
}