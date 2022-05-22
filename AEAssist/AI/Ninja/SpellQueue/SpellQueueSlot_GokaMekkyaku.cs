using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;

namespace AEAssist.AI.Ninja.SpellQueue
{
    public class SpellQueueSlot_GokaMekkyaku : IAISpellQueueSlot
    {
        public int Check(int index)
        {
            if (!Core.Me.HasAura(AurasDefine.Kassatsu) ||
                !SpellsDefine.Kassatsu.RecentlyUsed())
            {
                return -10;
            }
            return -4;
        }

        public void Fill(SpellQueueSlot slot)
        {
        }
    }
}