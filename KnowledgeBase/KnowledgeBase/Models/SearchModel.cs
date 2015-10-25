using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using PagedList;

namespace KnowledgeBase.Models
{
    public class SearchModel
    {
        [Required]
        [Display(Name="Text to search")]
        public string textToSearch { get; set; }
        [Display(Name ="Title")]
        public bool includeTitle { get; set; }
        [Display(Name = "Symptom")]
        public bool includeSymptom { get; set; }
        [Display(Name = "Diagnostic")]
        public bool includeDiagnostic { get; set; }
        [Display(Name = "Fix")]
        public bool includeFix { get; set; }
        [Display(Name = "Comments")]
        public bool includeComments { get; set; }
        public List<IssueModel> issues { get; set; }
        public IPagedList issuesPaged { get; set; }
    }
}