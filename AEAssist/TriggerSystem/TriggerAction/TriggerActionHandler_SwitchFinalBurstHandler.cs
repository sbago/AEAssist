using AEAssist.TriggerAction;

namespace AEAssist.TriggerSystem.TriggerAction
{
    public class TriggerActionHandler_SwitchFinalBurstHandler : ATriggerActionHandler<TriggerAction_SwitchFinalBurst>
    {
        protected override void Handle(TriggerAction_SwitchFinalBurst t)
        {
            AEAssist.DataBinding.Instance.FinalBurst = t.value;
        }
    }
}