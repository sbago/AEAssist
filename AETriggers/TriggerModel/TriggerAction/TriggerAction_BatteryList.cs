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
    }
}