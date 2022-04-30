namespace AEAssist.AI.Machinist
{
    [SpellEvent(SpellsDefine.Hypercharge)]
    public class SpellEvent_Hypercharge : ISpellEvent
    {
        public void Run(uint spellId)
        {
            AIRoot.GetBattleData<MCHBattleData>().HyperchargeGCDCount = 0;
        }
    }
}