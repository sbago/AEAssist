using AEAssist.AI;
using AETriggers.TriggerModel;

namespace AEAssist.TriggerSystem.TriggerCond
{
    public class TriggerCondHandler_EnemyInLOS : ATriggerCondHandler<TriggerCond_EnemyInLOS>
    {
        protected override bool Check(TriggerCond_EnemyInLOS cond)
        {
            var enemy = TargetMgr.Instance.Enemys;
            foreach (var v in enemy.Values)
            {
                if (v.Name.Contains(cond.name))
                    return true;
            }

            return false;
        }
    }
}