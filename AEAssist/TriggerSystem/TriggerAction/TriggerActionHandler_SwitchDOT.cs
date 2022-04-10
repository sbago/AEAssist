using AETriggers.TriggerModel;

namespace AEAssist.TriggerSystem.TriggerAction
{
    public class TriggerActionHandler_SwitchDOT : ATriggerActionHandler<TriggerAction_SwitchDOT>
    {
        protected override void Handle(TriggerAction_SwitchDOT t)
        {
            DataBinding.Instance.UseDot = t.value;
        }
    }
}