using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Linq;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using e_PTIT.Models;
namespace e_PTIT.Controllers
{
    public class AdminController : Controller
    {
        private EPtitDataClassesDataContext db = new EPtitDataClassesDataContext();
        Helpers.CommonFunctions CFunc = new Helpers.CommonFunctions();

        [HttpGet]
        public ActionResult Login()
        {
            Session["IsValid"] = null;
            Session["CurrentUser"] = null;
            Session["AdminId"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection formEntry)
        {

            if (ModelState.IsValid)
            {
                AdminstratorDataClass validationObj = new AdminstratorDataClass();
                Models.Administrators admin = validationObj.IsValid(formEntry["userName"].Trim(), formEntry["password"].Trim());
                if (admin != null)
                {
                    Session["IsValid"] = true;
                    Session["CurrentUser"] = admin.userName;
                    Session["AdminId"] = admin.pkadminId;
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                    return View();
                }
            }
            return RedirectToAction("Index");
        }

        // GET: Admin
        public ActionResult Index()
        {
            
            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            return View();
        }

        #region 'Magazines'
        // GET: Admin
        public ActionResult Magazines()
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            List<MagazineEdition> magazineObj = db.MagazineEditions.ToList();
            return View(magazineObj);
        }

        public ActionResult NewEdition()
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            MagazineEdition magazineObj = new MagazineEdition();
            return View(magazineObj);
        }
        [HttpPost]
        public ActionResult NewEdition(MagazineEdition magazineObj)
        {
            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            try
            {
                // TODO: Add insert logic here
                if (magazineObj.Number.ToString().Trim().Length < 1)
                    ModelState.AddModelError("MagazineEdition.Number", " Number is required! ");
                if (magazineObj.Title.Trim().Length < 1)
                    ModelState.AddModelError("MagazineEdition.Title", " Title is required!  ");
                if (magazineObj.PublishedOn.ToString().Trim().Length < 1)
                    ModelState.AddModelError("MagazineEdition.PublishedOn", " Published On is required!  ");
                if (!ModelState.IsValid)
                {
                    return View(magazineObj);
                }
                MagazineEdition newEdition = new MagazineEdition();
                newEdition.Number = magazineObj.Number;
                newEdition.Title = magazineObj.Title.Trim();
                newEdition.Description = magazineObj.Description.Trim();
                newEdition.CoverImage = magazineObj.CoverImage.Trim();
                newEdition.PublishedOn = magazineObj.PublishedOn;
                newEdition.ArchivedOn = magazineObj.ArchivedOn;
                newEdition.isCurrentEdition = magazineObj.isCurrentEdition;
                db.MagazineEditions.InsertOnSubmit(newEdition);
                db.SubmitChanges();
                return RedirectToAction("Magazines");
            }
            catch
            {
                return View("Magazines");
            }
        }

        public ActionResult EditEdition(int id)
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            MagazineEdition magazineObj = db.MagazineEditions.Where(mb => mb.pkEditionId == id).FirstOrDefault();
            return View(magazineObj);
        }
        [HttpPost]
        public ActionResult EditEdition(int id,MagazineEdition magazineObj)
        {
            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            try
            {
                // TODO: Add insert logic here
                if (magazineObj.Number.ToString().Trim().Length < 1)
                    ModelState.AddModelError("MagazineEdition.Number", " Number is required! ");
                if (magazineObj.Title.Trim().Length < 1)
                    ModelState.AddModelError("MagazineEdition.Title", " Title is required!  ");
                if (magazineObj.PublishedOn.ToString().Trim().Length < 1)
                    ModelState.AddModelError("MagazineEdition.PublishedOn", " Published On is required!  ");
                if (!ModelState.IsValid)
                {
                    return View(magazineObj);
                }
                MagazineEdition magazineDbObj = db.MagazineEditions.Where(mb => mb.pkEditionId == id).FirstOrDefault();
                magazineDbObj.Number = magazineObj.Number;
                magazineDbObj.Title = magazineObj.Title.Trim();
                magazineDbObj.Description = magazineObj.Description.Trim();
                magazineDbObj.CoverImage = magazineObj.CoverImage.Trim();
                magazineDbObj.PublishedOn = magazineObj.PublishedOn;
                magazineDbObj.ArchivedOn = magazineObj.ArchivedOn;
                magazineDbObj.isCurrentEdition = magazineObj.isCurrentEdition;
                db.SubmitChanges();
                return RedirectToAction("Magazines");
            }
            catch
            {
                return View("Magazines");
            }
        }
        #endregion

        #region 'Stories'
        // GET: Admin
        public ActionResult Stories()
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            List<Story> storyObj = db.Stories.ToList();
            return View(storyObj);
        }

        public ActionResult NewStory()
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            Story storyObj = new Story();
            return View(storyObj);
        }
        [HttpPost]
        public ActionResult NewStory(Story storyObj)
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            try
            {
                // TODO: Add insert logic here
                if (storyObj.title.ToString().Trim().Length < 1)
                    ModelState.AddModelError("Story.title", " Title is required! ");
              
                if (!ModelState.IsValid)
                {
                    return View(storyObj);
                }
                Story newStory = new Story();
                newStory.title = storyObj.title.Trim();
                newStory.summary = storyObj.summary.Trim();
                newStory.CreatedOn =DateTime.Now;
                newStory.PostedDate = storyObj.PostedDate;
                newStory.fkEditionId = storyObj.fkEditionId;
                newStory.FontName = storyObj.FontName;
                newStory.NumberOfPages = storyObj.NumberOfPages;
                newStory.ShowOnHomePage = storyObj.ShowOnHomePage;
                newStory.Status = storyObj.Status;
                newStory.ImageName = storyObj.ImageName.Trim();
                db.Stories.InsertOnSubmit(newStory);
                db.SubmitChanges();
                return RedirectToAction("Stories");
            }
            catch
            {
                return View("Stories");
            }
        }

        public ActionResult EditStory(int id)
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            Story storyObj = db.Stories.Where(mb => mb.pkStoryId == id).FirstOrDefault();
            return View(storyObj);
        }
        [HttpPost]
        public ActionResult EditStory(int id, Story storyObj)
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            try
            {
                // TODO: Add insert logic here
                if (storyObj.title.ToString().Trim().Length < 1)
                    ModelState.AddModelError("Story.title", " Title is required! ");

                if (!ModelState.IsValid)
                {
                    return View(storyObj);
                }
                Story editStoryObj = db.Stories.Where(mb => mb.pkStoryId == id).FirstOrDefault();
                editStoryObj.title = storyObj.title.Trim();
                editStoryObj.summary = storyObj.summary.Trim();
                editStoryObj.PostedDate = storyObj.PostedDate;
                editStoryObj.fkEditionId = storyObj.fkEditionId;
                editStoryObj.FontName = storyObj.FontName;
                editStoryObj.NumberOfPages = storyObj.NumberOfPages;
                editStoryObj.ShowOnHomePage = storyObj.ShowOnHomePage;
                editStoryObj.Status = storyObj.Status;
                editStoryObj.ImageName = storyObj.ImageName.Trim();
                db.SubmitChanges();
                return RedirectToAction("Stories");
            }
            catch
            {
                return View("Stories");
            }
        }
        #endregion

        #region 'Story Content'
        // GET: Admin
        public ActionResult StoryContents()
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            List<StoryContent> storyContentObj = db.StoryContents.ToList();
            return View(storyContentObj);
        }

        public ActionResult NewStoryContent()
        {
            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            StoryContent storyContentObj = new StoryContent();
            return View(storyContentObj);
        }
        [HttpPost]
        public ActionResult NewStoryContent(StoryContent storyContentObj)
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            try
            {
                // TODO: Add insert logic here
                if (storyContentObj.pageName.ToString().Trim().Length < 1)
                    ModelState.AddModelError("StoryContent.pageName", "Page Name is required! ");
                if (storyContentObj.pageContent.ToString().Trim().Length < 1)
                    ModelState.AddModelError("StoryContent.pageContent", "Page Content is required! ");
                if (!ModelState.IsValid)
                {
                    return View(storyContentObj);
                }
                StoryContent newStoryContent = new StoryContent();
                newStoryContent.pageNumber = storyContentObj.pageNumber;
                newStoryContent.pageName = storyContentObj.pageName.Trim();
                newStoryContent.pageContent = storyContentObj.pageContent.Trim();
                newStoryContent.CreatedOn = DateTime.Now;
                newStoryContent.fkStoryId = storyContentObj.fkStoryId;
                newStoryContent.ImageName = storyContentObj.ImageName.Trim();
                newStoryContent.BackgroundName = storyContentObj.BackgroundName;
                newStoryContent.gadgetImageName = storyContentObj.gadgetImageName; 
                db.StoryContents.InsertOnSubmit(newStoryContent);
                db.SubmitChanges();
                return RedirectToAction("StoryContents");
            }
            catch
            {
                return View("StoryContents");
            }
        }

        public ActionResult EditStoryContent(int id)
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            StoryContent storyContentObj = db.StoryContents.Where(mb => mb.pkStoryPageId == id).FirstOrDefault();
            return View(storyContentObj);
        }
        [HttpPost]
        public ActionResult EditStoryContent(int id, StoryContent storyContentObj)
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            try
            {
                // TODO: Add insert logic here
                if (storyContentObj.pageName.ToString().Trim().Length < 1)
                    ModelState.AddModelError("StoryContent.pageName", "Page Name is required! ");
                if (storyContentObj.pageContent.ToString().Trim().Length < 1)
                    ModelState.AddModelError("StoryContent.pageContent", "Page Content is required! ");
                if (!ModelState.IsValid)
                {
                    return View(storyContentObj);
                }
                StoryContent editStoryContentObj = db.StoryContents.Where(mb => mb.pkStoryPageId == id).FirstOrDefault();
                editStoryContentObj.pageNumber = storyContentObj.pageNumber;
                editStoryContentObj.pageName = storyContentObj.pageName.Trim();
                editStoryContentObj.pageContent = storyContentObj.pageContent.Trim();
                editStoryContentObj.ModifiedOn = DateTime.Now;
                editStoryContentObj.fkStoryId = storyContentObj.fkStoryId;
                editStoryContentObj.ImageName = storyContentObj.ImageName.Trim();
                editStoryContentObj.BackgroundName = storyContentObj.BackgroundName;
                editStoryContentObj.gadgetImageName = storyContentObj.gadgetImageName; 
                db.SubmitChanges();
                return RedirectToAction("StoryContents");
            }
            catch
            {
                return View("StoryContents");
            }
        }

        #endregion

        #region 'Proverbs'
        // GET: Admin
        public ActionResult Proverbs()
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            List<Proverb> proverbObj = db.Proverbs.ToList();
            return View(proverbObj);
        }

        public ActionResult NewProverb()
        {
            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            Proverb proverbObj = new Proverb();
            return View(proverbObj);
        }
        [HttpPost]
        public ActionResult NewProverb(Proverb proverbObj)
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            try
            {
                // TODO: Add insert logic here
                if (proverbObj.title.ToString().Trim().Length < 1)
                    ModelState.AddModelError("Proverb.title", " Title is required! ");

                if (!ModelState.IsValid)
                {
                    return View(proverbObj);
                }
                Proverb newProverb = new Proverb();
                newProverb.title = proverbObj.title.Trim();
                newProverb.summary = proverbObj.summary.Trim();
                newProverb.CreatedOn = DateTime.Now;
                newProverb.PostedDate = proverbObj.PostedDate;
                newProverb.fkEditionId = proverbObj.fkEditionId;
                newProverb.FontName = proverbObj.FontName;
                newProverb.NumberOfPages = proverbObj.NumberOfPages;
                newProverb.ShowOnHomePage = proverbObj.ShowOnHomePage;
                newProverb.Status = proverbObj.Status;
                newProverb.ImageName = proverbObj.ImageName.Trim();
                db.Proverbs.InsertOnSubmit(newProverb);
                db.SubmitChanges();
                return RedirectToAction("Proverbs");
            }
            catch
            {
                return View("Proverbs");
            }
        }

        public ActionResult EditProverb(int id)
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            Proverb proverbObj = db.Proverbs.Where(mb => mb.pkProverbId == id).FirstOrDefault();
            return View(proverbObj);
        }
        [HttpPost]
        public ActionResult EditProverb(int id, Proverb proverbObj)
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            try
            {
                // TODO: Add insert logic here
                if (proverbObj.title.ToString().Trim().Length < 1)
                    ModelState.AddModelError("Proverb.title", " Title is required! ");
                if (!ModelState.IsValid)
                {
                    return View(proverbObj);
                }
                Proverb editProverbObj = db.Proverbs.Where(mb => mb.pkProverbId == id).FirstOrDefault();
                editProverbObj.title = proverbObj.title.Trim();
                editProverbObj.summary = proverbObj.summary.Trim();
                editProverbObj.PostedDate = proverbObj.PostedDate;
                editProverbObj.fkEditionId = proverbObj.fkEditionId;
                editProverbObj.FontName = proverbObj.FontName;
                editProverbObj.NumberOfPages = proverbObj.NumberOfPages;
                editProverbObj.ShowOnHomePage = proverbObj.ShowOnHomePage;
                editProverbObj.Status = proverbObj.Status;
                editProverbObj.ImageName = proverbObj.ImageName.Trim();
                db.SubmitChanges();
                return RedirectToAction("Proverbs");
            }
            catch
            {
                return View("Proverbs");
            }
        }

        #endregion 
        
        #region 'Proverbs Content'
        // GET: Admin
        public ActionResult ProverbContents()
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            List<ProverbContent> proverbContentObj = db.ProverbContents.ToList();
            return View(proverbContentObj);
        }

        public ActionResult NewProverbContent()
        {
            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            ProverbContent proverbContentObj = new ProverbContent();
            return View(proverbContentObj);
        }
        [HttpPost]
        public ActionResult NewProverbContent(ProverbContent proverbContentObj)
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            try
            {
                // TODO: Add insert logic here
                if (proverbContentObj.pageName.ToString().Trim().Length < 1)
                    ModelState.AddModelError("ProverbContent.pageName", "Page Name is required! ");
                if (proverbContentObj.pageContent.ToString().Trim().Length < 1)
                    ModelState.AddModelError("ProverbContent.pageContent", "Page Content is required! ");
                if (!ModelState.IsValid)
                {
                    return View(proverbContentObj);
                }
                ProverbContent newProverbContent = new ProverbContent();
                newProverbContent.pageNumber = proverbContentObj.pageNumber;
                newProverbContent.pageName = proverbContentObj.pageName.Trim();
                newProverbContent.pageContent = proverbContentObj.pageContent.Trim();
                newProverbContent.CreatedOn = DateTime.Now;
                newProverbContent.fkProverbId = proverbContentObj.fkProverbId;
                newProverbContent.ImageName = proverbContentObj.ImageName.Trim();
                newProverbContent.BackgroundName = proverbContentObj.BackgroundName;
                newProverbContent.gadgetImageName = proverbContentObj.gadgetImageName;
                db.ProverbContents.InsertOnSubmit(newProverbContent);
                db.SubmitChanges();
                return RedirectToAction("ProverbContents");
            }
            catch
            {
                return View("ProverbContents");
            }
        }

        public ActionResult EditProverbContent(int id)
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            ProverbContent proverbContentObj = db.ProverbContents.Where(mb => mb.pkProverbPageId == id).FirstOrDefault();
            return View(proverbContentObj);
        }
        [HttpPost]
        public ActionResult EditProverbContent(int id, ProverbContent proverbContentObj)
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            try
            {
                // TODO: Add insert logic here
                if (proverbContentObj.pageName.ToString().Trim().Length < 1)
                    ModelState.AddModelError("ProverbContent.pageName", "Page Name is required! ");
                if (proverbContentObj.pageContent.ToString().Trim().Length < 1)
                    ModelState.AddModelError("ProverbContent.pageContent", "Page Content is required! ");
                if (!ModelState.IsValid)
                {
                    return View(proverbContentObj);
                }
                ProverbContent editProverbContentObj = db.ProverbContents.Where(mb => mb.pkProverbPageId == id).FirstOrDefault();
                editProverbContentObj.pageNumber = proverbContentObj.pageNumber;
                editProverbContentObj.pageName = proverbContentObj.pageName.Trim();
                editProverbContentObj.pageContent = proverbContentObj.pageContent.Trim();
                editProverbContentObj.ModifiedOn = DateTime.Now;
                editProverbContentObj.fkProverbId = proverbContentObj.fkProverbId;
                editProverbContentObj.ImageName = proverbContentObj.ImageName.Trim();
                editProverbContentObj.BackgroundName = proverbContentObj.BackgroundName;
                editProverbContentObj.gadgetImageName = proverbContentObj.gadgetImageName;
                db.SubmitChanges();
                return RedirectToAction("ProverbContents");
            }
            catch
            {
                return View("ProverbContents");
            }
        }
        #endregion
        
        #region 'Humor'
        // GET: Admin
        public ActionResult Humors()
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            List<Humor> humorObj = db.Humors.ToList();
            return View(humorObj);
        }

        public ActionResult NewHumor()
        {
            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            Humor humorObj = new Humor();
            return View(humorObj);
        }
        [HttpPost]
        public ActionResult NewHumor(Humor humorObj)
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            try
            {
                // TODO: Add insert logic here
                if (humorObj.title.ToString().Trim().Length < 1)
                    ModelState.AddModelError("Humor.title", " Title is required! ");

                if (!ModelState.IsValid)
                {
                    return View(humorObj);
                }
                Humor newHumor = new Humor();
                newHumor.title = humorObj.title.Trim();
                newHumor.summary = humorObj.summary.Trim();
                newHumor.CreatedOn = DateTime.Now;
                newHumor.PostedDate = humorObj.PostedDate;
                newHumor.fkEditionId = humorObj.fkEditionId;
                newHumor.FontName = humorObj.FontName;
                newHumor.NumberOfPages = humorObj.NumberOfPages;
                newHumor.ShowOnHomePage = humorObj.ShowOnHomePage;
                newHumor.Status = humorObj.Status;
                newHumor.ImageName = humorObj.ImageName.Trim();
                db.Humors.InsertOnSubmit(newHumor);
                db.SubmitChanges();
                return RedirectToAction("Humors");
            }
            catch
            {
                return View("Humors");
            }
        }

        public ActionResult EditHumor(int id)
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            Humor humorObj = db.Humors.Where(mb => mb.pkHumorId == id).FirstOrDefault();
            return View(humorObj);
        }
        [HttpPost]
        public ActionResult EditHumor(int id, Humor humorObj)
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            try
            {
                // TODO: Add insert logic here
                if (humorObj.title.ToString().Trim().Length < 1)
                    ModelState.AddModelError("Humor.title", " Title is required! ");
                if (!ModelState.IsValid)
                {
                    return View(humorObj);
                }
                Humor editHumorObj = db.Humors.Where(mb => mb.pkHumorId == id).FirstOrDefault();
                editHumorObj.title = humorObj.title.Trim();
                editHumorObj.summary = humorObj.summary.Trim();
                editHumorObj.PostedDate = humorObj.PostedDate;
                editHumorObj.fkEditionId = humorObj.fkEditionId;
                editHumorObj.FontName = humorObj.FontName;
                editHumorObj.NumberOfPages = humorObj.NumberOfPages;
                editHumorObj.ShowOnHomePage = humorObj.ShowOnHomePage;
                editHumorObj.Status = humorObj.Status;
                editHumorObj.ImageName = humorObj.ImageName.Trim();
                db.SubmitChanges();
                return RedirectToAction("Humors");
            }
            catch
            {
                return View("Humors");
            }
        }

        #endregion

        #region 'Humor Content'
        // GET: Admin
        public ActionResult HumorContents()
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            List<HumorContent> humorContentObj = db.HumorContents.ToList();
            return View(humorContentObj);
        }

        public ActionResult NewHumorContent()
        {
            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            HumorContent humorContentObj = new HumorContent();
            return View(humorContentObj);
        }
        [HttpPost]
        public ActionResult NewHumorContent(HumorContent humorContentObj)
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            try
            {
                // TODO: Add insert logic here
                if (humorContentObj.pageName.ToString().Trim().Length < 1)
                    ModelState.AddModelError("HumorContent.pageName", "Page Name is required! ");
                if (humorContentObj.pageContent.ToString().Trim().Length < 1)
                    ModelState.AddModelError("HumorContent.pageContent", "Page Content is required! ");
                if (!ModelState.IsValid)
                {
                    return View(humorContentObj);
                }
                HumorContent newHumorContent = new HumorContent();
                newHumorContent.pageNumber = humorContentObj.pageNumber;
                newHumorContent.pageName = humorContentObj.pageName.Trim();
                newHumorContent.pageContent = humorContentObj.pageContent.Trim();
                newHumorContent.CreatedOn = DateTime.Now;
                newHumorContent.fkHumorId = humorContentObj.fkHumorId;
                newHumorContent.ImageName = humorContentObj.ImageName.Trim();
                newHumorContent.BackgroundName = humorContentObj.BackgroundName;
                newHumorContent.gadgetImageName = humorContentObj.gadgetImageName;
                db.HumorContents.InsertOnSubmit(newHumorContent);
                db.SubmitChanges();
                return RedirectToAction("HumorContents");
            }
            catch
            {
                return View("HumorContents");
            }
        }

        public ActionResult EditHumorContent(int id)
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            HumorContent humorContentObj = db.HumorContents.Where(mb => mb.pkHumorPageId == id).FirstOrDefault();
            return View(humorContentObj);
        }
        [HttpPost]
        public ActionResult EditHumorContent(int id, HumorContent humorContentObj)
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            try
            {
                // TODO: Add insert logic here
                if (humorContentObj.pageName.ToString().Trim().Length < 1)
                    ModelState.AddModelError("HumorContent.pageName", "Page Name is required! ");
                if (humorContentObj.pageContent.ToString().Trim().Length < 1)
                    ModelState.AddModelError("HumorContent.pageContent", "Page Content is required! ");
                if (!ModelState.IsValid)
                {
                    return View(humorContentObj);
                }
                HumorContent editHumorContentObj = db.HumorContents.Where(mb => mb.pkHumorPageId == id).FirstOrDefault();
                editHumorContentObj.pageNumber = humorContentObj.pageNumber;
                editHumorContentObj.pageName = humorContentObj.pageName.Trim();
                editHumorContentObj.pageContent = humorContentObj.pageContent.Trim();
                editHumorContentObj.ModifiedOn = DateTime.Now;
                editHumorContentObj.fkHumorId = humorContentObj.fkHumorId;
                editHumorContentObj.ImageName = humorContentObj.ImageName.Trim();
                editHumorContentObj.BackgroundName = humorContentObj.BackgroundName;
                editHumorContentObj.gadgetImageName = humorContentObj.gadgetImageName;
                db.SubmitChanges();
                return RedirectToAction("HumorContents");
            }
            catch
            {
                return View("HumorContents");
            }
        }
        #endregion

        #region 'Riddles'
        // GET: Admin
        public ActionResult Riddles()
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            List<Riddle> riddlesObj = db.Riddles.ToList();
            return View(riddlesObj);
        }

        public ActionResult NewRiddle()
        {
            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            Riddle riddleObj = new Riddle();
            return View(riddleObj);
        }
        [HttpPost]
        public ActionResult NewRiddle(Riddle riddleObj)
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            try
            {
                // TODO: Add insert logic here
                if (riddleObj.Question.ToString().Trim().Length < 1)
                    ModelState.AddModelError("Riddle.Question", " Question is required! ");
                if (riddleObj.Answer.ToString().Trim().Length < 1)
                    ModelState.AddModelError("Riddle.Answer", " Answer is required! ");

                if (!ModelState.IsValid)
                {
                    return View(riddleObj);
                }
                Riddle newRiddle = new Riddle();
                newRiddle.Name = riddleObj.Name.Trim();
                newRiddle.Question = riddleObj.Question.Trim();
                newRiddle.Answer = riddleObj.Answer.Trim();
                newRiddle.CreatedOn = DateTime.Now;
                newRiddle.PublishedOn = riddleObj.PublishedOn;
                newRiddle.fkEditionId = riddleObj.fkEditionId;
                db.Riddles.InsertOnSubmit(newRiddle);
                db.SubmitChanges();
                return RedirectToAction("Riddles");
            }
            catch
            {
                return View("Riddles");
            }
        }

        public ActionResult EditRiddle(int id)
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            Riddle riddleObj = db.Riddles.Where(mb => mb.pkRiddleId == id).FirstOrDefault();
            return View(riddleObj);
        }
        [HttpPost]
        public ActionResult EditRiddle(int id, Riddle riddleObj)
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            try
            {
                // TODO: Add insert logic here
                if (riddleObj.Question.ToString().Trim().Length < 1)
                    ModelState.AddModelError("Riddle.Question", " Question is required! ");
                if (riddleObj.Answer.ToString().Trim().Length < 1)
                    ModelState.AddModelError("Riddle.Answer", " Answer is required! ");
                if (!ModelState.IsValid)
                {
                    return View(riddleObj);
                }
                Riddle editRiddleObj = db.Riddles.Where(mb => mb.pkRiddleId == id).FirstOrDefault();
                editRiddleObj.Name = riddleObj.Name.Trim();
                editRiddleObj.Question = riddleObj.Question.Trim();
                editRiddleObj.Answer = riddleObj.Answer.Trim();
                editRiddleObj.ModifiedOn = DateTime.Now;
                editRiddleObj.PublishedOn = riddleObj.PublishedOn;
                editRiddleObj.fkEditionId = riddleObj.fkEditionId;
                db.SubmitChanges();
                return RedirectToAction("Riddles");
            }
            catch
            {
                return View("Riddles");
            }
        }

        #endregion

        #region 'Games - Matching'
        // GET: Admin
        public ActionResult MatchingGames()
        {
            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            List<MatchingGame> storyObj = db.MatchingGames.ToList();
            return View(storyObj);
        }

        public ActionResult NewMatchingGame()
        {
            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            MatchingGame storyObj = new MatchingGame();
            return View(storyObj);
        }
        [HttpPost]
        public ActionResult NewMatchingGame(MatchingGame storyObj)
        {
            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            try
            {
                // TODO: Add insert logic here
                if (storyObj.Title.ToString().Trim().Length < 1)
                    ModelState.AddModelError("MatchingGame.title", " Title is required! ");

                if (!ModelState.IsValid)
                {
                    return View(storyObj);
                }
                MatchingGame newStory = new MatchingGame();
                newStory.Title = storyObj.Title.Trim();
                newStory.Description = storyObj.Description.Trim();
                newStory.CreatedOn = DateTime.Now;
                newStory.PublishedOn = storyObj.PublishedOn;
                newStory.fkEditionId = storyObj.fkEditionId;
                newStory.CreatedOn = storyObj.CreatedOn;
                db.MatchingGames.InsertOnSubmit(newStory);
                db.SubmitChanges();
                return RedirectToAction("MatchingGames");
            }
            catch
            {
                return View("MatchingGames");
            }
        }

        public ActionResult EditMatchingGame(int id)
        {
            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            MatchingGame storyObj = db.MatchingGames.Where(mb => mb.pkMatchingGameID == id).FirstOrDefault();
            return View(storyObj);
        }
        [HttpPost]
        public ActionResult EditMatchingGame(int id, MatchingGame storyObj)
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            try
            {
                // TODO: Add insert logic here
                if (storyObj.Title.ToString().Trim().Length < 1)
                    ModelState.AddModelError("MatchingGame.title", " Title is required! ");

                if (!ModelState.IsValid)
                {
                    return View(storyObj);
                }
                MatchingGame editStoryObj = db.MatchingGames.Where(mb => mb.pkMatchingGameID == id).FirstOrDefault();
                editStoryObj.Title = storyObj.Title.Trim();
                editStoryObj.Description = storyObj.Description.Trim();
                editStoryObj.CreatedOn = DateTime.Now;
                editStoryObj.PublishedOn = storyObj.PublishedOn;
                editStoryObj.fkEditionId = storyObj.fkEditionId;
                editStoryObj.CreatedOn = storyObj.CreatedOn;
                db.SubmitChanges();
                return RedirectToAction("MatchingGames");
            }
            catch
            {
                return View("Stories");
            }
        }
        #endregion

        #region 'Games - Matching - Answer'
        // GET: Admin
        public ActionResult MatchingGameAnswers()
        {
            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            List<MatchingGameAnswer> storyContentObj = db.MatchingGameAnswers.ToList();
            return View(storyContentObj);
        }

        public ActionResult NewMatchingGameAnswer()
        {
            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            MatchingGameAnswer storyContentObj = new MatchingGameAnswer();
            return View(storyContentObj);
        }
        
        [HttpPost]
        public ActionResult NewMatchingGameAnswer(MatchingGameAnswer storyContentObj)
        {
            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            try
            {
                MatchingGameAnswer newStoryContent = new MatchingGameAnswer();
                newStoryContent.AnswerHTML = storyContentObj.AnswerHTML.Trim();
                newStoryContent.AnswerText = storyContentObj.AnswerText.Trim();
                newStoryContent.fkMatchGameId = storyContentObj.fkMatchGameId;
                newStoryContent.fkQuestionId = storyContentObj.fkQuestionId;
                db.MatchingGameAnswers.InsertOnSubmit(newStoryContent);
                db.SubmitChanges();
                return RedirectToAction("MatchingGameAnswers");
            }
            catch
            {
                return View("MatchingGameAnswers");
            }
        }

        public ActionResult EditMatchingGameAnswer(int id)
        {
            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            MatchingGameAnswer storyContentObj = db.MatchingGameAnswers.Where(mb => mb.pkMatchGameAnswerID == id).FirstOrDefault();
            return View(storyContentObj);
        }

        [HttpPost]
        public ActionResult EditMatchingGameAnswer(int id, MatchingGameAnswer storyContentObj)
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            try
            {
                // TODO: Add insert logic here

                if (!ModelState.IsValid)
                {
                    return View(storyContentObj);
                }
                MatchingGameAnswer editStoryContentObj = db.MatchingGameAnswers.Where(mb => mb.pkMatchGameAnswerID == id).FirstOrDefault();
                editStoryContentObj.AnswerHTML = storyContentObj.AnswerHTML.Trim();
                editStoryContentObj.AnswerText = storyContentObj.AnswerText.Trim();
                editStoryContentObj.fkMatchGameId = storyContentObj.fkMatchGameId;
                editStoryContentObj.fkQuestionId = storyContentObj.fkQuestionId;
                db.SubmitChanges();
                return RedirectToAction("MatchingGameAnswers");
            }
            catch
            {
                return View("MatchingGameAnswers");
            }
        }

        #endregion

        #region 'Games - Matching - Question'
        // GET: Admin
        public ActionResult MatchingGameQuestions()
        {
            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            List<MatchingGameQuestion> storyContentObj = db.MatchingGameQuestions.ToList();
            return View(storyContentObj);
        }

        public ActionResult NewMatchingGameQuestion()
        {
            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            MatchingGameQuestion storyContentObj = new MatchingGameQuestion();
            return View(storyContentObj);
        }

        [HttpPost]
        public ActionResult NewMatchingGameQuestion(MatchingGameQuestion storyContentObj)
        {
            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            try
            {
                MatchingGameQuestion newStoryContent = new MatchingGameQuestion();
                newStoryContent.QuestionHTML = storyContentObj.QuestionHTML.Trim();
                newStoryContent.QuestionText = storyContentObj.QuestionText.Trim();
                newStoryContent.fkMatchGameId = storyContentObj.fkMatchGameId;
                db.MatchingGameQuestions.InsertOnSubmit(newStoryContent);
                db.SubmitChanges();
                return RedirectToAction("MatchingGameQuestions");
            }
            catch
            {
                return View("MatchingGameQuestions");
            }
        }

        public ActionResult EditMatchingGameQuestion(int id)
        {
            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            MatchingGameQuestion storyContentObj = db.MatchingGameQuestions.Where(mb => mb.pkMatchGameQuestionID == id).FirstOrDefault();
            return View(storyContentObj);
        }

        [HttpPost]
        public ActionResult EditMatchingGameQuestion(int id, MatchingGameQuestion storyContentObj)
        {

            if (!CFunc.isValidSession())
                return RedirectToAction("Login", "Admin");
            try
            {
                // TODO: Add insert logic here

                if (!ModelState.IsValid)
                {
                    return View(storyContentObj);
                }
                MatchingGameQuestion editStoryContentObj = db.MatchingGameQuestions.Where(mb => mb.pkMatchGameQuestionID == id).FirstOrDefault();
                editStoryContentObj.QuestionHTML = storyContentObj.QuestionHTML.Trim();
                editStoryContentObj.QuestionText = storyContentObj.QuestionText.Trim();
                editStoryContentObj.fkMatchGameId = storyContentObj.fkMatchGameId;
                db.SubmitChanges();
                return RedirectToAction("MatchingGameQuestions");
            }
            catch
            {
                return View("MatchingGameQuestions");
            }
        }

        #endregion
    }
}
