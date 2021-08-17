using System.Collections.Generic;

namespace VRS_Eng_Manage_Tool.Data.Predicates
{
    public class PredicateResult_DSTN
    {
        public bool Started { get; set; }
        public List<OST.DSTN_Data> DstnInfo { get; set; }
    }
}