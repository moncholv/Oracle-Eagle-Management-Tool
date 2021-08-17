using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRS_Eng_Manage_Tool.Business.Audit
{
    public static class Commands
    {
        #region [ Get Command GTA ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public static string[] GetCommand_GTA(Data.OST.GTA_Data record)
        {
            bool gtmodid = !Utilities.OnlyHyphen(record.GTMODID);
            bool endgta = record.Start_GTA != record.End_GTA;
            object[] commandFields = null;
            object[] rollbackFields = null;

            string commandTemplate, rollbackTemplate;

            if(endgta)
            {
                commandFields = gtmodid ? new object[9] { record.Table, record.Start_GTA, record.End_GTA, record.XLAT, record.RI, record.MRNSET, record.ITU_PC, record.GTMODID, record.LOOPSET } : 
                    new object[8] { record.Table, record.Start_GTA, record.End_GTA, record.XLAT, record.RI, record.MRNSET, record.ITU_PC, record.LOOPSET };

                commandTemplate = gtmodid ? "ent-gta:gttsn={0}:gta={1}:egta={2}:xlat={3}:ri={4}:mrnset={5}:pci={6}:gtmodid={7}:loopset={8}" :
                    "ent-gta:gttsn={0}:gta={1}:egta={2}:xlat={3}:ri={4}:mrnset={5}:pci={6}:loopset={7}";

                rollbackFields = new object[3] { record.GTTSN, record.Start_GTA, record.End_GTA };
                rollbackTemplate = "dlt-gta:gttsn={0}:gta={1}:egta={2}";
            }
            else
            {
                commandFields = gtmodid ? new object[8] { record.Table, record.Start_GTA, record.XLAT, record.RI, record.MRNSET, record.ITU_PC, record.GTMODID, record.LOOPSET } :
                    new object[7] { record.Table, record.Start_GTA, record.XLAT, record.RI, record.MRNSET, record.ITU_PC, record.LOOPSET };

                commandTemplate = gtmodid ? "ent-gta:gttsn={0}:gta={1}:xlat={2}:ri={3}:mrnset={4}:pci={5}:gtmodid={6}:loopset={7}" :
                    "ent-gta:gttsn={0}:gta={1}:xlat={2}:ri={3}:mrnset={4}:pci={5}:loopset={6}";

                rollbackTemplate = "dlt-gta:gttsn={0}:gta={1}";
                rollbackFields = new object[2] { record.GTTSN, record.Start_GTA };
            }

            return new string[2] { string.Format(commandTemplate, commandFields), string.Format(rollbackTemplate, rollbackFields) };
        }
        #endregion
    }
}