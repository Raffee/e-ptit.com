using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_PTIT.Controllers
{
    public class OtherGamesController : Controller
    {
        // GET: OtherGames
        public ActionResult Index()
        {
            return View();
        }

        // GET: OtherGames/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OtherGames/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OtherGames/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: OtherGames/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OtherGames/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: OtherGames/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OtherGames/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
