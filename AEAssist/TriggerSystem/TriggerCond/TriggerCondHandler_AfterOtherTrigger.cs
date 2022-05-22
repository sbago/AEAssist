using AEAssist.AI;
using AEAssist.Helper;
using AEAssist.TriggerCond;

namespace AEAssist.TriggerSystem.TriggerCond
{
    public class TriggerCondHandler_AfterOtherTrigger : ATriggerCondHandler<TriggerCond_AfterOtherTrigger>
    {
        protected override bool Check(TriggerCond_AfterOtherTrigger cond)
        {
            long time = 0;
            if (cond.Complex == 0)
            {
                time = AIRoot.GetBattleData<BattleData>().GetExecutedTriggersTime(cond.TriggerId);
            }
            else if(cond.Complex == 1)
            {
                time = AIRoot.GetBattleData<BattleData>().GetExecutedTriggersTime_And(cond.ComplexTriggers);
            }
            else
            {
                time = AIRoot.GetBattleData<BattleData>().GetExecutedTriggersTime_Or(cond.ComplexTriggers);
            }
            if (time == 0)
                return false;
            if (TimeHelper.Now() - time >= cond.Time * 1000)
                return true;

            return false;
        }
    }
}