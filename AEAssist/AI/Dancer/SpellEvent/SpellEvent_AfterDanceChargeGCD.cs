using AEAssist.Define;

namespace AEAssist.AI.Dancer.SpellEvent
{
    [SpellEvent(SpellsDefine.DoubleStandardFinish)]
    [SpellEvent(SpellsDefine.QuadrupleTechnicalFinish)]
    [SpellEvent(SpellsDefine.Tillana)]
    public class SpellEvent_AfterDanceChargeGCD : ISpellEvent
    {
        public void Run(uint spellId)
        {
            AIRoot.GetBattleData<BattleData>().LimitAbility = true;
        }
    }
}