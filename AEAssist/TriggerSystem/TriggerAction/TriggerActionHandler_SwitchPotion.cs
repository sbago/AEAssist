using AEAssist.AI;
using AETriggers.TriggerModel;

namespace AEAssist.TriggerSystem.TriggerAction
{
    public class TriggerActionHandler_SwitchPotion : ATriggerActionHandler<TriggerAction_SwitchPotion>
    {
        protected override void Handle(TriggerAction_SwitchPotion t)
        {
            SettingMgr.GetSetting<GeneralSettings>().UsePotion = t.value;
        }
    }
}