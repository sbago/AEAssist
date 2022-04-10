using AEAssist.AI;
using AETriggers.TriggerModel;

namespace AEAssist.TriggerSystem.TriggerCond
{
    public class TriggerCondHandler_AfterBattleStart : ATriggerCondHandler<TriggerCond_AfterBattleStart>
    {
        protected override bool Check(TriggerCond_AfterBattleStart cond)
        {
            var battleTime = AIRoot.Instance.BattleData.BattleTime;
            return battleTime >= cond.Time;
        }
    }
}