using System.Collections.Generic;

namespace VRS_Eng_Manage_Tool.Data.OST
{
    public class STP_Info
    {
        public List<GTA_Data> GTA_Data { get; set; }
        public List<GTTSEL_Data> GTTSelData { get; set; }
        public List<GTTSET_Data> GTTSetData { get; set; }
        public List<OPCODE_Data> OpCodeData { get; set; }
        public List<MRNSET_Data> MrnsetData { get; set; }
        public List<MAPSET_Data> MapsetData { get; set; }
        public List<DSTN_Data> DstnData { get; set; }
        public List<SLK_Data> SlkData { get; set; }
        public List<ASSOC_Data> AssocData { get; set; }
        public List<HOST_Data> HostData { get; set; }
        public List<LOOPSET_Data> LoopsetData { get; set; }
        public List<TTMAP_Data> TTMapData { get; set; }

        public bool HasValues()
        {
            if (GTA_Data != null || GTTSelData != null || GTTSetData != null || OpCodeData != null || MrnsetData != null || 
                MapsetData != null || DstnData != null || SlkData != null || AssocData != null || HostData != null || LoopsetData != null || TTMapData != null)
                return true;

            return false;
        }
    }
}