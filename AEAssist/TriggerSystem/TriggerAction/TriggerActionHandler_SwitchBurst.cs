using AEAssist.AI;
using AETriggers.TriggerModel;

namespace AEAssist.TriggerSystem.TriggerAction
{
    public class TriggerActionHandler_SwitchBurst : ATriggerActionHandler<TriggerAction_SwitchBurst>
    {
        protected override void Handle(TriggerAction_SwitchBurst t)
        {
            DataBinding.Instance.Burst = t.value;
        }
    }
}