using System;

namespace AETriggers.TriggerModel
{
    [Trigger("EnemyHPPct", "某敌人血量百分比")]
    public class TriggerCond_EnemyHPPct : ITriggerCond
    {
        public float HpPct; // xx.xxx
        public string Name;

        public void WriteFromJson(string[] values)
        {
            Name = values[0];
            if (string.IsNullOrEmpty(Name)) throw new Exception($"{values[0]} 为空!");

            if (!float.TryParse(values[1], out var va)) throw new Exception($"{values[1]} 格式错误!");

            HpPct = va;
        }
    }
}