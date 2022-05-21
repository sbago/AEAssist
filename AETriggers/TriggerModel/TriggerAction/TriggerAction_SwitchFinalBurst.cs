using System;

namespace AEAssist.TriggerAction
{
    [Trigger("SwitchFinalBurst")]
    public class TriggerAction_SwitchFinalBurst : ITriggerAction
    {
        public bool value;

        public void WriteFromJson(string[] values)
        {
            if (!int.TryParse(values[0], out var va)) throw new Exception($"{values[0]}Error!\n");

            value = va == 1;
        }
        
        public string[] Pack2Json()
        {
            return new string[]
            {
                value ? "1" : "0"
            };
        }
    }
}