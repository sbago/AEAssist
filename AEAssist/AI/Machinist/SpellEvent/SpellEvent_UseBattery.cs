using AEAssist.Define;

namespace AEAssist.AI.Machinist.SpellEvent
{
    [SpellEvent(SpellsDefine.RookAutoturret)]
    [SpellEvent(SpellsDefine.AutomationQueen)]
    public class SpellEvent_UseBattery : ISpellEvent
    {
        public void Run(uint spellId)
        {
        }
    }
}