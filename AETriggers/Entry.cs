using System.Collections.Generic;
using AETriggers.TriggerModel;

namespace AETriggers
{
    public static class Entry
    {
        public static TriggerLine TriggerLine;

        public struct ExcelData
        {
            public string groupId;
            public string type;
            public string valueType;
            public string[] valueParams;
        }

        public static Dictionary<string, List<ExcelData>> AllExcelData = new Dictionary<string, List<ExcelData>>();

        public static void Init()
        {
        }
    }
}