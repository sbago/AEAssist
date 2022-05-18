using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI.Dancer.SpellQueue
{
    public class SpellQueueSlot_StandardDance : IAISpellQueueSlot
    {
        public int Check(int index)
        {
            return 0;
        }

        public void Fill(SpellQueueSlot slot)
        {
            slot.SetGCD(SpellsDefine.StandardStep, SpellTargetType.Self);

        }
    }
}