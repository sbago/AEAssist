using System;
using System.Collections.Generic;

namespace AEAssist.TriggerAction
{
    [Trigger("BatteryList")]
    public class TriggerAction_BatteryList : ITriggerAction
    {
        public List<int> BatteryList = new List<int>();

        public void WriteFromJson(string[] values)
        {
            if (string.IsNullOrEmpty(values[0]))
                throw new Exception("Error!");

            var strs = values[0].Split('|');
            if (strs == null || strs.Length == 0)
                throw new Exception("Error!");

            foreach (var v in strs)
            {
                if (!int.TryParse(v, out var battery)) throw new Exception($"{v} format Error!");

                BatteryList.Add(battery);
            }
        }

        public string[] Pack2Json()
        {
            var str = string.Empty;
            for (int i = 0; i < BatteryList.Count; i++)
            {
                str += BatteryList[i].ToString()+'|';
            }

            str = str.Remove(str.Length - 1);
            return new string[]
            {
                str
            };
        }
    }
}