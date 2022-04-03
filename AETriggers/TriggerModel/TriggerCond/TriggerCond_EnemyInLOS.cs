using System;

namespace AETriggers.TriggerModel
{
    [Trigger(name:"EnemyInLOS",remark:"敌人出现在视野里")]
    public class TriggerCond_EnemyInLOS : ITriggerCond
    {

        public string name;
        
        public void WriteFromJson(string[] values)
        {
            this.name = values[0];
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("配置了无效的敌人名!");
            }
        }
    }
}