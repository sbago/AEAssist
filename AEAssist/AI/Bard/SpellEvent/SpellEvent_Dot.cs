using AEAssist.Define;

namespace AEAssist.AI.Bard.SpellEvent
{
    [SpellEvent(SpellsDefine.IronJaws)]
    [SpellEvent(SpellsDefine.Windbite)]
    [SpellEvent(SpellsDefine.Stormbite)]
    [SpellEvent(SpellsDefine.VenomousBite)]
    [SpellEvent(SpellsDefine.CausticBite)]
    public class SpellEvent_Dot : ISpellEvent
    {
        public void Run(uint spellId)
        {
            if (spellId == SpellsDefine.IronJaws)
                BardSpellHelper.RecordIronJaw();
            else
                BardSpellHelper.RemoveRecordIronJaw();
        }
    }
}