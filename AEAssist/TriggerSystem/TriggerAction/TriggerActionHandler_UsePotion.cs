using AEAssist.AI;
using AEAssist.TriggerAction;

namespace AEAssist.TriggerSystem.TriggerAction
{
    public class TriggerActionHandler_UsePotion : ATriggerActionHandler<TriggerAction_UsePotion>
    {
        protected override void Handle(TriggerAction_UsePotion t)
        {
            AIRoot.GetBattleData<BattleData>().NextAbilityUsePotion = true;
        }
    }
}