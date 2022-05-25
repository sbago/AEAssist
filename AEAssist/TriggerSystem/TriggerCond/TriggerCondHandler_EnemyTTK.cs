using AEAssist.AI;
using AEAssist.Helper;
using AEAssist.TriggerCond;
using ff14bot;

namespace AEAssist.TriggerSystem.TriggerCond
{
    public class TriggerCondHandler_EnemyTTK : ATriggerCondHandler<TriggerCond_EnemyTTK>
    {
        protected override bool Check(TriggerCond_EnemyTTK cond)
        {
            var enemys = TargetMgr.Instance.Enemys;
            foreach (var v in enemys.Values)
            {
                if (!v.Name.Contains(cond.Name) && v.NpcId.ToString() != cond.Name)
                    continue;
                if (TTKHelper.IsTargetTTK(v, cond.TimeToKill, true))
                {
                    return true;
                }
            }

            return false;
        }
    }
}