using System;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeBase.Models
{
    public class IssueModel
    {
        [Required]
        public Guid id { get; set; }
        [Required]
        [Display(Name ="Title")]
        public string title { get; set; }
        [Required]
        [Display(Name = "Symptom")]
        public string symptom { get; set; }
        [Required]
        [Display(Name = "Diagnostic")]
        public string diagnostic { get; set; }
        [Required]
        [Display(Name = "Fix")]
        public string fix { get; set; }
        [Required]
        [Display(Name = "Creation Date")]
        public DateTime createdDate { get; set; }
        [Display(Name = "Comments")]
        public string comments { get; set; }
    }
}
