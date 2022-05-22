using System;

namespace AEAssist.TriggerAction
{
    [Trigger("DisableOtherTrigger",Tooltip = "关闭另一组触发器",ParamTooltip = "[Other trigger's group id]")]
    public class TriggerAction_DisableOtherTrigger : ITriggerAction
    {
        public string TriggerId;

        public void WriteFromJson(string[] values)
        {
            TriggerId = values[0];
#if Trigger
            if (!AETriggers.DataBinding.Instance.GroupIds.Contains(TriggerId))
                throw new Exception($"Id not found: {values[0]}!\n");
#endif
        }

        public string[] Pack2Json()
        {
            return new string[]
            {
                TriggerId
            };
        }
    }
}