using System.Collections.Generic;

namespace VRS_Eng_Manage_Tool.Data.Audits
{
    public class AuditResult
    {
        public List<string> NotInRAT1 { get; set; }
        public List<string> NotInSTP { get; set; }
        public List<string> Differences { get; set; }
    }
}