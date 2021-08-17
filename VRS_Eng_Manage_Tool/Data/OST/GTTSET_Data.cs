using System.Collections.Generic;

namespace VRS_Eng_Manage_Tool.Data.OST
{
    public class GTTSET_Data
    {
        public string GTTSN { get; set; }
        public string NETDOM { get; set; }
        public Enum.GTTSET_Type Type { get; set; }
        public string NPSN { get; set; }
        public string CHECKMULCOMP { get; set; }
        public string SETIDX { get; set; }
        public string MEASRQD { get; set; }
        public string SXUDT { get; set; }
        public string NDGT { get; set; }

        public string GTTSET_ID
        {
            get { return string.Format(Business.Utilities.GetStringFormatAudit(2), GTTSN, Type.ToString()); }
        }

        public string GTTSET_Footprint
        {
            get
            {
                return string.Format(Business.Utilities.GetStringFormatAudit(9),
                    GTTSN,
                    NETDOM,
                    Type,
                    NPSN,
                    CHECKMULCOMP,
                    SETIDX,
                    MEASRQD,
                    SXUDT,
                    NDGT);
            }
        }

        public string GTTSET_AuditDetail
        {
            get
            {
                return string.Format(Business.Utilities.GetStringFormatAudit(4),
                    GTTSN,
                    Type,
                    CHECKMULCOMP,
                    SETIDX);
            }
        }

        public List<string> GTTSET_AuditFields
        {
            get
            {
                return new List<string>()
                {
                    GTTSN,
                    Type.ToString(),
                    Business.Utilities.OnlyHyphen(CHECKMULCOMP) ? "-" : CHECKMULCOMP,
                    SETIDX,
                    Business.Utilities.OnlyHyphen(SXUDT) ? "-" : SXUDT,
                    Business.Utilities.OnlyHyphen(NDGT) ? "-" : NDGT
                };
            }
        }
    }
}