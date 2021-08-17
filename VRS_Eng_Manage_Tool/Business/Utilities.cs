using System;
using System.Collections.Generic;
using System.Linq;
namespace VRS_Eng_Manage_Tool.Business
{
    public static class Utilities
    {
        #region [ ContainsAny ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needles"></param>
        /// <returns></returns>
        public static bool ContainsAny(this string haystack, params string[] needles)
        {
            foreach (string needle in needles)
            {
                if (haystack.Contains(needle))
                    return true;
            }

            return false;
        }
        #endregion

        #region [ GetFieldValue ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string GetFieldValue(string name, string data)
        {
            string value = null;

            try
            {
                data = data.TrimStart();
                int startIndex = data.IndexOf(name);
                int endValueIndex = data.Substring(startIndex + name.Length, (data.Length - (startIndex + name.Length))).IndexOf(" ");
                value = data.Substring(startIndex + name.Length, endValueIndex != -1 ? endValueIndex : (data.Length - (startIndex + name.Length))); 
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return value;
        }
        #endregion

        #region [ GetEnumValues ]
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> GetEnumValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
        #endregion

        #region [ GetStringsInLine ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static List<string> GetStringsInLine(string line, bool punctuation)
        {
            if(punctuation)
            {
                var punctuationList = line.Where(Char.IsPunctuation).Distinct().ToArray();
                var words = line.Split().Select(x => x.Trim(punctuationList));
                return words.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
            }
            else
            {
                var words = line.Split();
                return words.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
            }
        }
        #endregion

        #region [ GetStringFormatAudit ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="elements"></param>
        /// <returns></returns>
        public static string GetStringFormatAudit(int elements)
        {
            System.Text.StringBuilder result = new System.Text.StringBuilder();

            for (int i = 0; i < (elements - 1); i++)
                result.Append("{" + i.ToString() + "}|");

            result.Append("{" + (elements - 1).ToString() + "}");

            return result.ToString();
        }
        #endregion

        #region [ Copy Listbox elements to Clipboard ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listboxItems"></param>
        /// <returns></returns>
        public static string CopyListboxElementsToClipboard(System.Windows.Forms.ListBox.ObjectCollection listboxItems)
        {
            System.Text.StringBuilder elements = new System.Text.StringBuilder();

            foreach (var item in listboxItems)
            {
                if(!OnlyHyphen(item.ToString()))
                    elements.AppendLine(item.ToString());
            }

            string finalString = System.Text.RegularExpressions.Regex.Replace(elements.ToString(), @"^\s*$\n|\r", string.Empty, System.Text.RegularExpressions.RegexOptions.Multiline).TrimEnd();

            System.Windows.Forms.Clipboard.SetText(finalString);

            return finalString;
        }
        #endregion

        #region [ Only has hyphen elements ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static bool OnlyHyphen(string word)
        {
            bool result = false;
            List<char> letters = new List<char>();
            letters.AddRange(word);

            if (letters.Distinct().Count() == 1 && letters[0] == '-')
                result = true;

            return result;
        }
        #endregion

        #region [ StartsWith ]
        public static bool StartsWith(string text)
        {
            return text.Substring(text.Length - 1, 1) == "*";
        }
        #endregion

        #region [ GetStartText ]
        public static string GetStartText(string text)
        {
            return text.Substring(0, text.Length - 1);
        }
        #endregion

        #region [ ArrayToList ]
        public static List<T> ArrayToList<T>(T[] array)
        {
            return array.ToList();
        }
        #endregion
    }
}