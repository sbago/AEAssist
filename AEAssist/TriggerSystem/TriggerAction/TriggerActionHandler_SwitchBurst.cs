using AEAssist.AI;
using AETriggers.TriggerModel;

namespace AEAssist.TriggerSystem.TriggerAction
{
    public class TriggerActionHandler_SwitchBurst : ATriggerActionHandler<TriggerAction_SwitchBurst>
    {
        protected override void Handle(TriggerAction_SwitchBurst t)
        {
            GUIHelper.ShowInfo($"触发器行为: {t.GetType().Name} {t.value}",2000,false);
            AIRoot.Instance.CloseBuff = !t.value;
        }
    }
}