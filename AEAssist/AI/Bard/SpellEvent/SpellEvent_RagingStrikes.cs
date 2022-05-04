using AEAssist.Define;

namespace AEAssist.AI.Bard.SpellEvent
{
    [SpellEvent(SpellsDefine.RagingStrikes)]
    public class SpellEvent_RagingStrikes : ISpellEvent
    {
        public void Run(uint spellId)
        {
            BardSpellHelper.RecordUsingRagingStrikesTime();
        }
    }
}