using System;

namespace AETriggers.TriggerModel
{
    [Trigger("SwitchAOE", "允许AOE")]
    public class TriggerAction_SwitchAOE : ITriggerAction
    {
        public bool value;

        public void WriteFromJson(string[] values)
        {
            if (!int.TryParse(values[0], out var va)) throw new Exception($"{values[0]}格式错误!\n");

            value = va == 1;
        }
    }
}