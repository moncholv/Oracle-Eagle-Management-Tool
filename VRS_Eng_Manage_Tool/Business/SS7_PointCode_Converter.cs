namespace VRS_Eng_Manage_Tool.Business
{
    public static class SS7_PointCode_Converter
    {
        #region [ DecimalToBit383 ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string DecimalToBit383(int value)
        {
            int firstbit = value & 14336;
            int secondbit = value & 2040;
            int thirdbit = value & 7;

            string secondParam = (secondbit >> 3).ToString();

            return (firstbit >> 11).ToString() + "-" + (secondParam.Length > 2 ? secondParam : "0" + secondParam) + "-" + (thirdbit >> 0).ToString();
        }
        #endregion

        #region [ _14Bit383_toDecimal ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string _14Bit383_toDecimal(string value)
        {
            string[] input = value.Split('-');

            int[] intValues = new int[3];
            for (int i = 0; i < 3; i++)
                intValues[i] = int.Parse(input[i]);

            intValues[0] = intValues[0] << 11;
            intValues[1] = intValues[1] << 3;
            intValues[2] = intValues[2] << 0;

            return (intValues[0] | intValues[1] | intValues[2]).ToString();
        }
        #endregion
    }
}