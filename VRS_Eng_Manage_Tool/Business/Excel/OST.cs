using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using DATA_ENUM = VRS_Eng_Manage_Tool.Data.Enum;

namespace VRS_Eng_Manage_Tool.Business.Excel
{
    public static class OST
    {
        #region [ GTA ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="opcodeData"></param>
        public static void GTA(ExcelPackage xlPackage, List<Data.OST.GTA_Data> gtaData, bool completeData)
        {
            int rowIndex = 0;

            List<string> completeHeaderGTA = new List<string>(Enum.GetNames(typeof(DATA_ENUM.ExcelHeaders.CompleteGTA)));
            List<string> simpleHeaderGTA = new List<string>(Enum.GetNames(typeof(DATA_ENUM.ExcelHeaders.SimpleGTA)));

            try
            {
                int numberColumns = completeData ? completeHeaderGTA.Count : simpleHeaderGTA.Count;

                ExcelWorksheet workSheet = MLVSoft_Common.Excel.ExcelBuilder.BuildExcelFrame(
                    xlPackage,
                    "GTA",
                    null,
                    "A1",
                    Color.FromArgb(31, 73, 125),
                    Color.White,
                    false,
                    null,
                    completeData ? completeHeaderGTA : simpleHeaderGTA,
                    Color.FromArgb(235, 241, 222),
                    Color.Black,
                    string.Format("A1:{0}1", MLVSoft_Common.Excel.Utilities.IndexToColumn(numberColumns)));

                rowIndex = 2;

                foreach (Data.OST.GTA_Data item in gtaData)
                {
                    try
                    {
                        workSheet.Cells[rowIndex, 1].Value = item.Table;

                        if (item.Start_GTA == "0" || (!item.Start_GTA.StartsWith("0") && MLVSoft_Common.Utilities.OnlyNumbers.IsNumeric(item.Start_GTA)))
                            workSheet.Cells[rowIndex, 2].Value = long.Parse(item.Start_GTA);
                        else
                            workSheet.Cells[rowIndex, 2].Value = item.Start_GTA;

                        if (item.End_GTA == "0" || (!item.End_GTA.StartsWith("0") && MLVSoft_Common.Utilities.OnlyNumbers.IsNumeric(item.End_GTA)))
                            workSheet.Cells[rowIndex, 3].Value = long.Parse(item.End_GTA);
                        else
                            workSheet.Cells[rowIndex, 3].Value = item.End_GTA;

                        workSheet.Cells[rowIndex, 4].Value = item.XLAT;
                        workSheet.Cells[rowIndex, 5].Value = item.RI;
                        workSheet.Cells[rowIndex, 6].Value = item.ITU_PC;

                        SetCellValue(workSheet, rowIndex, 7, item.MRNSET);
                        SetCellValue(workSheet, rowIndex, 8, item.MAPSET);
                        SetCellValue(workSheet, rowIndex, 9, item.SSN);

                        if (completeData)
                        {
                            SetCellValue(workSheet, rowIndex, 10, item.MAPSET);
                            SetCellValue(workSheet, rowIndex, 11, item.SSN);
                            SetCellValue(workSheet, rowIndex, 12, item.CCGT);
                            SetCellValue(workSheet, rowIndex, 13, item.CGGTMOD);
                            SetCellValue(workSheet, rowIndex, 14, item.GTMODID);
                            SetCellValue(workSheet, rowIndex, 15, item.TESTMODE);
                            SetCellValue(workSheet, rowIndex, 16, item.LOOPSET);
                            SetCellValue(workSheet, rowIndex, 17, item.FALLBACK);
                            SetCellValue(workSheet, rowIndex, 18, item.OPTSN);
                            SetCellValue(workSheet, rowIndex, 19, item.CGSELID);
                            SetCellValue(workSheet, rowIndex, 20, item.CDSELID);
                            SetCellValue(workSheet, rowIndex, 21, item.OPCSN);
                            SetCellValue(workSheet, rowIndex, 22, item.ACTSN);
                            SetCellValue(workSheet, rowIndex, 23, item.PPMEASREQD);
                            SetCellValue(workSheet, rowIndex, 24, item.CGPCACTION);
                            SetCellValue(workSheet, rowIndex, 25, item.GTTSN);
                            SetCellValue(workSheet, rowIndex, 26, item.NETDOM);
                            SetCellValue(workSheet, rowIndex, 27, item.NDGT);
                            SetCellValue(workSheet, rowIndex, 28, item.MRN);
                            SetCellValue(workSheet, rowIndex, 29, item.OPCODE);
                            SetCellValue(workSheet, rowIndex, 30, item.ACN);
                            SetCellValue(workSheet, rowIndex, 31, item.DPC);
                            SetCellValue(workSheet, rowIndex, 32, item.CGPC);
                            SetCellValue(workSheet, rowIndex, 33, item.OPC);
                            SetCellValue(workSheet, rowIndex, 34, item.NPSN);
                            SetCellValue(workSheet, rowIndex, 35, item.SADDR);
                            SetCellValue(workSheet, rowIndex, 36, item.EADDR);
                            SetCellValue(workSheet, rowIndex, 37, item.DEFMAPVR);
                            SetCellValue(workSheet, rowIndex, 38, item.PRIO);
                        }
                        else
                        {
                            workSheet.Cells[rowIndex, 10].Value = item.GTMODID;
                            workSheet.Cells[rowIndex, 11].Value = item.LOOPSET;
                            workSheet.Cells[rowIndex, 12].Value = item.FALLBACK;
                            workSheet.Cells[rowIndex, 13].Value = item.OPTSN;

                            SetCellValue(workSheet, rowIndex, 14, item.CDSELID);

                            workSheet.Cells[rowIndex, 15].Value = item.ACTSN;
                        }

                        MLVSoft_Common.Excel.EpplusManagement.SetRowBorder(workSheet.Cells, rowIndex, numberColumns);
                        MLVSoft_Common.Excel.EpplusManagement.HorizontalAligment(workSheet.Cells, rowIndex, numberColumns, OfficeOpenXml.Style.ExcelHorizontalAlignment.Left);
                        rowIndex += 1;
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                }

                workSheet.Cells.Style.Font.Size = 9;
                workSheet.Cells.AutoFitColumns();
                workSheet.View.FreezePanes(2, 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [ OPCODE ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xlPackage"></param>
        /// <param name="opcodeData"></param>
        /// <param name="completeData"></param>
        public static void OPCODE(ExcelPackage xlPackage, List<Data.OST.OPCODE_Data> opcodeData, bool completeData, DATA_ENUM.ExcelType excelType = DATA_ENUM.ExcelType.First)
        {
            List<string> completeHeaderOPCODE = new List<string>(Enum.GetNames(typeof(DATA_ENUM.ExcelHeaders.CompleteOPCODE)));
            List<string> simpleHeaderOPCODE = new List<string>(Enum.GetNames(typeof(DATA_ENUM.ExcelHeaders.SimpleOPCODE)));

            int rowIndex = 0;

            try
            {
                int numberColumns = completeData ? completeHeaderOPCODE.Count : simpleHeaderOPCODE.Count;

                ExcelWorksheet workSheet = MLVSoft_Common.Excel.ExcelBuilder.BuildExcelFrame(
                    xlPackage, 
                    "OPCODE",
                    null,
                    "A1",
                    Color.FromArgb(31, 73, 125),
                    Color.White,
                    false,
                    null,
                    completeData ? completeHeaderOPCODE : simpleHeaderOPCODE,
                    Color.FromArgb(235, 241, 222),
                    Color.Black,
                    string.Format("A1:{0}1", MLVSoft_Common.Excel.Utilities.IndexToColumn(numberColumns)));

                rowIndex = 2;
                    
                foreach (Data.OST.OPCODE_Data item in opcodeData)
                {
                    workSheet.Cells[rowIndex, 1].Value = item.Table;

                    if (completeData)
                    {
                        SetCellValue(workSheet, rowIndex, 2, item.ACN);
                        SetCellValue(workSheet, rowIndex, 3, item.OPCODE);
                        SetCellValue(workSheet, rowIndex, 4, item.PKGTYPE);
                        SetCellValue(workSheet, rowIndex, 5, item.XLAT);
                        SetCellValue(workSheet, rowIndex, 6, item.RI);
                        SetCellValue(workSheet, rowIndex, 7, item.ITUPC);
                        SetCellValue(workSheet, rowIndex, 8, item.MRNSET);
                        SetCellValue(workSheet, rowIndex, 9, item.MAPSET);
                        SetCellValue(workSheet, rowIndex, 10, item.SSN);
                        SetCellValue(workSheet, rowIndex, 11, item.CCGT);
                        SetCellValue(workSheet, rowIndex, 12, item.CGGTMOD);
                        SetCellValue(workSheet, rowIndex, 13, item.GTMODID);
                        SetCellValue(workSheet, rowIndex, 14, item.TESTMODE);
                        SetCellValue(workSheet, rowIndex, 15, item.LOOPSET);
                        SetCellValue(workSheet, rowIndex, 16, item.FALLBACK);
                        SetCellValue(workSheet, rowIndex, 17, item.OPTSN);
                        SetCellValue(workSheet, rowIndex, 18, item.CGSELID);
                        SetCellValue(workSheet, rowIndex, 19, item.CDSELID);
                        SetCellValue(workSheet, rowIndex, 20, item.OPCSN);
                        SetCellValue(workSheet, rowIndex, 21, item.ACTSN);
                        SetCellValue(workSheet, rowIndex, 22, item.PPMEASREQD);
                        SetCellValue(workSheet, rowIndex, 23, item.CGPCACTION);
                        SetCellValue(workSheet, rowIndex, 24, item.DEFMAPVR);
                        SetCellValue(workSheet, rowIndex, 25, item.PRIO);
                        SetCellValue(workSheet, rowIndex, 26, item.GTTSN);
                        SetCellValue(workSheet, rowIndex, 27, item.NETDOM);
                        SetCellValue(workSheet, rowIndex, 28, item.NDGT);
                        SetCellValue(workSheet, rowIndex, 29, item.MRN);
                        SetCellValue(workSheet, rowIndex, 30, item.DPC);
                        SetCellValue(workSheet, rowIndex, 31, item.CGPC);
                        SetCellValue(workSheet, rowIndex, 32, item.OPC);
                        SetCellValue(workSheet, rowIndex, 33, item.NPSN);
                        SetCellValue(workSheet, rowIndex, 34, item.SADDR);
                        SetCellValue(workSheet, rowIndex, 35, item.EADDR);
                    }
                    else
                    {
                        SetCellValue(workSheet, rowIndex, 2, item.OPCODE);
                        workSheet.Cells[rowIndex, 3].Value = item.ITUPC;
                        SetCellValue(workSheet, rowIndex, 4, item.MRNSET);
                        workSheet.Cells[rowIndex, 5].Value = item.GTMODID;
                        workSheet.Cells[rowIndex, 6].Value = item.LOOPSET;
                        workSheet.Cells[rowIndex, 7].Value = item.OPTSN;
                        SetCellValue(workSheet, rowIndex, 8, item.CDSELID);
                        workSheet.Cells[rowIndex, 9].Value = item.ACTSN;
                    }                    

                    MLVSoft_Common.Excel.EpplusManagement.SetRowBorder(workSheet.Cells, rowIndex, numberColumns);
                    MLVSoft_Common.Excel.EpplusManagement.HorizontalAligment(workSheet.Cells, rowIndex, numberColumns, OfficeOpenXml.Style.ExcelHorizontalAlignment.Left);
                    rowIndex += 1;
                }

                workSheet.Cells.Style.Font.Size = 9;
                workSheet.Cells.AutoFitColumns();
                workSheet.View.FreezePanes(2, 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [ GTTSEL ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xlPackage"></param>
        /// <param name="gttselData"></param>
        public static void GTTSEL(ExcelPackage xlPackage, List<Data.OST.GTTSEL_Data> gttselData)
        {
            List<string> headerGTTSEL = new List<string>(Enum.GetNames(typeof(DATA_ENUM.ExcelHeaders.GTTSEL)));

            int rowIndex = 0;

            try
            {
                int numberColumns = headerGTTSEL.Count;

                ExcelWorksheet workSheet = MLVSoft_Common.Excel.ExcelBuilder.BuildExcelFrame(
                    xlPackage,
                    "GTTSEL",
                    null,
                    "A1",
                    Color.FromArgb(31, 73, 125),
                    Color.White,
                    false,
                    null,
                    headerGTTSEL,
                    Color.FromArgb(235, 241, 222),
                    Color.Black,
                    string.Format("A1:{0}1", MLVSoft_Common.Excel.Utilities.IndexToColumn(numberColumns)));

                rowIndex = 2;

                foreach (Data.OST.GTTSEL_Data item in gttselData)
                {
                    workSheet.Cells[rowIndex, 1].Value = item.MSGTYPE;

                    SetCellValue(workSheet, rowIndex, 2, item.ANSI);
                    SetCellValue(workSheet, rowIndex, 3, item.INT);
                    SetCellValue(workSheet, rowIndex, 4, item.NAT);
                    SetCellValue(workSheet, rowIndex, 5, item.N24);
                    SetCellValue(workSheet, rowIndex, 6, item.INTS);
                    SetCellValue(workSheet, rowIndex, 7, item.NATS);
                    SetCellValue(workSheet, rowIndex, 8, item.TT);
                    SetCellValue(workSheet, rowIndex, 9, item.NP);
                    SetCellValue(workSheet, rowIndex, 10, item.NAI);
                    SetCellValue(workSheet, rowIndex, 11, item.SSN);
                    SetCellValue(workSheet, rowIndex, 12, item.SELID);

                    workSheet.Cells[rowIndex, 13].Value = item.LSN;
                    workSheet.Cells[rowIndex, 14].Value = item.CDPA_GTTSET;
                    workSheet.Cells[rowIndex, 15].Value = item.CGPA_GTTSET;

                    MLVSoft_Common.Excel.EpplusManagement.SetRowBorder(workSheet.Cells, rowIndex, numberColumns);
                    MLVSoft_Common.Excel.EpplusManagement.HorizontalAligment(workSheet.Cells, rowIndex, numberColumns, OfficeOpenXml.Style.ExcelHorizontalAlignment.Left);
                    rowIndex += 1;
                }

                workSheet.Cells.Style.Font.Size = 9;
                workSheet.Cells.AutoFitColumns();
                workSheet.View.FreezePanes(2, 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [ GTTSET ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xlPackage"></param>
        /// <param name="gttsetData"></param>
        public static void GTTSET(ExcelPackage xlPackage, List<Data.OST.GTTSET_Data> gttsetData, bool completeData)
        {
            List<string> simpleHeaderGTTSET = new List<string>(Enum.GetNames(typeof(DATA_ENUM.ExcelHeaders.SimpleHeaderGTTSET)));
            List<string> completeHeaderGTTSET = new List<string>(Enum.GetNames(typeof(DATA_ENUM.ExcelHeaders.CompleteHeaderGTTSET)));

            int rowIndex = 0;

            try
            {
                int numberColumns = completeData ? completeHeaderGTTSET.Count : simpleHeaderGTTSET.Count;

                ExcelWorksheet workSheet = MLVSoft_Common.Excel.ExcelBuilder.BuildExcelFrame(
                    xlPackage,
                    "GTTSET",
                    null,
                    "A1",
                    Color.FromArgb(31, 73, 125),
                    Color.White,
                    false,
                    null,
                    completeData ? completeHeaderGTTSET : simpleHeaderGTTSET,
                    Color.FromArgb(235, 241, 222),
                    Color.Black,
                    string.Format("A1:{0}1", MLVSoft_Common.Excel.Utilities.IndexToColumn(numberColumns)));

                rowIndex = 2;

                foreach (Data.OST.GTTSET_Data item in gttsetData)
                {
                    try
                    {
                        workSheet.Cells[rowIndex, 1].Value = item.GTTSN;

                        if (completeData)
                        {
                            workSheet.Cells[rowIndex, 2].Value = item.NETDOM;
                            workSheet.Cells[rowIndex, 3].Value = item.Type.ToString();
                            SetCellValue(workSheet, rowIndex, 4, item.NPSN);
                            workSheet.Cells[rowIndex, 5].Value = item.CHECKMULCOMP;
                            SetCellValue(workSheet, rowIndex, 6, item.SETIDX);
                            workSheet.Cells[rowIndex, 7].Value = item.MEASRQD;
                            workSheet.Cells[rowIndex, 8].Value = item.SXUDT;
                            SetCellValue(workSheet, rowIndex, 9, item.NDGT);

                        }
                        else
                        {
                            workSheet.Cells[rowIndex, 2].Value = item.Type.ToString();
                            workSheet.Cells[rowIndex, 3].Value = item.CHECKMULCOMP;
                            SetCellValue(workSheet, rowIndex, 4, item.SETIDX);
                            workSheet.Cells[rowIndex, 5].Value = item.SXUDT;
                            SetCellValue(workSheet, rowIndex, 6, item.NDGT);
                        }

                        MLVSoft_Common.Excel.EpplusManagement.SetRowBorder(workSheet.Cells, rowIndex, numberColumns);
                        MLVSoft_Common.Excel.EpplusManagement.HorizontalAligment(workSheet.Cells, rowIndex, numberColumns, OfficeOpenXml.Style.ExcelHorizontalAlignment.Left);
                        rowIndex += 1;
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                }

                workSheet.Cells.Style.Font.Size = 9;
                workSheet.Cells.AutoFitColumns();
                workSheet.View.FreezePanes(2, 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [ MRNSET ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="opcodeData"></param>
        public static void MRNSET(ExcelPackage xlPackage, List<Data.OST.MRNSET_Data> mrnsetData)
        {
            List<string> headerMRNSET = new List<string>(Enum.GetNames(typeof(DATA_ENUM.ExcelHeaders.MRNSET)));

            int rowIndex = 0;

            try
            {
                int numberColumns = headerMRNSET.Count;

                ExcelWorksheet workSheet = MLVSoft_Common.Excel.ExcelBuilder.BuildExcelFrame(
                    xlPackage,
                    "MRNSET",
                    null,
                    "A1",
                    Color.FromArgb(31, 73, 125),
                    Color.White,
                    false,
                    null,
                    headerMRNSET,
                    Color.FromArgb(235, 241, 222),
                    Color.Black,
                    string.Format("A1:{0}1", MLVSoft_Common.Excel.Utilities.IndexToColumn(numberColumns)));

                rowIndex = 2;

                foreach (Data.OST.MRNSET_Data item in mrnsetData)
                {
                    SetCellValue(workSheet, rowIndex, 1, item.MRNSET);
                    SetCellValue(workSheet, rowIndex, 2, item.NET);
                    workSheet.Cells[rowIndex, 3].Value = item.PC;
                    SetCellValue(workSheet, rowIndex, 4, item.RC.ToString());
                    workSheet.Cells[rowIndex, 5].Value = item.DPC_Decimal;
                    SetCellValue(workSheet, rowIndex, 6, item.CLLI);

                    MLVSoft_Common.Excel.EpplusManagement.SetRowBorder(workSheet.Cells, rowIndex, numberColumns);
                    MLVSoft_Common.Excel.EpplusManagement.HorizontalAligment(workSheet.Cells, rowIndex, numberColumns, OfficeOpenXml.Style.ExcelHorizontalAlignment.Left);
                    rowIndex += 1;
                }

                workSheet.Cells.Style.Font.Size = 9;
                workSheet.Cells.AutoFitColumns();
                workSheet.View.FreezePanes(2, 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [ MAPSET ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="opcodeData"></param>
        public static void MAPSET(ExcelPackage xlPackage, List<Data.OST.MAPSET_Data> mapsetData)
        {
            List<string> headerMAPSET = new List<string>(Enum.GetNames(typeof(DATA_ENUM.ExcelHeaders.MAPSET)));

            int rowIndex = 0;

            try
            {
                int numberColumns = headerMAPSET.Count;

                ExcelWorksheet workSheet = MLVSoft_Common.Excel.ExcelBuilder.BuildExcelFrame(
                    xlPackage,
                    "MAPSET",
                    null,
                    "A1",
                    Color.FromArgb(31, 73, 125),
                    Color.White,
                    false,
                    null,
                    headerMAPSET,
                    Color.FromArgb(235, 241, 222),
                    Color.Black,
                    string.Format("A1:{0}1", MLVSoft_Common.Excel.Utilities.IndexToColumn(numberColumns)));

                rowIndex = 2;

                foreach (Data.OST.MAPSET_Data item in mapsetData)
                {
                    SetCellValue(workSheet, rowIndex, 1, item.MAPSET);
                    workSheet.Cells[rowIndex, 2].Value = item.PCN;
                    workSheet.Cells[rowIndex, 3].Value = item.Mate_PCN;
                    SetCellValue(workSheet, rowIndex, 4, item.SSN);
                    SetCellValue(workSheet, rowIndex, 5, item.RC.ToString());
                    workSheet.Cells[rowIndex, 6].Value = item.MULT;

                    MLVSoft_Common.Excel.EpplusManagement.SetRowBorder(workSheet.Cells, rowIndex, numberColumns);
                    MLVSoft_Common.Excel.EpplusManagement.HorizontalAligment(workSheet.Cells, rowIndex, numberColumns, OfficeOpenXml.Style.ExcelHorizontalAlignment.Left);
                    rowIndex += 1;
                }

                workSheet.Cells.Style.Font.Size = 9;
                workSheet.Cells.AutoFitColumns();
                workSheet.View.FreezePanes(2, 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [ DSTN ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xlPackage"></param>
        /// <param name="dstnData"></param>
        public static void DSTN(ExcelPackage xlPackage, List<Data.OST.DSTN_Data> dstnData)
        {
            List<string> headerDSTN = new List<string>(Enum.GetNames(typeof(DATA_ENUM.ExcelHeaders.DSTN)));

            int rowIndex = 0;

            try
            {
                int numberColumns = headerDSTN.Count;

                ExcelWorksheet workSheet = MLVSoft_Common.Excel.ExcelBuilder.BuildExcelFrame(
                    xlPackage,
                    "DSTN",
                    null,
                    "A1",
                    Color.FromArgb(31, 73, 125),
                    Color.White,
                    false,
                    null,
                    headerDSTN,
                    Color.FromArgb(235, 241, 222),
                    Color.Black,
                    string.Format("A1:{0}1", MLVSoft_Common.Excel.Utilities.IndexToColumn(numberColumns)));

                rowIndex = 2;

                foreach (Data.OST.DSTN_Data item in dstnData)
                {
                    workSheet.Cells[rowIndex, 1].Value = item.Type.ToString();
                    workSheet.Cells[rowIndex, 2].Value = item.DPC;
                    workSheet.Cells[rowIndex, 3].Value = item.DPC_Dec;
                    workSheet.Cells[rowIndex, 4].Value = item.CLLI;
                    workSheet.Cells[rowIndex, 5].Value = item.LSN;

                    SetCellValue(workSheet, rowIndex, 6, item.RC.ToString());

                    workSheet.Cells[rowIndex, 7].Value = item.APCI;
                    workSheet.Cells[rowIndex, 8].Value = item.APCI_Dec;

                    MLVSoft_Common.Excel.EpplusManagement.SetRowBorder(workSheet.Cells, rowIndex, numberColumns);
                    MLVSoft_Common.Excel.EpplusManagement.HorizontalAligment(workSheet.Cells, rowIndex, numberColumns, OfficeOpenXml.Style.ExcelHorizontalAlignment.Left);
                    rowIndex += 1;
                }

                workSheet.Cells.Style.Font.Size = 9;
                workSheet.Cells.AutoFitColumns();
                workSheet.View.FreezePanes(2, 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [ SLK ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="slkData"></param>
        public static void SLK(ExcelPackage xlPackage, List<Data.OST.SLK_Data> slkData)
        {
            List<string> headerSLK = new List<string>(Enum.GetNames(typeof(DATA_ENUM.ExcelHeaders.SLK)));

            int rowIndex = 0;

            try
            {
                int numberColumns = headerSLK.Count;

                ExcelWorksheet workSheet = MLVSoft_Common.Excel.ExcelBuilder.BuildExcelFrame(
                    xlPackage,
                    "SLK",
                    null,
                    "A1",
                    Color.FromArgb(31, 73, 125),
                    Color.White,
                    false,
                    null,
                    headerSLK,
                    Color.FromArgb(235, 241, 222),
                    Color.Black,
                    string.Format("A1:{0}1", MLVSoft_Common.Excel.Utilities.IndexToColumn(numberColumns)));

                rowIndex = 2;

                foreach (Data.OST.SLK_Data item in slkData)
                {
                    SetCellValue(workSheet, rowIndex, 1, item.LOC);

                    workSheet.Cells[rowIndex, 2].Value = item.LINK;
                    workSheet.Cells[rowIndex, 3].Value = item.LSN;

                    SetCellValue(workSheet, rowIndex, 4, item.SLC);

                    workSheet.Cells[rowIndex, 5].Value = item.TYPE;
                    workSheet.Cells[rowIndex, 6].Value = item.ANAME;

                    SetCellValue(workSheet, rowIndex, 7, item.SLKTPS);
                    SetCellValue(workSheet, rowIndex, 8, item.MAXSLKTPS);

                    MLVSoft_Common.Excel.EpplusManagement.SetRowBorder(workSheet.Cells, rowIndex, numberColumns);
                    MLVSoft_Common.Excel.EpplusManagement.HorizontalAligment(workSheet.Cells, rowIndex, numberColumns, OfficeOpenXml.Style.ExcelHorizontalAlignment.Left);
                    rowIndex += 1;
                }

                workSheet.Cells.Style.Font.Size = 9;
                workSheet.Cells.AutoFitColumns();
                workSheet.View.FreezePanes(2, 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [ ASSOC ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="assocData"></param>
        public static void ASSOC(ExcelPackage xlPackage, List<Data.OST.ASSOC_Data> assocData)
        {
            List<string> headerASSOC = new List<string>(Enum.GetNames(typeof(DATA_ENUM.ExcelHeaders.ASSOC)));

            int rowIndex = 0;

            try
            {
                int numberColumns = headerASSOC.Count;

                ExcelWorksheet workSheet = MLVSoft_Common.Excel.ExcelBuilder.BuildExcelFrame(
                    xlPackage,
                    "ASSOC",
                    null,
                    "A1",
                    Color.FromArgb(31, 73, 125),
                    Color.White,
                    false,
                    null,
                    headerASSOC,
                    Color.FromArgb(235, 241, 222),
                    Color.Black,
                    string.Format("A1:{0}1", MLVSoft_Common.Excel.Utilities.IndexToColumn(numberColumns)));

                rowIndex = 2;

                foreach (Data.OST.ASSOC_Data item in assocData)
                {
                    workSheet.Cells[rowIndex, 1].Value = item.ANAME;

                    SetCellValue(workSheet, rowIndex, 2, item.LOC);

                    workSheet.Cells[rowIndex, 3].Value = item.PORT;
                    workSheet.Cells[rowIndex, 4].Value = item.ADAPTER;
                    workSheet.Cells[rowIndex, 5].Value = item.LHOST;
                    workSheet.Cells[rowIndex, 6].Value = item.ALHOST;
                    workSheet.Cells[rowIndex, 7].Value = item.LOCAL_IP;
                    workSheet.Cells[rowIndex, 8].Value = item.ALOCAL_IP;

                    SetCellValue(workSheet, rowIndex, 9, item.LPORT);

                    workSheet.Cells[rowIndex, 10].Value = item.RHOST;
                    workSheet.Cells[rowIndex, 11].Value = item.ARHOST;
                    workSheet.Cells[rowIndex, 12].Value = item.REMOTE_IP;
                    workSheet.Cells[rowIndex, 13].Value = item.AREMOTE_IP;

                    SetCellValue(workSheet, rowIndex, 14, item.RPORT);

                    MLVSoft_Common.Excel.EpplusManagement.SetRowBorder(workSheet.Cells, rowIndex, numberColumns);
                    MLVSoft_Common.Excel.EpplusManagement.HorizontalAligment(workSheet.Cells, rowIndex, numberColumns, OfficeOpenXml.Style.ExcelHorizontalAlignment.Left);
                    rowIndex += 1;
                }

                workSheet.Cells.Style.Font.Size = 9;
                workSheet.Cells.AutoFitColumns();
                workSheet.View.FreezePanes(2, 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [ HOST ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="hostData"></param>
        public static void HOST(ExcelPackage xlPackage, List<Data.OST.HOST_Data> hostData)
        {
            List<string> headerHOST = new List<string>(Enum.GetNames(typeof(DATA_ENUM.ExcelHeaders.HOST)));

            int rowIndex = 0;

            try
            {
                int numberColumns = headerHOST.Count;

                ExcelWorksheet workSheet = MLVSoft_Common.Excel.ExcelBuilder.BuildExcelFrame(
                    xlPackage,
                    "HOST",
                    null,
                    "A1",
                    Color.FromArgb(31, 73, 125),
                    Color.White,
                    false,
                    null,
                    headerHOST,
                    Color.FromArgb(235, 241, 222),
                    Color.Black,
                    string.Format("A1:{0}1", MLVSoft_Common.Excel.Utilities.IndexToColumn(numberColumns)));

                rowIndex = 2;

                foreach (Data.OST.HOST_Data item in hostData)
                {
                    workSheet.Cells[rowIndex, 1].Value = item.Type.ToString();
                    workSheet.Cells[rowIndex, 2].Value = item.LOC;
                    workSheet.Cells[rowIndex, 3].Value = item.IPADDR;
                    workSheet.Cells[rowIndex, 4].Value = item.HOST;

                    MLVSoft_Common.Excel.EpplusManagement.SetRowBorder(workSheet.Cells, rowIndex, numberColumns);
                    MLVSoft_Common.Excel.EpplusManagement.HorizontalAligment(workSheet.Cells, rowIndex, numberColumns, OfficeOpenXml.Style.ExcelHorizontalAlignment.Left);
                    rowIndex += 1;
                }

                workSheet.Cells.Style.Font.Size = 9;
                workSheet.Cells.AutoFitColumns();
                workSheet.View.FreezePanes(2, 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [ LOOPSET ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="loopsetData"></param>
        public static void LOOPSET(ExcelPackage xlPackage, List<Data.OST.LOOPSET_Data> loopsetData)
        {
            List<string> headerHOST = new List<string>(Enum.GetNames(typeof(DATA_ENUM.ExcelHeaders.LOOPSET)));

            int rowIndex = 0;

            try
            {
                int numberColumns = headerHOST.Count;

                ExcelWorksheet workSheet = MLVSoft_Common.Excel.ExcelBuilder.BuildExcelFrame(
                    xlPackage,
                    "LOOPSET",
                    null,
                    "A1",
                    Color.FromArgb(31, 73, 125),
                    Color.White,
                    false,
                    null,
                    headerHOST,
                    Color.FromArgb(235, 241, 222),
                    Color.Black,
                    string.Format("A1:{0}1", MLVSoft_Common.Excel.Utilities.IndexToColumn(numberColumns)));

                rowIndex = 2;

                foreach (Data.OST.LOOPSET_Data item in loopsetData.OrderBy(p => p.Loopset).ToList())
                {
                    workSheet.Cells[rowIndex, 1].Value = item.Loopset;
                    workSheet.Cells[rowIndex, 2].Value = item.Mode;
                    workSheet.Cells[rowIndex, 3].Value = item.PointCode;
                    workSheet.Cells[rowIndex, 4].Value = item.Type.ToString();

                    MLVSoft_Common.Excel.EpplusManagement.SetRowBorder(workSheet.Cells, rowIndex, numberColumns);
                    MLVSoft_Common.Excel.EpplusManagement.HorizontalAligment(workSheet.Cells, rowIndex, numberColumns, OfficeOpenXml.Style.ExcelHorizontalAlignment.Left);
                    rowIndex += 1;
                }

                workSheet.Cells.Style.Font.Size = 9;
                workSheet.Cells.AutoFitColumns();
                workSheet.View.FreezePanes(2, 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [ TTMAP ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="ttmapData"></param>
        public static void TTMAP(ExcelPackage xlPackage, List<Data.OST.TTMAP_Data> ttmapData)
        {
            List<string> headerHOST = new List<string>(Enum.GetNames(typeof(DATA_ENUM.ExcelHeaders.TTMAP)));

            int rowIndex = 0;

            try
            {
                int numberColumns = headerHOST.Count;

                ExcelWorksheet workSheet = MLVSoft_Common.Excel.ExcelBuilder.BuildExcelFrame(
                    xlPackage,
                    "TTMAP",
                    null,
                    "A1",
                    Color.FromArgb(31, 73, 125),
                    Color.White,
                    false,
                    null,
                    headerHOST,
                    Color.FromArgb(235, 241, 222),
                    Color.Black,
                    string.Format("A1:{0}1", MLVSoft_Common.Excel.Utilities.IndexToColumn(numberColumns)));

                rowIndex = 2;

                foreach (Data.OST.TTMAP_Data item in ttmapData.OrderBy(p => p.LSN).ToList())
                {
                    workSheet.Cells[rowIndex, 1].Value = item.LSN;
                    workSheet.Cells[rowIndex, 2].Value = item.IO;
                    workSheet.Cells[rowIndex, 3].Value = item.ETT;
                    workSheet.Cells[rowIndex, 4].Value = item.MTT;

                    MLVSoft_Common.Excel.EpplusManagement.SetRowBorder(workSheet.Cells, rowIndex, numberColumns);
                    MLVSoft_Common.Excel.EpplusManagement.HorizontalAligment(workSheet.Cells, rowIndex, numberColumns, OfficeOpenXml.Style.ExcelHorizontalAlignment.Left);
                    rowIndex += 1;
                }

                workSheet.Cells.Style.Font.Size = 9;
                workSheet.Cells.AutoFitColumns();
                workSheet.View.FreezePanes(2, 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [ SetCellValue ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workSheet"></param>
        /// <param name="rowIndex"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        private static void SetCellValue(ExcelWorksheet workSheet, int rowIndex, int column, string value)
        {
            if (value != null)
            {
                if (MLVSoft_Common.Utilities.OnlyNumbers.IsNumeric(value))
                    workSheet.Cells[rowIndex, column].Value = int.Parse(value);
                else
                    workSheet.Cells[rowIndex, column].Value = value;
            }
        }
        #endregion
    }
}