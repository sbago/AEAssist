using System;

namespace AETriggers.TriggerModel
{
    [Trigger("AfterOtherTrigger")]
    public class TriggerCond_AfterOtherTrigger : ITriggerCond
    {
        public int Time;
        public string TriggerId;

        public void WriteFromJson(string[] values)
        {
            TriggerId = values[0];
#if Trigger
            if (!Entry.AllExcelData.ContainsKey(this.TriggerId))
            {
                throw new Exception($"Id not found: {values[0]}!\n");
            }
#endif

            if (!int.TryParse(values[1], out var time)) throw new Exception($"{values[1]}Error!\n");

            Time = time;
            if (Time < 0) throw new Exception("out of range!");
            if (Time > 2000) throw new Exception($"Time is too large! : Sec: {Time}");
        }
    }
}