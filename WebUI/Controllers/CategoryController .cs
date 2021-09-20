using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            //var categories = cm.GetAllBl();
            return View(categories);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category ct)
        {
            //cm.CategoryAddBl(ct);
            return RedirectToAction("GetCategoryList");
        }
    }
}