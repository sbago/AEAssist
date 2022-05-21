using System;

namespace AEAssist.TriggerCond
{
    [Trigger("AfterOtherTrigger",Tooltip = "After another group triggered\n等另一组触发了之后",
        ParamTooltip = "[Other trigger's group id],[Time in sec]\n[另一组触发器Id],[过了多少秒]",
        Example = "group5,30")]
    public class TriggerCond_AfterOtherTrigger : ITriggerCond
    {
        public int Time;
        public string TriggerId;

        public void WriteFromJson(string[] values)
        {
            TriggerId = values[0];
#if Trigger
            if (!AETriggers.DataBinding.Instance.GroupIds.Contains(TriggerId)) throw new Exception($"Id not found: {values[0]}!\n");
#endif

            if (!int.TryParse(values[1], out var time)) throw new Exception($"{values[1]}Error!\n");

            Time = time;
            if (Time < 0) throw new Exception("out of range!");
            if (Time > 2000) throw new Exception($"Time is too large! : Sec: {Time}");
        }

        public string[] Pack2Json()
        {
            return new string[]
            {
                TriggerId,
                Time.ToString()
            };
        }
    }
}