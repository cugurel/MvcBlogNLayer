using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class AdminCateogoryController : Controller
    {
        // GET: AdminCateogory

        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            var categoryList = cm.GetCategoryList();
            return View(categoryList);
        }
        
        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CategoryAdd(Category ct)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult result = cv.Validate(ct);
            if (result.IsValid)
            {
                cm.CategoryAdd(ct);
                return RedirectToAction("index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}