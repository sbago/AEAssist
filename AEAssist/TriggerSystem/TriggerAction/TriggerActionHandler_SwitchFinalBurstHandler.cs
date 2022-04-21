using AETriggers.TriggerModel;

namespace AEAssist.TriggerSystem.TriggerAction
{
    public class TriggerActionHandler_SwitchFinalBurstHandler : ATriggerActionHandler<TriggerAction_SwitchFinalBurst>
    {
        protected override void Handle(TriggerAction_SwitchFinalBurst t)
        {
            DataBinding.Instance.FinalBurst = t.value;
        }
    }
}