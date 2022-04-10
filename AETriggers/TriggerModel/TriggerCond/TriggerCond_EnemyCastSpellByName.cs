using System;

namespace AETriggers.TriggerModel
{
    [Trigger("EnemyCastSpellByName", "场内有敌人正在读条xx技能")]
    public class TriggerCond_EnemyCastSpellByName : ITriggerCond
    {
        public string spellName;

        public void WriteFromJson(string[] values)
        {
            spellName = values[0];
            if (string.IsNullOrEmpty(spellName)) throw new Exception("配置了无效的技能名!");
        }
    }
}