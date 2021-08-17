using System.Collections.Generic;

namespace VRS_Eng_Manage_Tool.Data
{
    public class OperatorData : Romina.RominaAgentBasic
    {
        public Data.Enum.RangeType UpperSubRange { get; set; }
        public string MRNSET { get; set; }
        public string ITU_PC { get; set; }
        public string ITU_PC_CLLI { get; set; }
        public string LOOPSET { get; set; }
        public string OPTSN { get; set; }
        public string PDF_Path { get; set; }
        public string XML_Path { get; set; }
        public Dictionary<string, string> MRNSET_DPCs { get; set; }
        public List<string> NP1Routing { get; set; }
        public List<string> HomeAgreements { get; set; }
        public List<string> VisitedAgreements { get; set; }
    }
}