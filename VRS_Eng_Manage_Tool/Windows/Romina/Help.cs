using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VRS_Eng_Manage_Tool.Windows.Romina
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();

            this.KeyDown += Window_KeyDown;

            StringBuilder text = new StringBuilder();
            text.AppendLine("-- Advanced Search Functionality --");
            text.AppendLine("");
            text.AppendLine("This tool provides the ability to obtain Romina Agents information offline.");
            text.AppendLine("(Romina data must be loaded)");
            text.AppendLine("");
            text.AppendLine("");
            text.AppendLine("Search Types:");
            text.AppendLine("----------------------");
            text.AppendLine("");
            text.AppendLine("------ Generic -----");
            text.AppendLine("");
            text.AppendLine("    Anything that contains the typed value.");
            text.AppendLine("");
            text.AppendLine("");
            text.AppendLine("----- Specific -----");
            text.AppendLine("");
            text.AppendLine("    Any agent that has a field that is exactly as typed inside quotes --> (Ex. \"2050\").");
            text.AppendLine("");
            text.AppendLine("");
            text.AppendLine("----- By Field -----");
            text.AppendLine("");
            text.AppendLine("    IMSI 214 --> Will meet any agent that has this field containing the value.");
            text.AppendLine("    IMSI \"21401\" --> Will meet any agent that this field with exactly the value inside quotes.");
            text.AppendLine("");
            text.AppendLine("    Available fields to filter with:");
            text.AppendLine("    ------------------------------------------");
            text.AppendLine("     TSC (T)");
            text.AppendLine("     MGT (MG)");
            text.AppendLine("     IMSI (I)");
            text.AppendLine("     NAME (NA)");
            text.AppendLine("     NGT (NG)");
            text.AppendLine("     MSISDN (MS)");
            text.AppendLine("");
            text.AppendLine("");
            text.AppendLine("[ Additional search parameters ]");
            text.AppendLine("Both in Generic and By Field searchs, we can include -S to search info starting with the typed values.");
            text.AppendLine("Examples:");
            text.AppendLine("  -S 210 --> Will meet any agent that has a field that starts with that value.");
            text.AppendLine("  IMSI -S 210 --> Will meet any agent that which its field IMSI starts with that value.");

            this.HelpInfo_label.Text = text.ToString();
            this.Text = "Advanced Search Help";
        }

        void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                this.Dispose();
            }
        }
    }
}
