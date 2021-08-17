using System.Collections.Generic;
using OfficeOpenXml;
using System.Drawing;

namespace MLVSoft_Common.Excel
{
    public static class EpplusManagement
    {
        #region [ MergeCells ]
        /// <summary>
        ///
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="columnLetters"></param>
        /// <param name="firstRow"></param>
        /// <param name="lastRow"></param>
        public static void MergeCells(ExcelWorksheet worksheet, List<string> columnLetters, int firstRow, int lastRow)
        {
            foreach (string letter in columnLetters)
            {
                using (ExcelRange rng = worksheet.Cells[string.Format("{0}{1}:{0}{2}", letter, firstRow.ToString(), lastRow.ToString())])
                {
                    rng.Merge = true;
                    rng.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    rng.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Top;
                }
            }
        }
        #endregion

        #region [ MergeRows ]
        /// <summary>
        ///
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="columnLetters"></param>
        /// <param name="firstRow"></param>
        /// <param name="lastRow"></param>
        public static void MergeRows(ExcelWorksheet worksheet, List<string> columnLetters, int firstRow, int lastRow)
        {
            foreach (string letter in columnLetters)
            {
                using (ExcelRange rng = worksheet.Cells[string.Format("{0}{1}:{0}{2}", letter, firstRow.ToString(), lastRow.ToString())])
                {
                    rng.Merge = true;
                    rng.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    rng.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Top;
                }
            }
        }
        #endregion

        #region [ MergeColumns ]
        /// <summary>
        ///
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="firstLetter"></param>
        /// <param name="lastLetter"></param>
        /// <param name="rowIndex"></param>
        /// <param name="border"></param>
        /// <param name="center"></param>
        public static void MergeColumns(ExcelWorksheet worksheet, string firstLetter, string lastLetter, int rowIndex, bool border, bool center)
        {
            using (ExcelRange rng = worksheet.Cells[string.Format("{0}{2}:{1}{2}", firstLetter, lastLetter, rowIndex.ToString())])
            {
                rng.Merge = true;
                rng.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Top;
                if (border)
                    rng.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                if (center)
                    rng.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            }
        }
        #endregion

        #region [ BuildCenterHeader ]
        /// <summary>
        ///
        /// </summary>
        /// <param name="cellsRange"></param>
        /// <param name="backgroundColor"></param>
        /// <param name="fontColor"></param>
        public static void BuildCenterHeader(
            ExcelRange cellsRange,
            bool merge,
            Color backgroundColor,
            Color fontColor)
        {
            cellsRange.Merge = merge;
            cellsRange.Style.Font.Bold = true;
            cellsRange.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            cellsRange.Style.Fill.BackgroundColor.SetColor(backgroundColor);
            cellsRange.Style.Font.Color.SetColor(fontColor);
            cellsRange.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
            cellsRange.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            cellsRange.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
        }

        public static void BuildCenterHeader(
            ExcelRange cellsRange,
            bool merge,
            Color backgroundColor,
            Color fontColor,
            string fontName,
            float fontSize)
        {
            cellsRange.Merge = merge;
            cellsRange.Style.Font.Bold = true;
            cellsRange.Style.Font.Name = fontName;
            cellsRange.Style.Font.Size = fontSize;
            cellsRange.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            cellsRange.Style.Fill.BackgroundColor.SetColor(backgroundColor);
            cellsRange.Style.Font.Color.SetColor(fontColor);
            cellsRange.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
            cellsRange.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            cellsRange.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
        }
        #endregion

        #region [ BuildCustomHeader ]
        /// <summary>
        ///
        /// </summary>
        /// <param name="cellsRange"></param>
        /// <param name="bold"></param>
        /// <param name="backgroundColor"></param>
        /// <param name="fontColor"></param>
        /// <param name="borderStyle"></param>
        /// <param name="horizontalAlignment"></param>
        /// <param name="verticalAlignment"></param>
        public static void BuildCustomHeader(
            ExcelRange cellsRange,
            bool merge,
            bool bold,
            Color backgroundColor,
            Color fontColor,
            OfficeOpenXml.Style.ExcelBorderStyle borderStyle,
            OfficeOpenXml.Style.ExcelHorizontalAlignment horizontalAlignment,
            OfficeOpenXml.Style.ExcelVerticalAlignment verticalAlignment)
        {
            cellsRange.Merge = merge;
            cellsRange.Style.Font.Bold = bold;
            cellsRange.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            cellsRange.Style.Fill.BackgroundColor.SetColor(backgroundColor);
            cellsRange.Style.Font.Color.SetColor(fontColor);
            cellsRange.Style.Border.BorderAround(borderStyle);
            cellsRange.Style.HorizontalAlignment = horizontalAlignment;
            cellsRange.Style.VerticalAlignment = verticalAlignment;
        }
        #endregion

        #region [ SetCellColor ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cellsRange"></param>
        /// <param name="backgroundColor"></param>
        public static void SetCellColor(ExcelRange cellsRange, Color backgroundColor)
        {
            cellsRange.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            cellsRange.Style.Fill.BackgroundColor.SetColor(backgroundColor);
        }

        public static void SetCellColor(List<ExcelRange> cellsRange, Color backgroundColor)
        {
            foreach (ExcelRange cell in cellsRange)
            {
                cell.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                cell.Style.Fill.BackgroundColor.SetColor(backgroundColor);
            }
        }

        public static void SetCellColor(ExcelRange cellsRange, Color backgroundColor, int row, int startColumn, int numColumns)
        {
            for (int i = startColumn; i <= numColumns + startColumn - 1; i++)
            {
                cellsRange[row, i].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                cellsRange[row, i].Style.Fill.BackgroundColor.SetColor(backgroundColor);
            }
        }
        #endregion

        #region [ SetRowBorder ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cellsRange"></param>
        public static void SetRowBorder(List<ExcelRange> cellsRange)
        {
            foreach (ExcelRange cell in cellsRange)
                cell.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
        }

        public static void SetRowBorder(ExcelRange cellsRange, int row, int numColumns)
        {
            for (int i = 1; i <= numColumns; i++)
                cellsRange[row, i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
        }

        public static void SetRowBorder(ExcelRange cellsRange, int row, int startColumn, int numColumns)
        {
            for (int i = startColumn; i <= numColumns + startColumn - 1; i++)
                cellsRange[row, i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
        }

        public static void SetRowBorder(ExcelRange cellsRange)
        {
            cellsRange.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
        }
        #endregion

        #region [ SetTopRow ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cellsRange"></param>
        public static void SetTopRow(List<ExcelRange> cellsRange)
        {
            foreach (ExcelRange cell in cellsRange)
                cell.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thick;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cellsRange"></param>
        /// <param name="row"></param>
        /// <param name="numColumns"></param>
        /// <param name="startColumn"></param>
        public static void SetTopRow(ExcelRange cellsRange, int row, int startColumn, int numColumns)
        {
            for (int i = startColumn; i <= numColumns + startColumn - 1; i++)
                cellsRange[row, i].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
        }
        #endregion

        #region [ SetBottomRow ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cellsRange"></param>
        public static void SetBottomRow(List<ExcelRange> cellsRange)
        {
            foreach (ExcelRange cell in cellsRange)
                cell.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thick;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cellsRange"></param>
        /// <param name="row"></param>
        /// <param name="numColumns"></param>
        /// <param name="startColumn"></param>
        public static void SetBottomRow(ExcelRange cellsRange, int row, int numColumns)
        {
            for (int i = 1; i <= numColumns; i++)
                cellsRange[row, i].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
        }
        #endregion

        #region [ SetCellsFont ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cellsRange"></param>
        /// <param name="row"></param>
        /// <param name="numColumns"></param>
        /// <param name="startColumn"></param>
        /// <param name="fontName"></param>
        /// <param name="fontSize"></param>
        public static void SetCellsFont(ExcelRange cellsRange, int row, int numColumns, int startColumn, string fontName, float fontSize)
        {
            for (int i = startColumn; i <= numColumns + startColumn - 1; i++)
            {
                cellsRange[row, i].Style.Font.Name = fontName;
                cellsRange[row, i].Style.Font.Size = fontSize;
            }
        }
        #endregion

        #region [ CenterContent ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cellsRange"></param>
        public static void CenterContent(List<ExcelRange> cellsRange)
        {
            foreach (ExcelRange cell in cellsRange)
                cell.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cellsRange"></param>
        /// <param name="row"></param>
        /// <param name="numColumns"></param>
        public static void CenterContent(ExcelRange cellsRange, int row, int numColumns)
        {
            for (int i = 1; i <= numColumns; i++)
                cellsRange[row, i].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cellsRange"></param>
        /// <param name="row"></param>
        /// <param name="numColumns"></param>
        /// <param name="startColumn"></param>
        public static void CenterContent(ExcelRange cellsRange, int row, int startColumn, int numColumns)
        {
            for (int i = startColumn; i <= numColumns + startColumn - 1; i++)
                cellsRange[row, i].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
        }
        #endregion

        #region [ HorizontalAligment ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cellsRange"></param>
        /// <param name="row"></param>
        /// <param name="numColumns"></param>
        /// <param name="aligment"></param>
        public static void HorizontalAligment(ExcelRange cellsRange, int row, int numColumns, OfficeOpenXml.Style.ExcelHorizontalAlignment aligment)
        {
            for (int i = 1; i <= numColumns; i++)
                cellsRange[row, i].Style.HorizontalAlignment = aligment;
        }
        #endregion

        #region [ SetCellValue ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="ws"></param>
        /// <param name="rowIndex"></param>
        /// <param name="columnIndex"></param>
        public static void SetCellValue(string value, ExcelWorksheet ws, int rowIndex, int columnIndex)
        {
            if (MLVSoft_Common.Utilities.OnlyNumbers.IsNumeric(value))
            {
                ws.Cells[rowIndex, columnIndex].Style.Numberformat.Format = "0";
                ws.Cells[rowIndex, columnIndex].Value = int.Parse(value);
            }
            else
                ws.Cells[rowIndex, columnIndex].Value = value;
        }
        #endregion
    }
}
