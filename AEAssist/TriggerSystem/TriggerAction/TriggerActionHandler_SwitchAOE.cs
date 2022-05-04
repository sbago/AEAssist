using AEAssist.TriggerAction;

namespace AEAssist.TriggerSystem.TriggerAction
{
    public class TriggerActionHandler_SwitchAOE : ATriggerActionHandler<TriggerAction_SwitchAOE>
    {
        protected override void Handle(TriggerAction_SwitchAOE t)
        {
            AEAssist.DataBinding.Instance.UseAOE = t.value;
        }
    }
}