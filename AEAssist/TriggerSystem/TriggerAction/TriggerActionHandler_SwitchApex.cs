using AEAssist.TriggerAction;

namespace AEAssist.TriggerSystem.TriggerAction
{
    public class TriggerActionHandler_SwitchApex : ATriggerActionHandler<TriggerAction_SwitchApex>
    {
        protected override void Handle(TriggerAction_SwitchApex t)
        {
            AEAssist.DataBinding.Instance.UseApex = t.value;
        }
    }
}