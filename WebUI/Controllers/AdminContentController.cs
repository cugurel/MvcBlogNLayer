using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class AdminContentController : Controller
    {
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContentByHeading()
        {
            return View();
        }
    }
}