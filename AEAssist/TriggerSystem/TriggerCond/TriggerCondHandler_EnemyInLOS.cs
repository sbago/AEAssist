using AEAssist.AI;
using AEAssist.Helper;
using AEAssist.TriggerCond;

namespace AEAssist.TriggerSystem.TriggerCond
{
    public class TriggerCondHandler_EnemyInLOS : ATriggerCondHandler<TriggerCond_EnemyInLOS>
    {
        protected override bool Check(TriggerCond_EnemyInLOS cond)
        {
            if (AIRoot.GetBattleData<BattleData>().GetCondHitTime(cond, out var time))
            {
                if (TimeHelper.Now() >= time + cond.delayTime * 1000) return true;
            }
            else
            {
                var enemy = TargetMgr.Instance.Units;
                foreach (var v in enemy.Values)
                    if (v.NpcId.ToString() == cond.name || v.Name.Contains(cond.name))
                    {
                        AIRoot.GetBattleData<BattleData>().RecordCondHitTime(cond);
                        return false;
                    }
            }

            return false;
        }
    }
}