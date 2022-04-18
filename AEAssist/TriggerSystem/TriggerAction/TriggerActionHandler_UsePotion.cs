using AEAssist.AI;
using AETriggers.TriggerModel;

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