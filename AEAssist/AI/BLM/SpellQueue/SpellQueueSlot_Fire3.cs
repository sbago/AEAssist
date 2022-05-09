using AEAssist.Define;

namespace AEAssist.AI.BLM.SpellQueue
{
    public class SpellQueueSlot_Fire3 : IAISpellQueueSlot
    {
        public int Check(int index)
        {
            return 0;
        }

        public void Fill(SpellQueueSlot slot)
        {
            slot.GCDSpellId = SpellsDefine.Fire3;
        }
    }
}