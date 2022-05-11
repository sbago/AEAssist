using AEAssist.Define;
using ff14bot;
using ff14bot.Managers;

namespace AEAssist.AI.BlackMage.SpellQueue
{
    public class SpellQueueSlot_Despair : IAISpellQueueSlot
    {
        public int Check(int index)
        {
            if (Core.Me.CurrentMana < 800 || ActionResourceManager.BlackMage.AstralStacks <= 0)
                return -1;
            return 0;
        }

        public void Fill(SpellQueueSlot slot)
        {
            slot.GCDSpellId = SpellsDefine.Despair;
        }
    }
}