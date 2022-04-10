using AEAssist.AI;
using AEAssist.Helper;
using AETriggers.TriggerModel;

namespace AEAssist.TriggerSystem.TriggerCond
{
    public class TriggerCondHandler_AfterOtherTrigger : ATriggerCondHandler<TriggerCond_AfterOtherTrigger>
    {
        protected override bool Check(TriggerCond_AfterOtherTrigger cond)
        {
            var time = AIRoot.Instance.BattleData.GetExecutedTriggersTime(cond.TriggerId);
            if (time == 0)
                return false;
            if (TimeHelper.Now() - time >= cond.Time)
                return true;
            return false;
        }
    }
}