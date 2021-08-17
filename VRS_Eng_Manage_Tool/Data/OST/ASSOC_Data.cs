using System.Collections.Generic;

namespace VRS_Eng_Manage_Tool.Data.OST
{
    public class ASSOC_Data
    {
        public string ANAME { get; set; }
        public string LOC { get; set; }
        public string PORT { get; set; }
        public string LINK { get; set; }
        public string ADAPTER { get; set; }
        public string VER { get; set; }
        public string LHOST { get; set; }
        public string ALHOST { get; set; }
        public string LOCAL_IP { get; set; }
        public string ALOCAL_IP { get; set; }
        public string LPORT { get; set; }
        public string RHOST { get; set; }
        public string ARHOST { get; set; }
        public string REMOTE_IP { get; set; }
        public string AREMOTE_IP { get; set; }
        public string RPORT { get; set; }

        public string ASSOC_ID
        {
            get { return string.Format(Business.Utilities.GetStringFormatAudit(2), string.Empty, ANAME.Substring(1, ANAME.Length - 1)); }
        }

        public string ASSOC_Footprint
        {
            get { return string.Format(Business.Utilities.GetStringFormatAudit(3), ANAME.Substring(1, ANAME.Length - 1), LOC, ADAPTER); }
        }

        public string ASSOC_AuditDetail
        {
            get { return string.Format(Business.Utilities.GetStringFormatAudit(4), ANAME.Substring(1, ANAME.Length - 1), LOC, PORT, ADAPTER); }
        }

        public List<string> ASSOC_AuditFields
        {
            get
            {
                return new List<string>()
                {
                    ANAME,
                    LOC,
                    PORT,
                    ADAPTER,
                    LHOST,
                    Business.Utilities.OnlyHyphen(ALHOST) ? "---" : ALHOST,
                    LOCAL_IP,
                    Business.Utilities.OnlyHyphen(ALOCAL_IP) ? "---" : ALOCAL_IP,
                    Business.Utilities.OnlyHyphen(LPORT) ? "---" : LPORT,
                    Business.Utilities.OnlyHyphen(RHOST) ? "---" : RHOST,
                    Business.Utilities.OnlyHyphen(ARHOST) ? "---" : ARHOST,
                    Business.Utilities.OnlyHyphen(REMOTE_IP) ? "---" : REMOTE_IP,
                    Business.Utilities.OnlyHyphen(AREMOTE_IP) ? "---" : AREMOTE_IP,
                    Business.Utilities.OnlyHyphen(RPORT) ? "---" : RPORT,
                };
            }
        }
    }
}