using System.Collections.Generic;

namespace VRS_Eng_Manage_Tool.Data.OST
{
    public class TTMAP_Data
    {
        public string LSN { get; set; }
        public string IO { get; set; }
        public string ETT { get; set; }
        public string MTT { get; set; }

        public string TTMAP_ID
        {
            get { return string.Format(Business.Utilities.GetStringFormatAudit(2), string.Empty, LSN.Substring(0, LSN.Length - 1)); }
        }

        public string TTMAP_AuditDetail
        {
            get { return string.Format(Business.Utilities.GetStringFormatAudit(4), LSN.Substring(0, LSN.Length - 1), IO, ETT, MTT); }
        }

        public List<string> TTMAP_AuditFields
        {
            get
            {
                return new List<string>()
                {
                    LSN,
                    IO,
                    ETT,
                    MTT
                };
            }
        }

        public string TTMAP_Footprint
        {
            get
            {
                return string.Format(Business.Utilities.GetStringFormatAudit(4),
                    LSN.Substring(0, LSN.Length - 1),
                    IO,
                    ETT,
                    MTT);
            }
        }
    }
}