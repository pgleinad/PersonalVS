using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeBase.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Knowledge Base: the issue way to record and search issues and fixes";

            return View();
        }

        public ActionResult Issue()
        {
            ViewBag.Message = "Register issues page.";

            return View();
        }
    }
}