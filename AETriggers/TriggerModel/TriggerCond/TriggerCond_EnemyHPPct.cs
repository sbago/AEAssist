using System;

namespace AETriggers.TriggerModel
{
    [Trigger(name:"EnemyHPPct",remark:"某敌人血量百分比")]
    public class TriggerCond_EnemyHPPct : ITriggerCond
    {
        public string Name;
        public float HpPct; // xx.xxx
        
        public void WriteFromJson(string[] values)
        {
            this.Name = values[0];
            if (string.IsNullOrEmpty(this.Name))
            {
                throw new Exception($"{values[0]} 为空!");
            }

            if (!float.TryParse(values[1], out var va))
            {
                throw new Exception($"{values[1]} 格式错误!");
            }

            this.HpPct = va;
        }
    }
}