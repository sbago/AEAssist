using AEAssist.AI;
using AETriggers.TriggerModel;
using ff14bot.Managers;

namespace AEAssist.TriggerSystem.TriggerCond
{
    public class TriggerCondHandler_EnemyHpPct : ATriggerCondHandler<TriggerCond_EnemyHPPct>
    {
        protected override bool Check(TriggerCond_EnemyHPPct cond)
        {
            var enemys = TargetMgr.Instance.Enemys;
            foreach (var v in enemys.Values)
            {
                LogHelper.Info($"HPPct {v.Name} {v.CurrentHealthPercent}");
                if (!v.Name.Contains(cond.Name) && v.NpcId.ToString() != cond.Name)
                    continue;
                if (v.CurrentHealthPercent * 100 <= cond.HpPct)
                    return true;
            }

            return false;
        }
    }
}