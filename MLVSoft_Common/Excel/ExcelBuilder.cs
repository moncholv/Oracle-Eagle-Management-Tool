using System;
using System.Collections.Generic;
using OfficeOpenXml;

using EXCELSTYLE = OfficeOpenXml.Style;
using System.Drawing;
using System.IO;

namespace MLVSoft_Common.Excel
{
    public static class ExcelBuilder
    {
        #region [ Generate Excel Package ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static ExcelPackage BuildExcelPackage(string filePath)
        {
            ExcelPackage xlPackage = null;

            try
            {
                if (File.Exists(filePath))
                    File.Delete(filePath);

                xlPackage = new ExcelPackage(new FileInfo(filePath));

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return xlPackage;
        }
        #endregion

        #region [ BuildExcelFrame ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xlPackage"></param>
        /// <param name="workSheetName"></param>
        /// <param name="titleMessage"></param>
        /// <param name="titleRange"></param>
        /// <param name="titleBackgroundColor"></param>
        /// <param name="titleForeColor"></param>
        /// <param name="extendedTitle"></param>
        /// <param name="extendedTitleRange"></param>
        /// <param name="headerNames"></param>
        /// <param name="headerBackgroundColor"></param>
        /// <param name="headerForeColor"></param>
        /// <param name="autoFilterRange"></param>
        /// <returns></returns>
        public static ExcelWorksheet BuildExcelFrame(
            ExcelPackage xlPackage, 
            string workSheetName, 
            string titleMessage, 
            string titleRange, 
            Color titleBackgroundColor,
            Color titleForeColor, 
            bool extendedTitle, 
            string extendedTitleRange, 
            List<string> headerNames, 
            Color headerBackgroundColor, 
            Color headerForeColor, 
            string autoFilterRange)
        {
            ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets.Add(workSheetName);
            int row = 1;

            try
            {
                if (!string.IsNullOrEmpty(titleMessage))
                {
                    worksheet.Cells[1, 1].Value = titleMessage;
                    EpplusManagement.BuildCenterHeader(worksheet.Cells[titleRange], true, titleBackgroundColor, titleForeColor);

                    if (extendedTitle)
                        EpplusManagement.BuildCenterHeader(worksheet.Cells[extendedTitleRange], true, titleBackgroundColor, titleForeColor);

                    row = extendedTitle ? 3 : 2;
                }
                
                int index = 1;

                foreach (string name in headerNames)
                {
                    worksheet.Cells[row, index].Value = name;
                    index += 1;
                }

                for (int c = 1; c <= headerNames.Count; c++)
                {
                    EpplusManagement.BuildCustomHeader(
                        worksheet.Cells[row, c],
                        false,
                        true,
                        headerBackgroundColor,
                        headerForeColor,
                        EXCELSTYLE.ExcelBorderStyle.Thin,
                        EXCELSTYLE.ExcelHorizontalAlignment.Left,
                        EXCELSTYLE.ExcelVerticalAlignment.Center);
                }

                using (ExcelRange rng = worksheet.Cells[autoFilterRange])
                    rng.AutoFilter = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return worksheet;
        }
        #endregion

        #region [ Build Simple Header ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xlPackage"></param>
        /// <param name="workSheetName"></param>
        /// <param name="headerNames"></param>
        /// <param name="headerBackgroundColor"></param>
        /// <param name="headerForeColor"></param>
        /// <param name="autoFilterRange"></param>
        /// <returns></returns>
        public static ExcelWorksheet BuildSimpleHeader(ExcelPackage xlPackage, string workSheetName, List<string> headerNames, Color headerBackgroundColor, Color headerForeColor, string autoFilterRange)
        {
            ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets.Add(workSheetName);

            try
            {
                int column = 1;

                foreach (string name in headerNames)
                {
                    worksheet.Cells[1, column].Value = name;
                    column += 1;
                }

                for (int c = 1; c <= headerNames.Count; c++)
                {
                    EpplusManagement.BuildCustomHeader(
                        worksheet.Cells[1, c],
                        false,
                        true,
                        headerBackgroundColor,
                        headerForeColor,
                        EXCELSTYLE.ExcelBorderStyle.Thin,
                        EXCELSTYLE.ExcelHorizontalAlignment.Left,
                        EXCELSTYLE.ExcelVerticalAlignment.Center);
                }

                using (ExcelRange rng = worksheet.Cells[autoFilterRange])
                    rng.AutoFilter = true;
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return worksheet;
        }
        #endregion
    }
}