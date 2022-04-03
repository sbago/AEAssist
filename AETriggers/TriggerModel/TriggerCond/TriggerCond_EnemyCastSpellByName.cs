using System;

namespace AETriggers.TriggerModel
{
    [Trigger(name:"EnemyCastSpellByName",remark:"场内有敌人正在读条xx技能")]
    public class TriggerCond_EnemyCastSpellByName : ITriggerCond
    {
        public string spellName;
        
        public void WriteFromJson(string[] values)
        {
            this.spellName = values[0];
            if (string.IsNullOrEmpty(spellName))
            {
                throw new Exception("配置了无效的技能名!");
            }
        }
    }
}