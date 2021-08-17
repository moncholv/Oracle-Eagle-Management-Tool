using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using DATA_ENUM = VRS_Eng_Manage_Tool.Data.Enum;

namespace VRS_Eng_Manage_Tool.Business
{
    public static class Import_STP_data
    {
        private const string CommandLimit = ":num=200:force=yes";
        private const string CommandStructure = "{0}\\{1}{2}_{3}";

        public static void GetAll_Data(List<bool> StpValues) { }

        #region [ Get GTA Data ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StpValues"></param>
        /// <param name="folderPath"></param>
        /// <returns></returns>
        public static Dictionary<DATA_ENUM.STP, List<Data.OST.GTA_Data>> GetGTA_Data(List<bool> StpValues, string folderPath, bool complete)
        {
            Dictionary<DATA_ENUM.STP, List<Data.OST.GTA_Data>> GtaData = new Dictionary<DATA_ENUM.STP, List<Data.OST.GTA_Data>>();
            Data.OST.GTA_Data gtaInfo = null;

            string Table = null;
            bool commandStart, rtrv;
            commandStart = rtrv = false;
            Dictionary<int, string> searchFieldsIndex = GetSearchFields<DATA_ENUM.SearchFields.GTA>();

            try
            {
                foreach (int listIndex in Enumerable.Range(0, StpValues.Count).Where(i => StpValues[i]))
                {
                    GtaData.Add((DATA_ENUM.STP)listIndex, new List<Data.OST.GTA_Data>());

                    string commandName = "rtrv-gta_CXGTA";
                    string filePath = GetFileName(commandName, folderPath, listIndex);

                    var lines = File.ReadLines(filePath);
                    foreach (string line in lines)
                    {
                        string trimmedLine = line.TrimStart();

                        try
                        {
                            if (!string.IsNullOrEmpty(trimmedLine.Trim()))
                            {
                                if (trimmedLine.Contains("> rtrv-gta:gttsn="))
                                {
                                    commandStart = false;
                                    rtrv = true;
                                    Table = GetTableName(trimmedLine);
                                }
                                else if (trimmedLine.Contains("START GTA"))
                                {
                                    gtaInfo = null;
                                    commandStart = true;
                                }
                                else if (Utilities.ContainsAny(trimmedLine, searchFieldsIndex.Select(d => d.Value).ToArray()) && commandStart)
                                {
                                    AddValue<DATA_ENUM.SearchFields.Required.GTA, Data.OST.GTA_Data>(searchFieldsIndex, trimmedLine, complete, gtaInfo);
                                }
                                else if (trimmedLine.Contains("Command Retrieved") && commandStart)
                                {
                                    if (gtaInfo != null)
                                        GtaData[(DATA_ENUM.STP)listIndex].Add(gtaInfo);
                                    commandStart = false;
                                }
                                else if (commandStart)
                                {
                                    if (gtaInfo != null)
                                        GtaData[(DATA_ENUM.STP)listIndex].Add(gtaInfo);

                                    gtaInfo = new Data.OST.GTA_Data();
                                    gtaInfo.Table = Table;
                                    List<string> elements = Utilities.GetStringsInLine(trimmedLine, false);

                                    gtaInfo.Start_GTA = elements[0];
                                    gtaInfo.End_GTA = elements[1];
                                    
                                    if(elements.Count > 3)
                                    {
                                        gtaInfo.XLAT = elements[2];
                                        gtaInfo.RI = elements[3];
                                        gtaInfo.ITU_PC = elements[4];                                        
                                    }
                                    else
                                        gtaInfo.ITU_PC = elements[2];
                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return GtaData;
        }
        #endregion

        #region [ Get OpCode Data ]
        public static Dictionary<DATA_ENUM.STP, List<Data.OST.OPCODE_Data>> GetOpCode_Data(List<bool> StpValues, string folderPath, bool complete)
        {
            Dictionary<DATA_ENUM.STP, List<Data.OST.OPCODE_Data>> opCodeData = new Dictionary<DATA_ENUM.STP, List<Data.OST.OPCODE_Data>>();
            Data.OST.OPCODE_Data opCodeInfo = null;

            string Table = null;
            bool commandStart, rtrv;
            commandStart = rtrv = false;
            Dictionary<int, string> searchFieldsIndex = new Dictionary<int, string>();
            List<string> elements = null;

            searchFieldsIndex = GetSearchFields<DATA_ENUM.SearchFields.OpCode>();

            try
            {
                foreach (int listIndex in Enumerable.Range(0, StpValues.Count).Where(i => StpValues[i]))
                {
                    opCodeData.Add((DATA_ENUM.STP)listIndex, new List<Data.OST.OPCODE_Data>());

                    string commandName = "rtrv-gta_OPCODE";
                    string filePath = GetFileName(commandName, folderPath, listIndex);

                    var lines = File.ReadLines(filePath);
                    foreach (string line in lines)
                    {
                        string trimmedLine = line.TrimStart();

                        try
                        {
                            if (!string.IsNullOrEmpty(trimmedLine.Trim()))
                            {
                                if (trimmedLine.Contains("> rtrv-gta:gttsn="))
                                {
                                    commandStart = false;
                                    rtrv = true;
                                    Table = GetTableName(trimmedLine); ;
                                }
                                else if (trimmedLine.Contains("ACN"))
                                {
                                    opCodeInfo = null;
                                    commandStart = true;
                                }
                                else if (Utilities.ContainsAny(trimmedLine, searchFieldsIndex.Select(d => d.Value).ToArray()) && commandStart)
                                {
                                    AddValue<DATA_ENUM.SearchFields.Required.OpCode, Data.OST.OPCODE_Data>(searchFieldsIndex, trimmedLine, complete, opCodeInfo);
                                }
                                else if (trimmedLine.Contains("Command Retrieved") && commandStart)
                                {
                                    opCodeData[(DATA_ENUM.STP)listIndex].Add(opCodeInfo);
                                    commandStart = false;
                                }
                                else if (commandStart)
                                {
                                    if (opCodeInfo != null)
                                        opCodeData[(DATA_ENUM.STP)listIndex].Add(opCodeInfo);

                                    opCodeInfo = new Data.OST.OPCODE_Data();
                                    opCodeInfo.Table = Table;
                                    elements = Utilities.GetStringsInLine(trimmedLine, false);

                                    opCodeInfo.ACN = elements[0];
                                    opCodeInfo.OPCODE = elements[1];
                                    opCodeInfo.PKGTYPE = elements[2];
                                    
                                    if (elements.Count > 4)
                                    {
                                        opCodeInfo.XLAT = elements[3];
                                        opCodeInfo.RI = elements[4];
                                        opCodeInfo.ITUPC = elements[5];
                                    }
                                    else if (elements.Count == 4)
                                        opCodeInfo.ITUPC = elements[3];
                                    else
                                        opCodeInfo.XLAT = elements[3];
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return opCodeData;
        }
        #endregion

        #region [ Get GTTSEL Data ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StpValues"></param>
        /// <param name="folderPath"></param>
        /// <param name="complete"></param>
        /// <returns></returns>
        public static Dictionary<DATA_ENUM.STP, List<Data.OST.GTTSEL_Data>> GetGTTSelData(List<bool> StpValues, string folderPath, bool complete)
        {
            Dictionary<DATA_ENUM.STP, List<Data.OST.GTTSEL_Data>> gttselData = new Dictionary<DATA_ENUM.STP, List<Data.OST.GTTSEL_Data>>();
            Data.OST.GTTSEL_Data gttselInfo = null;
            List<string> elements = null;
            bool rtrvStart = false;
            DATA_ENUM.SearchFields.GTTSEL gttselType = DATA_ENUM.SearchFields.GTTSEL.ANSI;

            Dictionary<int, string> searchFieldsIndex = GetSearchFields<DATA_ENUM.SearchFields.GTTSEL>();

            try
            {
                foreach (int listIndex in Enumerable.Range(0, StpValues.Count).Where(i => StpValues[i]))
                {
                    gttselData.Add((DATA_ENUM.STP)listIndex, new List<Data.OST.GTTSEL_Data>());

                    string commandName = "rtrv-gttsel";
                    string filePath = GetFileName(commandName, folderPath, listIndex);

                    var lines = File.ReadLines(filePath);
                    foreach (string line in lines)
                    {
                        string trimmedLine = line.TrimStart();

                        try
                        {
                            if (Utilities.ContainsAny(trimmedLine, searchFieldsIndex.Select(d => d.Value).ToArray()))
                            {
                                rtrvStart = true;
                                elements = Utilities.GetStringsInLine(trimmedLine, false);
                                gttselType = (DATA_ENUM.SearchFields.GTTSEL)Enum.Parse(typeof(DATA_ENUM.SearchFields.GTTSEL), elements[1], true);
                            }
                            else if (string.IsNullOrEmpty(trimmedLine))
                            {
                                rtrvStart = false;
                            }
                            else if (rtrvStart)
                            {
                                if (trimmedLine.Substring(0, 1) == "a" || trimmedLine.Substring(0, 1) == "u")
                                {
                                    elements = Utilities.GetStringsInLine(trimmedLine, false);
                                    gttselInfo = new Data.OST.GTTSEL_Data();

                                    gttselInfo.MSGTYPE = elements[0];

                                    var propInfo = gttselInfo.GetType().GetProperty(gttselType.ToString());
                                    if (propInfo != null)
                                        propInfo.SetValue(gttselInfo, elements[1], null);

                                    gttselInfo.TT = elements[2];
                                    gttselInfo.NP = elements[3];
                                    gttselInfo.NAI = elements[4];
                                    gttselInfo.SSN = elements[5];
                                    gttselInfo.SELID = elements[6];
                                    gttselInfo.LSN = elements[7];
                                    gttselInfo.CDPA_GTTSET = elements[8];
                                    gttselInfo.CGPA_GTTSET = elements[9];

                                    gttselData[(DATA_ENUM.STP)listIndex].Add(gttselInfo);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return gttselData;
        }
        #endregion

        #region [ Get GTTSET Data ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StpValues"></param>
        /// <param name="folderPath"></param>
        /// <param name="complete"></param>
        /// <returns></returns>
        public static Dictionary<DATA_ENUM.STP, List<Data.OST.GTTSET_Data>> GetGTTSetData(List<bool> StpValues, string folderPath, bool complete)
        {
            Dictionary<DATA_ENUM.STP, List<Data.OST.GTTSET_Data>> gttsetData = new Dictionary<DATA_ENUM.STP, List<Data.OST.GTTSET_Data>>();
            Data.OST.GTTSET_Data gttsetInfo = null;
            List<string> elements = null;
            bool rtrvStart = false;

            try
            {
                foreach (int listIndex in Enumerable.Range(0, StpValues.Count).Where(i => StpValues[i]))
                {
                    gttsetData.Add((DATA_ENUM.STP)listIndex, new List<Data.OST.GTTSET_Data>());

                    string commandName = "rtrv-gttset";
                    string filePath = GetFileName(commandName, folderPath, listIndex);

                    var lines = File.ReadLines(filePath);
                    foreach (string line in lines)
                    {
                        string trimmedLine = line.TrimStart();

                        try
                        {
                            if (trimmedLine.StartsWith("GTTSN"))
                            {
                                rtrvStart = true;
                            }
                            else if (string.IsNullOrEmpty(trimmedLine))
                            {
                                rtrvStart = false;
                            }
                            else if (rtrvStart)
                            {
                                elements = Utilities.GetStringsInLine(trimmedLine, false);
                                gttsetData[(DATA_ENUM.STP)listIndex].Add(gttsetInfo = new Data.OST.GTTSET_Data()
                                {
                                    GTTSN = elements[0],
                                    NETDOM = elements[1],
                                    Type = (DATA_ENUM.GTTSET_Type)Enum.Parse(typeof(DATA_ENUM.GTTSET_Type), elements[2], true),
                                    NPSN = elements[3],
                                    CHECKMULCOMP = elements[4],
                                    SETIDX = elements[5],
                                    MEASRQD = elements[6],
                                    SXUDT = elements[7],
                                    NDGT = elements[8]
                                });
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return gttsetData;
        }
        #endregion

        #region [ Get MRNSET Data ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StpValues"></param>
        /// <param name="folderPath"></param>
        /// <param name="complete"></param>
        /// <returns></returns>
        public static Dictionary<DATA_ENUM.STP, List<Data.OST.MRNSET_Data>> GetMRNSET_Data(List<bool> StpValues, string folderPath, bool complete)
        {
            Dictionary<DATA_ENUM.STP, List<Data.OST.MRNSET_Data>> mrnsetData = new Dictionary<DATA_ENUM.STP, List<Data.OST.MRNSET_Data>>();
            Data.OST.MRNSET_Data mrnsetInfo = null;

            bool mrnsetInit, firstRecord;
            mrnsetInit = firstRecord = false;
            string mrnsetValue = null;
            int elementIndex = 0;
            Dictionary<int, string> searchFieldsIndex = new Dictionary<int, string>();
            List<string> elements = null;

            try
            {
                foreach (int listIndex in Enumerable.Range(0, StpValues.Count).Where(i => StpValues[i]))
                {
                    mrnsetData.Add((DATA_ENUM.STP)listIndex, new List<Data.OST.MRNSET_Data>());

                    string commandName = "rtrv-mrn";
                    string filePath = GetFileName(commandName, folderPath, listIndex);

                    var lines = File.ReadLines(filePath);
                    foreach (string line in lines)
                    {
                        string trimmedLine = line.TrimStart();

                        try
                        {
                            if(trimmedLine.StartsWith("MRNSET "))
                            {
                                mrnsetInit = true;
                                firstRecord = true;
                            }
                            else if(string.IsNullOrEmpty(trimmedLine))
                            {
                                mrnsetInit = false;
                            }
                            else if(mrnsetInit)
                            {
                                mrnsetInfo = new Data.OST.MRNSET_Data();

                                elements = Utilities.GetStringsInLine(trimmedLine, false);

                                if (firstRecord)
                                {
                                    elementIndex = 1;
                                    mrnsetValue = elements[0];
                                    mrnsetInfo.MRNSET = mrnsetValue;

                                    if (elements.Count == 4)
                                    {
                                        mrnsetInfo.NET = elements[1];
                                        elementIndex = 2;
                                    }
                                    else
                                        mrnsetInfo.NET = "-----";

                                    firstRecord = false;
                                }
                                else
                                {
                                    mrnsetInfo.MRNSET = mrnsetValue;
                                    elementIndex = 0;

                                    if (elements.Count == 3)
                                    {
                                        mrnsetInfo.NET = elements[0];
                                        elementIndex = 1;
                                    }
                                    else
                                        mrnsetInfo.NET = "-----";
                                }

                                mrnsetInfo.PC = elements[elementIndex];
                                mrnsetInfo.DPC_Decimal = mrnsetInfo.PC.StartsWith("s-") ? mrnsetInfo.PC.Replace("s-", "3-") : string.Format("0-{0}", SS7_PointCode_Converter._14Bit383_toDecimal(mrnsetInfo.PC));
                                mrnsetInfo.RC = int.Parse(elements[elementIndex + 1]);

                                mrnsetData[(DATA_ENUM.STP)listIndex].Add(mrnsetInfo);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return mrnsetData;
        }
        #endregion

        #region [ Get MAPSET Data ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StpValues"></param>
        /// <param name="folderPath"></param>
        /// <param name="complete"></param>
        /// <returns></returns>
        public static Dictionary<DATA_ENUM.STP, List<Data.OST.MAPSET_Data>> GetMAPSET_Data(List<bool> StpValues, string folderPath, bool complete)
        {
            Dictionary<DATA_ENUM.STP, List<Data.OST.MAPSET_Data>> mapsetData = new Dictionary<DATA_ENUM.STP, List<Data.OST.MAPSET_Data>>();
            Data.OST.MAPSET_Data mapsetInfo = null;

            bool mapsetInit, firstRecord;
            mapsetInit = firstRecord = false;
            string mapsetValue = null;
            string pcnValue = null;
            int elementIndex = 0;
            Dictionary<int, string> searchFieldsIndex = new Dictionary<int, string>();
            List<string> elements = null;

            try
            {
                foreach (int listIndex in Enumerable.Range(0, StpValues.Count).Where(i => StpValues[i]))
                {
                    mapsetData.Add((DATA_ENUM.STP)listIndex, new List<Data.OST.MAPSET_Data>());

                    string commandName = "rtrv-map";
                    string filePath = GetFileName(commandName, folderPath, listIndex);

                    var lines = File.ReadLines(filePath);
                    foreach (string line in lines)
                    {
                        string trimmedLine = line.TrimStart();

                        try
                        {
                            if (trimmedLine.StartsWith("MAPSET ID="))
                            {
                                mapsetInit = true;
                                firstRecord = true;
                                mapsetValue = trimmedLine.Split('=')[1];
                            }
                            else if (string.IsNullOrEmpty(trimmedLine))
                            {
                                mapsetInit = false;
                                firstRecord = false;
                            }
                            else if (mapsetInit && !trimmedLine.StartsWith("PCN"))
                            {
                                mapsetInfo = new Data.OST.MAPSET_Data();

                                elements = Utilities.GetStringsInLine(trimmedLine, false);

                                if (firstRecord)
                                {
                                    pcnValue = elements[0];
                                    mapsetInfo.Mate_PCN = "-----";
                                    firstRecord = false;
                                }
                                else
                                    mapsetInfo.Mate_PCN = elements[0];

                                mapsetInfo.MAPSET = mapsetValue;
                                mapsetInfo.PCN = pcnValue;
                                mapsetInfo.SSN = elements[1];
                                mapsetInfo.RC = int.Parse(elements[2]);
                                mapsetInfo.MULT = elements[3];
                                mapsetInfo.SRM = elements[4];
                                mapsetInfo.MRC = elements[5];
                                mapsetInfo.SSO = elements[7];

                                mapsetData[(DATA_ENUM.STP)listIndex].Add(mapsetInfo);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mapsetData;
        }
        #endregion

        #region [ Get DSTN Data ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StpValues"></param>
        /// <param name="folderPath"></param>
        /// <param name="complete"></param>
        /// <returns></returns>
        public static Dictionary<DATA_ENUM.STP, List<Data.OST.DSTN_Data>> GetDSTN_Data(List<bool> StpValues, string folderPath, bool complete)
        {
            Dictionary<DATA_ENUM.STP, List<Data.OST.DSTN_Data>> dstnData = new Dictionary<DATA_ENUM.STP, List<Data.OST.DSTN_Data>>();

            Data.OST.DSTN_Data dstnInfo = null;

            bool dstnInit, newDPC;
            dstnInit = newDPC = false;
            DATA_ENUM.DSTN_Type dstnType = DATA_ENUM.DSTN_Type.International;
            Dictionary<int, string> searchFieldsIndex = new Dictionary<int, string>();
            List<string> elements = null;
            string dpcValue, clliValue;
            dpcValue = clliValue = null;

            try
            {
                foreach (int listIndex in Enumerable.Range(0, StpValues.Count).Where(i => StpValues[i]))
                {
                    dstnData.Add((DATA_ENUM.STP)listIndex, new List<Data.OST.DSTN_Data>());

                    string commandName = "rtrv-rte";
                    string filePath = GetFileName(commandName, folderPath, listIndex);

                    var lines = File.ReadLines(filePath);
                    foreach (string line in lines)
                    {
                        string trimmedLine = line.TrimStart();
                        
                        try
                        {
                            if (trimmedLine.StartsWith("DPCI ") || trimmedLine.StartsWith("DPCN "))
                            {
                                dstnInit = true;
                                dstnType = trimmedLine.StartsWith("DPCI ") ? DATA_ENUM.DSTN_Type.International : DATA_ENUM.DSTN_Type.National;
                            }
                            else if (string.IsNullOrEmpty(trimmedLine))
                            {
                                dstnInit = false;
                            }
                            else if (!trimmedLine.StartsWith("LSN ") && dstnInit)
                            {
                                elements = Utilities.GetStringsInLine(trimmedLine, false);

                                if (elements.Count > 3 && elements[3] == "No")
                                {
                                    if (newDPC)
                                    {
                                        dstnInfo = new Data.OST.DSTN_Data()
                                        {
                                            Type = dstnType,
                                            DPC = dpcValue,
                                            DPC_Dec = dpcValue.StartsWith("s-") ? dpcValue.Replace("s-", "3-") : string.Format("0-{0}", SS7_PointCode_Converter._14Bit383_toDecimal(dpcValue)),
                                            CLLI = clliValue,
                                            LSN = "----------",
                                            APCI = "-----",
                                            APCI_Dec = "-----",
                                            RC = "No"
                                        };

                                        dstnData[(DATA_ENUM.STP)listIndex].Add(dstnInfo);
                                    }

                                    dpcValue = elements[0];
                                    clliValue = elements[4];
                                    newDPC = true;
                                }
                                else
                                {
                                    newDPC = false;
                                    dstnInfo = new Data.OST.DSTN_Data()
                                    {
                                        Type = dstnType,
                                        DPC = dpcValue,
                                        DPC_Dec = dpcValue.StartsWith("s-") ? dpcValue.Replace("s-", "3-") : string.Format("0-{0}", SS7_PointCode_Converter._14Bit383_toDecimal(dpcValue)),
                                        CLLI = clliValue,
                                        LSN = elements[0],
                                        RC = elements[1],
                                        APCI = elements[2],
                                        APCI_Dec = elements[2].StartsWith("s-") ? elements[2].Replace("s-", "3-") : string.Format("0-{0}", SS7_PointCode_Converter._14Bit383_toDecimal(elements[2]))
                                    };

                                    dstnData[(DATA_ENUM.STP)listIndex].Add(dstnInfo);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }

                    dstnData[(DATA_ENUM.STP)listIndex].Add(dstnInfo);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return dstnData;
        }
        #endregion

        #region [ Get SLK Data ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StpValues"></param>
        /// <param name="folderPath"></param>
        /// <param name="complete"></param>
        /// <returns></returns>
        public static Dictionary<DATA_ENUM.STP, List<Data.OST.SLK_Data>> GetSLK_Data(List<bool> StpValues, string folderPath, bool complete)
        {
            Dictionary<DATA_ENUM.STP, List<Data.OST.SLK_Data>> slkData = new Dictionary<DATA_ENUM.STP, List<Data.OST.SLK_Data>>();
            Data.OST.SLK_Data slkInfo = null;
            List<string> elements = null;

            bool slkInit = false;
            string locValue = null;

            try
            {
                foreach (int listIndex in Enumerable.Range(0, StpValues.Count).Where(i => StpValues[i]))
                {
                    slkData.Add((DATA_ENUM.STP)listIndex, new List<Data.OST.SLK_Data>());

                    string commandName = "rtrv-slk";
                    string filePath = GetFileName(commandName, folderPath, listIndex);

                    var lines = File.ReadLines(filePath);
                    foreach (string line in lines)
                    {
                        string trimmedLine = line.TrimStart();

                        try
                        {
                            if (trimmedLine.StartsWith("LOC "))
                            {
                                slkInit = true;
                            }
                            else if (string.IsNullOrEmpty(trimmedLine))
                            {
                                slkInit = false;
                            }
                            else if(trimmedLine.StartsWith("RSVDSLKTPS")) { continue; }                            
                            else if(slkInit)
                            {
                                elements = Utilities.GetStringsInLine(trimmedLine, false);

                                slkInfo = new Data.OST.SLK_Data()
                                {
                                    LOC = elements[0],
                                    LINK = elements[1],
                                    LSN = elements[2],
                                    SLC = elements[3],
                                    TYPE = elements[4],
                                    ANAME = elements[5],
                                    SLKTPS = elements[6],
                                    MAXSLKTPS = elements[7]
                                };

                                slkData[(DATA_ENUM.STP)listIndex].Add(slkInfo);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return slkData;
        }
        #endregion

        #region [ Get ASSOC Data ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StpValues"></param>
        /// <param name="folderPath"></param>
        /// <param name="complete"></param>
        /// <returns></returns>
        public static Dictionary<DATA_ENUM.STP, List<Data.OST.ASSOC_Data>> GetAssocData(List<bool> StpValues, string folderPath, bool complete)
        {
            Dictionary<DATA_ENUM.STP, List<Data.OST.ASSOC_Data>> assocData = new Dictionary<DATA_ENUM.STP, List<Data.OST.ASSOC_Data>>();
            Data.OST.ASSOC_Data assocInfo = null;
            List<string> elements = null;

            bool assocValues = false;

            try
            {
                foreach (int listIndex in Enumerable.Range(0, StpValues.Count).Where(i => StpValues[i]))
                {
                    assocData.Add((DATA_ENUM.STP)listIndex, new List<Data.OST.ASSOC_Data>());

                    string commandName = "rtrv-assoc__display__all";
                    string filePath = GetFileName(commandName, folderPath, listIndex);

                    var lines = File.ReadLines(filePath);
                    foreach (string line in lines)
                    {
                        string trimmedLine = line.TrimStart();

                        try
                        {
                            if (trimmedLine.StartsWith("ANAME "))
                            {
                                assocValues = true;
                                elements = Utilities.GetStringsInLine(trimmedLine, false);

                                if (assocInfo != null)
                                    assocData[(DATA_ENUM.STP)listIndex].Add(assocInfo);

                                assocInfo = new Data.OST.ASSOC_Data();
                                assocInfo.ANAME = elements[1];
                            }
                            else if (string.IsNullOrEmpty(trimmedLine))
                            {
                                if(assocValues)
                                    assocValues = false;
                            }
                            else if(assocValues)
                            {
                                elements = Utilities.GetStringsInLine(trimmedLine, false);

                                if (trimmedLine.StartsWith("LOC"))
                                {
                                    assocInfo.LOC = elements[1];
                                    assocInfo.PORT = elements[4];
                                    assocInfo.LINK = elements[6];
                                }
                                if (trimmedLine.StartsWith("ADAPTER"))
                                {
                                    assocInfo.ADAPTER = elements[1];
                                    assocInfo.VER = elements[3];
                                }
                                if (trimmedLine.StartsWith("LHOST"))
                                    assocInfo.LHOST = elements.Count > 1 ? elements[1] : "---";
                                if (trimmedLine.StartsWith("ALHOST"))
                                    assocInfo.ALHOST = elements.Count > 1 ? elements[1] : "---";
                                if (trimmedLine.StartsWith("RHOST") && !trimmedLine.StartsWith("RHOSTVAL"))
                                    assocInfo.RHOST = elements.Count > 1 ? elements[1] : "---";
                                if (trimmedLine.StartsWith("ARHOST"))
                                    assocInfo.ARHOST = elements.Count > 1 ? elements[1] : "---";
                                if (trimmedLine.StartsWith("LPORT"))
                                {
                                    assocInfo.LPORT = elements.Count > 2 ? elements[1] : "---";
                                    assocInfo.RPORT = elements.Count > 2 ? elements[3] : "---";
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }

                    if (assocInfo != null)
                        assocData[(DATA_ENUM.STP)listIndex].Add(assocInfo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return assocData;
        }
        #endregion

        #region [ Get HOST Data ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StpValues"></param>
        /// <param name="folderPath"></param>
        /// <param name="complete"></param>
        /// <returns></returns>
        public static Dictionary<DATA_ENUM.STP, List<Data.OST.HOST_Data>> GetHostData(List<bool> StpValues, string folderPath, bool complete)
        {
            Dictionary<DATA_ENUM.STP, List<Data.OST.HOST_Data>> hostData = new Dictionary<DATA_ENUM.STP, List<Data.OST.HOST_Data>>();
            Data.OST.HOST_Data hostInfo = null;
            List<string> elements = null;
            DATA_ENUM.Host_Type hostType = DATA_ENUM.Host_Type.Local;
            bool hostValues = false;

            try
            {
                foreach (int listIndex in Enumerable.Range(0, StpValues.Count).Where(i => StpValues[i]))
                {
                    hostData.Add((DATA_ENUM.STP)listIndex, new List<Data.OST.HOST_Data>());

                    string commandName = "rtrv-ip-host__display=all";
                    string filePath = GetFileName(commandName, folderPath, listIndex);

                    var lines = File.ReadLines(filePath);
                    foreach (string line in lines)
                    {
                        string trimmedLine = line.TrimStart();

                        try
                        {
                            if (trimmedLine.StartsWith("LOCAL IPADDR") || trimmedLine.StartsWith("REMOTE IPADDR"))
                            {
                                hostValues = true;
                                hostType = trimmedLine.StartsWith("LOCAL IPADDR") ? DATA_ENUM.Host_Type.Local : DATA_ENUM.Host_Type.Remote;
                            }
                            else if (string.IsNullOrEmpty(trimmedLine))
                            {
                                hostValues = false;
                            }
                            else if(hostValues)
                            {
                                elements = Utilities.GetStringsInLine(trimmedLine, false);
                                hostData[(DATA_ENUM.STP)listIndex].Add(hostInfo = new Data.OST.HOST_Data()
                                {
                                    IPADDR = elements[0],
                                    LOC = string.Format("{0}{1}", ((DATA_ENUM.STP)listIndex).ToString().ToUpper(), elements[1]),
                                    HOST = elements[1],
                                    Type = hostType
                                });
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return hostData;
        }
        #endregion

        #region [ Get LOOPSET Data ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StpValues"></param>
        /// <param name="folderPath"></param>
        /// <param name="complete"></param>
        /// <returns></returns>
        public static Dictionary<DATA_ENUM.STP, List<Data.OST.LOOPSET_Data>> GetLoopsetData(List<bool> StpValues, string folderPath, bool complete)
        {
            Dictionary<DATA_ENUM.STP, List<Data.OST.LOOPSET_Data>> loopsetData = new Dictionary<DATA_ENUM.STP, List<Data.OST.LOOPSET_Data>>();
            Data.OST.LOOPSET_Data loopsetInfo = null;
            List<string> elements = null;
            bool loopsetValues = false;
            string loopsetName, loopsetMode;
            loopsetName = loopsetMode = string.Empty;
            DATA_ENUM.LoopsetType loopsetType = DATA_ENUM.LoopsetType.INTL;

            try
            {
                foreach (int listIndex in Enumerable.Range(0, StpValues.Count).Where(i => StpValues[i]))
                {
                    loopsetData.Add((DATA_ENUM.STP)listIndex, new List<Data.OST.LOOPSET_Data>());

                    string commandName = "rtrv-loopset";
                    string filePath = GetFileName(commandName, folderPath, listIndex);

                    var lines = File.ReadLines(filePath);
                    foreach (string line in lines)
                    {
                        string trimmedLine = line.TrimStart();

                        try
                        {
                            if (trimmedLine.StartsWith("lp"))
                            {
                                elements = Utilities.GetStringsInLine(trimmedLine, false);

                                loopsetName = elements[0];
                                loopsetMode = elements[1];

                                if (elements.Count == 2)
                                {
                                    loopsetData[(DATA_ENUM.STP)listIndex].Add(new Data.OST.LOOPSET_Data()
                                    {
                                        Loopset = loopsetName,
                                        Mode = loopsetMode
                                    });
                                }
                                else
                                {
                                    loopsetValues = true;
                                    loopsetInfo = new Data.OST.LOOPSET_Data()
                                    {
                                        Loopset = loopsetName,
                                        Mode = loopsetMode,
                                        PointCode = elements[2]
                                    };

                                    if (elements.Count == 4)
                                    {
                                        loopsetInfo.Type = (DATA_ENUM.LoopsetType)Enum.Parse(typeof(DATA_ENUM.LoopsetType), elements[3].Replace("(", "").Replace(")", ""));
                                        loopsetData[(DATA_ENUM.STP)listIndex].Add(loopsetInfo);
                                    }
                                    else
                                    {
                                        loopsetType = (DATA_ENUM.LoopsetType)Enum.Parse(typeof(DATA_ENUM.LoopsetType), elements[4].Replace("(", "").Replace(")", ""));
                                        loopsetInfo.Type = loopsetType;
                                        loopsetData[(DATA_ENUM.STP)listIndex].Add(loopsetInfo);

                                        loopsetInfo = new Data.OST.LOOPSET_Data()
                                        {
                                            Loopset = elements[0],
                                            Mode = elements[1],
                                            PointCode = elements[3]
                                        };

                                        loopsetInfo.Type = loopsetType;
                                        loopsetData[(DATA_ENUM.STP)listIndex].Add(loopsetInfo);
                                    }
                                }
                            }
                            else if (string.IsNullOrEmpty(trimmedLine))
                            {
                                loopsetValues = false;
                            }
                            else if (loopsetValues)
                            {
                                elements = Utilities.GetStringsInLine(trimmedLine, false);


                                foreach (string item in elements)
                                {
                                    loopsetInfo = new Data.OST.LOOPSET_Data()
                                    {
                                        Loopset = loopsetName,
                                        Mode = loopsetMode,
                                        PointCode = item,
                                        Type = loopsetType
                                    };

                                    loopsetData[(DATA_ENUM.STP)listIndex].Add(loopsetInfo);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return loopsetData;
        }
        #endregion

        #region [ Get TTMAP Data ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StpValues"></param>
        /// <param name="folderPath"></param>
        /// <param name="complete"></param>
        /// <returns></returns>
        public static Dictionary<DATA_ENUM.STP, List<Data.OST.TTMAP_Data>> GetTTMapData(List<bool> StpValues, string folderPath, bool complete)
        {
            Dictionary<DATA_ENUM.STP, List<Data.OST.TTMAP_Data>> ttmapData = new Dictionary<DATA_ENUM.STP, List<Data.OST.TTMAP_Data>>();
            List<string> elements = null;
            bool ttmapValues = false;

            try
            {
                foreach (int listIndex in Enumerable.Range(0, StpValues.Count).Where(i => StpValues[i]))
                {
                    ttmapData.Add((DATA_ENUM.STP)listIndex, new List<Data.OST.TTMAP_Data>());

                    string commandName = "rtrv-ttmap";
                    string filePath = GetFileName(commandName, folderPath, listIndex);

                    var lines = File.ReadLines(filePath);
                    foreach (string line in lines)
                    {
                        string trimmedLine = line.TrimStart();

                        try
                        {
                            if (trimmedLine.StartsWith("LSN"))
                            {
                                ttmapValues = true;
                            }
                            else if (string.IsNullOrEmpty(trimmedLine))
                            {
                                ttmapValues = false;
                            }
                            else if (ttmapValues)
                            {
                                elements = Utilities.GetStringsInLine(trimmedLine, false);

                                if(elements.Count == 4)
                                {
                                    ttmapData[(DATA_ENUM.STP)listIndex].Add(new Data.OST.TTMAP_Data()
                                    {
                                        LSN = elements[0],
                                        IO = elements[1],
                                        ETT = elements[2],
                                        MTT = elements[3]
                                    });
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ttmapData;
        }
        #endregion

        //--------------------------------

        #region [ AddValue ]
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="E"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="searchFieldsIndex"></param>
        /// <param name="line"></param>
        /// <param name="complete"></param>
        /// <param name="classType"></param>
        private static void AddValue<E,T>(Dictionary<int, string> searchFieldsIndex, string line, bool complete, T classType)
        {
            string searchValue = null;

            foreach (KeyValuePair<int, string> searchField in searchFieldsIndex)
            {
                if (line.Contains(searchField.Value))
                {
                    bool addValue = complete;

                    searchValue = searchField.Value.Replace(" =", "=");
                    line = line.Replace(" = ", "=");

                    if (!complete && Enum.IsDefined(typeof(E), searchValue.Replace("=", "").Trim()))
                        addValue = true;

                    if (addValue)
                    {
                        var propInfo = classType.GetType().GetProperty(searchValue.Replace("=", "").Trim());
                        if (propInfo != null)
                            propInfo.SetValue(classType, Utilities.GetFieldValue(searchValue, line), null);
                    }
                }
            }
        }
        #endregion

        #region [ GetSearchFields ]
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="E"></typeparam>
        /// <returns></returns>
        private static Dictionary<int, string> GetSearchFields<E>()
        {
            Dictionary<int, string> searchFieldsIndex = new Dictionary<int, string>();

            foreach (int enumIndex in Enum.GetValues(typeof(E)))
            {
                var aux = (E)Enum.Parse(typeof(E), enumIndex.ToString(), true);
                searchFieldsIndex.Add(enumIndex, aux.ToString().Replace("_space", " ").Replace("_equal", "="));
            }

            return searchFieldsIndex;
        }
        #endregion

        #region [ GetTableName ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private static string GetTableName(string line)
        {
            int initIndex = line.IndexOf("> rtrv-gta:gttsn=") + 17;
            int tableLength = line.Substring(initIndex, line.Length - initIndex).IndexOf(":");

            return line.Substring(initIndex, tableLength);
        }
        #endregion

        #region [ Get File Name ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandName"></param>
        /// <param name="folderPath"></param>
        /// <param name="listIndex"></param>
        /// <returns></returns>
        private static string GetFileName(string commandName, string folderPath, int listIndex)
        {
            string filePath = string.Format(CommandStructure, folderPath, commandName, CommandLimit, ((DATA_ENUM.STP)listIndex).ToString());

            if (!File.Exists(filePath))
                filePath = string.Format(CommandStructure, folderPath, commandName, string.Empty, ((DATA_ENUM.STP)listIndex).ToString());

            return filePath;
        }
        #endregion
    }
}