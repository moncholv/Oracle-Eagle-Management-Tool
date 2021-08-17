namespace VRS_Eng_Manage_Tool.Data.OST
{
    public class GTTSEL_Data
    {
        public string MSGTYPE { get; set; }
        public string ANSI { get; set; }
        public string INT { get; set; }
        public string NAT { get; set; }
        public string N24 { get; set; }
        public string INTS { get; set; }
        public string NATS { get; set; }
        public string TT { get; set; }
        public string NP { get; set; }
        public string NAI { get; set; }
        public string SSN { get; set; }
        public string SELID { get; set; }
        public string LSN { get; set; }
        public string CDPA_GTTSET { get; set; }
        public string CGPA_GTTSET { get; set; }

        public string GTTSEL_ID
        {
            get
            {
                return string.Format(Business.Utilities.GetStringFormatAudit(7),
                    MSGTYPE,
                    ANSI,
                    LSN.Substring(0, LSN.Length - 1),
                    INT,
                    NATS,
                    TT,
                    NP);
            }
        }

        public string GTTSEL_Footprint
        {
            get
            {
                return string.Format(Business.Utilities.GetStringFormatAudit(15),
                    MSGTYPE,
                    ANSI,
                    INT,
                    NAT,
                    N24,
                    INTS,
                    NATS,
                    TT,
                    NP,
                    NAI,
                    SSN,
                    SELID,
                    LSN.Substring(0, LSN.Length - 1),
                    CDPA_GTTSET,
                    CGPA_GTTSET);
            }
        }

        public string GTTSEL_AuditDetail
        {
            get
            {
                return string.Format(Business.Utilities.GetStringFormatAudit(7),
                    MSGTYPE,
                    ANSI,
                    INT,
                    NATS,
                    TT,
                    NP,
                    LSN.Substring(0, LSN.Length - 1));
            }
        }

        public System.Collections.Generic.List<string> GTTSEL_AuditFields
        {
            get
            {
                return new System.Collections.Generic.List<string>()
                {
                    MSGTYPE,
                    ANSI,
                    INT,
                    NAT,
                    N24,
                    INTS,
                    NATS,
                    TT,
                    NP,
                    NAI,
                    Business.Utilities.OnlyHyphen(SSN) ? "-" : SSN,
                    SELID,
                    LSN,
                    CDPA_GTTSET,
                    Business.Utilities.OnlyHyphen(CGPA_GTTSET) ? "-" : CGPA_GTTSET
                };
            }
        }
    }
}