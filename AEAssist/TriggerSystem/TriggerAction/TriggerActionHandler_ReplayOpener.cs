using AEAssist.AI;
using AEAssist.TriggerAction;

namespace AEAssist.TriggerSystem.TriggerAction
{
    public class TriggerActionHandler_ReplayOpener : ATriggerActionHandler<TriggerAction_ReplayOpener>
    {
        protected override void Handle(TriggerAction_ReplayOpener t)
        {
            AIRoot.GetBattleData<BattleData>().OpenerIndex = 0;
        }
    }
}