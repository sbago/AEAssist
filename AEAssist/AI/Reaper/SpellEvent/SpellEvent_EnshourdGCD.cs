namespace AEAssist.AI.Reaper
{
    [SpellEvent(SpellsDefine.VoidReaping)]
    [SpellEvent(SpellsDefine.Communio)]
    [SpellEvent(SpellsDefine.GrimReaping)]
    [SpellEvent(SpellsDefine.CrossReaping)]
    public class SpellEvent_EnshourdGCD : ISpellEvent
    {
        public void Run(uint spellId)
        {
            AIRoot.GetBattleData<BattleData>().LimitAbility = true;
        }
    }
}