using System.Collections.Generic;

namespace VRS_Eng_Manage_Tool.Data.OST
{
    public class OPCODE_Data
    {
        public string Table { get; set; }
        public string ACN { get; set; }
        public string OPCODE { get; set; }
        public string PKGTYPE { get; set; }
        public string XLAT { get; set; }
        public string RI { get; set; }
        public string ITUPC { get; set; }
        public string MRNSET { get; set; }
        public string MAPSET { get; set; }
        public string SSN { get; set; }
        public string CCGT { get; set; }
        public string CGGTMOD { get; set; }
        public string GTMODID { get; set; }
        public string TESTMODE { get; set; }
        public string LOOPSET { get; set; }
        public string FALLBACK { get; set; }
        public string OPTSN { get; set; }
        public string CGSELID { get; set; }
        public string CDSELID { get; set; }
        public string OPCSN { get; set; }
        public string ACTSN { get; set; }
        public string PPMEASREQD { get; set; }
        public string CGPCACTION { get; set; }
        public string DEFMAPVR { get; set; }
        public string PRIO { get; set; }
        public string GTTSN { get; set; }
        public string NETDOM { get; set; }
        public string NDGT { get; set; }
        public string MRN { get; set; }
        public string DPC { get; set; }
        public string CGPC { get; set; }
        public string OPC { get; set; }
        public string NPSN { get; set; }
        public string SADDR { get; set; }
        public string EADDR { get; set; }

        public string OPCODE_ID
        {
            get
            {
                return string.Format(Business.Utilities.GetStringFormatAudit(2),
                    Table,
                    OPCODE);
            }
        }

        public string OPCODE_Footprint
        {
            get
            {
                return string.Format(Business.Utilities.GetStringFormatAudit(35),
                    Table,
                    ACN,
                    OPCODE,
                    PKGTYPE,
                    XLAT,
                    RI,
                    ITUPC,
                    MRNSET,
                    MAPSET,
                    SSN,
                    CCGT,
                    CGGTMOD,
                    GTMODID,
                    TESTMODE,
                    LOOPSET,
                    FALLBACK,
                    OPTSN,
                    CGSELID,
                    CDSELID,
                    OPCSN,
                    ACTSN,
                    PPMEASREQD,
                    CGPCACTION,
                    DEFMAPVR,
                    PRIO,
                    GTTSN,
                    NETDOM,
                    NDGT,
                    MRN,
                    DPC,
                    CGPC,
                    OPC,
                    NPSN,
                    SADDR,
                    EADDR);
            }
        }

        public List<string> OPCODE_AuditFields
        {
            get
            {
                return new List<string>()
                {
                    Table,
                    OPCODE,
                    ITUPC,
                    MRNSET,
                    Business.Utilities.OnlyHyphen(GTMODID) ? "-" : GTMODID,
                    LOOPSET,
                    Business.Utilities.OnlyHyphen(OPTSN) ? "-" : OPTSN,
                    Business.Utilities.OnlyHyphen(CDSELID) ? "-" : CDSELID,
                    Business.Utilities.OnlyHyphen(ACTSN) ? "-" : ACTSN
                };
            }
        }
    }
}