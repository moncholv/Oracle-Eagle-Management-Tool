using System.Windows.Forms;

namespace VRS_Eng_Manage_Tool.Business
{
    public static class OnlyNumbers
    {
        public static void OnlyNumbers_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);

            if (!char.IsControl(e.KeyChar))
            {
                if (!char.IsDigit(e.KeyChar))
                    e.Handled = true;
            }
            else if (e.KeyChar == '\b' || e.KeyChar == '\r') //tecla borrado o enter
                e.Handled = false;
        }

        public static void OnlyNumbers_dash_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);

            if (!char.IsControl(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != ' ')
            {
                if (!char.IsDigit(e.KeyChar))
                    e.Handled = true;
            }
            else if (e.KeyChar == '\b' || e.KeyChar == '-' || e.KeyChar == '\r' || e.KeyChar == ' ') //tecla borrado, enter, guión o espacio
                e.Handled = false;
        }

        public static bool IsNumeric(this string s)
        {
            float output;
            return float.TryParse(s, out output);
        }
    }
}