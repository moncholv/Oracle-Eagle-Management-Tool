using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Resources;

namespace MLVSoft_Common.Utilities
{
    public static class General
    {
        #region [ Enable Controls ]
        public static void EnableControls(List<System.Windows.Forms.Control> controls, bool value)
        {
            foreach (System.Windows.Forms.Control item in controls)
                item.Enabled = value;
        }
        #endregion

        #region [ GetResourceElementsNames ]
        /// <summary>
        ///
        /// </summary>
        /// <param name="resourceSet"></param>
        /// <returns></returns>
        public static List<string> GetResourceElementsNames(ResourceSet resourceSet)
        {
            List<string> resultList = new List<string>();

            foreach (DictionaryEntry entry in resourceSet)
                resultList.Add(entry.Value.ToString());

            return resultList;
        }
        #endregion

        #region [ NumberToString ]
        /// <summary>
        ///
        /// </summary>
        /// <param name="number"></param>
        /// <param name="isCaps"></param>
        /// <returns></returns>
        public static string NumberToString(int number, bool isCaps)
        {
            Char c = (Char)((isCaps ? 65 : 97) + (number - 1));
            return c.ToString();
        }
        #endregion

        #region [ FromListToString ]
        /// <summary>
        ///
        /// </summary>
        /// <param name="list"></param>
        /// <param name="separator"></param>
        /// <param name="trim"></param>
        /// <returns></returns>
        public static string FromListToString(List<string> list, string separator, bool trim)
        {
            StringBuilder stringChain = null;

            if (list != null)
            {
                list.Sort();

                foreach (string gtrc in list)
                {
                    if (stringChain == null)
                        stringChain = new StringBuilder();
                    else
                        stringChain.Append(separator);

                    if(trim)
                        stringChain.Append(gtrc.Trim());
                    else
                        stringChain.Append(gtrc);
                }
            }

            if (stringChain != null)
                return stringChain.ToString();
            else
                return string.Empty;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="list"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static List<string> FromStringToList(string list, string separator)
        {
            return list.Trim().Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
        #endregion

        #region [ UnSelectDataGridAction ]
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void UnSelectDataGridAction(object sender, System.EventArgs e)
        {
            System.Windows.Forms.DataGridView dgView = (System.Windows.Forms.DataGridView)sender;

            if (dgView.SelectedCells.Count > 0)
            {
                if (dgView.CurrentCell != null)
                    dgView.CurrentCell.Selected = false;
            }
        }
        #endregion

        #region [ LoadDataTable ]
        /// <summary>
        ///
        /// </summary>
        /// <param name="odbAdapter"></param>
        /// <param name="dtResult"></param>
        public static void LoadDataTable(OleDbDataAdapter odbAdapter, out DataTable dtResult)
        {
            dtResult = new DataTable();
            odbAdapter.Fill(dtResult);
        }
        #endregion

        #region [ Get Resource Name By Value ]
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <param name="resourceNameSpace"></param>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static string GetResourceNameByValue(string value, string resourceNameSpace, System.Reflection.Assembly assembly)
        {
            System.Resources.ResourceManager rm = new System.Resources.ResourceManager(resourceNameSpace, assembly);

            var entry =
                rm.GetResourceSet(System.Threading.Thread.CurrentThread.CurrentCulture, true, true)
                  .OfType<DictionaryEntry>()
                  .FirstOrDefault(e => e.Value.ToString() == value);

            var key = entry.Key.ToString();
            return key;
        }
        #endregion

        #region [ Most Common ]
        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T MostCommon<T>(this IEnumerable<T> list)
        {
            var most = (from i in list
                        group i by i into grp
                        orderby grp.Count() descending
                        select grp.Key).First();

            return most;
        }
        #endregion

        #region [ Return Short Date String ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ReturnShortDateString(DateTime date)
        {
            string month = date.Month.ToString();
            string day = date.Day.ToString();

            return string.Format(
                "{0}{1}{2}",
                date.Year.ToString(),
                month.Length == 1 ? "0" + month : month,
                day.Length == 1 ? "0" + day : day);
        }
        #endregion

        #region [ List Starts With String ]
        public static bool ListStartsWithString(List<string> stringList, string searchString)
        {
            return stringList.AsParallel().Where(x => x.StartsWith(searchString)).Count() > 0;
        }
        #endregion

        #region [ GetAssemblyVersion ]
        public static string GetAssemblyVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            return fvi.FileVersion;
        }
        #endregion
    }
}