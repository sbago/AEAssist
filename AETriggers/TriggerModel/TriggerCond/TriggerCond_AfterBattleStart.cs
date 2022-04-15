using System;

namespace AETriggers.TriggerModel
{
    [Trigger("AfterBattleStart")]
    public class TriggerCond_AfterBattleStart : ITriggerCond
    {
        public int Time;

        public void WriteFromJson(string[] values)
        {
            if (!int.TryParse(values[0], out var time)) throw new Exception($"{values[0]}Error!\n");

            Time = time;
            if (Time < 0) throw new Exception("Out of range!");
        }
    }
}