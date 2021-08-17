namespace VRS_Eng_Manage_Tool.Data.OST
{
    public class MRNSET_Data
    {
        public string MRNSET { get; set; }
        public string NET { get; set; }
        public string PC { get; set; }
        public int RC { get; set; }
        public string DPC_Decimal { get; set; }
        public string CLLI { get; set; }

        public string MRNSET_Footprint
        {
            get
            {
                return string.Format(Business.Utilities.GetStringFormatAudit(4),
                    MRNSET,
                    NET,
                    PC,
                    RC);
            }
        }

        public string MRNSET_ID
        {
            get { return string.Format(Business.Utilities.GetStringFormatAudit(2), MRNSET, PC); }
        }

        public System.Collections.Generic.List<string> MRNSET_AuditFields
        {
            get
            {
                return new System.Collections.Generic.List<string>()
                {
                    MRNSET,
                    NET,
                    PC,
                    RC.ToString(),
                    DPC_Decimal.ToString(),
                    CLLI
                };
            }
        }
    }
}