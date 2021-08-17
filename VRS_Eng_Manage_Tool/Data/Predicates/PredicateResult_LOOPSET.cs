using System.Collections.Generic;

namespace VRS_Eng_Manage_Tool.Data.Predicates
{
    public class PredicateResult_LOOPSET
    {
        public bool Started { get; set; }
        public List<OST.LOOPSET_Data> LoopsetInfo { get; set; }
    }
}