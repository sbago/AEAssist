namespace AEAssist.AI.Machinist
{
    [SpellEvent(SpellsDefine.RookAutoturret)]
    [SpellEvent(SpellsDefine.AutomationQueen)]
    public class SpellEvent_UseBattery : ISpellEvent
    {
        public void Run(uint spellId)
        {
            AIRoot.GetBattleData<MCHBattleData>().ResetBattery();
        }
    }
}