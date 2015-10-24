using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeBase.Models;

namespace KnowledgeBase.Services.DataBase.Context
{
    class Issue
    {
        private string connectionString;
        private XmlMappingSource mapping;

        public Issue(string serverPath)
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KnowledgeBaseConnection"].ConnectionString;
            mapping = XmlMappingSource.FromUrl(serverPath + "/Services/DataBase/Mappings/Issue.xml");
        }

        public bool add(IssueModel issue)
        {
            Guid id = issue.id;
            string title = issue.title;
            string symptom = issue.symptom;
            string diagnostic = issue.diagnostic;
            string fix = issue.fix;
            string comments = issue.comments;
            bool inserted = false;
            using (KnowledgeBaseContext dc = new KnowledgeBaseContext(connectionString, mapping))
            {
                if (dc.addIssue(id, title, symptom, diagnostic, fix, comments)>0)
                {
                    inserted = true;
                }
            }
            return inserted;
        }
    }
}
