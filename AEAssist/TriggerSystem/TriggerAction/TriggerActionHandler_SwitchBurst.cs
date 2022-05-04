using AEAssist.TriggerAction;

namespace AEAssist.TriggerSystem.TriggerAction
{
    public class TriggerActionHandler_SwitchBurst : ATriggerActionHandler<TriggerAction_SwitchBurst>
    {
        protected override void Handle(TriggerAction_SwitchBurst t)
        {
            AEAssist.DataBinding.Instance.Burst = t.value;
        }
    }
}