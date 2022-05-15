using System.Collections.Generic;

namespace AEAssist.AI.BlackMage.SpellQueue
{
    public class SpellQueue_DespairCombo : IAISpellQueue
    {
        public List<IAISpellQueueSlot> SlotQueue { get; } = new List<IAISpellQueueSlot>()
        {
            new SpellQueueSlot_Despair(),
            new SpellQueueSlot_Xenoglossy(),
            new SpellQueueSlot_Thunder(),
            new SpellQueueSlot_Fire4(),
            new SpellQueueSlot_Thunder(),
            new SpellQueueSlot_Despair(),
        };
    }
}