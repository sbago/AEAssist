using System;

namespace AETriggers.TriggerModel
{
    [Trigger("EnemyHPPct")]
    public class TriggerCond_EnemyHPPct : ITriggerCond
    {
        public float HpPct; // xx.xxx
        public string Name;
        public int delayTime;

        public void WriteFromJson(string[] values)
        {
            Name = values[0];
            if (string.IsNullOrEmpty(Name)) throw new Exception($"{values[0]} is null!");

            if (!float.TryParse(values[1], out var va)) throw new Exception($"{values[1]} Error!");

            HpPct = va;
            
            if (!int.TryParse(values[2], out var delay)) throw new Exception($"{values[2]}Error!\n");

            if (delay < 0) throw new Exception("Must >=0 : " + delay);
            delayTime = delay;
        }
    }
}