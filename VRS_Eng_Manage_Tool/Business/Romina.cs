using System;
using System.Collections.Generic;
using ExcelLibrary.SpreadSheet;
using System.Data;
using System.Linq;

using DATA_ENUM = VRS_Eng_Manage_Tool.Data.Enum;

namespace VRS_Eng_Manage_Tool.Business
{
    public class Romina
    {
        #region [ Get Romina Data ]
        public static List<Data.Romina.RominaAgent> GetRominaData(string file)
        {
            List<Data.Romina.RominaAgent> lRominaAgents = new List<Data.Romina.RominaAgent>();

            Workbook book = Workbook.Load(file);
            Worksheet sheet = book.Worksheets[0];

            int index = 0;

            foreach (KeyValuePair<int, Row> rowDAta in sheet.Cells.Rows)
            {
                if (rowDAta.Key > 15)
                {
                    try
                    {
                        lRominaAgents.Add(new Data.Romina.RominaAgent()
                        {
                            Type = GetCellData(rowDAta.Value, (int)DATA_ENUM.Romina.Headers.Type),
                            TSC = GetCellData(rowDAta.Value, (int)DATA_ENUM.Romina.Headers.TSC),
                            Country = GetCellData(rowDAta.Value, (int)DATA_ENUM.Romina.Headers.Country),
                            Name = GetCellData(rowDAta.Value, (int)DATA_ENUM.Romina.Headers.Name),
                            IMSI = GetCellData(rowDAta.Value, (int)DATA_ENUM.Romina.Headers.IMSI),
                            MGT = GetCellData(rowDAta.Value, (int)DATA_ENUM.Romina.Headers.MGT).Replace("#", ""),
                            Signalling_Group_GEO = GetCellData(rowDAta.Value, (int)DATA_ENUM.Romina.Headers.Signalling_Group_GEO),
                            PCode = GetCellData(rowDAta.Value, (int)DATA_ENUM.Romina.Headers.PCode),
                            WOW = GetCellData(rowDAta.Value, (int)DATA_ENUM.Romina.Headers.WOW),
                            GTRC = GetCellData(rowDAta.Value, (int)DATA_ENUM.Romina.Headers.GTRC),
                            NGT = GetCellData(rowDAta.Value, (int)DATA_ENUM.Romina.Headers.NGT).Split(',').ToList().Select(s => s.Replace("#", "")).ToList(),
                            MSISDNs = GetCellData(rowDAta.Value, (int)DATA_ENUM.Romina.Headers.MSISDN).Split(',').ToList().Select(s => s.Replace("#", "")).ToList(),
                            SP = GetCellData(rowDAta.Value, (int)DATA_ENUM.Romina.Headers.SP),
                            Destination = GetCellData(rowDAta.Value, (int)DATA_ENUM.Romina.Headers.Destination),
                            Standard = GetCellData(rowDAta.Value, (int)DATA_ENUM.Romina.Headers.Standard),
                            ACC = GetCellData(rowDAta.Value, (int)DATA_ENUM.Romina.Headers.ACC),
                            Main_TSC_hubbed = GetCellData(rowDAta.Value, (int)DATA_ENUM.Romina.Headers.Main_TSC_hubbed),
                            Service_Type = GetCellData(rowDAta.Value, (int)DATA_ENUM.Romina.Headers.Service_Type),
                            Peering_Hub = GetCellData(rowDAta.Value, (int)DATA_ENUM.Romina.Headers.Peering_Hub),
                            SoR = GetCellData(rowDAta.Value, (int)DATA_ENUM.Romina.Headers.SoR),
                            BRG = GetCellData(rowDAta.Value, (int)DATA_ENUM.Romina.Headers.BRG),
                            OTA = GetCellData(rowDAta.Value, (int)DATA_ENUM.Romina.Headers.OTA),
                            HSoR = GetCellData(rowDAta.Value, (int)DATA_ENUM.Romina.Headers.HSoR),
                            VHE = GetCellData(rowDAta.Value, (int)DATA_ENUM.Romina.Headers.VHE),
                            WSMS = GetCellData(rowDAta.Value, (int)DATA_ENUM.Romina.Headers.WSMS),
                            SMS_HUB = GetCellData(rowDAta.Value, (int)DATA_ENUM.Romina.Headers.SMS_HUB),
                            Standard_2 = GetCellData(rowDAta.Value, (int)DATA_ENUM.Romina.Headers.Standard_2),
                            ACC_2 = GetCellData(rowDAta.Value, (int)DATA_ENUM.Romina.Headers.ACC_2),
                            Main_TSC_3rd = GetCellData(rowDAta.Value, (int)DATA_ENUM.Romina.Headers.Main_TSC_3rd),
                            TSC_2 = GetCellData(rowDAta.Value, (int)DATA_ENUM.Romina.Headers.TSC_2)
                        });
                    }
                    catch(System.IO.IOException ioEx)
                    {
                        throw ioEx;
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }

                index += 1;
            }

            return lRominaAgents;
        }
        #endregion

        #region [ Get Cell Data ]
        private static string GetCellData(Row rowData, int index)
        {
            object value = rowData.GetCell(index).Value;
            return value != null ? value.ToString().Replace("#", "") : string.Empty;
        }
        #endregion
    }
}