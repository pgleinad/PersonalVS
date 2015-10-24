using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;

namespace KnowledgeBase.Services.DataBase.Context
{
    public class KnowledgeBaseContext : DataContext
    {
        public KnowledgeBaseContext(string connectionString, XmlMappingSource xmlMap) : base(connectionString, xmlMap) { }

        public int addIssue(Guid id, string title, string symptom, string diagnostic, string fix, string comments)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), id, title, symptom, diagnostic, fix, comments);
            return (int)result.ReturnValue;
        }
    }
}