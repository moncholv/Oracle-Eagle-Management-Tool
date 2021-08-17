using System;
using System.Collections.Generic;

namespace VRS_Eng_Manage_Tool.Data.Confluence
{
    public class Agreements
    {
        public string TSC { get; set; }
        public Enum.Agent_Type Agent_Type { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public string IMSI { get; set; }
        public string MGT { get; set; }
        public string State { get; set; }
        public string Hub_Connected { get; set; }
        public DateTime INTX_Date { get; set; }
        public Enum.Connection_Type Connection_Type { get; set; }
        public string MRNSET { get; set; }
        public List<string> DPC_338_FORMAT { get; set; }
        public List<string> DPC_DEC_FORMAT { get; set; }
        public string LOOPSET { get; set; }
        public string BulkUpload_R__IN { get; set; }
        public string SoR__IPN { get; set; }
        public string BRG { get; set; }
        public string OTA { get; set; }
        public string HSoR { get; set; }
        public string VHE { get; set; }
        public string WSMS { get; set; }
        public string SMS__HUB { get; set; }
        public string IPX_Root_DNS { get; set; }
        public string SS7_FW { get; set; }
        public string Peering_Hub { get; set; }
        public string Responsability { get; set; }
        public string Comments { get; set; }
    }
}