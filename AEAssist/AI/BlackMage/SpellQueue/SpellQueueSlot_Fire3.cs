using AEAssist.Define;

namespace AEAssist.AI.BlackMage.SpellQueue
{
    public class SpellQueueSlot_Fire3 : IAISpellQueueSlot
    {
        public int Check(int index)
        {
            return 0;
        }

        public void Fill(SpellQueueSlot slot)
        {
            slot.SetGCD(SpellsDefine.Fire3,SpellTargetType.CurrTarget);
        }
    }
}