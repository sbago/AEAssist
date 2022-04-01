using System.Threading.Tasks;
using AEAssist.AI;
using AETriggers.TriggerModel;

namespace AEAssist.TriggerSystem.TriggerCond
{
    public class TriggerCondHandler_AfterBattleStart : ATriggerCondHandler<TriggerCond_AfterBattleStart>
    {
        protected override void Handle(TriggerCond_AfterBattleStart cond, TaskCompletionSource<bool> tcs)
        {
            AIRoot.Instance.AddTcs(cond.Time,tcs);
        }
    }
}