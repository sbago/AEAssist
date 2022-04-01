using AEAssist.AI;
using AETriggers.TriggerModel;

namespace AEAssist.TriggerSystem.TriggerAction
{
    public class TriggerActionHandler_SwitchBurst : ATriggerActionHandler<TriggerAction_SwitchBurst>
    {
        protected override void Handle(TriggerAction_SwitchBurst t)
        {
            LogHelper.Info($"TriggerAction: {t.GetType().Name} {t.value}");
            AIRoot.Instance.CloseBuff = !t.value;
        }
    }
}