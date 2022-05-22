using AEAssist.AI;
using AEAssist.TriggerAction;

namespace AEAssist.TriggerSystem.TriggerAction
{
    public class TriggerActionHandler_RemoveOtherTrigger : ATriggerActionHandler<TriggerAction_DisableOtherTrigger>
    {
        protected override void Handle(TriggerAction_DisableOtherTrigger t)
        {
            AIRoot.GetBattleData<BattleData>().SetExecuted(t.TriggerId);
        }
    }
}