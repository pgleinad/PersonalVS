using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeBase.Controllers
{
    public class IssueController : Controller
    {
        public ActionResult Register()
        {
            return View("Register");
        }

        public ActionResult Search()
        {
            return View("Search");
        }
    }
}