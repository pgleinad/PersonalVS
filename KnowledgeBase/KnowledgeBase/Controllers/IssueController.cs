using KnowledgeBase.Models;
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

        public ActionResult Add(IssueModel issue)
        {
            issue.id = Guid.NewGuid();
            issue.comments = string.IsNullOrEmpty(issue.comments) ? string.Empty : issue.comments;
            if (ModelState.IsValid)
            {
                if (new KnowledgeBase.Services.DataBase.Context.Issue(Server.MapPath("~")).add(issue))
                {
                    ViewBag.SuccessMessage = "Issue succesfully recorded.";
                    ModelState.Clear();
                    return View("Register", null);
                }
                else
                {
                    ViewBag.ErrorMessage = "Please retry.";
                    return View("Register", issue);
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Please fill all the required fields";
                return View("Register", issue);
            }
        }
    }
}