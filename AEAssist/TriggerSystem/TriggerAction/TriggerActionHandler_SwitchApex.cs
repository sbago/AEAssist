using AETriggers.TriggerModel;

namespace AEAssist.TriggerSystem.TriggerAction
{
    public class TriggerActionHandler_SwitchApex : ATriggerActionHandler<TriggerAction_SwitchApex>
    {
        protected override void Handle(TriggerAction_SwitchApex t)
        {
            DataBinding.Instance.UseApex = t.value;
        }
    }
}