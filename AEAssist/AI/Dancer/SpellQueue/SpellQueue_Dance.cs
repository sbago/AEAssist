using System.Collections.Generic;

namespace AEAssist.AI.Dancer.SpellQueue
{
    public class SpellQueue_Dance : IAISpellQueue
    {
        public List<IAISpellQueueSlot> SlotQueue { get; } = new List<IAISpellQueueSlot>()
        {
            new SpellQueueSlot_DanceStep(),
            new SpellQueueSlot_DanceFinish()
        };
    }
}