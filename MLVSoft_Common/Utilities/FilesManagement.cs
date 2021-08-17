using System;
using System.Text;
using System.IO;
using System.Windows.Forms;
using ExcelLibrary.SpreadSheet;

namespace MLVSoft_Common.Utilities
{
    public static class FilesManagement
    {
        #region [ GenerateResultDirectory ]
        /// <summary>
        ///
        /// </summary>
        /// <param name="originPath"></param>
        /// <param name="definition"></param>
        /// <returns></returns>
        public static string GenerateResultDirectory(string originPath, string definition, DateTime dateTime)
        {
            StringBuilder outputPathChain = new StringBuilder();

            outputPathChain.Append(originPath);
            outputPathChain.Append("\\");
            outputPathChain.Append(dateTime.Year.ToString());
            outputPathChain.Append(dateTime.Month.ToString().Length == 1 ? "0" + dateTime.Month.ToString() : dateTime.Month.ToString());
            outputPathChain.Append(dateTime.Day.ToString().Length == 1 ? "0" + dateTime.Day.ToString() : dateTime.Day.ToString());
            outputPathChain.Append("_");
            outputPathChain.Append(dateTime.Hour.ToString().Length == 1 ? "0" + dateTime.Hour.ToString() : dateTime.Hour.ToString());
            outputPathChain.Append(dateTime.Minute.ToString().Length == 1 ? "0" + dateTime.Minute.ToString() : dateTime.Minute.ToString());
            outputPathChain.Append(definition);
            Directory.CreateDirectory(outputPathChain.ToString());
            return outputPathChain.ToString();
        }
        #endregion

        #region [ GetPartialFileName ]
        /// <summary>
        ///
        /// </summary>
        /// <param name="originPath"></param>
        /// <param name="actionDateTime"></param>
        /// <returns></returns>
        public static string GetPartialFileName(string originPath, DateTime actionDateTime)
        {
            StringBuilder fileNamePart1 = new StringBuilder();
            fileNamePart1.Append(originPath + @"\");
            fileNamePart1.Append(actionDateTime.Year.ToString());
            fileNamePart1.Append(actionDateTime.Month.ToString().Length == 1 ? "0" + actionDateTime.Month.ToString() : actionDateTime.Month.ToString());
            fileNamePart1.Append(actionDateTime.Day.ToString().Length == 1 ? "0" + actionDateTime.Day.ToString() : actionDateTime.Day.ToString());
            fileNamePart1.Append("_");
            fileNamePart1.Append(actionDateTime.Hour.ToString().Length == 1 ? "0" + actionDateTime.Hour.ToString() : actionDateTime.Hour.ToString());
            fileNamePart1.Append(actionDateTime.Minute.ToString().Length == 1 ? "0" + actionDateTime.Minute.ToString() : actionDateTime.Minute.ToString());

            return fileNamePart1.ToString();
        }
        #endregion

        #region [ Select File Dialog ]
        /// <summary>
        ///
        /// </summary>
        /// <param name="fileType"></param>
        /// <param name="fileExtension"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string SelectFileDialog(string fileType, string fileExtension, string title)
        {
            OpenFileDialog selectedFile = new OpenFileDialog();
            selectedFile.DefaultExt = fileType;
            selectedFile.Filter = string.Format("{0} files (*.{1})|*.{1}", fileType, fileExtension);
            selectedFile.Title = title;
            
            if (selectedFile.ShowDialog() == DialogResult.OK)
                return selectedFile.FileName;
            else
                return string.Empty;
        }
        #endregion

        #region [ Save File Dialog ]
        /// <summary>
        ///
        /// </summary>
        /// <param name="fileType"></param>
        /// <param name="fileExtension"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string SaveFileDialog(string fileType, string fileExtension, string title, string fileName = null)
        {
            SaveFileDialog saveFDialog = new SaveFileDialog();
            saveFDialog.InitialDirectory = "%USERPROFILE%";
            saveFDialog.RestoreDirectory = true;
            saveFDialog.Title = title;
            saveFDialog.FileName = string.IsNullOrEmpty(fileName) ? string.Empty : fileName;

            saveFDialog.Filter = string.Format("{0} documents (*.{1})|*.{1}", fileType, fileExtension);

            if (saveFDialog.ShowDialog() == DialogResult.OK)
                return saveFDialog.FileName;
            else
                return string.Empty;
        }
        #endregion

        #region [ Select Directory Dialog ]
        public static string SelectDirectoryDialog(string dialogMessage)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.ShowNewFolderButton = true;
            folderBrowser.Description = dialogMessage;
            
            if (folderBrowser.ShowDialog() == DialogResult.OK)
                return folderBrowser.SelectedPath;
            else
                return string.Empty;
        }
        #endregion

        #region [ GetCellData ]
        public static string GetCellData(Row rowData, int index)
        {
            object value = rowData.GetCell(index).Value;
            return value != null ? value.ToString().Replace("#", "") : string.Empty;
        }
        #endregion
    }
}