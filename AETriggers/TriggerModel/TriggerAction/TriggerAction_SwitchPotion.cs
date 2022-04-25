using System;

namespace AETriggers.TriggerModel
{
    [Trigger("SwitchPotion")]
    public class TriggerAction_SwitchPotion : ITriggerAction
    {
        public bool value;
        public void WriteFromJson(string[] values)
        {
            if (!int.TryParse(values[0], out var va)) throw new Exception($"{values[0]}Error!\n");

            value = va == 1;
        }
    }
}