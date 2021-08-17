using System.Collections.Generic;

namespace VRS_Eng_Manage_Tool.Data.Predicates
{
    public class PredicateResult_OPCODE
    {
        public bool Started { get; set; }
        public List<OST.OPCODE_Data> OpCodeInfo { get; set; }
    }
}