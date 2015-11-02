using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_PTIT.Controllers
{
    public class StoriesController : Controller
    {
        // GET: Stories
        public ActionResult Index()
        {
            return View();
        }

        // GET: Stories
        public ActionResult StoryOne()
        {
            return View();
        }

        public ActionResult StoryTwo()
        {
            return View();
        }

        public ActionResult StoryThree()
        {
            return View();
        }
    }
}