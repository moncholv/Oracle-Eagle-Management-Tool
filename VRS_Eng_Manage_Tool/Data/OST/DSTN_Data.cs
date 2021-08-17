namespace VRS_Eng_Manage_Tool.Data.OST
{
    public class DSTN_Data
    {
        public string DPC { get; set; }
        public string DPC_Dec { get; set; }
        public Enum.DSTN_Type Type { get; set; }
        public string CLLI { get; set; }
        public string LSN { get; set; }
        public string RC { get; set; }
        public string APCI { get; set; }
        public string APCI_Dec { get; set; }

        public string DSTN_ID
        {
            get { return string.Format(Business.Utilities.GetStringFormatAudit(2), Type, DPC); }
        }

        public string DSTN_Footprint
        {
            get
            {
                return string.Format(Business.Utilities.GetStringFormatAudit(6),
                    DPC,
                    Type,
                    CLLI,
                    LSN.Substring(0, LSN.Length - 1),
                    RC,
                    APCI);
            }
        }

        public System.Collections.Generic.List<string> DSTN_AuditFields
        {
            get
            {
                return new System.Collections.Generic.List<string>()
                {
                    Type.ToString(),
                    DPC,
                    DPC_Dec,
                    CLLI,
                    LSN.Substring(0, LSN.Length - 1),
                    RC,
                    APCI,
                    APCI_Dec
                };
            }
        }
    }
}