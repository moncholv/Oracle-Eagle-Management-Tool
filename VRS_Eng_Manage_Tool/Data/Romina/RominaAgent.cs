namespace VRS_Eng_Manage_Tool.Data.Romina
{
    public class RominaAgent : RominaAgentBasic
    {
        public string Signalling_Group_GEO { get; set; }
        public string PCode { get; set; }
        public string WOW { get; set; }
        public string GTRC { get; set; }     
        public string SP { get; set; }
        public string Destination { get; set; }
        public string Standard { get; set; }
        public string ACC { get; set; }
        public string Main_TSC_hubbed { get; set; }
        public string Service_Type { get; set; }
        public string Peering_Hub { get; set; }
        public string SoR { get; set; }
        public string BRG { get; set; }
        public string OTA { get; set; }
        public string HSoR { get; set; }
        public string VHE { get; set; }
        public string WSMS { get; set; }
        public string SMS_HUB { get; set; }
        public string Standard_2 { get; set; }
        public string ACC_2 { get; set; }
        public string Main_TSC_3rd { get; set; }
        public string TSC_2 { get; set; }        

        public string StringChain()
        {
            return string.Format(
                "{0},{1},{2},{3},{4},{5}",
                Type.ToUpper(),
                TSC.ToUpper(),
                Country.ToUpper(),
                Name.ToUpper(),
                IMSI.Replace("#", ""),
                !string.IsNullOrEmpty(MGT) ? MGT.Replace("#", "") : string.Empty);
        }

        public bool SpecificSearch(string search)
        {
            if (Type.ToUpper() == search)
                return true;

            if (TSC.ToUpper() == search)
                return true;

            if (Country.ToUpper() == search)
                return true;

            if (Name.ToUpper() == search)
                return true;

            if (IMSI.Replace("#", "") == search)
                return true;

            if (!string.IsNullOrEmpty(MGT) && MGT.Replace("#", "") == search)
                return true;

            return false;
        }

        public bool StartsWithSearch(string search)
        {
            if (Type.ToUpper().StartsWith(search))
                return true;

            if (TSC.ToUpper().StartsWith(search))
                return true;

            if (Country.ToUpper().StartsWith(search))
                return true;

            if (Name.ToUpper().StartsWith(search))
                return true;

            if (IMSI.Replace("#", "").StartsWith(search))
                return true;

            if (!string.IsNullOrEmpty(MGT) && MGT.Replace("#", "").StartsWith(search))
                return true;

            return false;
        }
    }
}