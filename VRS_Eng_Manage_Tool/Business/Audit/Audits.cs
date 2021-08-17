using System;
using System.Collections.Generic;
using System.Linq;

using AUDIT = VRS_Eng_Manage_Tool.Data.Audits;
using DATA_ENUM = VRS_Eng_Manage_Tool.Data.Enum;

namespace VRS_Eng_Manage_Tool.Business.Audit
{
    public static class Audits
    {
        static List<string> vrsDpcNames = new List<string>() { "deratsg01", "deratsg02", "itmilsg01", "itmilsg02" };

        static List<string> vrsDPCs = new List<string>()
            {
                "s-02622",
                "s-02623",
                "s-02620",
                "s-02621",
                "5-225-3",
                "5-225-4",
                "2-121-0",
                "2-121-1"
            };

        #region [ Audit GTA ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gtaData"></param>
        /// <returns></returns>
        public static Dictionary<DATA_ENUM.STP, AUDIT.AuditResult> AuditGTA(Dictionary<DATA_ENUM.STP, List<Data.OST.GTA_Data>> gtaData)
        {
            Dictionary<DATA_ENUM.STP, AUDIT.AuditResult> resultData = new Dictionary<DATA_ENUM.STP, AUDIT.AuditResult>();

            List<string>[] listsAnalysis = null;
            List<string> diffValues = null;

            List<Data.OST.GTA_Data> rat1Aux = null;
            List<Data.OST.GTA_Data> rat2Aux = null;

            try
            {
                #region [ RAT1 & RAT2 ]
                rat1Aux = new List<Data.OST.GTA_Data>(gtaData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value);
                rat2Aux = new List<Data.OST.GTA_Data>(gtaData.Where(w => w.Key == DATA_ENUM.STP.RAT2).First().Value);

                listsAnalysis = GetListsAnalysis(
                    gtaData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Select(s => s.GTA_ID).ToList(),
                    gtaData.Where(w => w.Key == DATA_ENUM.STP.RAT2).First().Value.Select(s => s.GTA_ID).ToList());

                diffValues = SetFinalGtaValues(ref rat1Aux, ref rat2Aux, listsAnalysis);

                resultData.Add(DATA_ENUM.STP.RAT2, new AUDIT.AuditResult()
                {
                    NotInRAT1 = listsAnalysis[1],
                    NotInSTP = listsAnalysis[0],
                    Differences = gtaData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Where(w => diffValues.Contains(w.GTA_Footprint)).Select(s => s.GTA_ID).ToList()
                });
                #endregion

                #region [ RAT1 & MIL1 ]
                rat1Aux = new List<Data.OST.GTA_Data>(gtaData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value);
                rat2Aux = new List<Data.OST.GTA_Data>(gtaData.Where(w => w.Key == DATA_ENUM.STP.MIL1).First().Value);

                listsAnalysis = GetListsAnalysis(
                    gtaData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Select(s => s.GTA_ID).ToList(),
                    gtaData.Where(w => w.Key == DATA_ENUM.STP.MIL1).First().Value.Select(s => s.GTA_ID).ToList());

                diffValues = SetFinalGtaValues(ref rat1Aux, ref rat2Aux, listsAnalysis);

                resultData.Add(DATA_ENUM.STP.MIL1, new AUDIT.AuditResult()
                {
                    NotInRAT1 = listsAnalysis[1],
                    NotInSTP = listsAnalysis[0],
                    Differences = gtaData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Where(w => diffValues.Contains(w.GTA_Footprint)).Select(s => s.GTA_ID).ToList()
                });
                #endregion

                #region [ RAT1 & MIL2 ]
                rat1Aux = new List<Data.OST.GTA_Data>(gtaData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value);
                rat2Aux = new List<Data.OST.GTA_Data>(gtaData.Where(w => w.Key == DATA_ENUM.STP.MIL2).First().Value);

                listsAnalysis = GetListsAnalysis(
                    gtaData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Select(s => s.GTA_ID).ToList(),
                    gtaData.Where(w => w.Key == DATA_ENUM.STP.MIL2).First().Value.Select(s => s.GTA_ID).ToList());

                diffValues = SetFinalGtaValues(ref rat1Aux, ref rat2Aux, listsAnalysis);

                resultData.Add(DATA_ENUM.STP.MIL2, new AUDIT.AuditResult()
                {
                    NotInRAT1 = listsAnalysis[1],
                    NotInSTP = listsAnalysis[0],
                    Differences = gtaData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Where(w => diffValues.Contains(w.GTA_Footprint)).Select(s => s.GTA_ID).ToList()
                });
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultData;
        }
        #endregion

        #region [ Audit OPCODE ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="opcodeData"></param>
        /// <returns></returns>
        public static Dictionary<DATA_ENUM.STP, AUDIT.AuditResult> AuditOPCODE(Dictionary<DATA_ENUM.STP, List<Data.OST.OPCODE_Data>> opcodeData)
        {
            Dictionary<DATA_ENUM.STP, AUDIT.AuditResult> resultData = new Dictionary<DATA_ENUM.STP, AUDIT.AuditResult>();

            List<string>[] listsAnalysis = null;
            List<string> diffValues = null;

            List<Data.OST.OPCODE_Data> rat1Aux = null;
            List<Data.OST.OPCODE_Data> rat2Aux = null;

            try
            {
                #region [ RAT1 & RAT2 ]
                rat1Aux = new List<Data.OST.OPCODE_Data>(opcodeData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value);
                rat2Aux = new List<Data.OST.OPCODE_Data>(opcodeData.Where(w => w.Key == DATA_ENUM.STP.RAT2).First().Value);

                listsAnalysis = GetListsAnalysis(
                    opcodeData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Select(s => s.OPCODE_ID).ToList(),
                    opcodeData.Where(w => w.Key == DATA_ENUM.STP.RAT2).First().Value.Select(s => s.OPCODE_ID).ToList());

                diffValues = SetFinalOpcodeValues(ref rat1Aux, ref rat2Aux, listsAnalysis);

                resultData.Add(DATA_ENUM.STP.RAT2, new AUDIT.AuditResult()
                {
                    NotInRAT1 = listsAnalysis[1],
                    NotInSTP = listsAnalysis[0],
                    Differences = opcodeData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Where(w => diffValues.Contains(w.OPCODE_Footprint)).Select(s => s.OPCODE_ID).ToList()
                });
                #endregion

                #region [ RAT1 & MIL1 ]
                rat1Aux = new List<Data.OST.OPCODE_Data>(opcodeData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value);
                rat2Aux = new List<Data.OST.OPCODE_Data>(opcodeData.Where(w => w.Key == DATA_ENUM.STP.MIL1).First().Value);

                listsAnalysis = GetListsAnalysis(
                    opcodeData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Select(s => s.OPCODE_ID).ToList(),
                    opcodeData.Where(w => w.Key == DATA_ENUM.STP.MIL1).First().Value.Select(s => s.OPCODE_ID).ToList());

                diffValues = SetFinalOpcodeValues(ref rat1Aux, ref rat2Aux, listsAnalysis);

                resultData.Add(DATA_ENUM.STP.MIL1, new AUDIT.AuditResult()
                {
                    NotInRAT1 = listsAnalysis[1],
                    NotInSTP = listsAnalysis[0],
                    Differences = opcodeData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Where(w => diffValues.Contains(w.OPCODE_Footprint)).Select(s => s.OPCODE_ID).ToList()
                });
                #endregion

                #region [ RAT1 & MIL2 ]
                rat1Aux = new List<Data.OST.OPCODE_Data>(opcodeData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value);
                rat2Aux = new List<Data.OST.OPCODE_Data>(opcodeData.Where(w => w.Key == DATA_ENUM.STP.MIL2).First().Value);

                listsAnalysis = GetListsAnalysis(
                    opcodeData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Select(s => s.OPCODE_ID).ToList(),
                    opcodeData.Where(w => w.Key == DATA_ENUM.STP.MIL2).First().Value.Select(s => s.OPCODE_ID).ToList());

                diffValues = SetFinalOpcodeValues(ref rat1Aux, ref rat2Aux, listsAnalysis);

                resultData.Add(DATA_ENUM.STP.MIL2, new AUDIT.AuditResult()
                {
                    NotInRAT1 = listsAnalysis[1],
                    NotInSTP = listsAnalysis[0],
                    Differences = opcodeData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Where(w => diffValues.Contains(w.OPCODE_Footprint)).Select(s => s.OPCODE_ID).ToList()
                });
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultData;
        }
        #endregion

        #region [ Audit GTTSEL ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gttselData"></param>
        /// <returns></returns>
        public static Dictionary<DATA_ENUM.STP, AUDIT.AuditResult> AuditGTTSEL(Dictionary<DATA_ENUM.STP, List<Data.OST.GTTSEL_Data>> gttselData)
        {
            Dictionary<DATA_ENUM.STP, AUDIT.AuditResult> resultData = new Dictionary<DATA_ENUM.STP, AUDIT.AuditResult>();

            List<string>[] listsAnalysis = null;
            List<string> diffValues = null;

            List<Data.OST.GTTSEL_Data> rat1Aux = null;
            List<Data.OST.GTTSEL_Data> rat2Aux = null;

            try
            {
                #region [ RAT1 & RAT2 ]
                rat1Aux = new List<Data.OST.GTTSEL_Data>(gttselData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value);
                rat2Aux = new List<Data.OST.GTTSEL_Data>(gttselData.Where(w => w.Key == DATA_ENUM.STP.RAT2).First().Value);

                listsAnalysis = GetListsAnalysis(
                    gttselData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Select(s => s.GTTSEL_ID).ToList(),
                    gttselData.Where(w => w.Key == DATA_ENUM.STP.RAT2).First().Value.Select(s => s.GTTSEL_ID).ToList(),
                    true);

                diffValues = SetFinalGttselValues(ref rat1Aux, ref rat2Aux, listsAnalysis);

                resultData.Add(DATA_ENUM.STP.RAT2, new AUDIT.AuditResult()
                {
                    NotInRAT1 = listsAnalysis[1],
                    NotInSTP = listsAnalysis[0],
                    Differences = gttselData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Where(w => diffValues.Contains(w.GTTSEL_Footprint)).Select(s => s.GTTSEL_ID).ToList()
                });
                #endregion

                #region [ RAT1 & MIL1 ]
                rat1Aux = new List<Data.OST.GTTSEL_Data>(gttselData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value);
                rat2Aux = new List<Data.OST.GTTSEL_Data>(gttselData.Where(w => w.Key == DATA_ENUM.STP.MIL1).First().Value);

                listsAnalysis = GetListsAnalysis(
                    gttselData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Select(s => s.GTTSEL_ID).ToList(),
                    gttselData.Where(w => w.Key == DATA_ENUM.STP.MIL1).First().Value.Select(s => s.GTTSEL_ID).ToList(),
                    true);

                diffValues = SetFinalGttselValues(ref rat1Aux, ref rat2Aux, listsAnalysis);

                resultData.Add(DATA_ENUM.STP.MIL1, new AUDIT.AuditResult()
                {
                    NotInRAT1 = listsAnalysis[1],
                    NotInSTP = listsAnalysis[0],
                    Differences = gttselData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Where(w => diffValues.Contains(w.GTTSEL_Footprint)).Select(s => s.GTTSEL_ID).ToList()
                });
                #endregion

                #region [ RAT1 & MIL2 ]
                rat1Aux = new List<Data.OST.GTTSEL_Data>(gttselData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value);
                rat2Aux = new List<Data.OST.GTTSEL_Data>(gttselData.Where(w => w.Key == DATA_ENUM.STP.MIL2).First().Value);

                listsAnalysis = GetListsAnalysis(
                    gttselData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Select(s => s.GTTSEL_ID).ToList(),
                    gttselData.Where(w => w.Key == DATA_ENUM.STP.MIL2).First().Value.Select(s => s.GTTSEL_ID).ToList(),
                    true);

                diffValues = SetFinalGttselValues(ref rat1Aux, ref rat2Aux, listsAnalysis);

                resultData.Add(DATA_ENUM.STP.MIL2, new AUDIT.AuditResult()
                {
                    NotInRAT1 = listsAnalysis[1],
                    NotInSTP = listsAnalysis[0],
                    Differences = gttselData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Where(w => diffValues.Contains(w.GTTSEL_Footprint)).Select(s => s.GTTSEL_ID).ToList()
                });
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultData;
        }
        #endregion

        #region [ Audit GTTSET ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gttsetData"></param>
        /// <returns></returns>
        public static Dictionary<DATA_ENUM.STP, AUDIT.AuditResult> AuditGTTSET(Dictionary<DATA_ENUM.STP, List<Data.OST.GTTSET_Data>> gttsetData)
        {
            Dictionary<DATA_ENUM.STP, AUDIT.AuditResult> resultData = new Dictionary<DATA_ENUM.STP, AUDIT.AuditResult>();

            List<string>[] listsAnalysis = null;
            List<string> diffValues = null;

            List<Data.OST.GTTSET_Data> rat1Aux = null;
            List<Data.OST.GTTSET_Data> rat2Aux = null;

            try
            {
                #region [ RAT1 & RAT2 ]
                rat1Aux = new List<Data.OST.GTTSET_Data>(gttsetData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value);
                rat2Aux = new List<Data.OST.GTTSET_Data>(gttsetData.Where(w => w.Key == DATA_ENUM.STP.RAT2).First().Value);

                listsAnalysis = GetListsAnalysis(
                    gttsetData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Select(s => s.GTTSET_ID).ToList(),
                    gttsetData.Where(w => w.Key == DATA_ENUM.STP.RAT2).First().Value.Select(s => s.GTTSET_ID).ToList());

                diffValues = SetFinalGttsetValues(ref rat1Aux, ref rat2Aux, listsAnalysis);

                resultData.Add(DATA_ENUM.STP.RAT2, new AUDIT.AuditResult()
                {
                    NotInRAT1 = listsAnalysis[1],
                    NotInSTP = listsAnalysis[0],
                    Differences = gttsetData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Where(w => diffValues.Contains(w.GTTSET_Footprint)).Select(s => s.GTTSET_ID).ToList()
                });
                #endregion

                #region [ RAT1 & MIL1 ]
                rat1Aux = new List<Data.OST.GTTSET_Data>(gttsetData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value);
                rat2Aux = new List<Data.OST.GTTSET_Data>(gttsetData.Where(w => w.Key == DATA_ENUM.STP.MIL1).First().Value);

                listsAnalysis = GetListsAnalysis(
                    gttsetData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Select(s => s.GTTSET_ID).ToList(),
                    gttsetData.Where(w => w.Key == DATA_ENUM.STP.MIL1).First().Value.Select(s => s.GTTSET_ID).ToList());

                diffValues = SetFinalGttsetValues(ref rat1Aux, ref rat2Aux, listsAnalysis);

                resultData.Add(DATA_ENUM.STP.MIL1, new AUDIT.AuditResult()
                {
                    NotInRAT1 = listsAnalysis[1],
                    NotInSTP = listsAnalysis[0],
                    Differences = gttsetData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Where(w => diffValues.Contains(w.GTTSET_Footprint)).Select(s => s.GTTSET_ID).ToList()
                });
                #endregion

                #region [ RAT1 & MIL2 ]
                rat1Aux = new List<Data.OST.GTTSET_Data>(gttsetData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value);
                rat2Aux = new List<Data.OST.GTTSET_Data>(gttsetData.Where(w => w.Key == DATA_ENUM.STP.MIL2).First().Value);

                listsAnalysis = GetListsAnalysis(
                    gttsetData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Select(s => s.GTTSET_ID).ToList(),
                    gttsetData.Where(w => w.Key == DATA_ENUM.STP.MIL2).First().Value.Select(s => s.GTTSET_ID).ToList());

                diffValues = SetFinalGttsetValues(ref rat1Aux, ref rat2Aux, listsAnalysis);

                resultData.Add(DATA_ENUM.STP.MIL2, new AUDIT.AuditResult()
                {
                    NotInRAT1 = listsAnalysis[1],
                    NotInSTP = listsAnalysis[0],
                    Differences = gttsetData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Where(w => diffValues.Contains(w.GTTSET_Footprint)).Select(s => s.GTTSET_ID).ToList()
                });
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultData;
        }
        #endregion

        #region [ Audit MRNSET ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mrnsetData"></param>
        /// <returns></returns>
        public static Dictionary<DATA_ENUM.STP, AUDIT.AuditResult> AuditMRNSET(Dictionary<DATA_ENUM.STP, List<Data.OST.MRNSET_Data>> mrnsetData)
        {
            Dictionary<DATA_ENUM.STP, AUDIT.AuditResult> resultData = new Dictionary<DATA_ENUM.STP, AUDIT.AuditResult>();

            List<string>[] listsAnalysis = null;
            List<string> diffValues = null;

            List<Data.OST.MRNSET_Data> rat1Aux = null;
            List<Data.OST.MRNSET_Data> rat2Aux = null;

            try
            {
                #region [ RAT1 & RAT2 ]
                rat1Aux = new List<Data.OST.MRNSET_Data>(mrnsetData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value);
                rat2Aux = new List<Data.OST.MRNSET_Data>(mrnsetData.Where(w => w.Key == DATA_ENUM.STP.RAT2).First().Value);

                listsAnalysis = GetListsAnalysis(
                    mrnsetData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Select(s => s.MRNSET_ID).ToList(),
                    mrnsetData.Where(w => w.Key == DATA_ENUM.STP.RAT2).First().Value.Select(s => s.MRNSET_ID).ToList());

                diffValues = SetFinalMrnsetValues(ref rat1Aux, ref rat2Aux, listsAnalysis);

                resultData.Add(DATA_ENUM.STP.RAT2, new AUDIT.AuditResult()
                {
                    NotInRAT1 = listsAnalysis[1],
                    NotInSTP = listsAnalysis[0],
                    Differences = mrnsetData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Where(w => diffValues.Contains(w.MRNSET_Footprint)).Select(s => s.MRNSET_ID).ToList()
                });
                #endregion

                #region [ RAT1 & MIL1 ]
                rat1Aux = new List<Data.OST.MRNSET_Data>(mrnsetData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value);
                rat2Aux = new List<Data.OST.MRNSET_Data>(mrnsetData.Where(w => w.Key == DATA_ENUM.STP.MIL1).First().Value);

                listsAnalysis = GetListsAnalysis(
                    mrnsetData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Select(s => s.MRNSET_ID).ToList(),
                    mrnsetData.Where(w => w.Key == DATA_ENUM.STP.MIL1).First().Value.Select(s => s.MRNSET_ID).ToList());

                diffValues = SetFinalMrnsetValues(ref rat1Aux, ref rat2Aux, listsAnalysis);

                resultData.Add(DATA_ENUM.STP.MIL1, new AUDIT.AuditResult()
                {
                    NotInRAT1 = listsAnalysis[1],
                    NotInSTP = listsAnalysis[0],
                    Differences = mrnsetData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Where(w => diffValues.Contains(w.MRNSET_Footprint)).Select(s => s.MRNSET_ID).ToList()
                });
                #endregion

                #region [ RAT1 & MIL2 ]
                rat1Aux = new List<Data.OST.MRNSET_Data>(mrnsetData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value);
                rat2Aux = new List<Data.OST.MRNSET_Data>(mrnsetData.Where(w => w.Key == DATA_ENUM.STP.MIL2).First().Value);

                listsAnalysis = GetListsAnalysis(
                    mrnsetData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Select(s => s.MRNSET_ID).ToList(),
                    mrnsetData.Where(w => w.Key == DATA_ENUM.STP.MIL2).First().Value.Select(s => s.MRNSET_ID).ToList());

                diffValues = SetFinalMrnsetValues(ref rat1Aux, ref rat2Aux, listsAnalysis);

                resultData.Add(DATA_ENUM.STP.MIL2, new AUDIT.AuditResult()
                {
                    NotInRAT1 = listsAnalysis[1],
                    NotInSTP = listsAnalysis[0],
                    Differences = mrnsetData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Where(w => diffValues.Contains(w.MRNSET_Footprint)).Select(s => s.MRNSET_ID).ToList()
                });
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultData;
        }
        #endregion

        #region [ Audit DSTN ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dstnData"></param>
        /// <returns></returns>
        public static Dictionary<DATA_ENUM.STP, AUDIT.AuditResult> AuditMRNSET(Dictionary<DATA_ENUM.STP, List<Data.OST.DSTN_Data>> dstnData)
        {
            Dictionary<DATA_ENUM.STP, AUDIT.AuditResult> resultData = new Dictionary<DATA_ENUM.STP, AUDIT.AuditResult>();

            List<string>[] listsAnalysis = null;
            List<string> diffValues = null;

            List<Data.OST.DSTN_Data> rat1Aux = null;
            List<Data.OST.DSTN_Data> rat2Aux = null;

            try
            {
                #region [ RAT1 & RAT2 ]
                rat1Aux = new List<Data.OST.DSTN_Data>(dstnData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value);
                rat2Aux = new List<Data.OST.DSTN_Data>(dstnData.Where(w => w.Key == DATA_ENUM.STP.RAT2).First().Value);

                listsAnalysis = GetListsAnalysis(
                    dstnData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Select(s => s.DSTN_ID).ToList(),
                    dstnData.Where(w => w.Key == DATA_ENUM.STP.RAT2).First().Value.Select(s => s.DSTN_ID).ToList());

                diffValues = SetFinalDstnValues(ref rat1Aux, ref rat2Aux, listsAnalysis);

                resultData.Add(DATA_ENUM.STP.RAT2, new AUDIT.AuditResult()
                {
                    NotInRAT1 = listsAnalysis[1],
                    NotInSTP = listsAnalysis[0],
                    Differences = dstnData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Where(w => diffValues.Contains(w.DSTN_Footprint)).Select(s => s.DSTN_ID).ToList()
                });
                #endregion

                #region [ RAT1 & MIL1 ]
                rat1Aux = new List<Data.OST.DSTN_Data>(dstnData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value);
                rat2Aux = new List<Data.OST.DSTN_Data>(dstnData.Where(w => w.Key == DATA_ENUM.STP.MIL1).First().Value);

                listsAnalysis = GetListsAnalysis(
                    dstnData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Select(s => s.DSTN_ID).ToList(),
                    dstnData.Where(w => w.Key == DATA_ENUM.STP.MIL1).First().Value.Select(s => s.DSTN_ID).ToList());

                diffValues = SetFinalDstnValues(ref rat1Aux, ref rat2Aux, listsAnalysis);

                resultData.Add(DATA_ENUM.STP.MIL1, new AUDIT.AuditResult()
                {
                    NotInRAT1 = listsAnalysis[1],
                    NotInSTP = listsAnalysis[0],
                    Differences = dstnData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Where(w => diffValues.Contains(w.DSTN_Footprint)).Select(s => s.DSTN_ID).ToList()
                });
                #endregion

                #region [ RAT1 & MIL2 ]
                rat1Aux = new List<Data.OST.DSTN_Data>(dstnData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value);
                rat2Aux = new List<Data.OST.DSTN_Data>(dstnData.Where(w => w.Key == DATA_ENUM.STP.MIL2).First().Value);

                listsAnalysis = GetListsAnalysis(
                    dstnData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Select(s => s.DSTN_ID).ToList(),
                    dstnData.Where(w => w.Key == DATA_ENUM.STP.MIL2).First().Value.Select(s => s.DSTN_ID).ToList());

                diffValues = SetFinalDstnValues(ref rat1Aux, ref rat2Aux, listsAnalysis);

                resultData.Add(DATA_ENUM.STP.MIL2, new AUDIT.AuditResult()
                {
                    NotInRAT1 = listsAnalysis[1],
                    NotInSTP = listsAnalysis[0],
                    Differences = dstnData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Where(w => diffValues.Contains(w.DSTN_Footprint)).Select(s => s.DSTN_ID).ToList()
                });
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultData;
        }
        #endregion

        #region [ Audit SLK ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="slkData"></param>
        /// <returns></returns>
        public static Dictionary<DATA_ENUM.STP, AUDIT.AuditResult> AuditSLK(Dictionary<DATA_ENUM.STP, List<Data.OST.SLK_Data>> slkData)
        {
            Dictionary<DATA_ENUM.STP, AUDIT.AuditResult> resultData = new Dictionary<DATA_ENUM.STP, AUDIT.AuditResult>();

            List<string>[] listsAnalysis = null;
            List<string> diffValues = null;

            List<Data.OST.SLK_Data> rat1Aux = null;
            List<Data.OST.SLK_Data> rat2Aux = null;

            try
            {
                #region [ RAT1 & RAT2 ]
                rat1Aux = new List<Data.OST.SLK_Data>(slkData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value);
                rat2Aux = new List<Data.OST.SLK_Data>(slkData.Where(w => w.Key == DATA_ENUM.STP.RAT2).First().Value);
                
                listsAnalysis = GetListsAnalysis(
                    slkData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Select(s => s.SLK_ID).ToList(),
                    slkData.Where(w => w.Key == DATA_ENUM.STP.RAT2).First().Value.Select(s => s.SLK_ID).ToList());

                diffValues = SetFinalSlkValues(ref rat1Aux, ref rat2Aux, listsAnalysis);

                resultData.Add(DATA_ENUM.STP.RAT2, new AUDIT.AuditResult()
                {
                    NotInRAT1 = listsAnalysis[1],
                    NotInSTP = listsAnalysis[0],
                    Differences = slkData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Where(w => diffValues.Contains(w.SLK_Footprint)).Select(s => s.SLK_ID).ToList()
                });
                #endregion

                #region [ RAT1 & MIL1 ]
                rat1Aux = new List<Data.OST.SLK_Data>(slkData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value);
                rat2Aux = new List<Data.OST.SLK_Data>(slkData.Where(w => w.Key == DATA_ENUM.STP.MIL1).First().Value);
                
                listsAnalysis = GetListsAnalysis(
                    slkData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Select(s => s.SLK_ID).ToList(),
                    slkData.Where(w => w.Key == DATA_ENUM.STP.MIL1).First().Value.Select(s => s.SLK_ID).ToList());

                diffValues = SetFinalSlkValues(ref rat1Aux, ref rat2Aux, listsAnalysis);

                resultData.Add(DATA_ENUM.STP.MIL1, new AUDIT.AuditResult()
                {
                    NotInRAT1 = listsAnalysis[1],
                    NotInSTP = listsAnalysis[0],
                    Differences = slkData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Where(w => diffValues.Contains(w.SLK_Footprint)).Select(s => s.SLK_ID).ToList()
                });
                #endregion

                #region [ RAT1 & MIL2 ]
                rat1Aux = new List<Data.OST.SLK_Data>(slkData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value);
                rat2Aux = new List<Data.OST.SLK_Data>(slkData.Where(w => w.Key == DATA_ENUM.STP.MIL2).First().Value);
                
                listsAnalysis = GetListsAnalysis(
                    slkData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Select(s => s.SLK_ID).ToList(),
                    slkData.Where(w => w.Key == DATA_ENUM.STP.MIL2).First().Value.Select(s => s.SLK_ID).ToList());

                diffValues = SetFinalSlkValues(ref rat1Aux, ref rat2Aux, listsAnalysis);

                resultData.Add(DATA_ENUM.STP.MIL2, new AUDIT.AuditResult()
                {
                    NotInRAT1 = listsAnalysis[1],
                    NotInSTP = listsAnalysis[0],
                    Differences = slkData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Where(w => diffValues.Contains(w.SLK_Footprint)).Select(s => s.SLK_ID).ToList()
                });
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultData;
        }
        #endregion

        #region [ Audit ASSOC ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="assocData"></param>
        /// <returns></returns>
        public static Dictionary<DATA_ENUM.STP, AUDIT.AuditResult> AuditASSOC(Dictionary<DATA_ENUM.STP, List<Data.OST.ASSOC_Data>> assocData)
        {
            Dictionary<DATA_ENUM.STP, AUDIT.AuditResult> resultData = new Dictionary<DATA_ENUM.STP, AUDIT.AuditResult>();

            List<string>[] listsAnalysis = null;
            List<string> diffValues = null;

            List<Data.OST.ASSOC_Data> rat1Aux = null;
            List<Data.OST.ASSOC_Data> rat2Aux = null;

            try
            {
                #region [ RAT1 & RAT2 ]
                rat1Aux = new List<Data.OST.ASSOC_Data>(assocData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value);
                rat2Aux = new List<Data.OST.ASSOC_Data>(assocData.Where(w => w.Key == DATA_ENUM.STP.RAT2).First().Value);

                listsAnalysis = GetListsAnalysis(
                    assocData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Select(s => s.ASSOC_ID).ToList(),
                    assocData.Where(w => w.Key == DATA_ENUM.STP.RAT2).First().Value.Select(s => s.ASSOC_ID).ToList(),
                    true);

                diffValues = SetFinalAssocValues(ref rat1Aux, ref rat2Aux, listsAnalysis);

                resultData.Add(DATA_ENUM.STP.RAT2, new AUDIT.AuditResult()
                {
                    NotInRAT1 = listsAnalysis[1],
                    NotInSTP = listsAnalysis[0],
                    Differences = assocData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Where(w => diffValues.Contains(w.ASSOC_Footprint)).Select(s => s.ASSOC_ID).ToList()
                });
                #endregion

                #region [ RAT1 & MIL1 ]
                rat1Aux = new List<Data.OST.ASSOC_Data>(assocData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value);
                rat2Aux = new List<Data.OST.ASSOC_Data>(assocData.Where(w => w.Key == DATA_ENUM.STP.MIL1).First().Value);

                listsAnalysis = GetListsAnalysis(
                    assocData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Select(s => s.ASSOC_ID).ToList(),
                    assocData.Where(w => w.Key == DATA_ENUM.STP.MIL1).First().Value.Select(s => s.ASSOC_ID).ToList(),
                    true);

                diffValues = SetFinalAssocValues(ref rat1Aux, ref rat2Aux, listsAnalysis);

                resultData.Add(DATA_ENUM.STP.MIL1, new AUDIT.AuditResult()
                {
                    NotInRAT1 = listsAnalysis[1],
                    NotInSTP = listsAnalysis[0],
                    Differences = assocData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Where(w => diffValues.Contains(w.ASSOC_Footprint)).Select(s => s.ASSOC_ID).ToList()
                });
                #endregion

                #region [ RAT1 & MIL2 ]
                rat1Aux = new List<Data.OST.ASSOC_Data>(assocData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value);
                rat2Aux = new List<Data.OST.ASSOC_Data>(assocData.Where(w => w.Key == DATA_ENUM.STP.MIL2).First().Value);

                listsAnalysis = GetListsAnalysis(
                    assocData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Select(s => s.ASSOC_ID).ToList(),
                    assocData.Where(w => w.Key == DATA_ENUM.STP.MIL2).First().Value.Select(s => s.ASSOC_ID).ToList(),
                    true);

                diffValues = SetFinalAssocValues(ref rat1Aux, ref rat2Aux, listsAnalysis);

                resultData.Add(DATA_ENUM.STP.MIL2, new AUDIT.AuditResult()
                {
                    NotInRAT1 = listsAnalysis[1],
                    NotInSTP = listsAnalysis[0],
                    Differences = assocData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Where(w => diffValues.Contains(w.ASSOC_Footprint)).Select(s => s.ASSOC_ID).ToList()
                });
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultData;
        }
        #endregion

        #region [ Audit LOOPSET ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loopsetData"></param>
        /// <returns></returns>
        public static Dictionary<DATA_ENUM.STP, AUDIT.AuditResult> AuditLOOPSET(Dictionary<DATA_ENUM.STP, List<Data.OST.LOOPSET_Data>> loopsetData)
        {
            Dictionary<DATA_ENUM.STP, AUDIT.AuditResult> resultData = new Dictionary<DATA_ENUM.STP, AUDIT.AuditResult>();

            List<string>[] listsAnalysis = null;
            List<string> diffValues = null;

            List<Data.OST.LOOPSET_Data> rat1Aux = null;
            List<Data.OST.LOOPSET_Data> rat2Aux = null;

            try
            {
                #region [ RAT1 & RAT2 ]
                rat1Aux = new List<Data.OST.LOOPSET_Data>(loopsetData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value);
                rat2Aux = new List<Data.OST.LOOPSET_Data>(loopsetData.Where(w => w.Key == DATA_ENUM.STP.RAT2).First().Value);

                listsAnalysis = GetListsAnalysis(
                    loopsetData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Select(s => s.LOOPSET_ID).ToList(),
                    loopsetData.Where(w => w.Key == DATA_ENUM.STP.RAT2).First().Value.Select(s => s.LOOPSET_ID).ToList(),
                    true);

                diffValues = SetFinalLoopsetValues(ref rat1Aux, ref rat2Aux, listsAnalysis);

                resultData.Add(DATA_ENUM.STP.RAT2, new AUDIT.AuditResult()
                {
                    NotInRAT1 = listsAnalysis[1],
                    NotInSTP = listsAnalysis[0],
                    Differences = loopsetData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Where(w => diffValues.Contains(w.LOOPSET_Footprint)).Select(s => s.LOOPSET_ID).ToList()
                });
                #endregion

                #region [ RAT1 & MIL1 ]
                rat1Aux = new List<Data.OST.LOOPSET_Data>(loopsetData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value);
                rat2Aux = new List<Data.OST.LOOPSET_Data>(loopsetData.Where(w => w.Key == DATA_ENUM.STP.MIL1).First().Value);

                listsAnalysis = GetListsAnalysis(
                    loopsetData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Select(s => s.LOOPSET_ID).ToList(),
                    loopsetData.Where(w => w.Key == DATA_ENUM.STP.MIL1).First().Value.Select(s => s.LOOPSET_ID).ToList(),
                    true);

                diffValues = SetFinalLoopsetValues(ref rat1Aux, ref rat2Aux, listsAnalysis);

                resultData.Add(DATA_ENUM.STP.MIL1, new AUDIT.AuditResult()
                {
                    NotInRAT1 = listsAnalysis[1],
                    NotInSTP = listsAnalysis[0],
                    Differences = loopsetData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Where(w => diffValues.Contains(w.LOOPSET_Footprint)).Select(s => s.LOOPSET_ID).ToList()
                });
                #endregion

                #region [ RAT1 & MIL2 ]
                rat1Aux = new List<Data.OST.LOOPSET_Data>(loopsetData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value);
                rat2Aux = new List<Data.OST.LOOPSET_Data>(loopsetData.Where(w => w.Key == DATA_ENUM.STP.MIL2).First().Value);

                listsAnalysis = GetListsAnalysis(
                    loopsetData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Select(s => s.LOOPSET_ID).ToList(),
                    loopsetData.Where(w => w.Key == DATA_ENUM.STP.MIL2).First().Value.Select(s => s.LOOPSET_ID).ToList(),
                    true);

                diffValues = SetFinalLoopsetValues(ref rat1Aux, ref rat2Aux, listsAnalysis);

                resultData.Add(DATA_ENUM.STP.MIL2, new AUDIT.AuditResult()
                {
                    NotInRAT1 = listsAnalysis[1],
                    NotInSTP = listsAnalysis[0],
                    Differences = loopsetData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Where(w => diffValues.Contains(w.LOOPSET_Footprint)).Select(s => s.LOOPSET_ID).ToList()
                });
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultData;
        }
        #endregion

        #region [ Audit TTMAP ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ttmapData"></param>
        /// <returns></returns>
        public static Dictionary<DATA_ENUM.STP, AUDIT.AuditResult> AuditTTMAP(Dictionary<DATA_ENUM.STP, List<Data.OST.TTMAP_Data>> ttmapData)
        {
            Dictionary<DATA_ENUM.STP, AUDIT.AuditResult> resultData = new Dictionary<DATA_ENUM.STP, AUDIT.AuditResult>();

            List<string>[] listsAnalysis = null;
            List<string> diffValues = null;

            List<Data.OST.TTMAP_Data> rat1Aux = null;
            List<Data.OST.TTMAP_Data> rat2Aux = null;

            try
            {
                #region [ RAT1 & RAT2 ]
                rat1Aux = new List<Data.OST.TTMAP_Data>(ttmapData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value);
                rat2Aux = new List<Data.OST.TTMAP_Data>(ttmapData.Where(w => w.Key == DATA_ENUM.STP.RAT2).First().Value);

                listsAnalysis = GetListsAnalysis(
                    ttmapData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Select(s => s.TTMAP_ID).ToList(),
                    ttmapData.Where(w => w.Key == DATA_ENUM.STP.RAT2).First().Value.Select(s => s.TTMAP_ID).ToList(),
                    true);

                diffValues = SetFinalTTMapValues(ref rat1Aux, ref rat2Aux, listsAnalysis);

                resultData.Add(DATA_ENUM.STP.RAT2, new AUDIT.AuditResult()
                {
                    NotInRAT1 = listsAnalysis[1],
                    NotInSTP = listsAnalysis[0],
                    Differences = ttmapData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Where(w => diffValues.Contains(w.TTMAP_Footprint)).Select(s => s.TTMAP_ID).ToList()
                });
                #endregion

                #region [ RAT1 & MIL1 ]
                rat1Aux = new List<Data.OST.TTMAP_Data>(ttmapData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value);
                rat2Aux = new List<Data.OST.TTMAP_Data>(ttmapData.Where(w => w.Key == DATA_ENUM.STP.MIL1).First().Value);

                listsAnalysis = GetListsAnalysis(
                    ttmapData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Select(s => s.TTMAP_ID).ToList(),
                    ttmapData.Where(w => w.Key == DATA_ENUM.STP.MIL1).First().Value.Select(s => s.TTMAP_ID).ToList(),
                    true);

                diffValues = SetFinalTTMapValues(ref rat1Aux, ref rat2Aux, listsAnalysis);

                resultData.Add(DATA_ENUM.STP.MIL1, new AUDIT.AuditResult()
                {
                    NotInRAT1 = listsAnalysis[1],
                    NotInSTP = listsAnalysis[0],
                    Differences = ttmapData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Where(w => diffValues.Contains(w.TTMAP_Footprint)).Select(s => s.TTMAP_ID).ToList()
                });
                #endregion

                #region [ RAT1 & MIL2 ]
                rat1Aux = new List<Data.OST.TTMAP_Data>(ttmapData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value);
                rat2Aux = new List<Data.OST.TTMAP_Data>(ttmapData.Where(w => w.Key == DATA_ENUM.STP.MIL2).First().Value);

                listsAnalysis = GetListsAnalysis(
                    ttmapData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Select(s => s.TTMAP_ID).ToList(),
                    ttmapData.Where(w => w.Key == DATA_ENUM.STP.MIL2).First().Value.Select(s => s.TTMAP_ID).ToList(),
                    true);

                diffValues = SetFinalTTMapValues(ref rat1Aux, ref rat2Aux, listsAnalysis);

                resultData.Add(DATA_ENUM.STP.MIL2, new AUDIT.AuditResult()
                {
                    NotInRAT1 = listsAnalysis[1],
                    NotInSTP = listsAnalysis[0],
                    Differences = ttmapData.Where(w => w.Key == DATA_ENUM.STP.RAT1).First().Value.Where(w => diffValues.Contains(w.TTMAP_Footprint)).Select(s => s.TTMAP_ID).ToList()
                });
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultData;
        }
        #endregion


        #region [ Get Lists Analysis ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aList"></param>
        /// <param name="bList"></param>
        /// <returns></returns>
        private static List<string>[] GetListsAnalysis(List<string> aList, List<string> bList, bool contains = false)
        {
            List<string>[] notPresent = new List<string>[2];

            // Exists in A list but not in B list
            notPresent[0] = aList.Except(bList).ToList();

            // Exists in B list but not in A list
            notPresent[1] = bList.Except(aList).ToList();

            vrsDPCs.AddRange(vrsDpcNames);

            foreach (string item in vrsDPCs)
            {
                for (int i = 0; i < 2; i++)
                {
                    if(contains)
                        notPresent[i].RemoveAll(r => r.Split('|')[1].Contains(item));
                    else
                        notPresent[i].RemoveAll(r => r.Split('|')[1] == item);
                }
            }

            return notPresent;
        }
        #endregion

        #region [ Set Final GTA Values ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rat1Aux"></param>
        /// <param name="rat2Aux"></param>
        /// <param name="analyzedData"></param>
        /// <returns></returns>
        private static List<string> SetFinalGtaValues(ref List<Data.OST.GTA_Data> rat1Aux, ref List<Data.OST.GTA_Data> rat2Aux, List<string>[] analyzedData)
        {
            foreach (string item in analyzedData[0])
                rat1Aux.RemoveAll(r => r.GTA_ID == item);

            foreach (string item in analyzedData[1])
                rat2Aux.RemoveAll(r => r.GTA_ID == item);

            return rat1Aux.ToList().Select(s => s.GTA_Footprint).ToList().Except(rat2Aux.ToList().Select(s => s.GTA_Footprint).ToList()).ToList();
        }
        #endregion

        #region [ Set Final OPCODE Values ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rat1Aux"></param>
        /// <param name="rat2Aux"></param>
        /// <param name="analyzedData"></param>
        /// <returns></returns>
        private static List<string> SetFinalOpcodeValues(ref List<Data.OST.OPCODE_Data> rat1Aux, ref List<Data.OST.OPCODE_Data> rat2Aux, List<string>[] analyzedData)
        {
            foreach (string item in analyzedData[0])
                rat1Aux.RemoveAll(r => r.OPCODE_ID == item);

            foreach (string item in analyzedData[1])
                rat2Aux.RemoveAll(r => r.OPCODE_ID == item);

            return rat1Aux.ToList().Select(s => s.OPCODE_Footprint).ToList().Except(rat2Aux.ToList().Select(s => s.OPCODE_Footprint).ToList()).ToList();
        }
        #endregion

        #region [ Set Final GTTSEL Values ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rat1Aux"></param>
        /// <param name="rat2Aux"></param>
        /// <param name="analyzedData"></param>
        /// <returns></returns>
        private static List<string> SetFinalGttselValues(ref List<Data.OST.GTTSEL_Data> rat1Aux, ref List<Data.OST.GTTSEL_Data> rat2Aux, List<string>[] analyzedData)
        {
            foreach (string item in vrsDPCs)
            {
                rat1Aux.RemoveAll(r => r.LSN.Substring(0, r.LSN.Length - 1) == item);
                rat2Aux.RemoveAll(r => r.LSN.Substring(0, r.LSN.Length - 1) == item);
            }

            foreach (string item in analyzedData[0])
                rat1Aux.RemoveAll(r => r.GTTSEL_ID == item);

            foreach (string item in analyzedData[1])
                rat2Aux.RemoveAll(r => r.GTTSEL_ID == item);

            return rat1Aux.ToList().Select(s => s.GTTSEL_Footprint).ToList().Except(rat2Aux.ToList().Select(s => s.GTTSEL_Footprint).ToList()).ToList();
        }
        #endregion

        #region [ Set Final GTTSET Values ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rat1Aux"></param>
        /// <param name="rat2Aux"></param>
        /// <param name="analyzedData"></param>
        /// <returns></returns>
        private static List<string> SetFinalGttsetValues(ref List<Data.OST.GTTSET_Data> rat1Aux, ref List<Data.OST.GTTSET_Data> rat2Aux, List<string>[] analyzedData)
        {
            foreach (string item in analyzedData[0])
                rat1Aux.RemoveAll(r => r.GTTSET_ID == item);

            foreach (string item in analyzedData[1])
                rat2Aux.RemoveAll(r => r.GTTSET_ID == item);

            return rat1Aux.ToList().Select(s => s.GTTSET_Footprint).ToList().Except(rat2Aux.ToList().Select(s => s.GTTSET_Footprint).ToList()).ToList();
        }
        #endregion

        #region [ Set Final MRNSET Values ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rat1Aux"></param>
        /// <param name="rat2Aux"></param>
        /// <param name="analyzedData"></param>
        /// <returns></returns>
        private static List<string> SetFinalMrnsetValues(ref List<Data.OST.MRNSET_Data> rat1Aux, ref List<Data.OST.MRNSET_Data> rat2Aux, List<string>[] analyzedData)
        {
            foreach (string item in vrsDPCs)
            {
                rat1Aux.RemoveAll(r => r.PC == item);
                rat2Aux.RemoveAll(r => r.PC == item);
            }

            foreach (string item in analyzedData[0])
                rat1Aux.RemoveAll(r => r.MRNSET_ID == item);

            foreach (string item in analyzedData[1])
                rat2Aux.RemoveAll(r => r.MRNSET_ID == item);

            return rat1Aux.ToList().Select(s => s.MRNSET_Footprint).ToList().Except(rat2Aux.ToList().Select(s => s.MRNSET_Footprint).ToList()).ToList();
        }
        #endregion

        #region [ Set Final DSTN Values ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rat1Aux"></param>
        /// <param name="rat2Aux"></param>
        /// <param name="analyzedData"></param>
        /// <returns></returns>
        private static List<string> SetFinalDstnValues(ref List<Data.OST.DSTN_Data> rat1Aux, ref List<Data.OST.DSTN_Data> rat2Aux, List<string>[] analyzedData)
        {
            foreach (string item in vrsDPCs)
            {
                rat1Aux.RemoveAll(r => r.DPC == item || r.APCI == item);
                rat2Aux.RemoveAll(r => r.DPC == item || r.APCI == item);
            }

            foreach (string item in analyzedData[0])
                rat1Aux.RemoveAll(r => r.DSTN_ID == item);

            foreach (string item in analyzedData[1])
                rat2Aux.RemoveAll(r => r.DSTN_ID == item);

            return rat1Aux.ToList().Select(s => s.DSTN_Footprint).ToList().Except(rat2Aux.ToList().Select(s => s.DSTN_Footprint).ToList()).ToList();
        }
        #endregion

        #region [ Set Final SLK Values ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rat1Aux"></param>
        /// <param name="rat2Aux"></param>
        /// <param name="analyzedData"></param>
        /// <returns></returns>
        private static List<string> SetFinalSlkValues(ref List<Data.OST.SLK_Data> rat1Aux, ref List<Data.OST.SLK_Data> rat2Aux, List<string>[] analyzedData)
        {
            foreach (string item in vrsDpcNames)
            {
                rat1Aux.RemoveAll(r => r.LSN.Substring(0, r.LSN.Length - 1) == item);
                rat2Aux.RemoveAll(r => r.LSN.Substring(0, r.LSN.Length - 1) == item);
            }

            foreach (string item in analyzedData[0])
                rat1Aux.RemoveAll(r => r.SLK_ID == item);

            foreach (string item in analyzedData[1])
                rat2Aux.RemoveAll(r => r.SLK_ID == item);

            return rat1Aux.ToList().Select(s => s.SLK_Footprint).ToList().Except(rat2Aux.ToList().Select(s => s.SLK_Footprint).ToList()).ToList();
        }
        #endregion

        #region [ Set Final ASSOC Values ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rat1Aux"></param>
        /// <param name="rat2Aux"></param>
        /// <param name="analyzedData"></param>
        /// <returns></returns>
        private static List<string> SetFinalAssocValues(ref List<Data.OST.ASSOC_Data> rat1Aux, ref List<Data.OST.ASSOC_Data> rat2Aux, List<string>[] analyzedData)
        {
            foreach (string item in vrsDpcNames)
            {
                rat1Aux.RemoveAll(r => r.ANAME.Contains(item));
                rat2Aux.RemoveAll(r => r.ANAME.Contains(item));                
            }

            foreach (string item in analyzedData[0])
                rat1Aux.RemoveAll(r => r.ASSOC_ID == item);

            foreach (string item in analyzedData[1])
                rat2Aux.RemoveAll(r => r.ASSOC_ID == item);

            return rat1Aux.ToList().Select(s => s.ASSOC_Footprint).ToList().Except(rat2Aux.ToList().Select(s => s.ASSOC_Footprint).ToList()).ToList();
        }
        #endregion

        #region [ Set Final LOOPSET Values ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rat1Aux"></param>
        /// <param name="rat2Aux"></param>
        /// <param name="analyzedData"></param>
        /// <returns></returns>
        private static List<string> SetFinalLoopsetValues(ref List<Data.OST.LOOPSET_Data> rat1Aux, ref List<Data.OST.LOOPSET_Data> rat2Aux, List<string>[] analyzedData)
        {
            foreach (string item in vrsDpcNames)
            {
                rat1Aux.RemoveAll(r => r.Loopset.Contains(item));
                rat2Aux.RemoveAll(r => r.Loopset.Contains(item));
            }

            foreach (string item in analyzedData[0])
                rat1Aux.RemoveAll(r => r.LOOPSET_ID == item);

            foreach (string item in analyzedData[1])
                rat2Aux.RemoveAll(r => r.LOOPSET_ID == item);

            return rat1Aux.ToList().Select(s => s.LOOPSET_Footprint).ToList().Except(rat2Aux.ToList().Select(s => s.LOOPSET_Footprint).ToList()).ToList();
        }
        #endregion

        #region [ Set Final TTMAP Values ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rat1Aux"></param>
        /// <param name="rat2Aux"></param>
        /// <param name="analyzedData"></param>
        /// <returns></returns>
        private static List<string> SetFinalTTMapValues(ref List<Data.OST.TTMAP_Data> rat1Aux, ref List<Data.OST.TTMAP_Data> rat2Aux, List<string>[] analyzedData)
        {
            foreach (string item in vrsDpcNames)
            {
                rat1Aux.RemoveAll(r => r.LSN.Contains(item));
                rat2Aux.RemoveAll(r => r.LSN.Contains(item));
            }

            foreach (string item in analyzedData[0])
                rat1Aux.RemoveAll(r => r.LSN == item);

            foreach (string item in analyzedData[1])
                rat2Aux.RemoveAll(r => r.LSN == item);

            return rat1Aux.ToList().Select(s => s.TTMAP_Footprint).ToList().Except(rat2Aux.ToList().Select(s => s.TTMAP_Footprint).ToList()).ToList();
        }
        #endregion
    }
}