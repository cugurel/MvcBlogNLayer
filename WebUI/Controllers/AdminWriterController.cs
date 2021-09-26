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
    public class AdminWriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var writerValues = wm.GetList();
            return View(writerValues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            wm.WriterAdd(writer);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateWriter(int id)
        {
            var writervalue = wm.GetById(id);
            return View(writervalue);
        }

        [HttpPost]
        public ActionResult UpdateWriter(Writer writer)
        {
            wm.WriterUpdate(writer);
            return RedirectToAction("Index");
        }
    }
}