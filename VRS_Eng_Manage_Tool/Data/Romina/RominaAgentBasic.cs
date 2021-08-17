using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRS_Eng_Manage_Tool.Data.Romina
{
    public class RominaAgentBasic
    {
        public string Type { get; set; }
        public string TSC { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public string IMSI { get; set; }
        public string MGT { get; set; }
        public List<string> NGT { get; set; }
        public List<string> MSISDNs { get; set; }
    }
}