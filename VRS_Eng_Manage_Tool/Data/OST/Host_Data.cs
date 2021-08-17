namespace VRS_Eng_Manage_Tool.Data.OST
{
    public class HOST_Data
    {
        public Enum.Host_Type Type { get; set; }
        public string LOC { get; set; }
        public string IPADDR { get; set; }
        public string HOST { get; set; }

        public string HOST_ID
        {
            get
            {
                return string.Format(Business.Utilities.GetStringFormatAudit(4),
                    Type,
                    LOC,
                    IPADDR,
                    HOST);
            }
        }
    }
}