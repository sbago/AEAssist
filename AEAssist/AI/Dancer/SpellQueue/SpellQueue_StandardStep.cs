using System.Collections.Generic;

namespace AEAssist.AI.Dancer.SpellQueue
{
    public class SpellQueue_StandardStep : IAISpellQueue
    {
        public List<IAISpellQueueSlot> SlotQueue { get; } = new List<IAISpellQueueSlot>()
        {
            new SpellQueueSlot_StandardDance(),
            new SpellQueueSlot_DanceStep(),
            new SpellQueueSlot_DanceStep(),
            new SpellQueueSlot_DanceFinish()
            
        };
    }
}