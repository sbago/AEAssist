using AEAssist.Define;

namespace AEAssist.AI.BlackMage.SpellQueue
{
    public class SpellQueueSlot_Fire4 : IAISpellQueueSlot
    {
        public int Check(int index)
        {
            // if (!BlackMageHelper.CanCastFire4())
            //     return -1;
            return -1;
        }

        public void Fill(SpellQueueSlot slot)
        {
            slot.GCDSpellId = SpellsDefine.Fire4;
        }
    }
}