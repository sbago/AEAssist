namespace AEAssist.AI.Machinist
{
    [SpellEvent(SpellsDefine.AutoCrossbow)]
    [SpellEvent(SpellsDefine.HeatBlast)]
    public class SpellEvent_UnderHyperChargetGCD : ISpellEvent
    {
        public void Run(uint spellId)
        {
            AIRoot.GetBattleData<BattleData>().LimitAbility = true;
            AIRoot.GetBattleData<MCHBattleData>().HyperchargeGCDCount++;
        }
    }
}