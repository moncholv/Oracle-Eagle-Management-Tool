using System.Collections.Generic;

namespace VRS_Eng_Manage_Tool.Data.OST
{
    public class SLK_Data
    {
        public string LOC { get; set; }
        public string LINK { get; set; }
        public string LSN { get; set; }
        public string SLC { get; set; }
        public string TYPE { get; set; }
        public string ANAME { get; set; }
        public string SLKTPS { get; set; }
        public string MAXSLKTPS { get; set; }

        public string SLK_ID
        {
            get { return string.Format(Business.Utilities.GetStringFormatAudit(3), LOC, LSN.Substring(0, LSN.Length - 1), LINK); }
        }

        public string SLK_Footprint
        {
            get
            {
                return string.Format(Business.Utilities.GetStringFormatAudit(8),
                    LOC,
                    LINK,
                    LSN.Substring(0, LSN.Length - 1),
                    SLC,
                    TYPE,
                    ANAME.Substring(1, LSN.Length - 1),
                    SLKTPS,
                    MAXSLKTPS);
            }
        }

        public string SLK_AuditDetail
        {
            get
            {
                return string.Format(Business.Utilities.GetStringFormatAudit(6),
                    LOC,
                    TYPE,
                    LINK,
                    LSN,
                    SLC,                    
                    ANAME);
            }
        }

        public List<string> SLK_AuditFields
        {
            get
            {
                return new List<string>()
                {
                    LOC,
                    LINK,
                    LSN,
                    SLC,
                    TYPE,
                    ANAME,
                    SLKTPS,
                    MAXSLKTPS
                };
            }
        }
    }
}