using AEAssist.Define;
using AEAssist.Helper;

namespace AEAssist.AI.BlackMage.SpellQueue
{
    public class SpellQueueSlot_Fire1 : IAISpellQueueSlot
    {
        public int Check(int index)
        {
            return 0;
        }

        public void Fill(SpellQueueSlot slot)
        {
            slot.SetGCD(SpellsDefine.Fire,SpellTargetType.CurrTarget);
        }
    }
}