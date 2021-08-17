using System.Collections.Generic;

namespace VRS_Eng_Manage_Tool.Data.Predicates
{
    public class PredicateResult_MRNSET
    {
        public bool Started { get; set; }
        public List<OST.MRNSET_Data> MrnsetInfo { get; set; }
    }
}