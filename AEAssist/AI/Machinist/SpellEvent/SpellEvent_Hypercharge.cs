using AEAssist.Define;

namespace AEAssist.AI.Machinist.SpellEvent
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