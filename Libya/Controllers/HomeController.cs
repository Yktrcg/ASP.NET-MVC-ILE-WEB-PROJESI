using Libya.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Libya1.Controllers
{
    
    public class HomeController : Controller 
    {

        resimlerEntities db = new resimlerEntities();

        public ActionResult Index()
        {
            var model = db.resimlers.ToList();
            return View(model);
        }
        public ActionResult Tarihi()
        {
            return View();
        }
        public ActionResult Tarım()
        {
            return View();
        }
        public ActionResult Enerji()
        {
            return View();
        }
        public ActionResult Ekonomi()
        {
            return View();
        }
        public ActionResult Truzim()
        {
            return View();
        }
        public ActionResult Iklim()
        {
            return View();
        }
    }
}

