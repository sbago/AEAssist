using AEAssist.AI;
using AEAssist.TriggerCond;

namespace AEAssist.TriggerSystem.TriggerCond
{
    public class TriggerCondHandler_AfterBattleStart : ATriggerCondHandler<TriggerCond_AfterBattleStart>
    {
        protected override bool Check(TriggerCond_AfterBattleStart cond)
        {
            var battleTime = AIRoot.GetBattleData<BattleData>().CurrBattleTimeInMs;
            return battleTime >= cond.Time * 1000;
        }
    }
}