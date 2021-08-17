using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace VRS_Eng_Manage_Tool.Business.Excel
{
    public static class Audits
    {
        #region [ Buil Auditd Worksheet ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xlPackage"></param>
        /// <param name="rType"></param>
        /// <param name="module"></param>
        /// <returns></returns>
        public static ExcelWorksheet BuilAuditdWorksheet(ExcelPackage xlPackage, Data.Enum.Audit.ResultType rType, Data.Enum.ModuleType module)
        {
            #region [ Generate Header fields ]
            string sheetName = null;
            List<string> headerFields = null;

            switch (rType)
            {
                case Data.Enum.Audit.ResultType.NotInRAT1:
                case Data.Enum.Audit.ResultType.NotInSTP:
                    sheetName = rType.ToString();
                    headerFields = new List<string>()
                    {
                        "STP",
                        "TYPE",
                        "ID Structure",
                        "ID Value"
                    };
                    break;

                case Data.Enum.Audit.ResultType.Differences:
                    sheetName = string.Format("{0}_diff", module.ToString());
                    headerFields = new List<string>() { "STP" };
                    switch (module)
                    {
                        case Data.Enum.ModuleType.GTA:
                            headerFields.AddRange(new List<string>(Enum.GetNames(typeof(Data.Enum.ExcelHeaders.SimpleGTA))));
                            break;

                        case Data.Enum.ModuleType.OPCODE:
                            headerFields.AddRange(new List<string>(Enum.GetNames(typeof(Data.Enum.ExcelHeaders.SimpleOPCODE))));
                            break;

                        case Data.Enum.ModuleType.GTTSEL:
                            headerFields.AddRange(new List<string>(Enum.GetNames(typeof(Data.Enum.ExcelHeaders.GTTSEL))));
                            break;

                        case Data.Enum.ModuleType.GTTSET:
                            headerFields.AddRange(new List<string>(Enum.GetNames(typeof(Data.Enum.ExcelHeaders.SimpleHeaderGTTSET))));
                            break;

                        case Data.Enum.ModuleType.MRNSET:
                            headerFields.AddRange(new List<string>(Enum.GetNames(typeof(Data.Enum.ExcelHeaders.MRNSET))));
                            break;

                        case Data.Enum.ModuleType.DSTN:
                            headerFields.AddRange(new List<string>(Enum.GetNames(typeof(Data.Enum.ExcelHeaders.DSTN))));
                            break;

                        case Data.Enum.ModuleType.SLK:
                            headerFields.AddRange(new List<string>(Enum.GetNames(typeof(Data.Enum.ExcelHeaders.SLK))));
                            break;

                        case Data.Enum.ModuleType.ASSOC:
                            headerFields.AddRange(new List<string>(Enum.GetNames(typeof(Data.Enum.ExcelHeaders.ASSOC))));
                            break;

                        case Data.Enum.ModuleType.LOOPSET:
                            headerFields.AddRange(new List<string>(Enum.GetNames(typeof(Data.Enum.ExcelHeaders.LOOPSET))));
                            break;

                        case Data.Enum.ModuleType.TTMAP:
                            headerFields.AddRange(new List<string>(Enum.GetNames(typeof(Data.Enum.ExcelHeaders.TTMAP))));
                            break;
                    }
                    break;
            }
            #endregion

            ExcelWorksheet workSheet = MLVSoft_Common.Excel.ExcelBuilder.BuildExcelFrame(
                    xlPackage,
                    sheetName,
                    null,
                    "A1",
                    Color.FromArgb(31, 73, 125),
                    Color.White,
                    false,
                    null,
                    headerFields,
                    Color.FromArgb(0, 112, 192),
                    Color.White,
                    string.Format("A1:{0}1", MLVSoft_Common.Excel.Utilities.IndexToColumn(headerFields.Count)));

            return workSheet;
        }
        #endregion

        #region [ Insert NotIn Records ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workSheet"></param>
        /// <param name="stp"></param>
        /// <param name="module"></param>
        /// <param name="records"></param>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public static int InsertNotInRecords(
            ExcelWorksheet workSheet, 
            Data.Enum.STP stp, 
            Data.Enum.ModuleType module, 
            List<string> records, 
            int rowIndex, 
            List<string> commands = null, 
            List<string> rollbacks = null)
        {
            string idStructure = null;

            switch (module)
            {
                case Data.Enum.ModuleType.GTA:
                    idStructure = "Table;StartGTA;EndGTA";
                    break;

                case Data.Enum.ModuleType.OPCODE:
                    idStructure = "Table;OPCODE";
                    break;

                case Data.Enum.ModuleType.GTTSEL:
                    idStructure = "ANSI;INT;NATS;TT;NP;LSN";
                    break;

                case Data.Enum.ModuleType.GTTSET:
                    idStructure = "GTTSN;TYPE;CHECKM;SETIDX";
                    break;

                case Data.Enum.ModuleType.MRNSET:
                    idStructure = "MRNSET;NET;PC;RC";
                    break;

                case Data.Enum.ModuleType.DSTN:
                    idStructure = "DPC;TYPE;CLLI;LSN;RC;APCI";
                    break;

                case Data.Enum.ModuleType.SLK:
                    idStructure = "LOC;TYPE;LINK;LSN;SLC;ANAME";
                    break;

                case Data.Enum.ModuleType.ASSOC:
                    idStructure = "ANAME;LOC;PORT;ADAPTER";
                    break;
            }

            int commandIndex = 0;

            foreach (string item in records)
            {
                workSheet.Cells[rowIndex, 1].Value = stp.ToString();
                workSheet.Cells[rowIndex, 2].Value = module.ToString();
                workSheet.Cells[rowIndex, 3].Value = idStructure;
                workSheet.Cells[rowIndex, 4].Value = item;                

                MLVSoft_Common.Excel.EpplusManagement.SetRowBorder(workSheet.Cells, rowIndex, 4);
                MLVSoft_Common.Excel.EpplusManagement.HorizontalAligment(workSheet.Cells, rowIndex, 4, OfficeOpenXml.Style.ExcelHorizontalAlignment.Left);

                rowIndex++;
                commandIndex++;
            }

            return rowIndex;
        }
        #endregion

        #region [ Insert Differences Records ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workSheet"></param>
        /// <param name="stp"></param>
        /// <param name="records"></param>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public static int InsertDifferencesRecords(ExcelWorksheet workSheet, Data.Enum.STP stp, Dictionary<List<string>, List<string>> records, int rowIndex)
        {
            workSheet.Cells[rowIndex, 1].Value = "RAT1";
            workSheet.Cells[rowIndex + 1, 1].Value = stp.ToString();

            try
            {
                foreach (KeyValuePair<List<string>, List<string>> stpsRecords in records)
                {
                    for (int columnIndex = 0; columnIndex < stpsRecords.Key.Count; columnIndex++)
                    {
                        workSheet.Cells[rowIndex, columnIndex + 2].Value = stpsRecords.Key[columnIndex];
                        MLVSoft_Common.Excel.EpplusManagement.SetCellColor(workSheet.Cells[rowIndex, columnIndex + 2], Color.FromArgb(221, 235, 247));

                        workSheet.Cells[rowIndex + 1, columnIndex + 2].Value = stpsRecords.Value[columnIndex];

                        if (stpsRecords.Key[columnIndex] != stpsRecords.Value[columnIndex])
                        {
                            MLVSoft_Common.Excel.EpplusManagement.SetCellColor(workSheet.Cells[rowIndex, columnIndex + 2], Color.Yellow);
                            MLVSoft_Common.Excel.EpplusManagement.SetCellColor(workSheet.Cells[rowIndex + 1, columnIndex + 2], Color.Yellow);
                        }
                    }

                    MLVSoft_Common.Excel.EpplusManagement.SetRowBorder(workSheet.Cells, rowIndex, stpsRecords.Key.Count + 1);
                    MLVSoft_Common.Excel.EpplusManagement.HorizontalAligment(workSheet.Cells, rowIndex, stpsRecords.Key.Count, OfficeOpenXml.Style.ExcelHorizontalAlignment.Left);

                    MLVSoft_Common.Excel.EpplusManagement.SetRowBorder(workSheet.Cells, rowIndex + 1, stpsRecords.Key.Count + 1);
                    MLVSoft_Common.Excel.EpplusManagement.SetBottomRow(workSheet.Cells, rowIndex + 1, stpsRecords.Key.Count + 1);
                    MLVSoft_Common.Excel.EpplusManagement.HorizontalAligment(workSheet.Cells, rowIndex + 1, stpsRecords.Key.Count, OfficeOpenXml.Style.ExcelHorizontalAlignment.Left);

                    rowIndex += 2;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return rowIndex;
        }
        #endregion

        #region [ Loopset Errors ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loopsetInfo"></param>
        /// <param name="filePath"></param>
        public static void LoopsetErrors(List<Data.Audits.LoopsetData> loopsetInfo, string filePath)
        {
            ExcelPackage xlPackage = MLVSoft_Common.Excel.ExcelBuilder.BuildExcelPackage(filePath);
            int rowIndex = 2;

            try
            {
                string sheetName = "Loopset Audit";
                List<string> headerFields = new List<string>()
                {
                    "Table",
                    "GTA",
                    "End_GTA",
                    "ITU PC",
                    "Current LOOPSET",
                    "Suggested LOOPSET"
                };

                ExcelWorksheet workSheet = MLVSoft_Common.Excel.ExcelBuilder.BuildExcelFrame(
                    xlPackage,
                    sheetName,
                    null,
                    "A1",
                    Color.FromArgb(31, 73, 125),
                    Color.White,
                    false,
                    null,
                    headerFields,
                    Color.FromArgb(0, 112, 192),
                    Color.White,
                    string.Format("A1:{0}1", MLVSoft_Common.Excel.Utilities.IndexToColumn(headerFields.Count)));

                foreach (Data.Audits.LoopsetData item in loopsetInfo)
                {
                    workSheet.Cells[rowIndex, 1].Value = item.Table;
                    workSheet.Cells[rowIndex, 2].Value = item.Gta;
                    workSheet.Cells[rowIndex, 3].Value = item.End_Gta;
                    workSheet.Cells[rowIndex, 4].Value = item.DPC;
                    workSheet.Cells[rowIndex, 5].Value = item.Loopset;
                    workSheet.Cells[rowIndex, 6].Value = item.Suggested_Loopset;

                    MLVSoft_Common.Excel.EpplusManagement.SetRowBorder(workSheet.Cells, rowIndex, headerFields.Count);
                    MLVSoft_Common.Excel.EpplusManagement.HorizontalAligment(workSheet.Cells, rowIndex, headerFields.Count, OfficeOpenXml.Style.ExcelHorizontalAlignment.Left);

                    rowIndex+=1;
                }

                workSheet.Cells.Style.Font.Size = 9;
                workSheet.Cells.AutoFitColumns();
                workSheet.View.FreezePanes(2, 1);

                xlPackage.Save();
                xlPackage.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}