namespace VRS_Eng_Manage_Tool.Data.OST
{
    public class GTA_Data
    {
        public string Table { get; set; }
        public string Start_GTA { get; set; }
        public string End_GTA { get; set; }
        public string XLAT { get; set; }
        public string RI { get; set; }
        public string ITU_PC { get; set; }
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
        public string GTTSN { get; set; }
        public string NETDOM { get; set; }
        public string NDGT { get; set; }
        public string MRN { get; set; }
        public string OPCODE { get; set; }
        public string ACN { get; set; }
        public string DPC { get; set; }
        public string CGPC { get; set; }
        public string OPC { get; set; }
        public string NPSN { get; set; }
        public string SADDR { get; set; }
        public string EADDR { get; set; }
        public string DEFMAPVR { get; set; }
        public string PRIO { get; set; }

        public string GTA_ID
        {
            get
            {
                return string.Format(Business.Utilities.GetStringFormatAudit(3),
                    Table,
                    Start_GTA,
                    End_GTA);
            }
        }

        public string GTA_Footprint
        {
            get
            {
                return string.Format(Business.Utilities.GetStringFormatAudit(36),
                    Table,
                    Start_GTA,
                    End_GTA,
                    XLAT,
                    RI,
                    ITU_PC,
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
                    GTTSN,
                    NETDOM,
                    NDGT,
                    MRN,
                    OPCODE,
                    ACN,
                    DPC,
                    CGPC,
                    OPC,
                    NPSN,
                    SADDR,
                    EADDR,
                    DEFMAPVR,
                    PRIO);
            }
        }

        public System.Collections.Generic.List<string> GTA_AuditFields
        {
            get
            {
                return new System.Collections.Generic.List<string>()
                {
                    Table,
                    Start_GTA,
                    End_GTA,
                    XLAT,
                    RI,
                    ITU_PC,
                    MRNSET,
                    MAPSET,
                    SSN,
                    Business.Utilities.OnlyHyphen(GTMODID) ? "-" : GTMODID,
                    LOOPSET,
                    FALLBACK,
                    Business.Utilities.OnlyHyphen(OPTSN) ? "-" : OPTSN,
                    Business.Utilities.OnlyHyphen(CDSELID) ? "-" : CDSELID,
                    Business.Utilities.OnlyHyphen(ACTSN) ? "-" : ACTSN
                };
            }
        }
    }
}