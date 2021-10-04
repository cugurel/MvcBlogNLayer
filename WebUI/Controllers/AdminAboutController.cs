using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class AdminAboutController : Controller
    {
        // GET: AdminAbout
        AboutManager am = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutValue = am.GetAboutList();
            return View(aboutValue);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            am.AboutAdd(about);
            return RedirectToAction("Index");
        }
    }
}