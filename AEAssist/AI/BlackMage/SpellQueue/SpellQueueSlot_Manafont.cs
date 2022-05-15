using AEAssist.Define;
using AEAssist.Helper;

namespace AEAssist.AI.BlackMage.SpellQueue
{
    public class SpellQueueSlot_Manafont : IAISpellQueueSlot
    {
        public int Check(int index)
        {
            return 0;
        }

        public void Fill(SpellQueueSlot slot)
        {
            slot.SetGCD(SpellsDefine.ManaFont,SpellTargetType.CurrTarget);
        }
    }
}