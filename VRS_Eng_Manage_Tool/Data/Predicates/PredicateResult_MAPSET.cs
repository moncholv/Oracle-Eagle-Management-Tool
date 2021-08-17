using System.Collections.Generic;

namespace VRS_Eng_Manage_Tool.Data.Predicates
{
    public class PredicateResult_MAPSET
    {
        public bool Started { get; set; }
        public List<OST.MAPSET_Data> MapsetInfo { get; set; }
    }
}