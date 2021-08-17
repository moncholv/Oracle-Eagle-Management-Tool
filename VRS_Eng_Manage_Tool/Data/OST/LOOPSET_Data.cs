using System.Collections.Generic;

namespace VRS_Eng_Manage_Tool.Data.OST
{
    public class LOOPSET_Data
    {
        public string Loopset { get; set; }
        public string Mode { get; set; }
        public string PointCode { get; set; }
        public Enum.LoopsetType Type { get; set; }

        public string LOOPSET_ID
        {
            get { return string.Format(Business.Utilities.GetStringFormatAudit(2), Loopset, PointCode); }
        }

        public string LOOPSET_AuditDetail
        {
            get { return string.Format(Business.Utilities.GetStringFormatAudit(4), Loopset, Mode, PointCode, Type.ToString()); }
        }

        public List<string> LOOPSET_AuditFields
        {
            get
            {
                return new List<string>()
                {
                    Loopset,
                    Mode,
                    PointCode,
                    Type.ToString()
                };
            }
        }

        public string LOOPSET_Footprint
        {
            get
            {
                return string.Format(Business.Utilities.GetStringFormatAudit(4),
                    Loopset,
                    Mode,
                    PointCode,
                    Type.ToString());
            }
        }
    }
}