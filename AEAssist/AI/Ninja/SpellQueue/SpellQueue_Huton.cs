using System.Collections.Generic;

namespace AEAssist.AI.Ninja.SpellQueue
{
    public class SpellQueue_Huton : IAISpellQueue
    {
        public List<IAISpellQueueSlot> SlotQueue { get; } = new List<IAISpellQueueSlot>()
        {
            new SpellQueueSlot_Huton(),
        };
    }
}