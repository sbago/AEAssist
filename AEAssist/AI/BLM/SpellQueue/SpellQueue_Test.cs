using System.Collections.Generic;

namespace AEAssist.AI.BLM.SpellQueue
{
    public class SpellQueue_Test : IAISpellQueue
    {
        public List<IAISpellQueueSlot> SlotQueue { get; } = new List<IAISpellQueueSlot>()
        {
            new SpellQueueSlot_Fire3(),
            new SpellQueueSlot_Fire4(),
            new SpellQueueSlot_Fire4(),
            new SpellQueueSlot_Fire4(),
            new SpellQueueSlot_Fire1(),
            new SpellQueueSlot_Fire4(),
            new SpellQueueSlot_Fire4(),
            new SpellQueueSlot_Fire4(),
            new SpellQueueSlot_Despair()
        };
    }
}