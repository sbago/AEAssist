using AEAssist.AI;
using AEAssist.Define;
using AETriggers.TriggerModel;

namespace AEAssist.TriggerSystem.TriggerAction
{
    public class TriggerActionHandler_CastGCD : ATriggerActionHandler<TriggerAction_CastGCD>
    {
        protected override void Handle(TriggerAction_CastGCD t)
        {
            AIRoot.GetBattleData<BattleData>().NextGcdSpellId = new SpellEntity(t.SpellId);
        }
    }
}