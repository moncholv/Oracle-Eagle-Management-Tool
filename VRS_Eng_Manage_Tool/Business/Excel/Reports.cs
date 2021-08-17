using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRS_Eng_Manage_Tool.Business.Excel
{
    public static class Reports
    {
        public static void RTMT_Report(ExcelPackage xlPackage, List<string> dataList)
        {
            int rowIndex = 1;
            ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets.Add("enrichment_ss7");

            try
            {
                foreach (string item in dataList)
                {
                    worksheet.Cells[rowIndex, 1].Value = item;
                    rowIndex += 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}