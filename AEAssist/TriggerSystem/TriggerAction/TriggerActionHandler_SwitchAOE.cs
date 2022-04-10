using AETriggers.TriggerModel;

namespace AEAssist.TriggerSystem.TriggerAction
{
    public class TriggerActionHandler_SwitchAOE : ATriggerActionHandler<TriggerAction_SwitchAOE>
    {
        protected override void Handle(TriggerAction_SwitchAOE t)
        {
            DataBinding.Instance.UseAOE = t.value;
        }
    }
}