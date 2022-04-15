using System;

namespace AETriggers.TriggerModel
{
    [Trigger("EnemyInLOS")]
    public class TriggerCond_EnemyInLOS : ITriggerCond
    {
        public string name;

        public void WriteFromJson(string[] values)
        {
            name = values[0];
            if (string.IsNullOrEmpty(name)) throw new Exception("is null!");
        }
    }
}