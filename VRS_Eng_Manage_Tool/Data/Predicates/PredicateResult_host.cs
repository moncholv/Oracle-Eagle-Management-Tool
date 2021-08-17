using System.Collections.Generic;

namespace VRS_Eng_Manage_Tool.Data.Predicates
{
    public class PredicateResult_HOST
    {
        public bool Started { get; set; }
        public List<OST.HOST_Data> HostInfo { get; set; }
    }
}