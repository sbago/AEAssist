using System.Collections.Generic;

namespace AEAssist.AI.Samurai.SpellQueue
{
    public class SpellQueue_OgiNamikiriCombo : IAISpellQueue
    {
        public List<IAISpellQueueSlot> SlotQueue { get; } = new List<IAISpellQueueSlot>()
        {
            new SpellQueueSlot_KaeshiNamikiri()
        };
    }
}