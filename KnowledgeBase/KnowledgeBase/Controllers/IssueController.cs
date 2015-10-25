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
            List<IssueModel> issues = new KnowledgeBase.Services.DataBase.Context.Issue(Server.MapPath("~")).getAll();
            SearchModel search = new SearchModel();
            search.issues = issues;
            return View("Search", search);
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

        public ActionResult SearchByFilter(SearchModel search)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(search.textToSearch))
            {
                List<IssueModel> searchedIssues = new List<IssueModel>();
                var issues = new KnowledgeBase.Services.DataBase.Context.Issue(Server.MapPath("~")).getAll();
                if (search.includeTitle)
                {
                    var filtered = issues.Where(i => i.title.Contains(search.textToSearch)).ToList();
                    searchedIssues = searchedIssues.Union(filtered).ToList();
                }
                if (search.includeSymptom)
                {
                    var filtered = issues.Where(i => i.symptom.Contains(search.textToSearch)).ToList();
                    searchedIssues = searchedIssues.Union(filtered).ToList();
                }
                if (search.includeDiagnostic)
                {
                    var filtered = issues.Where(i => i.diagnostic.Contains(search.textToSearch)).ToList();
                    searchedIssues = searchedIssues.Union(filtered).ToList();
                }
                if (search.includeFix)
                {
                    var filtered = issues.Where(i => i.fix.Contains(search.textToSearch)).ToList();
                    searchedIssues = searchedIssues.Union(filtered).ToList();
                }
                if (search.includeComments)
                {
                    var filtered = issues.Where(i => i.comments.Contains(search.textToSearch)).ToList();
                    searchedIssues = searchedIssues.Union(filtered).ToList();
                }
                search.issues = searchedIssues;
                return View("Search", search);
            }
            else
            {
                ModelState.Clear();
                return RedirectToAction("Search");
            }
        }

        public ActionResult Detail(Guid id)
        {
            var issues = new KnowledgeBase.Services.DataBase.Context.Issue(Server.MapPath("~")).getAll();
            IssueModel issue = issues.Where(i => i.id == id).FirstOrDefault();
            return View("Detail", issue);
        }
    }
}