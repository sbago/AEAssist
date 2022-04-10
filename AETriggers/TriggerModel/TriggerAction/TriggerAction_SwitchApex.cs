using System;

namespace AETriggers.TriggerModel
{
    [Trigger("SwitchApex", "是否允许使用绝峰箭")]
    public class TriggerAction_SwitchApex : ITriggerAction
    {
        public bool value;

        public void WriteFromJson(string[] values)
        {
            if (!int.TryParse(values[0], out var va)) throw new Exception($"{values[0]}格式错误!\n");

            value = va == 1;
        }
    }
}